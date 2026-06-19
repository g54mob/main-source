using System;
using System.IO;
using Unity.Collections.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	internal class StreamBinaryWriter : BinaryWriter, IDisposable
	{
		private Stream stream;

		private byte[] buffer;

		public long Position
		{
			get
			{
				return stream.Position;
			}
			set
			{
				stream.Position = value;
			}
		}

		public long Length => stream.Length;

		public StreamBinaryWriter(string fileName, int bufferSize = 65536)
		{
			stream = File.Open(fileName, FileMode.Create, FileAccess.Write);
			buffer = new byte[bufferSize];
		}

		public void Dispose()
		{
			stream.Dispose();
		}

		public unsafe void WriteBytes(void* data, int bytes)
		{
			int num = bytes;
			int val = buffer.Length;
			fixed (byte* destination = buffer)
			{
				while (num != 0)
				{
					int num2 = Math.Min(num, val);
					UnsafeUtility.MemCpy(destination, data, num2);
					stream.Write(buffer, 0, num2);
					data = (byte*)data + num2;
					num -= num2;
				}
			}
		}
	}
}
