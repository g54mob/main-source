using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
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
	public struct PlaceWaterStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int tileset;

			public uint placeWaterDuration_startTick;

			public uint placeWaterDuration_targetTicks;

			public uint placeWaterDuration_stopTick;

			public uint particleDelay_startTick;

			public uint particleDelay_targetTicks;

			public uint particleDelay_stopTick;

			public int bestPositionToPlaceAt_x;

			public int bestPositionToPlaceAt_y;

			public int bestPositionToPlaceAt_z;
		}

		private const int ChangeMaskBits = 10;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 10;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<PlaceWaterStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<PlaceWaterStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<PlaceWaterStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<PlaceWaterStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in PlaceWaterStateCD component)
		{
			snapshot.tileset = component.tileset;
			snapshot.placeWaterDuration_startTick = component.placeWaterDuration.startTick.SerializedData;
			snapshot.placeWaterDuration_targetTicks = component.placeWaterDuration.targetTicks;
			snapshot.placeWaterDuration_stopTick = component.placeWaterDuration.stopTick.SerializedData;
			snapshot.particleDelay_startTick = component.particleDelay.startTick.SerializedData;
			snapshot.particleDelay_targetTicks = component.particleDelay.targetTicks;
			snapshot.particleDelay_stopTick = component.particleDelay.stopTick.SerializedData;
			snapshot.bestPositionToPlaceAt_x = component.bestPositionToPlaceAt.x;
			snapshot.bestPositionToPlaceAt_y = component.bestPositionToPlaceAt.y;
			snapshot.bestPositionToPlaceAt_z = component.bestPositionToPlaceAt.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref PlaceWaterStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.tileset = snapshotBefore.tileset;
			component.placeWaterDuration.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.placeWaterDuration_startTick
			};
			component.placeWaterDuration.targetTicks = snapshotBefore.placeWaterDuration_targetTicks;
			component.placeWaterDuration.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.placeWaterDuration_stopTick
			};
			component.particleDelay.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.particleDelay_startTick
			};
			component.particleDelay.targetTicks = snapshotBefore.particleDelay_targetTicks;
			component.particleDelay.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.particleDelay_stopTick
			};
			component.bestPositionToPlaceAt.x = snapshotBefore.bestPositionToPlaceAt_x;
			component.bestPositionToPlaceAt.y = snapshotBefore.bestPositionToPlaceAt_y;
			component.bestPositionToPlaceAt.z = snapshotBefore.bestPositionToPlaceAt_z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref PlaceWaterStateCD component, in PlaceWaterStateCD backup)
		{
			component.tileset = backup.tileset;
			component.placeWaterDuration.startTick = backup.placeWaterDuration.startTick;
			component.placeWaterDuration.targetTicks = backup.placeWaterDuration.targetTicks;
			component.placeWaterDuration.stopTick = backup.placeWaterDuration.stopTick;
			component.particleDelay.startTick = backup.particleDelay.startTick;
			component.particleDelay.targetTicks = backup.particleDelay.targetTicks;
			component.particleDelay.stopTick = backup.particleDelay.stopTick;
			component.bestPositionToPlaceAt.x = backup.bestPositionToPlaceAt.x;
			component.bestPositionToPlaceAt.y = backup.bestPositionToPlaceAt.y;
			component.bestPositionToPlaceAt.z = backup.bestPositionToPlaceAt.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.tileset = predictor.PredictInt(snapshot.tileset, baseline1.tileset, baseline2.tileset);
			snapshot.placeWaterDuration_startTick = (uint)predictor.PredictInt((int)snapshot.placeWaterDuration_startTick, (int)baseline1.placeWaterDuration_startTick, (int)baseline2.placeWaterDuration_startTick);
			snapshot.placeWaterDuration_targetTicks = (uint)predictor.PredictInt((int)snapshot.placeWaterDuration_targetTicks, (int)baseline1.placeWaterDuration_targetTicks, (int)baseline2.placeWaterDuration_targetTicks);
			snapshot.placeWaterDuration_stopTick = (uint)predictor.PredictInt((int)snapshot.placeWaterDuration_stopTick, (int)baseline1.placeWaterDuration_stopTick, (int)baseline2.placeWaterDuration_stopTick);
			snapshot.particleDelay_startTick = (uint)predictor.PredictInt((int)snapshot.particleDelay_startTick, (int)baseline1.particleDelay_startTick, (int)baseline2.particleDelay_startTick);
			snapshot.particleDelay_targetTicks = (uint)predictor.PredictInt((int)snapshot.particleDelay_targetTicks, (int)baseline1.particleDelay_targetTicks, (int)baseline2.particleDelay_targetTicks);
			snapshot.particleDelay_stopTick = (uint)predictor.PredictInt((int)snapshot.particleDelay_stopTick, (int)baseline1.particleDelay_stopTick, (int)baseline2.particleDelay_stopTick);
			snapshot.bestPositionToPlaceAt_x = predictor.PredictInt(snapshot.bestPositionToPlaceAt_x, baseline1.bestPositionToPlaceAt_x, baseline2.bestPositionToPlaceAt_x);
			snapshot.bestPositionToPlaceAt_y = predictor.PredictInt(snapshot.bestPositionToPlaceAt_y, baseline1.bestPositionToPlaceAt_y, baseline2.bestPositionToPlaceAt_y);
			snapshot.bestPositionToPlaceAt_z = predictor.PredictInt(snapshot.bestPositionToPlaceAt_z, baseline1.bestPositionToPlaceAt_z, baseline2.bestPositionToPlaceAt_z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.tileset != baseline.tileset) ? 1u : 0u);
			num |= (uint)((snapshot.placeWaterDuration_startTick != baseline.placeWaterDuration_startTick) ? 2 : 0);
			num |= (uint)((snapshot.placeWaterDuration_targetTicks != baseline.placeWaterDuration_targetTicks) ? 4 : 0);
			num |= (uint)((snapshot.placeWaterDuration_stopTick != baseline.placeWaterDuration_stopTick) ? 8 : 0);
			num |= (uint)((snapshot.particleDelay_startTick != baseline.particleDelay_startTick) ? 16 : 0);
			num |= (uint)((snapshot.particleDelay_targetTicks != baseline.particleDelay_targetTicks) ? 32 : 0);
			num |= (uint)((snapshot.particleDelay_stopTick != baseline.particleDelay_stopTick) ? 64 : 0);
			num |= (uint)((snapshot.bestPositionToPlaceAt_x != baseline.bestPositionToPlaceAt_x) ? 128 : 0);
			num |= (uint)((snapshot.bestPositionToPlaceAt_y != baseline.bestPositionToPlaceAt_y) ? 256 : 0);
			num |= (uint)((snapshot.bestPositionToPlaceAt_z != baseline.bestPositionToPlaceAt_z) ? 512 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 10);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 10);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileset, baseline.tileset, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeWaterDuration_startTick, baseline.placeWaterDuration_startTick, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeWaterDuration_targetTicks, baseline.placeWaterDuration_targetTicks, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeWaterDuration_stopTick, baseline.placeWaterDuration_stopTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_startTick, baseline.particleDelay_startTick, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_targetTicks, baseline.particleDelay_targetTicks, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_stopTick, baseline.particleDelay_stopTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_x, baseline.bestPositionToPlaceAt_x, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_y, baseline.bestPositionToPlaceAt_y, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_z, baseline.bestPositionToPlaceAt_z, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.tileset != baseline.tileset) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileset, baseline.tileset, in compressionModel);
			}
			num |= (uint)((snapshot.placeWaterDuration_startTick != baseline.placeWaterDuration_startTick) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeWaterDuration_startTick, baseline.placeWaterDuration_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.placeWaterDuration_targetTicks != baseline.placeWaterDuration_targetTicks) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeWaterDuration_targetTicks, baseline.placeWaterDuration_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.placeWaterDuration_stopTick != baseline.placeWaterDuration_stopTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.placeWaterDuration_stopTick, baseline.placeWaterDuration_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.particleDelay_startTick != baseline.particleDelay_startTick) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_startTick, baseline.particleDelay_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.particleDelay_targetTicks != baseline.particleDelay_targetTicks) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_targetTicks, baseline.particleDelay_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.particleDelay_stopTick != baseline.particleDelay_stopTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_stopTick, baseline.particleDelay_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.bestPositionToPlaceAt_x != baseline.bestPositionToPlaceAt_x) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_x, baseline.bestPositionToPlaceAt_x, in compressionModel);
			}
			num |= (uint)((snapshot.bestPositionToPlaceAt_y != baseline.bestPositionToPlaceAt_y) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_y, baseline.bestPositionToPlaceAt_y, in compressionModel);
			}
			num |= (uint)((snapshot.bestPositionToPlaceAt_z != baseline.bestPositionToPlaceAt_z) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bestPositionToPlaceAt_z, baseline.bestPositionToPlaceAt_z, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 10);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 10);
			if ((num & 1) != 0)
			{
				snapshot.tileset = reader.ReadPackedIntDelta(baseline.tileset, in compressionModel);
			}
			else
			{
				snapshot.tileset = baseline.tileset;
			}
			if ((num & 2) != 0)
			{
				snapshot.placeWaterDuration_startTick = reader.ReadPackedUIntDelta(baseline.placeWaterDuration_startTick, in compressionModel);
			}
			else
			{
				snapshot.placeWaterDuration_startTick = baseline.placeWaterDuration_startTick;
			}
			if ((num & 4) != 0)
			{
				snapshot.placeWaterDuration_targetTicks = reader.ReadPackedUIntDelta(baseline.placeWaterDuration_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.placeWaterDuration_targetTicks = baseline.placeWaterDuration_targetTicks;
			}
			if ((num & 8) != 0)
			{
				snapshot.placeWaterDuration_stopTick = reader.ReadPackedUIntDelta(baseline.placeWaterDuration_stopTick, in compressionModel);
			}
			else
			{
				snapshot.placeWaterDuration_stopTick = baseline.placeWaterDuration_stopTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.particleDelay_startTick = reader.ReadPackedUIntDelta(baseline.particleDelay_startTick, in compressionModel);
			}
			else
			{
				snapshot.particleDelay_startTick = baseline.particleDelay_startTick;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.particleDelay_targetTicks = reader.ReadPackedUIntDelta(baseline.particleDelay_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.particleDelay_targetTicks = baseline.particleDelay_targetTicks;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.particleDelay_stopTick = reader.ReadPackedUIntDelta(baseline.particleDelay_stopTick, in compressionModel);
			}
			else
			{
				snapshot.particleDelay_stopTick = baseline.particleDelay_stopTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.bestPositionToPlaceAt_x = reader.ReadPackedIntDelta(baseline.bestPositionToPlaceAt_x, in compressionModel);
			}
			else
			{
				snapshot.bestPositionToPlaceAt_x = baseline.bestPositionToPlaceAt_x;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.bestPositionToPlaceAt_y = reader.ReadPackedIntDelta(baseline.bestPositionToPlaceAt_y, in compressionModel);
			}
			else
			{
				snapshot.bestPositionToPlaceAt_y = baseline.bestPositionToPlaceAt_y;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.bestPositionToPlaceAt_z = reader.ReadPackedIntDelta(baseline.bestPositionToPlaceAt_z, in compressionModel);
			}
			else
			{
				snapshot.bestPositionToPlaceAt_z = baseline.bestPositionToPlaceAt_z;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 957689210179932508uL,
					ComponentType = ComponentType.ReadWrite<PlaceWaterStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<PlaceWaterStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 10,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 4080310029937144292uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<PlaceWaterStateCD, Snapshot, PlaceWaterStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
