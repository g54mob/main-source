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
	public struct RangeAttackStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public float aimDirection_x;

			public float aimDirection_y;

			public float aimDirection_z;

			public float shootDirection_x;

			public float shootDirection_y;

			public float shootDirection_z;

			public int shotsDone;
		}

		private const int ChangeMaskBits = 3;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 3;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<RangeAttackStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<RangeAttackStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<RangeAttackStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<RangeAttackStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in RangeAttackStateCD component)
		{
			snapshot.aimDirection_x = component.aimDirection.x;
			snapshot.aimDirection_y = component.aimDirection.y;
			snapshot.aimDirection_z = component.aimDirection.z;
			snapshot.shootDirection_x = component.shootDirection.x;
			snapshot.shootDirection_y = component.shootDirection.y;
			snapshot.shootDirection_z = component.shootDirection.z;
			snapshot.shotsDone = component.shotsDone;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref RangeAttackStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.aimDirection = new float3(snapshotBefore.aimDirection_x, snapshotBefore.aimDirection_y, snapshotBefore.aimDirection_z);
			component.shootDirection = new float3(snapshotBefore.shootDirection_x, snapshotBefore.shootDirection_y, snapshotBefore.shootDirection_z);
			component.shotsDone = snapshotBefore.shotsDone;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref RangeAttackStateCD component, in RangeAttackStateCD backup)
		{
			component.aimDirection.x = backup.aimDirection.x;
			component.aimDirection.y = backup.aimDirection.y;
			component.aimDirection.z = backup.aimDirection.z;
			component.shootDirection.x = backup.shootDirection.x;
			component.shootDirection.y = backup.shootDirection.y;
			component.shootDirection.z = backup.shootDirection.z;
			component.shotsDone = backup.shotsDone;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.shotsDone = predictor.PredictInt(snapshot.shotsDone, baseline1.shotsDone, baseline2.shotsDone);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.aimDirection_x != baseline.aimDirection_x) ? 1u : 0u);
			num |= (uint)((snapshot.aimDirection_y != baseline.aimDirection_y) ? 1 : 0);
			num |= (uint)((snapshot.aimDirection_z != baseline.aimDirection_z) ? 1 : 0);
			num |= (uint)((snapshot.shootDirection_x != baseline.shootDirection_x) ? 2 : 0);
			num |= (uint)((snapshot.shootDirection_y != baseline.shootDirection_y) ? 2 : 0);
			num |= (uint)((snapshot.shootDirection_z != baseline.shootDirection_z) ? 2 : 0);
			num |= (uint)((snapshot.shotsDone != baseline.shotsDone) ? 4 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 3);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.aimDirection_x, baseline.aimDirection_x, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.aimDirection_y, baseline.aimDirection_y, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.aimDirection_z, baseline.aimDirection_z, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.shootDirection_x, baseline.shootDirection_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.shootDirection_y, baseline.shootDirection_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.shootDirection_z, baseline.shootDirection_z, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.shotsDone, baseline.shotsDone, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.aimDirection_x != baseline.aimDirection_x) ? 1u : 0u);
			num |= (uint)((snapshot.aimDirection_y != baseline.aimDirection_y) ? 1 : 0);
			num |= (uint)((snapshot.aimDirection_z != baseline.aimDirection_z) ? 1 : 0);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.aimDirection_x, baseline.aimDirection_x, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.aimDirection_y, baseline.aimDirection_y, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.aimDirection_z, baseline.aimDirection_z, in compressionModel);
			}
			num |= (uint)((snapshot.shootDirection_x != baseline.shootDirection_x) ? 2 : 0);
			num |= (uint)((snapshot.shootDirection_y != baseline.shootDirection_y) ? 2 : 0);
			num |= (uint)((snapshot.shootDirection_z != baseline.shootDirection_z) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.shootDirection_x, baseline.shootDirection_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.shootDirection_y, baseline.shootDirection_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.shootDirection_z, baseline.shootDirection_z, in compressionModel);
			}
			num |= (uint)((snapshot.shotsDone != baseline.shotsDone) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.shotsDone, baseline.shotsDone, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 3);
			if ((num & 1) != 0)
			{
				snapshot.aimDirection_x = reader.ReadPackedFloatDelta(baseline.aimDirection_x, in compressionModel);
			}
			else
			{
				snapshot.aimDirection_x = baseline.aimDirection_x;
			}
			if ((num & 1) != 0)
			{
				snapshot.aimDirection_y = reader.ReadPackedFloatDelta(baseline.aimDirection_y, in compressionModel);
			}
			else
			{
				snapshot.aimDirection_y = baseline.aimDirection_y;
			}
			if ((num & 1) != 0)
			{
				snapshot.aimDirection_z = reader.ReadPackedFloatDelta(baseline.aimDirection_z, in compressionModel);
			}
			else
			{
				snapshot.aimDirection_z = baseline.aimDirection_z;
			}
			if ((num & 2) != 0)
			{
				snapshot.shootDirection_x = reader.ReadPackedFloatDelta(baseline.shootDirection_x, in compressionModel);
			}
			else
			{
				snapshot.shootDirection_x = baseline.shootDirection_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.shootDirection_y = reader.ReadPackedFloatDelta(baseline.shootDirection_y, in compressionModel);
			}
			else
			{
				snapshot.shootDirection_y = baseline.shootDirection_y;
			}
			if ((num & 2) != 0)
			{
				snapshot.shootDirection_z = reader.ReadPackedFloatDelta(baseline.shootDirection_z, in compressionModel);
			}
			else
			{
				snapshot.shootDirection_z = baseline.shootDirection_z;
			}
			if ((num & 4) != 0)
			{
				snapshot.shotsDone = reader.ReadPackedIntDelta(baseline.shotsDone, in compressionModel);
			}
			else
			{
				snapshot.shotsDone = baseline.shotsDone;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1966819302090705106uL,
					ComponentType = ComponentType.ReadWrite<RangeAttackStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<RangeAttackStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 3,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 1053430860618556690uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<RangeAttackStateCD, Snapshot, RangeAttackStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
