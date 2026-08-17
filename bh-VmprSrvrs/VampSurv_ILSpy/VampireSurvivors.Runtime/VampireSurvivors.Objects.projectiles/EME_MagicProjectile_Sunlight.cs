using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MagicProjectile_Sunlight : Projectile
{
	protected ParticleSystem _particleSystem;

	protected ParticleEventCall _particleEventCall;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _alphaTween;

	private Timer _hitboxTimer;

	private MultiTargetTween _moveTween;

	private EME_SpiritRings1Weapon _trueWeapon;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0068: Expected I, but got O
		//IL_0070: Expected I, but got O
		//IL_0080: Expected O, but got I
		//IL_0100: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_09f6: Expected O, but got I4
		//IL_00bc: Expected O, but got I
		//IL_0124: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_0162: Expected O, but got I4
		//IL_0162: Expected O, but got I4
		//IL_0176: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		//IL_0298: Expected I4, but got F4
		//IL_0ac3: Expected I, but got O
		//IL_0a34: Expected I, but got O
		//IL_0612: Expected O, but got Ref
		//IL_036f: Expected O, but got I
		//IL_0a69: Expected O, but got F4
		//IL_03e1: Expected O, but got I
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Expected O, but got Unknown
		//IL_0458: Expected O, but got F4
		//IL_0460: Expected I4, but got O
		//IL_0764: Expected I, but got O
		//IL_0488: Expected O, but got I
		//IL_04c9: Expected O, but got I
		//IL_0b40: Expected I, but got O
		//IL_0b4a: Expected O, but got F4
		//IL_07ce: Expected O, but got I4
		//IL_0521: Expected O, but got I
		//IL_057c: Expected O, but got I
		//IL_0590: Expected O, but got F4
		//IL_0598: Expected I4, but got O
		//IL_0866: Expected I, but got O
		//IL_08d6: Expected O, but got I4
		//IL_0928: Expected I4, but got O
		//IL_0a4e->IL09c8: Incompatible stack heights: 1 vs 0
		//IL_035a->IL09c8: Incompatible stack heights: 1 vs 0
		//IL_038f->IL09c8: Incompatible stack heights: 1 vs 0
		//IL_03b1->IL09c8: Incompatible stack heights: 1 vs 0
		//IL_0a85->IL09c8: Incompatible stack heights: 1 vs 0
		//IL_0469->IL06a5: Incompatible stack heights: 1 vs 0
		//IL_07a9->IL09c8: Incompatible stack heights: 1 vs 0
		//IL_04e9->IL09c8: Incompatible stack heights: 2 vs 0
		//IL_0b5f->IL06f3: Incompatible stack heights: 1 vs 0
		//IL_0541->IL09c8: Incompatible stack heights: 3 vs 0
		//IL_0566->IL09c8: Incompatible stack heights: 3 vs 0
		//IL_0859->IL09c8: Incompatible stack heights: 1 vs 0
		//IL_05a5->IL0a8a: Incompatible stack heights: 3 vs 0
		//IL_08ab->IL09c8: Incompatible stack heights: 2 vs 0
		//IL_08ee->IL09c8: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		if ((object)_particleSystem == null)
		{
			goto IL_09c8;
		}
		_particleSystem.Play(withChildren: true);
		Weapon weapon2 = _weapon;
		_isCullable = false;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_09cf;
		}
		nint num = (nint)typeof(EME_SpiritRings1Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rdx_v90 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ r9_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rdx_v90 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ r9_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v167+FFFFFFF8+v529 @ rax_v162*8]");
			if (0 == (nint)typeof(EME_SpiritRings1Weapon))
			{
				obj3 = 1;
				goto IL_09de;
			}
		}
		obj3 = 0;
		goto IL_09de;
		IL_09de:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_09cf;
		IL_0aea:
		BulletPool bulletPool;
		bool flag2 = bulletPool == null;
		float num4 = 0.2f;
		float2 ret;
		float num5 = default(float);
		if (!flag2)
		{
			bool flag3 = ((EventEmitter)bulletPool).callbacks == null;
			num4 = 0.2f;
			if (!flag3)
			{
				bool flag4 = ((EventEmitter)bulletPool).callbacks == null;
				Transform.get_position_Injected((IntPtr)((EventEmitter)bulletPool).callbacks, out *(Vector3*)(&ret));
				base.position = (float2)num5;
				float2 float6 = default(float2);
				float2 float5 = float6;
				num4 = num5;
			}
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		Delegate[] array = (Delegate[])new object[1];
		if (array != null)
		{
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag5 = obj4 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig != null)
			{
				((EventEmitter)(object)tweenConfig).callbacks = array;
				((Group)(object)tweenConfig).children = (HashSet<PhaserGameObject>)1128792064;
				_ = 1;
				MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
				_alphaTween = alphaTween;
				if (_despawnTween != null)
				{
					_despawnTween.Kill();
				}
				TweenConfig tweenConfig2 = new TweenConfig();
				Delegate[] array2 = (Delegate[])new object[1];
				if (array2 != null)
				{
					nint num7 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					bool flag6 = obj5 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig2 != null)
					{
						((EventEmitter)(object)tweenConfig2).callbacks = array2;
						_ = 1;
						((Group)(object)tweenConfig2).children = (HashSet<PhaserGameObject>)1133903872;
						if ((object)weapon != null)
						{
							float num8 = weapon.PDuration();
							TweenCallback tweenCallback = delegate
							{
								if (_hitboxTimer != null)
								{
									_hitboxTimer.Cancel();
								}
								_particleSystem.Stop();
							};
							((Group)(object)tweenConfig2)._physicsType = (PhysicsType)tweenCallback;
							TweenCallback pool2 = delegate
							{
								Despawn();
							};
							((BulletPool)(object)tweenConfig2)._pool = (ObjectPool)(object)pool2;
							MultiTargetTween despawnTween = Tweens.Add(tweenConfig2);
							_despawnTween = despawnTween;
							return;
						}
					}
				}
			}
		}
		goto IL_09c8;
		IL_06a5:
		bulletPool = null;
		goto IL_0aea;
		IL_09cf:
		_trueWeapon = (EME_SpiritRings1Weapon)trueWeapon;
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
			ArcadeSprite arcadeSprite3 = setScale(0.2f, (float?)(object)0);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * 100f;
			soundConfig.Detune = detune;
			float num9 = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_sunlight, soundConfig, 300f, 5, num9);
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			if ((object)_weapon != null)
			{
				float hitBoxDelay = _weapon.HitBoxDelay;
				Action onComplete = delegate
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					GoToNearestEnemy();
				};
				float num10 = hitBoxDelay * 0.001f;
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer hitboxTimer = Timers.Register(num10, onComplete, null, isLooped: true, (byte)(int)num9 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_hitboxTimer = hitboxTimer;
				GameManager core = GM.Core;
				if (index != 0)
				{
					if ((object)GM.Core != null)
					{
						BulletPool cachedTransform = (BulletPool)(object)_cachedTransform;
						if ((object)_cachedTransform != null)
						{
							bool flag7 = ((EventEmitter)cachedTransform).callbacks == null;
							Transform.get_position_Injected((IntPtr)((EventEmitter)cachedTransform).callbacks, out *(Vector3*)(&ret));
							if ((object)_weapon != null)
							{
								float num11 = _weapon.PArea();
								BulletPool weapon3 = (BulletPool)(object)_weapon;
								if ((object)_weapon != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rdi_v23 (VampireSurvivors.Objects.Pools.BulletPool)+58]");
									BulletPool bulletPool2 = (BulletPool)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rdi_v23 (VampireSurvivors.Objects.Pools.BulletPool)+58]");
									if ((nint)0 != 0 && (object)core._stage != null)
									{
										List<EnemyController> enemiesInCircle = core._stage.GetEnemiesInCircle((float2)num5, num10);
										if (enemiesInCircle != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v24 (VampireSurvivors.Objects.Pools.BulletPool)+B0]");
											bool flag8 = false;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v24 (VampireSurvivors.Objects.Pools.BulletPool)+B0]");
											object obj6 = (nint)0 << 13;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v24 (VampireSurvivors.Objects.Pools.BulletPool)+B0]");
											object obj7 = obj6 ^ 0;
											object obj8 = obj7 >> 17;
											Vector3 vector = (Vector3)(obj7 ^ obj8);
											object obj9 = (object)vector << 5;
											object obj10 = obj9 ^ (object)vector;
											bool flag9 = enemiesInCircle._size <= 0;
											float num12 = num10;
											float2 float5 = (float2)num5;
											bool flag10 = (byte)(int)enemiesInCircle != 0;
											if (flag9)
											{
												goto IL_06a5;
											}
											int num13 = enemiesInCircle._size;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v24 (VampireSurvivors.Objects.Pools.BulletPool)+B0]");
											object obj11 = (nint)num13 * (nint)0;
											object obj12 = obj11 >> 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v144 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.EnemyController>)+18]");
											bool flag11 = (nint)obj12 >= 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v144 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.EnemyController>)+10]");
											object obj13 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v144 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.EnemyController>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v83+18]");
												bool flag12 = (nint)obj12 >= 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v83+20+v252 @ rcx_v125*8]");
												object obj14 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v83+20+v252 @ rcx_v125*8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rcx_v126+68]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rcx_v126+68]");
														Transform transform = ((Component)0).transform;
														num12 = num10;
														float5 = (float2)num5;
														flag10 = (byte)(int)enemiesInCircle != 0;
														bulletPool = (BulletPool)(object)transform;
														goto IL_0aea;
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
				else if ((object)GM.Core != null)
				{
					BulletPool cachedTransform2 = (BulletPool)(object)_cachedTransform;
					if ((object)_cachedTransform != null)
					{
						if (((EventEmitter)cachedTransform2).callbacks == null)
						{
							UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
						}
						else
						{
							Transform.get_position_Injected((IntPtr)((EventEmitter)cachedTransform2).callbacks, out *(Vector3*)(&ret));
							if ((object)core._stage != null)
							{
								object obj15 = default(object);
								EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj15));
								bool flag13 = (object)enemyController == null;
								float num14 = 3.4028235E+38f;
								float num12 = 300f;
								float2 float5 = ret;
								bool flag8 = true;
								bool flag10 = false;
								if (flag13)
								{
									goto IL_06a5;
								}
								Transform transform2 = enemyController.transform;
								num14 = 3.4028235E+38f;
								num12 = 300f;
								float5 = ret;
								flag8 = true;
								flag10 = false;
								bulletPool = (BulletPool)(object)transform2;
								goto IL_0aea;
							}
						}
					}
				}
			}
		}
		goto IL_09c8;
		IL_09c8:
		throw new NullReferenceException();
	}

	private unsafe void GoToNearestEnemy()
	{
		//IL_003a: Expected O, but got Ref
		//IL_00da: Expected I, but got O
		//IL_012c: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_01b4->IL01b4: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rbx_v4 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rbx_v4 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			object obj = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj));
			if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			float2 float5 = enemyController.position;
			if (_moveTween != null)
			{
				_moveTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			bool flag = obj2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.x = (float?)(object)1;
			tweenConfig.y = (float?)(object)1;
			float hitBoxDelay = _weapon.HitBoxDelay;
			float duration = hitBoxDelay * 0.35f;
			tweenConfig.duration = duration;
			TweenCallback onComplete = delegate
			{
				Weapon weapon = _weapon;
				GameManager gameMan = weapon._gameMan;
				ArcanaManager arcanaManager = gameMan._arcanaManager;
				List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj3 = default(object);
					if ((nint)obj3 != -1)
					{
						Weapon weapon2 = _weapon;
						GameManager gameMan2 = weapon2._gameMan;
						float2 float6 = base.position;
						Vector2 pos = default(Vector2);
						gameMan2._arcanaManager.TriggerFireExplosion(pos);
					}
				}
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween moveTween = Tweens.Add(tweenConfig);
			_moveTween = moveTween;
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		_isCullable = true;
		if ((object)_particleSystem != null)
		{
			_particleSystem.Stop();
		}
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void DespawnAfterParticlesToFinish()
	{
		_isCullable = true;
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__8_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		GoToNearestEnemy();
	}

	private void _003CInitProjectile_003Eb__8_1()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		_particleSystem.Stop();
	}

	private void _003CInitProjectile_003Eb__8_2()
	{
		Despawn();
	}

	private void _003CGoToNearestEnemy_003Eb__9_0()
	{
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				Weapon weapon2 = _weapon;
				GameManager gameMan2 = weapon2._gameMan;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				gameMan2._arcanaManager.TriggerFireExplosion(pos);
			}
		}
	}
}
