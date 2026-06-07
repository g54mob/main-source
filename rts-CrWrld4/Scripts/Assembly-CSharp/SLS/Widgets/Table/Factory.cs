using UnityEngine;

namespace SLS.Widgets.Table
{
	public class Factory
	{
		private bool firstBuild;

		private Control control;

		private Table table;

		public Factory(Table table)
		{
		}

		public void Build(Datum headerDatum, Datum footerDatum, Control control)
		{
		}

		public void MakeRows()
		{
		}

		private void InstantiateCells(Row row, bool isHeader, bool isFooter)
		{
		}

		private void MakeScrollbar(bool hor)
		{
		}

		private MeasureMaster MakeMeasureMaster(RectTransform parent)
		{
			return null;
		}
	}
}
