using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class AppUpdaterUnitySettings : SettingsPropertyGroup
	{
		[SerializeField]
		[Tooltip("The default text used for update prompt title, if displayed.")]
		private string m_defaultPromptTitle;

		[SerializeField]
		[Tooltip("The default text used for update prompt message, if displayed.")]
		private string m_defaultPromptMessage;

		public string DefaultPromptTitle => null;

		public string DefaultPromptMessage => null;

		public AppUpdaterUnitySettings(bool isEnabled = true, string defaultPromptTitle = null, string defaultPromptMessage = null)
			: base(null, isEnabled: false)
		{
		}
	}
}
