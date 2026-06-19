using System;
using System.Collections.Specialized;

namespace Loxodon.Framework.Observables
{
	public static class ObservableListExtensions
	{
		private class ObservableListWrapper<From, To> : ObservableList<To>, IDisposable
		{
			private readonly IConverter<From, To> converter;

			private readonly ObservableList<From> list;

			private bool disposedValue;

			public ObservableListWrapper(ObservableList<From> list, IConverter<From, To> converter)
			{
				this.list = list;
				this.converter = converter;
				foreach (From item in list)
				{
					AddItem(converter.Create(item));
				}
				if (this.list != null)
				{
					this.list.CollectionChanged += OnCollectionChanged;
				}
			}

			protected override bool ReadOnly()
			{
				return true;
			}

			private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
			{
				switch (eventArgs.Action)
				{
				case NotifyCollectionChangedAction.Add:
					InsertItem(eventArgs.NewStartingIndex, eventArgs.NewItems[0]);
					break;
				case NotifyCollectionChangedAction.Remove:
					RemoveItem(eventArgs.OldStartingIndex, eventArgs.OldItems[0]);
					break;
				case NotifyCollectionChangedAction.Replace:
					ReplaceItem(eventArgs.OldStartingIndex, eventArgs.OldItems[0], eventArgs.NewItems[0]);
					break;
				case NotifyCollectionChangedAction.Reset:
					ResetItem();
					break;
				case NotifyCollectionChangedAction.Move:
					MoveItem(eventArgs.OldStartingIndex, eventArgs.NewStartingIndex, eventArgs.NewItems[0]);
					break;
				}
			}

			private void InsertItem(int index, object item)
			{
				To item2 = converter.Create((From)item);
				base.InsertItem(index, item2);
			}

			private void RemoveItem(int index, object item)
			{
				base.RemoveItem(index);
			}

			private void ReplaceItem(int index, object oldItem, object item)
			{
				To to = base[index];
				converter.Update((From)item, to);
			}

			private void MoveItem(int oldIndex, int index, object item)
			{
				base.MoveItem(oldIndex, index);
			}

			private void ResetItem()
			{
				base.ClearItems();
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!disposedValue)
				{
					if (list != null)
					{
						list.CollectionChanged -= OnCollectionChanged;
					}
					disposedValue = true;
				}
			}

			~ObservableListWrapper()
			{
				Dispose(disposing: false);
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		}

		public static ObservableList<To> ToList<From, To>(this ObservableList<From> list, IConverter<From, To> converter)
		{
			return new ObservableListWrapper<From, To>(list, converter);
		}
	}
}
