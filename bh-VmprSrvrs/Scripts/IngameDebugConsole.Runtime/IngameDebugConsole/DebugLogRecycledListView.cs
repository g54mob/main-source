using System.Collections.Generic;
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

		private float _1OverLogItemHeight;

		private float viewportHeight;

		private List<DebugLogEntry> collapsedLogEntries;

		private DebugLogIndexList<int> indicesOfEntriesToShow;

		private DebugLogIndexList<DebugLogEntryTimestamp> timestampsOfEntriesToShow;

		private int indexOfSelectedLogEntry;

		private float positionOfSelectedLogEntry;

		private float heightOfSelectedLogEntry;

		private float deltaHeightOfSelectedLogEntry;

		private readonly Dictionary<int, DebugLogItem> logItemsAtIndices;

		private bool isCollapseOn;

		private int currentTopIndex;

		private int currentBottomIndex;

		public float ItemHeight => 0f;

		public float SelectedItemHeight => 0f;

		private void Awake()
		{
		}

		public void Initialize(DebugLogManager manager, List<DebugLogEntry> collapsedLogEntries, DebugLogIndexList<int> indicesOfEntriesToShow, DebugLogIndexList<DebugLogEntryTimestamp> timestampsOfEntriesToShow, float logItemHeight)
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

		public void OnLogEntriesUpdated(bool updateAllVisibleItemContents)
		{
		}

		public void OnCollapsedLogEntryAtIndexUpdated(int index)
		{
		}

		public void OnViewportWidthChanged()
		{
		}

		public void OnViewportHeightChanged()
		{
		}

		private void HardResetItems()
		{
		}

		private void CalculateContentHeight()
		{
		}

		public void UpdateItemsInTheList(bool updateAllVisibleItemContents)
		{
		}

		private void CreateLogItemsBetweenIndices(int topIndex, int bottomIndex)
		{
		}

		private void CreateLogItemAtIndex(int index)
		{
		}

		private void DestroyLogItemsBetweenIndices(int topIndex, int bottomIndex)
		{
		}

		private void UpdateLogItemContentsBetweenIndices(int topIndex, int bottomIndex)
		{
		}

		private void ColorLogItem(DebugLogItem logItem, int index)
		{
		}
	}
}
