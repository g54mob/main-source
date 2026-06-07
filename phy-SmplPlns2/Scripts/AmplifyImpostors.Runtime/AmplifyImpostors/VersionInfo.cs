using System;

namespace AmplifyImpostors
{
	[Serializable]
	public class VersionInfo
	{
		public const byte Major = 1;

		public const byte Minor = 0;

		public const byte Release = 0;

		public static byte Revision;

		public static int FullNumber => 10000 + Revision;

		public static string FullLabel => "Version=" + FullNumber;

		public static string StaticToString()
		{
			return $"{(byte)1}.{(byte)0}.{(byte)0}" + ((Revision > 0) ? ("." + Revision) : "");
		}
	}
}
