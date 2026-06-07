using System.Collections.Generic;
using UnityEngine;

public class ProductionListPanel : MenuListPanel
{
	protected readonly Dictionary<BuildingType, CraftingSectionHeader> buildingHeaders = new Dictionary<BuildingType, CraftingSectionHeader>(new BuildingEqualityComparer());

	public override void Initialize()
	{
		base.Initialize();
		headerCollapseManager = new HeaderCollapseManager();
		RemoveAutoLayout();
	}

	public override void UpdateWorkerCount()
	{
		base.UpdateWorkerCount();
		foreach (KeyValuePair<BuildingType, CraftingSectionHeader> buildingHeader in buildingHeaders)
		{
			if (buildingHeader.Value.displayedBuilding != null)
			{
				buildingHeader.Value.UpdateProductionCapacityLabel();
			}
		}
	}

	public override void UpdateBuildingData()
	{
		base.UpdateBuildingData();
		foreach (CraftingSectionHeader value in buildingHeaders.Values)
		{
			if (value.gameObject.activeInHierarchy && value.displayedBuilding != null)
			{
				value.UpdateBuildingData();
			}
		}
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		foreach (KeyValuePair<BuildingType, CraftingSectionHeader> buildingHeader in buildingHeaders)
		{
			buildingHeader.Value.ReloadLabels();
		}
	}

	public void ClearAllAlerts()
	{
		foreach (CommonListItem value in visibleListItems.Values)
		{
			value.ClearAlertState();
		}
	}

	protected CraftingSectionHeader HeaderForBuilding(BuildingType t)
	{
		if (buildingHeaders.TryGetValue(t, out var value))
		{
			return value;
		}
		return null;
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		foreach (KeyValuePair<BuildingType, CraftingSectionHeader> buildingHeader in buildingHeaders)
		{
			buildingHeader.Value.UpdatePauseDisplay();
			if (displayedTown.buildings.TryGetValue(buildingHeader.Key, out var value))
			{
				buildingHeader.Value.LoadState(value);
				continue;
			}
			buildingHeader.Value.displayedBuilding = null;
			buildingHeader.Value.layoutManager.linkedObject = null;
		}
	}

	protected CraftingSectionHeader AddBuildingHeader(BuildingType t, LayoutManager parentLayoutManager)
	{
		CraftingSectionHeader craftingSectionHeader = MenuManager.InstantiatedSectionHeader(layoutGroup.transform);
		buildingHeaders[t] = craftingSectionHeader;
		parentLayoutManager.AddChildManagerWithHeight(craftingSectionHeader.layoutManager, EntityId.FromBuilding(t), 46f);
		craftingSectionHeader.parentPanel = this;
		return craftingSectionHeader;
	}

	public override void UpdateStaticDisplay()
	{
		base.UpdateStaticDisplay();
		UpdateBuildingData();
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		foreach (KeyValuePair<BuildingType, CraftingSectionHeader> buildingHeader in buildingHeaders)
		{
			if (buildingHeader.Value.gameObject.activeInHierarchy)
			{
				buildingHeader.Value.UpdateSimulationDisplay();
			}
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		foreach (KeyValuePair<BuildingType, CraftingSectionHeader> buildingHeader in buildingHeaders)
		{
			if (buildingHeader.Value.gameObject.activeInHierarchy)
			{
				buildingHeader.Value.UpdateDynamicDisplay();
			}
		}
	}

	public override void ResetPanel()
	{
		base.ResetPanel();
		headerCollapseManager.Reset();
	}

	public override void UpdateAutoClaimDisplay()
	{
		base.UpdateAutoClaimDisplay();
		foreach (CraftingSectionHeader value in buildingHeaders.Values)
		{
			value.UpdateAutoClaimDisplay();
		}
	}

	public override void UpdateAutoAssignDisplay()
	{
		base.UpdateAutoAssignDisplay();
		foreach (CraftingSectionHeader value in buildingHeaders.Values)
		{
			value.UpdateAutoAssignDisplay();
		}
	}

	public override void UpdatePauseDisplay()
	{
		base.UpdatePauseDisplay();
		foreach (CraftingSectionHeader value in buildingHeaders.Values)
		{
			value.UpdatePauseDisplay();
		}
	}

	public override void UpdateProductionLimitDisplay()
	{
		base.UpdateProductionLimitDisplay();
		foreach (CraftingSectionHeader value in buildingHeaders.Values)
		{
			value.UpdateProductionLimitDisplay();
		}
		foreach (CommonListItem value2 in visibleListItems.Values)
		{
			value2.ReloadProductionLimitState();
		}
	}

	public override void UpdatePriorityDisplay()
	{
		base.UpdatePriorityDisplay();
		foreach (CraftingSectionHeader value in buildingHeaders.Values)
		{
			value.UpdatePriorityDisplay();
		}
		foreach (CommonListItem value2 in visibleListItems.Values)
		{
			value2.ReloadPriorityState();
		}
	}

	public virtual void UpdateHeaderAvailability()
	{
		foreach (KeyValuePair<BuildingType, CraftingSectionHeader> buildingHeader in buildingHeaders)
		{
			CraftingSectionHeader value = buildingHeader.Value;
			bool isValid = value.layoutManager.isValid;
			bool isValid2 = value.layoutManager.isValid;
			value.layoutManager.isValid = isValid2;
			value.gameObject.SetActive(isValid2 && !IsMinimized(value.layoutManager.parentManager) && !value.layoutManager.isSuppressed);
			if (isValid2)
			{
				value.UpdateRegionAvailability();
				value.UpdateMinimizationSprite();
				value.collapseButtonImage.gameObject.SetActive(value.layoutManager.hasValidChildren || value.layoutManager.isRoot);
				bool flag = value.layoutManager.parentManager != null && !value.layoutManager.parentManager.isSuppressed;
				value.SetIndentLevel(flag ? 1 : 0);
			}
			if (!isValid && isValid2)
			{
				value.UpdateBuildingData();
			}
		}
	}

	protected override void AssignParentHeader(LayoutManager manager, MonoBehaviour item)
	{
		if (!(item is CommonListItem commonListItem))
		{
			return;
		}
		foreach (CraftingSectionHeader value in buildingHeaders.Values)
		{
			if (value.layoutManager == manager)
			{
				commonListItem.parentHeader = value;
				break;
			}
		}
	}

	public void AnimateHeader(BuildingType t)
	{
		if (buildingHeaders.TryGetValue(t, out var value))
		{
			value.AnimateTextFlash();
		}
	}

	public virtual void JumpToState(StateManager sm)
	{
	}

	public void ReloadRepeatsForBuilding(BuildingType t)
	{
		foreach (CommonListItem value in visibleListItems.Values)
		{
			value.ReloadRepeatState();
		}
	}

	public void SetMinimizationStateForAllBuildings(bool nextState)
	{
		foreach (CraftingSectionHeader value in buildingHeaders.Values)
		{
			activeHeaderCollapseManager.SetMinimized(value.layoutManager.minimizationKey, nextState);
		}
	}
}
