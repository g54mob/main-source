public class BiomeBossHydraStatueUI : SimpleCraftingUI
{
	protected override void Awake()
	{
		recipeUI.Init();
		root.SetActive(value: false);
	}
}
