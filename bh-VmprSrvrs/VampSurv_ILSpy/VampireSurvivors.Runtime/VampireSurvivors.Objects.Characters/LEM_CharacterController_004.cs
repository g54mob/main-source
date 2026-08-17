using System;
using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Objects.Characters;

public class LEM_CharacterController_004 : LEM_CharacterController_Base
{
	private int skippedTimes;

	public override bool StartWithSurvarotDraft => false;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
	}

	public override void OnLevelUpSkipped()
	{
		//IL_001d: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_018f: Expected O, but got F4
		//IL_01b5: Invalid comparison between F4 and I4
		//IL_01de: Expected O, but got I4
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		CharacterSkillCardsManager characterSkillCardsManager = CharacterSkillCardsManager;
		List<CharacterSkillCard_Base> characterCards = characterSkillCardsManager._characterCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> characterCards2 = characterSkillCardsManager._characterCards;
		while ((nint)obj2 < characterCards._size)
		{
			if ((nint)obj < characterCards2._size)
			{
				CharacterSkillCard_Base[] items = characterCards2._items;
				items[obj].OnOwnerLevelUpSkipped();
				characterCards2 = characterSkillCardsManager._characterCards;
				obj++;
				obj2 = obj;
				characterCards = characterSkillCardsManager._characterCards;
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
		float num = (float)skippedTimes * 0.05f;
		float num2 = 0.9f - num;
		float num3 = num2 + 0.1f;
		bool flag = 0.1f > num3;
		float num4 = 0.1f;
		if (!flag)
		{
			num4 = num3;
		}
		object obj3 = UnityEngine.Random.value;
		bool flag2 = num4 < num;
		float num5 = num4 - num;
		bool flag3 = num5 == 0f;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		object obj4 = flag5 & flag4;
		if (obj4 != null)
		{
			GiveSurvarocchi();
			int num6 = skippedTimes + 1;
			skippedTimes = num6;
		}
	}
}
