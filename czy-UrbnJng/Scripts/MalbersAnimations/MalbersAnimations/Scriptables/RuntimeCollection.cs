using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Scriptables
{
	public abstract class RuntimeCollection<T> : ScriptableObject where T : Object
	{
		public List<T> items = new List<T>();

		public string Description;

		public UnityEvent OnSetEmpty = new UnityEvent();

		public bool debug;

		public int Count => items.Count;

		public List<T> Items
		{
			get
			{
				return items;
			}
			set
			{
				items = value;
			}
		}

		public bool IsEmpty
		{
			get
			{
				if (items != null)
				{
					return items.Count == 0;
				}
				return true;
			}
		}

		public T this[int index]
		{
			get
			{
				return Items[index];
			}
			set
			{
				Items[index] = value;
			}
		}

		public virtual void Clear()
		{
			items = new List<T>();
			OnSetEmpty.Invoke();
			Debugging("Clear");
		}

		public virtual T Item_Get(int index)
		{
			return items[index % items.Count];
		}

		public virtual T Item_GetFirst()
		{
			return items[0];
		}

		public virtual T Item_Get(string name)
		{
			return items.Find((T x) => x.name == name);
		}

		public virtual bool Has_Item(T obj)
		{
			return items.Contains(obj);
		}

		public virtual int Item_Index(T obj)
		{
			return items.IndexOf(obj);
		}

		public virtual T Item_GetRandom()
		{
			if (items != null && items.Count > 0)
			{
				return items[Random.Range(0, items.Count)];
			}
			return null;
		}

		public virtual void Item_Add(T newItem)
		{
			if (newItem != null)
			{
				items.RemoveAll((T x) => x == null);
				if (!items.Contains(newItem))
				{
					items.Add(newItem);
					OnAddEvent(newItem);
					Debugging("Add [" + newItem.name + "]");
				}
			}
		}

		public void Debugging(string value, string color = "white")
		{
		}

		public virtual void Item_Remove(T newItem)
		{
			if (newItem != null)
			{
				items.RemoveAll((T x) => x == null);
				if (items.Contains(newItem))
				{
					OnRemoveEvent(newItem);
					items.Remove(newItem);
					Debugging("Remove [" + newItem.name + "]");
				}
			}
			if (items == null || items.Count == 0)
			{
				Clear();
			}
		}

		protected virtual void OnAddEvent(T newItem)
		{
		}

		protected virtual void OnRemoveEvent(T newItem)
		{
		}
	}
}
