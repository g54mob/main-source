using System;
using System.Xml.XPath;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XPathBehaviorAccessor : XmlAccessor, IXmlIncludedType, IXmlIncludedTypeMap, IConfigurable<XPathAttribute>, IConfigurable<XPathVariableAttribute>, IConfigurable<XPathFunctionAttribute>
	{
		private class DefaultAccessor : XPathBehaviorAccessor
		{
			private readonly XPathBehaviorAccessor parent;

			public DefaultAccessor(XPathBehaviorAccessor parent, CompiledXPath path)
				: base(parent.ClrType, parent.Context)
			{
				this.parent = parent;
				base.path = path;
			}

			public override void Prepare()
			{
				includedTypes = parent.includedTypes;
				base.Context = parent.Context;
				base.Prepare();
			}
		}

		private class ItemAccessor : XPathBehaviorAccessor
		{
			public ItemAccessor(XPathBehaviorAccessor parent)
				: base(parent.ClrType.GetCollectionItemType(), parent.Context)
			{
				includedTypes = parent.includedTypes;
				path = parent.path;
				ConfigureNillable(nillable: true);
			}

			public override IXmlCollectionAccessor GetCollectionAccessor(Type itemType)
			{
				return GetDefaultCollectionAccessor(itemType);
			}
		}

		private CompiledXPath path;

		private XmlIncludedTypeSet includedTypes;

		private XmlAccessor defaultAccessor;

		private XmlAccessor itemAccessor;

		internal static readonly XmlAccessorFactory<XPathBehaviorAccessor> Factory = (string name, Type type, IXmlContext context) => new XPathBehaviorAccessor(type, context);

		XmlName IXmlIncludedType.XsiType => XmlName.Empty;

		IXmlIncludedType IXmlIncludedTypeMap.Default => this;

		private bool SelectsNodes => path.Path.ReturnType == XPathResultType.NodeSet;

		private bool CreatesAttributes => path.LastStep?.IsAttribute ?? false;

		protected XPathBehaviorAccessor(Type type, IXmlContext context)
			: base(type, context)
		{
			includedTypes = new XmlIncludedTypeSet();
			foreach (IXmlIncludedType includedType in context.GetIncludedTypes(base.ClrType))
			{
				includedTypes.Add(includedType);
			}
		}

		public void Configure(XPathAttribute attribute)
		{
			if (path != null)
			{
				throw Error.AttributeConflict(path.Path.Expression);
			}
			path = attribute.SetPath;
			if (path != attribute.GetPath)
			{
				if (base.Serializer.CanGetStub)
				{
					throw Error.SeparateGetterSetterOnComplexType(path.Path.Expression);
				}
				defaultAccessor = new DefaultAccessor(this, attribute.GetPath);
			}
		}

		public void Configure(XPathVariableAttribute attribute)
		{
			CloneContext().AddVariable(attribute);
		}

		public void Configure(XPathFunctionAttribute attribute)
		{
			CloneContext().AddFunction(attribute);
		}

		public override void Prepare()
		{
			if (CreatesAttributes)
			{
				state &= ~States.Nillable;
			}
			base.Context.Enlist(path);
			if (defaultAccessor != null)
			{
				defaultAccessor.Prepare();
			}
		}

		public override bool IsPropertyDefined(IXmlNode parentNode)
		{
			if (SelectsNodes)
			{
				return base.IsPropertyDefined(parentNode);
			}
			return false;
		}

		public override object GetPropertyValue(IXmlNode parentNode, IDictionaryAdapter parentObject, XmlReferenceManager references, bool orStub)
		{
			return GetPropertyValueCore(parentNode, parentObject, references, orStub) ?? GetDefaultPropertyValue(parentNode, parentObject, references, orStub);
		}

		private object GetPropertyValueCore(IXmlNode parentNode, IDictionaryAdapter parentObject, XmlReferenceManager references, bool orStub)
		{
			if (!SelectsNodes)
			{
				return Evaluate(parentNode);
			}
			return base.GetPropertyValue(parentNode, parentObject, references, orStub);
		}

		private object GetDefaultPropertyValue(IXmlNode parentNode, IDictionaryAdapter parentObject, XmlReferenceManager references, bool orStub)
		{
			if (defaultAccessor == null)
			{
				return null;
			}
			return defaultAccessor.GetPropertyValue(parentNode, parentObject, references, orStub);
		}

		private object Evaluate(IXmlNode node)
		{
			object obj = node.Evaluate(path);
			if (obj == null)
			{
				return null;
			}
			return Convert.ChangeType(obj, base.ClrType);
		}

		public override void SetPropertyValue(IXmlNode parentNode, IDictionaryAdapter parentObject, XmlReferenceManager references, object oldValue, ref object value)
		{
			if (SelectsNodes)
			{
				base.SetPropertyValue(parentNode, parentObject, references, oldValue, ref value);
				return;
			}
			throw Error.XPathNotCreatable(path);
		}

		public override IXmlCollectionAccessor GetCollectionAccessor(Type itemType)
		{
			return itemAccessor ?? (itemAccessor = new ItemAccessor(this));
		}

		public override IXmlCursor SelectPropertyNode(IXmlNode node, bool create)
		{
			CursorFlags flags = CursorFlags.AllNodes.MutableIf(create);
			return node.Select(path, this, base.Context, flags);
		}

		public override IXmlCursor SelectCollectionNode(IXmlNode node, bool create)
		{
			return node.SelectSelf(base.ClrType);
		}

		public override IXmlCursor SelectCollectionItems(IXmlNode node, bool create)
		{
			CursorFlags flags = CursorFlags.AllNodes.MutableIf(create) | CursorFlags.Multiple;
			return node.Select(path, this, base.Context, flags);
		}

		public bool TryGet(XmlName xsiType, out IXmlIncludedType includedType)
		{
			if (xsiType == XmlName.Empty || xsiType == base.XsiType)
			{
				return Try.Success(out includedType, (IXmlIncludedType)this);
			}
			if (!includedTypes.TryGet(xsiType, out includedType))
			{
				return false;
			}
			if (!base.ClrType.IsAssignableFrom(includedType.ClrType))
			{
				return Try.Failure<IXmlIncludedType>(out includedType);
			}
			return true;
		}

		public bool TryGet(Type clrType, out IXmlIncludedType includedType)
		{
			if (!(clrType == base.ClrType))
			{
				return includedTypes.TryGet(clrType, out includedType);
			}
			return Try.Success(out includedType, (IXmlIncludedType)this);
		}
	}
}
