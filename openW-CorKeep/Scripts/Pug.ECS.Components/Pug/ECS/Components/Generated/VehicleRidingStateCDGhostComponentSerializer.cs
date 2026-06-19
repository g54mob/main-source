using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
using Pug.UnityExtensions;
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
	public struct VehicleRidingStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public float previousVelocity_x;

			public float previousVelocity_y;

			public float previousVelocity_z;

			public uint reorientationDelay_startTick;

			public uint reorientationDelay_targetTicks;

			public uint reorientationDelay_stopTick;

			public uint previousDirection_id;

			public float prevPosition_x;

			public float prevPosition_y;

			public float prevPosition_z;

			public float drivingDirection_x;

			public float drivingDirection_y;

			public float drivingDirection_z;

			public float speed;

			public uint attackDestructiblesTimer_startTick;

			public uint attackDestructiblesTimer_targetTicks;

			public uint attackDestructiblesTimer_stopTick;
		}

		private const int ChangeMaskBits = 11;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 11;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<VehicleRidingStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<VehicleRidingStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<VehicleRidingStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<VehicleRidingStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in VehicleRidingStateCD component)
		{
			snapshot.previousVelocity_x = component.previousVelocity.x;
			snapshot.previousVelocity_y = component.previousVelocity.y;
			snapshot.previousVelocity_z = component.previousVelocity.z;
			snapshot.reorientationDelay_startTick = component.reorientationDelay.startTick.SerializedData;
			snapshot.reorientationDelay_targetTicks = component.reorientationDelay.targetTicks;
			snapshot.reorientationDelay_stopTick = component.reorientationDelay.stopTick.SerializedData;
			snapshot.previousDirection_id = (uint)component.previousDirection.id;
			snapshot.prevPosition_x = component.prevPosition.x;
			snapshot.prevPosition_y = component.prevPosition.y;
			snapshot.prevPosition_z = component.prevPosition.z;
			snapshot.drivingDirection_x = component.drivingDirection.x;
			snapshot.drivingDirection_y = component.drivingDirection.y;
			snapshot.drivingDirection_z = component.drivingDirection.z;
			snapshot.speed = component.speed;
			snapshot.attackDestructiblesTimer_startTick = component.attackDestructiblesTimer.startTick.SerializedData;
			snapshot.attackDestructiblesTimer_targetTicks = component.attackDestructiblesTimer.targetTicks;
			snapshot.attackDestructiblesTimer_stopTick = component.attackDestructiblesTimer.stopTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref VehicleRidingStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.previousVelocity = new float3(snapshotBefore.previousVelocity_x, snapshotBefore.previousVelocity_y, snapshotBefore.previousVelocity_z);
			component.reorientationDelay.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.reorientationDelay_startTick
			};
			component.reorientationDelay.targetTicks = snapshotBefore.reorientationDelay_targetTicks;
			component.reorientationDelay.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.reorientationDelay_stopTick
			};
			component.previousDirection.id = (Direction.Id)snapshotBefore.previousDirection_id;
			component.prevPosition = new float3(snapshotBefore.prevPosition_x, snapshotBefore.prevPosition_y, snapshotBefore.prevPosition_z);
			component.drivingDirection = new float3(snapshotBefore.drivingDirection_x, snapshotBefore.drivingDirection_y, snapshotBefore.drivingDirection_z);
			component.speed = snapshotBefore.speed;
			component.attackDestructiblesTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.attackDestructiblesTimer_startTick
			};
			component.attackDestructiblesTimer.targetTicks = snapshotBefore.attackDestructiblesTimer_targetTicks;
			component.attackDestructiblesTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.attackDestructiblesTimer_stopTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref VehicleRidingStateCD component, in VehicleRidingStateCD backup)
		{
			component.previousVelocity.x = backup.previousVelocity.x;
			component.previousVelocity.y = backup.previousVelocity.y;
			component.previousVelocity.z = backup.previousVelocity.z;
			component.reorientationDelay.startTick = backup.reorientationDelay.startTick;
			component.reorientationDelay.targetTicks = backup.reorientationDelay.targetTicks;
			component.reorientationDelay.stopTick = backup.reorientationDelay.stopTick;
			component.previousDirection.id = backup.previousDirection.id;
			component.prevPosition.x = backup.prevPosition.x;
			component.prevPosition.y = backup.prevPosition.y;
			component.prevPosition.z = backup.prevPosition.z;
			component.drivingDirection.x = backup.drivingDirection.x;
			component.drivingDirection.y = backup.drivingDirection.y;
			component.drivingDirection.z = backup.drivingDirection.z;
			component.speed = backup.speed;
			component.attackDestructiblesTimer.startTick = backup.attackDestructiblesTimer.startTick;
			component.attackDestructiblesTimer.targetTicks = backup.attackDestructiblesTimer.targetTicks;
			component.attackDestructiblesTimer.stopTick = backup.attackDestructiblesTimer.stopTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.reorientationDelay_startTick = (uint)predictor.PredictInt((int)snapshot.reorientationDelay_startTick, (int)baseline1.reorientationDelay_startTick, (int)baseline2.reorientationDelay_startTick);
			snapshot.reorientationDelay_targetTicks = (uint)predictor.PredictInt((int)snapshot.reorientationDelay_targetTicks, (int)baseline1.reorientationDelay_targetTicks, (int)baseline2.reorientationDelay_targetTicks);
			snapshot.reorientationDelay_stopTick = (uint)predictor.PredictInt((int)snapshot.reorientationDelay_stopTick, (int)baseline1.reorientationDelay_stopTick, (int)baseline2.reorientationDelay_stopTick);
			snapshot.previousDirection_id = (uint)predictor.PredictInt((int)snapshot.previousDirection_id, (int)baseline1.previousDirection_id, (int)baseline2.previousDirection_id);
			snapshot.attackDestructiblesTimer_startTick = (uint)predictor.PredictInt((int)snapshot.attackDestructiblesTimer_startTick, (int)baseline1.attackDestructiblesTimer_startTick, (int)baseline2.attackDestructiblesTimer_startTick);
			snapshot.attackDestructiblesTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.attackDestructiblesTimer_targetTicks, (int)baseline1.attackDestructiblesTimer_targetTicks, (int)baseline2.attackDestructiblesTimer_targetTicks);
			snapshot.attackDestructiblesTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.attackDestructiblesTimer_stopTick, (int)baseline1.attackDestructiblesTimer_stopTick, (int)baseline2.attackDestructiblesTimer_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.previousVelocity_x != baseline.previousVelocity_x) ? 1u : 0u);
			num |= (uint)((snapshot.previousVelocity_y != baseline.previousVelocity_y) ? 1 : 0);
			num |= (uint)((snapshot.previousVelocity_z != baseline.previousVelocity_z) ? 1 : 0);
			num |= (uint)((snapshot.reorientationDelay_startTick != baseline.reorientationDelay_startTick) ? 2 : 0);
			num |= (uint)((snapshot.reorientationDelay_targetTicks != baseline.reorientationDelay_targetTicks) ? 4 : 0);
			num |= (uint)((snapshot.reorientationDelay_stopTick != baseline.reorientationDelay_stopTick) ? 8 : 0);
			num |= (uint)((snapshot.previousDirection_id != baseline.previousDirection_id) ? 16 : 0);
			num |= (uint)((snapshot.prevPosition_x != baseline.prevPosition_x) ? 32 : 0);
			num |= (uint)((snapshot.prevPosition_y != baseline.prevPosition_y) ? 32 : 0);
			num |= (uint)((snapshot.prevPosition_z != baseline.prevPosition_z) ? 32 : 0);
			num |= (uint)((snapshot.drivingDirection_x != baseline.drivingDirection_x) ? 64 : 0);
			num |= (uint)((snapshot.drivingDirection_y != baseline.drivingDirection_y) ? 64 : 0);
			num |= (uint)((snapshot.drivingDirection_z != baseline.drivingDirection_z) ? 64 : 0);
			num |= (uint)((snapshot.speed != baseline.speed) ? 128 : 0);
			num |= (uint)((snapshot.attackDestructiblesTimer_startTick != baseline.attackDestructiblesTimer_startTick) ? 256 : 0);
			num |= (uint)((snapshot.attackDestructiblesTimer_targetTicks != baseline.attackDestructiblesTimer_targetTicks) ? 512 : 0);
			num |= (uint)((snapshot.attackDestructiblesTimer_stopTick != baseline.attackDestructiblesTimer_stopTick) ? 1024 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 11);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 11);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_x, baseline.previousVelocity_x, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_y, baseline.previousVelocity_y, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_z, baseline.previousVelocity_z, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_startTick, baseline.reorientationDelay_startTick, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_targetTicks, baseline.reorientationDelay_targetTicks, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_stopTick, baseline.reorientationDelay_stopTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.previousDirection_id, baseline.previousDirection_id, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPosition_x, baseline.prevPosition_x, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPosition_y, baseline.prevPosition_y, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPosition_z, baseline.prevPosition_z, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.drivingDirection_x, baseline.drivingDirection_x, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.drivingDirection_y, baseline.drivingDirection_y, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.drivingDirection_z, baseline.drivingDirection_z, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.speed, baseline.speed, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.attackDestructiblesTimer_startTick, baseline.attackDestructiblesTimer_startTick, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.attackDestructiblesTimer_targetTicks, baseline.attackDestructiblesTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.attackDestructiblesTimer_stopTick, baseline.attackDestructiblesTimer_stopTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.previousVelocity_x != baseline.previousVelocity_x) ? 1u : 0u);
			num |= (uint)((snapshot.previousVelocity_y != baseline.previousVelocity_y) ? 1 : 0);
			num |= (uint)((snapshot.previousVelocity_z != baseline.previousVelocity_z) ? 1 : 0);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_x, baseline.previousVelocity_x, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_y, baseline.previousVelocity_y, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_z, baseline.previousVelocity_z, in compressionModel);
			}
			num |= (uint)((snapshot.reorientationDelay_startTick != baseline.reorientationDelay_startTick) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_startTick, baseline.reorientationDelay_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.reorientationDelay_targetTicks != baseline.reorientationDelay_targetTicks) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_targetTicks, baseline.reorientationDelay_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.reorientationDelay_stopTick != baseline.reorientationDelay_stopTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_stopTick, baseline.reorientationDelay_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.previousDirection_id != baseline.previousDirection_id) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.previousDirection_id, baseline.previousDirection_id, in compressionModel);
			}
			num |= (uint)((snapshot.prevPosition_x != baseline.prevPosition_x) ? 32 : 0);
			num |= (uint)((snapshot.prevPosition_y != baseline.prevPosition_y) ? 32 : 0);
			num |= (uint)((snapshot.prevPosition_z != baseline.prevPosition_z) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPosition_x, baseline.prevPosition_x, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPosition_y, baseline.prevPosition_y, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPosition_z, baseline.prevPosition_z, in compressionModel);
			}
			num |= (uint)((snapshot.drivingDirection_x != baseline.drivingDirection_x) ? 64 : 0);
			num |= (uint)((snapshot.drivingDirection_y != baseline.drivingDirection_y) ? 64 : 0);
			num |= (uint)((snapshot.drivingDirection_z != baseline.drivingDirection_z) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.drivingDirection_x, baseline.drivingDirection_x, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.drivingDirection_y, baseline.drivingDirection_y, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.drivingDirection_z, baseline.drivingDirection_z, in compressionModel);
			}
			num |= (uint)((snapshot.speed != baseline.speed) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.speed, baseline.speed, in compressionModel);
			}
			num |= (uint)((snapshot.attackDestructiblesTimer_startTick != baseline.attackDestructiblesTimer_startTick) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.attackDestructiblesTimer_startTick, baseline.attackDestructiblesTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.attackDestructiblesTimer_targetTicks != baseline.attackDestructiblesTimer_targetTicks) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.attackDestructiblesTimer_targetTicks, baseline.attackDestructiblesTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.attackDestructiblesTimer_stopTick != baseline.attackDestructiblesTimer_stopTick) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.attackDestructiblesTimer_stopTick, baseline.attackDestructiblesTimer_stopTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 11);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 11);
			if ((num & 1) != 0)
			{
				snapshot.previousVelocity_x = reader.ReadPackedFloatDelta(baseline.previousVelocity_x, in compressionModel);
			}
			else
			{
				snapshot.previousVelocity_x = baseline.previousVelocity_x;
			}
			if ((num & 1) != 0)
			{
				snapshot.previousVelocity_y = reader.ReadPackedFloatDelta(baseline.previousVelocity_y, in compressionModel);
			}
			else
			{
				snapshot.previousVelocity_y = baseline.previousVelocity_y;
			}
			if ((num & 1) != 0)
			{
				snapshot.previousVelocity_z = reader.ReadPackedFloatDelta(baseline.previousVelocity_z, in compressionModel);
			}
			else
			{
				snapshot.previousVelocity_z = baseline.previousVelocity_z;
			}
			if ((num & 2) != 0)
			{
				snapshot.reorientationDelay_startTick = reader.ReadPackedUIntDelta(baseline.reorientationDelay_startTick, in compressionModel);
			}
			else
			{
				snapshot.reorientationDelay_startTick = baseline.reorientationDelay_startTick;
			}
			if ((num & 4) != 0)
			{
				snapshot.reorientationDelay_targetTicks = reader.ReadPackedUIntDelta(baseline.reorientationDelay_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.reorientationDelay_targetTicks = baseline.reorientationDelay_targetTicks;
			}
			if ((num & 8) != 0)
			{
				snapshot.reorientationDelay_stopTick = reader.ReadPackedUIntDelta(baseline.reorientationDelay_stopTick, in compressionModel);
			}
			else
			{
				snapshot.reorientationDelay_stopTick = baseline.reorientationDelay_stopTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.previousDirection_id = reader.ReadPackedUIntDelta(baseline.previousDirection_id, in compressionModel);
			}
			else
			{
				snapshot.previousDirection_id = baseline.previousDirection_id;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.prevPosition_x = reader.ReadPackedFloatDelta(baseline.prevPosition_x, in compressionModel);
			}
			else
			{
				snapshot.prevPosition_x = baseline.prevPosition_x;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.prevPosition_y = reader.ReadPackedFloatDelta(baseline.prevPosition_y, in compressionModel);
			}
			else
			{
				snapshot.prevPosition_y = baseline.prevPosition_y;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.prevPosition_z = reader.ReadPackedFloatDelta(baseline.prevPosition_z, in compressionModel);
			}
			else
			{
				snapshot.prevPosition_z = baseline.prevPosition_z;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.drivingDirection_x = reader.ReadPackedFloatDelta(baseline.drivingDirection_x, in compressionModel);
			}
			else
			{
				snapshot.drivingDirection_x = baseline.drivingDirection_x;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.drivingDirection_y = reader.ReadPackedFloatDelta(baseline.drivingDirection_y, in compressionModel);
			}
			else
			{
				snapshot.drivingDirection_y = baseline.drivingDirection_y;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.drivingDirection_z = reader.ReadPackedFloatDelta(baseline.drivingDirection_z, in compressionModel);
			}
			else
			{
				snapshot.drivingDirection_z = baseline.drivingDirection_z;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.speed = reader.ReadPackedFloatDelta(baseline.speed, in compressionModel);
			}
			else
			{
				snapshot.speed = baseline.speed;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.attackDestructiblesTimer_startTick = reader.ReadPackedUIntDelta(baseline.attackDestructiblesTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.attackDestructiblesTimer_startTick = baseline.attackDestructiblesTimer_startTick;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.attackDestructiblesTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.attackDestructiblesTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.attackDestructiblesTimer_targetTicks = baseline.attackDestructiblesTimer_targetTicks;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.attackDestructiblesTimer_stopTick = reader.ReadPackedUIntDelta(baseline.attackDestructiblesTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.attackDestructiblesTimer_stopTick = baseline.attackDestructiblesTimer_stopTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 9322176271568608902uL,
					ComponentType = ComponentType.ReadWrite<VehicleRidingStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<VehicleRidingStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 11,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 17110174830599239022uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<VehicleRidingStateCD, Snapshot, VehicleRidingStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
