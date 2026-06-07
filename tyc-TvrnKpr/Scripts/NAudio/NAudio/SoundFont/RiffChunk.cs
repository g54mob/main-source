using System.IO;

namespace NAudio.SoundFont
{
	internal class RiffChunk
	{
		private string chunkID;

		private uint chunkSize;

		private long dataOffset;

		private BinaryReader riffFile;

		public string ChunkID
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public uint ChunkSize => 0u;

		public long DataOffset => 0L;

		public static RiffChunk GetTopLevelChunk(BinaryReader file)
		{
			return null;
		}

		private RiffChunk(BinaryReader file)
		{
		}

		public string ReadChunkID()
		{
			return null;
		}

		private void ReadChunk()
		{
		}

		public RiffChunk GetNextSubChunk()
		{
			return null;
		}

		public byte[] GetData()
		{
			return null;
		}

		public string GetDataAsString()
		{
			return null;
		}

		public T GetDataAsStructure<T>(StructureBuilder<T> s)
		{
			return default(T);
		}

		public T[] GetDataAsStructureArray<T>(StructureBuilder<T> s)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
