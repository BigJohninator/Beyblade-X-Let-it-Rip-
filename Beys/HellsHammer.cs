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
	public class HellsHammer : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.LetItRip.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<HellsHammerProjectile>();
			Item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddIngredient<HellsChain>(1);
			recipe.AddIngredient<UniqueBeyCore>(1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			
		}
	}
}