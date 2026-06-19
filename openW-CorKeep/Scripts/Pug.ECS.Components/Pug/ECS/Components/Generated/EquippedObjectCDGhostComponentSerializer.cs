using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.NetCode;
using Unity.NetCode.LowLevel.Unsafe;

namespace Pug.ECS.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	public struct EquippedObjectCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int equippedSlotIndex;

			public int containedObject_objectData_objectID;

			public int containedObject_objectData_amount;

			public int containedObject_objectData_variation;

			public int containedObject_objectData_variationUpdateCount;

			public int containedObject_auxDataIndex;
		}

		private const int ChangeMaskBits = 6;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 6;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<EquippedObjectCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<EquippedObjectCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CalculateChangeMask([NoAlias][ReadOnly] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			CalculateChangeMaskGenerated(in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshot), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline), changeMaskData, startOffset);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void PredictDelta([NoAlias] IntPtr snapshotData, [NoAlias] IntPtr baseline1Data, [NoAlias] IntPtr baseline2Data, ref GhostDeltaPredictor predictor)
		{
			PredictDeltaGenerated(ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotData), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline1Data), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline2Data), ref predictor);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SerializeWithPredictedBaseline([ReadOnly][NoAlias] IntPtr snapshot, [ReadOnly][NoAlias] IntPtr baseline0, [ReadOnly][NoAlias] IntPtr baseline1, [ReadOnly][NoAlias] IntPtr baseline2, ref GhostDeltaPredictor predictor, [NoAlias][ReadOnly] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			Snapshot snapshot2 = GhostComponentSerializer.TypeCast<Snapshot>(baseline0);
			PredictDeltaGenerated(ref snapshot2, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline1), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline2), ref predictor);
			SerializeCombinedGenerated(in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshot), in snapshot2, changeMaskData, startOffset, ref writer, in compressionModel);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SerializeCombined([ReadOnly][NoAlias] IntPtr snapshot, [ReadOnly][NoAlias] IntPtr baseline, [NoAlias][ReadOnly] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			SerializeCombinedGenerated(in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshot), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline), changeMaskData, startOffset, ref writer, in compressionModel);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Serialize([ReadOnly][NoAlias] IntPtr snapshot, [ReadOnly][NoAlias] IntPtr baseline, [NoAlias][ReadOnly] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			SerializeGenerated(in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshot), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline), changeMaskData, startOffset, ref writer, in compressionModel);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Deserialize(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMask, int startOffset, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr baseline)
		{
			DeserializeGenerated(ref reader, in compressionModel, changeMask, startOffset, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RestoreFromBackup([NoAlias] IntPtr component, [NoAlias][ReadOnly] IntPtr backup)
		{
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<EquippedObjectCD>(component), in GhostComponentSerializer.TypeCastReadonly<EquippedObjectCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in EquippedObjectCD component)
		{
			snapshot.equippedSlotIndex = component.equippedSlotIndex;
			snapshot.containedObject_objectData_objectID = (int)component.containedObject.objectData.objectID;
			snapshot.containedObject_objectData_amount = component.containedObject.objectData.amount;
			snapshot.containedObject_objectData_variation = component.containedObject.objectData.variation;
			snapshot.containedObject_objectData_variationUpdateCount = component.containedObject.objectData.variationUpdateCount;
			snapshot.containedObject_auxDataIndex = component.containedObject.auxDataIndex;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref EquippedObjectCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.equippedSlotIndex = snapshotBefore.equippedSlotIndex;
			component.containedObject.objectData.objectID = (ObjectID)snapshotBefore.containedObject_objectData_objectID;
			component.containedObject.objectData.amount = snapshotBefore.containedObject_objectData_amount;
			component.containedObject.objectData.variation = snapshotBefore.containedObject_objectData_variation;
			component.containedObject.objectData.variationUpdateCount = snapshotBefore.containedObject_objectData_variationUpdateCount;
			component.containedObject.auxDataIndex = snapshotBefore.containedObject_auxDataIndex;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref EquippedObjectCD component, in EquippedObjectCD backup)
		{
			component.equippedSlotIndex = backup.equippedSlotIndex;
			component.containedObject.objectData.objectID = backup.containedObject.objectData.objectID;
			component.containedObject.objectData.amount = backup.containedObject.objectData.amount;
			component.containedObject.objectData.variation = backup.containedObject.objectData.variation;
			component.containedObject.objectData.variationUpdateCount = backup.containedObject.objectData.variationUpdateCount;
			component.containedObject.auxDataIndex = backup.containedObject.auxDataIndex;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.equippedSlotIndex = predictor.PredictInt(snapshot.equippedSlotIndex, baseline1.equippedSlotIndex, baseline2.equippedSlotIndex);
			snapshot.containedObject_objectData_objectID = predictor.PredictInt(snapshot.containedObject_objectData_objectID, baseline1.containedObject_objectData_objectID, baseline2.containedObject_objectData_objectID);
			snapshot.containedObject_objectData_amount = predictor.PredictInt(snapshot.containedObject_objectData_amount, baseline1.containedObject_objectData_amount, baseline2.containedObject_objectData_amount);
			snapshot.containedObject_objectData_variation = predictor.PredictInt(snapshot.containedObject_objectData_variation, baseline1.containedObject_objectData_variation, baseline2.containedObject_objectData_variation);
			snapshot.containedObject_objectData_variationUpdateCount = predictor.PredictInt(snapshot.containedObject_objectData_variationUpdateCount, baseline1.containedObject_objectData_variationUpdateCount, baseline2.containedObject_objectData_variationUpdateCount);
			snapshot.containedObject_auxDataIndex = predictor.PredictInt(snapshot.containedObject_auxDataIndex, baseline1.containedObject_auxDataIndex, baseline2.containedObject_auxDataIndex);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.equippedSlotIndex != baseline.equippedSlotIndex) ? 1u : 0u);
			num |= (uint)((snapshot.containedObject_objectData_objectID != baseline.containedObject_objectData_objectID) ? 2 : 0);
			num |= (uint)((snapshot.containedObject_objectData_amount != baseline.containedObject_objectData_amount) ? 4 : 0);
			num |= (uint)((snapshot.containedObject_objectData_variation != baseline.containedObject_objectData_variation) ? 8 : 0);
			num |= (uint)((snapshot.containedObject_objectData_variationUpdateCount != baseline.containedObject_objectData_variationUpdateCount) ? 16 : 0);
			num |= (uint)((snapshot.containedObject_auxDataIndex != baseline.containedObject_auxDataIndex) ? 32 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.equippedSlotIndex, baseline.equippedSlotIndex, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.containedObject_objectData_objectID, baseline.containedObject_objectData_objectID, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.containedObject_objectData_amount, baseline.containedObject_objectData_amount, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.containedObject_objectData_variation, baseline.containedObject_objectData_variation, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.containedObject_objectData_variationUpdateCount, baseline.containedObject_objectData_variationUpdateCount, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.containedObject_auxDataIndex, baseline.containedObject_auxDataIndex, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.equippedSlotIndex != baseline.equippedSlotIndex) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.equippedSlotIndex, baseline.equippedSlotIndex, in compressionModel);
			}
			num |= (uint)((snapshot.containedObject_objectData_objectID != baseline.containedObject_objectData_objectID) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.containedObject_objectData_objectID, baseline.containedObject_objectData_objectID, in compressionModel);
			}
			num |= (uint)((snapshot.containedObject_objectData_amount != baseline.containedObject_objectData_amount) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.containedObject_objectData_amount, baseline.containedObject_objectData_amount, in compressionModel);
			}
			num |= (uint)((snapshot.containedObject_objectData_variation != baseline.containedObject_objectData_variation) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.containedObject_objectData_variation, baseline.containedObject_objectData_variation, in compressionModel);
			}
			num |= (uint)((snapshot.containedObject_objectData_variationUpdateCount != baseline.containedObject_objectData_variationUpdateCount) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.containedObject_objectData_variationUpdateCount, baseline.containedObject_objectData_variationUpdateCount, in compressionModel);
			}
			num |= (uint)((snapshot.containedObject_auxDataIndex != baseline.containedObject_auxDataIndex) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.containedObject_auxDataIndex, baseline.containedObject_auxDataIndex, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				snapshot.equippedSlotIndex = reader.ReadPackedIntDelta(baseline.equippedSlotIndex, in compressionModel);
			}
			else
			{
				snapshot.equippedSlotIndex = baseline.equippedSlotIndex;
			}
			if ((num & 2) != 0)
			{
				snapshot.containedObject_objectData_objectID = reader.ReadPackedIntDelta(baseline.containedObject_objectData_objectID, in compressionModel);
			}
			else
			{
				snapshot.containedObject_objectData_objectID = baseline.containedObject_objectData_objectID;
			}
			if ((num & 4) != 0)
			{
				snapshot.containedObject_objectData_amount = reader.ReadPackedIntDelta(baseline.containedObject_objectData_amount, in compressionModel);
			}
			else
			{
				snapshot.containedObject_objectData_amount = baseline.containedObject_objectData_amount;
			}
			if ((num & 8) != 0)
			{
				snapshot.containedObject_objectData_variation = reader.ReadPackedIntDelta(baseline.containedObject_objectData_variation, in compressionModel);
			}
			else
			{
				snapshot.containedObject_objectData_variation = baseline.containedObject_objectData_variation;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.containedObject_objectData_variationUpdateCount = reader.ReadPackedIntDelta(baseline.containedObject_objectData_variationUpdateCount, in compressionModel);
			}
			else
			{
				snapshot.containedObject_objectData_variationUpdateCount = baseline.containedObject_objectData_variationUpdateCount;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.containedObject_auxDataIndex = reader.ReadPackedIntDelta(baseline.containedObject_auxDataIndex, in compressionModel);
			}
			else
			{
				snapshot.containedObject_auxDataIndex = baseline.containedObject_auxDataIndex;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 5032326342240550756uL,
					ComponentType = ComponentType.ReadWrite<EquippedObjectCD>(),
					ComponentSize = UnsafeUtility.SizeOf<EquippedObjectCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 6,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 16037615631324036570uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<EquippedObjectCD, Snapshot, EquippedObjectCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
			}
			return s_State;
		}

		void IGhostSerializer.CopyToSnapshot(in GhostSerializerState serializerState, IntPtr snapshot, IntPtr component)
		{
			CopyToSnapshot(in serializerState, snapshot, component);
		}

		void IGhostSerializer.CopyFromSnapshot(in GhostDeserializerState serializerState, IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, IntPtr snapshotBefore, IntPtr snapshotAfter)
		{
			CopyFromSnapshot(in serializerState, component, snapshotInterpolationFactor, snapshotInterpolationFactorRaw, snapshotBefore, snapshotAfter);
		}

		void IGhostSerializer.SerializeCombined(IntPtr snapshot, IntPtr baseline, IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			SerializeCombined(snapshot, baseline, changeMaskData, startOffset, ref writer, in compressionModel);
		}

		void IGhostSerializer.SerializeWithPredictedBaseline(IntPtr snapshot, IntPtr baseline0, IntPtr baseline1, IntPtr baseline2, ref GhostDeltaPredictor predictor, IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			SerializeWithPredictedBaseline(snapshot, baseline0, baseline1, baseline2, ref predictor, changeMaskData, startOffset, ref writer, in compressionModel);
		}

		void IGhostSerializer.Serialize(IntPtr snapshot, IntPtr baseline, IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			Serialize(snapshot, baseline, changeMaskData, startOffset, ref writer, in compressionModel);
		}

		void IGhostSerializer.Deserialize(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMask, int startOffset, IntPtr snapshot, IntPtr baseline)
		{
			Deserialize(ref reader, in compressionModel, changeMask, startOffset, snapshot, baseline);
		}
	}
}
