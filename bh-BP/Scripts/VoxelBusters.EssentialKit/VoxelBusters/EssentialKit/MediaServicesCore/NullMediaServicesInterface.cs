namespace VoxelBusters.EssentialKit.MediaServicesCore
{
	internal sealed class NullMediaServicesInterface : NativeMediaServicesInterfaceBase
	{
		public NullMediaServicesInterface()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public override GalleryAccessStatus GetGalleryAccessStatus(GalleryAccessMode mode)
		{
			return default(GalleryAccessStatus);
		}

		public override CameraAccessStatus GetCameraAccessStatus()
		{
			return default(CameraAccessStatus);
		}

		public override void SelectMediaContent(MediaContentSelectOptions options, SelectMediaContentInternalCallback callback)
		{
		}

		public override void CaptureMediaContent(MediaContentCaptureOptions options, CaptureMediaContentInternalCallback callback)
		{
		}

		public override void SaveMediaContent(byte[] data, string mimeType, MediaContentSaveOptions options, SaveMediaContentInternalCallback callback)
		{
		}
	}
}
