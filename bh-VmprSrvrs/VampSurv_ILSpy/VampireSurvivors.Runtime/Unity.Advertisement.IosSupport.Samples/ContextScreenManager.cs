using Cpp2ILInjected;
using Unity.Advertisement.IosSupport.Components;
using UnityEngine;

namespace Unity.Advertisement.IosSupport.Samples;

public class ContextScreenManager : MonoBehaviour
{
	public ContextScreenView contextScreenPrefab;

	private void Start()
	{
		Debug.Log("Unity iOS Support: App Tracking Transparency status not checked, because the platform is not iOS.");
	}

	public ContextScreenManager()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
