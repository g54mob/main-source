using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class BackButtonController : MonoBehaviour
{
	public static BackButtonController Instance;

	public static bool BackButtonClosesPage = true;

	public static bool IgnoreNextAdditionalListner = false;

	public bool ListenForControllerInput = true;

	private SignalBus _signalBus;

	private SelectableUI _selectable;

	private Selectable _rawSelectable;

	private Rewired.Player Player;

	private MultiplayerManager _multiplayer;

	private List<Action> _backtions;

	private GameObject randomize;

	private GameObject musicSelection;

	private void Construct(SignalBus signal, MultiplayerManager multi)
	{
		_signalBus = signal;
		_multiplayer = multi;
	}

	private void Awake()
	{
		//IL_0085: Expected O, but got I4
		//IL_0085: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_02fa: Expected O, but got I
		//IL_0154: Expected O, but got I4
		//IL_0154: Expected O, but got I
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0335: Expected O, but got I
		//IL_0200: Expected O, but got I4
		//IL_0200: Expected O, but got I
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_036e: Expected O, but got I
		Action<UISignals.ShowBackButtonSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99F00");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ShowBackButtonSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ShowBackButtonSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v12 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = Hide;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99FE0");
		Action<UISignals.ForceBackButtonNavigation> action4 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A160");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action5 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ForceBackButtonNavigation>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ForceBackButtonNavigation>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v30 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Action<UISignals.ResetBackButtonNavigation> action6 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A240");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj7 = null;
		Action<object> action7 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ResetBackButtonNavigation>)obj7)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ResetBackButtonNavigation>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v45 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus3.SubscribeInternal(signalType3, (object)null, (object)0, callback);
		SelectableUI component = GetComponent<SelectableUI>();
		_selectable = component;
		Selectable component2 = GetComponent<Selectable>();
		_rawSelectable = component2;
		Instance = this;
		ReInput.PlayerHelper players = ReInput.players;
		Rewired.Player player = players.GetPlayer(0);
		Player = player;
		randomize.SetActive(value: false);
		musicSelection.SetActive(value: false);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		Action<UISignals.ShowBackButtonSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = Hide;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rbx_v6 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		Action<UISignals.ForceBackButtonNavigation> token3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A160");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rbx_v10 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rbx_v11 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
		Action<UISignals.ResetBackButtonNavigation> token4 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A240");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rbx_v14 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rbx_v15 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType4 = default(Type);
		_signalBus.UnsubscribeInternal(signalType4, (object)null, (object)token4, throwIfMissing);
	}

	private void Update()
	{
		//IL_0033: Expected O, but got I4
		if (!ListenForControllerInput)
		{
			return;
		}
		PopupManager instance = PopupManager.Instance;
		Dictionary<string, GameObject> popups = instance._popups;
		object obj = popups._count - popups._freeCount;
		if ((nint)obj > 0)
		{
			return;
		}
		Rewired.Player currentUIPlayer = _multiplayer.GetCurrentUIPlayer();
		Player = currentUIPlayer;
		int playerCount = _multiplayer.GetPlayerCount();
		if (playerCount <= 1 && !_multiplayer.IsOnlineMultiplayer && BackButtonClosesPage)
		{
			if (!Player.GetButtonDown(6) && !Player.GetButtonDown(10))
			{
				return;
			}
		}
		else
		{
			if (!BackButtonClosesPage || _multiplayer.IsUIBeingBlocked || (!Player.GetButtonDown(6) && !Player.GetButtonDown(10)))
			{
				return;
			}
			Debug.Log("Back button pressed!");
			Button component = GetComponent<Button>();
			component.Select();
		}
		Button component2 = GetComponent<Button>();
		component2.m_OnClick.Invoke();
	}

	public static void AddListener(Action b)
	{
		if (!IgnoreNextAdditionalListner)
		{
			BackButtonController instance = Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F2220");
		}
		IgnoreNextAdditionalListner = false;
	}

	public static void TryRemoveListener(Action b)
	{
		Debug.Log("Removing");
		BackButtonController instance = Instance;
		if ((object)Instance == null || ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		BackButtonController instance2 = Instance;
		List<Action> backtions = instance2._backtions;
		if (backtions._size != 0)
		{
			int num = Array.IndexOf((object[])backtions._items, (object)b, 0, backtions._size);
			if (num != -1)
			{
				BackButtonController instance3 = Instance;
				bool flag = ((List<object>)(object)instance3._backtions).Remove((object)b);
			}
		}
	}

	private void RunLastAction()
	{
		IEnumerable<object> backtions = _backtions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.IEnumerable`1<System.Object>)+18]");
		if ((nint)0 > (nint)0)
		{
			object obj = Enumerable.Last(backtions);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v60 @ rax_v5 (System.Object)+18] (should have been resolved before IL gen)");
		}
	}

	public static void FireBack()
	{
		BackButtonController instance = Instance;
		IEnumerable<object> backtions = instance._backtions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v8 (System.Collections.Generic.IEnumerable`1<System.Object>)+18]");
		if ((nint)0 > (nint)0)
		{
			object obj = Enumerable.Last(backtions);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v73 @ rax_v9 (System.Object)+18] (should have been resolved before IL gen)");
		}
	}

	public static void GoBack()
	{
		Button component = Instance.GetComponent<Button>();
		component.Select();
		Button component2 = Instance.GetComponent<Button>();
		component2.m_OnClick.Invoke();
	}

	private void Show(UISignals.ShowBackButtonSignal sig)
	{
		//IL_001c: Expected I4, but got O
		SelectableUI selectable = _selectable;
		selectable.IsDefaultSelectedOnPage = (byte)(int)sig != 0;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
	}

	private unsafe void SetNavigation(UISignals.ForceBackButtonNavigation sig)
	{
		//IL_0014: Expected O, but got Ref
		Selectable selectable = default(Selectable);
		_rawSelectable.navigation = (Navigation)(&selectable);
	}

	private unsafe void ResetNavigation(UISignals.ResetBackButtonNavigation sig)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		_rawSelectable.navigation = (Navigation)(&obj);
	}

	private void Hide()
	{
		randomize.SetActive(value: false);
		musicSelection.SetActive(value: false);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public BackButtonController()
	{
		List<Action> backtions = new List<Action>();
		_backtions = backtions;
	}
}
