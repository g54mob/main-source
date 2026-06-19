using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PugTilemap;
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
	public struct PlacementCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint canPlaceObject;

			public int bestPositionToPlaceAt_x;

			public int bestPositionToPlaceAt_y;

			public int bestPositionToPlaceAt_z;

			public uint timeSincePlaced_startTick;

			public uint timeSincePlaced_targetTicks;

			public uint timeSincePlaced_stopTick;

			public int positionLastPlacedAt_x;

			public int positionLastPlacedAt_y;

			public int positionLastPlacedAt_z;

			public int previouslyPlacedTileType;

			public int currentPrefabVariation;

			public uint placeObjectOnWall;

			public int wallSideToPlaceObject_x;

			public int wallSideToPlaceObject_y;

			public uint tilePlacementTimer_startTick;

			public uint tilePlacementTimer_targetTicks;

			public uint tilePlacementTimer_stopTick;

			public int waterSourceEntity;

			public uint waterSourceEntitySpawnTick;

			public int entityToPaint;

			public uint entityToPaintSpawnTick;

			public int tileToPaint_tileset;

			public int tileToPaint_tileType;

			public uint canPlaceGround;

			public uint canPlaceRoofHole;

			public int rotationVariationToPlace;

			public int nonRotationVariationToPlace;
		}

		private const int ChangeMaskBits = 26;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 26;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<PlacementCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<PlacementCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<PlacementCD>(component), in GhostComponentSerializer.TypeCastReadonly<PlacementCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in PlacementCD component)
		{
			snapshot.canPlaceObject = (component.canPlaceObject ? 1u : 0u);
			snapshot.bestPositionToPlaceAt_x = component.bestPositionToPlaceAt.x;
			snapshot.bestPositionToPlaceAt_y = component.bestPositionToPlaceAt.y;
			snapshot.bestPositionToPlaceAt_z = component.bestPositionToPlaceAt.z;
			snapshot.timeSincePlaced_startTick = component.timeSincePlaced.startTick.SerializedData;
			snapshot.timeSincePlaced_targetTicks = component.timeSincePlaced.targetTicks;
			snapshot.timeSincePlaced_stopTick = component.timeSincePlaced.stopTick.SerializedData;
			snapshot.positionLastPlacedAt_x = component.positionLastPlacedAt.x;
			snapshot.positionLastPlacedAt_y = component.positionLastPlacedAt.y;
			snapshot.positionLastPlacedAt_z = component.positionLastPlacedAt.z;
			snapshot.previouslyPlacedTileType = (int)component.previouslyPlacedTileType;
			snapshot.currentPrefabVariation = component.currentPrefabVariation;
			snapshot.placeObjectOnWall = (component.placeObjectOnWall ? 1u : 0u);
			snapshot.wallSideToPlaceObject_x = component.wallSideToPlaceObject.x;
			snapshot.wallSideToPlaceObject_y = component.wallSideToPlaceObject.y;
			snapshot.tilePlacementTimer_startTick = component.tilePlacementTimer.startTick.SerializedData;
			snapshot.tilePlacementTimer_targetTicks = component.tilePlacementTimer.targetTicks;
			snapshot.tilePlacementTimer_stopTick = component.tilePlacementTimer.stopTick.SerializedData;
			snapshot.waterSourceEntity = 0;
			snapshot.waterSourceEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.waterSourceEntity))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.waterSourceEntity];
				snapshot.waterSourceEntity = ghostInstance.ghostId;
				snapshot.waterSourceEntitySpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.entityToPaint = 0;
			snapshot.entityToPaintSpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.entityToPaint))
			{
				GhostInstance ghostInstance2 = serializerState.GhostFromEntity[component.entityToPaint];
				snapshot.entityToPaint = ghostInstance2.ghostId;
				snapshot.entityToPaintSpawnTick = ghostInstance2.spawnTick.SerializedData;
			}
			snapshot.tileToPaint_tileset = component.tileToPaint.tileset;
			snapshot.tileToPaint_tileType = (int)component.tileToPaint.tileType;
			snapshot.canPlaceGround = (component.canPlaceGround ? 1u : 0u);
			snapshot.canPlaceRoofHole = (component.canPlaceRoofHole ? 1u : 0u);
			snapshot.rotationVariationToPlace = component.rotationVariationToPlace;
			snapshot.nonRotationVariationToPlace = component.nonRotationVariationToPlace;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref PlacementCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.canPlaceObject = snapshotBefore.canPlaceObject != 0;
			component.bestPositionToPlaceAt.x = snapshotBefore.bestPositionToPlaceAt_x;
			component.bestPositionToPlaceAt.y = snapshotBefore.bestPositionToPlaceAt_y;
			component.bestPositionToPlaceAt.z = snapshotBefore.bestPositionToPlaceAt_z;
			component.timeSincePlaced.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.timeSincePlaced_startTick
			};
			component.timeSincePlaced.targetTicks = snapshotBefore.timeSincePlaced_targetTicks;
			component.timeSincePlaced.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.timeSincePlaced_stopTick
			};
			component.positionLastPlacedAt.x = snapshotBefore.positionLastPlacedAt_x;
			component.positionLastPlacedAt.y = snapshotBefore.positionLastPlacedAt_y;
			component.positionLastPlacedAt.z = snapshotBefore.positionLastPlacedAt_z;
			component.previouslyPlacedTileType = (TileType)snapshotBefore.previouslyPlacedTileType;
			component.currentPrefabVariation = snapshotBefore.currentPrefabVariation;
			component.placeObjectOnWall = snapshotBefore.placeObjectOnWall != 0;
			component.wallSideToPlaceObject.x = snapshotBefore.wallSideToPlaceObject_x;
			component.wallSideToPlaceObject.y = snapshotBefore.wallSideToPlaceObject_y;
			component.tilePlacementTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.tilePlacementTimer_startTick
			};
			component.tilePlacementTimer.targetTicks = snapshotBefore.tilePlacementTimer_targetTicks;
			component.tilePlacementTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.tilePlacementTimer_stopTick
			};
			component.waterSourceEntity = Entity.Null;
			if (snapshotBefore.waterSourceEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.waterSourceEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.waterSourceEntitySpawnTick
				}
			}, out var item))
			{
				component.waterSourceEntity = item;
			}
			component.entityToPaint = Entity.Null;
			if (snapshotBefore.entityToPaint != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.entityToPaint,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.entityToPaintSpawnTick
				}
			}, out var item2))
			{
				component.entityToPaint = item2;
			}
			component.tileToPaint.tileset = snapshotBefore.tileToPaint_tileset;
			component.tileToPaint.tileType = (TileType)snapshotBefore.tileToPaint_tileType;
			component.canPlaceGround = snapshotBefore.canPlaceGround != 0;
			component.canPlaceRoofHole = snapshotBefore.canPlaceRoofHole != 0;
			component.rotationVariationToPlace = snapshotBefore.rotationVariationToPlace;
			component.nonRotationVariationToPlace = snapshotBefore.nonRotationVariationToPlace;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref PlacementCD component, in PlacementCD backup)
		{
			component.canPlaceObject = backup.canPlaceObject;
			component.bestPositionToPlaceAt.x = backup.bestPositionToPlaceAt.x;
			component.bestPositionToPlaceAt.y = backup.bestPositionToPlaceAt.y;
			component.bestPositionToPlaceAt.z = backup.bestPositionToPlaceAt.z;
			component.timeSincePlaced.startTick = backup.timeSincePlaced.startTick;
			component.timeSincePlaced.targetTicks = backup.timeSincePlaced.targetTicks;
			component.timeSincePlaced.stopTick = backup.timeSincePlaced.stopTick;
			component.positionLastPlacedAt.x = backup.positionLastPlacedAt.x;
			component.positionLastPlacedAt.y = backup.positionLastPlacedAt.y;
			component.positionLastPlacedAt.z = backup.positionLastPlacedAt.z;
			component.previouslyPlacedTileType = backup.previouslyPlacedTileType;
			component.currentPrefabVariation = backup.currentPrefabVariation;
			component.placeObjectOnWall = backup.placeObjectOnWall;
			component.wallSideToPlaceObject.x = backup.wallSideToPlaceObject.x;
			component.wallSideToPlaceObject.y = backup.wallSideToPlaceObject.y;
			component.tilePlacementTimer.startTick = backup.tilePlacementTimer.startTick;
			component.tilePlacementTimer.targetTicks = backup.tilePlacementTimer.targetTicks;
			component.tilePlacementTimer.stopTick = backup.tilePlacementTimer.stopTick;
			component.waterSourceEntity = backup.waterSourceEntity;
			component.entityToPaint = backup.entityToPaint;
			component.tileToPaint.tileset = backup.tileToPaint.tileset;
			component.tileToPaint.tileType = backup.tileToPaint.tileType;
			component.canPlaceGround = backup.canPlaceGround;
			component.canPlaceRoofHole = backup.canPlaceRoofHole;
			component.rotationVariationToPlace = backup.rotationVariationToPlace;
			component.nonRotationVariationToPlace = backup.nonRotationVariationToPlace;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.canPlaceObject = (uint)predictor.PredictInt((int)snapshot.canPlaceObject, (int)baseline1.canPlaceObject, (int)baseline2.canPlaceObject);
			snapshot.bestPositionToPlaceAt_x = predictor.PredictInt(snapshot.bestPositionToPlaceAt_x, baseline1.bestPositionToPlaceAt_x, baseline2.bestPositionToPlaceAt_x);
			snapshot.bestPositionToPlaceAt_y = predictor.PredictInt(snapshot.bestPositionToPlaceAt_y, baseline1.bestPositionToPlaceAt_y, baseline2.bestPositionToPlaceAt_y);
			snapshot.bestPositionToPlaceAt_z = predictor.PredictInt(snapshot.bestPositionToPlaceAt_z, baseline1.bestPositionToPlaceAt_z, baseline2.bestPositionToPlaceAt_z);
			snapshot.timeSincePlaced_startTick = (uint)predictor.PredictInt((int)snapshot.timeSincePlaced_startTick, (int)baseline1.timeSincePlaced_startTick, (int)baseline2.timeSincePlaced_startTick);
			snapshot.timeSincePlaced_targetTicks = (uint)predictor.PredictInt((int)snapshot.timeSincePlaced_targetTicks, (int)baseline1.timeSincePlaced_targetTicks, (int)baseline2.timeSincePlaced_targetTicks);
			snapshot.timeSincePlaced_stopTick = (uint)predictor.PredictInt((int)snapshot.timeSincePlaced_stopTick, (int)baseline1.timeSincePlaced_stopTick, (int)baseline2.timeSincePlaced_stopTick);
			snapshot.positionLastPlacedAt_x = predictor.PredictInt(snapshot.positionLastPlacedAt_x, baseline1.positionLastPlacedAt_x, baseline2.positionLastPlacedAt_x);
			snapshot.positionLastPlacedAt_y = predictor.PredictInt(snapshot.positionLastPlacedAt_y, baseline1.positionLastPlacedAt_y, baseline2.positionLastPlacedAt_y);
			snapshot.positionLastPlacedAt_z = predictor.PredictInt(snapshot.positionLastPlacedAt_z, baseline1.positionLastPlacedAt_z, baseline2.positionLastPlacedAt_z);
			snapshot.previouslyPlacedTileType = predictor.PredictInt(snapshot.previouslyPlacedTileType, baseline1.previouslyPlacedTileType, baseline2.previouslyPlacedTileType);
			snapshot.currentPrefabVariation = predictor.PredictInt(snapshot.currentPrefabVariation, baseline1.currentPrefabVariation, baseline2.currentPrefabVariation);
			snapshot.placeObjectOnWall = (uint)predictor.PredictInt((int)snapshot.placeObjectOnWall, (int)baseline1.placeObjectOnWall, (int)baseline2.placeObjectOnWall);
			snapshot.wallSideToPlaceObject_x = predictor.PredictInt(snapshot.wallSideToPlaceObject_x, baseline1.wallSideToPlaceObject_x, baseline2.wallSideToPlaceObject_x);
			snapshot.wallSideToPlaceObject_y = predictor.PredictInt(snapshot.wallSideToPlaceObject_y, baseline1.wallSideToPlaceObject_y, baseline2.wallSideToPlaceObject_y);
			snapshot.tilePlacementTimer_startTick = (uint)predictor.PredictInt((int)snapshot.tilePlacementTimer_startTick, (int)baseline1.tilePlacementTimer_startTick, (int)baseline2.tilePlacementTimer_startTick);
			snapshot.tilePlacementTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.tilePlacementTimer_targetTicks, (int)baseline1.tilePlacementTimer_targetTicks, (int)baseline2.tilePlacementTimer_targetTicks);
			snapshot.tilePlacementTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.tilePlacementTimer_stopTick, (int)baseline1.tilePlacementTimer_stopTick, (int)baseline2.tilePlacementTimer_stopTick);
			snapshot.waterSourceEntity = predictor.PredictInt(snapshot.waterSourceEntity, baseline1.waterSourceEntity, baseline2.waterSourceEntity);
			snapshot.waterSourceEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.waterSourceEntitySpawnTick, (int)baseline1.waterSourceEntitySpawnTick, baseline2.waterSourceEntity);
			snapshot.entityToPaint = predictor.PredictInt(snapshot.entityToPaint, baseline1.entityToPaint, baseline2.entityToPaint);
			snapshot.entityToPaintSpawnTick = (uint)predictor.PredictInt((int)snapshot.entityToPaintSpawnTick, (int)baseline1.entityToPaintSpawnTick, baseline2.entityToPaint);
			snapshot.tileToPaint_tileset = predictor.PredictInt(snapshot.tileToPaint_tileset, baseline1.tileToPaint_tileset, baseline2.tileToPaint_tileset);
			snapshot.tileToPaint_tileType = predictor.PredictInt(snapshot.tileToPaint_tileType, baseline1.tileToPaint_tileType, baseline2.tileToPaint_tileType);
			snapshot.canPlaceGround = (uint)predictor.PredictInt((int)snapshot.canPlaceGround, (int)baseline1.canPlaceGround, (int)baseline2.canPlaceGround);
			snapshot.canPlaceRoofHole = (uint)predictor.PredictInt((int)snapshot.canPlaceRoofHole, (int)baseline1.canPlaceRoofHole, (int)baseline2.canPlaceRoofHole);
			snapshot.rotationVariationToPlace = predictor.PredictInt(snapshot.rotationVariationToPlace, baseline1.rotationVariationToPlace, baseline2.rotationVariationToPlace);
			snapshot.nonRotationVariationToPlace = predictor.PredictInt(snapshot.nonRotationVariationToPlace, baseline1.nonRotationVariationToPlace, baseline2.nonRotationVariationToPlace);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.canPlaceObject != baseline.canPlaceObject) ? 1u : 0u);
			num |= (uint)((snapshot.bestPositionToPlaceAt_x != baseline.bestPositionToPlaceAt_x) ? 2 : 0);
			num |= (uint)((snapshot.bestPositionToPlaceAt_y != baseline.bestPositionToPlaceAt_y) ? 4 : 0);
			num |= (uint)((snapshot.bestPositionToPlaceAt_z != baseline.bestPositionToPlaceAt_z) ? 8 : 0);
			num |= (uint)((snapshot.timeSincePlaced_startTick != baseline.timeSincePlaced_startTick) ? 16 : 0);
			num |= (uint)((snapshot.timeSincePlaced_targetTicks != baseline.timeSincePlaced_targetTicks) ? 32 : 0);
			num |= (uint)((snapshot.timeSincePlaced_stopTick != baseline.timeSincePlaced_stopTick) ? 64 : 0);
			num |= (uint)((snapshot.positionLastPlacedAt_x != baseline.positionLastPlacedAt_x) ? 128 : 0);
			num |= (uint)((snapshot.positionLastPlacedAt_y != baseline.positionLastPlacedAt_y) ? 256 : 0);
			num |= (uint)((snapshot.positionLastPlacedAt_z != baseline.positionLastPlacedAt_z) ? 512 : 0);
			num |= (uint)((snapshot.previouslyPlacedTileType != baseline.previouslyPlacedTileType) ? 1024 : 0);
			num |= (uint)((snapshot.currentPrefabVariation != baseline.currentPrefabVariation) ? 2048 : 0);
			num |= (uint)((snapshot.placeObjectOnWall != baseline.placeObjectOnWall) ? 4096 : 0);
			num |= (uint)((snapshot.wallSideToPlaceObject_x != baseline.wallSideToPlaceObject_x) ? 8192 : 0);
			num |= (uint)((snapshot.wallSideToPlaceObject_y != baseline.wallSideToPlaceObject_y) ? 16384 : 0);
			num |= (uint)((snapshot.tilePlacementTimer_startTick != baseline.tilePlacementTimer_startTick) ? 32768 : 0);
			num |= (uint)((snapshot.tilePlacementTimer_targetTicks != baseline.tilePlacementTimer_targetTicks) ? 65536 : 0);
			num |= (uint)((snapshot.tilePlacementTimer_stopTick != baseline.tilePlacementTimer_stopTick) ? 131072 : 0);
			num |= (uint)((snapshot.waterSourceEntity != baseline.waterSourceEntity || snapshot.waterSourceEntitySpawnTick != baseline.waterSourceEntitySpawnTick) ? 262144 : 0);
			num |= (uint)((snapshot.entityToPaint != baseline.entityToPaint || snapshot.entityToPaintSpawnTick != baseline.entityToPaintSpawnTick) ? 524288 : 0);
			num |= (uint)((snapshot.tileToPaint_tileset != baseline.tileToPaint_tileset) ? 1048576 : 0);
			num |= (uint)((snapshot.tileToPaint_tileType != baseline.tileToPaint_tileType) ? 2097152 : 0);
			num |= (uint)((snapshot.canPlaceGround != baseline.canPlaceGround) ? 4194304 : 0);
			num |= (uint)((snapshot.canPlaceRoofHole != baseline.canPlaceRoofHole) ? 8388608 : 0);
			num |= (uint)((snapshot.rotationVariationToPlace != baseline.rotationVariationToPlace) ? 16777216 : 0);
			num |= (uint)((snapshot.nonRotationVariationToPlace != baseline.nonRotationVariationToPlace) ? 33554432 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 26);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 26);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.canPlaceObject, baseline.canPlaceObject, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_x, baseline.bestPositionToPlaceAt_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_y, baseline.bestPositionToPlaceAt_y, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_z, baseline.bestPositionToPlaceAt_z, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSincePlaced_startTick, baseline.timeSincePlaced_startTick, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSincePlaced_targetTicks, baseline.timeSincePlaced_targetTicks, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSincePlaced_stopTick, baseline.timeSincePlaced_stopTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.positionLastPlacedAt_x, baseline.positionLastPlacedAt_x, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.positionLastPlacedAt_y, baseline.positionLastPlacedAt_y, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.positionLastPlacedAt_z, baseline.positionLastPlacedAt_z, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.previouslyPlacedTileType, baseline.previouslyPlacedTileType, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedIntDelta(snapshot.currentPrefabVariation, baseline.currentPrefabVariation, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeObjectOnWall, baseline.placeObjectOnWall, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.wallSideToPlaceObject_x, baseline.wallSideToPlaceObject_x, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.wallSideToPlaceObject_y, baseline.wallSideToPlaceObject_y, in compressionModel);
			}
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tilePlacementTimer_startTick, baseline.tilePlacementTimer_startTick, in compressionModel);
			}
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tilePlacementTimer_targetTicks, baseline.tilePlacementTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tilePlacementTimer_stopTick, baseline.tilePlacementTimer_stopTick, in compressionModel);
			}
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.waterSourceEntity, baseline.waterSourceEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.waterSourceEntitySpawnTick, baseline.waterSourceEntitySpawnTick, in compressionModel);
			}
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.entityToPaint, baseline.entityToPaint, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.entityToPaintSpawnTick, baseline.entityToPaintSpawnTick, in compressionModel);
			}
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileToPaint_tileset, baseline.tileToPaint_tileset, in compressionModel);
			}
			if ((num & 0x200000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileToPaint_tileType, baseline.tileToPaint_tileType, in compressionModel);
			}
			if ((num & 0x400000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.canPlaceGround, baseline.canPlaceGround, in compressionModel);
			}
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.canPlaceRoofHole, baseline.canPlaceRoofHole, in compressionModel);
			}
			if ((num & 0x1000000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.rotationVariationToPlace, baseline.rotationVariationToPlace, in compressionModel);
			}
			if ((num & 0x2000000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.nonRotationVariationToPlace, baseline.nonRotationVariationToPlace, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.canPlaceObject != baseline.canPlaceObject) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.canPlaceObject, baseline.canPlaceObject, in compressionModel);
			}
			num |= (uint)((snapshot.bestPositionToPlaceAt_x != baseline.bestPositionToPlaceAt_x) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_x, baseline.bestPositionToPlaceAt_x, in compressionModel);
			}
			num |= (uint)((snapshot.bestPositionToPlaceAt_y != baseline.bestPositionToPlaceAt_y) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_y, baseline.bestPositionToPlaceAt_y, in compressionModel);
			}
			num |= (uint)((snapshot.bestPositionToPlaceAt_z != baseline.bestPositionToPlaceAt_z) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_z, baseline.bestPositionToPlaceAt_z, in compressionModel);
			}
			num |= (uint)((snapshot.timeSincePlaced_startTick != baseline.timeSincePlaced_startTick) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSincePlaced_startTick, baseline.timeSincePlaced_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.timeSincePlaced_targetTicks != baseline.timeSincePlaced_targetTicks) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSincePlaced_targetTicks, baseline.timeSincePlaced_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.timeSincePlaced_stopTick != baseline.timeSincePlaced_stopTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timeSincePlaced_stopTick, baseline.timeSincePlaced_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.positionLastPlacedAt_x != baseline.positionLastPlacedAt_x) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.positionLastPlacedAt_x, baseline.positionLastPlacedAt_x, in compressionModel);
			}
			num |= (uint)((snapshot.positionLastPlacedAt_y != baseline.positionLastPlacedAt_y) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.positionLastPlacedAt_y, baseline.positionLastPlacedAt_y, in compressionModel);
			}
			num |= (uint)((snapshot.positionLastPlacedAt_z != baseline.positionLastPlacedAt_z) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.positionLastPlacedAt_z, baseline.positionLastPlacedAt_z, in compressionModel);
			}
			num |= (uint)((snapshot.previouslyPlacedTileType != baseline.previouslyPlacedTileType) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.previouslyPlacedTileType, baseline.previouslyPlacedTileType, in compressionModel);
			}
			num |= (uint)((snapshot.currentPrefabVariation != baseline.currentPrefabVariation) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedIntDelta(snapshot.currentPrefabVariation, baseline.currentPrefabVariation, in compressionModel);
			}
			num |= (uint)((snapshot.placeObjectOnWall != baseline.placeObjectOnWall) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeObjectOnWall, baseline.placeObjectOnWall, in compressionModel);
			}
			num |= (uint)((snapshot.wallSideToPlaceObject_x != baseline.wallSideToPlaceObject_x) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.wallSideToPlaceObject_x, baseline.wallSideToPlaceObject_x, in compressionModel);
			}
			num |= (uint)((snapshot.wallSideToPlaceObject_y != baseline.wallSideToPlaceObject_y) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.wallSideToPlaceObject_y, baseline.wallSideToPlaceObject_y, in compressionModel);
			}
			num |= (uint)((snapshot.tilePlacementTimer_startTick != baseline.tilePlacementTimer_startTick) ? 32768 : 0);
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tilePlacementTimer_startTick, baseline.tilePlacementTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.tilePlacementTimer_targetTicks != baseline.tilePlacementTimer_targetTicks) ? 65536 : 0);
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tilePlacementTimer_targetTicks, baseline.tilePlacementTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.tilePlacementTimer_stopTick != baseline.tilePlacementTimer_stopTick) ? 131072 : 0);
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tilePlacementTimer_stopTick, baseline.tilePlacementTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.waterSourceEntity != baseline.waterSourceEntity || snapshot.waterSourceEntitySpawnTick != baseline.waterSourceEntitySpawnTick) ? 262144 : 0);
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.waterSourceEntity, baseline.waterSourceEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.waterSourceEntitySpawnTick, baseline.waterSourceEntitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.entityToPaint != baseline.entityToPaint || snapshot.entityToPaintSpawnTick != baseline.entityToPaintSpawnTick) ? 524288 : 0);
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.entityToPaint, baseline.entityToPaint, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.entityToPaintSpawnTick, baseline.entityToPaintSpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.tileToPaint_tileset != baseline.tileToPaint_tileset) ? 1048576 : 0);
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileToPaint_tileset, baseline.tileToPaint_tileset, in compressionModel);
			}
			num |= (uint)((snapshot.tileToPaint_tileType != baseline.tileToPaint_tileType) ? 2097152 : 0);
			if ((num & 0x200000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileToPaint_tileType, baseline.tileToPaint_tileType, in compressionModel);
			}
			num |= (uint)((snapshot.canPlaceGround != baseline.canPlaceGround) ? 4194304 : 0);
			if ((num & 0x400000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.canPlaceGround, baseline.canPlaceGround, in compressionModel);
			}
			num |= (uint)((snapshot.canPlaceRoofHole != baseline.canPlaceRoofHole) ? 8388608 : 0);
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.canPlaceRoofHole, baseline.canPlaceRoofHole, in compressionModel);
			}
			num |= (uint)((snapshot.rotationVariationToPlace != baseline.rotationVariationToPlace) ? 16777216 : 0);
			if ((num & 0x1000000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.rotationVariationToPlace, baseline.rotationVariationToPlace, in compressionModel);
			}
			num |= (uint)((snapshot.nonRotationVariationToPlace != baseline.nonRotationVariationToPlace) ? 33554432 : 0);
			if ((num & 0x2000000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.nonRotationVariationToPlace, baseline.nonRotationVariationToPlace, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 26);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 26);
			if ((num & 1) != 0)
			{
				snapshot.canPlaceObject = reader.ReadPackedUIntDelta(baseline.canPlaceObject, in compressionModel);
			}
			else
			{
				snapshot.canPlaceObject = baseline.canPlaceObject;
			}
			if ((num & 2) != 0)
			{
				snapshot.bestPositionToPlaceAt_x = reader.ReadPackedIntDelta(baseline.bestPositionToPlaceAt_x, in compressionModel);
			}
			else
			{
				snapshot.bestPositionToPlaceAt_x = baseline.bestPositionToPlaceAt_x;
			}
			if ((num & 4) != 0)
			{
				snapshot.bestPositionToPlaceAt_y = reader.ReadPackedIntDelta(baseline.bestPositionToPlaceAt_y, in compressionModel);
			}
			else
			{
				snapshot.bestPositionToPlaceAt_y = baseline.bestPositionToPlaceAt_y;
			}
			if ((num & 8) != 0)
			{
				snapshot.bestPositionToPlaceAt_z = reader.ReadPackedIntDelta(baseline.bestPositionToPlaceAt_z, in compressionModel);
			}
			else
			{
				snapshot.bestPositionToPlaceAt_z = baseline.bestPositionToPlaceAt_z;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.timeSincePlaced_startTick = reader.ReadPackedUIntDelta(baseline.timeSincePlaced_startTick, in compressionModel);
			}
			else
			{
				snapshot.timeSincePlaced_startTick = baseline.timeSincePlaced_startTick;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.timeSincePlaced_targetTicks = reader.ReadPackedUIntDelta(baseline.timeSincePlaced_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.timeSincePlaced_targetTicks = baseline.timeSincePlaced_targetTicks;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.timeSincePlaced_stopTick = reader.ReadPackedUIntDelta(baseline.timeSincePlaced_stopTick, in compressionModel);
			}
			else
			{
				snapshot.timeSincePlaced_stopTick = baseline.timeSincePlaced_stopTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.positionLastPlacedAt_x = reader.ReadPackedIntDelta(baseline.positionLastPlacedAt_x, in compressionModel);
			}
			else
			{
				snapshot.positionLastPlacedAt_x = baseline.positionLastPlacedAt_x;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.positionLastPlacedAt_y = reader.ReadPackedIntDelta(baseline.positionLastPlacedAt_y, in compressionModel);
			}
			else
			{
				snapshot.positionLastPlacedAt_y = baseline.positionLastPlacedAt_y;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.positionLastPlacedAt_z = reader.ReadPackedIntDelta(baseline.positionLastPlacedAt_z, in compressionModel);
			}
			else
			{
				snapshot.positionLastPlacedAt_z = baseline.positionLastPlacedAt_z;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.previouslyPlacedTileType = reader.ReadPackedIntDelta(baseline.previouslyPlacedTileType, in compressionModel);
			}
			else
			{
				snapshot.previouslyPlacedTileType = baseline.previouslyPlacedTileType;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.currentPrefabVariation = reader.ReadPackedIntDelta(baseline.currentPrefabVariation, in compressionModel);
			}
			else
			{
				snapshot.currentPrefabVariation = baseline.currentPrefabVariation;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.placeObjectOnWall = reader.ReadPackedUIntDelta(baseline.placeObjectOnWall, in compressionModel);
			}
			else
			{
				snapshot.placeObjectOnWall = baseline.placeObjectOnWall;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.wallSideToPlaceObject_x = reader.ReadPackedIntDelta(baseline.wallSideToPlaceObject_x, in compressionModel);
			}
			else
			{
				snapshot.wallSideToPlaceObject_x = baseline.wallSideToPlaceObject_x;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.wallSideToPlaceObject_y = reader.ReadPackedIntDelta(baseline.wallSideToPlaceObject_y, in compressionModel);
			}
			else
			{
				snapshot.wallSideToPlaceObject_y = baseline.wallSideToPlaceObject_y;
			}
			if ((num & 0x8000) != 0)
			{
				snapshot.tilePlacementTimer_startTick = reader.ReadPackedUIntDelta(baseline.tilePlacementTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.tilePlacementTimer_startTick = baseline.tilePlacementTimer_startTick;
			}
			if ((num & 0x10000) != 0)
			{
				snapshot.tilePlacementTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.tilePlacementTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.tilePlacementTimer_targetTicks = baseline.tilePlacementTimer_targetTicks;
			}
			if ((num & 0x20000) != 0)
			{
				snapshot.tilePlacementTimer_stopTick = reader.ReadPackedUIntDelta(baseline.tilePlacementTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.tilePlacementTimer_stopTick = baseline.tilePlacementTimer_stopTick;
			}
			if ((num & 0x40000) != 0)
			{
				snapshot.waterSourceEntity = reader.ReadPackedIntDelta(baseline.waterSourceEntity, in compressionModel);
				snapshot.waterSourceEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.waterSourceEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.waterSourceEntity = baseline.waterSourceEntity;
				snapshot.waterSourceEntitySpawnTick = baseline.waterSourceEntitySpawnTick;
			}
			if ((num & 0x80000) != 0)
			{
				snapshot.entityToPaint = reader.ReadPackedIntDelta(baseline.entityToPaint, in compressionModel);
				snapshot.entityToPaintSpawnTick = reader.ReadPackedUIntDelta(baseline.entityToPaintSpawnTick, in compressionModel);
			}
			else
			{
				snapshot.entityToPaint = baseline.entityToPaint;
				snapshot.entityToPaintSpawnTick = baseline.entityToPaintSpawnTick;
			}
			if ((num & 0x100000) != 0)
			{
				snapshot.tileToPaint_tileset = reader.ReadPackedIntDelta(baseline.tileToPaint_tileset, in compressionModel);
			}
			else
			{
				snapshot.tileToPaint_tileset = baseline.tileToPaint_tileset;
			}
			if ((num & 0x200000) != 0)
			{
				snapshot.tileToPaint_tileType = reader.ReadPackedIntDelta(baseline.tileToPaint_tileType, in compressionModel);
			}
			else
			{
				snapshot.tileToPaint_tileType = baseline.tileToPaint_tileType;
			}
			if ((num & 0x400000) != 0)
			{
				snapshot.canPlaceGround = reader.ReadPackedUIntDelta(baseline.canPlaceGround, in compressionModel);
			}
			else
			{
				snapshot.canPlaceGround = baseline.canPlaceGround;
			}
			if ((num & 0x800000) != 0)
			{
				snapshot.canPlaceRoofHole = reader.ReadPackedUIntDelta(baseline.canPlaceRoofHole, in compressionModel);
			}
			else
			{
				snapshot.canPlaceRoofHole = baseline.canPlaceRoofHole;
			}
			if ((num & 0x1000000) != 0)
			{
				snapshot.rotationVariationToPlace = reader.ReadPackedIntDelta(baseline.rotationVariationToPlace, in compressionModel);
			}
			else
			{
				snapshot.rotationVariationToPlace = baseline.rotationVariationToPlace;
			}
			if ((num & 0x2000000) != 0)
			{
				snapshot.nonRotationVariationToPlace = reader.ReadPackedIntDelta(baseline.nonRotationVariationToPlace, in compressionModel);
			}
			else
			{
				snapshot.nonRotationVariationToPlace = baseline.nonRotationVariationToPlace;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 4328909510700619324uL,
					ComponentType = ComponentType.ReadWrite<PlacementCD>(),
					ComponentSize = UnsafeUtility.SizeOf<PlacementCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 26,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 17955917204926978876uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<PlacementCD, Snapshot, PlacementCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
