using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_Overheal_MightUp(ArcanaType type) : CharacterSkillCard_Base(type)
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

	private void CharacterHealed(float value, float rawValue)
	{
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
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			overHealTimer = timer;
			OnOverhealTriggered(value, rawValue);
		}
	}

	protected unsafe void OnOverhealTriggered(float value, float rawValue)
	{
		//IL_00b0: Expected O, but got Ref
		//IL_00cc: Expected O, but got I4
		//IL_0109: Expected F4, but got O
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float value2 = default(float);
		EggFloat eggFloat2 = new EggFloat(value2, eggFloat._eggVal);
		value2 = eggFloat._val + 0.03f;
		playerStats._003CPower_003Ek__BackingField = eggFloat2;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj = default(object);
		CharacterController characterController = default(CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		string textureName = default(string);
		core._gizmoManager.DisplayIconOverhead("Leaf", "", (Color?)(object)(&obj), characterController, displayTimeMultiplier, vOffset, textureName);
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
