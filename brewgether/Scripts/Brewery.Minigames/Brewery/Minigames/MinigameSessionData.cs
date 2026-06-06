using Unity.Netcode;

namespace Brewery.Minigames
{
	public struct MinigameSessionData : INetworkSerializable
	{
		public MinigameId id;

		public int seed;

		public double sessionStartServerTime;

		public float maxRewardSeconds;

		public float alreadyGrantedSeconds;

		public int submissionsCountTotal;

		public int rushMeter;

		public MinigameTier rushTier;

		public float stepDurationEffective;

		public int stepIndex;

		public bool overclock;

		public float RemainingCapSeconds => 0f;

		public bool IsCapReached => false;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public static MinigameSessionData Create(int stepIndex, int seed, float stepDurationEffective, int carryOverRushMeter)
		{
			return default(MinigameSessionData);
		}

		public static MinigameTier ComputeRushTier(int rushMeter)
		{
			return default(MinigameTier);
		}
	}
}
