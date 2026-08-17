using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class SealPanel : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__7_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CShowWarning_003Eb__7_0()
		{
		}
	}

	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _Amount;

	private CanvasGroup _Warning;

	private Button _PortraitMegaSealButton;

	private PlayerOptions _playerOptions;

	private Tween _warningTween;

	public void Initialize(PlayerOptions player)
	{
		_playerOptions = player;
	}

	public void ShowWarning()
	{
		if (_warningTween != null)
		{
			TweenExtensions.Kill(_warningTween);
		}
		_Warning.alpha = 1f;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(_Warning, 0f, 1f);
		TweenCallback tweenCallback = _003C_003Ec._003C_003E9__7_0;
		if (_003C_003Ec._003C_003E9__7_0 == null)
		{
			tweenCallback = (_003C_003Ec._003C_003E9__7_0 = delegate
			{
			});
		}
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 14;
					_ = 0;
				}
			}
		}
		_warningTween = tweenerCore;
	}

	public void UpdateValues()
	{
		SetNormalLayout();
		GameObject gameObject = base.gameObject;
		PlayerOptionsData config = _playerOptions.Config;
		int num = config._003CSeals_003Ek__BackingField ^ config._003CSeals_003Ek__BackingField;
		int num2 = config._003CSeals_003Ek__BackingField & num;
		bool flag = num2 < 0;
		bool flag2 = config._003CSeals_003Ek__BackingField < 0;
		bool flag3 = config._003CSeals_003Ek__BackingField == 0;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		bool active = flag5 & flag4;
		gameObject.SetActive(active);
	}

	private unsafe void SetNormalLayout()
	{
		//IL_0092: Expected O, but got Ref
		//IL_0123: Expected O, but got Ref
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/seal_header", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_Title.text = translation;
		int maxSeals = _playerOptions.GetMaxSeals();
		object obj = default(object);
		string text2;
		if (maxSeals < 100)
		{
			string text = System.Number.FormatInt32(maxSeals, (ReadOnlySpan<char>)(&obj), null);
			text2 = text;
		}
		else
		{
			text2 = "∞";
		}
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CSealedItems_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		List<WeaponType> list2 = config2._003CSealedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		int value = (int)(num + 0);
		string text3 = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
		string text4 = text3 + " / " + text2;
		_Amount.text = text4;
		GameObject gameObject = _PortraitMegaSealButton.gameObject;
		gameObject.SetActive(value: false);
	}

	private unsafe void SetPortraitMegaSealLayout()
	{
		//IL_009f: Expected O, but got Ref
		//IL_00c0: Expected O, but got Ref
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CSealedItems_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		List<WeaponType> list2 = config2._003CSealedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		int value = (int)(num + 0);
		PlayerOptionsData config3 = _playerOptions.Config;
		object obj = default(object);
		string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
		string text2 = System.Number.FormatInt32(config3._003CSeals_003Ek__BackingField, (ReadOnlySpan<char>)(&obj), null);
		string text3 = " " + text + " / " + text2;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/seal_header", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string text4 = translation + text3;
		_Title.text = text4;
		GameObject gameObject = _PortraitMegaSealButton.gameObject;
		gameObject.SetActive(value: true);
	}

	private bool ShowPortraitMegaFormat()
	{
		return false;
	}

	public SealPanel()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
