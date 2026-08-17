using System;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class CardRiskInfoUI : MonoBehaviour
{
	private TextMeshProUGUI _riskTitle;

	private TextMeshProUGUI _riskDescription;

	public unsafe void UpdateText()
	{
		//IL_0081: Expected I, but got O
		//IL_01df: Expected I, but got O
		//IL_0099: Expected O, but got Ref
		//IL_00d0: Expected O, but got Ref
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("arcanaLang/{SURVAROT_RISK}name", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_riskTitle.text = translation;
		string translation2 = LocalizationManager.GetTranslation("arcanaLang/{SURVAROT_RISK}description", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		nint num = (nint)typeof(GameManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v8 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+B8]");
		nint num2 = 0;
		float num3 = GameManager.DifficultyAdjustmentEnemyHPMultiplier - 1f;
		float num4 = num3 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		nint num5 = (nint)typeof(GameManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rcx_v10 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+B8]");
		nint num6 = 0;
		float num7 = GameManager.DifficultyAdjustmentEnemyDamageMultiplier - 1f;
		float num8 = num7 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int value = default(int);
		object obj = default(object);
		string newValue = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
		string text = translation2.Replace("%0", newValue);
		int value2 = default(int);
		string newValue2 = System.Number.FormatInt32(value2, (ReadOnlySpan<char>)(&obj), null);
		string text2 = text.Replace("%1", newValue2);
		_riskDescription.text = text2;
		TextMeshProUGUI riskDescription = _riskDescription;
		if (((TMP_Text)riskDescription).m_HorizontalAlignment != HorizontalAlignmentOptions.Left || ((TMP_Text)riskDescription).m_VerticalAlignment != VerticalAlignmentOptions.Top)
		{
			((TMP_Text)riskDescription).m_HorizontalAlignment = HorizontalAlignmentOptions.Left;
			((TMP_Text)riskDescription).m_VerticalAlignment = VerticalAlignmentOptions.Top;
			((TMP_Text)riskDescription).m_havePropertiesChanged = true;
			riskDescription.SetVerticesDirty();
		}
	}

	public CardRiskInfoUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
