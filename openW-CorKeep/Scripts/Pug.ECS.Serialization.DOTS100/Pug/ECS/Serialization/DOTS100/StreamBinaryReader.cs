using System;
using System.IO;
using Unity.IO.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	internal class StreamBinaryReader : BinaryReader, IDisposable
	{
		internal string FilePath { get; }

		public long Position { get; set; }

		public StreamBinaryReader(string filePath, long bufferSize = 65536L)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentException("The filepath can neither be null nor empty", "filePath");
			}
			FilePath = filePath;
			Position = 0L;
		}

		public void Dispose()
		{
		}

		public unsafe void ReadBytes(void* data, int bytes)
		{
			ReadCommand readCommand = new ReadCommand
			{
				Size = bytes,
				Offset = Position,
				Buffer = data
			};
			ReadHandle readHandle = AsyncReadManager.Read(FilePath, &readCommand, 1u, "", 0uL);
			readHandle.JobHandle.Complete();
			if (readHandle.Status != ReadStatus.Complete)
			{
				throw new IOException("Failed to read from " + FilePath + "!");
			}
			Position += bytes;
		}
	}
}
