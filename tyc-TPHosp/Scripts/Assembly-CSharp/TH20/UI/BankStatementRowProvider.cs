using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class BankStatementRowProvider : ITableRowProvider
	{
		private GameObject _rowPrefab;

		private Table _table;

		private List<HospitalEvent> _events = new List<HospitalEvent>();

		private List<PanelItemStatementElement> _rowsPool = new List<PanelItemStatementElement>();

		private Dictionary<int, PanelItemStatementElement> _rowsInUse = new Dictionary<int, PanelItemStatementElement>();

		private List<Graphic> _cachedGraphicsList = new List<Graphic>(8);

		public int NumOfRows => _events.Count;

		public BankStatementRowProvider(List<HospitalEvent> events, GameObject rowPrefab)
		{
			_rowPrefab = rowPrefab;
			_events.AddRange(events);
		}

		public void AssignTable(Table table)
		{
			_table = table;
		}

		public void ReleaseRow(int i)
		{
			if (_rowsInUse.TryGetValue(i, out var value))
			{
				value.SetData(null);
				_rowsPool.Add(value);
				_rowsInUse.Remove(i);
				CanvasRenderer[] componentsInChildren = value.GetComponentsInChildren<CanvasRenderer>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					componentsInChildren[j].cull = true;
				}
			}
		}

		public RectTransform GetRow(int i)
		{
			if (_rowsInUse.TryGetValue(i, out var value))
			{
				return value.GetComponent<RectTransform>();
			}
			_table.SetDirty();
			if (_rowsPool.Count == 0)
			{
				value = Object.Instantiate(_rowPrefab).GetComponent<PanelItemStatementElement>();
				value.transform.SetParent(_table.Rows.transform, worldPositionStays: false);
			}
			else
			{
				value = _rowsPool[_rowsPool.Count - 1];
				_rowsPool.RemoveAt(_rowsPool.Count - 1);
				CanvasRenderer[] componentsInChildren = value.GetComponentsInChildren<CanvasRenderer>();
				foreach (CanvasRenderer obj in componentsInChildren)
				{
					obj.cull = false;
					_cachedGraphicsList.Clear();
					obj.GetComponents(_cachedGraphicsList);
					for (int k = 0; k < _cachedGraphicsList.Count; k++)
					{
						_cachedGraphicsList[k].SetVerticesDirty();
					}
					_cachedGraphicsList.Clear();
				}
			}
			value.SetData(_events[i]);
			_rowsInUse.Add(i, value);
			return value.GetComponent<RectTransform>();
		}

		public void SortColumn(int columnIndex, Table.SortDirection sortDirection)
		{
		}

		public void SetRowsToOrginalOrder()
		{
		}
	}
}
