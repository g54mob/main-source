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
	public struct MinionOwnerCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int minionCount;

			public uint orbitTimer_startTick;

			public uint orbitTimer_targetTicks;

			public uint orbitTimer_stopTick;

			public float smoothCount;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<MinionOwnerCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<MinionOwnerCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<MinionOwnerCD>(component), in GhostComponentSerializer.TypeCastReadonly<MinionOwnerCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in MinionOwnerCD component)
		{
			snapshot.minionCount = component.minionCount;
			snapshot.orbitTimer_startTick = component.orbitTimer.startTick.SerializedData;
			snapshot.orbitTimer_targetTicks = component.orbitTimer.targetTicks;
			snapshot.orbitTimer_stopTick = component.orbitTimer.stopTick.SerializedData;
			snapshot.smoothCount = component.smoothCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref MinionOwnerCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.minionCount = snapshotBefore.minionCount;
			component.orbitTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.orbitTimer_startTick
			};
			component.orbitTimer.targetTicks = snapshotBefore.orbitTimer_targetTicks;
			component.orbitTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.orbitTimer_stopTick
			};
			component.smoothCount = snapshotBefore.smoothCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref MinionOwnerCD component, in MinionOwnerCD backup)
		{
			component.minionCount = backup.minionCount;
			component.orbitTimer.startTick = backup.orbitTimer.startTick;
			component.orbitTimer.targetTicks = backup.orbitTimer.targetTicks;
			component.orbitTimer.stopTick = backup.orbitTimer.stopTick;
			component.smoothCount = backup.smoothCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.minionCount = predictor.PredictInt(snapshot.minionCount, baseline1.minionCount, baseline2.minionCount);
			snapshot.orbitTimer_startTick = (uint)predictor.PredictInt((int)snapshot.orbitTimer_startTick, (int)baseline1.orbitTimer_startTick, (int)baseline2.orbitTimer_startTick);
			snapshot.orbitTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.orbitTimer_targetTicks, (int)baseline1.orbitTimer_targetTicks, (int)baseline2.orbitTimer_targetTicks);
			snapshot.orbitTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.orbitTimer_stopTick, (int)baseline1.orbitTimer_stopTick, (int)baseline2.orbitTimer_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.minionCount != baseline.minionCount) ? 1u : 0u);
			num |= (uint)((snapshot.orbitTimer_startTick != baseline.orbitTimer_startTick) ? 2 : 0);
			num |= (uint)((snapshot.orbitTimer_targetTicks != baseline.orbitTimer_targetTicks) ? 4 : 0);
			num |= (uint)((snapshot.orbitTimer_stopTick != baseline.orbitTimer_stopTick) ? 8 : 0);
			num |= (uint)((snapshot.smoothCount != baseline.smoothCount) ? 16 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.minionCount, baseline.minionCount, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.orbitTimer_startTick, baseline.orbitTimer_startTick, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.orbitTimer_targetTicks, baseline.orbitTimer_targetTicks, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.orbitTimer_stopTick, baseline.orbitTimer_stopTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.smoothCount, baseline.smoothCount, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.minionCount != baseline.minionCount) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.minionCount, baseline.minionCount, in compressionModel);
			}
			num |= (uint)((snapshot.orbitTimer_startTick != baseline.orbitTimer_startTick) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.orbitTimer_startTick, baseline.orbitTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.orbitTimer_targetTicks != baseline.orbitTimer_targetTicks) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.orbitTimer_targetTicks, baseline.orbitTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.orbitTimer_stopTick != baseline.orbitTimer_stopTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.orbitTimer_stopTick, baseline.orbitTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.smoothCount != baseline.smoothCount) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.smoothCount, baseline.smoothCount, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				snapshot.minionCount = reader.ReadPackedIntDelta(baseline.minionCount, in compressionModel);
			}
			else
			{
				snapshot.minionCount = baseline.minionCount;
			}
			if ((num & 2) != 0)
			{
				snapshot.orbitTimer_startTick = reader.ReadPackedUIntDelta(baseline.orbitTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.orbitTimer_startTick = baseline.orbitTimer_startTick;
			}
			if ((num & 4) != 0)
			{
				snapshot.orbitTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.orbitTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.orbitTimer_targetTicks = baseline.orbitTimer_targetTicks;
			}
			if ((num & 8) != 0)
			{
				snapshot.orbitTimer_stopTick = reader.ReadPackedUIntDelta(baseline.orbitTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.orbitTimer_stopTick = baseline.orbitTimer_stopTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.smoothCount = reader.ReadPackedFloatDelta(baseline.smoothCount, in compressionModel);
			}
			else
			{
				snapshot.smoothCount = baseline.smoothCount;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 12532388930504974478uL,
					ComponentType = ComponentType.ReadWrite<MinionOwnerCD>(),
					ComponentSize = UnsafeUtility.SizeOf<MinionOwnerCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 5,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 7296242531845145236uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<MinionOwnerCD, Snapshot, MinionOwnerCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
