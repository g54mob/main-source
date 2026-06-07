namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal struct RewiredVersion
	{
		public int version1;

		public int version2;

		public int version3;

		public int version4;

		public string unityVersion;

		public RewiredVersion(int P_0, int P_1, int P_2, int P_3, string P_4)
		{
			version1 = 0;
			version2 = 0;
			version3 = 0;
			version4 = 0;
			unityVersion = null;
		}

		public RewiredVersion(string P_0)
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
