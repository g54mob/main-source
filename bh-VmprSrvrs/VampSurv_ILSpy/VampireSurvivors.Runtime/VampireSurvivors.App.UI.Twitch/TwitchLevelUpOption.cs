using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.App.UI.Twitch;

public class TwitchLevelUpOption : MonoBehaviour
{
	private TextMeshProUGUI _OptionText;

	private Action _callback;

	public TextMeshProUGUI OptionText => _OptionText;

	private void Awake()
	{
	}

	public void SetOptionCallback(Action callback)
	{
		_callback = callback;
	}

	public void TriggerCallback()
	{
		Action callback = _callback;
		if (_callback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public TwitchLevelUpOption()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
