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
	public class FoxBrushProjectile : ModProjectile
	{
        
		
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
            Projectile.penetrate = -1;
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
			float maxDetectRadius = 400f;
			
			if (DelayTimer < 10) {
				DelayTimer += 1;
				return;
			}

		
			if (HomingTarget == null) {
				HomingTarget = FindClosestNPC(maxDetectRadius);
			}

			
			if (HomingTarget != null && !IsValidTarget(HomingTarget)) {
				HomingTarget = null;
			}

		
			if (HomingTarget == null)
				return;

			
			float length = Projectile.velocity.Length();
			float targetAngle = Projectile.AngleTo(HomingTarget.Center);
			Projectile.velocity = Projectile.velocity.ToRotation().AngleTowards(targetAngle, MathHelper.ToRadians(20)).ToRotationVector2() * length;
			Projectile.rotation = Projectile.velocity.ToRotation();
		}

		
		public NPC FindClosestNPC(float maxDetectDistance) {
			NPC closestNPC = null;

			
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			
			foreach (var target in Main.ActiveNPCs) {
			
				if (IsValidTarget(target)) {
					
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					if (sqrDistanceToTarget < sqrMaxDetectDistance) {
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}

		public bool IsValidTarget(NPC target) {
			
			return target.CanBeChasedBy() && Collision.CanHit(Projectile.Center, 1, 1, target.position, target.width, target.height);
		}
	}
}