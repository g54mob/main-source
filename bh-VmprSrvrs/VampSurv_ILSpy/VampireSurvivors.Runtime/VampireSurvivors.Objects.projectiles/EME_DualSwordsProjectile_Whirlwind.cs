using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_DualSwordsProjectile_Whirlwind : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__11_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnRecycleSelf_003Eb__11_2()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = -2000f;
			soundConfig.Rate = 2f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_mwind1, soundConfig, 400f, 12, time);
		}
	}

	private ParticleSystem FX;

	private const float Radius = 25f;

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private bool _initialisedParticles;

	private static readonly int _AlphaMul;

	private Timer _DespawnTimer;

	private Timer _hitboxTimer;

	private bool isMoving;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 24 Invalid \"Jump target not found in method: 0x1871DA950\"");
	}

	private void InitializeSelf()
	{
		_initialisedParticles = true;
	}

	private void OnRecycleSelf()
	{
		//IL_006c: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_01d1: Invalid comparison between I4 and F4
		//IL_01f1: Expected F4, but got I4
		//IL_0281: Expected I, but got O
		//IL_030b: Expected O, but got I4
		//IL_03f4: Expected O, but got I4
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Expected O, but got Unknown
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected O, but got Unknown
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_05cf: Expected F4, but got I4
		//IL_05eb: Expected F4, but got I4
		//IL_06b8: Expected I, but got O
		//IL_074c: Expected O, but got I4
		//IL_07a0: Expected O, but got I4
		//IL_068e->IL07d4: Incompatible stack heights: 2 vs 0
		//IL_06fd->IL07d4: Incompatible stack heights: 2 vs 0
		//IL_06db->IL06db: Incompatible stack heights: 3 vs 2
		if ((object)FX != null)
		{
			FX.Play(withChildren: true);
		}
		BaseBody baseBody = body;
		_isCullable = false;
		if (body != null)
		{
			baseBody._enable = true;
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			if (body != null)
			{
				BaseBody baseBody2 = body.setCircle(25f, (float?)(object)1, (float?)(object)1);
				ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
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
					};
					float num = hitBoxDelay * 0.001f;
					bool flag = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer hitboxTimer = Timers.Register(num, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_hitboxTimer = hitboxTimer;
					if ((object)_weapon != null)
					{
						float num2 = _weapon.PArea();
						float num3 = num - 1f;
						if (0f > num3)
						{
							num3 = 0f;
						}
						float num4 = num3 * 0.5f;
						float num5 = num4 + 1f;
						bool flag2 = num5 > 3f;
						float endValue = 3f;
						if (!flag2)
						{
							endValue = num5;
						}
						if (_tween != null)
						{
							_tween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						Transform transform = base.transform;
						if (array != null)
						{
							if ((object)transform != null)
							{
								nint num6 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj = default(object);
								if (obj == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								tweenConfig.duration = 150f;
								tweenConfig.ease = Ease.Linear;
								tweenConfig.scale = (float?)(object)1;
								MultiTargetTween tween = Tweens.Add(tweenConfig);
								_tween = tween;
								Weapon weapon = _weapon;
								if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
								{
									float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
									Weapon weapon2 = _weapon;
									if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
									{
										bool flag3 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX;
										object obj2 = (flag3 ? 1 : 0) ^ 1;
										object obj3 = obj2 * 2;
										Action action = (Action)(obj3 - 1);
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer = s_scene._renderer;
												if (s_scene._renderer != null)
												{
													object obj4 = action * renderer.width;
													float num7 = (float)obj4 * 0.45f;
													bool flag4 = (object)GM.Core == null;
													Transform transform2 = base.transform;
													bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													Vector3 value = default(Vector3);
													Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
													Transform target = base.transform;
													float endValue2 = (float)float5 + num7;
													TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMoveX(target, endValue2, 0.6f);
													if (tweenerCore != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1321 @ rax_v65 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
													Transform target2 = base.transform;
													TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOMoveY(target2, endValue, 0.6f);
													if (tweenerCore2 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1486 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
														if ((nint)0 != 0)
														{
															_ = 2;
															_ = 0;
														}
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
													bool flag6 = (nint)0 != 0;
													float time = (flag ? 1 : 0);
													if (!flag6)
													{
														_ = 1;
														time = (flag ? 1 : 0);
													}
													TweenCallback tweenCallback = delegate
													{
														float num9 = _weapon.PDuration();
														Action onComplete2 = StartDespawn;
														object obj6 = default(object);
														float duration = (float)obj6 * 0.001f;
														bool useRealTime = default(bool);
														MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
														int repeat2 = default(int);
														TimerType type2 = default(TimerType);
														Timer despawnTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
														_DespawnTimer = despawnTimer;
													};
													if (_tween2 != null)
													{
														_tween2.Kill();
													}
													TweenConfig tweenConfig2 = new TweenConfig();
													object[] array2 = new object[1];
													Transform transform3 = base.transform;
													if (array2 != null)
													{
														if ((object)transform3 != null)
														{
															nint num8 = (nint)array2;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj5 = default(object);
															bool flag7 = obj5 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig2 != null)
														{
															tweenConfig2.targets = array2;
															tweenConfig2.delay = 450f;
															tweenConfig2.duration = 300f;
															tweenConfig2.ease = Ease.Linear;
															tweenConfig2.scale = (float?)(object)1;
															TweenCallback onStart = _003C_003Ec._003C_003E9__11_2;
															if (_003C_003Ec._003C_003E9__11_2 == null)
															{
																onStart = (_003C_003Ec._003C_003E9__11_2 = delegate
																{
																	//IL_003d: Expected O, but got I4
																	SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
																	soundConfig.Volume = (float?)(object)1;
																	soundConfig.Detune = -2000f;
																	soundConfig.Rate = 2f;
																	float time2 = default(float);
																	PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_mwind1, soundConfig, 400f, 12, time2);
																});
															}
															tweenConfig2.onStart = onStart;
															MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
															_tween2 = tween2;
															PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_mwind1, new SoundManager.SoundConfig
															{
																Volume = (float?)(object)1,
																Rate = 1f
															}, 400f, 12, time);
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
		}
		throw new NullReferenceException();
	}

	private void StartDespawn()
	{
		//IL_00c4: Expected I, but got O
		//IL_0136: Expected O, but got I4
		//IL_0151: Expected I, but got O
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if ((object)FX != null)
		{
			FX.Stop();
		}
		if (_tween != null)
		{
			_tween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
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
		tweenConfig.duration = 350f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_DualSwordsProjectile_Whirlwind>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween = tween;
	}

	public override void Despawn()
	{
		//IL_0100: Expected O, but got I4
		if ((object)FX != null)
		{
			FX.Clear(withChildren: true);
		}
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_DespawnTimer != null)
		{
			_DespawnTimer.Cancel();
		}
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		base.Despawn();
	}

	public override void InternalUpdate()
	{
	}

	static EME_DualSwordsProjectile_Whirlwind()
	{
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}

	private void _003COnRecycleSelf_003Eb__11_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003COnRecycleSelf_003Eb__11_1()
	{
		float num = _weapon.PDuration();
		Action onComplete = StartDespawn;
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_DespawnTimer = despawnTimer;
	}
}
