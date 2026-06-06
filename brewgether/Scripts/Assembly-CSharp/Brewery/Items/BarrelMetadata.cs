using System;
using Brewery.Core;
using Unity.Netcode;

namespace Brewery.Items
{
	[Serializable]
	public struct BarrelMetadata : INetworkSerializable
	{
		public BarrelState state;

		public BeverageType beverageType;

		public double fermentationStartTime;

		public double agingStartTime;

		public int remainingBottles;

		public float effectiveFermentationDuration;

		public float effectiveAgingDuration;

		public float effectiveSpoilDuration;

		public double spoilStartTime;

		public bool IsBeer => false;

		public bool IsWine => false;

		public bool IsSpirits => false;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public string ToJson()
		{
			return null;
		}

		public static BarrelMetadata? FromJson(string json)
		{
			return null;
		}
	}
}
