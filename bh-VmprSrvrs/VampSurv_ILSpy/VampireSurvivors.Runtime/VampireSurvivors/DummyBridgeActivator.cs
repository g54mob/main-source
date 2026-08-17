using System;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class DummyBridgeActivator : MonoBehaviour
{
	private CoherenceBridge _bridge;

	private CoherenceLiveQuery _liveQuery;

	private void Awake()
	{
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if ((object)CoherenceBridgeStore.masterBridge == null || ((UnityEngine.Object)masterBridge).m_CachedPtr == (IntPtr)0)
		{
			_bridge.enabled = true;
			_liveQuery.enabled = true;
		}
	}

	public DummyBridgeActivator()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
