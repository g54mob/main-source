using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public struct XmlName : IEquatable<XmlName>
	{
		public static readonly XmlName Empty;

		private readonly string localName;

		private readonly string namespaceUri;

		public string LocalName => localName;

		public string NamespaceUri => namespaceUri;

		public XmlName(string localName, string namespaceUri)
		{
			this.localName = localName;
			this.namespaceUri = namespaceUri;
		}

		public override int GetHashCode()
		{
			return XmlNameComparer.Default.GetHashCode(this);
		}

		public bool Equals(XmlName other)
		{
			return XmlNameComparer.Default.Equals(this, other);
		}

		public override bool Equals(object obj)
		{
			if (obj is XmlName)
			{
				return Equals((XmlName)obj);
			}
			return false;
		}

		public static bool operator ==(XmlName x, XmlName y)
		{
			return XmlNameComparer.Default.Equals(x, y);
		}

		public static bool operator !=(XmlName x, XmlName y)
		{
			return !XmlNameComparer.Default.Equals(x, y);
		}

		public XmlName WithNamespaceUri(string namespaceUri)
		{
			return new XmlName(localName, namespaceUri);
		}

		public override string ToString()
		{
			if (string.IsNullOrEmpty(localName))
			{
				return string.Empty;
			}
			if (string.IsNullOrEmpty(namespaceUri))
			{
				return localName;
			}
			return namespaceUri + ":" + localName;
		}

		public static XmlName ParseQName(string text)
		{
			if (text == null)
			{
				throw Error.ArgumentNull("text");
			}
			int num = text.IndexOf(':');
			switch (num)
			{
			case -1:
				return new XmlName(text, null);
			case 0:
				return new XmlName(text.Substring(1), null);
			default:
				if (num == text.Length)
				{
					return new XmlName(text.Substring(0, num), null);
				}
				return new XmlName(text.Substring(num + 1), text.Substring(0, num));
			}
		}
	}
}
