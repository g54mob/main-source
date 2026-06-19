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
	public struct ControllingOtherEntityCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int requestToBeControlledEntity;

			public uint requestToBeControlledEntitySpawnTick;

			public int controlledEntity;

			public uint controlledEntitySpawnTick;
		}

		private const int ChangeMaskBits = 2;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 2;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ControllingOtherEntityCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ControllingOtherEntityCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ControllingOtherEntityCD>(component), in GhostComponentSerializer.TypeCastReadonly<ControllingOtherEntityCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ControllingOtherEntityCD component)
		{
			snapshot.requestToBeControlledEntity = 0;
			snapshot.requestToBeControlledEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.requestToBeControlledEntity))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.requestToBeControlledEntity];
				snapshot.requestToBeControlledEntity = ghostInstance.ghostId;
				snapshot.requestToBeControlledEntitySpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.controlledEntity = 0;
			snapshot.controlledEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.controlledEntity))
			{
				GhostInstance ghostInstance2 = serializerState.GhostFromEntity[component.controlledEntity];
				snapshot.controlledEntity = ghostInstance2.ghostId;
				snapshot.controlledEntitySpawnTick = ghostInstance2.spawnTick.SerializedData;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ControllingOtherEntityCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.requestToBeControlledEntity = Entity.Null;
			if (snapshotBefore.requestToBeControlledEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.requestToBeControlledEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.requestToBeControlledEntitySpawnTick
				}
			}, out var item))
			{
				component.requestToBeControlledEntity = item;
			}
			component.controlledEntity = Entity.Null;
			if (snapshotBefore.controlledEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.controlledEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.controlledEntitySpawnTick
				}
			}, out var item2))
			{
				component.controlledEntity = item2;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ControllingOtherEntityCD component, in ControllingOtherEntityCD backup)
		{
			component.requestToBeControlledEntity = backup.requestToBeControlledEntity;
			component.controlledEntity = backup.controlledEntity;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.requestToBeControlledEntity = predictor.PredictInt(snapshot.requestToBeControlledEntity, baseline1.requestToBeControlledEntity, baseline2.requestToBeControlledEntity);
			snapshot.requestToBeControlledEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.requestToBeControlledEntitySpawnTick, (int)baseline1.requestToBeControlledEntitySpawnTick, baseline2.requestToBeControlledEntity);
			snapshot.controlledEntity = predictor.PredictInt(snapshot.controlledEntity, baseline1.controlledEntity, baseline2.controlledEntity);
			snapshot.controlledEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.controlledEntitySpawnTick, (int)baseline1.controlledEntitySpawnTick, baseline2.controlledEntity);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.requestToBeControlledEntity != baseline.requestToBeControlledEntity || snapshot.requestToBeControlledEntitySpawnTick != baseline.requestToBeControlledEntitySpawnTick) ? 1u : 0u);
			num |= (uint)((snapshot.controlledEntity != baseline.controlledEntity || snapshot.controlledEntitySpawnTick != baseline.controlledEntitySpawnTick) ? 2 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 2);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.requestToBeControlledEntity, baseline.requestToBeControlledEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.requestToBeControlledEntitySpawnTick, baseline.requestToBeControlledEntitySpawnTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.controlledEntity, baseline.controlledEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.controlledEntitySpawnTick, baseline.controlledEntitySpawnTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.requestToBeControlledEntity != baseline.requestToBeControlledEntity || snapshot.requestToBeControlledEntitySpawnTick != baseline.requestToBeControlledEntitySpawnTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.requestToBeControlledEntity, baseline.requestToBeControlledEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.requestToBeControlledEntitySpawnTick, baseline.requestToBeControlledEntitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.controlledEntity != baseline.controlledEntity || snapshot.controlledEntitySpawnTick != baseline.controlledEntitySpawnTick) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.controlledEntity, baseline.controlledEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.controlledEntitySpawnTick, baseline.controlledEntitySpawnTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 2);
			if ((num & 1) != 0)
			{
				snapshot.requestToBeControlledEntity = reader.ReadPackedIntDelta(baseline.requestToBeControlledEntity, in compressionModel);
				snapshot.requestToBeControlledEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.requestToBeControlledEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.requestToBeControlledEntity = baseline.requestToBeControlledEntity;
				snapshot.requestToBeControlledEntitySpawnTick = baseline.requestToBeControlledEntitySpawnTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.controlledEntity = reader.ReadPackedIntDelta(baseline.controlledEntity, in compressionModel);
				snapshot.controlledEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.controlledEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.controlledEntity = baseline.controlledEntity;
				snapshot.controlledEntitySpawnTick = baseline.controlledEntitySpawnTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 15715212353518195692uL,
					ComponentType = ComponentType.ReadWrite<ControllingOtherEntityCD>(),
					ComponentSize = UnsafeUtility.SizeOf<ControllingOtherEntityCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 2,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 2428645859570488458uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ControllingOtherEntityCD, Snapshot, ControllingOtherEntityCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
