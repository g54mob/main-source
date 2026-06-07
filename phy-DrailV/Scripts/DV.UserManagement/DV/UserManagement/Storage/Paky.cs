using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DV.UserManagement.Storage
{
	public class Paky
	{
		public struct Chunk
		{
			public int Type { get; private set; }

			public long StartByte { get; private set; }

			public long EndByte { get; private set; }

			public long Length => EndByte - StartByte;

			public Chunk(int type, long startByte, long endByte)
			{
				Type = type;
				StartByte = startByte;
				EndByte = endByte;
			}

			public override bool Equals(object obj)
			{
				if (obj is Chunk chunk)
				{
					if (chunk.Type.Equals(Type) && chunk.StartByte == StartByte)
					{
						return chunk.EndByte == EndByte;
					}
					return false;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (int)((StartByte ^ EndByte) % int.MaxValue);
			}
		}

		public struct InputData
		{
			public int Type { get; private set; }

			public byte[] Data { get; private set; }

			public InputData(int type, byte[] data)
			{
				Type = type;
				Data = data;
			}

			public InputData(int type, string text)
			{
				Type = type;
				Data = ENCODING.GetBytes(text);
			}
		}

		public static readonly Encoding ENCODING = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: false);

		private static readonly byte[] PAKY_MAGIC = ENCODING.GetBytes("PAKY");

		private const byte VERSION = 1;

		private IStreamProvider streamProvider;

		private List<Chunk> chunks = new List<Chunk>();

		public byte AppVersion { get; private set; }

		public IReadOnlyList<Chunk> Chunks => chunks;

		public string AppMagic { get; private set; } = "";

		public Paky(byte[] source, string appMagic, byte maxAppVersion = 1)
			: this(new MemoryStreamProvider(source, 0L), appMagic, maxAppVersion)
		{
		}

		public Paky(string fileName, string appMagic, byte maxAppVersion = 1)
			: this(new FileStreamProvider(fileName, 0L), appMagic, maxAppVersion)
		{
		}

		public Paky(IStreamProvider streamProvider, string appMagic, byte maxAppVersion = 1)
		{
			this.streamProvider = streamProvider;
			Stream stream = streamProvider.GrabStream();
			try
			{
				byte[] array = new byte[PAKY_MAGIC.Length];
				stream.Read(array, 0, array.Length);
				if (!array.SequenceEqual(PAKY_MAGIC))
				{
					throw new InvalidDataException("Initial magic header mismatch");
				}
				if (stream.ReadByte() != 0)
				{
					throw new InvalidDataException("Non-zero byte after initial magic");
				}
				if (string.IsNullOrEmpty(appMagic))
				{
					List<byte> list = new List<byte>();
					while (stream.CanRead)
					{
						int num = stream.ReadByte();
						if (num == 0)
						{
							break;
						}
						list.Add((byte)num);
					}
					AppMagic = ENCODING.GetString(list.ToArray());
				}
				else
				{
					byte[] bytes = ENCODING.GetBytes(appMagic);
					byte[] array2 = new byte[bytes.Length];
					stream.Read(array2, 0, array2.Length);
					if (!array2.SequenceEqual(bytes))
					{
						throw new InvalidDataException("App magic mismatch, maybe not meant for this application");
					}
					if (stream.ReadByte() != 0)
					{
						throw new InvalidDataException("Non-zero byte after app magic");
					}
					AppMagic = appMagic;
				}
				if ((byte)stream.ReadByte() > 1)
				{
					throw new InvalidDataException("File packed with Paky version greater than latest this app knows how to read");
				}
				if (stream.ReadByte() != 0)
				{
					throw new InvalidDataException("Non-zero byte after package version");
				}
				AppVersion = (byte)stream.ReadByte();
				if (AppVersion > maxAppVersion)
				{
					throw new InvalidDataException("File packed with newer version version of application");
				}
				if (stream.ReadByte() != 0)
				{
					throw new InvalidDataException("Non-zero byte after app version");
				}
				byte[] array3 = new byte[4];
				byte[] array4 = new byte[8];
				stream.Read(array3, 0, 4);
				int num2 = BitConverter.ToInt32(array3, 0);
				for (int i = 0; i < num2; i++)
				{
					stream.Read(array3, 0, 4);
					int type = BitConverter.ToInt32(array3, 0);
					stream.Read(array4, 0, 8);
					long startByte = BitConverter.ToInt64(array4, 0);
					stream.Read(array4, 0, 8);
					long endByte = BitConverter.ToInt64(array4, 0);
					chunks.Add(new Chunk(type, startByte, endByte));
				}
				if (stream.ReadByte() != 0)
				{
					throw new InvalidDataException("Non-zero byte after header");
				}
				long position = stream.Position;
				long length = stream.Length;
				for (int j = 0; j < chunks.Count; j++)
				{
					if (chunks[j].Length < 0)
					{
						throw new InvalidDataException($"Chunk {chunks[j].Type} has negative length");
					}
					if (chunks[j].Length > int.MaxValue)
					{
						throw new InvalidDataException($"Chunk {chunks[j].Type} is longer than {int.MaxValue} bytes, this is not supported");
					}
					if (chunks[j].StartByte < position)
					{
						throw new InvalidDataException($"Chunk {chunks[j].Type} starts before valid starting point (got {chunks[j].StartByte}, must be >= {position}");
					}
					if (chunks[j].EndByte > length)
					{
						throw new InvalidDataException($"Chunk {chunks[j].Type} ends after valid ending point (got {chunks[j].EndByte}, must be <= {length}");
					}
				}
			}
			finally
			{
				streamProvider.ReleaseStream();
			}
		}

		public byte[] ReadChunk(Chunk chunk, byte[] buffer = null)
		{
			if (!chunks.Contains(chunk))
			{
				throw new InvalidOperationException("Chunk doesn't belong to this package");
			}
			if (buffer == null)
			{
				buffer = new byte[chunk.Length];
			}
			else if (buffer.Length < chunk.Length)
			{
				throw new ArgumentException($"Provided buffer is {buffer.Length} bytes long, and at least {chunk.Length} bytes are needed.");
			}
			try
			{
				Stream stream = streamProvider.GrabStream();
				stream.Seek(chunk.StartByte, SeekOrigin.Begin);
				stream.Read(buffer, 0, (int)chunk.Length);
				return buffer;
			}
			finally
			{
				streamProvider.ReleaseStream();
			}
		}

		public string ReadChunkAsText(Chunk chunk, byte[] buffer = null)
		{
			byte[] array = ReadChunk(chunk, buffer);
			if (array == null)
			{
				return null;
			}
			return ENCODING.GetString(array);
		}

		public byte[] ReadFirst(int chunkType, byte[] buffer = null)
		{
			int num = FindChunkIndex(chunkType);
			if (num < 0)
			{
				return null;
			}
			return ReadChunk(chunks[num], buffer);
		}

		public bool HasChunk(int chunkType)
		{
			return FindChunkIndex(chunkType) >= 0;
		}

		public int FindChunkIndex(int chunkType, int searchStartIndex = 0)
		{
			for (int i = searchStartIndex; i < chunks.Count; i++)
			{
				if (chunks[i].Type == chunkType)
				{
					return i;
				}
			}
			return -1;
		}

		public string ReadFirstAsText(int chunkType, byte[] buffer = null)
		{
			byte[] array = ReadFirst(chunkType, buffer);
			if (array == null)
			{
				return null;
			}
			return ENCODING.GetString(array);
		}

		public void Close()
		{
			streamProvider = null;
		}

		public InputData[] ExportAsInputData()
		{
			InputData[] array = new InputData[chunks.Count];
			for (int i = 0; i < chunks.Count; i++)
			{
				Chunk chunk = chunks[i];
				array[i] = new InputData(chunk.Type, ReadChunk(chunk));
			}
			return array;
		}

		public static void Pack(IEnumerable<InputData> dataChunks, string appMagic, byte appVersion, Stream outputStream)
		{
			foreach (InputData dataChunk in dataChunks)
			{
				if (dataChunk.Data == null)
				{
					throw new Exception("One of the data chunks is null");
				}
				if (dataChunk.Data.LongLength > int.MaxValue)
				{
					throw new Exception($"One if the chunks is longer than {int.MaxValue}, this is not supported");
				}
			}
			byte[] bytes = ENCODING.GetBytes(appMagic);
			int num = dataChunks.Count();
			long num2 = (long)(PAKY_MAGIC.Length + 1 + bytes.Length + 1 + 1 + 1 + 1 + 1 + 4) + (long)(num * 20) + 1;
			outputStream.Write(PAKY_MAGIC, 0, PAKY_MAGIC.Length);
			outputStream.WriteByte(0);
			outputStream.Write(bytes, 0, bytes.Length);
			outputStream.WriteByte(0);
			outputStream.WriteByte(1);
			outputStream.WriteByte(0);
			outputStream.WriteByte(appVersion);
			outputStream.WriteByte(0);
			outputStream.Write(BitConverter.GetBytes(num), 0, 4);
			foreach (InputData dataChunk2 in dataChunks)
			{
				outputStream.Write(BitConverter.GetBytes(dataChunk2.Type), 0, 4);
				outputStream.Write(BitConverter.GetBytes(num2), 0, 8);
				outputStream.Write(BitConverter.GetBytes(num2 + dataChunk2.Data.Length), 0, 8);
				num2 += dataChunk2.Data.Length;
			}
			outputStream.WriteByte(0);
			foreach (InputData dataChunk3 in dataChunks)
			{
				outputStream.Write(dataChunk3.Data, 0, dataChunk3.Data.Length);
			}
		}

		public static void PackToFile(IEnumerable<InputData> dataChunks, string appMagic, byte appVersion, string fileName)
		{
			using (FileStream outputStream = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				Pack(dataChunks, appMagic, appVersion, outputStream);
			}
		}

		public static byte[] PackToBytes(IEnumerable<InputData> dataChunks, string appMagic, byte appVersion)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Pack(dataChunks, appMagic, appVersion, memoryStream);
				return memoryStream.ToArray();
			}
		}
	}
}
