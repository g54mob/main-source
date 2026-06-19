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
	public struct InitialHealthChangeGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int healthChange_entity;

			public uint healthChange_entitySpawnTick;

			public int healthChange_causedByEntity;

			public uint healthChange_causedByEntitySpawnTick;

			public float healthChange_optionalPositionToDropLootWhenDamaged_x;

			public float healthChange_optionalPositionToDropLootWhenDamaged_y;

			public int healthChange_amount;

			public uint healthChange_bypassMaxDamagePerHit;

			public uint healthChange_skipWallAndRootsLootDropOnDestroy;

			public uint healthChange_skipLootDropOnDestroy;

			public uint healthChange_skipLootDropIfDestroyPlants;

			public uint healthChange_wasKnockedBack;

			public uint healthChange_bypassDamageReduction;

			public uint healthChange_pullLootToPlayer;

			public uint healthChange_wasKilled;

			public uint healthChange_damagedByExplosion;

			public uint healthChange_applyToNonPredicted;
		}

		private const int ChangeMaskBits = 14;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 14;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<InitialHealthChange>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<InitialHealthChange>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<InitialHealthChange>(component), in GhostComponentSerializer.TypeCastReadonly<InitialHealthChange>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in InitialHealthChange component)
		{
			snapshot.healthChange_entity = 0;
			snapshot.healthChange_entitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.healthChange.entity))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.healthChange.entity];
				snapshot.healthChange_entity = ghostInstance.ghostId;
				snapshot.healthChange_entitySpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.healthChange_causedByEntity = 0;
			snapshot.healthChange_causedByEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.healthChange.causedByEntity))
			{
				GhostInstance ghostInstance2 = serializerState.GhostFromEntity[component.healthChange.causedByEntity];
				snapshot.healthChange_causedByEntity = ghostInstance2.ghostId;
				snapshot.healthChange_causedByEntitySpawnTick = ghostInstance2.spawnTick.SerializedData;
			}
			snapshot.healthChange_optionalPositionToDropLootWhenDamaged_x = component.healthChange.optionalPositionToDropLootWhenDamaged.x;
			snapshot.healthChange_optionalPositionToDropLootWhenDamaged_y = component.healthChange.optionalPositionToDropLootWhenDamaged.y;
			snapshot.healthChange_amount = component.healthChange.amount;
			snapshot.healthChange_bypassMaxDamagePerHit = (component.healthChange.bypassMaxDamagePerHit ? 1u : 0u);
			snapshot.healthChange_skipWallAndRootsLootDropOnDestroy = (component.healthChange.skipWallAndRootsLootDropOnDestroy ? 1u : 0u);
			snapshot.healthChange_skipLootDropOnDestroy = (component.healthChange.skipLootDropOnDestroy ? 1u : 0u);
			snapshot.healthChange_skipLootDropIfDestroyPlants = (component.healthChange.skipLootDropIfDestroyPlants ? 1u : 0u);
			snapshot.healthChange_wasKnockedBack = (component.healthChange.wasKnockedBack ? 1u : 0u);
			snapshot.healthChange_bypassDamageReduction = (component.healthChange.bypassDamageReduction ? 1u : 0u);
			snapshot.healthChange_pullLootToPlayer = (component.healthChange.pullLootToPlayer ? 1u : 0u);
			snapshot.healthChange_wasKilled = (component.healthChange.wasKilled ? 1u : 0u);
			snapshot.healthChange_damagedByExplosion = (component.healthChange.damagedByExplosion ? 1u : 0u);
			snapshot.healthChange_applyToNonPredicted = (component.healthChange.applyToNonPredicted ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref InitialHealthChange component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.healthChange.entity = Entity.Null;
			if (snapshotBefore.healthChange_entity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.healthChange_entity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.healthChange_entitySpawnTick
				}
			}, out var item))
			{
				component.healthChange.entity = item;
			}
			component.healthChange.causedByEntity = Entity.Null;
			if (snapshotBefore.healthChange_causedByEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.healthChange_causedByEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.healthChange_causedByEntitySpawnTick
				}
			}, out var item2))
			{
				component.healthChange.causedByEntity = item2;
			}
			component.healthChange.optionalPositionToDropLootWhenDamaged = new float2(snapshotBefore.healthChange_optionalPositionToDropLootWhenDamaged_x, snapshotBefore.healthChange_optionalPositionToDropLootWhenDamaged_y);
			component.healthChange.amount = snapshotBefore.healthChange_amount;
			component.healthChange.bypassMaxDamagePerHit = snapshotBefore.healthChange_bypassMaxDamagePerHit != 0;
			component.healthChange.skipWallAndRootsLootDropOnDestroy = snapshotBefore.healthChange_skipWallAndRootsLootDropOnDestroy != 0;
			component.healthChange.skipLootDropOnDestroy = snapshotBefore.healthChange_skipLootDropOnDestroy != 0;
			component.healthChange.skipLootDropIfDestroyPlants = snapshotBefore.healthChange_skipLootDropIfDestroyPlants != 0;
			component.healthChange.wasKnockedBack = snapshotBefore.healthChange_wasKnockedBack != 0;
			component.healthChange.bypassDamageReduction = snapshotBefore.healthChange_bypassDamageReduction != 0;
			component.healthChange.pullLootToPlayer = snapshotBefore.healthChange_pullLootToPlayer != 0;
			component.healthChange.wasKilled = snapshotBefore.healthChange_wasKilled != 0;
			component.healthChange.damagedByExplosion = snapshotBefore.healthChange_damagedByExplosion != 0;
			component.healthChange.applyToNonPredicted = snapshotBefore.healthChange_applyToNonPredicted != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref InitialHealthChange component, in InitialHealthChange backup)
		{
			component.healthChange.entity = backup.healthChange.entity;
			component.healthChange.causedByEntity = backup.healthChange.causedByEntity;
			component.healthChange.optionalPositionToDropLootWhenDamaged.x = backup.healthChange.optionalPositionToDropLootWhenDamaged.x;
			component.healthChange.optionalPositionToDropLootWhenDamaged.y = backup.healthChange.optionalPositionToDropLootWhenDamaged.y;
			component.healthChange.amount = backup.healthChange.amount;
			component.healthChange.bypassMaxDamagePerHit = backup.healthChange.bypassMaxDamagePerHit;
			component.healthChange.skipWallAndRootsLootDropOnDestroy = backup.healthChange.skipWallAndRootsLootDropOnDestroy;
			component.healthChange.skipLootDropOnDestroy = backup.healthChange.skipLootDropOnDestroy;
			component.healthChange.skipLootDropIfDestroyPlants = backup.healthChange.skipLootDropIfDestroyPlants;
			component.healthChange.wasKnockedBack = backup.healthChange.wasKnockedBack;
			component.healthChange.bypassDamageReduction = backup.healthChange.bypassDamageReduction;
			component.healthChange.pullLootToPlayer = backup.healthChange.pullLootToPlayer;
			component.healthChange.wasKilled = backup.healthChange.wasKilled;
			component.healthChange.damagedByExplosion = backup.healthChange.damagedByExplosion;
			component.healthChange.applyToNonPredicted = backup.healthChange.applyToNonPredicted;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.healthChange_entity = predictor.PredictInt(snapshot.healthChange_entity, baseline1.healthChange_entity, baseline2.healthChange_entity);
			snapshot.healthChange_entitySpawnTick = (uint)predictor.PredictInt((int)snapshot.healthChange_entitySpawnTick, (int)baseline1.healthChange_entitySpawnTick, baseline2.healthChange_entity);
			snapshot.healthChange_causedByEntity = predictor.PredictInt(snapshot.healthChange_causedByEntity, baseline1.healthChange_causedByEntity, baseline2.healthChange_causedByEntity);
			snapshot.healthChange_causedByEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.healthChange_causedByEntitySpawnTick, (int)baseline1.healthChange_causedByEntitySpawnTick, baseline2.healthChange_causedByEntity);
			snapshot.healthChange_amount = predictor.PredictInt(snapshot.healthChange_amount, baseline1.healthChange_amount, baseline2.healthChange_amount);
			snapshot.healthChange_bypassMaxDamagePerHit = (uint)predictor.PredictInt((int)snapshot.healthChange_bypassMaxDamagePerHit, (int)baseline1.healthChange_bypassMaxDamagePerHit, (int)baseline2.healthChange_bypassMaxDamagePerHit);
			snapshot.healthChange_skipWallAndRootsLootDropOnDestroy = (uint)predictor.PredictInt((int)snapshot.healthChange_skipWallAndRootsLootDropOnDestroy, (int)baseline1.healthChange_skipWallAndRootsLootDropOnDestroy, (int)baseline2.healthChange_skipWallAndRootsLootDropOnDestroy);
			snapshot.healthChange_skipLootDropOnDestroy = (uint)predictor.PredictInt((int)snapshot.healthChange_skipLootDropOnDestroy, (int)baseline1.healthChange_skipLootDropOnDestroy, (int)baseline2.healthChange_skipLootDropOnDestroy);
			snapshot.healthChange_skipLootDropIfDestroyPlants = (uint)predictor.PredictInt((int)snapshot.healthChange_skipLootDropIfDestroyPlants, (int)baseline1.healthChange_skipLootDropIfDestroyPlants, (int)baseline2.healthChange_skipLootDropIfDestroyPlants);
			snapshot.healthChange_wasKnockedBack = (uint)predictor.PredictInt((int)snapshot.healthChange_wasKnockedBack, (int)baseline1.healthChange_wasKnockedBack, (int)baseline2.healthChange_wasKnockedBack);
			snapshot.healthChange_bypassDamageReduction = (uint)predictor.PredictInt((int)snapshot.healthChange_bypassDamageReduction, (int)baseline1.healthChange_bypassDamageReduction, (int)baseline2.healthChange_bypassDamageReduction);
			snapshot.healthChange_pullLootToPlayer = (uint)predictor.PredictInt((int)snapshot.healthChange_pullLootToPlayer, (int)baseline1.healthChange_pullLootToPlayer, (int)baseline2.healthChange_pullLootToPlayer);
			snapshot.healthChange_wasKilled = (uint)predictor.PredictInt((int)snapshot.healthChange_wasKilled, (int)baseline1.healthChange_wasKilled, (int)baseline2.healthChange_wasKilled);
			snapshot.healthChange_damagedByExplosion = (uint)predictor.PredictInt((int)snapshot.healthChange_damagedByExplosion, (int)baseline1.healthChange_damagedByExplosion, (int)baseline2.healthChange_damagedByExplosion);
			snapshot.healthChange_applyToNonPredicted = (uint)predictor.PredictInt((int)snapshot.healthChange_applyToNonPredicted, (int)baseline1.healthChange_applyToNonPredicted, (int)baseline2.healthChange_applyToNonPredicted);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.healthChange_entity != baseline.healthChange_entity || snapshot.healthChange_entitySpawnTick != baseline.healthChange_entitySpawnTick) ? 1u : 0u);
			num |= (uint)((snapshot.healthChange_causedByEntity != baseline.healthChange_causedByEntity || snapshot.healthChange_causedByEntitySpawnTick != baseline.healthChange_causedByEntitySpawnTick) ? 2 : 0);
			num |= (uint)((snapshot.healthChange_optionalPositionToDropLootWhenDamaged_x != baseline.healthChange_optionalPositionToDropLootWhenDamaged_x) ? 4 : 0);
			num |= (uint)((snapshot.healthChange_optionalPositionToDropLootWhenDamaged_y != baseline.healthChange_optionalPositionToDropLootWhenDamaged_y) ? 4 : 0);
			num |= (uint)((snapshot.healthChange_amount != baseline.healthChange_amount) ? 8 : 0);
			num |= (uint)((snapshot.healthChange_bypassMaxDamagePerHit != baseline.healthChange_bypassMaxDamagePerHit) ? 16 : 0);
			num |= (uint)((snapshot.healthChange_skipWallAndRootsLootDropOnDestroy != baseline.healthChange_skipWallAndRootsLootDropOnDestroy) ? 32 : 0);
			num |= (uint)((snapshot.healthChange_skipLootDropOnDestroy != baseline.healthChange_skipLootDropOnDestroy) ? 64 : 0);
			num |= (uint)((snapshot.healthChange_skipLootDropIfDestroyPlants != baseline.healthChange_skipLootDropIfDestroyPlants) ? 128 : 0);
			num |= (uint)((snapshot.healthChange_wasKnockedBack != baseline.healthChange_wasKnockedBack) ? 256 : 0);
			num |= (uint)((snapshot.healthChange_bypassDamageReduction != baseline.healthChange_bypassDamageReduction) ? 512 : 0);
			num |= (uint)((snapshot.healthChange_pullLootToPlayer != baseline.healthChange_pullLootToPlayer) ? 1024 : 0);
			num |= (uint)((snapshot.healthChange_wasKilled != baseline.healthChange_wasKilled) ? 2048 : 0);
			num |= (uint)((snapshot.healthChange_damagedByExplosion != baseline.healthChange_damagedByExplosion) ? 4096 : 0);
			num |= (uint)((snapshot.healthChange_applyToNonPredicted != baseline.healthChange_applyToNonPredicted) ? 8192 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 14);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 14);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.healthChange_entity, baseline.healthChange_entity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.healthChange_entitySpawnTick, baseline.healthChange_entitySpawnTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.healthChange_causedByEntity, baseline.healthChange_causedByEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.healthChange_causedByEntitySpawnTick, baseline.healthChange_causedByEntitySpawnTick, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.healthChange_optionalPositionToDropLootWhenDamaged_x, baseline.healthChange_optionalPositionToDropLootWhenDamaged_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.healthChange_optionalPositionToDropLootWhenDamaged_y, baseline.healthChange_optionalPositionToDropLootWhenDamaged_y, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.healthChange_amount, baseline.healthChange_amount, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_bypassMaxDamagePerHit, baseline.healthChange_bypassMaxDamagePerHit, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_skipWallAndRootsLootDropOnDestroy, baseline.healthChange_skipWallAndRootsLootDropOnDestroy, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_skipLootDropOnDestroy, baseline.healthChange_skipLootDropOnDestroy, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_skipLootDropIfDestroyPlants, baseline.healthChange_skipLootDropIfDestroyPlants, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_wasKnockedBack, baseline.healthChange_wasKnockedBack, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_bypassDamageReduction, baseline.healthChange_bypassDamageReduction, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_pullLootToPlayer, baseline.healthChange_pullLootToPlayer, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_wasKilled, baseline.healthChange_wasKilled, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_damagedByExplosion, baseline.healthChange_damagedByExplosion, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_applyToNonPredicted, baseline.healthChange_applyToNonPredicted, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.healthChange_entity != baseline.healthChange_entity || snapshot.healthChange_entitySpawnTick != baseline.healthChange_entitySpawnTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.healthChange_entity, baseline.healthChange_entity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.healthChange_entitySpawnTick, baseline.healthChange_entitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_causedByEntity != baseline.healthChange_causedByEntity || snapshot.healthChange_causedByEntitySpawnTick != baseline.healthChange_causedByEntitySpawnTick) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.healthChange_causedByEntity, baseline.healthChange_causedByEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.healthChange_causedByEntitySpawnTick, baseline.healthChange_causedByEntitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_optionalPositionToDropLootWhenDamaged_x != baseline.healthChange_optionalPositionToDropLootWhenDamaged_x) ? 4 : 0);
			num |= (uint)((snapshot.healthChange_optionalPositionToDropLootWhenDamaged_y != baseline.healthChange_optionalPositionToDropLootWhenDamaged_y) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.healthChange_optionalPositionToDropLootWhenDamaged_x, baseline.healthChange_optionalPositionToDropLootWhenDamaged_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.healthChange_optionalPositionToDropLootWhenDamaged_y, baseline.healthChange_optionalPositionToDropLootWhenDamaged_y, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_amount != baseline.healthChange_amount) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.healthChange_amount, baseline.healthChange_amount, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_bypassMaxDamagePerHit != baseline.healthChange_bypassMaxDamagePerHit) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_bypassMaxDamagePerHit, baseline.healthChange_bypassMaxDamagePerHit, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_skipWallAndRootsLootDropOnDestroy != baseline.healthChange_skipWallAndRootsLootDropOnDestroy) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_skipWallAndRootsLootDropOnDestroy, baseline.healthChange_skipWallAndRootsLootDropOnDestroy, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_skipLootDropOnDestroy != baseline.healthChange_skipLootDropOnDestroy) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_skipLootDropOnDestroy, baseline.healthChange_skipLootDropOnDestroy, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_skipLootDropIfDestroyPlants != baseline.healthChange_skipLootDropIfDestroyPlants) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_skipLootDropIfDestroyPlants, baseline.healthChange_skipLootDropIfDestroyPlants, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_wasKnockedBack != baseline.healthChange_wasKnockedBack) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_wasKnockedBack, baseline.healthChange_wasKnockedBack, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_bypassDamageReduction != baseline.healthChange_bypassDamageReduction) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_bypassDamageReduction, baseline.healthChange_bypassDamageReduction, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_pullLootToPlayer != baseline.healthChange_pullLootToPlayer) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_pullLootToPlayer, baseline.healthChange_pullLootToPlayer, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_wasKilled != baseline.healthChange_wasKilled) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_wasKilled, baseline.healthChange_wasKilled, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_damagedByExplosion != baseline.healthChange_damagedByExplosion) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_damagedByExplosion, baseline.healthChange_damagedByExplosion, in compressionModel);
			}
			num |= (uint)((snapshot.healthChange_applyToNonPredicted != baseline.healthChange_applyToNonPredicted) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.healthChange_applyToNonPredicted, baseline.healthChange_applyToNonPredicted, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 14);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 14);
			if ((num & 1) != 0)
			{
				snapshot.healthChange_entity = reader.ReadPackedIntDelta(baseline.healthChange_entity, in compressionModel);
				snapshot.healthChange_entitySpawnTick = reader.ReadPackedUIntDelta(baseline.healthChange_entitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.healthChange_entity = baseline.healthChange_entity;
				snapshot.healthChange_entitySpawnTick = baseline.healthChange_entitySpawnTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.healthChange_causedByEntity = reader.ReadPackedIntDelta(baseline.healthChange_causedByEntity, in compressionModel);
				snapshot.healthChange_causedByEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.healthChange_causedByEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.healthChange_causedByEntity = baseline.healthChange_causedByEntity;
				snapshot.healthChange_causedByEntitySpawnTick = baseline.healthChange_causedByEntitySpawnTick;
			}
			if ((num & 4) != 0)
			{
				snapshot.healthChange_optionalPositionToDropLootWhenDamaged_x = reader.ReadPackedFloatDelta(baseline.healthChange_optionalPositionToDropLootWhenDamaged_x, in compressionModel);
			}
			else
			{
				snapshot.healthChange_optionalPositionToDropLootWhenDamaged_x = baseline.healthChange_optionalPositionToDropLootWhenDamaged_x;
			}
			if ((num & 4) != 0)
			{
				snapshot.healthChange_optionalPositionToDropLootWhenDamaged_y = reader.ReadPackedFloatDelta(baseline.healthChange_optionalPositionToDropLootWhenDamaged_y, in compressionModel);
			}
			else
			{
				snapshot.healthChange_optionalPositionToDropLootWhenDamaged_y = baseline.healthChange_optionalPositionToDropLootWhenDamaged_y;
			}
			if ((num & 8) != 0)
			{
				snapshot.healthChange_amount = reader.ReadPackedIntDelta(baseline.healthChange_amount, in compressionModel);
			}
			else
			{
				snapshot.healthChange_amount = baseline.healthChange_amount;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.healthChange_bypassMaxDamagePerHit = reader.ReadPackedUIntDelta(baseline.healthChange_bypassMaxDamagePerHit, in compressionModel);
			}
			else
			{
				snapshot.healthChange_bypassMaxDamagePerHit = baseline.healthChange_bypassMaxDamagePerHit;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.healthChange_skipWallAndRootsLootDropOnDestroy = reader.ReadPackedUIntDelta(baseline.healthChange_skipWallAndRootsLootDropOnDestroy, in compressionModel);
			}
			else
			{
				snapshot.healthChange_skipWallAndRootsLootDropOnDestroy = baseline.healthChange_skipWallAndRootsLootDropOnDestroy;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.healthChange_skipLootDropOnDestroy = reader.ReadPackedUIntDelta(baseline.healthChange_skipLootDropOnDestroy, in compressionModel);
			}
			else
			{
				snapshot.healthChange_skipLootDropOnDestroy = baseline.healthChange_skipLootDropOnDestroy;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.healthChange_skipLootDropIfDestroyPlants = reader.ReadPackedUIntDelta(baseline.healthChange_skipLootDropIfDestroyPlants, in compressionModel);
			}
			else
			{
				snapshot.healthChange_skipLootDropIfDestroyPlants = baseline.healthChange_skipLootDropIfDestroyPlants;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.healthChange_wasKnockedBack = reader.ReadPackedUIntDelta(baseline.healthChange_wasKnockedBack, in compressionModel);
			}
			else
			{
				snapshot.healthChange_wasKnockedBack = baseline.healthChange_wasKnockedBack;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.healthChange_bypassDamageReduction = reader.ReadPackedUIntDelta(baseline.healthChange_bypassDamageReduction, in compressionModel);
			}
			else
			{
				snapshot.healthChange_bypassDamageReduction = baseline.healthChange_bypassDamageReduction;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.healthChange_pullLootToPlayer = reader.ReadPackedUIntDelta(baseline.healthChange_pullLootToPlayer, in compressionModel);
			}
			else
			{
				snapshot.healthChange_pullLootToPlayer = baseline.healthChange_pullLootToPlayer;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.healthChange_wasKilled = reader.ReadPackedUIntDelta(baseline.healthChange_wasKilled, in compressionModel);
			}
			else
			{
				snapshot.healthChange_wasKilled = baseline.healthChange_wasKilled;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.healthChange_damagedByExplosion = reader.ReadPackedUIntDelta(baseline.healthChange_damagedByExplosion, in compressionModel);
			}
			else
			{
				snapshot.healthChange_damagedByExplosion = baseline.healthChange_damagedByExplosion;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.healthChange_applyToNonPredicted = reader.ReadPackedUIntDelta(baseline.healthChange_applyToNonPredicted, in compressionModel);
			}
			else
			{
				snapshot.healthChange_applyToNonPredicted = baseline.healthChange_applyToNonPredicted;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 4081819130859728674uL,
					ComponentType = ComponentType.ReadWrite<InitialHealthChange>(),
					ComponentSize = UnsafeUtility.SizeOf<InitialHealthChange>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 14,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 10659893765851423316uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 1
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<InitialHealthChange, Snapshot, InitialHealthChangeGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
