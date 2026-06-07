using System.Globalization;

namespace Humanizer.Localisation.Formatters
{
	public class DefaultFormatter : IFormatter
	{
		private readonly CultureInfo _culture;

		public DefaultFormatter(string localeCode)
		{
		}

		public virtual string DateHumanize_Now()
		{
			return null;
		}

		public virtual string DateHumanize_Never()
		{
			return null;
		}

		public virtual string DateHumanize(TimeUnit timeUnit, Tense timeUnitTense, int unit)
		{
			return null;
		}

		public virtual string TimeSpanHumanize_Zero()
		{
			return null;
		}

		public virtual string TimeSpanHumanize(TimeUnit timeUnit, int unit, bool toWords = false)
		{
			return null;
		}

		public virtual string DataUnitHumanize(DataUnit dataUnit, double count, bool toSymbol = true)
		{
			return null;
		}

		public virtual string TimeUnitHumanize(TimeUnit timeUnit)
		{
			return null;
		}

		private string GetResourceForDate(TimeUnit unit, Tense timeUnitTense, int count)
		{
			return null;
		}

		private string GetResourceForTimeSpan(TimeUnit unit, int count, bool toWords = false)
		{
			return null;
		}

		protected virtual string Format(string resourceKey)
		{
			return null;
		}

		protected virtual string Format(string resourceKey, int number, bool toWords = false)
		{
			return null;
		}

		protected virtual string GetResourceKey(string resourceKey, int number)
		{
			return null;
		}

		protected virtual string GetResourceKey(string resourceKey)
		{
			return null;
		}
	}
}
