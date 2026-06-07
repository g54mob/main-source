namespace Dhs5.Utility.Updates
{
	public interface IUpdateChannel
	{
		EUpdateChannel Channel { get; }

		EUpdatePass Pass { get; }

		ushort Order { get; }

		bool EnabledByDefault { get; }

		EUpdateCondition Condition { get; }

		float Frequency { get; }

		float TimeScale { get; }

		bool Realtime { get; }
	}
}
