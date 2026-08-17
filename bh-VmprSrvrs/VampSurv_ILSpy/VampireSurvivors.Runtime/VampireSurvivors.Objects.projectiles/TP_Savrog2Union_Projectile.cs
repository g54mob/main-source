using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Savrog2Union_Projectile : Projectile
{
	private TrailRenderer _Trail;

	private TrailRenderer _Trail2;

	private Material _Trail2MaterialLight;

	private Material _Trail2MaterialDark;

	[NonSerialized]
	public bool _isYeeted;

	[NonSerialized]
	public float _durataMillis;

	private MultiTargetTween _tween1;

	private SpriteRenderer _groundFx;

	private PhaserSprite _spikeSprite;

	private Vector2 _previousVector;

	private VampireSurvivors.Framework.TimerSystem.Timer _hitboxTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _expireTimer;

	private TP_Savrog2Union_Weapon _trueWeapon;

	private uint _tint = 16711680u;

	private bool _tpDlcLoaded;

	private TP_Savrog_Weapon _unionWeapon;

	private MultiTargetTween _unionTintTween;

	private int _unionTintCounter;

	private bool _isInverted;

	private const int RADIUS = 8;

	protected override void Awake()
	{
		//IL_00e8: Expected O, but got I4
		//IL_0169: Expected O, but got I4
		//IL_0151->IL02ff: Incompatible stack heights: 1 vs 0
		//IL_0196->IL02ff: Incompatible stack heights: 1 vs 0
		base.Awake();
		if ((object)this != null)
		{
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			SpriteRenderer spriteRenderer = RenderingExtensions.AddGraphic(gameObject, pos);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.FillCircle(spriteRenderer, 8);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(spriteRenderer2, 0.5f);
			SpriteRenderer spriteRenderer4 = RenderingExtensions.SetTint(spriteRenderer3, 4456448u);
			if ((object)spriteRenderer4 != null)
			{
				spriteRenderer4.enabled = true;
				Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
				((Renderer)spriteRenderer4).SetMaterial(material);
				_groundFx = spriteRenderer4;
				ArcadeSprite arcadeSprite = setVisible(visible: false);
				_previousVector = (Vector2)0;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v33 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v33 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
					GameObject gameObject2 = base.gameObject;
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_FireValve02");
					if ((object)phaserSprite != null)
					{
						PhaserSprite spikeSprite = phaserSprite.setOrigin(0.5f, (float?)(object)1);
						_spikeSprite = spikeSprite;
						if ((object)_spikeSprite != null)
						{
							Transform transform2 = _spikeSprite.transform;
							bool flag2 = (object)transform2 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rax_v45 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rax_v45 (UnityEngine.Transform)+10]");
							Transform.set_localPosition_Injected((IntPtr)0, ref ret);
							int num = default(int);
							List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_FireValve", 2, 5, "ThosePeople", num);
							PhaserSprite spikeSprite2 = _spikeSprite;
							bool flag4 = (object)_spikeSprite == null;
							bool flag5 = (object)spikeSprite2._spriteAnimation == null;
							bool startRandomFrame = default(bool);
							Action onComplete = default(Action);
							bool autoSetAnimation = default(bool);
							spikeSprite2._spriteAnimation.AddAnimation("idle", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
							PhaserSprite spikeSprite3 = _spikeSprite;
							bool flag6 = (object)_spikeSprite == null;
							bool flag7 = (object)spikeSprite3._spriteAnimation == null;
							spikeSprite3._spriteAnimation.SetAnimation("idle");
							Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
							bool flag8 = loadedDlc == null;
							int num2 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)5);
							int num3 = num2 >> 31;
							int tpDlcLoaded = num3 ^ 1;
							_tpDlcLoaded = (byte)tpDlcLoaded != 0;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0a26: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_0139: Expected O, but got I4
		//IL_0139: Expected O, but got I4
		//IL_0a3d: Expected O, but got F4
		//IL_01b6: Invalid comparison between F4 and O
		//IL_01d5: Invalid comparison between F4 and I4
		//IL_02cf: Expected O, but got I4
		//IL_0a65: Expected O, but got F4
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		//IL_0451: Expected O, but got I4
		//IL_04bd: Expected O, but got Ref
		//IL_0b31: Expected O, but got I4
		//IL_0613: Expected I, but got O
		//IL_06b9: Expected O, but got I4
		//IL_07eb: Expected I, but got O
		//IL_07fe: Expected O, but got I4
		//IL_080c: Expected O, but got I4
		//IL_05e9->IL09c6: Incompatible stack heights: 2 vs 0
		//IL_0658->IL09c6: Incompatible stack heights: 2 vs 0
		//IL_0636->IL0636: Incompatible stack heights: 3 vs 2
		//IL_0689->IL09c6: Incompatible stack heights: 2 vs 0
		//IL_0739->IL09c6: Incompatible stack heights: 2 vs 0
		//IL_0765->IL09c6: Incompatible stack heights: 2 vs 0
		//IL_07d9->IL09c6: Incompatible stack heights: 2 vs 0
		//IL_07b7->IL07b7: Incompatible stack heights: 3 vs 2
		//IL_0868->IL09c6: Incompatible stack heights: 2 vs 0
		//IL_093b->IL09c6: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_09ff;
		}
		nint num = (nint)typeof(TP_Savrog2Union_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v96 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v77 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v96 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v77 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v175+FFFFFFF8+v73 @ rax_v170*8]");
			if (0 == (nint)typeof(TP_Savrog2Union_Weapon))
			{
				obj3 = 1;
				goto IL_0a0e;
			}
		}
		obj3 = 0;
		goto IL_0a0e;
		IL_0a0e:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_09ff;
		IL_09ff:
		_trueWeapon = (TP_Savrog2Union_Weapon)trueWeapon;
		_isCullable = false;
		InitTrails();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body;
		if (body != null)
		{
			BaseBody baseBody2 = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
			BaseBody baseBody3 = body;
			if (body != null)
			{
				baseBody3._enable = true;
				if (_objectsHit != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					_isYeeted = false;
					object obj4 = UnityEngine.Random.value;
					if ((object)_spikeSprite != null)
					{
						object obj5 = default(object);
						bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5);
						float num4 = 0.5f - (float)obj5;
						bool flag3 = num4 == 0f;
						bool flag4 = !flag2;
						bool flag5 = !flag3;
						BlendMode blendMode = ((flag5 & flag4) ? BlendMode.Add : BlendMode.Normal);
						PhaserSprite phaserSprite = _spikeSprite.setBlendMode(blendMode);
						if ((object)_spikeSprite != null)
						{
							PhaserSprite phaserSprite2 = _spikeSprite.setVisible(visible: true);
							if ((object)_groundFx != null)
							{
								_groundFx.enabled = true;
								ArcadeSprite arcadeSprite2 = setVisible(visible: false);
								ArcadeSprite arcadeSprite3 = setAlpha(1f);
								if ((object)_spikeSprite != null)
								{
									PhaserSprite phaserSprite3 = _spikeSprite.setScale(0.45f, (float?)(object)1);
									object obj6 = UnityEngine.Random.value;
									if ((object)_spikeSprite != null)
									{
										float num5 = (float)obj5 * 0.5f;
										float alpha = num5 + 0.5f;
										PhaserSprite phaserSprite4 = _spikeSprite.setAlpha(alpha);
										SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_groundFx, 0.5f);
										if ((object)_spikeSprite != null)
										{
											PhaserSprite phaserSprite5 = _spikeSprite.setTint(16777215u);
											_unionTintCounter = 0;
											DoUnionTintTween();
											Weapon weapon2 = _weapon;
											if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
											{
												Vector2 scaledVelocity = ((Equipment)weapon2)._003COwner_003Ek__BackingField.ScaledVelocity;
												Vector2 vector = (Vector2)(this + 272);
												_previousVector = scaledVelocity;
												_ = 1048576000;
												((Vector2*)vector)->Normalize();
												Weapon weapon3 = _weapon;
												if ((object)_weapon != null)
												{
													if (!weapon3.IsHoming)
													{
														setVelocity(0f, (float?)(object)1);
													}
													else
													{
														_speed = 0.25f;
														Transform transform = base.AimForNearestEnemy(rotate: false);
													}
													float2 float5 = base.position;
													Transform transform2 = _spikeSprite.transform;
													bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													Vector3 value = default(Vector3);
													Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
													Transform transform3 = _spikeSprite.transform;
													object obj7 = default(object);
													transform3.localEulerAngles = (Vector3)(&obj7);
													Transform transform4 = _groundFx.transform;
													bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
													Vector3 value2 = default(Vector3);
													Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value2);
													SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_groundFx, _tint);
													SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_groundFx, 0f);
													ArcadeSprite arcadeSprite4 = setScale(0f, (float?)(object)0);
													Material material = ((Renderer)_Trail).GetMaterial();
													RenderingExtensions.SetAlpha(material, 1f);
													Material material2 = ((Renderer)_Trail2).GetMaterial();
													RenderingExtensions.SetAlpha(material2, 1f);
													PhaserSprite spikeSprite = _spikeSprite;
													SpriteAnimation spriteAnimation = spikeSprite._spriteAnimation;
													((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
													PhaserSprite spikeSprite2 = _spikeSprite;
													spikeSprite2._spriteAnimation.SetAnimation("idle");
													if (_tween1 != null)
													{
														_tween1.Kill();
													}
													TweenConfig tweenConfig = new TweenConfig();
													object[] array = new object[1];
													Transform transform5 = base.transform;
													if (array != null)
													{
														if ((object)transform5 != null)
														{
															nint num6 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj8 = default(object);
															bool flag8 = obj8 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig != null)
														{
															tweenConfig.targets = array;
															if ((object)_weapon != null)
															{
																float num7 = _weapon.PArea();
																tweenConfig.duration = 300f;
																tweenConfig.scale = (float?)(object)1;
																TweenCallback onStart = delegate
																{
																	//IL_0010: Expected O, but got I4
																	ArcadeSprite arcadeSprite5 = setScale(0f, (float?)(object)0);
																};
																tweenConfig.onStart = onStart;
																MultiTargetTween tween = Tweens.Add(tweenConfig);
																_tween1 = tween;
																TweenConfig tweenConfig2 = new TweenConfig();
																object[] array2 = new object[1];
																if ((object)_groundFx != null)
																{
																	Transform transform6 = _groundFx.transform;
																	if (array2 != null)
																	{
																		if ((object)transform6 != null)
																		{
																			void* value3 = ((IntPtr*)(&array2))->m_value;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																			object obj9 = default(object);
																			bool flag9 = obj9 == null;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		if (tweenConfig2 != null)
																		{
																			((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
																			((Weapon)(object)tweenConfig2)._gameSessionData = (GameSessionData)1;
																			((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1133903872;
																			_ = 1;
																			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
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
																				float num8 = hitBoxDelay * 0.001f;
																				bool useRealTime = default(bool);
																				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																				int repeat = default(int);
																				TimerType type = default(TimerType);
																				VampireSurvivors.Framework.TimerSystem.Timer hitboxTimer = Timers.Register(num8, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																				_hitboxTimer = hitboxTimer;
																				_durataMillis = 0f;
																				if (_expireTimer != null)
																				{
																					_expireTimer.Cancel();
																				}
																				if ((object)_weapon != null)
																				{
																					float num9 = _weapon.PDuration();
																					Action onComplete2 = FadeOut;
																					float num10 = num8 * 0.65f;
																					float duration = num10 * 0.001f;
																					VampireSurvivors.Framework.TimerSystem.Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																					_expireTimer = expireTimer;
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

	public unsafe void SetInversion(bool isInverted = false)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0084: Expected O, but got F4
		_isInverted = isInverted;
		float num = ((!isInverted) ? 1f : (-1f));
		Weapon weapon = _weapon;
		Vector2 scaledVelocity = ((Equipment)weapon)._003COwner_003Ek__BackingField.ScaledVelocity;
		float num2 = (float)scaledVelocity * num;
		object obj = default(object);
		float num3 = (float)obj * num;
		Vector2 vector = (Vector2)(this + 272);
		_previousVector = (Vector2)num2;
		((Vector2*)vector)->Normalize();
	}

	private void InitTrails()
	{
		//IL_0019: Expected I4, but got I8
		//IL_0047: Expected O, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected I4, but got Unknown
		//IL_0412->IL0360: Incompatible stack heights: 1 vs 0
		//IL_015b->IL0360: Incompatible stack heights: 1 vs 0
		//IL_0199->IL0360: Incompatible stack heights: 1 vs 0
		//IL_01e1->IL0360: Incompatible stack heights: 1 vs 0
		//IL_0463->IL0360: Incompatible stack heights: 2 vs 0
		//IL_0227->IL0360: Incompatible stack heights: 2 vs 0
		//IL_0250->IL0360: Incompatible stack heights: 2 vs 0
		//IL_02ab->IL0360: Incompatible stack heights: 2 vs 0
		//IL_02e9->IL0360: Incompatible stack heights: 2 vs 0
		//IL_0327->IL0360: Incompatible stack heights: 2 vs 0
		uint[] array = new uint[4] { 16711680u, 16776960u, 255u, 16711935u };
		if (array != null)
		{
			int num = (int)(_indexInWeapon & 0x80000003L);
			if ((nint)array < 0)
			{
				object obj = num - 1;
				object obj2 = obj | -4;
				num = obj2 + 1;
			}
			if (num >= array.Length)
			{
				throw new IndexOutOfRangeException();
			}
			_tint = array[num];
			if ((object)_weapon != null)
			{
				float num2 = _weapon.PArea();
				Array trail = (Array)(object)_Trail;
				object obj3 = default(object);
				float num3 = (float)obj3 * 4f;
				float num4 = num3 * 0.01f;
				if ((object)_Trail != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v8 (System.Array)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v8 (System.Array)+10]");
					TrailRenderer.Clear_Injected((IntPtr)0);
					if ((object)_Trail != null)
					{
						_Trail.enabled = false;
						TrailRenderer trailRenderer = RenderingExtensions.SetTint(_Trail, _tint);
						TrailRenderer trailRenderer2 = RenderingExtensions.SetAlpha(_Trail, 1f);
						if ((object)_Trail != null)
						{
							float startWidth = num4 * 1.3f;
							_Trail.startWidth = startWidth;
							if ((object)_Trail != null)
							{
								float endWidth = num4 * 0.35f;
								_Trail.endWidth = endWidth;
								Array trail2 = (Array)(object)_Trail2;
								if ((object)_Trail2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdi_v10 (System.Array)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdi_v10 (System.Array)+10]");
									TrailRenderer.Clear_Injected((IntPtr)0);
									if ((object)_Trail2 != null)
									{
										_Trail2.enabled = false;
										List<Material> list = new List<Material>();
										if (list != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A80120");
											if ((object)_Trail2 != null)
											{
												_Trail2.SetMaterials(list);
												TrailRenderer trailRenderer3 = RenderingExtensions.SetTint(_Trail2, 0u);
												TrailRenderer trailRenderer4 = RenderingExtensions.SetAlpha(_Trail2, 0.25f);
												if ((object)_Trail2 != null)
												{
													float startWidth2 = num4 * 0.5f;
													_Trail2.startWidth = startWidth2;
													if ((object)_Trail2 != null)
													{
														float endWidth2 = num4 * 0.175f;
														_Trail2.endWidth = endWidth2;
														if ((object)_Trail2 != null)
														{
															_Trail2.enabled = false;
															TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
															TrailRendererPauseController trailRendererPauseController2 = RenderingExtensions.AddPauseController(_Trail2);
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

	private void DoUnionTintTween()
	{
		//IL_009f: Expected I, but got O
		//IL_0110: Expected O, but got I4
		float num = 1.8125f / (float)new uint[4] { 16729156u, 16777028u, 16777215u, 16729343u }.Length;
		float duration = num * 1000f;
		if (_unionTintTween != null)
		{
			_unionTintTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_spikeSprite != null)
		{
			nint num2 = (nint)array;
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
		tweenConfig.duration = duration;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.tint = (uint?)(object)1;
		TweenCallback onComplete = delegate
		{
			int unionTintCounter = _unionTintCounter + 1;
			_unionTintCounter = unionTintCounter;
			DoUnionTintTween();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween unionTintTween = Tweens.Add(tweenConfig);
		_unionTintTween = unionTintTween;
	}

	public override void InternalUpdate()
	{
		//IL_0127: Expected O, but got I4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected I4, but got Unknown
		//IL_018d: Expected O, but got I4
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected I4, but got Unknown
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = -renderer.pixelHeight;
		_renderer.sortingOrder = num;
		int sortingOrder = num + 1;
		_groundFx.sortingOrder = sortingOrder;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num2 = num - 2;
		PhaserSprite phaserSprite = _spikeSprite.setDepth(num2);
		if (!_isYeeted)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num3 = deltaTime * 1000f;
			float durataMillis = num3 + _durataMillis;
			_durataMillis = durataMillis;
			return;
		}
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		int num4 = renderer2.pixelHeight >> 31;
		object obj = renderer2.pixelHeight - num4;
		object obj2 = obj >> 1;
		int sortingOrder2 = num + obj2;
		_Trail.sortingOrder = sortingOrder2;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		int num5 = renderer3.pixelHeight >> 31;
		object obj3 = renderer3.pixelHeight - num5;
		object obj4 = obj3 >> 1;
		int sortingOrder3 = num + obj4;
		_Trail2.sortingOrder = sortingOrder3;
	}

	public override void Despawn()
	{
		//IL_00c6: Expected O, but got I4
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		if (_unionTintTween != null)
		{
			_unionTintTween.Kill();
		}
		PhaserSprite phaserSprite = _spikeSprite.setVisible(visible: false);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		_groundFx.enabled = false;
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		PhaserSprite spikeSprite = _spikeSprite;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(spikeSprite._spriteRenderer, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_renderer, 0f);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_groundFx, 0f);
		Material material = ((Renderer)_Trail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 0f);
		Material material2 = ((Renderer)_Trail2).GetMaterial();
		RenderingExtensions.SetAlpha(material2, 0f);
		base.Despawn();
	}

	private void FadeOut()
	{
		//IL_0027: Expected I, but got O
		//IL_007f: Expected I, but got O
		//IL_00e9: Expected I, but got O
		//IL_0153: Expected I, but got O
		//IL_01a9: Expected O, but got I4
		//IL_01e9: Expected O, but got I4
		//IL_027e: Expected I, but got O
		//IL_02d4: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[4];
		if ((object)this != null)
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
		Material material = ((Renderer)_Trail).GetMaterial();
		if ((object)material != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Material material2 = ((Renderer)_Trail2).GetMaterial();
		if ((object)material2 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.alpha = (float?)(object)1;
		float num5 = _weapon.PArea();
		object obj5 = default(object);
		float num6 = (float)obj5 * 3f;
		tweenConfig.duration = 400f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		PhaserSprite spikeSprite = _spikeSprite;
		if ((object)spikeSprite._spriteRenderer != null)
		{
			nint num7 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 400f;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
	}

	public unsafe void Yeet()
	{
		//IL_0068: Expected O, but got I
		//IL_0080: Expected O, but got Ref
		//IL_00d5: Expected O, but got Ref
		//IL_03a5: Expected O, but got I4
		//IL_017b: Expected O, but got Ref
		//IL_022a: Expected I, but got O
		//IL_028a: Expected O, but got I4
		//IL_02b5: Expected O, but got I4
		if (_isYeeted)
		{
			return;
		}
		Weapon weapon = _weapon;
		_isYeeted = true;
		object obj4 = default(object);
		if (!weapon.IsHoming)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			IntPtr intPtr = default(IntPtr);
			Vector3 vector = (Vector3)(nint)intPtr;
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = obj4;
			object obj5 = default(object);
			ArcadeSprite arcadeSprite = (ArcadeSprite)(&obj5);
		}
		else
		{
			GameManager core = GM.Core;
			Weapon weapon2 = _weapon;
			float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
			object obj6 = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj6), excludeDead: true);
			ArcadeSprite arcadeSprite2;
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				arcadeSprite2 = enemyController;
			}
			else
			{
				Weapon weapon3 = _weapon;
				arcadeSprite2 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
			}
			float2 float6 = arcadeSprite2.position;
			float2 float7 = base.position;
			object obj7 = default(object);
			object obj3 = obj4 - obj7;
			object obj = float6 - float7;
			Vector3 vector = (Vector3)(&obj6);
			ArcadeSprite arcadeSprite = this;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		setVelocity(0f, (float?)(object)0);
		_Trail.Clear();
		_Trail.enabled = true;
		_Trail2.Clear();
		_Trail2.enabled = true;
		float2 float8 = base.position;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		tweenConfig.x = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		tweenConfig.duration = 150f;
		tweenConfig.y = (float?)(object)1;
		float delay = (float)_indexInWeapon * 50f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.delay = delay;
		TweenCallback onStart = delegate
		{
			//IL_0026: Expected O, but got Ref
			Transform transform2 = _spikeSprite.transform;
			object obj9 = default(object);
			transform2.localEulerAngles = (Vector3)(&obj9);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			FadeOut();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void _003CInitProjectile_003Eb__21_1()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}

	private void _003CInitProjectile_003Eb__21_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CDoUnionTintTween_003Eb__24_0()
	{
		int unionTintCounter = _unionTintCounter + 1;
		_unionTintCounter = unionTintCounter;
		DoUnionTintTween();
	}

	private void _003CFadeOut_003Eb__27_0()
	{
		Despawn();
	}

	private unsafe void _003CYeet_003Eb__28_0()
	{
		//IL_0026: Expected O, but got Ref
		Transform transform = _spikeSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CYeet_003Eb__28_1()
	{
		FadeOut();
	}
}
