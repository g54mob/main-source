using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlContextBase : XsltContext, IXmlNamespaceSource
	{
		private readonly XmlContextBase parent;

		private Dictionary<string, string> rootNamespaces;

		private bool hasNamespaces;

		private XPathContext xPathContext;

		private Dictionary<XmlName, IXsltContextVariable> variables;

		private Dictionary<XmlName, IXsltContextFunction> functions;

		private XPathContext XPathContext => xPathContext ?? (xPathContext = new XPathContext(this));

		public override bool Whitespace => true;

		public XmlContextBase()
			: base(new NameTable())
		{
			AddNamespace(Xsd.Namespace);
			AddNamespace(Xsi.Namespace);
			AddNamespace(Wsdl.Namespace);
			AddNamespace(XRef.Namespace);
		}

		protected XmlContextBase(XmlContextBase parent)
			: base(GetNameTable(parent))
		{
			this.parent = parent;
		}

		private static NameTable GetNameTable(XmlContextBase parent)
		{
			return (parent.NameTable as NameTable) ?? new NameTable();
		}

		public void AddNamespace(XmlNamespaceAttribute attribute)
		{
			string prefix = attribute.Prefix;
			string namespaceUri = attribute.NamespaceUri;
			if (string.IsNullOrEmpty(namespaceUri))
			{
				throw Error.InvalidNamespaceUri();
			}
			if (attribute.Default)
			{
				AddNamespace(string.Empty, namespaceUri);
			}
			if (!string.IsNullOrEmpty(prefix))
			{
				AddNamespace(prefix, namespaceUri);
				if (attribute.Root)
				{
					EnsureRootNamespaces().Add(prefix, namespaceUri);
				}
			}
		}

		public override void AddNamespace(string prefix, string uri)
		{
			base.AddNamespace(prefix, uri);
			hasNamespaces = true;
		}

		private Dictionary<string, string> EnsureRootNamespaces()
		{
			return rootNamespaces ?? (rootNamespaces = ((parent != null) ? new Dictionary<string, string>(parent.EnsureRootNamespaces()) : new Dictionary<string, string>()));
		}

		public override string LookupNamespace(string prefix)
		{
			if (!hasNamespaces)
			{
				return parent.LookupNamespace(prefix);
			}
			return base.LookupNamespace(prefix);
		}

		public override string LookupPrefix(string uri)
		{
			if (!hasNamespaces)
			{
				return parent.LookupPrefix(uri);
			}
			return base.LookupPrefix(uri);
		}

		public string GetElementPrefix(IXmlNode node, string namespaceUri)
		{
			if (namespaceUri == node.LookupNamespaceUri(string.Empty))
			{
				return string.Empty;
			}
			if (TryGetDefinedPrefix(node, namespaceUri, out var prefix))
			{
				return prefix;
			}
			if (!TryGetPreferredPrefix(node, namespaceUri, out prefix))
			{
				return string.Empty;
			}
			if (!ShouldDefineOnRoot(prefix, namespaceUri))
			{
				return string.Empty;
			}
			node.DefineNamespace(prefix, namespaceUri, root: true);
			return prefix;
		}

		public string GetAttributePrefix(IXmlNode node, string namespaceUri)
		{
			if (string.IsNullOrEmpty(namespaceUri))
			{
				return string.Empty;
			}
			if (TryGetDefinedPrefix(node, namespaceUri, out var prefix))
			{
				return prefix;
			}
			if (!TryGetPreferredPrefix(node, namespaceUri, out prefix))
			{
				prefix = GeneratePrefix(node);
			}
			bool root = ShouldDefineOnRoot(prefix, namespaceUri);
			node.DefineNamespace(prefix, namespaceUri, root);
			return prefix;
		}

		private static bool TryGetDefinedPrefix(IXmlNode node, string namespaceUri, out string prefix)
		{
			string value = node.LookupPrefix(namespaceUri);
			if (!string.IsNullOrEmpty(value))
			{
				return Try.Success(out prefix, value);
			}
			return Try.Failure<string>(out prefix);
		}

		private bool TryGetPreferredPrefix(IXmlNode node, string namespaceUri, out string prefix)
		{
			prefix = LookupPrefix(namespaceUri);
			if (string.IsNullOrEmpty(prefix))
			{
				return Try.Failure<string>(out prefix);
			}
			namespaceUri = node.LookupNamespaceUri(prefix);
			if (!string.IsNullOrEmpty(namespaceUri))
			{
				return Try.Failure<string>(out prefix);
			}
			return true;
		}

		private static string GeneratePrefix(IXmlNode node)
		{
			int num = 0;
			string text;
			while (true)
			{
				text = "p" + num;
				if (string.IsNullOrEmpty(node.LookupNamespaceUri(text)))
				{
					break;
				}
				num++;
			}
			return text;
		}

		private bool ShouldDefineOnRoot(string prefix, string uri)
		{
			if (rootNamespaces == null)
			{
				return parent.ShouldDefineOnRoot(prefix, uri);
			}
			return ShouldDefineOnRootCore(prefix, uri);
		}

		private bool ShouldDefineOnRootCore(string prefix, string uri)
		{
			if (rootNamespaces.TryGetValue(prefix, out var value))
			{
				return value == uri;
			}
			return false;
		}

		public override bool PreserveWhitespace(XPathNavigator node)
		{
			return true;
		}

		public override int CompareDocument(string baseUriA, string baseUriB)
		{
			return StringComparer.Ordinal.Compare(baseUriA, baseUriB);
		}

		public void AddVariable(string prefix, string name, IXsltContextVariable variable)
		{
			XmlName name2 = new XmlName(name, prefix ?? string.Empty);
			AddVariable(name2, variable);
		}

		public void AddFunction(string prefix, string name, IXsltContextFunction function)
		{
			XmlName name2 = new XmlName(name, prefix ?? string.Empty);
			AddFunction(name2, function);
		}

		public void AddVariable(XPathVariableAttribute attribute)
		{
			AddVariable(attribute.Name, attribute);
		}

		public void AddFunction(XPathFunctionAttribute attribute)
		{
			AddFunction(attribute.Name, attribute);
		}

		public void AddVariable(XmlName name, IXsltContextVariable variable)
		{
			EnsureVariables()[name] = variable;
		}

		public void AddFunction(XmlName name, IXsltContextFunction function)
		{
			EnsureFunctions()[name] = function;
		}

		private Dictionary<XmlName, IXsltContextVariable> EnsureVariables()
		{
			return variables ?? (variables = ((parent != null) ? new Dictionary<XmlName, IXsltContextVariable>(parent.EnsureVariables()) : new Dictionary<XmlName, IXsltContextVariable>()));
		}

		private Dictionary<XmlName, IXsltContextFunction> EnsureFunctions()
		{
			return functions ?? (functions = ((parent != null) ? new Dictionary<XmlName, IXsltContextFunction>(parent.EnsureFunctions()) : new Dictionary<XmlName, IXsltContextFunction>()));
		}

		public override IXsltContextVariable ResolveVariable(string prefix, string name)
		{
			if (variables == null)
			{
				if (parent == null)
				{
					return null;
				}
				return parent.ResolveVariable(prefix, name);
			}
			return ResolveVariableCore(prefix, name);
		}

		public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] argTypes)
		{
			if (functions == null)
			{
				if (parent == null)
				{
					return null;
				}
				return parent.ResolveFunction(prefix, name, argTypes);
			}
			return ResolveFunctionCore(prefix, name, argTypes);
		}

		private IXsltContextVariable ResolveVariableCore(string prefix, string name)
		{
			XmlName key = new XmlName(name, prefix ?? string.Empty);
			variables.TryGetValue(key, out var value);
			return value;
		}

		private IXsltContextFunction ResolveFunctionCore(string prefix, string name, XPathResultType[] argTypes)
		{
			XmlName key = new XmlName(name, prefix ?? string.Empty);
			functions.TryGetValue(key, out var value);
			return value;
		}

		public void Enlist(CompiledXPath path)
		{
			path.SetContext(XPathContext);
		}
	}
}
