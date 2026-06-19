using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
	public struct SnakeMovementStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int headRef;

			public uint headRefSpawnTick;

			public float currentDirection_x;

			public float currentDirection_y;

			public float currentDirection_z;

			public int currentPhase;
		}

		private const int ChangeMaskBits = 3;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 3;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<SnakeMovementStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<SnakeMovementStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<SnakeMovementStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<SnakeMovementStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in SnakeMovementStateCD component)
		{
			snapshot.headRef = 0;
			snapshot.headRefSpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.headRef))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.headRef];
				snapshot.headRef = ghostInstance.ghostId;
				snapshot.headRefSpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.currentDirection_x = component.currentDirection.x;
			snapshot.currentDirection_y = component.currentDirection.y;
			snapshot.currentDirection_z = component.currentDirection.z;
			snapshot.currentPhase = (int)component.currentPhase;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref SnakeMovementStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.headRef = Entity.Null;
			if (snapshotBefore.headRef != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.headRef,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.headRefSpawnTick
				}
			}, out var item))
			{
				component.headRef = item;
			}
			component.currentDirection = new float3(snapshotBefore.currentDirection_x, snapshotBefore.currentDirection_y, snapshotBefore.currentDirection_z);
			component.currentPhase = (SnakeMovementPhaseType)snapshotBefore.currentPhase;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref SnakeMovementStateCD component, in SnakeMovementStateCD backup)
		{
			component.headRef = backup.headRef;
			component.currentDirection.x = backup.currentDirection.x;
			component.currentDirection.y = backup.currentDirection.y;
			component.currentDirection.z = backup.currentDirection.z;
			component.currentPhase = backup.currentPhase;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.headRef = predictor.PredictInt(snapshot.headRef, baseline1.headRef, baseline2.headRef);
			snapshot.headRefSpawnTick = (uint)predictor.PredictInt((int)snapshot.headRefSpawnTick, (int)baseline1.headRefSpawnTick, baseline2.headRef);
			snapshot.currentPhase = predictor.PredictInt(snapshot.currentPhase, baseline1.currentPhase, baseline2.currentPhase);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.headRef != baseline.headRef || snapshot.headRefSpawnTick != baseline.headRefSpawnTick) ? 1u : 0u);
			num |= (uint)((snapshot.currentDirection_x != baseline.currentDirection_x) ? 2 : 0);
			num |= (uint)((snapshot.currentDirection_y != baseline.currentDirection_y) ? 2 : 0);
			num |= (uint)((snapshot.currentDirection_z != baseline.currentDirection_z) ? 2 : 0);
			num |= (uint)((snapshot.currentPhase != baseline.currentPhase) ? 4 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 3);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.headRef, baseline.headRef, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.headRefSpawnTick, baseline.headRefSpawnTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentDirection_x, baseline.currentDirection_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentDirection_y, baseline.currentDirection_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentDirection_z, baseline.currentDirection_z, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.currentPhase, baseline.currentPhase, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.headRef != baseline.headRef || snapshot.headRefSpawnTick != baseline.headRefSpawnTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.headRef, baseline.headRef, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.headRefSpawnTick, baseline.headRefSpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.currentDirection_x != baseline.currentDirection_x) ? 2 : 0);
			num |= (uint)((snapshot.currentDirection_y != baseline.currentDirection_y) ? 2 : 0);
			num |= (uint)((snapshot.currentDirection_z != baseline.currentDirection_z) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentDirection_x, baseline.currentDirection_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentDirection_y, baseline.currentDirection_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentDirection_z, baseline.currentDirection_z, in compressionModel);
			}
			num |= (uint)((snapshot.currentPhase != baseline.currentPhase) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.currentPhase, baseline.currentPhase, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 3);
			if ((num & 1) != 0)
			{
				snapshot.headRef = reader.ReadPackedIntDelta(baseline.headRef, in compressionModel);
				snapshot.headRefSpawnTick = reader.ReadPackedUIntDelta(baseline.headRefSpawnTick, in compressionModel);
			}
			else
			{
				snapshot.headRef = baseline.headRef;
				snapshot.headRefSpawnTick = baseline.headRefSpawnTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.currentDirection_x = reader.ReadPackedFloatDelta(baseline.currentDirection_x, in compressionModel);
			}
			else
			{
				snapshot.currentDirection_x = baseline.currentDirection_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.currentDirection_y = reader.ReadPackedFloatDelta(baseline.currentDirection_y, in compressionModel);
			}
			else
			{
				snapshot.currentDirection_y = baseline.currentDirection_y;
			}
			if ((num & 2) != 0)
			{
				snapshot.currentDirection_z = reader.ReadPackedFloatDelta(baseline.currentDirection_z, in compressionModel);
			}
			else
			{
				snapshot.currentDirection_z = baseline.currentDirection_z;
			}
			if ((num & 4) != 0)
			{
				snapshot.currentPhase = reader.ReadPackedIntDelta(baseline.currentPhase, in compressionModel);
			}
			else
			{
				snapshot.currentPhase = baseline.currentPhase;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 12532388930504974478uL,
					ComponentType = ComponentType.ReadWrite<SnakeMovementStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<SnakeMovementStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 3,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 2554466419895600110uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<SnakeMovementStateCD, Snapshot, SnakeMovementStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
