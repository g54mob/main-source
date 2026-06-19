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
	public struct RobotBossLegsBufferGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int leg;

			public uint legSpawnTick;

			public float plannedTargetPosition_x;

			public float plannedTargetPosition_y;

			public float plannedTargetPosition_z;

			public uint hasPlannedTarget;

			public float brokenTimer_lifespan;

			public int brokenTimerValue;

			public int legPosition;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<RobotBossLegsBuffer>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<RobotBossLegsBuffer>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<RobotBossLegsBuffer>(component), in GhostComponentSerializer.TypeCastReadonly<RobotBossLegsBuffer>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in RobotBossLegsBuffer component)
		{
			snapshot.leg = 0;
			snapshot.legSpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.leg))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.leg];
				snapshot.leg = ghostInstance.ghostId;
				snapshot.legSpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.plannedTargetPosition_x = component.plannedTargetPosition.x;
			snapshot.plannedTargetPosition_y = component.plannedTargetPosition.y;
			snapshot.plannedTargetPosition_z = component.plannedTargetPosition.z;
			snapshot.hasPlannedTarget = (component.hasPlannedTarget ? 1u : 0u);
			snapshot.brokenTimer_lifespan = component.brokenTimer.lifespan;
			snapshot.brokenTimerValue = component.brokenTimerValue;
			snapshot.legPosition = (int)component.legPosition;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref RobotBossLegsBuffer component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.leg = Entity.Null;
			if (snapshotBefore.leg != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.leg,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.legSpawnTick
				}
			}, out var item))
			{
				component.leg = item;
			}
			component.plannedTargetPosition = new float3(snapshotBefore.plannedTargetPosition_x, snapshotBefore.plannedTargetPosition_y, snapshotBefore.plannedTargetPosition_z);
			component.hasPlannedTarget = snapshotBefore.hasPlannedTarget != 0;
			component.brokenTimer.lifespan = snapshotBefore.brokenTimer_lifespan;
			component.brokenTimerValue = snapshotBefore.brokenTimerValue;
			component.legPosition = (RobotBossLegPosition)snapshotBefore.legPosition;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref RobotBossLegsBuffer component, in RobotBossLegsBuffer backup)
		{
			component.leg = backup.leg;
			component.plannedTargetPosition.x = backup.plannedTargetPosition.x;
			component.plannedTargetPosition.y = backup.plannedTargetPosition.y;
			component.plannedTargetPosition.z = backup.plannedTargetPosition.z;
			component.hasPlannedTarget = backup.hasPlannedTarget;
			component.brokenTimer.lifespan = backup.brokenTimer.lifespan;
			component.brokenTimerValue = backup.brokenTimerValue;
			component.legPosition = backup.legPosition;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.leg = predictor.PredictInt(snapshot.leg, baseline1.leg, baseline2.leg);
			snapshot.legSpawnTick = (uint)predictor.PredictInt((int)snapshot.legSpawnTick, (int)baseline1.legSpawnTick, baseline2.leg);
			snapshot.hasPlannedTarget = (uint)predictor.PredictInt((int)snapshot.hasPlannedTarget, (int)baseline1.hasPlannedTarget, (int)baseline2.hasPlannedTarget);
			snapshot.brokenTimerValue = predictor.PredictInt(snapshot.brokenTimerValue, baseline1.brokenTimerValue, baseline2.brokenTimerValue);
			snapshot.legPosition = predictor.PredictInt(snapshot.legPosition, baseline1.legPosition, baseline2.legPosition);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.leg != baseline.leg || snapshot.legSpawnTick != baseline.legSpawnTick) ? 1u : 0u);
			num |= (uint)((snapshot.plannedTargetPosition_x != baseline.plannedTargetPosition_x) ? 2 : 0);
			num |= (uint)((snapshot.plannedTargetPosition_y != baseline.plannedTargetPosition_y) ? 2 : 0);
			num |= (uint)((snapshot.plannedTargetPosition_z != baseline.plannedTargetPosition_z) ? 2 : 0);
			num |= (uint)((snapshot.hasPlannedTarget != baseline.hasPlannedTarget) ? 4 : 0);
			num |= (uint)((snapshot.brokenTimer_lifespan != baseline.brokenTimer_lifespan) ? 8 : 0);
			num |= (uint)((snapshot.brokenTimerValue != baseline.brokenTimerValue) ? 16 : 0);
			num |= (uint)((snapshot.legPosition != baseline.legPosition) ? 32 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.leg, baseline.leg, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.legSpawnTick, baseline.legSpawnTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.plannedTargetPosition_x, baseline.plannedTargetPosition_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.plannedTargetPosition_y, baseline.plannedTargetPosition_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.plannedTargetPosition_z, baseline.plannedTargetPosition_z, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hasPlannedTarget, baseline.hasPlannedTarget, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.brokenTimer_lifespan, baseline.brokenTimer_lifespan, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.brokenTimerValue, baseline.brokenTimerValue, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.legPosition, baseline.legPosition, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.leg != baseline.leg || snapshot.legSpawnTick != baseline.legSpawnTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.leg, baseline.leg, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.legSpawnTick, baseline.legSpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.plannedTargetPosition_x != baseline.plannedTargetPosition_x) ? 2 : 0);
			num |= (uint)((snapshot.plannedTargetPosition_y != baseline.plannedTargetPosition_y) ? 2 : 0);
			num |= (uint)((snapshot.plannedTargetPosition_z != baseline.plannedTargetPosition_z) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.plannedTargetPosition_x, baseline.plannedTargetPosition_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.plannedTargetPosition_y, baseline.plannedTargetPosition_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.plannedTargetPosition_z, baseline.plannedTargetPosition_z, in compressionModel);
			}
			num |= (uint)((snapshot.hasPlannedTarget != baseline.hasPlannedTarget) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hasPlannedTarget, baseline.hasPlannedTarget, in compressionModel);
			}
			num |= (uint)((snapshot.brokenTimer_lifespan != baseline.brokenTimer_lifespan) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.brokenTimer_lifespan, baseline.brokenTimer_lifespan, in compressionModel);
			}
			num |= (uint)((snapshot.brokenTimerValue != baseline.brokenTimerValue) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.brokenTimerValue, baseline.brokenTimerValue, in compressionModel);
			}
			num |= (uint)((snapshot.legPosition != baseline.legPosition) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.legPosition, baseline.legPosition, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				snapshot.leg = reader.ReadPackedIntDelta(baseline.leg, in compressionModel);
				snapshot.legSpawnTick = reader.ReadPackedUIntDelta(baseline.legSpawnTick, in compressionModel);
			}
			else
			{
				snapshot.leg = baseline.leg;
				snapshot.legSpawnTick = baseline.legSpawnTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.plannedTargetPosition_x = reader.ReadPackedFloatDelta(baseline.plannedTargetPosition_x, in compressionModel);
			}
			else
			{
				snapshot.plannedTargetPosition_x = baseline.plannedTargetPosition_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.plannedTargetPosition_y = reader.ReadPackedFloatDelta(baseline.plannedTargetPosition_y, in compressionModel);
			}
			else
			{
				snapshot.plannedTargetPosition_y = baseline.plannedTargetPosition_y;
			}
			if ((num & 2) != 0)
			{
				snapshot.plannedTargetPosition_z = reader.ReadPackedFloatDelta(baseline.plannedTargetPosition_z, in compressionModel);
			}
			else
			{
				snapshot.plannedTargetPosition_z = baseline.plannedTargetPosition_z;
			}
			if ((num & 4) != 0)
			{
				snapshot.hasPlannedTarget = reader.ReadPackedUIntDelta(baseline.hasPlannedTarget, in compressionModel);
			}
			else
			{
				snapshot.hasPlannedTarget = baseline.hasPlannedTarget;
			}
			if ((num & 8) != 0)
			{
				snapshot.brokenTimer_lifespan = reader.ReadPackedFloatDelta(baseline.brokenTimer_lifespan, in compressionModel);
			}
			else
			{
				snapshot.brokenTimer_lifespan = baseline.brokenTimer_lifespan;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.brokenTimerValue = reader.ReadPackedIntDelta(baseline.brokenTimerValue, in compressionModel);
			}
			else
			{
				snapshot.brokenTimerValue = baseline.brokenTimerValue;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.legPosition = reader.ReadPackedIntDelta(baseline.legPosition, in compressionModel);
			}
			else
			{
				snapshot.legPosition = baseline.legPosition;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 16877093822059739888uL,
					ComponentType = ComponentType.ReadWrite<RobotBossLegsBuffer>(),
					ComponentSize = UnsafeUtility.SizeOf<RobotBossLegsBuffer>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 6,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 7431589839372841876uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = BufferSerializationHelper<RobotBossLegsBuffer, Snapshot, RobotBossLegsBufferGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
