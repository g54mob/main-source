using System.Collections;
using System.Collections.Generic;

namespace SLS.Widgets.Table
{
	public class TableDatumList : IEnumerable<Datum>, IEnumerable
	{
		private Table table;

		private Control control;

		private List<Datum> list;

		private Dictionary<string, int> indexes;

		private int count;

		private float? _safeTempRowHeight;

		private bool _doingSafeHeightSum;

		private float? _avgHeight;

		private float? _safeHeightSum;

		private bool _changing;

		public int Count => 0;

		public float safeTempRowHeight => 0f;

		public bool doingSafeHeightSum => false;

		public float safeHeightSum => 0f;

		public bool changing => false;

		public Datum Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TableDatumList(Table table, Control control)
		{
		}

		private void InitDatum(Datum item, bool isNew = true)
		{
		}

		public void ClearMeasured()
		{
		}

		public void ClearSafeHeightSum()
		{
		}

		public void ClearMeasuredVertPos()
		{
		}

		private void FinishDataChange()
		{
		}

		private void RebuildIndexes()
		{
		}

		public void AddAll(List<Datum> items)
		{
		}

		public void Add(Datum item, bool finishAfterAdd = true)
		{
		}

		public void Clear(bool finishDataChange = true)
		{
		}

		public bool Contains(Datum item)
		{
			return false;
		}

		public Datum Get(string uid)
		{
			return null;
		}

		public bool Remove(string uid)
		{
			return false;
		}

		public bool Remove(Datum item)
		{
			return false;
		}

		public void Insert(int index, Datum item)
		{
		}

		public void RemoveAt(int index)
		{
		}

		public int IndexOf(Datum item)
		{
			return 0;
		}

		public int IndexOf(string uid)
		{
			return 0;
		}

		public bool Update(Datum item)
		{
			return false;
		}

		public IEnumerator<Datum> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
