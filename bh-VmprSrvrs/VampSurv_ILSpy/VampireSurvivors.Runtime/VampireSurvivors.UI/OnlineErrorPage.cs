using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class OnlineErrorPage : BaseUIPage
{
	private TextMeshProUGUI _errorTitle;

	private TextMeshProUGUI _errorText;

	private GameObject _okBtn;

	private SignalBus _signalBus;

	public void Construct(SignalBus signalBus)
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00f9: Expected O, but got I
		_signalBus = signalBus;
		Action<UISignals.ShowOnlineErrorScreenSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0150");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ShowOnlineErrorScreenSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ShowOnlineErrorScreenSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v13 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus2.SubscribeInternal(signalType, (object)null, (object)0, callback);
	}

	public void GoBack()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	private void OnShowError(UISignals.ShowOnlineErrorScreenSignal sig)
	{
		_errorTitle.text = sig.ErrorTitle;
		_errorText.text = sig.ErrorMessage;
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Action<UISignals.ShowOnlineErrorScreenSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0150");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
	}

	protected override void Update()
	{
		//IL_0158: Expected O, but got I4
		//IL_0172: Expected O, but got I4
		base.Update();
		EventSystem current = EventSystem.current;
		GameObject currentSelected = current.m_CurrentSelected;
		Selectable component = _okBtn.GetComponent<Selectable>();
		GameObject gameObject = component.gameObject;
		bool flag = (object)gameObject == null;
		bool flag2 = (object)current.m_CurrentSelected == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 != null)
		{
			return;
		}
		bool flag4;
		if ((object)gameObject != null)
		{
			if ((object)current.m_CurrentSelected != null)
			{
				object obj3 = (object)current.m_CurrentSelected - (object)gameObject;
				flag4 = obj3 == null;
			}
			else
			{
				flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			}
		}
		else
		{
			flag4 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
		}
		if (!flag4)
		{
			Selectable component2 = _okBtn.GetComponent<Selectable>();
			component2.Select();
		}
	}

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		Selectable component = _okBtn.GetComponent<Selectable>();
		component.Select();
	}
}
