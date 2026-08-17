using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Platforms;
using Zenject;

namespace VampireSurvivors.UI;

public class LandingScreenPage : MonoBehaviour
{
	public string AudioClip;

	private SignalBus _signalBus;

	private void Construct(SignalBus signal)
	{
		_signalBus = signal;
	}

	private void Start()
	{
	}

	private void Update()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_00aa: Expected F4, but got I4
		SystemPlatform sInstance = SystemPlatform.sInstance;
		IBaseAccount currentSystem = sInstance.m_CurrentSystem;
		if (Extensions.AnyDown(currentSystem.m_Player))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool flag = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, flag);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, flag ? 1 : 0);
		}
	}

	private void MoveToNextView()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0068: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool flag = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, flag);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, flag ? 1 : 0);
	}

	public LandingScreenPage()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
