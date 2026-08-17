using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_HPCritical_MaxArmor : CharacterSkillCard_Base
{
	public SubSkillCard_HPCritical_MaxArmor(ArcanaType type)
		: base(type)
	{
	}

	public override void InitialActivate()
	{
		base.InitialActivate();
		CharacterController linkedCharacter = LinkedCharacter;
		linkedCharacter._isCriticalHPEnabled = true;
		CharacterController linkedCharacter2 = LinkedCharacter;
		linkedCharacter2._hasAnyCriticalHPSkill = true;
	}

	public override void OnOwnerCriticalHPTreshold(float rawDamage)
	{
		base.OnOwnerCriticalHPTreshold(rawDamage);
		Action action = delegate
		{
			CharacterController linkedCharacter2 = LinkedCharacter;
			PlayerModifierStats playerStats = linkedCharacter2._playerStats;
			EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + 50f;
			playerStats._003CArmor_003Ek__BackingField = eggFloat2;
		};
		Action onComplete = delegate
		{
			CharacterController linkedCharacter2 = LinkedCharacter;
			PlayerModifierStats playerStats = linkedCharacter2._playerStats;
			EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val - 50f;
			playerStats._003CArmor_003Ek__BackingField = eggFloat2;
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v49.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(10f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		CharacterController linkedCharacter = LinkedCharacter;
		linkedCharacter._isCriticalHPEnabled = false;
	}

	private void _003COnOwnerCriticalHPTreshold_003Eb__2_0()
	{
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + 50f;
		playerStats._003CArmor_003Ek__BackingField = eggFloat2;
	}

	private void _003COnOwnerCriticalHPTreshold_003Eb__2_1()
	{
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val - 50f;
		playerStats._003CArmor_003Ek__BackingField = eggFloat2;
	}
}
