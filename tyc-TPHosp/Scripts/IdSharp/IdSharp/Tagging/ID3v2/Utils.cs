#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using zlib;

namespace IdSharp.Tagging.ID3v2
{
	internal static class Utils
	{
		private static Encoding m_ISO88591 = Encoding.GetEncoding(28591);

		public static byte ReadByte(Stream stream)
		{
			int num = stream.ReadByte();
			if (num == -1)
			{
				string message = $"Attempted to read past the end of the stream at position {stream.Position}";
				Trace.WriteLine(message);
				throw new InvalidDataException(message);
			}
			return (byte)num;
		}

		public static byte ReadByte(Stream stream, ref int bytesLeft)
		{
			if (bytesLeft > 0)
			{
				bytesLeft--;
				return ReadByte(stream);
			}
			string message = $"Attempted to read past the end of the frame at position {stream.Position}";
			Trace.WriteLine(message);
			throw new InvalidDataException(message);
		}

		public static byte[] Read(Stream stream, int count)
		{
			byte[] array = new byte[count];
			if (stream.Read(array, 0, count) != count)
			{
				string message = $"Attempted to read past the end of the stream when requesting {count} bytes at position {stream.Position}";
				Trace.WriteLine(message);
				throw new InvalidDataException(message);
			}
			return array;
		}

		public static byte[] Read(Stream stream, int count, ref int bytesLeft)
		{
			bytesLeft -= count;
			return Read(stream, count);
		}

		public static int ReadInt32(Stream stream)
		{
			byte[] array = Read(stream, 4);
			return (array[0] << 24) + (array[1] << 16) + (array[2] << 8) + array[3];
		}

		public static int ReadInt32SyncSafe(Stream stream)
		{
			byte[] array = Read(stream, 4);
			return (array[0] << 21) + (array[1] << 14) + (array[2] << 7) + array[3];
		}

		public static int ReadInt24(Stream stream)
		{
			byte[] array = Read(stream, 3);
			return (array[0] << 16) + (array[1] << 8) + array[2];
		}

		public static void Write(MemoryStream targetStream, byte[] byteArray)
		{
			targetStream.Write(byteArray, 0, byteArray.Length);
		}

		public static string ReadString(EncodingType textEncoding, Stream stream, int length)
		{
			byte[] array = Read(stream, length);
			string text;
			switch (textEncoding)
			{
			case EncodingType.ISO88591:
				text = ISO88591GetString(array);
				break;
			case EncodingType.Unicode:
				text = ((length <= 2) ? "" : ((array.Length < 2) ? Encoding.Unicode.GetString(array, 0, array.Length) : ((array[0] == byte.MaxValue && array[1] == 254) ? Encoding.Unicode.GetString(array, 2, array.Length - 2) : ((array[0] != 254 || array[1] != byte.MaxValue) ? Encoding.Unicode.GetString(array, 0, array.Length) : Encoding.BigEndianUnicode.GetString(array, 2, array.Length - 2)))));
				break;
			case EncodingType.UTF16BE:
				text = ((array.Length < 2) ? Encoding.BigEndianUnicode.GetString(array, 0, array.Length) : ((array[0] != 254 || array[1] != byte.MaxValue) ? Encoding.BigEndianUnicode.GetString(array, 0, array.Length) : Encoding.BigEndianUnicode.GetString(array, 2, array.Length - 2)));
				break;
			case EncodingType.UTF8:
				text = Encoding.UTF8.GetString(array, 0, length);
				break;
			default:
			{
				string message = $"Text Encoding '{textEncoding}' unknown at position {stream.Position}";
				Trace.WriteLine(message);
				return "";
			}
			}
			string text2 = text;
			char[] trimChars = new char[1];
			return text2.TrimEnd(trimChars);
		}

