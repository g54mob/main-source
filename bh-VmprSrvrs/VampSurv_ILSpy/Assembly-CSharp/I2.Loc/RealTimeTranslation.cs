using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace I2.Loc;

public class RealTimeTranslation : MonoBehaviour
{
	private string OriginalText;

	private string TranslatedText;

	private bool IsTranslating;

	public void OnGUI()
	{
		//IL_0347: Expected F4, but got I4
		//IL_00d6: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		//IL_038b: Expected F4, but got I4
		//IL_0284: Expected O, but got I4
		GUILayoutOption[] options = Array.Empty<GUILayoutOption>();
		GUILayout.Label("Translate:", options);
		GUILayoutOption[] options2 = new GUILayoutOption[1];
		float width = Screen.width;
		GUILayoutOption gUILayoutOption = GUILayout.Width(width);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string originalText = GUILayout.TextArea(OriginalText, options2);
		OriginalText = originalText;
		GUILayout.Space(10f);
		GUILayoutOption[] options3 = Array.Empty<GUILayoutOption>();
		GUILayout.BeginHorizontal(options3);
		GUILayoutOption[] options4 = new GUILayoutOption[1];
		GUILayoutOption gUILayoutOption2 = GUILayout.Height(100f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (GUILayout.Button("English -> Español", options4))
		{
			StartTranslating("en", "es");
			object obj = 0;
		}
		GUILayoutOption[] options5 = new GUILayoutOption[1];
		GUILayoutOption gUILayoutOption3 = GUILayout.Height(100f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (GUILayout.Button("Español -> English", options5))
		{
			StartTranslating("es", "en");
			object obj = 0;
		}
		GUILayoutUtility.EndLayoutGroup();
		GUILayout.Space(10f);
		GUILayoutOption[] options6 = Array.Empty<GUILayoutOption>();
		GUILayout.BeginHorizontal(options6);
		GUILayoutOption[] options7 = Array.Empty<GUILayoutOption>();
		string text = GUILayout.TextArea("Multiple Translation with 1 call:\n'This is an example' -> en,zh\n'Hola' -> en", options7);
		GUILayoutOption[] options8 = new GUILayoutOption[1];
		GUILayoutOption gUILayoutOption4 = GUILayout.ExpandHeight(expand: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (GUILayout.Button("Multi Translate", options8))
		{
			IsTranslating = true;
			Dictionary<string, TranslationQuery> dictionary = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002EA0");
			GoogleTranslation.AddQuery("This is an example", "en", "es", dictionary);
			GoogleTranslation.AddQuery("This is an example", "auto", "zh", dictionary);
			GoogleTranslation.AddQuery("Hola", "es", "en", dictionary);
			GoogleTranslation.fnOnTranslationReady onTranslationReady = OnMultitranslationReady;
			GoogleTranslation.Translate(dictionary, onTranslationReady);
			object obj = 0;
		}
		GUILayoutUtility.EndLayoutGroup();
		GUILayoutOption[] options9 = new GUILayoutOption[1];
		float width2 = Screen.width;
		GUILayoutOption gUILayoutOption5 = GUILayout.Width(width2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string text2 = GUILayout.TextArea(TranslatedText, options9);
		GUILayout.Space(10f);
		if (IsTranslating)
		{
			GUILayoutOption[] options10 = Array.Empty<GUILayoutOption>();
			GUILayout.Label("Contacting Google....", options10);
		}
	}

	public unsafe void StartTranslating(string fromCode, string toCode)
	{
		//IL_0012: Expected I, but got O
		//IL_0028: Expected O, but got I
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_00e6: Expected I, but got O
		//IL_0155: Expected O, but got I4
		//IL_016c: Expected I, but got I8
		//IL_00c2: Expected I, but got I8
		//IL_0088: Expected I, but got I8
		IsTranslating = true;
		GoogleTranslation.fnOnTranslated fnOnTranslated = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r9_v1 (Il2CppMethodInfo)+8]");
		((Delegate)fnOnTranslated).method_ptr = (IntPtr)0;
		((Delegate)fnOnTranslated).method = (nint)__ldftn(RealTimeTranslation.OnTranslationReady);
		((Delegate)fnOnTranslated).m_target = this;
		((Delegate)fnOnTranslated).method_code = (IntPtr)fnOnTranslated;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r9_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		nint num2;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r9_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 != 2)
			{
				goto IL_00c7;
			}
			num2 = unchecked((nint)6447144256L);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r9_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 != 1)
			{
				goto IL_00c7;
			}
			num2 = unchecked((nint)6447144208L);
		}
		goto IL_014c;
		IL_00c7:
		num2 = ((Delegate)fnOnTranslated).method_ptr;
		((Delegate)fnOnTranslated).method_code = (IntPtr)((Delegate)fnOnTranslated).m_target;
		goto IL_014c;
		IL_014c:
		object obj3 = 24;
		((Delegate)fnOnTranslated).extra_arg = unchecked((nint)6447144080L);
		GoogleTranslation.Translate(OriginalText, fromCode, toCode, fnOnTranslated);
	}

