namespace FishNet.Serializing.Helping
{
	public class Comparers
	{
		public static bool EqualityCompare<T>(T a, T b)
		{
			return false;
		}

		public static bool IsDefault<T>(T t)
		{
			return false;
		}

		public static bool IsEqualityCompareDefault<T>(T a)
		{
			return false;
		}
	}
}