		public static string ReadString(EncodingType textEncoding, Stream stream, ref int bytesLeft)
		{
			if (bytesLeft <= 0)
			{
				return "";
			}
			List<byte> list = new List<byte>();
			string text;
			if (textEncoding == EncodingType.ISO88591)
			{
				byte b = ReadByte(stream);
				bytesLeft--;
				if (bytesLeft == 0)
				{
					return "";
				}
				while (b != 0)
				{
					list.Add(b);
					b = ReadByte(stream);
					bytesLeft--;
					if (bytesLeft == 0)
					{
						if (b != 0)
						{
							list.Add(b);
						}
						return ISO88591GetString(list.ToArray());
					}
				}
				text = ISO88591GetString(list.ToArray());
			}
			else if (textEncoding == EncodingType.Unicode)
			{
				byte b2;
				byte b3;
				do
				{
					b2 = ReadByte(stream);
					list.Add(b2);
					bytesLeft--;
					if (bytesLeft == 0)
					{
						return "";
					}
					b3 = ReadByte(stream);
					list.Add(b3);
					bytesLeft--;
				}
				while (bytesLeft != 0 && (b2 != 0 || b3 != 0));
				byte[] array = list.ToArray();
				text = ((array.Length < 2) ? Encoding.Unicode.GetString(array, 0, array.Length) : ((array[0] == byte.MaxValue && array[1] == 254) ? Encoding.Unicode.GetString(array, 2, array.Length - 2) : ((array[0] != 254 || array[1] != byte.MaxValue) ? Encoding.Unicode.GetString(array, 0, array.Length) : Encoding.BigEndianUnicode.GetString(array, 2, array.Length - 2))));
			}
			else if (textEncoding == EncodingType.UTF16BE)
			{
				byte b4;
				byte b5;
				do
				{
					b4 = ReadByte(stream);
					list.Add(b4);
					bytesLeft--;
					if (bytesLeft == 0)
					{
						return "";
					}
					b5 = ReadByte(stream);
					list.Add(b5);
					bytesLeft--;
				}
				while (bytesLeft != 0 && (b4 != 0 || b5 != 0));
				byte[] array2 = list.ToArray();
				text = ((array2.Length < 2) ? Encoding.BigEndianUnicode.GetString(array2, 0, array2.Length) : ((array2[0] != 254 || array2[1] != byte.MaxValue) ? Encoding.BigEndianUnicode.GetString(array2, 0, array2.Length) : Encoding.BigEndianUnicode.GetString(array2, 2, array2.Length - 2)));
			}
			else
			{
				if (textEncoding != EncodingType.UTF8)
				{
					string message = $"Text Encoding '{textEncoding}' unknown at position {stream.Position}";
					Trace.WriteLine(message);
					return "";
				}
				byte b6 = ReadByte(stream);
				bytesLeft--;
				if (bytesLeft == 0)
				{
					return "";
				}
				while (b6 != 0)
				{
					list.Add(b6);
					b6 = ReadByte(stream);
					bytesLeft--;
					if (bytesLeft == 0)
					{
						return "";
					}
				}
				text = Encoding.UTF8.GetString(list.ToArray());
			}
			string text2 = text;
			char[] trimChars = new char[1];
			return text2.TrimEnd(trimChars);
		}

		private static void CopyStream(Stream input, Stream output, int size)
		{
			byte[] buffer = new byte[size];
			input.Read(buffer, 0, size);
			output.Write(buffer, 0, size);
			output.Flush();
		}

		public static Stream DecompressFrame(Stream stream, int compressedSize)
		{
			Stream stream2 = new MemoryStream();
			ZOutputStream output = new ZOutputStream(stream2);
			CopyStream(stream, output, compressedSize);
			stream2.Position = 0L;
			return stream2;
		}

		public static short ReadInt16(Stream stream, ref int bytesLeft)
		{
			byte[] array = Read(stream, 2);
			bytesLeft -= 2;
			return (short)((array[0] << 8) + array[1]);
		}

		public static long ConvertToInt64(byte[] byteArray)
		{
			long num = 0L;
			for (int i = 0; i < byteArray.Length; i++)
			{
				num <<= 8;
				num += byteArray[i];
			}
			return num;
		}

		public static bool IsBitSet(byte byteToCheck, byte bitToCheck)
		{
			return ((byteToCheck >> (int)bitToCheck) & 1) == 1;
		}

		public static Stream ReadUnsynchronizedStream(Stream stream, int length)
		{
			Stream stream2 = new MemoryStream(ReadUnsynchronized(stream, length), 0, length);
			stream2.Position = 0L;
			return stream2;
		}

