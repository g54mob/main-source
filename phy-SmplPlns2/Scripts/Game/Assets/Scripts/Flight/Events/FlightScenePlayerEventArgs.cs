namespace Assets.Scripts.Flight.Events
{
	public class FlightScenePlayerEventArgs
	{
		public FlightScenePlayer Player { get; }

		public FlightScenePlayerEventArgs(FlightScenePlayer player)
		{
			Player = player;
		}
	}
}
