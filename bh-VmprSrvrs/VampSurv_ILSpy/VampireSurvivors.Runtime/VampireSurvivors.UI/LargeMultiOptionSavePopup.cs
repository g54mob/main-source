using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class LargeMultiOptionSavePopup : LargeMultiOptionPopup
{
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public LargeMultiOptionSavePopup _003C_003E4__this;

		public Action onCancel;

		internal void _003CInitialize_003Eb__1()
		{
			Action action = onCancel;
			if (onCancel != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass1_1
	{
		public GameObject g;

		public _003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals1;

		internal void _003CInitialize_003Eb__0()
		{
			_003C_003Ec__DisplayClass1_0 obj = CS_0024_003C_003E8__locals1;
			obj._003C_003E4__this.SelectOption(g);
		}
	}

	private sealed class _003CFrameDelays_003Ed__2(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LargeMultiOptionSavePopup _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_039f: Expected O, but got Ref
			LargeMultiOptionSavePopup largeMultiOptionSavePopup = _003C_003E4__this;
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
				if ((object)_003C_003E4__this != null && largeMultiOptionSavePopup._spawned != null)
				{
					List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
					if (enumerator.MoveNext())
					{
						GameObject gameObject = null;
						throw new NullReferenceException();
					}
					List<GameObject> spawned = largeMultiOptionSavePopup._spawned;
					bool flag = largeMultiOptionSavePopup._spawned == null;
					_003CFrameDelays_003Ed__2 obj = (_003CFrameDelays_003Ed__2)(&enumerator);
					if (!flag)
					{
						if (spawned._size <= 0)
						{
							goto IL_03ad;
						}
						obj = (_003CFrameDelays_003Ed__2)(object)spawned._items;
						if (spawned._items != null && (object)_003C_003E4__this != null)
						{
							LargeMultiOptionPopupItem component = ((GameObject)(object)_003C_003E4__this).GetComponent<LargeMultiOptionPopupItem>();
							if ((object)component != null && (object)component.Tick != null)
							{
								component.Tick.SetActive(value: true);
								List<GameObject> spawned2 = largeMultiOptionSavePopup._spawned;
								if (largeMultiOptionSavePopup._spawned != null)
								{
									if (spawned2._size <= 0)
									{
										goto IL_03ad;
									}
									GameObject[] items = spawned2._items;
									if (spawned2._items != null && (object)items[0] != null)
									{
										Selectable componentInChildren = items[0].GetComponentInChildren<Selectable>(includeInactive: false);
										if ((object)componentInChildren != null)
										{
											componentInChildren.Select();
											goto IL_0334;
										}
									}
								}
							}
						}
					}
				}
				throw new NullReferenceException();
			}
			goto IL_0334;
			IL_03ad:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
			IL_0334:
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

	private GameObject _CancelButton;

	public unsafe void Initialize(string id, string title, string description, List<SaveOptionDataSet> options, Action<int> callback, bool hasCancelButton = false, Action onCancel = null)
	{
		//IL_0080: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_0469: Expected O, but got I4
		//IL_0472: Expected O, but got I4
		//IL_00e1: Expected O, but got I
		//IL_00f6: Expected O, but got I
		//IL_0b74: Expected I4, but got O
		//IL_04e0: Expected O, but got Ref
		//IL_0836: Expected O, but got Ref
		//IL_0858: Expected O, but got I4
		//IL_0571: Expected O, but got I4
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Expected O, but got Unknown
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Expected O, but got Unknown
		//IL_089d: Expected O, but got I4
		//IL_068d: Expected I, but got O
		//IL_06a3: Expected O, but got I
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Expected O, but got Unknown
		//IL_0727: Expected I, but got O
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Expected O, but got Unknown
		//IL_0b9a: Expected O, but got I4
		//IL_0bb1: Expected I, but got I8
		//IL_05ff: Expected O, but got I4
		//IL_0703: Expected I, but got I8
		//IL_0774: Expected O, but got Ref
		//IL_0796: Expected O, but got I4
		//IL_0170: Expected O, but got I
		//IL_07db: Expected O, but got I4
		//IL_0822: Expected O, but got I4
		//IL_01be: Expected O, but got I
		//IL_020b: Expected O, but got I
		//IL_0275: Expected I, but got O
		//IL_028b: Expected O, but got I
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_0302: Expected I, but got O
		//IL_0ad3: Expected O, but got I4
		//IL_0aea: Expected I, but got I8
		//IL_02eb: Expected I, but got I8
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_0612->IL0b16: Incompatible stack heights: 1 vs 0
		//IL_0827->IL0827: Incompatible stack heights: 1 vs 0
		//IL_0456->IL0aef: Incompatible stack heights: 7 vs 0
		_003C_003Ec__DisplayClass1_0 obj;
		Action onCancel2 = default(Action);
		Action<int> onSelectedCallback = default(Action<int>);
		object obj14 = default(object);
		GameObject gameObject2 = default(GameObject);
		string text = default(string);
		GameObject gameObject3 = default(GameObject);
		while (true)
		{
			obj = new _003C_003Ec__DisplayClass1_0();
			obj._003C_003E4__this = this;
			obj.onCancel = onCancel2;
			_ID = id;
			_Title.text = title;
			_onSelectedCallback = onSelectedCallback;
			TextMeshProUGUI description2 = _Description;
			description2.text = text;
			EventSystem current = EventSystem.current;
			_previouslySelected = current.m_CurrentSelected;
			object obj2 = 0;
			object obj3 = 0;
			while (true)
			{
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1524 @ stack_28+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				_003C_003Ec__DisplayClass1_1 obj5 = new _003C_003Ec__DisplayClass1_1();
				obj5.CS_0024_003C_003E8__locals1 = obj;
				object obj6 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1524 @ stack_28+18]");
				bool flag = (nint)obj6 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1524 @ stack_28+10]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rcx_v104+20+v161 @ r15_v6*8]");
				object obj8 = 0;
				GameObject g = UnityEngine.Object.Instantiate(_OptionPrefab, _Container);
				obj5.g = g;
				object g2 = obj5.g;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rbx_v31 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rbx_v31 (System.Object)+10]");
				IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v135 (UnityEngine.Transform)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v135 (UnityEngine.Transform)+10]");
				IntPtr child_Injected = Transform.GetChild_Injected((IntPtr)0, 0);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
				TextMeshProUGUI component = transform2.GetComponent<TextMeshProUGUI>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r14_v23+10]");
				component.text = (string)0;
				object g3 = obj5.g;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rbx_v33 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rbx_v33 (System.Object)+10]");
				IntPtr gcHandlePtr2 = GameObject.get_transform_Injected((IntPtr)0);
				Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v147 (UnityEngine.Transform)+10]");
				bool flag5 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v147 (UnityEngine.Transform)+10]");
				IntPtr child_Injected2 = Transform.GetChild_Injected((IntPtr)0, 1);
				Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected2);
				TextMeshProUGUI component2 = transform4.GetComponent<TextMeshProUGUI>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r14_v23+18]");
				component2.text = (string)0;
				object g4 = obj5.g;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rbx_v35 (System.Object)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rbx_v35 (System.Object)+10]");
				IntPtr gcHandlePtr3 = GameObject.get_transform_Injected((IntPtr)0);
				Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v159 (UnityEngine.Transform)+10]");
				bool flag7 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v159 (UnityEngine.Transform)+10]");
				IntPtr child_Injected3 = Transform.GetChild_Injected((IntPtr)0, 2);
				Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected3);
				TextMeshProUGUI component3 = transform6.GetComponent<TextMeshProUGUI>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r14_v23+20]");
				component3.text = (string)0;
				Button component4 = obj5.g.GetComponent<Button>();
				UnityAction unityAction = null;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r10_v8 (Il2CppMethodInfo)+8]");
				((Delegate)unityAction).method_ptr = (IntPtr)0;
				((Delegate)unityAction).method = (nint)__ldftn(_003C_003Ec__DisplayClass1_1._003CInitialize_003Eb__0);
				((Delegate)unityAction).m_target = obj5;
				((Delegate)unityAction).method_code = (IntPtr)unityAction;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r10_v8 (Il2CppMethodInfo)+4C]");
				object obj9 = (nint)0 >> 4;
				object obj10 = obj9 & 1;
				nint num2;
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r10_v8 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num2 = unchecked((nint)6447293664L);
						goto IL_0aca;
					}
				}
				((Delegate)unityAction).method_code = (IntPtr)((Delegate)unityAction).m_target;
				num2 = ((Delegate)unityAction).method_ptr;
				goto IL_0aca;
				IL_0aca:
				object obj11 = 24;
				((Delegate)unityAction).extra_arg = unchecked((nint)6447293568L);
				component4.m_OnClick.AddListener(unityAction);
				List<object> spawned = (List<object>)(object)_spawned;
				int version = spawned._version + 1;
				spawned._version = version;
				text = (string)(object)spawned._items;
				int size = spawned._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r9_v30 (System.String)+18]");
				if ((nint)size >= (nint)0)
				{
					spawned.AddWithResize((object)obj5.g);
				}
				else
				{
					int size2 = spawned._size + 1;
					spawned._size = size2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				if (obj2 == null)
				{
					Canvas componentInChildren = obj5.g.GetComponentInChildren<Canvas>(includeInactive: true);
					GameObject gameObject = componentInChildren.gameObject;
					gameObject.SetActive(value: true);
				}
				obj2++;
				obj3 = obj2;
			}
			List<GameObject> spawned2 = _spawned;
			object obj12 = 0;
			object obj13 = 0;
			while ((nint)obj12 < spawned2._size)
			{
				List<GameObject> spawned3 = _spawned;
				bool flag8 = (nint)obj13 >= spawned3._size;
				GameObject[] items = spawned3._items;
				Selectable component5 = items[obj13].GetComponent<Selectable>();
				component5.navigation = (Navigation)(&obj14);
				bool flag9 = (nint)obj13 <= 0;
				Selectable selectable = null;
				if (!flag9)
				{
					object obj15 = obj13 - 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Selectable component6 = gameObject2.GetComponent<Selectable>();
					SetNavigationUp(component5, component6);
					text = null;
					selectable = component6;
				}
				List<GameObject> spawned4 = _spawned;
				object obj16 = spawned4._size - 1;
				Selectable target;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16))
				{
					target = _Confirm;
				}
				else
				{
					object obj17 = obj13 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					target = gameObject3.GetComponent<Selectable>();
				}
				SetNavigationDown(component5, target);
				spawned2 = _spawned;
				obj13++;
				obj14 = 4;
				text = null;
				obj12 = obj13;
			}
			object cancelButton = _CancelButton;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rbx_v22 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cancelButton);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rbx_v22 (System.Object)+10]");
		object obj18 = default(object);
		GameObject.SetActive_Injected((IntPtr)0, (byte)(int)obj18 != 0);
		if (obj18 == null)
		{
			goto IL_0827;
		}
		Button component7 = _CancelButton.GetComponent<Button>();
		UnityAction unityAction2 = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r10_v7 (Il2CppMethodInfo)+8]");
		((Delegate)unityAction2).method_ptr = (IntPtr)0;
		((Delegate)unityAction2).method = (nint)__ldftn(_003C_003Ec__DisplayClass1_0._003CInitialize_003Eb__1);
		((Delegate)unityAction2).m_target = obj;
		((Delegate)unityAction2).method_code = (IntPtr)unityAction2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r10_v7 (Il2CppMethodInfo)+4C]");
		object obj19 = (nint)0 >> 4;
		object obj20 = obj19 & 1;
		nint num4;
		if (obj20 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r10_v7 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num4 = unchecked((nint)6447293664L);
				goto IL_0b91;
			}
		}
		num4 = ((Delegate)unityAction2).method_ptr;
		((Delegate)unityAction2).method_code = (IntPtr)((Delegate)unityAction2).m_target;
		goto IL_0b91;
		IL_0b91:
		object obj21 = 24;
		((Delegate)unityAction2).extra_arg = unchecked((nint)6447293568L);
		component7.m_OnClick.AddListener(unityAction2);
		Selectable component8 = _CancelButton.GetComponent<Selectable>();
		SetNavigationRight(_Confirm, component8);
		component8.navigation = (Navigation)(&obj14);
		List<GameObject> spawned5 = _spawned;
		object obj22 = spawned5._size - 1;
		bool flag10 = (nint)obj22 >= spawned5._size;
		GameObject[] items2 = spawned5._items;
		object obj23 = spawned5._size - 1;
		Selectable component9 = items2[obj23].GetComponent<Selectable>();
		SetNavigationUp(component8, component9);
		SetNavigationLeft(component8, _Confirm);
		obj14 = 4;
		goto IL_0827;
		IL_0827:
		_Confirm.navigation = (Navigation)(&obj14);
		List<GameObject> spawned6 = _spawned;
		object obj24 = spawned6._size - 1;
		bool flag11 = (nint)obj24 >= spawned6._size;
		GameObject[] items3 = spawned6._items;
		object obj25 = spawned6._size - 1;
		SetNavigationUp(target: items3[obj25].GetComponent<Selectable>(), origin: _Confirm);
		_003CFrameDelays_003Ed__2 obj26 = null;
		obj26._003C_003E1__state = 0;
		obj26._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj26);
	}

	private IEnumerator FrameDelays()
	{
		_003CFrameDelays_003Ed__2 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
