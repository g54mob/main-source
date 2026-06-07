using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class AddressBookUnitySettings : SettingsPropertyGroup
	{
		[SerializeField]
		[Tooltip("The default image to be used for contact.")]
		private Texture2D m_defaultImage;

		public Texture2D DefaultImage => null;

		public AddressBookUnitySettings(bool isEnabled = true)
			: base(null, isEnabled: false)
		{
		}
	}
}
