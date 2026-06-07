using Unity.Netcode;

namespace MyStuff.Environment
{
	public struct TimeOfDayState : INetworkSerializable
	{
		public float NormalizedTime;

		public int DayIndex;

		public float TimeScale;

		public bool IsPaused;

		public float ServerTimestamp;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
