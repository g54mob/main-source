using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class FB_Ariana : CharacterController_FirstBlood
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__2_0;

		public static Predicate<Equipment> _003C_003E9__2_1;

		public static Predicate<Equipment> _003C_003E9__2_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CLevelUp_003Eb__2_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 334;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CLevelUp_003Eb__2_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 322;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CLevelUp_003Eb__2_2(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 335;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private float cooldownBonus;

	public override float PArmor()
	{
		//IL_01e2: Invalid comparison between I4 and F4
		//IL_01f4: Expected F4, but got I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float num = base.PMoveSpeed();
		object obj = default(object);
		float num2 = (float)obj - 1f;
		if (!(num2 > 1f))
		{
			object obj2 = 1f & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_01d9;
			}
		}
		num2 = 1f;
		goto IL_01d9;
		IL_0202:
		float num3;
		return num3;
		IL_01d9:
		bool flag = !(0f < num2);
		float num4 = 0f;
		if (!flag)
		{
			num4 = num2;
		}
		float num5 = num4 * 10f;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = num5 + eggFloat._val;
		float value2 = default(float);
		EggFloat eggFloat3 = new EggFloat(value2, eggFloat2._eggVal);
		value2 = eggFloat2._val + ArmorManualIncrease;
		num3 = eggFloat3._eggVal + eggFloat3._val;
		object obj3 = num3 & -2147483649L;
		if ((nint)obj3 != 2139095040)
		{
			object obj4 = num3 & -2147483649L;
			if ((nint)obj4 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875DDAB8h\"");
				if (num3 == -1f / 0f)
				{
					num3 = -3.4028235E+38f;
				}
				goto IL_0202;
			}
		}
		num3 = 3.4028235E+38f;
		goto IL_0202;
	}

	public override void LevelUp()
	{
		base.LevelUp();
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		cooldownBonus = 0f;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__2_0;
		if (_003C_003Ec._003C_003E9__2_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__2_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 334;
				return obj == null;
			});
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		CharacterWeaponsManager weaponsManager2 = ((CharacterController)this)._weaponsManager;
		Predicate<Equipment> match2 = _003C_003Ec._003C_003E9__2_1;
		if (_003C_003Ec._003C_003E9__2_1 == null)
		{
			match2 = (_003C_003Ec._003C_003E9__2_1 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 322;
				return obj == null;
			});
		}
		Equipment equipment2 = ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField.Find(match2);
		CharacterWeaponsManager weaponsManager3 = ((CharacterController)this)._weaponsManager;
		Predicate<Equipment> match3 = _003C_003Ec._003C_003E9__2_2;
		if (_003C_003Ec._003C_003E9__2_2 == null)
		{
			match3 = (_003C_003Ec._003C_003E9__2_2 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 335;
				return obj == null;
			});
		}
		Equipment equipment3 = ((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField.Find(match3);
		if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
		{
			float num = cooldownBonus + 0.05f;
			cooldownBonus = num;
		}
		if ((object)equipment2 != null && ((UnityEngine.Object)equipment2).m_CachedPtr != (IntPtr)0)
		{
			float num2 = cooldownBonus + 0.05f;
			cooldownBonus = num2;
		}
		if ((object)equipment3 != null && ((UnityEngine.Object)equipment3).m_CachedPtr != (IntPtr)0)
		{
			float num3 = cooldownBonus + 0.05f;
			cooldownBonus = num3;
		}
	}

	public override float PCooldown()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_0116: Expected F4, but got I4
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val - cooldownBonus;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875DE214h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_0106;
			}
		}
		num = 3.4028235E+38f;
		goto IL_0106;
		IL_0106:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1875FFEF0");
		return 0f;
	}
}
