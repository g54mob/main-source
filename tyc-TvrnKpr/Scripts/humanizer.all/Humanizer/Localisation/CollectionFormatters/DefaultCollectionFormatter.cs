using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.CollectionFormatters
{
	internal class DefaultCollectionFormatter : ICollectionFormatter
	{
		protected string DefaultSeparator;

		public DefaultCollectionFormatter(string defaultSeparator)
		{
		}

		public virtual string Humanize<T>(IEnumerable<T> collection)
		{
			return null;
		}

		public virtual string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter)
		{
			return null;
		}

		public string Humanize<T>(IEnumerable<T> collection, Func<T, object> objectFormatter)
		{
			return null;
		}

		public virtual string Humanize<T>(IEnumerable<T> collection, string separator)
		{
			return null;
		}

		public virtual string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter, string separator)
		{
			return null;
		}

		public string Humanize<T>(IEnumerable<T> collection, Func<T, object> objectFormatter, string separator)
		{
			return null;
		}

		private string HumanizeDisplayStrings(IEnumerable<string> strings, string separator)
		{
			return null;
		}

		protected virtual string GetConjunctionFormatString(int itemCount)
		{
			return null;
		}
	}
}
