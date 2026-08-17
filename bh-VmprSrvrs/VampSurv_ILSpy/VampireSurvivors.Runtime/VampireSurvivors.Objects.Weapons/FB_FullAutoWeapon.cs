using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_FullAutoWeapon : FB_QuantisedAngleWeapon
{
	protected SpriteRenderer _muzzleFlash;

	protected bool _muzzleFlashLastRotated;

	protected int _frameCount;

	protected float _sinPhase;

	protected bool _randomizeSpeed;

	public override float SecondsToRotateAim360 => 0.9f;

	public override float QuantisationStep => 1f;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0124->IL009e: Incompatible stack heights: 1 vs 0
		//IL_0067->IL009e: Incompatible stack heights: 1 vs 0
		base.InitWeapon(characterController, weaponType);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				SpriteRenderer muzzleFlash = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "2Spell4Orange");
				_muzzleFlash = muzzleFlash;
				if ((object)_muzzleFlash != null)
				{
					_muzzleFlash.enabled = false;
					_frameCount = 5;
					_explosionType = WeaponType.FIREEXPLOSION;
					_randomizeSpeed = false;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
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
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan3._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (!characterController._isDead && !characterController.IsDisconnectedFromOnlinePlay && !PauseSystem._paused)
		{
			if (++_frameCount < 2)
			{
				int depth = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
				int sortingOrder = depth + 5;
				_muzzleFlash.sortingOrder = sortingOrder;
			}
			if (_frameCount == 2)
			{
				_muzzleFlash.enabled = false;
			}
		}
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0246: Expected I, but got O
		//IL_0166: Expected O, but got Ref
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_01d4: Invalid comparison between O and F4
		//IL_01ff: Expected F4, but got O
		//IL_0128->IL023a: Incompatible stack heights: 1 vs 0
		//IL_0154->IL023a: Incompatible stack heights: 1 vs 0
		//IL_0224->IL023a: Incompatible stack heights: 1 vs 0
		nint num = (nint)this;
		float2 firingVector = GetFiringVector();
		object obj = default(object);
		float num2 = (float)obj * 0.01f;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float num3 = num2 * 12f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			if ((object)_muzzleFlash != null)
			{
				Transform transform = _muzzleFlash.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector2 value = default(Vector2);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_muzzleFlash, 2f);
				_muzzleFlash.enabled = true;
				int depth = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
				int sortingOrder = depth + 1;
				_muzzleFlash.sortingOrder = sortingOrder;
				if (_muzzleFlashLastRotated)
				{
				}
				if ((object)_muzzleFlash != null)
				{
					Transform transform2 = _muzzleFlash.transform;
					if ((object)transform2 != null)
					{
						transform2.localEulerAngles = (Vector3)(&value);
						bool muzzleFlashLastRotated = !_muzzleFlashLastRotated;
						_muzzleFlashLastRotated = muzzleFlashLastRotated;
						Vector2 vector = default(Vector2);
						Projectile projectile = FireOneProjectile(vector, 0, _targetTransform);
						float num4 = PInterval();
						float num5 = _lastFiringInterval - (float)vector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						object obj2 = num5 & 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
						{
							float num6 = PInterval();
							_lastFiringInterval = (float)vector;
							base.ResetFiringTimer();
						}
						if (skipTriggers)
						{
							return;
						}
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override float PInterval()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		float num = base.PInterval();
		float num2 = currentWeaponData._003Cinterval_003Ek__BackingField * 0.1f;
		float num3 = base.PAmount();
		float num4 = num - 1f;
		float num5 = num4 * 16.666666f;
		float num6 = num - num5;
		if (num2 < num6)
		{
			num2 = num6;
		}
		return num2;
	}

	public unsafe override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_00e6: Expected O, but got I
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected Ref, but got Unknown
		float num = _sinPhase + 0.4f;
		_frameCount = 0;
		_sinPhase = num;
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			if (!_randomizeSpeed)
			{
				goto IL_0270;
			}
			List<float> critChancesArray = _critChancesArray;
			int critIndex = _critIndex + 1;
			_critIndex = critIndex;
			if (_critChancesArray != null)
			{
				int critIndex2 = _critIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
				int num2 = (int)((nint)critIndex2 % (nint)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)num2 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rcx_v22+20+v317 @ rdx_v10 (System.Int32)*4]");
						num = (projectile._speed = 0f + 0.5f);
						goto IL_0270;
					}
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			}
			goto IL_0292;
		}
		projectile = null;
		goto IL_02d2;
		IL_0292:
		return (Projectile)(object)new NullReferenceException();
		IL_0270:
		if (IsHoming)
		{
			Transform transform = projectile.AimForNearestEnemy();
			goto IL_02d2;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			float projectileSpeed = projectile.ProjectileSpeed;
			if (projectile.body != null && (object)s_scene.physics != null)
			{
				float rotation = _firingAngleDegrees * ((float)Math.PI / 180f);
				ref float2 vec = ref *(float2*)(projectile.body + 112);
				float2 float5 = s_scene.physics.velocityFromRotation(rotation, num, ref vec);
				projectile.angle = _firingAngleDegrees;
				goto IL_02d2;
			}
		}
		goto IL_0292;
		IL_02d2:
		return projectile;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		_muzzleFlash.enabled = false;
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_muzzleFlash.enabled = false;
	}

	public override bool LevelUp()
	{
		bool result = LevelUp(skipFire: false);
		if (((Equipment)this)._003CLevel_003Ek__BackingField >= 8)
		{
			_randomizeSpeed = true;
		}
		return result;
	}
}
