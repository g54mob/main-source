using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public class EditableBindingList<T> : System.ComponentModel.BindingList<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IEditableObject, IRevertibleChangeTracking, IChangeTracking
	{
		private bool isEditing;

		private List<T> snapshot;

		public bool IsChanged
		{
			get
			{
				if (snapshot == null || snapshot.Count != base.Count)
				{
					return false;
				}
				IEnumerator<T> enumerator = GetEnumerator();
				List<T>.Enumerator enumerator2 = snapshot.GetEnumerator();
				while (enumerator.MoveNext() && enumerator2.MoveNext())
				{
					if ((object)enumerator.Current != (object)enumerator2.Current)
					{
						return false;
					}
					if (enumerator.Current is IChangeTracking { IsChanged: not false })
					{
						return true;
					}
				}
				return false;
			}
		}

		public EditableBindingList()
		{
		}

		public EditableBindingList(IList<T> initial)
			: base(initial)
		{
		}

		public void BeginEdit()
		{
			if (!isEditing)
			{
				snapshot = new List<T>(this);
				isEditing = true;
			}
		}

		public void EndEdit()
		{
			isEditing = false;
			snapshot = null;
		}

		public void CancelEdit()
		{
			if (!isEditing)
			{
				return;
			}
			Clear();
			foreach (T item in snapshot)
			{
				Add(item);
			}
			snapshot = null;
			isEditing = false;
		}

		public void AcceptChanges()
		{
			BeginEdit();
		}

		public void RejectChanges()
		{
			CancelEdit();
		}
	}
}
