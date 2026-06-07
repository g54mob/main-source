using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class LeaderboardDefinition
	{
		[Serializable]
		public class AndroidPlatformProperties
		{
		}

		[Serializable]
		public class IosPlatformProperties
		{
		}

		[SerializeField]
		private string m_id;

		[SerializeField]
		private string m_platformId;

		[SerializeField]
		private RuntimePlatformConstantSet m_platformIdOverrides;

		[SerializeField]
		private string m_title;

		[SerializeField]
		[HideInInspector]
		private IosPlatformProperties m_iosProperties;

		[SerializeField]
		[HideInInspector]
		private AndroidPlatformProperties m_androidProperties;

		public string Id => null;

		public string Title => null;

		public IosPlatformProperties IosProperties => null;

		public AndroidPlatformProperties AndroidProperties => null;

		public LeaderboardDefinition(string id = null, string platformId = null, RuntimePlatformConstantSet platformIdOverrides = null, string title = null, IosPlatformProperties iosProperties = null, AndroidPlatformProperties androidProperties = null)
		{
		}

		public string GetPlatformIdForActivePlatform()
		{
			return null;
		}
	}
}
