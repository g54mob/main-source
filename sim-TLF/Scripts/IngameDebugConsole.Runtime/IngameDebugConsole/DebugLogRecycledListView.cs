using System;
using UnityEngine;
using UnityEngine.UI;

namespace IngameDebugConsole
{
	public class DebugLogRecycledListView : MonoBehaviour
	{
		[SerializeField]
		private RectTransform transformComponent;

		[SerializeField]
		private RectTransform viewportTransform;

		[SerializeField]
		private Color logItemNormalColor1;

		[SerializeField]
		private Color logItemNormalColor2;

		[SerializeField]
		private Color logItemSelectedColor;

		internal DebugLogManager manager;

		private ScrollRect scrollView;

		private float logItemHeight;

		private DynamicCircularBuffer<DebugLogEntry> entriesToShow;

		private DynamicCircularBuffer<DebugLogEntryTimestamp> timestampsOfEntriesToShow;

		private DebugLogEntry selectedLogEntry;

		private int indexOfSelectedLogEntry = int.MaxValue;

		private float heightOfSelectedLogEntry;

		private int collapsedOrderOfSelectedLogEntry;

		private float scrollDistanceToSelectedLogEntry;

		private readonly DynamicCircularBuffer<DebugLogItem> visibleLogItems = new DynamicCircularBuffer<DebugLogItem>(32);

		private bool isCollapseOn;

		private bool viewportSizeChanged;

		private int currentTopIndex = -1;

		private int currentBottomIndex = -1;

		private Predicate<DebugLogItem> shouldRemoveLogItemPredicate;

		private Action<DebugLogItem> poolLogItemAction;

		private float DeltaHeightOfSelectedLogEntry => heightOfSelectedLogEntry - logItemHeight;

		public float ItemHeight => logItemHeight;

		public float SelectedItemHeight => heightOfSelectedLogEntry;

		private void Awake()
		{
			scrollView = viewportTransform.GetComponentInParent<ScrollRect>();
			scrollView.onValueChanged.AddListener(delegate
			{
				if (manager.IsLogWindowVisible)
				{
					UpdateItemsInTheList(updateAllVisibleItemContents: false);
				}
			});
		}

		public void Initialize(DebugLogManager manager, DynamicCircularBuffer<DebugLogEntry> entriesToShow, DynamicCircularBuffer<DebugLogEntryTimestamp> timestampsOfEntriesToShow, float logItemHeight)
		{
			this.manager = manager;
			this.entriesToShow = entriesToShow;
			this.timestampsOfEntriesToShow = timestampsOfEntriesToShow;
			this.logItemHeight = logItemHeight;
			shouldRemoveLogItemPredicate = ShouldRemoveLogItem;
			poolLogItemAction = manager.PoolLogItem;
		}

		public void SetCollapseMode(bool collapse)
		{
			isCollapseOn = collapse;
		}

		public void OnLogItemClicked(DebugLogItem item)
		{
			OnLogItemClickedInternal(item.Index, item);
		}

		public void SelectAndFocusOnLogItemAtIndex(int itemIndex)
		{
			if (indexOfSelectedLogEntry != itemIndex)
			{
				OnLogItemClickedInternal(itemIndex);
			}
			float height = viewportTransform.rect.height;
			float num = height * 0.5f;
			float num2 = transformComponent.sizeDelta.y - height * 0.5f;
			float value = (float)itemIndex * logItemHeight + height * 0.5f;
			if (num == num2)
			{
				scrollView.verticalNormalizedPosition = 0.5f;
			}
			else
			{
				scrollView.verticalNormalizedPosition = Mathf.Clamp01(Mathf.InverseLerp(num2, num, value));
			}
			manager.SnapToBottom = false;
		}

		private void OnLogItemClickedInternal(int itemIndex, DebugLogItem referenceItem = null)
		{
			int num = indexOfSelectedLogEntry;
			DeselectSelectedLogItem();
			if (num != itemIndex)
			{
				selectedLogEntry = entriesToShow[itemIndex];
				indexOfSelectedLogEntry = itemIndex;
				CalculateSelectedLogEntryHeight(referenceItem);
				manager.SnapToBottom = false;
			}
			CalculateContentHeight();
			UpdateItemsInTheList(updateAllVisibleItemContents: true);
			manager.ValidateScrollPosition();
		}

