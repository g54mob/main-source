using System.IO;

namespace NSMedieval.Serialization
{
	public class FVBinaryWriter
	{
		private readonly MemoryStream memoryStream;

		private readonly string id;

		public BinaryWriter Writer { get; }

		public FVBinaryWriter(string id)
		{
			this.id = id;
			memoryStream = new MemoryStream();
			Writer = new BinaryWriter(memoryStream);
		}

		~FVBinaryWriter()
		{
			memoryStream?.Dispose();
		}

		public string GetId()
		{
			return id;
		}

		public byte[] GetBytes()
		{
			return memoryStream.ToArray();
		}

		public long GetBufferPosition()
		{
			return memoryStream.Position;
		}

		public void SeekBuffer(long index)
		{
			Writer.BaseStream.Seek(index, SeekOrigin.Begin);
		}
	}
}
