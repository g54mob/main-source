using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Frog2_TongueProjectile : Projectile
{
	private enum TongueState
	{
		Launch,
		Hold,
		Retract
	}

	private const float LaunchDurationMS = 100f;

	private const float HoldDurationMS = 300f;

	private const float RetractDurationMS = 200f;

	private PhaserSprite _tongueSprite;

	private PhaserSprite _fakeEnemySprite;

	private Vector2 _targetPos;

	private EnemyController _targetEnemy;

	private float _tongueSpriteWidth;

	private Timer _tongueTimer;

	private Timer _frogSpawnTimer;

	private TongueState _tongueState;

	private TP_Frog2_Weapon _trueWeapon;

	protected override void Awake()
	{
		//IL_0115: Expected O, but got I4
		//IL_0131: Expected O, but got I4
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
		if (thosepeople.Thosepeople != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A15BC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Frog_Tongue");
			PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0f, (float?)(object)1);
			PhaserSprite phaserSprite3 = phaserSprite2.setScale(1f, (float?)(object)0);
			GameObject gameObject2 = phaserSprite3.gameObject;
			((UnityEngine.Object)gameObject2).SetName("_tongueSprite");
			_tongueSprite = phaserSprite3;
			float width = _tongueSprite.Width;
			_tongueSpriteWidth = width;
			SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
			if (spriteTexturesBase.Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				GameObject gameObject3 = base.gameObject;
				PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "vfx", "WhiteDot");
				PhaserSprite phaserSprite5 = phaserSprite4.setVisible(visible: false);
				GameObject gameObject4 = phaserSprite5.gameObject;
				((UnityEngine.Object)gameObject4).SetName("_fakeEnemySprite");
				_fakeEnemySprite = phaserSprite5;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_0230: Expected O, but got I4
		//IL_00c8: Expected I4, but got O
		//IL_00ab: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		bool flag;
		if ((object)_weapon == null)
		{
			flag = false;
			goto IL_0226;
		}
		nint num = (nint)typeof(TP_Frog2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Frog2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Frog2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v32+FFFFFFF8+v69 @ rax_v27*8]");
			if (0 == (nint)typeof(TP_Frog2_Weapon))
			{
				obj3 = 1;
				goto IL_0235;
			}
		}
		obj3 = 0;
		goto IL_0235;
		IL_0235:
		bool flag2 = obj3 == null;
		flag = false;
		if (!flag2)
		{
			flag = (byte)(int)_weapon != 0;
		}
		goto IL_0226;
		IL_0226:
		_trueWeapon = (TP_Frog2_Weapon)flag;
		Transform transform = base.transform;
		Transform parent = _weapon.transform;
		transform.SetParent(parent, worldPositionStays: true);
		PhaserSprite phaserSprite = _tongueSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _fakeEnemySprite.setVisible(visible: false);
		if (_tongueTimer != null)
		{
			_tongueTimer.Cancel();
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num4 = deltaTime * 1000f;
		Action onComplete = LaunchTongue;
		float duration = num4 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer tongueTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_tongueTimer = tongueTimer;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0391: Expected F4, but got O
		//IL_00ba: Expected O, but got I4
		//IL_01d8: Expected O, but got I4
		//IL_00ee: Expected F4, but got I4
		//IL_02a9: Expected O, but got I4
		//IL_0168->IL02b2: Incompatible stack heights: 1 vs 0
		//IL_035a->IL02b2: Incompatible stack heights: 1 vs 0
		//IL_011f->IL02b2: Incompatible stack heights: 1 vs 0
		//IL_0244->IL02b2: Incompatible stack heights: 1 vs 0
		//IL_0215->IL02b2: Incompatible stack heights: 1 vs 0
		//IL_0379->IL02b2: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		float ret;
		Transform tongueTimer;
		float num2;
		float num;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			object obj = (object)_targetPos - (object)float5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Frog2_TongueProjectile)+E4]");
			object obj3 = default(object);
			object obj2 = 0 - obj3;
			if ((object)_tongueSprite != null)
			{
				Transform transform = _tongueSprite.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				Vector3 axis = default(Vector3);
				Quaternion.AngleAxis_Injected((float)_tongueSprite, ref axis, out *(Quaternion*)(&ret));
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float value = default(float);
				Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)(&value));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
				bool flag2 = _tongueState == TongueState.Launch;
				if (!flag2)
				{
					object obj4 = _tongueState - 1;
					if (!flag2)
					{
						if ((nint)obj4 == 1)
						{
							tongueTimer = (Transform)(object)_tongueTimer;
							if (_tongueTimer != null)
							{
								num = _tongueTimer.GetTimeRemaining();
								goto IL_018b;
							}
							goto IL_02b2;
						}
						num2 = 0f;
						num = ret;
					}
					else
					{
						num2 = 1f;
						num = ret;
					}
					goto IL_0340;
				}
				if (_tongueTimer != null)
				{
					num = _tongueTimer.GetTimeElapsed();
					tongueTimer = (Transform)(object)_tongueTimer;
					goto IL_018b;
				}
			}
		}
		goto IL_02b2;
		IL_018b:
		num2 = num / (float)(nint)((UnityEngine.Object)tongueTimer).m_CachedPtr;
		goto IL_0340;
		IL_02b2:
		throw new NullReferenceException();
		IL_0340:
		if ((object)_tongueSprite != null)
		{
			float num3 = ret / _tongueSpriteWidth;
			float xScale = num3 * num2;
			PhaserSprite phaserSprite = _tongueSprite.setScale(xScale, (float?)(object)1);
			if (_tongueState != TongueState.Retract)
			{
				if ((object)_fakeEnemySprite != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
					return;
				}
			}
			else if ((object)_fakeEnemySprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				float xScale2 = ((!(0.5f > num2)) ? 1f : (num2 + num2));
				if ((object)_fakeEnemySprite != null)
				{
					PhaserSprite phaserSprite2 = _fakeEnemySprite.setScale(xScale2, (float?)(object)0);
					return;
				}
			}
		}
		goto IL_02b2;
	}

	private void LaunchTongue()
	{
		//IL_001a: Expected O, but got I4
		//IL_0123: Expected O, but got F4
		//IL_015f: Expected O, but got I4
		//IL_00da: Expected I4, but got F4
		_tongueState = TongueState.Launch;
		PhaserSprite phaserSprite = _tongueSprite.setScale(0f, (float?)(object)1);
		PhaserSprite phaserSprite2 = _tongueSprite.setVisible(visible: true);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig.Rate = 2f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hasta, soundConfig, 200f, 10, num2);
		MorphTargetEnemy();
		if (_tongueTimer != null)
		{
			_tongueTimer.Cancel();
		}
		Action onComplete = HoldTongue;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer tongueTimer = Timers.Register(0.1f, onComplete, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_tongueTimer = tongueTimer;
	}

	private void HoldTongue()
	{
		_tongueState = TongueState.Hold;
		if (_tongueTimer != null)
		{
			_tongueTimer.Cancel();
		}
		Action onComplete = RetractTongue;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer tongueTimer = Timers.Register(0.3f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_tongueTimer = tongueTimer;
	}

	private void RetractTongue()
	{
		//IL_0105: Expected O, but got F4
		//IL_0141: Expected O, but got I4
		//IL_0088: Expected I, but got O
		//IL_00bc: Expected I4, but got F4
		_tongueState = TongueState.Retract;
		float2 float5 = default(float2);
		_trueWeapon.MakeHeartPickup(float5);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		float num = (float)float5 - 0.5f;
		soundConfig.Rate = 1.25f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hit, soundConfig, 200f, 10, num2);
		if (_tongueTimer != null)
		{
			_tongueTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog2_TongueProjectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num3 = (nint)this;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer tongueTimer = Timers.Register(0.2f, onComplete, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_tongueTimer = tongueTimer;
	}

	private void MorphTargetEnemy()
	{
		//IL_0166: Expected O, but got I4
		//IL_036b->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_014c->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_0184->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_01b7->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_01e2->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_0216->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_023f->IL02f1: Incompatible stack heights: 1 vs 0
		TP_Frog2_Weapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			int num = trueWeapon._003CEnemiesEatenThisRun_003Ek__BackingField + 1;
			trueWeapon._003CEnemiesEatenThisRun_003Ek__BackingField = num;
			EnemyController targetEnemy = _targetEnemy;
			if ((object)_targetEnemy != null)
			{
				SpriteRenderer enemyRenderer = targetEnemy._EnemyRenderer;
				if ((object)_fakeEnemySprite != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
					PhaserSprite fakeEnemySprite = _fakeEnemySprite;
					if ((object)_fakeEnemySprite != null && (object)targetEnemy._EnemyRenderer != null)
					{
						Sprite sprite = targetEnemy._EnemyRenderer.sprite;
						if ((object)fakeEnemySprite._spriteRenderer != null)
						{
							fakeEnemySprite._spriteRenderer.sprite = sprite;
							bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
							bool flag2 = SpriteRenderer.get_flipX_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr);
							if ((object)_fakeEnemySprite != null)
							{
								PhaserSprite phaserSprite = _fakeEnemySprite.setFlipX(flag2);
								if ((object)_fakeEnemySprite != null)
								{
									PhaserSprite phaserSprite2 = _fakeEnemySprite.setScale(1f, (float?)(object)0);
									if ((object)_fakeEnemySprite != null)
									{
										PhaserSprite phaserSprite3 = _fakeEnemySprite.setVisible(visible: true);
										if ((object)_targetEnemy != null)
										{
											_targetEnemy.GiveReward();
											if ((object)_targetEnemy != null)
											{
												_targetEnemy.Despawn();
												Weapon weapon = _weapon;
												if ((object)_weapon != null)
												{
													EnemyController targetEnemy2 = _targetEnemy;
													if ((object)_targetEnemy != null)
													{
														float num2 = targetEnemy2._hp + weapon._003CStatsInflictedDamage_003Ek__BackingField;
														weapon._003CStatsInflictedDamage_003Ek__BackingField = num2;
														if (_frogSpawnTimer != null)
														{
															_frogSpawnTimer.Cancel();
														}
														Action onComplete = delegate
														{
															//IL_0058: Expected I, but got O
															//IL_0066: Expected I, but got O
															//IL_0076: Expected O, but got I
															//IL_00f6: Expected O, but got I4
															//IL_00b2: Expected O, but got I
															//IL_00e8: Expected O, but got I4
															//IL_01a2: Expected O, but got I
															//IL_020b: Expected O, but got I8
															TP_Frog2_Weapon trueWeapon2 = _trueWeapon;
															float2 pos = default(float2);
															Projectile projectile = trueWeapon2._frogProjectilePool.SpawnAt(pos, _weapon);
															object obj3;
															if ((object)projectile != null)
															{
																nint num3 = (nint)projectile;
																nint num4 = (nint)typeof(TP_Frog2_FrogProjectile);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog2_FrogProjectile>)+130]");
																object obj = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
																nint num5 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog2_FrogProjectile>)+130]");
																if (num5 >= 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
																	object obj2 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v47+FFFFFFF8+v213 @ rax_v43*8]");
																	if (0 == (nint)typeof(TP_Frog2_FrogProjectile))
																	{
																		obj3 = 1;
																		goto IL_02a5;
																	}
																}
																obj3 = 0;
																goto IL_02a5;
															}
															TP_Frog_Projectile tP_Frog_Projectile = null;
															goto IL_02cc;
															IL_02a5:
															bool flag3 = obj3 == null;
															tP_Frog_Projectile = null;
															if (!flag3)
															{
																tP_Frog_Projectile = (TP_Frog_Projectile)projectile;
															}
															goto IL_02cc;
															IL_02cc:
															if ((object)tP_Frog_Projectile != null && ((UnityEngine.Object)tP_Frog_Projectile).m_CachedPtr != (IntPtr)0)
															{
																bool flag4 = _fakeEnemySprite.flipX;
																bool flag5 = (byte)((flag4 ? 1u : 0u) ^ 1u) != 0;
																PhaserSprite phaserSprite4 = tP_Frog_Projectile._frogSprite.setFlipX(flag5);
																BaseBody baseBody = tP_Frog_Projectile.body;
																baseBody._enable = true;
																tP_Frog_Projectile.PlayFrogAnim("idle");
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
																object obj4 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
																bool flag6 = (nint)0 != 0;
																TP_Frog_Projectile tP_Frog_Projectile2 = tP_Frog_Projectile;
																if (!flag6)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																	if (obj4 == null)
																	{
																		MissingMethodException ex = new MissingMethodException();
																		throw ex;
																	}
																	tP_Frog_Projectile2 = (TP_Frog_Projectile)6573110936L;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v541 @ rax_v23 (should have been resolved before IL gen)");
																if (tP_Frog_Projectile._moveTimer != null)
																{
																	tP_Frog_Projectile._moveTimer.Cancel();
																}
																Action onComplete2 = tP_Frog_Projectile._003CIdleOnSpawn_003Eb__26_0;
																float duration = 200f * 0.001f;
																bool useRealTime2 = default(bool);
																MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
																int repeat2 = default(int);
																TimerType type2 = default(TimerType);
																Timer moveTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
																tP_Frog_Projectile._moveTimer = moveTimer;
															}
														};
														bool useRealTime = default(bool);
														MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
														int repeat = default(int);
														TimerType type = default(TimerType);
														Timer frogSpawnTimer = Timers.Register(0.4f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
														_frogSpawnTimer = frogSpawnTimer;
														return;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SetTargetEnemy(EnemyController enemy)
	{
		_targetEnemy = enemy;
		if ((object)enemy != null)
		{
			((ArcadeSprite)enemy).CheckRenderer();
			if ((object)((ArcadeSprite)enemy)._spriteRenderer != null)
			{
				Transform transform = ((ArcadeSprite)enemy)._spriteRenderer.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector2 ret;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					_targetPos = ret;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void PlayLaunchSfx()
	{
		//IL_004b: Expected O, but got F4
		//IL_0087: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig.Rate = 2f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hasta, soundConfig, 200f, 10, time);
	}

	private void PlayRetractSfx()
	{
		//IL_004b: Expected O, but got F4
		//IL_0087: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig.Rate = 1.25f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hit, soundConfig, 200f, 10, time);
	}

	public override void Despawn()
	{
		if (_tongueTimer != null)
		{
			_tongueTimer.Cancel();
		}
		if (_frogSpawnTimer != null)
		{
			_frogSpawnTimer.Cancel();
		}
		base.Despawn();
	}

	private void _003CMorphTargetEnemy_003Eb__19_0()
	{
		//IL_0058: Expected I, but got O
		//IL_0066: Expected I, but got O
		//IL_0076: Expected O, but got I
		//IL_00f6: Expected O, but got I4
		//IL_00b2: Expected O, but got I
		//IL_00e8: Expected O, but got I4
		//IL_01a2: Expected O, but got I
		//IL_020b: Expected O, but got I8
		TP_Frog2_Weapon trueWeapon = _trueWeapon;
		float2 pos = default(float2);
		Projectile projectile = trueWeapon._frogProjectilePool.SpawnAt(pos, _weapon);
		TP_Frog_Projectile tP_Frog_Projectile;
		if ((object)projectile == null)
		{
			tP_Frog_Projectile = null;
			goto IL_02cc;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(TP_Frog2_FrogProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog2_FrogProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog2_FrogProjectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v47+FFFFFFF8+v213 @ rax_v43*8]");
			if (0 == (nint)typeof(TP_Frog2_FrogProjectile))
			{
				obj3 = 1;
				goto IL_02a5;
			}
		}
		obj3 = 0;
		goto IL_02a5;
		IL_02a5:
		bool flag = obj3 == null;
		tP_Frog_Projectile = null;
		if (!flag)
		{
			tP_Frog_Projectile = (TP_Frog_Projectile)projectile;
		}
		goto IL_02cc;
		IL_02cc:
		if ((object)tP_Frog_Projectile == null || ((UnityEngine.Object)tP_Frog_Projectile).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		bool flag2 = _fakeEnemySprite.flipX;
		bool flag3 = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
		PhaserSprite phaserSprite = tP_Frog_Projectile._frogSprite.setFlipX(flag3);
		BaseBody baseBody = tP_Frog_Projectile.body;
		baseBody._enable = true;
		tP_Frog_Projectile.PlayFrogAnim("idle");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag4 = (nint)0 != 0;
		TP_Frog_Projectile tP_Frog_Projectile2 = tP_Frog_Projectile;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj4 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			tP_Frog_Projectile2 = (TP_Frog_Projectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v541 @ rax_v23 (should have been resolved before IL gen)");
		if (tP_Frog_Projectile._moveTimer != null)
		{
			tP_Frog_Projectile._moveTimer.Cancel();
		}
		Action onComplete = tP_Frog_Projectile._003CIdleOnSpawn_003Eb__26_0;
		float duration = 200f * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer moveTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		tP_Frog_Projectile._moveTimer = moveTimer;
	}
}
