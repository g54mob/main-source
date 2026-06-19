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
	public struct BouncingProjectileCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int prevBounceTile_x;

			public int prevBounceTile_y;

			public int bounceCount;

			public int maxBounceCount;
		}

		private const int ChangeMaskBits = 4;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 4;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<BouncingProjectileCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<BouncingProjectileCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<BouncingProjectileCD>(component), in GhostComponentSerializer.TypeCastReadonly<BouncingProjectileCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in BouncingProjectileCD component)
		{
			snapshot.prevBounceTile_x = component.prevBounceTile.x;
			snapshot.prevBounceTile_y = component.prevBounceTile.y;
			snapshot.bounceCount = component.bounceCount;
			snapshot.maxBounceCount = component.maxBounceCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref BouncingProjectileCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.prevBounceTile.x = snapshotBefore.prevBounceTile_x;
			component.prevBounceTile.y = snapshotBefore.prevBounceTile_y;
			component.bounceCount = snapshotBefore.bounceCount;
			component.maxBounceCount = snapshotBefore.maxBounceCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref BouncingProjectileCD component, in BouncingProjectileCD backup)
		{
			component.prevBounceTile.x = backup.prevBounceTile.x;
			component.prevBounceTile.y = backup.prevBounceTile.y;
			component.bounceCount = backup.bounceCount;
			component.maxBounceCount = backup.maxBounceCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.prevBounceTile_x = predictor.PredictInt(snapshot.prevBounceTile_x, baseline1.prevBounceTile_x, baseline2.prevBounceTile_x);
			snapshot.prevBounceTile_y = predictor.PredictInt(snapshot.prevBounceTile_y, baseline1.prevBounceTile_y, baseline2.prevBounceTile_y);
			snapshot.bounceCount = predictor.PredictInt(snapshot.bounceCount, baseline1.bounceCount, baseline2.bounceCount);
			snapshot.maxBounceCount = predictor.PredictInt(snapshot.maxBounceCount, baseline1.maxBounceCount, baseline2.maxBounceCount);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.prevBounceTile_x != baseline.prevBounceTile_x) ? 1u : 0u);
			num |= (uint)((snapshot.prevBounceTile_y != baseline.prevBounceTile_y) ? 2 : 0);
			num |= (uint)((snapshot.bounceCount != baseline.bounceCount) ? 4 : 0);
			num |= (uint)((snapshot.maxBounceCount != baseline.maxBounceCount) ? 8 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 4);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.prevBounceTile_x, baseline.prevBounceTile_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.prevBounceTile_y, baseline.prevBounceTile_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bounceCount, baseline.bounceCount, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.maxBounceCount, baseline.maxBounceCount, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.prevBounceTile_x != baseline.prevBounceTile_x) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.prevBounceTile_x, baseline.prevBounceTile_x, in compressionModel);
			}
			num |= (uint)((snapshot.prevBounceTile_y != baseline.prevBounceTile_y) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.prevBounceTile_y, baseline.prevBounceTile_y, in compressionModel);
			}
			num |= (uint)((snapshot.bounceCount != baseline.bounceCount) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bounceCount, baseline.bounceCount, in compressionModel);
			}
			num |= (uint)((snapshot.maxBounceCount != baseline.maxBounceCount) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.maxBounceCount, baseline.maxBounceCount, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 4);
			if ((num & 1) != 0)
			{
				snapshot.prevBounceTile_x = reader.ReadPackedIntDelta(baseline.prevBounceTile_x, in compressionModel);
			}
			else
			{
				snapshot.prevBounceTile_x = baseline.prevBounceTile_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.prevBounceTile_y = reader.ReadPackedIntDelta(baseline.prevBounceTile_y, in compressionModel);
			}
			else
			{
				snapshot.prevBounceTile_y = baseline.prevBounceTile_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.bounceCount = reader.ReadPackedIntDelta(baseline.bounceCount, in compressionModel);
			}
			else
			{
				snapshot.bounceCount = baseline.bounceCount;
			}
			if ((num & 8) != 0)
			{
				snapshot.maxBounceCount = reader.ReadPackedIntDelta(baseline.maxBounceCount, in compressionModel);
			}
			else
			{
				snapshot.maxBounceCount = baseline.maxBounceCount;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 4321598702592082872uL,
					ComponentType = ComponentType.ReadWrite<BouncingProjectileCD>(),
					ComponentSize = UnsafeUtility.SizeOf<BouncingProjectileCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 4,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 7775255850831409970uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<BouncingProjectileCD, Snapshot, BouncingProjectileCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
