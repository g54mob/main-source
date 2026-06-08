namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class RealizableExtensions
	{
		public static IRealizable<T> RequireRealizable<T>(this IRealizableSource obj)
		{
			return obj.AsRealizable<T>() ?? throw Error.NotRealizable<T>();
		}
	}
}
