using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = true)]
	public class XmlNamespaceAttribute : Attribute
	{
		public bool Root { get; set; }

		public bool Default { get; set; }

		public string NamespaceUri { get; private set; }

		public string Prefix { get; private set; }

		public XmlNamespaceAttribute(string namespaceUri, string prefix)
		{
			NamespaceUri = namespaceUri;
			Prefix = prefix;
		}
	}
}
