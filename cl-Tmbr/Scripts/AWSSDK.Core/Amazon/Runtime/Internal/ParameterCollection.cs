using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Amazon.Runtime.Internal
{
	public class ParameterCollection : SortedDictionary<string, ParameterValue>
	{
		public ParameterCollection()
			: base((IComparer<string>)StringComparer.Ordinal)
		{
		}

		public void Add(string key, string value)
		{
			Add(key, new StringParameterValue(value));
		}

		public void Add(string key, List<string> values)
		{
			Add(key, new StringListParameterValue(values));
		}

		public void Add(string key, List<double> values)
		{
			Add(key, new DoubleListParameterValue(values));
		}

		public List<KeyValuePair<string, string>> GetSortedParametersList()
		{
			return GetParametersEnumerable().ToList();
		}

		internal IEnumerable<KeyValuePair<string, string>> GetParametersEnumerable()
		{
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, ParameterValue> current = enumerator.Current;
				string name = current.Key;
				ParameterValue value = current.Value;
				if (!(value is StringParameterValue stringParameterValue))
				{
					if (!(value is StringListParameterValue { Value: var value2 }))
					{
						if (value is DoubleListParameterValue { Value: var value3 })
						{
							value3.Sort();
							foreach (double item in value3)
							{
								yield return new KeyValuePair<string, string>(name, item.ToString(CultureInfo.InvariantCulture));
							}
							continue;
						}
						throw new AmazonClientException("Unsupported parameter value type '" + value.GetType().FullName + "'");
					}
					value2.Sort(StringComparer.Ordinal);
					foreach (string item2 in value2)
					{
						yield return new KeyValuePair<string, string>(name, item2);
					}
				}
				else
				{
					yield return new KeyValuePair<string, string>(name, stringParameterValue.Value);
				}
			}
		}
	}
}
