using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace VampireSurvivors;

public class LanguageButtonUI : MonoBehaviour
{
	private TextMeshProUGUI Text;

	private string Code;

	private string Name;

	private LanguageController Controller;

	public void SetLanguage(LanguageController controller, string name, string code)
	{
		Text.text = name;
		Code = code;
		Name = name;
		Controller = controller;
	}

	public void ApplyLanguage()
	{
		Controller.ApplyLanguage(Code);
	}

	public LanguageButtonUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
