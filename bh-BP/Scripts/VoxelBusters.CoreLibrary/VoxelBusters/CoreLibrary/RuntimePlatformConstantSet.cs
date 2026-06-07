using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	[Serializable]
	public class RuntimePlatformConstantSet
	{
		[SerializeField]
		private string m_ios;

		[SerializeField]
		private string m_tvos;

		[SerializeField]
		private string m_android;

		public RuntimePlatformConstantSet(string ios = null, string tvos = null, string android = null)
		{
		}

		public string GetConstantForActivePlatform(string defaultValue = null)
		{
			return null;
		}

		public string GetConstantForActiveOrSimulationPlatform(string defaultValue = null)
		{
			return null;
		}

		public string GetConstantForPlatform(RuntimePlatform platform, string defaultValue = null)
		{
			return null;
		}
	}
}
