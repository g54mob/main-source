using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Minigames
{
	public struct MinigameRewardResult : INetworkSerializable
	{
		public float secondsGranted;

		public float totalSecondsGrantedThisStep;

		public int rushMeter;

		public MinigameTier rushTier;

		public int qualityDelta;

		public int yieldDelta;

		public bool tierUpOccurred;

		public float instantBonusGranted;

		public bool rejected;

		public FixedString64Bytes rejectReason;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
