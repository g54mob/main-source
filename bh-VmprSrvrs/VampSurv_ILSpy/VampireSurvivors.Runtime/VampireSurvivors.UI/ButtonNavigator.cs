using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class ButtonNavigator : MonoBehaviour
{
	public SelectableUI.SelectableType SelectionType;

	private List<GameObject> _Graphics;

	private RectTransform rectTransform;

	private RectTransform OriginalParent;

	private RectTransform Target;

	private void Start()
	{
		//IL_00dc: Expected I, but got O
		//IL_00f2: Expected O, but got I
		//IL_01da: Expected I, but got O
		//IL_01f0: Expected O, but got I
		RectTransform component = GetComponent<RectTransform>();
		rectTransform = component;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Transform parent = transform.parent;
			if ((object)parent != null)
			{
				RectTransform component2 = parent.GetComponent<RectTransform>();
				OriginalParent = component2;
				SelectableUI.OnSelection b = Reset;
				Delegate obj = SelectableUI.UIItemDestroyed;
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, b);
					bool flag = (object)obj2 == null;
					Delegate obj3 = null;
					if (!flag)
					{
						bool flag2 = (object)obj2.GetType() != typeof(SelectableUI.OnSelection);
						obj3 = null;
						if (!flag2)
						{
							obj3 = obj2;
						}
						if ((object)obj3 == null)
						{
							break;
						}
					}
					nint num = (nint)typeof(SelectableUI);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rax_v21 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+B8]");
					object obj4 = (nint)0 + (nint)16;
					bool flag3 = obj == obj4;
					Delegate obj5;
					if (obj == obj4)
					{
						obj4 = obj3;
						obj5 = obj;
					}
					else
					{
						obj5 = (Delegate)obj4;
					}
					Delegate obj6 = obj;
					if (!flag3)
					{
						obj6 = obj5;
					}
					bool flag4 = (object)obj6 != obj;
					obj = obj6;
					if (flag4)
					{
						continue;
					}
					goto IL_0175;
				}
				goto IL_0450;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_045c;
		IL_0450:
		throw new InvalidCastException();
		IL_0175:
		SelectableUI.OnSetSelectorVisibility b2 = SetVisibility;
		Delegate obj7 = SelectableUI.SetSelectorVisibility;
		while (true)
		{
			Delegate obj8 = Delegate.Combine(obj7, b2);
			bool flag5 = (object)obj8 == null;
			Delegate obj9 = null;
			if (!flag5)
			{
				bool flag6 = (object)obj8.GetType() != typeof(SelectableUI.OnSetSelectorVisibility);
				obj9 = null;
				if (!flag6)
				{
					obj9 = obj8;
				}
				if ((object)obj9 == null)
				{
					break;
				}
			}
			nint num2 = (nint)typeof(SelectableUI);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rax_v31 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+B8]");
			object obj10 = (nint)0 + (nint)32;
			bool flag7 = obj7 == obj10;
			Delegate obj11;
			if (obj7 == obj10)
			{
				obj10 = obj9;
				obj11 = obj7;
			}
			else
			{
				obj11 = (Delegate)obj10;
			}
			Delegate obj12 = obj7;
			if (!flag7)
			{
				obj12 = obj11;
			}
			bool flag8 = (object)obj12 != obj7;
			obj7 = obj12;
			if (flag8)
			{
				continue;
			}
			if (SelectionType != SelectableUI.SelectableType.BUTTON)
			{
				if (SelectionType == SelectableUI.SelectableType.ITEM)
				{
					SelectableUI.OnSelection value = MoveToSelection;
					SelectableUI.UIItemSelected += value;
					SelectableUI.OnSelection value2 = Disable;
					SelectableUI.UIButtonSelected += value2;
				}
			}
			else
			{
				SelectableUI.OnSelection value3 = MoveToSelection;
				SelectableUI.UIButtonSelected += value3;
				SelectableUI.OnSelection value4 = Disable;
				SelectableUI.UIItemSelected += value4;
			}
			return;
		}
		goto IL_045c;
		IL_045c:
		InvalidCastException ex2 = new InvalidCastException();
		goto IL_0450;
	}

	private void OnDestroy()
	{
		//IL_0117: Expected I, but got O
		//IL_012d: Expected O, but got I
		//IL_0215: Expected I, but got O
		//IL_022b: Expected O, but got I
		if (SelectionType != SelectableUI.SelectableType.BUTTON)
		{
			if (SelectionType == SelectableUI.SelectableType.ITEM)
			{
				SelectableUI.OnSelection value = MoveToSelection;
				SelectableUI.UIItemSelected -= value;
				SelectableUI.OnSelection value2 = Disable;
				SelectableUI.UIButtonSelected -= value2;
			}
		}
		else
		{
			SelectableUI.OnSelection value3 = MoveToSelection;
			SelectableUI.UIButtonSelected -= value3;
			SelectableUI.OnSelection value4 = Disable;
			SelectableUI.UIItemSelected -= value4;
		}
		SelectableUI.OnSelection value5 = Reset;
		Delegate obj = SelectableUI.UIItemDestroyed;
		while (true)
		{
			Delegate obj2 = Delegate.Remove(obj, value5);
			bool flag = (object)obj2 == null;
			Delegate obj3 = null;
			if (!flag)
			{
				bool flag2 = (object)obj2.GetType() != typeof(SelectableUI.OnSelection);
				obj3 = null;
				if (!flag2)
				{
					obj3 = obj2;
				}
				if ((object)obj3 == null)
				{
					InvalidCastException ex = new InvalidCastException();
					break;
				}
			}
			nint num = (nint)typeof(SelectableUI);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v11 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+B8]");
			object obj4 = (nint)0 + (nint)16;
			bool flag3 = obj == obj4;
			Delegate obj5;
			if (obj == obj4)
			{
				obj4 = obj3;
				obj5 = obj;
			}
			else
			{
				obj5 = (Delegate)obj4;
			}
			Delegate obj6 = obj;
			if (!flag3)
			{
				obj6 = obj5;
			}
			bool flag4 = (object)obj6 != obj;
			obj = obj6;
			if (flag4)
			{
				continue;
			}
			SelectableUI.OnSetSelectorVisibility value6 = SetVisibility;
			Delegate obj7 = SelectableUI.SetSelectorVisibility;
			while (true)
			{
				Delegate obj8 = Delegate.Remove(obj7, value6);
				bool flag5 = (object)obj8 == null;
				Delegate obj9 = null;
				if (!flag5)
				{
					bool flag6 = (object)obj8.GetType() != typeof(SelectableUI.OnSetSelectorVisibility);
					obj9 = null;
					if (!flag6)
					{
						obj9 = obj8;
					}
					if ((object)obj9 == null)
					{
						break;
					}
				}
				nint num2 = (nint)typeof(SelectableUI);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v21 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+B8]");
				object obj10 = (nint)0 + (nint)32;
				bool flag7 = obj7 == obj10;
				Delegate obj11;
				if (obj7 == obj10)
				{
					obj10 = obj9;
					obj11 = obj7;
				}
				else
				{
					obj11 = (Delegate)obj10;
				}
				Delegate obj12 = obj7;
				if (!flag7)
				{
					obj12 = obj11;
				}
				bool flag8 = (object)obj12 != obj7;
				obj7 = obj12;
				if (!flag8)
				{
					return;
				}
			}
			break;
		}
		throw new InvalidCastException();
	}

	private unsafe void LateUpdate()
	{
		//IL_02ae: Expected O, but got I4
		//IL_02f7: Expected I4, but got O
		//IL_0162: Expected I, but got O
		//IL_0172: Expected O, but got I
		//IL_017f: Expected O, but got F4
		//IL_018c: Expected O, but got Ref
		//IL_0108: Expected I, but got O
		//IL_0118: Expected O, but got I
		//IL_0125: Expected O, but got Ref
		//IL_01c4: Expected O, but got I
		//IL_01ed: Expected I, but got O
		//IL_01fd: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_0455->IL0244: Incompatible stack heights: 5 vs 0
		//IL_012a->IL02fc: Incompatible stack heights: 6 vs 0
		//IL_0217->IL02fc: Incompatible stack heights: 9 vs 0
		//IL_0495->IL027d: Incompatible stack heights: 6 vs 0
		RectTransform target = Target;
		if ((object)Target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		List<GameObject> graphics = _Graphics;
		if (_Graphics != null)
		{
			List<GameObject>.Enumerator graphics2 = (List<GameObject>.Enumerator)_Graphics;
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			List<GameObject>.Enumerator ret = default(List<GameObject>.Enumerator);
			MultiplayerManager multiplayerManager = default(MultiplayerManager);
			object obj3 = default(object);
			while (enumerator.MoveNext())
			{
				Image component = ((GameObject)null).GetComponent<Image>();
				bool flag = (object)Target == null;
				GameObject gameObject = Target.gameObject;
				bool flag2 = (object)gameObject == null;
				bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
				bool flag4 = (object)component == null;
				bool flag5 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				Behaviour.set_enabled_Injected(((UnityEngine.Object)component).m_CachedPtr, (byte)(int)obj != 0);
				bool flag6 = MultiplayerManager.s_instance == null;
				int localPlayerCount = MultiplayerManager.s_instance.GetLocalPlayerCount();
				object obj2;
				if (localPlayerCount <= 1)
				{
					nint num = (nint)component;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1791 @ r8_v31 (Il2CppClass<UnityEngine.UI.Image>)+2B0]");
					obj2 = 0;
					component.color = (Color)(&ret);
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
				bool flag7 = multiplayerManager == null;
				Color uIControlColour = multiplayerManager.GetUIControlColour();
				nint num2 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1813 @ r8_v27 (Il2CppClass<UnityEngine.UI.Image>)+2A8]");
				graphics = (List<GameObject>)0;
				graphics2 = (List<GameObject>.Enumerator)uIControlColour.r;
				component.color = (Color)(&ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
				bool flag8 = obj3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rax_v108+20]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rax_v108+20]");
				bool flag9 = (nint)0 == 0;
				nint num3 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1815 @ r8_v29 (Il2CppClass<UnityEngine.UI.Image>)+350]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rdx_v49+98]");
				component.material = (Material)0;
			}
			object obj5 = rectTransform;
			RectTransform target2 = Target;
			if ((object)Target != null)
			{
				bool flag10 = ((UnityEngine.Object)target2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)target2).m_CachedPtr, out *(Vector3*)(&ret));
				bool flag11 = (object)rectTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdi_v26 (System.Object)+10]");
				bool flag12 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdi_v26 (System.Object)+10]");
				Vector3 value = default(Vector3);
				Transform.set_position_Injected((IntPtr)0, ref value);
				object obj6 = rectTransform;
				object target3 = Target;
				bool flag13 = (object)Target == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rdi_v27 (System.Object)+10]");
				bool flag14 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rdi_v27 (System.Object)+10]");
				RectTransform.get_sizeDelta_Injected((IntPtr)0, out Vector2 _);
				if ((object)rectTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v29 (System.Object)+10]");
					bool flag15 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v29 (System.Object)+10]");
					Vector2 value2 = default(Vector2);
					RectTransform.set_sizeDelta_Injected((IntPtr)0, ref value2);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Reset(RectTransform rtrans)
	{
		//IL_0145: Expected O, but got I4
		//IL_015f: Expected O, but got I4
		//IL_01bb->IL01bb: Incompatible stack heights: 1 vs 0
		RectTransform target = Target;
		bool flag = (object)Target == null;
		bool flag2 = (object)rtrans == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)Target != null)
			{
				if ((object)rtrans != null)
				{
					object obj3 = (object)rtrans - (object)Target;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)rtrans).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				goto IL_01bb;
			}
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		Transform transform = base.transform;
		transform.SetParent(OriginalParent, worldPositionStays: false);
		RectTransform rectTransform = this.rectTransform;
		bool flag5 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref value);
		goto IL_01bb;
		IL_01bb:
		Target = null;
	}

	private void MoveToSelection(RectTransform rtrans)
	{
		//IL_0122->IL008f: Incompatible stack heights: 2 vs 0
		Target = rtrans;
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			gameObject.SetActive(value: true);
			RectTransform rectTransform = this.rectTransform;
			if ((object)rtrans != null)
			{
				bool flag = ((UnityEngine.Object)rtrans).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)rtrans).m_CachedPtr, out Vector3 _);
				bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref value);
				Vector2 sizeDelta = rtrans.sizeDelta;
				if ((object)this.rectTransform != null)
				{
					this.rectTransform.sizeDelta = sizeDelta;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetVisibility(bool b)
	{
		//IL_005b->IL005b: Incompatible stack heights: 1 vs 0
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v5 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v5 (System.Object)+10]");
			GameObject.SetActive_Injected((IntPtr)0, b);
		}
	}

	private void Disable(RectTransform rTrans)
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public unsafe void DisableAllNavigation()
	{
		//IL_0017: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_005c: Expected O, but got Ref
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0073: Expected O, but got I4
		Selectable[] array = UnityEngine.Object.FindObjectsOfType<Selectable>();
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj2 < array.Length)
		{
			array[obj].navigation = (Navigation)(&obj3);
			obj++;
			obj3 = 0;
			obj2 = obj;
		}
	}

	public ButtonNavigator()
	{
		List<GameObject> graphics = new List<GameObject>();
		_Graphics = graphics;
	}
}
