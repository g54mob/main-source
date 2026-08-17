using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_PrismCutlassCounterWeapon : FB_PrismCutlassWeapon
{
	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		((Weapon)this).InitWeapon(characterController, weaponType);
		((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.05f;
		FB_PrismCutlassProjectile.ClearDirectionSpritesCache();
		FB_PrismCutlassProjectile.ClearDirectionSpritesCache();
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
				((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.25f;
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

	public FB_PrismCutlassCounterWeapon()
	{
		_counterWeaponType = WeaponType.FB_PRISMCUTLASS_COUNTER;
		((Weapon)this)._002Ector();
	}
}
