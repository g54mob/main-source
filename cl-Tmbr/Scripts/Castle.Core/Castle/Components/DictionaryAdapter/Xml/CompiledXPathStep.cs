using System.Xml.XPath;
using System.Xml.Xsl;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class CompiledXPathStep : CompiledXPathNode
	{
		private XPathExpression path;

		public XPathExpression Path
		{
			get
			{
				return path;
			}
			internal set
			{
				path = value;
			}
		}

		public CompiledXPathStep NextStep => (CompiledXPathStep)base.NextNode;

		internal CompiledXPathStep()
		{
		}

		internal override void SetContext(XsltContext context)
		{
			path.SetContext(context);
			base.SetContext(context);
		}
	}
}
