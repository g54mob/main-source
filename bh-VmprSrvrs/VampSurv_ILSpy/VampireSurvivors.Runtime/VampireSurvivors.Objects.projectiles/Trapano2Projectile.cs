using System;
using System.Collections.Generic;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Trapano2Projectile : Projectile
{
	private TrailRenderer _Trail;

	private TrailRenderer _Trail2;

	private Material _Trail2MaterialLight;

	private Material _Trail2MaterialDark;

	[NonSerialized]
	public bool _isYeeted;

	[NonSerialized]
	public float _durataMillis;

	private Vector2 _aimVec;

	private MultiTargetTween _tween1;

	private SpriteRenderer _groundFx;

	private PhaserSprite _spikeSprite;

	private Vector2 _previousVector;

	private VampireSurvivors.Framework.TimerSystem.Timer _hitboxTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _expireTimer;

	private Trapano2Weapon _trueWeapon;

	private uint _tint;

	private float _timeStopped;

	private bool _tpDlcLoaded;

	private TP_Savrog_Weapon _unionWeapon;

	private MultiTargetTween _unionTintTween;

	private int _unionTintCounter;

	private const int RADIUS = 8;

	protected override void Awake()
	{
		//IL_00e8: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_01a8: Expected O, but got I4
		//IL_015c->IL02c7: Incompatible stack heights: 1 vs 0
		//IL_0190->IL02c7: Incompatible stack heights: 1 vs 0
		//IL_0210->IL02c7: Incompatible stack heights: 1 vs 0
		//IL_0232->IL02c7: Incompatible stack heights: 1 vs 0
		//IL_0289->IL02c7: Incompatible stack heights: 1 vs 0
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
				_aimVec = (Vector2)0;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					GameObject gameObject2 = base.gameObject;
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "flame000");
					if ((object)phaserSprite != null)
					{
						PhaserSprite phaserSprite2 = phaserSprite.setScale(1f, (float?)(object)0);
						if ((object)phaserSprite2 != null)
						{
							PhaserSprite spikeSprite = phaserSprite2.setOrigin(0.5f, (float?)(object)0);
							_spikeSprite = spikeSprite;
							int num = default(int);
							List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("flame", 0, 28, "vfx", num);
							PhaserSprite spikeSprite2 = _spikeSprite;
							_durataMillis = 0f;
							if ((object)_spikeSprite != null && (object)spikeSprite2._spriteAnimation != null)
							{
								bool startRandomFrame = default(bool);
								Action onComplete = default(Action);
								bool autoSetAnimation = default(bool);
								spikeSprite2._spriteAnimation.AddAnimation("idle", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
								Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
								if (loadedDlc != null)
								{
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
		//IL_0a13: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_0139: Expected O, but got I4
		//IL_0139: Expected O, but got I4
		//IL_02d2: Expected O, but got I4
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_03ba: Expected O, but got I4
		//IL_0471: Expected O, but got Ref
		//IL_0b33: Expected O, but got I4
		//IL_0610: Expected I, but got O
		//IL_06b6: Expected O, but got I4
		//IL_07e8: Expected I, but got O
		//IL_07fb: Expected O, but got I4
		//IL_0809: Expected O, but got I4
		//IL_05e6->IL09b3: Incompatible stack heights: 13 vs 0
		//IL_0655->IL09b3: Incompatible stack heights: 13 vs 0
		//IL_0633->IL0633: Incompatible stack heights: 14 vs 13
		//IL_0686->IL09b3: Incompatible stack heights: 13 vs 0
		//IL_0736->IL09b3: Incompatible stack heights: 13 vs 0
		//IL_0762->IL09b3: Incompatible stack heights: 13 vs 0
		//IL_07d6->IL09b3: Incompatible stack heights: 13 vs 0
		//IL_07b4->IL07b4: Incompatible stack heights: 14 vs 13
		//IL_0865->IL09b3: Incompatible stack heights: 13 vs 0
		//IL_0938->IL09b3: Incompatible stack heights: 13 vs 0
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_09ec;
		}
		nint num = (nint)typeof(Trapano2Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v92 (Il2CppClass<VampireSurvivors.Objects.Weapons.Trapano2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v73 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v92 (Il2CppClass<VampireSurvivors.Objects.Weapons.Trapano2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v73 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v166+FFFFFFF8+v73 @ rax_v161*8]");
			if (0 == (nint)typeof(Trapano2Weapon))
			{
				obj3 = 1;
				goto IL_09fb;
			}
		}
		obj3 = 0;
		goto IL_09fb;
		IL_09fb:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_09ec;
		IL_09ec:
		_trueWeapon = (Trapano2Weapon)trueWeapon;
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
					if ((object)_spikeSprite != null)
					{
						PhaserSprite phaserSprite = _spikeSprite.setVisible(visible: true);
						if ((object)_groundFx != null)
						{
							_groundFx.enabled = true;
							ArcadeSprite arcadeSprite2 = setVisible(visible: false);
							ArcadeSprite arcadeSprite3 = setAlpha(1f);
							if ((object)_spikeSprite != null)
							{
								PhaserSprite phaserSprite2 = _spikeSprite.setAlpha(1f);
								SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_groundFx, 0.5f);
								if ((object)_spikeSprite != null)
								{
									PhaserSprite phaserSprite3 = _spikeSprite.setTint(16777215u);
									_unionTintCounter = 0;
									DoUnionTintTween();
									_aimVec = (Vector2)0;
									Weapon weapon2 = _weapon;
									if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
									{
										Vector2 scaledVelocity = ((Equipment)weapon2)._003COwner_003Ek__BackingField.ScaledVelocity;
										Vector2 vector = (Vector2)(this + 280);
										_previousVector = scaledVelocity;
										_ = 3242196992L;
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
											Weapon cachedTransform = (Weapon)(object)_cachedTransform;
											if ((object)_cachedTransform != null)
											{
												bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
												bool flag3 = (object)_spikeSprite == null;
												Transform transform2 = _spikeSprite.transform;
												bool flag4 = (object)transform2 == null;
												bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
												Vector3 value = default(Vector3);
												Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
												bool flag6 = (object)_spikeSprite == null;
												Transform transform3 = _spikeSprite.transform;
												bool flag7 = (object)transform3 == null;
												transform3.localEulerAngles = (Vector3)(&ret);
												bool flag8 = (object)_groundFx == null;
												Transform transform4 = _groundFx.transform;
												bool flag9 = (object)transform4 == null;
												bool flag10 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
												Vector3 value2 = default(Vector3);
												Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value2);
												SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_groundFx, _tint);
												SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_groundFx, 0f);
												ArcadeSprite arcadeSprite4 = setScale(0f, (float?)(object)0);
												PhaserSprite spikeSprite = _spikeSprite;
												bool flag11 = (object)_spikeSprite == null;
												SpriteAnimation spriteAnimation = spikeSprite._spriteAnimation;
												bool flag12 = (object)spikeSprite._spriteAnimation == null;
												((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
												PhaserSprite spikeSprite2 = _spikeSprite;
												bool flag13 = (object)_spikeSprite == null;
												bool flag14 = (object)spikeSprite2._spriteAnimation == null;
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
														nint num4 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj4 = default(object);
														bool flag15 = obj4 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig != null)
													{
														tweenConfig.targets = array;
														if ((object)_weapon != null)
														{
															float num5 = _weapon.PArea();
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
																		object obj5 = default(object);
																		bool flag16 = obj5 == null;
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
																			float num6 = hitBoxDelay * 0.001f;
																			bool useRealTime = default(bool);
																			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																			int repeat = default(int);
																			TimerType type = default(TimerType);
																			VampireSurvivors.Framework.TimerSystem.Timer hitboxTimer = Timers.Register(num6, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																			_hitboxTimer = hitboxTimer;
																			_durataMillis = 0f;
																			if (_expireTimer != null)
																			{
																				_expireTimer.Cancel();
																			}
																			if ((object)_weapon != null)
																			{
																				float num7 = _weapon.PDuration();
																				Action onComplete2 = FadeOut;
																				float duration = num6 * 0.001f;
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
		throw new NullReferenceException();
	}

	private void InitTrails()
	{
		//IL_0019: Expected I4, but got I8
		//IL_0047: Expected O, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected I4, but got Unknown
		//IL_03c3->IL0311: Incompatible stack heights: 1 vs 0
		//IL_015b->IL0311: Incompatible stack heights: 1 vs 0
		//IL_0189->IL0311: Incompatible stack heights: 1 vs 0
		//IL_01c1->IL0311: Incompatible stack heights: 1 vs 0
		//IL_0414->IL0311: Incompatible stack heights: 2 vs 0
		//IL_0207->IL0311: Incompatible stack heights: 2 vs 0
		//IL_0230->IL0311: Incompatible stack heights: 2 vs 0
		//IL_028b->IL0311: Incompatible stack heights: 2 vs 0
		//IL_02c9->IL0311: Incompatible stack heights: 2 vs 0
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdi_v8 (System.Array)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdi_v8 (System.Array)+10]");
					TrailRenderer.Clear_Injected((IntPtr)0);
					if ((object)_Trail != null)
					{
						_Trail.enabled = false;
						TrailRenderer trailRenderer = RenderingExtensions.SetTint(_Trail, _tint);
						TrailRenderer trailRenderer2 = RenderingExtensions.SetAlpha(_Trail, 1f);
						if ((object)_Trail != null)
						{
							_Trail.startWidth = num4;
							if ((object)_Trail != null)
							{
								_Trail.endWidth = num4;
								Array trail2 = (Array)(object)_Trail2;
								if ((object)_Trail2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v10 (System.Array)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v10 (System.Array)+10]");
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
												TrailRenderer trailRenderer3 = RenderingExtensions.SetTint(_Trail2, 16777215u);
												TrailRenderer trailRenderer4 = RenderingExtensions.SetAlpha(_Trail2, 0.25f);
												if ((object)_Trail2 != null)
												{
													float startWidth = num4 * 0.5f;
													_Trail2.startWidth = startWidth;
													if ((object)_Trail2 != null)
													{
														float endWidth = num4 * 0.5f;
														_Trail2.endWidth = endWidth;
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
		throw new NullReferenceException();
	}

	private void UpdateUnionTrails()
	{
		//IL_005d: Expected O, but got I4
		//IL_0088: Invalid comparison between I4 and F4
		//IL_01bf: Invalid comparison between I4 and F4
		//IL_01ef: Invalid comparison between I4 and F4
		//IL_021f: Invalid comparison between I4 and F4
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected I4, but got Unknown
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected I4, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected I4, but got Unknown
		Trapano2Weapon trueWeapon = _trueWeapon;
		if (trueWeapon._003CIsUnion_003Ek__BackingField)
		{
			Color[] unionTrailColours = trueWeapon._UnionTrailColours;
			int num = _unionTintCounter % unionTrailColours.Length;
			object obj = num + 2;
			object obj2 = obj + obj;
			object obj3 = default(object);
			float num2 = (float)obj3 * 255f;
			if (0f > num2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rdi,xmm0\"");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v5 (UnityEngine.Color[])+v281 @ rax_v13*8]");
			float num3 = 0f * 255f;
			if (0f > num3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rdx,xmm0\"");
			}
			float num4 = (float)obj3 * 255f;
			if (0f > num4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rcx,xmm0\"");
			}
			float num5 = (float)obj3 * 255f;
			if (0f > num5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm6\"");
			}
			object obj5 = default(object);
			object obj4 = obj5 << 8;
			int num6 = obj4 | num;
			int num7 = num6 << 8;
			int num8 = num7 | typeof(ColorUtils);
			int num9 = num8 << 8;
			TrailRenderer trailRenderer = RenderingExtensions.SetTint(tint: _tint = (uint)(num9 | obj2), trail: _Trail);
			List<Material> materials = new List<Material>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A80120");
			_Trail2.SetMaterials(materials);
			TrailRenderer trailRenderer2 = RenderingExtensions.SetTint(_Trail2, 0u);
			TrailRenderer trailRenderer3 = RenderingExtensions.SetAlpha(_Trail2, 1f);
		}
	}

	private void DoUnionTintTween()
	{
		//IL_005d: Expected O, but got I4
		//IL_0088: Invalid comparison between I4 and F4
		//IL_02ae: Invalid comparison between I4 and F4
		//IL_02de: Invalid comparison between I4 and F4
		//IL_030e: Invalid comparison between I4 and F4
		//IL_01c3: Expected I, but got O
		//IL_0234: Expected O, but got I4
		Trapano2Weapon trueWeapon = _trueWeapon;
		if (!trueWeapon._003CIsUnion_003Ek__BackingField)
		{
			return;
		}
		Color[] unionSpriteColours = trueWeapon._UnionSpriteColours;
		int num = _unionTintCounter % unionSpriteColours.Length;
		object obj = num + 2;
		object obj2 = obj + obj;
		object obj3 = default(object);
		float num2 = (float)obj3 * 255f;
		if (0f > num2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rbx,xmm0\"");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v7 (UnityEngine.Color[])+v373 @ rax_v15*8]");
		float num3 = 0f * 255f;
		if (0f > num3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rdx,xmm0\"");
		}
		float num4 = (float)obj3 * 255f;
		if (0f > num4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rcx,xmm0\"");
		}
		float num5 = (float)obj3 * 255f;
		if (0f > num5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm6\"");
		}
		Trapano2Weapon trueWeapon2 = _trueWeapon;
		Color[] unionSpriteColours2 = trueWeapon2._UnionSpriteColours;
		float num6 = 1.8125f / (float)unionSpriteColours2.Length;
		float duration = num6 * 1000f;
		if (_unionTintTween != null)
		{
			_unionTintTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_spikeSprite != null)
		{
			nint num7 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
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
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected I4, but got Unknown
		//IL_0476: Expected O, but got I4
		//IL_0491: Expected I4, but got O
		//IL_04dc: Expected O, but got I4
		//IL_04f7: Expected I4, but got O
		//IL_02e3: Invalid comparison between I4 and F4
		//IL_032e: Expected F4, but got I4
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Expected O, but got Unknown
		//IL_0585: Expected O, but got F4
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_03d8: Expected O, but got F4
		//IL_042b: Expected O, but got F4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int sortingOrder = -renderer.pixelHeight;
		_renderer.sortingOrder = sortingOrder;
		_groundFx.sortingOrder = sortingOrder;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		object obj = default(object);
		int num = obj - 1;
		PhaserSprite phaserSprite = _spikeSprite.setDepth(num);
		if (!_isYeeted)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num2 = deltaTime * 1000f;
			Weapon weapon = _weapon;
			float durataMillis = num2 + _durataMillis;
			_durataMillis = durataMillis;
			Vector2 scaledVelocity = ((Equipment)weapon)._003COwner_003Ek__BackingField.ScaledVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001872F6E08h\"");
			object obj2 = default(object);
			if ((object)scaledVelocity == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001872F6E08h\"");
				if (obj2 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872F6D86h\"");
					if ((object)_previousVector == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Trapano2Projectile)+11C]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872F6D86h\"");
						if (flag)
						{
							return;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
					object obj3 = default(object);
					if (!((_timeStopped = (float)obj3 + _timeStopped) < 0.08f))
					{
						_timeStopped = 0f;
						Yeet();
						_isYeeted = true;
					}
					return;
				}
			}
			if (_isYeeted)
			{
				return;
			}
			Weapon weapon2 = _weapon;
			if (weapon2.IsHoming)
			{
				return;
			}
			_timeStopped = 0f;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			Weapon weapon3 = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			object obj4 = characterController._currentDirectionRaw * characterController._currentDirectionRaw;
			float num3 = (float)obj4 * 0.5f;
			if (!(0f > num3))
			{
				if (num3 > 1f)
				{
					num3 = 1f;
				}
			}
			else
			{
				num3 = 0f;
			}
			object obj5 = scaledVelocity - _previousVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Trapano2Projectile)+11C]");
			object obj6 = obj2 - 0;
			float num4 = (float)obj5 * num3;
			float num5 = (float)obj6 * num3;
			float num6 = num4 + (float)_previousVector;
			float num7 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Trapano2Projectile)+11C]");
			float num8 = num7 + 0f;
			_previousVector = (Vector2)num6;
			float num9 = _weapon.PSpeed();
			if (num8 > 1f)
			{
				object obj7 = scaledVelocity - _aimVec;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Trapano2Projectile)+FC]");
				object obj8 = obj2 - 0;
				float num10 = (float)obj7 * 0.002f;
				float num11 = (float)obj8 * 0.002f;
				float num12 = (float)_aimVec - num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Trapano2Projectile)+FC]");
				float num13 = 0f - num11;
				_aimVec = (Vector2)num12;
				float num14 = _weapon.PSpeed();
				float num15 = num12 * num8;
				float num16 = num13 * num8;
				BaseBody baseBody = body;
				baseBody._velocity = (float2)num15;
			}
		}
		else
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			int num17 = renderer2.pixelHeight >> 31;
			object obj9 = renderer2.pixelHeight - num17;
			object obj10 = obj9 >> 1;
			int sortingOrder2 = (int)(obj + obj10);
			_Trail.sortingOrder = sortingOrder2;
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			int num18 = renderer3.pixelHeight >> 31;
			object obj11 = renderer3.pixelHeight - num18;
			object obj12 = obj11 >> 1;
			int sortingOrder3 = (int)(obj + obj12);
			_Trail2.sortingOrder = sortingOrder3;
		}
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
		base.Despawn();
	}

	private void FadeOut()
	{
		//IL_003e: Expected I, but got O
		//IL_0096: Expected I, but got O
		//IL_00ee: Expected I, but got O
		//IL_0158: Expected I, but got O
		//IL_01c2: Expected I, but got O
		//IL_0226: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[5];
		PhaserSprite spikeSprite = _spikeSprite;
		if ((object)spikeSprite._spriteRenderer != null)
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
		if ((object)_groundFx != null)
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
		Material material = ((Renderer)_Trail).GetMaterial();
		if ((object)material != null)
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
		Material material2 = ((Renderer)_Trail2).GetMaterial();
		if ((object)material2 != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private unsafe void Yeet()
	{
		//IL_0044: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_0486: Expected O, but got I4
		//IL_00f9: Expected O, but got Ref
		//IL_01d6: Expected O, but got Ref
		//IL_02e9: Expected I, but got O
		//IL_035d: Expected O, but got I4
		//IL_0388: Expected O, but got I4
		//IL_0555->IL048b: Incompatible stack heights: 1 vs 0
		//IL_02bf->IL048b: Incompatible stack heights: 1 vs 0
		//IL_032e->IL048b: Incompatible stack heights: 1 vs 0
		//IL_030c->IL030c: Incompatible stack heights: 2 vs 1
		Weapon weapon = _weapon;
		object obj;
		object obj2 = default(object);
		ArcadeSprite arcadeSprite2;
		Vector2 previousVector;
		Vector3 vector;
		ArcadeSprite arcadeSprite;
		if ((object)_weapon != null)
		{
			if (!weapon.IsHoming)
			{
				previousVector = _previousVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v1 (VampireSurvivors.Objects.Projectiles.Trapano2Projectile)+11C]");
				obj = 0;
				IntPtr intPtr = default(IntPtr);
				vector = (Vector3)(nint)intPtr;
				arcadeSprite = this;
				goto IL_0452;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				Weapon weapon2 = _weapon;
				if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
					if ((object)core._stage != null)
					{
						EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj2), excludeDead: true);
						if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
						{
							arcadeSprite2 = enemyController;
							goto IL_0198;
						}
						Weapon weapon3 = _weapon;
						if ((object)_weapon != null)
						{
							arcadeSprite2 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
							{
								goto IL_0198;
							}
						}
					}
				}
			}
		}
		goto IL_048b;
		IL_048b:
		throw new NullReferenceException();
		IL_0452:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float num = (float)obj * 57.29578f;
		base.angle = num;
		setVelocity(0f, (float?)(object)0);
		object trail = _Trail;
		if ((object)_Trail != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v7 (System.Object)+10]");
			if ((nint)0 == 0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_Trail);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v7 (System.Object)+10]");
				TrailRenderer.Clear_Injected((IntPtr)0);
				if ((object)_Trail != null)
				{
					_Trail.enabled = true;
					object trail2 = _Trail2;
					if ((object)_Trail2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rsi_v8 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rsi_v8 (System.Object)+10]");
						TrailRenderer.Clear_Injected((IntPtr)0);
						if ((object)_Trail2 != null)
						{
							_Trail2.enabled = true;
							UpdateUnionTrails();
							float2 float6 = base.position;
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							Transform transform = base.transform;
							if (array != null)
							{
								if ((object)transform != null)
								{
									nint num2 = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj3 = default(object);
									bool flag2 = obj3 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
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
										//IL_0062: Expected O, but got I4
										Transform transform2 = _spikeSprite.transform;
										object obj6 = default(object);
										transform2.localEulerAngles = (Vector3)(&obj6);
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
										soundConfig.Rate = 1f;
										float detune = (float)_indexInWeapon * -100f;
										soundConfig.Volume = (float?)(object)1;
										soundConfig.Detune = detune;
										float time = default(float);
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 12, time);
									};
									tweenConfig.onStart = onStart;
									TweenCallback onComplete = delegate
									{
										FadeOut();
									};
									tweenConfig.onComplete = onComplete;
									MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_048b;
		IL_0198:
		float2 float7 = arcadeSprite2.position;
		float2 float8 = base.position;
		object obj4 = default(object);
		object obj5 = default(object);
		obj = obj4 - obj5;
		previousVector = float7 - float8;
		vector = (Vector3)(&obj2);
		arcadeSprite = this;
		goto IL_0452;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && (_isYeeted ? 1 : 0) != (nint)obj && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void _003CInitProjectile_003Eb__22_1()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}

	private void _003CInitProjectile_003Eb__22_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CDoUnionTintTween_003Eb__25_0()
	{
		int unionTintCounter = _unionTintCounter + 1;
		_unionTintCounter = unionTintCounter;
		DoUnionTintTween();
	}

	private void _003CFadeOut_003Eb__28_0()
	{
		Despawn();
	}

	private unsafe void _003CYeet_003Eb__29_0()
	{
		//IL_0026: Expected O, but got Ref
		//IL_0062: Expected O, but got I4
		Transform transform = _spikeSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 12, time);
	}

	private void _003CYeet_003Eb__29_1()
	{
		FadeOut();
	}
}
