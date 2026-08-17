using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class LoopWeapon : Weapon
{
	private bool _cooldownAffectedByMovement;

	private const float Mul = 166.66667f;

	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		bool flag = !_cooldownAffectedByMovement;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		if (!flag)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = deltaTime2 * 1000f;
			float num4 = frameWalk * 100f;
			num2 = num3 / 166.66667f;
			float num5 = num4 * num2;
			float num6 = num5 + base._003CTotalTime_003Ek__BackingField;
			base._003CTotalTime_003Ek__BackingField = num6;
		}
		float num7 = base.PInterval();
		if (!(base._003CTotalTime_003Ek__BackingField < num2))
		{
			float num8 = base.PInterval();
			float num9 = base._003CTotalTime_003Ek__BackingField - num2;
			base._003CTotalTime_003Ek__BackingField = num9;
			base.Fire();
		}
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				_explodeOnExpire = true;
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager3 = gameMan3._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
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
		CheckBeginningArcana();
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}
}
