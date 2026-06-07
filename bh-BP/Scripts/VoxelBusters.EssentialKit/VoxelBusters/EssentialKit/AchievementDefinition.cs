using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class AchievementDefinition
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
		private int m_numOfStepsToUnlock;

		[SerializeField]
		[HideInInspector]
		private IosPlatformProperties m_iosProperties;

		[SerializeField]
		[HideInInspector]
		private AndroidPlatformProperties m_androidProperties;

		public string Id => null;

		public string Title => null;

		public int NumOfStepsToUnlock => 0;

		public IosPlatformProperties IosProperties => null;

		public AndroidPlatformProperties AndroidProperties => null;

		public AchievementDefinition(string id = null, string platformId = null, RuntimePlatformConstantSet platformIdOverrides = null, string title = null, int numOfStepsToUnlock = 1, IosPlatformProperties iosProperties = null, AndroidPlatformProperties androidProperties = null)
		{
		}

		public string GetPlatformIdForActivePlatform()
		{
			return null;
		}
	}
}
