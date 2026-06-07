using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DV.Util
{
	public class ObservableCollectionExt<T> : ObservableCollection<T>
	{
		public ObservableCollectionExt()
		{
		}

		public ObservableCollectionExt(IEnumerable<T> collection)
			: base(collection)
		{
		}

		public ObservableCollectionExt(List<T> list)
			: base(list)
		{
		}

		public void AddRange(IEnumerable<T> collection)
		{
			CheckReentrancy();
			int count = base.Items.Count;
			List<T> list = ((collection is List<T> list2) ? list2 : new List<T>(collection));
			foreach (T item in list)
			{
				base.Items.Add(item);
			}
			OnPropertyChanged(new PropertyChangedEventArgs("Count"));
			OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, list, count));
		}

		public void Reset(IEnumerable<T> range)
		{
			CheckReentrancy();
			base.Items.Clear();
			foreach (T item in range)
			{
				base.Items.Add(item);
			}
			OnPropertyChanged(new PropertyChangedEventArgs("Count"));
			OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
			CheckReentrancy();
			int num = index;
			List<T> list = ((collection is List<T> list2) ? list2 : new List<T>(collection));
			foreach (T item in list)
			{
				base.Items.Insert(num, item);
				num++;
			}
			OnPropertyChanged(new PropertyChangedEventArgs("Count"));
			OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, list, index));
		}
	}
}
