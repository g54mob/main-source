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
	public struct PlayerCustomizationCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public FixedString32Bytes customization_name;

			public ulong customization_body_m_low;

			public ulong customization_body_m_high;

			public ulong customization_skinColor_m_low;

			public ulong customization_skinColor_m_high;

			public ulong customization_hair_m_low;

			public ulong customization_hair_m_high;

			public ulong customization_hairColor_m_low;

			public ulong customization_hairColor_m_high;

			public ulong customization_hairShadeColor_m_low;

			public ulong customization_hairShadeColor_m_high;

			public ulong customization_eyes_m_low;

			public ulong customization_eyes_m_high;

			public ulong customization_eyesColor_m_low;

			public ulong customization_eyesColor_m_high;

			public ulong customization_shirtSkin_m_low;

			public ulong customization_shirtSkin_m_high;

			public ulong customization_shirtColor_m_low;

			public ulong customization_shirtColor_m_high;

			public ulong customization_pantsSkin_m_low;

			public ulong customization_pantsSkin_m_high;

			public ulong customization_pantsColor_m_low;

			public ulong customization_pantsColor_m_high;

			public ulong customization_helm_m_low;

			public ulong customization_helm_m_high;

			public ulong customization_breastArmor_m_low;

			public ulong customization_breastArmor_m_high;

			public ulong customization_pantsArmor_m_low;

			public ulong customization_pantsArmor_m_high;

			public uint customization_role;

			public int triggerCount;
		}

		private const int ChangeMaskBits = 31;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 31;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<PlayerCustomizationCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<PlayerCustomizationCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<PlayerCustomizationCD>(component), in GhostComponentSerializer.TypeCastReadonly<PlayerCustomizationCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in PlayerCustomizationCD component)
		{
			snapshot.customization_name = component.customization.name;
			snapshot.customization_body_m_low = component.customization.body.m_low;
			snapshot.customization_body_m_high = component.customization.body.m_high;
			snapshot.customization_skinColor_m_low = component.customization.skinColor.m_low;
			snapshot.customization_skinColor_m_high = component.customization.skinColor.m_high;
			snapshot.customization_hair_m_low = component.customization.hair.m_low;
			snapshot.customization_hair_m_high = component.customization.hair.m_high;
			snapshot.customization_hairColor_m_low = component.customization.hairColor.m_low;
			snapshot.customization_hairColor_m_high = component.customization.hairColor.m_high;
			snapshot.customization_hairShadeColor_m_low = component.customization.hairShadeColor.m_low;
			snapshot.customization_hairShadeColor_m_high = component.customization.hairShadeColor.m_high;
			snapshot.customization_eyes_m_low = component.customization.eyes.m_low;
			snapshot.customization_eyes_m_high = component.customization.eyes.m_high;
			snapshot.customization_eyesColor_m_low = component.customization.eyesColor.m_low;
			snapshot.customization_eyesColor_m_high = component.customization.eyesColor.m_high;
			snapshot.customization_shirtSkin_m_low = component.customization.shirtSkin.m_low;
			snapshot.customization_shirtSkin_m_high = component.customization.shirtSkin.m_high;
			snapshot.customization_shirtColor_m_low = component.customization.shirtColor.m_low;
			snapshot.customization_shirtColor_m_high = component.customization.shirtColor.m_high;
			snapshot.customization_pantsSkin_m_low = component.customization.pantsSkin.m_low;
			snapshot.customization_pantsSkin_m_high = component.customization.pantsSkin.m_high;
			snapshot.customization_pantsColor_m_low = component.customization.pantsColor.m_low;
			snapshot.customization_pantsColor_m_high = component.customization.pantsColor.m_high;
			snapshot.customization_helm_m_low = component.customization.helm.m_low;
			snapshot.customization_helm_m_high = component.customization.helm.m_high;
			snapshot.customization_breastArmor_m_low = component.customization.breastArmor.m_low;
			snapshot.customization_breastArmor_m_high = component.customization.breastArmor.m_high;
			snapshot.customization_pantsArmor_m_low = component.customization.pantsArmor.m_low;
			snapshot.customization_pantsArmor_m_high = component.customization.pantsArmor.m_high;
			snapshot.customization_role = component.customization.role;
			snapshot.triggerCount = component.triggerCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref PlayerCustomizationCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.customization.name = snapshotBefore.customization_name;
			component.customization.body.m_low = snapshotBefore.customization_body_m_low;
			component.customization.body.m_high = snapshotBefore.customization_body_m_high;
			component.customization.skinColor.m_low = snapshotBefore.customization_skinColor_m_low;
			component.customization.skinColor.m_high = snapshotBefore.customization_skinColor_m_high;
			component.customization.hair.m_low = snapshotBefore.customization_hair_m_low;
			component.customization.hair.m_high = snapshotBefore.customization_hair_m_high;
			component.customization.hairColor.m_low = snapshotBefore.customization_hairColor_m_low;
			component.customization.hairColor.m_high = snapshotBefore.customization_hairColor_m_high;
			component.customization.hairShadeColor.m_low = snapshotBefore.customization_hairShadeColor_m_low;
			component.customization.hairShadeColor.m_high = snapshotBefore.customization_hairShadeColor_m_high;
			component.customization.eyes.m_low = snapshotBefore.customization_eyes_m_low;
			component.customization.eyes.m_high = snapshotBefore.customization_eyes_m_high;
			component.customization.eyesColor.m_low = snapshotBefore.customization_eyesColor_m_low;
			component.customization.eyesColor.m_high = snapshotBefore.customization_eyesColor_m_high;
			component.customization.shirtSkin.m_low = snapshotBefore.customization_shirtSkin_m_low;
			component.customization.shirtSkin.m_high = snapshotBefore.customization_shirtSkin_m_high;
			component.customization.shirtColor.m_low = snapshotBefore.customization_shirtColor_m_low;
			component.customization.shirtColor.m_high = snapshotBefore.customization_shirtColor_m_high;
			component.customization.pantsSkin.m_low = snapshotBefore.customization_pantsSkin_m_low;
			component.customization.pantsSkin.m_high = snapshotBefore.customization_pantsSkin_m_high;
			component.customization.pantsColor.m_low = snapshotBefore.customization_pantsColor_m_low;
			component.customization.pantsColor.m_high = snapshotBefore.customization_pantsColor_m_high;
			component.customization.helm.m_low = snapshotBefore.customization_helm_m_low;
			component.customization.helm.m_high = snapshotBefore.customization_helm_m_high;
			component.customization.breastArmor.m_low = snapshotBefore.customization_breastArmor_m_low;
			component.customization.breastArmor.m_high = snapshotBefore.customization_breastArmor_m_high;
			component.customization.pantsArmor.m_low = snapshotBefore.customization_pantsArmor_m_low;
			component.customization.pantsArmor.m_high = snapshotBefore.customization_pantsArmor_m_high;
			component.customization.role = (byte)snapshotBefore.customization_role;
			component.triggerCount = snapshotBefore.triggerCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref PlayerCustomizationCD component, in PlayerCustomizationCD backup)
		{
			component.customization.name = backup.customization.name;
			component.customization.body.m_low = backup.customization.body.m_low;
			component.customization.body.m_high = backup.customization.body.m_high;
			component.customization.skinColor.m_low = backup.customization.skinColor.m_low;
			component.customization.skinColor.m_high = backup.customization.skinColor.m_high;
			component.customization.hair.m_low = backup.customization.hair.m_low;
			component.customization.hair.m_high = backup.customization.hair.m_high;
			component.customization.hairColor.m_low = backup.customization.hairColor.m_low;
			component.customization.hairColor.m_high = backup.customization.hairColor.m_high;
			component.customization.hairShadeColor.m_low = backup.customization.hairShadeColor.m_low;
			component.customization.hairShadeColor.m_high = backup.customization.hairShadeColor.m_high;
			component.customization.eyes.m_low = backup.customization.eyes.m_low;
			component.customization.eyes.m_high = backup.customization.eyes.m_high;
			component.customization.eyesColor.m_low = backup.customization.eyesColor.m_low;
			component.customization.eyesColor.m_high = backup.customization.eyesColor.m_high;
			component.customization.shirtSkin.m_low = backup.customization.shirtSkin.m_low;
			component.customization.shirtSkin.m_high = backup.customization.shirtSkin.m_high;
			component.customization.shirtColor.m_low = backup.customization.shirtColor.m_low;
			component.customization.shirtColor.m_high = backup.customization.shirtColor.m_high;
			component.customization.pantsSkin.m_low = backup.customization.pantsSkin.m_low;
			component.customization.pantsSkin.m_high = backup.customization.pantsSkin.m_high;
			component.customization.pantsColor.m_low = backup.customization.pantsColor.m_low;
			component.customization.pantsColor.m_high = backup.customization.pantsColor.m_high;
			component.customization.helm.m_low = backup.customization.helm.m_low;
			component.customization.helm.m_high = backup.customization.helm.m_high;
			component.customization.breastArmor.m_low = backup.customization.breastArmor.m_low;
			component.customization.breastArmor.m_high = backup.customization.breastArmor.m_high;
			component.customization.pantsArmor.m_low = backup.customization.pantsArmor.m_low;
			component.customization.pantsArmor.m_high = backup.customization.pantsArmor.m_high;
			component.customization.role = backup.customization.role;
			component.triggerCount = backup.triggerCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.customization_body_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_body_m_low, (long)baseline1.customization_body_m_low, (long)baseline2.customization_body_m_low);
			snapshot.customization_body_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_body_m_high, (long)baseline1.customization_body_m_high, (long)baseline2.customization_body_m_high);
			snapshot.customization_skinColor_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_skinColor_m_low, (long)baseline1.customization_skinColor_m_low, (long)baseline2.customization_skinColor_m_low);
			snapshot.customization_skinColor_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_skinColor_m_high, (long)baseline1.customization_skinColor_m_high, (long)baseline2.customization_skinColor_m_high);
			snapshot.customization_hair_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_hair_m_low, (long)baseline1.customization_hair_m_low, (long)baseline2.customization_hair_m_low);
			snapshot.customization_hair_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_hair_m_high, (long)baseline1.customization_hair_m_high, (long)baseline2.customization_hair_m_high);
			snapshot.customization_hairColor_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_hairColor_m_low, (long)baseline1.customization_hairColor_m_low, (long)baseline2.customization_hairColor_m_low);
			snapshot.customization_hairColor_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_hairColor_m_high, (long)baseline1.customization_hairColor_m_high, (long)baseline2.customization_hairColor_m_high);
			snapshot.customization_hairShadeColor_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_hairShadeColor_m_low, (long)baseline1.customization_hairShadeColor_m_low, (long)baseline2.customization_hairShadeColor_m_low);
			snapshot.customization_hairShadeColor_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_hairShadeColor_m_high, (long)baseline1.customization_hairShadeColor_m_high, (long)baseline2.customization_hairShadeColor_m_high);
			snapshot.customization_eyes_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_eyes_m_low, (long)baseline1.customization_eyes_m_low, (long)baseline2.customization_eyes_m_low);
			snapshot.customization_eyes_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_eyes_m_high, (long)baseline1.customization_eyes_m_high, (long)baseline2.customization_eyes_m_high);
			snapshot.customization_eyesColor_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_eyesColor_m_low, (long)baseline1.customization_eyesColor_m_low, (long)baseline2.customization_eyesColor_m_low);
			snapshot.customization_eyesColor_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_eyesColor_m_high, (long)baseline1.customization_eyesColor_m_high, (long)baseline2.customization_eyesColor_m_high);
			snapshot.customization_shirtSkin_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_shirtSkin_m_low, (long)baseline1.customization_shirtSkin_m_low, (long)baseline2.customization_shirtSkin_m_low);
			snapshot.customization_shirtSkin_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_shirtSkin_m_high, (long)baseline1.customization_shirtSkin_m_high, (long)baseline2.customization_shirtSkin_m_high);
			snapshot.customization_shirtColor_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_shirtColor_m_low, (long)baseline1.customization_shirtColor_m_low, (long)baseline2.customization_shirtColor_m_low);
			snapshot.customization_shirtColor_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_shirtColor_m_high, (long)baseline1.customization_shirtColor_m_high, (long)baseline2.customization_shirtColor_m_high);
			snapshot.customization_pantsSkin_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_pantsSkin_m_low, (long)baseline1.customization_pantsSkin_m_low, (long)baseline2.customization_pantsSkin_m_low);
			snapshot.customization_pantsSkin_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_pantsSkin_m_high, (long)baseline1.customization_pantsSkin_m_high, (long)baseline2.customization_pantsSkin_m_high);
			snapshot.customization_pantsColor_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_pantsColor_m_low, (long)baseline1.customization_pantsColor_m_low, (long)baseline2.customization_pantsColor_m_low);
			snapshot.customization_pantsColor_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_pantsColor_m_high, (long)baseline1.customization_pantsColor_m_high, (long)baseline2.customization_pantsColor_m_high);
			snapshot.customization_helm_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_helm_m_low, (long)baseline1.customization_helm_m_low, (long)baseline2.customization_helm_m_low);
			snapshot.customization_helm_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_helm_m_high, (long)baseline1.customization_helm_m_high, (long)baseline2.customization_helm_m_high);
			snapshot.customization_breastArmor_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_breastArmor_m_low, (long)baseline1.customization_breastArmor_m_low, (long)baseline2.customization_breastArmor_m_low);
			snapshot.customization_breastArmor_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_breastArmor_m_high, (long)baseline1.customization_breastArmor_m_high, (long)baseline2.customization_breastArmor_m_high);
			snapshot.customization_pantsArmor_m_low = (ulong)predictor.PredictLong((long)snapshot.customization_pantsArmor_m_low, (long)baseline1.customization_pantsArmor_m_low, (long)baseline2.customization_pantsArmor_m_low);
			snapshot.customization_pantsArmor_m_high = (ulong)predictor.PredictLong((long)snapshot.customization_pantsArmor_m_high, (long)baseline1.customization_pantsArmor_m_high, (long)baseline2.customization_pantsArmor_m_high);
			snapshot.customization_role = (uint)predictor.PredictInt((int)snapshot.customization_role, (int)baseline1.customization_role, (int)baseline2.customization_role);
			snapshot.triggerCount = predictor.PredictInt(snapshot.triggerCount, baseline1.triggerCount, baseline2.triggerCount);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((!snapshot.customization_name.Equals(baseline.customization_name)) ? 1u : 0u);
			num |= (uint)((snapshot.customization_body_m_low != baseline.customization_body_m_low) ? 2 : 0);
			num |= (uint)((snapshot.customization_body_m_high != baseline.customization_body_m_high) ? 4 : 0);
			num |= (uint)((snapshot.customization_skinColor_m_low != baseline.customization_skinColor_m_low) ? 8 : 0);
			num |= (uint)((snapshot.customization_skinColor_m_high != baseline.customization_skinColor_m_high) ? 16 : 0);
			num |= (uint)((snapshot.customization_hair_m_low != baseline.customization_hair_m_low) ? 32 : 0);
			num |= (uint)((snapshot.customization_hair_m_high != baseline.customization_hair_m_high) ? 64 : 0);
			num |= (uint)((snapshot.customization_hairColor_m_low != baseline.customization_hairColor_m_low) ? 128 : 0);
			num |= (uint)((snapshot.customization_hairColor_m_high != baseline.customization_hairColor_m_high) ? 256 : 0);
			num |= (uint)((snapshot.customization_hairShadeColor_m_low != baseline.customization_hairShadeColor_m_low) ? 512 : 0);
			num |= (uint)((snapshot.customization_hairShadeColor_m_high != baseline.customization_hairShadeColor_m_high) ? 1024 : 0);
			num |= (uint)((snapshot.customization_eyes_m_low != baseline.customization_eyes_m_low) ? 2048 : 0);
			num |= (uint)((snapshot.customization_eyes_m_high != baseline.customization_eyes_m_high) ? 4096 : 0);
			num |= (uint)((snapshot.customization_eyesColor_m_low != baseline.customization_eyesColor_m_low) ? 8192 : 0);
			num |= (uint)((snapshot.customization_eyesColor_m_high != baseline.customization_eyesColor_m_high) ? 16384 : 0);
			num |= (uint)((snapshot.customization_shirtSkin_m_low != baseline.customization_shirtSkin_m_low) ? 32768 : 0);
			num |= (uint)((snapshot.customization_shirtSkin_m_high != baseline.customization_shirtSkin_m_high) ? 65536 : 0);
			num |= (uint)((snapshot.customization_shirtColor_m_low != baseline.customization_shirtColor_m_low) ? 131072 : 0);
			num |= (uint)((snapshot.customization_shirtColor_m_high != baseline.customization_shirtColor_m_high) ? 262144 : 0);
			num |= (uint)((snapshot.customization_pantsSkin_m_low != baseline.customization_pantsSkin_m_low) ? 524288 : 0);
			num |= (uint)((snapshot.customization_pantsSkin_m_high != baseline.customization_pantsSkin_m_high) ? 1048576 : 0);
			num |= (uint)((snapshot.customization_pantsColor_m_low != baseline.customization_pantsColor_m_low) ? 2097152 : 0);
			num |= (uint)((snapshot.customization_pantsColor_m_high != baseline.customization_pantsColor_m_high) ? 4194304 : 0);
			num |= (uint)((snapshot.customization_helm_m_low != baseline.customization_helm_m_low) ? 8388608 : 0);
			num |= (uint)((snapshot.customization_helm_m_high != baseline.customization_helm_m_high) ? 16777216 : 0);
			num |= (uint)((snapshot.customization_breastArmor_m_low != baseline.customization_breastArmor_m_low) ? 33554432 : 0);
			num |= (uint)((snapshot.customization_breastArmor_m_high != baseline.customization_breastArmor_m_high) ? 67108864 : 0);
			num |= (uint)((snapshot.customization_pantsArmor_m_low != baseline.customization_pantsArmor_m_low) ? 134217728 : 0);
			num |= (uint)((snapshot.customization_pantsArmor_m_high != baseline.customization_pantsArmor_m_high) ? 268435456 : 0);
			num |= (uint)((snapshot.customization_role != baseline.customization_role) ? 536870912 : 0);
			num |= (uint)((snapshot.triggerCount != baseline.triggerCount) ? 1073741824 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 31);
			if ((num & 1) != 0)
			{
				writer.WritePackedFixedString32Delta(snapshot.customization_name, baseline.customization_name, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_body_m_low, baseline.customization_body_m_low, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_body_m_high, baseline.customization_body_m_high, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_skinColor_m_low, baseline.customization_skinColor_m_low, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_skinColor_m_high, baseline.customization_skinColor_m_high, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hair_m_low, baseline.customization_hair_m_low, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hair_m_high, baseline.customization_hair_m_high, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hairColor_m_low, baseline.customization_hairColor_m_low, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hairColor_m_high, baseline.customization_hairColor_m_high, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hairShadeColor_m_low, baseline.customization_hairShadeColor_m_low, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hairShadeColor_m_high, baseline.customization_hairShadeColor_m_high, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_eyes_m_low, baseline.customization_eyes_m_low, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_eyes_m_high, baseline.customization_eyes_m_high, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_eyesColor_m_low, baseline.customization_eyesColor_m_low, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_eyesColor_m_high, baseline.customization_eyesColor_m_high, in compressionModel);
			}
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_shirtSkin_m_low, baseline.customization_shirtSkin_m_low, in compressionModel);
			}
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_shirtSkin_m_high, baseline.customization_shirtSkin_m_high, in compressionModel);
			}
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_shirtColor_m_low, baseline.customization_shirtColor_m_low, in compressionModel);
			}
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_shirtColor_m_high, baseline.customization_shirtColor_m_high, in compressionModel);
			}
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsSkin_m_low, baseline.customization_pantsSkin_m_low, in compressionModel);
			}
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsSkin_m_high, baseline.customization_pantsSkin_m_high, in compressionModel);
			}
			if ((num & 0x200000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsColor_m_low, baseline.customization_pantsColor_m_low, in compressionModel);
			}
			if ((num & 0x400000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsColor_m_high, baseline.customization_pantsColor_m_high, in compressionModel);
			}
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_helm_m_low, baseline.customization_helm_m_low, in compressionModel);
			}
			if ((num & 0x1000000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_helm_m_high, baseline.customization_helm_m_high, in compressionModel);
			}
			if ((num & 0x2000000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_breastArmor_m_low, baseline.customization_breastArmor_m_low, in compressionModel);
			}
			if ((num & 0x4000000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_breastArmor_m_high, baseline.customization_breastArmor_m_high, in compressionModel);
			}
			if ((num & 0x8000000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsArmor_m_low, baseline.customization_pantsArmor_m_low, in compressionModel);
			}
			if ((num & 0x10000000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsArmor_m_high, baseline.customization_pantsArmor_m_high, in compressionModel);
			}
			if ((num & 0x20000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.customization_role, baseline.customization_role, in compressionModel);
			}
			if ((num & 0x40000000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.triggerCount, baseline.triggerCount, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((!snapshot.customization_name.Equals(baseline.customization_name)) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedFixedString32Delta(snapshot.customization_name, baseline.customization_name, in compressionModel);
			}
			num |= (uint)((snapshot.customization_body_m_low != baseline.customization_body_m_low) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_body_m_low, baseline.customization_body_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_body_m_high != baseline.customization_body_m_high) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_body_m_high, baseline.customization_body_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_skinColor_m_low != baseline.customization_skinColor_m_low) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_skinColor_m_low, baseline.customization_skinColor_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_skinColor_m_high != baseline.customization_skinColor_m_high) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_skinColor_m_high, baseline.customization_skinColor_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_hair_m_low != baseline.customization_hair_m_low) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hair_m_low, baseline.customization_hair_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_hair_m_high != baseline.customization_hair_m_high) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hair_m_high, baseline.customization_hair_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_hairColor_m_low != baseline.customization_hairColor_m_low) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hairColor_m_low, baseline.customization_hairColor_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_hairColor_m_high != baseline.customization_hairColor_m_high) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hairColor_m_high, baseline.customization_hairColor_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_hairShadeColor_m_low != baseline.customization_hairShadeColor_m_low) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hairShadeColor_m_low, baseline.customization_hairShadeColor_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_hairShadeColor_m_high != baseline.customization_hairShadeColor_m_high) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_hairShadeColor_m_high, baseline.customization_hairShadeColor_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_eyes_m_low != baseline.customization_eyes_m_low) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_eyes_m_low, baseline.customization_eyes_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_eyes_m_high != baseline.customization_eyes_m_high) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_eyes_m_high, baseline.customization_eyes_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_eyesColor_m_low != baseline.customization_eyesColor_m_low) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_eyesColor_m_low, baseline.customization_eyesColor_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_eyesColor_m_high != baseline.customization_eyesColor_m_high) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_eyesColor_m_high, baseline.customization_eyesColor_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_shirtSkin_m_low != baseline.customization_shirtSkin_m_low) ? 32768 : 0);
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_shirtSkin_m_low, baseline.customization_shirtSkin_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_shirtSkin_m_high != baseline.customization_shirtSkin_m_high) ? 65536 : 0);
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_shirtSkin_m_high, baseline.customization_shirtSkin_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_shirtColor_m_low != baseline.customization_shirtColor_m_low) ? 131072 : 0);
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_shirtColor_m_low, baseline.customization_shirtColor_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_shirtColor_m_high != baseline.customization_shirtColor_m_high) ? 262144 : 0);
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_shirtColor_m_high, baseline.customization_shirtColor_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_pantsSkin_m_low != baseline.customization_pantsSkin_m_low) ? 524288 : 0);
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsSkin_m_low, baseline.customization_pantsSkin_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_pantsSkin_m_high != baseline.customization_pantsSkin_m_high) ? 1048576 : 0);
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsSkin_m_high, baseline.customization_pantsSkin_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_pantsColor_m_low != baseline.customization_pantsColor_m_low) ? 2097152 : 0);
			if ((num & 0x200000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsColor_m_low, baseline.customization_pantsColor_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_pantsColor_m_high != baseline.customization_pantsColor_m_high) ? 4194304 : 0);
			if ((num & 0x400000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsColor_m_high, baseline.customization_pantsColor_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_helm_m_low != baseline.customization_helm_m_low) ? 8388608 : 0);
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_helm_m_low, baseline.customization_helm_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_helm_m_high != baseline.customization_helm_m_high) ? 16777216 : 0);
			if ((num & 0x1000000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_helm_m_high, baseline.customization_helm_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_breastArmor_m_low != baseline.customization_breastArmor_m_low) ? 33554432 : 0);
			if ((num & 0x2000000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_breastArmor_m_low, baseline.customization_breastArmor_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_breastArmor_m_high != baseline.customization_breastArmor_m_high) ? 67108864 : 0);
			if ((num & 0x4000000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_breastArmor_m_high, baseline.customization_breastArmor_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_pantsArmor_m_low != baseline.customization_pantsArmor_m_low) ? 134217728 : 0);
			if ((num & 0x8000000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsArmor_m_low, baseline.customization_pantsArmor_m_low, in compressionModel);
			}
			num |= (uint)((snapshot.customization_pantsArmor_m_high != baseline.customization_pantsArmor_m_high) ? 268435456 : 0);
			if ((num & 0x10000000) != 0)
			{
				writer.WritePackedULongDelta(snapshot.customization_pantsArmor_m_high, baseline.customization_pantsArmor_m_high, in compressionModel);
			}
			num |= (uint)((snapshot.customization_role != baseline.customization_role) ? 536870912 : 0);
			if ((num & 0x20000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.customization_role, baseline.customization_role, in compressionModel);
			}
			num |= (uint)((snapshot.triggerCount != baseline.triggerCount) ? 1073741824 : 0);
			if ((num & 0x40000000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.triggerCount, baseline.triggerCount, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 31);
			if ((num & 1) != 0)
			{
				snapshot.customization_name = reader.ReadPackedFixedString32Delta(baseline.customization_name, in compressionModel);
			}
			else
			{
				snapshot.customization_name = baseline.customization_name;
			}
			if ((num & 2) != 0)
			{
				snapshot.customization_body_m_low = reader.ReadPackedULongDelta(baseline.customization_body_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_body_m_low = baseline.customization_body_m_low;
			}
			if ((num & 4) != 0)
			{
				snapshot.customization_body_m_high = reader.ReadPackedULongDelta(baseline.customization_body_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_body_m_high = baseline.customization_body_m_high;
			}
			if ((num & 8) != 0)
			{
				snapshot.customization_skinColor_m_low = reader.ReadPackedULongDelta(baseline.customization_skinColor_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_skinColor_m_low = baseline.customization_skinColor_m_low;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.customization_skinColor_m_high = reader.ReadPackedULongDelta(baseline.customization_skinColor_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_skinColor_m_high = baseline.customization_skinColor_m_high;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.customization_hair_m_low = reader.ReadPackedULongDelta(baseline.customization_hair_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_hair_m_low = baseline.customization_hair_m_low;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.customization_hair_m_high = reader.ReadPackedULongDelta(baseline.customization_hair_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_hair_m_high = baseline.customization_hair_m_high;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.customization_hairColor_m_low = reader.ReadPackedULongDelta(baseline.customization_hairColor_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_hairColor_m_low = baseline.customization_hairColor_m_low;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.customization_hairColor_m_high = reader.ReadPackedULongDelta(baseline.customization_hairColor_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_hairColor_m_high = baseline.customization_hairColor_m_high;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.customization_hairShadeColor_m_low = reader.ReadPackedULongDelta(baseline.customization_hairShadeColor_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_hairShadeColor_m_low = baseline.customization_hairShadeColor_m_low;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.customization_hairShadeColor_m_high = reader.ReadPackedULongDelta(baseline.customization_hairShadeColor_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_hairShadeColor_m_high = baseline.customization_hairShadeColor_m_high;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.customization_eyes_m_low = reader.ReadPackedULongDelta(baseline.customization_eyes_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_eyes_m_low = baseline.customization_eyes_m_low;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.customization_eyes_m_high = reader.ReadPackedULongDelta(baseline.customization_eyes_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_eyes_m_high = baseline.customization_eyes_m_high;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.customization_eyesColor_m_low = reader.ReadPackedULongDelta(baseline.customization_eyesColor_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_eyesColor_m_low = baseline.customization_eyesColor_m_low;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.customization_eyesColor_m_high = reader.ReadPackedULongDelta(baseline.customization_eyesColor_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_eyesColor_m_high = baseline.customization_eyesColor_m_high;
			}
			if ((num & 0x8000) != 0)
			{
				snapshot.customization_shirtSkin_m_low = reader.ReadPackedULongDelta(baseline.customization_shirtSkin_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_shirtSkin_m_low = baseline.customization_shirtSkin_m_low;
			}
			if ((num & 0x10000) != 0)
			{
				snapshot.customization_shirtSkin_m_high = reader.ReadPackedULongDelta(baseline.customization_shirtSkin_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_shirtSkin_m_high = baseline.customization_shirtSkin_m_high;
			}
			if ((num & 0x20000) != 0)
			{
				snapshot.customization_shirtColor_m_low = reader.ReadPackedULongDelta(baseline.customization_shirtColor_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_shirtColor_m_low = baseline.customization_shirtColor_m_low;
			}
			if ((num & 0x40000) != 0)
			{
				snapshot.customization_shirtColor_m_high = reader.ReadPackedULongDelta(baseline.customization_shirtColor_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_shirtColor_m_high = baseline.customization_shirtColor_m_high;
			}
			if ((num & 0x80000) != 0)
			{
				snapshot.customization_pantsSkin_m_low = reader.ReadPackedULongDelta(baseline.customization_pantsSkin_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_pantsSkin_m_low = baseline.customization_pantsSkin_m_low;
			}
			if ((num & 0x100000) != 0)
			{
				snapshot.customization_pantsSkin_m_high = reader.ReadPackedULongDelta(baseline.customization_pantsSkin_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_pantsSkin_m_high = baseline.customization_pantsSkin_m_high;
			}
			if ((num & 0x200000) != 0)
			{
				snapshot.customization_pantsColor_m_low = reader.ReadPackedULongDelta(baseline.customization_pantsColor_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_pantsColor_m_low = baseline.customization_pantsColor_m_low;
			}
			if ((num & 0x400000) != 0)
			{
				snapshot.customization_pantsColor_m_high = reader.ReadPackedULongDelta(baseline.customization_pantsColor_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_pantsColor_m_high = baseline.customization_pantsColor_m_high;
			}
			if ((num & 0x800000) != 0)
			{
				snapshot.customization_helm_m_low = reader.ReadPackedULongDelta(baseline.customization_helm_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_helm_m_low = baseline.customization_helm_m_low;
			}
			if ((num & 0x1000000) != 0)
			{
				snapshot.customization_helm_m_high = reader.ReadPackedULongDelta(baseline.customization_helm_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_helm_m_high = baseline.customization_helm_m_high;
			}
			if ((num & 0x2000000) != 0)
			{
				snapshot.customization_breastArmor_m_low = reader.ReadPackedULongDelta(baseline.customization_breastArmor_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_breastArmor_m_low = baseline.customization_breastArmor_m_low;
			}
			if ((num & 0x4000000) != 0)
			{
				snapshot.customization_breastArmor_m_high = reader.ReadPackedULongDelta(baseline.customization_breastArmor_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_breastArmor_m_high = baseline.customization_breastArmor_m_high;
			}
			if ((num & 0x8000000) != 0)
			{
				snapshot.customization_pantsArmor_m_low = reader.ReadPackedULongDelta(baseline.customization_pantsArmor_m_low, in compressionModel);
			}
			else
			{
				snapshot.customization_pantsArmor_m_low = baseline.customization_pantsArmor_m_low;
			}
			if ((num & 0x10000000) != 0)
			{
				snapshot.customization_pantsArmor_m_high = reader.ReadPackedULongDelta(baseline.customization_pantsArmor_m_high, in compressionModel);
			}
			else
			{
				snapshot.customization_pantsArmor_m_high = baseline.customization_pantsArmor_m_high;
			}
			if ((num & 0x20000000) != 0)
			{
				snapshot.customization_role = reader.ReadPackedUIntDelta(baseline.customization_role, in compressionModel);
			}
			else
			{
				snapshot.customization_role = baseline.customization_role;
			}
			if ((num & 0x40000000) != 0)
			{
				snapshot.triggerCount = reader.ReadPackedIntDelta(baseline.triggerCount, in compressionModel);
			}
			else
			{
				snapshot.triggerCount = baseline.triggerCount;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 8108725983747953090uL,
					ComponentType = ComponentType.ReadWrite<PlayerCustomizationCD>(),
					ComponentSize = UnsafeUtility.SizeOf<PlayerCustomizationCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 31,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 14704247468094646638uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<PlayerCustomizationCD, Snapshot, PlayerCustomizationCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
