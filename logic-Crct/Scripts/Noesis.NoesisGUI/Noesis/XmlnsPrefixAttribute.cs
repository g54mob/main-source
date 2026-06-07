using System;

namespace Noesis
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public sealed class XmlnsPrefixAttribute : Attribute
	{
		private string _xmlNamespace;

		private string _prefix;

		public string XmlNamespace => null;

		public string Prefix => null;

		public XmlnsPrefixAttribute(string xmlNamespace, string prefix)
		{
		}
	}
}
