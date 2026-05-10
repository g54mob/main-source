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

		private int indexOfSelectedLogEntry;

		private float heightOfSelectedLogEntry;

		private int collapsedOrderOfSelectedLogEntry;

		private float scrollDistanceToSelectedLogEntry;

		private readonly DynamicCircularBuffer<DebugLogItem> visibleLogItems;

		private bool isCollapseOn;

		private int currentTopIndex;

		private int currentBottomIndex;

		private Predicate<DebugLogItem> shouldRemoveLogItemPredicate;

		private Action<DebugLogItem> poolLogItemAction;

		private float DeltaHeightOfSelectedLogEntry => 0f;

		public float ItemHeight => 0f;

		public float SelectedItemHeight => 0f;

		private void Awake()
		{
		}

		public void Initialize(DebugLogManager manager, DynamicCircularBuffer<DebugLogEntry> entriesToShow, DynamicCircularBuffer<DebugLogEntryTimestamp> timestampsOfEntriesToShow, float logItemHeight)
		{
		}

		public void SetCollapseMode(bool collapse)
		{
		}

		public void OnLogItemClicked(DebugLogItem item)
		{
		}

		public void SelectAndFocusOnLogItemAtIndex(int itemIndex)
		{
		}

		private void OnLogItemClickedInternal(int itemIndex, DebugLogItem referenceItem = null)
		{
		}

		public void DeselectSelectedLogItem()
		{
		}

		public void OnBeforeFilterLogs()
		{
		}

		public void OnAfterFilterLogs()
		{
		}

		public void OnLogEntriesUpdated(bool updateAllVisibleItemContents)
		{
		}

		public void OnCollapsedLogEntryAtIndexUpdated(int index)
		{
		}

		public void RefreshCollapsedLogEntryCounts()
		{
		}

		public void OnLogEntriesRemoved(int removedLogCount)
		{
		}

		private bool ShouldRemoveLogItem(DebugLogItem logItem)
		{
			return false;
		}

		private int FindIndexOfLogEntryInReverseDirection(DebugLogEntry logEntry, int startIndex)
		{
			return 0;
		}

		public void OnViewportWidthChanged()
		{
		}

		public void OnViewportHeightChanged()
		{
		}

		private void CalculateContentHeight()
		{
		}

		private void CalculateSelectedLogEntryHeight(DebugLogItem referenceItem = null)
		{
		}

		private void UpdateItemsInTheList(bool updateAllVisibleItemContents)
		{
		}

		private DebugLogItem GetLogItemAtIndex(int index)
		{
			return null;
		}

		private void UpdateLogItemContentsBetweenIndices(int topIndex, int bottomIndex, int logItemOffset)
		{
		}

		private void RepositionLogItem(DebugLogItem logItem)
		{
		}

		private void ColorLogItem(DebugLogItem logItem)
		{
		}
	}
}
