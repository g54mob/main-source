using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_A000 : CharacterSkillCard_Base
{
	public CharacterSkillCard_A000(ArcanaType type)
		: base(type)
	{
	}

	public override void InitialActivate()
	{
		//IL_01e1: Expected O, but got F4
		//IL_01ea: Invalid comparison between F4 and O
		//IL_0209: Invalid comparison between F4 and I4
		//IL_0232: Expected O, but got I4
		//IL_036d: Expected O, but got F4
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected O, but got Unknown
		//IL_0399: Expected O, but got F4
		//IL_03be: Invalid comparison between F4 and I4
		//IL_03cd: Invalid comparison between F4 and O
		//IL_03ec: Expected O, but got I4
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_0259: Expected O, but got F4
		//IL_0262: Invalid comparison between F4 and O
		//IL_0281: Invalid comparison between F4 and I4
		//IL_02aa: Expected O, but got I4
		//IL_0428: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		//IL_0154: Expected I, but got O
		//IL_0310: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_00c3: Expected I, but got O
		base.InitialActivate();
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.25f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		float num = 0.25f - (float)obj2;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj3 = flag4 & flag3;
		if (obj3 != null)
		{
			object obj4 = UnityEngine.Random.value;
			bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.35f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
			float num2 = 0.35f - (float)obj2;
			bool flag6 = num2 == 0f;
			bool flag7 = !flag5;
			bool flag8 = !flag6;
			object obj5 = flag8 & flag7;
			if (obj5 == null)
			{
				AddRandomProgressiveBonus();
			}
			else
			{
				CharacterController linkedCharacter = LinkedCharacter;
				if ((object)LinkedCharacter != null && ((UnityEngine.Object)linkedCharacter).m_CachedPtr != (IntPtr)0)
				{
					object obj6 = UnityEngine.Random.RandomRangeInt(1, 5);
					if ((nint)obj6 > 0)
					{
						object obj7;
						do
						{
							bool flag9 = AvailableSlots == 0;
							if (AvailableSlots > 0)
							{
								int availableSlots = AvailableSlots - 1;
								AvailableSlots = availableSlots;
								if (OnEveryLevelUp == null)
								{
									ModifierStats onEveryLevelUp = new ModifierStats();
									OnEveryLevelUp = onEveryLevelUp;
								}
								nint num3 = (nint)typeof(CharacterSkillCard_RandomGenerator);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rcx_v43 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterSkillCard_RandomGenerator>)+E4]");
								flag9 = (nint)0 == 0;
								CharacterSkillCard_RandomGenerator.GetRandomModifierGrowth(OnEveryLevelUp);
							}
							obj7 = !flag9;
						}
						while (obj7 != null);
					}
				}
			}
		}
		object obj8 = UnityEngine.Random.value;
		float num4 = 0.5f - (float)obj2;
		object obj9 = 0.5f ^ obj2;
		object obj10 = 0.5f ^ num4;
		object obj11 = obj9 & obj10;
		bool flag10 = (nint)obj11 < 0;
		bool flag11 = num4 < 0f;
		bool flag12 = (object)0.5f == obj2;
		bool flag13 = flag11 == flag10;
		object obj12 = !flag12;
		object obj13 = flag13 & obj12;
		if (obj13 == null && flag12)
		{
			return;
		}
		ModifierStats modifierStats = new ModifierStats();
		object obj14 = UnityEngine.Random.RandomRangeInt(1, 5);
		if ((nint)obj14 > 0)
		{
			object obj15;
			do
			{
				bool flag14 = AvailableSlots == 0;
				if (AvailableSlots > 0)
				{
					int availableSlots2 = AvailableSlots - 1;
					AvailableSlots = availableSlots2;
					nint num5 = (nint)typeof(CharacterSkillCard_RandomGenerator);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ rcx_v25 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterSkillCard_RandomGenerator>)+E4]");
					flag14 = (nint)0 == 0;
					CharacterSkillCard_RandomGenerator.GetRandomModifierStat(modifierStats);
				}
				obj15 = !flag14;
			}
			while (obj15 != null);
		}
		if ((object)LinkedCharacter != null)
		{
			LinkedCharacter.PlayerStatsUpgrade(modifierStats);
		}
	}
}
