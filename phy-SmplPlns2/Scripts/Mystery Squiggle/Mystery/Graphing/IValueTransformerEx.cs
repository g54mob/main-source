namespace Mystery.Graphing
{
	public static class IValueTransformerEx
	{
		public static string GetMinString(this IValueTransformer transformer, IValueRange range)
		{
			return transformer.ToString(range.Min);
		}

		public static string GetMidString(this IValueTransformer transformer, object min, object max)
		{
			return transformer.ToString(transformer.GetMid(min, max));
		}

		public static string GetMidString(this IValueTransformer transformer, IValueRange range)
		{
			return transformer.GetMidString(range.Min, range.Max);
		}

		public static string GetMaxString(this IValueTransformer transformer, IValueRange range)
		{
			return transformer.ToString(range.Max);
		}
	}
}