	private void OnTranslationReady(string Translation, string errorMsg)
	{
		IsTranslating = false;
		if (errorMsg == null)
		{
			TranslatedText = Translation;
		}
		else
		{
			Debug.LogError(errorMsg);
		}
	}

	public void ExampleMultiTranslations_Blocking()
	{
		//IL_0131: Expected O, but got I
		//IL_0147: Expected O, but got I
		Dictionary<string, TranslationQuery> dictionary = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002EA0");
		GoogleTranslation.AddQuery("This is an example", "en", "es", dictionary);
		GoogleTranslation.AddQuery("This is an example", "auto", "zh", dictionary);
		GoogleTranslation.AddQuery("Hola", "es", "en", dictionary);
		TranslationJob_Main translationJob_Main = new TranslationJob_Main(dictionary, null);
		while (true)
		{
			switch (translationJob_Main.GetState())
			{
			case TranslationJob.eJobState.Running:
				continue;
			case TranslationJob.eJobState.Failed:
				return;
			}
			string queryResult = GoogleTranslation.GetQueryResult("This is an example", "en", dictionary);
			Debug.Log(queryResult);
			string queryResult2 = GoogleTranslation.GetQueryResult("This is an example", "zh", dictionary);
			Debug.Log(queryResult2);
			string queryResult3 = GoogleTranslation.GetQueryResult("This is an example", "", dictionary);
			Debug.Log(queryResult3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002F30");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v27+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v25+20]");
			Debug.Log(0);
			return;
		}
	}

	public void ExampleMultiTranslations_Async()
	{
		IsTranslating = true;
		Dictionary<string, TranslationQuery> dictionary = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002EA0");
		GoogleTranslation.AddQuery("This is an example", "en", "es", dictionary);
		GoogleTranslation.AddQuery("This is an example", "auto", "zh", dictionary);
		GoogleTranslation.AddQuery("Hola", "es", "en", dictionary);
		GoogleTranslation.fnOnTranslationReady onTranslationReady = OnMultitranslationReady;
		GoogleTranslation.Translate(dictionary, onTranslationReady);
	}

	private void OnMultitranslationReady(Dictionary<string, TranslationQuery> dict, string errorMsg)
	{
		//IL_0140: Expected O, but got I
		//IL_015c: Expected O, but got I
		if (errorMsg != null && errorMsg._stringLength > 0)
		{
			Debug.LogError(errorMsg);
			return;
		}
		IsTranslating = false;
		TranslatedText = "";
		string queryResult = GoogleTranslation.GetQueryResult("This is an example", "es", dict);
		string translatedText = TranslatedText + queryResult + "\n";
		TranslatedText = translatedText;
		string queryResult2 = GoogleTranslation.GetQueryResult("This is an example", "zh", dict);
		string translatedText2 = TranslatedText + queryResult2 + "\n";
		TranslatedText = translatedText2;
		string queryResult3 = GoogleTranslation.GetQueryResult("This is an example", "", dict);
		string translatedText3 = TranslatedText + queryResult3 + "\n";
		TranslatedText = translatedText3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002F30");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rax_v19+20]");
		object obj = 0;
		string translatedText4 = TranslatedText;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rdx_v15+20]");
		string translatedText5 = translatedText4 + (string)0;
		TranslatedText = translatedText5;
	}

	public bool IsWaitingForTranslation()
	{
		return IsTranslating;
	}

	public string GetTranslatedText()
	{
		return TranslatedText;
	}

	public void SetOriginalText(string text)
	{
		OriginalText = text;
	}

	public RealTimeTranslation()
	{
		//IL_0090: Expected O, but got I
		//IL_00a0: Expected O, but got I
		//IL_0058: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA34]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		OriginalText = "This is an example showing how to use the google translator to translate chat messages within the game.\nIt also supports multiline translations.";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v4+B8]");
		object translatedText = 0;
		TranslatedText = (string)translatedText;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v6 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
