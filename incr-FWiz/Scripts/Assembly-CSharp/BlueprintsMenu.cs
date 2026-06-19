using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintsMenu : MonoBehaviour
{
	private BuildingActionMode _buildMode;

	[SerializeField]
	private BlueprintsMenuOptionUI _uiBlueprintOption;

	[SerializeField]
	private Transform _uiBlueprintOptionsParent;

	private List<BlueprintsMenuOptionUI> _uiOptions;

	private BlueprintsMenuOptionUI _selectedOption;

	private BlueprintsMenuOptionUI _hoveredOption;

	private BuildingAsset _tooltipBuilding;

	[SerializeField]
	private GridLayoutGroup _gridLayoutGroup;

	[SerializeField]
	private int _gridColumneCount => 0;

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void Hide()
	{
	}

	public void Show()
	{
	}

	public void UpdateSelection(int index)
	{
	}

	public void EvaluateTooltip()
	{
	}

	public void SetTooltipBuilding(BuildingAsset asset)
	{
	}

	public void OnHover(BlueprintsMenuOptionUI menuOption)
	{
	}

	public void OnHoverEnd(BlueprintsMenuOptionUI menuOption)
	{
	}

	public void OnSelectOption(BlueprintsMenuOptionUI menuOption)
	{
	}
}
