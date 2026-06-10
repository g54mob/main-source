using NSEipix.Base;
using NSMedieval.WorldMap;

namespace NSMedieval.UI
{
	public abstract class CaravanPanelView : PopupView
	{
		public CaravanInstance CaravanInstance { get; set; }

		public abstract void UpdatedWorkersCount();
	}
}
