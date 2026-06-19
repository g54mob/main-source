using UnityEngine;

public class UnlockShopUIItem : AbstractUnlockShopUIItem
{
	[SerializeField]
	private BuildingTooltipTrigger _tooltipTrigger;

	[SerializeField]
	private CostGroupUI _costGroupUI;

	[SerializeField]
	private GameObject _contentLockSymbol;

	[SerializeField]
	private ContentLockHoverHandler _contentLockHoverHandler;

	public override void Initiate(UnlockShopCanvasUI parent, ShopItem shopItem)
	{
	}

	protected override void OnClick()
	{
	}
}
