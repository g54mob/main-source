using System;
using Unity.Netcode;

namespace Brewery.Systems
{
	[Serializable]
	public struct BoilingProcessMetadata : INetworkSerializable
	{
		public BoilingStep currentStep;

		public bool converted;

		public bool sterilized;

		public bool tempOK;

		public bool pitched;

		public bool usedEnzymePack;

		public bool usedRiceHulls;

		public bool usedDefoamer;

		public bool usedYeastNutrient;

		public double cooldownStartTime;

		public float cooldownDuration;

		public int totalBatches;

		public int currentBatch;

		public int batchesCompleted;

		public float effectiveConversionDuration;

		public float effectiveSterilizationDuration;

		public float effectiveCooldownDuration;

		public ulong operatorClientId;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public static BoilingProcessMetadata CreateNew()
		{
			return default(BoilingProcessMetadata);
		}

		public int CalculateFinalBottles()
		{
			return 0;
		}

		public int CalculateFinalBottles(ulong clientId)
		{
			return 0;
		}
	}
}
