using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeTooltip : ObjectTooltip
{
	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private CostGroupUI _costGroupUI;

	[SerializeField]
	private Image _itemIcon;

	private Recipe _recipe;

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
