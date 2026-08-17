using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnDamaged_RecoveryUp(ArcanaType type) : CharacterSkillCard_Base(type)
{
	private float bonusDelay = 10000f;

	private float currentBonusStacks;

	public override void OnOwnerGetDamaged(float damageAmount)
	{
		if (currentBonusStacks < 100f)
		{
			Action action = delegate
			{
				CharacterController linkedCharacter = LinkedCharacter;
				PlayerModifierStats playerStats = linkedCharacter._playerStats;
				EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
				float value = default(float);
				EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
				value = eggFloat._val + 0.1f;
				playerStats._003CRegen_003Ek__BackingField = eggFloat2;
				float num3 = currentBonusStacks + 1f;
				currentBonusStacks = num3;
			};
			Action onComplete = delegate
			{
				CharacterController linkedCharacter = LinkedCharacter;
				PlayerModifierStats playerStats = linkedCharacter._playerStats;
				EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
				float value = default(float);
				EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
				value = eggFloat._val - 0.1f;
				playerStats._003CRegen_003Ek__BackingField = eggFloat2;
				float num3 = currentBonusStacks - 1f;
				currentBonusStacks = num3;
			};
			float num = currentBonusStacks * 100f;
			float num2 = bonusDelay - num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v58.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			float duration = num2 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private void _003COnOwnerGetDamaged_003Eb__3_0()
	{
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + 0.1f;
		playerStats._003CRegen_003Ek__BackingField = eggFloat2;
		float num = currentBonusStacks + 1f;
		currentBonusStacks = num;
	}

	private void _003COnOwnerGetDamaged_003Eb__3_1()
	{
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val - 0.1f;
		playerStats._003CRegen_003Ek__BackingField = eggFloat2;
		float num = currentBonusStacks - 1f;
		currentBonusStacks = num;
	}
}
