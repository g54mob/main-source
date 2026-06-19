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
	public struct BossLarvaCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public float currentRotationX;

			public float currentRotationY;

			public float currentRotationZ;

			public float currentRotationW;

			public int currentPhase;

			public int segment0;

			public uint segment0SpawnTick;

			public int segment1;

			public uint segment1SpawnTick;

			public int segment2;

			public uint segment2SpawnTick;

			public int segment3;

			public uint segment3SpawnTick;

			public int segment4;

			public uint segment4SpawnTick;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<BossLarvaCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<BossLarvaCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<BossLarvaCD>(component), in GhostComponentSerializer.TypeCastReadonly<BossLarvaCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in BossLarvaCD component)
		{
			snapshot.currentRotationX = component.currentRotation.value.x;
			snapshot.currentRotationY = component.currentRotation.value.y;
			snapshot.currentRotationZ = component.currentRotation.value.z;
			snapshot.currentRotationW = component.currentRotation.value.w;
			snapshot.currentPhase = component.currentPhase;
			snapshot.segment0 = 0;
			snapshot.segment0SpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.segment0))
			{
				GhostInstance ghostInstance = serializerState.GhostFromEntity[component.segment0];
				snapshot.segment0 = ghostInstance.ghostId;
				snapshot.segment0SpawnTick = ghostInstance.spawnTick.SerializedData;
			}
			snapshot.segment1 = 0;
			snapshot.segment1SpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.segment1))
			{
				GhostInstance ghostInstance2 = serializerState.GhostFromEntity[component.segment1];
				snapshot.segment1 = ghostInstance2.ghostId;
				snapshot.segment1SpawnTick = ghostInstance2.spawnTick.SerializedData;
			}
			snapshot.segment2 = 0;
			snapshot.segment2SpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.segment2))
			{
				GhostInstance ghostInstance3 = serializerState.GhostFromEntity[component.segment2];
				snapshot.segment2 = ghostInstance3.ghostId;
				snapshot.segment2SpawnTick = ghostInstance3.spawnTick.SerializedData;
			}
			snapshot.segment3 = 0;
			snapshot.segment3SpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.segment3))
			{
				GhostInstance ghostInstance4 = serializerState.GhostFromEntity[component.segment3];
				snapshot.segment3 = ghostInstance4.ghostId;
				snapshot.segment3SpawnTick = ghostInstance4.spawnTick.SerializedData;
			}
			snapshot.segment4 = 0;
			snapshot.segment4SpawnTick = NetworkTick.Invalid.SerializedData;
			if (serializerState.GhostFromEntity.HasComponent(component.segment4))
			{
				GhostInstance ghostInstance5 = serializerState.GhostFromEntity[component.segment4];
				snapshot.segment4 = ghostInstance5.ghostId;
				snapshot.segment4SpawnTick = ghostInstance5.spawnTick.SerializedData;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref BossLarvaCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.currentRotation = new quaternion(snapshotBefore.currentRotationX, snapshotBefore.currentRotationY, snapshotBefore.currentRotationZ, snapshotBefore.currentRotationW);
			component.currentPhase = snapshotBefore.currentPhase;
			component.segment0 = Entity.Null;
			if (snapshotBefore.segment0 != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.segment0,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.segment0SpawnTick
				}
			}, out var item))
			{
				component.segment0 = item;
			}
			component.segment1 = Entity.Null;
			if (snapshotBefore.segment1 != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.segment1,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.segment1SpawnTick
				}
			}, out var item2))
			{
				component.segment1 = item2;
			}
			component.segment2 = Entity.Null;
			if (snapshotBefore.segment2 != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.segment2,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.segment2SpawnTick
				}
			}, out var item3))
			{
				component.segment2 = item3;
			}
			component.segment3 = Entity.Null;
			if (snapshotBefore.segment3 != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.segment3,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.segment3SpawnTick
				}
			}, out var item4))
			{
				component.segment3 = item4;
			}
			component.segment4 = Entity.Null;
			if (snapshotBefore.segment4 != 0 && deserializerState.GhostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = snapshotBefore.segment4,
				spawnTick = new NetworkTick
				{
					SerializedData = snapshotBefore.segment4SpawnTick
				}
			}, out var item5))
			{
				component.segment4 = item5;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref BossLarvaCD component, in BossLarvaCD backup)
		{
			component.currentRotation = backup.currentRotation;
			component.currentPhase = backup.currentPhase;
			component.segment0 = backup.segment0;
			component.segment1 = backup.segment1;
			component.segment2 = backup.segment2;
			component.segment3 = backup.segment3;
			component.segment4 = backup.segment4;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.currentPhase = predictor.PredictInt(snapshot.currentPhase, baseline1.currentPhase, baseline2.currentPhase);
			snapshot.segment0 = predictor.PredictInt(snapshot.segment0, baseline1.segment0, baseline2.segment0);
			snapshot.segment0SpawnTick = (uint)predictor.PredictInt((int)snapshot.segment0SpawnTick, (int)baseline1.segment0SpawnTick, baseline2.segment0);
			snapshot.segment1 = predictor.PredictInt(snapshot.segment1, baseline1.segment1, baseline2.segment1);
			snapshot.segment1SpawnTick = (uint)predictor.PredictInt((int)snapshot.segment1SpawnTick, (int)baseline1.segment1SpawnTick, baseline2.segment1);
			snapshot.segment2 = predictor.PredictInt(snapshot.segment2, baseline1.segment2, baseline2.segment2);
			snapshot.segment2SpawnTick = (uint)predictor.PredictInt((int)snapshot.segment2SpawnTick, (int)baseline1.segment2SpawnTick, baseline2.segment2);
			snapshot.segment3 = predictor.PredictInt(snapshot.segment3, baseline1.segment3, baseline2.segment3);
			snapshot.segment3SpawnTick = (uint)predictor.PredictInt((int)snapshot.segment3SpawnTick, (int)baseline1.segment3SpawnTick, baseline2.segment3);
			snapshot.segment4 = predictor.PredictInt(snapshot.segment4, baseline1.segment4, baseline2.segment4);
			snapshot.segment4SpawnTick = (uint)predictor.PredictInt((int)snapshot.segment4SpawnTick, (int)baseline1.segment4SpawnTick, baseline2.segment4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.currentRotationX != baseline.currentRotationX || snapshot.currentRotationY != baseline.currentRotationY || snapshot.currentRotationZ != baseline.currentRotationZ || snapshot.currentRotationW != baseline.currentRotationW) ? 1u : 0u);
			num |= (uint)((snapshot.currentPhase != baseline.currentPhase) ? 2 : 0);
			num |= (uint)((snapshot.segment0 != baseline.segment0 || snapshot.segment0SpawnTick != baseline.segment0SpawnTick) ? 4 : 0);
			num |= (uint)((snapshot.segment1 != baseline.segment1 || snapshot.segment1SpawnTick != baseline.segment1SpawnTick) ? 8 : 0);
			num |= (uint)((snapshot.segment2 != baseline.segment2 || snapshot.segment2SpawnTick != baseline.segment2SpawnTick) ? 16 : 0);
			num |= (uint)((snapshot.segment3 != baseline.segment3 || snapshot.segment3SpawnTick != baseline.segment3SpawnTick) ? 32 : 0);
			num |= (uint)((snapshot.segment4 != baseline.segment4 || snapshot.segment4SpawnTick != baseline.segment4SpawnTick) ? 64 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentRotationX, baseline.currentRotationX, in compressionModel);
				writer.WritePackedFloatDelta(snapshot.currentRotationY, baseline.currentRotationY, in compressionModel);
				writer.WritePackedFloatDelta(snapshot.currentRotationZ, baseline.currentRotationZ, in compressionModel);
				writer.WritePackedFloatDelta(snapshot.currentRotationW, baseline.currentRotationW, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.currentPhase, baseline.currentPhase, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segment0, baseline.segment0, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.segment0SpawnTick, baseline.segment0SpawnTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segment1, baseline.segment1, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.segment1SpawnTick, baseline.segment1SpawnTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segment2, baseline.segment2, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.segment2SpawnTick, baseline.segment2SpawnTick, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segment3, baseline.segment3, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.segment3SpawnTick, baseline.segment3SpawnTick, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segment4, baseline.segment4, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.segment4SpawnTick, baseline.segment4SpawnTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.currentRotationX != baseline.currentRotationX || snapshot.currentRotationY != baseline.currentRotationY || snapshot.currentRotationZ != baseline.currentRotationZ || snapshot.currentRotationW != baseline.currentRotationW) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.currentRotationX, baseline.currentRotationX, in compressionModel);
				writer.WritePackedFloatDelta(snapshot.currentRotationY, baseline.currentRotationY, in compressionModel);
				writer.WritePackedFloatDelta(snapshot.currentRotationZ, baseline.currentRotationZ, in compressionModel);
				writer.WritePackedFloatDelta(snapshot.currentRotationW, baseline.currentRotationW, in compressionModel);
			}
			num |= (uint)((snapshot.currentPhase != baseline.currentPhase) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.currentPhase, baseline.currentPhase, in compressionModel);
			}
			num |= (uint)((snapshot.segment0 != baseline.segment0 || snapshot.segment0SpawnTick != baseline.segment0SpawnTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segment0, baseline.segment0, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.segment0SpawnTick, baseline.segment0SpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.segment1 != baseline.segment1 || snapshot.segment1SpawnTick != baseline.segment1SpawnTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segment1, baseline.segment1, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.segment1SpawnTick, baseline.segment1SpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.segment2 != baseline.segment2 || snapshot.segment2SpawnTick != baseline.segment2SpawnTick) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segment2, baseline.segment2, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.segment2SpawnTick, baseline.segment2SpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.segment3 != baseline.segment3 || snapshot.segment3SpawnTick != baseline.segment3SpawnTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segment3, baseline.segment3, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.segment3SpawnTick, baseline.segment3SpawnTick, in compressionModel);
			}
			num |= (uint)((snapshot.segment4 != baseline.segment4 || snapshot.segment4SpawnTick != baseline.segment4SpawnTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.segment4, baseline.segment4, in compressionModel);
				writer.WritePackedUIntDelta(snapshot.segment4SpawnTick, baseline.segment4SpawnTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 7);
			if ((num & 1) != 0)
			{
				snapshot.currentRotationX = reader.ReadPackedFloatDelta(baseline.currentRotationX, in compressionModel);
				snapshot.currentRotationY = reader.ReadPackedFloatDelta(baseline.currentRotationY, in compressionModel);
				snapshot.currentRotationZ = reader.ReadPackedFloatDelta(baseline.currentRotationZ, in compressionModel);
				snapshot.currentRotationW = reader.ReadPackedFloatDelta(baseline.currentRotationW, in compressionModel);
			}
			else
			{
				snapshot.currentRotationX = baseline.currentRotationX;
				snapshot.currentRotationY = baseline.currentRotationY;
				snapshot.currentRotationZ = baseline.currentRotationZ;
				snapshot.currentRotationW = baseline.currentRotationW;
			}
			if ((num & 2) != 0)
			{
				snapshot.currentPhase = reader.ReadPackedIntDelta(baseline.currentPhase, in compressionModel);
			}
			else
			{
				snapshot.currentPhase = baseline.currentPhase;
			}
			if ((num & 4) != 0)
			{
				snapshot.segment0 = reader.ReadPackedIntDelta(baseline.segment0, in compressionModel);
				snapshot.segment0SpawnTick = reader.ReadPackedUIntDelta(baseline.segment0SpawnTick, in compressionModel);
			}
			else
			{
				snapshot.segment0 = baseline.segment0;
				snapshot.segment0SpawnTick = baseline.segment0SpawnTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.segment1 = reader.ReadPackedIntDelta(baseline.segment1, in compressionModel);
				snapshot.segment1SpawnTick = reader.ReadPackedUIntDelta(baseline.segment1SpawnTick, in compressionModel);
			}
			else
			{
				snapshot.segment1 = baseline.segment1;
				snapshot.segment1SpawnTick = baseline.segment1SpawnTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.segment2 = reader.ReadPackedIntDelta(baseline.segment2, in compressionModel);
				snapshot.segment2SpawnTick = reader.ReadPackedUIntDelta(baseline.segment2SpawnTick, in compressionModel);
			}
			else
			{
				snapshot.segment2 = baseline.segment2;
				snapshot.segment2SpawnTick = baseline.segment2SpawnTick;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.segment3 = reader.ReadPackedIntDelta(baseline.segment3, in compressionModel);
				snapshot.segment3SpawnTick = reader.ReadPackedUIntDelta(baseline.segment3SpawnTick, in compressionModel);
			}
			else
			{
				snapshot.segment3 = baseline.segment3;
				snapshot.segment3SpawnTick = baseline.segment3SpawnTick;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.segment4 = reader.ReadPackedIntDelta(baseline.segment4, in compressionModel);
				snapshot.segment4SpawnTick = reader.ReadPackedUIntDelta(baseline.segment4SpawnTick, in compressionModel);
			}
			else
			{
				snapshot.segment4 = baseline.segment4;
				snapshot.segment4SpawnTick = baseline.segment4SpawnTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1966819302090705106uL,
					ComponentType = ComponentType.ReadWrite<BossLarvaCD>(),
					ComponentSize = UnsafeUtility.SizeOf<BossLarvaCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 7,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 1337281800963773332uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<BossLarvaCD, Snapshot, BossLarvaCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
