using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class SongProjectile : Projectile
{
	private Blitter _blitter;

	private Blitter _blitterBg;

	private bool _blittersMade;

	private MultiTargetTween _fadeOutTween;

	private Timer _fadeOutTimer;

	private MultiTargetTween _scaleTween;

	private bool _isBroken;

	private Timer _hitboxTimer;

	private const float BobAlpha = 0.5f;

	private const float ScaleX = 32f;

	private List<Sprite> _spriteList;

	private static int _fps = 60;

	private static double _frameTime;

	private double _frameTimeMS;

	private double _elapsed;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_004c: Expected O, but got I4
		//IL_01ef: Expected I, but got O
		//IL_024a: Expected I, but got O
		//IL_0380: Invalid comparison between O and F4
		//IL_0478: Invalid comparison between O and F4
		//IL_056e: Invalid comparison between O and F4
		//IL_0664: Invalid comparison between O and F4
		//IL_08db: Expected O, but got Ref
		//IL_0934: Expected O, but got Ref
		//IL_098d: Expected O, but got Ref
		//IL_09fc: Expected O, but got Ref
		//IL_0a55: Expected O, but got Ref
		//IL_0a92: Expected O, but got F4
		//IL_0866: Expected F4, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		MakeBlitters();
		bool flag = default(bool);
		Bounds bounds;
		if ((object)_renderer != null)
		{
			_renderer.enabled = false;
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
			BaseBody baseBody = body;
			if (body != null)
			{
				baseBody._enable = true;
				_isCullable = false;
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
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer hitboxTimer = Timers.Register(num, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_hitboxTimer = hitboxTimer;
					if (_scaleTween != null)
					{
						_scaleTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array != null)
					{
						if ((object)_cachedTransform != null)
						{
							nint num2 = (nint)array;
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
							((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
							if ((object)_weapon != null)
							{
								_ = 0;
								float num3 = _weapon.PArea();
								float num4 = num * 32f;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
								_ = 0;
								bounds = CameraExtensions.OrthographicBounds(_mainCamera);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rax_v61 (UnityEngine.Bounds)+10]");
								_ = 0;
								_ = bounds.m_Center;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rax_v61 (UnityEngine.Bounds)+10]");
								float num5 = 0f * 2f;
								float num6 = num5 * 100f;
								_ = 0;
								_ = 1140457472;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
								_ = 0;
								MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
								_scaleTween = scaleTween;
								if ((object)_weapon != null)
								{
									float num7 = _weapon.PArea();
									if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref bounds.m_Center) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.5f))
									{
										goto IL_043c;
									}
									Blitter blitter = _blitter;
									if ((object)_blitter != null)
									{
										List<Bob> bobs = blitter._bobs;
										if (blitter._bobs != null)
										{
											if (bobs._size < 200)
											{
												AddBobs(_blitter, 100);
												AddBobs(_blitterBg, 100);
											}
											goto IL_043c;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_086b;
		IL_086b:
		throw new NullReferenceException();
		IL_043c:
		if ((object)_weapon != null)
		{
			float num8 = _weapon.PArea();
			if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref bounds.m_Center) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2f))
			{
				goto IL_0532;
			}
			Blitter blitter2 = _blitter;
			if ((object)_blitter != null)
			{
				List<Bob> bobs2 = blitter2._bobs;
				if (blitter2._bobs != null)
				{
					if (bobs2._size < 300)
					{
						AddBobs(_blitter, 100);
						AddBobs(_blitterBg, 100);
					}
					goto IL_0532;
				}
			}
		}
		goto IL_086b;
		IL_0628:
		if ((object)_weapon != null)
		{
			float num9 = _weapon.PArea();
			if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref bounds.m_Center) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f))
			{
				goto IL_071e;
			}
			Blitter blitter3 = _blitter;
			if ((object)_blitter != null)
			{
				List<Bob> bobs3 = blitter3._bobs;
				if (blitter3._bobs != null)
				{
					if (bobs3._size < 1000)
					{
						AddBobs(_blitter, 100);
						AddBobs(_blitterBg, 100);
					}
					goto IL_071e;
				}
			}
		}
		goto IL_086b;
		IL_071e:
		Renderer cachedTransform = (Renderer)(object)_cachedTransform;
		_isBroken = false;
		if ((object)_cachedTransform != null)
		{
			_ = 0;
			_ = 0;
			bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj4);
			bool flag3 = (object)_blitter == null;
			Transform transform = _blitter.transform;
			bool flag4 = (object)transform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
			_ = 0;
			bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj5);
			bool flag6 = (object)_blitterBg == null;
			Transform transform2 = _blitterBg.transform;
			bool flag7 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
			_ = 0;
			bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
			Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj6);
			Weapon cachedTransform2 = (Weapon)(object)_cachedTransform;
			bool flag9 = (object)_weapon == null;
			Transform transform3 = _weapon.transform;
			bool flag10 = (object)transform3 == null;
			_ = 0;
			_ = 0;
			bool flag11 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
			Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj7);
			bool flag12 = (object)_cachedTransform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
			_ = 0;
			bool flag13 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
			Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref *(Vector3*)obj8);
			Shoot();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
			{
				Rate = 1f
			};
			object obj9 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
			float num10 = 0f * 500f;
			_ = 0;
			_ = 1053609165;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
			_ = 0;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Song, soundConfig, 150f, 3, flag ? 1 : 0);
			return;
		}
		goto IL_086b;
		IL_0532:
		if ((object)_weapon != null)
		{
			float num11 = _weapon.PArea();
			if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref bounds.m_Center) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2.5f))
			{
				goto IL_0628;
			}
			Blitter blitter4 = _blitter;
			if ((object)_blitter != null)
			{
				List<Bob> bobs4 = blitter4._bobs;
				if (blitter4._bobs != null)
				{
					if (bobs4._size < 500)
					{
						AddBobs(_blitter, 200);
						AddBobs(_blitterBg, 200);
					}
					goto IL_0628;
				}
			}
		}
		goto IL_086b;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_038f: Expected I, but got O
		//IL_0424: Expected O, but got Ref
		//IL_0442: Expected O, but got I
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Expected O, but got Unknown
		//IL_04c2: Expected O, but got F4
		//IL_0512: Expected O, but got I4
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Expected O, but got Unknown
		//IL_0119: Expected O, but got F8
		//IL_027a: Expected O, but got F4
		//IL_00f5->IL028f: Incompatible stack heights: 12 vs 0
		//IL_0163->IL028f: Incompatible stack heights: 12 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			bool flag2 = (object)_blitter == null;
			Transform transform = _blitter.transform;
			bool flag3 = (object)transform == null;
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			bool flag5 = (object)_blitterBg == null;
			Transform transform2 = _blitterBg.transform;
			bool flag6 = (object)transform2 == null;
			bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
			nint num = (nint)_cachedTransform;
			bool flag8 = (object)_weapon == null;
			Transform transform3 = _weapon.transform;
			bool flag9 = (object)transform3 == null;
			bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
			bool flag11 = (object)_cachedTransform == null;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rsi_v19 (System.IntPtr)+10]");
			bool flag12 = (nint)0 == 0;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rsi_v19 (System.IntPtr)+10]");
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj3);
			object obj4 = (nint)0 ^ (nint)0;
			object obj5 = 0 & obj4;
			bool flag13 = (nint)obj5 < 0;
			bool flag14 = (nint)0 < (nint)0;
			bool flag15 = (nint)0 == 0;
			object obj6 = Time.deltaTime;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [188A109F8h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
			_elapsed = 0.0;
			bool flag16 = flag14 == flag13;
			object obj7 = !flag15;
			object obj8 = flag16 & obj7;
			if (obj8 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,xmm0\"");
			_elapsed = 0.0;
			if ((object)_weapon != null)
			{
				float num2 = _weapon.PArea();
				object obj9 = _frameTimeMS ^ -0.0;
				float num3 = (float)obj9 * 32f;
				float num4 = num3 * 0.5f;
				float left = num4 * 0.01f;
				if ((object)_weapon != null)
				{
					float num5 = _weapon.PArea();
					float num6 = (float)_frameTimeMS * 32f;
					float num7 = num6 * 0.5f;
					float right = num7 * 0.01f;
					Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
					Bounds bounds2 = CameraExtensions.OrthographicBounds(_mainCamera);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1240 @ rax_v72 (UnityEngine.Bounds)+10]");
					_ = 0;
					_ = bounds2.m_Center;
					if (_isBroken)
					{
						Bounds bounds3 = CameraExtensions.OrthographicBounds(_mainCamera);
						object obj10 = default(object);
						float num8 = (float)obj10 * 2f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1297 @ rax_v77 (UnityEngine.Bounds)+10]");
						_ = 0;
						right = num8 * 0.5f;
						Bounds bounds4 = CameraExtensions.OrthographicBounds(_mainCamera);
						float num9 = (float)obj10 * 2f;
						object obj11 = num9 ^ -0f;
						left = (float)obj11 * 0.5f;
					}
					float top = default(float);
					float bottom = default(float);
					BlitterBounce(_blitter, left, right, top, bottom);
					BlitterBounce(_blitterBg, left, right, top, bottom);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		_isCullable = true;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		UpdateBlitter(_blitter, 0f);
		UpdateBlitter(_blitterBg, 0f);
		GameObject gameObject = _blitter.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _blitterBg.gameObject;
		gameObject2.SetActive(value: false);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	private void Shoot()
	{
		//IL_0228: Expected O, but got I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected I4, but got Unknown
		//IL_0236: Expected O, but got I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected I4, but got Unknown
		Weapon weapon = _weapon;
		int num = ((Equipment)weapon)._003COwner_003Ek__BackingField.Depth;
		Blitter blitter = _blitter;
		object obj = Screen.height;
		int sortingOrder = obj + num;
		blitter._meshRenderer.sortingOrder = sortingOrder;
		Blitter blitterBg = _blitterBg;
		object obj2 = Screen.height;
		int sortingOrder2 = num - obj2;
		blitterBg._meshRenderer.sortingOrder = sortingOrder2;
		GameObject gameObject = _blitter.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = _blitterBg.gameObject;
		gameObject2.SetActive(value: true);
		Blitter blitter2 = _blitter;
		Material material = ((Renderer)blitter2._meshRenderer).GetMaterial();
		RenderingExtensions.SetAlpha(material, 1f);
		Blitter blitterBg2 = _blitterBg;
		Material material2 = ((Renderer)blitterBg2._meshRenderer).GetMaterial();
		RenderingExtensions.SetAlpha(material2, 1f);
		UpdateBlitter(_blitter);
		UpdateBlitter(_blitterBg);
		_blitter.UpdateBobs();
		_blitterBg.UpdateBobs();
		if (_fadeOutTimer != null)
		{
			_fadeOutTimer.Cancel();
		}
		float num2 = _weapon.PDuration();
		Action onComplete = delegate
		{
			//IL_00aa: Expected I, but got O
			//IL_0121: Expected I, but got O
			//IL_0185: Expected O, but got I4
			//IL_01a0: Expected I, but got O
			BaseBody baseBody = body;
			_isBroken = true;
			baseBody._enable = false;
			if (_fadeOutTween != null)
			{
				_fadeOutTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[2];
			Blitter blitter3 = _blitter;
			Material material3 = ((Renderer)blitter3._meshRenderer).GetMaterial();
			if ((object)material3 != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Blitter blitterBg3 = _blitterBg;
			Material material4 = ((Renderer)blitterBg3._meshRenderer).GetMaterial();
			if ((object)material4 != null)
			{
				nint num4 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 1000f;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SongProjectile>)+370]");
			TweenCallback onComplete2 = new TweenCallback(this, (IntPtr)0);
			nint num5 = (nint)this;
			tweenConfig.onComplete = onComplete2;
			MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig);
			_fadeOutTween = fadeOutTween;
		};
		object obj3 = default(object);
		float duration = (float)obj3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer fadeOutTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_fadeOutTimer = fadeOutTimer;
	}

	private unsafe void UpdateBlitter(Blitter blitter, float factor = 0.01f)
	{
		//IL_028c: Expected O, but got Ref
		//IL_00be: Expected O, but got I
		//IL_029f: Expected O, but got F4
		//IL_00d3: Expected O, but got I
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0190: Expected O, but got I
		//IL_01d3: Expected O, but got I
		//IL_02cc: Expected O, but got F4
		//IL_02df: Expected I, but got O
		//IL_0306: Expected I, but got O
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_0326->IL0326: Incompatible stack heights: 5 vs 3
		Transform transform = blitter.transform;
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector2 ret;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
		bool flag2 = (object)transform == null;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector2 value = default(Vector2);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		Vector2 vector = ret;
		object obj = (object)(&value);
		Transform transform2 = null;
		while (true)
		{
			List<Bob> bobs = blitter._bobs;
			if ((nint)transform2 < bobs._size)
			{
				bool flag4 = (nint)transform2 >= bobs._size;
				Transform items = (Transform)(object)bobs._items;
				Transform obj2 = transform2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v12 (UnityEngine.Transform)+18]");
				bool flag5 = (nint)obj2 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v12 (UnityEngine.Transform)+20+v156 @ rbx_v14 (UnityEngine.Transform)*8]");
				Transform transform3 = (Transform)0;
				object obj3 = UnityEngine.Random.value;
				float num = (float)vector * (float)Math.PI;
				float num2 = num + num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdi_v13 (UnityEngine.Transform)+30]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebx\"");
				object obj5 = obj + (object)transform2;
				object obj6 = obj5 >> 2;
				object obj7 = obj6 >> 31;
				obj = obj6 + obj7;
				object obj8 = obj * 7;
				object obj9 = (object)transform2 - obj8;
				float num3 = (float)obj9 + 1f;
				float num4 = num3 * 0.5f;
				float num5 = num2 * num4;
				float num6 = num5 * factor;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdi_v13 (UnityEngine.Transform)+30]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				float num7 = num2 * 5f;
				float num8 = num7 * factor;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdi_v13 (UnityEngine.Transform)+30]");
				object obj11 = 0;
				object obj12 = UnityEngine.Random.value;
				float num9 = num8 * 0.2f;
				float num10 = num9 + 0.8f;
				nint num11 = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rax_v50 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num12 = 0;
				vector = Vector2.zeroVector;
				((UnityEngine.Object)transform3).m_CachedPtr = (IntPtr)Vector2.zeroVector;
				transform2 = (Transform)(transform2 + 1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rcx_v34 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				_ = 0;
				continue;
			}
			break;
		}
	}

	private void BlitterBounce(Blitter blitter, float left, float right, float top, float bottom)
	{
		List<Bob>.Enumerator enumerator = default(List<Bob>.Enumerator);
		if (enumerator.MoveNext())
		{
			Bob bob = null;
			throw new NullReferenceException();
		}
	}

	private void MakeBlitters()
	{
		if (_blittersMade)
		{
			return;
		}
		List<Sprite> spriteList = new List<Sprite>();
		Sprite sprite = SpriteManager.GetSprite("PfxPink", "vfx");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
		Sprite sprite2 = SpriteManager.GetSprite("PfxYellow", "vfx");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
		Sprite sprite3 = SpriteManager.GetSprite("PfxBlue", "vfx");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
		_spriteList = spriteList;
		List<Sprite> spriteList2 = _spriteList;
		if (spriteList2._size > 0)
		{
			Sprite[] items = spriteList2._items;
			Texture2D texture = items[0].texture;
			Blitter blitter = Blitter.CreateBlitter(BlendMode.Add, texture);
			_blitter = blitter;
			AddBobs(_blitter, 100);
			List<Sprite> spriteList3 = _spriteList;
			if (spriteList3._size > 0)
			{
				Sprite[] items2 = spriteList3._items;
				Texture2D texture2 = items2[0].texture;
				Blitter blitterBg = Blitter.CreateBlitter(BlendMode.Add, texture2);
				_blitterBg = blitterBg;
				AddBobs(_blitterBg, 100);
				_blittersMade = true;
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void AddBobs(Blitter blitter, int amount)
	{
		//IL_000e: Expected O, but got I4
		//IL_017f: Expected O, but got F4
		//IL_01b6: Expected I, but got O
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected I4, but got Unknown
		//IL_019d: Expected O, but got F4
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0151->IL01a2: Incompatible stack heights: 1 vs 0
		//IL_0156->IL01a7: Incompatible stack heights: 1 vs 0
		if (amount > 0)
		{
			object obj = 0;
			float num2 = default(float);
			Vector2 pos = default(Vector2);
			do
			{
				object obj2 = UnityEngine.Random.value;
				float num = num2 * (float)Math.PI;
				nint num3 = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v18 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num4 = 0;
				List<Sprite> spriteList = _spriteList;
				int num5 = obj % spriteList._size;
				bool flag = num5 >= spriteList._size;
				Sprite[] items = spriteList._items;
				Bob bob = blitter.CreateBob(pos, items[num5]);
				BobData bobData = bob._bobData;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num6 = num + num;
				bobData._003CVx_003Ek__BackingField = num6;
				BobData bobData2 = bob._bobData;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				float num7 = (bobData2._003CVy_003Ek__BackingField = num * 10f);
				BobData bobData3 = bob._bobData;
				object obj3 = UnityEngine.Random.value;
				float num8 = num7 * 0.2f;
				obj++;
				num2 = (bobData3._003CBounce_003Ek__BackingField = num8 + 1f);
			}
			while ((nint)obj < amount);
		}
	}

	public SongProjectile()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A109F8h]\"");
		_frameTimeMS = _frameTime;
		base._002Ector();
	}

	static SongProjectile()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
		_frameTime = 1.0;
	}

	private void _003CInitProjectile_003Eb__16_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CShoot_003Eb__19_0()
	{
		//IL_00aa: Expected I, but got O
		//IL_0121: Expected I, but got O
		//IL_0185: Expected O, but got I4
		//IL_01a0: Expected I, but got O
		BaseBody baseBody = body;
		_isBroken = true;
		baseBody._enable = false;
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		Blitter blitter = _blitter;
		Material material = ((Renderer)blitter._meshRenderer).GetMaterial();
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
		Blitter blitterBg = _blitterBg;
		Material material2 = ((Renderer)blitterBg._meshRenderer).GetMaterial();
		if ((object)material2 != null)
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
		tweenConfig.duration = 1000f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SongProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num3 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig);
		_fadeOutTween = fadeOutTween;
	}
}
