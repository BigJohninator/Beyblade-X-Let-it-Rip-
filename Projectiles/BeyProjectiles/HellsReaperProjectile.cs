using Humanizer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;

namespace LetItRip.Content.Projectiles.BeyProjectiles
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class HellsReaperProjectile : ModProjectile
	{
        
		// Store the target NPC using Projectile.ai[0]
		private NPC HomingTarget {
			get => Projectile.ai[0] == 0 ? null : Main.npc[(int)Projectile.ai[0] - 1];
			set {
				Projectile.ai[0] = value == null ? 0 : value.whoAmI + 1;
			}
		}

		public ref float DelayTimer => ref Projectile.ai[1];

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;

            Projectile.aiStyle = -1;

            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 5;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            DrawOffsetX = -23;
            DrawOriginOffsetY = -21;

            AIType = ProjectileID.Bullet;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           
            if (Projectile.penetrate <= 0)
            {
                SoundEngine.PlaySound(SoundID.Tink, Projectile.position);
                Projectile.Kill();
                return false;
            }

            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

            SoundEngine.PlaySound(SoundID.Tink, Projectile.position);

            if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }

            if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }
		public override void AI() {
             float rotatespeed = 0.75f * (float)Projectile.direction;
            Projectile.rotation += rotatespeed;
			float maxDetectRadius = 400f; // The maximum radius at which a projectile can detect a target

			// A short delay to homing behavior after being fired
			if (DelayTimer < 10) {
				DelayTimer += 1;
				return;
			}

			// First, we find a homing target if we don't have one
			if (HomingTarget == null) {
				HomingTarget = FindClosestNPC(maxDetectRadius);
			}

			// If we have a homing target, make sure it is still valid. If the NPC dies or moves away, we'll want to find a new target
			if (HomingTarget != null && !IsValidTarget(HomingTarget)) {
				HomingTarget = null;
			}

			// If we don't have a target, don't adjust trajectory
			if (HomingTarget == null)
				return;

			// If found, we rotate the projectile velocity in the direction of the target.
			// We only rotate by 3 degrees an update to give it a smooth trajectory. Increase the rotation speed here to make tighter turns
			float length = Projectile.velocity.Length();
			float targetAngle = Projectile.AngleTo(HomingTarget.Center);
			Projectile.velocity = Projectile.velocity.ToRotation().AngleTowards(targetAngle, MathHelper.ToRadians(10)).ToRotationVector2() * length;
			Projectile.rotation = Projectile.velocity.ToRotation();
		}

		// Finding the closest NPC to attack within maxDetectDistance range
		// If not found then returns null
		public NPC FindClosestNPC(float maxDetectDistance) {
			NPC closestNPC = null;

			// Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			// Loop through all NPCs
			foreach (var target in Main.ActiveNPCs) {
				// Check if NPC able to be targeted. 
				if (IsValidTarget(target)) {
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance) {
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}

		public bool IsValidTarget(NPC target) {
			// This method checks that the NPC is:
			// 1. active (alive)
			// 2. chaseable (e.g. not a cultist archer)
			// 3. max life bigger than 5 (e.g. not a critter)
			// 4. can take damage (e.g. moonlord core after all it's parts are downed)
			// 5. hostile (!friendly)
			// 6. not immortal (e.g. not a target dummy)
			// 7. doesn't have solid tiles blocking a line of sight between the projectile and NPC
			return target.CanBeChasedBy() && Collision.CanHit(Projectile.Center, 1, 1, target.position, target.width, target.height);
		}
	}
}