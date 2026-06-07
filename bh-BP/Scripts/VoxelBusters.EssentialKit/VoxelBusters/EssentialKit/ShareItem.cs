using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class ShareItem
	{
		public enum ShareItemType
		{
			None = 0,
			Text = 1,
			URL = 2,
			ImageData = 3,
			FileData = 4,
			Screenshot = 5
		}

		private static readonly ShareItem kInvalidItem;

		private ShareItemType m_itemType;

		private string m_text;

		private URLString? m_url;

		private byte[] m_rawData;

		private string m_imagePath;

		private string m_mimeType;

		private string m_fileName;

		public ShareItemType ItemType => default(ShareItemType);

		public static ShareItem Text(string text)
		{
			return null;
		}

		public static ShareItem URL(URLString url)
		{
			return null;
		}

		public static ShareItem Image(Texture2D image, TextureEncodingFormat textureEncodingFormat, string fileName)
		{
			return null;
		}

		public static ShareItem File(byte[] data, string mimeType, string fileName)
		{
			return null;
		}

		public static ShareItem Screenshot()
		{
			return null;
		}

		public string GetText()
		{
			return null;
		}

		public URLString? GetURL()
		{
			return null;
		}

		public byte[] GetFileData(out string mimeType, out string fileName)
		{
			mimeType = null;
			fileName = null;
			return null;
		}
	}
}
