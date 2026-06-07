using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

public class PrintedFile
{
	private enum ChunkType
	{
		None = 0,
		Metadata = 1,
		Gadget = 2,
		Assets = 3,
		ModuleDatas = 4
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
	private struct ChunkLocation
	{
		public uint offset;

		public uint size;

		public uint end => 0u;

		public ChunkLocation(uint offset, uint size)
		{
			this.offset = 0u;
			this.size = 0u;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
	private struct ChunkDescriptor
	{
		public ChunkType type;

		public ChunkLocation location;

		public ChunkDescriptor(ChunkType type, ChunkLocation location)
		{
			this.type = default(ChunkType);
			this.location = default(ChunkLocation);
		}
	}

	private class ChunksTable
	{
		public List<ChunkDescriptor> chunks;

		public ChunkDescriptor? GetChunkDescriptor(ChunkType type)
		{
			return null;
		}

		public int GetChunkIndex(ChunkType type)
		{
			return 0;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
	private struct AssetDescriptor
	{
		public uint assetId;

		public uint offset;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
	private struct ModuleDataDescriptor
	{
		public uint moduleId;

		public uint offset;
	}

	private enum ReadHeaderResult
	{
		Ok = 0,
		InvalidSignature = 1,
		UnsupportedVersion = 2
	}

	private const uint version = 0u;

	public const string extension = "printed";

	private static byte[] fileSignature;

	private static T ToStruct<T>(byte[] data) where T : struct
	{
		return default(T);
	}

	private static byte[] GetBytes<T>(T data) where T : struct
	{
		return null;
	}

	private static byte[] GetModuleDataSegment(SerializedModuleData.PersistentState persistentSerializedModuleData)
	{
		return null;
	}

	private static byte[] GetModuleDatasChunk(SerializedGadget.PersistentState persistentSerializedGadget)
	{
		return null;
	}

	public static void WriteDataToStream(SerializedGadgetMetaData.PersistentState persistentMetadata, SerializedGadget.PersistentState persistentSerializedGadget, Stream stream)
	{
	}

	public static void UpdateMetadata(string file, SerializedGadgetMetaData.PersistentState persistentMetadata)
	{
	}

	private static void WriteChunksTable(BinaryWriter writer, ChunksTable chunksTable, uint writeVersion)
	{
	}

	private static ReadHeaderResult ReadHeader(BinaryReader reader, out uint readedVersion, out long chunksTableLocation, out ChunksTable chunksTable)
	{
		readedVersion = default(uint);
		chunksTableLocation = default(long);
		chunksTable = null;
		return default(ReadHeaderResult);
	}

	private static ChunksTable ReadChunksTable(BinaryReader reader, uint readedVersion)
	{
		return null;
	}

	public static SerializedGadgetMetaData.PersistentState ReadPersistentMetadata(string file)
	{
		return null;
	}

	private static SerializedPersistentModuleDatas ReadSerializedPersistentModuleDatas(BinaryReader reader)
	{
		return null;
	}

	public static SerializedGadget.PersistentState ReadGadgetPersistentState(string file)
	{
		return null;
	}
}
