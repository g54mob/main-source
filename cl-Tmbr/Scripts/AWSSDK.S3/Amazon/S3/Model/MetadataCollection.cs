using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Amazon.S3.Model.Internal.MarshallTransformations;

namespace Amazon.S3.Model
{
	public sealed class MetadataCollection
	{
		internal const string MetaDataHeaderPrefix = "x-amz-meta-";

		private IDictionary<string, string> values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		public string this[string name]
		{
			get
			{
				if (!name.StartsWith("x-amz-meta-", StringComparison.OrdinalIgnoreCase))
				{
					name = "x-amz-meta-" + name;
				}
				if (values.TryGetValue(name, out var value))
				{
					return value;
				}
				return null;
			}
			set
			{
				if (!name.StartsWith("x-amz-meta-", StringComparison.OrdinalIgnoreCase))
				{
					name = "x-amz-meta-" + name;
				}
				values[name] = value;
			}
		}

		public int Count => values.Count;

		public ICollection<string> Keys => values.Keys;

		public void Add(string name, string value)
		{
			this[name] = value;
		}

		public void Clear()
		{
			foreach (string item in values.Keys.ToList())
			{
				if (item.StartsWith("x-amz-meta-", StringComparison.OrdinalIgnoreCase))
				{
					values.Remove(item);
				}
			}
		}

		internal void Marshall(string memberName, XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(memberName);
			foreach (KeyValuePair<string, string> value2 in values)
			{
				xmlWriter.WriteStartElement("MetadataEntry");
				string value = value2.Key.Replace("x-amz-meta-", "");
				xmlWriter.WriteElementString("Name", S3Transforms.ToXmlStringValue(value));
				xmlWriter.WriteElementString("Value", S3Transforms.ToXmlStringValue(value2.Value));
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
		}
	}
}
