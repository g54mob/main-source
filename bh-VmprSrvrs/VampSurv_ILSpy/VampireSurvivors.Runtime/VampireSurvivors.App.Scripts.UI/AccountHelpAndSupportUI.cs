using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI;

public class AccountHelpAndSupportUI : MonoBehaviour, IUIObject, ISelectableUI
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static UnityAction _003C_003E9__8_0;

		public static UnityAction _003C_003E9__8_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CAwake_003Eb__8_0()
		{
			Application.OpenURL("https://poncle.games/account-help");
		}

		internal void _003CAwake_003Eb__8_1()
		{
			Application.OpenURL("https://poncle.games/privacy-policy");
		}
	}

	private const string ACCOUNT_HELP_URL = "https://poncle.games/account-help";

	private const string PRIVACY_POLICY_URL = "https://poncle.games/privacy-policy";

	private TextMeshProUGUI _HelpText;

	private TextMeshProUGUI _HelpButtonText;

	private TextMeshProUGUI _PrivacyPolicyText;

	private TextMeshProUGUI _PrivacyPolicyButtonText;

	private Button _HelpButton;

	private Button _PrivacyPolicyButton;

	private void Awake()
	{
		_HelpButtonText.text = "https://poncle.games/account-help";
		_PrivacyPolicyButtonText.text = "https://poncle.games/privacy-policy";
		Button helpButton = _HelpButton;
		UnityAction call = _003C_003Ec._003C_003E9__8_0;
		if (_003C_003Ec._003C_003E9__8_0 == null)
		{
			call = (_003C_003Ec._003C_003E9__8_0 = delegate
			{
				Application.OpenURL("https://poncle.games/account-help");
			});
		}
		helpButton.m_OnClick.AddListener(call);
		Button privacyPolicyButton = _PrivacyPolicyButton;
		UnityAction call2 = _003C_003Ec._003C_003E9__8_1;
		if (_003C_003Ec._003C_003E9__8_1 == null)
		{
			call2 = (_003C_003Ec._003C_003E9__8_1 = delegate
			{
				Application.OpenURL("https://poncle.games/privacy-policy");
			});
		}
		privacyPolicyButton.m_OnClick.AddListener(call2);
	}

	public void SetHelpText(string text)
	{
		_HelpText.text = text;
	}

	public void SetPrivacyPolicyText(string text)
	{
		_PrivacyPolicyText.text = text;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public Selectable GetSelectable()
	{
		return _HelpButton;
	}

	public unsafe void UpdateNavigation(Selectable above, Selectable below, Selectable left, Selectable right)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0059: Expected O, but got Ref
		//IL_00e2: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Button helpButton = _HelpButton;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rax_v1 (UnityEngine.UI.Button)+48]");
		_ = 0;
		_ = ((Selectable)helpButton).m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rax_v1 (UnityEngine.UI.Button)+38]");
		_ = 0;
		_ = _PrivacyPolicyButton;
		Navigation navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
		_ = 0;
		_HelpButton.navigation = navigation;
		Button privacyPolicyButton = _PrivacyPolicyButton;
		_ = ((Selectable)privacyPolicyButton).m_Navigation;
		_ = 4;
		_ = _HelpButton;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v8 (UnityEngine.UI.Button)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v8 (UnityEngine.UI.Button)+48]");
		_ = 0;
		Navigation navigation2 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v8 (UnityEngine.UI.Button)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v8 (UnityEngine.UI.Button)+48]");
		_ = 0;
		_PrivacyPolicyButton.navigation = navigation2;
	}

	public AccountHelpAndSupportUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
