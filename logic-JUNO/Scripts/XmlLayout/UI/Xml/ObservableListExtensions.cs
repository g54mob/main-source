using System.Collections.Generic;

namespace UI.Xml
{
	public static class ObservableListExtensions
	{
		public static ObservableList<T> ToObservableList<T>(this IEnumerable<T> collection) where T : class
		{
			ObservableList<T> observableList = new ObservableList<T>();
			if (collection != null)
			{
				observableList.AddRange(collection);
			}
			return observableList;
		}
	}
}
