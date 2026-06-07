using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	[Serializable]
	[Obsolete("This class is deprecated. Instead use RuntimePlatformConstantSet.", true)]
	public class NativePlatformConstantSet
	{
		[SerializeField]
		private string m_ios;

		[SerializeField]
		private string m_tvos;

		[SerializeField]
		private string m_android;

		public NativePlatformConstantSet(string ios = null, string tvos = null, string android = null)
		{
		}

		public string GetConstantForActivePlatform(string defaultValue = null)
		{
			return null;
		}

		public string GetConstantForPlatform(NativePlatform platform, string defaultValue = null)
		{
			return null;
		}
	}
}
