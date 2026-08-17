using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class SilverWindProjectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__20_3;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CInitProjectile_003Eb__20_3()
		{
		}
	}

	private TrailRenderer _trail;

	private SpriteAnimation _anims;

	private Timer _expireTimer;

	[NonSerialized]
	private uint[] _colors = new uint[3] { 15658734u, 65535u, 255u };

	[NonSerialized]
	private uint[] _tints = new uint[1] { 16777215u };

	[NonSerialized]
	private List<string> _particles;

	private float _fnTime;

	private bool _isInStartingPosition;

	private ParticleEmitterManager _pfxManager;

	private bool _canUpdateTrail;

	private MultiTargetTween _fadeInTween;

	private Timer _hitboxTimer;

	private ParticleSystem _pfxEmitter;

	protected virtual uint[] Colors => _colors;

	protected virtual uint[] Tints => _tints;

	protected virtual List<string> Particles => _particles;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00a6: Expected O, but got Ref
		//IL_00c0: Expected native int or pointer, but got O
		//IL_02b8: Expected O, but got I4
		//IL_00d8: Expected O, but got Ref
		//IL_00ff: Expected O, but got I
		//IL_0114: Expected native int or pointer, but got O
		//IL_012e: Expected O, but got I
		//IL_014e: Expected O, but got Ref
		//IL_0168: Expected native int or pointer, but got O
		//IL_02d5: Expected O, but got I4
		//IL_0236: Expected O, but got I4
		//IL_0236: Expected I4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("ProjectileHoly1", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
		_pfxManager = pfxManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> particles = Particles;
		particleSystemConfig._frame = particles;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1000f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 32));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		_ = 0;
		particleSystemConfig._on = false;
		Transform parent = base.transform;
		ParticleSystem pfxEmitter = _pfxManager.CreateEmitter(particleSystemConfig, parent);
		_pfxEmitter = pfxEmitter;
		Vector2 pivot = default(Vector2);
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("leaf", 0, 19, pivot, text, num, flag);
		_anims.ForceInit();
		bool autoSetAnimation = default(bool);
		_anims.AddAnimation("spin", animationFrames, 30, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		_anims.SetAnimation("spin");
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_renderer).SetMaterial(material);
		Material material2 = MaterialManager.GetMaterial(MaterialType.TrailAdditive);
		((Renderer)_trail).SetMaterial(material2);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_00b4: Expected I4, but got O
		//IL_0115: Expected I4, but got O
		//IL_0197: Expected I4, but got O
		//IL_021a: Expected I4, but got O
		//IL_09c2: Expected O, but got I
		//IL_04cf: Invalid comparison between I and F4
		//IL_0651: Expected O, but got I4
		//IL_0883: Expected O, but got I4
		//IL_08b1: Expected F4, but got I4
		//IL_0137->IL08b6: Incompatible stack heights: 1 vs 0
		//IL_0154->IL08b6: Incompatible stack heights: 1 vs 0
		//IL_01ba->IL08b6: Incompatible stack heights: 2 vs 0
		//IL_01d7->IL08b6: Incompatible stack heights: 2 vs 0
		//IL_0234->IL08b6: Incompatible stack heights: 3 vs 0
		//IL_0975->IL08b6: Incompatible stack heights: 4 vs 0
		//IL_026d->IL08b6: Incompatible stack heights: 4 vs 0
		//IL_029c->IL08b6: Incompatible stack heights: 4 vs 0
		//IL_02cb->IL08b6: Incompatible stack heights: 4 vs 0
		//IL_09ea->IL08b6: Incompatible stack heights: 4 vs 0
		//IL_0380->IL08b6: Incompatible stack heights: 6 vs 0
		//IL_0452->IL08b6: Incompatible stack heights: 10 vs 0
		//IL_04aa->IL08b6: Incompatible stack heights: 10 vs 0
		//IL_0523->IL08b6: Incompatible stack heights: 10 vs 0
		//IL_059b->IL08b6: Incompatible stack heights: 10 vs 0
		//IL_0577->IL0577: Incompatible stack heights: 11 vs 10
		//IL_061e->IL08b6: Incompatible stack heights: 10 vs 0
		//IL_05fc->IL05fc: Incompatible stack heights: 11 vs 10
		//IL_06ff->IL08b6: Incompatible stack heights: 10 vs 0
		//IL_07c7->IL08b6: Incompatible stack heights: 10 vs 0
		base.InitProjectile(pool, weapon, index);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(4f, (float?)(object)0, (float?)(object)0);
			_isCullable = false;
			_speed = 1.1f;
			if ((object)_weapon != null)
			{
				float num = _weapon.PArea();
				float xScale = default(float);
				ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				int num2 = (int)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rdi_v11 (System.Int32)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rdi_v11 (System.Int32)+10]");
					Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret);
					ParticleSystem particleSystem = RenderingExtensions.SetScale(scale: 1f / (float)ret, component: _pfxEmitter);
					_isInStartingPosition = true;
					int num3 = (int)Colors;
					uint[] colors = Colors;
					if (colors != null && num3 != 0)
					{
						int num4 = _indexInWeapon % colors.Length;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v980 @ rax_v40 (System.Int32)+18]");
						bool flag2 = (nint)num4 >= (nint)0;
						int num5 = (int)Tints;
						uint[] tints = Tints;
						if (tints != null && num5 != 0)
						{
							int num6 = _indexInWeapon % tints.Length;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ rax_v46 (System.Int32)+18]");
							bool flag3 = (nint)num6 >= (nint)0;
							int num7 = (int)_trail;
							if ((object)_trail != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v14 (System.Int32)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v14 (System.Int32)+10]");
								TrailRenderer.Clear_Injected((IntPtr)0);
								if ((object)_trail != null)
								{
									_trail.startWidth = 0.02f;
									if ((object)_trail != null)
									{
										_trail.endWidth = 0.02f;
										if ((object)_trail != null)
										{
											_trail.time = 1.2f;
											if ((object)_trail != null)
											{
												Material material = ((Renderer)_trail).GetMaterial();
												RenderingExtensions.SetAlpha(material, 1f);
												Gradient gradient = new Gradient();
												IntPtr ptr = Gradient.Init();
												gradient.m_Ptr = ptr;
												gradient.m_RequiresNativeCleanup = true;
												GradientColorKey[] array = new GradientColorKey[2];
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v980 @ rax_v40 (System.Int32)+20+v995 @ rdx_v28 (System.Int32)*4]");
												object obj = (nint)0 >> 16;
												float num8 = (float)obj / 255f;
												if (array != null)
												{
													bool flag5 = array.Length <= 0;
													_ = 0;
													bool flag6 = array.Length <= 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
													_ = 0;
													_ = 1f;
													GradientAlphaKey[] array2 = new GradientAlphaKey[4];
													if (array2 != null)
													{
														bool flag7 = array2.Length <= 0;
														_ = 1055286886;
														bool flag8 = array2.Length <= 1;
														_ = 1048576000;
														_ = 1056964608;
														bool flag9 = array2.Length <= 2;
														_ = 1036831949;
														_ = 1056964608;
														bool flag10 = array2.Length <= 3;
														_ = 0;
														_ = 1065353216;
														gradient.SetKeys(array, array2);
														if ((object)_trail != null)
														{
															_trail.colorGradient = gradient;
															TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ rax_v46 (System.Int32)+20+v204 @ rdx_v34 (System.Int32)*4]");
															ArcadeSprite arcadeSprite2 = setTint(0u);
															if ((object)_weapon != null)
															{
																float num9 = _weapon.PArea();
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
																if (!(0f < 2f) || _fadeInTween != null)
																{
																	_fadeInTween.Kill();
																}
																TweenConfig tweenConfig = new TweenConfig();
																object[] array3 = new object[2];
																if (array3 != null)
																{
																	if ((object)_renderer != null)
																	{
																		int value = ((int*)(&array3))->m_value;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																		object obj2 = default(object);
																		bool flag11 = obj2 == null;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	if ((object)_trail != null)
																	{
																		Material material2 = ((Renderer)_trail).GetMaterial();
																		if ((object)material2 != null)
																		{
																			int value2 = ((int*)(&array3))->m_value;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																			object obj3 = default(object);
																			bool flag12 = obj3 == null;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		if (tweenConfig != null)
																		{
																			tweenConfig.targets = array3;
																			tweenConfig.duration = 200f;
																			tweenConfig.alpha = (float?)(object)1;
																			TweenCallback onStart = delegate
																			{
																				TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, 1f);
																				ArcadeSprite arcadeSprite3 = setAlpha(0f);
																			};
																			tweenConfig.onStart = onStart;
																			TweenCallback onComplete = _003C_003Ec._003C_003E9__20_3;
																			if (_003C_003Ec._003C_003E9__20_3 == null)
																			{
																				onComplete = (_003C_003Ec._003C_003E9__20_3 = delegate
																				{
																				});
																			}
																			tweenConfig.onComplete = onComplete;
																			MultiTargetTween fadeInTween = Tweens.Add(tweenConfig);
																			_fadeInTween = fadeInTween;
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
																				float num10 = hitBoxDelay * 0.001f;
																				bool flag13 = default(bool);
																				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																				int repeat = default(int);
																				TimerType type = default(TimerType);
																				Timer hitboxTimer = Timers.Register(num10, onComplete2, null, isLooped: true, flag13, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																				_hitboxTimer = hitboxTimer;
																				if (_expireTimer != null)
																				{
																					_expireTimer.Cancel();
																				}
																				if ((object)_weapon != null)
																				{
																					float num11 = _weapon.PDuration();
																					Action onComplete3 = delegate
																					{
																						if (_expireTimer != null)
																						{
																							_expireTimer.Cancel();
																						}
																						FadeOut();
																					};
																					float duration = num10 * 0.001f;
																					Timer expireTimer = Timers.Register(duration, onComplete3, null, isLooped: false, flag13, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																					_expireTimer = expireTimer;
																					_canUpdateTrail = false;
																					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
																					{
																						Rate = 1f
																					};
																					float detune = (float)_indexInWeapon * -100f;
																					soundConfig.Volume = (float?)(object)1;
																					soundConfig.Detune = detune;
																					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 100, flag13 ? 1 : 0);
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
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void SetTarget(Transform target)
	{
		//IL_013d: Expected I, but got O
		//IL_00dc: Expected O, but got I
		//IL_011f: Expected O, but got Ref
		_targetTransform = target;
		Weapon weapon = _weapon;
		Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
		float num = AngleFromTargetRadians(_targetTransform, playerTransform);
		float[] array = new float[9] { 0f, 10f, -10f, 20f, -20f, 30f, -30f, 40f, -40f };
		int num2 = _indexInWeapon % array.Length;
		float projectileSpeed = base.ProjectileSpeed;
		float num3 = array[num2] * ((float)Math.PI / 180f);
		float rotation = num3 + num;
		Vector2 vector = SetVelocityFromRotation(rotation, num);
		nint num4 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v18 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num5 = 0;
		BaseBody baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v12 (BaseBody)+74]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rcx_v12 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		object obj = num6 - 0;
		object obj2 = (object)baseBody._velocity - (object)Vector2.rightVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Transform transform = _renderer.transform;
		object obj3 = default(object);
		transform.localEulerAngles = (Vector3)(&obj3);
	}

	private void FadeOut()
	{
		//IL_003e: Expected I, but got O
		//IL_0096: Expected I, but got O
		//IL_0108: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		Material material = ((Renderer)_trail).GetMaterial();
		if ((object)material != null)
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
		if ((object)_renderer != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 100f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
	}

	public override void InternalUpdate()
	{
		//IL_0579: Expected O, but got I
		//IL_0030: Expected O, but got I
		//IL_062d: Expected O, but got F4
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Expected O, but got Unknown
		//IL_0419: Expected I, but got O
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Expected O, but got Unknown
		//IL_05d1->IL0545: Incompatible stack heights: 1 vs 0
		//IL_0092->IL0092: Incompatible stack heights: 1 vs 0
		ParticleSystem pfxEmitter = _pfxEmitter;
		bool flag = (object)_pfxEmitter == null;
		IntPtr intPtr = default(IntPtr);
		Vector2 vector = (Vector2)(nint)intPtr;
		Vector2 vector2 = default(Vector2);
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
			vector = (Vector2)(nint)intPtr;
			if (!flag2)
			{
				Renderer cachedTransform = (Renderer)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					if ((object)_pfxManager != null)
					{
						_pfxManager.EmitParticleAt(vector2);
						vector = vector2;
						goto IL_0092;
					}
				}
				goto IL_0545;
			}
		}
		goto IL_0092;
		IL_0092:
		Weapon weapon = _weapon;
		float num12;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			float2 float6 = base.position;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					object obj2 = default(object);
					object obj3 = default(object);
					object obj = obj2 - obj3;
					float num = renderer.height * 0.5f;
					float num2 = (float)obj + num;
					float num3 = num2 * 100f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
					if ((object)_trail != null)
					{
						int sortingOrder = default(int);
						_trail.sortingOrder = sortingOrder;
						Weapon weapon2 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							float2 float7 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
							float2 float8 = base.position;
							PhaserScene s_scene2 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer2 = s_scene2._renderer;
								if (s_scene2._renderer != null)
								{
									object obj4 = obj2 - obj3;
									float num4 = renderer2.height * 0.5f;
									float num5 = (float)obj4 + 1f;
									float num6 = num5 + num4;
									float num7 = num6 * 100f;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
									if ((object)_renderer != null)
									{
										int sortingOrder2 = default(int);
										_renderer.sortingOrder = sortingOrder2;
										if (!_isInStartingPosition)
										{
											goto IL_04e8;
										}
										object obj5 = Time.deltaTime;
										if ((object)_weapon != null)
										{
											float num8 = _weapon.PSpeed();
											float num9 = num7 * num7;
											float num10 = (_fnTime = num9 + _fnTime) * 3.375f;
											PhaserScene s_scene3 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null && s_scene3._renderer != null && (object)_weapon != null)
											{
												float num11 = _weapon.PArea();
												num12 = num7 * 0.125f;
												object obj6 = 0.4f & -2147483649L;
												float num13;
												if ((nint)obj6 <= 2139095040)
												{
													bool flag4 = !(0.4f > num12);
													num13 = 0.4f;
													if (flag4)
													{
														goto IL_0673;
													}
												}
												num13 = num12;
												goto IL_0673;
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
		goto IL_0545;
		IL_0545:
		throw new NullReferenceException();
		IL_04e8:
		if (!_canUpdateTrail)
		{
			_canUpdateTrail = true;
			if ((object)_trail != null)
			{
				_trail.Clear();
				return;
			}
			goto IL_0545;
		}
		return;
		IL_0673:
		Weapon weapon3 = _weapon;
		if ((object)_weapon != null)
		{
			nint num14 = (nint)weapon3;
			float num15 = _weapon.PArea();
			object obj7 = num12 & -2147483649L;
			if ((nint)obj7 > 2139095040 || !(num12 > 6f))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
			Weapon weapon4 = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
			{
				float2 float9 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.position;
				base.position = vector2;
				goto IL_04e8;
			}
		}
		goto IL_0545;
	}

	public SilverWindProjectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxHoly2.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_particles = list;
		_isInStartingPosition = true;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__20_2()
	{
		TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, 1f);
		ArcadeSprite arcadeSprite = setAlpha(0f);
	}

	private void _003CInitProjectile_003Eb__20_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CInitProjectile_003Eb__20_1()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		FadeOut();
	}

	private void _003CFadeOut_003Eb__22_0()
	{
		Despawn();
	}
}