		public void DeselectSelectedLogItem()
		{
			selectedLogEntry = null;
			indexOfSelectedLogEntry = int.MaxValue;
			heightOfSelectedLogEntry = 0f;
		}

		public void OnBeforeFilterLogs()
		{
			collapsedOrderOfSelectedLogEntry = 0;
			scrollDistanceToSelectedLogEntry = 0f;
			if (selectedLogEntry == null)
			{
				return;
			}
			if (!isCollapseOn)
			{
				for (int i = 0; i < indexOfSelectedLogEntry; i++)
				{
					if (entriesToShow[i] == selectedLogEntry)
					{
						collapsedOrderOfSelectedLogEntry++;
					}
				}
			}
			scrollDistanceToSelectedLogEntry = (float)indexOfSelectedLogEntry * ItemHeight - transformComponent.anchoredPosition.y;
		}

		public void OnAfterFilterLogs()
		{
			int num = -1;
			if (selectedLogEntry != null)
			{
				for (int i = 0; i < entriesToShow.Count; i++)
				{
					if (entriesToShow[i] == selectedLogEntry && collapsedOrderOfSelectedLogEntry-- == 0)
					{
						num = i;
						break;
					}
				}
			}
			if (num < 0)
			{
				DeselectSelectedLogItem();
				return;
			}
			indexOfSelectedLogEntry = num;
			transformComponent.anchoredPosition = new Vector2(0f, (float)num * ItemHeight - scrollDistanceToSelectedLogEntry);
		}

		public void OnLogEntriesUpdated(bool updateAllVisibleItemContents)
		{
			CalculateContentHeight();
			UpdateItemsInTheList(updateAllVisibleItemContents);
		}

		public void OnCollapsedLogEntryAtIndexUpdated(int index)
		{
			if (index >= currentTopIndex && index <= currentBottomIndex)
			{
				DebugLogItem logItemAtIndex = GetLogItemAtIndex(index);
				logItemAtIndex.ShowCount();
				if (timestampsOfEntriesToShow != null)
				{
					logItemAtIndex.UpdateTimestamp(timestampsOfEntriesToShow[index]);
				}
			}
		}

		public void RefreshCollapsedLogEntryCounts()
		{
			for (int i = 0; i < visibleLogItems.Count; i++)
			{
				visibleLogItems[i].ShowCount();
			}
		}

		public void OnLogEntriesRemoved(int removedLogCount)
		{
			if (selectedLogEntry != null)
			{
				if (isCollapseOn ? (selectedLogEntry.count == 0) : (indexOfSelectedLogEntry < removedLogCount))
				{
					DeselectSelectedLogItem();
				}
				else
				{
					indexOfSelectedLogEntry = (isCollapseOn ? FindIndexOfLogEntryInReverseDirection(selectedLogEntry, indexOfSelectedLogEntry) : (indexOfSelectedLogEntry - removedLogCount));
				}
			}
			if (!manager.IsLogWindowVisible && manager.SnapToBottom)
			{
				visibleLogItems.TrimStart(visibleLogItems.Count, poolLogItemAction);
			}
			else if (!isCollapseOn)
			{
				visibleLogItems.TrimStart(Mathf.Clamp(removedLogCount - currentTopIndex, 0, visibleLogItems.Count), poolLogItemAction);
			}
			else
			{
				visibleLogItems.RemoveAll(shouldRemoveLogItemPredicate);
				if (visibleLogItems.Count > 0)
				{
					removedLogCount = currentTopIndex - FindIndexOfLogEntryInReverseDirection(visibleLogItems[0].Entry, visibleLogItems[0].Index);
				}
			}
			if (visibleLogItems.Count == 0)
			{
				currentTopIndex = -1;
				if (!manager.SnapToBottom)
				{
					transformComponent.anchoredPosition = Vector2.zero;
				}
				return;
			}
			currentTopIndex = Mathf.Max(0, currentTopIndex - removedLogCount);
			currentBottomIndex = currentTopIndex + visibleLogItems.Count - 1;
			float y = visibleLogItems[0].Transform.anchoredPosition.y;
			for (int i = 0; i < visibleLogItems.Count; i++)
			{
				DebugLogItem debugLogItem = visibleLogItems[i];
				debugLogItem.Index = currentTopIndex + i;
				if (manager.IsLogWindowVisible)
				{
					RepositionLogItem(debugLogItem);
					ColorLogItem(debugLogItem);
					if (isCollapseOn)
					{
						debugLogItem.ShowCount();
					}
				}
			}
			if (!manager.SnapToBottom)
			{
				transformComponent.anchoredPosition = new Vector2(0f, Mathf.Max(0f, transformComponent.anchoredPosition.y - (visibleLogItems[0].Transform.anchoredPosition.y - y)));
			}
		}

