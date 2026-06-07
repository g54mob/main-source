using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jundroo.ModTools.Core
{
	public static class AssetHeaders
	{
		public static readonly byte[] AssemblyHeader = new byte[128]
		{
			72, 50, 210, 183, 136, 156, 218, 76, 148, 225,
			133, 206, 41, 37, 231, 56, 85, 34, 189, 42,
			255, 102, 89, 65, 144, 154, 44, 155, 116, 249,
			4, 176, 253, 60, 223, 206, 149, 88, 214, 65,
			180, 144, 141, 22, 148, 219, 204, 184, 199, 5,
			69, 174, 76, 35, 238, 77, 185, 3, 56, 74,
			142, 193, 9, 65, 166, 111, 44, 77, 95, 65,
			79, 71, 188, 40, 188, 74, 94, 34, 43, 127,
			122, 70, 159, 84, 29, 139, 76, 71, 173, 99,
			166, 201, 165, 205, 200, 157, 191, 124, 138, 64,
			69, 121, 186, 75, 145, 119, 219, 96, 77, 237,
			179, 167, 122, 86, 210, 234, 196, 136, 75, 74,
			189, 217, 66, 223, 138, 211, 169, 229
		};

		public static readonly byte[] ManifestHeader = new byte[128]
		{
			118, 247, 120, 50, 85, 159, 157, 68, 181, 185,
			75, 158, 230, 56, 246, 107, 159, 118, 60, 214,
			6, 86, 165, 69, 135, 207, 124, 206, 249, 15,
			253, 15, 70, 228, 70, 43, 78, 164, 237, 72,
			177, 183, 154, 98, 154, 234, 176, 172, 238, 251,
			170, 12, 46, 249, 1, 65, 190, 92, 255, 44,
			178, 129, 71, 99, 50, 82, 176, 68, 179, 188,
			186, 66, 149, 131, 163, 212, 77, 56, 54, 221,
			118, 189, 164, 96, 99, 146, 4, 75, 157, 172,
			177, 78, 114, 60, 237, 3, 146, 177, 242, 217,
			36, 137, 40, 69, 185, 202, 139, 70, 144, 226,
			249, 197, 71, 254, 35, 158, 91, 23, 220, 79,
			142, 82, 173, 166, 68, 150, 146, 13
		};

		public static byte[] ExtractAsset(byte[] assetBytes, byte[] headerBytes)
		{
			int num = headerBytes.Length + 4;
			if (assetBytes.Length < num)
			{
				throw new InvalidDataException("The asset header information is missing or invalid.");
			}
			byte[] array = new byte[headerBytes.Length];
			Buffer.BlockCopy(assetBytes, 0, array, 0, array.Length);
			if (!array.SequenceEqual(headerBytes))
			{
				throw new InvalidDataException("The asset header information is incorrect.");
			}
			byte[] array2 = new byte[4];
			Buffer.BlockCopy(assetBytes, headerBytes.Length, array2, 0, array2.Length);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(array2);
			}
			int num2 = BitConverter.ToInt32(array2, 0);
			if (num2 + num != assetBytes.Length)
			{
				throw new InvalidDataException("The asset length is incorrect.");
			}
			byte[] array3 = new byte[num2];
			Buffer.BlockCopy(assetBytes, num, array3, 0, array3.Length);
			return array3;
		}

		public static XDocument LoadManifest(byte[] bytes)
		{
			byte[] bytes2 = ExtractAsset(bytes, ManifestHeader);
			return XDocument.Parse(Encoding.UTF8.GetString(bytes2).Substring(1));
		}

		public static void SaveAsset(Stream stream, byte[] assetBytes, byte[] headerBytes)
		{
			stream.Write(headerBytes, 0, headerBytes.Length);
			byte[] bytes = BitConverter.GetBytes(assetBytes.Length);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			stream.Write(bytes, 0, bytes.Length);
			stream.Write(assetBytes, 0, assetBytes.Length);
		}

		public static byte[] SaveManifest(XDocument xml)
		{
			byte[] assetBytes = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				xml.Save((Stream)memoryStream);
				assetBytes = memoryStream.ToArray();
			}
			using MemoryStream memoryStream2 = new MemoryStream();
			SaveAsset(memoryStream2, assetBytes, ManifestHeader);
			return memoryStream2.ToArray();
		}
	}
}
