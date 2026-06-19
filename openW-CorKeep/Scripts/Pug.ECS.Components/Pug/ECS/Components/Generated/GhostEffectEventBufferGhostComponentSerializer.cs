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
	public struct GhostEffectEventBufferGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint value_effectID;

			public uint value_localOnlyEffect;

			public int value_position1_x;

			public int value_position1_y;

			public int value_position1_z;

			public int value_vector1_x;

			public int value_vector1_y;

			public int value_vector1_z;

			public int value_value1;

			public int value_value2;

			public int value_entity;

			public uint value_entitySpawnTick;

			public int value_entity2;

			public uint value_entity2SpawnTick;

			public int value_tileInfo_tileset;

			public int value_tileInfo_tileType;

			public int value_tileInfo_state;

			public uint Tick;
		}

		private const int ChangeMaskBits = 12;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 12;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<GhostEffectEventBuffer>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<GhostEffectEventBuffer>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<GhostEffectEventBuffer>(component), in GhostComponentSerializer.TypeCastReadonly<GhostEffectEventBuffer>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in GhostEffectEventBuffer component)
		{
			snapshot.value_effectID = (uint)component.value.effectID;
			snapshot.value_localOnlyEffect = component.value.localOnlyEffect;
			snapshot.value_position1_x = (int)math.round(component.value.position1.x * 1000f);
			snapshot.value_position1_y = (int)math.round(component.value.position1.y * 1000f);
			snapshot.value_position1_z = (int)math.round(component.value.position1.z * 1000f);
			snapshot.value_vector1_x = (int)math.round(component.value.vector1.x * 1000f);
			snapshot.value_vector1_y = (int)math.round(component.value.vector1.y * 1000f);
			snapshot.value_vector1_z = (int)math.round(component.value.vector1.z * 1000f);
			snapshot.value_value1 = component.value.value1;
			snapshot.value_value2 = component.value.value2;
			snapshot.value_entity = 0;
			snapshot.value_entitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.value.entity))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.value.entity];
				snapshot.value_entity = ghostInstance.ghostId;
				snapshot.value_entitySpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.value_entity2 = 0;
			snapshot.value_entity2SpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.value.entity2))
			{
				GhostInstance ghostInstance2 = serializerState.GhostFromEntity[component.value.entity2];
				snapshot.value_entity2 = ghostInstance2.ghostId;
				snapshot.value_entity2SpawnTick = ghostInstance2.spawnTick.SerializedData;
			}
			snapshot.value_tileInfo_tileset = component.value.tileInfo.tileset;
			snapshot.value_tileInfo_tileType = (int)component.value.tileInfo.tileType;
			snapshot.value_tileInfo_state = component.value.tileInfo.state;
			snapshot.Tick = component.Tick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref GhostEffectEventBuffer component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.value.effectID = (EffectID)snapshotBefore.value_effectID;
			component.value.localOnlyEffect = (byte)snapshotBefore.value_localOnlyEffect;
			component.value.position1 = new float3((float)snapshotBefore.value_position1_x * 0.001f, (float)snapshotBefore.value_position1_y * 0.001f, (float)snapshotBefore.value_position1_z * 0.001f);
			component.value.vector1 = new float3((float)snapshotBefore.value_vector1_x * 0.001f, (float)snapshotBefore.value_vector1_y * 0.001f, (float)snapshotBefore.value_vector1_z * 0.001f);
			component.value.value1 = snapshotBefore.value_value1;
			component.value.value2 = snapshotBefore.value_value2;
			component.value.entity = Entity.Null;
			if (snapshotBefore.value_entity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.value_entity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.value_entitySpawnTick
				}
			}, out var item))
			{
				component.value.entity = item;
			}
			component.value.entity2 = Entity.Null;
			if (snapshotBefore.value_entity2 != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.value_entity2,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.value_entity2SpawnTick
				}
			}, out var item2))
			{
				component.value.entity2 = item2;
			}
			component.value.tileInfo.tileset = snapshotBefore.value_tileInfo_tileset;
			component.value.tileInfo.tileType = (TileType)snapshotBefore.value_tileInfo_tileType;
			component.value.tileInfo.state = snapshotBefore.value_tileInfo_state;
			component.Tick = new NetworkTick
			{
				SerializedData = snapshotBefore.Tick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref GhostEffectEventBuffer component, in GhostEffectEventBuffer backup)
		{
			component.value.effectID = backup.value.effectID;
			component.value.localOnlyEffect = backup.value.localOnlyEffect;
			component.value.position1.x = backup.value.position1.x;
			component.value.position1.y = backup.value.position1.y;
			component.value.position1.z = backup.value.position1.z;
			component.value.vector1.x = backup.value.vector1.x;
			component.value.vector1.y = backup.value.vector1.y;
			component.value.vector1.z = backup.value.vector1.z;
			component.value.value1 = backup.value.value1;
			component.value.value2 = backup.value.value2;
			component.value.entity = backup.value.entity;
			component.value.entity2 = backup.value.entity2;
			component.value.tileInfo.tileset = backup.value.tileInfo.tileset;
			component.value.tileInfo.tileType = backup.value.tileInfo.tileType;
			component.value.tileInfo.state = backup.value.tileInfo.state;
			component.Tick = backup.Tick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.value_effectID = (uint)predictor.PredictInt((int)snapshot.value_effectID, (int)baseline1.value_effectID, (int)baseline2.value_effectID);
			snapshot.value_localOnlyEffect = (uint)predictor.PredictInt((int)snapshot.value_localOnlyEffect, (int)baseline1.value_localOnlyEffect, (int)baseline2.value_localOnlyEffect);
			snapshot.value_position1_x = predictor.PredictInt(snapshot.value_position1_x, baseline1.value_position1_x, baseline2.value_position1_x);
			snapshot.value_position1_y = predictor.PredictInt(snapshot.value_position1_y, baseline1.value_position1_y, baseline2.value_position1_y);
			snapshot.value_position1_z = predictor.PredictInt(snapshot.value_position1_z, baseline1.value_position1_z, baseline2.value_position1_z);
			snapshot.value_vector1_x = predictor.PredictInt(snapshot.value_vector1_x, baseline1.value_vector1_x, baseline2.value_vector1_x);
			snapshot.value_vector1_y = predictor.PredictInt(snapshot.value_vector1_y, baseline1.value_vector1_y, baseline2.value_vector1_y);
			snapshot.value_vector1_z = predictor.PredictInt(snapshot.value_vector1_z, baseline1.value_vector1_z, baseline2.value_vector1_z);
			snapshot.value_value1 = predictor.PredictInt(snapshot.value_value1, baseline1.value_value1, baseline2.value_value1);
			snapshot.value_value2 = predictor.PredictInt(snapshot.value_value2, baseline1.value_value2, baseline2.value_value2);
			snapshot.value_entity = predictor.PredictInt(snapshot.value_entity, baseline1.value_entity, baseline2.value_entity);
			snapshot.value_entitySpawnTick = (uint)predictor.PredictInt((int)snapshot.value_entitySpawnTick, (int)baseline1.value_entitySpawnTick, baseline2.value_entity);
			snapshot.value_entity2 = predictor.PredictInt(snapshot.value_entity2, baseline1.value_entity2, baseline2.value_entity2);
			snapshot.value_entity2SpawnTick = (uint)predictor.PredictInt((int)snapshot.value_entity2SpawnTick, (int)baseline1.value_entity2SpawnTick, baseline2.value_entity2);
			snapshot.value_tileInfo_tileset = predictor.PredictInt(snapshot.value_tileInfo_tileset, baseline1.value_tileInfo_tileset, baseline2.value_tileInfo_tileset);
			snapshot.value_tileInfo_tileType = predictor.PredictInt(snapshot.value_tileInfo_tileType, baseline1.value_tileInfo_tileType, baseline2.value_tileInfo_tileType);
			snapshot.value_tileInfo_state = predictor.PredictInt(snapshot.value_tileInfo_state, baseline1.value_tileInfo_state, baseline2.value_tileInfo_state);
			snapshot.Tick = (uint)predictor.PredictInt((int)snapshot.Tick, (int)baseline1.Tick, (int)baseline2.Tick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.value_effectID != baseline.value_effectID) ? 1u : 0u);
			num |= (uint)((snapshot.value_localOnlyEffect != baseline.value_localOnlyEffect) ? 2 : 0);
			num |= (uint)((snapshot.value_position1_x != baseline.value_position1_x) ? 4 : 0);
			num |= (uint)((snapshot.value_position1_y != baseline.value_position1_y) ? 4 : 0);
			num |= (uint)((snapshot.value_position1_z != baseline.value_position1_z) ? 4 : 0);
			num |= (uint)((snapshot.value_vector1_x != baseline.value_vector1_x) ? 8 : 0);
			num |= (uint)((snapshot.value_vector1_y != baseline.value_vector1_y) ? 8 : 0);
			num |= (uint)((snapshot.value_vector1_z != baseline.value_vector1_z) ? 8 : 0);
			num |= (uint)((snapshot.value_value1 != baseline.value_value1) ? 16 : 0);
			num |= (uint)((snapshot.value_value2 != baseline.value_value2) ? 32 : 0);
			num |= (uint)((snapshot.value_entity != baseline.value_entity || snapshot.value_entitySpawnTick != baseline.value_entitySpawnTick) ? 64 : 0);
			num |= (uint)((snapshot.value_entity2 != baseline.value_entity2 || snapshot.value_entity2SpawnTick != baseline.value_entity2SpawnTick) ? 128 : 0);
			num |= (uint)((snapshot.value_tileInfo_tileset != baseline.value_tileInfo_tileset) ? 256 : 0);
			num |= (uint)((snapshot.value_tileInfo_tileType != baseline.value_tileInfo_tileType) ? 512 : 0);
			num |= (uint)((snapshot.value_tileInfo_state != baseline.value_tileInfo_state) ? 1024 : 0);
			num |= (uint)((snapshot.Tick != baseline.Tick) ? 2048 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 12);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 12);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.value_effectID, baseline.value_effectID, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.value_localOnlyEffect, baseline.value_localOnlyEffect, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_position1_x, baseline.value_position1_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_position1_y, baseline.value_position1_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_position1_z, baseline.value_position1_z, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_vector1_x, baseline.value_vector1_x, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_vector1_y, baseline.value_vector1_y, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_vector1_z, baseline.value_vector1_z, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_value1, baseline.value_value1, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_value2, baseline.value_value2, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_entity, baseline.value_entity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.value_entitySpawnTick, baseline.value_entitySpawnTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_entity2, baseline.value_entity2, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.value_entity2SpawnTick, baseline.value_entity2SpawnTick, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_tileInfo_tileset, baseline.value_tileInfo_tileset, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_tileInfo_tileType, baseline.value_tileInfo_tileType, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_tileInfo_state, baseline.value_tileInfo_state, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Tick, baseline.Tick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.value_effectID != baseline.value_effectID) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.value_effectID, baseline.value_effectID, in compressionModel);
			}
			num |= (uint)((snapshot.value_localOnlyEffect != baseline.value_localOnlyEffect) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.value_localOnlyEffect, baseline.value_localOnlyEffect, in compressionModel);
			}
			num |= (uint)((snapshot.value_position1_x != baseline.value_position1_x) ? 4 : 0);
			num |= (uint)((snapshot.value_position1_y != baseline.value_position1_y) ? 4 : 0);
			num |= (uint)((snapshot.value_position1_z != baseline.value_position1_z) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_position1_x, baseline.value_position1_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_position1_y, baseline.value_position1_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_position1_z, baseline.value_position1_z, in compressionModel);
			}
			num |= (uint)((snapshot.value_vector1_x != baseline.value_vector1_x) ? 8 : 0);
			num |= (uint)((snapshot.value_vector1_y != baseline.value_vector1_y) ? 8 : 0);
			num |= (uint)((snapshot.value_vector1_z != baseline.value_vector1_z) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_vector1_x, baseline.value_vector1_x, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_vector1_y, baseline.value_vector1_y, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_vector1_z, baseline.value_vector1_z, in compressionModel);
			}
			num |= (uint)((snapshot.value_value1 != baseline.value_value1) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_value1, baseline.value_value1, in compressionModel);
			}
			num |= (uint)((snapshot.value_value2 != baseline.value_value2) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_value2, baseline.value_value2, in compressionModel);
			}
			num |= (uint)((snapshot.value_entity != baseline.value_entity || snapshot.value_entitySpawnTick != baseline.value_entitySpawnTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_entity, baseline.value_entity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.value_entitySpawnTick, baseline.value_entitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.value_entity2 != baseline.value_entity2 || snapshot.value_entity2SpawnTick != baseline.value_entity2SpawnTick) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_entity2, baseline.value_entity2, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.value_entity2SpawnTick, baseline.value_entity2SpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.value_tileInfo_tileset != baseline.value_tileInfo_tileset) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_tileInfo_tileset, baseline.value_tileInfo_tileset, in compressionModel);
			}
			num |= (uint)((snapshot.value_tileInfo_tileType != baseline.value_tileInfo_tileType) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_tileInfo_tileType, baseline.value_tileInfo_tileType, in compressionModel);
			}
			num |= (uint)((snapshot.value_tileInfo_state != baseline.value_tileInfo_state) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.value_tileInfo_state, baseline.value_tileInfo_state, in compressionModel);
			}
			num |= (uint)((snapshot.Tick != baseline.Tick) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Tick, baseline.Tick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 12);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 12);
			if ((num & 1) != 0)
			{
				snapshot.value_effectID = reader.ReadPackedUIntDelta(baseline.value_effectID, in compressionModel);
			}
			else
			{
				snapshot.value_effectID = baseline.value_effectID;
			}
			if ((num & 2) != 0)
			{
				snapshot.value_localOnlyEffect = reader.ReadPackedUIntDelta(baseline.value_localOnlyEffect, in compressionModel);
			}
			else
			{
				snapshot.value_localOnlyEffect = baseline.value_localOnlyEffect;
			}
			if ((num & 4) != 0)
			{
				snapshot.value_position1_x = reader.ReadPackedIntDelta(baseline.value_position1_x, in compressionModel);
			}
			else
			{
				snapshot.value_position1_x = baseline.value_position1_x;
			}
			if ((num & 4) != 0)
			{
				snapshot.value_position1_y = reader.ReadPackedIntDelta(baseline.value_position1_y, in compressionModel);
			}
			else
			{
				snapshot.value_position1_y = baseline.value_position1_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.value_position1_z = reader.ReadPackedIntDelta(baseline.value_position1_z, in compressionModel);
			}
			else
			{
				snapshot.value_position1_z = baseline.value_position1_z;
			}
			if ((num & 8) != 0)
			{
				snapshot.value_vector1_x = reader.ReadPackedIntDelta(baseline.value_vector1_x, in compressionModel);
			}
			else
			{
				snapshot.value_vector1_x = baseline.value_vector1_x;
			}
			if ((num & 8) != 0)
			{
				snapshot.value_vector1_y = reader.ReadPackedIntDelta(baseline.value_vector1_y, in compressionModel);
			}
			else
			{
				snapshot.value_vector1_y = baseline.value_vector1_y;
			}
			if ((num & 8) != 0)
			{
				snapshot.value_vector1_z = reader.ReadPackedIntDelta(baseline.value_vector1_z, in compressionModel);
			}
			else
			{
				snapshot.value_vector1_z = baseline.value_vector1_z;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.value_value1 = reader.ReadPackedIntDelta(baseline.value_value1, in compressionModel);
			}
			else
			{
				snapshot.value_value1 = baseline.value_value1;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.value_value2 = reader.ReadPackedIntDelta(baseline.value_value2, in compressionModel);
			}
			else
			{
				snapshot.value_value2 = baseline.value_value2;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.value_entity = reader.ReadPackedIntDelta(baseline.value_entity, in compressionModel);
				snapshot.value_entitySpawnTick = reader.ReadPackedUIntDelta(baseline.value_entitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.value_entity = baseline.value_entity;
				snapshot.value_entitySpawnTick = baseline.value_entitySpawnTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.value_entity2 = reader.ReadPackedIntDelta(baseline.value_entity2, in compressionModel);
				snapshot.value_entity2SpawnTick = reader.ReadPackedUIntDelta(baseline.value_entity2SpawnTick, in compressionModel);
			}
			else
			{
				snapshot.value_entity2 = baseline.value_entity2;
				snapshot.value_entity2SpawnTick = baseline.value_entity2SpawnTick;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.value_tileInfo_tileset = reader.ReadPackedIntDelta(baseline.value_tileInfo_tileset, in compressionModel);
			}
			else
			{
				snapshot.value_tileInfo_tileset = baseline.value_tileInfo_tileset;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.value_tileInfo_tileType = reader.ReadPackedIntDelta(baseline.value_tileInfo_tileType, in compressionModel);
			}
			else
			{
				snapshot.value_tileInfo_tileType = baseline.value_tileInfo_tileType;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.value_tileInfo_state = reader.ReadPackedIntDelta(baseline.value_tileInfo_state, in compressionModel);
			}
			else
			{
				snapshot.value_tileInfo_state = baseline.value_tileInfo_state;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.Tick = reader.ReadPackedUIntDelta(baseline.Tick, in compressionModel);
			}
			else
			{
				snapshot.Tick = baseline.Tick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 5843876661729686932uL,
					ComponentType = ComponentType.ReadWrite<GhostEffectEventBuffer>(),
					ComponentSize = UnsafeUtility.SizeOf<GhostEffectEventBuffer>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 12,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 3407782589638822148uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = BufferSerializationHelper<GhostEffectEventBuffer, Snapshot, GhostEffectEventBufferGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
