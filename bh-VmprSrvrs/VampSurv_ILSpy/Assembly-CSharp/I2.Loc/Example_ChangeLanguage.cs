using Cpp2ILInjected;
using UnityEngine;

namespace I2.Loc;

public class Example_ChangeLanguage : MonoBehaviour
{
	public void SetLanguage_English()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA28]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SetLanguage("English");
	}

	public void SetLanguage_French()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA29]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SetLanguage("French");
	}

	public void SetLanguage_Spanish()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA2A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 26 Invalid \"Jump target not found in method: 0x180B82AD0\"");
	}

	public void SetLanguage(string LangName)
	{
		if (LocalizationManager.HasLanguage(LangName))
		{
			LocalizationManager.CurrentLanguage = LangName;
		}
	}

	public Example_ChangeLanguage()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
