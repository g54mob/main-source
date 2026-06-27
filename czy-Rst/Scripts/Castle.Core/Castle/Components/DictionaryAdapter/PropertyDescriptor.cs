using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;

namespace Castle.Components.DictionaryAdapter
{
	[DebuggerDisplay("{Property.DeclaringType.FullName,nq}.{PropertyName,nq}")]
	public class PropertyDescriptor : IDictionaryKeyBuilder, IDictionaryBehavior, IDictionaryPropertyGetter, IDictionaryPropertySetter
	{
		private IDictionary state;

		private Dictionary<object, object> extendedProperties;

		protected List<IDictionaryBehavior> dictionaryBehaviors;

		private static readonly object[] NoAnnotations = new object[0];

		public int ExecutionOrder => 0;

		public string PropertyName
		{
			get
			{
				if (!(Property != null))
				{
					return null;
				}
				return Property.Name;
			}
		}

		public Type PropertyType
		{
			get
			{
				if (!(Property != null))
				{
					return null;
				}
				return Property.PropertyType;
			}
		}

		public PropertyInfo Property { get; private set; }

		public bool IsDynamicProperty { get; private set; }

		public IDictionary State => state ?? (state = new Dictionary<object, object>());

		public bool Fetch { get; set; }

		public bool IfExists { get; set; }

		public bool SuppressNotifications { get; set; }

		public object[] Annotations { get; private set; }

		public TypeConverter TypeConverter { get; private set; }

		public IDictionary ExtendedProperties => extendedProperties ?? (extendedProperties = new Dictionary<object, object>());

		public IEnumerable<IDictionaryBehavior> Behaviors
		{
			get
			{
				IEnumerable<IDictionaryBehavior> enumerable = dictionaryBehaviors;
				return enumerable ?? Enumerable.Empty<IDictionaryBehavior>();
			}
		}

		internal List<IDictionaryBehavior> BehaviorsInternal => dictionaryBehaviors;

		public IEnumerable<IDictionaryKeyBuilder> KeyBuilders
		{
			get
			{
				if (dictionaryBehaviors == null)
				{
					return Enumerable.Empty<IDictionaryKeyBuilder>();
				}
				return dictionaryBehaviors.OfType<IDictionaryKeyBuilder>();
			}
		}

		public IEnumerable<IDictionaryPropertySetter> Setters
		{
			get
			{
				if (dictionaryBehaviors == null)
				{
					return Enumerable.Empty<IDictionaryPropertySetter>();
				}
				return dictionaryBehaviors.OfType<IDictionaryPropertySetter>();
			}
		}

		public IEnumerable<IDictionaryPropertyGetter> Getters
		{
			get
			{
				if (dictionaryBehaviors == null)
				{
					return Enumerable.Empty<IDictionaryPropertyGetter>();
				}
				return dictionaryBehaviors.OfType<IDictionaryPropertyGetter>();
			}
		}

		public IEnumerable<IDictionaryInitializer> Initializers
		{
			get
			{
				if (dictionaryBehaviors == null)
				{
					return Enumerable.Empty<IDictionaryInitializer>();
				}
				return dictionaryBehaviors.OfType<IDictionaryInitializer>();
			}
		}

		public IEnumerable<IDictionaryMetaInitializer> MetaInitializers
		{
			get
			{
				if (dictionaryBehaviors == null)
				{
					return Enumerable.Empty<IDictionaryMetaInitializer>();
				}
				return dictionaryBehaviors.OfType<IDictionaryMetaInitializer>();
			}
		}

		public PropertyDescriptor()
		{
			Annotations = NoAnnotations;
		}

		public PropertyDescriptor(PropertyInfo property, object[] annotations)
			: this()
		{
			Property = property;
			Annotations = annotations ?? NoAnnotations;
			IsDynamicProperty = typeof(IDynamicValue).IsAssignableFrom(property.PropertyType);
			ObtainTypeConverter();
		}

		public PropertyDescriptor(object[] annotations)
		{
			Annotations = annotations ?? NoAnnotations;
		}

		public PropertyDescriptor(PropertyDescriptor source, bool copyBehaviors)
		{
			Property = source.Property;
			Annotations = source.Annotations;
			IsDynamicProperty = source.IsDynamicProperty;
			TypeConverter = source.TypeConverter;
			SuppressNotifications = source.SuppressNotifications;
			state = source.state;
			IfExists = source.IfExists;
			Fetch = source.Fetch;
			if (source.extendedProperties != null)
			{
				extendedProperties = new Dictionary<object, object>(source.extendedProperties);
			}
			if (copyBehaviors && source.dictionaryBehaviors != null)
			{
				dictionaryBehaviors = new List<IDictionaryBehavior>(source.dictionaryBehaviors);
			}
		}

