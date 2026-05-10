using System.Globalization;

namespace CsvHelper.Configuration
{
	public class MapTypeConverterOption
	{
		private readonly MemberMap memberMap;

		public MapTypeConverterOption(MemberMap memberMap)
		{
		}

		public virtual MemberMap CultureInfo(CultureInfo cultureInfo)
		{
			return null;
		}

		public virtual MemberMap DateTimeStyles(DateTimeStyles dateTimeStyle)
		{
			return null;
		}

		public virtual MemberMap NumberStyles(NumberStyles numberStyle)
		{
			return null;
		}

		public virtual MemberMap Format(params string[] formats)
		{
			return null;
		}

		public virtual MemberMap BooleanValues(bool isTrue, bool clearValues = true, params string[] booleanValues)
		{
			return null;
		}

		public virtual MemberMap NullValues(params string[] nullValues)
		{
			return null;
		}

		public virtual MemberMap NullValues(bool clearValues, params string[] nullValues)
		{
			return null;
		}
	}
}
