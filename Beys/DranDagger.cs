using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LetItRip.Content.Projectiles.BeyProjectiles;
using LetItRip.Content.Items.BasicItems;

namespace LetItRip.Content.Items.Beys
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class DranDagger : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.LetItRip.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DranDaggerProjectile>();
			Item.shootSpeed = 12f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ItemID.ShadowScale, 10);
			recipe.AddIngredient<BeyCore>(1);
            recipe.AddIngredient<DranSword>(1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.TissueSample, 10);
			recipe2.AddIngredient<BeyCore>(1);
            recipe2.AddIngredient<DranSword>(1);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}