using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestsPanel : MenuListPanel, IPointerDownHandler, IEventSystemHandler
{
	public GameObject questListItemPrefab;

	public MenuButton headerNavigationButton;

	public MenuButton headerButton;

	private readonly Dictionary<QuestGroup, SectionHeader> headers = new Dictionary<QuestGroup, SectionHeader>(new QuestGroupingEqualityComparer());

	public LabelButton claimAllButton;

	public RectTransform claimButtonRegion;

	[NonSerialized]
	public bool targetHeaderState;

	private bool displayedHeaderState;

	public GameObject headerRegion;

	public Image maskImage;

	public Image collapseButtonImage;

	[NonSerialized]
	public bool isMinimized;

	public override void Show()
	{
		base.Show();
		if (panelType == MenuPanelType.QuestsPopup)
		{
			MenuPanel.m.questsPanel.headerNavigationButton.isSelected = true;
		}
	}

	public override void Hide()
	{
		base.Hide();
		if (panelType == MenuPanelType.QuestsPopup)
		{
			MenuPanel.m.questsPanel.headerNavigationButton.isSelected = false;
		}
	}

	public override bool IsFixedPosition()
	{
		return false;
	}

	public override void Initialize()
	{
		base.Initialize();
		RemoveAutoLayout();
		primaryLayoutManager.areChildRecordsPersistent = true;
		headerCollapseManager = new HeaderCollapseManager();
		headerNavigationButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.Quests);
		if (panelType == MenuPanelType.Quests)
		{
			claimButtonRegion.SetRight(3f);
			if (null != headerNavigationButton)
			{
				headerNavigationButton.InitializeButton();
				headerNavigationButton.AddPointerClickTrigger(MenuManager.Instance.OnQuestsNavigationPressed);
			}
			headerButton.InitializeButton();
			headerButton.AddPointerClickTrigger(OnHeaderPressed);
			headerButton.buttonState = CustomButtonState.Background;
			if (header.TryGetComponent<Image>(out var component))
			{
				component.raycastTarget = false;
				component.enabled = false;
			}
			panelBackgroundImage.enabled = false;
			if (scrollRect.TryGetComponent<Image>(out var component2))
			{
				component2.enabled = true;
			}
			DraggableBorder componentInChildren = GetComponentInChildren<DraggableBorder>();
			if (null != componentInChildren)
			{
				UnityEngine.Object.Destroy(componentInChildren.gameObject);
			}
			header.SetFixed(nextState: true);
		}
		else
		{
			header.SetFixed(nextState: false);
			headerButton.gameObject.SetActive(value: false);
			((RectTransform)header.transform).SetHeight(40f);
			collapseButtonImage.gameObject.SetActive(value: false);
			((RectTransform)headerNavigationButton.transform).SetLeft(3f);
			headerNavigationButton.GetComponent<Image>().enabled = false;
		}
	}

	public override void ResetPanel()
	{
		base.ResetPanel();
		isMinimized = false;
		SetHeaderVisible(nextState: false);
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		foreach (KeyValuePair<QuestGroup, SectionHeader> header in headers)
		{
			header.Value.ReloadLabels();
		}
		claimAllButton.label.text = "ClaimAll".Localized();
	}

	public void UpdateHeaderAvailability()
	{
		int num = 0;
		foreach (SectionHeader value in headers.Values)
		{
			if (value.layoutManager.isValid)
			{
				num++;
			}
		}
		bool flag = panelType == MenuPanelType.QuestsPopup;
		foreach (SectionHeader value2 in headers.Values)
		{
			value2.layoutManager.SetSuppressedFromRoot(!flag);
			value2.gameObject.SetActive(value2.layoutManager.isValid && flag);
		}
	}

	public override void ExpandAllVisible()
	{
		base.ExpandAllVisible();
		foreach (SectionHeader value in headers.Values)
		{
			TryExpandHeader(value);
		}
	}

	private void GetCategoryHeader(QuestGroup questGroup)
	{
		string localizationKey = TextDisplay.LocalizationKeyForQuestGrouping(questGroup);
		SectionHeader sectionHeader = MenuManager.InstantiatedSimpleSectionHeader(layoutGroup.transform, localizationKey);
		headers[questGroup] = sectionHeader;
		primaryLayoutManager.AddChildManagerWithHeight(sectionHeader.layoutManager, EntityId.FromGeneric((int)questGroup), 36f);
		sectionHeader.parentPanel = this;
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (panelType == MenuPanelType.Quests)
		{
			if (isMinimized && MenuPanel.gm.numQuestsReadyToClaim >= 1)
			{
				claimAllButton.gameObject.SetActive(value: true);
				claimAllButton.buttonState = CustomButtonState.BlueFlashing;
			}
			else if (MenuPanel.gm.numQuestsReadyToClaim >= 2)
			{
				claimAllButton.gameObject.SetActive(value: true);
				claimAllButton.buttonState = CustomButtonState.BlueFlashing;
			}
			else
			{
				claimAllButton.gameObject.SetActive(value: false);
			}
		}
		else if (MenuPanel.gm.numQuestsReadyToClaim >= 1)
		{
			claimAllButton.buttonState = CustomButtonState.BlueFlashing;
		}
		else
		{
			claimAllButton.buttonState = CustomButtonState.Disabled;
		}
		if (targetHeaderState != displayedHeaderState)
		{
			SetHeaderVisible(targetHeaderState);
		}
	}

	private void OnClaimAllPressed()
	{
		if (!claimAllButton.shouldIgnoreAction)
		{
			MenuPanel.gm.CompleteAllQuests();
		}
	}

	public void SetHeaderVisible(bool nextState)
	{
	}

	public override void CreateItems()
	{
		base.CreateItems();
		GetCategoryHeader(QuestGroup.Completed);
		GetCategoryHeader(QuestGroup.Primary);
		GetCategoryHeader(QuestGroup.Recipe);
		claimAllButton.AddPointerClickTrigger(OnClaimAllPressed);
	}

	private void CreateQuestItem(Quest q)
	{
		QuestGroup questGroup = q.questGroup;
		if (q.IsReadyToClaim())
		{
			questGroup = QuestGroup.Completed;
		}
		if (questGroup != QuestGroup.Upgrade && headers.TryGetValue(questGroup, out var value))
		{
			int count = q.completionRequirement.requirements.Count;
			float num = 4f;
			float num2 = 3f;
			float layoutHeight = 8f + num + 40f * (float)count + num2 * (float)(count - 1);
			q.layoutHeight = layoutHeight;
			float num3 = 4f;
			value.layoutManager.AddItemWithHeight(q, q.layoutHeight + num3);
		}
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		foreach (Quest value in MenuPanel.gm.globalQuests.Values)
		{
			if (value.availability == BuildObjectAvailability.Available && value.IsReadyToClaim())
			{
				CreateQuestItem(value);
			}
		}
		foreach (Quest value2 in MenuPanel.gm.globalQuests.Values)
		{
			if (value2.availability == BuildObjectAvailability.Available && !value2.IsReadyToClaim())
			{
				CreateQuestItem(value2);
			}
		}
	}

	protected override void UpdateItemAvailability()
	{
		base.UpdateItemAvailability();
		maskImage.enabled = MenuPanel.gm.tutorialQuestType == QuestType.None;
		targetHeaderState = false;
	}

	protected override bool ShouldItemBeValid(object obj)
	{
		if (obj is Quest quest)
		{
			return quest.availability == BuildObjectAvailability.Available;
		}
		return false;
	}

	protected override bool ShouldLayoutGroupBeValid(LayoutManager layoutManager)
	{
		return layoutManager.hasValidChildren;
	}

	protected override MonoBehaviour CreateListItemForPool()
	{
		QuestListItem component = MenuManager.GetMenuObject(questListItemPrefab, layoutGroup.transform).GetComponent<QuestListItem>();
		component.Initialize();
		return component;
	}

	protected override void AssignKeyToItem(object key, MonoBehaviour item)
	{
		if (item is QuestListItem questListItem && key is Quest q)
		{
			questListItem.LoadQuest(q);
			questListItem.OnStateAssignmentChanged();
		}
	}

	public override bool ShouldBeAvailable()
	{
		return true;
	}

	public bool QueueJumpToQuest(QuestType t)
	{
		if (Crafting.questCache.TryGetValue(t, out var _) && MenuPanel.gm.globalQuests.TryGetValue(t, out var value2))
		{
			return QueueJumpToQuest(value2);
		}
		return false;
	}

	public bool QueueJumpToQuest(Quest quest)
	{
		if (quest.availability == BuildObjectAvailability.Available)
		{
			QueueJumpToItemWithLinkedObject(quest);
			return true;
		}
		return MenuManager.Instance.NavigateToRequirementRecursively(quest.displayRequirement.requirements);
	}

	public void OnHeaderPressed()
	{
		isMinimized = !isMinimized;
		MenuPanel.m.UpdateLeftPanelLayouts();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
