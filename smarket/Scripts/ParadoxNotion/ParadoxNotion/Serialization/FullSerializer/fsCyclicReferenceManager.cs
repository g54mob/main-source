using System.Collections.Generic;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public class fsCyclicReferenceManager
	{
		private class ObjectReferenceEqualityComparator : IEqualityComparer<object>
		{
			public static readonly IEqualityComparer<object> Instance;

			bool IEqualityComparer<object>.Equals(object x, object y)
			{
				return false;
			}

			int IEqualityComparer<object>.GetHashCode(object obj)
			{
				return 0;
			}
		}

		private Dictionary<object, int> _objectIds;

		private int _nextId;

		private Dictionary<int, object> _marked;

		private int _depth;

		public void Clear()
		{
		}

		public bool Enter()
		{
			return false;
		}

		public bool Exit()
		{
			return false;
		}

		public object GetReferenceObject(int id)
		{
			return null;
		}

		public void AddReferenceWithId(int id, object reference)
		{
		}

		public int GetReferenceId(object item)
		{
			return 0;
		}

		public bool IsReference(object item)
		{
			return false;
		}

		public void MarkSerialized(object item)
		{
		}
	}
}
