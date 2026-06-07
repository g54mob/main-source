using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	[Serializable]
	[Obsolete("This class is deprecated. Instead use RuntimePlatformConstant.", true)]
	public class PlatformConstant
	{
		[SerializeField]
		private NativePlatform m_platform;

		[SerializeField]
		private string m_value;

		public NativePlatform Platform
		{
			get
			{
				return default(NativePlatform);
			}
			private set
			{
			}
		}

		public string Value
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public PlatformConstant(NativePlatform platform, string value)
		{
		}

		public static PlatformConstant iOS(string value)
		{
			return null;
		}

		public static PlatformConstant tvOS(string value)
		{
			return null;
		}

		public static PlatformConstant Android(string value)
		{
			return null;
		}

		public static PlatformConstant All(string value)
		{
			return null;
		}

		public static PlatformConstant Current(string value)
		{
			return null;
		}

		public bool IsEqualToPlatform(NativePlatform other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
