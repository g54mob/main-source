using System;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class EnemyItemUI : SelectableUI
{
	private TextMeshProUGUI _Number;

	private TextMeshProUGUI _Name;

	private Image _Background;

	private BestiaryPage _page;

	private EnemyData _data;

	private EnemyType _type;

	private bool _hasKilled;

	public unsafe void SetData(EnemyType type, int count, EnemyData dat, BestiaryPage page, bool hasKilled)
	{
		//IL_001f: Expected O, but got Ref
		//IL_00a9: Expected O, but got Ref
		int value = count + 1;
		if ("000" != null)
		{
		}
		object obj = default(object);
		string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
		_Number.text = text;
		BestiaryPage page2 = default(BestiaryPage);
		_page = page2;
		_data = dat;
		bool flag = default(bool);
		_hasKilled = flag;
		_type = type;
		if (dat._003CbHighlight_003Ek__BackingField && flag)
		{
			_Name.color = (Color)(&obj);
		}
		string text2;
		if (_hasKilled)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C86]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string localPrefix = dat.GetLocalPrefix(type);
			string term = localPrefix + "bName";
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text2 = translation;
		}
		else
		{
			text2 = "---------------";
		}
		_Name.text = text2;
	}

	public bool HasKilled()
	{
		return _hasKilled;
	}

	protected override void OnSelected()
	{
		_Background.enabled = true;
		_page.SetInfoPanel(_type, _data, this);
	}

	protected override void OnDeselected()
	{
		_Background.enabled = false;
	}

	private void SetInfoPanel()
	{
		_page.SetInfoPanel(_type, _data, this);
	}

	public EnemyItemUI()
	{
		//IL_0036: Expected I, but got O
		base._ShowSelector = true;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
