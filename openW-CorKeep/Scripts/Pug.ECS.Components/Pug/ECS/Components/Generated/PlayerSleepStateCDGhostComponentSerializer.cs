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
	public struct PlayerSleepStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint wasPreviouslyForcedSleep;

			public uint minSleepTimer_startTick;

			public uint minSleepTimer_targetTicks;

			public uint minSleepTimer_stopTick;

			public uint qualitySleepTimer_startTick;

			public uint qualitySleepTimer_targetTicks;

			public uint qualitySleepTimer_stopTick;

			public uint wasPreviouslyAsleepFromBeingStill;
		}

		private const int ChangeMaskBits = 8;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 8;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<PlayerSleepStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<PlayerSleepStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<PlayerSleepStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<PlayerSleepStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in PlayerSleepStateCD component)
		{
			snapshot.wasPreviouslyForcedSleep = (component.wasPreviouslyForcedSleep ? 1u : 0u);
			snapshot.minSleepTimer_startTick = component.minSleepTimer.startTick.SerializedData;
			snapshot.minSleepTimer_targetTicks = component.minSleepTimer.targetTicks;
			snapshot.minSleepTimer_stopTick = component.minSleepTimer.stopTick.SerializedData;
			snapshot.qualitySleepTimer_startTick = component.qualitySleepTimer.startTick.SerializedData;
			snapshot.qualitySleepTimer_targetTicks = component.qualitySleepTimer.targetTicks;
			snapshot.qualitySleepTimer_stopTick = component.qualitySleepTimer.stopTick.SerializedData;
			snapshot.wasPreviouslyAsleepFromBeingStill = (component.wasPreviouslyAsleepFromBeingStill ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref PlayerSleepStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.wasPreviouslyForcedSleep = snapshotBefore.wasPreviouslyForcedSleep != 0;
			component.minSleepTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.minSleepTimer_startTick
			};
			component.minSleepTimer.targetTicks = snapshotBefore.minSleepTimer_targetTicks;
			component.minSleepTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.minSleepTimer_stopTick
			};
			component.qualitySleepTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.qualitySleepTimer_startTick
			};
			component.qualitySleepTimer.targetTicks = snapshotBefore.qualitySleepTimer_targetTicks;
			component.qualitySleepTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.qualitySleepTimer_stopTick
			};
			component.wasPreviouslyAsleepFromBeingStill = snapshotBefore.wasPreviouslyAsleepFromBeingStill != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref PlayerSleepStateCD component, in PlayerSleepStateCD backup)
		{
			component.wasPreviouslyForcedSleep = backup.wasPreviouslyForcedSleep;
			component.minSleepTimer.startTick = backup.minSleepTimer.startTick;
			component.minSleepTimer.targetTicks = backup.minSleepTimer.targetTicks;
			component.minSleepTimer.stopTick = backup.minSleepTimer.stopTick;
			component.qualitySleepTimer.startTick = backup.qualitySleepTimer.startTick;
			component.qualitySleepTimer.targetTicks = backup.qualitySleepTimer.targetTicks;
			component.qualitySleepTimer.stopTick = backup.qualitySleepTimer.stopTick;
			component.wasPreviouslyAsleepFromBeingStill = backup.wasPreviouslyAsleepFromBeingStill;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.wasPreviouslyForcedSleep = (uint)predictor.PredictInt((int)snapshot.wasPreviouslyForcedSleep, (int)baseline1.wasPreviouslyForcedSleep, (int)baseline2.wasPreviouslyForcedSleep);
			snapshot.minSleepTimer_startTick = (uint)predictor.PredictInt((int)snapshot.minSleepTimer_startTick, (int)baseline1.minSleepTimer_startTick, (int)baseline2.minSleepTimer_startTick);
			snapshot.minSleepTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.minSleepTimer_targetTicks, (int)baseline1.minSleepTimer_targetTicks, (int)baseline2.minSleepTimer_targetTicks);
			snapshot.minSleepTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.minSleepTimer_stopTick, (int)baseline1.minSleepTimer_stopTick, (int)baseline2.minSleepTimer_stopTick);
			snapshot.qualitySleepTimer_startTick = (uint)predictor.PredictInt((int)snapshot.qualitySleepTimer_startTick, (int)baseline1.qualitySleepTimer_startTick, (int)baseline2.qualitySleepTimer_startTick);
			snapshot.qualitySleepTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.qualitySleepTimer_targetTicks, (int)baseline1.qualitySleepTimer_targetTicks, (int)baseline2.qualitySleepTimer_targetTicks);
			snapshot.qualitySleepTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.qualitySleepTimer_stopTick, (int)baseline1.qualitySleepTimer_stopTick, (int)baseline2.qualitySleepTimer_stopTick);
			snapshot.wasPreviouslyAsleepFromBeingStill = (uint)predictor.PredictInt((int)snapshot.wasPreviouslyAsleepFromBeingStill, (int)baseline1.wasPreviouslyAsleepFromBeingStill, (int)baseline2.wasPreviouslyAsleepFromBeingStill);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.wasPreviouslyForcedSleep != baseline.wasPreviouslyForcedSleep) ? 1u : 0u);
			num |= (uint)((snapshot.minSleepTimer_startTick != baseline.minSleepTimer_startTick) ? 2 : 0);
			num |= (uint)((snapshot.minSleepTimer_targetTicks != baseline.minSleepTimer_targetTicks) ? 4 : 0);
			num |= (uint)((snapshot.minSleepTimer_stopTick != baseline.minSleepTimer_stopTick) ? 8 : 0);
			num |= (uint)((snapshot.qualitySleepTimer_startTick != baseline.qualitySleepTimer_startTick) ? 16 : 0);
			num |= (uint)((snapshot.qualitySleepTimer_targetTicks != baseline.qualitySleepTimer_targetTicks) ? 32 : 0);
			num |= (uint)((snapshot.qualitySleepTimer_stopTick != baseline.qualitySleepTimer_stopTick) ? 64 : 0);
			num |= (uint)((snapshot.wasPreviouslyAsleepFromBeingStill != baseline.wasPreviouslyAsleepFromBeingStill) ? 128 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 8);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.wasPreviouslyForcedSleep, baseline.wasPreviouslyForcedSleep, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minSleepTimer_startTick, baseline.minSleepTimer_startTick, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minSleepTimer_targetTicks, baseline.minSleepTimer_targetTicks, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minSleepTimer_stopTick, baseline.minSleepTimer_stopTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.qualitySleepTimer_startTick, baseline.qualitySleepTimer_startTick, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.qualitySleepTimer_targetTicks, baseline.qualitySleepTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.qualitySleepTimer_stopTick, baseline.qualitySleepTimer_stopTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.wasPreviouslyAsleepFromBeingStill, baseline.wasPreviouslyAsleepFromBeingStill, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.wasPreviouslyForcedSleep != baseline.wasPreviouslyForcedSleep) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.wasPreviouslyForcedSleep, baseline.wasPreviouslyForcedSleep, in compressionModel);
			}
			num |= (uint)((snapshot.minSleepTimer_startTick != baseline.minSleepTimer_startTick) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minSleepTimer_startTick, baseline.minSleepTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.minSleepTimer_targetTicks != baseline.minSleepTimer_targetTicks) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minSleepTimer_targetTicks, baseline.minSleepTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.minSleepTimer_stopTick != baseline.minSleepTimer_stopTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minSleepTimer_stopTick, baseline.minSleepTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.qualitySleepTimer_startTick != baseline.qualitySleepTimer_startTick) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.qualitySleepTimer_startTick, baseline.qualitySleepTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.qualitySleepTimer_targetTicks != baseline.qualitySleepTimer_targetTicks) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.qualitySleepTimer_targetTicks, baseline.qualitySleepTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.qualitySleepTimer_stopTick != baseline.qualitySleepTimer_stopTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.qualitySleepTimer_stopTick, baseline.qualitySleepTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.wasPreviouslyAsleepFromBeingStill != baseline.wasPreviouslyAsleepFromBeingStill) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.wasPreviouslyAsleepFromBeingStill, baseline.wasPreviouslyAsleepFromBeingStill, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 8);
			if ((num & 1) != 0)
			{
				snapshot.wasPreviouslyForcedSleep = reader.ReadPackedUIntDelta(baseline.wasPreviouslyForcedSleep, in compressionModel);
			}
			else
			{
				snapshot.wasPreviouslyForcedSleep = baseline.wasPreviouslyForcedSleep;
			}
			if ((num & 2) != 0)
			{
				snapshot.minSleepTimer_startTick = reader.ReadPackedUIntDelta(baseline.minSleepTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.minSleepTimer_startTick = baseline.minSleepTimer_startTick;
			}
			if ((num & 4) != 0)
			{
				snapshot.minSleepTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.minSleepTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.minSleepTimer_targetTicks = baseline.minSleepTimer_targetTicks;
			}
			if ((num & 8) != 0)
			{
				snapshot.minSleepTimer_stopTick = reader.ReadPackedUIntDelta(baseline.minSleepTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.minSleepTimer_stopTick = baseline.minSleepTimer_stopTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.qualitySleepTimer_startTick = reader.ReadPackedUIntDelta(baseline.qualitySleepTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.qualitySleepTimer_startTick = baseline.qualitySleepTimer_startTick;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.qualitySleepTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.qualitySleepTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.qualitySleepTimer_targetTicks = baseline.qualitySleepTimer_targetTicks;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.qualitySleepTimer_stopTick = reader.ReadPackedUIntDelta(baseline.qualitySleepTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.qualitySleepTimer_stopTick = baseline.qualitySleepTimer_stopTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.wasPreviouslyAsleepFromBeingStill = reader.ReadPackedUIntDelta(baseline.wasPreviouslyAsleepFromBeingStill, in compressionModel);
			}
			else
			{
				snapshot.wasPreviouslyAsleepFromBeingStill = baseline.wasPreviouslyAsleepFromBeingStill;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 16877093822059739888uL,
					ComponentType = ComponentType.ReadWrite<PlayerSleepStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<PlayerSleepStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 8,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 3716343627598950236uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<PlayerSleepStateCD, Snapshot, PlayerSleepStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
