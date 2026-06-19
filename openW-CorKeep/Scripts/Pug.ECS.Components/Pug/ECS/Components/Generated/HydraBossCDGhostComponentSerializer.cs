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
	public struct HydraBossCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint isShootingBeam;

			public float beamTargetPoint_x;

			public float beamTargetPoint_y;

			public float beamTargetPoint_z;

			public float pointToLookAt_x;

			public float pointToLookAt_y;

			public float pointToLookAt_z;

			public uint isGhost;

			public uint isVoid;
		}

		private const int ChangeMaskBits = 5;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 5;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<HydraBossCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<HydraBossCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<HydraBossCD>(component), in GhostComponentSerializer.TypeCastReadonly<HydraBossCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in HydraBossCD component)
		{
			snapshot.isShootingBeam = (component.isShootingBeam ? 1u : 0u);
			snapshot.beamTargetPoint_x = component.beamTargetPoint.x;
			snapshot.beamTargetPoint_y = component.beamTargetPoint.y;
			snapshot.beamTargetPoint_z = component.beamTargetPoint.z;
			snapshot.pointToLookAt_x = component.pointToLookAt.x;
			snapshot.pointToLookAt_y = component.pointToLookAt.y;
			snapshot.pointToLookAt_z = component.pointToLookAt.z;
			snapshot.isGhost = (component.isGhost ? 1u : 0u);
			snapshot.isVoid = (component.isVoid ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref HydraBossCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.isShootingBeam = snapshotBefore.isShootingBeam != 0;
			snapshotInterpolationFactor = math.max(snapshotInterpolationFactorRaw, 0f);
			float3 start = new float3(snapshotBefore.beamTargetPoint_x, snapshotBefore.beamTargetPoint_y, snapshotBefore.beamTargetPoint_z);
			float3 end = new float3(snapshotAfter.beamTargetPoint_x, snapshotAfter.beamTargetPoint_y, snapshotAfter.beamTargetPoint_z);
			component.beamTargetPoint = math.lerp(start, end, snapshotInterpolationFactor);
			component.pointToLookAt = new float3(snapshotBefore.pointToLookAt_x, snapshotBefore.pointToLookAt_y, snapshotBefore.pointToLookAt_z);
			component.isGhost = snapshotBefore.isGhost != 0;
			component.isVoid = snapshotBefore.isVoid != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref HydraBossCD component, in HydraBossCD backup)
		{
			component.isShootingBeam = backup.isShootingBeam;
			component.beamTargetPoint.x = backup.beamTargetPoint.x;
			component.beamTargetPoint.y = backup.beamTargetPoint.y;
			component.beamTargetPoint.z = backup.beamTargetPoint.z;
			component.pointToLookAt.x = backup.pointToLookAt.x;
			component.pointToLookAt.y = backup.pointToLookAt.y;
			component.pointToLookAt.z = backup.pointToLookAt.z;
			component.isGhost = backup.isGhost;
			component.isVoid = backup.isVoid;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.isShootingBeam = (uint)predictor.PredictInt((int)snapshot.isShootingBeam, (int)baseline1.isShootingBeam, (int)baseline2.isShootingBeam);
			snapshot.isGhost = (uint)predictor.PredictInt((int)snapshot.isGhost, (int)baseline1.isGhost, (int)baseline2.isGhost);
			snapshot.isVoid = (uint)predictor.PredictInt((int)snapshot.isVoid, (int)baseline1.isVoid, (int)baseline2.isVoid);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.isShootingBeam != baseline.isShootingBeam) ? 1u : 0u);
			num |= (uint)((snapshot.beamTargetPoint_x != baseline.beamTargetPoint_x) ? 2 : 0);
			num |= (uint)((snapshot.beamTargetPoint_y != baseline.beamTargetPoint_y) ? 2 : 0);
			num |= (uint)((snapshot.beamTargetPoint_z != baseline.beamTargetPoint_z) ? 2 : 0);
			num |= (uint)((snapshot.pointToLookAt_x != baseline.pointToLookAt_x) ? 4 : 0);
			num |= (uint)((snapshot.pointToLookAt_y != baseline.pointToLookAt_y) ? 4 : 0);
			num |= (uint)((snapshot.pointToLookAt_z != baseline.pointToLookAt_z) ? 4 : 0);
			num |= (uint)((snapshot.isGhost != baseline.isGhost) ? 8 : 0);
			num |= (uint)((snapshot.isVoid != baseline.isVoid) ? 16 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isShootingBeam, baseline.isShootingBeam, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.beamTargetPoint_x, baseline.beamTargetPoint_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.beamTargetPoint_y, baseline.beamTargetPoint_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.beamTargetPoint_z, baseline.beamTargetPoint_z, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pointToLookAt_x, baseline.pointToLookAt_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pointToLookAt_y, baseline.pointToLookAt_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pointToLookAt_z, baseline.pointToLookAt_z, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isGhost, baseline.isGhost, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isVoid, baseline.isVoid, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.isShootingBeam != baseline.isShootingBeam) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isShootingBeam, baseline.isShootingBeam, in compressionModel);
			}
			num |= (uint)((snapshot.beamTargetPoint_x != baseline.beamTargetPoint_x) ? 2 : 0);
			num |= (uint)((snapshot.beamTargetPoint_y != baseline.beamTargetPoint_y) ? 2 : 0);
			num |= (uint)((snapshot.beamTargetPoint_z != baseline.beamTargetPoint_z) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.beamTargetPoint_x, baseline.beamTargetPoint_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.beamTargetPoint_y, baseline.beamTargetPoint_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.beamTargetPoint_z, baseline.beamTargetPoint_z, in compressionModel);
			}
			num |= (uint)((snapshot.pointToLookAt_x != baseline.pointToLookAt_x) ? 4 : 0);
			num |= (uint)((snapshot.pointToLookAt_y != baseline.pointToLookAt_y) ? 4 : 0);
			num |= (uint)((snapshot.pointToLookAt_z != baseline.pointToLookAt_z) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pointToLookAt_x, baseline.pointToLookAt_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pointToLookAt_y, baseline.pointToLookAt_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pointToLookAt_z, baseline.pointToLookAt_z, in compressionModel);
			}
			num |= (uint)((snapshot.isGhost != baseline.isGhost) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isGhost, baseline.isGhost, in compressionModel);
			}
			num |= (uint)((snapshot.isVoid != baseline.isVoid) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isVoid, baseline.isVoid, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				snapshot.isShootingBeam = reader.ReadPackedUIntDelta(baseline.isShootingBeam, in compressionModel);
			}
			else
			{
				snapshot.isShootingBeam = baseline.isShootingBeam;
			}
			if ((num & 2) != 0)
			{
				snapshot.beamTargetPoint_x = reader.ReadPackedFloatDelta(baseline.beamTargetPoint_x, in compressionModel);
			}
			else
			{
				snapshot.beamTargetPoint_x = baseline.beamTargetPoint_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.beamTargetPoint_y = reader.ReadPackedFloatDelta(baseline.beamTargetPoint_y, in compressionModel);
			}
			else
			{
				snapshot.beamTargetPoint_y = baseline.beamTargetPoint_y;
			}
			if ((num & 2) != 0)
			{
				snapshot.beamTargetPoint_z = reader.ReadPackedFloatDelta(baseline.beamTargetPoint_z, in compressionModel);
			}
			else
			{
				snapshot.beamTargetPoint_z = baseline.beamTargetPoint_z;
			}
			if ((num & 4) != 0)
			{
				snapshot.pointToLookAt_x = reader.ReadPackedFloatDelta(baseline.pointToLookAt_x, in compressionModel);
			}
			else
			{
				snapshot.pointToLookAt_x = baseline.pointToLookAt_x;
			}
			if ((num & 4) != 0)
			{
				snapshot.pointToLookAt_y = reader.ReadPackedFloatDelta(baseline.pointToLookAt_y, in compressionModel);
			}
			else
			{
				snapshot.pointToLookAt_y = baseline.pointToLookAt_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.pointToLookAt_z = reader.ReadPackedFloatDelta(baseline.pointToLookAt_z, in compressionModel);
			}
			else
			{
				snapshot.pointToLookAt_z = baseline.pointToLookAt_z;
			}
			if ((num & 8) != 0)
			{
				snapshot.isGhost = reader.ReadPackedUIntDelta(baseline.isGhost, in compressionModel);
			}
			else
			{
				snapshot.isGhost = baseline.isGhost;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.isVoid = reader.ReadPackedUIntDelta(baseline.isVoid, in compressionModel);
			}
			else
			{
				snapshot.isVoid = baseline.isVoid;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 15556942311609237811uL,
					ComponentType = ComponentType.ReadWrite<HydraBossCD>(),
					ComponentSize = UnsafeUtility.SizeOf<HydraBossCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 5,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 1525307274730697476uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<HydraBossCD, Snapshot, HydraBossCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
