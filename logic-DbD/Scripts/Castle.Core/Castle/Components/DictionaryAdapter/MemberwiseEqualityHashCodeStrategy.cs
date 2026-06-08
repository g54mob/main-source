using System;
using System.Collections;
using System.Collections.Generic;

namespace Castle.Components.DictionaryAdapter
{
	public class MemberwiseEqualityHashCodeStrategy : DictionaryBehaviorAttribute, IDictionaryEqualityHashCodeStrategy, IDictionaryInitializer, IDictionaryBehavior, IEqualityComparer<IDictionaryAdapter>
	{
		private class HashCodeVisitor : AbstractDictionaryAdapterVisitor
		{
			private int hashCode;

			public int CalculateHashCode(IDictionaryAdapter dictionaryAdapter)
			{
				if (dictionaryAdapter == null)
				{
					return 0;
				}
				hashCode = 27;
				if (!VisitDictionaryAdapter(dictionaryAdapter, null))
				{
					return 0;
				}
				return hashCode;
			}

			protected override void VisitProperty(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, object state)
			{
				object property2 = dictionaryAdapter.GetProperty(property.PropertyName, ifExists: true);
				CollectHashCode(property, GetValueHashCode(property2));
			}

			protected override void VisitInterface(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, object state)
			{
				IDictionaryAdapter nested = (IDictionaryAdapter)dictionaryAdapter.GetProperty(property.PropertyName, ifExists: true);
				CollectHashCode(property, GetNestedHashCode(nested));
			}

			protected override void VisitCollection(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, Type collectionItemType, object state)
			{
				IEnumerable collection = (IEnumerable)dictionaryAdapter.GetProperty(property.PropertyName, ifExists: true);
				CollectHashCode(property, GetCollectionHashcode(collection));
			}

			private int GetValueHashCode(object value)
			{
				if (value == null)
				{
					return 0;
				}
				if (value is IDictionaryAdapter)
				{
					return GetNestedHashCode((IDictionaryAdapter)value);
				}
				if (value is IEnumerable && !(value is string))
				{
					return GetCollectionHashcode((IEnumerable)value);
				}
				return value.GetHashCode();
			}

			private int GetNestedHashCode(IDictionaryAdapter nested)
			{
				int num = hashCode;
				int result = CalculateHashCode(nested);
				hashCode = num;
				return result;
			}

			private int GetCollectionHashcode(IEnumerable collection)
			{
				if (collection == null)
				{
					return 0;
				}
				int num = 0;
				foreach (object item in collection)
				{
					int valueHashCode = GetValueHashCode(item);
					num = 13 * num + valueHashCode;
				}
				return num;
			}

			private void CollectHashCode(PropertyDescriptor property, int valueHashCode)
			{
				hashCode = 13 * hashCode + property.PropertyName.GetHashCode();
				hashCode = 13 * hashCode + valueHashCode;
			}
		}

		public bool Equals(IDictionaryAdapter adapter1, IDictionaryAdapter adapter2)
		{
			if (adapter1 == adapter2)
			{
				return true;
			}
			if ((adapter1 == null) ^ (adapter2 == null))
			{
				return false;
			}
			if (adapter1.Meta.Type != adapter2.Meta.Type)
			{
				return false;
			}
			return GetHashCode(adapter1) == GetHashCode(adapter2);
		}

		public int GetHashCode(IDictionaryAdapter adapter)
		{
			GetHashCode(adapter, out var hashCode);
			return hashCode;
		}

		public bool GetHashCode(IDictionaryAdapter adapter, out int hashCode)
		{
			hashCode = new HashCodeVisitor().CalculateHashCode(adapter);
			return true;
		}

		void IDictionaryInitializer.Initialize(IDictionaryAdapter dictionaryAdapter, object[] behaviors)
		{
			dictionaryAdapter.This.EqualityHashCodeStrategy = this;
		}
	}
}
