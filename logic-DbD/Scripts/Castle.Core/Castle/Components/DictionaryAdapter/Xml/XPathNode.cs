using System;
using System.Xml;
using System.Xml.XPath;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XPathNode : XmlNodeBase, IXmlNode, IXmlKnownType, IXmlIdentity, IRealizableSource, IVirtual, IRealizable<XPathNavigator>, IRealizable<XmlNode>
	{
		protected XPathNavigator node;

		protected readonly CompiledXPath xpath;

		public object UnderlyingObject => node;

		XPathNavigator IRealizable<XPathNavigator>.Value
		{
			get
			{
				Realize();
				return node;
			}
		}

		XmlNode IRealizable<XmlNode>.Value
		{
			get
			{
				Realize();
				return (XmlNode)node.UnderlyingObject;
			}
		}

		public override CompiledXPath Path => xpath;

		public virtual XmlName Name => new XmlName(node.LocalName, node.NamespaceURI);

		public virtual XmlName XsiType => this.GetXsiType();

		public virtual bool IsElement => node.NodeType == XPathNodeType.Element;

		public virtual bool IsAttribute => node.NodeType == XPathNodeType.Attribute;

		public virtual bool IsNil
		{
			get
			{
				return this.IsXsiNil();
			}
			set
			{
				this.SetXsiNil(value);
			}
		}

		public virtual string Value
		{
			get
			{
				return node.Value;
			}
			set
			{
				if (!(IsNil = value == null))
				{
					node.SetValue(value);
				}
			}
		}

		public virtual string Xml => node.OuterXml;

		protected XPathNode(CompiledXPath path, IXmlNamespaceSource namespaces, IXmlNode parent)
			: base(namespaces, parent)
		{
			xpath = path;
		}

		public XPathNode(XPathNavigator node, Type type, IXmlNamespaceSource namespaces)
			: this(null, namespaces, null)
		{
			if (node == null)
			{
				throw Error.ArgumentNull("node");
			}
			if (type == null)
			{
				throw Error.ArgumentNull("type");
			}
			this.node = node;
			base.type = type;
		}

		public string GetAttribute(XmlName name)
		{
			if (!IsReal || !node.MoveToAttribute(name.LocalName, name.NamespaceUri))
			{
				return null;
			}
			string value = node.Value;
			node.MoveToParent();
			if (!string.IsNullOrEmpty(value))
			{
				return value;
			}
			return null;
		}

		public void SetAttribute(XmlName name, string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				ClearAttribute(name);
			}
			else
			{
				SetAttributeCore(name, value);
			}
		}

		private void SetAttributeCore(XmlName name, string value)
		{
			if (!IsElement)
			{
				throw Error.CannotSetAttribute(this);
			}
			Realize();
			if (node.MoveToAttribute(name.LocalName, name.NamespaceUri))
			{
				node.SetValue(value);
				node.MoveToParent();
			}
			else
			{
				string attributePrefix = base.Namespaces.GetAttributePrefix(this, name.NamespaceUri);
				node.CreateAttribute(attributePrefix, name.LocalName, name.NamespaceUri, value);
			}
		}

		private void ClearAttribute(XmlName name)
		{
			if (IsReal && node.MoveToAttribute(name.LocalName, name.NamespaceUri))
			{
				node.DeleteSelf();
			}
		}

		public string LookupPrefix(string namespaceUri)
		{
			return node.LookupPrefix(namespaceUri);
		}

		public string LookupNamespaceUri(string prefix)
		{
			return node.LookupNamespace(prefix);
		}

		public void DefineNamespace(string prefix, string namespaceUri, bool root)
		{
			(root ? node.GetRootElement() : (IsElement ? node : (IsAttribute ? node.GetParent() : node.GetRootElement()))).CreateAttribute("xmlns", prefix, "http://www.w3.org/2000/xmlns/", namespaceUri);
		}

		public bool UnderlyingPositionEquals(IXmlNode node)
		{
			IRealizable<XmlNode> realizable = node.AsRealizable<XmlNode>();
			if (realizable != null)
			{
				if (realizable.IsReal)
				{
					return realizable.Value == this.node.UnderlyingObject;
				}
				return false;
			}
			IRealizable<XPathNavigator> realizable2 = node.AsRealizable<XPathNavigator>();
			if (realizable2 != null)
			{
				if (realizable2.IsReal)
				{
					return realizable2.Value.IsSamePosition(this.node);
				}
				return false;
			}
			return false;
		}

		public virtual IXmlNode Save()
		{
			return this;
		}

		public IXmlCursor SelectSelf(Type clrType)
		{
			return new XmlSelfCursor(this, clrType);
		}

		public IXmlCursor SelectChildren(IXmlKnownTypeMap knownTypes, IXmlNamespaceSource namespaces, CursorFlags flags)
		{
			return new SysXmlCursor(this, knownTypes, namespaces, flags);
		}

		public IXmlIterator SelectSubtree()
		{
			return new SysXmlSubtreeIterator(this, base.Namespaces);
		}

		public IXmlCursor Select(CompiledXPath path, IXmlIncludedTypeMap includedTypes, IXmlNamespaceSource namespaces, CursorFlags flags)
		{
			if (!flags.SupportsMutation())
			{
				return new XPathReadOnlyCursor(this, path, includedTypes, namespaces, flags);
			}
			return new XPathMutableCursor(this, path, includedTypes, namespaces, flags);
		}

		public virtual object Evaluate(CompiledXPath path)
		{
			return node.Evaluate(path.Path);
		}

		public virtual XmlReader ReadSubtree()
		{
			return node.ReadSubtree();
		}

		public virtual XmlWriter WriteAttributes()
		{
			return node.CreateAttributes();
		}

		public virtual XmlWriter WriteChildren()
		{
			return node.AppendChild();
		}

		public virtual void Clear()
		{
			node.DeleteChildren();
		}
	}
}
