namespace VoxelBusters.EssentialKit
{
	public class MediaContentCaptureOptions
	{
		public MediaContentCaptureType CaptureType { get; private set; }

		public string Title { get; private set; }

		public string FileName { get; private set; }

		public MediaContentCaptureSource Source { get; set; }

		public MediaContentCaptureOptions(MediaContentCaptureType captureType, string title, string fileName, MediaContentCaptureSource source = MediaContentCaptureSource.Camera)
		{
		}

		public static MediaContentCaptureOptions CreateForImage()
		{
			return null;
		}

		public static MediaContentCaptureOptions CreateForVideo()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
