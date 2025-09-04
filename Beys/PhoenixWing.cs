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
	public class PhoenixWing : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.LetItRip.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 310;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<PhoenixWingProjectile>();
			Item.shootSpeed = 20f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FireFeather, 1);
			recipe.AddIngredient(ItemID.LightShard, 3);
			recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddIngredient<PhoenixFeather>(1);
			recipe.AddIngredient<EnhancedBeyCore>(1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			
		}
	}
}