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
	public struct ManaCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int mana;

			public int maxMana;

			public float accumulatedMana;

			public uint delay;

			public uint manaRegenTimer_startTick;

			public uint manaRegenTimer_targetTicks;

			public uint manaRegenTimer_stopTick;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ManaCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ManaCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ManaCD>(component), in GhostComponentSerializer.TypeCastReadonly<ManaCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ManaCD component)
		{
			snapshot.mana = component.mana;
			snapshot.maxMana = component.maxMana;
			snapshot.accumulatedMana = component.accumulatedMana;
			snapshot.delay = (component.delay ? 1u : 0u);
			snapshot.manaRegenTimer_startTick = component.manaRegenTimer.startTick.SerializedData;
			snapshot.manaRegenTimer_targetTicks = component.manaRegenTimer.targetTicks;
			snapshot.manaRegenTimer_stopTick = component.manaRegenTimer.stopTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ManaCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.mana = snapshotBefore.mana;
			component.maxMana = snapshotBefore.maxMana;
			component.accumulatedMana = snapshotBefore.accumulatedMana;
			component.delay = snapshotBefore.delay != 0;
			component.manaRegenTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.manaRegenTimer_startTick
			};
			component.manaRegenTimer.targetTicks = snapshotBefore.manaRegenTimer_targetTicks;
			component.manaRegenTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.manaRegenTimer_stopTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ManaCD component, in ManaCD backup)
		{
			component.mana = backup.mana;
			component.maxMana = backup.maxMana;
			component.accumulatedMana = backup.accumulatedMana;
			component.delay = backup.delay;
			component.manaRegenTimer.startTick = backup.manaRegenTimer.startTick;
			component.manaRegenTimer.targetTicks = backup.manaRegenTimer.targetTicks;
			component.manaRegenTimer.stopTick = backup.manaRegenTimer.stopTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.mana = predictor.PredictInt(snapshot.mana, baseline1.mana, baseline2.mana);
			snapshot.maxMana = predictor.PredictInt(snapshot.maxMana, baseline1.maxMana, baseline2.maxMana);
			snapshot.delay = (uint)predictor.PredictInt((int)snapshot.delay, (int)baseline1.delay, (int)baseline2.delay);
			snapshot.manaRegenTimer_startTick = (uint)predictor.PredictInt((int)snapshot.manaRegenTimer_startTick, (int)baseline1.manaRegenTimer_startTick, (int)baseline2.manaRegenTimer_startTick);
			snapshot.manaRegenTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.manaRegenTimer_targetTicks, (int)baseline1.manaRegenTimer_targetTicks, (int)baseline2.manaRegenTimer_targetTicks);
			snapshot.manaRegenTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.manaRegenTimer_stopTick, (int)baseline1.manaRegenTimer_stopTick, (int)baseline2.manaRegenTimer_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.mana != baseline.mana) ? 1u : 0u);
			num |= (uint)((snapshot.maxMana != baseline.maxMana) ? 2 : 0);
			num |= (uint)((snapshot.accumulatedMana != baseline.accumulatedMana) ? 4 : 0);
			num |= (uint)((snapshot.delay != baseline.delay) ? 8 : 0);
			num |= (uint)((snapshot.manaRegenTimer_startTick != baseline.manaRegenTimer_startTick) ? 16 : 0);
			num |= (uint)((snapshot.manaRegenTimer_targetTicks != baseline.manaRegenTimer_targetTicks) ? 32 : 0);
			num |= (uint)((snapshot.manaRegenTimer_stopTick != baseline.manaRegenTimer_stopTick) ? 64 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.mana, baseline.mana, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.maxMana, baseline.maxMana, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.accumulatedMana, baseline.accumulatedMana, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.delay, baseline.delay, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.manaRegenTimer_startTick, baseline.manaRegenTimer_startTick, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.manaRegenTimer_targetTicks, baseline.manaRegenTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.manaRegenTimer_stopTick, baseline.manaRegenTimer_stopTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.mana != baseline.mana) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.mana, baseline.mana, in compressionModel);
			}
			num |= (uint)((snapshot.maxMana != baseline.maxMana) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.maxMana, baseline.maxMana, in compressionModel);
			}
			num |= (uint)((snapshot.accumulatedMana != baseline.accumulatedMana) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.accumulatedMana, baseline.accumulatedMana, in compressionModel);
			}
			num |= (uint)((snapshot.delay != baseline.delay) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.delay, baseline.delay, in compressionModel);
			}
			num |= (uint)((snapshot.manaRegenTimer_startTick != baseline.manaRegenTimer_startTick) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.manaRegenTimer_startTick, baseline.manaRegenTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.manaRegenTimer_targetTicks != baseline.manaRegenTimer_targetTicks) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.manaRegenTimer_targetTicks, baseline.manaRegenTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.manaRegenTimer_stopTick != baseline.manaRegenTimer_stopTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.manaRegenTimer_stopTick, baseline.manaRegenTimer_stopTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				snapshot.mana = reader.ReadPackedIntDelta(baseline.mana, in compressionModel);
			}
			else
			{
				snapshot.mana = baseline.mana;
			}
			if ((num & 2) != 0)
			{
				snapshot.maxMana = reader.ReadPackedIntDelta(baseline.maxMana, in compressionModel);
			}
			else
			{
				snapshot.maxMana = baseline.maxMana;
			}
			if ((num & 4) != 0)
			{
				snapshot.accumulatedMana = reader.ReadPackedFloatDelta(baseline.accumulatedMana, in compressionModel);
			}
			else
			{
				snapshot.accumulatedMana = baseline.accumulatedMana;
			}
			if ((num & 8) != 0)
			{
				snapshot.delay = reader.ReadPackedUIntDelta(baseline.delay, in compressionModel);
			}
			else
			{
				snapshot.delay = baseline.delay;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.manaRegenTimer_startTick = reader.ReadPackedUIntDelta(baseline.manaRegenTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.manaRegenTimer_startTick = baseline.manaRegenTimer_startTick;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.manaRegenTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.manaRegenTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.manaRegenTimer_targetTicks = baseline.manaRegenTimer_targetTicks;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.manaRegenTimer_stopTick = reader.ReadPackedUIntDelta(baseline.manaRegenTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.manaRegenTimer_stopTick = baseline.manaRegenTimer_stopTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1966819302090705106uL,
					ComponentType = ComponentType.ReadWrite<ManaCD>(),
					ComponentSize = UnsafeUtility.SizeOf<ManaCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 7,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 14565222576491013844uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ManaCD, Snapshot, ManaCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
