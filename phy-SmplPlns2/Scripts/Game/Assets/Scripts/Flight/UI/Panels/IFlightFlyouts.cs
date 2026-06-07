using Assets.Scripts.UI;

namespace Assets.Scripts.Flight.UI.Panels
{
	public interface IFlightFlyouts
	{
		IFlyout ActivitySettings { get; }

		IFlyout ChangeCraft { get; }

		IFlyout Menu { get; }

		IFlyout PlayerList { get; }

		IFlyout Selected { get; set; }

		IFlyout SelectLocation { get; }

		IFlyout ServerSettings { get; }

		IFlyout Settings { get; }

		IFlyout SpawnCraft { get; }

		IFlyout FindById(string id);

		void ToggleFlyout(IFlyout flyout);
	}
}
