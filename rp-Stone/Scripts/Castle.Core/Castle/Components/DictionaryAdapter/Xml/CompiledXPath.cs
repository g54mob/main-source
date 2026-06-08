using System.Xml.XPath;
using System.Xml.Xsl;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class CompiledXPath
	{
		private XPathExpression path;

		private CompiledXPathStep firstStep;

		private int depth;

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

		public CompiledXPathStep FirstStep
		{
			get
			{
				return firstStep;
			}
			internal set
			{
				firstStep = value;
			}
		}

		public CompiledXPathStep LastStep
		{
			get
			{
				CompiledXPathStep compiledXPathStep = null;
				for (CompiledXPathStep nextStep = firstStep; nextStep != null; nextStep = compiledXPathStep.NextStep)
				{
					compiledXPathStep = nextStep;
				}
				return compiledXPathStep;
			}
		}

		public int Depth
		{
			get
			{
				return depth;
			}
			internal set
			{
				depth = value;
			}
		}

		public bool IsCreatable => firstStep != null;

		internal CompiledXPath()
		{
		}

		internal void MakeNotCreatable()
		{
			firstStep = null;
			depth = 0;
		}

		internal void Prepare()
		{
			if (firstStep != null)
			{
				firstStep.Prepare();
			}
		}

		public void SetContext(XsltContext context)
		{
			path.SetContext(context);
			if (firstStep != null)
			{
				firstStep.SetContext(context);
			}
		}
	}
}
