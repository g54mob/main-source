using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class PatronSatisfactionPatronChartItemView : BaseInteractable3DUIView
	{
		[SerializeField]
		private Transform _modelParent;

		public PatronSatisfactionChart.ChartItem ChartItem { get; set; }

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		public void AppendModel(GameObject model)
		{
		}
	}
}
