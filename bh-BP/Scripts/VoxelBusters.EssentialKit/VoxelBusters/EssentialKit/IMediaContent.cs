using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public interface IMediaContent
	{
		void AsTexture2D(EventCallback<Texture2D> onComplete);

		void AsRawMediaData(EventCallback<RawMediaData> onComplete);

		void AsFilePath(string destinationDirectory, string fileName, EventCallback<string> onComplete);
	}
}
