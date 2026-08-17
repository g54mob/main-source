using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Hydrostorm2_Weapon : TP_Hydrostorm_Weapon
{
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public TP_Hydrostorm2_Weapon _003C_003E4__this;

		public float2 pos;
	}

	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireBoraProjectiles_003Eb__0()
		{
			//IL_01a1: Expected O, but got I4
			//IL_00a8->IL016a: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL016a: Incompatible stack heights: 1 vs 0
			//IL_0118->IL016a: Incompatible stack heights: 1 vs 0
			//IL_013a->IL016a: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass21_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass21_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Hydrostorm2_Weapon tP_Hydrostorm2_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null)
						{
							if (!tP_Hydrostorm2_Weapon._isVisible)
							{
								return;
							}
							if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
							{
								Vector2 pos = default(Vector2);
								Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Hydrostorm2_Weapon._targetTransform);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private Projectile _BoraProjectilePrefab;

	private const float BoraDamageMultiplier = 2f;

	private const float Mul = 333.33334f;

	private bool _cooldownAffectedByMovement;

	private BulletPool _boraProjectilePool;

	protected override uint RainEmitterTint1 => 12312831u;

	protected override uint RainEmitterTint2 => 4696831u;

	protected override int RainEmitterQuantity => 80;

	protected unsafe override ParticleSystem.MinMaxCurve RainEmitterAlpha
	{
		get
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_0013: Expected native int or pointer, but got O
			//IL_0026: Expected native int or pointer, but got O
			ParticleSystem.MinMaxCurve minMaxCurve = default(ParticleSystem.MinMaxCurve);
			((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_Mode = ParticleSystemCurveMode.Constant;
			System.Runtime.CompilerServices.Unsafe.Write(&((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_CurveMax, null);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0.6f, 0.25f));
			return minMaxCurve;
		}
	}

	protected override bool EnableBottleEmitters => false;

	protected override bool EnableGroundEmitters => true;

	public float BoraFallDurationMillis => 600f;

	protected override void OnStart()
	{
		//IL_0106: Expected I, but got O
		base.OnStart();
		if (_boraProjectilePool == null)
		{
			BulletPool boraProjectilePool = new BulletPool(_BoraProjectilePrefab, 100);
			_boraProjectilePool = boraProjectilePool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemy_Bora;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_boraProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Hydrostorm2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_boraProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		FireBoraProjectiles();
		FireProjectiles();
		PlaySfx();
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private void FireBoraProjectiles()
	{
		//IL_01ea: Invalid comparison between F4 and I4
		//IL_019f: Invalid comparison between F4 and I4
		_003C_003Ec__DisplayClass21_0 obj = new _003C_003Ec__DisplayClass21_0();
		obj._003C_003E4__this = this;
		float2 float5 = (obj.pos = ((Equipment)this)._003COwner_003Ek__BackingField.position);
		float num = base.PAmount();
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		float num3 = (float)float5 + 9f;
		float num4 = (float)float5 * num3;
		float num5 = base.PDuration();
		bool flag = 1f > num4;
		float num6 = 1f;
		if (!flag)
		{
			num6 = num4;
		}
		float num7 = (float)float5 - 600f;
		float num8 = num7 / num6;
		if (!(num4 > 0f))
		{
			return;
		}
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass21_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass21_1();
			CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 = obj;
			if (flag2)
			{
				CS_0024_003C_003E8__locals9.localIndex = (flag2 ? 1 : 0);
				Action onComplete = delegate
				{
					//IL_01a1: Expected O, but got I4
					//IL_00a8->IL016a: Incompatible stack heights: 1 vs 0
					//IL_00d7->IL016a: Incompatible stack heights: 1 vs 0
					//IL_0118->IL016a: Incompatible stack heights: 1 vs 0
					//IL_013a->IL016a: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass21_0 obj3 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						GameObject gameObject = obj3._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj4 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass21_0 obj5 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Hydrostorm2_Weapon tP_Hydrostorm2_Weapon = obj5._003C_003E4__this;
								if ((object)obj5._003C_003E4__this != null)
								{
									if (!tP_Hydrostorm2_Weapon._isVisible)
									{
										return;
									}
									if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
									{
										Vector2 pos = default(Vector2);
										Projectile projectile = obj5._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals9.localIndex, tP_Hydrostorm2_Weapon._targetTransform);
										return;
									}
								}
							}
						}
					}
					throw new NullReferenceException();
				};
				float num9 = (float)(flag2 ? 1 : 0) * num8;
				float duration = num9 * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			}
			else
			{
				_003C_003Ec__DisplayClass21_0 obj2 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
			}
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		}
		while (num4 > (float)(flag2 ? 1 : 0));
	}

	protected override void UpdateFiringInterval()
	{
		float deltaTime = PauseSystem.DeltaTime;
		bool flag = !_cooldownAffectedByMovement;
		float num = deltaTime * 1000f;
		float num2 = (((Weapon)this)._003CTotalTime_003Ek__BackingField = num + ((Weapon)this)._003CTotalTime_003Ek__BackingField);
		if (!flag)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = deltaTime2 * 1000f;
			float num4 = frameWalk * 100f;
			num2 = num3 / 333.33334f;
			float num5 = num4 * num2;
			float num6 = num5 + ((Weapon)this)._003CTotalTime_003Ek__BackingField;
			((Weapon)this)._003CTotalTime_003Ek__BackingField = num6;
		}
		float num7 = base.PInterval();
		if (!(((Weapon)this)._003CTotalTime_003Ek__BackingField < num2))
		{
			((Weapon)this)._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
	}

	protected override void PlaySfx()
	{
		//IL_0033: Expected F4, but got I4
		//IL_0065: Expected F4, but got I4
		//IL_009c: Expected F4, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_DivineStorm, 1000f, 6, 0f, volume, rate, detune, loop, 1f);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_DivineStorm, 1000f, 6, 0f, volume, rate, detune, loop, 1f);
		PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_DivineStorm, 1000f, 6, 0f, volume, rate, detune, loop, 1f);
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
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

	private bool OnBulletOverlapsEnemy_Bora(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0159: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0176;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj2 = default(object);
									object obj = obj2 * obj2;
									float damage = (float)obj + (float)obj;
									base.DealDamage(component, damage);
								}
								goto IL_0176;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0176:
		return false;
	}
}
