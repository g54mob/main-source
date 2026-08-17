using System;
using System.Reflection;
using Coherence.Connection;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace VampireSurvivors;

public class LobbyCharacterData : MonoBehaviour
{
	private static LobbyCharacterData _003CInstance_003Ek__BackingField;

	private int _003CRnjNameIndex_003Ek__BackingField;

	private string _003CRnjSpriteName_003Ek__BackingField;

	private int _003CRnjStartingWeapon_003Ek__BackingField;

	private uint _003CMissingNoSeed_003Ek__BackingField;

	public static LobbyCharacterData Instance
	{
		get
		{
			return _003CInstance_003Ek__BackingField;
		}
		private set
		{
			_003CInstance_003Ek__BackingField = value;
		}
	}

	public int RnjNameIndex
	{
		get
		{
			return _003CRnjNameIndex_003Ek__BackingField;
		}
		set
		{
			_003CRnjNameIndex_003Ek__BackingField = value;
		}
	}

	public string RnjSpriteName
	{
		get
		{
			return _003CRnjSpriteName_003Ek__BackingField;
		}
		set
		{
			_003CRnjSpriteName_003Ek__BackingField = value;
		}
	}

	public int RnjStartingWeapon
	{
		get
		{
			return _003CRnjStartingWeapon_003Ek__BackingField;
		}
		set
		{
			_003CRnjStartingWeapon_003Ek__BackingField = value;
		}
	}

	public uint MissingNoSeed
	{
		get
		{
			return _003CMissingNoSeed_003Ek__BackingField;
		}
		set
		{
			_003CMissingNoSeed_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_006c: Expected O, but got I
		_003CInstance_003Ek__BackingField = this;
		Debug.Log("LobbyCharacterData Awake");
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected = masterBridge.onDisconnected;
		UnityAction<CoherenceBridge, ConnectionCloseReason> action = OnDisconnected;
		UnityEngine.Events.BaseInvokableCall baseInvokableCall = UnityEvent<CoherenceBridge, ConnectionCloseReason>.GetDelegate(action);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rsi_v2 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A5D0D0");
		_ = 1;
	}

	private void OnDestroy()
	{
		//IL_006e: Expected O, but got I
		//IL_006e: Expected O, but got I
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected = masterBridge.onDisconnected;
		UnityAction<CoherenceBridge, ConnectionCloseReason> unityAction = OnDisconnected;
		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rsi_v2 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v9 (UnityEngine.Events.UnityAction`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+20]");
		((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
	}

	private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	public LobbyCharacterData()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
