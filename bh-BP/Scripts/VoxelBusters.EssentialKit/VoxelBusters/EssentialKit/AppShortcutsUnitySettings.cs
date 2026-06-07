using System;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class AppShortcutsUnitySettings : SettingsPropertyGroup
	{
		[SerializeField]
		[Tooltip("The texture used as small icon in post Android L Devices.")]
		private List<Texture2D> m_icons;

		public List<Texture2D> Icons
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AppShortcutsUnitySettings(bool isEnabled = true, List<Texture2D> icons = null)
			: base(null, isEnabled: false)
		{
		}
	}
}
