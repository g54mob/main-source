using System;
using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class SysXmlCursor : SysXmlNode, IXmlCursor, IXmlIterator, IXmlNode, IXmlKnownType, IXmlIdentity, IRealizableSource, IVirtual
	{
		protected enum State
		{
			Empty = -4,
			End = -3,
			AttributePrimed = -2,
			ElementPrimed = -1,
			Initial = 0,
			Element = 1,
			Attribute = 2
		}

		private State state;

		private int index;

		private readonly IXmlKnownTypeMap knownTypes;

		private readonly CursorFlags flags;

		protected static readonly StringComparer DefaultComparer = StringComparer.OrdinalIgnoreCase;

		public override bool IsReal => HasCurrent;

		public bool HasCurrent => state > State.Initial;

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
					return GetEffectiveName(knownTypes.Default, node);
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

		public SysXmlCursor(IXmlNode parent, IXmlKnownTypeMap knownTypes, IXmlNamespaceSource namespaces, CursorFlags flags)
			: base(namespaces, parent)
		{
			if (parent == null)
			{
				throw Error.ArgumentNull("parent");
			}
			if (knownTypes == null)
			{
				throw Error.ArgumentNull("knownTypes");
			}
			this.knownTypes = knownTypes;
			this.flags = flags;
			index = -1;
			IRealizable<XmlNode> realizable = parent.RequireRealizable<XmlNode>();
			if (realizable.IsReal)
			{
				node = realizable.Value;
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
			bool hasCurrent = HasCurrent;
			int num;
			if (MoveNextCore())
			{
				if (!flags.AllowsMultipleItems())
				{
					num = (IsAtEnd() ? 1 : 0);
					if (num == 0)
					{
						goto IL_002b;
					}
				}
				else
				{
					num = 1;
				}
				goto IL_0036;
			}
			num = 0;
			goto IL_002b;
			IL_002b:
			if (!hasCurrent)
			{
				state = State.Empty;
			}
			goto IL_0036;
			IL_0036:
			return (byte)num != 0;
		}

		private bool MoveNextCore()
		{
			while (Advance())
			{
				if (IsMatch())
				{
					return true;
				}
			}
			return false;
		}

		private bool IsMatch()
		{
			if (!knownTypes.TryGet(this, out var knownType))
			{
				return Try.Failure<Type>(out type);
			}
			return Try.Success(out type, knownType.ClrType);
		}

		private bool Advance()
		{
			while (true)
			{
				switch (state)
				{
				case State.Initial:
					if (!AdvanceToFirstElement() && !AdvanceToFirstAttribute())
					{
						return Fail(State.End);
					}
					return true;
				case State.Element:
					if (!AdvanceToNextElement() && !AdvanceToFirstAttribute())
					{
						return Fail(State.End);
					}
					return true;
				case State.Attribute:
					if (!AdvanceToNextAttribute())
					{
						return Fail(State.End);
					}
					return true;
				case State.ElementPrimed:
					return Succeed(State.Element);
				case State.AttributePrimed:
					return Succeed(State.Attribute);
				case State.End:
					return false;
				case State.Empty:
					return false;
				}
			}
		}

		protected virtual bool AdvanceToFirstElement()
		{
			if (!flags.IncludesElements() || node == null)
			{
				return false;
			}
			if (!AdvanceElement(node.FirstChild))
			{
				return false;
			}
			state = State.Element;
			return true;
		}

		private bool AdvanceToNextElement()
		{
			if (AdvanceElement(node.NextSibling))
			{
				return true;
			}
			MoveToParentOfElement();
			return false;
		}

		protected virtual bool AdvanceToFirstAttribute()
		{
			if (!flags.IncludesAttributes() || node == null)
			{
				return false;
			}
			if (!AdvanceAttribute(node))
			{
				return false;
			}
			state = State.Attribute;
			return true;
		}

		private bool AdvanceToNextAttribute()
		{
			if (AdvanceAttribute(((XmlAttribute)node).OwnerElement))
			{
				return true;
			}
			MoveToParentOfAttribute();
			return false;
		}

		private bool AdvanceElement(XmlNode next)
		{
			while (true)
			{
				if (next == null)
				{
					return false;
				}
				if (next.NodeType == XmlNodeType.Element)
				{
					break;
				}
				next = next.NextSibling;
			}
			node = next;
			return true;
		}

		private bool AdvanceAttribute(XmlNode parent)
		{
			XmlAttributeCollection attributes = parent.Attributes;
			XmlAttribute attribute;
			do
			{
				index++;
				if (index >= attributes.Count)
				{
					return false;
				}
				attribute = attributes[index];
			}
			while (attribute.IsNamespace());
			node = attribute;
			return true;
		}

		private bool Succeed(State state)
		{
			this.state = state;
			return true;
		}

		private bool Fail(State state)
		{
			this.state = state;
			return false;
		}

		private bool IsAtEnd()
		{
			XmlNode xmlNode = node;
			Type type = base.type;
			State state = this.state;
			int num = index;
			bool num2 = MoveNextCore();
			node = xmlNode;
			base.type = type;
			this.state = state;
			index = num;
			return !num2;
		}

		public void MoveTo(IXmlNode position)
		{
			IRealizable<XmlNode> realizable = position.AsRealizable<XmlNode>();
			if (realizable == null || !realizable.IsReal)
			{
				throw Error.CursorCannotMoveToGivenNode();
			}
			if (!knownTypes.TryGet(position, out var knownType))
			{
				throw Error.CursorCannotMoveToGivenNode();
			}
			node = realizable.Value;
			type = knownType.ClrType;
			if (IsElement)
			{
				SetMovedToElement();
			}
			else
			{
				SetMovedToAttribute();
			}
		}

		private void SetMovedToElement()
		{
			state = State.Element;
			index = -1;
		}

		private void SetMovedToAttribute()
		{
			state = State.Attribute;
			XmlAttributeCollection attributes = ((XmlAttribute)node).OwnerElement.Attributes;
			index = 0;
			while (index < attributes.Count && attributes[index] != node)
			{
				index++;
			}
		}

		public void MoveToEnd()
		{
			switch (state)
			{
			case State.ElementPrimed:
			case State.Element:
				MoveToParentOfElement();
				state = State.End;
				break;
			case State.AttributePrimed:
			case State.Attribute:
				MoveToParentOfAttribute();
				state = State.End;
				break;
			case State.Initial:
				state = (IsAtEnd() ? State.Empty : State.End);
				break;
			}
		}

		public void Reset()
		{
			MoveToEnd();
			state = State.Initial;
			index = -1;
		}

		private void MoveToParentOfElement()
		{
			node = node.ParentNode;
		}

		private void MoveToParentOfAttribute()
		{
			node = ((XmlAttribute)node).OwnerElement;
		}

		private void MoveToRealizedParent()
		{
			IXmlNode xmlNode = base.Parent;
			node = xmlNode.AsRealizable<XmlNode>().Value;
			xmlNode.IsNil = false;
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
				if (state != State.Empty)
				{
					throw Error.CursorNotInRealizableState();
				}
				if (!flags.SupportsMutation())
				{
					throw Error.CursorNotMutable();
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
			RequireCoercible();
			IXmlKnownType xmlKnownType = knownTypes.Require(clrType);
			if (IsElement)
			{
				CoerceElement(xmlKnownType);
			}
			else
			{
				CoerceAttribute(xmlKnownType);
			}
			type = xmlKnownType.ClrType;
		}

		private void CoerceElement(IXmlKnownType knownType)
		{
			XmlElement xmlElement = (XmlElement)node;
			XmlNode parentNode = xmlElement.ParentNode;
			XmlName effectiveName = GetEffectiveName(knownType, parentNode);
			if (!XmlNameComparer.Default.Equals(Name, effectiveName))
			{
				XmlElement newChild = CreateElementCore(parentNode, effectiveName);
				parentNode.ReplaceChild(newChild, xmlElement);
				if (knownType.XsiType != XmlName.Empty)
				{
					this.SetXsiType(knownType.XsiType);
				}
			}
			else
			{
				this.SetXsiType(knownType.XsiType);
			}
		}

		private void CoerceAttribute(IXmlKnownType knownType)
		{
			RequireNoXsiType(knownType);
			XmlAttribute xmlAttribute = (XmlAttribute)node;
			XmlElement ownerElement = xmlAttribute.OwnerElement;
			XmlName effectiveName = GetEffectiveName(knownType, ownerElement);
			if (!XmlNameComparer.Default.Equals(Name, effectiveName))
			{
				XmlAttribute xmlAttribute2 = CreateAttributeCore(ownerElement, effectiveName);
				XmlAttributeCollection attributes = ownerElement.Attributes;
				attributes.RemoveNamedItem(xmlAttribute2.LocalName, xmlAttribute2.NamespaceURI);
				attributes.InsertBefore(xmlAttribute2, xmlAttribute);
				attributes.Remove(xmlAttribute);
			}
		}

		public void Create(Type type)
		{
			IXmlKnownType xmlKnownType = knownTypes.Require(type);
			XmlNode position = RequireCreatable();
			if (flags.IncludesElements())
			{
				CreateElement(xmlKnownType, position);
			}
			else
			{
				CreateAttribute(xmlKnownType, position);
			}
			base.type = xmlKnownType.ClrType;
		}

		private void CreateElement(IXmlKnownType knownType, XmlNode position)
		{
			XmlNode xmlNode = node;
			XmlName effectiveName = GetEffectiveName(knownType, xmlNode);
			XmlElement newChild = CreateElementCore(xmlNode, effectiveName);
			xmlNode.InsertBefore(newChild, position);
			state = State.Element;
			if (knownType.XsiType != XmlName.Empty)
			{
				this.SetXsiType(knownType.XsiType);
			}
		}

		private void CreateAttribute(IXmlKnownType knownType, XmlNode position)
		{
			RequireNoXsiType(knownType);
			XmlNode xmlNode = node;
			XmlName effectiveName = GetEffectiveName(knownType, xmlNode);
			XmlAttribute newNode = CreateAttributeCore(xmlNode, effectiveName);
			xmlNode.Attributes.InsertBefore(newNode, (XmlAttribute)position);
			state = State.Attribute;
		}

		private XmlElement CreateElementCore(XmlNode parent, XmlName name)
		{
			XmlDocument obj = parent.OwnerDocument ?? ((XmlDocument)parent);
			string elementPrefix = base.Namespaces.GetElementPrefix(this, name.NamespaceUri);
			return (XmlElement)(node = obj.CreateElement(elementPrefix, name.LocalName, name.NamespaceUri));
		}

		private XmlAttribute CreateAttributeCore(XmlNode parent, XmlName name)
		{
			XmlDocument obj = parent.OwnerDocument ?? ((XmlDocument)parent);
			string attributePrefix = base.Namespaces.GetAttributePrefix(this, name.NamespaceUri);
			return (XmlAttribute)(node = obj.CreateAttribute(attributePrefix, name.LocalName, name.NamespaceUri));
		}

		private void RequireNoXsiType(IXmlKnownType knownType)
		{
			if (knownType.XsiType != XmlName.Empty)
			{
				throw Error.CannotSetAttribute(this);
			}
		}

		private XmlName GetEffectiveName(IXmlKnownType knownType, XmlNode parent)
		{
			XmlName name = knownType.Name;
			if (name.NamespaceUri == null)
			{
				return name.WithNamespaceUri((parent != null) ? parent.NamespaceURI : string.Empty);
			}
			return name;
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
			XmlNode xmlNode = node;
			bool isElement = IsElement;
			MoveNext();
			switch (state)
			{
			case State.Attribute:
				state = State.AttributePrimed;
				break;
			case State.Element:
				state = State.ElementPrimed;
				break;
			}
			if (isElement)
			{
				RemoveElement(xmlNode);
			}
			else
			{
				RemoveAttribute(xmlNode);
			}
		}

		private void RemoveElement(XmlNode node)
		{
			node.ParentNode.RemoveChild(node);
		}

		private void RemoveAttribute(XmlNode node)
		{
			XmlAttribute xmlAttribute = (XmlAttribute)node;
			xmlAttribute.OwnerElement.Attributes.Remove(xmlAttribute);
		}

		public override IXmlNode Save()
		{
			if (!HasCurrent)
			{
				return this;
			}
			return new SysXmlNode(node, type, base.Namespaces);
		}

		private XmlNode RequireCreatable()
		{
			XmlNode result;
			switch (state)
			{
			case State.Element:
				result = node;
				MoveToParentOfElement();
				break;
			case State.Attribute:
				result = node;
				MoveToParentOfAttribute();
				break;
			case State.Empty:
				result = null;
				MoveToRealizedParent();
				break;
			case State.End:
				result = null;
				break;
			default:
				throw Error.CursorNotInCreatableState();
			}
			return result;
		}

		private void RequireCoercible()
		{
			if (state <= State.Initial)
			{
				throw Error.CursorNotInCoercibleState();
			}
		}

		private void RequireRemovable()
		{
			if (state <= State.Initial)
			{
				throw Error.CursorNotInRemovableState();
			}
		}
	}
}
