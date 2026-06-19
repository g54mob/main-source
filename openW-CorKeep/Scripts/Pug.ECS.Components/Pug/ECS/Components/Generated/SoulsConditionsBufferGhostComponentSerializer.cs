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
	public struct SoulsConditionsBufferGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int conditionData_conditionID;

			public float conditionData_duration;

			public int conditionData_value;

			public float conditionData_valueMultiplier;

			public int soulID;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<SoulsConditionsBuffer>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<SoulsConditionsBuffer>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<SoulsConditionsBuffer>(component), in GhostComponentSerializer.TypeCastReadonly<SoulsConditionsBuffer>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in SoulsConditionsBuffer component)
		{
			snapshot.conditionData_conditionID = (int)component.conditionData.conditionID;
			snapshot.conditionData_duration = component.conditionData.duration;
			snapshot.conditionData_value = component.conditionData.value;
			snapshot.conditionData_valueMultiplier = component.conditionData.valueMultiplier;
			snapshot.soulID = (int)component.soulID;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref SoulsConditionsBuffer component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.conditionData.conditionID = (ConditionID)snapshotBefore.conditionData_conditionID;
			component.conditionData.duration = snapshotBefore.conditionData_duration;
			component.conditionData.value = snapshotBefore.conditionData_value;
			component.conditionData.valueMultiplier = snapshotBefore.conditionData_valueMultiplier;
			component.soulID = (SoulID)snapshotBefore.soulID;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref SoulsConditionsBuffer component, in SoulsConditionsBuffer backup)
		{
			component.conditionData.conditionID = backup.conditionData.conditionID;
			component.conditionData.duration = backup.conditionData.duration;
			component.conditionData.value = backup.conditionData.value;
			component.conditionData.valueMultiplier = backup.conditionData.valueMultiplier;
			component.soulID = backup.soulID;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.conditionData_conditionID = predictor.PredictInt(snapshot.conditionData_conditionID, baseline1.conditionData_conditionID, baseline2.conditionData_conditionID);
			snapshot.conditionData_value = predictor.PredictInt(snapshot.conditionData_value, baseline1.conditionData_value, baseline2.conditionData_value);
			snapshot.soulID = predictor.PredictInt(snapshot.soulID, baseline1.soulID, baseline2.soulID);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.conditionData_conditionID != baseline.conditionData_conditionID) ? 1u : 0u);
			num |= (uint)((snapshot.conditionData_duration != baseline.conditionData_duration) ? 2 : 0);
			num |= (uint)((snapshot.conditionData_value != baseline.conditionData_value) ? 4 : 0);
			num |= (uint)((snapshot.conditionData_valueMultiplier != baseline.conditionData_valueMultiplier) ? 8 : 0);
			num |= (uint)((snapshot.soulID != baseline.soulID) ? 16 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.conditionData_conditionID, baseline.conditionData_conditionID, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.conditionData_duration, baseline.conditionData_duration, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.conditionData_value, baseline.conditionData_value, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.conditionData_valueMultiplier, baseline.conditionData_valueMultiplier, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.soulID, baseline.soulID, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.conditionData_conditionID != baseline.conditionData_conditionID) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.conditionData_conditionID, baseline.conditionData_conditionID, in compressionModel);
			}
			num |= (uint)((snapshot.conditionData_duration != baseline.conditionData_duration) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.conditionData_duration, baseline.conditionData_duration, in compressionModel);
			}
			num |= (uint)((snapshot.conditionData_value != baseline.conditionData_value) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.conditionData_value, baseline.conditionData_value, in compressionModel);
			}
			num |= (uint)((snapshot.conditionData_valueMultiplier != baseline.conditionData_valueMultiplier) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.conditionData_valueMultiplier, baseline.conditionData_valueMultiplier, in compressionModel);
			}
			num |= (uint)((snapshot.soulID != baseline.soulID) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.soulID, baseline.soulID, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				snapshot.conditionData_conditionID = reader.ReadPackedIntDelta(baseline.conditionData_conditionID, in compressionModel);
			}
			else
			{
				snapshot.conditionData_conditionID = baseline.conditionData_conditionID;
			}
			if ((num & 2) != 0)
			{
				snapshot.conditionData_duration = reader.ReadPackedFloatDelta(baseline.conditionData_duration, in compressionModel);
			}
			else
			{
				snapshot.conditionData_duration = baseline.conditionData_duration;
			}
			if ((num & 4) != 0)
			{
				snapshot.conditionData_value = reader.ReadPackedIntDelta(baseline.conditionData_value, in compressionModel);
			}
			else
			{
				snapshot.conditionData_value = baseline.conditionData_value;
			}
			if ((num & 8) != 0)
			{
				snapshot.conditionData_valueMultiplier = reader.ReadPackedFloatDelta(baseline.conditionData_valueMultiplier, in compressionModel);
			}
			else
			{
				snapshot.conditionData_valueMultiplier = baseline.conditionData_valueMultiplier;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.soulID = reader.ReadPackedIntDelta(baseline.soulID, in compressionModel);
			}
			else
			{
				snapshot.soulID = baseline.soulID;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 12532388930504974478uL,
					ComponentType = ComponentType.ReadWrite<SoulsConditionsBuffer>(),
					ComponentSize = UnsafeUtility.SizeOf<SoulsConditionsBuffer>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 5,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 10404194026915207004uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = BufferSerializationHelper<SoulsConditionsBuffer, Snapshot, SoulsConditionsBufferGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
