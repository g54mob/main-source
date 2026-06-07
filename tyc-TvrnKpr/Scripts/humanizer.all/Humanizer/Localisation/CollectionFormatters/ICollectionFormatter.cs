using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.CollectionFormatters
{
	public interface ICollectionFormatter
	{
		string Humanize<T>(IEnumerable<T> collection);

		string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter);

		string Humanize<T>(IEnumerable<T> collection, Func<T, object> objectFormatter);

		string Humanize<T>(IEnumerable<T> collection, string separator);

		string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter, string separator);

		string Humanize<T>(IEnumerable<T> collection, Func<T, object> objectFormatter, string separator);
	}
}
