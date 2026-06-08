using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public abstract class XmlNodeAccessor : XmlAccessor, IXmlKnownType, IXmlIdentity, IXmlKnownTypeMap
	{
		private string localName;

		private string namespaceUri;

		private XmlKnownTypeSet knownTypes;

		protected static readonly StringComparer NameComparer = StringComparer.OrdinalIgnoreCase;

		public XmlName Name => new XmlName(localName, namespaceUri);

		XmlName IXmlIdentity.XsiType => XmlName.Empty;

		protected IXmlKnownTypeMap KnownTypes
		{
			get
			{
				if (knownTypes != null)
				{
					return knownTypes;
				}
				return this;
			}
		}

		IXmlKnownType IXmlKnownTypeMap.Default => this;

		protected XmlNodeAccessor(Type type, IXmlContext context)
			: this(context.GetDefaultXsiType(type).LocalName, type, context)
		{
		}

		protected XmlNodeAccessor(string name, Type type, IXmlContext context)
			: base(type, context)
		{
			if (name == null)
			{
				throw Error.ArgumentNull("name");
			}
			if (name == string.Empty)
			{
				throw Error.InvalidLocalName();
			}
			localName = XmlConvert.EncodeLocalName(name);
			namespaceUri = context.ChildNamespaceUri;
		}

		public bool TryGet(IXmlIdentity xmlName, out IXmlKnownType knownType)
		{
			if (!IsMatch(xmlName))
			{
				return Try.Failure<IXmlKnownType>(out knownType);
			}
			return Try.Success(out knownType, (IXmlKnownType)this);
		}

		public bool TryGet(Type clrType, out IXmlKnownType knownType)
		{
			if (!IsMatch(clrType))
			{
				return Try.Failure<IXmlKnownType>(out knownType);
			}
			return Try.Success(out knownType, (IXmlKnownType)this);
		}

		protected virtual bool IsMatch(IXmlIdentity xmlIdentity)
		{
			if (NameComparer.Equals(localName, xmlIdentity.Name.LocalName) && IsMatchOnNamespaceUri(xmlIdentity))
			{
				return IsMatchOnXsiType(xmlIdentity);
			}
			return false;
		}

		private bool IsMatchOnNamespaceUri(IXmlIdentity xmlIdentity)
		{
			string y = xmlIdentity.Name.NamespaceUri;
			if (base.Context.IsReservedNamespaceUri(y))
			{
				return NameComparer.Equals(namespaceUri, y);
			}
			if (namespaceUri != null && !ShouldIgnoreAttributeNamespaceUri(xmlIdentity))
			{
				return NameComparer.Equals(namespaceUri, y);
			}
			return true;
		}

		private bool IsMatchOnXsiType(IXmlIdentity xmlIdentity)
		{
			XmlName xmlName = xmlIdentity.XsiType;
			if (!(xmlName == XmlName.Empty))
			{
				return xmlName == base.XsiType;
			}
			return true;
		}

		private bool ShouldIgnoreAttributeNamespaceUri(IXmlIdentity xmlName)
		{
			if (xmlName is IXmlNode { IsAttribute: not false })
			{
				return (state & States.ConfiguredNamespaceUri) == 0;
			}
			return false;
		}

		protected virtual bool IsMatch(Type clrType)
		{
			if (!(clrType == base.ClrType))
			{
				if (base.Serializer.Kind == XmlTypeKind.Collection)
				{
					return typeof(IEnumerable).IsAssignableFrom(clrType);
				}
				return false;
			}
			return true;
		}

		protected void ConfigureLocalName(string localName)
		{
			ConfigureField(ref this.localName, localName, States.ConfiguredLocalName);
		}

		protected void ConfigureNamespaceUri(string namespaceUri)
		{
			ConfigureField(ref this.namespaceUri, namespaceUri, States.ConfiguredNamespaceUri);
		}

		private void ConfigureField(ref string field, string value, States mask)
		{
			if (!string.IsNullOrEmpty(value))
			{
				if ((state & mask) != 0)
				{
					throw Error.AttributeConflict(localName);
				}
				field = value;
				state |= mask;
			}
		}

		protected void ConfigureKnownTypesFromParent(XmlNodeAccessor accessor)
		{
			if (knownTypes != null)
			{
				throw Error.AttributeConflict(localName);
			}
			knownTypes = accessor.knownTypes;
		}

		protected void ConfigureKnownTypesFromAttributes<T>(IEnumerable<T> attributes, IXmlBehaviorSemantics<T> semantics)
		{
			foreach (T attribute in attributes)
			{
				Type type = semantics.GetClrType(attribute);
				if (type != null)
				{
					XmlName defaultXsiType = base.Context.GetDefaultXsiType(type);
					XmlName name = new XmlName(semantics.GetLocalName(attribute).NonEmpty() ?? defaultXsiType.LocalName, semantics.GetNamespaceUri(attribute) ?? namespaceUri);
					AddKnownType(name, defaultXsiType, type, overwrite: true);
				}
			}
		}

		public override void Prepare()
		{
			if (knownTypes == null)
			{
				ConfigureIncludedTypes(this);
			}
			else
			{
				ConfigureDefaultAndIncludedTypes();
			}
		}

		private void ConfigureDefaultAndIncludedTypes()
		{
			IXmlKnownType[] array = knownTypes.ToArray();
			knownTypes.AddXsiTypeDefaults();
			IXmlKnownType[] array2 = array;
			foreach (IXmlKnownType knownType in array2)
			{
				ConfigureIncludedTypes(knownType);
			}
		}

		private void ConfigureIncludedTypes(IXmlKnownType knownType)
		{
			foreach (IXmlIncludedType includedType in base.Context.GetIncludedTypes(knownType.ClrType))
			{
				AddKnownType(knownType.Name, includedType.XsiType, includedType.ClrType, overwrite: false);
			}
		}

		private void AddKnownType(XmlName name, XmlName xsiType, Type clrType, bool overwrite)
		{
			if (knownTypes == null)
			{
				knownTypes = new XmlKnownTypeSet(base.ClrType);
				AddSelfAsKnownType();
			}
			knownTypes.Add(new XmlKnownType(name, xsiType, clrType), overwrite);
		}

		private void AddSelfAsKnownType()
		{
			States states = States.ConfiguredLocalName | States.ConfiguredNamespaceUri | States.ConfiguredKnownTypes;
			if ((state & states) != States.ConfiguredKnownTypes)
			{
				knownTypes.Add(new XmlKnownType(Name, base.XsiType, base.ClrType), overwrite: true);
				knownTypes.Add(new XmlKnownType(Name, XmlName.Empty, base.ClrType), overwrite: true);
			}
		}
	}
}
