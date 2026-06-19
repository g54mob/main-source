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
	public struct UseOffHandStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint offHandCooldownTimer_startTick;

			public uint offHandCooldownTimer_targetTicks;

			public uint offHandCooldownTimer_stopTick;

			public float shieldedAmount;

			public float initialDashDirection_x;

			public float initialDashDirection_y;

			public float initialDashDirection_z;

			public uint moveTimer_startTick;

			public uint moveTimer_targetTicks;

			public uint moveTimer_stopTick;

			public uint minionDetonationTimer_startTick;

			public uint minionDetonationTimer_targetTicks;

			public uint minionDetonationTimer_stopTick;

			public uint remoteDetonatorTimer_startTick;

			public uint remoteDetonatorTimer_targetTicks;

			public uint remoteDetonatorTimer_stopTick;

			public uint minShieldTimer_startTick;

			public uint minShieldTimer_targetTicks;

			public uint minShieldTimer_stopTick;

			public uint parryTimer_startTick;

			public uint parryTimer_targetTicks;

			public uint parryTimer_stopTick;

			public uint remoteDetonatorHadAnyTriggered;
		}

		private const int ChangeMaskBits = 21;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 21;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<UseOffHandStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<UseOffHandStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<UseOffHandStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<UseOffHandStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in UseOffHandStateCD component)
		{
			snapshot.offHandCooldownTimer_startTick = component.offHandCooldownTimer.startTick.SerializedData;
			snapshot.offHandCooldownTimer_targetTicks = component.offHandCooldownTimer.targetTicks;
			snapshot.offHandCooldownTimer_stopTick = component.offHandCooldownTimer.stopTick.SerializedData;
			snapshot.shieldedAmount = component.shieldedAmount;
			snapshot.initialDashDirection_x = component.initialDashDirection.x;
			snapshot.initialDashDirection_y = component.initialDashDirection.y;
			snapshot.initialDashDirection_z = component.initialDashDirection.z;
			snapshot.moveTimer_startTick = component.moveTimer.startTick.SerializedData;
			snapshot.moveTimer_targetTicks = component.moveTimer.targetTicks;
			snapshot.moveTimer_stopTick = component.moveTimer.stopTick.SerializedData;
			snapshot.minionDetonationTimer_startTick = component.minionDetonationTimer.startTick.SerializedData;
			snapshot.minionDetonationTimer_targetTicks = component.minionDetonationTimer.targetTicks;
			snapshot.minionDetonationTimer_stopTick = component.minionDetonationTimer.stopTick.SerializedData;
			snapshot.remoteDetonatorTimer_startTick = component.remoteDetonatorTimer.startTick.SerializedData;
			snapshot.remoteDetonatorTimer_targetTicks = component.remoteDetonatorTimer.targetTicks;
			snapshot.remoteDetonatorTimer_stopTick = component.remoteDetonatorTimer.stopTick.SerializedData;
			snapshot.minShieldTimer_startTick = component.minShieldTimer.startTick.SerializedData;
			snapshot.minShieldTimer_targetTicks = component.minShieldTimer.targetTicks;
			snapshot.minShieldTimer_stopTick = component.minShieldTimer.stopTick.SerializedData;
			snapshot.parryTimer_startTick = component.parryTimer.startTick.SerializedData;
			snapshot.parryTimer_targetTicks = component.parryTimer.targetTicks;
			snapshot.parryTimer_stopTick = component.parryTimer.stopTick.SerializedData;
			snapshot.remoteDetonatorHadAnyTriggered = (component.remoteDetonatorHadAnyTriggered ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref UseOffHandStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.offHandCooldownTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.offHandCooldownTimer_startTick
			};
			component.offHandCooldownTimer.targetTicks = snapshotBefore.offHandCooldownTimer_targetTicks;
			component.offHandCooldownTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.offHandCooldownTimer_stopTick
			};
			component.shieldedAmount = snapshotBefore.shieldedAmount;
			component.initialDashDirection = new float3(snapshotBefore.initialDashDirection_x, snapshotBefore.initialDashDirection_y, snapshotBefore.initialDashDirection_z);
			component.moveTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.moveTimer_startTick
			};
			component.moveTimer.targetTicks = snapshotBefore.moveTimer_targetTicks;
			component.moveTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.moveTimer_stopTick
			};
			component.minionDetonationTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.minionDetonationTimer_startTick
			};
			component.minionDetonationTimer.targetTicks = snapshotBefore.minionDetonationTimer_targetTicks;
			component.minionDetonationTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.minionDetonationTimer_stopTick
			};
			component.remoteDetonatorTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.remoteDetonatorTimer_startTick
			};
			component.remoteDetonatorTimer.targetTicks = snapshotBefore.remoteDetonatorTimer_targetTicks;
			component.remoteDetonatorTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.remoteDetonatorTimer_stopTick
			};
			component.minShieldTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.minShieldTimer_startTick
			};
			component.minShieldTimer.targetTicks = snapshotBefore.minShieldTimer_targetTicks;
			component.minShieldTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.minShieldTimer_stopTick
			};
			component.parryTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.parryTimer_startTick
			};
			component.parryTimer.targetTicks = snapshotBefore.parryTimer_targetTicks;
			component.parryTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.parryTimer_stopTick
			};
			component.remoteDetonatorHadAnyTriggered = snapshotBefore.remoteDetonatorHadAnyTriggered != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref UseOffHandStateCD component, in UseOffHandStateCD backup)
		{
			component.offHandCooldownTimer.startTick = backup.offHandCooldownTimer.startTick;
			component.offHandCooldownTimer.targetTicks = backup.offHandCooldownTimer.targetTicks;
			component.offHandCooldownTimer.stopTick = backup.offHandCooldownTimer.stopTick;
			component.shieldedAmount = backup.shieldedAmount;
			component.initialDashDirection.x = backup.initialDashDirection.x;
			component.initialDashDirection.y = backup.initialDashDirection.y;
			component.initialDashDirection.z = backup.initialDashDirection.z;
			component.moveTimer.startTick = backup.moveTimer.startTick;
			component.moveTimer.targetTicks = backup.moveTimer.targetTicks;
			component.moveTimer.stopTick = backup.moveTimer.stopTick;
			component.minionDetonationTimer.startTick = backup.minionDetonationTimer.startTick;
			component.minionDetonationTimer.targetTicks = backup.minionDetonationTimer.targetTicks;
			component.minionDetonationTimer.stopTick = backup.minionDetonationTimer.stopTick;
			component.remoteDetonatorTimer.startTick = backup.remoteDetonatorTimer.startTick;
			component.remoteDetonatorTimer.targetTicks = backup.remoteDetonatorTimer.targetTicks;
			component.remoteDetonatorTimer.stopTick = backup.remoteDetonatorTimer.stopTick;
			component.minShieldTimer.startTick = backup.minShieldTimer.startTick;
			component.minShieldTimer.targetTicks = backup.minShieldTimer.targetTicks;
			component.minShieldTimer.stopTick = backup.minShieldTimer.stopTick;
			component.parryTimer.startTick = backup.parryTimer.startTick;
			component.parryTimer.targetTicks = backup.parryTimer.targetTicks;
			component.parryTimer.stopTick = backup.parryTimer.stopTick;
			component.remoteDetonatorHadAnyTriggered = backup.remoteDetonatorHadAnyTriggered;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.offHandCooldownTimer_startTick = (uint)predictor.PredictInt((int)snapshot.offHandCooldownTimer_startTick, (int)baseline1.offHandCooldownTimer_startTick, (int)baseline2.offHandCooldownTimer_startTick);
			snapshot.offHandCooldownTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.offHandCooldownTimer_targetTicks, (int)baseline1.offHandCooldownTimer_targetTicks, (int)baseline2.offHandCooldownTimer_targetTicks);
			snapshot.offHandCooldownTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.offHandCooldownTimer_stopTick, (int)baseline1.offHandCooldownTimer_stopTick, (int)baseline2.offHandCooldownTimer_stopTick);
			snapshot.moveTimer_startTick = (uint)predictor.PredictInt((int)snapshot.moveTimer_startTick, (int)baseline1.moveTimer_startTick, (int)baseline2.moveTimer_startTick);
			snapshot.moveTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.moveTimer_targetTicks, (int)baseline1.moveTimer_targetTicks, (int)baseline2.moveTimer_targetTicks);
			snapshot.moveTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.moveTimer_stopTick, (int)baseline1.moveTimer_stopTick, (int)baseline2.moveTimer_stopTick);
			snapshot.minionDetonationTimer_startTick = (uint)predictor.PredictInt((int)snapshot.minionDetonationTimer_startTick, (int)baseline1.minionDetonationTimer_startTick, (int)baseline2.minionDetonationTimer_startTick);
			snapshot.minionDetonationTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.minionDetonationTimer_targetTicks, (int)baseline1.minionDetonationTimer_targetTicks, (int)baseline2.minionDetonationTimer_targetTicks);
			snapshot.minionDetonationTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.minionDetonationTimer_stopTick, (int)baseline1.minionDetonationTimer_stopTick, (int)baseline2.minionDetonationTimer_stopTick);
			snapshot.remoteDetonatorTimer_startTick = (uint)predictor.PredictInt((int)snapshot.remoteDetonatorTimer_startTick, (int)baseline1.remoteDetonatorTimer_startTick, (int)baseline2.remoteDetonatorTimer_startTick);
			snapshot.remoteDetonatorTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.remoteDetonatorTimer_targetTicks, (int)baseline1.remoteDetonatorTimer_targetTicks, (int)baseline2.remoteDetonatorTimer_targetTicks);
			snapshot.remoteDetonatorTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.remoteDetonatorTimer_stopTick, (int)baseline1.remoteDetonatorTimer_stopTick, (int)baseline2.remoteDetonatorTimer_stopTick);
			snapshot.minShieldTimer_startTick = (uint)predictor.PredictInt((int)snapshot.minShieldTimer_startTick, (int)baseline1.minShieldTimer_startTick, (int)baseline2.minShieldTimer_startTick);
			snapshot.minShieldTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.minShieldTimer_targetTicks, (int)baseline1.minShieldTimer_targetTicks, (int)baseline2.minShieldTimer_targetTicks);
			snapshot.minShieldTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.minShieldTimer_stopTick, (int)baseline1.minShieldTimer_stopTick, (int)baseline2.minShieldTimer_stopTick);
			snapshot.parryTimer_startTick = (uint)predictor.PredictInt((int)snapshot.parryTimer_startTick, (int)baseline1.parryTimer_startTick, (int)baseline2.parryTimer_startTick);
			snapshot.parryTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.parryTimer_targetTicks, (int)baseline1.parryTimer_targetTicks, (int)baseline2.parryTimer_targetTicks);
			snapshot.parryTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.parryTimer_stopTick, (int)baseline1.parryTimer_stopTick, (int)baseline2.parryTimer_stopTick);
			snapshot.remoteDetonatorHadAnyTriggered = (uint)predictor.PredictInt((int)snapshot.remoteDetonatorHadAnyTriggered, (int)baseline1.remoteDetonatorHadAnyTriggered, (int)baseline2.remoteDetonatorHadAnyTriggered);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.offHandCooldownTimer_startTick != baseline.offHandCooldownTimer_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.offHandCooldownTimer_targetTicks != baseline.offHandCooldownTimer_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.offHandCooldownTimer_stopTick != baseline.offHandCooldownTimer_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.shieldedAmount != baseline.shieldedAmount) ? 8 : 0);
			num |= (uint)((snapshot.initialDashDirection_x != baseline.initialDashDirection_x) ? 16 : 0);
			num |= (uint)((snapshot.initialDashDirection_y != baseline.initialDashDirection_y) ? 16 : 0);
			num |= (uint)((snapshot.initialDashDirection_z != baseline.initialDashDirection_z) ? 16 : 0);
			num |= (uint)((snapshot.moveTimer_startTick != baseline.moveTimer_startTick) ? 32 : 0);
			num |= (uint)((snapshot.moveTimer_targetTicks != baseline.moveTimer_targetTicks) ? 64 : 0);
			num |= (uint)((snapshot.moveTimer_stopTick != baseline.moveTimer_stopTick) ? 128 : 0);
			num |= (uint)((snapshot.minionDetonationTimer_startTick != baseline.minionDetonationTimer_startTick) ? 256 : 0);
			num |= (uint)((snapshot.minionDetonationTimer_targetTicks != baseline.minionDetonationTimer_targetTicks) ? 512 : 0);
			num |= (uint)((snapshot.minionDetonationTimer_stopTick != baseline.minionDetonationTimer_stopTick) ? 1024 : 0);
			num |= (uint)((snapshot.remoteDetonatorTimer_startTick != baseline.remoteDetonatorTimer_startTick) ? 2048 : 0);
			num |= (uint)((snapshot.remoteDetonatorTimer_targetTicks != baseline.remoteDetonatorTimer_targetTicks) ? 4096 : 0);
			num |= (uint)((snapshot.remoteDetonatorTimer_stopTick != baseline.remoteDetonatorTimer_stopTick) ? 8192 : 0);
			num |= (uint)((snapshot.minShieldTimer_startTick != baseline.minShieldTimer_startTick) ? 16384 : 0);
			num |= (uint)((snapshot.minShieldTimer_targetTicks != baseline.minShieldTimer_targetTicks) ? 32768 : 0);
			num |= (uint)((snapshot.minShieldTimer_stopTick != baseline.minShieldTimer_stopTick) ? 65536 : 0);
			num |= (uint)((snapshot.parryTimer_startTick != baseline.parryTimer_startTick) ? 131072 : 0);
			num |= (uint)((snapshot.parryTimer_targetTicks != baseline.parryTimer_targetTicks) ? 262144 : 0);
			num |= (uint)((snapshot.parryTimer_stopTick != baseline.parryTimer_stopTick) ? 524288 : 0);
			num |= (uint)((snapshot.remoteDetonatorHadAnyTriggered != baseline.remoteDetonatorHadAnyTriggered) ? 1048576 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 21);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 21);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.offHandCooldownTimer_startTick, baseline.offHandCooldownTimer_startTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.offHandCooldownTimer_targetTicks, baseline.offHandCooldownTimer_targetTicks, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.offHandCooldownTimer_stopTick, baseline.offHandCooldownTimer_stopTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.shieldedAmount, baseline.shieldedAmount, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.initialDashDirection_x, baseline.initialDashDirection_x, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.initialDashDirection_y, baseline.initialDashDirection_y, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.initialDashDirection_z, baseline.initialDashDirection_z, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.moveTimer_startTick, baseline.moveTimer_startTick, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.moveTimer_targetTicks, baseline.moveTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.moveTimer_stopTick, baseline.moveTimer_stopTick, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minionDetonationTimer_startTick, baseline.minionDetonationTimer_startTick, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minionDetonationTimer_targetTicks, baseline.minionDetonationTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minionDetonationTimer_stopTick, baseline.minionDetonationTimer_stopTick, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.remoteDetonatorTimer_startTick, baseline.remoteDetonatorTimer_startTick, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.remoteDetonatorTimer_targetTicks, baseline.remoteDetonatorTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.remoteDetonatorTimer_stopTick, baseline.remoteDetonatorTimer_stopTick, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minShieldTimer_startTick, baseline.minShieldTimer_startTick, in compressionModel);
			}
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minShieldTimer_targetTicks, baseline.minShieldTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minShieldTimer_stopTick, baseline.minShieldTimer_stopTick, in compressionModel);
			}
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.parryTimer_startTick, baseline.parryTimer_startTick, in compressionModel);
			}
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.parryTimer_targetTicks, baseline.parryTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.parryTimer_stopTick, baseline.parryTimer_stopTick, in compressionModel);
			}
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.remoteDetonatorHadAnyTriggered, baseline.remoteDetonatorHadAnyTriggered, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.offHandCooldownTimer_startTick != baseline.offHandCooldownTimer_startTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.offHandCooldownTimer_startTick, baseline.offHandCooldownTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.offHandCooldownTimer_targetTicks != baseline.offHandCooldownTimer_targetTicks) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.offHandCooldownTimer_targetTicks, baseline.offHandCooldownTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.offHandCooldownTimer_stopTick != baseline.offHandCooldownTimer_stopTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.offHandCooldownTimer_stopTick, baseline.offHandCooldownTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.shieldedAmount != baseline.shieldedAmount) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.shieldedAmount, baseline.shieldedAmount, in compressionModel);
			}
			num |= (uint)((snapshot.initialDashDirection_x != baseline.initialDashDirection_x) ? 16 : 0);
			num |= (uint)((snapshot.initialDashDirection_y != baseline.initialDashDirection_y) ? 16 : 0);
			num |= (uint)((snapshot.initialDashDirection_z != baseline.initialDashDirection_z) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.initialDashDirection_x, baseline.initialDashDirection_x, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.initialDashDirection_y, baseline.initialDashDirection_y, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.initialDashDirection_z, baseline.initialDashDirection_z, in compressionModel);
			}
			num |= (uint)((snapshot.moveTimer_startTick != baseline.moveTimer_startTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.moveTimer_startTick, baseline.moveTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.moveTimer_targetTicks != baseline.moveTimer_targetTicks) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.moveTimer_targetTicks, baseline.moveTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.moveTimer_stopTick != baseline.moveTimer_stopTick) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.moveTimer_stopTick, baseline.moveTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.minionDetonationTimer_startTick != baseline.minionDetonationTimer_startTick) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minionDetonationTimer_startTick, baseline.minionDetonationTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.minionDetonationTimer_targetTicks != baseline.minionDetonationTimer_targetTicks) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minionDetonationTimer_targetTicks, baseline.minionDetonationTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.minionDetonationTimer_stopTick != baseline.minionDetonationTimer_stopTick) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minionDetonationTimer_stopTick, baseline.minionDetonationTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.remoteDetonatorTimer_startTick != baseline.remoteDetonatorTimer_startTick) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.remoteDetonatorTimer_startTick, baseline.remoteDetonatorTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.remoteDetonatorTimer_targetTicks != baseline.remoteDetonatorTimer_targetTicks) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.remoteDetonatorTimer_targetTicks, baseline.remoteDetonatorTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.remoteDetonatorTimer_stopTick != baseline.remoteDetonatorTimer_stopTick) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.remoteDetonatorTimer_stopTick, baseline.remoteDetonatorTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.minShieldTimer_startTick != baseline.minShieldTimer_startTick) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minShieldTimer_startTick, baseline.minShieldTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.minShieldTimer_targetTicks != baseline.minShieldTimer_targetTicks) ? 32768 : 0);
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minShieldTimer_targetTicks, baseline.minShieldTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.minShieldTimer_stopTick != baseline.minShieldTimer_stopTick) ? 65536 : 0);
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.minShieldTimer_stopTick, baseline.minShieldTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.parryTimer_startTick != baseline.parryTimer_startTick) ? 131072 : 0);
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.parryTimer_startTick, baseline.parryTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.parryTimer_targetTicks != baseline.parryTimer_targetTicks) ? 262144 : 0);
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.parryTimer_targetTicks, baseline.parryTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.parryTimer_stopTick != baseline.parryTimer_stopTick) ? 524288 : 0);
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.parryTimer_stopTick, baseline.parryTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.remoteDetonatorHadAnyTriggered != baseline.remoteDetonatorHadAnyTriggered) ? 1048576 : 0);
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.remoteDetonatorHadAnyTriggered, baseline.remoteDetonatorHadAnyTriggered, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 21);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 21);
			if ((num & 1) != 0)
			{
				snapshot.offHandCooldownTimer_startTick = reader.ReadPackedUIntDelta(baseline.offHandCooldownTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.offHandCooldownTimer_startTick = baseline.offHandCooldownTimer_startTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.offHandCooldownTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.offHandCooldownTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.offHandCooldownTimer_targetTicks = baseline.offHandCooldownTimer_targetTicks;
			}
			if ((num & 4) != 0)
			{
				snapshot.offHandCooldownTimer_stopTick = reader.ReadPackedUIntDelta(baseline.offHandCooldownTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.offHandCooldownTimer_stopTick = baseline.offHandCooldownTimer_stopTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.shieldedAmount = reader.ReadPackedFloatDelta(baseline.shieldedAmount, in compressionModel);
			}
			else
			{
				snapshot.shieldedAmount = baseline.shieldedAmount;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.initialDashDirection_x = reader.ReadPackedFloatDelta(baseline.initialDashDirection_x, in compressionModel);
			}
			else
			{
				snapshot.initialDashDirection_x = baseline.initialDashDirection_x;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.initialDashDirection_y = reader.ReadPackedFloatDelta(baseline.initialDashDirection_y, in compressionModel);
			}
			else
			{
				snapshot.initialDashDirection_y = baseline.initialDashDirection_y;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.initialDashDirection_z = reader.ReadPackedFloatDelta(baseline.initialDashDirection_z, in compressionModel);
			}
			else
			{
				snapshot.initialDashDirection_z = baseline.initialDashDirection_z;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.moveTimer_startTick = reader.ReadPackedUIntDelta(baseline.moveTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.moveTimer_startTick = baseline.moveTimer_startTick;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.moveTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.moveTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.moveTimer_targetTicks = baseline.moveTimer_targetTicks;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.moveTimer_stopTick = reader.ReadPackedUIntDelta(baseline.moveTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.moveTimer_stopTick = baseline.moveTimer_stopTick;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.minionDetonationTimer_startTick = reader.ReadPackedUIntDelta(baseline.minionDetonationTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.minionDetonationTimer_startTick = baseline.minionDetonationTimer_startTick;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.minionDetonationTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.minionDetonationTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.minionDetonationTimer_targetTicks = baseline.minionDetonationTimer_targetTicks;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.minionDetonationTimer_stopTick = reader.ReadPackedUIntDelta(baseline.minionDetonationTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.minionDetonationTimer_stopTick = baseline.minionDetonationTimer_stopTick;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.remoteDetonatorTimer_startTick = reader.ReadPackedUIntDelta(baseline.remoteDetonatorTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.remoteDetonatorTimer_startTick = baseline.remoteDetonatorTimer_startTick;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.remoteDetonatorTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.remoteDetonatorTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.remoteDetonatorTimer_targetTicks = baseline.remoteDetonatorTimer_targetTicks;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.remoteDetonatorTimer_stopTick = reader.ReadPackedUIntDelta(baseline.remoteDetonatorTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.remoteDetonatorTimer_stopTick = baseline.remoteDetonatorTimer_stopTick;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.minShieldTimer_startTick = reader.ReadPackedUIntDelta(baseline.minShieldTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.minShieldTimer_startTick = baseline.minShieldTimer_startTick;
			}
			if ((num & 0x8000) != 0)
			{
				snapshot.minShieldTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.minShieldTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.minShieldTimer_targetTicks = baseline.minShieldTimer_targetTicks;
			}
			if ((num & 0x10000) != 0)
			{
				snapshot.minShieldTimer_stopTick = reader.ReadPackedUIntDelta(baseline.minShieldTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.minShieldTimer_stopTick = baseline.minShieldTimer_stopTick;
			}
			if ((num & 0x20000) != 0)
			{
				snapshot.parryTimer_startTick = reader.ReadPackedUIntDelta(baseline.parryTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.parryTimer_startTick = baseline.parryTimer_startTick;
			}
			if ((num & 0x40000) != 0)
			{
				snapshot.parryTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.parryTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.parryTimer_targetTicks = baseline.parryTimer_targetTicks;
			}
			if ((num & 0x80000) != 0)
			{
				snapshot.parryTimer_stopTick = reader.ReadPackedUIntDelta(baseline.parryTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.parryTimer_stopTick = baseline.parryTimer_stopTick;
			}
			if ((num & 0x100000) != 0)
			{
				snapshot.remoteDetonatorHadAnyTriggered = reader.ReadPackedUIntDelta(baseline.remoteDetonatorHadAnyTriggered, in compressionModel);
			}
			else
			{
				snapshot.remoteDetonatorHadAnyTriggered = baseline.remoteDetonatorHadAnyTriggered;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 6625661780564924274uL,
					ComponentType = ComponentType.ReadWrite<UseOffHandStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<UseOffHandStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 21,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 9912015590936605550uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<UseOffHandStateCD, Snapshot, UseOffHandStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
