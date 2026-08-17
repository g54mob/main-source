using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class UIButtonAudio : MonoBehaviour
{
	public SfxType _Sound;

	private Button _button;

	private void Start()
	{
		Button component = GetComponent<Button>();
		_button = component;
		Button button = _button;
		UnityAction call = Play;
		button.m_OnClick.AddListener(call);
	}

	private void Play()
	{
		if (_Sound != SfxType.None)
		{
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(_Sound, null, 0f, 10, time);
		}
	}

	public UIButtonAudio()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
