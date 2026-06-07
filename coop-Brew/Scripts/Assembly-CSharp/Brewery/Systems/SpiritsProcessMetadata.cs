using System;
using Unity.Netcode;

namespace Brewery.Systems
{
	[Serializable]
	public struct SpiritsProcessMetadata : INetworkSerializable
	{
		public SpiritsStep currentStep;

		public bool mashingComplete;

		public bool fermentationComplete;

		public bool distillationComplete;

		public bool usedYeastNutrients;

		public bool usedEnzymePack;

		public bool usedRiceHulls;

		public double currentStepStartTime;

		public double currentStepDuration;

		public ulong operatorClientId;

		public static SpiritsProcessMetadata CreateNew()
		{
			return default(SpiritsProcessMetadata);
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