		public static byte[] ReadUnsynchronized(byte[] stream)
		{
			using MemoryStream memoryStream = new MemoryStream(stream.Length);
			int i = 0;
			int num = 0;
			for (; i < stream.Length; i++)
			{
				byte b = stream[num++];
				memoryStream.WriteByte(b);
				if (b == byte.MaxValue)
				{
					b = stream[num++];
					if (b != 0)
					{
						memoryStream.WriteByte(b);
						i++;
					}
				}
			}
			return memoryStream.ToArray();
		}

		public static byte[] ReadUnsynchronized(Stream stream, int size)
		{
			using MemoryStream memoryStream = new MemoryStream(size);
			for (int i = 0; i < size; i++)
			{
				byte b = ReadByte(stream);
				memoryStream.WriteByte(b);
				if (b == byte.MaxValue)
				{
					b = ReadByte(stream);
					if (b != 0)
					{
						memoryStream.WriteByte(b);
						i++;
					}
				}
			}
			return memoryStream.ToArray();
		}

		public static int ReadInt32Unsynchronized(Stream stream)
		{
			byte[] array = ReadUnsynchronized(stream, 4);
			return (array[0] << 24) + (array[1] << 16) + (array[2] << 8) + array[3];
		}

		public static int ReadInt24Unsynchronized(Stream stream)
		{
			byte[] array = ReadUnsynchronized(stream, 3);
			return (array[0] << 16) + (array[1] << 8) + array[2];
		}

		public static byte[] GetStringBytes(ID3v2TagVersion tagVersion, EncodingType encodingType, string value, bool isTerminated)
		{
			List<byte> list = new List<byte>();
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v22:
			{
				EncodingType encodingType3 = encodingType;
				if (encodingType3 == EncodingType.Unicode)
				{
					if (!string.IsNullOrEmpty(value))
					{
						list.Add(byte.MaxValue);
						list.Add(254);
						list.AddRange(Encoding.Unicode.GetBytes(value));
					}
					if (isTerminated)
					{
						byte[] collection4 = new byte[2];
						list.AddRange(collection4);
					}
				}
				else
				{
					list.AddRange(ISO88591GetBytes(value));
					if (isTerminated)
					{
						list.Add(0);
					}
				}
				break;
			}
			case ID3v2TagVersion.ID3v23:
			{
				EncodingType encodingType2 = encodingType;
				if (encodingType2 == EncodingType.Unicode)
				{
					if (!string.IsNullOrEmpty(value))
					{
						list.Add(byte.MaxValue);
						list.Add(254);
						list.AddRange(Encoding.Unicode.GetBytes(value));
					}
					if (isTerminated)
					{
						byte[] collection3 = new byte[2];
						list.AddRange(collection3);
					}
				}
				else
				{
					list.AddRange(ISO88591GetBytes(value));
					if (isTerminated)
					{
						list.Add(0);
					}
				}
				break;
			}
			case ID3v2TagVersion.ID3v24:
				switch (encodingType)
				{
				case EncodingType.UTF8:
					if (!string.IsNullOrEmpty(value))
					{
						list.AddRange(Encoding.UTF8.GetBytes(value));
					}
					if (isTerminated)
					{
						list.Add(0);
					}
					break;
				case EncodingType.UTF16BE:
					if (!string.IsNullOrEmpty(value))
					{
						list.AddRange(Encoding.BigEndianUnicode.GetBytes(value));
					}
					if (isTerminated)
					{
						byte[] collection2 = new byte[2];
						list.AddRange(collection2);
					}
					break;
				case EncodingType.Unicode:
					if (!string.IsNullOrEmpty(value))
					{
						list.Add(byte.MaxValue);
						list.Add(254);
						list.AddRange(Encoding.Unicode.GetBytes(value));
					}
					if (isTerminated)
					{
						byte[] collection = new byte[2];
						list.AddRange(collection);
					}
					break;
				default:
					list.AddRange(ISO88591GetBytes(value));
					if (isTerminated)
					{
						list.Add(0);
					}
					break;
				}
				break;
			default:
				throw new ArgumentException("Unknown tag version");
			}
			return list.ToArray();
		}

