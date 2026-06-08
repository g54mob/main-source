using System;
using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlSelfCursor : IXmlCursor, IXmlIterator, IXmlNode, IXmlKnownType, IXmlIdentity, IRealizableSource, IVirtual
	{
		private readonly IXmlNode node;

		private readonly Type clrType;

		private int position;

		public CursorFlags Flags
		{
			get
			{
				if (!node.IsAttribute)
				{
					return CursorFlags.Elements;
				}
				return CursorFlags.Attributes;
			}
		}

		public CompiledXPath Path => node.Path;

		public XmlName Name => node.Name;

		public XmlName XsiType => node.XsiType;

		public Type ClrType => clrType ?? node.ClrType;

		public bool IsReal => node.IsReal;

		public bool IsElement => node.IsElement;

		public bool IsAttribute => node.IsAttribute;

		public bool IsNil
		{
			get
			{
				return node.IsNil;
			}
			set
			{
				throw Error.NotSupported();
			}
		}

		public string Value
		{
			get
			{
				return node.Value;
			}
			set
			{
				node.Value = value;
			}
		}

		public string Xml => node.Xml;

		public IXmlNode Parent => node.Parent;

		public IXmlNamespaceSource Namespaces => node.Namespaces;

		public object UnderlyingObject => node.UnderlyingObject;

		public event EventHandler Realized
		{
			add
			{
				node.Realized += value;
			}
			remove
			{
				node.Realized -= value;
			}
		}

		public XmlSelfCursor(IXmlNode node, Type clrType)
		{
			this.node = node;
			this.clrType = clrType;
			Reset();
		}

		public bool UnderlyingPositionEquals(IXmlNode node)
		{
			return this.node.UnderlyingPositionEquals(node);
		}

		public IRealizable<T> AsRealizable<T>()
		{
			return node.AsRealizable<T>();
		}

		public void Realize()
		{
			node.Realize();
		}

		public string GetAttribute(XmlName name)
		{
			return node.GetAttribute(name);
		}

		public void SetAttribute(XmlName name, string value)
		{
			node.SetAttribute(name, value);
		}

		public string LookupPrefix(string namespaceUri)
		{
			return node.LookupPrefix(namespaceUri);
		}

		public string LookupNamespaceUri(string prefix)
		{
			return node.LookupNamespaceUri(prefix);
		}

		public void DefineNamespace(string prefix, string namespaceUri, bool root)
		{
			node.DefineNamespace(prefix, namespaceUri, root);
		}

		public bool MoveNext()
		{
			return ++position == 0;
		}

		public void MoveToEnd()
		{
			position = 1;
		}

		public void Reset()
		{
			position = -1;
		}

		public void MoveTo(IXmlNode position)
		{
			if (position != node)
			{
				throw Error.NotSupported();
			}
		}

		public IXmlNode Save()
		{
			if (position != 0)
			{
				return this;
			}
			return new XmlSelfCursor(node.Save(), clrType)
			{
				position = 0
			};
		}

		public IXmlCursor SelectSelf(Type clrType)
		{
			return new XmlSelfCursor(node, clrType);
		}

		public IXmlCursor SelectChildren(IXmlKnownTypeMap knownTypes, IXmlNamespaceSource namespaces, CursorFlags flags)
		{
			return node.SelectChildren(knownTypes, namespaces, flags);
		}

		public IXmlIterator SelectSubtree()
		{
			return node.SelectSubtree();
		}

		public IXmlCursor Select(CompiledXPath path, IXmlIncludedTypeMap knownTypes, IXmlNamespaceSource namespaces, CursorFlags flags)
		{
			return node.Select(path, knownTypes, namespaces, flags);
		}

		public object Evaluate(CompiledXPath path)
		{
			return node.Evaluate(path);
		}

		public XmlReader ReadSubtree()
		{
			return node.ReadSubtree();
		}

		public XmlWriter WriteAttributes()
		{
			return node.WriteAttributes();
		}

		public XmlWriter WriteChildren()
		{
			return node.WriteChildren();
		}

		public void MakeNext(Type type)
		{
			if (!MoveNext())
			{
				throw Error.NotSupported();
			}
		}

		public void Create(Type type)
		{
			throw Error.NotSupported();
		}

		public void Coerce(Type type)
		{
		}

		public void Clear()
		{
			node.Clear();
		}

		public void Remove()
		{
		}

		public void RemoveAllNext()
		{
		}
	}
}
