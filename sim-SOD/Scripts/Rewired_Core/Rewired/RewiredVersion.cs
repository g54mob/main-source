namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct RewiredVersion
	{
		public int version1;

		public int version2;

		public int version3;

		public int version4;

		public string unityVersion;

		public RewiredVersion(int version1, int version2, int version3, int version4, string unityVersion)
		{
			this.version1 = 0;
			this.version2 = 0;
			this.version3 = 0;
			this.version4 = 0;
			this.unityVersion = null;
		}

		public RewiredVersion(string versionString)
		{
			version1 = 0;
			version2 = 0;
			version3 = 0;
			version4 = 0;
			unityVersion = null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static bool operator ==(RewiredVersion a, RewiredVersion b)
		{
			return false;
		}

		public static bool operator !=(RewiredVersion a, RewiredVersion b)
		{
			return false;
		}

		public static bool operator >(RewiredVersion a, RewiredVersion b)
		{
			return false;
		}

		public static bool operator <(RewiredVersion a, RewiredVersion b)
		{
			return false;
		}
	}
}
