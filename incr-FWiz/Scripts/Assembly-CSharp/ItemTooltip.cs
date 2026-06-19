using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : ObjectTooltip
{
	[SerializeField]
	private TextMeshProUGUI _title;

	private ItemType _itemType;

	[SerializeField]
	private Image _itemIcon;

	public override string ID => null;

	public override bool CanHandle(object obj)
	{
		return false;
	}

	public override bool CanWipe(object obj)
	{
		return false;
	}

	protected override bool DoHandle(object obj)
	{
		return false;
	}

	protected override bool DoWipe(object obj)
	{
		return false;
	}
}
