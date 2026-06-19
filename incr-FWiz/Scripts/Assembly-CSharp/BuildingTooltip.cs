using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTooltip : ObjectTooltip
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private TextMeshProUGUI _description;

	[SerializeField]
	private CostGroupUI _uiCostGroup;

	private BuildingAsset _buildingAsset;

	[SerializeField]
	private bool _showItemTootlips;

	[SerializeField]
	private Transform _supportingTooltipsParent;

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
