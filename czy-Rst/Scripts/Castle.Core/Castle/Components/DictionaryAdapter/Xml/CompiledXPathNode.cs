using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class CompiledXPathNode
	{
		private string prefix;

		private string localName;

		private bool isAttribute;

		private XPathExpression value;

		private CompiledXPathNode next;

		private CompiledXPathNode previous;

		private IList<CompiledXPathNode> dependencies;

		private static readonly IList<CompiledXPathNode> NoDependencies = Array.AsReadOnly(new CompiledXPathNode[0]);

		public string Prefix
		{
			get
			{
				return prefix;
			}
			internal set
			{
				prefix = value;
			}
		}

		public string LocalName
		{
			get
			{
				return localName;
			}
			internal set
			{
				localName = value;
			}
		}

		public bool IsAttribute
		{
			get
			{
				return isAttribute;
			}
			internal set
			{
				isAttribute = value;
			}
		}

		public bool IsSelfReference => localName == null;

		public bool IsSimple
		{
			get
			{
				if (next == null)
				{
					return HasNoRealDependencies();
				}
				return false;
			}
		}

		public XPathExpression Value
		{
			get
			{
				return value ?? GetSelfReferenceValue();
			}
			internal set
			{
				this.value = value;
			}
		}

		public CompiledXPathNode NextNode
		{
			get
			{
				return next;
			}
			internal set
			{
				next = value;
			}
		}

		public CompiledXPathNode PreviousNode
		{
			get
			{
				return previous;
			}
			internal set
			{
				previous = value;
			}
		}

		public IList<CompiledXPathNode> Dependencies => dependencies ?? (dependencies = new List<CompiledXPathNode>());

		internal CompiledXPathNode()
		{
		}

		private bool HasNoRealDependencies()
		{
			if (dependencies != null && dependencies.Count != 0)
			{
				if (dependencies.Count == 1)
				{
					return dependencies[0].IsSelfReference;
				}
				return false;
			}
			return true;
		}

		private XPathExpression GetSelfReferenceValue()
		{
			if (dependencies == null || dependencies.Count != 1 || !dependencies[0].IsSelfReference)
			{
				return null;
			}
			return dependencies[0].value;
		}

		internal virtual void Prepare()
		{
			IList<CompiledXPathNode> list;
			if (dependencies == null)
			{
				list = NoDependencies;
			}
			else
			{
				IList<CompiledXPathNode> list2 = Array.AsReadOnly(dependencies.ToArray());
				list = list2;
			}
			dependencies = list;
			foreach (CompiledXPathNode dependency in dependencies)
			{
				dependency.Prepare();
			}
			if (next != null)
			{
				next.Prepare();
			}
		}

		internal virtual void SetContext(XsltContext context)
		{
			if (value != null)
			{
				value.SetContext(context);
			}
			foreach (CompiledXPathNode dependency in dependencies)
			{
				dependency.SetContext(context);
			}
			if (next != null)
			{
				next.SetContext(context);
			}
		}
	}
}
