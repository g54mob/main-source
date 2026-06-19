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
using Unity.Transforms;

namespace Pug.Other.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	public struct PugLocalTransformWithRotationDefaultVariantGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int Position_x;

			public int Position_y;

			public int Position_z;

			public int RotationX;

			public int RotationY;

			public int RotationZ;

			public int RotationW;
		}

		private const int ChangeMaskBits = 2;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 2;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<LocalTransform>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<LocalTransform>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<LocalTransform>(component), in GhostComponentSerializer.TypeCastReadonly<LocalTransform>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in LocalTransform component)
		{
			snapshot.Position_x = (int)math.round(component.Position.x * 1000f);
			snapshot.Position_y = (int)math.round(component.Position.y * 1000f);
			snapshot.Position_z = (int)math.round(component.Position.z * 1000f);
			snapshot.RotationX = (int)math.round(component.Rotation.value.x * 1000f);
			snapshot.RotationY = (int)math.round(component.Rotation.value.y * 1000f);
			snapshot.RotationZ = (int)math.round(component.Rotation.value.z * 1000f);
			snapshot.RotationW = (int)math.round(component.Rotation.value.w * 1000f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref LocalTransform component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			snapshotInterpolationFactor = snapshotInterpolationFactorRaw;
			float3 float5 = new float3((float)snapshotBefore.Position_x * 0.001f, (float)snapshotBefore.Position_y * 0.001f, (float)snapshotBefore.Position_z * 0.001f);
			float3 float6 = new float3((float)snapshotAfter.Position_x * 0.001f, (float)snapshotAfter.Position_y * 0.001f, (float)snapshotAfter.Position_z * 0.001f);
			if (math.distancesq(float5, float6) > 9f)
			{
				snapshotInterpolationFactor = 0f;
			}
			component.Position = math.lerp(float5, float6, snapshotInterpolationFactor);
			snapshotInterpolationFactor = snapshotInterpolationFactorRaw;
			quaternion q = math.normalize(new quaternion((float)snapshotBefore.RotationX * 0.001f, (float)snapshotBefore.RotationY * 0.001f, (float)snapshotBefore.RotationZ * 0.001f, (float)snapshotBefore.RotationW * 0.001f));
			quaternion q2 = math.normalize(new quaternion((float)snapshotAfter.RotationX * 0.001f, (float)snapshotAfter.RotationY * 0.001f, (float)snapshotAfter.RotationZ * 0.001f, (float)snapshotAfter.RotationW * 0.001f));
			component.Rotation = math.slerp(q, q2, snapshotInterpolationFactor);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref LocalTransform component, in LocalTransform backup)
		{
			component.Position.x = backup.Position.x;
			component.Position.y = backup.Position.y;
			component.Position.z = backup.Position.z;
			component.Rotation = backup.Rotation;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.Position_x = predictor.PredictInt(snapshot.Position_x, baseline1.Position_x, baseline2.Position_x);
			snapshot.Position_y = predictor.PredictInt(snapshot.Position_y, baseline1.Position_y, baseline2.Position_y);
			snapshot.Position_z = predictor.PredictInt(snapshot.Position_z, baseline1.Position_z, baseline2.Position_z);
			snapshot.RotationX = predictor.PredictInt(snapshot.RotationX, baseline1.RotationX, baseline2.RotationX);
			snapshot.RotationY = predictor.PredictInt(snapshot.RotationY, baseline1.RotationY, baseline2.RotationY);
			snapshot.RotationZ = predictor.PredictInt(snapshot.RotationZ, baseline1.RotationZ, baseline2.RotationZ);
			snapshot.RotationW = predictor.PredictInt(snapshot.RotationW, baseline1.RotationW, baseline2.RotationW);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.Position_x != baseline.Position_x) ? 1u : 0u);
			num |= (uint)((snapshot.Position_y != baseline.Position_y) ? 1 : 0);
			num |= (uint)((snapshot.Position_z != baseline.Position_z) ? 1 : 0);
			num |= (uint)((snapshot.RotationX != baseline.RotationX || snapshot.RotationY != baseline.RotationY || snapshot.RotationZ != baseline.RotationZ || snapshot.RotationW != baseline.RotationW) ? 2 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 2);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.Position_x, baseline.Position_x, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.Position_y, baseline.Position_y, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.Position_z, baseline.Position_z, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.RotationX, baseline.RotationX, in compressionModel);
				writer.WritePackedIntDelta(snapshot.RotationY, baseline.RotationY, in compressionModel);
				writer.WritePackedIntDelta(snapshot.RotationZ, baseline.RotationZ, in compressionModel);
				writer.WritePackedIntDelta(snapshot.RotationW, baseline.RotationW, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.Position_x != baseline.Position_x) ? 1u : 0u);
			num |= (uint)((snapshot.Position_y != baseline.Position_y) ? 1 : 0);
			num |= (uint)((snapshot.Position_z != baseline.Position_z) ? 1 : 0);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.Position_x, baseline.Position_x, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.Position_y, baseline.Position_y, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.Position_z, baseline.Position_z, in compressionModel);
			}
			num |= (uint)((snapshot.RotationX != baseline.RotationX || snapshot.RotationY != baseline.RotationY || snapshot.RotationZ != baseline.RotationZ || snapshot.RotationW != baseline.RotationW) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.RotationX, baseline.RotationX, in compressionModel);
				writer.WritePackedIntDelta(snapshot.RotationY, baseline.RotationY, in compressionModel);
				writer.WritePackedIntDelta(snapshot.RotationZ, baseline.RotationZ, in compressionModel);
				writer.WritePackedIntDelta(snapshot.RotationW, baseline.RotationW, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 2);
			if ((num & 1) != 0)
			{
				snapshot.Position_x = reader.ReadPackedIntDelta(baseline.Position_x, in compressionModel);
			}
			else
			{
				snapshot.Position_x = baseline.Position_x;
			}
			if ((num & 1) != 0)
			{
				snapshot.Position_y = reader.ReadPackedIntDelta(baseline.Position_y, in compressionModel);
			}
			else
			{
				snapshot.Position_y = baseline.Position_y;
			}
			if ((num & 1) != 0)
			{
				snapshot.Position_z = reader.ReadPackedIntDelta(baseline.Position_z, in compressionModel);
			}
			else
			{
				snapshot.Position_z = baseline.Position_z;
			}
			if ((num & 2) != 0)
			{
				snapshot.RotationX = reader.ReadPackedIntDelta(baseline.RotationX, in compressionModel);
				snapshot.RotationY = reader.ReadPackedIntDelta(baseline.RotationY, in compressionModel);
				snapshot.RotationZ = reader.ReadPackedIntDelta(baseline.RotationZ, in compressionModel);
				snapshot.RotationW = reader.ReadPackedIntDelta(baseline.RotationW, in compressionModel);
			}
			else
			{
				snapshot.RotationX = baseline.RotationX;
				snapshot.RotationY = baseline.RotationY;
				snapshot.RotationZ = baseline.RotationZ;
				snapshot.RotationW = baseline.RotationW;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 6796529724231883215uL,
					ComponentType = ComponentType.ReadWrite<LocalTransform>(),
					ComponentSize = UnsafeUtility.SizeOf<LocalTransform>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 2,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 15677068320473896030uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<LocalTransform, Snapshot, PugLocalTransformWithRotationDefaultVariantGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
