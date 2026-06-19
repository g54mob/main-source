using UnityEngine;

public class SimpleCraftingUI : CraftingUIBase
{
	private bool inited;

	protected virtual void Awake()
	{
		Init();
	}

	public void Init()
	{
		if (!inited)
		{
			inited = true;
			recipeUI.Init();
			root.SetActive(value: false);
			title.Init();
		}
	}

	public override void ShowCraftingUI()
	{
		base.ShowCraftingUI();
		recipeUI.windowIndex = windowIndex;
		recipeUI.ShowContainerUI();
		UpdateAllCraftingUI();
	}

	public override void UpdateAllCraftingUI(bool autoFillMaterials = false)
	{
		for (int i = 0; i < recipeUI.totalVisibleSlots; i++)
		{
			recipeUI.OnSlotUpdated(i);
		}
	}

	public override UIelement GetClosestUIElement(Vector3 worldPosition)
	{
		return recipeUI.GetClosestUIElement(worldPosition);
	}
}
