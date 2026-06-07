namespace WaveHarmonic.Crest.Utility
{
	internal static class Hash
	{
		public static int CreateHash()
		{
			return 423118183;
		}

		public static void AddFloat(float value, ref int hash)
		{
			hash ^= value.GetHashCode();
		}

		public static void AddInt(int value, ref int hash)
		{
			hash ^= value;
		}

		public static void AddBool(bool value, ref int hash)
		{
			hash ^= (value ? 1952813940 : 1650757685);
		}

		public static void AddObject(object value, ref int hash)
		{
			hash ^= value.GetHashCode();
		}

		public static void AddObject<T>(T value, ref int hash) where T : struct
		{
			hash ^= value.GetHashCode();
		}
	}
}
