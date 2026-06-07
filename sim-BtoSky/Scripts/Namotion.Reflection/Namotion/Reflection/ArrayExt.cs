namespace Namotion.Reflection
{
	internal static class ArrayExt
	{
		private static class EmptyHolder<T>
		{
			internal static readonly T[] _empty = new T[0];
		}

		public static T[] Empty<T>()
		{
			return EmptyHolder<T>._empty;
		}
	}
}
