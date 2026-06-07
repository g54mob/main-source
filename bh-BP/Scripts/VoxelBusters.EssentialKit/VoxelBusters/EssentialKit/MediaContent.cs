using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class MediaContent : IMediaContent
	{
		protected byte[] Data { get; set; }

		protected string Mime { get; set; }

		public virtual void AsTexture2D(EventCallback<Texture2D> onComplete)
		{
		}

		public void AsRawMediaData(EventCallback<RawMediaData> onComplete)
		{
		}

		public virtual void AsFilePath(string destinationDirectory, string fileName, EventCallback<string> onComplete)
		{
		}

		public static MediaContent From(byte[] data, string mime)
		{
			return null;
		}

		public static MediaContent From(Texture2D texture)
		{
			return null;
		}
	}
}
