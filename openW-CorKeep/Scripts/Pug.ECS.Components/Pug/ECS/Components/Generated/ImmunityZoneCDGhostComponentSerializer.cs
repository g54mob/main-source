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
	public struct ImmunityZoneCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public float radius;

			public uint removeImmunityZone;

			public int offset_x;

			public int offset_y;

			public uint useRectangularBounds;

			public int rectangularWidth;

			public int rectangularHeight;
		}

		private const int ChangeMaskBits = 7;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 7;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ImmunityZoneCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ImmunityZoneCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ImmunityZoneCD>(component), in GhostComponentSerializer.TypeCastReadonly<ImmunityZoneCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ImmunityZoneCD component)
		{
			snapshot.radius = component.radius;
			snapshot.removeImmunityZone = (component.removeImmunityZone ? 1u : 0u);
			snapshot.offset_x = component.offset.x;
			snapshot.offset_y = component.offset.y;
			snapshot.useRectangularBounds = (component.useRectangularBounds ? 1u : 0u);
			snapshot.rectangularWidth = component.rectangularWidth;
			snapshot.rectangularHeight = component.rectangularHeight;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ImmunityZoneCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.radius = snapshotBefore.radius;
			component.removeImmunityZone = snapshotBefore.removeImmunityZone != 0;
			component.offset.x = snapshotBefore.offset_x;
			component.offset.y = snapshotBefore.offset_y;
			component.useRectangularBounds = snapshotBefore.useRectangularBounds != 0;
			component.rectangularWidth = snapshotBefore.rectangularWidth;
			component.rectangularHeight = snapshotBefore.rectangularHeight;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ImmunityZoneCD component, in ImmunityZoneCD backup)
		{
			component.radius = backup.radius;
			component.removeImmunityZone = backup.removeImmunityZone;
			component.offset.x = backup.offset.x;
			component.offset.y = backup.offset.y;
			component.useRectangularBounds = backup.useRectangularBounds;
			component.rectangularWidth = backup.rectangularWidth;
			component.rectangularHeight = backup.rectangularHeight;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.removeImmunityZone = (uint)predictor.PredictInt((int)snapshot.removeImmunityZone, (int)baseline1.removeImmunityZone, (int)baseline2.removeImmunityZone);
			snapshot.offset_x = predictor.PredictInt(snapshot.offset_x, baseline1.offset_x, baseline2.offset_x);
			snapshot.offset_y = predictor.PredictInt(snapshot.offset_y, baseline1.offset_y, baseline2.offset_y);
			snapshot.useRectangularBounds = (uint)predictor.PredictInt((int)snapshot.useRectangularBounds, (int)baseline1.useRectangularBounds, (int)baseline2.useRectangularBounds);
			snapshot.rectangularWidth = predictor.PredictInt(snapshot.rectangularWidth, baseline1.rectangularWidth, baseline2.rectangularWidth);
			snapshot.rectangularHeight = predictor.PredictInt(snapshot.rectangularHeight, baseline1.rectangularHeight, baseline2.rectangularHeight);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.radius != baseline.radius) ? 1u : 0u);
			num |= (uint)((snapshot.removeImmunityZone != baseline.removeImmunityZone) ? 2 : 0);
			num |= (uint)((snapshot.offset_x != baseline.offset_x) ? 4 : 0);
			num |= (uint)((snapshot.offset_y != baseline.offset_y) ? 8 : 0);
			num |= (uint)((snapshot.useRectangularBounds != baseline.useRectangularBounds) ? 16 : 0);
			num |= (uint)((snapshot.rectangularWidth != baseline.rectangularWidth) ? 32 : 0);
			num |= (uint)((snapshot.rectangularHeight != baseline.rectangularHeight) ? 64 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.radius, baseline.radius, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.removeImmunityZone, baseline.removeImmunityZone, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.offset_x, baseline.offset_x, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.offset_y, baseline.offset_y, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.useRectangularBounds, baseline.useRectangularBounds, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.rectangularWidth, baseline.rectangularWidth, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.rectangularHeight, baseline.rectangularHeight, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.radius != baseline.radius) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.radius, baseline.radius, in compressionModel);
			}
			num |= (uint)((snapshot.removeImmunityZone != baseline.removeImmunityZone) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.removeImmunityZone, baseline.removeImmunityZone, in compressionModel);
			}
			num |= (uint)((snapshot.offset_x != baseline.offset_x) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.offset_x, baseline.offset_x, in compressionModel);
			}
			num |= (uint)((snapshot.offset_y != baseline.offset_y) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.offset_y, baseline.offset_y, in compressionModel);
			}
			num |= (uint)((snapshot.useRectangularBounds != baseline.useRectangularBounds) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.useRectangularBounds, baseline.useRectangularBounds, in compressionModel);
			}
			num |= (uint)((snapshot.rectangularWidth != baseline.rectangularWidth) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.rectangularWidth, baseline.rectangularWidth, in compressionModel);
			}
			num |= (uint)((snapshot.rectangularHeight != baseline.rectangularHeight) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.rectangularHeight, baseline.rectangularHeight, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				snapshot.radius = reader.ReadPackedFloatDelta(baseline.radius, in compressionModel);
			}
			else
			{
				snapshot.radius = baseline.radius;
			}
			if ((num & 2) != 0)
			{
				snapshot.removeImmunityZone = reader.ReadPackedUIntDelta(baseline.removeImmunityZone, in compressionModel);
			}
			else
			{
				snapshot.removeImmunityZone = baseline.removeImmunityZone;
			}
			if ((num & 4) != 0)
			{
				snapshot.offset_x = reader.ReadPackedIntDelta(baseline.offset_x, in compressionModel);
			}
			else
			{
				snapshot.offset_x = baseline.offset_x;
			}
			if ((num & 8) != 0)
			{
				snapshot.offset_y = reader.ReadPackedIntDelta(baseline.offset_y, in compressionModel);
			}
			else
			{
				snapshot.offset_y = baseline.offset_y;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.useRectangularBounds = reader.ReadPackedUIntDelta(baseline.useRectangularBounds, in compressionModel);
			}
			else
			{
				snapshot.useRectangularBounds = baseline.useRectangularBounds;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.rectangularWidth = reader.ReadPackedIntDelta(baseline.rectangularWidth, in compressionModel);
			}
			else
			{
				snapshot.rectangularWidth = baseline.rectangularWidth;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.rectangularHeight = reader.ReadPackedIntDelta(baseline.rectangularHeight, in compressionModel);
			}
			else
			{
				snapshot.rectangularHeight = baseline.rectangularHeight;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1966819302090705106uL,
					ComponentType = ComponentType.ReadWrite<ImmunityZoneCD>(),
					ComponentSize = UnsafeUtility.SizeOf<ImmunityZoneCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 7,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 12677657948645863474uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ImmunityZoneCD, Snapshot, ImmunityZoneCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
