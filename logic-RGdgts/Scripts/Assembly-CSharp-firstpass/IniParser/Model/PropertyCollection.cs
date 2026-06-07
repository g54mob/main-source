using System.Collections;
using System.Collections.Generic;

namespace IniParser.Model
{
	public class PropertyCollection : IDeepCloneable<PropertyCollection>, IEnumerable<Property>, IEnumerable
	{
		private Property _lastAdded;

		private readonly Dictionary<string, Property> _properties;

		private readonly IEqualityComparer<string> _searchComparer;

		public string Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Count => 0;

		public PropertyCollection()
		{
		}

		public PropertyCollection(IEqualityComparer<string> searchComparer)
		{
		}

		public PropertyCollection(PropertyCollection ori, IEqualityComparer<string> searchComparer)
		{
		}

		public bool Add(string key)
		{
			return false;
		}

		public bool Add(Property property)
		{
			return false;
		}

		public bool Add(string key, string value)
		{
			return false;
		}

		public void ClearComments()
		{
		}

		public bool Contains(string keyName)
		{
			return false;
		}

		public Property FindByKey(string keyName)
		{
			return null;
		}

		public void Merge(PropertyCollection propertyToMerge)
		{
		}

		public void Clear()
		{
		}

		public bool Remove(string keyName)
		{
			return false;
		}

		public IEnumerator<Property> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public PropertyCollection DeepClone()
		{
			return null;
		}

		internal void AddPropertyInternal(Property property)
		{
		}

		internal Property GetLast()
		{
			return null;
		}
	}
}
