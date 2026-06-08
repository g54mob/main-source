using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Castle.Components.DictionaryAdapter
{
	[DebuggerDisplay("Type: {Type.FullName,nq}")]
	public class DictionaryAdapterMeta
	{
		private IDictionary extendedProperties;

		private readonly Func<DictionaryAdapterInstance, IDictionaryAdapter> creator;

		public Type Type { get; private set; }

		public Type Implementation { get; private set; }

		public object[] Behaviors { get; private set; }

		public IDictionaryAdapterFactory Factory { get; private set; }

		public IDictionary<string, PropertyDescriptor> Properties { get; private set; }

		public IDictionaryMetaInitializer[] MetaInitializers { get; private set; }

		public IDictionaryInitializer[] Initializers { get; private set; }

		public IDictionary ExtendedProperties
		{
			get
			{
				if (extendedProperties == null)
				{
					extendedProperties = new Dictionary<object, object>();
				}
				return extendedProperties;
			}
		}

		public DictionaryAdapterMeta(Type type, Type implementation, object[] behaviors, IDictionaryMetaInitializer[] metaInitializers, IDictionaryInitializer[] initializers, IDictionary<string, PropertyDescriptor> properties, IDictionaryAdapterFactory factory, Func<DictionaryAdapterInstance, IDictionaryAdapter> creator)
		{
			Type = type;
			Implementation = implementation;
			Behaviors = behaviors;
			MetaInitializers = metaInitializers;
			Initializers = initializers;
			Properties = properties;
			Factory = factory;
			this.creator = creator;
			InitializeMeta();
		}

		public PropertyDescriptor CreateDescriptor()
		{
			IDictionaryMetaInitializer[] metaInitializers = MetaInitializers;
			List<object> list = CollectSharedBehaviors(Behaviors, metaInitializers);
			List<IDictionaryInitializer> list2 = CollectSharedBehaviors(Initializers, metaInitializers);
			PropertyDescriptor propertyDescriptor = ((list != null) ? new PropertyDescriptor(list.ToArray()) : new PropertyDescriptor());
			IDictionaryBehavior[] behaviors = metaInitializers;
			propertyDescriptor.AddBehaviors(behaviors);
			if (list2 != null)
			{
				propertyDescriptor.AddBehaviors(list2);
			}
			return propertyDescriptor;
		}

		private static List<T> CollectSharedBehaviors<T>(T[] source, IDictionaryMetaInitializer[] predicates)
		{
			List<T> list = null;
			foreach (T val in source)
			{
				for (int j = 0; j < predicates.Length; j++)
				{
					if (predicates[j].ShouldHaveBehavior(val))
					{
						if (list == null)
						{
							list = new List<T>(source.Length);
						}
						list.Add(val);
						break;
					}
				}
			}
			return list;
		}

		public DictionaryAdapterMeta GetAdapterMeta(Type type)
		{
			return Factory.GetAdapterMeta(type, this);
		}

		public object CreateInstance(IDictionary dictionary, PropertyDescriptor descriptor)
		{
			DictionaryAdapterInstance arg = new DictionaryAdapterInstance(dictionary, this, descriptor, Factory);
			return creator(arg);
		}

		private void InitializeMeta()
		{
			IDictionaryMetaInitializer[] metaInitializers = MetaInitializers;
			for (int i = 0; i < metaInitializers.Length; i++)
			{
				metaInitializers[i].Initialize(Factory, this);
			}
		}
	}
}
