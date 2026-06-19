using System.Collections.Generic;
using System.Collections.Specialized;
using Loxodon.Framework.Observables;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ObservableDictionaryExample : MonoBehaviour
	{
		private ObservableDictionary<int, Item> dict;

		protected void Start()
		{
			dict = new ObservableDictionary<int, Item>();
			dict.CollectionChanged += OnCollectionChanged;
			dict.Add(1, new Item
			{
				Title = "title1",
				IconPath = "xxx/xxx/icon1.png",
				Content = "this is a test."
			});
			dict.Add(2, new Item
			{
				Title = "title2",
				IconPath = "xxx/xxx/icon2.png",
				Content = "this is a test."
			});
			dict.Remove(1);
			dict.Clear();
		}

		protected void OnDestroy()
		{
			if (dict != null)
			{
				dict.CollectionChanged -= OnCollectionChanged;
				dict = null;
			}
		}

		protected void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			switch (eventArgs.Action)
			{
			case NotifyCollectionChangedAction.Add:
			{
				foreach (KeyValuePair<int, Item> newItem in eventArgs.NewItems)
				{
					Debug.LogFormat("ADD key:{0} item:{1}", newItem.Key, newItem.Value);
				}
				break;
			}
			case NotifyCollectionChangedAction.Remove:
			{
				foreach (KeyValuePair<int, Item> oldItem in eventArgs.OldItems)
				{
					Debug.LogFormat("REMOVE key:{0} item:{1}", oldItem.Key, oldItem.Value);
				}
				break;
			}
			case NotifyCollectionChangedAction.Replace:
				foreach (KeyValuePair<int, Item> oldItem2 in eventArgs.OldItems)
				{
					Debug.LogFormat("REPLACE before key:{0} item:{1}", oldItem2.Key, oldItem2.Value);
				}
				{
					foreach (KeyValuePair<int, Item> newItem2 in eventArgs.NewItems)
					{
						Debug.LogFormat("REPLACE after key:{0} item:{1}", newItem2.Key, newItem2.Value);
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
