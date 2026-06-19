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
	public struct WallBossCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int mainEntity;

			public uint mainEntitySpawnTick;

			public uint isMainEntity;

			public int leftEntity;

			public uint leftEntitySpawnTick;

			public int rightEntity;

			public uint rightEntitySpawnTick;

			public int segmentNumber;

			public int movementState;

			public float currentSpeed;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<WallBossCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<WallBossCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<WallBossCD>(component), in GhostComponentSerializer.TypeCastReadonly<WallBossCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in WallBossCD component)
		{
			snapshot.mainEntity = 0;
			snapshot.mainEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.mainEntity))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.mainEntity];
				snapshot.mainEntity = ghostInstance.ghostId;
				snapshot.mainEntitySpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.isMainEntity = (component.isMainEntity ? 1u : 0u);
			snapshot.leftEntity = 0;
			snapshot.leftEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.leftEntity))
			{
				GhostInstance ghostInstance2 = serializerState.GhostFromEntity[component.leftEntity];
				snapshot.leftEntity = ghostInstance2.ghostId;
				snapshot.leftEntitySpawnTick = ghostInstance2.spawnTick.SerializedData;
			}
			snapshot.rightEntity = 0;
			snapshot.rightEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.rightEntity))
			{
				GhostInstance ghostInstance3 = serializerState.GhostFromEntity[component.rightEntity];
				snapshot.rightEntity = ghostInstance3.ghostId;
				snapshot.rightEntitySpawnTick = ghostInstance3.spawnTick.SerializedData;
			}
			snapshot.segmentNumber = component.segmentNumber;
			snapshot.movementState = (int)component.movementState;
			snapshot.currentSpeed = component.currentSpeed;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref WallBossCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.mainEntity = Entity.Null;
			if (snapshotBefore.mainEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.mainEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.mainEntitySpawnTick
				}
			}, out var item))
			{
				component.mainEntity = item;
			}
			component.isMainEntity = snapshotBefore.isMainEntity != 0;
			component.leftEntity = Entity.Null;
			if (snapshotBefore.leftEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.leftEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.leftEntitySpawnTick
				}
			}, out var item2))
			{
				component.leftEntity = item2;
			}
			component.rightEntity = Entity.Null;
			if (snapshotBefore.rightEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.rightEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.rightEntitySpawnTick
				}
			}, out var item3))
			{
				component.rightEntity = item3;
			}
			component.segmentNumber = snapshotBefore.segmentNumber;
			component.movementState = (WallBossMovementState)snapshotBefore.movementState;
			component.currentSpeed = snapshotBefore.currentSpeed;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref WallBossCD component, in WallBossCD backup)
		{
			component.mainEntity = backup.mainEntity;
			component.isMainEntity = backup.isMainEntity;
			component.leftEntity = backup.leftEntity;
			component.rightEntity = backup.rightEntity;
			component.segmentNumber = backup.segmentNumber;
			component.movementState = backup.movementState;
			component.currentSpeed = backup.currentSpeed;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.mainEntity = predictor.PredictInt(snapshot.mainEntity, baseline1.mainEntity, baseline2.mainEntity);
			snapshot.mainEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.mainEntitySpawnTick, (int)baseline1.mainEntitySpawnTick, baseline2.mainEntity);
			snapshot.isMainEntity = (uint)predictor.PredictInt((int)snapshot.isMainEntity, (int)baseline1.isMainEntity, (int)baseline2.isMainEntity);
			snapshot.leftEntity = predictor.PredictInt(snapshot.leftEntity, baseline1.leftEntity, baseline2.leftEntity);
			snapshot.leftEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.leftEntitySpawnTick, (int)baseline1.leftEntitySpawnTick, baseline2.leftEntity);
			snapshot.rightEntity = predictor.PredictInt(snapshot.rightEntity, baseline1.rightEntity, baseline2.rightEntity);
			snapshot.rightEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.rightEntitySpawnTick, (int)baseline1.rightEntitySpawnTick, baseline2.rightEntity);
			snapshot.segmentNumber = predictor.PredictInt(snapshot.segmentNumber, baseline1.segmentNumber, baseline2.segmentNumber);
			snapshot.movementState = predictor.PredictInt(snapshot.movementState, baseline1.movementState, baseline2.movementState);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.mainEntity != baseline.mainEntity || snapshot.mainEntitySpawnTick != baseline.mainEntitySpawnTick) ? 1u : 0u);
			num |= (uint)((snapshot.isMainEntity != baseline.isMainEntity) ? 2 : 0);
			num |= (uint)((snapshot.leftEntity != baseline.leftEntity || snapshot.leftEntitySpawnTick != baseline.leftEntitySpawnTick) ? 4 : 0);
			num |= (uint)((snapshot.rightEntity != baseline.rightEntity || snapshot.rightEntitySpawnTick != baseline.rightEntitySpawnTick) ? 8 : 0);
			num |= (uint)((snapshot.segmentNumber != baseline.segmentNumber) ? 16 : 0);
			num |= (uint)((snapshot.movementState != baseline.movementState) ? 32 : 0);
			num |= (uint)((snapshot.currentSpeed != baseline.currentSpeed) ? 64 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.mainEntity, baseline.mainEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.mainEntitySpawnTick, baseline.mainEntitySpawnTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isMainEntity, baseline.isMainEntity, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.leftEntity, baseline.leftEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.leftEntitySpawnTick, baseline.leftEntitySpawnTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.rightEntity, baseline.rightEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.rightEntitySpawnTick, baseline.rightEntitySpawnTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segmentNumber, baseline.segmentNumber, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.movementState, baseline.movementState, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentSpeed, baseline.currentSpeed, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.mainEntity != baseline.mainEntity || snapshot.mainEntitySpawnTick != baseline.mainEntitySpawnTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.mainEntity, baseline.mainEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.mainEntitySpawnTick, baseline.mainEntitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.isMainEntity != baseline.isMainEntity) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isMainEntity, baseline.isMainEntity, in compressionModel);
			}
			num |= (uint)((snapshot.leftEntity != baseline.leftEntity || snapshot.leftEntitySpawnTick != baseline.leftEntitySpawnTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.leftEntity, baseline.leftEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.leftEntitySpawnTick, baseline.leftEntitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.rightEntity != baseline.rightEntity || snapshot.rightEntitySpawnTick != baseline.rightEntitySpawnTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.rightEntity, baseline.rightEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.rightEntitySpawnTick, baseline.rightEntitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.segmentNumber != baseline.segmentNumber) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segmentNumber, baseline.segmentNumber, in compressionModel);
			}
			num |= (uint)((snapshot.movementState != baseline.movementState) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.movementState, baseline.movementState, in compressionModel);
			}
			num |= (uint)((snapshot.currentSpeed != baseline.currentSpeed) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentSpeed, baseline.currentSpeed, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				snapshot.mainEntity = reader.ReadPackedIntDelta(baseline.mainEntity, in compressionModel);
				snapshot.mainEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.mainEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.mainEntity = baseline.mainEntity;
				snapshot.mainEntitySpawnTick = baseline.mainEntitySpawnTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.isMainEntity = reader.ReadPackedUIntDelta(baseline.isMainEntity, in compressionModel);
			}
			else
			{
				snapshot.isMainEntity = baseline.isMainEntity;
			}
			if ((num & 4) != 0)
			{
				snapshot.leftEntity = reader.ReadPackedIntDelta(baseline.leftEntity, in compressionModel);
				snapshot.leftEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.leftEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.leftEntity = baseline.leftEntity;
				snapshot.leftEntitySpawnTick = baseline.leftEntitySpawnTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.rightEntity = reader.ReadPackedIntDelta(baseline.rightEntity, in compressionModel);
				snapshot.rightEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.rightEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.rightEntity = baseline.rightEntity;
				snapshot.rightEntitySpawnTick = baseline.rightEntitySpawnTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.segmentNumber = reader.ReadPackedIntDelta(baseline.segmentNumber, in compressionModel);
			}
			else
			{
				snapshot.segmentNumber = baseline.segmentNumber;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.movementState = reader.ReadPackedIntDelta(baseline.movementState, in compressionModel);
			}
			else
			{
				snapshot.movementState = baseline.movementState;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.currentSpeed = reader.ReadPackedFloatDelta(baseline.currentSpeed, in compressionModel);
			}
			else
			{
				snapshot.currentSpeed = baseline.currentSpeed;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1966819302090705106uL,
					ComponentType = ComponentType.ReadWrite<WallBossCD>(),
					ComponentSize = UnsafeUtility.SizeOf<WallBossCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 7,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 9259816993571709076uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<WallBossCD, Snapshot, WallBossCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
