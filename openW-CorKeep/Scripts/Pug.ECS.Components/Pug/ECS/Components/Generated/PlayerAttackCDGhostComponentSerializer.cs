using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
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
	public struct PlayerAttackCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public float windupMult;

			public uint isWoundup;

			public uint hitDuration_startTick;

			public uint hitDuration_targetTicks;

			public uint hitDuration_stopTick;

			public uint hitDelay_startTick;

			public uint hitDelay_targetTicks;

			public uint hitDelay_stopTick;

			public int animationToPlayAfterAttack;

			public int slotType;

			public int meleeDamage;

			public float lungeForce;

			public float recoilForce;

			public uint leaveTrail;

			public int trails;

			public int objectType;

			public float windupForce;

			public uint heldItemIsBroken;

			public int hitStreak;

			public uint spawnStuffOnHitCooldown_startTick;

			public uint spawnStuffOnHitCooldown_targetTicks;

			public uint spawnStuffOnHitCooldown_stopTick;

			public int currentWindupTier;

			public uint didSpawnTrail;
		}

		private const int ChangeMaskBits = 24;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 24;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<PlayerAttackCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<PlayerAttackCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<PlayerAttackCD>(component), in GhostComponentSerializer.TypeCastReadonly<PlayerAttackCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in PlayerAttackCD component)
		{
			snapshot.windupMult = component.windupMult;
			snapshot.isWoundup = (component.isWoundup ? 1u : 0u);
			snapshot.hitDuration_startTick = component.hitDuration.startTick.SerializedData;
			snapshot.hitDuration_targetTicks = component.hitDuration.targetTicks;
			snapshot.hitDuration_stopTick = component.hitDuration.stopTick.SerializedData;
			snapshot.hitDelay_startTick = component.hitDelay.startTick.SerializedData;
			snapshot.hitDelay_targetTicks = component.hitDelay.targetTicks;
			snapshot.hitDelay_stopTick = component.hitDelay.stopTick.SerializedData;
			snapshot.animationToPlayAfterAttack = component.animationToPlayAfterAttack;
			snapshot.slotType = (int)component.slotType;
			snapshot.meleeDamage = component.meleeDamage;
			snapshot.lungeForce = component.lungeForce;
			snapshot.recoilForce = component.recoilForce;
			snapshot.leaveTrail = (component.leaveTrail ? 1u : 0u);
			snapshot.trails = component.trails;
			snapshot.objectType = (int)component.objectType;
			snapshot.windupForce = component.windupForce;
			snapshot.heldItemIsBroken = (component.heldItemIsBroken ? 1u : 0u);
			snapshot.hitStreak = component.hitStreak;
			snapshot.spawnStuffOnHitCooldown_startTick = component.spawnStuffOnHitCooldown.startTick.SerializedData;
			snapshot.spawnStuffOnHitCooldown_targetTicks = component.spawnStuffOnHitCooldown.targetTicks;
			snapshot.spawnStuffOnHitCooldown_stopTick = component.spawnStuffOnHitCooldown.stopTick.SerializedData;
			snapshot.currentWindupTier = component.currentWindupTier;
			snapshot.didSpawnTrail = (component.didSpawnTrail ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref PlayerAttackCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.windupMult = snapshotBefore.windupMult;
			component.isWoundup = snapshotBefore.isWoundup != 0;
			component.hitDuration.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.hitDuration_startTick
			};
			component.hitDuration.targetTicks = snapshotBefore.hitDuration_targetTicks;
			component.hitDuration.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.hitDuration_stopTick
			};
			component.hitDelay.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.hitDelay_startTick
			};
			component.hitDelay.targetTicks = snapshotBefore.hitDelay_targetTicks;
			component.hitDelay.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.hitDelay_stopTick
			};
			component.animationToPlayAfterAttack = snapshotBefore.animationToPlayAfterAttack;
			component.slotType = (EquipmentSlotType)snapshotBefore.slotType;
			component.meleeDamage = snapshotBefore.meleeDamage;
			component.lungeForce = snapshotBefore.lungeForce;
			component.recoilForce = snapshotBefore.recoilForce;
			component.leaveTrail = snapshotBefore.leaveTrail != 0;
			component.trails = snapshotBefore.trails;
			component.objectType = (ObjectType)snapshotBefore.objectType;
			component.windupForce = snapshotBefore.windupForce;
			component.heldItemIsBroken = snapshotBefore.heldItemIsBroken != 0;
			component.hitStreak = snapshotBefore.hitStreak;
			component.spawnStuffOnHitCooldown.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.spawnStuffOnHitCooldown_startTick
			};
			component.spawnStuffOnHitCooldown.targetTicks = snapshotBefore.spawnStuffOnHitCooldown_targetTicks;
			component.spawnStuffOnHitCooldown.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.spawnStuffOnHitCooldown_stopTick
			};
			component.currentWindupTier = snapshotBefore.currentWindupTier;
			component.didSpawnTrail = snapshotBefore.didSpawnTrail != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref PlayerAttackCD component, in PlayerAttackCD backup)
		{
			component.windupMult = backup.windupMult;
			component.isWoundup = backup.isWoundup;
			component.hitDuration.startTick = backup.hitDuration.startTick;
			component.hitDuration.targetTicks = backup.hitDuration.targetTicks;
			component.hitDuration.stopTick = backup.hitDuration.stopTick;
			component.hitDelay.startTick = backup.hitDelay.startTick;
			component.hitDelay.targetTicks = backup.hitDelay.targetTicks;
			component.hitDelay.stopTick = backup.hitDelay.stopTick;
			component.animationToPlayAfterAttack = backup.animationToPlayAfterAttack;
			component.slotType = backup.slotType;
			component.meleeDamage = backup.meleeDamage;
			component.lungeForce = backup.lungeForce;
			component.recoilForce = backup.recoilForce;
			component.leaveTrail = backup.leaveTrail;
			component.trails = backup.trails;
			component.objectType = backup.objectType;
			component.windupForce = backup.windupForce;
			component.heldItemIsBroken = backup.heldItemIsBroken;
			component.hitStreak = backup.hitStreak;
			component.spawnStuffOnHitCooldown.startTick = backup.spawnStuffOnHitCooldown.startTick;
			component.spawnStuffOnHitCooldown.targetTicks = backup.spawnStuffOnHitCooldown.targetTicks;
			component.spawnStuffOnHitCooldown.stopTick = backup.spawnStuffOnHitCooldown.stopTick;
			component.currentWindupTier = backup.currentWindupTier;
			component.didSpawnTrail = backup.didSpawnTrail;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.isWoundup = (uint)predictor.PredictInt((int)snapshot.isWoundup, (int)baseline1.isWoundup, (int)baseline2.isWoundup);
			snapshot.hitDuration_startTick = (uint)predictor.PredictInt((int)snapshot.hitDuration_startTick, (int)baseline1.hitDuration_startTick, (int)baseline2.hitDuration_startTick);
			snapshot.hitDuration_targetTicks = (uint)predictor.PredictInt((int)snapshot.hitDuration_targetTicks, (int)baseline1.hitDuration_targetTicks, (int)baseline2.hitDuration_targetTicks);
			snapshot.hitDuration_stopTick = (uint)predictor.PredictInt((int)snapshot.hitDuration_stopTick, (int)baseline1.hitDuration_stopTick, (int)baseline2.hitDuration_stopTick);
			snapshot.hitDelay_startTick = (uint)predictor.PredictInt((int)snapshot.hitDelay_startTick, (int)baseline1.hitDelay_startTick, (int)baseline2.hitDelay_startTick);
			snapshot.hitDelay_targetTicks = (uint)predictor.PredictInt((int)snapshot.hitDelay_targetTicks, (int)baseline1.hitDelay_targetTicks, (int)baseline2.hitDelay_targetTicks);
			snapshot.hitDelay_stopTick = (uint)predictor.PredictInt((int)snapshot.hitDelay_stopTick, (int)baseline1.hitDelay_stopTick, (int)baseline2.hitDelay_stopTick);
			snapshot.animationToPlayAfterAttack = predictor.PredictInt(snapshot.animationToPlayAfterAttack, baseline1.animationToPlayAfterAttack, baseline2.animationToPlayAfterAttack);
			snapshot.slotType = predictor.PredictInt(snapshot.slotType, baseline1.slotType, baseline2.slotType);
			snapshot.meleeDamage = predictor.PredictInt(snapshot.meleeDamage, baseline1.meleeDamage, baseline2.meleeDamage);
			snapshot.leaveTrail = (uint)predictor.PredictInt((int)snapshot.leaveTrail, (int)baseline1.leaveTrail, (int)baseline2.leaveTrail);
			snapshot.trails = predictor.PredictInt(snapshot.trails, baseline1.trails, baseline2.trails);
			snapshot.objectType = predictor.PredictInt(snapshot.objectType, baseline1.objectType, baseline2.objectType);
			snapshot.heldItemIsBroken = (uint)predictor.PredictInt((int)snapshot.heldItemIsBroken, (int)baseline1.heldItemIsBroken, (int)baseline2.heldItemIsBroken);
			snapshot.hitStreak = predictor.PredictInt(snapshot.hitStreak, baseline1.hitStreak, baseline2.hitStreak);
			snapshot.spawnStuffOnHitCooldown_startTick = (uint)predictor.PredictInt((int)snapshot.spawnStuffOnHitCooldown_startTick, (int)baseline1.spawnStuffOnHitCooldown_startTick, (int)baseline2.spawnStuffOnHitCooldown_startTick);
			snapshot.spawnStuffOnHitCooldown_targetTicks = (uint)predictor.PredictInt((int)snapshot.spawnStuffOnHitCooldown_targetTicks, (int)baseline1.spawnStuffOnHitCooldown_targetTicks, (int)baseline2.spawnStuffOnHitCooldown_targetTicks);
			snapshot.spawnStuffOnHitCooldown_stopTick = (uint)predictor.PredictInt((int)snapshot.spawnStuffOnHitCooldown_stopTick, (int)baseline1.spawnStuffOnHitCooldown_stopTick, (int)baseline2.spawnStuffOnHitCooldown_stopTick);
			snapshot.currentWindupTier = predictor.PredictInt(snapshot.currentWindupTier, baseline1.currentWindupTier, baseline2.currentWindupTier);
			snapshot.didSpawnTrail = (uint)predictor.PredictInt((int)snapshot.didSpawnTrail, (int)baseline1.didSpawnTrail, (int)baseline2.didSpawnTrail);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.windupMult != baseline.windupMult) ? 1u : 0u);
			num |= (uint)((snapshot.isWoundup != baseline.isWoundup) ? 2 : 0);
			num |= (uint)((snapshot.hitDuration_startTick != baseline.hitDuration_startTick) ? 4 : 0);
			num |= (uint)((snapshot.hitDuration_targetTicks != baseline.hitDuration_targetTicks) ? 8 : 0);
			num |= (uint)((snapshot.hitDuration_stopTick != baseline.hitDuration_stopTick) ? 16 : 0);
			num |= (uint)((snapshot.hitDelay_startTick != baseline.hitDelay_startTick) ? 32 : 0);
			num |= (uint)((snapshot.hitDelay_targetTicks != baseline.hitDelay_targetTicks) ? 64 : 0);
			num |= (uint)((snapshot.hitDelay_stopTick != baseline.hitDelay_stopTick) ? 128 : 0);
			num |= (uint)((snapshot.animationToPlayAfterAttack != baseline.animationToPlayAfterAttack) ? 256 : 0);
			num |= (uint)((snapshot.slotType != baseline.slotType) ? 512 : 0);
			num |= (uint)((snapshot.meleeDamage != baseline.meleeDamage) ? 1024 : 0);
			num |= (uint)((snapshot.lungeForce != baseline.lungeForce) ? 2048 : 0);
			num |= (uint)((snapshot.recoilForce != baseline.recoilForce) ? 4096 : 0);
			num |= (uint)((snapshot.leaveTrail != baseline.leaveTrail) ? 8192 : 0);
			num |= (uint)((snapshot.trails != baseline.trails) ? 16384 : 0);
			num |= (uint)((snapshot.objectType != baseline.objectType) ? 32768 : 0);
			num |= (uint)((snapshot.windupForce != baseline.windupForce) ? 65536 : 0);
			num |= (uint)((snapshot.heldItemIsBroken != baseline.heldItemIsBroken) ? 131072 : 0);
			num |= (uint)((snapshot.hitStreak != baseline.hitStreak) ? 262144 : 0);
			num |= (uint)((snapshot.spawnStuffOnHitCooldown_startTick != baseline.spawnStuffOnHitCooldown_startTick) ? 524288 : 0);
			num |= (uint)((snapshot.spawnStuffOnHitCooldown_targetTicks != baseline.spawnStuffOnHitCooldown_targetTicks) ? 1048576 : 0);
			num |= (uint)((snapshot.spawnStuffOnHitCooldown_stopTick != baseline.spawnStuffOnHitCooldown_stopTick) ? 2097152 : 0);
			num |= (uint)((snapshot.currentWindupTier != baseline.currentWindupTier) ? 4194304 : 0);
			num |= (uint)((snapshot.didSpawnTrail != baseline.didSpawnTrail) ? 8388608 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 24);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 24);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.windupMult, baseline.windupMult, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isWoundup, baseline.isWoundup, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDuration_startTick, baseline.hitDuration_startTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDuration_targetTicks, baseline.hitDuration_targetTicks, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDuration_stopTick, baseline.hitDuration_stopTick, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDelay_startTick, baseline.hitDelay_startTick, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDelay_targetTicks, baseline.hitDelay_targetTicks, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDelay_stopTick, baseline.hitDelay_stopTick, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.animationToPlayAfterAttack, baseline.animationToPlayAfterAttack, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.slotType, baseline.slotType, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.meleeDamage, baseline.meleeDamage, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.lungeForce, baseline.lungeForce, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.recoilForce, baseline.recoilForce, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.leaveTrail, baseline.leaveTrail, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.trails, baseline.trails, in compressionModel);
			}
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectType, baseline.objectType, in compressionModel);
			}
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.windupForce, baseline.windupForce, in compressionModel);
			}
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.heldItemIsBroken, baseline.heldItemIsBroken, in compressionModel);
			}
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.hitStreak, baseline.hitStreak, in compressionModel);
			}
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.spawnStuffOnHitCooldown_startTick, baseline.spawnStuffOnHitCooldown_startTick, in compressionModel);
			}
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.spawnStuffOnHitCooldown_targetTicks, baseline.spawnStuffOnHitCooldown_targetTicks, in compressionModel);
			}
			if ((num & 0x200000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.spawnStuffOnHitCooldown_stopTick, baseline.spawnStuffOnHitCooldown_stopTick, in compressionModel);
			}
			if ((num & 0x400000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.currentWindupTier, baseline.currentWindupTier, in compressionModel);
			}
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.didSpawnTrail, baseline.didSpawnTrail, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.windupMult != baseline.windupMult) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.windupMult, baseline.windupMult, in compressionModel);
			}
			num |= (uint)((snapshot.isWoundup != baseline.isWoundup) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isWoundup, baseline.isWoundup, in compressionModel);
			}
			num |= (uint)((snapshot.hitDuration_startTick != baseline.hitDuration_startTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDuration_startTick, baseline.hitDuration_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.hitDuration_targetTicks != baseline.hitDuration_targetTicks) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDuration_targetTicks, baseline.hitDuration_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.hitDuration_stopTick != baseline.hitDuration_stopTick) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDuration_stopTick, baseline.hitDuration_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.hitDelay_startTick != baseline.hitDelay_startTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDelay_startTick, baseline.hitDelay_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.hitDelay_targetTicks != baseline.hitDelay_targetTicks) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDelay_targetTicks, baseline.hitDelay_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.hitDelay_stopTick != baseline.hitDelay_stopTick) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hitDelay_stopTick, baseline.hitDelay_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.animationToPlayAfterAttack != baseline.animationToPlayAfterAttack) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.animationToPlayAfterAttack, baseline.animationToPlayAfterAttack, in compressionModel);
			}
			num |= (uint)((snapshot.slotType != baseline.slotType) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.slotType, baseline.slotType, in compressionModel);
			}
			num |= (uint)((snapshot.meleeDamage != baseline.meleeDamage) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.meleeDamage, baseline.meleeDamage, in compressionModel);
			}
			num |= (uint)((snapshot.lungeForce != baseline.lungeForce) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.lungeForce, baseline.lungeForce, in compressionModel);
			}
			num |= (uint)((snapshot.recoilForce != baseline.recoilForce) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.recoilForce, baseline.recoilForce, in compressionModel);
			}
			num |= (uint)((snapshot.leaveTrail != baseline.leaveTrail) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.leaveTrail, baseline.leaveTrail, in compressionModel);
			}
			num |= (uint)((snapshot.trails != baseline.trails) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.trails, baseline.trails, in compressionModel);
			}
			num |= (uint)((snapshot.objectType != baseline.objectType) ? 32768 : 0);
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectType, baseline.objectType, in compressionModel);
			}
			num |= (uint)((snapshot.windupForce != baseline.windupForce) ? 65536 : 0);
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.windupForce, baseline.windupForce, in compressionModel);
			}
			num |= (uint)((snapshot.heldItemIsBroken != baseline.heldItemIsBroken) ? 131072 : 0);
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.heldItemIsBroken, baseline.heldItemIsBroken, in compressionModel);
			}
			num |= (uint)((snapshot.hitStreak != baseline.hitStreak) ? 262144 : 0);
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.hitStreak, baseline.hitStreak, in compressionModel);
			}
			num |= (uint)((snapshot.spawnStuffOnHitCooldown_startTick != baseline.spawnStuffOnHitCooldown_startTick) ? 524288 : 0);
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.spawnStuffOnHitCooldown_startTick, baseline.spawnStuffOnHitCooldown_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.spawnStuffOnHitCooldown_targetTicks != baseline.spawnStuffOnHitCooldown_targetTicks) ? 1048576 : 0);
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.spawnStuffOnHitCooldown_targetTicks, baseline.spawnStuffOnHitCooldown_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.spawnStuffOnHitCooldown_stopTick != baseline.spawnStuffOnHitCooldown_stopTick) ? 2097152 : 0);
			if ((num & 0x200000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.spawnStuffOnHitCooldown_stopTick, baseline.spawnStuffOnHitCooldown_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.currentWindupTier != baseline.currentWindupTier) ? 4194304 : 0);
			if ((num & 0x400000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.currentWindupTier, baseline.currentWindupTier, in compressionModel);
			}
			num |= (uint)((snapshot.didSpawnTrail != baseline.didSpawnTrail) ? 8388608 : 0);
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.didSpawnTrail, baseline.didSpawnTrail, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 24);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 24);
			if ((num & 1) != 0)
			{
				snapshot.windupMult = reader.ReadPackedFloatDelta(baseline.windupMult, in compressionModel);
			}
			else
			{
				snapshot.windupMult = baseline.windupMult;
			}
			if ((num & 2) != 0)
			{
				snapshot.isWoundup = reader.ReadPackedUIntDelta(baseline.isWoundup, in compressionModel);
			}
			else
			{
				snapshot.isWoundup = baseline.isWoundup;
			}
			if ((num & 4) != 0)
			{
				snapshot.hitDuration_startTick = reader.ReadPackedUIntDelta(baseline.hitDuration_startTick, in compressionModel);
			}
			else
			{
				snapshot.hitDuration_startTick = baseline.hitDuration_startTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.hitDuration_targetTicks = reader.ReadPackedUIntDelta(baseline.hitDuration_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.hitDuration_targetTicks = baseline.hitDuration_targetTicks;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.hitDuration_stopTick = reader.ReadPackedUIntDelta(baseline.hitDuration_stopTick, in compressionModel);
			}
			else
			{
				snapshot.hitDuration_stopTick = baseline.hitDuration_stopTick;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.hitDelay_startTick = reader.ReadPackedUIntDelta(baseline.hitDelay_startTick, in compressionModel);
			}
			else
			{
				snapshot.hitDelay_startTick = baseline.hitDelay_startTick;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.hitDelay_targetTicks = reader.ReadPackedUIntDelta(baseline.hitDelay_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.hitDelay_targetTicks = baseline.hitDelay_targetTicks;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.hitDelay_stopTick = reader.ReadPackedUIntDelta(baseline.hitDelay_stopTick, in compressionModel);
			}
			else
			{
				snapshot.hitDelay_stopTick = baseline.hitDelay_stopTick;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.animationToPlayAfterAttack = reader.ReadPackedIntDelta(baseline.animationToPlayAfterAttack, in compressionModel);
			}
			else
			{
				snapshot.animationToPlayAfterAttack = baseline.animationToPlayAfterAttack;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.slotType = reader.ReadPackedIntDelta(baseline.slotType, in compressionModel);
			}
			else
			{
				snapshot.slotType = baseline.slotType;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.meleeDamage = reader.ReadPackedIntDelta(baseline.meleeDamage, in compressionModel);
			}
			else
			{
				snapshot.meleeDamage = baseline.meleeDamage;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.lungeForce = reader.ReadPackedFloatDelta(baseline.lungeForce, in compressionModel);
			}
			else
			{
				snapshot.lungeForce = baseline.lungeForce;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.recoilForce = reader.ReadPackedFloatDelta(baseline.recoilForce, in compressionModel);
			}
			else
			{
				snapshot.recoilForce = baseline.recoilForce;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.leaveTrail = reader.ReadPackedUIntDelta(baseline.leaveTrail, in compressionModel);
			}
			else
			{
				snapshot.leaveTrail = baseline.leaveTrail;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.trails = reader.ReadPackedIntDelta(baseline.trails, in compressionModel);
			}
			else
			{
				snapshot.trails = baseline.trails;
			}
			if ((num & 0x8000) != 0)
			{
				snapshot.objectType = reader.ReadPackedIntDelta(baseline.objectType, in compressionModel);
			}
			else
			{
				snapshot.objectType = baseline.objectType;
			}
			if ((num & 0x10000) != 0)
			{
				snapshot.windupForce = reader.ReadPackedFloatDelta(baseline.windupForce, in compressionModel);
			}
			else
			{
				snapshot.windupForce = baseline.windupForce;
			}
			if ((num & 0x20000) != 0)
			{
				snapshot.heldItemIsBroken = reader.ReadPackedUIntDelta(baseline.heldItemIsBroken, in compressionModel);
			}
			else
			{
				snapshot.heldItemIsBroken = baseline.heldItemIsBroken;
			}
			if ((num & 0x40000) != 0)
			{
				snapshot.hitStreak = reader.ReadPackedIntDelta(baseline.hitStreak, in compressionModel);
			}
			else
			{
				snapshot.hitStreak = baseline.hitStreak;
			}
			if ((num & 0x80000) != 0)
			{
				snapshot.spawnStuffOnHitCooldown_startTick = reader.ReadPackedUIntDelta(baseline.spawnStuffOnHitCooldown_startTick, in compressionModel);
			}
			else
			{
				snapshot.spawnStuffOnHitCooldown_startTick = baseline.spawnStuffOnHitCooldown_startTick;
			}
			if ((num & 0x100000) != 0)
			{
				snapshot.spawnStuffOnHitCooldown_targetTicks = reader.ReadPackedUIntDelta(baseline.spawnStuffOnHitCooldown_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.spawnStuffOnHitCooldown_targetTicks = baseline.spawnStuffOnHitCooldown_targetTicks;
			}
			if ((num & 0x200000) != 0)
			{
				snapshot.spawnStuffOnHitCooldown_stopTick = reader.ReadPackedUIntDelta(baseline.spawnStuffOnHitCooldown_stopTick, in compressionModel);
			}
			else
			{
				snapshot.spawnStuffOnHitCooldown_stopTick = baseline.spawnStuffOnHitCooldown_stopTick;
			}
			if ((num & 0x400000) != 0)
			{
				snapshot.currentWindupTier = reader.ReadPackedIntDelta(baseline.currentWindupTier, in compressionModel);
			}
			else
			{
				snapshot.currentWindupTier = baseline.currentWindupTier;
			}
			if ((num & 0x800000) != 0)
			{
				snapshot.didSpawnTrail = reader.ReadPackedUIntDelta(baseline.didSpawnTrail, in compressionModel);
			}
			else
			{
				snapshot.didSpawnTrail = baseline.didSpawnTrail;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 7688588023647605200uL,
					ComponentType = ComponentType.ReadWrite<PlayerAttackCD>(),
					ComponentSize = UnsafeUtility.SizeOf<PlayerAttackCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 24,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 653187025514511322uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<PlayerAttackCD, Snapshot, PlayerAttackCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
