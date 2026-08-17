using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnSkip_CooldownDown : CharacterSkillCard_Base
{
	public SubSkillCard_OnSkip_CooldownDown(ArcanaType type)
		: base(type)
	{
	}

	public override void OnOwnerLevelUpSkipped()
	{
		base.OnOwnerLevelUpSkipped();
		Action action = delegate
		{
			CharacterController linkedCharacter = LinkedCharacter;
			PlayerModifierStats playerStats = linkedCharacter._playerStats;
			EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val - 1f;
			playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
		};
		Action onComplete = delegate
		{
			CharacterController linkedCharacter = LinkedCharacter;
			PlayerModifierStats playerStats = linkedCharacter._playerStats;
			EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + 1f;
			playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v45.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(10f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void _003COnOwnerLevelUpSkipped_003Eb__1_0()
	{
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val - 1f;
		playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
	}

	private void _003COnOwnerLevelUpSkipped_003Eb__1_1()
	{
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + 1f;
		playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
	}
}
