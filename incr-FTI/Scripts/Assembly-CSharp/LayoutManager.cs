using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class LayoutManager : LayoutItem
{
	public List<EntityId> childKeys = new List<EntityId>();

	public List<LayoutItem> childItems = new List<LayoutItem>();

	public bool areChildRecordsPersistent;

	public bool hasValidChildren;

	public int minimizationKey;

	public readonly RectTransform layoutRect;

	public const float marginBeforeItemsStart = 0f;

	public bool isRoot;

	public int numColumns;

	public UnityAction<bool> minimizationResponder;

	public float spacing;

	public float childIndent;

	public bool debug;

	public LayoutManager(RectTransform targetTransform)
	{
		isValid = true;
		layoutRect = targetTransform;
	}

	public void AddChildManagerWithHeight(LayoutManager subManager, EntityId childKey, float headerHeight)
	{
		subManager.linkedObject = childKey;
		subManager.heightOfSelf = headerHeight;
		subManager.parentManager = this;
		subManager.minimizationKey = childKey.GetHashCode();
		childKeys.Add(childKey);
		childItems.Add(subManager);
	}

	public void AddEntityWithHeight(EntityId id, float h, string dbg = null)
	{
		LayoutItem layoutItem = new LayoutItem();
		layoutItem.heightOfSelf = h;
		layoutItem.parentManager = this;
		childKeys.Add(id);
		childItems.Add(layoutItem);
	}

	public void AddItemWithHeight(object obj, float h)
	{
		LayoutItem layoutItem = new LayoutItem();
		layoutItem.linkedObject = obj;
		layoutItem.heightOfSelf = h;
		layoutItem.parentManager = this;
		childItems.Add(layoutItem);
		if (obj is TradingState tradingState)
		{
			childKeys.Add(EntityId.FromItem(tradingState.itemType));
		}
	}

	public void ClearRecursively()
	{
		foreach (LayoutItem childItem in childItems)
		{
			if (childItem.linkedObject is StateManager)
			{
				childItem.linkedObject = null;
			}
		}
		foreach (LayoutItem childItem2 in childItems)
		{
			if (childItem2 is LayoutManager layoutManager)
			{
				layoutManager.ClearRecursively();
			}
		}
		if (!areChildRecordsPersistent)
		{
			if (childItems != null)
			{
				childItems.Clear();
			}
			if (childKeys != null)
			{
				childKeys.Clear();
			}
		}
	}

	public bool HasItemInAlertStateRecursive()
	{
		foreach (LayoutItem childItem in childItems)
		{
			if (childItem is LayoutManager layoutManager)
			{
				if (layoutManager.HasItemInAlertStateRecursive())
				{
					return true;
				}
				continue;
			}
			object obj = childItem.linkedObject;
			if (obj is StateManager { isInAlertState: not false })
			{
				return true;
			}
			if (obj is BuildingState buildingState && buildingState.constructionState.isInAlertState)
			{
				return true;
			}
			if (obj is Upgrade { isInAlertState: not false })
			{
				return true;
			}
		}
		return false;
	}

	public LayoutItem ChildItemWithLinkedObject(object obj)
	{
		foreach (LayoutItem childItem in childItems)
		{
			if (childItem.linkedObject == obj)
			{
				return childItem;
			}
			if (childItem is LayoutManager layoutManager)
			{
				LayoutItem layoutItem = layoutManager.ChildItemWithLinkedObject(obj);
				if (layoutItem != null)
				{
					return layoutItem;
				}
			}
		}
		return null;
	}

	public LayoutManager CurrentParent()
	{
		if (parentManager == null)
		{
			return this;
		}
		if (!parentManager.isSuppressed)
		{
			return parentManager;
		}
		return parentManager.CurrentParent();
	}

	public void SetSuppressionRecursively(bool nextState)
	{
		SetSuppressedFromRoot(nextState);
		parentManager?.SetSuppressionRecursively(nextState);
	}
}
