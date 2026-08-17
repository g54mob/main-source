using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

public class DisableURPDebugUpdater : MonoBehaviour
{
	private void Awake()
	{
		DebugManager instance = DebugManager.instance;
		if (instance.m_EnableRuntimeUI)
		{
			instance.m_EnableRuntimeUI = false;
			UnityEngine.Rendering.DebugUpdater.DisableRuntime();
		}
	}

	public DisableURPDebugUpdater()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
