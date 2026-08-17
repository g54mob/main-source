using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_PowerOfLire_Weapon : Weapon
{
	private bool _isManualFire;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public override float PPower()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		return config._003CRunCoins_003Ek__BackingField * 0.01f;
	}

	public void SetManualFire()
	{
		_isManualFire = true;
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void ResetFiringTimer()
	{
		if (!_isManualFire)
		{
			base.ResetFiringTimer();
		}
		else if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0067: Invalid comparison between O and F4
		//IL_0092: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void TransformAll()
	{
	}
}
