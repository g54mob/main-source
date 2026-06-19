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
	public struct SittingStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint tryingToLeaveStateTimer_startTick;

			public uint tryingToLeaveStateTimer_targetTicks;

			public uint tryingToLeaveStateTimer_stopTick;

			public uint allowedToLeaveStateTimer_startTick;

			public uint allowedToLeaveStateTimer_targetTicks;

			public uint allowedToLeaveStateTimer_stopTick;
		}

		private const int ChangeMaskBits = 6;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 6;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<SittingStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<SittingStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<SittingStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<SittingStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in SittingStateCD component)
		{
			snapshot.tryingToLeaveStateTimer_startTick = component.tryingToLeaveStateTimer.startTick.SerializedData;
			snapshot.tryingToLeaveStateTimer_targetTicks = component.tryingToLeaveStateTimer.targetTicks;
			snapshot.tryingToLeaveStateTimer_stopTick = component.tryingToLeaveStateTimer.stopTick.SerializedData;
			snapshot.allowedToLeaveStateTimer_startTick = component.allowedToLeaveStateTimer.startTick.SerializedData;
			snapshot.allowedToLeaveStateTimer_targetTicks = component.allowedToLeaveStateTimer.targetTicks;
			snapshot.allowedToLeaveStateTimer_stopTick = component.allowedToLeaveStateTimer.stopTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref SittingStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.tryingToLeaveStateTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.tryingToLeaveStateTimer_startTick
			};
			component.tryingToLeaveStateTimer.targetTicks = snapshotBefore.tryingToLeaveStateTimer_targetTicks;
			component.tryingToLeaveStateTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.tryingToLeaveStateTimer_stopTick
			};
			component.allowedToLeaveStateTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.allowedToLeaveStateTimer_startTick
			};
			component.allowedToLeaveStateTimer.targetTicks = snapshotBefore.allowedToLeaveStateTimer_targetTicks;
			component.allowedToLeaveStateTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.allowedToLeaveStateTimer_stopTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref SittingStateCD component, in SittingStateCD backup)
		{
			component.tryingToLeaveStateTimer.startTick = backup.tryingToLeaveStateTimer.startTick;
			component.tryingToLeaveStateTimer.targetTicks = backup.tryingToLeaveStateTimer.targetTicks;
			component.tryingToLeaveStateTimer.stopTick = backup.tryingToLeaveStateTimer.stopTick;
			component.allowedToLeaveStateTimer.startTick = backup.allowedToLeaveStateTimer.startTick;
			component.allowedToLeaveStateTimer.targetTicks = backup.allowedToLeaveStateTimer.targetTicks;
			component.allowedToLeaveStateTimer.stopTick = backup.allowedToLeaveStateTimer.stopTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.tryingToLeaveStateTimer_startTick = (uint)predictor.PredictInt((int)snapshot.tryingToLeaveStateTimer_startTick, (int)baseline1.tryingToLeaveStateTimer_startTick, (int)baseline2.tryingToLeaveStateTimer_startTick);
			snapshot.tryingToLeaveStateTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.tryingToLeaveStateTimer_targetTicks, (int)baseline1.tryingToLeaveStateTimer_targetTicks, (int)baseline2.tryingToLeaveStateTimer_targetTicks);
			snapshot.tryingToLeaveStateTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.tryingToLeaveStateTimer_stopTick, (int)baseline1.tryingToLeaveStateTimer_stopTick, (int)baseline2.tryingToLeaveStateTimer_stopTick);
			snapshot.allowedToLeaveStateTimer_startTick = (uint)predictor.PredictInt((int)snapshot.allowedToLeaveStateTimer_startTick, (int)baseline1.allowedToLeaveStateTimer_startTick, (int)baseline2.allowedToLeaveStateTimer_startTick);
			snapshot.allowedToLeaveStateTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.allowedToLeaveStateTimer_targetTicks, (int)baseline1.allowedToLeaveStateTimer_targetTicks, (int)baseline2.allowedToLeaveStateTimer_targetTicks);
			snapshot.allowedToLeaveStateTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.allowedToLeaveStateTimer_stopTick, (int)baseline1.allowedToLeaveStateTimer_stopTick, (int)baseline2.allowedToLeaveStateTimer_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.tryingToLeaveStateTimer_startTick != baseline.tryingToLeaveStateTimer_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.tryingToLeaveStateTimer_targetTicks != baseline.tryingToLeaveStateTimer_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.tryingToLeaveStateTimer_stopTick != baseline.tryingToLeaveStateTimer_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.allowedToLeaveStateTimer_startTick != baseline.allowedToLeaveStateTimer_startTick) ? 8 : 0);
			num |= (uint)((snapshot.allowedToLeaveStateTimer_targetTicks != baseline.allowedToLeaveStateTimer_targetTicks) ? 16 : 0);
			num |= (uint)((snapshot.allowedToLeaveStateTimer_stopTick != baseline.allowedToLeaveStateTimer_stopTick) ? 32 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tryingToLeaveStateTimer_startTick, baseline.tryingToLeaveStateTimer_startTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tryingToLeaveStateTimer_targetTicks, baseline.tryingToLeaveStateTimer_targetTicks, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tryingToLeaveStateTimer_stopTick, baseline.tryingToLeaveStateTimer_stopTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_startTick, baseline.allowedToLeaveStateTimer_startTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_targetTicks, baseline.allowedToLeaveStateTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_stopTick, baseline.allowedToLeaveStateTimer_stopTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.tryingToLeaveStateTimer_startTick != baseline.tryingToLeaveStateTimer_startTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tryingToLeaveStateTimer_startTick, baseline.tryingToLeaveStateTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.tryingToLeaveStateTimer_targetTicks != baseline.tryingToLeaveStateTimer_targetTicks) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tryingToLeaveStateTimer_targetTicks, baseline.tryingToLeaveStateTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.tryingToLeaveStateTimer_stopTick != baseline.tryingToLeaveStateTimer_stopTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.tryingToLeaveStateTimer_stopTick, baseline.tryingToLeaveStateTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.allowedToLeaveStateTimer_startTick != baseline.allowedToLeaveStateTimer_startTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_startTick, baseline.allowedToLeaveStateTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.allowedToLeaveStateTimer_targetTicks != baseline.allowedToLeaveStateTimer_targetTicks) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_targetTicks, baseline.allowedToLeaveStateTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.allowedToLeaveStateTimer_stopTick != baseline.allowedToLeaveStateTimer_stopTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_stopTick, baseline.allowedToLeaveStateTimer_stopTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				snapshot.tryingToLeaveStateTimer_startTick = reader.ReadPackedUIntDelta(baseline.tryingToLeaveStateTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.tryingToLeaveStateTimer_startTick = baseline.tryingToLeaveStateTimer_startTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.tryingToLeaveStateTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.tryingToLeaveStateTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.tryingToLeaveStateTimer_targetTicks = baseline.tryingToLeaveStateTimer_targetTicks;
			}
			if ((num & 4) != 0)
			{
				snapshot.tryingToLeaveStateTimer_stopTick = reader.ReadPackedUIntDelta(baseline.tryingToLeaveStateTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.tryingToLeaveStateTimer_stopTick = baseline.tryingToLeaveStateTimer_stopTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.allowedToLeaveStateTimer_startTick = reader.ReadPackedUIntDelta(baseline.allowedToLeaveStateTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.allowedToLeaveStateTimer_startTick = baseline.allowedToLeaveStateTimer_startTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.allowedToLeaveStateTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.allowedToLeaveStateTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.allowedToLeaveStateTimer_targetTicks = baseline.allowedToLeaveStateTimer_targetTicks;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.allowedToLeaveStateTimer_stopTick = reader.ReadPackedUIntDelta(baseline.allowedToLeaveStateTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.allowedToLeaveStateTimer_stopTick = baseline.allowedToLeaveStateTimer_stopTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 5032326342240550756uL,
					ComponentType = ComponentType.ReadWrite<SittingStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<SittingStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 6,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 11107218726235645468uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<SittingStateCD, Snapshot, SittingStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
