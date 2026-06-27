using System;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public class BindingListInitializer<T> : IValueInitializer
	{
		private class SuppressListChangedEvents : IDisposable
		{
			private readonly bool raiseEvents;

			private readonly System.ComponentModel.BindingList<T> bindingList;

			public SuppressListChangedEvents(System.ComponentModel.BindingList<T> bindingList)
			{
				this.bindingList = bindingList;
				raiseEvents = this.bindingList.RaiseListChangedEvents;
				this.bindingList.RaiseListChangedEvents = false;
			}

			public void Dispose()
			{
				bindingList.RaiseListChangedEvents = raiseEvents;
			}
		}

		private readonly Func<object> addNew;

		private readonly Func<int, object, object> addAt;

		private readonly Func<int, object, object> setAt;

		private readonly Action<int> removeAt;

		private readonly Action reset;

		private bool addingNew;

		public BindingListInitializer(Func<int, object, object> addAt, Func<object> addNew, Func<int, object, object> setAt, Action<int> removeAt, Action reset)
		{
			this.addAt = addAt;
			this.addNew = addNew;
			this.setAt = setAt;
			this.removeAt = removeAt;
			this.reset = reset;
		}

		public void Initialize(IDictionaryAdapter dictionaryAdapter, object value)
		{
			System.ComponentModel.BindingList<T> bindingList = (System.ComponentModel.BindingList<T>)value;
			if (addNew != null)
			{
				bindingList.AddingNew += delegate(object sender, AddingNewEventArgs args)
				{
					args.NewObject = addNew();
					addingNew = true;
				};
			}
			bindingList.ListChanged += delegate(object sender, ListChangedEventArgs args)
			{
				switch (args.ListChangedType)
				{
				case ListChangedType.ItemAdded:
					if (!addingNew && addAt != null)
					{
						object obj2 = addAt(args.NewIndex, bindingList[args.NewIndex]);
						if (obj2 != null)
						{
							using (new SuppressListChangedEvents(bindingList))
							{
								bindingList[args.NewIndex] = (T)obj2;
							}
						}
					}
					addingNew = false;
					break;
				case ListChangedType.ItemChanged:
					if (setAt != null)
					{
						object obj = setAt(args.NewIndex, bindingList[args.NewIndex]);
						if (obj != null)
						{
							using (new SuppressListChangedEvents(bindingList))
							{
								bindingList[args.NewIndex] = (T)obj;
								break;
							}
						}
					}
					break;
				case ListChangedType.ItemDeleted:
					if (removeAt != null)
					{
						removeAt(args.NewIndex);
					}
					break;
				case ListChangedType.Reset:
					if (reset != null)
					{
						reset();
					}
					break;
				case ListChangedType.ItemMoved:
					break;
				}
			};
		}
	}
}
