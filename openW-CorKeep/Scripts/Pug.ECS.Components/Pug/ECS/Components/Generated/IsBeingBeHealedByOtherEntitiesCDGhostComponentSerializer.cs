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
	public struct IsBeingBeHealedByOtherEntitiesCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint timer_startTick;

			public uint timer_targetTicks;

			public uint timer_stopTick;

			public uint isBeingHealed;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<IsBeingBeHealedByOtherEntitiesCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<IsBeingBeHealedByOtherEntitiesCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<IsBeingBeHealedByOtherEntitiesCD>(component), in GhostComponentSerializer.TypeCastReadonly<IsBeingBeHealedByOtherEntitiesCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in IsBeingBeHealedByOtherEntitiesCD component)
		{
			snapshot.timer_startTick = component.timer.startTick.SerializedData;
			snapshot.timer_targetTicks = component.timer.targetTicks;
			snapshot.timer_stopTick = component.timer.stopTick.SerializedData;
			snapshot.isBeingHealed = (component.isBeingHealed ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref IsBeingBeHealedByOtherEntitiesCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.timer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.timer_startTick
			};
			component.timer.targetTicks = snapshotBefore.timer_targetTicks;
			component.timer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.timer_stopTick
			};
			component.isBeingHealed = snapshotBefore.isBeingHealed != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref IsBeingBeHealedByOtherEntitiesCD component, in IsBeingBeHealedByOtherEntitiesCD backup)
		{
			component.timer.startTick = backup.timer.startTick;
			component.timer.targetTicks = backup.timer.targetTicks;
			component.timer.stopTick = backup.timer.stopTick;
			component.isBeingHealed = backup.isBeingHealed;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.timer_startTick = (uint)predictor.PredictInt((int)snapshot.timer_startTick, (int)baseline1.timer_startTick, (int)baseline2.timer_startTick);
			snapshot.timer_targetTicks = (uint)predictor.PredictInt((int)snapshot.timer_targetTicks, (int)baseline1.timer_targetTicks, (int)baseline2.timer_targetTicks);
			snapshot.timer_stopTick = (uint)predictor.PredictInt((int)snapshot.timer_stopTick, (int)baseline1.timer_stopTick, (int)baseline2.timer_stopTick);
			snapshot.isBeingHealed = (uint)predictor.PredictInt((int)snapshot.isBeingHealed, (int)baseline1.isBeingHealed, (int)baseline2.isBeingHealed);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.timer_startTick != baseline.timer_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.timer_targetTicks != baseline.timer_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.timer_stopTick != baseline.timer_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.isBeingHealed != baseline.isBeingHealed) ? 8 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 4);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_startTick, baseline.timer_startTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_targetTicks, baseline.timer_targetTicks, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_stopTick, baseline.timer_stopTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isBeingHealed, baseline.isBeingHealed, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.timer_startTick != baseline.timer_startTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_startTick, baseline.timer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.timer_targetTicks != baseline.timer_targetTicks) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_targetTicks, baseline.timer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.timer_stopTick != baseline.timer_stopTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.timer_stopTick, baseline.timer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.isBeingHealed != baseline.isBeingHealed) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isBeingHealed, baseline.isBeingHealed, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 4);
			if ((num & 1) != 0)
			{
				snapshot.timer_startTick = reader.ReadPackedUIntDelta(baseline.timer_startTick, in compressionModel);
			}
			else
			{
				snapshot.timer_startTick = baseline.timer_startTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.timer_targetTicks = reader.ReadPackedUIntDelta(baseline.timer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.timer_targetTicks = baseline.timer_targetTicks;
			}
			if ((num & 4) != 0)
			{
				snapshot.timer_stopTick = reader.ReadPackedUIntDelta(baseline.timer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.timer_stopTick = baseline.timer_stopTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.isBeingHealed = reader.ReadPackedUIntDelta(baseline.isBeingHealed, in compressionModel);
			}
			else
			{
				snapshot.isBeingHealed = baseline.isBeingHealed;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 4321598702592082872uL,
					ComponentType = ComponentType.ReadWrite<IsBeingBeHealedByOtherEntitiesCD>(),
					ComponentSize = UnsafeUtility.SizeOf<IsBeingBeHealedByOtherEntitiesCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 4,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.OnlyPredictedClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 13416341371587793340uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<IsBeingBeHealedByOtherEntitiesCD, Snapshot, IsBeingBeHealedByOtherEntitiesCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
