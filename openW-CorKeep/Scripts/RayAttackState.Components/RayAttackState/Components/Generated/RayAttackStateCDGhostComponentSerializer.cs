using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.NetCode;
using Unity.NetCode.LowLevel.Unsafe;

namespace RayAttackState.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	public struct RayAttackStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public float startRadianAngle;

			public int state;

			public uint stateTimer_startTick;

			public uint stateTimer_targetTicks;

			public uint stateTimer_stopTick;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<RayAttackStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<RayAttackStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<RayAttackStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<RayAttackStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in RayAttackStateCD component)
		{
			snapshot.startRadianAngle = component.startRadianAngle;
			snapshot.state = (int)component.state;
			snapshot.stateTimer_startTick = component.stateTimer.startTick.SerializedData;
			snapshot.stateTimer_targetTicks = component.stateTimer.targetTicks;
			snapshot.stateTimer_stopTick = component.stateTimer.stopTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref RayAttackStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.startRadianAngle = snapshotBefore.startRadianAngle;
			component.state = (RayAttackStateCD.State)snapshotBefore.state;
			component.stateTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.stateTimer_startTick
			};
			component.stateTimer.targetTicks = snapshotBefore.stateTimer_targetTicks;
			component.stateTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.stateTimer_stopTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref RayAttackStateCD component, in RayAttackStateCD backup)
		{
			component.startRadianAngle = backup.startRadianAngle;
			component.state = backup.state;
			component.stateTimer.startTick = backup.stateTimer.startTick;
			component.stateTimer.targetTicks = backup.stateTimer.targetTicks;
			component.stateTimer.stopTick = backup.stateTimer.stopTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.state = predictor.PredictInt(snapshot.state, baseline1.state, baseline2.state);
			snapshot.stateTimer_startTick = (uint)predictor.PredictInt((int)snapshot.stateTimer_startTick, (int)baseline1.stateTimer_startTick, (int)baseline2.stateTimer_startTick);
			snapshot.stateTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.stateTimer_targetTicks, (int)baseline1.stateTimer_targetTicks, (int)baseline2.stateTimer_targetTicks);
			snapshot.stateTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.stateTimer_stopTick, (int)baseline1.stateTimer_stopTick, (int)baseline2.stateTimer_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.startRadianAngle != baseline.startRadianAngle) ? 1u : 0u);
			num |= (uint)((snapshot.state != baseline.state) ? 2 : 0);
			num |= (uint)((snapshot.stateTimer_startTick != baseline.stateTimer_startTick) ? 4 : 0);
			num |= (uint)((snapshot.stateTimer_targetTicks != baseline.stateTimer_targetTicks) ? 8 : 0);
			num |= (uint)((snapshot.stateTimer_stopTick != baseline.stateTimer_stopTick) ? 16 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.startRadianAngle, baseline.startRadianAngle, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.state, baseline.state, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.stateTimer_startTick, baseline.stateTimer_startTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.stateTimer_targetTicks, baseline.stateTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.stateTimer_stopTick, baseline.stateTimer_stopTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.startRadianAngle != baseline.startRadianAngle) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.startRadianAngle, baseline.startRadianAngle, in compressionModel);
			}
			num |= (uint)((snapshot.state != baseline.state) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.state, baseline.state, in compressionModel);
			}
			num |= (uint)((snapshot.stateTimer_startTick != baseline.stateTimer_startTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.stateTimer_startTick, baseline.stateTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.stateTimer_targetTicks != baseline.stateTimer_targetTicks) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.stateTimer_targetTicks, baseline.stateTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.stateTimer_stopTick != baseline.stateTimer_stopTick) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.stateTimer_stopTick, baseline.stateTimer_stopTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				snapshot.startRadianAngle = reader.ReadPackedFloatDelta(baseline.startRadianAngle, in compressionModel);
			}
			else
			{
				snapshot.startRadianAngle = baseline.startRadianAngle;
			}
			if ((num & 2) != 0)
			{
				snapshot.state = reader.ReadPackedIntDelta(baseline.state, in compressionModel);
			}
			else
			{
				snapshot.state = baseline.state;
			}
			if ((num & 4) != 0)
			{
				snapshot.stateTimer_startTick = reader.ReadPackedUIntDelta(baseline.stateTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.stateTimer_startTick = baseline.stateTimer_startTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.stateTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.stateTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.stateTimer_targetTicks = baseline.stateTimer_targetTicks;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.stateTimer_stopTick = reader.ReadPackedUIntDelta(baseline.stateTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.stateTimer_stopTick = baseline.stateTimer_stopTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 12532388930504974478uL,
					ComponentType = ComponentType.ReadWrite<RayAttackStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<RayAttackStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 5,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 4415356496440405886uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<RayAttackStateCD, Snapshot, RayAttackStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
