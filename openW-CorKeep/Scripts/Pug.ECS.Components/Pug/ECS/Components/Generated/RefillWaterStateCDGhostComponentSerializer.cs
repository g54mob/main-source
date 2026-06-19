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
	public struct RefillWaterStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int waterSourceEntity;

			public uint waterSourceEntitySpawnTick;

			public int tileset;

			public float pickupWorldPosition_x;

			public float pickupWorldPosition_y;

			public float pickupWorldPosition_z;

			public uint refillWaterDuration_startTick;

			public uint refillWaterDuration_targetTicks;

			public uint refillWaterDuration_stopTick;

			public uint particleDelay_startTick;

			public uint particleDelay_targetTicks;

			public uint particleDelay_stopTick;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<RefillWaterStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<RefillWaterStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<RefillWaterStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<RefillWaterStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in RefillWaterStateCD component)
		{
			snapshot.waterSourceEntity = 0;
			snapshot.waterSourceEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.waterSourceEntity))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.waterSourceEntity];
				snapshot.waterSourceEntity = ghostInstance.ghostId;
				snapshot.waterSourceEntitySpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.tileset = component.tileset;
			snapshot.pickupWorldPosition_x = component.pickupWorldPosition.x;
			snapshot.pickupWorldPosition_y = component.pickupWorldPosition.y;
			snapshot.pickupWorldPosition_z = component.pickupWorldPosition.z;
			snapshot.refillWaterDuration_startTick = component.refillWaterDuration.startTick.SerializedData;
			snapshot.refillWaterDuration_targetTicks = component.refillWaterDuration.targetTicks;
			snapshot.refillWaterDuration_stopTick = component.refillWaterDuration.stopTick.SerializedData;
			snapshot.particleDelay_startTick = component.particleDelay.startTick.SerializedData;
			snapshot.particleDelay_targetTicks = component.particleDelay.targetTicks;
			snapshot.particleDelay_stopTick = component.particleDelay.stopTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref RefillWaterStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.waterSourceEntity = Entity.Null;
			if (snapshotBefore.waterSourceEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.waterSourceEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.waterSourceEntitySpawnTick
				}
			}, out var item))
			{
				component.waterSourceEntity = item;
			}
			component.tileset = snapshotBefore.tileset;
			component.pickupWorldPosition = new float3(snapshotBefore.pickupWorldPosition_x, snapshotBefore.pickupWorldPosition_y, snapshotBefore.pickupWorldPosition_z);
			component.refillWaterDuration.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.refillWaterDuration_startTick
			};
			component.refillWaterDuration.targetTicks = snapshotBefore.refillWaterDuration_targetTicks;
			component.refillWaterDuration.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.refillWaterDuration_stopTick
			};
			component.particleDelay.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.particleDelay_startTick
			};
			component.particleDelay.targetTicks = snapshotBefore.particleDelay_targetTicks;
			component.particleDelay.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.particleDelay_stopTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref RefillWaterStateCD component, in RefillWaterStateCD backup)
		{
			component.waterSourceEntity = backup.waterSourceEntity;
			component.tileset = backup.tileset;
			component.pickupWorldPosition.x = backup.pickupWorldPosition.x;
			component.pickupWorldPosition.y = backup.pickupWorldPosition.y;
			component.pickupWorldPosition.z = backup.pickupWorldPosition.z;
			component.refillWaterDuration.startTick = backup.refillWaterDuration.startTick;
			component.refillWaterDuration.targetTicks = backup.refillWaterDuration.targetTicks;
			component.refillWaterDuration.stopTick = backup.refillWaterDuration.stopTick;
			component.particleDelay.startTick = backup.particleDelay.startTick;
			component.particleDelay.targetTicks = backup.particleDelay.targetTicks;
			component.particleDelay.stopTick = backup.particleDelay.stopTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.waterSourceEntity = predictor.PredictInt(snapshot.waterSourceEntity, baseline1.waterSourceEntity, baseline2.waterSourceEntity);
			snapshot.waterSourceEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.waterSourceEntitySpawnTick, (int)baseline1.waterSourceEntitySpawnTick, baseline2.waterSourceEntity);
			snapshot.tileset = predictor.PredictInt(snapshot.tileset, baseline1.tileset, baseline2.tileset);
			snapshot.refillWaterDuration_startTick = (uint)predictor.PredictInt((int)snapshot.refillWaterDuration_startTick, (int)baseline1.refillWaterDuration_startTick, (int)baseline2.refillWaterDuration_startTick);
			snapshot.refillWaterDuration_targetTicks = (uint)predictor.PredictInt((int)snapshot.refillWaterDuration_targetTicks, (int)baseline1.refillWaterDuration_targetTicks, (int)baseline2.refillWaterDuration_targetTicks);
			snapshot.refillWaterDuration_stopTick = (uint)predictor.PredictInt((int)snapshot.refillWaterDuration_stopTick, (int)baseline1.refillWaterDuration_stopTick, (int)baseline2.refillWaterDuration_stopTick);
			snapshot.particleDelay_startTick = (uint)predictor.PredictInt((int)snapshot.particleDelay_startTick, (int)baseline1.particleDelay_startTick, (int)baseline2.particleDelay_startTick);
			snapshot.particleDelay_targetTicks = (uint)predictor.PredictInt((int)snapshot.particleDelay_targetTicks, (int)baseline1.particleDelay_targetTicks, (int)baseline2.particleDelay_targetTicks);
			snapshot.particleDelay_stopTick = (uint)predictor.PredictInt((int)snapshot.particleDelay_stopTick, (int)baseline1.particleDelay_stopTick, (int)baseline2.particleDelay_stopTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.waterSourceEntity != baseline.waterSourceEntity || snapshot.waterSourceEntitySpawnTick != baseline.waterSourceEntitySpawnTick) ? 1u : 0u);
			num |= (uint)((snapshot.tileset != baseline.tileset) ? 2 : 0);
			num |= (uint)((snapshot.pickupWorldPosition_x != baseline.pickupWorldPosition_x) ? 4 : 0);
			num |= (uint)((snapshot.pickupWorldPosition_y != baseline.pickupWorldPosition_y) ? 4 : 0);
			num |= (uint)((snapshot.pickupWorldPosition_z != baseline.pickupWorldPosition_z) ? 4 : 0);
			num |= (uint)((snapshot.refillWaterDuration_startTick != baseline.refillWaterDuration_startTick) ? 8 : 0);
			num |= (uint)((snapshot.refillWaterDuration_targetTicks != baseline.refillWaterDuration_targetTicks) ? 16 : 0);
			num |= (uint)((snapshot.refillWaterDuration_stopTick != baseline.refillWaterDuration_stopTick) ? 32 : 0);
			num |= (uint)((snapshot.particleDelay_startTick != baseline.particleDelay_startTick) ? 64 : 0);
			num |= (uint)((snapshot.particleDelay_targetTicks != baseline.particleDelay_targetTicks) ? 128 : 0);
			num |= (uint)((snapshot.particleDelay_stopTick != baseline.particleDelay_stopTick) ? 256 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 9);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 9);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.waterSourceEntity, baseline.waterSourceEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.waterSourceEntitySpawnTick, baseline.waterSourceEntitySpawnTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileset, baseline.tileset, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pickupWorldPosition_x, baseline.pickupWorldPosition_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pickupWorldPosition_y, baseline.pickupWorldPosition_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pickupWorldPosition_z, baseline.pickupWorldPosition_z, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.refillWaterDuration_startTick, baseline.refillWaterDuration_startTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.refillWaterDuration_targetTicks, baseline.refillWaterDuration_targetTicks, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.refillWaterDuration_stopTick, baseline.refillWaterDuration_stopTick, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_startTick, baseline.particleDelay_startTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_targetTicks, baseline.particleDelay_targetTicks, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_stopTick, baseline.particleDelay_stopTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.waterSourceEntity != baseline.waterSourceEntity || snapshot.waterSourceEntitySpawnTick != baseline.waterSourceEntitySpawnTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.waterSourceEntity, baseline.waterSourceEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.waterSourceEntitySpawnTick, baseline.waterSourceEntitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.tileset != baseline.tileset) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.tileset, baseline.tileset, in compressionModel);
			}
			num |= (uint)((snapshot.pickupWorldPosition_x != baseline.pickupWorldPosition_x) ? 4 : 0);
			num |= (uint)((snapshot.pickupWorldPosition_y != baseline.pickupWorldPosition_y) ? 4 : 0);
			num |= (uint)((snapshot.pickupWorldPosition_z != baseline.pickupWorldPosition_z) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pickupWorldPosition_x, baseline.pickupWorldPosition_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pickupWorldPosition_y, baseline.pickupWorldPosition_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pickupWorldPosition_z, baseline.pickupWorldPosition_z, in compressionModel);
			}
			num |= (uint)((snapshot.refillWaterDuration_startTick != baseline.refillWaterDuration_startTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.refillWaterDuration_startTick, baseline.refillWaterDuration_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.refillWaterDuration_targetTicks != baseline.refillWaterDuration_targetTicks) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.refillWaterDuration_targetTicks, baseline.refillWaterDuration_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.refillWaterDuration_stopTick != baseline.refillWaterDuration_stopTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.refillWaterDuration_stopTick, baseline.refillWaterDuration_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.particleDelay_startTick != baseline.particleDelay_startTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_startTick, baseline.particleDelay_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.particleDelay_targetTicks != baseline.particleDelay_targetTicks) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_targetTicks, baseline.particleDelay_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.particleDelay_stopTick != baseline.particleDelay_stopTick) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.particleDelay_stopTick, baseline.particleDelay_stopTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 9);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 9);
			if ((num & 1) != 0)
			{
				snapshot.waterSourceEntity = reader.ReadPackedIntDelta(baseline.waterSourceEntity, in compressionModel);
				snapshot.waterSourceEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.waterSourceEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.waterSourceEntity = baseline.waterSourceEntity;
				snapshot.waterSourceEntitySpawnTick = baseline.waterSourceEntitySpawnTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.tileset = reader.ReadPackedIntDelta(baseline.tileset, in compressionModel);
			}
			else
			{
				snapshot.tileset = baseline.tileset;
			}
			if ((num & 4) != 0)
			{
				snapshot.pickupWorldPosition_x = reader.ReadPackedFloatDelta(baseline.pickupWorldPosition_x, in compressionModel);
			}
			else
			{
				snapshot.pickupWorldPosition_x = baseline.pickupWorldPosition_x;
			}
			if ((num & 4) != 0)
			{
				snapshot.pickupWorldPosition_y = reader.ReadPackedFloatDelta(baseline.pickupWorldPosition_y, in compressionModel);
			}
			else
			{
				snapshot.pickupWorldPosition_y = baseline.pickupWorldPosition_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.pickupWorldPosition_z = reader.ReadPackedFloatDelta(baseline.pickupWorldPosition_z, in compressionModel);
			}
			else
			{
				snapshot.pickupWorldPosition_z = baseline.pickupWorldPosition_z;
			}
			if ((num & 8) != 0)
			{
				snapshot.refillWaterDuration_startTick = reader.ReadPackedUIntDelta(baseline.refillWaterDuration_startTick, in compressionModel);
			}
			else
			{
				snapshot.refillWaterDuration_startTick = baseline.refillWaterDuration_startTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.refillWaterDuration_targetTicks = reader.ReadPackedUIntDelta(baseline.refillWaterDuration_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.refillWaterDuration_targetTicks = baseline.refillWaterDuration_targetTicks;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.refillWaterDuration_stopTick = reader.ReadPackedUIntDelta(baseline.refillWaterDuration_stopTick, in compressionModel);
			}
			else
			{
				snapshot.refillWaterDuration_stopTick = baseline.refillWaterDuration_stopTick;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.particleDelay_startTick = reader.ReadPackedUIntDelta(baseline.particleDelay_startTick, in compressionModel);
			}
			else
			{
				snapshot.particleDelay_startTick = baseline.particleDelay_startTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.particleDelay_targetTicks = reader.ReadPackedUIntDelta(baseline.particleDelay_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.particleDelay_targetTicks = baseline.particleDelay_targetTicks;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.particleDelay_stopTick = reader.ReadPackedUIntDelta(baseline.particleDelay_stopTick, in compressionModel);
			}
			else
			{
				snapshot.particleDelay_stopTick = baseline.particleDelay_stopTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 7455028707620208954uL,
					ComponentType = ComponentType.ReadWrite<RefillWaterStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<RefillWaterStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 9,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 213407601381482802uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<RefillWaterStateCD, Snapshot, RefillWaterStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
