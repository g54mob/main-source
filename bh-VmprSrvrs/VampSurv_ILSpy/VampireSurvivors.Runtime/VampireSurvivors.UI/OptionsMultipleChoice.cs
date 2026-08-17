using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class OptionsMultipleChoice : MonoBehaviour, ISelectableUI, IUIObject
{
	private sealed class _003CFrameDelay_003Ed__12(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private TextMeshProUGUI _Label;

	private GameObject _OptionPrefab;

	private RectTransform _Container;

	private OptionsMultipleChoiceOption _selected;

	private List<GameObject> _spawned;

	private Selectable _above;

	private Selectable _below;

	public void Initialize(string text, List<string> optionLabels, List<Action> callbacks, int selectedIndex)
	{
		//IL_001d: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02b6->IL0314: Incompatible stack heights: 4 vs 0
		_Label.text = text;
		object obj = 0;
		object obj2 = 0;
		List<Action> list = callbacks;
		object obj3 = default(object);
		while ((nint)obj < optionLabels._size)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_OptionPrefab, _Container);
			OptionsMultipleChoiceOption component = gameObject.GetComponent<OptionsMultipleChoiceOption>();
			bool flag = (nint)obj2 >= optionLabels._size;
			string[] items = optionLabels._items;
			bool flag2 = (nint)obj2 >= list._size;
			Action[] items2 = list._items;
			component._Label.text = items[obj2];
			Button button = component._Button;
			UnityAction call = component.Select;
			button.m_OnClick.AddListener(call);
			Button button2 = component._Button;
			UnityAction call2 = items2[obj2].Invoke;
			button2.m_OnClick.AddListener(call2);
			component._owner = this;
			bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)component).m_CachedPtr);
			GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			bool flag4 = (nint)obj2 >= optionLabels._size;
			string[] items3 = optionLabels._items;
			string text2 = "OptionsChoice-" + items3[obj2];
			((UnityEngine.Object)gameObject2).SetName(text2);
			List<object> spawned = (List<object>)(object)_spawned;
			int version = spawned._version + 1;
			spawned._version = version;
			List<Action> items4 = (List<Action>)(object)spawned._items;
			if (spawned._size >= items4._size)
			{
				spawned.AddWithResize((object)gameObject);
			}
			else
			{
				int size = spawned._size + 1;
				spawned._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			if (obj2 == obj3)
			{
				component.Select();
			}
			obj2++;
			obj = obj2;
			list = callbacks;
		}
	}

	public void OptionSelected(OptionsMultipleChoiceOption option)
	{
		OptionsMultipleChoiceOption selected = _selected;
		if ((object)_selected != null)
		{
			GameObject gameObject = selected._Tick.gameObject;
			gameObject.SetActive(value: false);
		}
		_selected = option;
	}

	public Selectable GetSelectable()
	{
		List<GameObject> spawned = _spawned;
		if (spawned._size > 0)
		{
			GameObject[] items = spawned._items;
			return items[0].GetComponent<Selectable>();
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Selectable result = default(Selectable);
		return result;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public unsafe void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
	{
		//IL_0021: Expected O, but got I8
		//IL_002a: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_01fc: Expected O, but got Ref
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0222: Expected O, but got I4
		_above = up;
		Selectable below = default(Selectable);
		_below = below;
		List<GameObject> spawned = _spawned;
		Selectable selectable = (Selectable)6603577472L;
		object obj = 0;
		object obj2 = 0;
		GameObject gameObject = default(GameObject);
		GameObject gameObject2 = default(GameObject);
		GameObject gameObject3 = default(GameObject);
		object obj7 = default(object);
		while (true)
		{
			if ((nint)obj < spawned._size)
			{
				List<GameObject> spawned2 = _spawned;
				if ((nint)obj2 >= spawned2._size)
				{
					break;
				}
				GameObject[] items = spawned2._items;
				Selectable component = items[obj2].GetComponent<Selectable>();
				object obj3 = obj2 - 1;
				bool flag = (nint)obj3 <= -1;
				Selectable selectable2 = null;
				if (!flag)
				{
					object obj4 = obj2 - 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Selectable component2 = gameObject.GetComponent<Selectable>();
					selectable2 = component2;
				}
				List<GameObject> spawned3 = _spawned;
				object obj5 = obj2 + 1;
				bool flag2 = (nint)obj5 >= spawned3._size;
				Selectable selectable3 = null;
				if (!flag2)
				{
					object obj6 = obj2 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Selectable component3 = gameObject2.GetComponent<Selectable>();
					selectable3 = component3;
				}
				if ((object)selectable2 == null || ((UnityEngine.Object)selectable2).m_CachedPtr == (IntPtr)0)
				{
				}
				if ((object)selectable3 == null || ((UnityEngine.Object)selectable3).m_CachedPtr != (IntPtr)0)
				{
					selectable = _below;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Selectable component4 = gameObject3.GetComponent<Selectable>();
				component4.navigation = (Navigation)(&obj7);
				spawned = _spawned;
				obj2++;
				obj7 = 4;
				obj = obj2;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private IEnumerator FrameDelay()
	{
		_003CFrameDelay_003Ed__12 obj = null;
		obj._003C_003E1__state = 0;
		return obj;
	}

	public OptionsMultipleChoice()
	{
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
	}
}
