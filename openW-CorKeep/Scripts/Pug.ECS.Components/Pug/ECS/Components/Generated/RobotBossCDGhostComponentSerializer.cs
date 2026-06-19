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
	public struct RobotBossCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int internalState;

			public uint fellInLava;

			public uint animateTheLegs;

			public int legBrokenTime;

			public uint legsAreVulnerable;

			public uint isActuallyMoving;

			public int rangeAttackPattern;

			public float rangeAttackDirection_x;

			public float rangeAttackDirection_y;

			public float rangeAttackDirection_z;
		}

		private const int ChangeMaskBits = 8;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 8;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<RobotBossCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<RobotBossCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<RobotBossCD>(component), in GhostComponentSerializer.TypeCastReadonly<RobotBossCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in RobotBossCD component)
		{
			snapshot.internalState = (int)component.internalState;
			snapshot.fellInLava = (component.fellInLava ? 1u : 0u);
			snapshot.animateTheLegs = (component.animateTheLegs ? 1u : 0u);
			snapshot.legBrokenTime = component.legBrokenTime;
			snapshot.legsAreVulnerable = (component.legsAreVulnerable ? 1u : 0u);
			snapshot.isActuallyMoving = (component.isActuallyMoving ? 1u : 0u);
			snapshot.rangeAttackPattern = (int)component.rangeAttackPattern;
			snapshot.rangeAttackDirection_x = component.rangeAttackDirection.x;
			snapshot.rangeAttackDirection_y = component.rangeAttackDirection.y;
			snapshot.rangeAttackDirection_z = component.rangeAttackDirection.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref RobotBossCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.internalState = (RobotBossInternalState)snapshotBefore.internalState;
			component.fellInLava = snapshotBefore.fellInLava != 0;
			component.animateTheLegs = snapshotBefore.animateTheLegs != 0;
			component.legBrokenTime = snapshotBefore.legBrokenTime;
			component.legsAreVulnerable = snapshotBefore.legsAreVulnerable != 0;
			component.isActuallyMoving = snapshotBefore.isActuallyMoving != 0;
			component.rangeAttackPattern = (RobotBossAttackPattern)snapshotBefore.rangeAttackPattern;
			component.rangeAttackDirection = new float3(snapshotBefore.rangeAttackDirection_x, snapshotBefore.rangeAttackDirection_y, snapshotBefore.rangeAttackDirection_z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref RobotBossCD component, in RobotBossCD backup)
		{
			component.internalState = backup.internalState;
			component.fellInLava = backup.fellInLava;
			component.animateTheLegs = backup.animateTheLegs;
			component.legBrokenTime = backup.legBrokenTime;
			component.legsAreVulnerable = backup.legsAreVulnerable;
			component.isActuallyMoving = backup.isActuallyMoving;
			component.rangeAttackPattern = backup.rangeAttackPattern;
			component.rangeAttackDirection.x = backup.rangeAttackDirection.x;
			component.rangeAttackDirection.y = backup.rangeAttackDirection.y;
			component.rangeAttackDirection.z = backup.rangeAttackDirection.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.internalState = predictor.PredictInt(snapshot.internalState, baseline1.internalState, baseline2.internalState);
			snapshot.fellInLava = (uint)predictor.PredictInt((int)snapshot.fellInLava, (int)baseline1.fellInLava, (int)baseline2.fellInLava);
			snapshot.animateTheLegs = (uint)predictor.PredictInt((int)snapshot.animateTheLegs, (int)baseline1.animateTheLegs, (int)baseline2.animateTheLegs);
			snapshot.legBrokenTime = predictor.PredictInt(snapshot.legBrokenTime, baseline1.legBrokenTime, baseline2.legBrokenTime);
			snapshot.legsAreVulnerable = (uint)predictor.PredictInt((int)snapshot.legsAreVulnerable, (int)baseline1.legsAreVulnerable, (int)baseline2.legsAreVulnerable);
			snapshot.isActuallyMoving = (uint)predictor.PredictInt((int)snapshot.isActuallyMoving, (int)baseline1.isActuallyMoving, (int)baseline2.isActuallyMoving);
			snapshot.rangeAttackPattern = predictor.PredictInt(snapshot.rangeAttackPattern, baseline1.rangeAttackPattern, baseline2.rangeAttackPattern);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.internalState != baseline.internalState) ? 1u : 0u);
			num |= (uint)((snapshot.fellInLava != baseline.fellInLava) ? 2 : 0);
			num |= (uint)((snapshot.animateTheLegs != baseline.animateTheLegs) ? 4 : 0);
			num |= (uint)((snapshot.legBrokenTime != baseline.legBrokenTime) ? 8 : 0);
			num |= (uint)((snapshot.legsAreVulnerable != baseline.legsAreVulnerable) ? 16 : 0);
			num |= (uint)((snapshot.isActuallyMoving != baseline.isActuallyMoving) ? 32 : 0);
			num |= (uint)((snapshot.rangeAttackPattern != baseline.rangeAttackPattern) ? 64 : 0);
			num |= (uint)((snapshot.rangeAttackDirection_x != baseline.rangeAttackDirection_x) ? 128 : 0);
			num |= (uint)((snapshot.rangeAttackDirection_y != baseline.rangeAttackDirection_y) ? 128 : 0);
			num |= (uint)((snapshot.rangeAttackDirection_z != baseline.rangeAttackDirection_z) ? 128 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 8);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.internalState, baseline.internalState, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fellInLava, baseline.fellInLava, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.animateTheLegs, baseline.animateTheLegs, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.legBrokenTime, baseline.legBrokenTime, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.legsAreVulnerable, baseline.legsAreVulnerable, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isActuallyMoving, baseline.isActuallyMoving, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.rangeAttackPattern, baseline.rangeAttackPattern, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.rangeAttackDirection_x, baseline.rangeAttackDirection_x, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.rangeAttackDirection_y, baseline.rangeAttackDirection_y, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.rangeAttackDirection_z, baseline.rangeAttackDirection_z, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.internalState != baseline.internalState) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.internalState, baseline.internalState, in compressionModel);
			}
			num |= (uint)((snapshot.fellInLava != baseline.fellInLava) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fellInLava, baseline.fellInLava, in compressionModel);
			}
			num |= (uint)((snapshot.animateTheLegs != baseline.animateTheLegs) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.animateTheLegs, baseline.animateTheLegs, in compressionModel);
			}
			num |= (uint)((snapshot.legBrokenTime != baseline.legBrokenTime) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.legBrokenTime, baseline.legBrokenTime, in compressionModel);
			}
			num |= (uint)((snapshot.legsAreVulnerable != baseline.legsAreVulnerable) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.legsAreVulnerable, baseline.legsAreVulnerable, in compressionModel);
			}
			num |= (uint)((snapshot.isActuallyMoving != baseline.isActuallyMoving) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isActuallyMoving, baseline.isActuallyMoving, in compressionModel);
			}
			num |= (uint)((snapshot.rangeAttackPattern != baseline.rangeAttackPattern) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.rangeAttackPattern, baseline.rangeAttackPattern, in compressionModel);
			}
			num |= (uint)((snapshot.rangeAttackDirection_x != baseline.rangeAttackDirection_x) ? 128 : 0);
			num |= (uint)((snapshot.rangeAttackDirection_y != baseline.rangeAttackDirection_y) ? 128 : 0);
			num |= (uint)((snapshot.rangeAttackDirection_z != baseline.rangeAttackDirection_z) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.rangeAttackDirection_x, baseline.rangeAttackDirection_x, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.rangeAttackDirection_y, baseline.rangeAttackDirection_y, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.rangeAttackDirection_z, baseline.rangeAttackDirection_z, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 8);
			if ((num & 1) != 0)
			{
				snapshot.internalState = reader.ReadPackedIntDelta(baseline.internalState, in compressionModel);
			}
			else
			{
				snapshot.internalState = baseline.internalState;
			}
			if ((num & 2) != 0)
			{
				snapshot.fellInLava = reader.ReadPackedUIntDelta(baseline.fellInLava, in compressionModel);
			}
			else
			{
				snapshot.fellInLava = baseline.fellInLava;
			}
			if ((num & 4) != 0)
			{
				snapshot.animateTheLegs = reader.ReadPackedUIntDelta(baseline.animateTheLegs, in compressionModel);
			}
			else
			{
				snapshot.animateTheLegs = baseline.animateTheLegs;
			}
			if ((num & 8) != 0)
			{
				snapshot.legBrokenTime = reader.ReadPackedIntDelta(baseline.legBrokenTime, in compressionModel);
			}
			else
			{
				snapshot.legBrokenTime = baseline.legBrokenTime;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.legsAreVulnerable = reader.ReadPackedUIntDelta(baseline.legsAreVulnerable, in compressionModel);
			}
			else
			{
				snapshot.legsAreVulnerable = baseline.legsAreVulnerable;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.isActuallyMoving = reader.ReadPackedUIntDelta(baseline.isActuallyMoving, in compressionModel);
			}
			else
			{
				snapshot.isActuallyMoving = baseline.isActuallyMoving;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.rangeAttackPattern = reader.ReadPackedIntDelta(baseline.rangeAttackPattern, in compressionModel);
			}
			else
			{
				snapshot.rangeAttackPattern = baseline.rangeAttackPattern;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.rangeAttackDirection_x = reader.ReadPackedFloatDelta(baseline.rangeAttackDirection_x, in compressionModel);
			}
			else
			{
				snapshot.rangeAttackDirection_x = baseline.rangeAttackDirection_x;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.rangeAttackDirection_y = reader.ReadPackedFloatDelta(baseline.rangeAttackDirection_y, in compressionModel);
			}
			else
			{
				snapshot.rangeAttackDirection_y = baseline.rangeAttackDirection_y;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.rangeAttackDirection_z = reader.ReadPackedFloatDelta(baseline.rangeAttackDirection_z, in compressionModel);
			}
			else
			{
				snapshot.rangeAttackDirection_z = baseline.rangeAttackDirection_z;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 957689210179932508uL,
					ComponentType = ComponentType.ReadWrite<RobotBossCD>(),
					ComponentSize = UnsafeUtility.SizeOf<RobotBossCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 8,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 4707385604239488412uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<RobotBossCD, Snapshot, RobotBossCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
