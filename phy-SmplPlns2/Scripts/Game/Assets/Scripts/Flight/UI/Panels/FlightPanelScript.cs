using Assets.Scripts.UI;
using Jundroo.Juicy;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class FlightPanelScript : WidgetScript
	{
		public FlightUIScript FlightUI { get; private set; }

		public IFlyout Flyout { get; private set; }

		public virtual void InitializeFlightPanel(FlightUIScript flightUI)
		{
			FlightUI = flightUI;
			Flyout = GetComponentInParent<IFlyout>(includeInactive: true);
		}
	}
}
