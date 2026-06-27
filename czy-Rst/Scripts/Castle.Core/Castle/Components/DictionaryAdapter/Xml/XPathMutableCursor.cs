using System;
using System.Xml;
using System.Xml.XPath;

namespace Castle.Components.DictionaryAdapter.Xml
{
	internal class XPathMutableCursor : XPathNode, IXmlCursor, IXmlIterator, IXmlNode, IXmlKnownType, IXmlIdentity, IRealizableSource, IVirtual
	{
		private XPathBufferedNodeIterator iterator;

		private CompiledXPathStep step;

		private int depth;

		private readonly IXmlIncludedTypeMap knownTypes;

		private readonly CursorFlags flags;

		public override bool IsReal => HasCurrent;

		public bool HasCurrent => depth == xpath.Depth;

		public bool HasPartialOrCurrent => node != null;

		public override Type ClrType
		{
			get
			{
				if (!HasCurrent)
				{
					return knownTypes.Default.ClrType;
				}
				return base.ClrType;
			}
		}

		public override XmlName Name
		{
			get
			{
				if (!HasCurrent)
				{
					return XmlName.Empty;
				}
				return base.Name;
			}
		}

		public override XmlName XsiType
		{
			get
			{
				if (!HasCurrent)
				{
					return knownTypes.Default.XsiType;
				}
				return base.XsiType;
			}
		}

		public override bool IsElement
		{
			get
			{
				if (!HasCurrent)
				{
					return flags.IncludesElements();
				}
				return base.IsElement;
			}
		}

		public override bool IsAttribute
		{
			get
			{
				if (!HasCurrent)
				{
					return !flags.IncludesElements();
				}
				return base.IsAttribute;
			}
		}

		public override bool IsNil
		{
			get
			{
				if (HasCurrent)
				{
					return base.IsNil;
				}
				return false;
			}
			set
			{
				Realize();
				base.IsNil = value;
			}
		}

		public override string Value
		{
			get
			{
				if (!HasCurrent)
				{
					return string.Empty;
				}
				return base.Value;
			}
			set
			{
				base.Value = value;
			}
		}

		public override string Xml
		{
			get
			{
				if (!HasCurrent)
				{
					return null;
				}
				return base.Xml;
			}
		}

		public override event EventHandler Realized;

		public XPathMutableCursor(IXmlNode parent, CompiledXPath path, IXmlIncludedTypeMap knownTypes, IXmlNamespaceSource namespaces, CursorFlags flags)
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
			if (knownTypes == null)
			{
				throw Error.ArgumentNull("knownTypes");
			}
			if (!path.IsCreatable)
			{
				throw Error.XPathNotCreatable(path);
			}
			step = path.FirstStep;
			this.knownTypes = knownTypes;
			this.flags = flags;
			IRealizable<XPathNavigator> realizable = parent.RequireRealizable<XPathNavigator>();
			if (realizable.IsReal)
			{
				iterator = new XPathBufferedNodeIterator(realizable.Value.Select(path.FirstStep.Path));
			}
		}

		public override object Evaluate(CompiledXPath path)
		{
			if (!HasCurrent)
			{
				return null;
			}
			return base.Evaluate(path);
		}

		public bool MoveNext()
		{
			ResetCurrent();
			do
			{
				if (iterator == null || !iterator.MoveNext() || !Consume(iterator, flags.AllowsMultipleItems()))
				{
					return SetAtEnd();
				}
			}
			while (!SeekCurrent());
			return true;
		}

		private bool SeekCurrent()
		{
			while (depth < xpath.Depth)
			{
				XPathNodeIterator xPathNodeIterator = node.Select(step.Path);
				if (!xPathNodeIterator.MoveNext())
				{
					return true;
				}
				if (!Consume(xPathNodeIterator, multiple: false))
				{
					return false;
				}
			}
			if (!knownTypes.TryGet(XsiType, out var includedType))
			{
				return false;
			}
			type = includedType.ClrType;
			return true;
		}

		private bool Consume(XPathNodeIterator iterator, bool multiple)
		{
			XPathNavigator current = iterator.Current;
			if (!multiple && iterator.MoveNext())
			{
				return false;
			}
			node = current;
			Descend();
			return true;
		}

		private bool SetAtEnd()
		{
			ResetCurrent();
			return false;
		}

		public void Reset()
		{
			ResetCurrent();
			iterator.Reset();
		}

		public void MoveToEnd()
		{
			ResetCurrent();
			iterator.MoveToEnd();
		}

		private void ResetCurrent()
		{
			node = null;
			type = null;
			ResetDepth();
		}

		private void ResetDepth()
		{
			step = xpath.FirstStep;
			depth = 0;
		}

		private int Descend()
		{
			step = step.NextStep;
			return ++depth;
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
			while (MoveNext())
			{
				if (HasCurrent && node.IsSamePosition(value))
				{
					return;
				}
			}
			throw Error.CursorCannotMoveToGivenNode();
		}

		protected virtual void OnRealized()
		{
			if (Realized != null)
			{
				Realized(this, EventArgs.Empty);
			}
		}

