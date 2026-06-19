using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
using Pug.UnityExtensions;
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
	public struct WalkStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint previousDirection_id;

			public float previousVelocity_x;

			public float previousVelocity_y;

			public float previousVelocity_z;

			public uint reorientationDelay_startTick;

			public uint reorientationDelay_targetTicks;

			public uint reorientationDelay_stopTick;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<WalkStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<WalkStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<WalkStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<WalkStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in WalkStateCD component)
		{
			snapshot.previousDirection_id = (uint)component.previousDirection.id;
			snapshot.previousVelocity_x = component.previousVelocity.x;
			snapshot.previousVelocity_y = component.previousVelocity.y;
			snapshot.previousVelocity_z = component.previousVelocity.z;
			snapshot.reorientationDelay_startTick = component.reorientationDelay.startTick.SerializedData;
			snapshot.reorientationDelay_targetTicks = component.reorientationDelay.targetTicks;
			snapshot.reorientationDelay_stopTick = component.reorientationDelay.stopTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref WalkStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.previousDirection.id = (Direction.Id)snapshotBefore.previousDirection_id;
			component.previousVelocity = new float3(snapshotBefore.previousVelocity_x, snapshotBefore.previousVelocity_y, snapshotBefore.previousVelocity_z);
			component.reorientationDelay.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.reorientationDelay_startTick
			};
			component.reorientationDelay.targetTicks = snapshotBefore.reorientationDelay_targetTicks;
			component.reorientationDelay.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.reorientationDelay_stopTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref WalkStateCD component, in WalkStateCD backup)
		{
			component.previousDirection.id = backup.previousDirection.id;
			component.previousVelocity.x = backup.previousVelocity.x;
			component.previousVelocity.y = backup.previousVelocity.y;
			component.previousVelocity.z = backup.previousVelocity.z;
			component.reorientationDelay.startTick = backup.reorientationDelay.startTick;
			component.reorientationDelay.targetTicks = backup.reorientationDelay.targetTicks;
			component.reorientationDelay.stopTick = backup.reorientationDelay.stopTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.previousDirection_id = (uint)predictor.PredictInt((int)snapshot.previousDirection_id, (int)baseline1.previousDirection_id, (int)baseline2.previousDirection_id);
			snapshot.reorientationDelay_startTick = (uint)predictor.PredictInt((int)snapshot.reorientationDelay_startTick, (int)baseline1.reorientationDelay_startTick, (int)baseline2.reorientationDelay_startTick);
			snapshot.reorientationDelay_targetTicks = (uint)predictor.PredictInt((int)snapshot.reorientationDelay_targetTicks, (int)baseline1.reorientationDelay_targetTicks, (int)baseline2.reorientationDelay_targetTicks);
			snapshot.reorientationDelay_stopTick = (uint)predictor.PredictInt((int)snapshot.reorientationDelay_stopTick, (int)baseline1.reorientationDelay_stopTick, (int)baseline2.reorientationDelay_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.previousDirection_id != baseline.previousDirection_id) ? 1u : 0u);
			num |= (uint)((snapshot.previousVelocity_x != baseline.previousVelocity_x) ? 2 : 0);
			num |= (uint)((snapshot.previousVelocity_y != baseline.previousVelocity_y) ? 2 : 0);
			num |= (uint)((snapshot.previousVelocity_z != baseline.previousVelocity_z) ? 2 : 0);
			num |= (uint)((snapshot.reorientationDelay_startTick != baseline.reorientationDelay_startTick) ? 4 : 0);
			num |= (uint)((snapshot.reorientationDelay_targetTicks != baseline.reorientationDelay_targetTicks) ? 8 : 0);
			num |= (uint)((snapshot.reorientationDelay_stopTick != baseline.reorientationDelay_stopTick) ? 16 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.previousDirection_id, baseline.previousDirection_id, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_x, baseline.previousVelocity_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_y, baseline.previousVelocity_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_z, baseline.previousVelocity_z, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_startTick, baseline.reorientationDelay_startTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_targetTicks, baseline.reorientationDelay_targetTicks, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_stopTick, baseline.reorientationDelay_stopTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.previousDirection_id != baseline.previousDirection_id) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.previousDirection_id, baseline.previousDirection_id, in compressionModel);
			}
			num |= (uint)((snapshot.previousVelocity_x != baseline.previousVelocity_x) ? 2 : 0);
			num |= (uint)((snapshot.previousVelocity_y != baseline.previousVelocity_y) ? 2 : 0);
			num |= (uint)((snapshot.previousVelocity_z != baseline.previousVelocity_z) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_x, baseline.previousVelocity_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_y, baseline.previousVelocity_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.previousVelocity_z, baseline.previousVelocity_z, in compressionModel);
			}
			num |= (uint)((snapshot.reorientationDelay_startTick != baseline.reorientationDelay_startTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_startTick, baseline.reorientationDelay_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.reorientationDelay_targetTicks != baseline.reorientationDelay_targetTicks) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_targetTicks, baseline.reorientationDelay_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.reorientationDelay_stopTick != baseline.reorientationDelay_stopTick) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.reorientationDelay_stopTick, baseline.reorientationDelay_stopTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 5);
			if ((num & 1) != 0)
			{
				snapshot.previousDirection_id = reader.ReadPackedUIntDelta(baseline.previousDirection_id, in compressionModel);
			}
			else
			{
				snapshot.previousDirection_id = baseline.previousDirection_id;
			}
			if ((num & 2) != 0)
			{
				snapshot.previousVelocity_x = reader.ReadPackedFloatDelta(baseline.previousVelocity_x, in compressionModel);
			}
			else
			{
				snapshot.previousVelocity_x = baseline.previousVelocity_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.previousVelocity_y = reader.ReadPackedFloatDelta(baseline.previousVelocity_y, in compressionModel);
			}
			else
			{
				snapshot.previousVelocity_y = baseline.previousVelocity_y;
			}
			if ((num & 2) != 0)
			{
				snapshot.previousVelocity_z = reader.ReadPackedFloatDelta(baseline.previousVelocity_z, in compressionModel);
			}
			else
			{
				snapshot.previousVelocity_z = baseline.previousVelocity_z;
			}
			if ((num & 4) != 0)
			{
				snapshot.reorientationDelay_startTick = reader.ReadPackedUIntDelta(baseline.reorientationDelay_startTick, in compressionModel);
			}
			else
			{
				snapshot.reorientationDelay_startTick = baseline.reorientationDelay_startTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.reorientationDelay_targetTicks = reader.ReadPackedUIntDelta(baseline.reorientationDelay_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.reorientationDelay_targetTicks = baseline.reorientationDelay_targetTicks;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.reorientationDelay_stopTick = reader.ReadPackedUIntDelta(baseline.reorientationDelay_stopTick, in compressionModel);
			}
			else
			{
				snapshot.reorientationDelay_stopTick = baseline.reorientationDelay_stopTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1966819302090705106uL,
					ComponentType = ComponentType.ReadWrite<WalkStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<WalkStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 5,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 5388225225481330186uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<WalkStateCD, Snapshot, WalkStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
