using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	[Serializable]
	public class NativeFeatureUsagePermissionDefinition
	{
		[SerializeField]
		private string m_description;

		[SerializeField]
		private RuntimePlatformConstantSet m_descriptionOverrides;

		public NativeFeatureUsagePermissionDefinition(string description = null, RuntimePlatformConstantSet descriptionOverrides = null)
		{
		}

		public string GetDescriptionForActivePlatform()
		{
			return null;
		}

		public string GetDescription(RuntimePlatform platform)
		{
			return null;
		}

		private string FormatDescription(string description, RuntimePlatform targetPlatform)
		{
			return null;
		}
	}
}
