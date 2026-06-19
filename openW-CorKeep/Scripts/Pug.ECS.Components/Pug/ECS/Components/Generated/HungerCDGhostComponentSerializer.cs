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
	public struct HungerCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int hunger;

			public float previousPosition_x;

			public float previousPosition_y;

			public float previousPosition_z;

			public float accumulatedMovement;

			public uint canConsumeHunger;

			public float standingStillTimer;

			public float consistentRunningTimer;

			public float loseConsistentRunningTimer;

			public float damageFromRunningTimer;

			public float loseDamageFromRunningStreakTimer;
		}

		private const int ChangeMaskBits = 9;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 9;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<HungerCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<HungerCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<HungerCD>(component), in GhostComponentSerializer.TypeCastReadonly<HungerCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in HungerCD component)
		{
			snapshot.hunger = component.hunger;
			snapshot.previousPosition_x = component.previousPosition.x;
			snapshot.previousPosition_y = component.previousPosition.y;
			snapshot.previousPosition_z = component.previousPosition.z;
			snapshot.accumulatedMovement = component.accumulatedMovement;
			snapshot.canConsumeHunger = (component.canConsumeHunger ? 1u : 0u);
			snapshot.standingStillTimer = component.standingStillTimer;
			snapshot.consistentRunningTimer = component.consistentRunningTimer;
			snapshot.loseConsistentRunningTimer = component.loseConsistentRunningTimer;
			snapshot.damageFromRunningTimer = component.damageFromRunningTimer;
			snapshot.loseDamageFromRunningStreakTimer = component.loseDamageFromRunningStreakTimer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref HungerCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.hunger = snapshotBefore.hunger;
			component.previousPosition = new float3(snapshotBefore.previousPosition_x, snapshotBefore.previousPosition_y, snapshotBefore.previousPosition_z);
			component.accumulatedMovement = snapshotBefore.accumulatedMovement;
			component.canConsumeHunger = snapshotBefore.canConsumeHunger != 0;
			component.standingStillTimer = snapshotBefore.standingStillTimer;
			component.consistentRunningTimer = snapshotBefore.consistentRunningTimer;
			component.loseConsistentRunningTimer = snapshotBefore.loseConsistentRunningTimer;
			component.damageFromRunningTimer = snapshotBefore.damageFromRunningTimer;
			component.loseDamageFromRunningStreakTimer = snapshotBefore.loseDamageFromRunningStreakTimer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref HungerCD component, in HungerCD backup)
		{
			component.hunger = backup.hunger;
			component.previousPosition.x = backup.previousPosition.x;
			component.previousPosition.y = backup.previousPosition.y;
			component.previousPosition.z = backup.previousPosition.z;
			component.accumulatedMovement = backup.accumulatedMovement;
			component.canConsumeHunger = backup.canConsumeHunger;
			component.standingStillTimer = backup.standingStillTimer;
			component.consistentRunningTimer = backup.consistentRunningTimer;
			component.loseConsistentRunningTimer = backup.loseConsistentRunningTimer;
			component.damageFromRunningTimer = backup.damageFromRunningTimer;
			component.loseDamageFromRunningStreakTimer = backup.loseDamageFromRunningStreakTimer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.hunger = predictor.PredictInt(snapshot.hunger, baseline1.hunger, baseline2.hunger);
			snapshot.canConsumeHunger = (uint)predictor.PredictInt((int)snapshot.canConsumeHunger, (int)baseline1.canConsumeHunger, (int)baseline2.canConsumeHunger);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.hunger != baseline.hunger) ? 1u : 0u);
			num |= (uint)((snapshot.previousPosition_x != baseline.previousPosition_x) ? 2 : 0);
			num |= (uint)((snapshot.previousPosition_y != baseline.previousPosition_y) ? 2 : 0);
			num |= (uint)((snapshot.previousPosition_z != baseline.previousPosition_z) ? 2 : 0);
			num |= (uint)((snapshot.accumulatedMovement != baseline.accumulatedMovement) ? 4 : 0);
			num |= (uint)((snapshot.canConsumeHunger != baseline.canConsumeHunger) ? 8 : 0);
			num |= (uint)((snapshot.standingStillTimer != baseline.standingStillTimer) ? 16 : 0);
			num |= (uint)((snapshot.consistentRunningTimer != baseline.consistentRunningTimer) ? 32 : 0);
			num |= (uint)((snapshot.loseConsistentRunningTimer != baseline.loseConsistentRunningTimer) ? 64 : 0);
			num |= (uint)((snapshot.damageFromRunningTimer != baseline.damageFromRunningTimer) ? 128 : 0);
			num |= (uint)((snapshot.loseDamageFromRunningStreakTimer != baseline.loseDamageFromRunningStreakTimer) ? 256 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 9);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 9);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.hunger, baseline.hunger, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousPosition_x, baseline.previousPosition_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousPosition_y, baseline.previousPosition_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousPosition_z, baseline.previousPosition_z, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.accumulatedMovement, baseline.accumulatedMovement, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.canConsumeHunger, baseline.canConsumeHunger, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.standingStillTimer, baseline.standingStillTimer, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.consistentRunningTimer, baseline.consistentRunningTimer, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.loseConsistentRunningTimer, baseline.loseConsistentRunningTimer, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.damageFromRunningTimer, baseline.damageFromRunningTimer, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.loseDamageFromRunningStreakTimer, baseline.loseDamageFromRunningStreakTimer, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.hunger != baseline.hunger) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.hunger, baseline.hunger, in compressionModel);
			}
			num |= (uint)((snapshot.previousPosition_x != baseline.previousPosition_x) ? 2 : 0);
			num |= (uint)((snapshot.previousPosition_y != baseline.previousPosition_y) ? 2 : 0);
			num |= (uint)((snapshot.previousPosition_z != baseline.previousPosition_z) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousPosition_x, baseline.previousPosition_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousPosition_y, baseline.previousPosition_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousPosition_z, baseline.previousPosition_z, in compressionModel);
			}
			num |= (uint)((snapshot.accumulatedMovement != baseline.accumulatedMovement) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.accumulatedMovement, baseline.accumulatedMovement, in compressionModel);
			}
			num |= (uint)((snapshot.canConsumeHunger != baseline.canConsumeHunger) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.canConsumeHunger, baseline.canConsumeHunger, in compressionModel);
			}
			num |= (uint)((snapshot.standingStillTimer != baseline.standingStillTimer) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.standingStillTimer, baseline.standingStillTimer, in compressionModel);
			}
			num |= (uint)((snapshot.consistentRunningTimer != baseline.consistentRunningTimer) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.consistentRunningTimer, baseline.consistentRunningTimer, in compressionModel);
			}
			num |= (uint)((snapshot.loseConsistentRunningTimer != baseline.loseConsistentRunningTimer) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.loseConsistentRunningTimer, baseline.loseConsistentRunningTimer, in compressionModel);
			}
			num |= (uint)((snapshot.damageFromRunningTimer != baseline.damageFromRunningTimer) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.damageFromRunningTimer, baseline.damageFromRunningTimer, in compressionModel);
			}
			num |= (uint)((snapshot.loseDamageFromRunningStreakTimer != baseline.loseDamageFromRunningStreakTimer) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.loseDamageFromRunningStreakTimer, baseline.loseDamageFromRunningStreakTimer, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 9);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 9);
			if ((num & 1) != 0)
			{
				snapshot.hunger = reader.ReadPackedIntDelta(baseline.hunger, in compressionModel);
			}
			else
			{
				snapshot.hunger = baseline.hunger;
			}
			if ((num & 2) != 0)
			{
				snapshot.previousPosition_x = reader.ReadPackedFloatDelta(baseline.previousPosition_x, in compressionModel);
			}
			else
			{
				snapshot.previousPosition_x = baseline.previousPosition_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.previousPosition_y = reader.ReadPackedFloatDelta(baseline.previousPosition_y, in compressionModel);
			}
			else
			{
				snapshot.previousPosition_y = baseline.previousPosition_y;
			}
			if ((num & 2) != 0)
			{
				snapshot.previousPosition_z = reader.ReadPackedFloatDelta(baseline.previousPosition_z, in compressionModel);
			}
			else
			{
				snapshot.previousPosition_z = baseline.previousPosition_z;
			}
			if ((num & 4) != 0)
			{
				snapshot.accumulatedMovement = reader.ReadPackedFloatDelta(baseline.accumulatedMovement, in compressionModel);
			}
			else
			{
				snapshot.accumulatedMovement = baseline.accumulatedMovement;
			}
			if ((num & 8) != 0)
			{
				snapshot.canConsumeHunger = reader.ReadPackedUIntDelta(baseline.canConsumeHunger, in compressionModel);
			}
			else
			{
				snapshot.canConsumeHunger = baseline.canConsumeHunger;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.standingStillTimer = reader.ReadPackedFloatDelta(baseline.standingStillTimer, in compressionModel);
			}
			else
			{
				snapshot.standingStillTimer = baseline.standingStillTimer;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.consistentRunningTimer = reader.ReadPackedFloatDelta(baseline.consistentRunningTimer, in compressionModel);
			}
			else
			{
				snapshot.consistentRunningTimer = baseline.consistentRunningTimer;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.loseConsistentRunningTimer = reader.ReadPackedFloatDelta(baseline.loseConsistentRunningTimer, in compressionModel);
			}
			else
			{
				snapshot.loseConsistentRunningTimer = baseline.loseConsistentRunningTimer;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.damageFromRunningTimer = reader.ReadPackedFloatDelta(baseline.damageFromRunningTimer, in compressionModel);
			}
			else
			{
				snapshot.damageFromRunningTimer = baseline.damageFromRunningTimer;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.loseDamageFromRunningStreakTimer = reader.ReadPackedFloatDelta(baseline.loseDamageFromRunningStreakTimer, in compressionModel);
			}
			else
			{
				snapshot.loseDamageFromRunningStreakTimer = baseline.loseDamageFromRunningStreakTimer;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 7455028707620208954uL,
					ComponentType = ComponentType.ReadWrite<HungerCD>(),
					ComponentSize = UnsafeUtility.SizeOf<HungerCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 9,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 10702058291001203924uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<HungerCD, Snapshot, HungerCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
