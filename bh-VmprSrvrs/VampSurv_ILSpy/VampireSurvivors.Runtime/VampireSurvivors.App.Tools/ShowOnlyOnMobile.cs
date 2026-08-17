using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Tools;

public class ShowOnlyOnMobile : MonoBehaviour
{
	private void Awake()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public ShowOnlyOnMobile()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
