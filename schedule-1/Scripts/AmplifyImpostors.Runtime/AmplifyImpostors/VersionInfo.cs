using System;

namespace AmplifyImpostors
{
	[Serializable]
	public class VersionInfo
	{
		public const byte Major = 0;

		public const byte Minor = 9;

		public const byte Release = 9;

		public static byte Revision;

		public static int FullNumber => 0;

		public static string FullLabel => null;

		public static string StaticToString()
		{
			return null;
		}
	}
}
