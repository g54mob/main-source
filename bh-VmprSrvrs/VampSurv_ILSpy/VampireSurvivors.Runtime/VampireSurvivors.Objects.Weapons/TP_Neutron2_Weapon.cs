using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Neutron2_Weapon : Weapon
{
	private const float _explosionDamageMultiplier = 2f;

	private int _exploIndex;

	private bool _canExplode = true;

	private Tween _explodeTimer;

	private bool _generatedPools;

	private BulletPool _onGetHitExplosionPool;

	private BulletPool _neutronExplosionPool;

	public BulletPool NeutronExplosionPool => _neutronExplosionPool;

	protected override void OnStart()
	{
		//IL_0163: Expected I, but got O
		//IL_01f4: Expected I, but got O
		//IL_0297: Expected I, but got O
		base.OnStart();
		if (!_generatedPools)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_NEUTRON_WEAPON);
			BulletPool neutronExplosionPool = new BulletPool(projectilePrefab);
			_neutronExplosionPool = neutronExplosionPool;
			Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.ROCHEREXP);
			BulletPool onGetHitExplosionPool = new BulletPool(projectilePrefab2);
			_onGetHitExplosionPool = onGetHitExplosionPool;
			_generatedPools = true;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemy_Explosion;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_neutronExplosionPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Neutron2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_neutronExplosionPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene3.physics;
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Neutron2_Weapon>)+390]");
				ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider3 = physics3.add.overlap(_onGetHitExplosionPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					ArcadePhysics physics4 = s_scene4.physics;
					GameManager core4 = GM.Core;
					PhysicsManager physicsManager2 = core4._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Neutron2_Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num3 = (nint)this;
					Collider collider4 = physics4.add.overlap(_onGetHitExplosionPool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_exploIndex = 0;
		_canExplode = true;
		Action<GameplaySignals.CharacterLostShieldSignal> action = null;
		((TP_Neutron2_Weapon)(object)action).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)this);
		((TP_Neutron2_Weapon)(object)_signalBus).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)action);
		Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
		((TP_Neutron2_Weapon)(object)action2).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
		((TP_Neutron2_Weapon)(object)_signalBus).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0087: Expected O, but got Ref
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Ref, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected Ref, but got Unknown
		if (!IsHoming)
		{
			GameManager gameMan = _gameMan;
			ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
			Transform targetTransform = gameMan._stage.PickRandomEnemy(ref rng);
			_targetTransform = targetTransform;
		}
		else
		{
			GameManager core = GM.Core;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			object obj = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				Transform targetTransform2 = enemyController.transform;
				_targetTransform = targetTransform2;
			}
			else
			{
				GameManager gameMan2 = _gameMan;
				ref Unity.Mathematics.Random rng2 = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
				Transform targetTransform3 = gameMan2._stage.PickRandomEnemy(ref rng2);
				_targetTransform = targetTransform3;
			}
		}
		base.Fire(skipTriggers);
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CFreezeChance_003Ek__BackingField = 0.25f;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
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
		CheckBeginningArcana();
	}

	public override int ActiveProjectileCount()
	{
		int num;
		if (_projectilePool == null)
		{
			num = 0;
		}
		else
		{
			int num2 = _projectilePool.countActive();
			num = num2;
		}
		if (_onGetHitExplosionPool == null)
		{
			return num;
		}
		int num3 = _onGetHitExplosionPool.countActive();
		return num3 + num;
	}

	public override void SetVisible(bool visible)
	{
		//IL_0038: Expected O, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		_isVisible = visible;
		if (visible)
		{
			return;
		}
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] < 0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterLostShieldSignal> action = null;
			((TP_Neutron2_Weapon)(object)action).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)this);
			((TP_Neutron2_Weapon)(object)_signalBus).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)action);
		}
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
			((TP_Neutron2_Weapon)(object)action2).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
			((TP_Neutron2_Weapon)(object)_signalBus).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
		}
		if (_neutronExplosionPool != null)
		{
			_neutronExplosionPool.Cleanup();
		}
		if (_onGetHitExplosionPool != null)
		{
			_onGetHitExplosionPool.Cleanup();
		}
	}

	private void ExplodeOnPlayerDamage(GameplaySignals.CharacterReceivedDamageSignal signal)
	{
		//IL_00fa: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal != null)
				{
					object obj3 = (object)signal - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+CharacterReceivedDamageSignal)+10]");
				flag4 = (nint)0 == 0;
			}
			if (!flag4)
			{
				return;
			}
		}
		ExplodeOnPlayer();
	}

	private void ExplodeOnPlayerShield(GameplaySignals.CharacterLostShieldSignal signal)
	{
		//IL_0113: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController character = signal.Character;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal.Character == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal.Character != null)
				{
					object obj3 = (object)signal.Character - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		ExplodeOnPlayer();
	}

	private void ExplodeOnPlayer()
	{
		//IL_0144: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_030c: Expected O, but got I4
		//IL_0254: Expected O, but got I4
		//IL_032c: Expected O, but got I4
		if (_canExplode)
		{
			_canExplode = false;
			if (_explodeTimer != null)
			{
				TweenExtensions.Kill(_explodeTimer);
			}
			TweenCallback callback = delegate
			{
				_canExplode = true;
			};
			Tween tween = DOVirtual.DelayedCall(0.5f, callback, ignoreTimeScale: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tween.stringId = "DefaultGameTweenId";
			_explodeTimer = tween;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Projectile projectile = _onGetHitExplosionPool.SpawnAt(position, this);
			int exploIndex = _exploIndex + 1;
			_exploIndex = exploIndex;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			int num = _exploIndex & 1;
			bool flag = num == 0;
			object obj = !flag;
			float detune = ((obj != null) ? (-1000f) : 1000f);
			soundConfig.Detune = detune;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ExploGH, soundConfig, 200f, 10, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Rate = 1f;
			int num2 = _exploIndex & 1;
			bool flag2 = num2 == 0;
			float detune2 = 1000f;
			if (!flag2)
			{
				detune2 = -1000f;
			}
			soundConfig2.Detune = detune2;
			soundConfig2.Volume = (float?)(object)1;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ExploGH2, soundConfig2, 200f, 10, time);
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Rate = 1f;
			int num3 = _exploIndex & 1;
			bool flag3 = num3 == 0;
			object obj2 = !flag3;
			float detune3 = ((obj2 != null) ? (-900f) : 900f);
			soundConfig3.Detune = detune3;
			soundConfig3.Volume = (float?)(object)1;
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.ExploGH2, soundConfig3, 200f, 10, time);
		}
	}

	private bool OnBulletOverlapsEnemy_Explosion(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
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

	private void _003CExplodeOnPlayer_003Eb__18_0()
	{
		_canExplode = true;
	}
}
