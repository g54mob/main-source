using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public interface IBindingList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IBindingListSource, ICancelAddNew, IRaiseItemChangedEvents
	{
		bool AllowNew { get; }

		bool AllowEdit { get; }

		bool AllowRemove { get; }

		bool SupportsChangeNotification { get; }

		bool SupportsSearching { get; }

		bool SupportsSorting { get; }

		bool IsSorted { get; }

		System.ComponentModel.PropertyDescriptor SortProperty { get; }

		ListSortDirection SortDirection { get; }

		event ListChangedEventHandler ListChanged;

		T AddNew();

		int Find(System.ComponentModel.PropertyDescriptor property, object key);

		void AddIndex(System.ComponentModel.PropertyDescriptor property);

		void RemoveIndex(System.ComponentModel.PropertyDescriptor property);

		void ApplySort(System.ComponentModel.PropertyDescriptor property, ListSortDirection direction);

		void RemoveSort();
	}
}
