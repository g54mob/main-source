using System;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VampireSurvivors;

public class InstantiationSceneSetter : MonoBehaviour
{
	private void Awake()
	{
		//IL_0087: Expected O, but got I4
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if ((object)CoherenceBridgeStore.masterBridge != null && ((UnityEngine.Object)masterBridge).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
			GameObject gameObject = base.gameObject;
			Scene scene = gameObject.scene;
			CoherenceBridge coherenceBridge = default(CoherenceBridge);
			coherenceBridge.InstantiationScene = (Scene?)(object)1;
		}
	}

	public InstantiationSceneSetter()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
