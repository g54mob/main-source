using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Valmanway2_Weapon : Weapon
{
	private const float BonusAreaGainedPerSecond = 0.1f;

	private const float BonusAreaLostPerSecond = 0.25f;

	private const float BonusAreaMax = 1f;

	private float _bonusArea;

	public override float PArea()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj2 = default(object);
		object obj = obj2 * currentWeaponData._003Carea_003Ek__BackingField;
		return (float)obj + _bonusArea;
	}

	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_bonusArea = 0f;
	}

	public override void InternalUpdate()
	{
		//IL_0023: Invalid comparison between F4 and I4
		//IL_00da: Expected O, but got I4
		//IL_00f4: Invalid comparison between I4 and F4
		//IL_00cc: Expected F4, but got I4
		base.InternalUpdate();
		CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (!(characterController._walked > 0f))
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 0.25f;
			float num2 = _bonusArea - num;
		}
		else
		{
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = deltaTime2 * 0.1f;
			float num2 = num3 + _bonusArea;
		}
		object obj = 344;
		float num4 = _bonusArea;
		if (!(0f > _bonusArea))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = 0f;
		}
		_bonusArea = num4;
	}

	private void UpdateBonusArea()
	{
		//IL_001d: Invalid comparison between F4 and I4
		//IL_00d4: Expected O, but got I4
		//IL_00ee: Invalid comparison between I4 and F4
		//IL_00c6: Expected F4, but got I4
		CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (!(characterController._walked > 0f))
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 0.25f;
			float num2 = _bonusArea - num;
		}
		else
		{
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = deltaTime2 * 0.1f;
			float num2 = num3 + _bonusArea;
		}
		object obj = 344;
		float num4 = _bonusArea;
		if (!(0f > _bonusArea))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = 0f;
		}
		_bonusArea = num4;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_bonusBounces = 1;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager3 = gameMan3._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}
}
