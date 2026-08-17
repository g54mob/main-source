using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Savrog_Weapon : Weapon
{
	private const float Mul = 16.666666f;

	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		BulletPool projectilePool = _projectilePool;
		projectilePool.IsUncapped = true;
	}

	public override void InternalUpdate()
	{
		//IL_00de: Invalid comparison between F4 and I4
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
		float num3 = num / 16.666666f;
		float num4 = frameWalk * 100f;
		float num5 = num4 * num3;
		float num6 = (base._003CTotalTime_003Ek__BackingField = num5 + num2);
		float num7 = base.PInterval();
		if (!(num6 < frameWalk))
		{
			CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController._walked > 0f)
			{
				base._003CTotalTime_003Ek__BackingField = 0f;
				base.Fire();
			}
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		CheckBeginningArcana();
	}
}
