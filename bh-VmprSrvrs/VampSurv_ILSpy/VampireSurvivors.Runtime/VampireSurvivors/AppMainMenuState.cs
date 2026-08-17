using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class AppMainMenuState : AppStateMachineState
{
	public override void OnEnter()
	{
		//IL_0186: Expected O, but got I4
		//IL_0186: Expected O, but got I
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_08ea: Expected O, but got I
		//IL_0310: Expected O, but got I4
		//IL_0310: Expected O, but got I
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_0921: Expected O, but got I
		//IL_043a: Expected O, but got I4
		//IL_043a: Expected O, but got I
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_0958: Expected O, but got I
		//IL_0566: Expected O, but got I4
		//IL_0566: Expected O, but got I
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected O, but got Unknown
		//IL_098f: Expected O, but got I
		//IL_0692: Expected O, but got I4
		//IL_0692: Expected O, but got I
		//IL_069b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Expected O, but got Unknown
		//IL_09c6: Expected O, but got I
		//IL_07ed: Expected O, but got I4
		//IL_07ed: Expected O, but got I
		//IL_07f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Expected O, but got Unknown
		//IL_09fd: Expected O, but got I
		base.OnEnter();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = ShowAchievements;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7410");
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action action2 = ShowCollections;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7590");
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action3 = ShowCredits;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7710");
		AppStateMachine appStateMachine4 = base.appStateMachine;
		Action action4 = ShowOptions;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7890");
		AppStateMachine appStateMachine5 = base.appStateMachine;
		Action action5 = ShowPowerUps;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7A10");
		AppStateMachine appStateMachine6 = base.appStateMachine;
		Action action6 = ShowCharacterSelect;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action7 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowCharacterSelectScreenSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowCharacterSelectScreenSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = appStateMachine6.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rax_v34 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		AppStateMachine appStateMachine7 = base.appStateMachine;
		Action action8 = ShowOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7050");
		AppStateMachine appStateMachine8 = base.appStateMachine;
		Action action9 = ShowBestiary;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7B90");
		AppStateMachine appStateMachine9 = base.appStateMachine;
		Action action10 = ShowSecrets;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1072 @ rbx_v14 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rbx_v15 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rbx_v15 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj4 = null;
		Action<object> action11 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowSecretsScreenSignal>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowSecretsScreenSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = appStateMachine9.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v57 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		AppStateMachine appStateMachine10 = base.appStateMachine;
		Action<UISignals.QuickStartGameSignal> action12 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7D10");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ rbx_v18 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rbx_v19 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rbx_v19 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj7 = null;
		Action<object> action13 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.QuickStartGameSignal>)obj7)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.QuickStartGameSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = appStateMachine10.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rax_v73 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus3.SubscribeInternal(signalType3, (object)null, (object)0, callback);
		AppStateMachine appStateMachine11 = base.appStateMachine;
		Action action14 = ShowAccountPage;
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1484 @ rbx_v22 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rbx_v23 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rbx_v23 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj10 = null;
		Action<object> action15 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowAccountPageSignal>)obj10)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowAccountPageSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj12 = default(object);
		object obj11 = obj12 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus4 = appStateMachine11.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v89 (System.Object)+10]");
		Type signalType4 = default(Type);
		signalBus4.SubscribeInternal(signalType4, (object)null, (object)0, callback);
		AppStateMachine appStateMachine12 = base.appStateMachine;
		Action action16 = ShowDLCStore;
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ rbx_v26 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rbx_v27 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rbx_v27 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj13 = null;
		Action<object> action17 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowDLCStoreSignal>)obj13)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowDLCStoreSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj15 = default(object);
		object obj14 = obj15 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus5 = appStateMachine12.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v105 (System.Object)+10]");
		Type signalType5 = default(Type);
		signalBus5.SubscribeInternal(signalType5, (object)null, (object)0, callback);
		AppStateMachine appStateMachine13 = base.appStateMachine;
		Action action18 = ShowAdventuresSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7DF0");
		AppStateMachine appStateMachine14 = base.appStateMachine;
		Action action19 = ShowTPCredits;
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1900 @ rbx_v32 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rbx_v33 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rbx_v33 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj16 = null;
		Action<object> action20 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowTPCreditsSignal>)obj16)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowTPCreditsSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj18 = default(object);
		object obj17 = obj18 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus6 = appStateMachine14.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v124 (System.Object)+10]");
		Type signalType6 = default(Type);
		signalBus6.SubscribeInternal(signalType6, (object)null, (object)0, callback);
		AppStateMachine appStateMachine15 = base.appStateMachine;
		appStateMachine15.Multiplayer.ResetMultiplayerSelections();
		BackButtonController instance = BackButtonController.Instance;
		instance.ListenForControllerInput = true;
		AppStateMachine appStateMachine16 = base.appStateMachine;
		MultiplayerManager multiplayer = appStateMachine16.Multiplayer;
		multiplayer.AllowPlayerJoining = false;
		AppStateMachine appStateMachine17 = base.appStateMachine;
		MultiplayerManager multiplayer2 = appStateMachine17.Multiplayer;
		multiplayer2.AllowPlayerRemoval = true;
		AccountButtonController.CanShow = true;
		QuitGameButton.ShouldShow = true;
	}

	public override void OnExit()
	{
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Expected O, but got Unknown
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Expected O, but got Unknown
		base.OnExit();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = ShowAchievements;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7F70");
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action action2 = ShowCollections;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8030");
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action3 = ShowCredits;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA80F0");
		AppStateMachine appStateMachine4 = base.appStateMachine;
		Action action4 = ShowOptions;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA81B0");
		AppStateMachine appStateMachine5 = base.appStateMachine;
		Action action5 = ShowPowerUps;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8270");
		AppStateMachine appStateMachine6 = base.appStateMachine;
		Action token = ShowCharacterSelect;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		appStateMachine6.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		AppStateMachine appStateMachine7 = base.appStateMachine;
		Action action6 = ShowOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7350");
		AppStateMachine appStateMachine8 = base.appStateMachine;
		Action action7 = ShowBestiary;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8330");
		AppStateMachine appStateMachine9 = base.appStateMachine;
		Action token2 = ShowSecrets;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rbx_v14 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ rbx_v15 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		appStateMachine9.SignalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		AppStateMachine appStateMachine10 = base.appStateMachine;
		Action<UISignals.QuickStartGameSignal> token3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7D10");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v864 @ rbx_v18 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v881 @ rbx_v19 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		appStateMachine10.SignalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
		AppStateMachine appStateMachine11 = base.appStateMachine;
		Action token4 = ShowAccountPage;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v958 @ rbx_v22 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v975 @ rbx_v23 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType4 = default(Type);
		appStateMachine11.SignalBus.UnsubscribeInternal(signalType4, (object)null, (object)token4, throwIfMissing);
		AppStateMachine appStateMachine12 = base.appStateMachine;
		Action token5 = ShowDLCStore;
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ rbx_v26 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1069 @ rbx_v27 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj10 = default(object);
		object obj9 = obj10 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType5 = default(Type);
		appStateMachine12.SignalBus.UnsubscribeInternal(signalType5, (object)null, (object)token5, throwIfMissing);
		AppStateMachine appStateMachine13 = base.appStateMachine;
		Action action8 = ShowAdventuresSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA83F0");
		AppStateMachine appStateMachine14 = base.appStateMachine;
		Action token6 = ShowTPCredits;
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1150 @ rbx_v32 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1167 @ rbx_v33 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj12 = default(object);
		object obj11 = obj12 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType6 = default(Type);
		appStateMachine14.SignalBus.UnsubscribeInternal(signalType6, (object)null, (object)token6, throwIfMissing);
		AccountButtonController.CanShow = false;
		QuitGameButton.ShouldShow = false;
	}

	private void ShowDLCStore()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4298]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("OPEN_DLC_STORE");
		GameEventMessage.SendEvent("OPEN_DLC_STORE");
	}

	private void ShowAccountPage()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4299]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("OPEN_ACCOUNT_PAGE");
		GameEventMessage.SendEvent("OPEN_ACCOUNT_PAGE");
	}

	private void ShowAchievements()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A429A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ACHIEVEMENTS");
		GameEventMessage.SendEvent("SHOW_ACHIEVEMENTS");
	}

	private void ShowCollections()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A429B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_COLLECTIONS");
		GameEventMessage.SendEvent("SHOW_COLLECTIONS");
	}

	private void ShowOptions()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A429C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_OPTIONS");
		GameEventMessage.SendEvent("SHOW_OPTIONS");
	}

	private void ShowCredits()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A429D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_CREDITS");
		GameEventMessage.SendEvent("SHOW_CREDITS");
	}

	private void ShowTPCredits()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A429E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("OPEN_TPCREDITS");
		GameEventMessage.SendEvent("OPEN_TPCREDITS");
	}

	private void ShowPowerUps()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A429F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_POWER_UPS");
		GameEventMessage.SendEvent("SHOW_POWER_UPS");
	}

	private void ShowCharacterSelect()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42A0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SELECT_CHARACTER");
		GameEventMessage.SendEvent("SELECT_CHARACTER");
	}

	private void ShowOnlineScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42A1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE");
		GameEventMessage.SendEvent("SHOW_ONLINE");
	}

	private void ShowBestiary()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42A2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("OPEN_BESTIARY");
		GameEventMessage.SendEvent("OPEN_BESTIARY");
	}

	private void ShowSecrets()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42A3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("OPEN_SECRETS");
		GameEventMessage.SendEvent("OPEN_SECRETS");
	}

	private void QuickStartGame(UISignals.QuickStartGameSignal obj)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42A4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("START_GAME");
		GameEventMessage.SendEvent("START_GAME");
	}

	private void ShowAdventuresSelection()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42A5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SELECT_ADVENTURE");
		GameEventMessage.SendEvent("SELECT_ADVENTURE");
	}

	public AppMainMenuState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
