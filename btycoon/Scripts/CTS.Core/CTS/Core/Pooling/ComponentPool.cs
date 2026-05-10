using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core.Pooling
{
	internal class ComponentPool
	{
		private Transform _parent;

		public bool autoReturn;

		public int count;

		public string Name { get; set; }

		public List<PooledObject> Queue { get; } = new List<PooledObject>();

		public Transform Parent
		{
			get
			{
				if ((bool)_parent)
				{
					return _parent;
				}
				_parent = new GameObject(Name + " Pool").transform;
				return _parent;
			}
		}

		public PooledObject Dequeue()
		{
			PooledObject result = Queue[0];
			Queue.RemoveAt(0);
			return result;
		}
	}
}
