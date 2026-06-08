using System;
using System.Collections.Generic;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlNameComparer : IEqualityComparer<XmlName>
	{
		public static readonly XmlNameComparer Default = new XmlNameComparer(StringComparer.Ordinal);

		public static readonly XmlNameComparer IgnoreCase = new XmlNameComparer(StringComparer.OrdinalIgnoreCase);

		private readonly StringComparer comparer;

		private XmlNameComparer(StringComparer comparer)
		{
			this.comparer = comparer;
		}

		public int GetHashCode(XmlName name)
		{
			int num = ((name.LocalName != null) ? comparer.GetHashCode(name.LocalName) : 0);
			if (name.NamespaceUri != null)
			{
				num = ((num << 7) | (num >> 25)) ^ comparer.GetHashCode(name.NamespaceUri);
			}
			return num;
		}

		public bool Equals(XmlName x, XmlName y)
		{
			if (comparer.Equals(x.LocalName, y.LocalName))
			{
				return comparer.Equals(x.NamespaceUri, y.NamespaceUri);
			}
			return false;
		}
	}
}
