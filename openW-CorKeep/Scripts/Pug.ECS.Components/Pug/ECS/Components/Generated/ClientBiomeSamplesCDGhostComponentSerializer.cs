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
	public struct ClientBiomeSamplesCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int BasePosition_x;

			public int BasePosition_y;

			public int LinearBaseIndex;

			public uint Biomes_offset0000;

			public uint Biomes_offset0004;

			public uint Biomes_offset0008;

			public uint Biomes_offset0012;

			public uint Biomes_offset0016;

			public uint Biomes_offset0020;

			public uint Biomes_offset0024;

			public uint Biomes_offset0028;

			public uint Biomes_offset0032;

			public uint Biomes_offset0036;

			public uint Biomes_offset0040;

			public uint Biomes_offset0044;

			public uint Biomes_offset0048;

			public uint Biomes_offset0052;

			public uint Biomes_offset0056;

			public uint Biomes_offset0060;
		}

		private const int ChangeMaskBits = 19;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 19;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ClientBiomeSamplesCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ClientBiomeSamplesCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ClientBiomeSamplesCD>(component), in GhostComponentSerializer.TypeCastReadonly<ClientBiomeSamplesCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ClientBiomeSamplesCD component)
		{
			snapshot.BasePosition_x = component.BasePosition.x;
			snapshot.BasePosition_y = component.BasePosition.y;
			snapshot.LinearBaseIndex = component.LinearBaseIndex;
			snapshot.Biomes_offset0000 = component.Biomes.offset0000;
			snapshot.Biomes_offset0004 = component.Biomes.offset0004;
			snapshot.Biomes_offset0008 = component.Biomes.offset0008;
			snapshot.Biomes_offset0012 = component.Biomes.offset0012;
			snapshot.Biomes_offset0016 = component.Biomes.offset0016;
			snapshot.Biomes_offset0020 = component.Biomes.offset0020;
			snapshot.Biomes_offset0024 = component.Biomes.offset0024;
			snapshot.Biomes_offset0028 = component.Biomes.offset0028;
			snapshot.Biomes_offset0032 = component.Biomes.offset0032;
			snapshot.Biomes_offset0036 = component.Biomes.offset0036;
			snapshot.Biomes_offset0040 = component.Biomes.offset0040;
			snapshot.Biomes_offset0044 = component.Biomes.offset0044;
			snapshot.Biomes_offset0048 = component.Biomes.offset0048;
			snapshot.Biomes_offset0052 = component.Biomes.offset0052;
			snapshot.Biomes_offset0056 = component.Biomes.offset0056;
			snapshot.Biomes_offset0060 = component.Biomes.offset0060;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ClientBiomeSamplesCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.BasePosition.x = snapshotBefore.BasePosition_x;
			component.BasePosition.y = snapshotBefore.BasePosition_y;
			component.LinearBaseIndex = snapshotBefore.LinearBaseIndex;
			component.Biomes.offset0000 = snapshotBefore.Biomes_offset0000;
			component.Biomes.offset0004 = snapshotBefore.Biomes_offset0004;
			component.Biomes.offset0008 = snapshotBefore.Biomes_offset0008;
			component.Biomes.offset0012 = snapshotBefore.Biomes_offset0012;
			component.Biomes.offset0016 = snapshotBefore.Biomes_offset0016;
			component.Biomes.offset0020 = snapshotBefore.Biomes_offset0020;
			component.Biomes.offset0024 = snapshotBefore.Biomes_offset0024;
			component.Biomes.offset0028 = snapshotBefore.Biomes_offset0028;
			component.Biomes.offset0032 = snapshotBefore.Biomes_offset0032;
			component.Biomes.offset0036 = snapshotBefore.Biomes_offset0036;
			component.Biomes.offset0040 = snapshotBefore.Biomes_offset0040;
			component.Biomes.offset0044 = snapshotBefore.Biomes_offset0044;
			component.Biomes.offset0048 = snapshotBefore.Biomes_offset0048;
			component.Biomes.offset0052 = snapshotBefore.Biomes_offset0052;
			component.Biomes.offset0056 = snapshotBefore.Biomes_offset0056;
			component.Biomes.offset0060 = snapshotBefore.Biomes_offset0060;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ClientBiomeSamplesCD component, in ClientBiomeSamplesCD backup)
		{
			component.BasePosition.x = backup.BasePosition.x;
			component.BasePosition.y = backup.BasePosition.y;
			component.LinearBaseIndex = backup.LinearBaseIndex;
			component.Biomes.offset0000 = backup.Biomes.offset0000;
			component.Biomes.offset0004 = backup.Biomes.offset0004;
			component.Biomes.offset0008 = backup.Biomes.offset0008;
			component.Biomes.offset0012 = backup.Biomes.offset0012;
			component.Biomes.offset0016 = backup.Biomes.offset0016;
			component.Biomes.offset0020 = backup.Biomes.offset0020;
			component.Biomes.offset0024 = backup.Biomes.offset0024;
			component.Biomes.offset0028 = backup.Biomes.offset0028;
			component.Biomes.offset0032 = backup.Biomes.offset0032;
			component.Biomes.offset0036 = backup.Biomes.offset0036;
			component.Biomes.offset0040 = backup.Biomes.offset0040;
			component.Biomes.offset0044 = backup.Biomes.offset0044;
			component.Biomes.offset0048 = backup.Biomes.offset0048;
			component.Biomes.offset0052 = backup.Biomes.offset0052;
			component.Biomes.offset0056 = backup.Biomes.offset0056;
			component.Biomes.offset0060 = backup.Biomes.offset0060;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.BasePosition_x = predictor.PredictInt(snapshot.BasePosition_x, baseline1.BasePosition_x, baseline2.BasePosition_x);
			snapshot.BasePosition_y = predictor.PredictInt(snapshot.BasePosition_y, baseline1.BasePosition_y, baseline2.BasePosition_y);
			snapshot.LinearBaseIndex = predictor.PredictInt(snapshot.LinearBaseIndex, baseline1.LinearBaseIndex, baseline2.LinearBaseIndex);
			snapshot.Biomes_offset0000 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0000, (int)baseline1.Biomes_offset0000, (int)baseline2.Biomes_offset0000);
			snapshot.Biomes_offset0004 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0004, (int)baseline1.Biomes_offset0004, (int)baseline2.Biomes_offset0004);
			snapshot.Biomes_offset0008 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0008, (int)baseline1.Biomes_offset0008, (int)baseline2.Biomes_offset0008);
			snapshot.Biomes_offset0012 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0012, (int)baseline1.Biomes_offset0012, (int)baseline2.Biomes_offset0012);
			snapshot.Biomes_offset0016 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0016, (int)baseline1.Biomes_offset0016, (int)baseline2.Biomes_offset0016);
			snapshot.Biomes_offset0020 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0020, (int)baseline1.Biomes_offset0020, (int)baseline2.Biomes_offset0020);
			snapshot.Biomes_offset0024 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0024, (int)baseline1.Biomes_offset0024, (int)baseline2.Biomes_offset0024);
			snapshot.Biomes_offset0028 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0028, (int)baseline1.Biomes_offset0028, (int)baseline2.Biomes_offset0028);
			snapshot.Biomes_offset0032 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0032, (int)baseline1.Biomes_offset0032, (int)baseline2.Biomes_offset0032);
			snapshot.Biomes_offset0036 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0036, (int)baseline1.Biomes_offset0036, (int)baseline2.Biomes_offset0036);
			snapshot.Biomes_offset0040 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0040, (int)baseline1.Biomes_offset0040, (int)baseline2.Biomes_offset0040);
			snapshot.Biomes_offset0044 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0044, (int)baseline1.Biomes_offset0044, (int)baseline2.Biomes_offset0044);
			snapshot.Biomes_offset0048 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0048, (int)baseline1.Biomes_offset0048, (int)baseline2.Biomes_offset0048);
			snapshot.Biomes_offset0052 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0052, (int)baseline1.Biomes_offset0052, (int)baseline2.Biomes_offset0052);
			snapshot.Biomes_offset0056 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0056, (int)baseline1.Biomes_offset0056, (int)baseline2.Biomes_offset0056);
			snapshot.Biomes_offset0060 = (uint)predictor.PredictInt((int)snapshot.Biomes_offset0060, (int)baseline1.Biomes_offset0060, (int)baseline2.Biomes_offset0060);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.BasePosition_x != baseline.BasePosition_x) ? 1u : 0u);
			num |= (uint)((snapshot.BasePosition_y != baseline.BasePosition_y) ? 2 : 0);
			num |= (uint)((snapshot.LinearBaseIndex != baseline.LinearBaseIndex) ? 4 : 0);
			num |= (uint)((snapshot.Biomes_offset0000 != baseline.Biomes_offset0000) ? 8 : 0);
			num |= (uint)((snapshot.Biomes_offset0004 != baseline.Biomes_offset0004) ? 16 : 0);
			num |= (uint)((snapshot.Biomes_offset0008 != baseline.Biomes_offset0008) ? 32 : 0);
			num |= (uint)((snapshot.Biomes_offset0012 != baseline.Biomes_offset0012) ? 64 : 0);
			num |= (uint)((snapshot.Biomes_offset0016 != baseline.Biomes_offset0016) ? 128 : 0);
			num |= (uint)((snapshot.Biomes_offset0020 != baseline.Biomes_offset0020) ? 256 : 0);
			num |= (uint)((snapshot.Biomes_offset0024 != baseline.Biomes_offset0024) ? 512 : 0);
			num |= (uint)((snapshot.Biomes_offset0028 != baseline.Biomes_offset0028) ? 1024 : 0);
			num |= (uint)((snapshot.Biomes_offset0032 != baseline.Biomes_offset0032) ? 2048 : 0);
			num |= (uint)((snapshot.Biomes_offset0036 != baseline.Biomes_offset0036) ? 4096 : 0);
			num |= (uint)((snapshot.Biomes_offset0040 != baseline.Biomes_offset0040) ? 8192 : 0);
			num |= (uint)((snapshot.Biomes_offset0044 != baseline.Biomes_offset0044) ? 16384 : 0);
			num |= (uint)((snapshot.Biomes_offset0048 != baseline.Biomes_offset0048) ? 32768 : 0);
			num |= (uint)((snapshot.Biomes_offset0052 != baseline.Biomes_offset0052) ? 65536 : 0);
			num |= (uint)((snapshot.Biomes_offset0056 != baseline.Biomes_offset0056) ? 131072 : 0);
			num |= (uint)((snapshot.Biomes_offset0060 != baseline.Biomes_offset0060) ? 262144 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 19);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 19);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.BasePosition_x, baseline.BasePosition_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.BasePosition_y, baseline.BasePosition_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.LinearBaseIndex, baseline.LinearBaseIndex, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0000, baseline.Biomes_offset0000, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0004, baseline.Biomes_offset0004, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0008, baseline.Biomes_offset0008, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0012, baseline.Biomes_offset0012, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0016, baseline.Biomes_offset0016, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0020, baseline.Biomes_offset0020, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0024, baseline.Biomes_offset0024, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0028, baseline.Biomes_offset0028, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0032, baseline.Biomes_offset0032, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0036, baseline.Biomes_offset0036, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0040, baseline.Biomes_offset0040, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0044, baseline.Biomes_offset0044, in compressionModel);
			}
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0048, baseline.Biomes_offset0048, in compressionModel);
			}
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0052, baseline.Biomes_offset0052, in compressionModel);
			}
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0056, baseline.Biomes_offset0056, in compressionModel);
			}
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0060, baseline.Biomes_offset0060, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.BasePosition_x != baseline.BasePosition_x) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.BasePosition_x, baseline.BasePosition_x, in compressionModel);
			}
			num |= (uint)((snapshot.BasePosition_y != baseline.BasePosition_y) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.BasePosition_y, baseline.BasePosition_y, in compressionModel);
			}
			num |= (uint)((snapshot.LinearBaseIndex != baseline.LinearBaseIndex) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.LinearBaseIndex, baseline.LinearBaseIndex, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0000 != baseline.Biomes_offset0000) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0000, baseline.Biomes_offset0000, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0004 != baseline.Biomes_offset0004) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0004, baseline.Biomes_offset0004, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0008 != baseline.Biomes_offset0008) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0008, baseline.Biomes_offset0008, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0012 != baseline.Biomes_offset0012) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0012, baseline.Biomes_offset0012, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0016 != baseline.Biomes_offset0016) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0016, baseline.Biomes_offset0016, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0020 != baseline.Biomes_offset0020) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0020, baseline.Biomes_offset0020, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0024 != baseline.Biomes_offset0024) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0024, baseline.Biomes_offset0024, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0028 != baseline.Biomes_offset0028) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0028, baseline.Biomes_offset0028, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0032 != baseline.Biomes_offset0032) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0032, baseline.Biomes_offset0032, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0036 != baseline.Biomes_offset0036) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0036, baseline.Biomes_offset0036, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0040 != baseline.Biomes_offset0040) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0040, baseline.Biomes_offset0040, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0044 != baseline.Biomes_offset0044) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0044, baseline.Biomes_offset0044, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0048 != baseline.Biomes_offset0048) ? 32768 : 0);
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0048, baseline.Biomes_offset0048, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0052 != baseline.Biomes_offset0052) ? 65536 : 0);
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0052, baseline.Biomes_offset0052, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0056 != baseline.Biomes_offset0056) ? 131072 : 0);
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0056, baseline.Biomes_offset0056, in compressionModel);
			}
			num |= (uint)((snapshot.Biomes_offset0060 != baseline.Biomes_offset0060) ? 262144 : 0);
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Biomes_offset0060, baseline.Biomes_offset0060, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 19);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 19);
			if ((num & 1) != 0)
			{
				snapshot.BasePosition_x = reader.ReadPackedIntDelta(baseline.BasePosition_x, in compressionModel);
			}
			else
			{
				snapshot.BasePosition_x = baseline.BasePosition_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.BasePosition_y = reader.ReadPackedIntDelta(baseline.BasePosition_y, in compressionModel);
			}
			else
			{
				snapshot.BasePosition_y = baseline.BasePosition_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.LinearBaseIndex = reader.ReadPackedIntDelta(baseline.LinearBaseIndex, in compressionModel);
			}
			else
			{
				snapshot.LinearBaseIndex = baseline.LinearBaseIndex;
			}
			if ((num & 8) != 0)
			{
				snapshot.Biomes_offset0000 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0000, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0000 = baseline.Biomes_offset0000;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.Biomes_offset0004 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0004, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0004 = baseline.Biomes_offset0004;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.Biomes_offset0008 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0008, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0008 = baseline.Biomes_offset0008;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.Biomes_offset0012 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0012, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0012 = baseline.Biomes_offset0012;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.Biomes_offset0016 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0016, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0016 = baseline.Biomes_offset0016;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.Biomes_offset0020 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0020, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0020 = baseline.Biomes_offset0020;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.Biomes_offset0024 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0024, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0024 = baseline.Biomes_offset0024;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.Biomes_offset0028 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0028, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0028 = baseline.Biomes_offset0028;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.Biomes_offset0032 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0032, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0032 = baseline.Biomes_offset0032;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.Biomes_offset0036 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0036, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0036 = baseline.Biomes_offset0036;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.Biomes_offset0040 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0040, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0040 = baseline.Biomes_offset0040;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.Biomes_offset0044 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0044, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0044 = baseline.Biomes_offset0044;
			}
			if ((num & 0x8000) != 0)
			{
				snapshot.Biomes_offset0048 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0048, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0048 = baseline.Biomes_offset0048;
			}
			if ((num & 0x10000) != 0)
			{
				snapshot.Biomes_offset0052 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0052, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0052 = baseline.Biomes_offset0052;
			}
			if ((num & 0x20000) != 0)
			{
				snapshot.Biomes_offset0056 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0056, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0056 = baseline.Biomes_offset0056;
			}
			if ((num & 0x40000) != 0)
			{
				snapshot.Biomes_offset0060 = reader.ReadPackedUIntDelta(baseline.Biomes_offset0060, in compressionModel);
			}
			else
			{
				snapshot.Biomes_offset0060 = baseline.Biomes_offset0060;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 93467466151598730uL,
					ComponentType = ComponentType.ReadWrite<ClientBiomeSamplesCD>(),
					ComponentSize = UnsafeUtility.SizeOf<ClientBiomeSamplesCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 19,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 17019261023658142386uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ClientBiomeSamplesCD, Snapshot, ClientBiomeSamplesCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
