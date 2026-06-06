using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Stations
{
	[Serializable]
	public struct StationUpgradeData : INetworkSerializable, IEquatable<StationUpgradeData>
	{
		public bool hasTier1AutoSensor;

		public bool hasTier2MaterialSensor;

		public int totalBatches;

		public int currentBatch;

		public int leftoverMaterials;

		public float batchProcessingTime;

		public float currentBatchTimer;

		public bool isBatchProcessing;

		public ulong batchStarterClientId;

		public int internalGrapeMustCount;

		public FixedString64Bytes sensorMaterial1Id;

		public int sensorMaterial1Quantity;

		public FixedString64Bytes sensorMaterial2Id;

		public int sensorMaterial2Quantity;

		public FixedString64Bytes sensorMaterial3Id;

		public int sensorMaterial3Quantity;

		public FixedString64Bytes sensorMaterial4Id;

		public int sensorMaterial4Quantity;

		public const int MaxSensorMaterialCapacity = 10;

		public const int MaxSensorSlots = 4;

		public const ulong NoPlayerClientId = ulong.MaxValue;

		public static StationUpgradeData CreateNew()
		{
			return default(StationUpgradeData);
		}

		public int GetSensorMaterialQuantity(string itemId)
		{
			return 0;
		}

		public bool SetSensorMaterialQuantity(string itemId, int quantity)
		{
			return false;
		}

		public bool ConsumeSensorMaterial(string itemId)
		{
			return false;
		}

		public float GetBatchProgress()
		{
			return 0f;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(StationUpgradeData other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		private static bool TryUpdateSlot(ref FixedString64Bytes slotId, ref int slotQuantity, string targetId, int quantity)
		{
			return false;
		}

		private static bool TryAssignEmptySlot(ref FixedString64Bytes slotId, ref int slotQuantity, string targetId, int quantity)
		{
			return false;
		}

		private static void ClearSlotIfEmpty(ref FixedString64Bytes slotId, ref int slotQuantity)
		{
		}

		private static bool FixedStringEquals(FixedString64Bytes fixedString, string value)
		{
			return false;
		}
	}
}
