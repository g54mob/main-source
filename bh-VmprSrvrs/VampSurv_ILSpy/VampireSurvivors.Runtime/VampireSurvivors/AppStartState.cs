using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class AppStartState : AppStateMachineState
{
	public override void OnEnter()
	{
		//IL_00eb: Expected O, but got I4
		//IL_00eb: Expected O, but got I
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0175: Expected O, but got I
		base.OnEnter();
		AppStateMachine appStateMachine = base.appStateMachine;
		if (appStateMachine.SkipToGame)
		{
			parentStateMachine.FireEvent("START_GAME");
			GameEventMessage.SendEvent("START_GAME");
		}
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action action = MoveToLanding;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.IntroAnimCompletedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.IntroAnimCompletedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = appStateMachine2.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v16 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action3 = ProgressToOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7050");
	}

	public override void OnExit()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		base.OnExit();
		AppStateMachine appStateMachine = base.appStateMachine;
		if (!appStateMachine.SkipToGame)
		{
			Action token = MoveToLanding;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool throwIfMissing = default(bool);
			appStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
			AppStateMachine appStateMachine2 = base.appStateMachine;
			Action action = ProgressToOnlineScreen;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7350");
		}
	}

	private void MoveToLanding()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42E7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("LANDING_SCREEN");
		GameEventMessage.SendEvent("LANDING_SCREEN");
	}

	private void ProgressToOnlineScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42E8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE");
		GameEventMessage.SendEvent("SHOW_ONLINE");
	}

	public AppStartState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
