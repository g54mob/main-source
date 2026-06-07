namespace ModApi.Flight.UI
{
	public interface IFlightLogUI
	{
		bool Collapsed { get; set; }

		IFlightLog FlightLog { get; }

		bool Pinned { get; set; }

		bool Visible { get; set; }
	}
}
