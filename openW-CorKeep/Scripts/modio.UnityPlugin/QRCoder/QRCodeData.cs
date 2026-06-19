using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using QRCoder.Framework4._0Methods;

namespace QRCoder
{
	public class QRCodeData : IDisposable
	{
		public enum Compression
		{
			Uncompressed = 0,
			Deflate = 1,
			GZip = 2
		}

		public List<BitArray> ModuleMatrix { get; set; }

		public int Version { get; private set; }

		public QRCodeData(int version)
		{
			Version = version;
			int num = ModulesPerSideFromVersion(version);
			ModuleMatrix = new List<BitArray>();
			for (int i = 0; i < num; i++)
			{
				ModuleMatrix.Add(new BitArray(num));
			}
		}

		public QRCodeData(byte[] rawData, Compression compressMode)
		{
			List<byte> list = new List<byte>(rawData);
			switch (compressMode)
			{
			case Compression.Deflate:
			{
				using (MemoryStream stream2 = new MemoryStream(list.ToArray()))
				{
					using MemoryStream memoryStream2 = new MemoryStream();
					using (DeflateStream input2 = new DeflateStream(stream2, CompressionMode.Decompress))
					{
						Stream4Methods.CopyTo(input2, memoryStream2);
					}
					list = new List<byte>(memoryStream2.ToArray());
				}
				break;
			}
			case Compression.GZip:
			{
				using (MemoryStream stream = new MemoryStream(list.ToArray()))
				{
					using MemoryStream memoryStream = new MemoryStream();
					using (GZipStream input = new GZipStream(stream, CompressionMode.Decompress))
					{
						Stream4Methods.CopyTo(input, memoryStream);
					}
					list = new List<byte>(memoryStream.ToArray());
				}
				break;
			}
			}
			if (list[0] != 81 || list[1] != 82 || list[2] != 82)
			{
				throw new Exception("Invalid raw data file. Filetype doesn't match \"QRR\".");
			}
			int num = list[4];
			list.RemoveRange(0, 5);
			Version = (num - 21 - 8) / 4 + 1;
			Queue<bool> queue = new Queue<bool>(8 * list.Count);
			foreach (byte item in list)
			{
				new BitArray(new byte[1] { item });
				for (int num2 = 7; num2 >= 0; num2--)
				{
					queue.Enqueue((item & (1 << num2)) != 0);
				}
			}
			ModuleMatrix = new List<BitArray>(num);
			for (int i = 0; i < num; i++)
			{
				ModuleMatrix.Add(new BitArray(num));
				for (int j = 0; j < num; j++)
				{
					ModuleMatrix[i][j] = queue.Dequeue();
				}
			}
		}

		public byte[] GetRawData(Compression compressMode)
		{
			List<byte> list = new List<byte>();
			list.AddRange(new byte[4] { 81, 82, 82, 0 });
			list.Add((byte)ModuleMatrix.Count);
			Queue<int> queue = new Queue<int>();
			foreach (BitArray item in ModuleMatrix)
			{
				foreach (object item2 in item)
				{
					queue.Enqueue(((bool)item2) ? 1 : 0);
				}
			}
			for (int i = 0; i < 8 - ModuleMatrix.Count * ModuleMatrix.Count % 8; i++)
			{
				queue.Enqueue(0);
			}
			while (queue.Count > 0)
			{
				byte b = 0;
				for (int num = 7; num >= 0; num--)
				{
					b += (byte)(queue.Dequeue() << num);
				}
				list.Add(b);
			}
			byte[] array = list.ToArray();
			switch (compressMode)
			{
			case Compression.Deflate:
			{
				using (MemoryStream memoryStream2 = new MemoryStream())
				{
					using (DeflateStream deflateStream = new DeflateStream(memoryStream2, CompressionMode.Compress))
					{
						deflateStream.Write(array, 0, array.Length);
					}
					array = memoryStream2.ToArray();
				}
				break;
			}
			case Compression.GZip:
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, leaveOpen: true))
					{
						gZipStream.Write(array, 0, array.Length);
					}
					array = memoryStream.ToArray();
				}
				break;
			}
			}
			return array;
		}

		private static int ModulesPerSideFromVersion(int version)
		{
			return 21 + (version - 1) * 4;
		}

		public void Dispose()
		{
			ModuleMatrix = null;
			Version = 0;
		}
	}
}
