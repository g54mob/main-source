using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class MedicalScan2Weapon : Weapon
{
	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
	}

	protected override void MakeLevelOne()
	{
		//IL_005c: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		base.MakeLevelOne();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		Action onComplete = delegate
		{
			base.Fire();
		};
		bool flag = list._size == 0;
		object obj = 1000;
		if (!flag)
		{
			obj = 100;
		}
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0085: Invalid comparison between O and F4
		//IL_00b0: Expected F4, but got O
		Transform targetTransform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
		_targetTransform = targetTransform;
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
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private void _003CMakeLevelOne_003Eb__1_0()
	{
		base.Fire();
	}
}
