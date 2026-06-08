using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlArrayBehaviorAccessor : XmlNodeAccessor, IConfigurable<XmlArrayAttribute>, IConfigurable<XmlArrayItemAttribute>
	{
		private class ItemAccessor : XmlNodeAccessor, IConfigurable<XmlArrayItemAttribute>, IXmlBehaviorSemantics<XmlArrayItemAttribute>
		{
			private List<XmlArrayItemAttribute> attributes;

			public ItemAccessor(Type itemClrType, XmlNodeAccessor accessor)
				: base(itemClrType, accessor.Context)
			{
				ConfigureNillable(nillable: true);
				ConfigureReference(accessor.IsReference);
			}

			public void Configure(XmlArrayItemAttribute attribute)
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
					attributes = new List<XmlArrayItemAttribute>();
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

			public override IXmlCursor SelectCollectionItems(IXmlNode node, bool mutable)
			{
				return node.SelectChildren(base.KnownTypes, base.Context, (CursorFlags.Elements | CursorFlags.Multiple).MutableIf(mutable));
			}

			public string GetLocalName(XmlArrayItemAttribute attribute)
			{
				return attribute.ElementName;
			}

			public string GetNamespaceUri(XmlArrayItemAttribute attribute)
			{
				return attribute.Namespace;
			}

			public Type GetClrType(XmlArrayItemAttribute attribute)
			{
				return attribute.Type;
			}
		}

		private readonly ItemAccessor itemAccessor;

		internal static readonly XmlAccessorFactory<XmlArrayBehaviorAccessor> Factory = (string name, Type type, IXmlContext context) => new XmlArrayBehaviorAccessor(name, type, context);

		private const CursorFlags PropertyFlags = CursorFlags.Elements;

		private const CursorFlags CollectionItemFlags = CursorFlags.Elements | CursorFlags.Multiple;

		public XmlArrayBehaviorAccessor(string name, Type type, IXmlContext context)
			: base(name, type, context)
		{
			if (base.Serializer.Kind != XmlTypeKind.Collection)
			{
				throw Error.AttributeConflict(name);
			}
			itemAccessor = new ItemAccessor(base.ClrType.GetCollectionItemType(), this);
		}

		public void Configure(XmlArrayAttribute attribute)
		{
			ConfigureLocalName(attribute.ElementName);
			ConfigureNamespaceUri(attribute.Namespace);
			ConfigureNillable(attribute.IsNullable);
		}

		public void Configure(XmlArrayItemAttribute attribute)
		{
			itemAccessor.Configure(attribute);
		}

		public override void Prepare()
		{
			base.Prepare();
			itemAccessor.Prepare();
		}

		public override IXmlCollectionAccessor GetCollectionAccessor(Type itemType)
		{
			return itemAccessor;
		}

		public override IXmlCursor SelectPropertyNode(IXmlNode node, bool mutable)
		{
			return node.SelectChildren(this, base.Context, CursorFlags.Elements.MutableIf(mutable));
		}
	}
}
