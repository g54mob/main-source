using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
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
	public struct ClientSubMapLayerCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public int layer_tileset;

			public int layer_tileType;

			public int data_viewpoint_x;

			public int data_viewpoint_y;

			public FixedString512Bytes data_bitfield;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ClientSubMapLayerCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ClientSubMapLayerCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ClientSubMapLayerCD>(component), in GhostComponentSerializer.TypeCastReadonly<ClientSubMapLayerCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ClientSubMapLayerCD component)
		{
			snapshot.layer_tileset = component.layer.tileset;
			snapshot.layer_tileType = (int)component.layer.tileType;
			snapshot.data_viewpoint_x = component.data.viewPoint.x;
			snapshot.data_viewpoint_y = component.data.viewPoint.y;
			snapshot.data_bitfield.Length = 384;
			uint* unsafePtr = (uint*)snapshot.data_bitfield.GetUnsafePtr();
			uint* unsafePtr2 = (uint*)component.data.bitfield.GetUnsafePtr();
			for (int i = 0; i < 96; i++)
			{
				unsafePtr[i] = unsafePtr2[i];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ClientSubMapLayerCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.layer.tileset = snapshotBefore.layer_tileset;
			component.layer.tileType = (TileType)snapshotBefore.layer_tileType;
			component.data.viewPoint.x = snapshotBefore.data_viewpoint_x;
			component.data.viewPoint.y = snapshotBefore.data_viewpoint_y;
			uint* unsafePtr = (uint*)snapshotBefore.data_bitfield.GetUnsafePtr();
			uint* unsafePtr2 = (uint*)component.data.bitfield.GetUnsafePtr();
			for (int i = 0; i < 96; i++)
			{
				unsafePtr2[i] = unsafePtr[i];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void RestoreFromBackupGenerated(ref ClientSubMapLayerCD component, in ClientSubMapLayerCD backup)
		{
			component.layer.tileset = backup.layer.tileset;
			component.layer.tileType = backup.layer.tileType;
			component.data.viewPoint.x = backup.data.viewPoint.x;
			component.data.viewPoint.y = backup.data.viewPoint.y;
			uint* unsafePtr = (uint*)component.data.bitfield.GetUnsafePtr();
			uint* unsafePtr2 = (uint*)backup.data.bitfield.GetUnsafePtr();
			for (int i = 0; i < 96; i++)
			{
				unsafePtr[i] = unsafePtr2[i];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.layer_tileset = predictor.PredictInt(snapshot.layer_tileset, baseline1.layer_tileset, baseline2.layer_tileset);
			snapshot.layer_tileType = predictor.PredictInt(snapshot.layer_tileType, baseline1.layer_tileType, baseline2.layer_tileType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.layer_tileset != baseline.layer_tileset) ? 1u : 0u);
			num |= (uint)((snapshot.layer_tileType != baseline.layer_tileType) ? 2 : 0);
			bool flag = snapshot.data_viewpoint_x != baseline.data_viewpoint_x || snapshot.data_viewpoint_y != baseline.data_viewpoint_y || snapshot.data_bitfield.Length != baseline.data_bitfield.Length;
			if (!flag)
			{
				uint* unsafePtr = (uint*)snapshot.data_bitfield.GetUnsafePtr();
				uint* unsafePtr2 = (uint*)baseline.data_bitfield.GetUnsafePtr();
				for (int i = 0; i < 96; i++)
				{
					flag |= unsafePtr[i] != unsafePtr2[i];
				}
			}
			num |= (uint)(flag ? 4 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 3);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.layer_tileset, baseline.layer_tileset, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.layer_tileType, baseline.layer_tileType, in compressionModel);
			}
			if ((num & 4) == 0)
			{
				return;
			}
			writer.WritePackedIntDelta(snapshot.data_viewpoint_x, baseline.data_viewpoint_x, in compressionModel);
			writer.WritePackedIntDelta(snapshot.data_viewpoint_y, baseline.data_viewpoint_y, in compressionModel);
			bool flag = baseline.data_bitfield.Length != 384;
			int2 int5 = new int2(64, 48);
			int2 int6 = new int2(snapshot.data_viewpoint_x, snapshot.data_viewpoint_y) - int5 / 2;
			int2 int7 = new int2(baseline.data_viewpoint_x, baseline.data_viewpoint_y) - int5 / 2;
			int2 int8 = int6 - int7;
			int2 int9 = math.max(int6, int7);
			int2 int10 = math.min(int6 + int5, int7 + int5);
			int2 int11 = math.select(int7 + int5, int6, int6 <= int7);
			int2 int12 = math.select(int6 + int5, int7, int6 <= int7);
			ulong num2 = 0uL;
			for (int i = int9.x - int6.x; i < int10.x - int6.x; i++)
			{
				num2 |= (ulong)(1L << i);
			}
			BitwiseDataStreamWriter bitwiseDataStreamWriter = new BitwiseDataStreamWriter(compressionModel);
			ulong* unsafePtr = (ulong*)snapshot.data_bitfield.GetUnsafePtr();
			ulong* unsafePtr2 = (ulong*)baseline.data_bitfield.GetUnsafePtr();
			int2 int13 = int5;
			int2 x = new int2(0);
			for (int j = 0; j < int5.y; j++)
			{
				ulong num3 = unsafePtr[j];
				int num4 = j + int6.y;
				int num5 = int11.x - int6.x;
				int num6 = int12.x - int6.x;
				if (num4 < int9.y || num4 >= int10.y || flag)
				{
					num5 = 0;
					num6 = int5.x;
				}
				else
				{
					ulong num7 = unsafePtr2[num4 - int7.y];
					num7 = ((int8.x > 0) ? (num7 >> int8.x) : (num7 << -int8.x));
					ulong num8 = (num3 ^ num7) & num2;
					if (num8 != 0L)
					{
						for (int k = int9.x - int6.x; k < int10.x - int6.x; k++)
						{
							if ((num8 & (ulong)(1L << k)) != 0L)
							{
								int13 = math.min(int13, new int2(k, j));
								x = math.max(x, new int2(k + 1, j + 1));
							}
						}
					}
				}
				for (int l = num5; l < num6; l++)
				{
					bitwiseDataStreamWriter.WriteBit(ref writer, (num3 & (ulong)(1L << l)) != 0);
				}
			}
			bool flag2 = math.all(int13 < int5);
			bitwiseDataStreamWriter.WriteBit(ref writer, flag2);
			if (flag2)
			{
				bitwiseDataStreamWriter.WriteByte(ref writer, (byte)int13.x);
				bitwiseDataStreamWriter.WriteByte(ref writer, (byte)int13.y);
				bitwiseDataStreamWriter.WriteByte(ref writer, (byte)x.x);
				bitwiseDataStreamWriter.WriteByte(ref writer, (byte)x.y);
				for (int m = int13.y; m < x.y; m++)
				{
					ulong num9 = unsafePtr[m];
					for (int n = int13.x; n < x.x; n++)
					{
						bitwiseDataStreamWriter.WriteBit(ref writer, (num9 & (ulong)(1L << n)) != 0);
					}
				}
			}
			bitwiseDataStreamWriter.Flush(ref writer);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.layer_tileset != baseline.layer_tileset) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedIntDelta(snapshot.layer_tileset, baseline.layer_tileset, in compressionModel);
			}
			num |= (uint)((snapshot.layer_tileType != baseline.layer_tileType) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.layer_tileType, baseline.layer_tileType, in compressionModel);
			}
			bool flag = snapshot.data_viewpoint_x != baseline.data_viewpoint_x || snapshot.data_viewpoint_y != baseline.data_viewpoint_y || snapshot.data_bitfield.Length != baseline.data_bitfield.Length;
			if (!flag)
			{
				uint* unsafePtr = (uint*)snapshot.data_bitfield.GetUnsafePtr();
				uint* unsafePtr2 = (uint*)baseline.data_bitfield.GetUnsafePtr();
				for (int i = 0; i < 96; i++)
				{
					flag |= unsafePtr[i] != unsafePtr2[i];
				}
			}
			num |= (uint)(flag ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.data_viewpoint_x, baseline.data_viewpoint_x, in compressionModel);
				writer.WritePackedIntDelta(snapshot.data_viewpoint_y, baseline.data_viewpoint_y, in compressionModel);
				bool flag2 = baseline.data_bitfield.Length != 384;
				int2 int5 = new int2(64, 48);
				int2 int6 = new int2(snapshot.data_viewpoint_x, snapshot.data_viewpoint_y) - int5 / 2;
				int2 int7 = new int2(baseline.data_viewpoint_x, baseline.data_viewpoint_y) - int5 / 2;
				int2 int8 = int6 - int7;
				int2 int9 = math.max(int6, int7);
				int2 int10 = math.min(int6 + int5, int7 + int5);
				int2 int11 = math.select(int7 + int5, int6, int6 <= int7);
				int2 int12 = math.select(int6 + int5, int7, int6 <= int7);
				ulong num2 = 0uL;
				for (int j = int9.x - int6.x; j < int10.x - int6.x; j++)
				{
					num2 |= (ulong)(1L << j);
				}
				BitwiseDataStreamWriter bitwiseDataStreamWriter = new BitwiseDataStreamWriter(compressionModel);
				ulong* unsafePtr3 = (ulong*)snapshot.data_bitfield.GetUnsafePtr();
				ulong* unsafePtr4 = (ulong*)baseline.data_bitfield.GetUnsafePtr();
				int2 int13 = int5;
				int2 x = new int2(0);
				for (int k = 0; k < int5.y; k++)
				{
					ulong num3 = unsafePtr3[k];
					int num4 = k + int6.y;
					int num5 = int11.x - int6.x;
					int num6 = int12.x - int6.x;
					if (num4 < int9.y || num4 >= int10.y || flag2)
					{
						num5 = 0;
						num6 = int5.x;
					}
					else
					{
						ulong num7 = unsafePtr4[num4 - int7.y];
						num7 = ((int8.x > 0) ? (num7 >> int8.x) : (num7 << -int8.x));
						ulong num8 = (num3 ^ num7) & num2;
						if (num8 != 0L)
						{
							for (int l = int9.x - int6.x; l < int10.x - int6.x; l++)
							{
								if ((num8 & (ulong)(1L << l)) != 0L)
								{
									int13 = math.min(int13, new int2(l, k));
									x = math.max(x, new int2(l + 1, k + 1));
								}
							}
						}
					}
					for (int m = num5; m < num6; m++)
					{
						bitwiseDataStreamWriter.WriteBit(ref writer, (num3 & (ulong)(1L << m)) != 0);
					}
				}
				bool flag3 = math.all(int13 < int5);
				bitwiseDataStreamWriter.WriteBit(ref writer, flag3);
				if (flag3)
				{
					bitwiseDataStreamWriter.WriteByte(ref writer, (byte)int13.x);
					bitwiseDataStreamWriter.WriteByte(ref writer, (byte)int13.y);
					bitwiseDataStreamWriter.WriteByte(ref writer, (byte)x.x);
					bitwiseDataStreamWriter.WriteByte(ref writer, (byte)x.y);
					for (int n = int13.y; n < x.y; n++)
					{
						ulong num9 = unsafePtr3[n];
						for (int num10 = int13.x; num10 < x.x; num10++)
						{
							bitwiseDataStreamWriter.WriteBit(ref writer, (num9 & (ulong)(1L << num10)) != 0);
						}
					}
				}
				bitwiseDataStreamWriter.Flush(ref writer);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 3);
			if ((num & 1) != 0)
			{
				snapshot.layer_tileset = reader.ReadPackedIntDelta(baseline.layer_tileset, in compressionModel);
			}
			else
			{
				snapshot.layer_tileset = baseline.layer_tileset;
			}
			if ((num & 2) != 0)
			{
				snapshot.layer_tileType = reader.ReadPackedIntDelta(baseline.layer_tileType, in compressionModel);
			}
			else
			{
				snapshot.layer_tileType = baseline.layer_tileType;
			}
			if ((num & 4) != 0)
			{
				snapshot.data_viewpoint_x = reader.ReadPackedIntDelta(baseline.data_viewpoint_x, in compressionModel);
				snapshot.data_viewpoint_y = reader.ReadPackedIntDelta(baseline.data_viewpoint_y, in compressionModel);
				snapshot.data_bitfield.Length = 384;
				bool flag = baseline.data_bitfield.Length != 384;
				int2 int5 = new int2(64, 48);
				int2 int6 = new int2(snapshot.data_viewpoint_x, snapshot.data_viewpoint_y) - int5 / 2;
				int2 int7 = new int2(baseline.data_viewpoint_x, baseline.data_viewpoint_y) - int5 / 2;
				int2 int8 = int6 - int7;
				int2 int9 = math.max(int6, int7);
				int2 int10 = math.min(int6 + int5, int7 + int5);
				int2 int11 = math.select(int7 + int5, int6, int6 <= int7);
				int2 int12 = math.select(int6 + int5, int7, int6 <= int7);
				BitwiseDataStreamReader bitwiseDataStreamReader = new BitwiseDataStreamReader(compressionModel);
				ulong* unsafePtr = (ulong*)snapshot.data_bitfield.GetUnsafePtr();
				ulong* unsafePtr2 = (ulong*)baseline.data_bitfield.GetUnsafePtr();
				for (int i = 0; i < int5.y; i++)
				{
					int num2 = i + int8.y;
					ulong num3 = ((num2 >= 0 && num2 < int5.y) ? unsafePtr2[num2] : 0);
					num3 = ((int8.x > 0) ? (num3 >> int8.x) : (num3 << -int8.x));
					int num4 = i + int6.y;
					int num5 = int11.x - int6.x;
					int num6 = int12.x - int6.x;
					if (num4 < int9.y || num4 >= int10.y || flag)
					{
						num5 = 0;
						num6 = int5.x;
					}
					for (int j = num5; j < num6; j++)
					{
						num3 = ((!bitwiseDataStreamReader.ReadBit(ref reader)) ? (num3 & (ulong)(~(1L << j))) : (num3 | (ulong)(1L << j)));
					}
					unsafePtr[i] = num3;
				}
				if (!bitwiseDataStreamReader.ReadBit(ref reader))
				{
					return;
				}
				int2 int13 = new int2(bitwiseDataStreamReader.ReadByte(ref reader), bitwiseDataStreamReader.ReadByte(ref reader));
				int2 int14 = new int2(bitwiseDataStreamReader.ReadByte(ref reader), bitwiseDataStreamReader.ReadByte(ref reader));
				for (int k = int13.y; k < int14.y; k++)
				{
					ulong num7 = unsafePtr[k];
					for (int l = int13.x; l < int14.x; l++)
					{
						num7 = ((!bitwiseDataStreamReader.ReadBit(ref reader)) ? (num7 & (ulong)(~(1L << l))) : (num7 | (ulong)(1L << l)));
					}
					unsafePtr[k] = num7;
				}
			}
			else
			{
				snapshot.data_viewpoint_x = baseline.data_viewpoint_x;
				snapshot.data_viewpoint_y = baseline.data_viewpoint_y;
				snapshot.data_bitfield = baseline.data_bitfield;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 17627838338810177770uL,
					ComponentType = ComponentType.ReadWrite<ClientSubMapLayerCD>(),
					ComponentSize = UnsafeUtility.SizeOf<ClientSubMapLayerCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 3,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 9824809055455300062uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ClientSubMapLayerCD, Snapshot, ClientSubMapLayerCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
