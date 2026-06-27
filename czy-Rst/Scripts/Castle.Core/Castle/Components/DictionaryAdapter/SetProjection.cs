using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Castle.Components.DictionaryAdapter
{
	public class SetProjection<T> : ListProjection<T>, ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private readonly HashSet<T> set;

		public SetProjection(ICollectionAdapter<T> adapter)
			: base(adapter)
		{
			set = new HashSet<T>();
			Repopulate();
		}

		public override bool Contains(T item)
		{
			return set.Contains(item);
		}

		public bool IsSubsetOf(IEnumerable<T> other)
		{
			return set.IsSubsetOf(other);
		}

		public bool IsSupersetOf(IEnumerable<T> other)
		{
			return set.IsSupersetOf(other);
		}

		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			return set.IsProperSubsetOf(other);
		}

		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			return set.IsProperSupersetOf(other);
		}

		public bool Overlaps(IEnumerable<T> other)
		{
			return set.Overlaps(other);
		}

		public bool SetEquals(IEnumerable<T> other)
		{
			return set.SetEquals(other);
		}

		private void Repopulate()
		{
			SuspendEvents();
			int num = base.Count;
			int num2 = 0;
			while (num2 < num)
			{
				T item = base[num2];
				if (!set.Add(item))
				{
					RemoveAt(num2);
					num--;
				}
				else
				{
					num2++;
				}
			}
			ResumeEvents();
		}

		public override void EndNew(int index)
		{
			if (IsNew(index) && OnInserting(base[index]))
			{
				base.EndNew(index);
			}
			else
			{
				CancelNew(index);
			}
		}

		public override bool Add(T item)
		{
			if (!set.Contains(item))
			{
				return base.Add(item);
			}
			return false;
		}

		protected override bool OnInserting(T value)
		{
			return set.Add(value);
		}

		protected override bool OnReplacing(T oldValue, T newValue)
		{
			if (!set.Add(newValue))
			{
				return false;
			}
			set.Remove(oldValue);
			return true;
		}

		public override bool Remove(T item)
		{
			if (set.Remove(item))
			{
				return base.Remove(item);
			}
			return false;
		}

		public override void RemoveAt(int index)
		{
			set.Remove(base[index]);
			base.RemoveAt(index);
		}

		public override void Clear()
		{
			set.Clear();
			base.Clear();
		}

		public void UnionWith(IEnumerable<T> other)
		{
			foreach (T item in other)
			{
				Add(item);
			}
		}

		public void ExceptWith(IEnumerable<T> other)
		{
			foreach (T item in other)
			{
				Remove(item);
			}
		}

		public void IntersectWith(IEnumerable<T> other)
		{
			T[] other2 = set.Except(other).ToArray();
			ExceptWith(other2);
		}

		public void SymmetricExceptWith(IEnumerable<T> other)
		{
			T[] array = set.Intersect(other).ToArray();
			IEnumerable<T> other2 = other.Except(array);
			ExceptWith(array);
			UnionWith(other2);
		}
	}
}