		private bool ShouldRemoveLogItem(DebugLogItem logItem)
		{
			if (logItem.Entry.count == 0)
			{
				poolLogItemAction(logItem);
				return true;
			}
			return false;
		}

		private int FindIndexOfLogEntryInReverseDirection(DebugLogEntry logEntry, int startIndex)
		{
			for (int num = Mathf.Min(startIndex, entriesToShow.Count - 1); num >= 0; num--)
			{
				if (entriesToShow[num] == logEntry)
				{
					return num;
				}
			}
			return -1;
		}

		private void OnRectTransformDimensionsChange()
		{
			viewportSizeChanged = true;
		}

		private void LateUpdate()
		{
			if (viewportSizeChanged)
			{
				viewportSizeChanged = false;
				OnViewportSizeChanged();
			}
		}

		private void OnViewportSizeChanged()
		{
			if (indexOfSelectedLogEntry >= entriesToShow.Count)
			{
				UpdateItemsInTheList(updateAllVisibleItemContents: false);
				return;
			}
			CalculateSelectedLogEntryHeight();
			CalculateContentHeight();
			UpdateItemsInTheList(updateAllVisibleItemContents: true);
			manager.ValidateScrollPosition();
		}

		private void CalculateContentHeight()
		{
			float num = Mathf.Max(1f, (float)entriesToShow.Count * logItemHeight);
			if (selectedLogEntry != null)
			{
				num += DeltaHeightOfSelectedLogEntry;
			}
			transformComponent.sizeDelta = new Vector2(0f, num);
		}

		private void CalculateSelectedLogEntryHeight(DebugLogItem referenceItem = null)
		{
			if (!referenceItem)
			{
				if (visibleLogItems.Count == 0)
				{
					UpdateItemsInTheList(updateAllVisibleItemContents: false);
					if (visibleLogItems.Count == 0)
					{
						return;
					}
				}
				referenceItem = visibleLogItems[0];
			}
			heightOfSelectedLogEntry = referenceItem.CalculateExpandedHeight(selectedLogEntry, (timestampsOfEntriesToShow != null) ? new DebugLogEntryTimestamp?(timestampsOfEntriesToShow[indexOfSelectedLogEntry]) : ((DebugLogEntryTimestamp?)null));
		}

