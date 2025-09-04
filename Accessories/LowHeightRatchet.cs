using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using LetItRip.Content.Projectiles.BeyProjectiles;
using LetItRip.Content.Items.BasicItems;

namespace LetItRip.Content.Items.Accessories
{
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class LowHeightRatchet : ModItem
	{
		

		public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.LetItRip.hjson' file.
		public override void SetDefaults()
		{

			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Generic) += 0.05f;
			player.GetArmorPenetration(DamageClass.Generic) += 0.2f;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TitaniumBar, 15);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.SharkFin, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.AdamantiteBar, 15);
			recipe2.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe2.AddIngredient(ItemID.SharkFin, 5);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.Register();
		}
	}
}