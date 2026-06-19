using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TH20.UI
{
	[AddComponentMenu("Layout/Table", 100)]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	public class Table : ElementLayoutController, ILayoutGroup, ILayoutController
	{
		private class AscendingComparer : IComparer<SortEntry>
		{
			public int Compare(SortEntry x, SortEntry y)
			{
				return x.Comparable.CompareTo(y.Comparable);
			}
		}

		private class DescendingComparer : IComparer<SortEntry>
		{
			public int Compare(SortEntry x, SortEntry y)
			{
				return -x.Comparable.CompareTo(y.Comparable);
			}
		}

		private class InstanceIdComparer : IComparer<Transform>
		{
			public int Compare(Transform x, Transform y)
			{
				return -x.GetInstanceID().CompareTo(y.GetInstanceID());
			}
		}

		private struct SortEntry
		{
			public int OriginalIndex;

			public IComparable Comparable;
		}

		public enum SortDirection
		{
			Ascending = 0,
			Descending = 1
		}

		[Serializable]
		public class ColumnDefinition
		{
			[FormerlySerializedAs("MinWidth")]
			public float WidthWeight = 10f;

			[NonSerialized]
			public float MinWidthFraction;

			[NonSerialized]
			public float MaxWidthFraction = 1f;

			[NonSerialized]
			public float MinX;

			[NonSerialized]
			public ColumnSortButton ColumnSortButton;
		}

		private CustomSampler _samplerSetLayout;

		private CustomSampler _samplerUpdateCulling;

		private CustomSampler _samplerSetLayoutColumns;

		private CustomSampler _samplerSetLayoutFilter;

		private CustomSampler _samplerUpdateRowCellsLayoutNotTableCell;

		private CustomSampler _samplerUpdateRowCellsLayout;

		private CustomSampler _samplerUpdateRowCellsLayoutSetRect;

		private CustomSampler _samplerGetUnfilteredRow;

		private CustomSampler _samplerUpdateRowCulling;

		private CustomSampler _samplerUpdateRowCullingGetRenderers;

		private CustomSampler _samplerUpdateRowCullingShowGraphics;

		private CustomSampler _samplerUpdateRowCullingSetDirty;

		private CustomSampler _samplerUpdateRowGetGraphics;

		private static readonly List<NotTableCell> _cachedNotTableCell = new List<NotTableCell>(4);

		private static readonly List<SortEntry> _cachedComparablesList = new List<SortEntry>(128);

		private static readonly List<CanvasRenderer> _cachedCanvasRenderersList = new List<CanvasRenderer>(32);

		private static readonly List<Graphic> _cachedGraphicsList = new List<Graphic>(8);

		private static readonly List<ColumnSortButton> _cachedColumnSortButtonList = new List<ColumnSortButton>(8);

		private static readonly InstanceIdComparer _cachedInstanceIdComparer = new InstanceIdComparer();

		private static readonly AscendingComparer _cachedAscendingComparer = new AscendingComparer();

		private static readonly DescendingComparer _cachedDescendingComparer = new DescendingComparer();

		[SerializeField]
		private bool _autoResort = true;

		[SerializeField]
		private bool _useRowsParentForCullling = true;

		private Coroutine _autoResortCoroutine;

		private int _sortedColumnIndex = -1;

		private SortDirection _sortedDirection;

		private Func<RectTransform, bool> _rowFilter;

		private RectTransform[] _filteredRows;

		private int[] _filteredState;

		private ITableRowProvider _rowProvider;

		private int[] _cachedInstanceIds;

		private CanvasRenderer[][] _cachedCanvasRenderers;

		private bool[] _cachedRowCullState;

		public float RowHeight = 20f;

		public float ColumnSpacing;

		public Action onSortOrderChanged;

		public Action onRowsOrderChanged;

		[FormerlySerializedAs("Header")]
		public RectTransform ColumnHeaders;

		public ScrollRect RowsScrollRect;

		public RectTransform Rows;

		public TableRowCuller TableRowCuller;

		public bool AggressiveRowCaching;

		public bool NoAutoSorting;

		public bool NoLayout;

		public List<ColumnDefinition> ColumnDefinitions = new List<ColumnDefinition>();

		public bool AutoSort
		{
			get
			{
				return _autoResort;
			}
			set
			{
				if (!NoAutoSorting)
				{
					if (_autoResort == value)
					{
						return;
					}
					_autoResort = value;
					if (base.isActiveAndEnabled)
					{
						if (_autoResort)
						{
							StartAutoSort();
						}
						else
						{
							StopAutoSort();
						}
					}
				}
				else
				{
					_autoResort = false;
					StopAutoSort();
				}
			}
		}

		public ITableRowProvider RowProvider
		{
			get
			{
				return _rowProvider;
			}
			set
			{
				if (_rowProvider != value)
				{
					if (_rowProvider != null)
					{
						_rowProvider.AssignTable(null);
					}
					_rowProvider = value;
					if (_rowProvider != null)
					{
						_rowProvider.AssignTable(this);
					}
					Refresh();
				}
			}
		}

		public Func<RectTransform, bool> RowFilter
		{
			set
			{
				if (_rowFilter != value)
				{
					_rowFilter = value;
					Refresh();
				}
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (RowsScrollRect != null)
			{
				RowsScrollRect.onValueChanged.AddListener(OnScroll);
			}
			_samplerSetLayout = CustomSampler.Create("Table.SetLayout");
			_samplerUpdateCulling = CustomSampler.Create("Table.UpdateCulling");
			_samplerSetLayoutColumns = CustomSampler.Create("Table.SetLayout.Columns");
			_samplerSetLayoutFilter = CustomSampler.Create("Table.SetLayout.Filter");
			_samplerUpdateRowCellsLayoutNotTableCell = CustomSampler.Create("Table.UpdateRowCellsLayout.NotTableCell");
			_samplerUpdateRowCellsLayout = CustomSampler.Create("Table.UpdateRowCellsLayout");
			_samplerUpdateRowCellsLayoutSetRect = CustomSampler.Create("Table.UpdateRowCellsLayout.SetCellRect");
			_samplerGetUnfilteredRow = CustomSampler.Create("Table.GetUnfilteredRow");
			_samplerUpdateRowCulling = CustomSampler.Create("Table.UpdateRowCulling");
			_samplerUpdateRowCullingGetRenderers = CustomSampler.Create("Table.UpdateRowCulling.GetRenderers");
			_samplerUpdateRowCullingShowGraphics = CustomSampler.Create("Table.UpdateRowCulling.ShowGraphics");
			_samplerUpdateRowCullingSetDirty = CustomSampler.Create("Table.UpdateRowCulling.SetDirty");
			_samplerUpdateRowGetGraphics = CustomSampler.Create("Table.UpdateRowCulling.GetGraphics");
			StartAutoSort();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (RowsScrollRect != null)
			{
				RowsScrollRect.onValueChanged.RemoveListener(OnScroll);
			}
			StopAutoSort();
		}

		public void SetLayoutHorizontal()
		{
			SetLayout(RectTransform.Axis.Horizontal);
		}

		public void SetLayoutVertical()
		{
			SetLayout(RectTransform.Axis.Vertical);
		}

		public void NotifySortModeChange(ColumnSortButton columnSortButton)
		{
			int num = ColumnDefinitions.FindIndex((ColumnDefinition def) => def.ColumnSortButton == columnSortButton);
			for (int num2 = 0; num2 < ColumnDefinitions.Count; num2++)
			{
				if (num2 != num && ColumnDefinitions[num2].ColumnSortButton != null)
				{
					ColumnDefinitions[num2].ColumnSortButton.SetSortModeWithoutNotifyingTable(ColumnSortButton.SortMode.None);
				}
			}
			switch (columnSortButton.CurrentSortMode)
			{
			case ColumnSortButton.SortMode.Ascending:
				SortColumn(num, SortDirection.Ascending);
				break;
			case ColumnSortButton.SortMode.Descending:
				SortColumn(num, SortDirection.Descending);
				break;
			case ColumnSortButton.SortMode.None:
				_sortedColumnIndex = -1;
				SetRowsToOrginalOrder();
				break;
			}
			if (onSortOrderChanged != null)
			{
				onSortOrderChanged();
			}
		}

		public bool IsSorted(out int columnIndex, out SortDirection sortDirection)
		{
			columnIndex = _sortedColumnIndex;
			sortDirection = _sortedDirection;
			return _sortedColumnIndex >= 0;
		}

		public void SortColumn(int columnIndex, SortDirection sortDirection)
		{
			if (Rows == null)
			{
				return;
			}
			if (_rowProvider != null)
			{
				_rowProvider.SortColumn(columnIndex, sortDirection);
				_sortedColumnIndex = columnIndex;
				_sortedDirection = sortDirection;
				return;
			}
			_cachedComparablesList.Clear();
			if (_rowFilter != null && (_filteredRows == null || _filteredRows.Length < GetRowCount()))
			{
				UpdateFilterRows();
			}
			for (int i = 0; i < GetRowCount(); i++)
			{
				RectTransform filteredRow = GetFilteredRow(i);
				if (!(filteredRow == null) && !(filteredRow.GetComponent<UnsortedRow>() != null) && columnIndex < filteredRow.childCount)
				{
					RectTransform cell = GetCell(filteredRow, columnIndex);
					IComparable comparable = ((cell != null) ? cell.GetComponent<IComparable>() : null);
					if (comparable != null)
					{
						_cachedComparablesList.Add(new SortEntry
						{
							Comparable = comparable,
							OriginalIndex = i
						});
					}
				}
			}
			switch (sortDirection)
			{
			case SortDirection.Ascending:
				_cachedComparablesList.Sort(_cachedAscendingComparer);
				break;
			case SortDirection.Descending:
				_cachedComparablesList.Sort(_cachedDescendingComparer);
				break;
			}
			float num = 0f;
			float y = Rows.anchoredPosition.y;
			float height = ((RectTransform)Rows.parent).rect.height;
			bool flag = false;
			for (int j = 0; j < _cachedComparablesList.Count; j++)
			{
				Transform obj = ((MonoBehaviour)_cachedComparablesList[j].Comparable).transform;
				RectTransform component = obj.parent.GetComponent<RectTransform>();
				if (obj.parent.GetSiblingIndex() != j && component.GetSiblingIndex() != j)
				{
					flag = true;
					component.SetSiblingIndex(j);
				}
				if (_cachedComparablesList[j].OriginalIndex != j)
				{
					component.anchorMin = new Vector2(0f, 1f);
					component.anchorMax = new Vector2(1f, 1f);
					component.sizeDelta = Vector2.zero;
					component.anchoredPosition = Vector2.zero;
					component.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, num, RowHeight);
					UpdateRowCulling(component, j, height, y);
				}
				num += RowHeight;
			}
			_sortedColumnIndex = columnIndex;
			_sortedDirection = sortDirection;
			_cachedComparablesList.Clear();
			if (flag && onRowsOrderChanged != null)
			{
				onRowsOrderChanged();
			}
		}

		public void SetRowsToOrginalOrder()
		{
			if (Rows == null)
			{
				return;
			}
			if (_rowProvider != null)
			{
				_rowProvider.SetRowsToOrginalOrder();
				return;
			}
			List<Transform> list = new List<Transform>(GetRowCount());
			foreach (Transform row in Rows)
			{
				list.Add(row);
			}
			float y = Rows.anchoredPosition.y;
			float height = ((RectTransform)Rows.parent).rect.height;
			bool flag = false;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].GetSiblingIndex() != i)
				{
					flag = true;
					list[i].SetSiblingIndex(i);
				}
				UpdateRowCulling((RectTransform)list[i], i, height, y);
			}
			if (flag && onRowsOrderChanged != null)
			{
				onRowsOrderChanged();
			}
			SetDirty();
		}

		public void Refresh()
		{
			Resort();
			SetDirty();
		}

		public void Resort()
		{
			if (IsSorted(out var columnIndex, out var sortDirection))
			{
				SortColumn(columnIndex, sortDirection);
			}
			else if (_sortedColumnIndex <= 0)
			{
				SetRowsToOrginalOrder();
			}
		}

		public void UpdateCulling()
		{
			float y = Rows.anchoredPosition.y;
			float height = ((RectTransform)Rows.parent).rect.height;
			if (!(Rows != null) || !Rows.gameObject.activeInHierarchy)
			{
				return;
			}
			ResizeCacheArray(ref _filteredState, GetRowCount());
			if (_rowProvider != null)
			{
				for (int i = 0; i < GetRowCount(); i++)
				{
					if (ShouldCullRow(i, height, y))
					{
						_rowProvider.ReleaseRow(i);
					}
					else
					{
						_rowProvider.GetRow(i);
					}
				}
			}
			else
			{
				for (int j = 0; j < GetRowCount(); j++)
				{
					RectTransform unfilteredRow = GetUnfilteredRow(j);
					UpdateRowCulling(unfilteredRow, j, height, y);
				}
			}
		}

		private void OnScroll(Vector2 scrollPos)
		{
			UpdateCulling();
		}

		private bool ShouldCullRow(int rowIndex, float rowsParentHeight, float rowsAnchoredPosition)
		{
			float num = (float)rowIndex * RowHeight;
			float num2 = (float)rowIndex * RowHeight + RowHeight;
			num -= rowsAnchoredPosition;
			if (num2 - rowsAnchoredPosition < 0f)
			{
				return true;
			}
			if (num > rowsParentHeight)
			{
				return true;
			}
			return false;
		}

		private int GetRowCount()
		{
			if (_rowProvider != null)
			{
				return _rowProvider.NumOfRows;
			}
			if (Rows != null)
			{
				return Rows.childCount;
			}
			return 0;
		}

		private RectTransform GetCell(Transform row, int column)
		{
			int num = 0;
			foreach (Transform item in row)
			{
				if (!(item.GetComponent<NotTableCell>() != null))
				{
					if (num == column)
					{
						return item as RectTransform;
					}
					num++;
				}
			}
			return null;
		}

		private static void ResizeCacheArray<T>(ref T[] array, int minimumCapacity)
		{
			if (minimumCapacity < 0)
			{
				throw new Exception($"invalid minimumCapacity {minimumCapacity}");
			}
			if (array == null)
			{
				array = new T[minimumCapacity];
			}
			else if (array.Length < minimumCapacity)
			{
				int num = array.Length * 2;
				if (num < minimumCapacity)
				{
					num = minimumCapacity;
				}
				Array.Resize(ref array, num);
			}
		}

		private void UpdateRowCulling(RectTransform row, int rowChildIndex, float rowsParentHeight, float rowsAnchoredPositionY)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			bool flag = false;
			int rowIndex;
			if (_rowFilter != null)
			{
				if (_filteredState == null || _filteredState.Length < GetRowCount())
				{
					UpdateFilterRows();
				}
				rowIndex = _filteredState[rowChildIndex];
				flag = _filteredState[rowChildIndex] < 0;
			}
			else
			{
				rowIndex = rowChildIndex;
			}
			if (_useRowsParentForCullling)
			{
				flag = flag || ShouldCullRow(rowIndex, rowsParentHeight, rowsAnchoredPositionY);
			}
			bool flag2 = false;
			if (AggressiveRowCaching)
			{
				if (_cachedRowCullState[rowChildIndex] == flag)
				{
					return;
				}
				for (int i = 0; i < _cachedCanvasRenderers[rowChildIndex].Length; i++)
				{
					if (UpdateCanvasRendererCullingAgressiveCaching(rowChildIndex, _cachedCanvasRenderers[rowChildIndex][i], flag))
					{
						flag2 = true;
					}
				}
				_cachedRowCullState[rowChildIndex] = flag;
			}
			else
			{
				_cachedCanvasRenderersList.Clear();
				row.GetComponentsInChildren(_cachedCanvasRenderersList);
				foreach (CanvasRenderer cachedCanvasRenderers in _cachedCanvasRenderersList)
				{
					if (UpdateCanvasRendererCulling(cachedCanvasRenderers, flag))
					{
						flag2 = true;
					}
				}
				_cachedCanvasRenderersList.Clear();
			}
			if (flag2)
			{
				SetDirty();
			}
		}

		private bool UpdateCanvasRendererCulling(CanvasRenderer canvasRenderer, bool cullRow)
		{
			if (canvasRenderer.cull != cullRow)
			{
				canvasRenderer.cull = cullRow;
				if (!cullRow)
				{
					_cachedGraphicsList.Clear();
					canvasRenderer.GetComponents(_cachedGraphicsList);
					for (int i = 0; i < _cachedGraphicsList.Count; i++)
					{
						_cachedGraphicsList[i].SetVerticesDirty();
					}
					_cachedGraphicsList.Clear();
				}
				return true;
			}
			return false;
		}

		private bool UpdateCanvasRendererCullingAgressiveCaching(int rowChildIndex, CanvasRenderer canvasRenderer, bool cullRow)
		{
			if (_cachedRowCullState[rowChildIndex] != cullRow)
			{
				canvasRenderer.cull = cullRow;
				if (!cullRow)
				{
					_cachedGraphicsList.Clear();
					canvasRenderer.GetComponents(_cachedGraphicsList);
					for (int i = 0; i < _cachedGraphicsList.Count; i++)
					{
						_cachedGraphicsList[i].SetVerticesDirty();
					}
					_cachedGraphicsList.Clear();
				}
				return true;
			}
			return false;
		}

		private void SetLayout(RectTransform.Axis axis)
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < ColumnDefinitions.Count; i++)
			{
				num2 += ColumnDefinitions[i].WidthWeight;
			}
			for (int j = 0; j < ColumnDefinitions.Count; j++)
			{
				ColumnDefinitions[j].MinWidthFraction = num;
				ColumnDefinitions[j].MaxWidthFraction = num + Mathf.Clamp01(ColumnDefinitions[j].WidthWeight / num2);
				num = ColumnDefinitions[j].MaxWidthFraction;
				if (!(ColumnHeaders != null) || !ColumnHeaders.gameObject.activeInHierarchy || j >= ColumnHeaders.childCount)
				{
					continue;
				}
				RectTransform rectTransform = ColumnHeaders.GetChild(j) as RectTransform;
				if (!(rectTransform != null))
				{
					continue;
				}
				if (!NoLayout)
				{
					Vector2 anchorMin = rectTransform.anchorMin;
					Vector2 anchorMin2 = new Vector2(ColumnDefinitions[j].MinWidthFraction, 0f);
					if (!Mathf.Approximately(anchorMin.x, anchorMin2.x) || !Mathf.Approximately(anchorMin.y, anchorMin2.y))
					{
						rectTransform.anchorMin = anchorMin2;
					}
					Vector2 anchorMax = rectTransform.anchorMax;
					Vector2 anchorMax2 = new Vector2(ColumnDefinitions[j].MaxWidthFraction, 1f);
					if (!Mathf.Approximately(anchorMax.x, anchorMax2.x) || !Mathf.Approximately(anchorMax.y, anchorMax2.y))
					{
						rectTransform.anchorMax = anchorMax2;
					}
					Vector2 anchorMax3 = rectTransform.anchorMax;
					Vector2 pivot = new Vector2(0f, 0f);
					if (!Mathf.Approximately(anchorMax3.x, pivot.x) || !Mathf.Approximately(anchorMax3.y, pivot.y))
					{
						rectTransform.pivot = pivot;
					}
					Vector2 sizeDelta = rectTransform.sizeDelta;
					Vector2 sizeDelta2 = new Vector2(0f, 0f);
					if (!Mathf.Approximately(sizeDelta.x, sizeDelta2.x) || !Mathf.Approximately(sizeDelta.y, sizeDelta2.y))
					{
						rectTransform.sizeDelta = sizeDelta2;
					}
					Vector2 anchoredPosition = rectTransform.anchoredPosition;
					Vector2 anchoredPosition2 = new Vector2(0f, 0f);
					if (!Mathf.Approximately(anchoredPosition.x, anchoredPosition2.x) || !Mathf.Approximately(anchoredPosition.y, anchoredPosition2.y))
					{
						rectTransform.anchoredPosition = anchoredPosition2;
					}
				}
				rectTransform.GetComponents(_cachedColumnSortButtonList);
				ColumnDefinitions[j].ColumnSortButton = ((_cachedColumnSortButtonList.Count > 0) ? _cachedColumnSortButtonList[0] : null);
				_cachedColumnSortButtonList.Clear();
			}
			int num3 = ((_rowFilter == null) ? GetRowCount() : UpdateFilterRows());
			if (AggressiveRowCaching && _rowProvider == null)
			{
				ResizeCacheArray(ref _cachedInstanceIds, GetRowCount());
				ResizeCacheArray(ref _cachedCanvasRenderers, GetRowCount());
				ResizeCacheArray(ref _cachedRowCullState, GetRowCount());
				for (int k = 0; k < GetRowCount(); k++)
				{
					RectTransform rectTransform2 = Rows.GetChild(k) as RectTransform;
					if (_cachedInstanceIds[k] != rectTransform2.gameObject.GetInstanceID())
					{
						_cachedInstanceIds[k] = rectTransform2.gameObject.GetInstanceID();
						_cachedCanvasRenderers[k] = rectTransform2.GetComponentsInChildren<CanvasRenderer>();
						_cachedRowCullState[k] = false;
						UpdateRowCellsLayout(rectTransform2);
					}
				}
			}
			if (Rows != null && Rows.gameObject.activeInHierarchy)
			{
				if (axis == RectTransform.Axis.Vertical)
				{
					if (RowsScrollRect == null)
					{
						Rows.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Top, 0f, RowHeight * (float)num3);
					}
					else
					{
						Rows.SetSizeWithCurrentAnchorsSafe(RectTransform.Axis.Vertical, RowHeight * (float)num3);
					}
				}
				float num4 = 0f;
				float y = Rows.anchoredPosition.y;
				float height = ((RectTransform)Rows.parent).rect.height;
				for (int l = 0; l < num3; l++)
				{
					if (_rowProvider != null && ShouldCullRow(l, height, y))
					{
						num4 += RowHeight;
						continue;
					}
					RectTransform filteredRow = GetFilteredRow(l);
					if (filteredRow == null)
					{
						continue;
					}
					if (_rowProvider == null && ShouldCullRow(l, height, y))
					{
						num4 += RowHeight;
						continue;
					}
					Vector2 anchorMin3 = filteredRow.anchorMin;
					if (!Mathf.Approximately(anchorMin3.x, 0f))
					{
						filteredRow.anchorMin = new Vector2(0f, anchorMin3.y);
					}
					Vector2 anchorMax4 = filteredRow.anchorMax;
					if (!Mathf.Approximately(anchorMax4.x, 1f))
					{
						filteredRow.anchorMax = new Vector2(1f, anchorMax4.y);
					}
					Vector2 sizeDelta3 = filteredRow.sizeDelta;
					if (!Mathf.Approximately(sizeDelta3.x, 0f))
					{
						filteredRow.sizeDelta = new Vector2(0f, sizeDelta3.x);
					}
					Vector2 anchoredPosition3 = filteredRow.anchoredPosition;
					if (!Mathf.Approximately(anchoredPosition3.x, 0f))
					{
						filteredRow.anchoredPosition = new Vector2(0f, anchoredPosition3.x);
					}
					filteredRow.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Top, num4, RowHeight);
					num4 += RowHeight;
					if (!AggressiveRowCaching)
					{
						UpdateRowCellsLayout(filteredRow);
					}
				}
			}
			if (RowsScrollRect != null)
			{
				RowsScrollRect.SetLayoutVertical();
				RowsScrollRect.SetLayoutHorizontal();
				RowsScrollRect.verticalNormalizedPosition = Mathf.Clamp01(RowsScrollRect.verticalNormalizedPosition);
			}
			UpdateCulling();
		}

		private int UpdateFilterRows()
		{
			ResizeCacheArray(ref _filteredRows, GetRowCount());
			ResizeCacheArray(ref _filteredState, GetRowCount());
			int num = -1;
			for (int i = 0; i < GetRowCount(); i++)
			{
				_filteredRows[i] = null;
				RectTransform rectTransform = Rows.GetChild(i) as RectTransform;
				if (_rowFilter(rectTransform))
				{
					num++;
					_filteredState[i] = num;
					_filteredRows[num] = rectTransform;
				}
				else
				{
					_filteredState[i] = -1;
				}
			}
			return num + 1;
		}

		private void UpdateRowCellsLayout(Transform row)
		{
			int num = 0;
			foreach (Transform item in row)
			{
				if (num >= ColumnDefinitions.Count)
				{
					break;
				}
				item.GetComponents(_cachedNotTableCell);
				if (_cachedNotTableCell.Count > 0)
				{
					continue;
				}
				RectTransform rectTransform = item as RectTransform;
				if (!(rectTransform == null) && rectTransform.gameObject.activeInHierarchy && !NoLayout)
				{
					Vector2 anchorMin = rectTransform.anchorMin;
					Vector2 anchorMin2 = new Vector2(ColumnDefinitions[num].MinWidthFraction, 0f);
					if (!Mathf.Approximately(anchorMin.x, anchorMin2.x) || !Mathf.Approximately(anchorMin.y, anchorMin2.y))
					{
						rectTransform.anchorMin = anchorMin2;
					}
					Vector2 anchorMax = rectTransform.anchorMax;
					Vector2 anchorMax2 = new Vector2(ColumnDefinitions[num].MaxWidthFraction, 1f);
					if (!Mathf.Approximately(anchorMax.x, anchorMax2.x) || !Mathf.Approximately(anchorMax.y, anchorMax2.y))
					{
						rectTransform.anchorMax = anchorMax2;
					}
					Vector2 anchorMax3 = rectTransform.anchorMax;
					Vector2 pivot = new Vector2(0f, 0f);
					if (!Mathf.Approximately(anchorMax3.x, pivot.x) || !Mathf.Approximately(anchorMax3.y, pivot.y))
					{
						rectTransform.pivot = pivot;
					}
					Vector2 sizeDelta = rectTransform.sizeDelta;
					Vector2 sizeDelta2 = new Vector2(0f, 0f);
					if (!Mathf.Approximately(sizeDelta.x, sizeDelta2.x) || !Mathf.Approximately(sizeDelta.y, sizeDelta2.y))
					{
						rectTransform.sizeDelta = sizeDelta2;
					}
					Vector2 anchoredPosition = rectTransform.anchoredPosition;
					Vector2 anchoredPosition2 = new Vector2(0f, 0f);
					if (!Mathf.Approximately(anchoredPosition.x, anchoredPosition2.x) || !Mathf.Approximately(anchoredPosition.y, anchoredPosition2.y))
					{
						rectTransform.anchoredPosition = anchoredPosition2;
					}
					num++;
				}
			}
		}

		private IEnumerator ResortCoroutine()
		{
			while (true)
			{
				yield return new WaitForSecondsRealtime(1f);
				Resort();
			}
		}

		private void StartAutoSort()
		{
			if (NoAutoSorting)
			{
				StopAutoSort();
			}
			else if (_autoResort)
			{
				_autoResortCoroutine = StartCoroutine(ResortCoroutine());
			}
		}

		private void StopAutoSort()
		{
			if (_autoResortCoroutine != null)
			{
				StopCoroutine(_autoResortCoroutine);
				_autoResortCoroutine = null;
			}
		}

		public RectTransform GetUnfilteredRow(int rowIndex)
		{
			if (_rowProvider != null)
			{
				return _rowProvider.GetRow(rowIndex);
			}
			if (Rows != null && rowIndex < GetRowCount())
			{
				return Rows.GetChild(rowIndex) as RectTransform;
			}
			return null;
		}

		public RectTransform GetFilteredRow(int rowIndex)
		{
			if (_rowFilter == null)
			{
				return GetUnfilteredRow(rowIndex);
			}
			if (Rows == null || rowIndex >= GetRowCount())
			{
				return null;
			}
			return _filteredRows[rowIndex];
		}
	}
}
