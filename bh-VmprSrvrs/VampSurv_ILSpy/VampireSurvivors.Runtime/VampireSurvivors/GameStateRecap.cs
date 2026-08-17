using System;
using Cpp2ILInjected;
using DG.Tweening.Core;
using Doozy.Engine;
using UnityEngine;
using UnityEngine.SceneManagement;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class GameStateRecap : GameStateMachineState
{
	public override void OnEnter()
	{
		//IL_00b4: Expected O, but got I4
		//IL_00b4: Expected O, but got I
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_010d: Expected O, but got I
		Debug.Log("[GameStateRecap] OnEnter");
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action action = ReturnToLanding;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.RecapPageCompletedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.RecapPageCompletedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = gameStateMachine.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v15 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
	}

	public override void OnExit()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action token = ReturnToLanding;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		gameStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
	}

	private void ReturnToLanding()
	{
		//IL_005f: Expected O, but got I4
		parentStateMachine.FireEvent("RETURN_TO_LANDING");
		GameEventMessage.SendEvent("RETURN_TO_LANDING");
		int num = DG.Tweening.Core.TweenManager.DespawnAll();
		SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		Scene scene = SceneManager.LoadScene("ScenePreloader", (LoadSceneParameters)1);
	}

	public GameStateRecap()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
