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
	public struct AnticipationCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint AnticipationDuration_startTick;

			public uint AnticipationDuration_targetTicks;

			public uint AnticipationDuration_stopTick;

			public uint cooldowmTimer_startTick;

			public uint cooldowmTimer_targetTicks;

			public uint cooldowmTimer_stopTick;

			public uint firstAttack;
		}

		private const int ChangeMaskBits = 7;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 7;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<AnticipationCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<AnticipationCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<AnticipationCD>(component), in GhostComponentSerializer.TypeCastReadonly<AnticipationCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in AnticipationCD component)
		{
			snapshot.AnticipationDuration_startTick = component.AnticipationDuration.startTick.SerializedData;
			snapshot.AnticipationDuration_targetTicks = component.AnticipationDuration.targetTicks;
			snapshot.AnticipationDuration_stopTick = component.AnticipationDuration.stopTick.SerializedData;
			snapshot.cooldowmTimer_startTick = component.cooldowmTimer.startTick.SerializedData;
			snapshot.cooldowmTimer_targetTicks = component.cooldowmTimer.targetTicks;
			snapshot.cooldowmTimer_stopTick = component.cooldowmTimer.stopTick.SerializedData;
			snapshot.firstAttack = (component.firstAttack ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref AnticipationCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.AnticipationDuration.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.AnticipationDuration_startTick
			};
			component.AnticipationDuration.targetTicks = snapshotBefore.AnticipationDuration_targetTicks;
			component.AnticipationDuration.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.AnticipationDuration_stopTick
			};
			component.cooldowmTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.cooldowmTimer_startTick
			};
			component.cooldowmTimer.targetTicks = snapshotBefore.cooldowmTimer_targetTicks;
			component.cooldowmTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.cooldowmTimer_stopTick
			};
			component.firstAttack = snapshotBefore.firstAttack != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref AnticipationCD component, in AnticipationCD backup)
		{
			component.AnticipationDuration.startTick = backup.AnticipationDuration.startTick;
			component.AnticipationDuration.targetTicks = backup.AnticipationDuration.targetTicks;
			component.AnticipationDuration.stopTick = backup.AnticipationDuration.stopTick;
			component.cooldowmTimer.startTick = backup.cooldowmTimer.startTick;
			component.cooldowmTimer.targetTicks = backup.cooldowmTimer.targetTicks;
			component.cooldowmTimer.stopTick = backup.cooldowmTimer.stopTick;
			component.firstAttack = backup.firstAttack;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.AnticipationDuration_startTick = (uint)predictor.PredictInt((int)snapshot.AnticipationDuration_startTick, (int)baseline1.AnticipationDuration_startTick, (int)baseline2.AnticipationDuration_startTick);
			snapshot.AnticipationDuration_targetTicks = (uint)predictor.PredictInt((int)snapshot.AnticipationDuration_targetTicks, (int)baseline1.AnticipationDuration_targetTicks, (int)baseline2.AnticipationDuration_targetTicks);
			snapshot.AnticipationDuration_stopTick = (uint)predictor.PredictInt((int)snapshot.AnticipationDuration_stopTick, (int)baseline1.AnticipationDuration_stopTick, (int)baseline2.AnticipationDuration_stopTick);
			snapshot.cooldowmTimer_startTick = (uint)predictor.PredictInt((int)snapshot.cooldowmTimer_startTick, (int)baseline1.cooldowmTimer_startTick, (int)baseline2.cooldowmTimer_startTick);
			snapshot.cooldowmTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.cooldowmTimer_targetTicks, (int)baseline1.cooldowmTimer_targetTicks, (int)baseline2.cooldowmTimer_targetTicks);
			snapshot.cooldowmTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.cooldowmTimer_stopTick, (int)baseline1.cooldowmTimer_stopTick, (int)baseline2.cooldowmTimer_stopTick);
			snapshot.firstAttack = (uint)predictor.PredictInt((int)snapshot.firstAttack, (int)baseline1.firstAttack, (int)baseline2.firstAttack);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.AnticipationDuration_startTick != baseline.AnticipationDuration_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.AnticipationDuration_targetTicks != baseline.AnticipationDuration_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.AnticipationDuration_stopTick != baseline.AnticipationDuration_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.cooldowmTimer_startTick != baseline.cooldowmTimer_startTick) ? 8 : 0);
			num |= (uint)((snapshot.cooldowmTimer_targetTicks != baseline.cooldowmTimer_targetTicks) ? 16 : 0);
			num |= (uint)((snapshot.cooldowmTimer_stopTick != baseline.cooldowmTimer_stopTick) ? 32 : 0);
			num |= (uint)((snapshot.firstAttack != baseline.firstAttack) ? 64 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.AnticipationDuration_startTick, baseline.AnticipationDuration_startTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.AnticipationDuration_targetTicks, baseline.AnticipationDuration_targetTicks, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.AnticipationDuration_stopTick, baseline.AnticipationDuration_stopTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.cooldowmTimer_startTick, baseline.cooldowmTimer_startTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.cooldowmTimer_targetTicks, baseline.cooldowmTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.cooldowmTimer_stopTick, baseline.cooldowmTimer_stopTick, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.firstAttack, baseline.firstAttack, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.AnticipationDuration_startTick != baseline.AnticipationDuration_startTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.AnticipationDuration_startTick, baseline.AnticipationDuration_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.AnticipationDuration_targetTicks != baseline.AnticipationDuration_targetTicks) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.AnticipationDuration_targetTicks, baseline.AnticipationDuration_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.AnticipationDuration_stopTick != baseline.AnticipationDuration_stopTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.AnticipationDuration_stopTick, baseline.AnticipationDuration_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.cooldowmTimer_startTick != baseline.cooldowmTimer_startTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.cooldowmTimer_startTick, baseline.cooldowmTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.cooldowmTimer_targetTicks != baseline.cooldowmTimer_targetTicks) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.cooldowmTimer_targetTicks, baseline.cooldowmTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.cooldowmTimer_stopTick != baseline.cooldowmTimer_stopTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.cooldowmTimer_stopTick, baseline.cooldowmTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.firstAttack != baseline.firstAttack) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.firstAttack, baseline.firstAttack, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				snapshot.AnticipationDuration_startTick = reader.ReadPackedUIntDelta(baseline.AnticipationDuration_startTick, in compressionModel);
			}
			else
			{
				snapshot.AnticipationDuration_startTick = baseline.AnticipationDuration_startTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.AnticipationDuration_targetTicks = reader.ReadPackedUIntDelta(baseline.AnticipationDuration_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.AnticipationDuration_targetTicks = baseline.AnticipationDuration_targetTicks;
			}
			if ((num & 4) != 0)
			{
				snapshot.AnticipationDuration_stopTick = reader.ReadPackedUIntDelta(baseline.AnticipationDuration_stopTick, in compressionModel);
			}
			else
			{
				snapshot.AnticipationDuration_stopTick = baseline.AnticipationDuration_stopTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.cooldowmTimer_startTick = reader.ReadPackedUIntDelta(baseline.cooldowmTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.cooldowmTimer_startTick = baseline.cooldowmTimer_startTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.cooldowmTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.cooldowmTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.cooldowmTimer_targetTicks = baseline.cooldowmTimer_targetTicks;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.cooldowmTimer_stopTick = reader.ReadPackedUIntDelta(baseline.cooldowmTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.cooldowmTimer_stopTick = baseline.cooldowmTimer_stopTick;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.firstAttack = reader.ReadPackedUIntDelta(baseline.firstAttack, in compressionModel);
			}
			else
			{
				snapshot.firstAttack = baseline.firstAttack;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1966819302090705106uL,
					ComponentType = ComponentType.ReadWrite<AnticipationCD>(),
					ComponentSize = UnsafeUtility.SizeOf<AnticipationCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 7,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 15939815341760764156uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<AnticipationCD, Snapshot, AnticipationCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
