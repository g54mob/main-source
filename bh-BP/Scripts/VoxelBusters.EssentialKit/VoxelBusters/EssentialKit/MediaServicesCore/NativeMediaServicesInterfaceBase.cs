using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.MediaServicesCore
{
	public abstract class NativeMediaServicesInterfaceBase : NativeFeatureInterfaceBase, INativeMediaServicesInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		protected NativeMediaServicesInterfaceBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public abstract GalleryAccessStatus GetGalleryAccessStatus(GalleryAccessMode mode);

		public abstract CameraAccessStatus GetCameraAccessStatus();

		public abstract void SelectMediaContent(MediaContentSelectOptions options, SelectMediaContentInternalCallback callback);

		public abstract void CaptureMediaContent(MediaContentCaptureOptions options, CaptureMediaContentInternalCallback callback);

		public abstract void SaveMediaContent(byte[] data, string mimeType, MediaContentSaveOptions options, SaveMediaContentInternalCallback callback);
	}
}
