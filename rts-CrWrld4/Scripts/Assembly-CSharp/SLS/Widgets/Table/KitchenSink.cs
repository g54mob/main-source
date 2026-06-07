using System.Collections.Generic;
using UnityEngine;

namespace SLS.Widgets.Table
{
	public class KitchenSink : MonoBehaviour
	{
		public Table table;

		public Sprite sprite1;

		public Sprite sprite2;

		public Sprite sprite3;

		public Sprite sprite4;

		public Sprite sprite5;

		private bool started;

		private int colCount;

		private int rowCount;

		private Dictionary<string, Sprite> spriteDict;

		private void Start()
		{
		}

		private void DoTable(int numCols, int numRows, bool initial = false)
		{
		}

		private void SelectionCallback(Datum d)
		{
		}
	}
}
