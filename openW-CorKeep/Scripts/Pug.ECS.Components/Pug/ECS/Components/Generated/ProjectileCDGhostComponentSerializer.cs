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
	public struct ProjectileCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public float prevPos_x;

			public float prevPos_y;

			public float prevPrevPos_x;

			public float prevPrevPos_y;

			public int lastHitEnemy;

			public uint lastHitEnemySpawnTick;

			public float directionRadians;
		}

		private const int ChangeMaskBits = 4;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 4;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ProjectileCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ProjectileCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ProjectileCD>(component), in GhostComponentSerializer.TypeCastReadonly<ProjectileCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ProjectileCD component)
		{
			snapshot.prevPos_x = component.prevPos.x;
			snapshot.prevPos_y = component.prevPos.y;
			snapshot.prevPrevPos_x = component.prevPrevPos.x;
			snapshot.prevPrevPos_y = component.prevPrevPos.y;
			snapshot.lastHitEnemy = 0;
			snapshot.lastHitEnemySpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.lastHitEnemy))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.lastHitEnemy];
				snapshot.lastHitEnemy = ghostInstance.ghostId;
				snapshot.lastHitEnemySpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.directionRadians = component.directionRadians;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ProjectileCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.prevPos = new float2(snapshotBefore.prevPos_x, snapshotBefore.prevPos_y);
			component.prevPrevPos = new float2(snapshotBefore.prevPrevPos_x, snapshotBefore.prevPrevPos_y);
			component.lastHitEnemy = Entity.Null;
			if (snapshotBefore.lastHitEnemy != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.lastHitEnemy,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.lastHitEnemySpawnTick
				}
			}, out var item))
			{
				component.lastHitEnemy = item;
			}
			component.directionRadians = snapshotBefore.directionRadians;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ProjectileCD component, in ProjectileCD backup)
		{
			component.prevPos.x = backup.prevPos.x;
			component.prevPos.y = backup.prevPos.y;
			component.prevPrevPos.x = backup.prevPrevPos.x;
			component.prevPrevPos.y = backup.prevPrevPos.y;
			component.lastHitEnemy = backup.lastHitEnemy;
			component.directionRadians = backup.directionRadians;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.lastHitEnemy = predictor.PredictInt(snapshot.lastHitEnemy, baseline1.lastHitEnemy, baseline2.lastHitEnemy);
			snapshot.lastHitEnemySpawnTick = (uint)predictor.PredictInt((int)snapshot.lastHitEnemySpawnTick, (int)baseline1.lastHitEnemySpawnTick, baseline2.lastHitEnemy);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.prevPos_x != baseline.prevPos_x) ? 1u : 0u);
			num |= (uint)((snapshot.prevPos_y != baseline.prevPos_y) ? 1 : 0);
			num |= (uint)((snapshot.prevPrevPos_x != baseline.prevPrevPos_x) ? 2 : 0);
			num |= (uint)((snapshot.prevPrevPos_y != baseline.prevPrevPos_y) ? 2 : 0);
			num |= (uint)((snapshot.lastHitEnemy != baseline.lastHitEnemy || snapshot.lastHitEnemySpawnTick != baseline.lastHitEnemySpawnTick) ? 4 : 0);
			num |= (uint)((snapshot.directionRadians != baseline.directionRadians) ? 8 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 4);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPos_x, baseline.prevPos_x, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPos_y, baseline.prevPos_y, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPrevPos_x, baseline.prevPrevPos_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPrevPos_y, baseline.prevPrevPos_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.lastHitEnemy, baseline.lastHitEnemy, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.lastHitEnemySpawnTick, baseline.lastHitEnemySpawnTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.directionRadians, baseline.directionRadians, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.prevPos_x != baseline.prevPos_x) ? 1u : 0u);
			num |= (uint)((snapshot.prevPos_y != baseline.prevPos_y) ? 1 : 0);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPos_x, baseline.prevPos_x, in compressionModel);
			}
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPos_y, baseline.prevPos_y, in compressionModel);
			}
			num |= (uint)((snapshot.prevPrevPos_x != baseline.prevPrevPos_x) ? 2 : 0);
			num |= (uint)((snapshot.prevPrevPos_y != baseline.prevPrevPos_y) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPrevPos_x, baseline.prevPrevPos_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.prevPrevPos_y, baseline.prevPrevPos_y, in compressionModel);
			}
			num |= (uint)((snapshot.lastHitEnemy != baseline.lastHitEnemy || snapshot.lastHitEnemySpawnTick != baseline.lastHitEnemySpawnTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.lastHitEnemy, baseline.lastHitEnemy, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.lastHitEnemySpawnTick, baseline.lastHitEnemySpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.directionRadians != baseline.directionRadians) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.directionRadians, baseline.directionRadians, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 4);
			if ((num & 1) != 0)
			{
				snapshot.prevPos_x = reader.ReadPackedFloatDelta(baseline.prevPos_x, in compressionModel);
			}
			else
			{
				snapshot.prevPos_x = baseline.prevPos_x;
			}
			if ((num & 1) != 0)
			{
				snapshot.prevPos_y = reader.ReadPackedFloatDelta(baseline.prevPos_y, in compressionModel);
			}
			else
			{
				snapshot.prevPos_y = baseline.prevPos_y;
			}
			if ((num & 2) != 0)
			{
				snapshot.prevPrevPos_x = reader.ReadPackedFloatDelta(baseline.prevPrevPos_x, in compressionModel);
			}
			else
			{
				snapshot.prevPrevPos_x = baseline.prevPrevPos_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.prevPrevPos_y = reader.ReadPackedFloatDelta(baseline.prevPrevPos_y, in compressionModel);
			}
			else
			{
				snapshot.prevPrevPos_y = baseline.prevPrevPos_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.lastHitEnemy = reader.ReadPackedIntDelta(baseline.lastHitEnemy, in compressionModel);
				snapshot.lastHitEnemySpawnTick = reader.ReadPackedUIntDelta(baseline.lastHitEnemySpawnTick, in compressionModel);
			}
			else
			{
				snapshot.lastHitEnemy = baseline.lastHitEnemy;
				snapshot.lastHitEnemySpawnTick = baseline.lastHitEnemySpawnTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.directionRadians = reader.ReadPackedFloatDelta(baseline.directionRadians, in compressionModel);
			}
			else
			{
				snapshot.directionRadians = baseline.directionRadians;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 5032326342240550756uL,
					ComponentType = ComponentType.ReadWrite<ProjectileCD>(),
					ComponentSize = UnsafeUtility.SizeOf<ProjectileCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 4,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 15563923098960743252uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ProjectileCD, Snapshot, ProjectileCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
