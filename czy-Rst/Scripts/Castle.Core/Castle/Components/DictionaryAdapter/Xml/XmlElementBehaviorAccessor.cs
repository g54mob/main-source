using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlElementBehaviorAccessor : XmlNodeAccessor, IConfigurable<XmlElementAttribute>, IXmlBehaviorSemantics<XmlElementAttribute>
	{
		private class ItemAccessor : XmlNodeAccessor
		{
			public ItemAccessor(XmlNodeAccessor parent)
				: base(parent.ClrType.GetCollectionItemType(), parent.Context)
			{
				ConfigureLocalName(parent.Name.LocalName);
				ConfigureNamespaceUri(parent.Name.NamespaceUri);
				ConfigureNillable(parent.IsNillable);
				ConfigureReference(parent.IsReference);
				ConfigureKnownTypesFromParent(parent);
			}

			public override void Prepare()
			{
			}

			public override IXmlCursor SelectCollectionItems(IXmlNode node, bool mutable)
			{
				return node.SelectChildren(base.KnownTypes, base.Context, CursorFlags.Elements.MutableIf(mutable) | CursorFlags.Multiple);
			}
		}

		private ItemAccessor itemAccessor;

		private List<XmlElementAttribute> attributes;

		internal static readonly XmlAccessorFactory<XmlElementBehaviorAccessor> Factory = (string name, Type type, IXmlContext context) => new XmlElementBehaviorAccessor(name, type, context);

		public XmlElementBehaviorAccessor(string name, Type type, IXmlContext context)
			: base(name, type, context)
		{
		}

		public void Configure(XmlElementAttribute attribute)
		{
			if (attribute.Type == null)
			{
				ConfigureLocalName(attribute.ElementName);
				ConfigureNamespaceUri(attribute.Namespace);
				ConfigureNillable(attribute.IsNullable);
				return;
			}
			if (attributes == null)
			{
				attributes = new List<XmlElementAttribute>();
			}
			attributes.Add(attribute);
		}

		public override void Prepare()
		{
			if (attributes != null)
			{
				ConfigureKnownTypesFromAttributes(attributes, this);
				attributes = null;
			}
			base.Prepare();
		}

		public override void SetValue(IXmlCursor cursor, IDictionaryAdapter parentObject, XmlReferenceManager references, bool hasCurrent, object oldValue, ref object newValue)
		{
			if (newValue == null && base.IsCollection)
			{
				RemoveCollectionItems(cursor, references, oldValue);
			}
			else
			{
				base.SetValue(cursor, parentObject, references, hasCurrent, oldValue, ref newValue);
			}
		}

		public override IXmlCollectionAccessor GetCollectionAccessor(Type itemType)
		{
			return itemAccessor ?? (itemAccessor = new ItemAccessor(this));
		}

		public override IXmlCursor SelectPropertyNode(IXmlNode node, bool mutable)
		{
			return node.SelectChildren(base.KnownTypes, base.Context, CursorFlags.Elements.MutableIf(mutable));
		}

		public override IXmlCursor SelectCollectionNode(IXmlNode node, bool mutable)
		{
			return node.SelectSelf(base.ClrType);
		}

		public string GetLocalName(XmlElementAttribute attribute)
		{
			return attribute.ElementName;
		}

		public string GetNamespaceUri(XmlElementAttribute attribute)
		{
			return attribute.Namespace;
		}

		public Type GetClrType(XmlElementAttribute attribute)
		{
			return attribute.Type;
		}
	}
}
