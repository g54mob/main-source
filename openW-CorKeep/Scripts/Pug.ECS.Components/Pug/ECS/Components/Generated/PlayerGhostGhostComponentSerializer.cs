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
	public struct PlayerGhostGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint playerGuid_Value_x;

			public uint playerGuid_Value_y;

			public uint playerGuid_Value_z;

			public uint playerGuid_Value_w;

			public int playerIndex;

			public int adminPrivileges;

			public ulong onlineId;

			public FixedString32Bytes onlineName;

			public uint platform;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<PlayerGhost>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<PlayerGhost>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<PlayerGhost>(component), in GhostComponentSerializer.TypeCastReadonly<PlayerGhost>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in PlayerGhost component)
		{
			snapshot.playerGuid_Value_x = component.playerGuid.Value.x;
			snapshot.playerGuid_Value_y = component.playerGuid.Value.y;
			snapshot.playerGuid_Value_z = component.playerGuid.Value.z;
			snapshot.playerGuid_Value_w = component.playerGuid.Value.w;
			snapshot.playerIndex = component.playerIndex;
			snapshot.adminPrivileges = component.adminPrivileges;
			snapshot.onlineId = component.onlineId;
			snapshot.onlineName = component.onlineName;
			snapshot.platform = component.platform;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref PlayerGhost component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.playerGuid.Value.x = snapshotBefore.playerGuid_Value_x;
			component.playerGuid.Value.y = snapshotBefore.playerGuid_Value_y;
			component.playerGuid.Value.z = snapshotBefore.playerGuid_Value_z;
			component.playerGuid.Value.w = snapshotBefore.playerGuid_Value_w;
			component.playerIndex = snapshotBefore.playerIndex;
			component.adminPrivileges = snapshotBefore.adminPrivileges;
			component.onlineId = snapshotBefore.onlineId;
			component.onlineName = snapshotBefore.onlineName;
			component.platform = (byte)snapshotBefore.platform;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref PlayerGhost component, in PlayerGhost backup)
		{
			component.playerGuid.Value.x = backup.playerGuid.Value.x;
			component.playerGuid.Value.y = backup.playerGuid.Value.y;
			component.playerGuid.Value.z = backup.playerGuid.Value.z;
			component.playerGuid.Value.w = backup.playerGuid.Value.w;
			component.playerIndex = backup.playerIndex;
			component.adminPrivileges = backup.adminPrivileges;
			component.onlineId = backup.onlineId;
			component.onlineName = backup.onlineName;
			component.platform = backup.platform;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.playerGuid_Value_x = (uint)predictor.PredictInt((int)snapshot.playerGuid_Value_x, (int)baseline1.playerGuid_Value_x, (int)baseline2.playerGuid_Value_x);
			snapshot.playerGuid_Value_y = (uint)predictor.PredictInt((int)snapshot.playerGuid_Value_y, (int)baseline1.playerGuid_Value_y, (int)baseline2.playerGuid_Value_y);
			snapshot.playerGuid_Value_z = (uint)predictor.PredictInt((int)snapshot.playerGuid_Value_z, (int)baseline1.playerGuid_Value_z, (int)baseline2.playerGuid_Value_z);
			snapshot.playerGuid_Value_w = (uint)predictor.PredictInt((int)snapshot.playerGuid_Value_w, (int)baseline1.playerGuid_Value_w, (int)baseline2.playerGuid_Value_w);
			snapshot.playerIndex = predictor.PredictInt(snapshot.playerIndex, baseline1.playerIndex, baseline2.playerIndex);
			snapshot.adminPrivileges = predictor.PredictInt(snapshot.adminPrivileges, baseline1.adminPrivileges, baseline2.adminPrivileges);
			snapshot.onlineId = (ulong)predictor.PredictLong((long)snapshot.onlineId, (long)baseline1.onlineId, (long)baseline2.onlineId);
			snapshot.platform = (uint)predictor.PredictInt((int)snapshot.platform, (int)baseline1.platform, (int)baseline2.platform);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.playerGuid_Value_x != baseline.playerGuid_Value_x) ? 1u : 0u);
			num |= (uint)((snapshot.playerGuid_Value_y != baseline.playerGuid_Value_y) ? 2 : 0);
			num |= (uint)((snapshot.playerGuid_Value_z != baseline.playerGuid_Value_z) ? 4 : 0);
			num |= (uint)((snapshot.playerGuid_Value_w != baseline.playerGuid_Value_w) ? 8 : 0);
			num |= (uint)((snapshot.playerIndex != baseline.playerIndex) ? 16 : 0);
			num |= (uint)((snapshot.adminPrivileges != baseline.adminPrivileges) ? 32 : 0);
			num |= (uint)((snapshot.onlineId != baseline.onlineId) ? 64 : 0);
			num |= (uint)((!snapshot.onlineName.Equals(baseline.onlineName)) ? 128 : 0);
			num |= (uint)((snapshot.platform != baseline.platform) ? 256 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 9);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 9);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.playerGuid_Value_x, baseline.playerGuid_Value_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.playerGuid_Value_y, baseline.playerGuid_Value_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.playerGuid_Value_z, baseline.playerGuid_Value_z, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.playerGuid_Value_w, baseline.playerGuid_Value_w, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.playerIndex, baseline.playerIndex, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.adminPrivileges, baseline.adminPrivileges, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedULongDelta(snapshot.onlineId, baseline.onlineId, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFixedString32Delta(snapshot.onlineName, baseline.onlineName, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.platform, baseline.platform, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.playerGuid_Value_x != baseline.playerGuid_Value_x) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.playerGuid_Value_x, baseline.playerGuid_Value_x, in compressionModel);
			}
			num |= (uint)((snapshot.playerGuid_Value_y != baseline.playerGuid_Value_y) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.playerGuid_Value_y, baseline.playerGuid_Value_y, in compressionModel);
			}
			num |= (uint)((snapshot.playerGuid_Value_z != baseline.playerGuid_Value_z) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.playerGuid_Value_z, baseline.playerGuid_Value_z, in compressionModel);
			}
			num |= (uint)((snapshot.playerGuid_Value_w != baseline.playerGuid_Value_w) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.playerGuid_Value_w, baseline.playerGuid_Value_w, in compressionModel);
			}
			num |= (uint)((snapshot.playerIndex != baseline.playerIndex) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.playerIndex, baseline.playerIndex, in compressionModel);
			}
			num |= (uint)((snapshot.adminPrivileges != baseline.adminPrivileges) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.adminPrivileges, baseline.adminPrivileges, in compressionModel);
			}
			num |= (uint)((snapshot.onlineId != baseline.onlineId) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedULongDelta(snapshot.onlineId, baseline.onlineId, in compressionModel);
			}
			num |= (uint)((!snapshot.onlineName.Equals(baseline.onlineName)) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedFixedString32Delta(snapshot.onlineName, baseline.onlineName, in compressionModel);
			}
			num |= (uint)((snapshot.platform != baseline.platform) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.platform, baseline.platform, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 9);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 9);
			if ((num & 1) != 0)
			{
				snapshot.playerGuid_Value_x = reader.ReadPackedUIntDelta(baseline.playerGuid_Value_x, in compressionModel);
			}
			else
			{
				snapshot.playerGuid_Value_x = baseline.playerGuid_Value_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.playerGuid_Value_y = reader.ReadPackedUIntDelta(baseline.playerGuid_Value_y, in compressionModel);
			}
			else
			{
				snapshot.playerGuid_Value_y = baseline.playerGuid_Value_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.playerGuid_Value_z = reader.ReadPackedUIntDelta(baseline.playerGuid_Value_z, in compressionModel);
			}
			else
			{
				snapshot.playerGuid_Value_z = baseline.playerGuid_Value_z;
			}
			if ((num & 8) != 0)
			{
				snapshot.playerGuid_Value_w = reader.ReadPackedUIntDelta(baseline.playerGuid_Value_w, in compressionModel);
			}
			else
			{
				snapshot.playerGuid_Value_w = baseline.playerGuid_Value_w;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.playerIndex = reader.ReadPackedIntDelta(baseline.playerIndex, in compressionModel);
			}
			else
			{
				snapshot.playerIndex = baseline.playerIndex;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.adminPrivileges = reader.ReadPackedIntDelta(baseline.adminPrivileges, in compressionModel);
			}
			else
			{
				snapshot.adminPrivileges = baseline.adminPrivileges;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.onlineId = reader.ReadPackedULongDelta(baseline.onlineId, in compressionModel);
			}
			else
			{
				snapshot.onlineId = baseline.onlineId;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.onlineName = reader.ReadPackedFixedString32Delta(baseline.onlineName, in compressionModel);
			}
			else
			{
				snapshot.onlineName = baseline.onlineName;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.platform = reader.ReadPackedUIntDelta(baseline.platform, in compressionModel);
			}
			else
			{
				snapshot.platform = baseline.platform;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 15168673681901513398uL,
					ComponentType = ComponentType.ReadWrite<PlayerGhost>(),
					ComponentSize = UnsafeUtility.SizeOf<PlayerGhost>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 9,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 9949911123698397540uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<PlayerGhost, Snapshot, PlayerGhostGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
