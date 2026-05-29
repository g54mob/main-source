using System.Collections.Generic;

namespace MyBox.Internal
{
	internal class Bundle<T>
	{
		private Dictionary<string, T> bundleData;

		internal Bundle()
		{
		}

		internal void AddData(string dataKey, T data, bool overrideIfExists = true)
		{
		}

		internal void AddData(KeyValuePair<string, T> keyValuePair, bool overrideIfExists = true)
		{
		}

		internal bool TryGetData(string dataKey, out T result)
		{
			result = default(T);
			return false;
		}

		internal bool DataExists(string dataKey)
		{
			return false;
		}

		internal Dictionary<string, T> GetBundleData()
		{
			return null;
		}

		internal void AddBundleData(Dictionary<string, T> bundle, bool overrideIfExists)
		{
		}

		internal void AddBundleData(Bundle<T> bundle, bool overrideIfExists)
		{
		}
	}
}