		protected override void Realize()
		{
			if (!HasCurrent)
			{
				if (iterator != null && !iterator.IsEmpty && !HasPartialOrCurrent)
				{
					throw Error.CursorNotInRealizableState();
				}
				Create(knownTypes.Default.ClrType);
				OnRealized();
			}
		}

		public void MakeNext(Type clrType)
		{
			if (MoveNext())
			{
				Coerce(clrType);
			}
			else
			{
				Create(clrType);
			}
		}

		public void Coerce(Type clrType)
		{
			IXmlIncludedType xmlIncludedType = knownTypes.Require(clrType);
			this.SetXsiType(xmlIncludedType.XsiType);
			type = clrType;
		}

		public void Create(Type type)
		{
			if (HasCurrent)
			{
				Insert();
			}
			else if (HasPartialOrCurrent)
			{
				Complete();
			}
			else
			{
				Append();
			}
			Coerce(type);
		}

		private void Insert()
		{
			while (--depth > 0)
			{
				node.MoveToParent();
			}
			ResetDepth();
			using (XmlWriter writer = node.InsertBefore())
			{
				WriteNode(step, writer);
			}
			bool moved = node.MoveToPrevious();
			SeekCurrentAfterCreate(moved);
		}

		private void Append()
		{
			node = base.Parent.AsRealizable<XPathNavigator>().Value.Clone();
			base.Parent.IsNil = false;
			Complete();
		}

		private void Complete()
		{
			using (XmlWriter writer = CreateWriterForAppend())
			{
				WriteNode(step, writer);
			}
			bool moved = (step.IsAttribute ? node.MoveToLastAttribute() : node.MoveToLastChild());
			SeekCurrentAfterCreate(moved);
		}

		private XmlWriter CreateWriterForAppend()
		{
			if (!step.IsAttribute)
			{
				return node.AppendChild();
			}
			return node.CreateAttributes();
		}

		private void WriteNode(CompiledXPathNode node, XmlWriter writer)
		{
			if (node.IsAttribute)
			{
				WriteAttribute(node, writer);
			}
			else if (node.IsSimple)
			{
				WriteSimpleElement(node, writer);
			}
			else
			{
				WriteComplexElement(node, writer);
			}
		}

		private void WriteAttribute(CompiledXPathNode node, XmlWriter writer)
		{
			writer.WriteStartAttribute(node.Prefix, node.LocalName, null);
			WriteValue(node, writer);
			writer.WriteEndAttribute();
		}

		private void WriteSimpleElement(CompiledXPathNode node, XmlWriter writer)
		{
			writer.WriteStartElement(node.Prefix, node.LocalName, null);
			WriteValue(node, writer);
			writer.WriteEndElement();
		}

		private void WriteComplexElement(CompiledXPathNode node, XmlWriter writer)
		{
			writer.WriteStartElement(node.Prefix, node.LocalName, null);
			WriteSubnodes(node, writer, attributes: true);
			WriteSubnodes(node, writer, attributes: false);
			writer.WriteEndElement();
		}

		private void WriteSubnodes(CompiledXPathNode parent, XmlWriter writer, bool attributes)
		{
			CompiledXPathNode nextNode = parent.NextNode;
			if (nextNode != null && nextNode.IsAttribute == attributes)
			{
				WriteNode(nextNode, writer);
			}
			foreach (CompiledXPathNode dependency in parent.Dependencies)
			{
				if (dependency.IsAttribute == attributes)
				{
					WriteNode(dependency, writer);
				}
			}
		}

		private void WriteValue(CompiledXPathNode node, XmlWriter writer)
		{
			if (node.Value != null)
			{
				object value = base.Parent.AsRealizable<XPathNavigator>().Value.Evaluate(node.Value);
				writer.WriteValue(value);
			}
		}

		private void SeekCurrentAfterCreate(bool moved)
		{
			RequireMoved(moved);
			if (Descend() != xpath.Depth)
			{
				do
				{
					moved = (step.IsAttribute ? node.MoveToFirstAttribute() : node.MoveToFirstChild());
					RequireMoved(moved);
				}
				while (Descend() < xpath.Depth);
			}
		}

		public void RemoveAllNext()
		{
			while (MoveNext())
			{
				Remove();
			}
		}

		public void Remove()
		{
			RequireRemovable();
			XmlName xmlName = XmlName.Empty;
			if (!HasCurrent)
			{
				string namespaceUri = LookupNamespaceUri(step.Prefix) ?? node.NamespaceURI;
				xmlName = new XmlName(step.LocalName, namespaceUri);
			}
			while (!node.MoveToChild(xmlName.LocalName, xmlName.NamespaceUri))
			{
				xmlName = new XmlName(node.LocalName, node.NamespaceURI);
				node.DeleteSelf();
				depth--;
				if (depth <= 0)
				{
					break;
				}
			}
			ResetCurrent();
		}

		public override IXmlNode Save()
		{
			if (!HasCurrent)
			{
				return this;
			}
			return new XPathNode(node.Clone(), type, base.Namespaces);
		}

		private void RequireRemovable()
		{
			if (!HasPartialOrCurrent)
			{
				throw Error.CursorNotInRemovableState();
			}
		}

		private void RequireMoved(bool result)
		{
			if (!result)
			{
				throw Error.XPathNavigationFailed(step.Path);
			}
		}
	}
}
