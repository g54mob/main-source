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
	public struct PlayerAimPositionCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public float position_x;

			public float position_y;

			public float position_z;

			public uint isHittingSomething;

			public float beamStrength;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<PlayerAimPositionCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<PlayerAimPositionCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<PlayerAimPositionCD>(component), in GhostComponentSerializer.TypeCastReadonly<PlayerAimPositionCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in PlayerAimPositionCD component)
		{
			snapshot.position_x = component.position.x;
			snapshot.position_y = component.position.y;
			snapshot.position_z = component.position.z;
			snapshot.isHittingSomething = (component.isHittingSomething ? 1u : 0u);
			snapshot.beamStrength = component.beamStrength;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref PlayerAimPositionCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.position = new float3(snapshotBefore.position_x, snapshotBefore.position_y, snapshotBefore.position_z);
			component.isHittingSomething = snapshotBefore.isHittingSomething != 0;
			component.beamStrength = snapshotBefore.beamStrength;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref PlayerAimPositionCD component, in PlayerAimPositionCD backup)
		{
			component.position.x = backup.position.x;
			component.position.y = backup.position.y;
			component.position.z = backup.position.z;
			component.isHittingSomething = backup.isHittingSomething;
			component.beamStrength = backup.beamStrength;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.isHittingSomething = (uint)predictor.PredictInt((int)snapshot.isHittingSomething, (int)baseline1.isHittingSomething, (int)baseline2.isHittingSomething);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.position_x != baseline.position_x) ? 1u : 0u);
			num |= (uint)((snapshot.position_y != baseline.position_y) ? 1 : 0);
			num |= (uint)((snapshot.position_z != baseline.position_z) ? 1 : 0);
			num |= (uint)((snapshot.isHittingSomething != baseline.isHittingSomething) ? 2 : 0);
			num |= (uint)((snapshot.beamStrength != baseline.beamStrength) ? 4 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 3);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.position_x, baseline.position_x, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.position_y, baseline.position_y, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.position_z, baseline.position_z, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isHittingSomething, baseline.isHittingSomething, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.beamStrength, baseline.beamStrength, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.position_x != baseline.position_x) ? 1u : 0u);
			num |= (uint)((snapshot.position_y != baseline.position_y) ? 1 : 0);
			num |= (uint)((snapshot.position_z != baseline.position_z) ? 1 : 0);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.position_x, baseline.position_x, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.position_y, baseline.position_y, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.position_z, baseline.position_z, in compressionModel);
			}
			num |= (uint)((snapshot.isHittingSomething != baseline.isHittingSomething) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isHittingSomething, baseline.isHittingSomething, in compressionModel);
			}
			num |= (uint)((snapshot.beamStrength != baseline.beamStrength) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.beamStrength, baseline.beamStrength, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 3);
			if ((num & 1) != 0)
			{
				snapshot.position_x = reader.ReadPackedFloatDelta(baseline.position_x, in compressionModel);
			}
			else
			{
				snapshot.position_x = baseline.position_x;
			}
			if ((num & 1) != 0)
			{
				snapshot.position_y = reader.ReadPackedFloatDelta(baseline.position_y, in compressionModel);
			}
			else
			{
				snapshot.position_y = baseline.position_y;
			}
			if ((num & 1) != 0)
			{
				snapshot.position_z = reader.ReadPackedFloatDelta(baseline.position_z, in compressionModel);
			}
			else
			{
				snapshot.position_z = baseline.position_z;
			}
			if ((num & 2) != 0)
			{
				snapshot.isHittingSomething = reader.ReadPackedUIntDelta(baseline.isHittingSomething, in compressionModel);
			}
			else
			{
				snapshot.isHittingSomething = baseline.isHittingSomething;
			}
			if ((num & 4) != 0)
			{
				snapshot.beamStrength = reader.ReadPackedFloatDelta(baseline.beamStrength, in compressionModel);
			}
			else
			{
				snapshot.beamStrength = baseline.beamStrength;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 12532388930504974478uL,
					ComponentType = ComponentType.ReadWrite<PlayerAimPositionCD>(),
					ComponentSize = UnsafeUtility.SizeOf<PlayerAimPositionCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 3,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 17250948261952935260uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<PlayerAimPositionCD, Snapshot, PlayerAimPositionCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
