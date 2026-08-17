using Cpp2ILInjected;
using UnityEngine;

namespace I2.Loc;

public class CallbackNotification : MonoBehaviour
{
	public void OnModifyLocalization()
	{
		string mainTranslation = Localize.MainTranslation;
		if (Localize.MainTranslation != null && mainTranslation._stringLength > 0)
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("Color/Red", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string mainTranslation2 = Localize.MainTranslation.Replace("{PLAYER_COLOR}", translation);
			Localize.MainTranslation = mainTranslation2;
		}
	}

	public CallbackNotification()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
