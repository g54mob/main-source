using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_PistolProjectile_BoundingShot : Projectile
{
	private ParticleSystem boundingShotVFX;

	private ParticleEventCall boundingShotParticleEventCall;

	private readonly List<int> _targetAngles;

	private Timer _expireTimer;

	private Timer _despawnTimer;

	private float _saveVelX;

	private float _saveVelY;

	private EME_Pistol1Weapon _trueWeapon;

	private Timer _bounceTimer;

	private bool _canBounce;

	protected override void Awake()
	{
		base.Awake();
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0066: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		SetupMechanics();
		if ((object)boundingShotVFX != null)
		{
			boundingShotVFX.Play(withChildren: true);
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_boundshot, soundConfig, 200f, 10, time);
	}

	private unsafe void SetupMechanics()
	{
		//IL_0026: Expected I, but got O
		//IL_002e: Expected I, but got O
		//IL_003e: Expected O, but got I
		//IL_00be: Expected O, but got I4
		//IL_007a: Expected O, but got I
		//IL_00b0: Expected O, but got I4
		//IL_0113: Expected O, but got I4
		//IL_0113: Expected O, but got I4
		//IL_0179: Expected O, but got I4
		//IL_0179: Expected O, but got I4
		//IL_042a->IL034d: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		_canBounce = true;
		_isCullable = false;
		bool flag;
		EME_Pistol1Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			flag = false;
			trueWeapon = null;
			goto IL_0396;
		}
		nint num = (nint)typeof(EME_Pistol1Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r8_v36 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Pistol1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r8_v36 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Pistol1Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v90+FFFFFFF8+v55 @ rax_v85*8]");
			if (0 == (nint)typeof(EME_Pistol1Weapon))
			{
				obj3 = 1;
				goto IL_03a5;
			}
		}
		obj3 = 0;
		goto IL_03a5;
		IL_03a5:
		bool flag2 = obj3 == null;
		flag = false;
		trueWeapon = null;
		if (!flag2)
		{
			flag = false;
			trueWeapon = (EME_Pistol1Weapon)_weapon;
		}
		goto IL_0396;
		IL_0396:
		_trueWeapon = trueWeapon;
		if (base.body != null)
		{
			BaseBody baseBody = base.body.setCircle(8f, (float?)(object)flag, (float?)(object)flag);
			_speed = 8f;
			Transform targetTransform = base.AimForRandomEnemy();
			_targetTransform = targetTransform;
			SetScaleToArea();
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
			setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
			Weapon weapon2 = _weapon;
			if ((object)_weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null && base.body != null)
				{
					Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
					BaseBody baseBody2 = base.body;
					if (base.body != null)
					{
						baseBody2._onWorldBounds = true;
						if (_expireTimer != null)
						{
							_expireTimer.Cancel();
						}
						if ((object)_weapon != null)
						{
							float num4 = _weapon.PDuration();
							Action onComplete = StartDespawn;
							object obj4 = default(object);
							float duration = (float)obj4 * 0.001f;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, flag);
							_expireTimer = expireTimer;
							object targetTransform2 = _targetTransform;
							if ((object)_targetTransform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rbx_v11 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rbx_v11 (System.Object)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
								object cachedTransform = _cachedTransform;
								if ((object)_cachedTransform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v12 (System.Object)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v12 (System.Object)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 ret2);
									object obj5 = ret - ret2;
									object obj7 = default(object);
									object obj8 = default(object);
									object obj6 = obj7 - obj8;
									object cachedTransform2 = _cachedTransform;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
									Quaternion.Internal_FromEulerRad_Injected(ref ret, out Quaternion _);
									bool flag5 = (object)_cachedTransform == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rbx_v13 (System.Object)+10]");
									bool flag6 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rbx_v13 (System.Object)+10]");
									Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&ret2));
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetupVisuals()
	{
		if ((object)boundingShotVFX != null)
		{
			boundingShotVFX.Play(withChildren: true);
		}
	}

	public override void SetTarget(Transform target)
	{
		//IL_009c: Expected O, but got I
		_targetTransform = target;
		Weapon weapon = _weapon;
		Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
		float num = AngleFromTargetRadians(_targetTransform, playerTransform);
		List<int> targetAngles = _targetAngles;
		int indexInWeapon = _indexInWeapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32>)+18]");
		int num2 = (int)((nint)indexInWeapon % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)num2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			float projectileSpeed = base.ProjectileSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v6+20+v138 @ rdx_v8 (System.Int32)*4]");
			float num3 = 0f * ((float)Math.PI / 180f);
			float rotation = num3 + num;
			Vector2 vector = SetVelocityFromRotation(rotation, num);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_003c: Expected O, but got I4
		//IL_0084: Expected F4, but got O
		//IL_00d2: Expected F4, but got I
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_renderer.sortingOrder = sortingOrder;
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018722E42Ch\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v24 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018722E451h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v24 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		Transform transform = boundingShotVFX.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)(&euler));
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		if (b == body)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			Projectile projectile = _trueWeapon.FireOneProjectile(pos, 0);
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_01a4: Expected O, but got F4
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0158: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		bool flag = default(bool);
		if (!flag && _canBounce != flag)
		{
			_canBounce = flag;
			if (_bounceTimer != null)
			{
				_bounceTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canBounce = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer bounceTimer = Timers.Register(0.060000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_bounceTimer = bounceTimer;
			object obj = UnityEngine.Random.value;
			float num = ((!(0.060000002f > 0.5f)) ? (-1f) : 1f);
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj2 = num ^ 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v18 (BaseBody)+74]");
			object obj3 = 0 * obj2;
			float num2 = (float)baseBody._velocity * num;
			ArcadeSprite sprite = _sprite;
			BaseBody baseBody2 = sprite.body;
			baseBody2._velocity = (float2)num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			Projectile projectile = _trueWeapon.FireOneProjectile(pos, 0);
		}
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_0232: Expected O, but got I4
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
		//IL_018e: Expected O, but got F4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_01cc;
			}
		}
		obj5 = 4294967295L;
		goto IL_01cc;
		IL_024d:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		Projectile projectile = _trueWeapon.FireOneProjectile(pos, 0);
		return;
		IL_01cc:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_024d;
			}
		}
		obj6 = 4294967295L;
		goto IL_024d;
	}

	private void StartDespawn()
	{
		//IL_00e9: Expected I, but got O
		//IL_0147: Expected O, but got I4
		//IL_0176: Expected F4, but got I4
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		Projectile projectile = _trueWeapon.FireOneProjectile(pos, 0);
		BaseBody baseBody = body;
		baseBody._enable = false;
		if ((object)boundingShotVFX != null)
		{
			boundingShotVFX.Stop();
		}
		if ((object)boundingShotVFX != null)
		{
			boundingShotVFX.Clear(withChildren: true);
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile_BoundingShot>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(0.25f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_boundshotend, soundConfig, 200f, 10, flag ? 1 : 0);
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		if ((object)boundingShotVFX != null)
		{
			boundingShotVFX.Stop();
		}
		if ((object)boundingShotVFX != null)
		{
			boundingShotVFX.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void DespawnAfterParticlesStopped()
	{
		base.Despawn();
	}

	private void FinishDespawn()
	{
		base.Despawn();
	}

	public EME_PistolProjectile_BoundingShot()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0450: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0478: Expected O, but got I
		//IL_015a: Expected O, but got I
		//IL_013f: Expected I4, but got I8
		//IL_04a0: Expected O, but got I
		//IL_01c8: Expected O, but got I
		//IL_04c8: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_021b: Expected I4, but got I8
		//IL_04f0: Expected O, but got I
		//IL_02a4: Expected O, but got I
		//IL_0518: Expected O, but got I
		//IL_0312: Expected O, but got I
		//IL_02f7: Expected I4, but got I8
		//IL_0540: Expected O, but got I
		//IL_0380: Expected O, but got I
		//IL_0568: Expected O, but got I
		//IL_03ee: Expected O, but got I
		//IL_03d3: Expected I4, but got I8
		List<int> list = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(-10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 4294967286L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(-20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 4294967276L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 30;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(-30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 4294967266L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(-40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 4294967256L;
		}
		_targetAngles = list;
		_canBounce = true;
		base._002Ector();
	}

	private void _003COnHasHitAnObject_003Eb__17_0()
	{
		_canBounce = true;
	}
}
