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
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Pocket2_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public TP_Pocket2_Weapon _003C_003E4__this;

		public bool flipped;

		public bool isSuperAttack;
	}

	private sealed class _003C_003Ec__DisplayClass30_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_003Eb__0()
		{
			//IL_0132: Expected O, but got I4
			//IL_00a8->IL00fb: Incompatible stack heights: 1 vs 0
			//IL_00ca->IL00fb: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass30_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass30_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						obj3._003C_003E4__this.FireProjectile(localIndex, obj3.flipped, obj3.isSuperAttack);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private Projectile _InvisibleProjectilePrefab;

	private const float MaxBonusPower = 0.5f;

	private const float MaxBonusArmor = 5f;

	private const float MaxBonusCritMul = 1f;

	private const float SuperAttackFireInterval = 7f;

	private const float SuperAttackDamageMultiplier = 1.7f;

	private float _bonusPower;

	private float _bonusArmor;

	private float _bonusCritMul;

	private bool _bonusStatsApplied;

	private int _fireCounter;

	private MultiTargetTween _ringTween;

	private MultiTargetTween _burstTween1;

	private MultiTargetTween _burstTween2;

	private PhaserSprite _ringSprite;

	private PhaserSprite _burstSprite1;

	private PhaserSprite _burstSprite2;

	private BulletPool _invisibleProjectilePool;

	public float PAreaMax => 3.5f;

	public BulletPool InvisibleProjectilePool => _invisibleProjectilePool;

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(3.5f > num2);
		float result = 3.5f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F5AD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "vfx", "sPFX_ring_64");
		PhaserSprite phaserSprite2 = phaserSprite.setDepth(500);
		GameObject gameObject2 = phaserSprite2.gameObject;
		((UnityEngine.Object)gameObject2).SetName("_ringSprite");
		_ringSprite = phaserSprite2;
		SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
		if (thosepeople.Thosepeople != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1480]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject3 = base.gameObject;
			PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject3, vector, "ThosePeople", "TP_VFX_Claimh_Solais_Burst");
			PhaserSprite phaserSprite4 = phaserSprite3.setDepth(500);
			GameObject gameObject4 = phaserSprite4.gameObject;
			((UnityEngine.Object)gameObject4).SetName("_burstSprite1");
			_burstSprite1 = phaserSprite4;
			SpriteTextures.SpriteTexturesThosepeople thosepeople2 = SpriteTextures.Thosepeople;
			if (thosepeople2.Thosepeople != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1480]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				GameObject gameObject5 = base.gameObject;
				PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject5, vector, "ThosePeople", "TP_VFX_Claimh_Solais_Burst");
				PhaserSprite phaserSprite6 = phaserSprite5.setDepth(500);
				GameObject gameObject6 = phaserSprite6.gameObject;
				((UnityEngine.Object)gameObject6).SetName("_burstSprite2");
				_burstSprite2 = phaserSprite6;
				PhaserSprite phaserSprite7 = _ringSprite.setLocalPosition(vector);
				PhaserSprite phaserSprite8 = _burstSprite1.setLocalPosition(vector);
				PhaserSprite phaserSprite9 = _burstSprite2.setLocalPosition(vector);
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnStart()
	{
		//IL_006e: Expected I, but got O
		//IL_0111: Expected I, but got O
		base.OnStart();
		if (_invisibleProjectilePool == null)
		{
			BulletPool invisibleProjectilePool = new BulletPool(_InvisibleProjectilePrefab);
			_invisibleProjectilePool = invisibleProjectilePool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pocket2_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_invisibleProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pocket2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_invisibleProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_003e: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		base.InitWeapon(characterController, weaponType);
		_bonusStatsApplied = false;
		_fireCounter = 0;
		PhaserSprite phaserSprite = _ringSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _burstSprite1.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _burstSprite2.setScale(2f, (float?)(object)0);
		PhaserSprite phaserSprite4 = _burstSprite1.setAlpha(0f);
		PhaserSprite phaserSprite5 = _burstSprite2.setAlpha(0f);
	}

	private void LateUpdate()
	{
		UpdateStatBonuses();
	}

	private void UpdateStatBonuses()
	{
		//IL_004e: Invalid comparison between I4 and F4
		//IL_0099: Expected F4, but got I4
		if (!_isVisible)
		{
			return;
		}
		RemoveCurrentStatBonuses();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		float num = (float)spawnedEnemies._size / 300f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num2 = num * 0.5f;
		_bonusStatsApplied = true;
		float bonusArmor = num * 5f;
		_bonusCritMul = num;
		_bonusPower = num2;
		_bonusArmor = bonusArmor;
		PlayerModifierStats playerStats = characterController._playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num2;
		playerStats._003CPower_003Ek__BackingField = eggFloat2;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats2 = characterController2._playerStats;
		EggFloat eggFloat3 = playerStats2._003CArmor_003Ek__BackingField;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = eggFloat3._val + _bonusArmor;
		playerStats2._003CArmor_003Ek__BackingField = eggFloat4;
		float critMul = ArcanaManager.CritMul + _bonusCritMul;
		ArcanaManager.CritMul = critMul;
	}

	private void RemoveCurrentStatBonuses()
	{
		if (_bonusStatsApplied)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			PlayerModifierStats playerStats = characterController._playerStats;
			EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val - _bonusPower;
			playerStats._003CPower_003Ek__BackingField = eggFloat2;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			PlayerModifierStats playerStats2 = characterController2._playerStats;
			EggFloat eggFloat3 = playerStats2._003CArmor_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val - _bonusArmor;
			playerStats2._003CArmor_003Ek__BackingField = eggFloat4;
			float critMul = ArcanaManager.CritMul - _bonusCritMul;
			ArcanaManager.CritMul = critMul;
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_00b4: Expected F4, but got I4
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_0271: Invalid comparison between O and F4
		//IL_00ed: Invalid comparison between F4 and I4
		//IL_0224: Invalid comparison between F4 and I4
		_003C_003Ec__DisplayClass30_0 obj = new _003C_003Ec__DisplayClass30_0();
		obj._003C_003E4__this = this;
		int num = ++_fireCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187457E43h\"");
		bool isSuperAttack = num == 0;
		obj.isSuperAttack = isSuperAttack;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		obj.flipped = characterController._isFlipped;
		float num2 = base.PAmount();
		bool flag = num <= 0;
		float num3 = num;
		if (!flag)
		{
			int num4 = 0;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				num3 = (float)num4 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if (!(num3 > 0f))
				{
					FireProjectile(num4, obj.flipped, obj.isSuperAttack);
					if (obj.isSuperAttack)
					{
						DoSuperAttackVfx();
					}
				}
				else
				{
					_003C_003Ec__DisplayClass30_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass30_1();
					CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 = obj;
					CS_0024_003C_003E8__locals7.localIndex = num4;
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						//IL_0132: Expected O, but got I4
						//IL_00a8->IL00fb: Incompatible stack heights: 1 vs 0
						//IL_00ca->IL00fb: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass30_0 obj3 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
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
								_003C_003Ec__DisplayClass30_0 obj5 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
								{
									obj5._003C_003E4__this.FireProjectile(CS_0024_003C_003E8__locals7.localIndex, obj5.flipped, obj5.isSuperAttack);
									return;
								}
							}
						}
						throw new NullReferenceException();
					};
					float num5 = (float)num4 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					num3 = num5 * 0.001f;
					Timer lastShotTimer = Timers.Register(num3, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				num4++;
				float num6 = base.PAmount();
			}
			while (num3 > (float)num4);
		}
		float num7 = base.PInterval();
		float num8 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num8 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num9 = base.PInterval();
			_lastFiringInterval = num3;
			base.ResetFiringTimer();
		}
		bool flag2 = default(bool);
		if (!flag2)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private void FireProjectile(int index, bool flipped, bool isSuperAttack)
	{
		//IL_0057: Expected I, but got O
		//IL_0065: Expected I, but got O
		//IL_0075: Expected O, but got I
		//IL_00f5: Expected O, but got I4
		//IL_00b1: Expected O, but got I
		//IL_00e7: Expected O, but got I4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, index, _targetTransform);
		bool flag = (object)projectile == null;
		TP_Pocket2_Projectile tP_Pocket2_Projectile = null;
		object obj3;
		if (!flag)
		{
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(TP_Pocket2_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Pocket2_Projectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Pocket2_Projectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rax_v24+FFFFFFF8+v95 @ rax_v20*8]");
				if (0 == (nint)typeof(TP_Pocket2_Projectile))
				{
					obj3 = 1;
					goto IL_0154;
				}
			}
			obj3 = 0;
			goto IL_0154;
		}
		goto IL_017b;
		IL_017b:
		if ((object)tP_Pocket2_Projectile != null && ((UnityEngine.Object)tP_Pocket2_Projectile).m_CachedPtr != (IntPtr)0)
		{
			tP_Pocket2_Projectile.FinishInitialisation(isSuperAttack, flipped);
		}
		return;
		IL_0154:
		bool flag2 = obj3 == null;
		tP_Pocket2_Projectile = null;
		if (!flag2)
		{
			tP_Pocket2_Projectile = (TP_Pocket2_Projectile)projectile;
		}
		goto IL_017b;
	}

	private void DoSuperAttackVfx()
	{
		//IL_0088: Expected O, but got I4
		//IL_00ee: Expected I, but got O
		//IL_0144: Expected O, but got I4
		//IL_0160: Expected O, but got I4
		//IL_0196: Expected O, but got I4
		//IL_01fc: Expected I, but got O
		//IL_0252: Expected O, but got I4
		//IL_0260: Expected O, but got I4
		//IL_029f: Expected O, but got I4
		//IL_0305: Expected I, but got O
		//IL_035b: Expected O, but got I4
		//IL_0369: Expected O, but got I4
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		if (_burstTween1 != null)
		{
			_burstTween1.Kill();
		}
		if (_burstTween2 != null)
		{
			_burstTween2.Kill();
		}
		PhaserSprite phaserSprite = _ringSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _ringSprite.setAlpha(1f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_ringSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 400f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween ringTween = Tweens.Add(tweenConfig);
		_ringTween = ringTween;
		PhaserSprite phaserSprite3 = _burstSprite1.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite4 = _burstSprite1.setAlpha(1f);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_burstSprite1 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scale = (float?)(object)1;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 400f;
		MultiTargetTween burstTween = Tweens.Add(tweenConfig2);
		_burstTween1 = burstTween;
		PhaserSprite phaserSprite5 = _burstSprite2.setScale(3f, (float?)(object)0);
		PhaserSprite phaserSprite6 = _burstSprite2.setAlpha(1f);
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_burstSprite2 != null)
		{
			nint num3 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.scale = (float?)(object)1;
		tweenConfig3.alpha = (float?)(object)1;
		tweenConfig3.duration = 400f;
		MultiTargetTween ringTween2 = Tweens.Add(tweenConfig3);
		_ringTween = ringTween2;
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
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
	}

	public override void Cleanup()
	{
		RemoveCurrentStatBonuses();
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		if (_burstTween1 != null)
		{
			_burstTween1.Kill();
		}
		if (_burstTween2 != null)
		{
			_burstTween2.Kill();
		}
		base.Cleanup();
	}

	private void KillTweens()
	{
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		if (_burstTween1 != null)
		{
			_burstTween1.Kill();
		}
		if (_burstTween2 != null)
		{
			_burstTween2.Kill();
		}
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_024c: Expected I4, but got O
		//IL_00fe: Expected I, but got O
		//IL_010c: Expected I, but got O
		//IL_011c: Expected O, but got I
		//IL_019c: Expected O, but got I4
		//IL_0158: Expected O, but got I
		//IL_018e: Expected O, but got I4
		EnemyController component;
		Projectile component2;
		Projectile projectile;
		object obj3;
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0269;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 == null)
							{
								projectile = null;
								goto IL_029b;
							}
							nint num = (nint)component2;
							nint num2 = (nint)typeof(TP_Pocket2_InvisibleProjectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Pocket2_InvisibleProjectile>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Pocket2_InvisibleProjectile>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rax_v32+FFFFFFF8+v283 @ rax_v28*8]");
								if (0 == (nint)typeof(TP_Pocket2_InvisibleProjectile))
								{
									obj3 = 1;
									goto IL_0274;
								}
							}
							obj3 = 0;
							goto IL_0274;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_029b:
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			bool flag = projectile.HasAlreadyHitObject(component);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v4 (VampireSurvivors.Objects.Projectiles.Projectile)+D0]");
				float num4 = (((nint)0 == (flag ? 1 : 0)) ? 1f : 1.7f);
				float num5 = base.PPower();
				float num6 = base.CalcCritMul();
				object obj5 = default(object);
				object obj4 = obj5 * obj5;
				float damage = (float)obj4 * num4;
				base.DealDamage(component, damage);
			}
		}
		goto IL_0269;
		IL_0274:
		bool flag2 = obj3 == null;
		projectile = null;
		if (!flag2)
		{
			projectile = component2;
		}
		goto IL_029b;
		IL_0269:
		return false;
	}
}
