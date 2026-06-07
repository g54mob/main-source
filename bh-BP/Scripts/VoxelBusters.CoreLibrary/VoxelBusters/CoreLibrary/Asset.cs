using System;

namespace VoxelBusters.CoreLibrary
{
	[Serializable]
	public class Asset
	{
		public byte[] Data { get; private set; }

		public string MimeType { get; private set; }

		public string Name { get; private set; }

		public Asset(byte[] data, string mimeType, string name)
		{
		}

		public static Asset CreatePNGAsset(byte[] data, string name)
		{
			return null;
		}

		public static Asset CreateJPGAsset(byte[] data, string name)
		{
			return null;
		}

		public static Asset CreateMP4Asset(byte[] data, string name)
		{
			return null;
		}

		public static Asset CreatePDFAsset(byte[] data, string name)
		{
			return null;
		}

		public static Asset CreateTextAsset(byte[] data, string name)
		{
			return null;
		}
	}
}
