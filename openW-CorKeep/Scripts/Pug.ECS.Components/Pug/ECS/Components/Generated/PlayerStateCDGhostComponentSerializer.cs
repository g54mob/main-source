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
	public struct PlayerStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int nextState;

			public int level1State;

			public int level2State;

			public int level3State;

			public uint isStateLocked;

			public uint nextStateLocked;

			public uint nextStatePushed;

			public int nextPoppedStateMask;
		}

		private const int ChangeMaskBits = 8;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 8;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<PlayerStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<PlayerStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<PlayerStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<PlayerStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in PlayerStateCD component)
		{
			snapshot.nextState = (int)component.nextState;
			snapshot.level1State = (int)component.level1State;
			snapshot.level2State = (int)component.level2State;
			snapshot.level3State = (int)component.level3State;
			snapshot.isStateLocked = (component.isStateLocked ? 1u : 0u);
			snapshot.nextStateLocked = (component.nextStateLocked ? 1u : 0u);
			snapshot.nextStatePushed = (component.nextStatePushed ? 1u : 0u);
			snapshot.nextPoppedStateMask = (int)component.nextPoppedStateMask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref PlayerStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.nextState = (PlayerStateEnum)snapshotBefore.nextState;
			component.level1State = (PlayerStateEnum)snapshotBefore.level1State;
			component.level2State = (PlayerStateEnum)snapshotBefore.level2State;
			component.level3State = (PlayerStateEnum)snapshotBefore.level3State;
			component.isStateLocked = snapshotBefore.isStateLocked != 0;
			component.nextStateLocked = snapshotBefore.nextStateLocked != 0;
			component.nextStatePushed = snapshotBefore.nextStatePushed != 0;
			component.nextPoppedStateMask = (PlayerStateEnum)snapshotBefore.nextPoppedStateMask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref PlayerStateCD component, in PlayerStateCD backup)
		{
			component.nextState = backup.nextState;
			component.level1State = backup.level1State;
			component.level2State = backup.level2State;
			component.level3State = backup.level3State;
			component.isStateLocked = backup.isStateLocked;
			component.nextStateLocked = backup.nextStateLocked;
			component.nextStatePushed = backup.nextStatePushed;
			component.nextPoppedStateMask = backup.nextPoppedStateMask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.nextState = predictor.PredictInt(snapshot.nextState, baseline1.nextState, baseline2.nextState);
			snapshot.level1State = predictor.PredictInt(snapshot.level1State, baseline1.level1State, baseline2.level1State);
			snapshot.level2State = predictor.PredictInt(snapshot.level2State, baseline1.level2State, baseline2.level2State);
			snapshot.level3State = predictor.PredictInt(snapshot.level3State, baseline1.level3State, baseline2.level3State);
			snapshot.isStateLocked = (uint)predictor.PredictInt((int)snapshot.isStateLocked, (int)baseline1.isStateLocked, (int)baseline2.isStateLocked);
			snapshot.nextStateLocked = (uint)predictor.PredictInt((int)snapshot.nextStateLocked, (int)baseline1.nextStateLocked, (int)baseline2.nextStateLocked);
			snapshot.nextStatePushed = (uint)predictor.PredictInt((int)snapshot.nextStatePushed, (int)baseline1.nextStatePushed, (int)baseline2.nextStatePushed);
			snapshot.nextPoppedStateMask = predictor.PredictInt(snapshot.nextPoppedStateMask, baseline1.nextPoppedStateMask, baseline2.nextPoppedStateMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.nextState != baseline.nextState) ? 1u : 0u);
			num |= (uint)((snapshot.level1State != baseline.level1State) ? 2 : 0);
			num |= (uint)((snapshot.level2State != baseline.level2State) ? 4 : 0);
			num |= (uint)((snapshot.level3State != baseline.level3State) ? 8 : 0);
			num |= (uint)((snapshot.isStateLocked != baseline.isStateLocked) ? 16 : 0);
			num |= (uint)((snapshot.nextStateLocked != baseline.nextStateLocked) ? 32 : 0);
			num |= (uint)((snapshot.nextStatePushed != baseline.nextStatePushed) ? 64 : 0);
			num |= (uint)((snapshot.nextPoppedStateMask != baseline.nextPoppedStateMask) ? 128 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 8);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.nextState, baseline.nextState, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.level1State, baseline.level1State, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.level2State, baseline.level2State, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.level3State, baseline.level3State, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isStateLocked, baseline.isStateLocked, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.nextStateLocked, baseline.nextStateLocked, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.nextStatePushed, baseline.nextStatePushed, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.nextPoppedStateMask, baseline.nextPoppedStateMask, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.nextState != baseline.nextState) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.nextState, baseline.nextState, in compressionModel);
			}
			num |= (uint)((snapshot.level1State != baseline.level1State) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.level1State, baseline.level1State, in compressionModel);
			}
			num |= (uint)((snapshot.level2State != baseline.level2State) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.level2State, baseline.level2State, in compressionModel);
			}
			num |= (uint)((snapshot.level3State != baseline.level3State) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.level3State, baseline.level3State, in compressionModel);
			}
			num |= (uint)((snapshot.isStateLocked != baseline.isStateLocked) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isStateLocked, baseline.isStateLocked, in compressionModel);
			}
			num |= (uint)((snapshot.nextStateLocked != baseline.nextStateLocked) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.nextStateLocked, baseline.nextStateLocked, in compressionModel);
			}
			num |= (uint)((snapshot.nextStatePushed != baseline.nextStatePushed) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.nextStatePushed, baseline.nextStatePushed, in compressionModel);
			}
			num |= (uint)((snapshot.nextPoppedStateMask != baseline.nextPoppedStateMask) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.nextPoppedStateMask, baseline.nextPoppedStateMask, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 8);
			if ((num & 1) != 0)
			{
				snapshot.nextState = reader.ReadPackedIntDelta(baseline.nextState, in compressionModel);
			}
			else
			{
				snapshot.nextState = baseline.nextState;
			}
			if ((num & 2) != 0)
			{
				snapshot.level1State = reader.ReadPackedIntDelta(baseline.level1State, in compressionModel);
			}
			else
			{
				snapshot.level1State = baseline.level1State;
			}
			if ((num & 4) != 0)
			{
				snapshot.level2State = reader.ReadPackedIntDelta(baseline.level2State, in compressionModel);
			}
			else
			{
				snapshot.level2State = baseline.level2State;
			}
			if ((num & 8) != 0)
			{
				snapshot.level3State = reader.ReadPackedIntDelta(baseline.level3State, in compressionModel);
			}
			else
			{
				snapshot.level3State = baseline.level3State;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.isStateLocked = reader.ReadPackedUIntDelta(baseline.isStateLocked, in compressionModel);
			}
			else
			{
				snapshot.isStateLocked = baseline.isStateLocked;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.nextStateLocked = reader.ReadPackedUIntDelta(baseline.nextStateLocked, in compressionModel);
			}
			else
			{
				snapshot.nextStateLocked = baseline.nextStateLocked;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.nextStatePushed = reader.ReadPackedUIntDelta(baseline.nextStatePushed, in compressionModel);
			}
			else
			{
				snapshot.nextStatePushed = baseline.nextStatePushed;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.nextPoppedStateMask = reader.ReadPackedIntDelta(baseline.nextPoppedStateMask, in compressionModel);
			}
			else
			{
				snapshot.nextPoppedStateMask = baseline.nextPoppedStateMask;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 16877093822059739888uL,
					ComponentType = ComponentType.ReadWrite<PlayerStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<PlayerStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 8,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 8035656825479101806uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<PlayerStateCD, Snapshot, PlayerStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
