using System;
using UnityEngine;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class AdditionalPlatformSupportSettings
	{
		[SerializeField]
		private bool m_supportAndroidPc;

		public bool SupportAndroidPc => false;

		public AdditionalPlatformSupportSettings(bool supportAndroidPc = false)
		{
		}
	}
}
