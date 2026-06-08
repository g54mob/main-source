using System;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Castle.Components.DictionaryAdapter.Xml
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = true)]
	public abstract class XPathFunctionAttribute : Attribute, IXsltContextFunction
	{
		public static readonly XPathResultType[] NoArgs = new XPathResultType[0];

		public abstract XmlName Name { get; }

		public abstract XPathResultType ReturnType { get; }

		public virtual XPathResultType[] ArgTypes => NoArgs;

		public virtual int Maxargs => ArgTypes.Length;

		public virtual int Minargs => ArgTypes.Length;

		public abstract object Invoke(XsltContext context, object[] args, XPathNavigator node);
	}
}
