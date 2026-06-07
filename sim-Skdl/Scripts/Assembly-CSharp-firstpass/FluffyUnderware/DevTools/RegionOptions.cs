namespace FluffyUnderware.DevTools
{
	public struct RegionOptions<T>
	{
		public string LabelFrom;

		public string LabelTo;

		public string OptionalTooltip;

		public DTValueClamping ClampFrom;

		public DTValueClamping ClampTo;

		public T FromMin;

		public T FromMax;

		public T ToMin;

		public T ToMax;

		public static RegionOptions<T> Default => default(RegionOptions<T>);

		public static RegionOptions<T> MinMax(T min, T max)
		{
			return default(RegionOptions<T>);
		}
	}
}
