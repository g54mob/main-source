using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Energy2_Weapon : Weapon
{
	private bool _003CIsBeamActive_003Ek__BackingField;

	private bool _initialisedParticles;

	private float _totalTimeCounterWeapon;

	protected WeaponType _counterWeaponType = WeaponType.TP_ENERGY1_COUNTER;

	protected Weapon _counterWeapon;

	protected SantaJavelinCounterWeapon _counterSet;

	protected bool _hasCounterSet;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	public bool IsBeamActive
	{
		get
		{
			return _003CIsBeamActive_003Ek__BackingField;
		}
		set
		{
			_003CIsBeamActive_003Ek__BackingField = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_003CIsBeamActive_003Ek__BackingField = false;
		float num = base.PInterval();
		object obj = default(object);
		_totalTimeCounterWeapon = (base._003CTotalTime_003Ek__BackingField = (float)obj * 0.5f);
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = base.PInterval();
		float num3 = num + base._003CTotalTime_003Ek__BackingField;
		float totalTimeCounterWeapon = num + _totalTimeCounterWeapon;
		base._003CTotalTime_003Ek__BackingField = num3;
		_totalTimeCounterWeapon = totalTimeCounterWeapon;
		if (!_003CIsBeamActive_003Ek__BackingField && !(num3 < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
			}
		}
		if (!(_totalTimeCounterWeapon < deltaTime))
		{
			_totalTimeCounterWeapon = 0f;
			Fire_FireCounter();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0072: Invalid comparison between O and F4
		//IL_009d: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = FireOneProjectile(vector, 0, _targetTransform);
		_003CIsBeamActive_003Ek__BackingField = true;
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

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			Transform transform = projectile.transform;
			if ((object)transform == null)
			{
				return (Projectile)(object)new NullReferenceException();
			}
			transform.SetParent(_cachedTransform, worldPositionStays: true);
		}
		return projectile;
	}

	protected void Fire_FireCounter(bool skipTriggers = false)
	{
		if (!_hasCounterSet)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				_hasCounterSet = true;
				_counterWeapon = weaponByType;
				_counterWeapon.Cleanup();
				GameObject gameObject = _counterWeapon.gameObject;
				gameObject.SetActive(value: true);
			}
		}
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			_counterWeapon.Fire(skipTriggers);
		}
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		if (!IsPrimaryWeapon)
		{
			return;
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj <= -1)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType == null || ((UnityEngine.Object)weaponByType).m_CachedPtr == (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			bool allowDuplicates = default(bool);
			Weapon weapon = (_counterWeapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates));
			while (!weapon.IsMaxLevel())
			{
				bool flag = weapon.LevelUp(skipFire: true);
			}
		}
	}
}
