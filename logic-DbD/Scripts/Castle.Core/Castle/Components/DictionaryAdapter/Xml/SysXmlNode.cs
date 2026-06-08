using System;
using System.Xml;
using System.Xml.XPath;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class SysXmlNode : XmlNodeBase, IXmlNode, IXmlKnownType, IXmlIdentity, IRealizableSource, IVirtual, IRealizable<XmlNode>, IRealizable<XPathNavigator>
	{
		protected XmlNode node;

		public object UnderlyingObject => node;

		XmlNode IRealizable<XmlNode>.Value
		{
			get
			{
				Realize();
				return node;
			}
		}

		XPathNavigator IRealizable<XPathNavigator>.Value
		{
			get
			{
				Realize();
				return node.CreateNavigator();
			}
		}

		public virtual XmlName Name => new XmlName(node.LocalName, node.NamespaceURI);

		public virtual XmlName XsiType => this.GetXsiType();

		public virtual bool IsElement => node.NodeType == XmlNodeType.Element;

		public virtual bool IsAttribute => node.NodeType == XmlNodeType.Attribute;

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
				return node.InnerText;
			}
			set
			{
				if (!(IsNil = value == null))
				{
					node.InnerText = value;
				}
			}
		}

		public virtual string Xml => node.OuterXml;

		protected SysXmlNode(IXmlNamespaceSource namespaces, IXmlNode parent)
			: base(namespaces, parent)
		{
		}

		public SysXmlNode(XmlNode node, Type type, IXmlNamespaceSource namespaces)
			: base(namespaces, null)
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

		public bool UnderlyingPositionEquals(IXmlNode node)
		{
			IRealizable<XmlNode> realizable = node.AsRealizable<XmlNode>();
			if (realizable != null)
			{
				if (realizable.IsReal)
				{
					return realizable.Value == this.node;
				}
				return false;
			}
			IRealizable<XPathNavigator> realizable2 = node.AsRealizable<XPathNavigator>();
			if (realizable2 != null)
			{
				if (realizable2.IsReal)
				{
					return realizable2.Value.UnderlyingObject == this.node;
				}
				return false;
			}
			return false;
		}

		public string GetAttribute(XmlName name)
		{
			if (!IsReal)
			{
				return null;
			}
			if (!(node is XmlElement xmlElement))
			{
				return null;
			}
			XmlAttribute attributeNode = xmlElement.GetAttributeNode(name.LocalName, name.NamespaceUri);
			if (attributeNode == null)
			{
				return null;
			}
			string value = attributeNode.Value;
			if (string.IsNullOrEmpty(value))
			{
				return null;
			}
			return value;
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
			if (!(node is XmlElement xmlElement))
			{
				throw Error.CannotSetAttribute(this);
			}
			XmlAttribute xmlAttribute = xmlElement.GetAttributeNode(name.LocalName, name.NamespaceUri);
			if (xmlAttribute == null)
			{
				string attributePrefix = base.Namespaces.GetAttributePrefix(this, name.NamespaceUri);
				xmlAttribute = xmlElement.OwnerDocument.CreateAttribute(attributePrefix, name.LocalName, name.NamespaceUri);
				xmlElement.SetAttributeNode(xmlAttribute);
			}
			xmlAttribute.Value = value;
		}

		private void ClearAttribute(XmlName name)
		{
			if (IsReal && node is XmlElement xmlElement)
			{
				xmlElement.RemoveAttribute(name.LocalName, name.NamespaceUri);
			}
		}

		public string LookupPrefix(string namespaceUri)
		{
			return node.GetPrefixOfNamespace(namespaceUri);
		}

		public string LookupNamespaceUri(string prefix)
		{
			return node.GetNamespaceOfPrefix(prefix);
		}

		public void DefineNamespace(string prefix, string namespaceUri, bool root)
		{
			XmlElement xmlElement = GetNamespaceTargetElement();
			if (xmlElement == null)
			{
				throw Error.InvalidOperation();
			}
			if (root)
			{
				xmlElement = xmlElement.FindRoot();
			}
			xmlElement.DefineNamespace(prefix, namespaceUri);
		}

		private XmlElement GetNamespaceTargetElement()
		{
			if (node is XmlElement result)
			{
				return result;
			}
			if (node is XmlAttribute xmlAttribute)
			{
				return xmlAttribute.OwnerElement;
			}
			if (node is XmlDocument xmlDocument)
			{
				return xmlDocument.DocumentElement;
			}
			return null;
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

		public XmlReader ReadSubtree()
		{
			return node.CreateNavigator().ReadSubtree();
		}

		public XmlWriter WriteAttributes()
		{
			return node.CreateNavigator().CreateAttributes();
		}

		public XmlWriter WriteChildren()
		{
			return node.CreateNavigator().AppendChild();
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
			return node.CreateNavigator().Evaluate(path.Path);
		}

		public XmlNode GetNode()
		{
			return node;
		}

		public void Clear()
		{
			if (IsElement)
			{
				ClearAttributes();
			}
			else if (IsAttribute)
			{
				Value = string.Empty;
				return;
			}
			ClearChildren();
		}

		private void ClearAttributes()
		{
			XmlAttributeCollection attributes = node.Attributes;
			int num = attributes.Count;
			while (num > 0)
			{
				XmlAttribute attribute = attributes[--num];
				if (!attribute.IsNamespace() && !attribute.IsXsiType())
				{
					attributes.RemoveAt(num);
				}
			}
		}

		private void ClearChildren()
		{
			XmlNode xmlNode = node.FirstChild;
			while (xmlNode != null)
			{
				XmlNode nextSibling = xmlNode.NextSibling;
				node.RemoveChild(xmlNode);
				xmlNode = nextSibling;
			}
		}
	}
}
