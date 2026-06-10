using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Model.MapNew;
using NSMedieval.Serialization;
using NSMedieval.Tools;
using NSMedieval.Types;

namespace NSMedieval.Village.Map
{
	[Serializable]
	[FVSerializableKey("MapNodesHolder", "")]
	public class MapNodesHolder : System.Runtime.Serialization.ISerializable, IFVSerializable
	{
		private int count;

		private int sizeX;

		private int sizeY;

		private int sizeZ;

		private MapNode[] gridData;

		public MapNode[] GridData => gridData;

		public MapNodesHolder(MapNode[] gridData, Vec3Int size)
		{
			SetGridData(gridData);
			sizeX = size.x;
			sizeY = size.y;
			sizeZ = size.z;
		}

		public void Dispose()
		{
			gridData = null;
			count = 0;
		}

		protected MapNodesHolder(SerializationInfo info, StreamingContext context)
		{
			count = info.GetInt32("count");
			sizeX = info.GetInt32("sizeX");
			sizeY = info.GetInt32("sizeY");
			sizeZ = info.GetInt32("sizeZ");
			byte[] array = (byte[])info.GetValue("dataType", typeof(byte[]));
			byte[] array2 = (byte[])info.GetValue("coverage", typeof(byte[]));
			byte[] array3 = (byte[])info.GetValue("digAmount", typeof(byte[]));
			byte[] array4 = (byte[])info.GetValue("health", typeof(byte[]));
			byte[] array5 = (byte[])info.GetValue("byteId", typeof(byte[]));
			gridData = new MapNode[count];
			GridDataIndexTools.InitialiseFastMethods(sizeX, sizeY, sizeZ);
			VoxelTypeRepository instance = Repository<VoxelTypeRepository, VoxelType>.Instance;
			for (int i = 0; i < count; i++)
			{
				VoxelType byByteId = instance.GetByByteId(array5[i]);
				GridDataType gridDataType = (GridDataType)ReadInt(ref array, i * 4);
				CoverageType coverageType = (CoverageType)array2[i];
				byte digAmount = array3[i];
				short health = ReadShort(ref array4, i * 2);
				MapNode mapNode = new MapNode(GridDataIndexTools.FastTo3DIndex(i), byByteId, health, digAmount, coverageType, gridDataType);
				gridData[i] = mapNode;
			}
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			count = gridData.Length;
			info.AddValue("count", count);
			info.AddValue("sizeX", sizeX);
			info.AddValue("sizeY", sizeY);
			info.AddValue("sizeZ", sizeZ);
			byte[] outData = new byte[4 * count];
			byte[] outData2 = new byte[count];
			byte[] outData3 = new byte[count];
			byte[] outData4 = new byte[2 * count];
			byte[] outData5 = new byte[count];
			for (int i = 0; i < count; i++)
			{
				MapNode mapNode = gridData[i];
				byte voxelTypeIdByte = mapNode.VoxelTypeIdByte;
				AppendValueInt(ref outData, (int)mapNode.DataType, i * 4);
				AppendValueShort(ref outData4, mapNode.Health, i * 2);
				AppendValueByte(ref outData3, mapNode.DigAmount, i);
				AppendValueByte(ref outData2, (byte)mapNode.Coverage, i);
				AppendValueByte(ref outData5, voxelTypeIdByte, i);
			}
			info.AddValue("dataType", outData);
			info.AddValue("coverage", outData2);
			info.AddValue("digAmount", outData3);
			info.AddValue("health", outData4);
			info.AddValue("byteId", outData5);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.ChangeWriter("MapNodes.bin");
			count = gridData.Length;
			serializer.Write("count", count);
			serializer.Write("sizeX", sizeX);
			serializer.Write("sizeY", sizeY);
			serializer.Write("sizeZ", sizeZ);
			byte[] outData = new byte[4 * count];
			byte[] outData2 = new byte[count];
			byte[] outData3 = new byte[count];
			byte[] outData4 = new byte[2 * count];
			byte[] outData5 = new byte[count];
			for (int i = 0; i < count; i++)
			{
				MapNode mapNode = gridData[i];
				byte voxelTypeIdByte = mapNode.VoxelTypeIdByte;
				AppendValueInt(ref outData, (int)mapNode.DataType, i * 4);
				AppendValueShort(ref outData4, mapNode.Health, i * 2);
				AppendValueByte(ref outData3, mapNode.DigAmount, i);
				AppendValueByte(ref outData2, (byte)mapNode.Coverage, i);
				AppendValueByte(ref outData5, voxelTypeIdByte, i);
			}
			serializer.Write("dataType", outData);
			serializer.Write("coverage", outData2);
			serializer.Write("digAmount", outData3);
			serializer.Write("health", outData4);
			serializer.Write("byteId", outData5);
			serializer.PopBackWriter();
		}

