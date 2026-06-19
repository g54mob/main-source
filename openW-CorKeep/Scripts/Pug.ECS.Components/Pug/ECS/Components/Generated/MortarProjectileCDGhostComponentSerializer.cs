using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.NetCode.LowLevel.Unsafe;

namespace Pug.ECS.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	public struct MortarProjectileCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint internalState;

			public float targetPosition_x;

			public float targetPosition_y;

			public float targetPosition_z;

			public uint timer_startTick;

			public uint timer_targetTicks;

			public uint timer_stopTick;

			public float totalAirTime;

			public float airTime;
		}

		private const int ChangeMaskBits = 7;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 7;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<MortarProjectileCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<MortarProjectileCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<MortarProjectileCD>(component), in GhostComponentSerializer.TypeCastReadonly<MortarProjectileCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in MortarProjectileCD component)
		{
			snapshot.internalState = (uint)component.internalState;
			snapshot.targetPosition_x = component.targetPosition.x;
			snapshot.targetPosition_y = component.targetPosition.y;
			snapshot.targetPosition_z = component.targetPosition.z;
			snapshot.timer_startTick = component.timer.startTick.SerializedData;
			snapshot.timer_targetTicks = component.timer.targetTicks;
			snapshot.timer_stopTick = component.timer.stopTick.SerializedData;
			snapshot.totalAirTime = component.totalAirTime;
			snapshot.airTime = component.airTime;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref MortarProjectileCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.internalState = (MortarProjectileState)snapshotBefore.internalState;
			component.targetPosition = new float3(snapshotBefore.targetPosition_x, snapshotBefore.targetPosition_y, snapshotBefore.targetPosition_z);
			component.timer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.timer_startTick
			};
			component.timer.targetTicks = snapshotBefore.timer_targetTicks;
			component.timer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.timer_stopTick
			};
			component.totalAirTime = snapshotBefore.totalAirTime;
			component.airTime = snapshotBefore.airTime;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref MortarProjectileCD component, in MortarProjectileCD backup)
		{
			component.internalState = backup.internalState;
			component.targetPosition.x = backup.targetPosition.x;
			component.targetPosition.y = backup.targetPosition.y;
			component.targetPosition.z = backup.targetPosition.z;
			component.timer.startTick = backup.timer.startTick;
			component.timer.targetTicks = backup.timer.targetTicks;
			component.timer.stopTick = backup.timer.stopTick;
			component.totalAirTime = backup.totalAirTime;
			component.airTime = backup.airTime;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.internalState = (uint)predictor.PredictInt((int)snapshot.internalState, (int)baseline1.internalState, (int)baseline2.internalState);
			snapshot.timer_startTick = (uint)predictor.PredictInt((int)snapshot.timer_startTick, (int)baseline1.timer_startTick, (int)baseline2.timer_startTick);
			snapshot.timer_targetTicks = (uint)predictor.PredictInt((int)snapshot.timer_targetTicks, (int)baseline1.timer_targetTicks, (int)baseline2.timer_targetTicks);
			snapshot.timer_stopTick = (uint)predictor.PredictInt((int)snapshot.timer_stopTick, (int)baseline1.timer_stopTick, (int)baseline2.timer_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.internalState != baseline.internalState) ? 1u : 0u);
			num |= (uint)((snapshot.targetPosition_x != baseline.targetPosition_x) ? 2 : 0);
			num |= (uint)((snapshot.targetPosition_y != baseline.targetPosition_y) ? 2 : 0);
			num |= (uint)((snapshot.targetPosition_z != baseline.targetPosition_z) ? 2 : 0);
			num |= (uint)((snapshot.timer_startTick != baseline.timer_startTick) ? 4 : 0);
			num |= (uint)((snapshot.timer_targetTicks != baseline.timer_targetTicks) ? 8 : 0);
			num |= (uint)((snapshot.timer_stopTick != baseline.timer_stopTick) ? 16 : 0);
			num |= (uint)((snapshot.totalAirTime != baseline.totalAirTime) ? 32 : 0);
			num |= (uint)((snapshot.airTime != baseline.airTime) ? 64 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.internalState, baseline.internalState, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_x, baseline.targetPosition_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_y, baseline.targetPosition_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_z, baseline.targetPosition_z, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_startTick, baseline.timer_startTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_targetTicks, baseline.timer_targetTicks, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_stopTick, baseline.timer_stopTick, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.totalAirTime, baseline.totalAirTime, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.airTime, baseline.airTime, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.internalState != baseline.internalState) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.internalState, baseline.internalState, in compressionModel);
			}
			num |= (uint)((snapshot.targetPosition_x != baseline.targetPosition_x) ? 2 : 0);
			num |= (uint)((snapshot.targetPosition_y != baseline.targetPosition_y) ? 2 : 0);
			num |= (uint)((snapshot.targetPosition_z != baseline.targetPosition_z) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_x, baseline.targetPosition_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_y, baseline.targetPosition_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_z, baseline.targetPosition_z, in compressionModel);
			}
			num |= (uint)((snapshot.timer_startTick != baseline.timer_startTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_startTick, baseline.timer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.timer_targetTicks != baseline.timer_targetTicks) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_targetTicks, baseline.timer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.timer_stopTick != baseline.timer_stopTick) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_stopTick, baseline.timer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.totalAirTime != baseline.totalAirTime) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.totalAirTime, baseline.totalAirTime, in compressionModel);
			}
			num |= (uint)((snapshot.airTime != baseline.airTime) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.airTime, baseline.airTime, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				snapshot.internalState = reader.ReadPackedUIntDelta(baseline.internalState, in compressionModel);
			}
			else
			{
				snapshot.internalState = baseline.internalState;
			}
			if ((num & 2) != 0)
			{
				snapshot.targetPosition_x = reader.ReadPackedFloatDelta(baseline.targetPosition_x, in compressionModel);
			}
			else
			{
				snapshot.targetPosition_x = baseline.targetPosition_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.targetPosition_y = reader.ReadPackedFloatDelta(baseline.targetPosition_y, in compressionModel);
			}
			else
			{
				snapshot.targetPosition_y = baseline.targetPosition_y;
			}
			if ((num & 2) != 0)
			{
				snapshot.targetPosition_z = reader.ReadPackedFloatDelta(baseline.targetPosition_z, in compressionModel);
			}
			else
			{
				snapshot.targetPosition_z = baseline.targetPosition_z;
			}
			if ((num & 4) != 0)
			{
				snapshot.timer_startTick = reader.ReadPackedUIntDelta(baseline.timer_startTick, in compressionModel);
			}
			else
			{
				snapshot.timer_startTick = baseline.timer_startTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.timer_targetTicks = reader.ReadPackedUIntDelta(baseline.timer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.timer_targetTicks = baseline.timer_targetTicks;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.timer_stopTick = reader.ReadPackedUIntDelta(baseline.timer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.timer_stopTick = baseline.timer_stopTick;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.totalAirTime = reader.ReadPackedFloatDelta(baseline.totalAirTime, in compressionModel);
			}
			else
			{
				snapshot.totalAirTime = baseline.totalAirTime;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.airTime = reader.ReadPackedFloatDelta(baseline.airTime, in compressionModel);
			}
			else
			{
				snapshot.airTime = baseline.airTime;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 15168673681901513398uL,
					ComponentType = ComponentType.ReadWrite<MortarProjectileCD>(),
					ComponentSize = UnsafeUtility.SizeOf<MortarProjectileCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 7,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 13788187538782812190uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<MortarProjectileCD, Snapshot, MortarProjectileCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
