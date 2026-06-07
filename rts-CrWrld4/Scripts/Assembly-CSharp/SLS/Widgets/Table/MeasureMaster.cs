using UnityEngine;
using UnityEngine.UI;

namespace SLS.Widgets.Table
{
	public class MeasureMaster : MonoBehaviour
	{
		public Table table;

		public Control control;

		private Text text;

		private decimal datumRevision;

		public void Initialize(Table table, Text text, Control control)
		{
		}

		private float SumColumnWidths()
		{
			return 0f;
		}

		public void DoMeasure(Row r)
		{
		}

		public void MeasureCell(Datum d, Element e, Column c)
		{
		}

		private void MeasureCellDone(Column c, Datum d, Element e)
		{
		}
	}
}
