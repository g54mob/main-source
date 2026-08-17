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

public class MedicalScanWeapon : Weapon
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
		//IL_0115: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_008f: Invalid comparison between O and F4
		//IL_00ba: Expected F4, but got O
		GameObject gameObject = base.gameObject;
		bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
		if (obj != null)
		{
			Transform targetTransform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			_targetTransform = targetTransform;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 vector = default(Vector2);
			Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
			float num = base.PInterval();
			float num2 = _lastFiringInterval - (float)vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj2 = num2 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
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
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if (!visible)
		{
			Debug.Log("[MedicalScanWeapon] Despawning Projectiles");
			_projectilePool.Cleanup();
		}
	}

	private void _003CMakeLevelOne_003Eb__1_0()
	{
		base.Fire();
	}
}
