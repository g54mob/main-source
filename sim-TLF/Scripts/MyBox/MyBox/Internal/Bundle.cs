using System.Collections.Generic;

namespace MyBox.Internal
{
	internal class Bundle<T>
	{
		private Dictionary<string, T> bundleData;

		internal Bundle()
		{
			bundleData = new Dictionary<string, T>();
		}

		internal void AddData(string dataKey, T data, bool overrideIfExists = true)
		{
			bool flag = bundleData.ContainsKey(dataKey);
			if (flag && overrideIfExists)
			{
				bundleData[dataKey] = data;
			}
			else if (!flag)
			{
				bundleData.Add(dataKey, data);
			}
		}

		internal void AddData(KeyValuePair<string, T> keyValuePair, bool overrideIfExists = true)
		{
			bool flag = bundleData.ContainsKey(keyValuePair.Key);
			if (flag && overrideIfExists)
			{
				bundleData[keyValuePair.Key] = keyValuePair.Value;
			}
			else if (!flag)
			{
				bundleData.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}

		internal bool TryGetData(string dataKey, out T result)
		{
			return bundleData.TryGetValue(dataKey, out result);
		}

		internal bool DataExists(string dataKey)
		{
			return bundleData.ContainsKey(dataKey);
		}

		internal Dictionary<string, T> GetBundleData()
		{
			return new Dictionary<string, T>(new Dictionary<string, T>(bundleData));
		}

		internal void AddBundleData(Dictionary<string, T> bundle, bool overrideIfExists)
		{
			foreach (KeyValuePair<string, T> item in bundle)
			{
				AddData(item, overrideIfExists);
			}
		}

		internal void AddBundleData(Bundle<T> bundle, bool overrideIfExists)
		{
			AddBundleData(bundle.bundleData, overrideIfExists);
		}
	}
}
