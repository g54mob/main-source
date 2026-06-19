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
	public struct ContainedObjectsBufferGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int objectData_objectID;

			public int objectData_amount;

			public int objectData_variation;

			public int objectData_variationUpdateCount;

			public int auxDataIndex;
		}

		private const int ChangeMaskBits = 5;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 5;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ContainedObjectsBuffer>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ContainedObjectsBuffer>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ContainedObjectsBuffer>(component), in GhostComponentSerializer.TypeCastReadonly<ContainedObjectsBuffer>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ContainedObjectsBuffer component)
		{
			snapshot.objectData_objectID = (int)component.objectData.objectID;
			snapshot.objectData_amount = component.objectData.amount;
			snapshot.objectData_variation = component.objectData.variation;
			snapshot.objectData_variationUpdateCount = component.objectData.variationUpdateCount;
			snapshot.auxDataIndex = component.auxDataIndex;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ContainedObjectsBuffer component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.objectData.objectID = (ObjectID)snapshotBefore.objectData_objectID;
			component.objectData.amount = snapshotBefore.objectData_amount;
			component.objectData.variation = snapshotBefore.objectData_variation;
			component.objectData.variationUpdateCount = snapshotBefore.objectData_variationUpdateCount;
			component.auxDataIndex = snapshotBefore.auxDataIndex;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ContainedObjectsBuffer component, in ContainedObjectsBuffer backup)
		{
			component.objectData.objectID = backup.objectData.objectID;
			component.objectData.amount = backup.objectData.amount;
			component.objectData.variation = backup.objectData.variation;
			component.objectData.variationUpdateCount = backup.objectData.variationUpdateCount;
			component.auxDataIndex = backup.auxDataIndex;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.objectData_objectID = predictor.PredictInt(snapshot.objectData_objectID, baseline1.objectData_objectID, baseline2.objectData_objectID);
			snapshot.objectData_amount = predictor.PredictInt(snapshot.objectData_amount, baseline1.objectData_amount, baseline2.objectData_amount);
			snapshot.objectData_variation = predictor.PredictInt(snapshot.objectData_variation, baseline1.objectData_variation, baseline2.objectData_variation);
			snapshot.objectData_variationUpdateCount = predictor.PredictInt(snapshot.objectData_variationUpdateCount, baseline1.objectData_variationUpdateCount, baseline2.objectData_variationUpdateCount);
			snapshot.auxDataIndex = predictor.PredictInt(snapshot.auxDataIndex, baseline1.auxDataIndex, baseline2.auxDataIndex);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.objectData_objectID != baseline.objectData_objectID) ? 1u : 0u);
			num |= (uint)((snapshot.objectData_amount != baseline.objectData_amount) ? 2 : 0);
			num |= (uint)((snapshot.objectData_variation != baseline.objectData_variation) ? 4 : 0);
			num |= (uint)((snapshot.objectData_variationUpdateCount != baseline.objectData_variationUpdateCount) ? 8 : 0);
			num |= (uint)((snapshot.auxDataIndex != baseline.auxDataIndex) ? 16 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_objectID, baseline.objectData_objectID, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_amount, baseline.objectData_amount, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_variation, baseline.objectData_variation, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_variationUpdateCount, baseline.objectData_variationUpdateCount, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.auxDataIndex, baseline.auxDataIndex, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.objectData_objectID != baseline.objectData_objectID) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_objectID, baseline.objectData_objectID, in compressionModel);
			}
			num |= (uint)((snapshot.objectData_amount != baseline.objectData_amount) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_amount, baseline.objectData_amount, in compressionModel);
			}
			num |= (uint)((snapshot.objectData_variation != baseline.objectData_variation) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_variation, baseline.objectData_variation, in compressionModel);
			}
			num |= (uint)((snapshot.objectData_variationUpdateCount != baseline.objectData_variationUpdateCount) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_variationUpdateCount, baseline.objectData_variationUpdateCount, in compressionModel);
			}
			num |= (uint)((snapshot.auxDataIndex != baseline.auxDataIndex) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.auxDataIndex, baseline.auxDataIndex, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				snapshot.objectData_objectID = reader.ReadPackedIntDelta(baseline.objectData_objectID, in compressionModel);
			}
			else
			{
				snapshot.objectData_objectID = baseline.objectData_objectID;
			}
			if ((num & 2) != 0)
			{
				snapshot.objectData_amount = reader.ReadPackedIntDelta(baseline.objectData_amount, in compressionModel);
			}
			else
			{
				snapshot.objectData_amount = baseline.objectData_amount;
			}
			if ((num & 4) != 0)
			{
				snapshot.objectData_variation = reader.ReadPackedIntDelta(baseline.objectData_variation, in compressionModel);
			}
			else
			{
				snapshot.objectData_variation = baseline.objectData_variation;
			}
			if ((num & 8) != 0)
			{
				snapshot.objectData_variationUpdateCount = reader.ReadPackedIntDelta(baseline.objectData_variationUpdateCount, in compressionModel);
			}
			else
			{
				snapshot.objectData_variationUpdateCount = baseline.objectData_variationUpdateCount;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.auxDataIndex = reader.ReadPackedIntDelta(baseline.auxDataIndex, in compressionModel);
			}
			else
			{
				snapshot.auxDataIndex = baseline.auxDataIndex;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 12532388930504974478uL,
					ComponentType = ComponentType.ReadWrite<ContainedObjectsBuffer>(),
					ComponentSize = UnsafeUtility.SizeOf<ContainedObjectsBuffer>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 5,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 10135632064218960402uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = BufferSerializationHelper<ContainedObjectsBuffer, Snapshot, ContainedObjectsBufferGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
