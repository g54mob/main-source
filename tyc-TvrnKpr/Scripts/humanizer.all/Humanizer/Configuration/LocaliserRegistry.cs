using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Configuration
{
	public class LocaliserRegistry<TLocaliser> where TLocaliser : class
	{
		private readonly IDictionary<string, Func<CultureInfo, TLocaliser>> _localisers;

		private readonly Func<CultureInfo, TLocaliser> _defaultLocaliser;

		public LocaliserRegistry(TLocaliser defaultLocaliser)
		{
		}

		public LocaliserRegistry(Func<CultureInfo, TLocaliser> defaultLocaliser)
		{
		}

		public TLocaliser ResolveForUiCulture()
		{
			return null;
		}

		public TLocaliser ResolveForCulture(CultureInfo culture)
		{
			return null;
		}

		public void Register(string localeCode, TLocaliser localiser)
		{
		}

		public void Register(string localeCode, Func<CultureInfo, TLocaliser> localiser)
		{
		}

		private Func<CultureInfo, TLocaliser> FindLocaliser(CultureInfo culture)
		{
			return null;
		}
	}
}
