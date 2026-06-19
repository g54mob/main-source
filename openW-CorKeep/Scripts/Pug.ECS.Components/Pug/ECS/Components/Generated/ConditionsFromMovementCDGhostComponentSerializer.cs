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
	public struct ConditionsFromMovementCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint standStillTimer_startTick;

			public uint standStillTimer_targetTicks;

			public uint standStillTimer_stopTick;

			public uint interactTimer_startTick;

			public uint interactTimer_targetTicks;

			public uint interactTimer_stopTick;

			public uint sleepyTimer_startTick;

			public uint sleepyTimer_targetTicks;

			public uint sleepyTimer_stopTick;
		}

		private const int ChangeMaskBits = 9;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 9;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ConditionsFromMovementCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ConditionsFromMovementCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ConditionsFromMovementCD>(component), in GhostComponentSerializer.TypeCastReadonly<ConditionsFromMovementCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ConditionsFromMovementCD component)
		{
			snapshot.standStillTimer_startTick = component.standStillTimer.startTick.SerializedData;
			snapshot.standStillTimer_targetTicks = component.standStillTimer.targetTicks;
			snapshot.standStillTimer_stopTick = component.standStillTimer.stopTick.SerializedData;
			snapshot.interactTimer_startTick = component.interactTimer.startTick.SerializedData;
			snapshot.interactTimer_targetTicks = component.interactTimer.targetTicks;
			snapshot.interactTimer_stopTick = component.interactTimer.stopTick.SerializedData;
			snapshot.sleepyTimer_startTick = component.sleepyTimer.startTick.SerializedData;
			snapshot.sleepyTimer_targetTicks = component.sleepyTimer.targetTicks;
			snapshot.sleepyTimer_stopTick = component.sleepyTimer.stopTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ConditionsFromMovementCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.standStillTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.standStillTimer_startTick
			};
			component.standStillTimer.targetTicks = snapshotBefore.standStillTimer_targetTicks;
			component.standStillTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.standStillTimer_stopTick
			};
			component.interactTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.interactTimer_startTick
			};
			component.interactTimer.targetTicks = snapshotBefore.interactTimer_targetTicks;
			component.interactTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.interactTimer_stopTick
			};
			component.sleepyTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.sleepyTimer_startTick
			};
			component.sleepyTimer.targetTicks = snapshotBefore.sleepyTimer_targetTicks;
			component.sleepyTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.sleepyTimer_stopTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ConditionsFromMovementCD component, in ConditionsFromMovementCD backup)
		{
			component.standStillTimer.startTick = backup.standStillTimer.startTick;
			component.standStillTimer.targetTicks = backup.standStillTimer.targetTicks;
			component.standStillTimer.stopTick = backup.standStillTimer.stopTick;
			component.interactTimer.startTick = backup.interactTimer.startTick;
			component.interactTimer.targetTicks = backup.interactTimer.targetTicks;
			component.interactTimer.stopTick = backup.interactTimer.stopTick;
			component.sleepyTimer.startTick = backup.sleepyTimer.startTick;
			component.sleepyTimer.targetTicks = backup.sleepyTimer.targetTicks;
			component.sleepyTimer.stopTick = backup.sleepyTimer.stopTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.standStillTimer_startTick = (uint)predictor.PredictInt((int)snapshot.standStillTimer_startTick, (int)baseline1.standStillTimer_startTick, (int)baseline2.standStillTimer_startTick);
			snapshot.standStillTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.standStillTimer_targetTicks, (int)baseline1.standStillTimer_targetTicks, (int)baseline2.standStillTimer_targetTicks);
			snapshot.standStillTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.standStillTimer_stopTick, (int)baseline1.standStillTimer_stopTick, (int)baseline2.standStillTimer_stopTick);
			snapshot.interactTimer_startTick = (uint)predictor.PredictInt((int)snapshot.interactTimer_startTick, (int)baseline1.interactTimer_startTick, (int)baseline2.interactTimer_startTick);
			snapshot.interactTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.interactTimer_targetTicks, (int)baseline1.interactTimer_targetTicks, (int)baseline2.interactTimer_targetTicks);
			snapshot.interactTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.interactTimer_stopTick, (int)baseline1.interactTimer_stopTick, (int)baseline2.interactTimer_stopTick);
			snapshot.sleepyTimer_startTick = (uint)predictor.PredictInt((int)snapshot.sleepyTimer_startTick, (int)baseline1.sleepyTimer_startTick, (int)baseline2.sleepyTimer_startTick);
			snapshot.sleepyTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.sleepyTimer_targetTicks, (int)baseline1.sleepyTimer_targetTicks, (int)baseline2.sleepyTimer_targetTicks);
			snapshot.sleepyTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.sleepyTimer_stopTick, (int)baseline1.sleepyTimer_stopTick, (int)baseline2.sleepyTimer_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.standStillTimer_startTick != baseline.standStillTimer_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.standStillTimer_targetTicks != baseline.standStillTimer_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.standStillTimer_stopTick != baseline.standStillTimer_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.interactTimer_startTick != baseline.interactTimer_startTick) ? 8 : 0);
			num |= (uint)((snapshot.interactTimer_targetTicks != baseline.interactTimer_targetTicks) ? 16 : 0);
			num |= (uint)((snapshot.interactTimer_stopTick != baseline.interactTimer_stopTick) ? 32 : 0);
			num |= (uint)((snapshot.sleepyTimer_startTick != baseline.sleepyTimer_startTick) ? 64 : 0);
			num |= (uint)((snapshot.sleepyTimer_targetTicks != baseline.sleepyTimer_targetTicks) ? 128 : 0);
			num |= (uint)((snapshot.sleepyTimer_stopTick != baseline.sleepyTimer_stopTick) ? 256 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 9);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 9);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.standStillTimer_startTick, baseline.standStillTimer_startTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.standStillTimer_targetTicks, baseline.standStillTimer_targetTicks, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.standStillTimer_stopTick, baseline.standStillTimer_stopTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.interactTimer_startTick, baseline.interactTimer_startTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.interactTimer_targetTicks, baseline.interactTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.interactTimer_stopTick, baseline.interactTimer_stopTick, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.sleepyTimer_startTick, baseline.sleepyTimer_startTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.sleepyTimer_targetTicks, baseline.sleepyTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.sleepyTimer_stopTick, baseline.sleepyTimer_stopTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.standStillTimer_startTick != baseline.standStillTimer_startTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.standStillTimer_startTick, baseline.standStillTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.standStillTimer_targetTicks != baseline.standStillTimer_targetTicks) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.standStillTimer_targetTicks, baseline.standStillTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.standStillTimer_stopTick != baseline.standStillTimer_stopTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.standStillTimer_stopTick, baseline.standStillTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.interactTimer_startTick != baseline.interactTimer_startTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.interactTimer_startTick, baseline.interactTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.interactTimer_targetTicks != baseline.interactTimer_targetTicks) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.interactTimer_targetTicks, baseline.interactTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.interactTimer_stopTick != baseline.interactTimer_stopTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.interactTimer_stopTick, baseline.interactTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.sleepyTimer_startTick != baseline.sleepyTimer_startTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.sleepyTimer_startTick, baseline.sleepyTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.sleepyTimer_targetTicks != baseline.sleepyTimer_targetTicks) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.sleepyTimer_targetTicks, baseline.sleepyTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.sleepyTimer_stopTick != baseline.sleepyTimer_stopTick) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.sleepyTimer_stopTick, baseline.sleepyTimer_stopTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 9);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 9);
			if ((num & 1) != 0)
			{
				snapshot.standStillTimer_startTick = reader.ReadPackedUIntDelta(baseline.standStillTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.standStillTimer_startTick = baseline.standStillTimer_startTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.standStillTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.standStillTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.standStillTimer_targetTicks = baseline.standStillTimer_targetTicks;
			}
			if ((num & 4) != 0)
			{
				snapshot.standStillTimer_stopTick = reader.ReadPackedUIntDelta(baseline.standStillTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.standStillTimer_stopTick = baseline.standStillTimer_stopTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.interactTimer_startTick = reader.ReadPackedUIntDelta(baseline.interactTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.interactTimer_startTick = baseline.interactTimer_startTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.interactTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.interactTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.interactTimer_targetTicks = baseline.interactTimer_targetTicks;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.interactTimer_stopTick = reader.ReadPackedUIntDelta(baseline.interactTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.interactTimer_stopTick = baseline.interactTimer_stopTick;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.sleepyTimer_startTick = reader.ReadPackedUIntDelta(baseline.sleepyTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.sleepyTimer_startTick = baseline.sleepyTimer_startTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.sleepyTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.sleepyTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.sleepyTimer_targetTicks = baseline.sleepyTimer_targetTicks;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.sleepyTimer_stopTick = reader.ReadPackedUIntDelta(baseline.sleepyTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.sleepyTimer_stopTick = baseline.sleepyTimer_stopTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 15168673681901513398uL,
					ComponentType = ComponentType.ReadWrite<ConditionsFromMovementCD>(),
					ComponentSize = UnsafeUtility.SizeOf<ConditionsFromMovementCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 9,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 5665551025432444116uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ConditionsFromMovementCD, Snapshot, ConditionsFromMovementCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
