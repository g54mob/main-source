using System;
using System.Collections;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public abstract class XmlAccessor : IXmlPropertyAccessor, IXmlAccessor, IXmlCollectionAccessor
	{
		[Flags]
		protected enum States
		{
			Nillable = 1,
			Volatile = 2,
			Reference = 4,
			ConfiguredContext = 8,
			ConfiguredLocalName = 0x10,
			ConfiguredNamespaceUri = 0x20,
			ConfiguredKnownTypes = 0x40
		}

		private readonly Type clrType;

		private readonly XmlName xsiType;

		private readonly XmlTypeSerializer serializer;

		private IXmlContext context;

		protected States state;

		public Type ClrType => clrType;

		public XmlName XsiType => xsiType;

		public XmlTypeSerializer Serializer => serializer;

		public IXmlContext Context
		{
			get
			{
				return context;
			}
			protected set
			{
				SetContext(value);
			}
		}

		public bool IsCollection => serializer.Kind == XmlTypeKind.Collection;

		public virtual bool IsIgnored => false;

		public bool IsNillable => (state & States.Nillable) != 0;

		public bool IsVolatile => (state & States.Volatile) != 0;

		public bool IsReference => (state & States.Reference) != 0;

		protected XmlAccessor(Type clrType, IXmlContext context)
		{
			if (clrType == null)
			{
				throw Error.ArgumentNull("clrType");
			}
			if (context == null)
			{
				throw Error.ArgumentNull("context");
			}
			clrType = clrType.NonNullable();
			this.clrType = clrType;
			xsiType = context.GetDefaultXsiType(clrType);
			serializer = XmlTypeSerializer.For(clrType);
			this.context = context;
		}

		public virtual void ConfigureNillable(bool nillable)
		{
			if (nillable)
			{
				state |= States.Nillable;
			}
		}

		public void ConfigureVolatile(bool isVolatile)
		{
			if (isVolatile)
			{
				state |= States.Volatile;
			}
		}

		public virtual void ConfigureReference(bool isReference)
		{
			if (isReference)
			{
				state |= States.Reference;
			}
		}

		public virtual void Prepare()
		{
		}

		protected IXmlContext CloneContext()
		{
			if ((state & States.ConfiguredContext) == 0)
			{
				context = context.Clone();
				state |= States.ConfiguredContext;
			}
			return context;
		}

		private void SetContext(IXmlContext value)
		{
			if (value == null)
			{
				throw Error.ArgumentNull("value");
			}
			context = value;
		}

		public virtual bool IsPropertyDefined(IXmlNode parentNode)
		{
			return (IsCollection ? SelectCollectionNode(parentNode, mutable: false) : SelectPropertyNode(parentNode, mutable: false)).MoveNext();
		}

		public virtual object GetPropertyValue(IXmlNode parentNode, IDictionaryAdapter parentObject, XmlReferenceManager references, bool orStub)
		{
			if (orStub)
			{
				orStub &= serializer.CanGetStub;
			}
			IXmlCursor xmlCursor = (IsCollection ? SelectCollectionNode(parentNode, orStub) : SelectPropertyNode(parentNode, orStub));
			return GetValue(xmlCursor, parentObject, references, xmlCursor.MoveNext(), orStub);
		}

		public object GetValue(IXmlNode node, IDictionaryAdapter parentObject, XmlReferenceManager references, bool nodeExists, bool orStub)
		{
			object value;
			if ((nodeExists || orStub) && IsReference)
			{
				value = null;
				if (references.OnGetStarting(ref node, ref value, out var token))
				{
					value = GetValueCore(node, parentObject, nodeExists, orStub);
					references.OnGetCompleted(node, value, token);
				}
			}
			else
			{
				value = GetValueCore(node, parentObject, nodeExists, orStub);
			}
			return value;
		}

		private object GetValueCore(IXmlNode node, IDictionaryAdapter parentObject, bool nodeExists, bool orStub)
		{
			if (nodeExists)
			{
				if (!node.IsNil)
				{
					return serializer.GetValue(node, parentObject, this);
				}
				if (IsNillable)
				{
					return null;
				}
			}
			if (!orStub)
			{
				return null;
			}
			return serializer.GetStub(node, parentObject, this);
		}

		public virtual void SetPropertyValue(IXmlNode parentNode, IDictionaryAdapter parentObject, XmlReferenceManager references, object oldValue, ref object value)
		{
			IXmlCursor xmlCursor = (IsCollection ? SelectCollectionNode(parentNode, mutable: true) : SelectPropertyNode(parentNode, mutable: true));
			SetValue(xmlCursor, parentObject, references, xmlCursor.MoveNext(), oldValue, ref value);
		}

		public virtual void SetValue(IXmlCursor cursor, IDictionaryAdapter parentObject, XmlReferenceManager references, bool hasCurrent, object oldValue, ref object newValue)
		{
			bool flag = newValue != null;
			bool isNillable = IsNillable;
			bool isReference = IsReference;
			Type type = (flag ? newValue.GetComponentType() : clrType);
			if (flag || isNillable)
			{
				if (hasCurrent)
				{
					Coerce(cursor, type, !flag && cursor.IsAttribute);
				}
				else
				{
					cursor.Create(type);
				}
			}
			else if (!hasCurrent)
			{
				return;
			}
			object token = null;
			if (!isReference || references.OnAssigningValue(cursor, oldValue, ref newValue, out token))
			{
				object givenValue = newValue;
				if (flag)
				{
					serializer.SetValue(cursor, parentObject, this, oldValue, ref newValue);
				}
				else if (isNillable)
				{
					cursor.IsNil = true;
				}
				else
				{
					cursor.Remove();
					cursor.RemoveAllNext();
				}
				if (isReference)
				{
					references.OnAssignedValue(cursor, givenValue, newValue, token);
				}
			}
		}

		private void Coerce(IXmlCursor cursor, Type clrType, bool replace)
		{
			if (replace)
			{
				cursor.Remove();
				cursor.MoveNext();
				cursor.Create(ClrType);
			}
			else
			{
				cursor.Coerce(clrType);
			}
		}

		public void GetCollectionItems(IXmlNode parentNode, IDictionaryAdapter parentObject, XmlReferenceManager references, IList values)
		{
			IXmlCursor xmlCursor = SelectCollectionItems(parentNode, mutable: false);
			while (xmlCursor.MoveNext())
			{
				object value;
				if (IsReference)
				{
					IXmlNode node = xmlCursor;
					value = null;
					if (references.OnGetStarting(ref node, ref value, out var token))
					{
						value = serializer.GetValue(node, parentObject, this);
						references.OnGetCompleted(node, value, token);
					}
				}
				else
				{
					value = serializer.GetValue(xmlCursor, parentObject, this);
				}
				values.Add(value);
			}
		}

		protected void RemoveCollectionItems(IXmlNode parentNode, XmlReferenceManager references, object value)
		{
			if (value is ICollectionProjection collectionProjection)
			{
				collectionProjection.Clear();
				return;
			}
			Type collectionItemType = clrType.GetCollectionItemType();
			IXmlCursor xmlCursor = GetCollectionAccessor(collectionItemType).SelectCollectionItems(parentNode, mutable: true);
			bool isReference = IsReference;
			if (value is IEnumerable enumerable)
			{
				foreach (object item in enumerable)
				{
					if (!xmlCursor.MoveNext())
					{
						break;
					}
					if (isReference)
					{
						references.OnAssigningNull(xmlCursor, item);
					}
				}
			}
			xmlCursor.Reset();
			xmlCursor.RemoveAllNext();
		}

		public virtual IXmlCollectionAccessor GetCollectionAccessor(Type itemType)
		{
			return GetDefaultCollectionAccessor(itemType);
		}

		protected IXmlCollectionAccessor GetDefaultCollectionAccessor(Type itemType)
		{
			XmlDefaultBehaviorAccessor xmlDefaultBehaviorAccessor = new XmlDefaultBehaviorAccessor(itemType, Context);
			xmlDefaultBehaviorAccessor.ConfigureNillable(nillable: true);
			xmlDefaultBehaviorAccessor.ConfigureReference(IsReference);
			return xmlDefaultBehaviorAccessor;
		}

		public virtual IXmlCursor SelectPropertyNode(IXmlNode parentNode, bool mutable)
		{
			throw Error.NotSupported();
		}

		public virtual IXmlCursor SelectCollectionNode(IXmlNode parentNode, bool mutable)
		{
			return SelectPropertyNode(parentNode, mutable);
		}

		public virtual IXmlCursor SelectCollectionItems(IXmlNode parentNode, bool mutable)
		{
			throw Error.NotSupported();
		}
	}
}
