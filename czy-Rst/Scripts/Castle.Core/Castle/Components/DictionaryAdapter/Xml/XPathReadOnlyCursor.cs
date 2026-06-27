using System;
using System.Xml.XPath;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XPathReadOnlyCursor : XPathNode, IXmlCursor, IXmlIterator, IXmlNode, IXmlKnownType, IXmlIdentity, IRealizableSource, IVirtual
	{
		private XPathNodeIterator iterator;

		private readonly IXmlIncludedTypeMap includedTypes;

		private readonly CursorFlags flags;

		public XPathReadOnlyCursor(IXmlNode parent, CompiledXPath path, IXmlIncludedTypeMap includedTypes, IXmlNamespaceSource namespaces, CursorFlags flags)
			: base(path, namespaces, parent)
		{
			if (parent == null)
			{
				throw Error.ArgumentNull("parent");
			}
			if (path == null)
			{
				throw Error.ArgumentNull("path");
			}
			if (includedTypes == null)
			{
				throw Error.ArgumentNull("includedTypes");
			}
			this.includedTypes = includedTypes;
			this.flags = flags;
			Reset();
		}

		public void Reset()
		{
			IRealizable<XPathNavigator> realizable = base.Parent.RequireRealizable<XPathNavigator>();
			if (realizable.IsReal)
			{
				iterator = realizable.Value.Select(xpath.Path);
			}
		}

		public bool MoveNext()
		{
			do
			{
				if (iterator == null || !iterator.MoveNext() || (!flags.AllowsMultipleItems() && iterator.MoveNext()))
				{
					return SetAtEnd();
				}
			}
			while (!SetAtNext());
			return true;
		}

		private bool SetAtEnd()
		{
			node = null;
			type = null;
			return false;
		}

		private bool SetAtNext()
		{
			node = iterator.Current;
			if (!includedTypes.TryGet(XsiType, out var includedType))
			{
				return false;
			}
			type = includedType.ClrType;
			return true;
		}

		public void MoveTo(IXmlNode position)
		{
			IRealizable<XPathNavigator> realizable = position.AsRealizable<XPathNavigator>();
			if (realizable == null || !realizable.IsReal)
			{
				throw Error.CursorCannotMoveToGivenNode();
			}
			XPathNavigator value = realizable.Value;
			Reset();
			if (iterator != null)
			{
				while (iterator.MoveNext())
				{
					if (iterator.Current.IsSamePosition(value))
					{
						SetAtNext();
						return;
					}
				}
			}
			throw Error.CursorCannotMoveToGivenNode();
		}

		public void MoveToEnd()
		{
			if (iterator != null)
			{
				while (iterator.MoveNext())
				{
				}
			}
			SetAtEnd();
		}

		public void MakeNext(Type type)
		{
			throw Error.CursorNotMutable();
		}

		public void Create(Type type)
		{
			throw Error.CursorNotMutable();
		}

		public void Coerce(Type type)
		{
			throw Error.CursorNotMutable();
		}

		public void Remove()
		{
			throw Error.CursorNotMutable();
		}

		public void RemoveAllNext()
		{
			throw Error.CursorNotMutable();
		}

		public override IXmlNode Save()
		{
			return new XPathNode(node.Clone(), type, base.Namespaces);
		}
	}
}
