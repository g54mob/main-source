using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class MenuListPanel : MenuPanel
{
	public ScrollRect scrollRect;

	public LayoutGroup layoutGroup;

	[NonSerialized]
	public SingleSelectionManager selectionManager;

	[SerializeField]
	protected LayoutManager primaryLayoutManager;

	protected readonly Dictionary<object, MonoBehaviour> visibleListItems = new Dictionary<object, MonoBehaviour>();

	public IObjectPool<MonoBehaviour> listItemPool;

	private RectTransform layoutRect;

	private RectTransform viewportRect;

	public HeaderCollapseManager headerCollapseManager;

	public HeaderCollapseManager activeHeaderCollapseManager;

	protected float itemHeight = 50f;

	protected float headerHeight = 46f;

	protected float simpleHeaderHeight = 36f;

	protected const float indentMargin = 26f;

	private CommonListItem queuedJumpItem;

	private LayoutItem queuedLayoutItem;

	private int queuedJumpCountdown;

	protected bool flagAutoExpandVisible;

	protected bool usePersistentRows;

	private const bool disablePooledObjects = false;

	[NonSerialized]
	public bool arePanelCostsStale;

	[NonSerialized]
	public bool isCapacityAvailableStale;

	protected const bool disableHeaderGameObjects = true;

	private static int debugIndentLevel;

	public bool isBuildingDataStale;

	public override void Show()
	{
		base.Show();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.UpdateAlertState();
			}
		}
	}

	public override void Hide()
	{
		bool num = IsVisible();
		selectionManager?.ClearSelection();
		base.Hide();
		if (!num)
		{
			return;
		}
		foreach (LayoutItem childItem in primaryLayoutManager.childItems)
		{
			if (!(childItem is LayoutManager layoutManager))
			{
				continue;
			}
			foreach (LayoutItem childItem2 in layoutManager.childItems)
			{
				if (childItem2.linkedObject is StateManager stateManager)
				{
					stateManager.isInAlertState = false;
				}
			}
		}
	}

	public override void Initialize()
	{
		base.Initialize();
		primaryLayoutManager = new LayoutManager((RectTransform)layoutGroup.transform);
		if (null != scrollRect)
		{
			scrollRect.scrollSensitivity = 40f;
			scrollRect.verticalScrollbarSpacing = 1f;
			scrollRect.onValueChanged.AddListener(OnScrolled);
			viewportRect = scrollRect.viewport;
		}
		selectionManager = new SingleSelectionManager(OnSelectionChangedByManager);
		layoutRect = (RectTransform)layoutGroup.transform;
		if (panelType != MenuPanelType.CombinedProduction)
		{
			listItemPool = new ObjectPool<MonoBehaviour>(CreateListItemForPool, OnPooledObjectGet, OnPooledObjectReleased);
		}
	}

	public override void ResetPanel()
	{
		base.ResetPanel();
		selectionManager?.ClearSelection();
	}

	public override void FlagAllStaticDataStale()
	{
		base.FlagAllStaticDataStale();
		isBuildingDataStale = true;
		isCapacityAvailableStale = true;
	}

	private void OnScrolled(Vector2 value)
	{
		CalculateListVisibility();
	}

	protected virtual MonoBehaviour CreateListItemForPool()
	{
		UnityEngine.Debug.LogError("NEED TO IMPLEMENT CreateListItemForPool");
		return null;
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		primaryLayoutManager.ClearRecursively();
		foreach (KeyValuePair<object, MonoBehaviour> visibleListItem in visibleListItems)
		{
			if (listItemPool == null)
			{
				if (visibleListItem.Value is CommonListItem { parentPool: not null } commonListItem)
				{
					commonListItem.parentPool.Release(commonListItem);
				}
			}
			else
			{
				listItemPool.Release(visibleListItem.Value);
			}
		}
		visibleListItems.Clear();
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.ReloadLabelParent();
			}
			else if (value is InventoryListItem inventoryListItem)
			{
				inventoryListItem.ReloadLabels();
			}
			else if (value is QuestListItem questListItem)
			{
				questListItem.ReloadLabel();
			}
			else if (value is WorldListItem worldListItem)
			{
				worldListItem.ReloadLabels();
			}
			else if (value is UpgradeListItem upgradeListItem)
			{
				upgradeListItem.ReloadLabels();
			}
			else if (value is LogListItem logListItem)
			{
				logListItem.ReloadLabels();
			}
		}
	}

	public void Clear()
	{
		foreach (Transform item in layoutGroup.transform)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		primaryLayoutManager.ClearRecursively();
	}

	public override void UpdateStaticDisplay()
	{
		base.UpdateStaticDisplay();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.UpdateStaticDisplay();
			}
			else if (value is QuestListItem questListItem)
			{
				questListItem.UpdateStaticDisplay();
			}
		}
		UpdatePanelCosts();
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is InventoryListItem inventoryListItem)
			{
				inventoryListItem.UpdateSimulationDisplay();
			}
			else if (value is CommonListItem commonListItem)
			{
				commonListItem.UpdateSimulationDisplay();
			}
			else if (value is QuestListItem questListItem)
			{
				questListItem.UpdateSimulationDisplay();
			}
			else if (value is UpgradeListItem upgradeListItem)
			{
				upgradeListItem.UpdateSimulationDisplay();
			}
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (null != queuedJumpItem)
		{
			if (queuedJumpCountdown > 0)
			{
				queuedJumpCountdown--;
			}
			else
			{
				JumpToListItem(queuedJumpItem);
				queuedJumpItem = null;
			}
		}
		if (queuedLayoutItem != null)
		{
			if (queuedJumpCountdown > 0)
			{
				queuedJumpCountdown--;
			}
			else
			{
				JumpToListItem(queuedLayoutItem);
				queuedLayoutItem = null;
			}
		}
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.UpdateDynamicDisplay();
			}
			else if (value is UpgradeListItem upgradeListItem)
			{
				upgradeListItem.UpdateDynamicDisplay();
			}
			else if (value is QuestListItem questListItem)
			{
				questListItem.UpdateDynamicDisplay();
			}
			else
			{
				_ = value is FileListItem;
			}
		}
		if (isBuildingDataStale)
		{
			UpdateBuildingData();
		}
		if (isCapacityAvailableStale)
		{
			UpdateWorkerCount();
		}
		if (arePanelCostsStale)
		{
			UpdatePanelCosts();
		}
	}

	private void MaximizeParentHeader(LayoutItem p)
	{
		if (p.parentManager != null)
		{
			activeHeaderCollapseManager.SetMinimized(p.parentManager.minimizationKey, next: false);
		}
	}

	private void JumpToListItem(LayoutItem p)
	{
		ClearFilters();
		PerformUpdateItemAvailability();
		MaximizeParentHeader(p);
		RecalculateLayout();
		MenuUtility.JumpToItem(p, scrollRect);
		CalculateListVisibility();
		PerformUpdateItemAvailability();
		if (p.linkedObject != null && visibleListItems.TryGetValue(p.linkedObject, out var value))
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.AnimateFocusHighlight();
			}
			else if (value is QuestListItem questListItem)
			{
				questListItem.AnimateFocusHighlight();
			}
		}
	}

	protected virtual void ClearFilters()
	{
	}

	protected void JumpToListItem(CommonListItem p)
	{
		p.MaximizeParentHeader();
		MenuUtility.JumpToItem(p.transform, scrollRect);
		p.AnimateFocusHighlight();
	}

	protected float HeightForItem()
	{
		return 46f;
	}

	public virtual void ExpandAllVisible()
	{
		flagAutoExpandVisible = false;
	}

	public void TryExpandHeader(SectionHeader h)
	{
		bool flag = false;
		foreach (LayoutItem childItem in h.layoutManager.childItems)
		{
			if (childItem.isValid)
			{
				flag = true;
				break;
			}
		}
		if (flag && activeHeaderCollapseManager.IsMinimized(h.layoutManager.minimizationKey))
		{
			activeHeaderCollapseManager.SetMinimized(h.layoutManager.minimizationKey, next: false);
		}
	}

	public override void PerformUpdateItemAvailability()
	{
		AssignHeaderCollapseManager();
		base.PerformUpdateItemAvailability();
		if (flagAutoExpandVisible)
		{
			ExpandAllVisible();
		}
		RecalculateLayout();
		CalculateListVisibility();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.UpdateIndividualAvailability();
			}
		}
	}

	private void ApplyIndent(StringBuilder sb)
	{
		for (int i = 0; i < debugIndentLevel; i++)
		{
			sb.Append(TextDisplay.Indent);
		}
	}

	private void AppendValidItemsRecursive(LayoutManager lm, StringBuilder sb)
	{
		sb.Append(TextDisplay.NewLine);
		ApplyIndent(sb);
		sb.Append(lm.PrintDebug() + ":" + lm.isValid);
		if (lm.linkedObject == null)
		{
			sb.Append("   (NULL OBJECT)");
		}
		else if (lm.linkedObject is StateManager { isLocked: not false })
		{
			sb.Append("   (LOCKED)");
		}
		debugIndentLevel++;
		foreach (LayoutItem childItem in lm.childItems)
		{
			if (childItem is LayoutManager lm2)
			{
				AppendValidItemsRecursive(lm2, sb);
				continue;
			}
			sb.Append(TextDisplay.NewLine);
			ApplyIndent(sb);
			sb.Append(childItem.PrintDebug() + ":" + childItem.isValid);
			if (childItem.linkedObject == null)
			{
				sb.Append("   (NULL OBJECT)");
			}
			else if (childItem.linkedObject is StateManager { isLocked: not false })
			{
				sb.Append("   (LOCKED)");
			}
		}
		debugIndentLevel--;
	}

	protected override void UpdateItemAvailability()
	{
		UpdateItemValidityRecursive(primaryLayoutManager);
		base.UpdateItemAvailability();
	}

	private void UpdateItemValidityRecursive(LayoutManager layoutManager)
	{
		bool flag = false;
		layoutManager.hasValidChildren = false;
		foreach (LayoutItem childItem in layoutManager.childItems)
		{
			if (childItem.linkedObject == null)
			{
				childItem.isValid = false;
				continue;
			}
			if (childItem is LayoutManager layoutManager2)
			{
				UpdateItemValidityRecursive(layoutManager2);
				childItem.isValid = ShouldLayoutGroupBeValid(layoutManager2);
				if (!flag)
				{
				}
			}
			else
			{
				childItem.isValid = ShouldLayoutItemBeValid(childItem);
			}
			if (childItem.isValid)
			{
				layoutManager.hasValidChildren = true;
			}
		}
	}

	protected virtual bool ShouldLayoutGroupBeValid(LayoutManager layoutManager)
	{
		return true;
	}

	protected virtual bool ShouldLayoutItemBeValid(LayoutItem layoutItem)
	{
		return ShouldItemBeValid(layoutItem.linkedObject);
	}

	protected virtual bool ShouldItemBeValid(object obj)
	{
		UnityEngine.Debug.LogError("Did not implement ShouldItemBeAvailable on " + this?.ToString() + ":" + obj);
		return false;
	}

	[Conditional("UNITY_EDITORx")]
	private void LogLayout(string s)
	{
		_ = panelType;
		_ = 41;
	}

	public virtual void AssignHeaderCollapseManager()
	{
		activeHeaderCollapseManager = headerCollapseManager;
	}

	private void RecalculateLayout()
	{
		_ = panelType;
		_ = 41;
		if (primaryLayoutManager.childItems.Count != 0)
		{
			_ = headerCollapseManager;
			CalculatePositionsRecursively(primaryLayoutManager, 0f);
			layoutRect.SetHeight(primaryLayoutManager.max);
			float num = ViewportHeight();
			if (primaryLayoutManager.max < num)
			{
				layoutRect.anchoredPosition = new Vector2(0f, 0f);
			}
		}
	}

	private void CalculatePositionsRecursively(LayoutManager lm, float startY)
	{
		if (!lm.isValid)
		{
			return;
		}
		bool flag = IsMinimized(lm);
		lm.minimizationResponder?.Invoke(flag);
		lm.y = startY;
		RectTransform rt = lm.layoutRect;
		lm.hasValidChildren = false;
		float num = (lm.isSuppressed ? 0f : lm.heightOfSelf);
		lm.max = lm.y + num + 0f;
		bool flag2 = false;
		foreach (LayoutItem childItem in lm.childItems)
		{
			if (childItem.isValid)
			{
				lm.hasValidChildren = true;
				break;
			}
		}
		if (!flag)
		{
			int num2 = 0;
			float y = 0f;
			foreach (LayoutItem childItem2 in lm.childItems)
			{
				if (!childItem2.isValid)
				{
					continue;
				}
				if (childItem2 is LayoutManager layoutManager)
				{
					CalculatePositionsRecursively(layoutManager, lm.max);
					lm.max = layoutManager.max;
					childItem2.leftAnchor = 0f;
					childItem2.rightAnchor = 1f;
					flag2 = false;
					continue;
				}
				if (num2 > 0)
				{
					childItem2.y = y;
				}
				else
				{
					childItem2.y = lm.max;
				}
				if (childItem2.isSuppressed)
				{
					continue;
				}
				childItem2.max = childItem2.y + childItem2.heightOfSelf;
				if (lm.numColumns <= 1 || num2 == 0)
				{
					lm.max += childItem2.heightOfSelf;
					childItem2.leftAnchor = 0f;
				}
				else
				{
					childItem2.leftAnchor = (float)num2 / (float)lm.numColumns;
				}
				if (lm.numColumns <= 1)
				{
					childItem2.rightAnchor = 1f;
				}
				else
				{
					childItem2.rightAnchor = ((float)num2 + 1f) / (float)lm.numColumns;
				}
				flag2 = true;
				if (lm.numColumns > 1)
				{
					num2++;
					y = childItem2.y;
					if (num2 >= lm.numColumns)
					{
						num2 = 0;
					}
				}
			}
		}
		if (lm.parentManager != null)
		{
			rt.SetPosY(0f - lm.y);
		}
		_ = !lm.isSuppressed && flag2;
	}

	protected virtual void AssignParentHeader(LayoutManager manager, MonoBehaviour item)
	{
	}

	private float ViewportHeight()
	{
		float height = viewportRect.rect.height;
		if (height <= 0f)
		{
			height = ((RectTransform)base.transform.parent).rect.height;
		}
		return height;
	}

	private void CalculateListVisibility()
	{
		float y = layoutRect.anchoredPosition.y;
		float num = ViewportHeight();
		float maxVisible = y + num;
		MenuManager.applyVisibilityChangesImmediately = true;
		CalculateListVisibilityRecursive(primaryLayoutManager, y, maxVisible);
		AdjustPinnedHeadersRecursively(primaryLayoutManager);
		MenuManager.applyVisibilityChangesImmediately = false;
	}

	private void AdjustPinnedHeadersRecursively(LayoutManager lm)
	{
		if (lm.childItems.Count <= 1)
		{
			return;
		}
		float y = layoutRect.anchoredPosition.y;
		foreach (LayoutItem childItem in lm.childItems)
		{
			if (!(childItem is LayoutManager { layoutRect: var rt } layoutManager))
			{
				continue;
			}
			float num = y;
			if (layoutManager.parentManager != null && !layoutManager.parentManager.isSuppressed)
			{
				num += layoutManager.parentManager.heightOfSelf;
				if (layoutManager.parentManager.parentManager != null && !layoutManager.parentManager.parentManager.isSuppressed)
				{
					num += layoutManager.parentManager.parentManager.heightOfSelf;
				}
			}
			_ = layoutManager.debug;
			if (layoutManager.max > num && layoutManager.y < num && layoutManager.hasValidChildren)
			{
				float num2 = layoutManager.max - num - layoutManager.heightOfSelf;
				_ = layoutManager.debug;
				if (num2 < 0f)
				{
					rt.SetPosY(0f - num - num2);
				}
				else
				{
					rt.SetPosY(0f - num);
				}
			}
			else
			{
				_ = layoutManager.debug;
				rt.SetPosY(0f - layoutManager.y);
			}
			AdjustPinnedHeadersRecursively(layoutManager);
		}
	}

	protected virtual MonoBehaviour GetFromPool(object key)
	{
		MonoBehaviour fromPool = MenuPanel.m.GetFromPool(key);
		FinalizeCommonListItemForPool(fromPool);
		return fromPool;
	}

	private void CalculateListVisibilityRecursive(LayoutManager targetLayoutManager, float minVisible, float maxVisible)
	{
		bool flag = IsMinimized(targetLayoutManager);
		_ = panelType;
		_ = 41;
		bool flag2 = true;
		foreach (LayoutItem childItem in targetLayoutManager.childItems)
		{
			if (childItem is LayoutManager targetLayoutManager2)
			{
				CalculateListVisibilityRecursive(targetLayoutManager2, minVisible, maxVisible);
			}
			else
			{
				if (childItem.parentManager == null)
				{
					continue;
				}
				bool flag3 = !flag && childItem.parentManager.isValid && childItem.isValid;
				bool flag4 = false;
				if (flag3)
				{
					flag4 = childItem.max >= minVisible && childItem.y <= maxVisible;
				}
				object linkedObject = childItem.linkedObject;
				if (flag2)
				{
				}
				if (flag3 && flag4)
				{
					if (!visibleListItems.TryGetValue(linkedObject, out var value))
					{
						if (listItemPool == null)
						{
							value = GetFromPool(linkedObject);
							FinalizeCommonListItemForPool(value);
							((RectTransform)value.transform).SetLeft(childItem.parentManager.childIndent);
						}
						else
						{
							value = listItemPool.Get();
							value.transform.SetSiblingIndex(0);
							((RectTransform)value.transform).SetLeft(childItem.parentManager.childIndent);
						}
						visibleListItems[linkedObject] = value;
						AssignKeyToItem(linkedObject, value);
						AssignParentHeader(targetLayoutManager, value);
						if (!flag2)
						{
						}
					}
					RectTransform obj = (RectTransform)value.transform;
					obj.SetPosY(0f - childItem.y);
					obj.anchorMin = new Vector2(childItem.leftAnchor, 1f);
					obj.anchorMax = new Vector2(childItem.rightAnchor, 1f);
					if (usePersistentRows && !value.gameObject.activeSelf)
					{
						value.gameObject.SetActive(value: true);
					}
				}
				else
				{
					if (linkedObject == null || !visibleListItems.TryGetValue(linkedObject, out var value2))
					{
						continue;
					}
					if (value2 is MenuButton menuButton)
					{
						menuButton.OnRemoveFromList();
					}
					if (usePersistentRows)
					{
						if (!flag3)
						{
							value2.gameObject.SetActive(value: false);
							continue;
						}
						((RectTransform)value2.transform).SetPosY(0f - childItem.y);
						if (!flag2)
						{
						}
						continue;
					}
					if (listItemPool == null)
					{
						if (value2 is CommonListItem { parentPool: not null } commonListItem)
						{
							commonListItem.parentPool.Release(commonListItem);
						}
					}
					else
					{
						listItemPool.Release(value2);
					}
					visibleListItems.Remove(linkedObject);
				}
			}
		}
	}

	protected virtual void AssignKeyToItem(object key, MonoBehaviour item)
	{
		UnityEngine.Debug.LogError("Need to implement AssignKeyToItem " + key?.ToString() + " " + item);
	}

	protected void OnPooledObjectGet(MonoBehaviour b)
	{
		if (b is IPooledListItem pooledListItem)
		{
			pooledListItem.SetVisible(visible: true);
		}
	}

	protected void OnPooledObjectReleased(MonoBehaviour b)
	{
		if (b is IPooledListItem pooledListItem)
		{
			pooledListItem.SetVisible(visible: false);
		}
	}

	public override bool ShouldBeInAlertState()
	{
		return primaryLayoutManager.HasItemInAlertStateRecursive();
	}

	public MonoBehaviour GetVisibleListItemWithObject(object obj)
	{
		if (visibleListItems.TryGetValue(obj, out var value))
		{
			return value;
		}
		return null;
	}

	public void QueueJumpToItemWithLinkedObject(object obj)
	{
		LayoutItem layoutItem = primaryLayoutManager.ChildItemWithLinkedObject(obj);
		if (layoutItem != null)
		{
			QueueJumpToItem(layoutItem);
			if (obj is StateManager stateManager)
			{
				MenuManager.Instance.SetAsNavigationEntity(stateManager.AsEntity());
			}
			else if (obj is CountableState countableState)
			{
				MenuManager.Instance.SetAsNavigationEntity(countableState.AsEntity());
			}
		}
	}

	public void QueueJumpToItem(CommonListItem p)
	{
		queuedJumpCountdown = 1;
		queuedJumpItem = p;
		MenuManager.Instance.navigationPanel.SelectPanel(panelType);
	}

	public void QueueJumpToItem(LayoutItem p)
	{
		queuedJumpCountdown = 1;
		queuedLayoutItem = p;
	}

	protected MonoBehaviour CreateCommonListItemForPool(GameObject prefab)
	{
		CommonListItem component = MenuManager.GetMenuObject(prefab, layoutGroup.transform).GetComponent<CommonListItem>();
		component.Initialize();
		component.LoadSelectionManager(selectionManager);
		RectTransform obj = (RectTransform)component.transform;
		obj.SetSiblingIndex(0);
		obj.SetHeight(itemHeight);
		return component;
	}

	protected void FinalizeCommonListItemForPool(MonoBehaviour listItem)
	{
		RectTransform obj = (RectTransform)listItem.transform;
		obj.SetParent(layoutGroup.transform, worldPositionStays: false);
		if (listItem is CommonListItem commonListItem)
		{
			commonListItem.LoadSelectionManager(selectionManager);
		}
		obj.SetHeight(itemHeight);
	}

	protected void RemoveAutoLayout()
	{
		if (MenuManager.useDynamicSizing)
		{
			layoutGroup.enabled = false;
			if (layoutGroup.TryGetComponent<ContentSizeFitter>(out var component))
			{
				component.enabled = false;
			}
		}
	}

	public virtual void OnSelectionChangedByManager(EntityId id, bool nextState)
	{
		SelectableButton selectableButton = VisibleListItemWithEntity(id);
		if (null != selectableButton && !nextState)
		{
			selectableButton.RemoveSelection();
		}
	}

	protected virtual SelectableButton VisibleListItemWithEntity(EntityId seekEntity)
	{
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is SelectableButton selectableButton && selectableButton.selectionHandle.Equals(seekEntity))
			{
				return selectableButton;
			}
		}
		return null;
	}

	public void UpdatePanelCosts()
	{
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.LoadCost();
			}
			else if (value is UpgradeListItem upgradeListItem)
			{
				upgradeListItem.LoadCost();
			}
		}
		arePanelCostsStale = false;
	}

	public override void UpdatePauseDisplay()
	{
		base.UpdatePauseDisplay();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.ReloadPauseState();
			}
		}
	}

	public override void UpdateAutoClaimDisplay()
	{
		base.UpdateAutoClaimDisplay();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.ReloadAutoClaimState();
			}
		}
	}

	public override void UpdateAutoAssignDisplay()
	{
		base.UpdateAutoAssignDisplay();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.ReloadRepeatState();
			}
		}
	}

	public override void UpdateProductionLimitDisplay()
	{
		base.UpdateProductionLimitDisplay();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.ReloadProductionLimitState();
			}
		}
	}

	public override void UpdatePriorityDisplay()
	{
		base.UpdatePriorityDisplay();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem)
			{
				commonListItem.ReloadPriorityState();
			}
		}
	}

	public virtual void UpdateWorkerCount()
	{
		if (this is ResearchPanel researchPanel)
		{
			researchPanel.singleBuildingHeader.UpdateProductionCapacityLabel();
		}
		isCapacityAvailableStale = false;
	}

	public virtual void UpdateBuildingData()
	{
		if (this is ResearchPanel researchPanel)
		{
			researchPanel.singleBuildingHeader.UpdateBuildingData();
		}
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CraftListItem craftListItem)
			{
				craftListItem.UpdateBuildingData();
			}
			else if (value is TradingListItem tradingListItem)
			{
				tradingListItem.UpdateBuildingData();
			}
			else if (value is ResearchListItem researchListItem)
			{
				researchListItem.UpdateBuildingData();
			}
		}
		isBuildingDataStale = false;
	}

	protected override void ApplyStateAnimations()
	{
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is CommonListItem commonListItem && null != commonListItem.rateDisplayRegion && null != commonListItem.rateDisplayRegion.progressButton)
			{
				commonListItem.rateDisplayRegion.progressButton.AnimateInstant();
			}
		}
	}

	public void MaximizeAllLayoutsWithParent(LayoutManager parent)
	{
		SetMinimizationStateOnAllWithParent(primaryLayoutManager, parent, nextState: false);
	}

	public void MinimizeAllLayoutsWithParent(LayoutManager parent)
	{
		SetMinimizationStateOnAllWithParent(primaryLayoutManager, parent, nextState: true);
	}

	public bool TryGetPrimaryCollapseManager(out HeaderCollapseManager result)
	{
		result = headerCollapseManager;
		return result != null;
	}

	[Conditional("UNITY_EDITOR")]
	public void DebugMinimization(LayoutManager lm, StringBuilder sb)
	{
		if (lm != null)
		{
			sb.Append(TextDisplay.NewLine);
			sb.Append(lm.PrintDebug());
			sb.Append(" Has Manager? " + (activeHeaderCollapseManager != null));
			sb.Append(" Suppressed " + lm.isSuppressed);
			if (activeHeaderCollapseManager != null)
			{
				sb.Append(" HCM Name? " + activeHeaderCollapseManager.debugString);
				sb.Append(" Minimized in hcm? " + activeHeaderCollapseManager.IsMinimized(lm.minimizationKey));
			}
			if (!lm.isSuppressed && activeHeaderCollapseManager != null)
			{
				activeHeaderCollapseManager.IsMinimized(lm.minimizationKey);
			}
		}
	}

	public bool IsMinimized(LayoutManager lm)
	{
		_ = activeHeaderCollapseManager;
		if (lm == null || activeHeaderCollapseManager == null)
		{
			return false;
		}
		if (!lm.isSuppressed && activeHeaderCollapseManager.IsMinimized(lm.minimizationKey))
		{
			return true;
		}
		return IsMinimized(lm.parentManager);
	}

	public bool TryMaximizeAllParents(LayoutManager lm)
	{
		bool result = false;
		if (activeHeaderCollapseManager.IsMinimized(lm.minimizationKey))
		{
			activeHeaderCollapseManager.SetMinimized(lm.minimizationKey, next: false);
		}
		if (lm.parentManager != null && TryMaximizeAllParents(lm.parentManager))
		{
			result = true;
		}
		return result;
	}

	public void SetMinimizationStateOnAllWithParent(LayoutManager targetManager, LayoutManager testMatchManager, bool nextState)
	{
		if (activeHeaderCollapseManager != null && targetManager.CurrentParent() == testMatchManager)
		{
			activeHeaderCollapseManager.SetMinimized(targetManager.minimizationKey, nextState);
		}
		foreach (LayoutItem childItem in targetManager.childItems)
		{
			if (childItem is LayoutManager targetManager2)
			{
				SetMinimizationStateOnAllWithParent(targetManager2, testMatchManager, nextState);
			}
		}
	}

	public void ToggleMinimizationForAllSimilarHeaders(LayoutManager layoutManager)
	{
		if (activeHeaderCollapseManager.IsMinimized(layoutManager.minimizationKey))
		{
			if (this is ProductionListPanel productionListPanel && layoutManager.linkedObject is BuildingState)
			{
				productionListPanel.SetMinimizationStateForAllBuildings(nextState: false);
			}
			else
			{
				MaximizeAllLayoutsWithParent(layoutManager.CurrentParent());
			}
			QueueJumpToItemWithLinkedObject(layoutManager.linkedObject);
		}
		else if (this is ProductionListPanel productionListPanel2 && layoutManager.linkedObject is BuildingState)
		{
			productionListPanel2.SetMinimizationStateForAllBuildings(nextState: true);
		}
		else
		{
			MinimizeAllLayoutsWithParent(layoutManager.CurrentParent());
		}
	}
}