		private void UpdateItemsInTheList(bool updateAllVisibleItemContents)
		{
			if (entriesToShow.Count > 0)
			{
				float num = transformComponent.anchoredPosition.y - 1f;
				float num2 = num + viewportTransform.rect.height + 2f;
				float num3 = (float)indexOfSelectedLogEntry * logItemHeight;
				if (num3 <= num2)
				{
					if (num3 <= num)
					{
						num = Mathf.Max(num - DeltaHeightOfSelectedLogEntry, num3 - 1f);
						num2 = Mathf.Max(num2 - DeltaHeightOfSelectedLogEntry, num + 2f);
					}
					else
					{
						num2 = Mathf.Max(num2 - DeltaHeightOfSelectedLogEntry, num3 + 1f);
					}
				}
				int num4 = Mathf.Min((int)(num2 / logItemHeight), entriesToShow.Count - 1);
				int num5 = Mathf.Clamp((int)(num / logItemHeight), 0, num4);
				if (currentTopIndex == -1)
				{
					updateAllVisibleItemContents = true;
					int i = 0;
					for (int num6 = num4 - num5 + 1; i < num6; i++)
					{
						visibleLogItems.Add(manager.PopLogItem());
					}
				}
				else if (num4 < currentTopIndex || num5 > currentBottomIndex)
				{
					updateAllVisibleItemContents = true;
					visibleLogItems.TrimStart(visibleLogItems.Count, poolLogItemAction);
					int j = 0;
					for (int num7 = num4 - num5 + 1; j < num7; j++)
					{
						visibleLogItems.Add(manager.PopLogItem());
					}
				}
				else
				{
					if (num5 > currentTopIndex)
					{
						visibleLogItems.TrimStart(num5 - currentTopIndex, poolLogItemAction);
					}
					if (num4 < currentBottomIndex)
					{
						visibleLogItems.TrimEnd(currentBottomIndex - num4, poolLogItemAction);
					}
					if (num5 < currentTopIndex)
					{
						int k = 0;
						for (int num8 = currentTopIndex - num5; k < num8; k++)
						{
							visibleLogItems.AddFirst(manager.PopLogItem());
						}
						if (!updateAllVisibleItemContents)
						{
							UpdateLogItemContentsBetweenIndices(num5, currentTopIndex - 1, num5);
						}
					}
					if (num4 > currentBottomIndex)
					{
						int l = 0;
						for (int num9 = num4 - currentBottomIndex; l < num9; l++)
						{
							visibleLogItems.Add(manager.PopLogItem());
						}
						if (!updateAllVisibleItemContents)
						{
							UpdateLogItemContentsBetweenIndices(currentBottomIndex + 1, num4, num5);
						}
					}
				}
				currentTopIndex = num5;
				currentBottomIndex = num4;
				if (updateAllVisibleItemContents)
				{
					UpdateLogItemContentsBetweenIndices(currentTopIndex, currentBottomIndex, num5);
				}
			}
			else if (currentTopIndex != -1)
			{
				visibleLogItems.TrimStart(visibleLogItems.Count, poolLogItemAction);
				currentTopIndex = -1;
			}
		}

		private DebugLogItem GetLogItemAtIndex(int index)
		{
			return visibleLogItems[index - currentTopIndex];
		}

		private void UpdateLogItemContentsBetweenIndices(int topIndex, int bottomIndex, int logItemOffset)
		{
			for (int i = topIndex; i <= bottomIndex; i++)
			{
				DebugLogItem debugLogItem = visibleLogItems[i - logItemOffset];
				debugLogItem.SetContent(entriesToShow[i], (timestampsOfEntriesToShow != null) ? new DebugLogEntryTimestamp?(timestampsOfEntriesToShow[i]) : ((DebugLogEntryTimestamp?)null), i, i == indexOfSelectedLogEntry);
				RepositionLogItem(debugLogItem);
				ColorLogItem(debugLogItem);
				if (isCollapseOn)
				{
					debugLogItem.ShowCount();
				}
				else
				{
					debugLogItem.HideCount();
				}
			}
		}

		private void RepositionLogItem(DebugLogItem logItem)
		{
			int index = logItem.Index;
			Vector2 anchoredPosition = new Vector2(1f, (float)(-index) * logItemHeight);
			if (index > indexOfSelectedLogEntry)
			{
				anchoredPosition.y -= DeltaHeightOfSelectedLogEntry;
			}
			logItem.Transform.anchoredPosition = anchoredPosition;
		}

		private void ColorLogItem(DebugLogItem logItem)
		{
			int index = logItem.Index;
			if (index == indexOfSelectedLogEntry)
			{
				logItem.Image.color = logItemSelectedColor;
			}
			else if (index % 2 == 0)
			{
				logItem.Image.color = logItemNormalColor1;
			}
			else
			{
				logItem.Image.color = logItemNormalColor2;
			}
		}
	}
}
