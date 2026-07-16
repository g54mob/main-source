public static class ShopCategoryExtensions
{
	public static void SetCostColor(this ShopCategory category, float scrap)
	{
		category.costText.color = ((category.shopCost > scrap) ? ColorUtils.HexToColor("FF0800") : ColorUtils.HexToColor("3BFF00"));
	}
}
