using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
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
	public struct PlaceObjectPlayerStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint placeDuration_startTick;

			public uint placeDuration_targetTicks;

			public uint placeDuration_stopTick;

			public float positionToPlaceAt_x;

			public float positionToPlaceAt_y;

			public float positionToPlaceAt_z;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<PlaceObjectPlayerStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<PlaceObjectPlayerStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<PlaceObjectPlayerStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<PlaceObjectPlayerStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in PlaceObjectPlayerStateCD component)
		{
			snapshot.placeDuration_startTick = component.placeDuration.startTick.SerializedData;
			snapshot.placeDuration_targetTicks = component.placeDuration.targetTicks;
			snapshot.placeDuration_stopTick = component.placeDuration.stopTick.SerializedData;
			snapshot.positionToPlaceAt_x = component.positionToPlaceAt.x;
			snapshot.positionToPlaceAt_y = component.positionToPlaceAt.y;
			snapshot.positionToPlaceAt_z = component.positionToPlaceAt.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref PlaceObjectPlayerStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.placeDuration.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.placeDuration_startTick
			};
			component.placeDuration.targetTicks = snapshotBefore.placeDuration_targetTicks;
			component.placeDuration.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.placeDuration_stopTick
			};
			component.positionToPlaceAt = new float3(snapshotBefore.positionToPlaceAt_x, snapshotBefore.positionToPlaceAt_y, snapshotBefore.positionToPlaceAt_z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref PlaceObjectPlayerStateCD component, in PlaceObjectPlayerStateCD backup)
		{
			component.placeDuration.startTick = backup.placeDuration.startTick;
			component.placeDuration.targetTicks = backup.placeDuration.targetTicks;
			component.placeDuration.stopTick = backup.placeDuration.stopTick;
			component.positionToPlaceAt.x = backup.positionToPlaceAt.x;
			component.positionToPlaceAt.y = backup.positionToPlaceAt.y;
			component.positionToPlaceAt.z = backup.positionToPlaceAt.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.placeDuration_startTick = (uint)predictor.PredictInt((int)snapshot.placeDuration_startTick, (int)baseline1.placeDuration_startTick, (int)baseline2.placeDuration_startTick);
			snapshot.placeDuration_targetTicks = (uint)predictor.PredictInt((int)snapshot.placeDuration_targetTicks, (int)baseline1.placeDuration_targetTicks, (int)baseline2.placeDuration_targetTicks);
			snapshot.placeDuration_stopTick = (uint)predictor.PredictInt((int)snapshot.placeDuration_stopTick, (int)baseline1.placeDuration_stopTick, (int)baseline2.placeDuration_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.placeDuration_startTick != baseline.placeDuration_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.placeDuration_targetTicks != baseline.placeDuration_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.placeDuration_stopTick != baseline.placeDuration_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.positionToPlaceAt_x != baseline.positionToPlaceAt_x) ? 8 : 0);
			num |= (uint)((snapshot.positionToPlaceAt_y != baseline.positionToPlaceAt_y) ? 8 : 0);
			num |= (uint)((snapshot.positionToPlaceAt_z != baseline.positionToPlaceAt_z) ? 8 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 4);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeDuration_startTick, baseline.placeDuration_startTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeDuration_targetTicks, baseline.placeDuration_targetTicks, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeDuration_stopTick, baseline.placeDuration_stopTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.positionToPlaceAt_x, baseline.positionToPlaceAt_x, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.positionToPlaceAt_y, baseline.positionToPlaceAt_y, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.positionToPlaceAt_z, baseline.positionToPlaceAt_z, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.placeDuration_startTick != baseline.placeDuration_startTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeDuration_startTick, baseline.placeDuration_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.placeDuration_targetTicks != baseline.placeDuration_targetTicks) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeDuration_targetTicks, baseline.placeDuration_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.placeDuration_stopTick != baseline.placeDuration_stopTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeDuration_stopTick, baseline.placeDuration_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.positionToPlaceAt_x != baseline.positionToPlaceAt_x) ? 8 : 0);
			num |= (uint)((snapshot.positionToPlaceAt_y != baseline.positionToPlaceAt_y) ? 8 : 0);
			num |= (uint)((snapshot.positionToPlaceAt_z != baseline.positionToPlaceAt_z) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.positionToPlaceAt_x, baseline.positionToPlaceAt_x, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.positionToPlaceAt_y, baseline.positionToPlaceAt_y, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.positionToPlaceAt_z, baseline.positionToPlaceAt_z, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 4);
			if ((num & 1) != 0)
			{
				snapshot.placeDuration_startTick = reader.ReadPackedUIntDelta(baseline.placeDuration_startTick, in compressionModel);
			}
			else
			{
				snapshot.placeDuration_startTick = baseline.placeDuration_startTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.placeDuration_targetTicks = reader.ReadPackedUIntDelta(baseline.placeDuration_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.placeDuration_targetTicks = baseline.placeDuration_targetTicks;
			}
			if ((num & 4) != 0)
			{
				snapshot.placeDuration_stopTick = reader.ReadPackedUIntDelta(baseline.placeDuration_stopTick, in compressionModel);
			}
			else
			{
				snapshot.placeDuration_stopTick = baseline.placeDuration_stopTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.positionToPlaceAt_x = reader.ReadPackedFloatDelta(baseline.positionToPlaceAt_x, in compressionModel);
			}
			else
			{
				snapshot.positionToPlaceAt_x = baseline.positionToPlaceAt_x;
			}
			if ((num & 8) != 0)
			{
				snapshot.positionToPlaceAt_y = reader.ReadPackedFloatDelta(baseline.positionToPlaceAt_y, in compressionModel);
			}
			else
			{
				snapshot.positionToPlaceAt_y = baseline.positionToPlaceAt_y;
			}
			if ((num & 8) != 0)
			{
				snapshot.positionToPlaceAt_z = reader.ReadPackedFloatDelta(baseline.positionToPlaceAt_z, in compressionModel);
			}
			else
			{
				snapshot.positionToPlaceAt_z = baseline.positionToPlaceAt_z;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 5032326342240550756uL,
					ComponentType = ComponentType.ReadWrite<PlaceObjectPlayerStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<PlaceObjectPlayerStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 4,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 1200448409787303346uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<PlaceObjectPlayerStateCD, Snapshot, PlaceObjectPlayerStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
