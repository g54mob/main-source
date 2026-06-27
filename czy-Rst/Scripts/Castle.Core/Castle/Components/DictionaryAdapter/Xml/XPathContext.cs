using System.Xml.XPath;
using System.Xml.Xsl;

namespace Castle.Components.DictionaryAdapter.Xml
{
	internal class XPathContext : XsltContext
	{
		private readonly XsltContext context;

		public override string DefaultNamespace => string.Empty;

		public override bool Whitespace => context.Whitespace;

		public XPathContext(XsltContext xpathContext)
		{
			context = xpathContext;
		}

		public override string LookupNamespace(string prefix)
		{
			if (!string.IsNullOrEmpty(prefix))
			{
				return context.LookupNamespace(prefix);
			}
			return string.Empty;
		}

		public override bool PreserveWhitespace(XPathNavigator node)
		{
			return context.PreserveWhitespace(node);
		}

		public override int CompareDocument(string baseUri, string nextbaseUri)
		{
			return context.CompareDocument(baseUri, nextbaseUri);
		}

		public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] argTypes)
		{
			return context.ResolveFunction(prefix, name, argTypes);
		}

		public override IXsltContextVariable ResolveVariable(string prefix, string name)
		{
			return context.ResolveVariable(prefix, name);
		}
	}
}
