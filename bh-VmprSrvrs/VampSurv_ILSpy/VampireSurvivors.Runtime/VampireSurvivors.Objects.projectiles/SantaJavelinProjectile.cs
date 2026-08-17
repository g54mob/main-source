using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class SantaJavelinProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public SantaJavelinProjectile _003C_003E4__this;

		public float despawnDelay;

		internal void _003CStartDespawn_003Eb__0()
		{
			//IL_0099: Expected I, but got O
			SantaJavelinProjectile santaJavelinProjectile = _003C_003E4__this;
			BaseBody body = santaJavelinProjectile.body;
			body._enable = false;
			SantaJavelinProjectile santaJavelinProjectile2 = _003C_003E4__this;
			if (santaJavelinProjectile2._expireTimer != null)
			{
				santaJavelinProjectile2._expireTimer.Cancel();
			}
			object obj = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v1 (Il2CppClass<System.Object>)+370]");
			Action onComplete = new Action(obj, (IntPtr)0);
			nint num = (nint)obj;
			float duration = despawnDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private SpriteRenderer _JavelinSprite;

	private SpriteRenderer _GroundFx;

	private SpriteTrail _Trail;

	protected SantaJavelinWeapon _trueWeapon;

	private Camera _camera;

	private Tween _positionTween;

	private Timer _expireTimer;

	private ParticleSystem _explosionPfx1;

	private ParticleSystem _explosionPfx2;

	private const float Radius = 32f;

	private const float ExploRadius = 8f;

	private bool _isBroken;

	private bool _isDespawning;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private MultiTargetTween _tween4;

	private float fullSalvoDuration;

	private MultiTargetTween _tween5;

	private MultiTargetTween _tween6;

	private float _javelinScale;

	private Vector3 _trailScale;

	protected virtual bool MirrorMotion => false;

	protected override void Awake()
	{
		//IL_0170->IL0119: Incompatible stack heights: 1 vs 0
		//IL_0095->IL0119: Incompatible stack heights: 1 vs 0
		//IL_00c8->IL0119: Incompatible stack heights: 1 vs 0
		//IL_00f4->IL0119: Incompatible stack heights: 1 vs 0
		//IL_01c5->IL0119: Incompatible stack heights: 2 vs 0
		base.Awake();
		GenerateParticleSystems();
		if ((object)_GroundFx != null)
		{
			Transform transform = _GroundFx.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
				if ((object)_GroundFx != null)
				{
					_GroundFx.enabled = false;
					if ((object)_Trail != null)
					{
						SpriteTrail spriteTrail = _Trail.setVisible(b: false);
						if ((object)_JavelinSprite != null)
						{
							Transform transform2 = _JavelinSprite.transform;
							if ((object)transform2 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)0, true);
								if ((object)_JavelinSprite != null)
								{
									_JavelinSprite.enabled = false;
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

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0030: Expected I, but got O
		//IL_0038: Expected I, but got O
		//IL_0048: Expected O, but got I
		//IL_00c8: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_039f: Expected O, but got I4
		//IL_0084: Expected O, but got I
		//IL_00ba: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0378;
		}
		nint num = (nint)typeof(SantaJavelinWeapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelinWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelinWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v62+FFFFFFF8+v70 @ rax_v57*8]");
			if (0 == (nint)typeof(SantaJavelinWeapon))
			{
				obj3 = 1;
				goto IL_0387;
			}
		}
		obj3 = 0;
		goto IL_0387;
		IL_0387:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0378;
		IL_0378:
		_trueWeapon = (SantaJavelinWeapon)trueWeapon;
		Camera camera = _camera;
		if ((object)_camera == null || ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_camera = main;
		}
		_speed = 2f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setOrigin(1f, (float?)(object)1);
		ArcadeSprite arcadeSprite3 = setVisible(visible: false);
		BaseBody baseBody2 = body;
		_isCullable = false;
		_isBroken = false;
		baseBody2._enable = false;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		_isDespawning = false;
		_renderer.enabled = true;
		_GroundFx.enabled = false;
		float num4 = weapon.PArea();
		object obj4 = default(object);
		float num5 = (float)obj4 / 10f;
		float javelinScale = num5 + 1f;
		_javelinScale = javelinScale;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_JavelinSprite, 0.5f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_JavelinSprite, _javelinScale);
		bool mirrorMotion = MirrorMotion;
		_JavelinSprite.flipY = mirrorMotion;
		bool mirrorMotion2 = MirrorMotion;
		bool flag2 = !mirrorMotion2;
		float num6 = 1f;
		if (!flag2)
		{
			num6 = -1f;
		}
		float yScale = _javelinScale * num6;
		SpriteTrail spriteTrail = RenderingExtensions.SetScale(_Trail, _javelinScale, yScale);
		SpriteTrail spriteTrail2 = _Trail.setVisible(b: false);
	}

	public override void SetNullTarget()
	{
		Despawn();
	}

	public unsafe void SetTargetVec(Vector3 target)
	{
		//IL_0008: Expected O, but got Ref
		//IL_010d: Expected O, but got I
		//IL_0dd2: Expected O, but got Ref
		//IL_0e74: Expected O, but got Ref
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_0265: Expected O, but got I8
		//IL_0eb1: Expected O, but got I4
		//IL_027c: Expected O, but got I4
		//IL_035b: Expected O, but got Ref
		//IL_0390: Expected O, but got I8
		//IL_04cb: Expected O, but got I4
		//IL_04df: Expected O, but got I4
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Expected O, but got Unknown
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Expected O, but got Unknown
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Expected O, but got Unknown
		//IL_118e: Expected O, but got I4
		//IL_119e: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a3: Expected O, but got Unknown
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Expected O, but got Unknown
		//IL_05e7: Expected O, but got Ref
		//IL_0604: Invalid comparison between O and F4
		//IL_0485: Expected O, but got I4
		//IL_0f84: Expected I, but got O
		//IL_0f69: Expected F4, but got I
		//IL_11fa: Expected O, but got Ref
		//IL_1208: Expected O, but got Ref
		//IL_1216: Expected F4, but got O
		//IL_102f: Expected O, but got Ref
		//IL_0679: Expected F4, but got I
		//IL_1089: Expected O, but got Ref
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Expected O, but got Unknown
		//IL_112c: Expected O, but got Ref
		//IL_0b6f: Expected O, but got I4
		//IL_0cb8: Expected O, but got Ref
		//IL_0ce0: Expected native int or pointer, but got O
		//IL_0cf3: Expected O, but got Ref
		//IL_093c: Expected I, but got O
		//IL_0a44: Expected I, but got O
		//IL_0ad5: Expected O, but got I
		//IL_0da1->IL0d22: Incompatible stack heights: 1 vs 0
		//IL_00b1->IL0d22: Incompatible stack heights: 1 vs 0
		//IL_016b->IL0d22: Incompatible stack heights: 1 vs 0
		//IL_019a->IL0d22: Incompatible stack heights: 1 vs 0
		//IL_117b->IL0d22: Incompatible stack heights: 8 vs 0
		//IL_02ab->IL0d22: Incompatible stack heights: 8 vs 0
		//IL_02d9->IL0d22: Incompatible stack heights: 8 vs 0
		//IL_0f4f->IL0d22: Incompatible stack heights: 8 vs 0
		//IL_075f->IL0d22: Incompatible stack heights: 16 vs 0
		//IL_088f->IL0d22: Incompatible stack heights: 20 vs 0
		//IL_08bb->IL0d22: Incompatible stack heights: 20 vs 0
		//IL_092a->IL0d22: Incompatible stack heights: 20 vs 0
		//IL_0908->IL0908: Incompatible stack heights: 21 vs 20
		//IL_0a18->IL0d22: Incompatible stack heights: 20 vs 0
		//IL_0a89->IL0d22: Incompatible stack heights: 20 vs 0
		//IL_0a67->IL0a67: Incompatible stack heights: 21 vs 20
		//IL_0b1e->IL0b1e: Incompatible stack heights: 20 vs 16
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Weapon weapon = _weapon;
		Vector3 ret;
		float num3;
		float2 float5 = default(float2);
		float num12;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;
		nint num15;
		object obj16;
		object obj17;
		nint num16;
		object obj18;
		object obj19;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				if ((object)_weapon != null)
				{
					float num = _weapon.PArea();
					float num2 = (float)ret * 64f;
					num3 = num2 * 0.01f;
					if ((object)_weapon != null)
					{
						float num4 = _weapon.PAmount();
						_ = 0;
						float num5 = (float)ret + 1f;
						_ = 0;
						_ = 1;
						float num6 = num3 / num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
						setVelocity(0f, (float?)(object)0);
						_ = target.x;
						Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ rax_v79 (UnityEngine.Bounds)+10]");
						_ = 0;
						_ = bounds.m_Center;
						base.position = float5;
						if ((object)_JavelinSprite != null)
						{
							_JavelinSprite.enabled = true;
							if ((object)_JavelinSprite != null)
							{
								Transform transform2 = _JavelinSprite.transform;
								float2 float6 = base.position;
								bool flag2 = (object)transform2 == null;
								_ = 0;
								bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
								Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj3);
								bool flag4 = (object)_Trail == null;
								Transform transform3 = _Trail.transform;
								bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
								bool flag6 = (object)transform3 == null;
								_ = 0;
								bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
								Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj4);
								bool flag8 = (object)_Trail == null;
								_Trail.Reset();
								bool mirrorMotion = MirrorMotion;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
								object obj5 = num3 ^ 0;
								float num7 = (float)obj5 * 0.5f;
								object obj6 = 4294967295L;
								if (!mirrorMotion)
								{
									obj6 = 1;
								}
								object obj7 = _indexInWeapon + 1;
								float num8 = (float)obj6 * num6;
								float num9 = num8 * (float)obj7;
								float num10 = num7 * (float)obj6;
								float num11 = num10 + target.x;
								num12 = num9 + num11;
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									PhaserScene.Renderer renderer = s_scene._renderer;
									if (s_scene._renderer != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
										if ((object)_renderer != null)
										{
											int sortingOrder = default(int);
											_renderer.sortingOrder = sortingOrder;
											Tween positionTween = _positionTween;
											if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
											{
												DG.Tweening.TweenExtensions.Kill(_positionTween);
											}
											Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
											_ = 0;
											tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, endValue, 0.25f);
											object obj8 = 6603577472L;
											TweenCallback tweenCallback2;
											if (tweenerCore != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2147 @ rax_v111 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
													bool flag9 = (nint)0 == 0;
													_ = 0;
													if (!flag9)
													{
														object obj9 = tweenerCore + 184;
														object obj10 = obj9 >> 12;
														object obj11 = obj10 & 0x1FFFFF;
														object obj12 = obj11 >> 6;
														object obj13 = obj11 & 0x3F;
														nint num14;
														do
														{
															object obj14 = 1 << (int)obj13;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r15_v28+462E0+v2333 @ rdx_v132*8]");
															object obj15 = 0 | obj14;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r15_v28+462E0+v2333 @ rdx_v132*8]");
															nint num13 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r15_v28+462E0+v2333 @ rdx_v132*8]");
															if (num13 == 0)
															{
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r15_v28+462E0+v2333 @ rdx_v132*8]");
															num14 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r15_v28+462E0+v2333 @ rdx_v132*8]");
														}
														while (num14 != 0);
														TweenCallback tweenCallback = Break;
														tweenCallback2 = tweenCallback;
														num15 = 0;
														obj16 = 0;
														obj17 = this;
														goto IL_04f2;
													}
												}
											}
											TweenCallback tweenCallback3 = Break;
											bool flag10 = tweenerCore == null;
											tweenCallback2 = tweenCallback3;
											num15 = 0;
											obj16 = 0;
											obj17 = this;
											num16 = 0;
											obj18 = 0;
											obj19 = this;
											if (!flag10)
											{
												goto IL_04f2;
											}
											goto IL_0551;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0d22;
		IL_10c3:
		WeaponData currentWeaponData;
		float num18;
		float num17 = currentWeaponData._003CrepeatInterval_003Ek__BackingField * num18;
		fullSalvoDuration = num17;
		float num19;
		if (_indexInWeapon != 0)
		{
			if ((object)_GroundFx != null)
			{
				_GroundFx.enabled = false;
				goto IL_0b1e;
			}
		}
		else
		{
			bool flag11 = (object)_GroundFx == null;
			Transform transform4 = _GroundFx.transform;
			bool flag12 = (object)transform4 == null;
			num19 = target.x;
			_ = target.x;
			_ = target.z;
			bool flag13 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj20);
			bool flag14 = (object)_GroundFx == null;
			_GroundFx.enabled = true;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 0.05f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_GroundFx, 0f);
			if (_tween1 != null)
			{
				_tween1.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_GroundFx != null)
			{
				Transform transform5 = _GroundFx.transform;
				if (array != null)
				{
					if ((object)transform5 != null)
					{
						SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale((SpriteRenderer)(object)transform5, 0f);
						bool flag15 = (object)spriteRenderer3 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
						_ = 0;
						float num20 = num3 * 0.35f;
						_ = 1;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
						_ = 0;
						_ = 1132068864;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
						_ = 0;
						MultiTargetTween tween = Tweens.Add(tweenConfig);
						_tween1 = tween;
						if (_tween2 != null)
						{
							_tween2.Kill();
						}
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						if (array2 != null)
						{
							if ((object)_GroundFx != null)
							{
								nint num21 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj21 = default(object);
								bool flag16 = obj21 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig2 != null)
							{
								tweenConfig2.targets = array2;
								_ = 0;
								tweenConfig2.duration = 250f;
								_ = 1041865114;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
								tweenConfig2.alpha = (float?)(object)0;
								TweenCallback onComplete = delegate
								{
									//IL_005e: Expected I, but got O
									//IL_00d1: Expected O, but got I4
									if (_tween3 != null)
									{
										_tween3.Kill();
									}
									TweenConfig tweenConfig3 = new TweenConfig();
									object[] array3 = new object[1];
									if ((object)_GroundFx != null)
									{
										nint num30 = (nint)array3;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj31 = default(object);
										if (obj31 == null)
										{
											ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
											throw ex;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									tweenConfig3.targets = array3;
									tweenConfig3.delay = fullSalvoDuration;
									tweenConfig3.duration = 200f;
									tweenConfig3.alpha = (float?)(object)1;
									MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
									_tween3 = tween3;
								};
								tweenConfig2.onComplete = onComplete;
								MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
								_tween2 = tween2;
								goto IL_0b1e;
							}
						}
					}
				}
			}
		}
		goto IL_0d22;
		IL_04f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2147 @ rax_v111 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		bool flag17 = (nint)0 == 0;
		num16 = num15;
		obj18 = obj16;
		obj19 = obj17;
		if (!flag17)
		{
			num16 = num15;
			obj18 = obj16;
			obj19 = obj17;
		}
		goto IL_0551;
		IL_0551:
		_positionTween = tweenerCore;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_positionTween == null)
		{
			goto IL_0d22;
		}
		float2 float7 = base.position;
		float num22 = num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		float num23 = num22 - 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
		object obj23 = default(object);
		object obj22 = obj23 - 0;
		object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
		{
			float num24 = num23 / (float)float5;
			float2 float8 = obj22 / (object)float5;
			float2 float9 = float8;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
			float num24 = 0f;
			float2 float9 = float5;
		}
		Transform transform6 = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		nint num25 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2856 @ rax_v123 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2857 @ rax_v124 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
		_ = 0;
		_ = Vector3.forwardVector;
		_ = 0;
		object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Quaternion.AngleAxis_Injected((float)this, ref *(Vector3*)obj26, out *(Quaternion*)obj25);
		bool flag18 = (object)transform6 == null;
		bool flag19 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
		Transform.set_rotation_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Quaternion*)(&ret));
		bool flag20 = (object)_JavelinSprite == null;
		Transform transform7 = _JavelinSprite.transform;
		_ = 0;
		bool flag21 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
		object obj27 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Transform.get_rotation_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out *(Quaternion*)obj27);
		bool flag22 = (object)transform7 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
		num19 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2919 @ rax_v133 (UnityEngine.Transform)+10]");
		bool flag23 = (nint)0 == 0;
		object obj28 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2919 @ rax_v133 (UnityEngine.Transform)+10]");
		Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)obj28);
		Weapon weapon2 = _weapon;
		bool flag24 = (object)_weapon == null;
		currentWeaponData = weapon2._currentWeaponData;
		bool flag25 = weapon2._currentWeaponData == null;
		float num27 = _weapon.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
		num18 = 0f - 1f;
		if (!(1f > num18))
		{
			object obj29 = 1f & -2147483649L;
			if ((nint)obj29 <= 2139095040)
			{
				goto IL_10c3;
			}
		}
		num18 = 1f;
		goto IL_10c3;
		IL_0d22:
		throw new NullReferenceException();
		IL_0b1e:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Rate = 1f
		};
		bool flag26 = (object)_trueWeapon == null;
		float pitchCorrection = _trueWeapon.PitchCorrection;
		object obj30 = _indexInWeapon * 50;
		_ = 0;
		_ = 1051931443;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		_ = 0;
		float num28 = (float)obj30 + num19;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_javelin, soundConfig, 200f, 12, time);
		SpriteTrail spriteTrail = RenderingExtensions.SetScale(_Trail, _javelinScale);
		GameManager core = GM.Core;
		bool flag27 = (object)GM.Core == null;
		bool flag28 = core._playerOptions == null;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag29 = config == null;
		bool flag30 = (object)_Trail == null;
		SpriteTrail spriteTrail2 = _Trail.setVisible(config._003CFlashingVFXEnabled_003Ek__BackingField);
		bool flag31 = (object)_weapon == null;
		float num29 = _weapon.PArea();
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		float max = num19 + num19;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, max));
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		RenderingExtensions.SetScale(_explosionPfx1, minMaxCurve2);
	}

	public override void InternalUpdate()
	{
		if ((object)_JavelinSprite != null)
		{
			Transform transform = _JavelinSprite.transform;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void Break()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0052: Expected O, but got I
		//IL_0a00: Expected I, but got O
		//IL_01d3: Expected I, but got O
		//IL_0284: Expected O, but got I
		//IL_0389: Expected I, but got O
		//IL_042c: Expected O, but got I
		//IL_0509: Expected I, but got O
		//IL_05cb: Expected O, but got I
		//IL_0652: Unknown result type (might be due to invalid IL or missing references)
		//IL_0657: Expected O, but got Unknown
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected O, but got Unknown
		//IL_06dd: Expected O, but got I
		//IL_06dd: Expected O, but got I
		//IL_073a: Expected O, but got I4
		//IL_09f1->IL09f1: Incompatible stack heights: 3 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_isBroken)
		{
			return;
		}
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			bool flag = !weapon._explodeOnExpire;
			IntPtr intPtr = default(IntPtr);
			float2 float5 = (float2)(nint)intPtr;
			if (!flag)
			{
				float2 float6 = base.position;
				Projectile projectile = _weapon.SpawnExplosionAt(float6, 0, 1, 0f);
				float5 = float6;
			}
			_isBroken = true;
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v29 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			ArcadeSprite sprite = _sprite;
			if ((object)_sprite != null)
			{
				BaseBody baseBody = sprite.body;
				if (sprite.body != null)
				{
					baseBody._velocity = Vector2.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v23 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
					_ = 0;
					if (_objectsHit != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
						BaseBody baseBody2 = body;
						if (body != null)
						{
							baseBody2._enable = true;
							if (_tween4 != null)
							{
								_tween4.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							if (array != null)
							{
								if ((object)_JavelinSprite != null)
								{
									nint num3 = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj3 = default(object);
									if (obj3 == null)
									{
										ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
										throw ex;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									tweenConfig.targets = array;
									tweenConfig.duration = 200f;
									_ = 0;
									tweenConfig.ease = Ease.InQuad;
									tweenConfig.yoyo = true;
									_ = 1065353216;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
									tweenConfig.alpha = (float?)(object)0;
									TweenCallback onComplete = StartDespawn;
									tweenConfig.onComplete = onComplete;
									MultiTargetTween tween = Tweens.Add(tweenConfig);
									_tween4 = tween;
									if (_tween5 != null)
									{
										_tween5.Kill();
									}
									TweenConfig tweenConfig2 = new TweenConfig();
									object[] array2 = new object[1];
									if ((object)_Trail != null)
									{
										Transform transform = _Trail.transform;
										if (array2 != null)
										{
											if ((object)transform != null)
											{
												nint num4 = (nint)array2;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj4 = default(object);
												if (obj4 == null)
												{
													ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
													throw ex2;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig2 != null)
											{
												tweenConfig2.targets = array2;
												_ = 0;
												tweenConfig2.duration = 200f;
												tweenConfig2.ease = Ease.InQuad;
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
												tweenConfig2.scale = (float?)(object)0;
												MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
												_tween5 = tween2;
												if (_tween6 != null)
												{
													_tween6.Kill();
												}
												TweenConfig tweenConfig3 = new TweenConfig();
												object[] array3 = new object[1];
												if ((object)_JavelinSprite != null)
												{
													Transform transform2 = _JavelinSprite.transform;
													if (array3 != null)
													{
														if ((object)transform2 != null)
														{
															nint num5 = (nint)array3;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj5 = default(object);
															if (obj5 == null)
															{
																ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
																throw ex3;
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig3 != null)
														{
															tweenConfig3.targets = array3;
															float num6 = _javelinScale * 1.05f;
															_ = 0;
															tweenConfig3.duration = 200f;
															tweenConfig3.ease = Ease.InQuad;
															tweenConfig3.yoyo = true;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
															tweenConfig3.scale = (float?)(object)0;
															MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
															_tween6 = tween3;
															if ((object)_weapon != null)
															{
																float num7 = _weapon.PArea();
																float num8 = num6 * 32f;
																_ = 0;
																_ = 0;
																_ = 1;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
																object obj6 = num8 ^ 0;
																float num9 = (float)obj6 + 16f;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
																object obj7 = num8 ^ 0;
																float num10 = (float)obj7 + 16f;
																if (body != null)
																{
																	BaseBody baseBody3 = body;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
																	nint num11 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
																	BaseBody baseBody4 = baseBody3.setCircle(num8, (float?)(object)num11, (float?)(object)0);
																	PhaserScene s_scene = ArcadePhysics.s_scene;
																	if (ArcadePhysics.s_scene != null)
																	{
																		PhaserScene.Renderer renderer = s_scene._renderer;
																		if (s_scene._renderer != null)
																		{
																			int num12 = renderer.pixelHeight >> 31;
																			object obj8 = renderer.pixelHeight - num12;
																			object obj9 = obj8 >> 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
																			if ((object)_GroundFx != null)
																			{
																				int sortingOrder = default(int);
																				_GroundFx.sortingOrder = sortingOrder;
																				GameManager core = GM.Core;
																				if ((object)GM.Core != null && core._playerOptions != null)
																				{
																					PlayerOptionsData config = core._playerOptions.Config;
																					if (config != null)
																					{
																						if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
																						{
																							return;
																						}
																						Component explosionPfx = _explosionPfx1;
																						_ = 0;
																						_ = 0;
																						if ((object)_explosionPfx1 != null)
																						{
																							Transform transform3 = _explosionPfx1.transform;
																							if ((object)transform3 != null)
																							{
																								bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																								Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
																								_ = 0;
																								_ = 1;
																								_ = 1;
																								bool flag3 = (object)_explosionPfx1 == null;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
																								_ = 0;
																								_ = 0;
																								_ = 0;
																								_ = 0;
																								_ = 0;
																								bool flag4 = ((UnityEngine.Object)explosionPfx).m_CachedPtr == (IntPtr)0;
																								ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
																								ParticleSystem.Emit_Injected(((UnityEngine.Object)explosionPfx).m_CachedPtr, ref emitParams, 1);
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
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StartDespawn()
	{
		//IL_016c: Expected I, but got O
		//IL_01d0: Expected O, but got I4
		_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass30_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		if (_isDespawning)
		{
			return;
		}
		SpriteTrail spriteTrail = _Trail.setVisible(b: false);
		Tween positionTween = _positionTween;
		_isCullable = true;
		if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_positionTween);
		}
		SpriteTrail spriteTrail2 = _Trail.setVisible(b: false);
		_isDespawning = true;
		float despawnDelay = ((_indexInWeapon != 0) ? 100f : fullSalvoDuration);
		CS_0024_003C_003E8__locals6.despawnDelay = despawnDelay;
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_JavelinSprite != null)
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
		tweenConfig.duration = 100f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_0099: Expected I, but got O
			SantaJavelinProjectile santaJavelinProjectile = CS_0024_003C_003E8__locals6._003C_003E4__this;
			BaseBody baseBody = santaJavelinProjectile.body;
			baseBody._enable = false;
			SantaJavelinProjectile santaJavelinProjectile2 = CS_0024_003C_003E8__locals6._003C_003E4__this;
			if (santaJavelinProjectile2._expireTimer != null)
			{
				santaJavelinProjectile2._expireTimer.Cancel();
			}
			object obj2 = CS_0024_003C_003E8__locals6._003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v1 (Il2CppClass<System.Object>)+370]");
			Action onComplete2 = new Action(obj2, (IntPtr)0);
			nint num2 = (nint)obj2;
			float duration = CS_0024_003C_003E8__locals6.despawnDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween4 = tween;
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		_isCullable = true;
		_GroundFx.enabled = false;
		Tween positionTween = _positionTween;
		if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_positionTween);
		}
		SpriteTrail spriteTrail = _Trail.setVisible(b: false);
		_JavelinSprite.enabled = false;
		base.Despawn();
	}

	private void GetComponents()
	{
		Camera camera = _camera;
		if ((object)_camera == null || ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_camera = main;
		}
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_00f9: Expected O, but got I
		//IL_0113: Expected native int or pointer, but got O
		//IL_012d: Expected O, but got I
		//IL_015b: Expected O, but got I4
		//IL_0174: Expected O, but got Ref
		//IL_018e: Expected native int or pointer, but got O
		//IL_0536: Expected O, but got I4
		//IL_01a6: Expected O, but got Ref
		//IL_01c0: Expected native int or pointer, but got O
		//IL_0553: Expected O, but got I4
		//IL_0219: Expected O, but got I
		//IL_031f: Expected O, but got Ref
		//IL_0346: Expected O, but got I
		//IL_0360: Expected native int or pointer, but got O
		//IL_037a: Expected O, but got I
		//IL_03a8: Expected O, but got I4
		//IL_03c1: Expected O, but got Ref
		//IL_03db: Expected native int or pointer, but got O
		//IL_058d: Expected O, but got I
		//IL_0413: Expected O, but got Ref
		//IL_042d: Expected native int or pointer, but got O
		//IL_05c7: Expected O, but got I
		//IL_0465: Expected O, but got Ref
		//IL_047f: Expected native int or pointer, but got O
		//IL_0601: Expected O, but got I
		//IL_04de: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HitCloudDesat");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(150f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.65f, 0.35f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 4f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
		_ = 0;
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		_ = 0;
		particleSystemConfig._on = false;
		_ = 48127;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
		particleSystemConfig._tint = (uint?)(object)0;
		ParticleSystem explosionPfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform, "ExplosionPfx1");
		_explosionPfx1 = explosionPfx;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version2 = list2._version + 1;
		list2._version = version2;
		string[] items2 = list2._items;
		if (list2._size >= items2.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"_grain");
		}
		else
		{
			int num2 = list2._size + 1;
			list2._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+78]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+88]");
		_ = 0;
		minMaxCurve2 = new ParticleSystem.MinMaxCurve(150f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0.35f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+98]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(100f, 200f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		_ = 0;
		_ = 0;
		particleSystemConfig2._on = false;
		_ = 35071;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
		particleSystemConfig2._tint = (uint?)(object)0;
		ParticleSystem explosionPfx2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, _cachedTransform, "ExplosionPfx2");
		_explosionPfx2 = explosionPfx2;
	}

	private void _003CSetTargetVec_003Eb__27_0()
	{
		//IL_005e: Expected I, but got O
		//IL_00d1: Expected O, but got I4
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_GroundFx != null)
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
		tweenConfig.delay = fullSalvoDuration;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween3 = tween;
	}
}
