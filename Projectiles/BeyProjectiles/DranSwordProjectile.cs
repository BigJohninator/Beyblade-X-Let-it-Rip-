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
	public class DranSwordProjectile : ModProjectile
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.LetItRip.hjson' file.
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; 
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;

            Projectile.aiStyle = -1;

            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
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
            Projectile.penetrate--;
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
		 public override void AI()
        {
             Projectile.ai[0]++;
            float rotatespeed = 0.75f * (float)Projectile.direction;
            Projectile.rotation += rotatespeed;
        }
	}
}