		public string GetKey(IDictionaryAdapter dictionaryAdapter, string key, PropertyDescriptor descriptor)
		{
			List<IDictionaryBehavior> list = dictionaryBehaviors;
			if (list != null)
			{
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					if (list[i] is IDictionaryKeyBuilder dictionaryKeyBuilder)
					{
						key = dictionaryKeyBuilder.GetKey(dictionaryAdapter, key, this);
					}
				}
			}
			return key;
		}

		public object GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor descriptor, bool ifExists)
		{
			key = GetKey(dictionaryAdapter, key, descriptor);
			storedValue = storedValue ?? dictionaryAdapter.ReadProperty(key);
			List<IDictionaryBehavior> list = dictionaryBehaviors;
			if (list != null)
			{
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					if (list[i] is IDictionaryPropertyGetter dictionaryPropertyGetter)
					{
						storedValue = dictionaryPropertyGetter.GetPropertyValue(dictionaryAdapter, key, storedValue, this, IfExists || ifExists);
					}
				}
			}
			return storedValue;
		}

		public bool SetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, ref object value, PropertyDescriptor descriptor)
		{
			key = GetKey(dictionaryAdapter, key, descriptor);
			List<IDictionaryBehavior> list = dictionaryBehaviors;
			if (list != null)
			{
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					if (list[i] is IDictionaryPropertySetter dictionaryPropertySetter && !dictionaryPropertySetter.SetPropertyValue(dictionaryAdapter, key, ref value, this))
					{
						return false;
					}
				}
			}
			dictionaryAdapter.StoreProperty(this, key, value);
			return true;
		}

		public PropertyDescriptor AddBehavior(IDictionaryBehavior behavior)
		{
			if (behavior == null)
			{
				return this;
			}
			if (!(behavior is IDictionaryBehaviorBuilder dictionaryBehaviorBuilder))
			{
				MergeBehavior(ref dictionaryBehaviors, behavior);
			}
			else
			{
				object[] array = dictionaryBehaviorBuilder.BuildBehaviors();
				foreach (object obj in array)
				{
					AddBehavior(obj as IDictionaryBehavior);
				}
			}
			return this;
		}

		public static void MergeBehavior<T>(ref List<T> dictionaryBehaviors, T behavior) where T : class, IDictionaryBehavior
		{
			List<T> list = dictionaryBehaviors;
			if (list == null)
			{
				list = new List<T>();
				list.Add(behavior);
				dictionaryBehaviors = list;
				return;
			}
			int num = 0;
			int executionOrder = behavior.ExecutionOrder;
			int count = list.Count;
			IDictionaryBehavior dictionaryBehavior;
			int executionOrder2;
			while (true)
			{
				dictionaryBehavior = list[num];
				executionOrder2 = dictionaryBehavior.ExecutionOrder;
				if (executionOrder2 >= executionOrder)
				{
					break;
				}
				if (++num == count)
				{
					list.Add(behavior);
					return;
				}
			}
			while (executionOrder2 == executionOrder)
			{
				if (dictionaryBehavior == behavior)
				{
					return;
				}
				if (++num == count)
				{
					list.Add(behavior);
					return;
				}
				dictionaryBehavior = list[num];
				executionOrder2 = dictionaryBehavior.ExecutionOrder;
			}
			list.Insert(num, behavior);
		}

		public PropertyDescriptor AddBehaviors(params IDictionaryBehavior[] behaviors)
		{
			foreach (IDictionaryBehavior behavior in behaviors)
			{
				AddBehavior(behavior);
			}
			return this;
		}

		public PropertyDescriptor AddBehaviors(IEnumerable<IDictionaryBehavior> behaviors)
		{
			if (behaviors != null)
			{
				foreach (IDictionaryBehavior behavior in behaviors)
				{
					AddBehavior(behavior);
				}
			}
			return this;
		}

		public PropertyDescriptor CopyBehaviors(PropertyDescriptor other)
		{
			List<IDictionaryBehavior> list = dictionaryBehaviors;
			if (list != null)
			{
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					IDictionaryBehavior dictionaryBehavior = list[i].Copy();
					if (dictionaryBehavior != null)
					{
						other.AddBehavior(dictionaryBehavior);
					}
				}
			}
			return this;
		}

		public IDictionaryBehavior Copy()
		{
			return new PropertyDescriptor(this, copyBehaviors: true);
		}

		private void ObtainTypeConverter()
		{
			Type typeConverter = AttributesUtil.GetTypeConverter(Property);
			TypeConverter = ((typeConverter != null) ? ((TypeConverter)Activator.CreateInstance(typeConverter)) : TypeDescriptor.GetConverter(PropertyType));
		}
	}
}
