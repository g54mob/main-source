using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PugTilemap;
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
	public struct EffectEventCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint effectID;

			public uint localOnlyEffect;

			public int position1_x;

			public int position1_y;

			public int position1_z;

			public int vector1_x;

			public int vector1_y;

			public int vector1_z;

			public int value1;

			public int value2;

			public int entity;

			public uint entitySpawnTick;

			public int entity2;

			public uint entity2SpawnTick;

			public int tileInfo_tileset;

			public int tileInfo_tileType;

			public int tileInfo_state;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<EffectEventCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<EffectEventCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<EffectEventCD>(component), in GhostComponentSerializer.TypeCastReadonly<EffectEventCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in EffectEventCD component)
		{
			snapshot.effectID = (uint)component.effectID;
			snapshot.localOnlyEffect = component.localOnlyEffect;
			snapshot.position1_x = (int)math.round(component.position1.x * 1000f);
			snapshot.position1_y = (int)math.round(component.position1.y * 1000f);
			snapshot.position1_z = (int)math.round(component.position1.z * 1000f);
			snapshot.vector1_x = (int)math.round(component.vector1.x * 1000f);
			snapshot.vector1_y = (int)math.round(component.vector1.y * 1000f);
			snapshot.vector1_z = (int)math.round(component.vector1.z * 1000f);
			snapshot.value1 = component.value1;
			snapshot.value2 = component.value2;
			snapshot.entity = 0;
			snapshot.entitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.entity))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.entity];
				snapshot.entity = ghostInstance.ghostId;
				snapshot.entitySpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.entity2 = 0;
			snapshot.entity2SpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.entity2))
			{
				GhostInstance ghostInstance2 = serializerState.GhostFromEntity[component.entity2];
				snapshot.entity2 = ghostInstance2.ghostId;
				snapshot.entity2SpawnTick = ghostInstance2.spawnTick.SerializedData;
			}
			snapshot.tileInfo_tileset = component.tileInfo.tileset;
			snapshot.tileInfo_tileType = (int)component.tileInfo.tileType;
			snapshot.tileInfo_state = component.tileInfo.state;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref EffectEventCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.effectID = (EffectID)snapshotBefore.effectID;
			component.localOnlyEffect = (byte)snapshotBefore.localOnlyEffect;
			component.position1 = new float3((float)snapshotBefore.position1_x * 0.001f, (float)snapshotBefore.position1_y * 0.001f, (float)snapshotBefore.position1_z * 0.001f);
			component.vector1 = new float3((float)snapshotBefore.vector1_x * 0.001f, (float)snapshotBefore.vector1_y * 0.001f, (float)snapshotBefore.vector1_z * 0.001f);
			component.value1 = snapshotBefore.value1;
			component.value2 = snapshotBefore.value2;
			component.entity = Entity.Null;
			if (snapshotBefore.entity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.entity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.entitySpawnTick
				}
			}, out var item))
			{
				component.entity = item;
			}
			component.entity2 = Entity.Null;
			if (snapshotBefore.entity2 != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.entity2,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.entity2SpawnTick
				}
			}, out var item2))
			{
				component.entity2 = item2;
			}
			component.tileInfo.tileset = snapshotBefore.tileInfo_tileset;
			component.tileInfo.tileType = (TileType)snapshotBefore.tileInfo_tileType;
			component.tileInfo.state = snapshotBefore.tileInfo_state;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref EffectEventCD component, in EffectEventCD backup)
		{
			component.effectID = backup.effectID;
			component.localOnlyEffect = backup.localOnlyEffect;
			component.position1.x = backup.position1.x;
			component.position1.y = backup.position1.y;
			component.position1.z = backup.position1.z;
			component.vector1.x = backup.vector1.x;
			component.vector1.y = backup.vector1.y;
			component.vector1.z = backup.vector1.z;
			component.value1 = backup.value1;
			component.value2 = backup.value2;
			component.entity = backup.entity;
			component.entity2 = backup.entity2;
			component.tileInfo.tileset = backup.tileInfo.tileset;
			component.tileInfo.tileType = backup.tileInfo.tileType;
			component.tileInfo.state = backup.tileInfo.state;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.effectID = (uint)predictor.PredictInt((int)snapshot.effectID, (int)baseline1.effectID, (int)baseline2.effectID);
			snapshot.localOnlyEffect = (uint)predictor.PredictInt((int)snapshot.localOnlyEffect, (int)baseline1.localOnlyEffect, (int)baseline2.localOnlyEffect);
			snapshot.position1_x = predictor.PredictInt(snapshot.position1_x, baseline1.position1_x, baseline2.position1_x);
			snapshot.position1_y = predictor.PredictInt(snapshot.position1_y, baseline1.position1_y, baseline2.position1_y);
			snapshot.position1_z = predictor.PredictInt(snapshot.position1_z, baseline1.position1_z, baseline2.position1_z);
			snapshot.vector1_x = predictor.PredictInt(snapshot.vector1_x, baseline1.vector1_x, baseline2.vector1_x);
			snapshot.vector1_y = predictor.PredictInt(snapshot.vector1_y, baseline1.vector1_y, baseline2.vector1_y);
			snapshot.vector1_z = predictor.PredictInt(snapshot.vector1_z, baseline1.vector1_z, baseline2.vector1_z);
			snapshot.value1 = predictor.PredictInt(snapshot.value1, baseline1.value1, baseline2.value1);
			snapshot.value2 = predictor.PredictInt(snapshot.value2, baseline1.value2, baseline2.value2);
			snapshot.entity = predictor.PredictInt(snapshot.entity, baseline1.entity, baseline2.entity);
			snapshot.entitySpawnTick = (uint)predictor.PredictInt((int)snapshot.entitySpawnTick, (int)baseline1.entitySpawnTick, baseline2.entity);
			snapshot.entity2 = predictor.PredictInt(snapshot.entity2, baseline1.entity2, baseline2.entity2);
			snapshot.entity2SpawnTick = (uint)predictor.PredictInt((int)snapshot.entity2SpawnTick, (int)baseline1.entity2SpawnTick, baseline2.entity2);
			snapshot.tileInfo_tileset = predictor.PredictInt(snapshot.tileInfo_tileset, baseline1.tileInfo_tileset, baseline2.tileInfo_tileset);
			snapshot.tileInfo_tileType = predictor.PredictInt(snapshot.tileInfo_tileType, baseline1.tileInfo_tileType, baseline2.tileInfo_tileType);
			snapshot.tileInfo_state = predictor.PredictInt(snapshot.tileInfo_state, baseline1.tileInfo_state, baseline2.tileInfo_state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.effectID != baseline.effectID) ? 1u : 0u);
			num |= (uint)((snapshot.localOnlyEffect != baseline.localOnlyEffect) ? 2 : 0);
			num |= (uint)((snapshot.position1_x != baseline.position1_x) ? 4 : 0);
			num |= (uint)((snapshot.position1_y != baseline.position1_y) ? 4 : 0);
			num |= (uint)((snapshot.position1_z != baseline.position1_z) ? 4 : 0);
			num |= (uint)((snapshot.vector1_x != baseline.vector1_x) ? 8 : 0);
			num |= (uint)((snapshot.vector1_y != baseline.vector1_y) ? 8 : 0);
			num |= (uint)((snapshot.vector1_z != baseline.vector1_z) ? 8 : 0);
			num |= (uint)((snapshot.value1 != baseline.value1) ? 16 : 0);
			num |= (uint)((snapshot.value2 != baseline.value2) ? 32 : 0);
			num |= (uint)((snapshot.entity != baseline.entity || snapshot.entitySpawnTick != baseline.entitySpawnTick) ? 64 : 0);
			num |= (uint)((snapshot.entity2 != baseline.entity2 || snapshot.entity2SpawnTick != baseline.entity2SpawnTick) ? 128 : 0);
			num |= (uint)((snapshot.tileInfo_tileset != baseline.tileInfo_tileset) ? 256 : 0);
			num |= (uint)((snapshot.tileInfo_tileType != baseline.tileInfo_tileType) ? 512 : 0);
			num |= (uint)((snapshot.tileInfo_state != baseline.tileInfo_state) ? 1024 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 11);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 11);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.effectID, baseline.effectID, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.localOnlyEffect, baseline.localOnlyEffect, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.position1_x, baseline.position1_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.position1_y, baseline.position1_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.position1_z, baseline.position1_z, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.vector1_x, baseline.vector1_x, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.vector1_y, baseline.vector1_y, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.vector1_z, baseline.vector1_z, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value1, baseline.value1, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value2, baseline.value2, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.entity, baseline.entity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.entitySpawnTick, baseline.entitySpawnTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.entity2, baseline.entity2, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.entity2SpawnTick, baseline.entity2SpawnTick, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileInfo_tileset, baseline.tileInfo_tileset, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileInfo_tileType, baseline.tileInfo_tileType, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileInfo_state, baseline.tileInfo_state, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.effectID != baseline.effectID) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.effectID, baseline.effectID, in compressionModel);
			}
			num |= (uint)((snapshot.localOnlyEffect != baseline.localOnlyEffect) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.localOnlyEffect, baseline.localOnlyEffect, in compressionModel);
			}
			num |= (uint)((snapshot.position1_x != baseline.position1_x) ? 4 : 0);
			num |= (uint)((snapshot.position1_y != baseline.position1_y) ? 4 : 0);
			num |= (uint)((snapshot.position1_z != baseline.position1_z) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.position1_x, baseline.position1_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.position1_y, baseline.position1_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.position1_z, baseline.position1_z, in compressionModel);
			}
			num |= (uint)((snapshot.vector1_x != baseline.vector1_x) ? 8 : 0);
			num |= (uint)((snapshot.vector1_y != baseline.vector1_y) ? 8 : 0);
			num |= (uint)((snapshot.vector1_z != baseline.vector1_z) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.vector1_x, baseline.vector1_x, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.vector1_y, baseline.vector1_y, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.vector1_z, baseline.vector1_z, in compressionModel);
			}
			num |= (uint)((snapshot.value1 != baseline.value1) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value1, baseline.value1, in compressionModel);
			}
			num |= (uint)((snapshot.value2 != baseline.value2) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value2, baseline.value2, in compressionModel);
			}
			num |= (uint)((snapshot.entity != baseline.entity || snapshot.entitySpawnTick != baseline.entitySpawnTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.entity, baseline.entity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.entitySpawnTick, baseline.entitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.entity2 != baseline.entity2 || snapshot.entity2SpawnTick != baseline.entity2SpawnTick) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.entity2, baseline.entity2, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.entity2SpawnTick, baseline.entity2SpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.tileInfo_tileset != baseline.tileInfo_tileset) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileInfo_tileset, baseline.tileInfo_tileset, in compressionModel);
			}
			num |= (uint)((snapshot.tileInfo_tileType != baseline.tileInfo_tileType) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileInfo_tileType, baseline.tileInfo_tileType, in compressionModel);
			}
			num |= (uint)((snapshot.tileInfo_state != baseline.tileInfo_state) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileInfo_state, baseline.tileInfo_state, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 11);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 11);
			if ((num & 1) != 0)
			{
				snapshot.effectID = reader.ReadPackedUIntDelta(baseline.effectID, in compressionModel);
			}
			else
			{
				snapshot.effectID = baseline.effectID;
			}
			if ((num & 2) != 0)
			{
				snapshot.localOnlyEffect = reader.ReadPackedUIntDelta(baseline.localOnlyEffect, in compressionModel);
			}
			else
			{
				snapshot.localOnlyEffect = baseline.localOnlyEffect;
			}
			if ((num & 4) != 0)
			{
				snapshot.position1_x = reader.ReadPackedIntDelta(baseline.position1_x, in compressionModel);
			}
			else
			{
				snapshot.position1_x = baseline.position1_x;
			}
			if ((num & 4) != 0)
			{
				snapshot.position1_y = reader.ReadPackedIntDelta(baseline.position1_y, in compressionModel);
			}
			else
			{
				snapshot.position1_y = baseline.position1_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.position1_z = reader.ReadPackedIntDelta(baseline.position1_z, in compressionModel);
			}
			else
			{
				snapshot.position1_z = baseline.position1_z;
			}
			if ((num & 8) != 0)
			{
				snapshot.vector1_x = reader.ReadPackedIntDelta(baseline.vector1_x, in compressionModel);
			}
			else
			{
				snapshot.vector1_x = baseline.vector1_x;
			}
			if ((num & 8) != 0)
			{
				snapshot.vector1_y = reader.ReadPackedIntDelta(baseline.vector1_y, in compressionModel);
			}
			else
			{
				snapshot.vector1_y = baseline.vector1_y;
			}
			if ((num & 8) != 0)
			{
				snapshot.vector1_z = reader.ReadPackedIntDelta(baseline.vector1_z, in compressionModel);
			}
			else
			{
				snapshot.vector1_z = baseline.vector1_z;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.value1 = reader.ReadPackedIntDelta(baseline.value1, in compressionModel);
			}
			else
			{
				snapshot.value1 = baseline.value1;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.value2 = reader.ReadPackedIntDelta(baseline.value2, in compressionModel);
			}
			else
			{
				snapshot.value2 = baseline.value2;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.entity = reader.ReadPackedIntDelta(baseline.entity, in compressionModel);
				snapshot.entitySpawnTick = reader.ReadPackedUIntDelta(baseline.entitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.entity = baseline.entity;
				snapshot.entitySpawnTick = baseline.entitySpawnTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.entity2 = reader.ReadPackedIntDelta(baseline.entity2, in compressionModel);
				snapshot.entity2SpawnTick = reader.ReadPackedUIntDelta(baseline.entity2SpawnTick, in compressionModel);
			}
			else
			{
				snapshot.entity2 = baseline.entity2;
				snapshot.entity2SpawnTick = baseline.entity2SpawnTick;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.tileInfo_tileset = reader.ReadPackedIntDelta(baseline.tileInfo_tileset, in compressionModel);
			}
			else
			{
				snapshot.tileInfo_tileset = baseline.tileInfo_tileset;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.tileInfo_tileType = reader.ReadPackedIntDelta(baseline.tileInfo_tileType, in compressionModel);
			}
			else
			{
				snapshot.tileInfo_tileType = baseline.tileInfo_tileType;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.tileInfo_state = reader.ReadPackedIntDelta(baseline.tileInfo_state, in compressionModel);
			}
			else
			{
				snapshot.tileInfo_state = baseline.tileInfo_state;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 4587394662998240158uL,
					ComponentType = ComponentType.ReadWrite<EffectEventCD>(),
					ComponentSize = UnsafeUtility.SizeOf<EffectEventCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 11,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 833309810126387540uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<EffectEventCD, Snapshot, EffectEventCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
