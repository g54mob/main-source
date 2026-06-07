using System;

namespace VoxelBusters.EssentialKit
{
	[Obsolete("This class is obsolete. Use SaveMediaContent instead.", true)]
	public class MediaServicesSaveImageToGalleryResult
	{
		public bool Success { get; private set; }

		internal MediaServicesSaveImageToGalleryResult(bool success)
		{
		}
	}
}
