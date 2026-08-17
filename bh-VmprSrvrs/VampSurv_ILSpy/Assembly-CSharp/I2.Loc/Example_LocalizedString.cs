using Cpp2ILInjected;
using UnityEngine;

namespace I2.Loc;

public class Example_LocalizedString : MonoBehaviour
{
	public LocalizedString _MyLocalizedString;

	public string _NormalString;

	public string _StringWithTermPopup;

	public unsafe void Start()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected O, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		object obj3 = obj + 23;
		_ = _MyLocalizedString;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (I2.Loc.Example_LocalizedString)+30]");
		_ = 0;
		object message = (LocalizedString)obj3;
		Debug.Log(message);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(_NormalString, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		Debug.Log(translation);
		string translation2 = LocalizationManager.GetTranslation(_StringWithTermPopup, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		Debug.Log(translation2);
		_ = 0;
		LocalizedString localizedString = (LocalizedString)(obj + 23);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-9]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1+7]");
		_ = 0;
		string message2 = ((LocalizedString*)localizedString)->ToString();
		Debug.Log(message2);
		object obj4 = obj + 23;
		_ = _MyLocalizedString;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (I2.Loc.Example_LocalizedString)+30]");
		_ = 0;
		object message3 = (LocalizedString)obj4;
		Debug.Log(message3);
		_ = 0;
		object obj5 = obj + 23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-9]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1+7]");
		_ = 0;
		object message4 = (LocalizedString)obj5;
		Debug.Log(message4);
		_ = 0;
		object obj6 = obj + 23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-9]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1+17]");
		_ = 0;
		object message5 = (LocalizedString)obj6;
		Debug.Log(message5);
		_ = 0;
		object obj7 = obj + 23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1+17]");
		_ = 0;
		_ = 20;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1+27]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-9]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1+7]");
		_ = 0;
		object message6 = (LocalizedString)obj7;
		Debug.Log(message6);
		object obj8 = obj + 23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-9]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1+7]");
		_ = 0;
		object message7 = (LocalizedString)obj8;
		Debug.Log(message7);
	}

	public Example_LocalizedString()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
