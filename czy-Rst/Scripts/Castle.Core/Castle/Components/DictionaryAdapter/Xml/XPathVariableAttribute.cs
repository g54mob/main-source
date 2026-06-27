using System;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Castle.Components.DictionaryAdapter.Xml
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = true)]
	public abstract class XPathVariableAttribute : Attribute, IXsltContextVariable
	{
		public abstract XmlName Name { get; }

		public abstract XPathResultType VariableType { get; }

		bool IXsltContextVariable.IsLocal => false;

		bool IXsltContextVariable.IsParam => false;

		public abstract object Evaluate(XsltContext context);
	}
}
