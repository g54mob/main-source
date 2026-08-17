using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_Overheal_FeverUp(ArcanaType type) : CharacterSkillCard_Base(type)
{
	private float overhealTriggerValue = 16f;

	private Timer overHealTimer;

	private bool canOverheal = true;

	private float overhealDelay = 100f;

	public override void InitialActivate()
	{
		base.InitialActivate();
		CharacterController linkedCharacter = LinkedCharacter;
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj = Delegate.Combine(linkedCharacter._onHpRecoveryCallback, b);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		linkedCharacter._onHpRecoveryCallback = (Action<float, float>)obj;
		canOverheal = true;
	}

	private unsafe void CharacterHealed(float value, float rawValue)
	{
		//IL_014d: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_014d: Expected F4, but got O
		//IL_014d: Expected O, but got I4
		//IL_014d: Expected O, but got Ref
		//IL_0169: Expected O, but got I4
		//IL_01a6: Expected F4, but got I4
		float num = rawValue - value;
		if (!(num < overhealTriggerValue) && canOverheal)
		{
			canOverheal = false;
			if (overHealTimer != null)
			{
				overHealTimer.Cancel();
			}
			Action onComplete = delegate
			{
				canOverheal = true;
			};
			float duration = overhealDelay * 0.001f;
			bool flag = default(bool);
			MonoBehaviour monoBehaviour = default(MonoBehaviour);
			int num2 = default(int);
			TimerType timerType = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, flag, monoBehaviour, num2, timerType, isOnlineTimer: false, canPause: false);
			overHealTimer = timer;
			CharacterController linkedCharacter = LinkedCharacter;
			PlayerModifierStats playerStats = linkedCharacter._playerStats;
			float num3 = playerStats._003CFever_003Ek__BackingField + 0.01f;
			playerStats._003CFever_003Ek__BackingField = num3;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			core._gizmoManager.DisplayIconOverhead("antipyretic", "", (Color?)(object)(&obj), (CharacterController)flag, (float)monoBehaviour, (Vector2)num2, (string)timerType);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Detune = 500f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LittleHeart, soundConfig, 150f, 3, flag ? 1 : 0);
		}
	}

	protected unsafe void OnOverhealTriggered(float value, float rawValue)
	{
		//IL_007d: Expected O, but got Ref
		//IL_0099: Expected O, but got I4
		//IL_00d6: Expected F4, but got O
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		float num = playerStats._003CFever_003Ek__BackingField + 0.01f;
		playerStats._003CFever_003Ek__BackingField = num;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj = default(object);
		CharacterController characterController = default(CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		string textureName = default(string);
		core._gizmoManager.DisplayIconOverhead("antipyretic", "", (Color?)(object)(&obj), characterController, displayTimeMultiplier, vOffset, textureName);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = 500f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LittleHeart, soundConfig, 150f, 3, (float)characterController);
	}

	private void _003CCharacterHealed_003Eb__6_0()
	{
		canOverheal = true;
	}
}
