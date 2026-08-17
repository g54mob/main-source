using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Kick1Weapon : EME_Weapon
{
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public EME_Kick1Weapon _003C_003E4__this;

		public Vector2 pos;

		public int index;

		public Transform target;

		internal void _003CFire_FireGlimmerProjectile_003Eb__0()
		{
			//IL_00d6: Expected O, but got I4
			//IL_0041: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Detune = -300f;
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning, soundConfig, 200f, 6, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Detune = -1000f;
			soundConfig2.Rate = 1f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Lightning, soundConfig2, 200f, 6, time);
			Vector2 vector = default(Vector2);
			Projectile projectile = _003C_003E4__this.FireOneProjectile(vector, index, target);
		}

		internal void _003CFire_FireGlimmerProjectile_003Eb__1()
		{
			//IL_00d6: Expected O, but got I4
			//IL_0041: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Detune = -200f;
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning, soundConfig, 200f, 6, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Detune = -1000f;
			soundConfig2.Rate = 1f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Lightning, soundConfig2, 200f, 6, time);
			Vector2 vector = default(Vector2);
			Projectile projectile = _003C_003E4__this.FireOneProjectile(vector, index, target);
		}
	}

	public float bonusPower;

	public float overhealingTotal = 1f;

	private BulletPool _dragonBpool;

	private BulletPool _dragonCpool;

	private BulletPool _dragonSpool;

	protected Projectile _DragonBPrefab;

	protected Projectile _DragonCPrefab;

	protected Projectile _DragonSPrefab;

	private bool _cooldownAffectedByMovement;

	private const float Mul = 166.66667f;

	protected override int EvolutionLevel => 8;

	protected override int _comboIndex1 => 3;

	protected override int _comboIndex2 => 6;

	protected override int _comboIndex3
	{
		get
		{
			//IL_000a: Expected I4, but got I8
			return -1;
		}
	}

	public virtual bool IsEvolved => false;

	public virtual int WallBounces => 2;

	public override float PPower()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
			float num3 = default(float);
			float num2 = ((characterController._currentHp < num3) ? 1f : 1.5f);
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				WeaponData currentWeaponData = _currentWeaponData;
				if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = currentWeaponData._003Cpower_003Ek__BackingField * num3;
					float num5 = num4 * num2;
					return num3 + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnStart()
	{
		//IL_0212: Expected I, but got O
		//IL_033b: Expected I, but got O
		((Weapon)this).OnStart();
		InitGlimmer1BulletPool();
		InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		if (!IsEvolved)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj = Delegate.Combine(characterController._onHpRecoveryCallback, b);
		Action<float, float> action = default(Action<float, float>);
		if ((object)obj == null)
		{
			action = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if (action == null)
			{
				throw new InvalidCastException();
			}
		}
		characterController._onHpRecoveryCallback = action;
		BulletPool dragonBpool = new BulletPool(_DragonBPrefab, 20);
		_dragonBpool = dragonBpool;
		BulletPool dragonCpool = new BulletPool(_DragonCPrefab, 20);
		_dragonCpool = dragonCpool;
		BulletPool dragonSpool = new BulletPool(_DragonSPrefab, 20);
		_dragonSpool = dragonSpool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyRecoveryBonus;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_dragonBpool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Kick1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num = (nint)this;
				Collider collider2 = physics2.add.overlap(_dragonBpool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					ArcadePhysics physics3 = s_scene3.physics;
					GameManager core3 = GM.Core;
					ArcadePhysicsCallback collideCallback3 = OnBulletOverlapsEnemyRecoveryBonus;
					Collider collider3 = physics3.add.overlap(_dragonCpool, core3.Enemies, collideCallback3, processCallback, callbackContext);
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene4 = ArcadePhysics.s_scene;
						ArcadePhysics physics4 = s_scene4.physics;
						GameManager core4 = GM.Core;
						PhysicsManager physicsManager2 = core4._physicsManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Kick1Weapon>)+3A0]");
						ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
						nint num2 = (nint)this;
						Collider collider4 = physics4.add.overlap(_dragonCpool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
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
			num2 = num3 / 166.66667f;
			float num5 = num4 * num2;
			float num6 = num5 + ((Weapon)this)._003CTotalTime_003Ek__BackingField;
			((Weapon)this)._003CTotalTime_003Ek__BackingField = num6;
		}
		float num7 = base.PInterval();
		if (!(((Weapon)this)._003CTotalTime_003Ek__BackingField < num2))
		{
			float num8 = base.PInterval();
			float num9 = ((Weapon)this)._003CTotalTime_003Ek__BackingField - num2;
			((Weapon)this)._003CTotalTime_003Ek__BackingField = num9;
			PlayNextAttackAnim();
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

	protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_004c: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		//IL_017f: Expected O, but got I4
		//IL_0223: Expected I4, but got F4
		//IL_0273: Expected I4, but got F4
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals14._003C_003E4__this = this;
		CS_0024_003C_003E8__locals14.pos = pos;
		CS_0024_003C_003E8__locals14.index = index;
		CS_0024_003C_003E8__locals14.target = target;
		object obj = default(object);
		float num = default(float);
		Vector2 pos2 = default(Vector2);
		if (obj == _glimmer1Pool)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = -500f;
			soundConfig.Rate = 1f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning, soundConfig, 200f, 6, num);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Detune = -1000f;
			soundConfig2.Rate = 1f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Lightning, soundConfig2, 200f, 6, num);
			Projectile projectile = base.FireOneProjectile(pos2, CS_0024_003C_003E8__locals14.index, CS_0024_003C_003E8__locals14.target);
		}
		if (obj == _glimmer2Pool)
		{
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Volume = (float?)(object)1;
			soundConfig3.Detune = -400f;
			soundConfig3.Rate = 1f;
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Lightning, soundConfig3, 200f, 6, num);
			SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
			soundConfig4.Volume = (float?)(object)1;
			soundConfig4.Detune = -1000f;
			soundConfig4.Rate = 1f;
			PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Lightning, soundConfig4, 200f, 6, num);
			Projectile projectile2 = base.FireOneProjectile(pos2, CS_0024_003C_003E8__locals14.index, CS_0024_003C_003E8__locals14.target);
			Action onComplete = delegate
			{
				//IL_00d6: Expected O, but got I4
				//IL_0041: Expected O, but got I4
				SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
				soundConfig5.Detune = -300f;
				soundConfig5.Rate = 1f;
				soundConfig5.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Lightning, soundConfig5, 200f, 6, time);
				SoundManager.SoundConfig soundConfig6 = new SoundManager.SoundConfig();
				soundConfig6.Volume = (float?)(object)1;
				soundConfig6.Detune = -1000f;
				soundConfig6.Rate = 1f;
				PlaySoundResult playSoundResult6 = SoundManager.PlaySound(SfxType.Lightning, soundConfig6, 200f, 6, time);
				Vector2 pos3 = default(Vector2);
				Projectile projectile3 = CS_0024_003C_003E8__locals14._003C_003E4__this.FireOneProjectile(pos3, CS_0024_003C_003E8__locals14.index, CS_0024_003C_003E8__locals14.target);
			};
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Action onComplete2 = delegate
			{
				//IL_00d6: Expected O, but got I4
				//IL_0041: Expected O, but got I4
				SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
				soundConfig5.Detune = -200f;
				soundConfig5.Rate = 1f;
				soundConfig5.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Lightning, soundConfig5, 200f, 6, time);
				SoundManager.SoundConfig soundConfig6 = new SoundManager.SoundConfig();
				soundConfig6.Volume = (float?)(object)1;
				soundConfig6.Detune = -1000f;
				soundConfig6.Rate = 1f;
				PlaySoundResult playSoundResult6 = SoundManager.PlaySound(SfxType.Lightning, soundConfig6, 200f, 6, time);
				Vector2 pos3 = default(Vector2);
				Projectile projectile3 = CS_0024_003C_003E8__locals14._003C_003E4__this.FireOneProjectile(pos3, CS_0024_003C_003E8__locals14.index, CS_0024_003C_003E8__locals14.target);
			};
			Timer timer2 = Timers.Register(0.2f, onComplete2, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private void BonusOverHealDamage(float value, float rawValue)
	{
		//IL_0043: Invalid comparison between I4 and F4
		//IL_0055: Expected F4, but got I4
		float num = rawValue - value;
		float num2 = (overhealingTotal = num + overhealingTotal) * 0.001f;
		bool flag = !(0f < num2);
		float num3 = 0f;
		if (!flag)
		{
			num3 = num2;
		}
		bonusPower = num3;
	}

	protected override void InitGlimmer1BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer1Prefab = _Glimmer1Prefab;
		if ((object)_Glimmer1Prefab != null && ((UnityEngine.Object)glimmer1Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer1Pool = new BulletPool(_Glimmer1Prefab, 20);
			_glimmer1Pool = glimmer1Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyDamageX15;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer1Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Kick1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer1Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected override void InitGlimmer2BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer2Prefab = _Glimmer2Prefab;
		if ((object)_Glimmer2Prefab != null && ((UnityEngine.Object)glimmer2Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer2Pool = new BulletPool(_Glimmer2Prefab, 20);
			_glimmer2Pool = glimmer2Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyRecoveryBonus;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer2Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Kick1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer2Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected bool OnBulletOverlapsEnemyDamageX15(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
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
						goto IL_0179;
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
									float num = PPower();
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj * 1.5f;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	protected bool OnBulletOverlapsEnemyRecoveryBonus(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015d: Expected I4, but got O
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
						goto IL_017a;
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
									float num = PPower();
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj + bonusPower;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_017a;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_017a:
		return false;
	}

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		if (level == 1)
		{
			return WeaponType.EME_KICK_TECH_01;
		}
		bool flag = level != 2;
		WeaponType result = WeaponType.VOID;
		if (!flag)
		{
			result = WeaponType.EME_KICK_TECH_02;
		}
		return result;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
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
				_cooldownAffectedByMovement = true;
			}
		}
	}
}
