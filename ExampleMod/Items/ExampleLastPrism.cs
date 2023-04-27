using ExampleMod.Projectiles;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExampleMod.Items
{
    public class ExampleLastPrism : ModItem
    {
        // You can use a vanilla texture for your Item by using the format: "Terraria/Item_<Item ID>".
        public static Color OverrideColor = new Color(122, 173, 255);

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Example Last Prism");
            Tooltip.SetDefault(@"A slightly different laser-firing Prism
Ignores NPC immunity frames and fires 10 beams at once instead of 6.");
        }

        public override void SetDefaults()
        {
            // Start by using CloneDefaults to clone all the basic Item properties from the vanilla Last Prism.
            // For example, this copies sprite size, use style, sell price, and the Item being a magic weapon.
            Item.CloneDefaults(ItemID.LastPrism);
            Item.mana = 4;
            Item.damage = 42;
            Item.shoot = ProjectileType<ExampleLastPrismHoldout>();
            Item.shootSpeed = 30f;

            // Change the Item's draw color so that it is visually distinct from the vanilla Last Prism.
            Item.color = OverrideColor;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.Benches);
            recipe.Register();
            
        }

        // Because this weapon fires a holdout projectile, it needs to block usage if its projectile already exists.
        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ProjectileType<ExampleLastPrismHoldout>()] <= 0;
    }
}