using System;
using UnityEngine;
using UnityEngine.Serialization;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class MediaServicesUnitySettings : SettingsPropertyGroup
	{
		[Header("Capture Media Content Settings")]
		[SerializeField]
		[FormerlySerializedAs("m_usesCamera")]
		[Tooltip("If enabled, permission required to access camera will be added for image capture.")]
		private bool m_usesCameraForImageCapture;

		[SerializeField]
		[Tooltip("If enabled, permission required to access camera will be added for video capture (video capture additionally needs microphone, we add it automatically once you enable this).")]
		private bool m_usesCameraForVideoCapture;

		[Space]
		[Header("Save Media Content Settings")]
		[SerializeField]
		[Tooltip("If enabled, permission required to save files in photo gallery will be added.")]
		private bool m_savesFilesToPhotoGallery;

		[SerializeField]
		[Tooltip("If enabled, permission required to create custom directories when saving will be added. For ex: permission to create new albums in photo gallery will be added.")]
		private bool m_savesFilesToCustomDirectories;

		public bool UsesCameraForImageCapture => false;

		public bool UsesCameraForVideoCapture => false;

		public bool SavesFilesToPhotoGallery => false;

		public bool SavesFilesToCustomDirectories => false;

		public MediaServicesUnitySettings(bool isEnabled = true, bool usesCameraForImageCapture = true, bool usesCameraForVideoCapture = false, bool savesFilesToGallery = true, bool savesFilesToCustomAlbums = true)
			: base(null, isEnabled: false)
		{
		}
	}
}
