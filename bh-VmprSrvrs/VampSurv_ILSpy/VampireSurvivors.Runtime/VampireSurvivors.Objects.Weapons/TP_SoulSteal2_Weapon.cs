using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_SoulSteal2_Weapon : TP_PowerOfLire_Weapon
{
	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.98f;
		((Weapon)this)._003CTotalTime_003Ek__BackingField = num2;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (((Weapon)this)._003CTotalTime_003Ek__BackingField = num + ((Weapon)this)._003CTotalTime_003Ek__BackingField);
		float num3 = base.PInterval();
		if (!(num2 < deltaTime))
		{
			float num4 = base.PInterval();
			float num5 = ((Weapon)this)._003CTotalTime_003Ek__BackingField - deltaTime;
			((Weapon)this)._003CTotalTime_003Ek__BackingField = num5;
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}
}
