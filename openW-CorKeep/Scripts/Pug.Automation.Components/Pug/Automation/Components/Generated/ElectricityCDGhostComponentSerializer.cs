using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.NetCode;
using Unity.NetCode.LowLevel.Unsafe;

namespace Pug.Automation.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	public struct ElectricityCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int electricityAmountLeft;

			public int electricityAmountRight;

			public int electricityAmountUp;

			public int electricityAmountDown;

			public int sourceEnergy;

			public uint blocksElectricity;
		}

		private const int ChangeMaskBits = 6;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 6;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ElectricityCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ElectricityCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ElectricityCD>(component), in GhostComponentSerializer.TypeCastReadonly<ElectricityCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ElectricityCD component)
		{
			snapshot.electricityAmountLeft = component.electricityAmountLeft;
			snapshot.electricityAmountRight = component.electricityAmountRight;
			snapshot.electricityAmountUp = component.electricityAmountUp;
			snapshot.electricityAmountDown = component.electricityAmountDown;
			snapshot.sourceEnergy = component.sourceEnergy;
			snapshot.blocksElectricity = (component.blocksElectricity ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ElectricityCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.electricityAmountLeft = snapshotBefore.electricityAmountLeft;
			component.electricityAmountRight = snapshotBefore.electricityAmountRight;
			component.electricityAmountUp = snapshotBefore.electricityAmountUp;
			component.electricityAmountDown = snapshotBefore.electricityAmountDown;
			component.sourceEnergy = snapshotBefore.sourceEnergy;
			component.blocksElectricity = snapshotBefore.blocksElectricity != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ElectricityCD component, in ElectricityCD backup)
		{
			component.electricityAmountLeft = backup.electricityAmountLeft;
			component.electricityAmountRight = backup.electricityAmountRight;
			component.electricityAmountUp = backup.electricityAmountUp;
			component.electricityAmountDown = backup.electricityAmountDown;
			component.sourceEnergy = backup.sourceEnergy;
			component.blocksElectricity = backup.blocksElectricity;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.electricityAmountLeft = predictor.PredictInt(snapshot.electricityAmountLeft, baseline1.electricityAmountLeft, baseline2.electricityAmountLeft);
			snapshot.electricityAmountRight = predictor.PredictInt(snapshot.electricityAmountRight, baseline1.electricityAmountRight, baseline2.electricityAmountRight);
			snapshot.electricityAmountUp = predictor.PredictInt(snapshot.electricityAmountUp, baseline1.electricityAmountUp, baseline2.electricityAmountUp);
			snapshot.electricityAmountDown = predictor.PredictInt(snapshot.electricityAmountDown, baseline1.electricityAmountDown, baseline2.electricityAmountDown);
			snapshot.sourceEnergy = predictor.PredictInt(snapshot.sourceEnergy, baseline1.sourceEnergy, baseline2.sourceEnergy);
			snapshot.blocksElectricity = (uint)predictor.PredictInt((int)snapshot.blocksElectricity, (int)baseline1.blocksElectricity, (int)baseline2.blocksElectricity);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.electricityAmountLeft != baseline.electricityAmountLeft) ? 1u : 0u);
			num |= (uint)((snapshot.electricityAmountRight != baseline.electricityAmountRight) ? 2 : 0);
			num |= (uint)((snapshot.electricityAmountUp != baseline.electricityAmountUp) ? 4 : 0);
			num |= (uint)((snapshot.electricityAmountDown != baseline.electricityAmountDown) ? 8 : 0);
			num |= (uint)((snapshot.sourceEnergy != baseline.sourceEnergy) ? 16 : 0);
			num |= (uint)((snapshot.blocksElectricity != baseline.blocksElectricity) ? 32 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.electricityAmountLeft, baseline.electricityAmountLeft, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.electricityAmountRight, baseline.electricityAmountRight, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.electricityAmountUp, baseline.electricityAmountUp, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.electricityAmountDown, baseline.electricityAmountDown, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.sourceEnergy, baseline.sourceEnergy, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.blocksElectricity, baseline.blocksElectricity, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.electricityAmountLeft != baseline.electricityAmountLeft) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.electricityAmountLeft, baseline.electricityAmountLeft, in compressionModel);
			}
			num |= (uint)((snapshot.electricityAmountRight != baseline.electricityAmountRight) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.electricityAmountRight, baseline.electricityAmountRight, in compressionModel);
			}
			num |= (uint)((snapshot.electricityAmountUp != baseline.electricityAmountUp) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.electricityAmountUp, baseline.electricityAmountUp, in compressionModel);
			}
			num |= (uint)((snapshot.electricityAmountDown != baseline.electricityAmountDown) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.electricityAmountDown, baseline.electricityAmountDown, in compressionModel);
			}
			num |= (uint)((snapshot.sourceEnergy != baseline.sourceEnergy) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.sourceEnergy, baseline.sourceEnergy, in compressionModel);
			}
			num |= (uint)((snapshot.blocksElectricity != baseline.blocksElectricity) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.blocksElectricity, baseline.blocksElectricity, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 6);
			if ((num & 1) != 0)
			{
				snapshot.electricityAmountLeft = reader.ReadPackedIntDelta(baseline.electricityAmountLeft, in compressionModel);
			}
			else
			{
				snapshot.electricityAmountLeft = baseline.electricityAmountLeft;
			}
			if ((num & 2) != 0)
			{
				snapshot.electricityAmountRight = reader.ReadPackedIntDelta(baseline.electricityAmountRight, in compressionModel);
			}
			else
			{
				snapshot.electricityAmountRight = baseline.electricityAmountRight;
			}
			if ((num & 4) != 0)
			{
				snapshot.electricityAmountUp = reader.ReadPackedIntDelta(baseline.electricityAmountUp, in compressionModel);
			}
			else
			{
				snapshot.electricityAmountUp = baseline.electricityAmountUp;
			}
			if ((num & 8) != 0)
			{
				snapshot.electricityAmountDown = reader.ReadPackedIntDelta(baseline.electricityAmountDown, in compressionModel);
			}
			else
			{
				snapshot.electricityAmountDown = baseline.electricityAmountDown;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.sourceEnergy = reader.ReadPackedIntDelta(baseline.sourceEnergy, in compressionModel);
			}
			else
			{
				snapshot.sourceEnergy = baseline.sourceEnergy;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.blocksElectricity = reader.ReadPackedUIntDelta(baseline.blocksElectricity, in compressionModel);
			}
			else
			{
				snapshot.blocksElectricity = baseline.blocksElectricity;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 5032326342240550756uL,
					ComponentType = ComponentType.ReadWrite<ElectricityCD>(),
					ComponentSize = UnsafeUtility.SizeOf<ElectricityCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 6,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 10724968734529015150uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ElectricityCD, Snapshot, ElectricityCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
