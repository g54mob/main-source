using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace VampireSurvivors;

public class TMPMassReplacer : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SetAutoSizeSettings()
	{
		//IL_001c: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0070: Expected O, but got I
		//IL_0178: Expected I, but got O
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_010a: Expected I, but got O
		TextMeshProUGUI[] array = UnityEngine.Object.FindObjectsOfType<TextMeshProUGUI>();
		object obj = 0;
		object obj2 = 0;
		nint num = 0;
		while ((nint)obj2 < array.Length)
		{
			TextMeshProUGUI textMeshProUGUI = array[obj];
			bool flag = ((TMP_Text)textMeshProUGUI).m_fontSizeMax == ((TMP_Text)textMeshProUGUI).m_fontSize;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871FD8CAh\"");
			TextMeshProUGUI textMeshProUGUI2 = (TextMeshProUGUI)num;
			if (!flag)
			{
				((TMP_Text)textMeshProUGUI).m_fontSizeMax = ((TMP_Text)textMeshProUGUI).m_fontSize;
				textMeshProUGUI.SetVerticesDirty();
				textMeshProUGUI.SetLayoutDirty();
				textMeshProUGUI2 = textMeshProUGUI;
			}
			bool flag2 = ((TMP_Text)textMeshProUGUI).m_fontSizeMin == 12f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871FD907h\"");
			if (!flag2)
			{
				((TMP_Text)textMeshProUGUI).m_fontSizeMin = 12f;
				textMeshProUGUI.SetVerticesDirty();
				textMeshProUGUI.SetLayoutDirty();
				textMeshProUGUI2 = textMeshProUGUI;
			}
			bool flag3 = ((TMP_Text)textMeshProUGUI).m_enableAutoSizing;
			num = (nint)textMeshProUGUI2;
			if (!flag3)
			{
				((TMP_Text)textMeshProUGUI).m_enableAutoSizing = true;
				textMeshProUGUI.SetVerticesDirty();
				textMeshProUGUI.SetLayoutDirty();
				num = (nint)textMeshProUGUI;
			}
			obj++;
			obj2 = obj;
		}
	}

	private TextMeshProUGUI[] GetChildren()
	{
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			return transform.GetComponentsInChildren<TextMeshProUGUI>();
		}
		return (TextMeshProUGUI[])(object)new NullReferenceException();
	}

	public TMPMassReplacer()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