		public MapNodesHolder(FVDeserializer deserializer)
		{
			deserializer.ChangeReader("MapNodes.bin");
			count = deserializer.ReadInt("count");
			sizeX = deserializer.ReadInt("sizeX");
			sizeY = deserializer.ReadInt("sizeY");
			sizeZ = deserializer.ReadInt("sizeZ");
			byte[] array = deserializer.ReadByteArray("dataType");
			byte[] array2 = deserializer.ReadByteArray("coverage");
			byte[] array3 = deserializer.ReadByteArray("digAmount");
			byte[] array4 = deserializer.ReadByteArray("health");
			byte[] array5 = deserializer.ReadByteArray("byteId");
			gridData = new MapNode[count];
			GridDataIndexTools.InitialiseFastMethods(sizeX, sizeY, sizeZ);
			for (int i = 0; i < count; i++)
			{
				VoxelType byByteId = VoxelTypeRepository.FastInstance.GetByByteId(array5[i]);
				GridDataType gridDataType = (GridDataType)ReadInt(ref array, i * 4);
				CoverageType coverageType = (CoverageType)array2[i];
				byte digAmount = array3[i];
				short health = ReadShort(ref array4, i * 2);
				MapNode mapNode = new MapNode(GridDataIndexTools.FastTo3DIndex(i), byByteId, health, digAmount, coverageType, gridDataType);
				gridData[i] = mapNode;
			}
			deserializer.PopBackReader();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private short ReadShort(ref byte[] array, int index)
		{
			return (short)(array[index] | (array[index + 1] << 8));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int ReadInt(ref byte[] array, int index)
		{
			return array[index] | (array[index + 1] << 8) | (array[index + 2] << 16) | (array[index + 3] << 24);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AppendValueInt(ref byte[] outData, int data, int index)
		{
			outData[index] = (byte)(data & 0xFF);
			outData[index + 1] = (byte)((data >> 8) & 0xFF);
			outData[index + 2] = (byte)((data >> 16) & 0xFF);
			outData[index + 3] = (byte)((data >> 24) & 0xFF);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AppendValueShort(ref byte[] outData, short data, int index)
		{
			outData[index] = (byte)(data & 0xFF);
			outData[index + 1] = (byte)((data >> 8) & 0xFF);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AppendValueByte(ref byte[] outData, byte data, int index)
		{
			outData[index] = data;
		}

		private void SetGridData(MapNode[] gridData)
		{
			int t = gridData?.GetHashCode() ?? (-1);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\MapNodesHolder.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("SetGridData: ");
				messageBuilder.AppendFormatted((gridData == null) ? "NULL" : gridData.Length.ToString());
				messageBuilder.AppendLiteral(", hash = ");
				messageBuilder.AppendFormatted(t);
			}
			Log.Info(messageBuilder);
			this.gridData = gridData;
			if (gridData != null)
			{
				count = this.gridData.Length;
			}
		}
	}
}
