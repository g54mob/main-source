using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class QuitGameButton : MonoBehaviour
{
	public static bool ShouldShow;

	private void Start()
	{
	}

	public void Quit()
	{
		Application.Quit();
	}

	public QuitGameButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
