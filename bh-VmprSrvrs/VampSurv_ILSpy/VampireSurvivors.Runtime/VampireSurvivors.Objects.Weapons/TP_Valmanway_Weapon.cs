using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Valmanway_Weapon : Weapon
{
	private float _walked;

	private Timer _walkedTimer;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private bool _initialisedParticles;

	private const float MUL = 500f;

	private bool _isManualFire;

	public void SetManualFire()
	{
		_isManualFire = true;
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(4.5f > num2);
		float result = 4.5f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		base._003CTotalTime_003Ek__BackingField = 0f;
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_walkedTimer != null)
		{
			_walkedTimer.Cancel();
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
		float num3 = num / 500f;
		float num4 = frameWalk * 100f;
		float num5 = num4 * num3;
		float num6 = (base._003CTotalTime_003Ek__BackingField = num5 + num2);
		float num7 = base.PInterval();
		if (!(num6 < frameWalk))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (!_isManualFire)
			{
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
}