		public static byte[] ConvertToUnsynchronized(byte[] data)
		{
			using MemoryStream memoryStream = new MemoryStream((int)((double)data.Length * 1.05));
			for (int i = 0; i < data.Length; i++)
			{
				memoryStream.WriteByte(data[i]);
				if (data[i] == byte.MaxValue && i != data.Length - 1 && (data[i + 1] == 0 || (data[i + 1] & 0xE0) == 224))
				{
					memoryStream.WriteByte(0);
				}
			}
			return memoryStream.ToArray();
		}

		public static byte[] GetBytesDecimal(decimal decimalValue, int bytes)
		{
			byte[] bytesMinimal = GetBytesMinimal((ulong)decimalValue);
			if (bytesMinimal.Length == bytes)
			{
				return bytesMinimal;
			}
			if (bytesMinimal.Length > bytes)
			{
				byte[] array = new byte[bytes];
				int num = bytesMinimal.Length - bytes;
				int num2 = 0;
				while (num < bytesMinimal.Length)
				{
					array[num2] = bytesMinimal[num];
					num++;
					num2++;
				}
				return array;
			}
			byte[] array2 = new byte[bytes];
			int num3 = bytes - bytesMinimal.Length;
			int num4 = 0;
			while (num3 < bytes)
			{
				array2[num3] = bytesMinimal[num4];
				num3++;
				num4++;
			}
			return array2;
		}

		public static byte[] GetBytesMinimal(long value)
		{
			return GetBytesMinimal((ulong)value);
		}

		public static byte[] GetBytesMinimal(ulong value)
		{
			if (value <= 255)
			{
				return new byte[1] { (byte)value };
			}
			if (value <= 65535)
			{
				return Get2Bytes((ushort)value);
			}
			if (value <= uint.MaxValue)
			{
				return Get4Bytes((uint)value);
			}
			return Get8Bytes(value);
		}

		public static byte[] Get8Bytes(ulong value)
		{
			return new byte[8]
			{
				(byte)((value >> 56) & 0xFF),
				(byte)((value >> 48) & 0xFF),
				(byte)((value >> 40) & 0xFF),
				(byte)((value >> 32) & 0xFF),
				(byte)((value >> 24) & 0xFF),
				(byte)((value >> 16) & 0xFF),
				(byte)((value >> 8) & 0xFF),
				(byte)(value & 0xFF)
			};
		}

		public static byte[] Get4Bytes(uint value)
		{
			return new byte[4]
			{
				(byte)((value >> 24) & 0xFF),
				(byte)((value >> 16) & 0xFF),
				(byte)((value >> 8) & 0xFF),
				(byte)(value & 0xFF)
			};
		}

		public static byte[] Get2Bytes(ushort value)
		{
			return new byte[2]
			{
				(byte)((value >> 8) & 0xFF),
				(byte)(value & 0xFF)
			};
		}

		public static byte[] Get4Bytes(int value)
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value", value, "Value cannot be less than 0");
			}
			return Get4Bytes((uint)value);
		}

		public static byte[] Get2Bytes(short value)
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value", value, "Value cannot be less than 0");
			}
			return Get2Bytes((ushort)value);
		}

		public static byte[] ISO88591GetBytes(string value)
		{
			if (value == null)
			{
				return new byte[0];
			}
			return m_ISO88591.GetBytes(value);
		}

		public static string ISO88591GetString(byte[] value)
		{
			if (value == null)
			{
				return string.Empty;
			}
			return m_ISO88591.GetString(value);
		}

		public static void ReplaceBytes(string path, int bytesToRemove, byte[] bytesToAdd)
		{
			byte[] array = new byte[8];
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)random.Next(65, 91);
			}
			string arg = Encoding.ASCII.GetString(array);
			string text = $"{path}.{arg}.tmp";
			File.Move(path, text);
			byte[] buffer = new byte[32767];
			using (FileStream fileStream = File.Open(text, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				using FileStream fileStream2 = File.Open(path, FileMode.CreateNew, FileAccess.Write, FileShare.None);
				fileStream2.Write(bytesToAdd, 0, bytesToAdd.Length);
				fileStream.Position = bytesToRemove;
				for (int num = fileStream.Read(buffer, 0, 32767); num > 0; num = fileStream.Read(buffer, 0, 32767))
				{
					fileStream2.Write(buffer, 0, num);
				}
			}
			File.Delete(text);
		}
	}
}
