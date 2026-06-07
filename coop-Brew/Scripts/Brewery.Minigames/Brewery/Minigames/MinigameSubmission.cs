using Unity.Netcode;

namespace Brewery.Minigames
{
	public struct MinigameSubmission : INetworkSerializable
	{
		public int stepIndex;

		public int seed;

		public MinigameId minigameId;

		public int rawScore;

		public MinigameTier tier;

		public bool overclock;

		public int clientRuntimeMs;

		public int comboMax;

		public int eventSuccesses;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
