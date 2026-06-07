using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	[Serializable]
	public class RuntimePlatformConstant
	{
		[SerializeField]
		private RuntimePlatform m_platform;

		[SerializeField]
		private string m_value;

		public RuntimePlatform Platform => default(RuntimePlatform);

		public string Value => null;

		public RuntimePlatformConstant(RuntimePlatform platform, string value)
		{
		}

		public static RuntimePlatformConstant iOS(string value)
		{
			return null;
		}

		public static RuntimePlatformConstant tvOS(string value)
		{
			return null;
		}

		public static RuntimePlatformConstant Android(string value)
		{
			return null;
		}

		public static RuntimePlatformConstant Current(string value)
		{
			return null;
		}

		public bool IsEqualToPlatform(RuntimePlatform other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
