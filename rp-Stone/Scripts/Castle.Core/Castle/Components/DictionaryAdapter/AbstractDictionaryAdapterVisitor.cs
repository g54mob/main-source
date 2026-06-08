using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Castle.Core;

namespace Castle.Components.DictionaryAdapter
{
	public abstract class AbstractDictionaryAdapterVisitor : IDictionaryAdapterVisitor
	{
		private readonly Dictionary<IDictionaryAdapter, int> scopes;

		protected bool Cancelled { get; set; }

		protected AbstractDictionaryAdapterVisitor()
		{
			scopes = new Dictionary<IDictionaryAdapter, int>(ReferenceEqualityComparer<IDictionaryAdapter>.Instance);
		}

		protected AbstractDictionaryAdapterVisitor(AbstractDictionaryAdapterVisitor parent)
		{
			scopes = parent.scopes;
		}

		public virtual bool VisitDictionaryAdapter(IDictionaryAdapter dictionaryAdapter, object state)
		{
			return VisitDictionaryAdapter(dictionaryAdapter, null, null);
		}

		public virtual bool VisitDictionaryAdapter(IDictionaryAdapter dictionaryAdapter, Func<PropertyDescriptor, bool> selector, object state)
		{
			if (!PushScope(dictionaryAdapter))
			{
				return false;
			}
			try
			{
				foreach (PropertyDescriptor value in dictionaryAdapter.This.Properties.Values)
				{
					if (Cancelled)
					{
						break;
					}
					if (selector == null || selector(value))
					{
						if (IsCollection(value, out var collectionItemType))
						{
							VisitCollection(dictionaryAdapter, value, collectionItemType, state);
						}
						else if (value.PropertyType.GetTypeInfo().IsInterface)
						{
							VisitInterface(dictionaryAdapter, value, state);
						}
						else
						{
							VisitProperty(dictionaryAdapter, value, state);
						}
					}
				}
			}
			finally
			{
				PopScope(dictionaryAdapter);
			}
			return true;
		}

		void IDictionaryAdapterVisitor.VisitProperty(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, object state)
		{
			VisitProperty(dictionaryAdapter, property, state);
		}

		protected virtual void VisitProperty(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, object state)
		{
		}

		void IDictionaryAdapterVisitor.VisitInterface(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, object state)
		{
			VisitInterface(dictionaryAdapter, property, state);
		}

		protected virtual void VisitInterface(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, object state)
		{
			VisitProperty(dictionaryAdapter, property, state);
		}

		void IDictionaryAdapterVisitor.VisitCollection(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, Type collectionItemType, object state)
		{
			VisitCollection(dictionaryAdapter, property, collectionItemType, state);
		}

		protected virtual void VisitCollection(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, Type collectionItemType, object state)
		{
			VisitProperty(dictionaryAdapter, property, state);
		}

		private bool PushScope(IDictionaryAdapter dictionaryAdapter)
		{
			if (scopes.ContainsKey(dictionaryAdapter))
			{
				return false;
			}
			scopes.Add(dictionaryAdapter, 0);
			return true;
		}

		private void PopScope(IDictionaryAdapter dictionaryAdapter)
		{
			scopes.Remove(dictionaryAdapter);
		}

		private static bool IsCollection(PropertyDescriptor property, out Type collectionItemType)
		{
			collectionItemType = null;
			Type propertyType = property.PropertyType;
			if (propertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(propertyType))
			{
				if (propertyType.GetTypeInfo().IsArray)
				{
					collectionItemType = propertyType.GetElementType();
				}
				else if (propertyType.GetTypeInfo().IsGenericType)
				{
					Type[] genericArguments = propertyType.GetGenericArguments();
					collectionItemType = genericArguments[0];
				}
				else
				{
					collectionItemType = typeof(object);
				}
				return true;
			}
			return false;
		}
	}
}
