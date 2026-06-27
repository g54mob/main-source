using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Formatting;

namespace FluentAssertions.Execution
{
	internal class ContextDataDictionary
	{
		public class DataItem
		{
			public string Key { get; }

			public object Value { get; }

			public bool Reportable { get; }

			public bool RequiresFormatting { get; }

			public DataItem(string key, object value, bool reportable, bool requiresFormatting)
			{
				Key = key;
				Value = value;
				Reportable = reportable;
				RequiresFormatting = requiresFormatting;
				base._002Ector();
			}

			public DataItem Clone()
			{
				object value = ((Value is ICloneable2 cloneable) ? cloneable.Clone() : Value);
				return new DataItem(Key, value, Reportable, RequiresFormatting);
			}
		}

		private readonly List<DataItem> items = new List<DataItem>();

		public IDictionary<string, object> GetReportable()
		{
			return items.Where((DataItem item) => item.Reportable).ToDictionary((DataItem item) => item.Key, (DataItem item) => item.Value);
		}

		public string AsStringOrDefault(string key)
		{
			DataItem dataItem = items.SingleOrDefault((DataItem i) => i.Key == key);
			if (dataItem != null)
			{
				if (dataItem.RequiresFormatting)
				{
					return Formatter.ToString(dataItem.Value);
				}
				return dataItem.Value.ToString();
			}
			return null;
		}

		public void Add(ContextDataDictionary contextDataDictionary)
		{
			foreach (DataItem item in contextDataDictionary.items)
			{
				Add(item.Clone());
			}
		}

		public void Add(DataItem item)
		{
			int num = items.FindIndex((DataItem i) => i.Key == item.Key);
			if (num >= 0)
			{
				items[num] = item;
			}
			else
			{
				items.Add(item);
			}
		}
	}
}
