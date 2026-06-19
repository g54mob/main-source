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
	public struct ExplosionCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint hasDealtDamage;

			public int damage;

			public int tileDamage;

			public float radius;

			public uint delayTimer_startTick;

			public uint delayTimer_targetTicks;

			public uint delayTimer_stopTick;

			public int triggerEntityToIgnoreExplosionDamage;

			public uint triggerEntityToIgnoreExplosionDamageSpawnTick;

			public int level;

			public int spawnNapalmObjectID;

			public int spawnNapalmVariation;

			public int napalmIncreasedBurningDamagePercentage;

			public uint cameFromExplosive;

			public uint cameFromBomb;

			public int explosionPushback;
		}

		private const int ChangeMaskBits = 15;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 15;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ExplosionCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ExplosionCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ExplosionCD>(component), in GhostComponentSerializer.TypeCastReadonly<ExplosionCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ExplosionCD component)
		{
			snapshot.hasDealtDamage = (component.hasDealtDamage ? 1u : 0u);
			snapshot.damage = component.damage;
			snapshot.tileDamage = component.tileDamage;
			snapshot.radius = component.radius;
			snapshot.delayTimer_startTick = component.delayTimer.startTick.SerializedData;
			snapshot.delayTimer_targetTicks = component.delayTimer.targetTicks;
			snapshot.delayTimer_stopTick = component.delayTimer.stopTick.SerializedData;
			snapshot.triggerEntityToIgnoreExplosionDamage = 0;
			snapshot.triggerEntityToIgnoreExplosionDamageSpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.triggerEntityToIgnoreExplosionDamage))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.triggerEntityToIgnoreExplosionDamage];
				snapshot.triggerEntityToIgnoreExplosionDamage = ghostInstance.ghostId;
				snapshot.triggerEntityToIgnoreExplosionDamageSpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.level = component.level;
			snapshot.spawnNapalmObjectID = (int)component.spawnNapalmObjectID;
			snapshot.spawnNapalmVariation = component.spawnNapalmVariation;
			snapshot.napalmIncreasedBurningDamagePercentage = component.napalmIncreasedBurningDamagePercentage;
			snapshot.cameFromExplosive = (component.cameFromExplosive ? 1u : 0u);
			snapshot.cameFromBomb = (component.cameFromBomb ? 1u : 0u);
			snapshot.explosionPushback = (int)component.explosionPushback;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ExplosionCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.hasDealtDamage = snapshotBefore.hasDealtDamage != 0;
			component.damage = snapshotBefore.damage;
			component.tileDamage = snapshotBefore.tileDamage;
			component.radius = snapshotBefore.radius;
			component.delayTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.delayTimer_startTick
			};
			component.delayTimer.targetTicks = snapshotBefore.delayTimer_targetTicks;
			component.delayTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.delayTimer_stopTick
			};
			component.triggerEntityToIgnoreExplosionDamage = Entity.Null;
			if (snapshotBefore.triggerEntityToIgnoreExplosionDamage != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.triggerEntityToIgnoreExplosionDamage,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.triggerEntityToIgnoreExplosionDamageSpawnTick
				}
			}, out var item))
			{
				component.triggerEntityToIgnoreExplosionDamage = item;
			}
			component.level = snapshotBefore.level;
			component.spawnNapalmObjectID = (ObjectID)snapshotBefore.spawnNapalmObjectID;
			component.spawnNapalmVariation = snapshotBefore.spawnNapalmVariation;
			component.napalmIncreasedBurningDamagePercentage = snapshotBefore.napalmIncreasedBurningDamagePercentage;
			component.cameFromExplosive = snapshotBefore.cameFromExplosive != 0;
			component.cameFromBomb = snapshotBefore.cameFromBomb != 0;
			component.explosionPushback = (ExplosionPushbackLevel)snapshotBefore.explosionPushback;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ExplosionCD component, in ExplosionCD backup)
		{
			component.hasDealtDamage = backup.hasDealtDamage;
			component.damage = backup.damage;
			component.tileDamage = backup.tileDamage;
			component.radius = backup.radius;
			component.delayTimer.startTick = backup.delayTimer.startTick;
			component.delayTimer.targetTicks = backup.delayTimer.targetTicks;
			component.delayTimer.stopTick = backup.delayTimer.stopTick;
			component.triggerEntityToIgnoreExplosionDamage = backup.triggerEntityToIgnoreExplosionDamage;
			component.level = backup.level;
			component.spawnNapalmObjectID = backup.spawnNapalmObjectID;
			component.spawnNapalmVariation = backup.spawnNapalmVariation;
			component.napalmIncreasedBurningDamagePercentage = backup.napalmIncreasedBurningDamagePercentage;
			component.cameFromExplosive = backup.cameFromExplosive;
			component.cameFromBomb = backup.cameFromBomb;
			component.explosionPushback = backup.explosionPushback;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.hasDealtDamage = (uint)predictor.PredictInt((int)snapshot.hasDealtDamage, (int)baseline1.hasDealtDamage, (int)baseline2.hasDealtDamage);
			snapshot.damage = predictor.PredictInt(snapshot.damage, baseline1.damage, baseline2.damage);
			snapshot.tileDamage = predictor.PredictInt(snapshot.tileDamage, baseline1.tileDamage, baseline2.tileDamage);
			snapshot.delayTimer_startTick = (uint)predictor.PredictInt((int)snapshot.delayTimer_startTick, (int)baseline1.delayTimer_startTick, (int)baseline2.delayTimer_startTick);
			snapshot.delayTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.delayTimer_targetTicks, (int)baseline1.delayTimer_targetTicks, (int)baseline2.delayTimer_targetTicks);
			snapshot.delayTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.delayTimer_stopTick, (int)baseline1.delayTimer_stopTick, (int)baseline2.delayTimer_stopTick);
			snapshot.triggerEntityToIgnoreExplosionDamage = predictor.PredictInt(snapshot.triggerEntityToIgnoreExplosionDamage, baseline1.triggerEntityToIgnoreExplosionDamage, baseline2.triggerEntityToIgnoreExplosionDamage);
			snapshot.triggerEntityToIgnoreExplosionDamageSpawnTick = (uint)predictor.PredictInt((int)snapshot.triggerEntityToIgnoreExplosionDamageSpawnTick, (int)baseline1.triggerEntityToIgnoreExplosionDamageSpawnTick, baseline2.triggerEntityToIgnoreExplosionDamage);
			snapshot.level = predictor.PredictInt(snapshot.level, baseline1.level, baseline2.level);
			snapshot.spawnNapalmObjectID = predictor.PredictInt(snapshot.spawnNapalmObjectID, baseline1.spawnNapalmObjectID, baseline2.spawnNapalmObjectID);
			snapshot.spawnNapalmVariation = predictor.PredictInt(snapshot.spawnNapalmVariation, baseline1.spawnNapalmVariation, baseline2.spawnNapalmVariation);
			snapshot.napalmIncreasedBurningDamagePercentage = predictor.PredictInt(snapshot.napalmIncreasedBurningDamagePercentage, baseline1.napalmIncreasedBurningDamagePercentage, baseline2.napalmIncreasedBurningDamagePercentage);
			snapshot.cameFromExplosive = (uint)predictor.PredictInt((int)snapshot.cameFromExplosive, (int)baseline1.cameFromExplosive, (int)baseline2.cameFromExplosive);
			snapshot.cameFromBomb = (uint)predictor.PredictInt((int)snapshot.cameFromBomb, (int)baseline1.cameFromBomb, (int)baseline2.cameFromBomb);
			snapshot.explosionPushback = predictor.PredictInt(snapshot.explosionPushback, baseline1.explosionPushback, baseline2.explosionPushback);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.hasDealtDamage != baseline.hasDealtDamage) ? 1u : 0u);
			num |= (uint)((snapshot.damage != baseline.damage) ? 2 : 0);
			num |= (uint)((snapshot.tileDamage != baseline.tileDamage) ? 4 : 0);
			num |= (uint)((snapshot.radius != baseline.radius) ? 8 : 0);
			num |= (uint)((snapshot.delayTimer_startTick != baseline.delayTimer_startTick) ? 16 : 0);
			num |= (uint)((snapshot.delayTimer_targetTicks != baseline.delayTimer_targetTicks) ? 32 : 0);
			num |= (uint)((snapshot.delayTimer_stopTick != baseline.delayTimer_stopTick) ? 64 : 0);
			num |= (uint)((snapshot.triggerEntityToIgnoreExplosionDamage != baseline.triggerEntityToIgnoreExplosionDamage || snapshot.triggerEntityToIgnoreExplosionDamageSpawnTick != baseline.triggerEntityToIgnoreExplosionDamageSpawnTick) ? 128 : 0);
			num |= (uint)((snapshot.level != baseline.level) ? 256 : 0);
			num |= (uint)((snapshot.spawnNapalmObjectID != baseline.spawnNapalmObjectID) ? 512 : 0);
			num |= (uint)((snapshot.spawnNapalmVariation != baseline.spawnNapalmVariation) ? 1024 : 0);
			num |= (uint)((snapshot.napalmIncreasedBurningDamagePercentage != baseline.napalmIncreasedBurningDamagePercentage) ? 2048 : 0);
			num |= (uint)((snapshot.cameFromExplosive != baseline.cameFromExplosive) ? 4096 : 0);
			num |= (uint)((snapshot.cameFromBomb != baseline.cameFromBomb) ? 8192 : 0);
			num |= (uint)((snapshot.explosionPushback != baseline.explosionPushback) ? 16384 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 15);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hasDealtDamage, baseline.hasDealtDamage, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.damage, baseline.damage, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileDamage, baseline.tileDamage, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.radius, baseline.radius, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.delayTimer_startTick, baseline.delayTimer_startTick, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.delayTimer_targetTicks, baseline.delayTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.delayTimer_stopTick, baseline.delayTimer_stopTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.triggerEntityToIgnoreExplosionDamage, baseline.triggerEntityToIgnoreExplosionDamage, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.triggerEntityToIgnoreExplosionDamageSpawnTick, baseline.triggerEntityToIgnoreExplosionDamageSpawnTick, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.level, baseline.level, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.spawnNapalmObjectID, baseline.spawnNapalmObjectID, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.spawnNapalmVariation, baseline.spawnNapalmVariation, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedIntDelta(snapshot.napalmIncreasedBurningDamagePercentage, baseline.napalmIncreasedBurningDamagePercentage, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.cameFromExplosive, baseline.cameFromExplosive, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.cameFromBomb, baseline.cameFromBomb, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.explosionPushback, baseline.explosionPushback, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.hasDealtDamage != baseline.hasDealtDamage) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hasDealtDamage, baseline.hasDealtDamage, in compressionModel);
			}
			num |= (uint)((snapshot.damage != baseline.damage) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.damage, baseline.damage, in compressionModel);
			}
			num |= (uint)((snapshot.tileDamage != baseline.tileDamage) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileDamage, baseline.tileDamage, in compressionModel);
			}
			num |= (uint)((snapshot.radius != baseline.radius) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.radius, baseline.radius, in compressionModel);
			}
			num |= (uint)((snapshot.delayTimer_startTick != baseline.delayTimer_startTick) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.delayTimer_startTick, baseline.delayTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.delayTimer_targetTicks != baseline.delayTimer_targetTicks) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.delayTimer_targetTicks, baseline.delayTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.delayTimer_stopTick != baseline.delayTimer_stopTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.delayTimer_stopTick, baseline.delayTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.triggerEntityToIgnoreExplosionDamage != baseline.triggerEntityToIgnoreExplosionDamage || snapshot.triggerEntityToIgnoreExplosionDamageSpawnTick != baseline.triggerEntityToIgnoreExplosionDamageSpawnTick) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.triggerEntityToIgnoreExplosionDamage, baseline.triggerEntityToIgnoreExplosionDamage, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.triggerEntityToIgnoreExplosionDamageSpawnTick, baseline.triggerEntityToIgnoreExplosionDamageSpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.level != baseline.level) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.level, baseline.level, in compressionModel);
			}
			num |= (uint)((snapshot.spawnNapalmObjectID != baseline.spawnNapalmObjectID) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.spawnNapalmObjectID, baseline.spawnNapalmObjectID, in compressionModel);
			}
			num |= (uint)((snapshot.spawnNapalmVariation != baseline.spawnNapalmVariation) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.spawnNapalmVariation, baseline.spawnNapalmVariation, in compressionModel);
			}
			num |= (uint)((snapshot.napalmIncreasedBurningDamagePercentage != baseline.napalmIncreasedBurningDamagePercentage) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedIntDelta(snapshot.napalmIncreasedBurningDamagePercentage, baseline.napalmIncreasedBurningDamagePercentage, in compressionModel);
			}
			num |= (uint)((snapshot.cameFromExplosive != baseline.cameFromExplosive) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.cameFromExplosive, baseline.cameFromExplosive, in compressionModel);
			}
			num |= (uint)((snapshot.cameFromBomb != baseline.cameFromBomb) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.cameFromBomb, baseline.cameFromBomb, in compressionModel);
			}
			num |= (uint)((snapshot.explosionPushback != baseline.explosionPushback) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.explosionPushback, baseline.explosionPushback, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 15);
			if ((num & 1) != 0)
			{
				snapshot.hasDealtDamage = reader.ReadPackedUIntDelta(baseline.hasDealtDamage, in compressionModel);
			}
			else
			{
				snapshot.hasDealtDamage = baseline.hasDealtDamage;
			}
			if ((num & 2) != 0)
			{
				snapshot.damage = reader.ReadPackedIntDelta(baseline.damage, in compressionModel);
			}
			else
			{
				snapshot.damage = baseline.damage;
			}
			if ((num & 4) != 0)
			{
				snapshot.tileDamage = reader.ReadPackedIntDelta(baseline.tileDamage, in compressionModel);
			}
			else
			{
				snapshot.tileDamage = baseline.tileDamage;
			}
			if ((num & 8) != 0)
			{
				snapshot.radius = reader.ReadPackedFloatDelta(baseline.radius, in compressionModel);
			}
			else
			{
				snapshot.radius = baseline.radius;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.delayTimer_startTick = reader.ReadPackedUIntDelta(baseline.delayTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.delayTimer_startTick = baseline.delayTimer_startTick;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.delayTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.delayTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.delayTimer_targetTicks = baseline.delayTimer_targetTicks;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.delayTimer_stopTick = reader.ReadPackedUIntDelta(baseline.delayTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.delayTimer_stopTick = baseline.delayTimer_stopTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.triggerEntityToIgnoreExplosionDamage = reader.ReadPackedIntDelta(baseline.triggerEntityToIgnoreExplosionDamage, in compressionModel);
				snapshot.triggerEntityToIgnoreExplosionDamageSpawnTick = reader.ReadPackedUIntDelta(baseline.triggerEntityToIgnoreExplosionDamageSpawnTick, in compressionModel);
			}
			else
			{
				snapshot.triggerEntityToIgnoreExplosionDamage = baseline.triggerEntityToIgnoreExplosionDamage;
				snapshot.triggerEntityToIgnoreExplosionDamageSpawnTick = baseline.triggerEntityToIgnoreExplosionDamageSpawnTick;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.level = reader.ReadPackedIntDelta(baseline.level, in compressionModel);
			}
			else
			{
				snapshot.level = baseline.level;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.spawnNapalmObjectID = reader.ReadPackedIntDelta(baseline.spawnNapalmObjectID, in compressionModel);
			}
			else
			{
				snapshot.spawnNapalmObjectID = baseline.spawnNapalmObjectID;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.spawnNapalmVariation = reader.ReadPackedIntDelta(baseline.spawnNapalmVariation, in compressionModel);
			}
			else
			{
				snapshot.spawnNapalmVariation = baseline.spawnNapalmVariation;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.napalmIncreasedBurningDamagePercentage = reader.ReadPackedIntDelta(baseline.napalmIncreasedBurningDamagePercentage, in compressionModel);
			}
			else
			{
				snapshot.napalmIncreasedBurningDamagePercentage = baseline.napalmIncreasedBurningDamagePercentage;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.cameFromExplosive = reader.ReadPackedUIntDelta(baseline.cameFromExplosive, in compressionModel);
			}
			else
			{
				snapshot.cameFromExplosive = baseline.cameFromExplosive;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.cameFromBomb = reader.ReadPackedUIntDelta(baseline.cameFromBomb, in compressionModel);
			}
			else
			{
				snapshot.cameFromBomb = baseline.cameFromBomb;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.explosionPushback = reader.ReadPackedIntDelta(baseline.explosionPushback, in compressionModel);
			}
			else
			{
				snapshot.explosionPushback = baseline.explosionPushback;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 4081819130859728674uL,
					ComponentType = ComponentType.ReadWrite<ExplosionCD>(),
					ComponentSize = UnsafeUtility.SizeOf<ExplosionCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 15,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 12257121935135403780uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ExplosionCD, Snapshot, ExplosionCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
