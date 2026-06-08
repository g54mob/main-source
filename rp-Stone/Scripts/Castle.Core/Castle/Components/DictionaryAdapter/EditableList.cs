using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public class EditableList<T> : List<T>, IEditableObject, IRevertibleChangeTracking, IChangeTracking
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
				Enumerator enumerator = GetEnumerator();
				Enumerator enumerator2 = snapshot.GetEnumerator();
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

		public EditableList()
		{
		}

		public EditableList(IEnumerable<T> collection)
			: base(collection)
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
			if (isEditing)
			{
				Clear();
				AddRange(snapshot);
				snapshot = null;
				isEditing = false;
			}
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
	public class EditableList : EditableList<object>, IList, ICollection, IEnumerable
	{
		public EditableList()
		{
		}

		public EditableList(IEnumerable<object> collection)
			: base(collection)
		{
		}
	}
}
