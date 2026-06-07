using System.Collections.Generic;
using UnityEngine;

public class ResearchPanel : ProductionListPanel
{
	public GameObject researchListItemPrefab;

	private readonly Dictionary<BuildObjectAvailability, SectionHeader> researchHeaders = new Dictionary<BuildObjectAvailability, SectionHeader>(new AvailabilityComparer());

	public SingleBuildingHeader singleBuildingHeader;

	public SearchHeader controlsHeader;

	private List<ResearchState> reusableResearchList = new List<ResearchState>();

	public override void Initialize()
	{
		base.Initialize();
		primaryLayoutManager.areChildRecordsPersistent = true;
		controlsHeader.Initialize();
		controlsHeader.purchaseAllButton.AddPointerClickTrigger(OnPurchaseAllPressed);
		controlsHeader.searchChangeDelegate = OnSearchTextChanged;
		singleBuildingHeader.Initialize(this);
	}

	public override void SetDisplayedTown(Town t)
	{
		base.SetDisplayedTown(t);
		singleBuildingHeader.displayedTown = t;
	}

	public override void Show()
	{
		base.Show();
		MenuPanel.gm.hasOpenedResearchPanel = true;
		MenuPanel.m.navigationPanel.researchButton.isSelected = true;
	}

	public override void Hide()
	{
		base.Hide();
		MenuPanel.m.navigationPanel.researchButton.isSelected = false;
	}

	public override void UpdatePauseDisplay()
	{
		base.UpdatePauseDisplay();
		singleBuildingHeader.UpdatePauseDisplay();
	}

	public override void UpdateAutoClaimDisplay()
	{
		base.UpdateAutoClaimDisplay();
		singleBuildingHeader.UpdateAutoClaimDisplay();
	}

	public override void UpdateAutoAssignDisplay()
	{
		base.UpdateAutoAssignDisplay();
		singleBuildingHeader.UpdateAutoAssignDisplay();
	}

	public override void UpdatePriorityDisplay()
	{
		base.UpdatePriorityDisplay();
		singleBuildingHeader.UpdatePriorityDisplay();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		singleBuildingHeader.UpdateDynamicDisplay();
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		if (HasResearchToClaim())
		{
			controlsHeader.purchaseAllButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		else
		{
			controlsHeader.purchaseAllButton.buttonState = CustomButtonState.Disabled;
		}
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		singleBuildingHeader.ReloadLabels();
		foreach (KeyValuePair<BuildObjectAvailability, SectionHeader> researchHeader in researchHeaders)
		{
			researchHeader.Value.primaryLabel.text = TextDisplay.LocalizationKeyforAvailability(researchHeader.Key).Localized();
		}
		controlsHeader.purchaseAllButton.label.text = "ClaimAll".Localized();
	}

	protected override void ApplyStateAnimations()
	{
		foreach (ResearchListItem value in visibleListItems.Values)
		{
			value.manualResearchButton.AnimateInstant();
		}
	}

	public override void CreateItems()
	{
		base.CreateItems();
		GetCategoryHeader(BuildObjectAvailability.Available);
		GetCategoryHeader(BuildObjectAvailability.Locked);
		GetCategoryHeader(BuildObjectAvailability.Completed);
	}

	private void GetCategoryHeader(BuildObjectAvailability category)
	{
		string localizationKey = TextDisplay.LocalizationKeyforAvailability(category);
		SectionHeader sectionHeader = MenuManager.InstantiatedSimpleSectionHeader(layoutGroup.transform, localizationKey);
		researchHeaders[category] = sectionHeader;
		primaryLayoutManager.AddChildManagerWithHeight(sectionHeader.layoutManager, EntityId.FromGeneric((int)category), simpleHeaderHeight);
		sectionHeader.parentPanel = this;
	}

	public void SetDefaultHidden()
	{
		headerCollapseManager.SetMinimized(2);
		headerCollapseManager.SetMinimized(3);
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		singleBuildingHeader.LoadState(displayedTown.buildings[BuildingType.School]);
		AddItemsInCategory(BuildObjectAvailability.Available);
		AddItemsInCategory(BuildObjectAvailability.Locked);
		AddItemsInCategory(BuildObjectAvailability.Completed);
	}

	private void AddItemsInCategory(BuildObjectAvailability availability)
	{
		if (!researchHeaders.TryGetValue(availability, out var value))
		{
			return;
		}
		foreach (KeyValuePair<ResearchType, ResearchState> item in displayedTown.research)
		{
			if (item.Value.availability == availability)
			{
				value.layoutManager.AddItemWithHeight(item.Value, itemHeight);
			}
		}
	}

	protected override void OnBecameAvailableDuringGame()
	{
		base.OnBecameAvailableDuringGame();
		SetDefaultHidden();
	}

	public override bool ShouldBeAvailable()
	{
		return GameManager.IsGlobalQuestComplete(QuestType.SchoolForResearchPanel);
	}

	protected override MonoBehaviour CreateListItemForPool()
	{
		return CreateCommonListItemForPool(researchListItemPrefab);
	}

	protected override void AssignKeyToItem(object key, MonoBehaviour item)
	{
		if (key is ResearchState rs && item is ResearchListItem researchListItem)
		{
			researchListItem.LoadState(rs);
			researchListItem.OnStateAssignmentChanged();
		}
	}

	public void JumpToResearch(ResearchType r)
	{
		if (displayedTown.research.TryGetValue(r, out var value))
		{
			JumpToState(value);
		}
	}

	public void JumpToAndSelectResearch(ResearchState r)
	{
		JumpToState(r);
	}

	public override void JumpToState(StateManager sm)
	{
		Show();
		QueueJumpToItemWithLinkedObject(sm);
	}

	private bool HasResearchToClaim()
	{
		if (displayedTown.hasResearchToClaim)
		{
			foreach (ResearchState value in displayedTown.research.Values)
			{
				if (PassesFilter(value) && value.IsAvailable() && value.isReadyToClaim)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool PassesFilter(ResearchState rs)
	{
		if (controlsHeader.searchField.text.Length > 0)
		{
			string text = TextDisplay.LabelForResearch(rs.type);
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			return LocalizationManager.LocalizedIndexOf(text, controlsHeader.searchField.text) >= 0;
		}
		return true;
	}

	protected override bool ShouldItemBeValid(object obj)
	{
		if (obj is ResearchState rs)
		{
			return PassesFilter(rs);
		}
		return false;
	}

	private void OnPurchaseAllPressed()
	{
		if (controlsHeader.purchaseAllButton.shouldIgnoreAction)
		{
			return;
		}
		MenuPanel.gm.BeginTrackingUnlocks();
		reusableResearchList.Clear();
		foreach (ResearchState value in displayedTown.research.Values)
		{
			if (PassesFilter(value) && value.IsAvailable() && value.isReadyToClaim)
			{
				value.Claim();
			}
		}
		ReloadLabels();
		MenuPanel.gm.ProcessMetadataQueue();
		MenuPanel.gm.EndTrackingUnlocks();
	}

	public void OnSearchTextChanged()
	{
		isItemAvailabilityStale = true;
	}

	protected override void ClearFilters()
	{
		base.ClearFilters();
		controlsHeader.OnCancelSearchPressed();
	}

	public void DeselectIfVisible(ResearchState state)
	{
		if (visibleListItems.TryGetValue(state, out var value) && value is ResearchListItem { isSelected: not false } researchListItem)
		{
			researchListItem.RemoveSelection();
		}
	}
}
