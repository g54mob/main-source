using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class CustomDropDown : MonoBehaviour, ISelectableUI, IUIObject
{
	private sealed class _003CWaitAndFormat_003Ed__20(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomDropDown _003C_003E4__this;

		public int count;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00c8: Expected I4, but got O
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
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.Format(count);
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

	private Graphic _SelectedItem;

	private Image _Arrow;

	private GameObject _OptionPrefab;

	private RectTransform _ContentContainer;

	private Button _DropDown;

	private int _ItemsToShow = 4;

	private ScrollEnhancer _Scroll;

	private GameObject _DropdownScrollContainer;

	private List<CustomDropdownItem> _spawned;

	private List<object> _options;

	private Action<int> _callback;

	private int _selectedIndex;

	public bool IsOpen
	{
		get
		{
			GameObject dropdownScrollContainer = _DropdownScrollContainer;
			bool flag = ((UnityEngine.Object)dropdownScrollContainer).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
	}

	public void InitialSet(string text, List<object> options, int selectedIndex, Action<int> callbackWithNewSelectedIndex, bool clearCurrentOptions = false)
	{
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		object obj = default(object);
		if (obj != null)
		{
			ClearOptions();
		}
		_Label.text = text;
		int num;
		if (selectedIndex >= 0)
		{
			bool flag = selectedIndex < options._size;
			num = selectedIndex;
			if (flag)
			{
				goto IL_01fe;
			}
		}
		num = options._size - 1;
		goto IL_01fe;
		IL_01fe:
		_selectedIndex = num;
		Transform transform = null;
		Transform transform2 = null;
		while ((nint)transform < options._size)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_OptionPrefab, _ContentContainer);
			CustomDropdownItem component = gameObject.GetComponent<CustomDropdownItem>();
			if ((nint)transform2 == num)
			{
				GameObject value = UnityEngine.Object.Instantiate((GameObject)(object)options, transform2);
				UpdateSelectedItem(value);
			}
			CustomDropdownItem component2 = gameObject.GetComponent<CustomDropdownItem>();
			GameObject gameObject2 = UnityEngine.Object.Instantiate((GameObject)(object)_spawned, (Transform)(object)component2);
			GameObject option = UnityEngine.Object.Instantiate((GameObject)(object)options, transform2);
			component.Initialize(option, this);
			transform2 = (Transform)(transform2 + 1);
			transform = transform2;
		}
		Scrollbar componentInChildren = _Scroll.GetComponentInChildren<Scrollbar>();
		Slider componentInChildren2 = _Scroll.GetComponentInChildren<Slider>();
		Slider slider = default(Slider);
		float offset = default(float);
		_Scroll.Initialize(3f, _ContentContainer, componentInChildren, slider, offset);
		_ItemsToShow = _ItemsToShow;
		_003CWaitAndFormat_003Ed__20 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		obj2.count = _ItemsToShow;
		Coroutine coroutine = StartCoroutine(obj2);
		Action<int> callback = default(Action<int>);
		_callback = callback;
		_options = options;
		ApplyNavigation();
	}

	private void ClearOptions()
	{
		//IL_0018: Expected O, but got I4
		//IL_02d3: Expected I, but got O
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_0071->IL023c: Incompatible stack heights: 1 vs 0
		//IL_00a8->IL023c: Incompatible stack heights: 1 vs 0
		//IL_00fc->IL02d8: Incompatible stack heights: 2 vs 0
		//IL_0101->IL0101: Incompatible stack heights: 2 vs 0
		List<CustomDropdownItem> spawned = _spawned;
		bool flag = (nint)_spawned < 0;
		if (_spawned != null)
		{
			object obj = spawned._size - 1;
			if (flag)
			{
				goto IL_0101;
			}
			while (true)
			{
				List<CustomDropdownItem> spawned2 = _spawned;
				if (_spawned == null)
				{
					break;
				}
				bool flag2 = (nint)obj >= spawned2._size;
				CustomDropdownItem[] items = spawned2._items;
				if (spawned2._items == null)
				{
					break;
				}
				object obj2 = items[obj];
				if ((object)items[obj] == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v7 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				nint num = (nint)typeof(UnityEngine.Object);
				UnityEngine.Object.Destroy(obj3, 0f);
				obj--;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rcx_v19 (Il2CppClass<UnityEngine.Object>)+E4]");
				if ((nint)0 >= (nint)0)
				{
					continue;
				}
				goto IL_0101;
			}
		}
		goto IL_023c;
		IL_0101:
		List<CustomDropdownItem> spawned3 = _spawned;
		if (_spawned != null)
		{
			int version = spawned3._version + 1;
			spawned3._version = version;
			spawned3._size = 0;
			if (spawned3._size > 0)
			{
				Array.Clear(spawned3._items, 0, spawned3._size);
			}
			List<object> options = _options;
			if (_options != null)
			{
				int version2 = options._version + 1;
				options._version = version2;
				options._size = 0;
				if (options._size > 0)
				{
					Array.Clear(options._items, 0, options._size);
				}
				return;
			}
		}
		goto IL_023c;
		IL_023c:
		throw new NullReferenceException();
	}

	public void RegenerateOptions(List<object> options, int selectedIndex)
	{
		//IL_0076: Expected I, but got O
		//IL_00ae: Expected I, but got O
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		ClearOptions();
		Transform transform = null;
		Transform transform2 = null;
		object option = default(object);
		while ((nint)transform2 < options._size)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_OptionPrefab, _ContentContainer);
			CustomDropdownItem component = gameObject.GetComponent<CustomDropdownItem>();
			bool flag = (nint)transform != selectedIndex;
			nint num = 0;
			if (!flag)
			{
				GameObject value = UnityEngine.Object.Instantiate((GameObject)(object)options, transform);
				UpdateSelectedItem(value);
				num = unchecked((nint)null);
			}
			CustomDropdownItem component2 = gameObject.GetComponent<CustomDropdownItem>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E120");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			nint num2 = (nint)component;
			component.Initialize(option, this);
			transform = (Transform)(transform + 1);
			transform2 = transform;
		}
		_options = options;
		int selectedIndex2;
		if (selectedIndex >= 0)
		{
			bool flag2 = selectedIndex < options._size;
			selectedIndex2 = selectedIndex;
			if (flag2)
			{
				goto IL_017d;
			}
		}
		selectedIndex2 = options._size - 1;
		goto IL_017d;
		IL_017d:
		_ItemsToShow = _ItemsToShow;
		_selectedIndex = selectedIndex2;
		Format(_ItemsToShow);
	}

	private unsafe void UpdateSelectedItem(object value)
	{
		//IL_0056: Expected I, but got O
		//IL_0063: Expected I, but got O
		//IL_0073: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_014c: Expected I, but got O
		//IL_0159: Expected I, but got O
		//IL_0169: Expected O, but got I
		//IL_00ea: Expected I, but got O
		//IL_00f7: Expected I, but got O
		//IL_01a5: Expected O, but got I
		//IL_0133: Expected O, but got Ref
		if (value != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			bool flag = value != null;
			object obj = null;
			if (!flag)
			{
				obj = value;
			}
			if (obj != null)
			{
				Graphic selectedItem = _SelectedItem;
				nint num = (nint)typeof(TextMeshProUGUI);
				nint num2 = (nint)selectedItem;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r8_v8 (Il2CppClass<TMPro.TextMeshProUGUI>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ r11_v3 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r8_v8 (Il2CppClass<TMPro.TextMeshProUGUI>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ r11_v3 (Il2CppClass<UnityEngine.UI.Graphic>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v21+FFFFFFF8+v208 @ rax_v20*8]");
					if (0 == (nint)typeof(TextMeshProUGUI))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
						bool flag2 = value != null;
						object obj4 = null;
						if (!flag2)
						{
							obj4 = value;
						}
						if (obj4 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v207 @ r11_v3 (Il2CppClass<UnityEngine.UI.Graphic>)+558] (should have been resolved before IL gen)");
							return;
						}
						throw new InvalidCastException();
					}
				}
				throw new InvalidCastException();
			}
		}
		Graphic selectedItem2 = _SelectedItem;
		nint num4 = (nint)typeof(Image);
		nint num5 = (nint)selectedItem2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v9 (Il2CppClass<UnityEngine.UI.Image>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v6 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v9 (Il2CppClass<UnityEngine.UI.Image>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v6 (Il2CppClass<UnityEngine.UI.Graphic>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v14+FFFFFFF8+v104 @ rax_v13*8]");
			if (0 == (nint)typeof(Image))
			{
				nint num7 = (nint)typeof(Color);
				nint num8 = (nint)value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v12 (Il2CppClass<System.Object>)+40]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v10 (Il2CppClass<UnityEngine.Color>)+40]");
				if (num9 == 0)
				{
					object obj7 = default(object);
					selectedItem2.color = (Color)(&obj7);
					return;
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
	}

	public void SetItemsToShow(int count, bool force = false)
	{
		_ItemsToShow = count;
		if (!force)
		{
			_003CWaitAndFormat_003Ed__20 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			obj.count = count;
			Coroutine coroutine = StartCoroutine(obj);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 101 Invalid \"Jump target not found in method: 0x186CAD5D0\"");
		}
	}

	private IEnumerator WaitAndFormat(int count)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CWaitAndFormat_003Ed__20 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.count = count;
			return obj;
		}
		obj.count = count;
		return obj;
	}

	private void Format(int count)
	{
		//IL_01de: Expected O, but got I4
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected I4, but got Unknown
		RectTransform component = _DropdownScrollContainer.GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		List<CustomDropdownItem> spawned = _spawned;
		if (spawned._size > 0)
		{
			CustomDropdownItem[] items = spawned._items;
			RectTransform component2 = items[0].GetComponent<RectTransform>();
			Vector2 sizeDelta2 = component2.sizeDelta;
			Vector2 sizeDelta3 = default(Vector2);
			component.sizeDelta = sizeDelta3;
			List<CustomDropdownItem> spawned2 = _spawned;
			if (spawned2._size > 0)
			{
				CustomDropdownItem[] items2 = spawned2._items;
				RectTransform component3 = items2[0].GetComponent<RectTransform>();
				Vector2 sizeDelta4 = component3.sizeDelta;
				Vector2 sizeDelta5 = component.sizeDelta;
				Vector2 parentSize = component.GetParentSize();
				Vector2 anchorMax = component.anchorMax;
				Vector2 anchorMin = component.anchorMin;
				component.sizeDelta = sizeDelta3;
				List<CustomDropdownItem> spawned3 = _spawned;
				ScrollEnhancer scroll = _Scroll;
				Slider slider = scroll._Slider;
				if ((object)scroll._Slider != null && ((UnityEngine.Object)slider).m_CachedPtr != (IntPtr)0)
				{
					GameObject gameObject = scroll._Slider.gameObject;
					object obj = spawned3._size - count;
					int num = spawned3._size ^ count;
					int num2 = spawned3._size ^ obj;
					int num3 = num & num2;
					bool flag = num3 < 0;
					bool flag2 = (nint)obj < 0;
					bool flag3 = obj == null;
					bool flag4 = flag2 == flag;
					bool flag5 = !flag3;
					bool active = flag5 & flag4;
					gameObject.SetActive(active);
				}
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void ApplyNavigation()
	{
		//IL_01a7: Expected O, but got I4
		//IL_01b0: Expected O, but got I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_0160: Expected O, but got Ref
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0186: Expected O, but got I4
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		List<CustomDropdownItem> spawned = _spawned;
		object obj = 0;
		object obj2 = 0;
		Component component3 = default(Component);
		Component component5 = default(Component);
		object obj7 = default(object);
		while (true)
		{
			if ((nint)obj2 < spawned._size)
			{
				List<CustomDropdownItem> spawned2 = _spawned;
				if ((nint)obj >= spawned2._size)
				{
					break;
				}
				CustomDropdownItem[] items = spawned2._items;
				Selectable component = items[obj].GetComponent<Selectable>();
				object obj3 = obj - 1;
				if ((nint)obj3 >= 0)
				{
					object obj4 = obj - 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Selectable component2 = component3.GetComponent<Selectable>();
				}
				List<CustomDropdownItem> spawned3 = _spawned;
				object obj5 = obj + 1;
				if ((nint)obj5 < spawned3._size)
				{
					object obj6 = obj + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Selectable component4 = component5.GetComponent<Selectable>();
				}
				component.navigation = (Navigation)(&obj7);
				spawned = _spawned;
				obj++;
				obj7 = 4;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Open()
	{
		if (!IsOpen)
		{
			_DropdownScrollContainer.SetActive(value: true);
			List<CustomDropdownItem> spawned = _spawned;
			int selectedIndex = _selectedIndex;
			if (_selectedIndex >= spawned._size)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			CustomDropdownItem[] items = spawned._items;
			Selectable component = items[selectedIndex].GetComponent<Selectable>();
			component.Select();
		}
		else
		{
			Close();
		}
	}

	public void SelectItem(CustomDropdownItem item)
	{
		//IL_01c0: Expected O, but got I4
		//IL_01c9: Expected O, but got I4
		//IL_020d: Expected O, but got I4
		//IL_0227: Expected O, but got I4
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		List<CustomDropdownItem> spawned = _spawned;
		object obj = 0;
		object obj2 = 0;
		object value = default(object);
		while (true)
		{
			if ((nint)obj2 < spawned._size)
			{
				List<CustomDropdownItem> spawned2 = _spawned;
				if ((nint)obj >= spawned2._size)
				{
					break;
				}
				CustomDropdownItem[] items = spawned2._items;
				CustomDropdownItem customDropdownItem = items[obj];
				bool flag = (object)items[obj] == null;
				bool flag2 = (object)item == null;
				object obj3 = flag2 & flag;
				bool flag3 = obj3 == null;
				object obj4 = !flag3;
				if (obj4 == null)
				{
					bool flag4;
					if ((object)item != null)
					{
						if ((object)items[obj] != null)
						{
							object obj5 = (object)items[obj] - (object)item;
							flag4 = obj5 == null;
						}
						else
						{
							flag4 = ((UnityEngine.Object)item).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						flag4 = ((UnityEngine.Object)customDropdownItem).m_CachedPtr == (IntPtr)0;
					}
					if (!flag4)
					{
						goto IL_014b;
					}
				}
				Action<int> callback = _callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v80 @ rax_v19 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				UpdateSelectedItem(value);
				goto IL_014b;
			}
			_DropdownScrollContainer.SetActive(value: false);
			Selectable component = _DropDown.GetComponent<Selectable>();
			component.Select();
			return;
			IL_014b:
			spawned = _spawned;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Close()
	{
		_DropdownScrollContainer.SetActive(value: false);
		Selectable component = _DropDown.GetComponent<Selectable>();
		component.Select();
	}

	public void Toggle()
	{
		if (!IsOpen && !IsOpen)
		{
			_DropdownScrollContainer.SetActive(value: true);
			List<CustomDropdownItem> spawned = _spawned;
			int selectedIndex = _selectedIndex;
			if (_selectedIndex >= spawned._size)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			CustomDropdownItem[] items = spawned._items;
			Selectable component = items[selectedIndex].GetComponent<Selectable>();
			component.Select();
		}
		else
		{
			Close();
		}
	}

	public void Update()
	{
		//IL_03dd: Expected O, but got I4
		//IL_0408: Expected O, but got I4
		//IL_0117: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_012a: Expected O, but got I4
		//IL_04b8: Expected O, but got I4
		//IL_04d2: Expected O, but got I4
		//IL_02a2: Expected O, but got I4
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected O, but got Unknown
		//IL_0133->IL0335: Incompatible stack heights: 1 vs 0
		//IL_0187->IL0335: Incompatible stack heights: 2 vs 0
		//IL_0534->IL0335: Incompatible stack heights: 1 vs 0
		//IL_02f6->IL0335: Incompatible stack heights: 1 vs 0
		//IL_0322->IL0335: Incompatible stack heights: 1 vs 0
		//IL_01b7->IL0335: Incompatible stack heights: 3 vs 0
		//IL_0555->IL04f9: Incompatible stack heights: 3 vs 1
		//IL_0278->IL0335: Incompatible stack heights: 3 vs 0
		Camera main = Camera.main;
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		Camera cam = main;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)core).m_CachedPtr == (IntPtr)0;
			cam = main;
			if (!flag2)
			{
				cam = UICamera._cameraUI;
			}
		}
		RectTransform component = GetComponent<RectTransform>();
		if ((object)_DropdownScrollContainer != null)
		{
			RectTransform component2 = _DropdownScrollContainer.GetComponent<RectTransform>();
			object dropdownScrollContainer = _DropdownScrollContainer;
			if ((object)_DropdownScrollContainer != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rbx_v11 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rbx_v11 (System.Object)+10]");
				object obj = GameObject.get_activeInHierarchy_Injected((IntPtr)0);
				if (obj == null)
				{
					return;
				}
				object obj2 = Input.GetMouseButtonDown(0);
				if (obj2 != null)
				{
					Input.get_mousePosition_Injected(out Vector3 ret);
					Vector2 screenPoint = default(Vector2);
					if (!RectTransformUtility.RectangleContainsScreenPoint(component, screenPoint, cam))
					{
						Input.get_mousePosition_Injected(out ret);
						if (!RectTransformUtility.RectangleContainsScreenPoint(component2, screenPoint, cam))
						{
							Close();
							return;
						}
					}
				}
				Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
				bool flag4 = componentsInChildren == null;
				object obj3 = 0;
				object obj4 = 0;
				object obj5 = 0;
				if (!flag4)
				{
					while (true)
					{
						if ((nint)obj5 < componentsInChildren.Length)
						{
							bool flag5 = (nint)obj4 >= componentsInChildren.Length;
							Transform transform = componentsInChildren[obj4];
							if ((object)componentsInChildren[obj4] == null)
							{
								break;
							}
							bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)transform).m_CachedPtr);
							GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
							EventSystem current = EventSystem.current;
							if ((object)current == null)
							{
								break;
							}
							GameObject currentSelected = current.m_CurrentSelected;
							bool flag7 = (object)current.m_CurrentSelected == null;
							bool flag8 = (object)gameObject == null;
							object obj6 = flag8 & flag7;
							bool flag9 = obj6 == null;
							object obj7 = !flag9;
							if (obj7 == null)
							{
								bool flag10;
								if ((object)current.m_CurrentSelected != null)
								{
									if ((object)gameObject != null)
									{
										object obj8 = (object)gameObject - (object)current.m_CurrentSelected;
										flag10 = obj8 == null;
									}
									else
									{
										flag10 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
									}
								}
								else
								{
									if ((object)gameObject == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1157 @ rax_v54 (UnityEngine.GameObject)+10]");
									flag10 = (nint)0 == 0;
								}
								if (!flag10)
								{
									goto IL_0539;
								}
							}
							obj3 = 1;
							goto IL_0539;
						}
						if (obj3 == null)
						{
							if ((object)_DropdownScrollContainer == null)
							{
								break;
							}
							_DropdownScrollContainer.SetActive(value: false);
							if ((object)_DropDown == null)
							{
								break;
							}
							Selectable component3 = _DropDown.GetComponent<Selectable>();
							if ((object)component3 == null)
							{
								break;
							}
							component3.Select();
						}
						return;
						IL_0539:
						obj4++;
						obj5 = obj4;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public Selectable GetSelectable()
	{
		return _DropDown;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public unsafe void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
	{
		//IL_0055: Expected O, but got Ref
		Button dropDown = _DropDown;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r10_v1 (UnityEngine.UI.Button)+48]");
		_ = 0;
		_ = ((Selectable)dropDown).m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r10_v1 (UnityEngine.UI.Button)+38]");
		_ = 0;
		object obj = default(object);
		dropDown.navigation = (Navigation)(&obj);
	}

	public CustomDropDown()
	{
		List<CustomDropdownItem> spawned = new List<CustomDropdownItem>();
		_spawned = spawned;
		List<object> options = new List<object>();
		_options = options;
	}
}
