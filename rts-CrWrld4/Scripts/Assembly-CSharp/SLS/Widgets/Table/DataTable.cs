using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SLS.Widgets.Table
{
	public class DataTable : MonoBehaviour
	{
		public Table table;

		public Sprite sprite1;

		public Sprite sprite2;

		public Sprite sprite3;

		public Sprite sprite4;

		public Sprite sprite5;

		public Sprite iconUp;

		public Sprite iconDown;

		private Dictionary<string, Sprite> spriteDict;

		private List<string> spriteNames;

		private List<DataTableData.Population> poplist;

		private void Start()
		{
		}

		public void DrawTable()
		{
		}

		private void OnInputFieldChange(Datum d, Column c, string oldVal, string newVal)
		{
		}

		private void OnTableSelectedWithCol(Datum datum, Column column)
		{
		}

		public void MoveSelection()
		{
		}

		private void OnHeaderClick(Column column, PointerEventData e)
		{
		}
	}
}
