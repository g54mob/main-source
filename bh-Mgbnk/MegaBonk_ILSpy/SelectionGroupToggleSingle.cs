using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectionGroupToggleSingle : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public SelectionGroupToggleSingleButton b;

		public SelectionGroupToggleSingle _003C_003E4__this;

		internal void _003CFindButtons_003Eb__0()
		{
			_003C_003E4__this.OnButtonSelect(b);
		}
	}

	public Action<SelectionGroupToggleSingleButton> A_ButtonSelected;

	public int startIndex;

	public bool canSelectMultiple;

	public bool canSelectNothing;

	public bool selectDefaultOnAwake = true;

	private SelectionGroupToggleSingleButton lastButton;

	private List<SelectionGroupToggleSingleButton> buttons;

	private List<SelectionGroupToggleSingleButton> _003CselectedButtons_003Ek__BackingField;

	private HashSet<SelectionGroupToggleSingleButton> registeredButtons;

	public List<SelectionGroupToggleSingleButton> selectedButtons
	{
		get
		{
			return _003CselectedButtons_003Ek__BackingField;
		}
		private set
		{
			_003CselectedButtons_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		FindButtons();
		List<SelectionGroupToggleSingleButton> list = new List<SelectionGroupToggleSingleButton>();
		_003CselectedButtons_003Ek__BackingField = list;
		if (!canSelectNothing)
		{
			List<SelectionGroupToggleSingleButton> list2 = buttons;
			if (list2._size > 0 && selectDefaultOnAwake)
			{
				ForceSelect(startIndex);
			}
		}
	}

	private void OnTransformChildrenChanged()
	{
		FindButtons();
	}

	public unsafe void FindButtons()
	{
		SelectionGroupToggleSingleButton[] componentsInChildren = GetComponentsInChildren<SelectionGroupToggleSingleButton>();
		List<object> list = Enumerable.ToList((IEnumerable<object>)componentsInChildren);
		buttons = (List<SelectionGroupToggleSingleButton>)(object)list;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		SelectionGroupToggleSingleButton b = default(SelectionGroupToggleSingleButton);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass14_0();
				if (CS_0024_003C_003E8__locals11 != null)
				{
					CS_0024_003C_003E8__locals11._003C_003E4__this = this;
					CS_0024_003C_003E8__locals11.b = b;
					if (registeredButtons != null)
					{
						if (!((HashSet<object>)(object)registeredButtons).Contains((object)CS_0024_003C_003E8__locals11.b))
						{
							if (registeredButtons == null)
							{
								throw new NullReferenceException();
							}
							bool flag = registeredButtons.Add(CS_0024_003C_003E8__locals11.b);
							if ((object)CS_0024_003C_003E8__locals11.b == null)
							{
								throw new NullReferenceException();
							}
							Button component = CS_0024_003C_003E8__locals11.b.GetComponent<Button>();
							if ((object)component == null)
							{
								throw new NullReferenceException();
							}
							UnityAction call = delegate
							{
								CS_0024_003C_003E8__locals11._003C_003E4__this.OnButtonSelect(CS_0024_003C_003E8__locals11.b);
							};
							if (component.m_OnClick == null)
							{
								break;
							}
							component.m_OnClick.AddListener(call);
							if (CS_0024_003C_003E8__locals11.b != lastButton)
							{
								CS_0024_003C_003E8__locals11.b.Deselect();
							}
						}
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<SelectionGroupToggleSingleButton>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private void SelectButton(SelectionGroupToggleSingleButton btn)
	{
		btn.Select();
		List<object> list = (List<object>)(object)_003CselectedButtons_003Ek__BackingField;
		int version = list._version + 1;
		list._version = version;
		object[] items = list._items;
		if (list._size >= items.Length)
		{
			list.AddWithResize((object)btn);
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			int num = default(int);
			items[num] = btn;
		}
		lastButton = btn;
	}

	private void DeselectButton(SelectionGroupToggleSingleButton btn)
	{
		if (btn != null)
		{
			btn.Deselect();
			bool flag = ((List<object>)(object)_003CselectedButtons_003Ek__BackingField).Remove((object)btn);
		}
	}

	public void SetNone()
	{
		if (_003CselectedButtons_003Ek__BackingField == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		SelectionGroupToggleSingleButton selectionGroupToggleSingleButton = default(SelectionGroupToggleSingleButton);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)selectionGroupToggleSingleButton == null)
				{
					break;
				}
				selectionGroupToggleSingleButton.Deselect();
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			List<SelectionGroupToggleSingleButton> list = new List<SelectionGroupToggleSingleButton>();
			_003CselectedButtons_003Ek__BackingField = list;
			return;
		}
		throw new NullReferenceException();
	}

	private void OnButtonSelect(SelectionGroupToggleSingleButton newBtn)
	{
		if (!newBtn._003CcanSelect_003Ek__BackingField)
		{
			return;
		}
		if (!canSelectMultiple)
		{
			if (~(newBtn._003CisSelected_003Ek__BackingField ? 1u : 0u) != 0)
			{
				DeselectButton(lastButton);
				goto IL_009d;
			}
			if (!canSelectNothing)
			{
				goto IL_00ac;
			}
		}
		else
		{
			if (~(newBtn._003CisSelected_003Ek__BackingField ? 1u : 0u) != 0)
			{
				goto IL_009d;
			}
			if (!canSelectNothing)
			{
				List<SelectionGroupToggleSingleButton> list = _003CselectedButtons_003Ek__BackingField;
				if (list._size <= 1)
				{
					goto IL_00ac;
				}
			}
		}
		DeselectButton(newBtn);
		goto IL_00ac;
		IL_00ac:
		Action<SelectionGroupToggleSingleButton> a_ButtonSelected = A_ButtonSelected;
		if (A_ButtonSelected != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v95 @ rax_v10 (System.Action`1<SelectionGroupToggleSingleButton>)+18] (should have been resolved before IL gen)");
		}
		return;
		IL_009d:
		SelectButton(newBtn);
		goto IL_00ac;
	}

	public SelectionGroupToggleSingleButton GetButton(int index)
	{
		if (index >= 0)
		{
			List<SelectionGroupToggleSingleButton> list = buttons;
			if (buttons == null)
			{
				return (SelectionGroupToggleSingleButton)(object)new NullReferenceException();
			}
			if (index < list._size)
			{
				return buttons.get_Item(index);
			}
		}
		return null;
	}

	public void ForceSelect(int index)
	{
		SelectionGroupToggleSingleButton selectionGroupToggleSingleButton = buttons.get_Item(index);
		if (!selectionGroupToggleSingleButton._003CcanSelect_003Ek__BackingField)
		{
			return;
		}
		if (!canSelectMultiple)
		{
			if (~(selectionGroupToggleSingleButton._003CisSelected_003Ek__BackingField ? 1u : 0u) != 0)
			{
				DeselectButton(lastButton);
				goto IL_00b5;
			}
			if (!canSelectNothing)
			{
				goto IL_00c4;
			}
		}
		else
		{
			if (~(selectionGroupToggleSingleButton._003CisSelected_003Ek__BackingField ? 1u : 0u) != 0)
			{
				goto IL_00b5;
			}
			if (!canSelectNothing)
			{
				List<SelectionGroupToggleSingleButton> list = _003CselectedButtons_003Ek__BackingField;
				if (list._size <= 1)
				{
					goto IL_00c4;
				}
			}
		}
		DeselectButton(selectionGroupToggleSingleButton);
		goto IL_00c4;
		IL_00c4:
		Action<SelectionGroupToggleSingleButton> a_ButtonSelected = A_ButtonSelected;
		if (A_ButtonSelected != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v160 @ rax_v12 (System.Action`1<SelectionGroupToggleSingleButton>)+18] (should have been resolved before IL gen)");
		}
		return;
		IL_00b5:
		SelectButton(selectionGroupToggleSingleButton);
		goto IL_00c4;
	}

	public int GetSelectedIndex()
	{
		//IL_00ee: Expected I4, but got O
		List<SelectionGroupToggleSingleButton> list = buttons;
		bool flag = buttons == null;
		int num = 0;
		int num2 = 0;
		if (!flag)
		{
			while (true)
			{
				if (num2 < list._size)
				{
					if (buttons == null)
					{
						break;
					}
					SelectionGroupToggleSingleButton selectionGroupToggleSingleButton = buttons.get_Item(num);
					if (lastButton != selectionGroupToggleSingleButton)
					{
						list = buttons;
						num++;
						if (buttons == null)
						{
							break;
						}
						num2 = num;
						continue;
					}
					return num;
				}
				return 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public SelectionGroupToggleSingle()
	{
		List<SelectionGroupToggleSingleButton> list = new List<SelectionGroupToggleSingleButton>();
		buttons = list;
		registeredButtons = (HashSet<SelectionGroupToggleSingleButton>)(object)new HashSet<object>();
		base._002Ector();
	}
}
