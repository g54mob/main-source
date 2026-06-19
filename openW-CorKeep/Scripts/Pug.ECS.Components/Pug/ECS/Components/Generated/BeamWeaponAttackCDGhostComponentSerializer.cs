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
	public struct BeamWeaponAttackCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint beamWeaponActiveTimer_startTick;

			public uint beamWeaponActiveTimer_targetTicks;

			public uint beamWeaponActiveTimer_stopTick;

			public uint specialAttackCooldown_startTick;

			public uint specialAttackCooldown_targetTicks;

			public uint specialAttackCooldown_stopTick;

			public uint lastContiniousActivateTick;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<BeamWeaponAttackCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<BeamWeaponAttackCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<BeamWeaponAttackCD>(component), in GhostComponentSerializer.TypeCastReadonly<BeamWeaponAttackCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in BeamWeaponAttackCD component)
		{
			snapshot.beamWeaponActiveTimer_startTick = component.beamWeaponActiveTimer.startTick.SerializedData;
			snapshot.beamWeaponActiveTimer_targetTicks = component.beamWeaponActiveTimer.targetTicks;
			snapshot.beamWeaponActiveTimer_stopTick = component.beamWeaponActiveTimer.stopTick.SerializedData;
			snapshot.specialAttackCooldown_startTick = component.specialAttackCooldown.startTick.SerializedData;
			snapshot.specialAttackCooldown_targetTicks = component.specialAttackCooldown.targetTicks;
			snapshot.specialAttackCooldown_stopTick = component.specialAttackCooldown.stopTick.SerializedData;
			snapshot.lastContiniousActivateTick = component.lastContiniousActivateTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref BeamWeaponAttackCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.beamWeaponActiveTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.beamWeaponActiveTimer_startTick
			};
			component.beamWeaponActiveTimer.targetTicks = snapshotBefore.beamWeaponActiveTimer_targetTicks;
			component.beamWeaponActiveTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.beamWeaponActiveTimer_stopTick
			};
			component.specialAttackCooldown.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.specialAttackCooldown_startTick
			};
			component.specialAttackCooldown.targetTicks = snapshotBefore.specialAttackCooldown_targetTicks;
			component.specialAttackCooldown.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.specialAttackCooldown_stopTick
			};
			component.lastContiniousActivateTick = new NetworkTick
			{
				SerializedData = snapshotBefore.lastContiniousActivateTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref BeamWeaponAttackCD component, in BeamWeaponAttackCD backup)
		{
			component.beamWeaponActiveTimer.startTick = backup.beamWeaponActiveTimer.startTick;
			component.beamWeaponActiveTimer.targetTicks = backup.beamWeaponActiveTimer.targetTicks;
			component.beamWeaponActiveTimer.stopTick = backup.beamWeaponActiveTimer.stopTick;
			component.specialAttackCooldown.startTick = backup.specialAttackCooldown.startTick;
			component.specialAttackCooldown.targetTicks = backup.specialAttackCooldown.targetTicks;
			component.specialAttackCooldown.stopTick = backup.specialAttackCooldown.stopTick;
			component.lastContiniousActivateTick = backup.lastContiniousActivateTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.beamWeaponActiveTimer_startTick = (uint)predictor.PredictInt((int)snapshot.beamWeaponActiveTimer_startTick, (int)baseline1.beamWeaponActiveTimer_startTick, (int)baseline2.beamWeaponActiveTimer_startTick);
			snapshot.beamWeaponActiveTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.beamWeaponActiveTimer_targetTicks, (int)baseline1.beamWeaponActiveTimer_targetTicks, (int)baseline2.beamWeaponActiveTimer_targetTicks);
			snapshot.beamWeaponActiveTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.beamWeaponActiveTimer_stopTick, (int)baseline1.beamWeaponActiveTimer_stopTick, (int)baseline2.beamWeaponActiveTimer_stopTick);
			snapshot.specialAttackCooldown_startTick = (uint)predictor.PredictInt((int)snapshot.specialAttackCooldown_startTick, (int)baseline1.specialAttackCooldown_startTick, (int)baseline2.specialAttackCooldown_startTick);
			snapshot.specialAttackCooldown_targetTicks = (uint)predictor.PredictInt((int)snapshot.specialAttackCooldown_targetTicks, (int)baseline1.specialAttackCooldown_targetTicks, (int)baseline2.specialAttackCooldown_targetTicks);
			snapshot.specialAttackCooldown_stopTick = (uint)predictor.PredictInt((int)snapshot.specialAttackCooldown_stopTick, (int)baseline1.specialAttackCooldown_stopTick, (int)baseline2.specialAttackCooldown_stopTick);
			snapshot.lastContiniousActivateTick = (uint)predictor.PredictInt((int)snapshot.lastContiniousActivateTick, (int)baseline1.lastContiniousActivateTick, (int)baseline2.lastContiniousActivateTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.beamWeaponActiveTimer_startTick != baseline.beamWeaponActiveTimer_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.beamWeaponActiveTimer_targetTicks != baseline.beamWeaponActiveTimer_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.beamWeaponActiveTimer_stopTick != baseline.beamWeaponActiveTimer_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.specialAttackCooldown_startTick != baseline.specialAttackCooldown_startTick) ? 8 : 0);
			num |= (uint)((snapshot.specialAttackCooldown_targetTicks != baseline.specialAttackCooldown_targetTicks) ? 16 : 0);
			num |= (uint)((snapshot.specialAttackCooldown_stopTick != baseline.specialAttackCooldown_stopTick) ? 32 : 0);
			num |= (uint)((snapshot.lastContiniousActivateTick != baseline.lastContiniousActivateTick) ? 64 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beamWeaponActiveTimer_startTick, baseline.beamWeaponActiveTimer_startTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beamWeaponActiveTimer_targetTicks, baseline.beamWeaponActiveTimer_targetTicks, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beamWeaponActiveTimer_stopTick, baseline.beamWeaponActiveTimer_stopTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.specialAttackCooldown_startTick, baseline.specialAttackCooldown_startTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.specialAttackCooldown_targetTicks, baseline.specialAttackCooldown_targetTicks, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.specialAttackCooldown_stopTick, baseline.specialAttackCooldown_stopTick, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.lastContiniousActivateTick, baseline.lastContiniousActivateTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.beamWeaponActiveTimer_startTick != baseline.beamWeaponActiveTimer_startTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beamWeaponActiveTimer_startTick, baseline.beamWeaponActiveTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.beamWeaponActiveTimer_targetTicks != baseline.beamWeaponActiveTimer_targetTicks) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beamWeaponActiveTimer_targetTicks, baseline.beamWeaponActiveTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.beamWeaponActiveTimer_stopTick != baseline.beamWeaponActiveTimer_stopTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beamWeaponActiveTimer_stopTick, baseline.beamWeaponActiveTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.specialAttackCooldown_startTick != baseline.specialAttackCooldown_startTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.specialAttackCooldown_startTick, baseline.specialAttackCooldown_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.specialAttackCooldown_targetTicks != baseline.specialAttackCooldown_targetTicks) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.specialAttackCooldown_targetTicks, baseline.specialAttackCooldown_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.specialAttackCooldown_stopTick != baseline.specialAttackCooldown_stopTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.specialAttackCooldown_stopTick, baseline.specialAttackCooldown_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.lastContiniousActivateTick != baseline.lastContiniousActivateTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.lastContiniousActivateTick, baseline.lastContiniousActivateTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				snapshot.beamWeaponActiveTimer_startTick = reader.ReadPackedUIntDelta(baseline.beamWeaponActiveTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.beamWeaponActiveTimer_startTick = baseline.beamWeaponActiveTimer_startTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.beamWeaponActiveTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.beamWeaponActiveTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.beamWeaponActiveTimer_targetTicks = baseline.beamWeaponActiveTimer_targetTicks;
			}
			if ((num & 4) != 0)
			{
				snapshot.beamWeaponActiveTimer_stopTick = reader.ReadPackedUIntDelta(baseline.beamWeaponActiveTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.beamWeaponActiveTimer_stopTick = baseline.beamWeaponActiveTimer_stopTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.specialAttackCooldown_startTick = reader.ReadPackedUIntDelta(baseline.specialAttackCooldown_startTick, in compressionModel);
			}
			else
			{
				snapshot.specialAttackCooldown_startTick = baseline.specialAttackCooldown_startTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.specialAttackCooldown_targetTicks = reader.ReadPackedUIntDelta(baseline.specialAttackCooldown_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.specialAttackCooldown_targetTicks = baseline.specialAttackCooldown_targetTicks;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.specialAttackCooldown_stopTick = reader.ReadPackedUIntDelta(baseline.specialAttackCooldown_stopTick, in compressionModel);
			}
			else
			{
				snapshot.specialAttackCooldown_stopTick = baseline.specialAttackCooldown_stopTick;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.lastContiniousActivateTick = reader.ReadPackedUIntDelta(baseline.lastContiniousActivateTick, in compressionModel);
			}
			else
			{
				snapshot.lastContiniousActivateTick = baseline.lastContiniousActivateTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1966819302090705106uL,
					ComponentType = ComponentType.ReadWrite<BeamWeaponAttackCD>(),
					ComponentSize = UnsafeUtility.SizeOf<BeamWeaponAttackCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 7,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 14825086761540427900uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<BeamWeaponAttackCD, Snapshot, BeamWeaponAttackCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
