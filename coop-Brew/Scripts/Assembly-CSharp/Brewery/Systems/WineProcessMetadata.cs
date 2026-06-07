using System;
using Unity.Netcode;

namespace Brewery.Systems
{
	[Serializable]
	public struct WineProcessMetadata : INetworkSerializable
	{
		public WineStep currentStep;

		public bool primaryFermentationComplete;

		public bool pressRackComplete;

		public bool agingPrepComplete;

		public bool usedYeastNutrients;

		public bool usedRiceHulls;

		public bool usedDefoamer;

		public double currentStepStartTime;

		public double currentStepDuration;

		public int totalBatches;

		public int currentBatch;

		public int batchesCompleted;

		public ulong operatorClientId;

		public static WineProcessMetadata CreateNew()
		{
			return default(WineProcessMetadata);
		}

		public int CalculateFinalBottles()
		{
			return 0;
		}

		public int CalculateFinalBottles(ulong clientId)
		{
			return 0;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
