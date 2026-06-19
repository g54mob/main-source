using System.Collections.Specialized;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ListView : UIView
	{
		private ObservableList<ListItemViewModel> items;

		public Transform content;

		public GameObject itemTemplate;

		public ObservableList<ListItemViewModel> Items
		{
			get
			{
				return items;
			}
			set
			{
				if (items != value)
				{
					if (items != null)
					{
						items.CollectionChanged -= OnCollectionChanged;
					}
					items = value;
					OnItemsChanged();
					if (items != null)
					{
						items.CollectionChanged += OnCollectionChanged;
					}
				}
			}
		}

		protected override void OnDestroy()
		{
			if (items != null)
			{
				items.CollectionChanged -= OnCollectionChanged;
			}
		}

		protected void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			switch (eventArgs.Action)
			{
			case NotifyCollectionChangedAction.Add:
				AddItem(eventArgs.NewStartingIndex, eventArgs.NewItems[0]);
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

		protected virtual void OnItemsChanged()
		{
			for (int num = content.childCount - 1; num >= 0; num--)
			{
				Object.Destroy(content.GetChild(num).gameObject);
			}
			for (int i = 0; i < items.Count; i++)
			{
				AddItem(i, items[i]);
			}
		}

		protected virtual void AddItem(int index, object item)
		{
			Debug.Log("Adding view item");
			GameObject obj = Object.Instantiate(itemTemplate);
			obj.transform.SetParent(content, worldPositionStays: false);
			obj.transform.SetSiblingIndex(index);
			obj.SetActive(value: true);
			obj.GetComponent<UIView>().SetDataContext(item);
		}

		protected virtual void RemoveItem(int index, object item)
		{
			UIView component = content.GetChild(index).GetComponent<UIView>();
			if (component.GetDataContext() == item)
			{
				component.gameObject.SetActive(value: false);
				Object.Destroy(component.gameObject);
			}
		}

		protected virtual void ReplaceItem(int index, object oldItem, object item)
		{
			UIView component = content.GetChild(index).GetComponent<UIView>();
			if (component.GetDataContext() == oldItem)
			{
				component.SetDataContext(item);
			}
		}

		protected virtual void MoveItem(int oldIndex, int index, object item)
		{
			content.GetChild(oldIndex).GetComponent<UIView>().transform.SetSiblingIndex(index);
		}

		protected virtual void ResetItem()
		{
			for (int num = content.childCount - 1; num >= 0; num--)
			{
				Object.Destroy(content.GetChild(num).gameObject);
			}
		}
	}
}
