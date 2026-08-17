using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class GameStateMerchant : GameStateMachineState
{
	public override void OnEnter()
	{
		//IL_00b8: Expected O, but got I4
		//IL_00b8: Expected O, but got I
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0171: Expected O, but got I
		GameStateMachine gameStateMachine = _gameStateMachine;
		gameStateMachine._003CGameplayManager_003Ek__BackingField.PauseGame();
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action = Return;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.MerchantClosedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.MerchantClosedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = gameStateMachine2.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v15 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action3 = null;
		((GameStateMerchant)(object)action3).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateMerchant)(object)gameStateMachine3.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action3);
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action action4 = Return;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8BB0");
	}

	public override void OnExit()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		GameStateMachine gameStateMachine = _gameStateMachine;
		gameStateMachine._003CGameplayManager_003Ek__BackingField.ResumeGame();
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action token = Return;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		gameStateMachine2.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action = null;
		((GameStateMerchant)(object)action).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateMerchant)(object)gameStateMachine3.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action);
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action action2 = Return;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8970");
	}

	private void Return()
	{
		if (SoundManager._003CAllowUIFades_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.FadeMusic(bgmType, 0.3f, 500f);
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4321]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("CONNECTION_ERROR");
		GameEventMessage.SendEvent("CONNECTION_ERROR");
	}

	public GameStateMerchant()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
