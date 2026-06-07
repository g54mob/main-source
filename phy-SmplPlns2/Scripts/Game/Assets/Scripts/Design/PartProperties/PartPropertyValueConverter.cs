using System;

namespace Assets.Scripts.Design.PartProperties
{
	public class PartPropertyValueConverter
	{
		public static PartPropertyValueConverter Default = new PartPropertyValueConverter((object x) => x, (object x) => x);

		public Func<object, object> ConvertFrom { get; }

		public Func<object, object> ConvertTo { get; }

		public PartPropertyValueConverter(Func<object, object> convertFrom, Func<object, object> convertTo)
		{
			ConvertFrom = convertFrom;
			ConvertTo = convertTo;
		}
	}
	public class PartPropertyValueConverter<TSource, TTarget> : PartPropertyValueConverter
	{
		public PartPropertyValueConverter(Func<TSource, TTarget> convertFrom, Func<TTarget, TSource> convertTo)
			: base((object x) => convertFrom((TSource)x), (object x) => convertTo((TTarget)x))
		{
		}
	}
}
