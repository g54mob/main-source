using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rhizomatic.Reactive;

namespace GRP
{
	public class Selector<T> where T : class, ISelectable
	{
		public StateList<T> selection;

		public HashSet<T> selected;

		public event Action onSelectionChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public T GetLast()
		{
			return null;
		}

		public bool IsSelected(T data)
		{
			return false;
		}

		public StateSelector<bool> GetSelectedState(T data)
		{
			return null;
		}

		public void SelectAll(T[] allData, bool additive = false)
		{
		}

		public void Select(T data, bool additive = false)
		{
		}

		public void ToggleSelect(T data)
		{
		}

		public void Remove(T data)
		{
		}

		public void SetSelection(T data, bool value, bool silent = false)
		{
		}

		public void Changed()
		{
		}

		public void MakeLast(T data)
		{
		}

		public void Clear()
		{
		}

		public SelectorData Serialize()
		{
			return null;
		}

		public void Deserialize(SelectorData data, Func<Id, T> getData)
		{
		}
	}
}
