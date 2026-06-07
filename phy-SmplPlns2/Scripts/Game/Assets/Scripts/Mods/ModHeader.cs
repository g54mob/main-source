using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Mods
{
	public class ModHeader
	{
		public static readonly ModHeader Default;

		private static readonly string _HeaderTagV1;

		private static readonly byte[] _HeaderTagV1Buffer;

		private static readonly byte[] _HeaderTagV1Bytes;

		private static readonly byte[] _LongBuffer1;

		private static readonly byte[] _LongBuffer2;

		public long? AssetBundleOffsetAndroid { get; }

		public long? AssetBundleOffsetIOS { get; }

		public long? AssetBundleOffsetLinux { get; }

		public long? AssetBundleOffsetMacOS { get; }

		public long? AssetBundleOffsetWindows { get; }

		static ModHeader()
		{
			Default = new ModHeader(0L, 0L, 0L, 0L, 0L);
			_HeaderTagV1 = "SimplePlanes2".Replace(" ", string.Empty) + "ModHeaderV001";
			_HeaderTagV1Bytes = Encoding.ASCII.GetBytes(_HeaderTagV1);
			_HeaderTagV1Buffer = new byte[_HeaderTagV1Bytes.Length];
			_LongBuffer1 = new byte[8];
			_LongBuffer2 = new byte[8];
		}

		public ModHeader(long? windowsOffset, long? macOSOffset, long? linuxOffset, long? androidOffset, long? iOSOffset)
		{
			AssetBundleOffsetWindows = windowsOffset;
			AssetBundleOffsetMacOS = macOSOffset;
			AssetBundleOffsetLinux = linuxOffset;
			AssetBundleOffsetAndroid = androidOffset;
			AssetBundleOffsetIOS = iOSOffset;
		}

		public ModHeader(FileInfo windowsBundle, FileInfo macOSBundle, FileInfo linuxBundle, FileInfo androidBundle, FileInfo iOSBundle)
		{
			long num = _HeaderTagV1Bytes.Length + 40;
			AssetBundleOffsetWindows = ((windowsBundle == null) ? ((long?)null) : new long?(num));
			if (windowsBundle != null)
			{
				num += windowsBundle.Length;
			}
			AssetBundleOffsetMacOS = ((macOSBundle == null) ? ((long?)null) : new long?(num));
			if (macOSBundle != null)
			{
				num += macOSBundle.Length;
			}
			AssetBundleOffsetLinux = ((linuxBundle == null) ? ((long?)null) : new long?(num));
			if (linuxBundle != null)
			{
				num += linuxBundle.Length;
			}
			AssetBundleOffsetAndroid = ((androidBundle == null) ? ((long?)null) : new long?(num));
			if (androidBundle != null)
			{
				num += androidBundle.Length;
			}
			AssetBundleOffsetIOS = ((iOSBundle == null) ? ((long?)null) : new long?(num));
		}

		public static ModHeader Read(string filePath)
		{
			FileInfo fileInfo = new FileInfo(filePath);
			if (fileInfo.Length < _HeaderTagV1Bytes.Length)
			{
				return null;
			}
			using FileStream fileStream = File.OpenRead(fileInfo.FullName);
			if (fileStream.Read(_HeaderTagV1Buffer, 0, _HeaderTagV1Buffer.Length) != _HeaderTagV1Buffer.Length)
			{
				return null;
			}
			if (!_HeaderTagV1Buffer.SequenceEqual(_HeaderTagV1Bytes))
			{
				return null;
			}
			long? windowsOffset = ReadOffset(fileStream);
			long? macOSOffset = ReadOffset(fileStream);
			long? linuxOffset = ReadOffset(fileStream);
			long? androidOffset = ReadOffset(fileStream);
			long? iOSOffset = ReadOffset(fileStream);
			return new ModHeader(windowsOffset, macOSOffset, linuxOffset, androidOffset, iOSOffset);
		}

		public static ModHeader Read(byte[] assetBytes)
		{
			if (assetBytes.Length < _HeaderTagV1Bytes.Length)
			{
				return null;
			}
			Buffer.BlockCopy(assetBytes, 0, _HeaderTagV1Buffer, 0, _HeaderTagV1Buffer.Length);
			if (!_HeaderTagV1Buffer.SequenceEqual(_HeaderTagV1Bytes))
			{
				return null;
			}
			long? windowsOffset;
			long? macOSOffset;
			long? linuxOffset;
			long? androidOffset;
			long? iOSOffset;
			using (MemoryStream memoryStream = new MemoryStream(assetBytes))
			{
				memoryStream.Seek(_HeaderTagV1Buffer.Length, SeekOrigin.Begin);
				windowsOffset = ReadOffset(memoryStream);
				macOSOffset = ReadOffset(memoryStream);
				linuxOffset = ReadOffset(memoryStream);
				androidOffset = ReadOffset(memoryStream);
				iOSOffset = ReadOffset(memoryStream);
			}
			return new ModHeader(windowsOffset, macOSOffset, linuxOffset, androidOffset, iOSOffset);
		}

		public void Write(Stream stream)
		{
			stream.Write(_HeaderTagV1Bytes, 0, _HeaderTagV1Bytes.Length);
			WriteOffset(stream, AssetBundleOffsetWindows);
			WriteOffset(stream, AssetBundleOffsetMacOS);
			WriteOffset(stream, AssetBundleOffsetLinux);
			WriteOffset(stream, AssetBundleOffsetAndroid);
			WriteOffset(stream, AssetBundleOffsetIOS);
		}

		private static long? ReadOffset(Stream stream)
		{
			if (stream.Read(_LongBuffer1, 0, 8) != 8)
			{
				throw new InvalidOperationException("Unable to read the platform asset bundle offset value from the file stream while reading a mod header.");
			}
			byte[] value = _LongBuffer1;
			if (!BitConverter.IsLittleEndian)
			{
				_LongBuffer2[0] = _LongBuffer1[7];
				_LongBuffer2[1] = _LongBuffer1[6];
				_LongBuffer2[2] = _LongBuffer1[5];
				_LongBuffer2[3] = _LongBuffer1[4];
				_LongBuffer2[4] = _LongBuffer1[3];
				_LongBuffer2[5] = _LongBuffer1[2];
				_LongBuffer2[6] = _LongBuffer1[1];
				_LongBuffer2[7] = _LongBuffer1[0];
				value = _LongBuffer2;
			}
			long num = BitConverter.ToInt64(value, 0);
			if (num <= 0)
			{
				return null;
			}
			return num;
		}

		private static void WriteOffset(Stream stream, long? offset)
		{
			byte[] array = BitConverter.GetBytes((!offset.HasValue) ? (-1) : offset.Value);
			if (!BitConverter.IsLittleEndian)
			{
				_LongBuffer2[0] = array[7];
				_LongBuffer2[1] = array[6];
				_LongBuffer2[2] = array[5];
				_LongBuffer2[3] = array[4];
				_LongBuffer2[4] = array[3];
				_LongBuffer2[5] = array[2];
				_LongBuffer2[6] = array[1];
				_LongBuffer2[7] = array[0];
				array = _LongBuffer2;
			}
			stream.Write(array, 0, 8);
		}
	}
}
