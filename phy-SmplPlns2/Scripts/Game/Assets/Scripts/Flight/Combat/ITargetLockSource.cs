namespace Assets.Scripts.Flight.Combat
{
	public interface ITargetLockSource
	{
		FlightScenePlayer Player { get; }

		ushort TeamId { get; }
	}
}
