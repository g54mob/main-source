using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
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
	public struct MinecartRidingStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int nextPlannedTurningWorldTilePos_x;

			public int nextPlannedTurningWorldTilePos_y;

			public int vectorToNextPlannedTurningWorldTilePos_x;

			public int vectorToNextPlannedTurningWorldTilePos_y;

			public int lastTurnedTile_x;

			public int lastTurnedTile_y;

			public uint timeSinceBreakingTimer_startTick;

			public uint timeSinceBreakingTimer_targetTicks;

			public uint timeSinceBreakingTimer_stopTick;

			public float activeVelocity_x;

			public float activeVelocity_y;

			public uint hasAPlannedTurningPointSet;

			public uint canTurn;

			public uint isBreaking;
		}

		private const int ChangeMaskBits = 13;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 13;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<MinecartRidingStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<MinecartRidingStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<MinecartRidingStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<MinecartRidingStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in MinecartRidingStateCD component)
		{
			snapshot.nextPlannedTurningWorldTilePos_x = component.nextPlannedTurningWorldTilePos.x;
			snapshot.nextPlannedTurningWorldTilePos_y = component.nextPlannedTurningWorldTilePos.y;
			snapshot.vectorToNextPlannedTurningWorldTilePos_x = component.vectorToNextPlannedTurningWorldTilePos.x;
			snapshot.vectorToNextPlannedTurningWorldTilePos_y = component.vectorToNextPlannedTurningWorldTilePos.y;
			snapshot.lastTurnedTile_x = component.lastTurnedTile.x;
			snapshot.lastTurnedTile_y = component.lastTurnedTile.y;
			snapshot.timeSinceBreakingTimer_startTick = component.timeSinceBreakingTimer.startTick.SerializedData;
			snapshot.timeSinceBreakingTimer_targetTicks = component.timeSinceBreakingTimer.targetTicks;
			snapshot.timeSinceBreakingTimer_stopTick = component.timeSinceBreakingTimer.stopTick.SerializedData;
			snapshot.activeVelocity_x = component.activeVelocity.x;
			snapshot.activeVelocity_y = component.activeVelocity.y;
			snapshot.hasAPlannedTurningPointSet = (component.hasAPlannedTurningPointSet ? 1u : 0u);
			snapshot.canTurn = (component.canTurn ? 1u : 0u);
			snapshot.isBreaking = (component.isBreaking ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref MinecartRidingStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.nextPlannedTurningWorldTilePos.x = snapshotBefore.nextPlannedTurningWorldTilePos_x;
			component.nextPlannedTurningWorldTilePos.y = snapshotBefore.nextPlannedTurningWorldTilePos_y;
			component.vectorToNextPlannedTurningWorldTilePos.x = snapshotBefore.vectorToNextPlannedTurningWorldTilePos_x;
			component.vectorToNextPlannedTurningWorldTilePos.y = snapshotBefore.vectorToNextPlannedTurningWorldTilePos_y;
			component.lastTurnedTile.x = snapshotBefore.lastTurnedTile_x;
			component.lastTurnedTile.y = snapshotBefore.lastTurnedTile_y;
			component.timeSinceBreakingTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.timeSinceBreakingTimer_startTick
			};
			component.timeSinceBreakingTimer.targetTicks = snapshotBefore.timeSinceBreakingTimer_targetTicks;
			component.timeSinceBreakingTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.timeSinceBreakingTimer_stopTick
			};
			component.activeVelocity = new float2(snapshotBefore.activeVelocity_x, snapshotBefore.activeVelocity_y);
			component.hasAPlannedTurningPointSet = snapshotBefore.hasAPlannedTurningPointSet != 0;
			component.canTurn = snapshotBefore.canTurn != 0;
			component.isBreaking = snapshotBefore.isBreaking != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref MinecartRidingStateCD component, in MinecartRidingStateCD backup)
		{
			component.nextPlannedTurningWorldTilePos.x = backup.nextPlannedTurningWorldTilePos.x;
			component.nextPlannedTurningWorldTilePos.y = backup.nextPlannedTurningWorldTilePos.y;
			component.vectorToNextPlannedTurningWorldTilePos.x = backup.vectorToNextPlannedTurningWorldTilePos.x;
			component.vectorToNextPlannedTurningWorldTilePos.y = backup.vectorToNextPlannedTurningWorldTilePos.y;
			component.lastTurnedTile.x = backup.lastTurnedTile.x;
			component.lastTurnedTile.y = backup.lastTurnedTile.y;
			component.timeSinceBreakingTimer.startTick = backup.timeSinceBreakingTimer.startTick;
			component.timeSinceBreakingTimer.targetTicks = backup.timeSinceBreakingTimer.targetTicks;
			component.timeSinceBreakingTimer.stopTick = backup.timeSinceBreakingTimer.stopTick;
			component.activeVelocity.x = backup.activeVelocity.x;
			component.activeVelocity.y = backup.activeVelocity.y;
			component.hasAPlannedTurningPointSet = backup.hasAPlannedTurningPointSet;
			component.canTurn = backup.canTurn;
			component.isBreaking = backup.isBreaking;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.nextPlannedTurningWorldTilePos_x = predictor.PredictInt(snapshot.nextPlannedTurningWorldTilePos_x, baseline1.nextPlannedTurningWorldTilePos_x, baseline2.nextPlannedTurningWorldTilePos_x);
			snapshot.nextPlannedTurningWorldTilePos_y = predictor.PredictInt(snapshot.nextPlannedTurningWorldTilePos_y, baseline1.nextPlannedTurningWorldTilePos_y, baseline2.nextPlannedTurningWorldTilePos_y);
			snapshot.vectorToNextPlannedTurningWorldTilePos_x = predictor.PredictInt(snapshot.vectorToNextPlannedTurningWorldTilePos_x, baseline1.vectorToNextPlannedTurningWorldTilePos_x, baseline2.vectorToNextPlannedTurningWorldTilePos_x);
			snapshot.vectorToNextPlannedTurningWorldTilePos_y = predictor.PredictInt(snapshot.vectorToNextPlannedTurningWorldTilePos_y, baseline1.vectorToNextPlannedTurningWorldTilePos_y, baseline2.vectorToNextPlannedTurningWorldTilePos_y);
			snapshot.lastTurnedTile_x = predictor.PredictInt(snapshot.lastTurnedTile_x, baseline1.lastTurnedTile_x, baseline2.lastTurnedTile_x);
			snapshot.lastTurnedTile_y = predictor.PredictInt(snapshot.lastTurnedTile_y, baseline1.lastTurnedTile_y, baseline2.lastTurnedTile_y);
			snapshot.timeSinceBreakingTimer_startTick = (uint)predictor.PredictInt((int)snapshot.timeSinceBreakingTimer_startTick, (int)baseline1.timeSinceBreakingTimer_startTick, (int)baseline2.timeSinceBreakingTimer_startTick);
			snapshot.timeSinceBreakingTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.timeSinceBreakingTimer_targetTicks, (int)baseline1.timeSinceBreakingTimer_targetTicks, (int)baseline2.timeSinceBreakingTimer_targetTicks);
			snapshot.timeSinceBreakingTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.timeSinceBreakingTimer_stopTick, (int)baseline1.timeSinceBreakingTimer_stopTick, (int)baseline2.timeSinceBreakingTimer_stopTick);
			snapshot.hasAPlannedTurningPointSet = (uint)predictor.PredictInt((int)snapshot.hasAPlannedTurningPointSet, (int)baseline1.hasAPlannedTurningPointSet, (int)baseline2.hasAPlannedTurningPointSet);
			snapshot.canTurn = (uint)predictor.PredictInt((int)snapshot.canTurn, (int)baseline1.canTurn, (int)baseline2.canTurn);
			snapshot.isBreaking = (uint)predictor.PredictInt((int)snapshot.isBreaking, (int)baseline1.isBreaking, (int)baseline2.isBreaking);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.nextPlannedTurningWorldTilePos_x != baseline.nextPlannedTurningWorldTilePos_x) ? 1u : 0u);
			num |= (uint)((snapshot.nextPlannedTurningWorldTilePos_y != baseline.nextPlannedTurningWorldTilePos_y) ? 2 : 0);
			num |= (uint)((snapshot.vectorToNextPlannedTurningWorldTilePos_x != baseline.vectorToNextPlannedTurningWorldTilePos_x) ? 4 : 0);
			num |= (uint)((snapshot.vectorToNextPlannedTurningWorldTilePos_y != baseline.vectorToNextPlannedTurningWorldTilePos_y) ? 8 : 0);
			num |= (uint)((snapshot.lastTurnedTile_x != baseline.lastTurnedTile_x) ? 16 : 0);
			num |= (uint)((snapshot.lastTurnedTile_y != baseline.lastTurnedTile_y) ? 32 : 0);
			num |= (uint)((snapshot.timeSinceBreakingTimer_startTick != baseline.timeSinceBreakingTimer_startTick) ? 64 : 0);
			num |= (uint)((snapshot.timeSinceBreakingTimer_targetTicks != baseline.timeSinceBreakingTimer_targetTicks) ? 128 : 0);
			num |= (uint)((snapshot.timeSinceBreakingTimer_stopTick != baseline.timeSinceBreakingTimer_stopTick) ? 256 : 0);
			num |= (uint)((snapshot.activeVelocity_x != baseline.activeVelocity_x) ? 512 : 0);
			num |= (uint)((snapshot.activeVelocity_y != baseline.activeVelocity_y) ? 512 : 0);
			num |= (uint)((snapshot.hasAPlannedTurningPointSet != baseline.hasAPlannedTurningPointSet) ? 1024 : 0);
			num |= (uint)((snapshot.canTurn != baseline.canTurn) ? 2048 : 0);
			num |= (uint)((snapshot.isBreaking != baseline.isBreaking) ? 4096 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 13);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 13);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.nextPlannedTurningWorldTilePos_x, baseline.nextPlannedTurningWorldTilePos_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.nextPlannedTurningWorldTilePos_y, baseline.nextPlannedTurningWorldTilePos_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.vectorToNextPlannedTurningWorldTilePos_x, baseline.vectorToNextPlannedTurningWorldTilePos_x, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.vectorToNextPlannedTurningWorldTilePos_y, baseline.vectorToNextPlannedTurningWorldTilePos_y, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.lastTurnedTile_x, baseline.lastTurnedTile_x, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.lastTurnedTile_y, baseline.lastTurnedTile_y, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSinceBreakingTimer_startTick, baseline.timeSinceBreakingTimer_startTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSinceBreakingTimer_targetTicks, baseline.timeSinceBreakingTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSinceBreakingTimer_stopTick, baseline.timeSinceBreakingTimer_stopTick, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.activeVelocity_x, baseline.activeVelocity_x, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.activeVelocity_y, baseline.activeVelocity_y, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hasAPlannedTurningPointSet, baseline.hasAPlannedTurningPointSet, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.canTurn, baseline.canTurn, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isBreaking, baseline.isBreaking, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.nextPlannedTurningWorldTilePos_x != baseline.nextPlannedTurningWorldTilePos_x) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.nextPlannedTurningWorldTilePos_x, baseline.nextPlannedTurningWorldTilePos_x, in compressionModel);
			}
			num |= (uint)((snapshot.nextPlannedTurningWorldTilePos_y != baseline.nextPlannedTurningWorldTilePos_y) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.nextPlannedTurningWorldTilePos_y, baseline.nextPlannedTurningWorldTilePos_y, in compressionModel);
			}
			num |= (uint)((snapshot.vectorToNextPlannedTurningWorldTilePos_x != baseline.vectorToNextPlannedTurningWorldTilePos_x) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.vectorToNextPlannedTurningWorldTilePos_x, baseline.vectorToNextPlannedTurningWorldTilePos_x, in compressionModel);
			}
			num |= (uint)((snapshot.vectorToNextPlannedTurningWorldTilePos_y != baseline.vectorToNextPlannedTurningWorldTilePos_y) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.vectorToNextPlannedTurningWorldTilePos_y, baseline.vectorToNextPlannedTurningWorldTilePos_y, in compressionModel);
			}
			num |= (uint)((snapshot.lastTurnedTile_x != baseline.lastTurnedTile_x) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.lastTurnedTile_x, baseline.lastTurnedTile_x, in compressionModel);
			}
			num |= (uint)((snapshot.lastTurnedTile_y != baseline.lastTurnedTile_y) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.lastTurnedTile_y, baseline.lastTurnedTile_y, in compressionModel);
			}
			num |= (uint)((snapshot.timeSinceBreakingTimer_startTick != baseline.timeSinceBreakingTimer_startTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSinceBreakingTimer_startTick, baseline.timeSinceBreakingTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.timeSinceBreakingTimer_targetTicks != baseline.timeSinceBreakingTimer_targetTicks) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSinceBreakingTimer_targetTicks, baseline.timeSinceBreakingTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.timeSinceBreakingTimer_stopTick != baseline.timeSinceBreakingTimer_stopTick) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSinceBreakingTimer_stopTick, baseline.timeSinceBreakingTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.activeVelocity_x != baseline.activeVelocity_x) ? 512 : 0);
			num |= (uint)((snapshot.activeVelocity_y != baseline.activeVelocity_y) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.activeVelocity_x, baseline.activeVelocity_x, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.activeVelocity_y, baseline.activeVelocity_y, in compressionModel);
			}
			num |= (uint)((snapshot.hasAPlannedTurningPointSet != baseline.hasAPlannedTurningPointSet) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hasAPlannedTurningPointSet, baseline.hasAPlannedTurningPointSet, in compressionModel);
			}
			num |= (uint)((snapshot.canTurn != baseline.canTurn) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.canTurn, baseline.canTurn, in compressionModel);
			}
			num |= (uint)((snapshot.isBreaking != baseline.isBreaking) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isBreaking, baseline.isBreaking, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 13);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 13);
			if ((num & 1) != 0)
			{
				snapshot.nextPlannedTurningWorldTilePos_x = reader.ReadPackedIntDelta(baseline.nextPlannedTurningWorldTilePos_x, in compressionModel);
			}
			else
			{
				snapshot.nextPlannedTurningWorldTilePos_x = baseline.nextPlannedTurningWorldTilePos_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.nextPlannedTurningWorldTilePos_y = reader.ReadPackedIntDelta(baseline.nextPlannedTurningWorldTilePos_y, in compressionModel);
			}
			else
			{
				snapshot.nextPlannedTurningWorldTilePos_y = baseline.nextPlannedTurningWorldTilePos_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.vectorToNextPlannedTurningWorldTilePos_x = reader.ReadPackedIntDelta(baseline.vectorToNextPlannedTurningWorldTilePos_x, in compressionModel);
			}
			else
			{
				snapshot.vectorToNextPlannedTurningWorldTilePos_x = baseline.vectorToNextPlannedTurningWorldTilePos_x;
			}
			if ((num & 8) != 0)
			{
				snapshot.vectorToNextPlannedTurningWorldTilePos_y = reader.ReadPackedIntDelta(baseline.vectorToNextPlannedTurningWorldTilePos_y, in compressionModel);
			}
			else
			{
				snapshot.vectorToNextPlannedTurningWorldTilePos_y = baseline.vectorToNextPlannedTurningWorldTilePos_y;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.lastTurnedTile_x = reader.ReadPackedIntDelta(baseline.lastTurnedTile_x, in compressionModel);
			}
			else
			{
				snapshot.lastTurnedTile_x = baseline.lastTurnedTile_x;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.lastTurnedTile_y = reader.ReadPackedIntDelta(baseline.lastTurnedTile_y, in compressionModel);
			}
			else
			{
				snapshot.lastTurnedTile_y = baseline.lastTurnedTile_y;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.timeSinceBreakingTimer_startTick = reader.ReadPackedUIntDelta(baseline.timeSinceBreakingTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.timeSinceBreakingTimer_startTick = baseline.timeSinceBreakingTimer_startTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.timeSinceBreakingTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.timeSinceBreakingTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.timeSinceBreakingTimer_targetTicks = baseline.timeSinceBreakingTimer_targetTicks;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.timeSinceBreakingTimer_stopTick = reader.ReadPackedUIntDelta(baseline.timeSinceBreakingTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.timeSinceBreakingTimer_stopTick = baseline.timeSinceBreakingTimer_stopTick;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.activeVelocity_x = reader.ReadPackedFloatDelta(baseline.activeVelocity_x, in compressionModel);
			}
			else
			{
				snapshot.activeVelocity_x = baseline.activeVelocity_x;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.activeVelocity_y = reader.ReadPackedFloatDelta(baseline.activeVelocity_y, in compressionModel);
			}
			else
			{
				snapshot.activeVelocity_y = baseline.activeVelocity_y;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.hasAPlannedTurningPointSet = reader.ReadPackedUIntDelta(baseline.hasAPlannedTurningPointSet, in compressionModel);
			}
			else
			{
				snapshot.hasAPlannedTurningPointSet = baseline.hasAPlannedTurningPointSet;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.canTurn = reader.ReadPackedUIntDelta(baseline.canTurn, in compressionModel);
			}
			else
			{
				snapshot.canTurn = baseline.canTurn;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.isBreaking = reader.ReadPackedUIntDelta(baseline.isBreaking, in compressionModel);
			}
			else
			{
				snapshot.isBreaking = baseline.isBreaking;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 4947700536777615060uL,
					ComponentType = ComponentType.ReadWrite<MinecartRidingStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<MinecartRidingStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 13,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 18179382745356785244uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<MinecartRidingStateCD, Snapshot, MinecartRidingStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
