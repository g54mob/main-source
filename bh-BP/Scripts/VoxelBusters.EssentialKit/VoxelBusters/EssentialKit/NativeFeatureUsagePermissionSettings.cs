using System;
using UnityEngine;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class NativeFeatureUsagePermissionSettings
	{
		[SerializeField]
		[Tooltip("Usage description displayed prior to accessing address book.")]
		private NativeFeatureUsagePermissionDefinition m_addressBookUsagePermission;

		[SerializeField]
		[Tooltip("Usage description displayed prior to accessing camera.")]
		private NativeFeatureUsagePermissionDefinition m_cameraUsagePermission;

		[SerializeField]
		[Tooltip("Usage description displayed prior to accessing gallery.")]
		private NativeFeatureUsagePermissionDefinition m_galleryUsagePermission;

		[SerializeField]
		[Tooltip("Usage description displayed prior to saving files to gallery.")]
		private NativeFeatureUsagePermissionDefinition m_galleryWritePermission;

		[SerializeField]
		[Tooltip("Usage description displayed prior to accessing location information.")]
		private NativeFeatureUsagePermissionDefinition m_locationWhenInUsePermission;

		[SerializeField]
		[Tooltip("Usage description displayed prior to loading friends.")]
		private NativeFeatureUsagePermissionDefinition m_accessFriendsPermission;

		public NativeFeatureUsagePermissionDefinition AddressBookUsagePermission => null;

		public NativeFeatureUsagePermissionDefinition CameraUsagePermission => null;

		public NativeFeatureUsagePermissionDefinition GalleryUsagePermission => null;

		public NativeFeatureUsagePermissionDefinition GalleryWritePermission => null;

		public NativeFeatureUsagePermissionDefinition LocationWhenInUsePermission => null;

		public NativeFeatureUsagePermissionDefinition AccessFriendsPermission => null;

		public NativeFeatureUsagePermissionSettings(NativeFeatureUsagePermissionDefinition addressBookUsagePermission = null, NativeFeatureUsagePermissionDefinition cameraUsagePermission = null, NativeFeatureUsagePermissionDefinition galleryUsagePermission = null, NativeFeatureUsagePermissionDefinition galleryWritePermission = null, NativeFeatureUsagePermissionDefinition locationWhenInUsePermission = null, NativeFeatureUsagePermissionDefinition accessFriendsPermission = null)
		{
		}
	}
}
