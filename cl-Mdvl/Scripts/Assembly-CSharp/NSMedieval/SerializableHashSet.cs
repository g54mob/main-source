using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class SerializableHashSet<T> : ISerializationCallbackReceiver
	{
		[SerializeField]
		private T[] items;

		private HashSet<T> set;

		public HashSet<T> Set
		{
			get
			{
				if (set == null)
				{
					set = new HashSet<T>();
				}
				return set;
			}
			set
			{
				set = value;
			}
		}

		public void OnBeforeSerialize()
		{
			items = Set.ToArray();
		}

		public void OnAfterDeserialize()
		{
			Set.Clear();
			if (items != null && items.Length != 0)
			{
				set.AddRange(items);
			}
		}
	}
}
