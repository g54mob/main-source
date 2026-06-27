using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlAdapter : DictionaryBehaviorAttribute, IDictionaryInitializer, IDictionaryBehavior, IDictionaryPropertyGetter, IDictionaryPropertySetter, IDictionaryCreateStrategy, IDictionaryCopyStrategy, IDictionaryReferenceManager, IVirtual, IXmlNodeSource
	{
		private IXmlNode node;

		private object source;

		private XmlReferenceManager references;

		private XmlMetadata primaryXmlMeta;

		private Dictionary<Type, XmlMetadata> secondaryXmlMetas;

		private readonly bool isRoot;

		public bool IsReal
		{
			get
			{
				if (node != null)
				{
					return node.IsReal;
				}
				return false;
			}
		}

		public IXmlNode Node => node;

		internal XmlReferenceManager References => references;

		public event EventHandler Realized;

		public XmlAdapter()
			: this(new XmlDocument())
		{
		}

		public XmlAdapter(XmlNode node)
		{
			if (node == null)
			{
				throw Error.ArgumentNull("node");
			}
			source = node;
			isRoot = true;
		}

		public XmlAdapter(IXmlNode node, XmlReferenceManager references)
		{
			if (node == null)
			{
				throw Error.ArgumentNull("node");
			}
			if (references == null)
			{
				throw Error.ArgumentNull("references");
			}
			this.node = node;
			this.references = references;
		}

		object IDictionaryCreateStrategy.Create(IDictionaryAdapter parent, Type type, IDictionary dictionary)
		{
			XmlAdapter adapter = new XmlAdapter(new XmlDocument());
			return parent.CreateChildAdapter(type, adapter, dictionary);
		}

		void IDictionaryInitializer.Initialize(IDictionaryAdapter dictionaryAdapter, object[] behaviors)
		{
			DictionaryAdapterMeta meta = dictionaryAdapter.Meta;
			if (primaryXmlMeta == null)
			{
				InitializePrimary(meta, dictionaryAdapter);
			}
			else
			{
				InitializeSecondary(meta);
			}
			InitializeBaseTypes(meta);
			InitializeStrategies(dictionaryAdapter);
			InitializeReference(dictionaryAdapter);
		}

		private void InitializePrimary(DictionaryAdapterMeta meta, IDictionaryAdapter dictionaryAdapter)
		{
			RequireXmlMeta(meta);
			primaryXmlMeta = meta.GetXmlMeta();
			if (node == null)
			{
				node = GetBaseNode();
			}
			if (!node.IsReal)
			{
				node.Realized += HandleNodeRealized;
			}
			if (references == null)
			{
				references = new XmlReferenceManager(node, DefaultXmlReferenceFormat.Instance);
			}
			InitializeReference(this);
		}

		private void InitializeSecondary(DictionaryAdapterMeta meta)
		{
			AddSecondaryXmlMeta(meta);
		}

		private void InitializeBaseTypes(DictionaryAdapterMeta meta)
		{
			Type[] interfaces = meta.Type.GetInterfaces();
			foreach (Type type in interfaces)
			{
				string text = type.Namespace;
				if (!(text == "Castle.Components.DictionaryAdapter") && !(text == "System.ComponentModel"))
				{
					DictionaryAdapterMeta adapterMeta = meta.GetAdapterMeta(type);
					AddSecondaryXmlMeta(adapterMeta);
				}
			}
		}

		private void InitializeStrategies(IDictionaryAdapter dictionaryAdapter)
		{
			DictionaryAdapterInstance dictionaryAdapterInstance = dictionaryAdapter.This;
			if (dictionaryAdapterInstance.CreateStrategy == null)
			{
				dictionaryAdapterInstance.CreateStrategy = this;
				dictionaryAdapterInstance.AddCopyStrategy(this);
			}
		}

		private void InitializeReference(object value)
		{
			if (isRoot)
			{
				references.Add(node, this, value, isInGraph: true);
			}
		}

		private void AddSecondaryXmlMeta(DictionaryAdapterMeta meta)
		{
			if (secondaryXmlMetas == null)
			{
				secondaryXmlMetas = new Dictionary<Type, XmlMetadata>();
			}
			else if (secondaryXmlMetas.ContainsKey(meta.Type))
			{
				return;
			}
			RequireXmlMeta(meta);
			secondaryXmlMetas[meta.Type] = meta.GetXmlMeta();
		}

		private static void RequireXmlMeta(DictionaryAdapterMeta meta)
		{
			if (!meta.HasXmlMeta())
			{
				throw Error.XmlMetadataNotAvailable(meta.Type);
			}
		}

		bool IDictionaryCopyStrategy.Copy(IDictionaryAdapter source, IDictionaryAdapter target, ref Func<PropertyDescriptor, bool> selector)
		{
			if (selector == null)
			{
				selector = (PropertyDescriptor property) => HasProperty(property.PropertyName, source);
			}
			return false;
		}

		object IDictionaryPropertyGetter.GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor property, bool ifExists)
		{
			if (TryGetAccessor(key, property, storedValue != null, out var accessor))
			{
				storedValue = accessor.GetPropertyValue(node, dictionaryAdapter, references, !ifExists);
				if (storedValue != null)
				{
					AttachObservers(storedValue, dictionaryAdapter, property);
					dictionaryAdapter.StoreProperty(property, key, storedValue);
				}
			}
			return storedValue;
		}

		bool IDictionaryPropertySetter.SetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, ref object value, PropertyDescriptor property)
		{
			if (TryGetAccessor(key, property, requireVolatile: false, out var accessor))
			{
				if (value != null && dictionaryAdapter.ShouldClearProperty(property, value))
				{
					value = null;
				}
				object oldValue = dictionaryAdapter.ReadProperty(key);
				accessor.SetPropertyValue(node, dictionaryAdapter, references, oldValue, ref value);
			}
			return true;
		}

		private static string EnsureKey(string key, PropertyDescriptor property)
		{
			if (!string.IsNullOrEmpty(key))
			{
				return key;
			}
			return property.PropertyName;
		}

		private IXmlNode GetBaseNode()
		{
			IXmlNode sourceNode = GetSourceNode();
			if (sourceNode.IsElement)
			{
				return sourceNode;
			}
			if (sourceNode.IsAttribute)
			{
				throw Error.NotSupported();
			}
			IXmlCursor xmlCursor = primaryXmlMeta.SelectBase(sourceNode);
			if (!xmlCursor.MoveNext())
			{
				return xmlCursor;
			}
			return xmlCursor.Save();
		}

		private IXmlNode GetSourceNode()
		{
			if (source is XmlNode xmlNode)
			{
				return new SysXmlNode(xmlNode, primaryXmlMeta.ClrType, primaryXmlMeta.Context);
			}
			throw Error.NotSupported();
		}

		private bool TryGetAccessor(string key, PropertyDescriptor property, bool requireVolatile, out XmlAccessor accessor)
		{
			accessor = (property.HasAccessor() ? property.GetAccessor() : CreateAccessor(key, property));
			if (accessor.IsIgnored)
			{
				return Try.Failure<XmlAccessor>(out accessor);
			}
			if (requireVolatile && !accessor.IsVolatile)
			{
				return Try.Failure<XmlAccessor>(out accessor);
			}
			return true;
		}

		private XmlAccessor CreateAccessor(string key, PropertyDescriptor property)
		{
			XmlAccessor accessor = null;
			bool isVolatile = false;
			bool isReference = false;
			if (string.IsNullOrEmpty(key))
			{
				accessor = CreateAccessor(key, property, XmlSelfAccessor.Factory);
			}
			object[] annotations = property.Annotations;
			foreach (object behavior in annotations)
			{
				if (IsIgnoreBehavior(behavior))
				{
					return XmlIgnoreBehaviorAccessor.Instance;
				}
				if (IsVolatileBehavior(behavior))
				{
					isVolatile = true;
				}
				else if (IsReferenceBehavior(behavior))
				{
					isReference = true;
				}
				else
				{
					TryApplyBehavior(key, property, behavior, ref accessor);
				}
			}
			if (accessor == null)
			{
				accessor = CreateAccessor(key, property, XmlDefaultBehaviorAccessor.Factory);
			}
			accessor.ConfigureVolatile(isVolatile);
			accessor.ConfigureReference(isReference);
			accessor.Prepare();
			property.SetAccessor(accessor);
			return accessor;
		}

		private bool TryApplyBehavior(string key, PropertyDescriptor property, object behavior, ref XmlAccessor accessor)
		{
			if (!TryApplyBehavior<XmlElementAttribute, XmlElementBehaviorAccessor>(key, property, behavior, ref accessor, XmlElementBehaviorAccessor.Factory) && !TryApplyBehavior<XmlArrayAttribute, XmlArrayBehaviorAccessor>(key, property, behavior, ref accessor, XmlArrayBehaviorAccessor.Factory) && !TryApplyBehavior<XmlArrayItemAttribute, XmlArrayBehaviorAccessor>(key, property, behavior, ref accessor, XmlArrayBehaviorAccessor.Factory) && !TryApplyBehavior<XmlAttributeAttribute, XmlAttributeBehaviorAccessor>(key, property, behavior, ref accessor, XmlAttributeBehaviorAccessor.Factory) && !TryApplyBehavior<XPathAttribute, XPathBehaviorAccessor>(key, property, behavior, ref accessor, XPathBehaviorAccessor.Factory) && !TryApplyBehavior<XPathVariableAttribute, XPathBehaviorAccessor>(key, property, behavior, ref accessor, XPathBehaviorAccessor.Factory))
			{
				return TryApplyBehavior<XPathFunctionAttribute, XPathBehaviorAccessor>(key, property, behavior, ref accessor, XPathBehaviorAccessor.Factory);
			}
			return true;
		}

		private bool TryApplyBehavior<TBehavior, TAccessor>(string key, PropertyDescriptor property, object behavior, ref XmlAccessor accessor, XmlAccessorFactory<TAccessor> factory) where TBehavior : class where TAccessor : XmlAccessor, IConfigurable<TBehavior>
		{
			if (!(behavior is TBehavior value))
			{
				return false;
			}
			if (accessor == null)
			{
				accessor = CreateAccessor(key, property, factory);
			}
			((accessor as TAccessor) ?? throw Error.AttributeConflict(key)).Configure(value);
			return true;
		}

		private TAccessor CreateAccessor<TAccessor>(string key, PropertyDescriptor property, XmlAccessorFactory<TAccessor> factory) where TAccessor : XmlAccessor
		{
			XmlMetadata xmlMetadata = GetXmlMetadata(property.Property.DeclaringType);
			TAccessor val = factory(key, property.PropertyType, xmlMetadata.Context);
			if (xmlMetadata.IsNullable.HasValue)
			{
				val.ConfigureNillable(xmlMetadata.IsNullable.Value);
			}
			if (xmlMetadata.IsReference.HasValue)
			{
				val.ConfigureReference(xmlMetadata.IsReference.Value);
			}
			return val;
		}

		private XmlMetadata GetXmlMetadata(Type type)
		{
			if (type == primaryXmlMeta.ClrType)
			{
				return primaryXmlMeta;
			}
			if (secondaryXmlMetas.TryGetValue(type, out var value))
			{
				return value;
			}
			throw Error.XmlMetadataNotAvailable(type);
		}

		private static bool IsIgnoreBehavior(object behavior)
		{
			return behavior is XmlIgnoreAttribute;
		}

		private static bool IsVolatileBehavior(object behavior)
		{
			return behavior is VolatileAttribute;
		}

		private static bool IsReferenceBehavior(object behavior)
		{
			return behavior is ReferenceAttribute;
		}

		void IVirtual.Realize()
		{
			throw new NotSupportedException("XmlAdapter does not support realization via IVirtual.Realize().");
		}

		protected virtual void OnRealized()
		{
			if (this.Realized != null)
			{
				this.Realized(this, EventArgs.Empty);
			}
		}

		private void HandleNodeRealized(object sender, EventArgs e)
		{
			OnRealized();
		}

		private void AttachObservers(object value, IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property)
		{
			if (value is IBindingList bindingList)
			{
				bindingList.ListChanged += delegate(object s, ListChangedEventArgs e)
				{
					HandleListChanged(s, e, dictionaryAdapter, property);
				};
			}
		}

		private void HandleListChanged(object value, ListChangedEventArgs args, IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property)
		{
			ListChangedType listChangedType = args.ListChangedType;
			if ((listChangedType == ListChangedType.ItemAdded || listChangedType == ListChangedType.ItemDeleted || listChangedType == ListChangedType.ItemMoved || listChangedType == ListChangedType.Reset) && dictionaryAdapter.ShouldClearProperty(property, value))
			{
				value = null;
				dictionaryAdapter.SetProperty(property.PropertyName, ref value);
			}
		}

		bool IDictionaryReferenceManager.IsReferenceProperty(IDictionaryAdapter dictionaryAdapter, string propertyName)
		{
			XmlAdapter xmlAdapter = For(dictionaryAdapter, required: false);
			if (xmlAdapter == null)
			{
				return false;
			}
			DictionaryAdapterInstance dictionaryAdapterInstance = dictionaryAdapter.This;
			if (!dictionaryAdapterInstance.Properties.TryGetValue(propertyName, out var value))
			{
				return false;
			}
			string key = value.GetKey(dictionaryAdapter, propertyName, dictionaryAdapterInstance.Descriptor);
			if (xmlAdapter.TryGetAccessor(key, value, requireVolatile: false, out var accessor))
			{
				return accessor.IsReference;
			}
			return false;
		}

		bool IDictionaryReferenceManager.TryGetReference(object keyObject, out object inGraphObject)
		{
			return references.TryGet(keyObject, out inGraphObject);
		}

		void IDictionaryReferenceManager.AddReference(object keyObject, object relatedObject, bool isInGraph)
		{
			references.Add(null, keyObject, relatedObject, isInGraph);
		}

		public override IDictionaryBehavior Copy()
		{
			return null;
		}

		public static XmlAdapter For(object obj)
		{
			return For(obj, required: true);
		}

		public static XmlAdapter For(object obj, bool required)
		{
			if (obj == null)
			{
				if (!required)
				{
					return null;
				}
				throw Error.ArgumentNull("obj");
			}
			if (!(obj is IDictionaryAdapter dictionaryAdapter))
			{
				if (!required)
				{
					return null;
				}
				throw Error.NotDictionaryAdapter("obj");
			}
			PropertyDescriptor descriptor = dictionaryAdapter.This.Descriptor;
			if (descriptor == null)
			{
				if (!required)
				{
					return null;
				}
				throw Error.NoInstanceDescriptor("obj");
			}
			IEnumerable<IDictionaryPropertyGetter> getters = descriptor.Getters;
			if (getters == null)
			{
				if (!required)
				{
					return null;
				}
				throw Error.NoXmlAdapter("obj");
			}
			foreach (IDictionaryPropertyGetter item in getters)
			{
				if (item is XmlAdapter result)
				{
					return result;
				}
			}
			if (!required)
			{
				return null;
			}
			throw Error.NoXmlAdapter("obj");
		}

		public static bool IsPropertyDefined(string propertyName, IDictionaryAdapter dictionaryAdapter)
		{
			return For(dictionaryAdapter, required: true)?.HasProperty(propertyName, dictionaryAdapter) ?? false;
		}

		public bool HasProperty(string propertyName, IDictionaryAdapter dictionaryAdapter)
		{
			string key = dictionaryAdapter.GetKey(propertyName);
			if (key == null)
			{
				return false;
			}
			if (dictionaryAdapter.This.Properties.TryGetValue(propertyName, out var value) && TryGetAccessor(key, value, requireVolatile: false, out var accessor))
			{
				return accessor.IsPropertyDefined(node);
			}
			return false;
		}
	}
}
