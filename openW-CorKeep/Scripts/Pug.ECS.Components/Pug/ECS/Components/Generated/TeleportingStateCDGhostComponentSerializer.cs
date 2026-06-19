using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
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
	public struct TeleportingStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint teleportingTimer_startTick;

			public uint teleportingTimer_targetTicks;

			public uint teleportingTimer_stopTick;

			public float targetPosition_x;

			public float targetPosition_y;

			public float targetPosition_z;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<TeleportingStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<TeleportingStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<TeleportingStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<TeleportingStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in TeleportingStateCD component)
		{
			snapshot.teleportingTimer_startTick = component.teleportingTimer.startTick.SerializedData;
			snapshot.teleportingTimer_targetTicks = component.teleportingTimer.targetTicks;
			snapshot.teleportingTimer_stopTick = component.teleportingTimer.stopTick.SerializedData;
			snapshot.targetPosition_x = component.targetPosition.x;
			snapshot.targetPosition_y = component.targetPosition.y;
			snapshot.targetPosition_z = component.targetPosition.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref TeleportingStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.teleportingTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.teleportingTimer_startTick
			};
			component.teleportingTimer.targetTicks = snapshotBefore.teleportingTimer_targetTicks;
			component.teleportingTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.teleportingTimer_stopTick
			};
			component.targetPosition.x = snapshotBefore.targetPosition_x;
			component.targetPosition.y = snapshotBefore.targetPosition_y;
			component.targetPosition.z = snapshotBefore.targetPosition_z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref TeleportingStateCD component, in TeleportingStateCD backup)
		{
			component.teleportingTimer.startTick = backup.teleportingTimer.startTick;
			component.teleportingTimer.targetTicks = backup.teleportingTimer.targetTicks;
			component.teleportingTimer.stopTick = backup.teleportingTimer.stopTick;
			component.targetPosition.x = backup.targetPosition.x;
			component.targetPosition.y = backup.targetPosition.y;
			component.targetPosition.z = backup.targetPosition.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.teleportingTimer_startTick = (uint)predictor.PredictInt((int)snapshot.teleportingTimer_startTick, (int)baseline1.teleportingTimer_startTick, (int)baseline2.teleportingTimer_startTick);
			snapshot.teleportingTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.teleportingTimer_targetTicks, (int)baseline1.teleportingTimer_targetTicks, (int)baseline2.teleportingTimer_targetTicks);
			snapshot.teleportingTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.teleportingTimer_stopTick, (int)baseline1.teleportingTimer_stopTick, (int)baseline2.teleportingTimer_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.teleportingTimer_startTick != baseline.teleportingTimer_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.teleportingTimer_targetTicks != baseline.teleportingTimer_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.teleportingTimer_stopTick != baseline.teleportingTimer_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.targetPosition_x != baseline.targetPosition_x) ? 8 : 0);
			num |= (uint)((snapshot.targetPosition_y != baseline.targetPosition_y) ? 16 : 0);
			num |= (uint)((snapshot.targetPosition_z != baseline.targetPosition_z) ? 32 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.teleportingTimer_startTick, baseline.teleportingTimer_startTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.teleportingTimer_targetTicks, baseline.teleportingTimer_targetTicks, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.teleportingTimer_stopTick, baseline.teleportingTimer_stopTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_x, baseline.targetPosition_x, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_y, baseline.targetPosition_y, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_z, baseline.targetPosition_z, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.teleportingTimer_startTick != baseline.teleportingTimer_startTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.teleportingTimer_startTick, baseline.teleportingTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.teleportingTimer_targetTicks != baseline.teleportingTimer_targetTicks) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.teleportingTimer_targetTicks, baseline.teleportingTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.teleportingTimer_stopTick != baseline.teleportingTimer_stopTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.teleportingTimer_stopTick, baseline.teleportingTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.targetPosition_x != baseline.targetPosition_x) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_x, baseline.targetPosition_x, in compressionModel);
			}
			num |= (uint)((snapshot.targetPosition_y != baseline.targetPosition_y) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_y, baseline.targetPosition_y, in compressionModel);
			}
			num |= (uint)((snapshot.targetPosition_z != baseline.targetPosition_z) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetPosition_z, baseline.targetPosition_z, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				snapshot.teleportingTimer_startTick = reader.ReadPackedUIntDelta(baseline.teleportingTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.teleportingTimer_startTick = baseline.teleportingTimer_startTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.teleportingTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.teleportingTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.teleportingTimer_targetTicks = baseline.teleportingTimer_targetTicks;
			}
			if ((num & 4) != 0)
			{
				snapshot.teleportingTimer_stopTick = reader.ReadPackedUIntDelta(baseline.teleportingTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.teleportingTimer_stopTick = baseline.teleportingTimer_stopTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.targetPosition_x = reader.ReadPackedFloatDelta(baseline.targetPosition_x, in compressionModel);
			}
			else
			{
				snapshot.targetPosition_x = baseline.targetPosition_x;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.targetPosition_y = reader.ReadPackedFloatDelta(baseline.targetPosition_y, in compressionModel);
			}
			else
			{
				snapshot.targetPosition_y = baseline.targetPosition_y;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.targetPosition_z = reader.ReadPackedFloatDelta(baseline.targetPosition_z, in compressionModel);
			}
			else
			{
				snapshot.targetPosition_z = baseline.targetPosition_z;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 5032326342240550756uL,
					ComponentType = ComponentType.ReadWrite<TeleportingStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<TeleportingStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 6,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 893795862110843610uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<TeleportingStateCD, Snapshot, TeleportingStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
