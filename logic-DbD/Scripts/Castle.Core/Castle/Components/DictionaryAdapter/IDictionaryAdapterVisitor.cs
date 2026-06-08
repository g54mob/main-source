using System;

namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryAdapterVisitor
	{
		bool VisitDictionaryAdapter(IDictionaryAdapter dictionaryAdapter, object state);

		bool VisitDictionaryAdapter(IDictionaryAdapter dictionaryAdapter, Func<PropertyDescriptor, bool> selector, object state);

		void VisitProperty(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, object state);

		void VisitInterface(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, object state);

		void VisitCollection(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, Type collectionItemType, object state);
	}
}
