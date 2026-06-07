namespace System.Collections.Generic
{
	public static class ListExtensions
	{
		public static object Clone<T>(this List<T> obj)
		{
			if (typeof(T).IsValueType)
			{
				return new List<T>(obj);
			}
			List<T> copy = new List<T>(obj.Count);
			obj.ForEach(delegate(T x)
			{
				copy.Add((T)((ICloneable)(object)x).Clone());
			});
			return copy;
		}
	}
}
