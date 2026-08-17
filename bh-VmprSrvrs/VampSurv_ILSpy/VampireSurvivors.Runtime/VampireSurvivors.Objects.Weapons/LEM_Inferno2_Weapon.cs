using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Graphics;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class LEM_Inferno2_Weapon : LEM_Inferno1_Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__27_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDoCoinRosary_003Eb__27_0()
		{
			GM.Core.TurnOnVacuumForGold();
			GM.Core.TurnOnVacuum();
		}
	}

	private Projectile _CombinedProjectilePrefab;

	private GenericShadowText _NaneinfText;

	private int _003CBlueKillScore_003Ek__BackingField;

	private int _003CRedKillScore_003Ek__BackingField;

	private BulletPool _combinedProjectilePool;

	private bool _hasCombined;

	private int _killsLastFrame;

	private PhaserSprite _jimboSprite;

	public int BlueKillScore
	{
		get
		{
			return _003CBlueKillScore_003Ek__BackingField;
		}
		private set
		{
			_003CBlueKillScore_003Ek__BackingField = value;
		}
	}

	public int RedKillScore
	{
		get
		{
			return _003CRedKillScore_003Ek__BackingField;
		}
		private set
		{
			_003CRedKillScore_003Ek__BackingField = value;
		}
	}

	protected virtual bool DespawnOnExplode => true;

	public override float PPower()
	{
		//IL_0087: Expected F4, but got I4
		//IL_0064: Expected F4, but got I4
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null)
		{
			int num;
			if (0 <= base._003CKillsWhileCurrentProjectileActive_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm6,xmm1\"");
				num = 0;
				float num2 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
				num = base._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
				float num2 = base._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
			}
			float num3 = ((!_hasCombined) ? 0.05f : 0.125f);
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = (float)num * num3;
					float num5 = num4 + currentWeaponData._003Cpower_003Ek__BackingField;
					float num6 = num5 * num2;
					return num2 + num6;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnStart()
	{
		//IL_008c: Expected I, but got O
		//IL_022b: Expected O, but got I4
		//IL_0247: Expected O, but got I4
		//IL_012f: Expected I, but got O
		base.OnStart();
		if (_combinedProjectilePool == null)
		{
			BulletPool combinedProjectilePool = new BulletPool(_CombinedProjectilePrefab);
			_combinedProjectilePool = combinedProjectilePool;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				ArcadePhysics physics = s_scene.physics;
				GameManager core = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno2_Weapon>)+350]");
				ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num = (nint)this;
				ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
				CallbackContext callbackContext = default(CallbackContext);
				Collider collider = physics.add.overlap(_combinedProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					ArcadePhysics physics2 = s_scene2.physics;
					GameManager core2 = GM.Core;
					PhysicsManager physicsManager = core2._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno2_Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num2 = (nint)this;
					Collider collider2 = physics2.add.overlap(_combinedProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
					goto IL_02e4;
				}
			}
			goto IL_0280;
		}
		goto IL_02e4;
		IL_0280:
		throw new NullReferenceException();
		IL_02e4:
		SpriteTextures.SpriteTexturesLemon lemon = SpriteTextures.Lemon;
		if (lemon.LEM_Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E58]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject = base.gameObject;
			Vector2 vector = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "LEM_vfx", "LEM_VFX_Jimbo");
			PhaserSprite phaserSprite2 = phaserSprite.setLocalPosition(vector);
			PhaserSprite phaserSprite3 = phaserSprite2.setDepth(1001);
			PhaserSprite phaserSprite4 = phaserSprite3.setOrigin(0f, (float?)(object)1);
			PhaserSprite phaserSprite5 = phaserSprite4.setScale(0f, (float?)(object)0);
			GameObject gameObject2 = phaserSprite5.gameObject;
			((UnityEngine.Object)gameObject2).SetName("_jimboSprite");
			_jimboSprite = phaserSprite5;
			return;
		}
		goto IL_0280;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		((Weapon)this).InitWeapon(characterController, weaponType);
		ResetKillTracking();
		base._003CHighestKillScoreThisRun_003Ek__BackingField = 0;
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (((Weapon)this)._003CTotalTime_003Ek__BackingField = (float)obj * 0.5f);
		AddOuterSaboteur();
		float num3 = base.PInterval();
		float num4 = num2 * 0.95f;
		_hasCombined = false;
		_killsLastFrame = 0;
		((Weapon)this)._003CTotalTime_003Ek__BackingField = num4;
		GenericShadowText naneinfText = _NaneinfText;
		if ((object)_NaneinfText != null && ((UnityEngine.Object)naneinfText).m_CachedPtr != (IntPtr)0)
		{
			GenericShadowText genericShadowText = RenderingExtensions.SetScale(_NaneinfText, 0f);
			_NaneinfText.SetDepth(1000);
		}
		AddInnerSaboteur();
	}

	private void InitNaneinfText()
	{
		GenericShadowText naneinfText = _NaneinfText;
		if ((object)_NaneinfText != null && ((UnityEngine.Object)naneinfText).m_CachedPtr != (IntPtr)0)
		{
			GenericShadowText genericShadowText = RenderingExtensions.SetScale(_NaneinfText, 0f);
			_NaneinfText.SetDepth(1000);
		}
	}

	protected override void FireInfernoProjectiles(Vector2 pos)
	{
		_hasCombined = false;
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
		Projectile projectile2 = base.FireOneProjectile(pos, 1, _targetTransform);
	}

	protected override void ResetKillTracking()
	{
		base._003CKillsWhileCurrentProjectileActive_003Ek__BackingField = 0;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		base._runEnemiesKilledWhenWeaponFired = config._003CRunEnemies_003Ek__BackingField;
		_003CBlueKillScore_003Ek__BackingField = 0;
	}

	protected override void UpdateKillCount()
	{
		//IL_00e0: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0109: Expected O, but got F4
		//IL_0112: Invalid comparison between F4 and O
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int num = (base._003CKillsWhileCurrentProjectileActive_003Ek__BackingField = config._003CRunEnemies_003Ek__BackingField - base._runEnemiesKilledWhenWeaponFired);
		if (num > base._003CHighestKillScoreThisRun_003Ek__BackingField)
		{
			base._003CHighestKillScoreThisRun_003Ek__BackingField = num;
		}
		object obj = num - _killsLastFrame;
		if ((nint)obj > 0)
		{
			object obj2 = 0;
			object obj4 = default(object);
			do
			{
				object obj3 = UnityEngine.Random.value;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
				{
					int num2 = _003CRedKillScore_003Ek__BackingField + 1;
					_003CRedKillScore_003Ek__BackingField = num2;
				}
				else
				{
					int num3 = _003CBlueKillScore_003Ek__BackingField + 1;
					_003CBlueKillScore_003Ek__BackingField = num3;
				}
				obj2++;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
		}
		_killsLastFrame = base._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
	}

	public override void InternalUpdate()
	{
		((Weapon)this).InternalUpdate();
		UpdateKillCount();
		float deltaTime = PauseSystem.DeltaTime;
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		float num = deltaTime * 1000f;
		float num2 = (((Weapon)this)._003CTotalTime_003Ek__BackingField = num + ((Weapon)this)._003CTotalTime_003Ek__BackingField);
		if (spawnedProjectiles._size <= 0)
		{
			float num3 = base.PInterval();
			if (!(num2 < deltaTime))
			{
				((Weapon)this)._003CTotalTime_003Ek__BackingField = 0f;
				base.Fire();
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 92 Invalid \"Jump target not found in method: 0x1874E36F0\"");
		throw new NullReferenceException();
	}

	private void CheckForCombine(bool forceCombine = false)
	{
		//IL_027c: Expected O, but got I4
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0324: Invalid comparison between I4 and F4
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_061c: Invalid comparison between I4 and F4
		//IL_0732: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected F4, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_0121: Expected I, but got O
		//IL_0129: Expected I, but got O
		//IL_0139: Expected O, but got I
		//IL_01b9: Expected O, but got I4
		//IL_03a2: Expected O, but got I4
		//IL_0175: Expected O, but got I
		//IL_070e: Expected I, but got O
		//IL_01ab: Expected O, but got I4
		//IL_042d: Expected I, but got O
		//IL_043b: Expected I, but got O
		//IL_044b: Expected O, but got I
		//IL_0487: Expected O, but got I
		//IL_06c6: Expected O, but got I4
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		if (_hasCombined)
		{
			return;
		}
		List<LEM_Inferno1_Projectile> list = new List<LEM_Inferno1_Projectile>();
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		object obj = null;
		nint num = 0;
		object obj2 = null;
		object obj6 = default(object);
		object obj7 = default(object);
		object obj8 = default(object);
		float time = default(float);
		Vector2 pos = default(Vector2);
		while (true)
		{
			object obj3;
			object obj11;
			Projectile projectile;
			object obj14;
			int num15;
			if ((nint)obj2 < spawnedProjectiles._size)
			{
				List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
				if ((nint)obj < spawnedProjectiles2._size)
				{
					Projectile[] items = spawnedProjectiles2._items;
					obj3 = items[obj];
					object obj4 = obj3 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj5 = obj6 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					num = 1;
					if (obj7 != obj8)
					{
						goto IL_01cb;
					}
					nint num2 = (nint)typeof(LEM_Inferno1_Projectile);
					nint num3 = (nint)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Inferno1_Projectile>)+130]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ r8_v11 (Il2CppClass<System.Object>)+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Inferno1_Projectile>)+130]");
					if (num4 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ r8_v11 (Il2CppClass<System.Object>)+C8]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v875 @ rax_v60+FFFFFFF8+v843 @ rax_v55*8]");
						if (0 == (nint)typeof(LEM_Inferno1_Projectile))
						{
							obj11 = 1;
							goto IL_05f1;
						}
					}
					obj11 = 0;
					goto IL_05f1;
				}
			}
			else
			{
				int num5 = list._size ^ list._size;
				int num6 = list._size & num5;
				bool flag = num6 < 0;
				bool flag2 = list._size < 0;
				bool flag3 = list._size == 0;
				if (flag3)
				{
					break;
				}
				bool flag4 = flag2 == flag;
				object obj12 = !flag4;
				object obj13 = obj12 | flag3;
				if (obj13 == null)
				{
					LEM_Inferno1_Projectile[] items2 = list._items;
					LEM_Inferno1_Projectile lEM_Inferno1_Projectile = items2[0];
					float num7 = lEM_Inferno1_Projectile._currentAngleDeg;
					if (list._size > 1)
					{
						LEM_Inferno1_Projectile lEM_Inferno1_Projectile2 = items2[1];
						float num8 = lEM_Inferno1_Projectile2._currentAngleDeg;
						if (0f > lEM_Inferno1_Projectile._currentAngleDeg)
						{
							num7 += 360f;
						}
						if (0f > num8)
						{
							num8 += 360f;
						}
						float num9 = num7 - num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						float num10 = num9 & 0;
						float num11 = 360f - num10;
						if (!(num11 > num10))
						{
							num10 = num11;
						}
						bool flag5 = !(5f > num10);
						bool flag6 = forceCombine;
						if (!flag5)
						{
							flag6 = true;
						}
						if (!flag6)
						{
							break;
						}
						_hasCombined = true;
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Volume = (float?)(object)1;
						soundConfig.Rate = 0.5f;
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, time);
						float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						projectile = base.FireOneProjectile(pos, 0, _targetTransform);
						bool flag7 = (object)projectile == null;
						obj14 = null;
						if (!flag7)
						{
							nint num12 = (nint)projectile;
							nint num13 = (nint)typeof(LEM_Inferno2_Projectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Inferno2_Projectile>)+130]");
							object obj15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num14 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Inferno2_Projectile>)+130]");
							if (num14 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj16 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v44+FFFFFFF8+v978 @ rax_v40*8]");
								if (0 == (nint)typeof(LEM_Inferno2_Projectile))
								{
									num15 = 1;
									goto IL_0660;
								}
							}
							num15 = 0;
							goto IL_0660;
						}
						goto IL_0687;
					}
				}
			}
			goto IL_058d;
			IL_01cb:
			spawnedProjectiles = _spawnedProjectiles;
			obj++;
			obj2 = obj;
			continue;
			IL_058d:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new NullReferenceException();
			IL_0660:
			bool flag8 = num15 == 0;
			obj14 = null;
			if (!flag8)
			{
				obj14 = projectile;
			}
			goto IL_0687;
			IL_05f1:
			bool flag9 = obj11 == null;
			object obj17 = null;
			if (!flag9)
			{
				obj17 = obj3;
			}
			((List<object>)(object)list).Add(obj17);
			num = (nint)obj17;
			goto IL_01cb;
			IL_0687:
			bool flag10 = (nint)obj14 < 0;
			if (obj14 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rbp_v8 (System.Object)+10]");
				flag10 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rbp_v8 (System.Object)+10]");
				if ((nint)0 == 0)
				{
				}
			}
			object obj18 = list._size - 1;
			if (flag10)
			{
				break;
			}
			while ((nint)obj18 < list._size)
			{
				LEM_Inferno1_Projectile[] items3 = list._items;
				items3[obj18].Despawn();
				obj18--;
				if ((nint)items3[obj18] < 0)
				{
					return;
				}
			}
			goto IL_058d;
		}
	}

	private void CombineProjectiles()
	{
		CheckForCombine(forceCombine: true);
	}

	public unsafe void TriggerNaneinf()
	{
		DoCoinRosary();
		DoNaneinfTextAnim();
		Action action = DoJimboSpriteAnim;
		action._002Ector(this, (nint)__ldftn(LEM_Inferno2_Weapon.DoJimboSpriteAnim));
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.25f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		DespawnActiveProjectiles();
		float num = base.PInterval();
		if (!(((Weapon)this)._003CTotalTime_003Ek__BackingField < 0.25f))
		{
			float num2 = base.PInterval();
			float num3 = 0.25f - 2000f;
			((Weapon)this)._003CTotalTime_003Ek__BackingField = num3;
		}
	}

	private unsafe void DoCoinRosary()
	{
		//IL_0044: Expected O, but got Ref
		//IL_023a: Expected O, but got I
		//IL_0225: Expected O, but got I
		//IL_01b9: Expected O, but got I
		//IL_0338: Expected I, but got O
		//IL_034e: Expected O, but got I
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_03ec: Expected I, but got O
		//IL_05b9: Expected O, but got I4
		//IL_05d0: Expected I, but got I8
		//IL_03ae: Expected I, but got I8
		//IL_02db: Expected O, but got Ref
		//IL_039c->IL03cd: Incompatible stack heights: 0 vs 1
		//IL_05e6->IL03f1: Incompatible stack heights: 1 vs 0
		//IL_03b3->IL05b0: Incompatible stack heights: 0 vs 1
		//IL_05ff->IL0461: Incompatible stack heights: 1 vs 0
		//IL_02c4->IL0461: Incompatible stack heights: 1 vs 0
		//IL_02f7->IL0461: Incompatible stack heights: 1 vs 0
		//IL_0321->IL0321: Incompatible stack heights: 1 vs 0
		List<EnemyController> allEnemiesOnScreen = GetAllEnemiesOnScreen();
		List<EnemyController> ret;
		if (allEnemiesOnScreen != null)
		{
			ret = allEnemiesOnScreen;
			List<EnemyController> list = allEnemiesOnScreen;
			List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
			if (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				List<EnemyController>.Enumerator enumerator2 = (List<EnemyController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			ArcadeSprite playerOptions = (ArcadeSprite)(object)_playerOptions;
			if (_playerOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v6 (ArcadeSprite)+68]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v6 (ArcadeSprite)+58]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v6 (ArcadeSprite)+78]");
						Transform transform;
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v6 (ArcadeSprite)+78]");
							transform = (Transform)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v793 @ rax_v21 (UnityEngine.Transform)+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_04ea;
							}
						}
						transform = playerOptions._cachedTrans;
						if ((object)playerOptions._cachedTrans == null)
						{
							goto IL_0461;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v6 (ArcadeSprite)+58]");
						Transform transform = (Transform)0;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v6 (ArcadeSprite)+68]");
					Transform transform = (Transform)0;
				}
				goto IL_04ea;
			}
		}
		goto IL_0461;
		IL_0544:
		Action onComplete = _003C_003Ec._003C_003E9__27_0;
		if (_003C_003Ec._003C_003E9__27_0 != null)
		{
			goto IL_03f1;
		}
		Action action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ r10_v3 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec._003CDoCoinRosary_003Eb__27_0);
		((Delegate)action).m_target = _003C_003Ec._003C_003E9;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ r10_v3 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		nint num2;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ r10_v3 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num2 = unchecked((nint)6447293664L);
				goto IL_05b0;
			}
		}
		else
		{
			bool flag = _003C_003Ec._003C_003E9 == null;
		}
		num2 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_05b0;
		IL_03f1:
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_05b0:
		object obj3 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		_003C_003Ec._003C_003E9__27_0 = action;
		onComplete = action;
		goto IL_03f1;
		IL_0461:
		throw new NullReferenceException();
		IL_04ea:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v793 @ rax_v21 (UnityEngine.Transform)+118]");
		if ((nint)0 != 0)
		{
			Camera main = Camera.main;
			if ((object)main != null)
			{
				Transform transform2 = main.transform;
				if ((object)transform2 != null)
				{
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
					if ((object)HeroVfxManager._factory != null)
					{
						ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.RosaryVfx);
						if ((object)pool != null)
						{
							RosaryVfx objectComponent = pool.GetObjectComponent<RosaryVfx>((Vector3)(&ret));
							if ((object)objectComponent != null)
							{
								objectComponent.SetParent(transform2);
								objectComponent.Play();
								goto IL_0544;
							}
						}
					}
				}
			}
			goto IL_0461;
		}
		goto IL_0544;
	}

	private List<EnemyController> GetAllEnemiesOnScreen()
	{
		//IL_007e: Expected O, but got I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_0137->IL0154: Incompatible stack heights: 2 vs 1
		//IL_013c->IL013c: Incompatible stack heights: 2 vs 1
		GameManager core = GM.Core;
		Stage stage = core._stage;
		bool flag = stage._spawnedEnemies == null;
		List<object> list = new List<object>(stage._spawnedEnemies);
		bool flag2 = (nint)list < 0;
		object obj = list._size - 1;
		if (!flag2)
		{
			bool flag4;
			do
			{
				bool flag3 = (nint)obj >= list._size;
				object[] items = list._items;
				ArcadeSprite arcadeSprite = (ArcadeSprite)items[obj];
				IntPtr main_Injected = Camera.get_main_Injected();
				Camera camera = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Camera>(main_Injected);
				((ArcadeSprite)items[obj]).CheckRenderer();
				flag4 = CameraExtensions.IsObjectVisible(camera, arcadeSprite._spriteRenderer);
				if (!flag4)
				{
					bool flag5 = list.Remove(items[obj]);
				}
				obj--;
			}
			while ((flag4 ? 1 : 0) >= (false ? 1 : 0));
		}
		return (List<EnemyController>)(object)list;
	}

	private unsafe void DoNaneinfTextAnim()
	{
		//IL_008a: Expected O, but got Ref
		//IL_02e9: Expected O, but got Ref
		GenericShadowText naneinfText = _NaneinfText;
		if ((object)_NaneinfText == null || ((UnityEngine.Object)naneinfText).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GenericShadowText genericShadowText = RenderingExtensions.SetScale(_NaneinfText, 0f);
		_NaneinfText.SetAlpha(1f);
		Transform transform = _NaneinfText.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		Transform target = _NaneinfText.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 10f, 2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 3;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GenericShadowText naneinfText2 = _NaneinfText;
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(naneinfText2._Text, 0f, 2f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GenericShadowText naneinfText3 = _NaneinfText;
		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(naneinfText3._ShadowText, 0f, 2f);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target2 = _NaneinfText.transform;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj), 2f);
		if (tweenerCore4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v996 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 3;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	private unsafe void DoJimboSpriteAnim()
	{
		//IL_0058: Expected O, but got Ref
		//IL_01fb: Expected O, but got Ref
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_jimboSprite, 0f);
		PhaserSprite phaserSprite2 = _jimboSprite.setAlpha(1f);
		Transform transform = _jimboSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		Transform target = _jimboSprite.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 2f, 1.5000001f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 3;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite jimboSprite = _jimboSprite;
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(jimboSprite._spriteRenderer, 0f, 1.5000001f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target2 = _jimboSprite.transform;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj), 1.5000001f);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 3;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	private void AddToBlueKillScore(int amount = 1)
	{
		int num = _003CBlueKillScore_003Ek__BackingField + amount;
		_003CBlueKillScore_003Ek__BackingField = num;
	}

	private void AddToRedKillScore(int amount = 1)
	{
		int num = _003CRedKillScore_003Ek__BackingField + amount;
		_003CRedKillScore_003Ek__BackingField = num;
	}
}
