using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.Platforms;

public class NintendoSwitchRewiredLayoutHelper : MonoBehaviour
{
	private string _MapCategory;

	private string _NormalLayout;

	private string _SwitchLayout;

	private static string s_MapCategory = "Default";

	private static string s_NormalLayout = "Default";

	private static string s_SwitchLayout = "Nintendo Switch";

	public NintendoSwitchRewiredLayoutHelper()
	{
		//IL_0068: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2995]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_MapCategory = "Default";
		_NormalLayout = "Default";
		_SwitchLayout = "Nintendo Switch";
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rcx_v7 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
