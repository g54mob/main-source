namespace Assets.Scripts.Flight.WorldObjects
{
	public interface IFlightSceneResettableObject
	{
		string DisplayName { get; }

		float ResetTimer { get; set; }

		int UniqueId { get; }

		void ResetObject();
	}
}
