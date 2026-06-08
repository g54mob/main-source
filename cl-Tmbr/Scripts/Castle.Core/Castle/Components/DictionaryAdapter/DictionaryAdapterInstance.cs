using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Castle.Components.DictionaryAdapter
{
	public class DictionaryAdapterInstance
	{
		private IDictionary extendedProperties;

		private List<IDictionaryCopyStrategy> copyStrategies;

		private static readonly IDictionaryInitializer[] NoInitializers = new IDictionaryInitializer[0];

		internal int? OldHashCode { get; set; }

		public IDictionary Dictionary { get; private set; }

		public PropertyDescriptor Descriptor { get; private set; }

		public IDictionaryAdapterFactory Factory { get; private set; }

		public IDictionaryInitializer[] Initializers { get; private set; }

		public IDictionary<string, PropertyDescriptor> Properties { get; private set; }

		public IDictionaryEqualityHashCodeStrategy EqualityHashCodeStrategy { get; set; }

		public IDictionaryCreateStrategy CreateStrategy { get; set; }

		public IDictionaryCoerceStrategy CoerceStrategy { get; set; }

		public IEnumerable<IDictionaryCopyStrategy> CopyStrategies
		{
			get
			{
				IEnumerable<IDictionaryCopyStrategy> enumerable = copyStrategies;
				return enumerable ?? Enumerable.Empty<IDictionaryCopyStrategy>();
			}
		}

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

		public DictionaryAdapterInstance(IDictionary dictionary, DictionaryAdapterMeta meta, PropertyDescriptor descriptor, IDictionaryAdapterFactory factory)
		{
			Dictionary = dictionary;
			Descriptor = descriptor;
			Factory = factory;
			List<IDictionaryBehavior> behaviorsInternal;
			if (descriptor == null || (behaviorsInternal = descriptor.BehaviorsInternal) == null)
			{
				Initializers = meta.Initializers;
				Properties = MergeProperties(meta.Properties);
			}
			else
			{
				Initializers = MergeInitializers(meta.Initializers, behaviorsInternal);
				Properties = MergeProperties(meta.Properties, behaviorsInternal);
			}
		}

		public void AddCopyStrategy(IDictionaryCopyStrategy copyStrategy)
		{
			if (copyStrategy == null)
			{
				throw new ArgumentNullException("copyStrategy");
			}
			if (copyStrategies == null)
			{
				copyStrategies = new List<IDictionaryCopyStrategy>();
			}
			copyStrategies.Add(copyStrategy);
		}

		private static IDictionaryInitializer[] MergeInitializers(IDictionaryInitializer[] source, List<IDictionaryBehavior> behaviors)
		{
			List<IDictionaryInitializer> dictionaryBehaviors = null;
			int num = source.Length;
			for (int i = 0; i < num; i++)
			{
				PropertyDescriptor.MergeBehavior(ref dictionaryBehaviors, source[i]);
			}
			num = behaviors.Count;
			for (int i = 0; i < num; i++)
			{
				if (behaviors[i] is IDictionaryInitializer behavior)
				{
					PropertyDescriptor.MergeBehavior(ref dictionaryBehaviors, behavior);
				}
			}
			if (dictionaryBehaviors != null)
			{
				return dictionaryBehaviors.ToArray();
			}
			return NoInitializers;
		}

		private static IDictionary<string, PropertyDescriptor> MergeProperties(IDictionary<string, PropertyDescriptor> source)
		{
			Dictionary<string, PropertyDescriptor> dictionary = new Dictionary<string, PropertyDescriptor>();
			foreach (KeyValuePair<string, PropertyDescriptor> item in source)
			{
				dictionary[item.Key] = new PropertyDescriptor(item.Value, copyBehaviors: true);
			}
			return dictionary;
		}

		private static IDictionary<string, PropertyDescriptor> MergeProperties(IDictionary<string, PropertyDescriptor> source, List<IDictionaryBehavior> behaviors)
		{
			int count = behaviors.Count;
			Dictionary<string, PropertyDescriptor> dictionary = new Dictionary<string, PropertyDescriptor>();
			foreach (KeyValuePair<string, PropertyDescriptor> item in source)
			{
				PropertyDescriptor propertyDescriptor = new PropertyDescriptor(item.Value, copyBehaviors: true);
				for (int i = 0; i < count; i++)
				{
					propertyDescriptor.AddBehavior(behaviors[i]);
				}
				dictionary[item.Key] = propertyDescriptor;
			}
			return dictionary;
		}
	}
}
