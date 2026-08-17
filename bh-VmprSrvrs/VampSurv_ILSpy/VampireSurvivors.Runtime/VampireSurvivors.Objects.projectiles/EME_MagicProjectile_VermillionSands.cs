using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
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

public class EME_MagicProjectile_VermillionSands : Projectile
{
	protected ParticleSystem _particleSystem;

	protected ParticleEventCall _particleEventCall;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _alphaTween;

	private Timer _hitboxTimer;

	private MultiTargetTween _moveTween;

	private Timer _movementTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0030: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0087: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_014d: Expected I4, but got F4
		//IL_0210: Expected I4, but got F4
		//IL_0259: Expected I4, but got O
		//IL_029e: Expected O, but got Ref
		//IL_02d4: Expected I4, but got O
		//IL_06f4: Expected O, but got F4
		//IL_03ec->IL0619: Incompatible stack heights: 1 vs 0
		//IL_0709->IL0336: Incompatible stack heights: 1 vs 0
		//IL_0415->IL0619: Incompatible stack heights: 1 vs 0
		//IL_04ba->IL0619: Incompatible stack heights: 1 vs 0
		//IL_050c->IL0619: Incompatible stack heights: 2 vs 0
		//IL_053f->IL0619: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		if ((object)_particleSystem != null)
		{
			_particleSystem.Play(withChildren: true);
			_isCullable = false;
			ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(48f, (float?)(object)1, (float?)(object)1);
				ArcadeSprite arcadeSprite3 = setScale(0.2f, (float?)(object)0);
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				float num = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Eme_sfx_vermillionsands, soundConfig, 1000f, 1, num);
				if (_movementTimer != null)
				{
					_movementTimer.Cancel();
				}
				Action onComplete = delegate
				{
					//IL_0056: Expected O, but got F4
					//IL_0092: Expected O, but got I4
					SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
					soundConfig2.Rate = 1f;
					object obj8 = UnityEngine.Random.value;
					object obj9 = default(object);
					float num9 = (float)obj9 - 0.2f;
					soundConfig2.Rate = 1f;
					float detune = num9 * 2000f;
					soundConfig2.Volume = (float?)(object)1;
					soundConfig2.Detune = detune;
					float time = default(float);
					PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Eme_sfx_vermillionmove, soundConfig2, 100f, 1, time);
					GoToNearestEnemy();
				};
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer movementTimer = Timers.Register(0.2f, onComplete, null, isLooped: true, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_movementTimer = movementTimer;
				if (_hitboxTimer != null)
				{
					_hitboxTimer.Cancel();
				}
				if ((object)_weapon != null)
				{
					float hitBoxDelay = _weapon.HitBoxDelay;
					Action onComplete2 = delegate
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					};
					float duration = hitBoxDelay * 0.001f;
					Timer hitboxTimer = Timers.Register(duration, onComplete2, null, isLooped: true, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_hitboxTimer = hitboxTimer;
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						int num2 = (int)_cachedTransform;
						if ((object)_cachedTransform != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdi_v11 (System.Int32)+10]");
							if ((nint)0 == 0)
							{
								UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdi_v11 (System.Int32)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
								if ((object)core._stage != null)
								{
									object obj = default(object);
									EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj));
									int num3;
									if ((object)enemyController != null)
									{
										Transform transform = enemyController.transform;
										num3 = (int)transform;
									}
									else
									{
										num3 = 0;
									}
									bool flag = num3 == 0;
									object obj2 = ret;
									float num4 = 0.2f;
									if (!flag)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rdi_v12 (System.Int32)+10]");
										bool flag2 = (nint)0 == 0;
										obj2 = ret;
										num4 = 0.2f;
										if (!flag2)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rdi_v12 (System.Int32)+10]");
											bool flag3 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rdi_v12 (System.Int32)+10]");
											Transform.get_position_Injected((IntPtr)0, out ret);
											float num5 = default(float);
											base.position = (float2)num5;
											object obj3 = default(object);
											obj2 = obj3;
											num4 = num5;
										}
									}
									if (_alphaTween != null)
									{
										_alphaTween.Kill();
									}
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if (array != null)
									{
										object obj4 = array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj5 = default(object);
										bool flag4 = obj5 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null && (object)_weapon != null)
										{
											float num6 = _weapon.PArea();
											_ = 1128792064;
											_ = 1;
											MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
											_alphaTween = alphaTween;
											if (_despawnTween != null)
											{
												_despawnTween.Kill();
											}
											TweenConfig tweenConfig2 = new TweenConfig();
											object[] array2 = new object[1];
											if (array2 != null)
											{
												object obj6 = array2;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj7 = default(object);
												bool flag5 = obj7 == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig2 != null)
												{
													_ = 1;
													_ = 1133903872;
													if ((object)weapon != null)
													{
														float num7 = weapon.PDuration();
														float num8 = (float)obj2 * 4f;
														TweenCallback tweenCallback = delegate
														{
															if (_movementTimer != null)
															{
																_movementTimer.Cancel();
															}
															if (_hitboxTimer != null)
															{
																_hitboxTimer.Cancel();
															}
															_particleSystem.Stop();
														};
														TweenCallback tweenCallback2 = delegate
														{
															Despawn();
														};
														MultiTargetTween despawnTween = Tweens.Add(tweenConfig2);
														_despawnTween = despawnTween;
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

	private unsafe void GoToNearestEnemy()
	{
		//IL_003a: Expected O, but got Ref
		//IL_00da: Expected I, but got O
		//IL_012c: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_0169->IL0169: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rbx_v4 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rbx_v4 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			object obj = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj));
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
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
				tweenConfig.duration = 100f;
				tweenConfig.y = (float?)(object)1;
				MultiTargetTween moveTween = Tweens.Add(tweenConfig);
				_moveTween = moveTween;
			}
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if ((object)_particleSystem != null)
		{
			_particleSystem.Stop();
		}
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void DespawnAfterParticlesToFinish()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__8_0()
	{
		//IL_0056: Expected O, but got F4
		//IL_0092: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.2f;
		soundConfig.Rate = 1f;
		float detune = num * 2000f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Eme_sfx_vermillionmove, soundConfig, 100f, 1, time);
		GoToNearestEnemy();
	}

	private void _003CInitProjectile_003Eb__8_1()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CInitProjectile_003Eb__8_2()
	{
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		_particleSystem.Stop();
	}

	private void _003CInitProjectile_003Eb__8_3()
	{
		Despawn();
	}
}
