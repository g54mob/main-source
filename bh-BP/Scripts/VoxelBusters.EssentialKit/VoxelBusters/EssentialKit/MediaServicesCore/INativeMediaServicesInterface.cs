using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.MediaServicesCore
{
	public interface INativeMediaServicesInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		GalleryAccessStatus GetGalleryAccessStatus(GalleryAccessMode mode);

		CameraAccessStatus GetCameraAccessStatus();

		void SelectMediaContent(MediaContentSelectOptions options, SelectMediaContentInternalCallback callback);

		void CaptureMediaContent(MediaContentCaptureOptions options, CaptureMediaContentInternalCallback callback);

		void SaveMediaContent(byte[] data, string mimeType, MediaContentSaveOptions options, SaveMediaContentInternalCallback callback);
	}
}
