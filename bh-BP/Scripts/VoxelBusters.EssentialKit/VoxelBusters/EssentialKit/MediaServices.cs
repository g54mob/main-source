using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.MediaServicesCore;

namespace VoxelBusters.EssentialKit
{
	public static class MediaServices
	{
		[ClearOnReload]
		private static INativeMediaServicesInterface s_nativeInterface;

		public static MediaServicesUnitySettings UnitySettings { get; private set; }

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(MediaServicesUnitySettings settings)
		{
		}

		public static GalleryAccessStatus GetGalleryAccessStatus(GalleryAccessMode mode)
		{
			return default(GalleryAccessStatus);
		}

		public static CameraAccessStatus GetCameraAccessStatus()
		{
			return default(CameraAccessStatus);
		}

		public static void SelectMediaContent(MediaContentSelectOptions options, EventCallback<IMediaContent[]> callback)
		{
		}

		public static void CaptureMediaContent(MediaContentCaptureOptions options, EventCallback<IMediaContent> callback)
		{
		}

		public static void SaveMediaContent(byte[] data, string mimeType, MediaContentSaveOptions options, EventCallback<bool> callback)
		{
		}

		private static void SendSelectMediaContentResult(EventCallback<IMediaContent[]> callback, IMediaContent[] contents, Error error)
		{
		}

		private static void SendCaptureMediaContentResult(EventCallback<IMediaContent> callback, IMediaContent content, Error error)
		{
		}

		private static void SendSaveMediaContentResult(EventCallback<bool> callback, bool success, Error error)
		{
		}

		[Obsolete("Use SelectMediaContent instead. If a permission is required, SelectMediaContent shows up the permission dialog.", true)]
		private static void RequestGalleryAccess(GalleryAccessMode mode, bool showPrepermissionDialog = true, EventCallback<MediaServicesRequestGalleryAccessResult> callback = null)
		{
		}

		[Obsolete("Use CaptureMediaContent instead. If a permission is required, CaptureMediaContent shows up the permission dialog.", true)]
		private static void RequestCameraAccess(bool showPrepermissionDialog = true, EventCallback<MediaServicesRequestCameraAccessResult> callback = null)
		{
		}

		[Obsolete("Use GetGalleryAccessStatus instead.", true)]
		private static bool CanSelectImageFromGallery()
		{
			return false;
		}

		[Obsolete("Use SelectMediaContent instead.", true)]
		private static void SelectImageFromGallery(bool canEdit, EventCallback<TextureData> callback)
		{
		}

		[Obsolete("Use GetCameraAccessStatus instead.", true)]
		private static bool CanCaptureImageFromCamera()
		{
			return false;
		}

		[Obsolete("Use CaptureMediaContent instead.", true)]
		public static void CaptureImageFromCamera(bool canEdit, EventCallback<TextureData> callback)
		{
		}

		[Obsolete("This method is obsolete. Use SaveMediaContent instead.", true)]
		private static bool CanSaveImageToGallery()
		{
			return false;
		}

		[Obsolete("This method is obsolete. Use SaveMediaContent instead.", true)]
		public static void SaveImageToGallery(Texture2D image, EventCallback<MediaServicesSaveImageToGalleryResult> callback)
		{
		}

		[Obsolete("This method is obsolete. Use SaveMediaContent instead.", true)]
		public static void SaveImageToGallery(string albumName, Texture2D image, EventCallback<MediaServicesSaveImageToGalleryResult> callback)
		{
		}
	}
}
