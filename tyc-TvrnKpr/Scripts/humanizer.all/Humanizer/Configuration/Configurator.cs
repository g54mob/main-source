using System;
using System.Globalization;
using System.Reflection;
using Humanizer.DateTimeHumanizeStrategy;
using Humanizer.Localisation.CollectionFormatters;
using Humanizer.Localisation.DateToOrdinalWords;
using Humanizer.Localisation.Formatters;
using Humanizer.Localisation.NumberToWords;
using Humanizer.Localisation.Ordinalizers;

namespace Humanizer.Configuration
{
	public static class Configurator
	{
		private static readonly LocaliserRegistry<ICollectionFormatter> _collectionFormatters;

		private static readonly LocaliserRegistry<IFormatter> _formatters;

		private static readonly LocaliserRegistry<INumberToWordsConverter> _numberToWordsConverters;

		private static readonly LocaliserRegistry<IOrdinalizer> _ordinalizers;

		private static readonly LocaliserRegistry<IDateToOrdinalWordConverter> _dateToOrdinalWordConverters;

		private static IDateTimeHumanizeStrategy _dateTimeHumanizeStrategy;

		private static IDateTimeOffsetHumanizeStrategy _dateTimeOffsetHumanizeStrategy;

		private static readonly Func<PropertyInfo, bool> DefaultEnumDescriptionPropertyLocator;

		private static Func<PropertyInfo, bool> _enumDescriptionPropertyLocator;

		public static LocaliserRegistry<ICollectionFormatter> CollectionFormatters => null;

		public static LocaliserRegistry<IFormatter> Formatters => null;

		public static LocaliserRegistry<INumberToWordsConverter> NumberToWordsConverters => null;

		public static LocaliserRegistry<IOrdinalizer> Ordinalizers => null;

		public static LocaliserRegistry<IDateToOrdinalWordConverter> DateToOrdinalWordsConverters => null;

		internal static ICollectionFormatter CollectionFormatter => null;

		internal static IOrdinalizer Ordinalizer => null;

		internal static IDateToOrdinalWordConverter DateToOrdinalWordsConverter => null;

		public static IDateTimeHumanizeStrategy DateTimeHumanizeStrategy
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static IDateTimeOffsetHumanizeStrategy DateTimeOffsetHumanizeStrategy
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static Func<PropertyInfo, bool> EnumDescriptionPropertyLocator
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal static IFormatter GetFormatter(CultureInfo culture)
		{
			return null;
		}

		internal static INumberToWordsConverter GetNumberToWordsConverter(CultureInfo culture)
		{
			return null;
		}
	}
}
