using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Slash2_Weapon : Weapon
{
	protected override void OnStart()
	{
		base.OnStart();
		base._003CCanCrit_003Ek__BackingField = true;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	protected override float CalcCritMul()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_025b: Expected O, but got I
		//IL_033c: Invalid comparison between F4 and I
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData == null || (object)((Equipment)this)._003COwner_003Ek__BackingField == null)
		{
			goto IL_0366;
		}
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PArea();
		float num3 = default(float);
		float num2 = num3 - 1f;
		if (!(num2 > 1f))
		{
			object obj = 1f & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				goto IL_039b;
			}
		}
		num2 = 1f;
		goto IL_039b;
		IL_03d9:
		WeaponData currentWeaponData2 = _currentWeaponData;
		float num4 = num2 + currentWeaponData._003CcritMul_003Ek__BackingField;
		float num6;
		float num5 = num4 + num6;
		float num7 = num5 + num3;
		if (_currentWeaponData == null)
		{
			goto IL_0366;
		}
		float num8 = currentWeaponData2._003CcritMul_003Ek__BackingField;
		if (!(num7 > currentWeaponData2._003CcritMul_003Ek__BackingField))
		{
			object obj2 = num7 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0434;
			}
		}
		num8 = num7;
		goto IL_0434;
		IL_0434:
		List<float> critChancesArray = _critChancesArray;
		if (_critChancesArray != null)
		{
			int critIndex = _critIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num9 = (int)((nint)critIndex % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num9 >= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return num3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v10 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v10 (System.Collections.Generic.List`1<System.Single>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v11+18]");
				if ((nint)num9 >= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				int critIndex2 = _critIndex + 1;
				_critIndex = critIndex2;
				WeaponData currentWeaponData3 = _currentWeaponData;
				if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float num10 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
					float num11 = num3 * currentWeaponData3._003CcritChance_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v11+20+v84 @ rdx_v11 (System.Int32)*4]");
					if (!(num11 > 0f))
					{
						return 1f;
					}
					return num8 * ArcanaManager.CritMul;
				}
			}
		}
		goto IL_0366;
		IL_03ba:
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
		{
			goto IL_0366;
		}
		float num12 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		num3--;
		if (!(num3 > 1f))
		{
			object obj4 = 1f & -2147483649L;
			if ((nint)obj4 <= 2139095040)
			{
				goto IL_03d9;
			}
		}
		num3 = 1f;
		goto IL_03d9;
		IL_0366:
		throw new NullReferenceException();
		IL_039b:
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
		{
			goto IL_0366;
		}
		float num13 = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
		num6 = num3 - 1f;
		if (!(num6 > 1f))
		{
			object obj5 = 1f & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				goto IL_03ba;
			}
		}
		num6 = 1f;
		goto IL_03ba;
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}
}
