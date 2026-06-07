using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	public abstract class ScriptableList<T> : ScriptableObject where T : Object
	{
		[TextArea(3, 20)]
		public string Description = "Store a List of Objects";

		[SerializeField]
		private List<T> items = new List<T>();

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

		public virtual T Item_GetRandom()
		{
			if (items != null && items.Count > 0)
			{
				return items[Random.Range(0, items.Count)];
			}
			return null;
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
	}
}
