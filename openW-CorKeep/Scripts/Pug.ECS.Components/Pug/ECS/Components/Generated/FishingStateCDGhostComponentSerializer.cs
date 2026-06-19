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
	public struct FishingStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint castTimer_startTick;

			public uint castTimer_targetTicks;

			public uint castTimer_stopTick;

			public uint throwTimer_startTick;

			public uint throwTimer_targetTicks;

			public uint throwTimer_stopTick;

			public uint pullUpTimer_startTick;

			public uint pullUpTimer_targetTicks;

			public uint pullUpTimer_stopTick;

			public uint allowedToLeaveStateTimer_startTick;

			public uint allowedToLeaveStateTimer_targetTicks;

			public uint allowedToLeaveStateTimer_stopTick;

			public uint fishBiteTimer_startTick;

			public uint fishBiteTimer_targetTicks;

			public uint fishBiteTimer_stopTick;

			public uint queueThrowAgain;

			public uint isSuccessfullyFishing;

			public uint fishOnTheHook;

			public int fishShoalEntity;

			public uint fishShoalEntitySpawnTick;

			public int octopusBossSpawnLocationEntity;

			public uint octopusBossSpawnLocationEntitySpawnTick;

			public int octopusBossEntity;

			public uint octopusBossEntitySpawnTick;

			public uint fishIsNibbling;

			public int fishingLootToSpawn;

			public float targetSinkWorldPosition_x;

			public float targetSinkWorldPosition_y;

			public float targetSinkWorldPosition_z;

			public uint useFishingMiniGame;

			public int startingBaitObjectID;

			public int caughtFishCounter;
		}

		private const int ChangeMaskBits = 27;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 27;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<FishingStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<FishingStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<FishingStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<FishingStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in FishingStateCD component)
		{
			snapshot.castTimer_startTick = component.castTimer.startTick.SerializedData;
			snapshot.castTimer_targetTicks = component.castTimer.targetTicks;
			snapshot.castTimer_stopTick = component.castTimer.stopTick.SerializedData;
			snapshot.throwTimer_startTick = component.throwTimer.startTick.SerializedData;
			snapshot.throwTimer_targetTicks = component.throwTimer.targetTicks;
			snapshot.throwTimer_stopTick = component.throwTimer.stopTick.SerializedData;
			snapshot.pullUpTimer_startTick = component.pullUpTimer.startTick.SerializedData;
			snapshot.pullUpTimer_targetTicks = component.pullUpTimer.targetTicks;
			snapshot.pullUpTimer_stopTick = component.pullUpTimer.stopTick.SerializedData;
			snapshot.allowedToLeaveStateTimer_startTick = component.allowedToLeaveStateTimer.startTick.SerializedData;
			snapshot.allowedToLeaveStateTimer_targetTicks = component.allowedToLeaveStateTimer.targetTicks;
			snapshot.allowedToLeaveStateTimer_stopTick = component.allowedToLeaveStateTimer.stopTick.SerializedData;
			snapshot.fishBiteTimer_startTick = component.fishBiteTimer.startTick.SerializedData;
			snapshot.fishBiteTimer_targetTicks = component.fishBiteTimer.targetTicks;
			snapshot.fishBiteTimer_stopTick = component.fishBiteTimer.stopTick.SerializedData;
			snapshot.queueThrowAgain = (component.queueThrowAgain ? 1u : 0u);
			snapshot.isSuccessfullyFishing = (component.isSuccessfullyFishing ? 1u : 0u);
			snapshot.fishOnTheHook = (component.fishOnTheHook ? 1u : 0u);
			snapshot.fishShoalEntity = 0;
			snapshot.fishShoalEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.fishShoalEntity))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.fishShoalEntity];
				snapshot.fishShoalEntity = ghostInstance.ghostId;
				snapshot.fishShoalEntitySpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.octopusBossSpawnLocationEntity = 0;
			snapshot.octopusBossSpawnLocationEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.octopusBossSpawnLocationEntity))
			{
				GhostInstance ghostInstance2 = serializerState.GhostFromEntity[component.octopusBossSpawnLocationEntity];
				snapshot.octopusBossSpawnLocationEntity = ghostInstance2.ghostId;
				snapshot.octopusBossSpawnLocationEntitySpawnTick = ghostInstance2.spawnTick.SerializedData;
			}
			snapshot.octopusBossEntity = 0;
			snapshot.octopusBossEntitySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.octopusBossEntity))
			{
				GhostInstance ghostInstance3 = serializerState.GhostFromEntity[component.octopusBossEntity];
				snapshot.octopusBossEntity = ghostInstance3.ghostId;
				snapshot.octopusBossEntitySpawnTick = ghostInstance3.spawnTick.SerializedData;
			}
			snapshot.fishIsNibbling = (component.fishIsNibbling ? 1u : 0u);
			snapshot.fishingLootToSpawn = (int)component.fishingLootToSpawn;
			snapshot.targetSinkWorldPosition_x = component.targetSinkWorldPosition.x;
			snapshot.targetSinkWorldPosition_y = component.targetSinkWorldPosition.y;
			snapshot.targetSinkWorldPosition_z = component.targetSinkWorldPosition.z;
			snapshot.useFishingMiniGame = (component.useFishingMiniGame ? 1u : 0u);
			snapshot.startingBaitObjectID = (int)component.startingBaitObjectID;
			snapshot.caughtFishCounter = component.caughtFishCounter;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref FishingStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.castTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.castTimer_startTick
			};
			component.castTimer.targetTicks = snapshotBefore.castTimer_targetTicks;
			component.castTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.castTimer_stopTick
			};
			component.throwTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.throwTimer_startTick
			};
			component.throwTimer.targetTicks = snapshotBefore.throwTimer_targetTicks;
			component.throwTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.throwTimer_stopTick
			};
			component.pullUpTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.pullUpTimer_startTick
			};
			component.pullUpTimer.targetTicks = snapshotBefore.pullUpTimer_targetTicks;
			component.pullUpTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.pullUpTimer_stopTick
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
			component.fishBiteTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.fishBiteTimer_startTick
			};
			component.fishBiteTimer.targetTicks = snapshotBefore.fishBiteTimer_targetTicks;
			component.fishBiteTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.fishBiteTimer_stopTick
			};
			component.queueThrowAgain = snapshotBefore.queueThrowAgain != 0;
			component.isSuccessfullyFishing = snapshotBefore.isSuccessfullyFishing != 0;
			component.fishOnTheHook = snapshotBefore.fishOnTheHook != 0;
			component.fishShoalEntity = Entity.Null;
			if (snapshotBefore.fishShoalEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.fishShoalEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.fishShoalEntitySpawnTick
				}
			}, out var item))
			{
				component.fishShoalEntity = item;
			}
			component.octopusBossSpawnLocationEntity = Entity.Null;
			if (snapshotBefore.octopusBossSpawnLocationEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.octopusBossSpawnLocationEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.octopusBossSpawnLocationEntitySpawnTick
				}
			}, out var item2))
			{
				component.octopusBossSpawnLocationEntity = item2;
			}
			component.octopusBossEntity = Entity.Null;
			if (snapshotBefore.octopusBossEntity != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.octopusBossEntity,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.octopusBossEntitySpawnTick
				}
			}, out var item3))
			{
				component.octopusBossEntity = item3;
			}
			component.fishIsNibbling = snapshotBefore.fishIsNibbling != 0;
			component.fishingLootToSpawn = (ObjectID)snapshotBefore.fishingLootToSpawn;
			component.targetSinkWorldPosition = new float3(snapshotBefore.targetSinkWorldPosition_x, snapshotBefore.targetSinkWorldPosition_y, snapshotBefore.targetSinkWorldPosition_z);
			component.useFishingMiniGame = snapshotBefore.useFishingMiniGame != 0;
			component.startingBaitObjectID = (ObjectID)snapshotBefore.startingBaitObjectID;
			component.caughtFishCounter = snapshotBefore.caughtFishCounter;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref FishingStateCD component, in FishingStateCD backup)
		{
			component.castTimer.startTick = backup.castTimer.startTick;
			component.castTimer.targetTicks = backup.castTimer.targetTicks;
			component.castTimer.stopTick = backup.castTimer.stopTick;
			component.throwTimer.startTick = backup.throwTimer.startTick;
			component.throwTimer.targetTicks = backup.throwTimer.targetTicks;
			component.throwTimer.stopTick = backup.throwTimer.stopTick;
			component.pullUpTimer.startTick = backup.pullUpTimer.startTick;
			component.pullUpTimer.targetTicks = backup.pullUpTimer.targetTicks;
			component.pullUpTimer.stopTick = backup.pullUpTimer.stopTick;
			component.allowedToLeaveStateTimer.startTick = backup.allowedToLeaveStateTimer.startTick;
			component.allowedToLeaveStateTimer.targetTicks = backup.allowedToLeaveStateTimer.targetTicks;
			component.allowedToLeaveStateTimer.stopTick = backup.allowedToLeaveStateTimer.stopTick;
			component.fishBiteTimer.startTick = backup.fishBiteTimer.startTick;
			component.fishBiteTimer.targetTicks = backup.fishBiteTimer.targetTicks;
			component.fishBiteTimer.stopTick = backup.fishBiteTimer.stopTick;
			component.queueThrowAgain = backup.queueThrowAgain;
			component.isSuccessfullyFishing = backup.isSuccessfullyFishing;
			component.fishOnTheHook = backup.fishOnTheHook;
			component.fishShoalEntity = backup.fishShoalEntity;
			component.octopusBossSpawnLocationEntity = backup.octopusBossSpawnLocationEntity;
			component.octopusBossEntity = backup.octopusBossEntity;
			component.fishIsNibbling = backup.fishIsNibbling;
			component.fishingLootToSpawn = backup.fishingLootToSpawn;
			component.targetSinkWorldPosition.x = backup.targetSinkWorldPosition.x;
			component.targetSinkWorldPosition.y = backup.targetSinkWorldPosition.y;
			component.targetSinkWorldPosition.z = backup.targetSinkWorldPosition.z;
			component.useFishingMiniGame = backup.useFishingMiniGame;
			component.startingBaitObjectID = backup.startingBaitObjectID;
			component.caughtFishCounter = backup.caughtFishCounter;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.castTimer_startTick = (uint)predictor.PredictInt((int)snapshot.castTimer_startTick, (int)baseline1.castTimer_startTick, (int)baseline2.castTimer_startTick);
			snapshot.castTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.castTimer_targetTicks, (int)baseline1.castTimer_targetTicks, (int)baseline2.castTimer_targetTicks);
			snapshot.castTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.castTimer_stopTick, (int)baseline1.castTimer_stopTick, (int)baseline2.castTimer_stopTick);
			snapshot.throwTimer_startTick = (uint)predictor.PredictInt((int)snapshot.throwTimer_startTick, (int)baseline1.throwTimer_startTick, (int)baseline2.throwTimer_startTick);
			snapshot.throwTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.throwTimer_targetTicks, (int)baseline1.throwTimer_targetTicks, (int)baseline2.throwTimer_targetTicks);
			snapshot.throwTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.throwTimer_stopTick, (int)baseline1.throwTimer_stopTick, (int)baseline2.throwTimer_stopTick);
			snapshot.pullUpTimer_startTick = (uint)predictor.PredictInt((int)snapshot.pullUpTimer_startTick, (int)baseline1.pullUpTimer_startTick, (int)baseline2.pullUpTimer_startTick);
			snapshot.pullUpTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.pullUpTimer_targetTicks, (int)baseline1.pullUpTimer_targetTicks, (int)baseline2.pullUpTimer_targetTicks);
			snapshot.pullUpTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.pullUpTimer_stopTick, (int)baseline1.pullUpTimer_stopTick, (int)baseline2.pullUpTimer_stopTick);
			snapshot.allowedToLeaveStateTimer_startTick = (uint)predictor.PredictInt((int)snapshot.allowedToLeaveStateTimer_startTick, (int)baseline1.allowedToLeaveStateTimer_startTick, (int)baseline2.allowedToLeaveStateTimer_startTick);
			snapshot.allowedToLeaveStateTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.allowedToLeaveStateTimer_targetTicks, (int)baseline1.allowedToLeaveStateTimer_targetTicks, (int)baseline2.allowedToLeaveStateTimer_targetTicks);
			snapshot.allowedToLeaveStateTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.allowedToLeaveStateTimer_stopTick, (int)baseline1.allowedToLeaveStateTimer_stopTick, (int)baseline2.allowedToLeaveStateTimer_stopTick);
			snapshot.fishBiteTimer_startTick = (uint)predictor.PredictInt((int)snapshot.fishBiteTimer_startTick, (int)baseline1.fishBiteTimer_startTick, (int)baseline2.fishBiteTimer_startTick);
			snapshot.fishBiteTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.fishBiteTimer_targetTicks, (int)baseline1.fishBiteTimer_targetTicks, (int)baseline2.fishBiteTimer_targetTicks);
			snapshot.fishBiteTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.fishBiteTimer_stopTick, (int)baseline1.fishBiteTimer_stopTick, (int)baseline2.fishBiteTimer_stopTick);
			snapshot.queueThrowAgain = (uint)predictor.PredictInt((int)snapshot.queueThrowAgain, (int)baseline1.queueThrowAgain, (int)baseline2.queueThrowAgain);
			snapshot.isSuccessfullyFishing = (uint)predictor.PredictInt((int)snapshot.isSuccessfullyFishing, (int)baseline1.isSuccessfullyFishing, (int)baseline2.isSuccessfullyFishing);
			snapshot.fishOnTheHook = (uint)predictor.PredictInt((int)snapshot.fishOnTheHook, (int)baseline1.fishOnTheHook, (int)baseline2.fishOnTheHook);
			snapshot.fishShoalEntity = predictor.PredictInt(snapshot.fishShoalEntity, baseline1.fishShoalEntity, baseline2.fishShoalEntity);
			snapshot.fishShoalEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.fishShoalEntitySpawnTick, (int)baseline1.fishShoalEntitySpawnTick, baseline2.fishShoalEntity);
			snapshot.octopusBossSpawnLocationEntity = predictor.PredictInt(snapshot.octopusBossSpawnLocationEntity, baseline1.octopusBossSpawnLocationEntity, baseline2.octopusBossSpawnLocationEntity);
			snapshot.octopusBossSpawnLocationEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.octopusBossSpawnLocationEntitySpawnTick, (int)baseline1.octopusBossSpawnLocationEntitySpawnTick, baseline2.octopusBossSpawnLocationEntity);
			snapshot.octopusBossEntity = predictor.PredictInt(snapshot.octopusBossEntity, baseline1.octopusBossEntity, baseline2.octopusBossEntity);
			snapshot.octopusBossEntitySpawnTick = (uint)predictor.PredictInt((int)snapshot.octopusBossEntitySpawnTick, (int)baseline1.octopusBossEntitySpawnTick, baseline2.octopusBossEntity);
			snapshot.fishIsNibbling = (uint)predictor.PredictInt((int)snapshot.fishIsNibbling, (int)baseline1.fishIsNibbling, (int)baseline2.fishIsNibbling);
			snapshot.fishingLootToSpawn = predictor.PredictInt(snapshot.fishingLootToSpawn, baseline1.fishingLootToSpawn, baseline2.fishingLootToSpawn);
			snapshot.useFishingMiniGame = (uint)predictor.PredictInt((int)snapshot.useFishingMiniGame, (int)baseline1.useFishingMiniGame, (int)baseline2.useFishingMiniGame);
			snapshot.startingBaitObjectID = predictor.PredictInt(snapshot.startingBaitObjectID, baseline1.startingBaitObjectID, baseline2.startingBaitObjectID);
			snapshot.caughtFishCounter = predictor.PredictInt(snapshot.caughtFishCounter, baseline1.caughtFishCounter, baseline2.caughtFishCounter);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.castTimer_startTick != baseline.castTimer_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.castTimer_targetTicks != baseline.castTimer_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.castTimer_stopTick != baseline.castTimer_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.throwTimer_startTick != baseline.throwTimer_startTick) ? 8 : 0);
			num |= (uint)((snapshot.throwTimer_targetTicks != baseline.throwTimer_targetTicks) ? 16 : 0);
			num |= (uint)((snapshot.throwTimer_stopTick != baseline.throwTimer_stopTick) ? 32 : 0);
			num |= (uint)((snapshot.pullUpTimer_startTick != baseline.pullUpTimer_startTick) ? 64 : 0);
			num |= (uint)((snapshot.pullUpTimer_targetTicks != baseline.pullUpTimer_targetTicks) ? 128 : 0);
			num |= (uint)((snapshot.pullUpTimer_stopTick != baseline.pullUpTimer_stopTick) ? 256 : 0);
			num |= (uint)((snapshot.allowedToLeaveStateTimer_startTick != baseline.allowedToLeaveStateTimer_startTick) ? 512 : 0);
			num |= (uint)((snapshot.allowedToLeaveStateTimer_targetTicks != baseline.allowedToLeaveStateTimer_targetTicks) ? 1024 : 0);
			num |= (uint)((snapshot.allowedToLeaveStateTimer_stopTick != baseline.allowedToLeaveStateTimer_stopTick) ? 2048 : 0);
			num |= (uint)((snapshot.fishBiteTimer_startTick != baseline.fishBiteTimer_startTick) ? 4096 : 0);
			num |= (uint)((snapshot.fishBiteTimer_targetTicks != baseline.fishBiteTimer_targetTicks) ? 8192 : 0);
			num |= (uint)((snapshot.fishBiteTimer_stopTick != baseline.fishBiteTimer_stopTick) ? 16384 : 0);
			num |= (uint)((snapshot.queueThrowAgain != baseline.queueThrowAgain) ? 32768 : 0);
			num |= (uint)((snapshot.isSuccessfullyFishing != baseline.isSuccessfullyFishing) ? 65536 : 0);
			num |= (uint)((snapshot.fishOnTheHook != baseline.fishOnTheHook) ? 131072 : 0);
			num |= (uint)((snapshot.fishShoalEntity != baseline.fishShoalEntity || snapshot.fishShoalEntitySpawnTick != baseline.fishShoalEntitySpawnTick) ? 262144 : 0);
			num |= (uint)((snapshot.octopusBossSpawnLocationEntity != baseline.octopusBossSpawnLocationEntity || snapshot.octopusBossSpawnLocationEntitySpawnTick != baseline.octopusBossSpawnLocationEntitySpawnTick) ? 524288 : 0);
			num |= (uint)((snapshot.octopusBossEntity != baseline.octopusBossEntity || snapshot.octopusBossEntitySpawnTick != baseline.octopusBossEntitySpawnTick) ? 1048576 : 0);
			num |= (uint)((snapshot.fishIsNibbling != baseline.fishIsNibbling) ? 2097152 : 0);
			num |= (uint)((snapshot.fishingLootToSpawn != baseline.fishingLootToSpawn) ? 4194304 : 0);
			num |= (uint)((snapshot.targetSinkWorldPosition_x != baseline.targetSinkWorldPosition_x) ? 8388608 : 0);
			num |= (uint)((snapshot.targetSinkWorldPosition_y != baseline.targetSinkWorldPosition_y) ? 8388608 : 0);
			num |= (uint)((snapshot.targetSinkWorldPosition_z != baseline.targetSinkWorldPosition_z) ? 8388608 : 0);
			num |= (uint)((snapshot.useFishingMiniGame != baseline.useFishingMiniGame) ? 16777216 : 0);
			num |= (uint)((snapshot.startingBaitObjectID != baseline.startingBaitObjectID) ? 33554432 : 0);
			num |= (uint)((snapshot.caughtFishCounter != baseline.caughtFishCounter) ? 67108864 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 27);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 27);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.castTimer_startTick, baseline.castTimer_startTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.castTimer_targetTicks, baseline.castTimer_targetTicks, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.castTimer_stopTick, baseline.castTimer_stopTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.throwTimer_startTick, baseline.throwTimer_startTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.throwTimer_targetTicks, baseline.throwTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.throwTimer_stopTick, baseline.throwTimer_stopTick, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.pullUpTimer_startTick, baseline.pullUpTimer_startTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.pullUpTimer_targetTicks, baseline.pullUpTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.pullUpTimer_stopTick, baseline.pullUpTimer_stopTick, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_startTick, baseline.allowedToLeaveStateTimer_startTick, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_targetTicks, baseline.allowedToLeaveStateTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_stopTick, baseline.allowedToLeaveStateTimer_stopTick, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishBiteTimer_startTick, baseline.fishBiteTimer_startTick, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishBiteTimer_targetTicks, baseline.fishBiteTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishBiteTimer_stopTick, baseline.fishBiteTimer_stopTick, in compressionModel);
			}
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.queueThrowAgain, baseline.queueThrowAgain, in compressionModel);
			}
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isSuccessfullyFishing, baseline.isSuccessfullyFishing, in compressionModel);
			}
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishOnTheHook, baseline.fishOnTheHook, in compressionModel);
			}
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.fishShoalEntity, baseline.fishShoalEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.fishShoalEntitySpawnTick, baseline.fishShoalEntitySpawnTick, in compressionModel);
			}
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.octopusBossSpawnLocationEntity, baseline.octopusBossSpawnLocationEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.octopusBossSpawnLocationEntitySpawnTick, baseline.octopusBossSpawnLocationEntitySpawnTick, in compressionModel);
			}
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.octopusBossEntity, baseline.octopusBossEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.octopusBossEntitySpawnTick, baseline.octopusBossEntitySpawnTick, in compressionModel);
			}
			if ((num & 0x200000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishIsNibbling, baseline.fishIsNibbling, in compressionModel);
			}
			if ((num & 0x400000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.fishingLootToSpawn, baseline.fishingLootToSpawn, in compressionModel);
			}
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetSinkWorldPosition_x, baseline.targetSinkWorldPosition_x, in compressionModel);
			}
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetSinkWorldPosition_y, baseline.targetSinkWorldPosition_y, in compressionModel);
			}
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetSinkWorldPosition_z, baseline.targetSinkWorldPosition_z, in compressionModel);
			}
			if ((num & 0x1000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.useFishingMiniGame, baseline.useFishingMiniGame, in compressionModel);
			}
			if ((num & 0x2000000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.startingBaitObjectID, baseline.startingBaitObjectID, in compressionModel);
			}
			if ((num & 0x4000000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.caughtFishCounter, baseline.caughtFishCounter, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.castTimer_startTick != baseline.castTimer_startTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.castTimer_startTick, baseline.castTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.castTimer_targetTicks != baseline.castTimer_targetTicks) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.castTimer_targetTicks, baseline.castTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.castTimer_stopTick != baseline.castTimer_stopTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.castTimer_stopTick, baseline.castTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.throwTimer_startTick != baseline.throwTimer_startTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.throwTimer_startTick, baseline.throwTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.throwTimer_targetTicks != baseline.throwTimer_targetTicks) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.throwTimer_targetTicks, baseline.throwTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.throwTimer_stopTick != baseline.throwTimer_stopTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.throwTimer_stopTick, baseline.throwTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.pullUpTimer_startTick != baseline.pullUpTimer_startTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.pullUpTimer_startTick, baseline.pullUpTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.pullUpTimer_targetTicks != baseline.pullUpTimer_targetTicks) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.pullUpTimer_targetTicks, baseline.pullUpTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.pullUpTimer_stopTick != baseline.pullUpTimer_stopTick) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.pullUpTimer_stopTick, baseline.pullUpTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.allowedToLeaveStateTimer_startTick != baseline.allowedToLeaveStateTimer_startTick) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_startTick, baseline.allowedToLeaveStateTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.allowedToLeaveStateTimer_targetTicks != baseline.allowedToLeaveStateTimer_targetTicks) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_targetTicks, baseline.allowedToLeaveStateTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.allowedToLeaveStateTimer_stopTick != baseline.allowedToLeaveStateTimer_stopTick) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.allowedToLeaveStateTimer_stopTick, baseline.allowedToLeaveStateTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.fishBiteTimer_startTick != baseline.fishBiteTimer_startTick) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishBiteTimer_startTick, baseline.fishBiteTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.fishBiteTimer_targetTicks != baseline.fishBiteTimer_targetTicks) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishBiteTimer_targetTicks, baseline.fishBiteTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.fishBiteTimer_stopTick != baseline.fishBiteTimer_stopTick) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishBiteTimer_stopTick, baseline.fishBiteTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.queueThrowAgain != baseline.queueThrowAgain) ? 32768 : 0);
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.queueThrowAgain, baseline.queueThrowAgain, in compressionModel);
			}
			num |= (uint)((snapshot.isSuccessfullyFishing != baseline.isSuccessfullyFishing) ? 65536 : 0);
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isSuccessfullyFishing, baseline.isSuccessfullyFishing, in compressionModel);
			}
			num |= (uint)((snapshot.fishOnTheHook != baseline.fishOnTheHook) ? 131072 : 0);
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishOnTheHook, baseline.fishOnTheHook, in compressionModel);
			}
			num |= (uint)((snapshot.fishShoalEntity != baseline.fishShoalEntity || snapshot.fishShoalEntitySpawnTick != baseline.fishShoalEntitySpawnTick) ? 262144 : 0);
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.fishShoalEntity, baseline.fishShoalEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.fishShoalEntitySpawnTick, baseline.fishShoalEntitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.octopusBossSpawnLocationEntity != baseline.octopusBossSpawnLocationEntity || snapshot.octopusBossSpawnLocationEntitySpawnTick != baseline.octopusBossSpawnLocationEntitySpawnTick) ? 524288 : 0);
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.octopusBossSpawnLocationEntity, baseline.octopusBossSpawnLocationEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.octopusBossSpawnLocationEntitySpawnTick, baseline.octopusBossSpawnLocationEntitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.octopusBossEntity != baseline.octopusBossEntity || snapshot.octopusBossEntitySpawnTick != baseline.octopusBossEntitySpawnTick) ? 1048576 : 0);
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.octopusBossEntity, baseline.octopusBossEntity, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.octopusBossEntitySpawnTick, baseline.octopusBossEntitySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.fishIsNibbling != baseline.fishIsNibbling) ? 2097152 : 0);
			if ((num & 0x200000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishIsNibbling, baseline.fishIsNibbling, in compressionModel);
			}
			num |= (uint)((snapshot.fishingLootToSpawn != baseline.fishingLootToSpawn) ? 4194304 : 0);
			if ((num & 0x400000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.fishingLootToSpawn, baseline.fishingLootToSpawn, in compressionModel);
			}
			num |= (uint)((snapshot.targetSinkWorldPosition_x != baseline.targetSinkWorldPosition_x) ? 8388608 : 0);
			num |= (uint)((snapshot.targetSinkWorldPosition_y != baseline.targetSinkWorldPosition_y) ? 8388608 : 0);
			num |= (uint)((snapshot.targetSinkWorldPosition_z != baseline.targetSinkWorldPosition_z) ? 8388608 : 0);
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetSinkWorldPosition_x, baseline.targetSinkWorldPosition_x, in compressionModel);
			}
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetSinkWorldPosition_y, baseline.targetSinkWorldPosition_y, in compressionModel);
			}
			if ((num & 0x800000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.targetSinkWorldPosition_z, baseline.targetSinkWorldPosition_z, in compressionModel);
			}
			num |= (uint)((snapshot.useFishingMiniGame != baseline.useFishingMiniGame) ? 16777216 : 0);
			if ((num & 0x1000000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.useFishingMiniGame, baseline.useFishingMiniGame, in compressionModel);
			}
			num |= (uint)((snapshot.startingBaitObjectID != baseline.startingBaitObjectID) ? 33554432 : 0);
			if ((num & 0x2000000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.startingBaitObjectID, baseline.startingBaitObjectID, in compressionModel);
			}
			num |= (uint)((snapshot.caughtFishCounter != baseline.caughtFishCounter) ? 67108864 : 0);
			if ((num & 0x4000000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.caughtFishCounter, baseline.caughtFishCounter, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 27);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 27);
			if ((num & 1) != 0)
			{
				snapshot.castTimer_startTick = reader.ReadPackedUIntDelta(baseline.castTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.castTimer_startTick = baseline.castTimer_startTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.castTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.castTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.castTimer_targetTicks = baseline.castTimer_targetTicks;
			}
			if ((num & 4) != 0)
			{
				snapshot.castTimer_stopTick = reader.ReadPackedUIntDelta(baseline.castTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.castTimer_stopTick = baseline.castTimer_stopTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.throwTimer_startTick = reader.ReadPackedUIntDelta(baseline.throwTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.throwTimer_startTick = baseline.throwTimer_startTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.throwTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.throwTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.throwTimer_targetTicks = baseline.throwTimer_targetTicks;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.throwTimer_stopTick = reader.ReadPackedUIntDelta(baseline.throwTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.throwTimer_stopTick = baseline.throwTimer_stopTick;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.pullUpTimer_startTick = reader.ReadPackedUIntDelta(baseline.pullUpTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.pullUpTimer_startTick = baseline.pullUpTimer_startTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.pullUpTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.pullUpTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.pullUpTimer_targetTicks = baseline.pullUpTimer_targetTicks;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.pullUpTimer_stopTick = reader.ReadPackedUIntDelta(baseline.pullUpTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.pullUpTimer_stopTick = baseline.pullUpTimer_stopTick;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.allowedToLeaveStateTimer_startTick = reader.ReadPackedUIntDelta(baseline.allowedToLeaveStateTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.allowedToLeaveStateTimer_startTick = baseline.allowedToLeaveStateTimer_startTick;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.allowedToLeaveStateTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.allowedToLeaveStateTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.allowedToLeaveStateTimer_targetTicks = baseline.allowedToLeaveStateTimer_targetTicks;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.allowedToLeaveStateTimer_stopTick = reader.ReadPackedUIntDelta(baseline.allowedToLeaveStateTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.allowedToLeaveStateTimer_stopTick = baseline.allowedToLeaveStateTimer_stopTick;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.fishBiteTimer_startTick = reader.ReadPackedUIntDelta(baseline.fishBiteTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.fishBiteTimer_startTick = baseline.fishBiteTimer_startTick;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.fishBiteTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.fishBiteTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.fishBiteTimer_targetTicks = baseline.fishBiteTimer_targetTicks;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.fishBiteTimer_stopTick = reader.ReadPackedUIntDelta(baseline.fishBiteTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.fishBiteTimer_stopTick = baseline.fishBiteTimer_stopTick;
			}
			if ((num & 0x8000) != 0)
			{
				snapshot.queueThrowAgain = reader.ReadPackedUIntDelta(baseline.queueThrowAgain, in compressionModel);
			}
			else
			{
				snapshot.queueThrowAgain = baseline.queueThrowAgain;
			}
			if ((num & 0x10000) != 0)
			{
				snapshot.isSuccessfullyFishing = reader.ReadPackedUIntDelta(baseline.isSuccessfullyFishing, in compressionModel);
			}
			else
			{
				snapshot.isSuccessfullyFishing = baseline.isSuccessfullyFishing;
			}
			if ((num & 0x20000) != 0)
			{
				snapshot.fishOnTheHook = reader.ReadPackedUIntDelta(baseline.fishOnTheHook, in compressionModel);
			}
			else
			{
				snapshot.fishOnTheHook = baseline.fishOnTheHook;
			}
			if ((num & 0x40000) != 0)
			{
				snapshot.fishShoalEntity = reader.ReadPackedIntDelta(baseline.fishShoalEntity, in compressionModel);
				snapshot.fishShoalEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.fishShoalEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.fishShoalEntity = baseline.fishShoalEntity;
				snapshot.fishShoalEntitySpawnTick = baseline.fishShoalEntitySpawnTick;
			}
			if ((num & 0x80000) != 0)
			{
				snapshot.octopusBossSpawnLocationEntity = reader.ReadPackedIntDelta(baseline.octopusBossSpawnLocationEntity, in compressionModel);
				snapshot.octopusBossSpawnLocationEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.octopusBossSpawnLocationEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.octopusBossSpawnLocationEntity = baseline.octopusBossSpawnLocationEntity;
				snapshot.octopusBossSpawnLocationEntitySpawnTick = baseline.octopusBossSpawnLocationEntitySpawnTick;
			}
			if ((num & 0x100000) != 0)
			{
				snapshot.octopusBossEntity = reader.ReadPackedIntDelta(baseline.octopusBossEntity, in compressionModel);
				snapshot.octopusBossEntitySpawnTick = reader.ReadPackedUIntDelta(baseline.octopusBossEntitySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.octopusBossEntity = baseline.octopusBossEntity;
				snapshot.octopusBossEntitySpawnTick = baseline.octopusBossEntitySpawnTick;
			}
			if ((num & 0x200000) != 0)
			{
				snapshot.fishIsNibbling = reader.ReadPackedUIntDelta(baseline.fishIsNibbling, in compressionModel);
			}
			else
			{
				snapshot.fishIsNibbling = baseline.fishIsNibbling;
			}
			if ((num & 0x400000) != 0)
			{
				snapshot.fishingLootToSpawn = reader.ReadPackedIntDelta(baseline.fishingLootToSpawn, in compressionModel);
			}
			else
			{
				snapshot.fishingLootToSpawn = baseline.fishingLootToSpawn;
			}
			if ((num & 0x800000) != 0)
			{
				snapshot.targetSinkWorldPosition_x = reader.ReadPackedFloatDelta(baseline.targetSinkWorldPosition_x, in compressionModel);
			}
			else
			{
				snapshot.targetSinkWorldPosition_x = baseline.targetSinkWorldPosition_x;
			}
			if ((num & 0x800000) != 0)
			{
				snapshot.targetSinkWorldPosition_y = reader.ReadPackedFloatDelta(baseline.targetSinkWorldPosition_y, in compressionModel);
			}
			else
			{
				snapshot.targetSinkWorldPosition_y = baseline.targetSinkWorldPosition_y;
			}
			if ((num & 0x800000) != 0)
			{
				snapshot.targetSinkWorldPosition_z = reader.ReadPackedFloatDelta(baseline.targetSinkWorldPosition_z, in compressionModel);
			}
			else
			{
				snapshot.targetSinkWorldPosition_z = baseline.targetSinkWorldPosition_z;
			}
			if ((num & 0x1000000) != 0)
			{
				snapshot.useFishingMiniGame = reader.ReadPackedUIntDelta(baseline.useFishingMiniGame, in compressionModel);
			}
			else
			{
				snapshot.useFishingMiniGame = baseline.useFishingMiniGame;
			}
			if ((num & 0x2000000) != 0)
			{
				snapshot.startingBaitObjectID = reader.ReadPackedIntDelta(baseline.startingBaitObjectID, in compressionModel);
			}
			else
			{
				snapshot.startingBaitObjectID = baseline.startingBaitObjectID;
			}
			if ((num & 0x4000000) != 0)
			{
				snapshot.caughtFishCounter = reader.ReadPackedIntDelta(baseline.caughtFishCounter, in compressionModel);
			}
			else
			{
				snapshot.caughtFishCounter = baseline.caughtFishCounter;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1352795039825984254uL,
					ComponentType = ComponentType.ReadWrite<FishingStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<FishingStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 27,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 11945669944982433372uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<FishingStateCD, Snapshot, FishingStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
