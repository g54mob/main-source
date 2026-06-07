using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SaintsField.DropdownBase;

namespace SaintsField
{
	public class AdvancedDropdownList<T> : IAdvancedDropdownList, IReadOnlyList<IAdvancedDropdownList>, IEnumerable<IAdvancedDropdownList>, IEnumerable, IReadOnlyCollection<IAdvancedDropdownList>
	{
		private readonly T _typeValue;

		private List<AdvancedDropdownList<T>> _typeChildren;

		public string displayName { get; }

		public object value => _typeValue;

		public IReadOnlyList<IAdvancedDropdownList> children => ((IEnumerable<AdvancedDropdownList<T>>)_typeChildren).Select((Func<AdvancedDropdownList<T>, IAdvancedDropdownList>)((AdvancedDropdownList<T> each) => each)).ToList();

		public bool disabled { get; }

		public string icon { get; }

		public bool isSeparator { get; }

		public int Count => _typeChildren.Count;

		public AdvancedDropdownList<T> this[int index] => _typeChildren[index];

		IAdvancedDropdownList IReadOnlyList<IAdvancedDropdownList>.this[int index] => _typeChildren[index];

		public void SetChildren(List<AdvancedDropdownList<T>> newChildren)
		{
			_typeChildren = newChildren;
		}

		public AdvancedDropdownList()
		{
			displayName = "";
			_typeValue = default(T);
			_typeChildren = new List<AdvancedDropdownList<T>>();
			disabled = false;
			icon = null;
			isSeparator = false;
		}

		public AdvancedDropdownList(string displayName, bool disabled = false, string icon = null)
		{
			this.displayName = displayName;
			_typeValue = default(T);
			_typeChildren = new List<AdvancedDropdownList<T>>();
			this.disabled = disabled;
			this.icon = icon;
			isSeparator = false;
		}

		public AdvancedDropdownList(string displayName, T value, bool disabled = false, string icon = null, bool isSeparator = false)
		{
			this.displayName = displayName;
			_typeValue = value;
			_typeChildren = new List<AdvancedDropdownList<T>>();
			this.disabled = disabled;
			this.icon = icon;
			this.isSeparator = isSeparator;
		}

		public AdvancedDropdownList(string displayName, IEnumerable<AdvancedDropdownList<T>> children, bool disabled = false, string icon = null, bool isSeparator = false)
		{
			this.displayName = displayName;
			_typeChildren = children.ToList();
			this.disabled = disabled;
			this.icon = icon;
			this.isSeparator = isSeparator;
		}

		public void Add(AdvancedDropdownList<T> child)
		{
			_typeChildren.Add(child);
		}

		public void Add(string displayNames, T value, bool disabled = false, string icon = null)
		{
			AddByNames(this, new Queue<string>(displayNames.Split('/')), value, disabled, icon);
		}

		public void Add(string displayNames)
		{
			if (displayNames == "" || displayNames == "/")
			{
				AddSeparator();
				return;
			}
			string displayNames2 = (displayNames.EndsWith("/") ? displayNames : (displayNames + "/"));
			Add(displayNames2, default(T));
		}

		private static void AddByNames(AdvancedDropdownList<T> container, Queue<string> nameQuery, T value, bool disabled = false, string icon = null)
		{
			string curName = nameQuery.Dequeue();
			if (nameQuery.Count == 0)
			{
				container.Add((curName == "") ? Separator() : new AdvancedDropdownList<T>(curName, value, disabled, icon));
				return;
			}
			IAdvancedDropdownList advancedDropdownList = container.children.FirstOrDefault((IAdvancedDropdownList each) => each.displayName == curName);
			AdvancedDropdownList<T> advancedDropdownList2;
			if (advancedDropdownList != null)
			{
				advancedDropdownList2 = (AdvancedDropdownList<T>)advancedDropdownList;
			}
			else
			{
				advancedDropdownList2 = new AdvancedDropdownList<T>(curName);
				container.Add(advancedDropdownList2);
			}
			AddByNames(advancedDropdownList2, nameQuery, value, disabled, icon);
		}

		public void AddSeparator()
		{
			_typeChildren.Add(Separator());
		}

		public int ChildCount()
		{
			return _typeChildren.Count((AdvancedDropdownList<T> each) => !each.isSeparator);
		}

		public int SepCount()
		{
			return _typeChildren.Count((AdvancedDropdownList<T> each) => each.isSeparator);
		}

		public static AdvancedDropdownList<T> Separator()
		{
			return new AdvancedDropdownList<T>("", default(T), disabled: false, null, isSeparator: true);
		}

		public IEnumerator<IAdvancedDropdownList> GetEnumerator()
		{
			return _typeChildren.Cast<IAdvancedDropdownList>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
