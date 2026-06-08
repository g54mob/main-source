using System;
using System.Collections.Specialized;
using System.Linq;

namespace Castle.Components.DictionaryAdapter
{
	public class NameValueCollectionAdapter : AbstractDictionaryAdapter
	{
		private readonly NameValueCollection nameValues;

		public override bool IsReadOnly => false;

		public override object this[object key]
		{
			get
			{
				return nameValues[key.ToString()];
			}
			set
			{
				string value2 = value?.ToString();
				nameValues[key.ToString()] = value2;
			}
		}

		public NameValueCollectionAdapter(NameValueCollection nameValues)
		{
			this.nameValues = nameValues;
		}

		public override bool Contains(object key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (this[key] != null)
			{
				return true;
			}
			return nameValues.AllKeys.Contains(key.ToString(), StringComparer.OrdinalIgnoreCase);
		}

		public static NameValueCollectionAdapter Adapt(NameValueCollection nameValues)
		{
			return new NameValueCollectionAdapter(nameValues);
		}
	}
}
