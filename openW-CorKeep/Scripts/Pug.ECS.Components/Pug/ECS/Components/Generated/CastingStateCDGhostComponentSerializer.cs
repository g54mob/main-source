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
	public struct CastingStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint castTimer_startTick;

			public uint castTimer_targetTicks;

			public uint castTimer_stopTick;

			public int previousHealth;

			public int previousMaxHealth;

			public uint itemIsInProcessOfBeingUsed;

			public int objectData_objectID;

			public int objectData_amount;

			public int objectData_variation;

			public int objectData_variationUpdateCount;

			public int inventoryIndexOnCast;

			public uint exitStateDelayTimer_startTick;

			public uint exitStateDelayTimer_targetTicks;

			public uint exitStateDelayTimer_stopTick;

			public uint castCompleteEffect;
		}

		private const int ChangeMaskBits = 15;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 15;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<CastingStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<CastingStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<CastingStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<CastingStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in CastingStateCD component)
		{
			snapshot.castTimer_startTick = component.castTimer.startTick.SerializedData;
			snapshot.castTimer_targetTicks = component.castTimer.targetTicks;
			snapshot.castTimer_stopTick = component.castTimer.stopTick.SerializedData;
			snapshot.previousHealth = component.previousHealth;
			snapshot.previousMaxHealth = component.previousMaxHealth;
			snapshot.itemIsInProcessOfBeingUsed = (component.itemIsInProcessOfBeingUsed ? 1u : 0u);
			snapshot.objectData_objectID = (int)component.objectData.objectID;
			snapshot.objectData_amount = component.objectData.amount;
			snapshot.objectData_variation = component.objectData.variation;
			snapshot.objectData_variationUpdateCount = component.objectData.variationUpdateCount;
			snapshot.inventoryIndexOnCast = component.inventoryIndexOnCast;
			snapshot.exitStateDelayTimer_startTick = component.exitStateDelayTimer.startTick.SerializedData;
			snapshot.exitStateDelayTimer_targetTicks = component.exitStateDelayTimer.targetTicks;
			snapshot.exitStateDelayTimer_stopTick = component.exitStateDelayTimer.stopTick.SerializedData;
			snapshot.castCompleteEffect = (uint)component.castCompleteEffect;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref CastingStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
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
			component.previousHealth = snapshotBefore.previousHealth;
			component.previousMaxHealth = snapshotBefore.previousMaxHealth;
			component.itemIsInProcessOfBeingUsed = snapshotBefore.itemIsInProcessOfBeingUsed != 0;
			component.objectData.objectID = (ObjectID)snapshotBefore.objectData_objectID;
			component.objectData.amount = snapshotBefore.objectData_amount;
			component.objectData.variation = snapshotBefore.objectData_variation;
			component.objectData.variationUpdateCount = snapshotBefore.objectData_variationUpdateCount;
			component.inventoryIndexOnCast = snapshotBefore.inventoryIndexOnCast;
			component.exitStateDelayTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.exitStateDelayTimer_startTick
			};
			component.exitStateDelayTimer.targetTicks = snapshotBefore.exitStateDelayTimer_targetTicks;
			component.exitStateDelayTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.exitStateDelayTimer_stopTick
			};
			component.castCompleteEffect = (EffectID)snapshotBefore.castCompleteEffect;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref CastingStateCD component, in CastingStateCD backup)
		{
			component.castTimer.startTick = backup.castTimer.startTick;
			component.castTimer.targetTicks = backup.castTimer.targetTicks;
			component.castTimer.stopTick = backup.castTimer.stopTick;
			component.previousHealth = backup.previousHealth;
			component.previousMaxHealth = backup.previousMaxHealth;
			component.itemIsInProcessOfBeingUsed = backup.itemIsInProcessOfBeingUsed;
			component.objectData.objectID = backup.objectData.objectID;
			component.objectData.amount = backup.objectData.amount;
			component.objectData.variation = backup.objectData.variation;
			component.objectData.variationUpdateCount = backup.objectData.variationUpdateCount;
			component.inventoryIndexOnCast = backup.inventoryIndexOnCast;
			component.exitStateDelayTimer.startTick = backup.exitStateDelayTimer.startTick;
			component.exitStateDelayTimer.targetTicks = backup.exitStateDelayTimer.targetTicks;
			component.exitStateDelayTimer.stopTick = backup.exitStateDelayTimer.stopTick;
			component.castCompleteEffect = backup.castCompleteEffect;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.castTimer_startTick = (uint)predictor.PredictInt((int)snapshot.castTimer_startTick, (int)baseline1.castTimer_startTick, (int)baseline2.castTimer_startTick);
			snapshot.castTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.castTimer_targetTicks, (int)baseline1.castTimer_targetTicks, (int)baseline2.castTimer_targetTicks);
			snapshot.castTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.castTimer_stopTick, (int)baseline1.castTimer_stopTick, (int)baseline2.castTimer_stopTick);
			snapshot.previousHealth = predictor.PredictInt(snapshot.previousHealth, baseline1.previousHealth, baseline2.previousHealth);
			snapshot.previousMaxHealth = predictor.PredictInt(snapshot.previousMaxHealth, baseline1.previousMaxHealth, baseline2.previousMaxHealth);
			snapshot.itemIsInProcessOfBeingUsed = (uint)predictor.PredictInt((int)snapshot.itemIsInProcessOfBeingUsed, (int)baseline1.itemIsInProcessOfBeingUsed, (int)baseline2.itemIsInProcessOfBeingUsed);
			snapshot.objectData_objectID = predictor.PredictInt(snapshot.objectData_objectID, baseline1.objectData_objectID, baseline2.objectData_objectID);
			snapshot.objectData_amount = predictor.PredictInt(snapshot.objectData_amount, baseline1.objectData_amount, baseline2.objectData_amount);
			snapshot.objectData_variation = predictor.PredictInt(snapshot.objectData_variation, baseline1.objectData_variation, baseline2.objectData_variation);
			snapshot.objectData_variationUpdateCount = predictor.PredictInt(snapshot.objectData_variationUpdateCount, baseline1.objectData_variationUpdateCount, baseline2.objectData_variationUpdateCount);
			snapshot.inventoryIndexOnCast = predictor.PredictInt(snapshot.inventoryIndexOnCast, baseline1.inventoryIndexOnCast, baseline2.inventoryIndexOnCast);
			snapshot.exitStateDelayTimer_startTick = (uint)predictor.PredictInt((int)snapshot.exitStateDelayTimer_startTick, (int)baseline1.exitStateDelayTimer_startTick, (int)baseline2.exitStateDelayTimer_startTick);
			snapshot.exitStateDelayTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.exitStateDelayTimer_targetTicks, (int)baseline1.exitStateDelayTimer_targetTicks, (int)baseline2.exitStateDelayTimer_targetTicks);
			snapshot.exitStateDelayTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.exitStateDelayTimer_stopTick, (int)baseline1.exitStateDelayTimer_stopTick, (int)baseline2.exitStateDelayTimer_stopTick);
			snapshot.castCompleteEffect = (uint)predictor.PredictInt((int)snapshot.castCompleteEffect, (int)baseline1.castCompleteEffect, (int)baseline2.castCompleteEffect);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.castTimer_startTick != baseline.castTimer_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.castTimer_targetTicks != baseline.castTimer_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.castTimer_stopTick != baseline.castTimer_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.previousHealth != baseline.previousHealth) ? 8 : 0);
			num |= (uint)((snapshot.previousMaxHealth != baseline.previousMaxHealth) ? 16 : 0);
			num |= (uint)((snapshot.itemIsInProcessOfBeingUsed != baseline.itemIsInProcessOfBeingUsed) ? 32 : 0);
			num |= (uint)((snapshot.objectData_objectID != baseline.objectData_objectID) ? 64 : 0);
			num |= (uint)((snapshot.objectData_amount != baseline.objectData_amount) ? 128 : 0);
			num |= (uint)((snapshot.objectData_variation != baseline.objectData_variation) ? 256 : 0);
			num |= (uint)((snapshot.objectData_variationUpdateCount != baseline.objectData_variationUpdateCount) ? 512 : 0);
			num |= (uint)((snapshot.inventoryIndexOnCast != baseline.inventoryIndexOnCast) ? 1024 : 0);
			num |= (uint)((snapshot.exitStateDelayTimer_startTick != baseline.exitStateDelayTimer_startTick) ? 2048 : 0);
			num |= (uint)((snapshot.exitStateDelayTimer_targetTicks != baseline.exitStateDelayTimer_targetTicks) ? 4096 : 0);
			num |= (uint)((snapshot.exitStateDelayTimer_stopTick != baseline.exitStateDelayTimer_stopTick) ? 8192 : 0);
			num |= (uint)((snapshot.castCompleteEffect != baseline.castCompleteEffect) ? 16384 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 15);
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
				writer.WritePackedIntDelta(snapshot.previousHealth, baseline.previousHealth, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.previousMaxHealth, baseline.previousMaxHealth, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.itemIsInProcessOfBeingUsed, baseline.itemIsInProcessOfBeingUsed, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_objectID, baseline.objectData_objectID, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_amount, baseline.objectData_amount, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_variation, baseline.objectData_variation, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_variationUpdateCount, baseline.objectData_variationUpdateCount, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.inventoryIndexOnCast, baseline.inventoryIndexOnCast, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.exitStateDelayTimer_startTick, baseline.exitStateDelayTimer_startTick, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.exitStateDelayTimer_targetTicks, baseline.exitStateDelayTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.exitStateDelayTimer_stopTick, baseline.exitStateDelayTimer_stopTick, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.castCompleteEffect, baseline.castCompleteEffect, in compressionModel);
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
			num |= (uint)((snapshot.previousHealth != baseline.previousHealth) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.previousHealth, baseline.previousHealth, in compressionModel);
			}
			num |= (uint)((snapshot.previousMaxHealth != baseline.previousMaxHealth) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.previousMaxHealth, baseline.previousMaxHealth, in compressionModel);
			}
			num |= (uint)((snapshot.itemIsInProcessOfBeingUsed != baseline.itemIsInProcessOfBeingUsed) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.itemIsInProcessOfBeingUsed, baseline.itemIsInProcessOfBeingUsed, in compressionModel);
			}
			num |= (uint)((snapshot.objectData_objectID != baseline.objectData_objectID) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_objectID, baseline.objectData_objectID, in compressionModel);
			}
			num |= (uint)((snapshot.objectData_amount != baseline.objectData_amount) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_amount, baseline.objectData_amount, in compressionModel);
			}
			num |= (uint)((snapshot.objectData_variation != baseline.objectData_variation) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_variation, baseline.objectData_variation, in compressionModel);
			}
			num |= (uint)((snapshot.objectData_variationUpdateCount != baseline.objectData_variationUpdateCount) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.objectData_variationUpdateCount, baseline.objectData_variationUpdateCount, in compressionModel);
			}
			num |= (uint)((snapshot.inventoryIndexOnCast != baseline.inventoryIndexOnCast) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.inventoryIndexOnCast, baseline.inventoryIndexOnCast, in compressionModel);
			}
			num |= (uint)((snapshot.exitStateDelayTimer_startTick != baseline.exitStateDelayTimer_startTick) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.exitStateDelayTimer_startTick, baseline.exitStateDelayTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.exitStateDelayTimer_targetTicks != baseline.exitStateDelayTimer_targetTicks) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.exitStateDelayTimer_targetTicks, baseline.exitStateDelayTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.exitStateDelayTimer_stopTick != baseline.exitStateDelayTimer_stopTick) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.exitStateDelayTimer_stopTick, baseline.exitStateDelayTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.castCompleteEffect != baseline.castCompleteEffect) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.castCompleteEffect, baseline.castCompleteEffect, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 15);
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
				snapshot.previousHealth = reader.ReadPackedIntDelta(baseline.previousHealth, in compressionModel);
			}
			else
			{
				snapshot.previousHealth = baseline.previousHealth;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.previousMaxHealth = reader.ReadPackedIntDelta(baseline.previousMaxHealth, in compressionModel);
			}
			else
			{
				snapshot.previousMaxHealth = baseline.previousMaxHealth;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.itemIsInProcessOfBeingUsed = reader.ReadPackedUIntDelta(baseline.itemIsInProcessOfBeingUsed, in compressionModel);
			}
			else
			{
				snapshot.itemIsInProcessOfBeingUsed = baseline.itemIsInProcessOfBeingUsed;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.objectData_objectID = reader.ReadPackedIntDelta(baseline.objectData_objectID, in compressionModel);
			}
			else
			{
				snapshot.objectData_objectID = baseline.objectData_objectID;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.objectData_amount = reader.ReadPackedIntDelta(baseline.objectData_amount, in compressionModel);
			}
			else
			{
				snapshot.objectData_amount = baseline.objectData_amount;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.objectData_variation = reader.ReadPackedIntDelta(baseline.objectData_variation, in compressionModel);
			}
			else
			{
				snapshot.objectData_variation = baseline.objectData_variation;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.objectData_variationUpdateCount = reader.ReadPackedIntDelta(baseline.objectData_variationUpdateCount, in compressionModel);
			}
			else
			{
				snapshot.objectData_variationUpdateCount = baseline.objectData_variationUpdateCount;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.inventoryIndexOnCast = reader.ReadPackedIntDelta(baseline.inventoryIndexOnCast, in compressionModel);
			}
			else
			{
				snapshot.inventoryIndexOnCast = baseline.inventoryIndexOnCast;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.exitStateDelayTimer_startTick = reader.ReadPackedUIntDelta(baseline.exitStateDelayTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.exitStateDelayTimer_startTick = baseline.exitStateDelayTimer_startTick;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.exitStateDelayTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.exitStateDelayTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.exitStateDelayTimer_targetTicks = baseline.exitStateDelayTimer_targetTicks;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.exitStateDelayTimer_stopTick = reader.ReadPackedUIntDelta(baseline.exitStateDelayTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.exitStateDelayTimer_stopTick = baseline.exitStateDelayTimer_stopTick;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.castCompleteEffect = reader.ReadPackedUIntDelta(baseline.castCompleteEffect, in compressionModel);
			}
			else
			{
				snapshot.castCompleteEffect = baseline.castCompleteEffect;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 4081819130859728674uL,
					ComponentType = ComponentType.ReadWrite<CastingStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<CastingStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 15,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 9864660405096211634uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<CastingStateCD, Snapshot, CastingStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
