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
	public struct EquipmentSlotCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public float currentWindup;

			public int secondaryUse_mechanic;

			public int secondaryUse_windupTiers;

			public int secondaryUse_cancelAttackIfNotAtWindupTier;

			public float secondaryUse_windupAreaSizeMultiplier;

			public float secondaryUse_extraDamageMultiplier;

			public float secondaryUse_projectileSpeedMultiplier;

			public float secondaryUse_windupTime;

			public uint secondaryUse_knockback;

			public float secondaryUse_manaCostMultiplier;

			public int secondaryUse_weaponEffectType;

			public int secondaryUse_useTerm;

			public int secondaryUse_minionToSpawn;

			public float warmupCD_warmupTime;

			public uint windupTimer_startTick;

			public uint windupTimer_targetTicks;

			public uint windupTimer_stopTick;

			public float currentWindupMultiplier;

			public uint atMaxWindup;

			public int currentWindupTier;

			public uint summonMinion;

			public uint interactIsPendingToBeUsed;

			public uint secondInteractIsPendingToBeUsed;

			public uint secondInteractBlockedUntilRelease;

			public uint windupCanceled;

			public uint warmupTimer_startTick;

			public uint warmupTimer_targetTicks;

			public uint warmupTimer_stopTick;

			public uint lastInteractPressedOnCooldownTick;
		}

		private const int ChangeMaskBits = 29;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 29;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<EquipmentSlotCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<EquipmentSlotCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<EquipmentSlotCD>(component), in GhostComponentSerializer.TypeCastReadonly<EquipmentSlotCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in EquipmentSlotCD component)
		{
			snapshot.currentWindup = component.currentWindup;
			snapshot.secondaryUse_mechanic = (int)component.secondaryUse.mechanic;
			snapshot.secondaryUse_windupTiers = component.secondaryUse.windupTiers;
			snapshot.secondaryUse_cancelAttackIfNotAtWindupTier = component.secondaryUse.cancelAttackIfNotAtWindupTier;
			snapshot.secondaryUse_windupAreaSizeMultiplier = component.secondaryUse.windupAreaSizeMultiplier;
			snapshot.secondaryUse_extraDamageMultiplier = component.secondaryUse.extraDamageMultiplier;
			snapshot.secondaryUse_projectileSpeedMultiplier = component.secondaryUse.projectileSpeedMultiplier;
			snapshot.secondaryUse_windupTime = component.secondaryUse.windupTime;
			snapshot.secondaryUse_knockback = (component.secondaryUse.knockback ? 1u : 0u);
			snapshot.secondaryUse_manaCostMultiplier = component.secondaryUse.manaCostMultiplier;
			snapshot.secondaryUse_weaponEffectType = (int)component.secondaryUse.weaponEffectType;
			snapshot.secondaryUse_useTerm = (int)component.secondaryUse.useTerm;
			snapshot.secondaryUse_minionToSpawn = (int)component.secondaryUse.minionToSpawn;
			snapshot.warmupCD_warmupTime = component.warmupCD.warmupTime;
			snapshot.windupTimer_startTick = component.windupTimer.startTick.SerializedData;
			snapshot.windupTimer_targetTicks = component.windupTimer.targetTicks;
			snapshot.windupTimer_stopTick = component.windupTimer.stopTick.SerializedData;
			snapshot.currentWindupMultiplier = component.currentWindupMultiplier;
			snapshot.atMaxWindup = (component.atMaxWindup ? 1u : 0u);
			snapshot.currentWindupTier = component.currentWindupTier;
			snapshot.summonMinion = (component.summonMinion ? 1u : 0u);
			snapshot.interactIsPendingToBeUsed = (component.interactIsPendingToBeUsed ? 1u : 0u);
			snapshot.secondInteractIsPendingToBeUsed = (component.secondInteractIsPendingToBeUsed ? 1u : 0u);
			snapshot.secondInteractBlockedUntilRelease = (component.secondInteractBlockedUntilRelease ? 1u : 0u);
			snapshot.windupCanceled = (component.windupCanceled ? 1u : 0u);
			snapshot.warmupTimer_startTick = component.warmupTimer.startTick.SerializedData;
			snapshot.warmupTimer_targetTicks = component.warmupTimer.targetTicks;
			snapshot.warmupTimer_stopTick = component.warmupTimer.stopTick.SerializedData;
			snapshot.lastInteractPressedOnCooldownTick = component.lastInteractPressedOnCooldownTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref EquipmentSlotCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.currentWindup = snapshotBefore.currentWindup;
			component.secondaryUse.mechanic = (SecondaryUseMechanic)snapshotBefore.secondaryUse_mechanic;
			component.secondaryUse.windupTiers = snapshotBefore.secondaryUse_windupTiers;
			component.secondaryUse.cancelAttackIfNotAtWindupTier = snapshotBefore.secondaryUse_cancelAttackIfNotAtWindupTier;
			component.secondaryUse.windupAreaSizeMultiplier = snapshotBefore.secondaryUse_windupAreaSizeMultiplier;
			component.secondaryUse.extraDamageMultiplier = snapshotBefore.secondaryUse_extraDamageMultiplier;
			component.secondaryUse.projectileSpeedMultiplier = snapshotBefore.secondaryUse_projectileSpeedMultiplier;
			component.secondaryUse.windupTime = snapshotBefore.secondaryUse_windupTime;
			component.secondaryUse.knockback = snapshotBefore.secondaryUse_knockback != 0;
			component.secondaryUse.manaCostMultiplier = snapshotBefore.secondaryUse_manaCostMultiplier;
			component.secondaryUse.weaponEffectType = (WeaponEffectType)snapshotBefore.secondaryUse_weaponEffectType;
			component.secondaryUse.useTerm = (SecondaryUseTerm)snapshotBefore.secondaryUse_useTerm;
			component.secondaryUse.minionToSpawn = (ObjectID)snapshotBefore.secondaryUse_minionToSpawn;
			component.warmupCD.warmupTime = snapshotBefore.warmupCD_warmupTime;
			component.windupTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.windupTimer_startTick
			};
			component.windupTimer.targetTicks = snapshotBefore.windupTimer_targetTicks;
			component.windupTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.windupTimer_stopTick
			};
			component.currentWindupMultiplier = snapshotBefore.currentWindupMultiplier;
			component.atMaxWindup = snapshotBefore.atMaxWindup != 0;
			component.currentWindupTier = snapshotBefore.currentWindupTier;
			component.summonMinion = snapshotBefore.summonMinion != 0;
			component.interactIsPendingToBeUsed = snapshotBefore.interactIsPendingToBeUsed != 0;
			component.secondInteractIsPendingToBeUsed = snapshotBefore.secondInteractIsPendingToBeUsed != 0;
			component.secondInteractBlockedUntilRelease = snapshotBefore.secondInteractBlockedUntilRelease != 0;
			component.windupCanceled = snapshotBefore.windupCanceled != 0;
			component.warmupTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.warmupTimer_startTick
			};
			component.warmupTimer.targetTicks = snapshotBefore.warmupTimer_targetTicks;
			component.warmupTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.warmupTimer_stopTick
			};
			component.lastInteractPressedOnCooldownTick = new NetworkTick
			{
				SerializedData = snapshotBefore.lastInteractPressedOnCooldownTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref EquipmentSlotCD component, in EquipmentSlotCD backup)
		{
			component.currentWindup = backup.currentWindup;
			component.secondaryUse.mechanic = backup.secondaryUse.mechanic;
			component.secondaryUse.windupTiers = backup.secondaryUse.windupTiers;
			component.secondaryUse.cancelAttackIfNotAtWindupTier = backup.secondaryUse.cancelAttackIfNotAtWindupTier;
			component.secondaryUse.windupAreaSizeMultiplier = backup.secondaryUse.windupAreaSizeMultiplier;
			component.secondaryUse.extraDamageMultiplier = backup.secondaryUse.extraDamageMultiplier;
			component.secondaryUse.projectileSpeedMultiplier = backup.secondaryUse.projectileSpeedMultiplier;
			component.secondaryUse.windupTime = backup.secondaryUse.windupTime;
			component.secondaryUse.knockback = backup.secondaryUse.knockback;
			component.secondaryUse.manaCostMultiplier = backup.secondaryUse.manaCostMultiplier;
			component.secondaryUse.weaponEffectType = backup.secondaryUse.weaponEffectType;
			component.secondaryUse.useTerm = backup.secondaryUse.useTerm;
			component.secondaryUse.minionToSpawn = backup.secondaryUse.minionToSpawn;
			component.warmupCD.warmupTime = backup.warmupCD.warmupTime;
			component.windupTimer.startTick = backup.windupTimer.startTick;
			component.windupTimer.targetTicks = backup.windupTimer.targetTicks;
			component.windupTimer.stopTick = backup.windupTimer.stopTick;
			component.currentWindupMultiplier = backup.currentWindupMultiplier;
			component.atMaxWindup = backup.atMaxWindup;
			component.currentWindupTier = backup.currentWindupTier;
			component.summonMinion = backup.summonMinion;
			component.interactIsPendingToBeUsed = backup.interactIsPendingToBeUsed;
			component.secondInteractIsPendingToBeUsed = backup.secondInteractIsPendingToBeUsed;
			component.secondInteractBlockedUntilRelease = backup.secondInteractBlockedUntilRelease;
			component.windupCanceled = backup.windupCanceled;
			component.warmupTimer.startTick = backup.warmupTimer.startTick;
			component.warmupTimer.targetTicks = backup.warmupTimer.targetTicks;
			component.warmupTimer.stopTick = backup.warmupTimer.stopTick;
			component.lastInteractPressedOnCooldownTick = backup.lastInteractPressedOnCooldownTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.secondaryUse_mechanic = predictor.PredictInt(snapshot.secondaryUse_mechanic, baseline1.secondaryUse_mechanic, baseline2.secondaryUse_mechanic);
			snapshot.secondaryUse_windupTiers = predictor.PredictInt(snapshot.secondaryUse_windupTiers, baseline1.secondaryUse_windupTiers, baseline2.secondaryUse_windupTiers);
			snapshot.secondaryUse_cancelAttackIfNotAtWindupTier = predictor.PredictInt(snapshot.secondaryUse_cancelAttackIfNotAtWindupTier, baseline1.secondaryUse_cancelAttackIfNotAtWindupTier, baseline2.secondaryUse_cancelAttackIfNotAtWindupTier);
			snapshot.secondaryUse_knockback = (uint)predictor.PredictInt((int)snapshot.secondaryUse_knockback, (int)baseline1.secondaryUse_knockback, (int)baseline2.secondaryUse_knockback);
			snapshot.secondaryUse_weaponEffectType = predictor.PredictInt(snapshot.secondaryUse_weaponEffectType, baseline1.secondaryUse_weaponEffectType, baseline2.secondaryUse_weaponEffectType);
			snapshot.secondaryUse_useTerm = predictor.PredictInt(snapshot.secondaryUse_useTerm, baseline1.secondaryUse_useTerm, baseline2.secondaryUse_useTerm);
			snapshot.secondaryUse_minionToSpawn = predictor.PredictInt(snapshot.secondaryUse_minionToSpawn, baseline1.secondaryUse_minionToSpawn, baseline2.secondaryUse_minionToSpawn);
			snapshot.windupTimer_startTick = (uint)predictor.PredictInt((int)snapshot.windupTimer_startTick, (int)baseline1.windupTimer_startTick, (int)baseline2.windupTimer_startTick);
			snapshot.windupTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.windupTimer_targetTicks, (int)baseline1.windupTimer_targetTicks, (int)baseline2.windupTimer_targetTicks);
			snapshot.windupTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.windupTimer_stopTick, (int)baseline1.windupTimer_stopTick, (int)baseline2.windupTimer_stopTick);
			snapshot.atMaxWindup = (uint)predictor.PredictInt((int)snapshot.atMaxWindup, (int)baseline1.atMaxWindup, (int)baseline2.atMaxWindup);
			snapshot.currentWindupTier = predictor.PredictInt(snapshot.currentWindupTier, baseline1.currentWindupTier, baseline2.currentWindupTier);
			snapshot.summonMinion = (uint)predictor.PredictInt((int)snapshot.summonMinion, (int)baseline1.summonMinion, (int)baseline2.summonMinion);
			snapshot.interactIsPendingToBeUsed = (uint)predictor.PredictInt((int)snapshot.interactIsPendingToBeUsed, (int)baseline1.interactIsPendingToBeUsed, (int)baseline2.interactIsPendingToBeUsed);
			snapshot.secondInteractIsPendingToBeUsed = (uint)predictor.PredictInt((int)snapshot.secondInteractIsPendingToBeUsed, (int)baseline1.secondInteractIsPendingToBeUsed, (int)baseline2.secondInteractIsPendingToBeUsed);
			snapshot.secondInteractBlockedUntilRelease = (uint)predictor.PredictInt((int)snapshot.secondInteractBlockedUntilRelease, (int)baseline1.secondInteractBlockedUntilRelease, (int)baseline2.secondInteractBlockedUntilRelease);
			snapshot.windupCanceled = (uint)predictor.PredictInt((int)snapshot.windupCanceled, (int)baseline1.windupCanceled, (int)baseline2.windupCanceled);
			snapshot.warmupTimer_startTick = (uint)predictor.PredictInt((int)snapshot.warmupTimer_startTick, (int)baseline1.warmupTimer_startTick, (int)baseline2.warmupTimer_startTick);
			snapshot.warmupTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.warmupTimer_targetTicks, (int)baseline1.warmupTimer_targetTicks, (int)baseline2.warmupTimer_targetTicks);
			snapshot.warmupTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.warmupTimer_stopTick, (int)baseline1.warmupTimer_stopTick, (int)baseline2.warmupTimer_stopTick);
			snapshot.lastInteractPressedOnCooldownTick = (uint)predictor.PredictInt((int)snapshot.lastInteractPressedOnCooldownTick, (int)baseline1.lastInteractPressedOnCooldownTick, (int)baseline2.lastInteractPressedOnCooldownTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.currentWindup != baseline.currentWindup) ? 1u : 0u);
			num |= (uint)((snapshot.secondaryUse_mechanic != baseline.secondaryUse_mechanic) ? 2 : 0);
			num |= (uint)((snapshot.secondaryUse_windupTiers != baseline.secondaryUse_windupTiers) ? 4 : 0);
			num |= (uint)((snapshot.secondaryUse_cancelAttackIfNotAtWindupTier != baseline.secondaryUse_cancelAttackIfNotAtWindupTier) ? 8 : 0);
			num |= (uint)((snapshot.secondaryUse_windupAreaSizeMultiplier != baseline.secondaryUse_windupAreaSizeMultiplier) ? 16 : 0);
			num |= (uint)((snapshot.secondaryUse_extraDamageMultiplier != baseline.secondaryUse_extraDamageMultiplier) ? 32 : 0);
			num |= (uint)((snapshot.secondaryUse_projectileSpeedMultiplier != baseline.secondaryUse_projectileSpeedMultiplier) ? 64 : 0);
			num |= (uint)((snapshot.secondaryUse_windupTime != baseline.secondaryUse_windupTime) ? 128 : 0);
			num |= (uint)((snapshot.secondaryUse_knockback != baseline.secondaryUse_knockback) ? 256 : 0);
			num |= (uint)((snapshot.secondaryUse_manaCostMultiplier != baseline.secondaryUse_manaCostMultiplier) ? 512 : 0);
			num |= (uint)((snapshot.secondaryUse_weaponEffectType != baseline.secondaryUse_weaponEffectType) ? 1024 : 0);
			num |= (uint)((snapshot.secondaryUse_useTerm != baseline.secondaryUse_useTerm) ? 2048 : 0);
			num |= (uint)((snapshot.secondaryUse_minionToSpawn != baseline.secondaryUse_minionToSpawn) ? 4096 : 0);
			num |= (uint)((snapshot.warmupCD_warmupTime != baseline.warmupCD_warmupTime) ? 8192 : 0);
			num |= (uint)((snapshot.windupTimer_startTick != baseline.windupTimer_startTick) ? 16384 : 0);
			num |= (uint)((snapshot.windupTimer_targetTicks != baseline.windupTimer_targetTicks) ? 32768 : 0);
			num |= (uint)((snapshot.windupTimer_stopTick != baseline.windupTimer_stopTick) ? 65536 : 0);
			num |= (uint)((snapshot.currentWindupMultiplier != baseline.currentWindupMultiplier) ? 131072 : 0);
			num |= (uint)((snapshot.atMaxWindup != baseline.atMaxWindup) ? 262144 : 0);
			num |= (uint)((snapshot.currentWindupTier != baseline.currentWindupTier) ? 524288 : 0);
			num |= (uint)((snapshot.summonMinion != baseline.summonMinion) ? 1048576 : 0);
			num |= (uint)((snapshot.interactIsPendingToBeUsed != baseline.interactIsPendingToBeUsed) ? 2097152 : 0);
			num |= (uint)((snapshot.secondInteractIsPendingToBeUsed != baseline.secondInteractIsPendingToBeUsed) ? 4194304 : 0);
			num |= (uint)((snapshot.secondInteractBlockedUntilRelease != baseline.secondInteractBlockedUntilRelease) ? 8388608 : 0);
			num |= (uint)((snapshot.windupCanceled != baseline.windupCanceled) ? 16777216 : 0);
			num |= (uint)((snapshot.warmupTimer_startTick != baseline.warmupTimer_startTick) ? 33554432 : 0);
			num |= (uint)((snapshot.warmupTimer_targetTicks != baseline.warmupTimer_targetTicks) ? 67108864 : 0);
			num |= (uint)((snapshot.warmupTimer_stopTick != baseline.warmupTimer_stopTick) ? 134217728 : 0);
			num |= (uint)((snapshot.lastInteractPressedOnCooldownTick != baseline.lastInteractPressedOnCooldownTick) ? 268435456 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 29);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 29);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentWindup, baseline.currentWindup, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_mechanic, baseline.secondaryUse_mechanic, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_windupTiers, baseline.secondaryUse_windupTiers, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_cancelAttackIfNotAtWindupTier, baseline.secondaryUse_cancelAttackIfNotAtWindupTier, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.secondaryUse_windupAreaSizeMultiplier, baseline.secondaryUse_windupAreaSizeMultiplier, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.secondaryUse_extraDamageMultiplier, baseline.secondaryUse_extraDamageMultiplier, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.secondaryUse_projectileSpeedMultiplier, baseline.secondaryUse_projectileSpeedMultiplier, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.secondaryUse_windupTime, baseline.secondaryUse_windupTime, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.secondaryUse_knockback, baseline.secondaryUse_knockback, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.secondaryUse_manaCostMultiplier, baseline.secondaryUse_manaCostMultiplier, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_weaponEffectType, baseline.secondaryUse_weaponEffectType, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_useTerm, baseline.secondaryUse_useTerm, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_minionToSpawn, baseline.secondaryUse_minionToSpawn, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.warmupCD_warmupTime, baseline.warmupCD_warmupTime, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.windupTimer_startTick, baseline.windupTimer_startTick, in compressionModel);
			}
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.windupTimer_targetTicks, baseline.windupTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.windupTimer_stopTick, baseline.windupTimer_stopTick, in compressionModel);
			}
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentWindupMultiplier, baseline.currentWindupMultiplier, in compressionModel);
			}
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.atMaxWindup, baseline.atMaxWindup, in compressionModel);
			}
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.currentWindupTier, baseline.currentWindupTier, in compressionModel);
			}
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.summonMinion, baseline.summonMinion, in compressionModel);
			}
			if ((num & 0x200000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.interactIsPendingToBeUsed, baseline.interactIsPendingToBeUsed, in compressionModel);
			}
			if ((num & 0x400000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.secondInteractIsPendingToBeUsed, baseline.secondInteractIsPendingToBeUsed, in compressionModel);
			}
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.secondInteractBlockedUntilRelease, baseline.secondInteractBlockedUntilRelease, in compressionModel);
			}
			if ((num & 0x1000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.windupCanceled, baseline.windupCanceled, in compressionModel);
			}
			if ((num & 0x2000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.warmupTimer_startTick, baseline.warmupTimer_startTick, in compressionModel);
			}
			if ((num & 0x4000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.warmupTimer_targetTicks, baseline.warmupTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x8000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.warmupTimer_stopTick, baseline.warmupTimer_stopTick, in compressionModel);
			}
			if ((num & 0x10000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.lastInteractPressedOnCooldownTick, baseline.lastInteractPressedOnCooldownTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.currentWindup != baseline.currentWindup) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentWindup, baseline.currentWindup, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_mechanic != baseline.secondaryUse_mechanic) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_mechanic, baseline.secondaryUse_mechanic, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_windupTiers != baseline.secondaryUse_windupTiers) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_windupTiers, baseline.secondaryUse_windupTiers, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_cancelAttackIfNotAtWindupTier != baseline.secondaryUse_cancelAttackIfNotAtWindupTier) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_cancelAttackIfNotAtWindupTier, baseline.secondaryUse_cancelAttackIfNotAtWindupTier, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_windupAreaSizeMultiplier != baseline.secondaryUse_windupAreaSizeMultiplier) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.secondaryUse_windupAreaSizeMultiplier, baseline.secondaryUse_windupAreaSizeMultiplier, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_extraDamageMultiplier != baseline.secondaryUse_extraDamageMultiplier) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.secondaryUse_extraDamageMultiplier, baseline.secondaryUse_extraDamageMultiplier, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_projectileSpeedMultiplier != baseline.secondaryUse_projectileSpeedMultiplier) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.secondaryUse_projectileSpeedMultiplier, baseline.secondaryUse_projectileSpeedMultiplier, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_windupTime != baseline.secondaryUse_windupTime) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.secondaryUse_windupTime, baseline.secondaryUse_windupTime, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_knockback != baseline.secondaryUse_knockback) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.secondaryUse_knockback, baseline.secondaryUse_knockback, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_manaCostMultiplier != baseline.secondaryUse_manaCostMultiplier) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.secondaryUse_manaCostMultiplier, baseline.secondaryUse_manaCostMultiplier, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_weaponEffectType != baseline.secondaryUse_weaponEffectType) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_weaponEffectType, baseline.secondaryUse_weaponEffectType, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_useTerm != baseline.secondaryUse_useTerm) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_useTerm, baseline.secondaryUse_useTerm, in compressionModel);
			}
			num |= (uint)((snapshot.secondaryUse_minionToSpawn != baseline.secondaryUse_minionToSpawn) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.secondaryUse_minionToSpawn, baseline.secondaryUse_minionToSpawn, in compressionModel);
			}
			num |= (uint)((snapshot.warmupCD_warmupTime != baseline.warmupCD_warmupTime) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.warmupCD_warmupTime, baseline.warmupCD_warmupTime, in compressionModel);
			}
			num |= (uint)((snapshot.windupTimer_startTick != baseline.windupTimer_startTick) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.windupTimer_startTick, baseline.windupTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.windupTimer_targetTicks != baseline.windupTimer_targetTicks) ? 32768 : 0);
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.windupTimer_targetTicks, baseline.windupTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.windupTimer_stopTick != baseline.windupTimer_stopTick) ? 65536 : 0);
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.windupTimer_stopTick, baseline.windupTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.currentWindupMultiplier != baseline.currentWindupMultiplier) ? 131072 : 0);
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentWindupMultiplier, baseline.currentWindupMultiplier, in compressionModel);
			}
			num |= (uint)((snapshot.atMaxWindup != baseline.atMaxWindup) ? 262144 : 0);
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.atMaxWindup, baseline.atMaxWindup, in compressionModel);
			}
			num |= (uint)((snapshot.currentWindupTier != baseline.currentWindupTier) ? 524288 : 0);
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.currentWindupTier, baseline.currentWindupTier, in compressionModel);
			}
			num |= (uint)((snapshot.summonMinion != baseline.summonMinion) ? 1048576 : 0);
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.summonMinion, baseline.summonMinion, in compressionModel);
			}
			num |= (uint)((snapshot.interactIsPendingToBeUsed != baseline.interactIsPendingToBeUsed) ? 2097152 : 0);
			if ((num & 0x200000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.interactIsPendingToBeUsed, baseline.interactIsPendingToBeUsed, in compressionModel);
			}
			num |= (uint)((snapshot.secondInteractIsPendingToBeUsed != baseline.secondInteractIsPendingToBeUsed) ? 4194304 : 0);
			if ((num & 0x400000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.secondInteractIsPendingToBeUsed, baseline.secondInteractIsPendingToBeUsed, in compressionModel);
			}
			num |= (uint)((snapshot.secondInteractBlockedUntilRelease != baseline.secondInteractBlockedUntilRelease) ? 8388608 : 0);
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.secondInteractBlockedUntilRelease, baseline.secondInteractBlockedUntilRelease, in compressionModel);
			}
			num |= (uint)((snapshot.windupCanceled != baseline.windupCanceled) ? 16777216 : 0);
			if ((num & 0x1000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.windupCanceled, baseline.windupCanceled, in compressionModel);
			}
			num |= (uint)((snapshot.warmupTimer_startTick != baseline.warmupTimer_startTick) ? 33554432 : 0);
			if ((num & 0x2000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.warmupTimer_startTick, baseline.warmupTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.warmupTimer_targetTicks != baseline.warmupTimer_targetTicks) ? 67108864 : 0);
			if ((num & 0x4000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.warmupTimer_targetTicks, baseline.warmupTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.warmupTimer_stopTick != baseline.warmupTimer_stopTick) ? 134217728 : 0);
			if ((num & 0x8000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.warmupTimer_stopTick, baseline.warmupTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.lastInteractPressedOnCooldownTick != baseline.lastInteractPressedOnCooldownTick) ? 268435456 : 0);
			if ((num & 0x10000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.lastInteractPressedOnCooldownTick, baseline.lastInteractPressedOnCooldownTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 29);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 29);
			if ((num & 1) != 0)
			{
				snapshot.currentWindup = reader.ReadPackedFloatDelta(baseline.currentWindup, in compressionModel);
			}
			else
			{
				snapshot.currentWindup = baseline.currentWindup;
			}
			if ((num & 2) != 0)
			{
				snapshot.secondaryUse_mechanic = reader.ReadPackedIntDelta(baseline.secondaryUse_mechanic, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_mechanic = baseline.secondaryUse_mechanic;
			}
			if ((num & 4) != 0)
			{
				snapshot.secondaryUse_windupTiers = reader.ReadPackedIntDelta(baseline.secondaryUse_windupTiers, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_windupTiers = baseline.secondaryUse_windupTiers;
			}
			if ((num & 8) != 0)
			{
				snapshot.secondaryUse_cancelAttackIfNotAtWindupTier = reader.ReadPackedIntDelta(baseline.secondaryUse_cancelAttackIfNotAtWindupTier, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_cancelAttackIfNotAtWindupTier = baseline.secondaryUse_cancelAttackIfNotAtWindupTier;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.secondaryUse_windupAreaSizeMultiplier = reader.ReadPackedFloatDelta(baseline.secondaryUse_windupAreaSizeMultiplier, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_windupAreaSizeMultiplier = baseline.secondaryUse_windupAreaSizeMultiplier;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.secondaryUse_extraDamageMultiplier = reader.ReadPackedFloatDelta(baseline.secondaryUse_extraDamageMultiplier, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_extraDamageMultiplier = baseline.secondaryUse_extraDamageMultiplier;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.secondaryUse_projectileSpeedMultiplier = reader.ReadPackedFloatDelta(baseline.secondaryUse_projectileSpeedMultiplier, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_projectileSpeedMultiplier = baseline.secondaryUse_projectileSpeedMultiplier;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.secondaryUse_windupTime = reader.ReadPackedFloatDelta(baseline.secondaryUse_windupTime, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_windupTime = baseline.secondaryUse_windupTime;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.secondaryUse_knockback = reader.ReadPackedUIntDelta(baseline.secondaryUse_knockback, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_knockback = baseline.secondaryUse_knockback;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.secondaryUse_manaCostMultiplier = reader.ReadPackedFloatDelta(baseline.secondaryUse_manaCostMultiplier, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_manaCostMultiplier = baseline.secondaryUse_manaCostMultiplier;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.secondaryUse_weaponEffectType = reader.ReadPackedIntDelta(baseline.secondaryUse_weaponEffectType, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_weaponEffectType = baseline.secondaryUse_weaponEffectType;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.secondaryUse_useTerm = reader.ReadPackedIntDelta(baseline.secondaryUse_useTerm, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_useTerm = baseline.secondaryUse_useTerm;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.secondaryUse_minionToSpawn = reader.ReadPackedIntDelta(baseline.secondaryUse_minionToSpawn, in compressionModel);
			}
			else
			{
				snapshot.secondaryUse_minionToSpawn = baseline.secondaryUse_minionToSpawn;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.warmupCD_warmupTime = reader.ReadPackedFloatDelta(baseline.warmupCD_warmupTime, in compressionModel);
			}
			else
			{
				snapshot.warmupCD_warmupTime = baseline.warmupCD_warmupTime;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.windupTimer_startTick = reader.ReadPackedUIntDelta(baseline.windupTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.windupTimer_startTick = baseline.windupTimer_startTick;
			}
			if ((num & 0x8000) != 0)
			{
				snapshot.windupTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.windupTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.windupTimer_targetTicks = baseline.windupTimer_targetTicks;
			}
			if ((num & 0x10000) != 0)
			{
				snapshot.windupTimer_stopTick = reader.ReadPackedUIntDelta(baseline.windupTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.windupTimer_stopTick = baseline.windupTimer_stopTick;
			}
			if ((num & 0x20000) != 0)
			{
				snapshot.currentWindupMultiplier = reader.ReadPackedFloatDelta(baseline.currentWindupMultiplier, in compressionModel);
			}
			else
			{
				snapshot.currentWindupMultiplier = baseline.currentWindupMultiplier;
			}
			if ((num & 0x40000) != 0)
			{
				snapshot.atMaxWindup = reader.ReadPackedUIntDelta(baseline.atMaxWindup, in compressionModel);
			}
			else
			{
				snapshot.atMaxWindup = baseline.atMaxWindup;
			}
			if ((num & 0x80000) != 0)
			{
				snapshot.currentWindupTier = reader.ReadPackedIntDelta(baseline.currentWindupTier, in compressionModel);
			}
			else
			{
				snapshot.currentWindupTier = baseline.currentWindupTier;
			}
			if ((num & 0x100000) != 0)
			{
				snapshot.summonMinion = reader.ReadPackedUIntDelta(baseline.summonMinion, in compressionModel);
			}
			else
			{
				snapshot.summonMinion = baseline.summonMinion;
			}
			if ((num & 0x200000) != 0)
			{
				snapshot.interactIsPendingToBeUsed = reader.ReadPackedUIntDelta(baseline.interactIsPendingToBeUsed, in compressionModel);
			}
			else
			{
				snapshot.interactIsPendingToBeUsed = baseline.interactIsPendingToBeUsed;
			}
			if ((num & 0x400000) != 0)
			{
				snapshot.secondInteractIsPendingToBeUsed = reader.ReadPackedUIntDelta(baseline.secondInteractIsPendingToBeUsed, in compressionModel);
			}
			else
			{
				snapshot.secondInteractIsPendingToBeUsed = baseline.secondInteractIsPendingToBeUsed;
			}
			if ((num & 0x800000) != 0)
			{
				snapshot.secondInteractBlockedUntilRelease = reader.ReadPackedUIntDelta(baseline.secondInteractBlockedUntilRelease, in compressionModel);
			}
			else
			{
				snapshot.secondInteractBlockedUntilRelease = baseline.secondInteractBlockedUntilRelease;
			}
			if ((num & 0x1000000) != 0)
			{
				snapshot.windupCanceled = reader.ReadPackedUIntDelta(baseline.windupCanceled, in compressionModel);
			}
			else
			{
				snapshot.windupCanceled = baseline.windupCanceled;
			}
			if ((num & 0x2000000) != 0)
			{
				snapshot.warmupTimer_startTick = reader.ReadPackedUIntDelta(baseline.warmupTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.warmupTimer_startTick = baseline.warmupTimer_startTick;
			}
			if ((num & 0x4000000) != 0)
			{
				snapshot.warmupTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.warmupTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.warmupTimer_targetTicks = baseline.warmupTimer_targetTicks;
			}
			if ((num & 0x8000000) != 0)
			{
				snapshot.warmupTimer_stopTick = reader.ReadPackedUIntDelta(baseline.warmupTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.warmupTimer_stopTick = baseline.warmupTimer_stopTick;
			}
			if ((num & 0x10000000) != 0)
			{
				snapshot.lastInteractPressedOnCooldownTick = reader.ReadPackedUIntDelta(baseline.lastInteractPressedOnCooldownTick, in compressionModel);
			}
			else
			{
				snapshot.lastInteractPressedOnCooldownTick = baseline.lastInteractPressedOnCooldownTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1352795039825984254uL,
					ComponentType = ComponentType.ReadWrite<EquipmentSlotCD>(),
					ComponentSize = UnsafeUtility.SizeOf<EquipmentSlotCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 29,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 8542065726680055644uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<EquipmentSlotCD, Snapshot, EquipmentSlotCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
