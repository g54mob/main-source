using Gh.Tk.UI.Dialogs;

namespace Gh.Tk
{
	public class ChartItemInteractable3DUIView : Button3DUIView
	{
		public PatronAttractionChart.AttractionChartItem chartItem;

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
