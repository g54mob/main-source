using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;

namespace VampireSurvivors.App.UI;

public static class TextAutoSizeHelper
{
	public unsafe static void UpdateTextSizes(List<TextMeshProUGUI> textObjects, int forceFontSize = -1, bool useLineCount = false)
	{
		//IL_0048: Expected I4, but got I8
		//IL_0051: Expected O, but got I4
		//IL_0503: Expected O, but got I4
		//IL_041e: Expected O, but got Ref
		//IL_00bc: Expected I, but got O
		//IL_00ef: Expected I, but got O
		//IL_0135: Expected O, but got I4
		//IL_02a9: Expected I, but got O
		//IL_036e: Expected O, but got I4
		if (textObjects == null || textObjects._size <= 0)
		{
			return;
		}
		bool flag = useLineCount;
		bool flag2 = false;
		int num = -1;
		object obj = 0;
		bool flag3 = false;
		bool flag4 = false;
		TMP_Text tMP_Text = default(TMP_Text);
		List<TextMeshProUGUI>.Enumerator enumerator = default(List<TextMeshProUGUI>.Enumerator);
		List<TextMeshProUGUI>.Enumerator enumerator3 = default(List<TextMeshProUGUI>.Enumerator);
		TMP_Text tMP_Text2 = default(TMP_Text);
		while (true)
		{
			List<TextMeshProUGUI>.Enumerator enumerator2;
			if ((flag4 ? 1 : 0) < textObjects._size)
			{
				if ((flag2 ? 1 : 0) < textObjects._size)
				{
					TextMeshProUGUI[] items = textObjects._items;
					TextMeshProUGUI textMeshProUGUI = items[flag2 ? 1u : 0u];
					nint num2 = (nint)textMeshProUGUI;
					textMeshProUGUI.ForceMeshUpdate();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (!useLineCount)
					{
						nint num3 = (nint)tMP_Text;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdx_v46 (Il2CppClass<TMPro.TMP_Text>)+678]");
						bool flag5 = false;
						float preferredWidth = tMP_Text.preferredWidth;
						if (0 <= (nint)obj)
						{
							goto IL_0520;
						}
						obj = 0;
					}
					else
					{
						TMP_TextInfo textInfo = tMP_Text.textInfo;
						bool flag6 = textInfo.lineCount <= num;
						bool flag5 = false;
						if (flag6)
						{
							goto IL_0520;
						}
						flag5 = false;
						num = textInfo.lineCount;
					}
					flag3 = flag2;
					goto IL_0520;
				}
			}
			else
			{
				if (forceFontSize != -1)
				{
					int num4 = 0;
					if (enumerator.MoveNext())
					{
						int num5 = 0;
						enumerator2 = (List<TextMeshProUGUI>.Enumerator)(&enumerator);
						break;
					}
					return;
				}
				if ((flag3 ? 1 : 0) < textObjects._size)
				{
					TextMeshProUGUI[] items2 = textObjects._items;
					TextMeshProUGUI textMeshProUGUI2 = items2[flag3 ? 1u : 0u];
					if (!((TMP_Text)textMeshProUGUI2).m_enableAutoSizing)
					{
						((TMP_Text)textMeshProUGUI2).m_enableAutoSizing = true;
						textMeshProUGUI2.SetVerticesDirty();
						textMeshProUGUI2.SetLayoutDirty();
					}
					if ((flag3 ? 1 : 0) < textObjects._size)
					{
						TextMeshProUGUI[] items3 = textObjects._items;
						TextMeshProUGUI textMeshProUGUI3 = items3[flag3 ? 1u : 0u];
						nint num6 = (nint)textMeshProUGUI3;
						textMeshProUGUI3.ForceMeshUpdate();
						if ((flag3 ? 1 : 0) < textObjects._size)
						{
							TextMeshProUGUI[] items4 = textObjects._items;
							TextMeshProUGUI textMeshProUGUI4 = items4[flag3 ? 1u : 0u];
							TextMeshProUGUI textMeshProUGUI5 = items4[flag3 ? 1u : 0u];
							if (((TMP_Text)textMeshProUGUI5).m_enableAutoSizing)
							{
								((TMP_Text)textMeshProUGUI5).m_enableAutoSizing = false;
								textMeshProUGUI5.SetVerticesDirty();
								textMeshProUGUI5.SetLayoutDirty();
							}
							if (enumerator3.MoveNext())
							{
								object obj2 = 0;
								throw new NullReferenceException();
							}
							return;
						}
					}
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			enumerator2 = (List<TextMeshProUGUI>.Enumerator)0;
			break;
			IL_0520:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			tMP_Text2.enableAutoSizing = false;
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			flag = false;
			flag4 = flag2;
		}
		throw new NullReferenceException();
	}
}
