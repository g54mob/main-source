using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VampireSurvivors.App.Framework;

public class Bootloader : MonoBehaviour
{
	private void Awake()
	{
		//IL_0019: Expected O, but got I4
		Scene scene = SceneManager.LoadScene("Preloader", (LoadSceneParameters)0);
	}

	public Bootloader()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
