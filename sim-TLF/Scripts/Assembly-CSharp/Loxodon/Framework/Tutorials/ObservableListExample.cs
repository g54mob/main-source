using System.Collections.Specialized;
using Loxodon.Framework.Observables;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ObservableListExample : MonoBehaviour
	{
		private ObservableList<Item> list;

		protected void Start()
		{
			list = new ObservableList<Item>();
			list.CollectionChanged += OnCollectionChanged;
			list.Add(new Item
			{
				Title = "title1",
				IconPath = "xxx/xxx/icon1.png",
				Content = "this is a test."
			});
			list[0] = new Item
			{
				Title = "title2",
				IconPath = "xxx/xxx/icon2.png",
				Content = "this is a test."
			};
			list.Clear();
		}

		protected void OnDestroy()
		{
			if (list != null)
			{
				list.CollectionChanged -= OnCollectionChanged;
				list = null;
			}
		}

		protected void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			switch (eventArgs.Action)
			{
			case NotifyCollectionChangedAction.Add:
			{
				foreach (Item newItem in eventArgs.NewItems)
				{
					Debug.LogFormat("ADD item:{0}", newItem);
				}
				break;
			}
			case NotifyCollectionChangedAction.Remove:
			{
				foreach (Item oldItem in eventArgs.OldItems)
				{
					Debug.LogFormat("REMOVE item:{0}", oldItem);
				}
				break;
			}
			case NotifyCollectionChangedAction.Replace:
				foreach (Item oldItem2 in eventArgs.OldItems)
				{
					Debug.LogFormat("REPLACE before item:{0}", oldItem2);
				}
				{
					foreach (Item newItem2 in eventArgs.NewItems)
					{
						Debug.LogFormat("REPLACE after item:{0}", newItem2);
					}
					break;
				}
			case NotifyCollectionChangedAction.Reset:
				Debug.LogFormat("RESET");
				break;
			case NotifyCollectionChangedAction.Move:
				break;
			}
		}
	}
}
