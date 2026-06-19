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
	public struct DeathStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint allowHardcoreRespawn;

			public uint isDyingOrDead;

			public uint spawnedPlayer;

			public uint respawnTimer_startTick;

			public uint respawnTimer_targetTicks;

			public uint respawnTimer_stopTick;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<DeathStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<DeathStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<DeathStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<DeathStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in DeathStateCD component)
		{
			snapshot.allowHardcoreRespawn = (component.allowHardcoreRespawn ? 1u : 0u);
			snapshot.isDyingOrDead = (component.isDyingOrDead ? 1u : 0u);
			snapshot.spawnedPlayer = (component.spawnedPlayer ? 1u : 0u);
			snapshot.respawnTimer_startTick = component.respawnTimer.startTick.SerializedData;
			snapshot.respawnTimer_targetTicks = component.respawnTimer.targetTicks;
			snapshot.respawnTimer_stopTick = component.respawnTimer.stopTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref DeathStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.allowHardcoreRespawn = snapshotBefore.allowHardcoreRespawn != 0;
			component.isDyingOrDead = snapshotBefore.isDyingOrDead != 0;
			component.spawnedPlayer = snapshotBefore.spawnedPlayer != 0;
			component.respawnTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.respawnTimer_startTick
			};
			component.respawnTimer.targetTicks = snapshotBefore.respawnTimer_targetTicks;
			component.respawnTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.respawnTimer_stopTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref DeathStateCD component, in DeathStateCD backup)
		{
			component.allowHardcoreRespawn = backup.allowHardcoreRespawn;
			component.isDyingOrDead = backup.isDyingOrDead;
			component.spawnedPlayer = backup.spawnedPlayer;
			component.respawnTimer.startTick = backup.respawnTimer.startTick;
			component.respawnTimer.targetTicks = backup.respawnTimer.targetTicks;
			component.respawnTimer.stopTick = backup.respawnTimer.stopTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.allowHardcoreRespawn = (uint)predictor.PredictInt((int)snapshot.allowHardcoreRespawn, (int)baseline1.allowHardcoreRespawn, (int)baseline2.allowHardcoreRespawn);
			snapshot.isDyingOrDead = (uint)predictor.PredictInt((int)snapshot.isDyingOrDead, (int)baseline1.isDyingOrDead, (int)baseline2.isDyingOrDead);
			snapshot.spawnedPlayer = (uint)predictor.PredictInt((int)snapshot.spawnedPlayer, (int)baseline1.spawnedPlayer, (int)baseline2.spawnedPlayer);
			snapshot.respawnTimer_startTick = (uint)predictor.PredictInt((int)snapshot.respawnTimer_startTick, (int)baseline1.respawnTimer_startTick, (int)baseline2.respawnTimer_startTick);
			snapshot.respawnTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.respawnTimer_targetTicks, (int)baseline1.respawnTimer_targetTicks, (int)baseline2.respawnTimer_targetTicks);
			snapshot.respawnTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.respawnTimer_stopTick, (int)baseline1.respawnTimer_stopTick, (int)baseline2.respawnTimer_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.allowHardcoreRespawn != baseline.allowHardcoreRespawn) ? 1u : 0u);
			num |= (uint)((snapshot.isDyingOrDead != baseline.isDyingOrDead) ? 2 : 0);
			num |= (uint)((snapshot.spawnedPlayer != baseline.spawnedPlayer) ? 4 : 0);
			num |= (uint)((snapshot.respawnTimer_startTick != baseline.respawnTimer_startTick) ? 8 : 0);
			num |= (uint)((snapshot.respawnTimer_targetTicks != baseline.respawnTimer_targetTicks) ? 16 : 0);
			num |= (uint)((snapshot.respawnTimer_stopTick != baseline.respawnTimer_stopTick) ? 32 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowHardcoreRespawn, baseline.allowHardcoreRespawn, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isDyingOrDead, baseline.isDyingOrDead, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.spawnedPlayer, baseline.spawnedPlayer, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.respawnTimer_startTick, baseline.respawnTimer_startTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.respawnTimer_targetTicks, baseline.respawnTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.respawnTimer_stopTick, baseline.respawnTimer_stopTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.allowHardcoreRespawn != baseline.allowHardcoreRespawn) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowHardcoreRespawn, baseline.allowHardcoreRespawn, in compressionModel);
			}
			num |= (uint)((snapshot.isDyingOrDead != baseline.isDyingOrDead) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isDyingOrDead, baseline.isDyingOrDead, in compressionModel);
			}
			num |= (uint)((snapshot.spawnedPlayer != baseline.spawnedPlayer) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.spawnedPlayer, baseline.spawnedPlayer, in compressionModel);
			}
			num |= (uint)((snapshot.respawnTimer_startTick != baseline.respawnTimer_startTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.respawnTimer_startTick, baseline.respawnTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.respawnTimer_targetTicks != baseline.respawnTimer_targetTicks) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.respawnTimer_targetTicks, baseline.respawnTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.respawnTimer_stopTick != baseline.respawnTimer_stopTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.respawnTimer_stopTick, baseline.respawnTimer_stopTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				snapshot.allowHardcoreRespawn = reader.ReadPackedUIntDelta(baseline.allowHardcoreRespawn, in compressionModel);
			}
			else
			{
				snapshot.allowHardcoreRespawn = baseline.allowHardcoreRespawn;
			}
			if ((num & 2) != 0)
			{
				snapshot.isDyingOrDead = reader.ReadPackedUIntDelta(baseline.isDyingOrDead, in compressionModel);
			}
			else
			{
				snapshot.isDyingOrDead = baseline.isDyingOrDead;
			}
			if ((num & 4) != 0)
			{
				snapshot.spawnedPlayer = reader.ReadPackedUIntDelta(baseline.spawnedPlayer, in compressionModel);
			}
			else
			{
				snapshot.spawnedPlayer = baseline.spawnedPlayer;
			}
			if ((num & 8) != 0)
			{
				snapshot.respawnTimer_startTick = reader.ReadPackedUIntDelta(baseline.respawnTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.respawnTimer_startTick = baseline.respawnTimer_startTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.respawnTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.respawnTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.respawnTimer_targetTicks = baseline.respawnTimer_targetTicks;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.respawnTimer_stopTick = reader.ReadPackedUIntDelta(baseline.respawnTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.respawnTimer_stopTick = baseline.respawnTimer_stopTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 5032326342240550756uL,
					ComponentType = ComponentType.ReadWrite<DeathStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<DeathStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 6,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 13901288934998488252uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<DeathStateCD, Snapshot, DeathStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
