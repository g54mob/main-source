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

namespace Pushback.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	public struct ReceivedPushbackCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint enabled;

			public float pushback_x;

			public float pushback_y;

			public float startPosition_x;

			public float startPosition_y;

			public float startPosition_z;

			public uint pushbackStartTick;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ReceivedPushbackCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ReceivedPushbackCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ReceivedPushbackCD>(component), in GhostComponentSerializer.TypeCastReadonly<ReceivedPushbackCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ReceivedPushbackCD component)
		{
			snapshot.enabled = (component.enabled ? 1u : 0u);
			snapshot.pushback_x = component.pushback.x;
			snapshot.pushback_y = component.pushback.y;
			snapshot.startPosition_x = component.startPosition.x;
			snapshot.startPosition_y = component.startPosition.y;
			snapshot.startPosition_z = component.startPosition.z;
			snapshot.pushbackStartTick = component.pushbackStartTick.SerializedData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ReceivedPushbackCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.enabled = snapshotBefore.enabled != 0;
			component.pushback = new float2(snapshotBefore.pushback_x, snapshotBefore.pushback_y);
			component.startPosition = new float3(snapshotBefore.startPosition_x, snapshotBefore.startPosition_y, snapshotBefore.startPosition_z);
			component.pushbackStartTick = new NetworkTick
			{
				SerializedData = snapshotBefore.pushbackStartTick
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ReceivedPushbackCD component, in ReceivedPushbackCD backup)
		{
			component.enabled = backup.enabled;
			component.pushback.x = backup.pushback.x;
			component.pushback.y = backup.pushback.y;
			component.startPosition.x = backup.startPosition.x;
			component.startPosition.y = backup.startPosition.y;
			component.startPosition.z = backup.startPosition.z;
			component.pushbackStartTick = backup.pushbackStartTick;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.enabled = (uint)predictor.PredictInt((int)snapshot.enabled, (int)baseline1.enabled, (int)baseline2.enabled);
			snapshot.pushbackStartTick = (uint)predictor.PredictInt((int)snapshot.pushbackStartTick, (int)baseline1.pushbackStartTick, (int)baseline2.pushbackStartTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.enabled != baseline.enabled) ? 1u : 0u);
			num |= (uint)((snapshot.pushback_x != baseline.pushback_x) ? 2 : 0);
			num |= (uint)((snapshot.pushback_y != baseline.pushback_y) ? 2 : 0);
			num |= (uint)((snapshot.startPosition_x != baseline.startPosition_x) ? 4 : 0);
			num |= (uint)((snapshot.startPosition_y != baseline.startPosition_y) ? 4 : 0);
			num |= (uint)((snapshot.startPosition_z != baseline.startPosition_z) ? 4 : 0);
			num |= (uint)((snapshot.pushbackStartTick != baseline.pushbackStartTick) ? 8 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 4);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.enabled, baseline.enabled, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pushback_x, baseline.pushback_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pushback_y, baseline.pushback_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.startPosition_x, baseline.startPosition_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.startPosition_y, baseline.startPosition_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.startPosition_z, baseline.startPosition_z, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.pushbackStartTick, baseline.pushbackStartTick, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.enabled != baseline.enabled) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.enabled, baseline.enabled, in compressionModel);
			}
			num |= (uint)((snapshot.pushback_x != baseline.pushback_x) ? 2 : 0);
			num |= (uint)((snapshot.pushback_y != baseline.pushback_y) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pushback_x, baseline.pushback_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.pushback_y, baseline.pushback_y, in compressionModel);
			}
			num |= (uint)((snapshot.startPosition_x != baseline.startPosition_x) ? 4 : 0);
			num |= (uint)((snapshot.startPosition_y != baseline.startPosition_y) ? 4 : 0);
			num |= (uint)((snapshot.startPosition_z != baseline.startPosition_z) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.startPosition_x, baseline.startPosition_x, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.startPosition_y, baseline.startPosition_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.startPosition_z, baseline.startPosition_z, in compressionModel);
			}
			num |= (uint)((snapshot.pushbackStartTick != baseline.pushbackStartTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.pushbackStartTick, baseline.pushbackStartTick, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 4);
			if ((num & 1) != 0)
			{
				snapshot.enabled = reader.ReadPackedUIntDelta(baseline.enabled, in compressionModel);
			}
			else
			{
				snapshot.enabled = baseline.enabled;
			}
			if ((num & 2) != 0)
			{
				snapshot.pushback_x = reader.ReadPackedFloatDelta(baseline.pushback_x, in compressionModel);
			}
			else
			{
				snapshot.pushback_x = baseline.pushback_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.pushback_y = reader.ReadPackedFloatDelta(baseline.pushback_y, in compressionModel);
			}
			else
			{
				snapshot.pushback_y = baseline.pushback_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.startPosition_x = reader.ReadPackedFloatDelta(baseline.startPosition_x, in compressionModel);
			}
			else
			{
				snapshot.startPosition_x = baseline.startPosition_x;
			}
			if ((num & 4) != 0)
			{
				snapshot.startPosition_y = reader.ReadPackedFloatDelta(baseline.startPosition_y, in compressionModel);
			}
			else
			{
				snapshot.startPosition_y = baseline.startPosition_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.startPosition_z = reader.ReadPackedFloatDelta(baseline.startPosition_z, in compressionModel);
			}
			else
			{
				snapshot.startPosition_z = baseline.startPosition_z;
			}
			if ((num & 8) != 0)
			{
				snapshot.pushbackStartTick = reader.ReadPackedUIntDelta(baseline.pushbackStartTick, in compressionModel);
			}
			else
			{
				snapshot.pushbackStartTick = baseline.pushbackStartTick;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1966819302090705106uL,
					ComponentType = ComponentType.ReadWrite<ReceivedPushbackCD>(),
					ComponentSize = UnsafeUtility.SizeOf<ReceivedPushbackCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 4,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 8499533983993026014uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ReceivedPushbackCD, Snapshot, ReceivedPushbackCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
