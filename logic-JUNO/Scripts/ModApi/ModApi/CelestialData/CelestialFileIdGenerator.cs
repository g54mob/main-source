using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ModApi.CelestialData
{
	public static class CelestialFileIdGenerator
	{
		private static readonly byte[] _byteOrderMark = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetPreamble();

		private static readonly Encoding _encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

		private static char[] _inputCharBuffer;

		private static MD5CryptoServiceProvider _md5 = new MD5CryptoServiceProvider();

		private static StreamWriter _streamWriter;

		public static Guid GenerateId(Stream stream, bool normalizeTextContent)
		{
			if (normalizeTextContent)
			{
				using (StreamReader inputStream = new StreamReader(stream))
				{
					return GenerateIdWithNormalizedText(inputStream);
				}
			}
			return new Guid(_md5.ComputeHash(stream));
		}

		public static Guid GenerateId(byte[] data, bool normalizeTextContent)
		{
			if (normalizeTextContent)
			{
				using (MemoryStream stream = new MemoryStream(data, writable: false))
				{
					using StreamReader inputStream = new StreamReader(stream);
					return GenerateIdWithNormalizedText(inputStream);
				}
			}
			return new Guid(_md5.ComputeHash(data));
		}

		public static Guid GenerateId(Stream stream, CelestialFileType type)
		{
			return GenerateId(stream, ShouldNormalizeTextContent(type));
		}

		public static Guid GenerateId(byte[] data, CelestialFileType type)
		{
			return GenerateId(data, ShouldNormalizeTextContent(type));
		}

		public static Guid GenerateId(CelestialFilePath path, CelestialFileType type)
		{
			return GenerateId(path, ShouldNormalizeTextContent(type));
		}

		public static Guid GenerateId(CelestialFilePath path, bool normalizeTextContent)
		{
			if (normalizeTextContent)
			{
				using (StreamReader inputStream = new StreamReader(path.FullPath))
				{
					return GenerateIdWithNormalizedText(inputStream);
				}
			}
			using FileStream inputStream2 = File.Open(path.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
			return new Guid(_md5.ComputeHash(inputStream2));
		}

		private static Guid GenerateIdWithNormalizedText(StreamReader inputStream)
		{
			StreamWriter streamWriter = GetStreamWriter();
			MemoryStream memoryStream = (MemoryStream)streamWriter.BaseStream;
			char[] array = _inputCharBuffer ?? (_inputCharBuffer = new char[4096]);
			int count = array.Length;
			int num = 0;
			streamWriter.BaseStream.Write(_byteOrderMark, 0, _byteOrderMark.Length);
			while ((num = inputStream.ReadBlock(array, 0, count)) != 0)
			{
				int num2 = 0;
				int num3 = 0;
				for (int i = num2; i < num; i++)
				{
					switch (array[i])
					{
					case '\r':
						num3 = i - num2;
						if (num3 > 0)
						{
							streamWriter.Write(array, num2, num3);
						}
						num2 = i + 1;
						break;
					case '\n':
						num3 = i - num2;
						if (num3 > 0)
						{
							streamWriter.Write(array, num2, num3);
						}
						streamWriter.Write('\r');
						streamWriter.Write('\n');
						num2 = i + 1;
						break;
					}
				}
				num3 = num - num2;
				if (num3 > 0)
				{
					streamWriter.Write(array, num2, num3);
				}
			}
			streamWriter.Flush();
			memoryStream.Position = 0L;
			return new Guid(_md5.ComputeHash(memoryStream.GetBuffer(), 0, (int)memoryStream.Length));
		}

		private static StreamWriter GetStreamWriter()
		{
			if (_streamWriter == null)
			{
				_streamWriter = new StreamWriter(new MemoryStream(), _encoding, 4096, leaveOpen: true);
			}
			else
			{
				_streamWriter.Flush();
				Stream baseStream = _streamWriter.BaseStream;
				baseStream.Position = 0L;
				baseStream.SetLength(0L);
			}
			return _streamWriter;
		}

		private static bool ShouldNormalizeTextContent(CelestialFileType celestialFileType)
		{
			if (celestialFileType != CelestialFileType.PlanetarySystem)
			{
				return celestialFileType == CelestialFileType.CelestialBody;
			}
			return true;
		}
	}
}
