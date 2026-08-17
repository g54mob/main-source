using System;
using System.Reflection;
using Cpp2ILInjected;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class LabeledInputUI : MonoBehaviour, ISelectableUI, IUIObject, ISubmitHandler, IEventSystemHandler, IDeselectHandler
{
	private TextMeshProUGUI _Label;

	private TMP_InputField _Input;

	private TouchScreenKeyboardType _KeyboardType;

	private bool _HasBeenActivated;

	private TouchScreenKeyboard _softKeyboard;

	public TextMeshProUGUI Label => _Label;

	public TMP_InputField Input => _Input;

	private void OnEnable()
	{
		//IL_009f: Expected I, but got O
		//IL_022d: Expected O, but got I
		if (!SteamUtils.IsRunningOnSteamDeck)
		{
			goto IL_00fa;
		}
		Action b = OnFloatingGamepadTextInputDismissed;
		Delegate obj = SteamUtils.OnFloatingGamepadTextInputDismissed;
		while (true)
		{
			Delegate obj2 = Delegate.Combine(obj, b);
			bool flag = (object)obj2 == null;
			Delegate obj3 = null;
			if (!flag)
			{
				bool flag2 = (object)obj2.GetType() != typeof(Action);
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
			nint num = (nint)typeof(SteamUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ r8_v12 (Il2CppClass<Steamworks.SteamUtils>)+B8]");
			object obj4 = (nint)0 + (nint)32;
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
			goto IL_00fa;
		}
		goto IL_02a3;
		IL_00fa:
		TMP_InputField input = _Input;
		if ((object)_Input != null)
		{
			UnityAction<string> call = OnInputSelected;
			if (input.m_OnSelect != null)
			{
				input.m_OnSelect.AddListener(call);
				TMP_InputField input2 = _Input;
				if ((object)_Input != null)
				{
					UnityAction<string> call2 = OnEndEdit;
					if (input2.m_OnEndEdit != null)
					{
						input2.m_OnEndEdit.AddListener(call2);
						return;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_02a3;
		IL_02a3:
		throw new InvalidCastException();
	}

	private void OnDisable()
	{
		//IL_009f: Expected I, but got O
		//IL_0303: Expected O, but got I
		//IL_01d8: Expected O, but got I
		//IL_01d8: Expected O, but got I
		//IL_02b6: Expected O, but got I
		//IL_02b6: Expected O, but got I
		if (!SteamUtils.IsRunningOnSteamDeck)
		{
			goto IL_00fa;
		}
		Action value = OnFloatingGamepadTextInputDismissed;
		Delegate obj = SteamUtils.OnFloatingGamepadTextInputDismissed;
		while (true)
		{
			Delegate obj2 = Delegate.Remove(obj, value);
			bool flag = (object)obj2 == null;
			Delegate obj3 = null;
			if (!flag)
			{
				bool flag2 = (object)obj2.GetType() != typeof(Action);
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
			nint num = (nint)typeof(SteamUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ r8_v12 (Il2CppClass<Steamworks.SteamUtils>)+B8]");
			object obj4 = (nint)0 + (nint)32;
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
			goto IL_00fa;
		}
		goto IL_0379;
		IL_00fa:
		TMP_InputField input = _Input;
		if ((object)_Input != null)
		{
			TMP_InputField.SelectionEvent onSelect = input.m_OnSelect;
			UnityAction<string> unityAction = OnInputSelected;
			if (input.m_OnSelect != null && unityAction != null)
			{
				MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdi_v4 (TMPro.TMP_InputField+SelectionEvent)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdi_v4 (TMPro.TMP_InputField+SelectionEvent)+10]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v10 (UnityEngine.Events.UnityAction`1<System.String>)+20]");
					((UnityEngine.Events.InvokableCallList)num2).RemoveListener(0, methodImpl);
					TMP_InputField input2 = _Input;
					if ((object)_Input != null)
					{
						TMP_InputField.SubmitEvent onEndEdit = input2.m_OnEndEdit;
						UnityAction<string> unityAction2 = OnEndEdit;
						if (input2.m_OnEndEdit != null && unityAction2 != null)
						{
							MethodInfo methodImpl2 = ((MulticastDelegate)unityAction2).GetMethodImpl();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdi_v5 (TMPro.TMP_InputField+SubmitEvent)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdi_v5 (TMPro.TMP_InputField+SubmitEvent)+10]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v16 (UnityEngine.Events.UnityAction`1<System.String>)+20]");
								((UnityEngine.Events.InvokableCallList)num3).RemoveListener(0, methodImpl2);
								return;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_0379;
		IL_0379:
		throw new InvalidCastException();
	}

	private void LateUpdate()
	{
		TMP_InputField input = _Input;
		if (input.m_AllowInput)
		{
			_HasBeenActivated = true;
		}
		if (!input.m_AllowInput && _HasBeenActivated)
		{
			_HasBeenActivated = false;
			_softKeyboard = null;
			Selectable component = GetComponent<Selectable>();
			component.Select();
		}
	}

	public void SetKeyboardType(TouchScreenKeyboardType t)
	{
	}

	public void SetContentType(TMP_InputField.ContentType contentType)
	{
		_Input.contentType = contentType;
	}

	public void SetLabel(string text)
	{
		_Label.text = text;
	}

	public bool IsFocused()
	{
		//IL_0041: Expected I4, but got O
		TMP_InputField input = _Input;
		if ((object)_Input != null)
		{
			return input.m_AllowInput;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void SetInputPlaceholderText(string value)
	{
		TMP_InputField input = _Input;
		TextMeshProUGUI componentInChildren = input.m_Placeholder.GetComponentInChildren<TextMeshProUGUI>();
		if ((object)componentInChildren != null && ((UnityEngine.Object)componentInChildren).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		}
	}

	public string GetText()
	{
		TMP_InputField input = _Input;
		if ((object)_Input != null)
		{
			return input.m_Text;
		}
		return (string)(object)new NullReferenceException();
	}

	public Selectable GetSelectable()
	{
		return GetComponent<Selectable>();
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
	{
	}

	public void ActivateInputField()
	{
		_Input.Select();
		_Input.ActivateInputField();
	}

	public void OnSubmit(BaseEventData eventData)
	{
		if (SteamUtils.IsRunningOnSteamDeck)
		{
			SystemPlatform sInstance = SystemPlatform.sInstance;
			sInstance.m_CurrentSystem.DisplayOnscreenKeyboard();
		}
	}

	public void OnDeselect(BaseEventData eventData)
	{
	}

	private void OnInputSelected(string arg0)
	{
	}

	private void OnEndEdit(string arg0)
	{
	}

	private void OnFloatingGamepadTextInputDismissed()
	{
		_Input.DeactivateInputField();
		_Input.OnDeselect(null);
	}

	private bool IsRunningOnXboxHandheld()
	{
		return false;
	}

	private void TryShowXboxVirtualKeyboard()
	{
	}

	private void TryHideXboxVirtualKeyboard()
	{
	}

	public LabeledInputUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
