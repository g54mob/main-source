using System.Collections.Generic;

namespace GameKit.Utilities.ObjectPooling
{
	public class ListStack<GameObject>
	{
		private float _lastAccessedTime;

		public int Count => 0;

		public List<GameObject> Entries { get; private set; }

		public List<float> EntriesAddedTimes { get; private set; }

		public bool AccessedRecently(float threshold)
		{
			return false;
		}

		public List<GameObject> Cull(float threshold)
		{
			return null;
		}

		public void Push(GameObject item)
		{
		}

		public GameObject Pop()
		{
			return default(GameObject);
		}

		public void Remove(int index)
		{
		}

		public bool Remove(GameObject item)
		{
			return false;
		}

		public void Clear()
		{
		}
	}
}
