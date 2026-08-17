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
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class Song2Projectile : Projectile
{
	private Blitter _blitter;

	private Blitter _blitterBg;

	private bool _blittersMade;

	private Timer _hitboxTimer;

	private Timer _fadeOutTimer;

	private MultiTargetTween _fadeOutTween;

	private MultiTargetTween _scaleTween;

	private bool _isBroken;

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
		//IL_0127: Expected I, but got O
		//IL_0182: Expected I, but got O
		//IL_0500: Expected O, but got Ref
		//IL_0559: Expected O, but got Ref
		//IL_05b2: Expected O, but got Ref
		//IL_0621: Expected O, but got Ref
		//IL_067a: Expected O, but got Ref
		//IL_06b7: Expected O, but got F4
		//IL_048b: Expected F4, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		MakeBlitters();
		if ((object)_renderer != null)
		{
			_renderer.enabled = false;
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
			BaseBody baseBody = body;
			if (body != null)
			{
				baseBody._enable = true;
				_isCullable = false;
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
						nint num = (nint)array;
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
							float num2 = _weapon.PArea();
							object obj4 = default(object);
							float num3 = (float)obj4 * 32f;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
							_ = 0;
							Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v56 (UnityEngine.Bounds)+10]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v56 (UnityEngine.Bounds)+10]");
							float num4 = 0f * 2f;
							_ = bounds.m_Center;
							float num5 = num4 * 100f;
							_ = 0;
							_ = 1140457472;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
							_ = 0;
							MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
							_scaleTween = scaleTween;
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
								float duration = hitBoxDelay * 0.001f;
								bool flag = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_hitboxTimer = hitboxTimer;
								Renderer cachedTransform = (Renderer)(object)_cachedTransform;
								_isBroken = false;
								if ((object)_cachedTransform != null)
								{
									_ = 0;
									_ = 0;
									bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
									object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
									Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj5);
									bool flag3 = (object)_blitter == null;
									Transform transform = _blitter.transform;
									bool flag4 = (object)transform == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
									_ = 0;
									bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
									Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj6);
									bool flag6 = (object)_blitterBg == null;
									Transform transform2 = _blitterBg.transform;
									bool flag7 = (object)transform2 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
									_ = 0;
									bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
									Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj7);
									Weapon cachedTransform2 = (Weapon)(object)_cachedTransform;
									bool flag9 = (object)_weapon == null;
									Transform transform3 = _weapon.transform;
									bool flag10 = (object)transform3 == null;
									_ = 0;
									_ = 0;
									bool flag11 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
									Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj8);
									bool flag12 = (object)_cachedTransform == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
									_ = 0;
									bool flag13 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
									object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 1));
									Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref *(Vector3*)obj9);
									Shoot();
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
									{
										Rate = 1f
									};
									object obj10 = UnityEngine.Random.value;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
									float num6 = 0f * 1000f;
									_ = 0;
									_ = 1053609165;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
									_ = 0;
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Song, soundConfig, 150f, 3, flag ? 1 : 0);
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

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00ac: Invalid comparison between O and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			EnemyController component = gameObject.GetComponent<EnemyController>();
			object obj2 = default(object);
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && ((object)component._003CResDebuffs_003Ek__BackingField == null || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)) && component._003CSlow_003Ek__BackingField > 0.2f)
			{
				float num = component._003CSlow_003Ek__BackingField - 0.05f;
				component._003CSlow_003Ek__BackingField = num;
			}
		}
	}

	public override void Despawn()
	{
		_isCullable = true;
		UpdateBlitter(_blitter, 0f);
		UpdateBlitter(_blitterBg, 0f);
		GameObject gameObject = _blitter.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _blitterBg.gameObject;
		gameObject2.SetActive(value: false);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	private void Shoot()
	{
		//IL_0435: Expected O, but got I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected I4, but got Unknown
		//IL_0443: Expected O, but got I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected I4, but got Unknown
		//IL_02a6: Expected I, but got O
		//IL_0319: Expected I, but got O
		//IL_0397: Expected O, but got I4
		//IL_03e3: Expected I, but got O
		//IL_02c9->IL02c9: Incompatible stack heights: 1 vs 0
		//IL_033c->IL033c: Incompatible stack heights: 1 vs 0
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
			BaseBody baseBody = body;
			_isBroken = true;
			baseBody._enable = false;
			BaseBody baseBody2 = body;
			baseBody2._enable = false;
		};
		object obj3 = default(object);
		float num3 = (float)obj3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer fadeOutTimer = Timers.Register(num3, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_fadeOutTimer = fadeOutTimer;
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
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Blitter blitterBg3 = _blitterBg;
		Material material4 = ((Renderer)blitterBg3._meshRenderer).GetMaterial();
		if ((object)material4 != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			bool flag2 = obj5 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		float num6 = _weapon.PDuration();
		float num7 = (tweenConfig.delay = num3 * 0.5f);
		tweenConfig.alpha = (float?)(object)1;
		float num8 = _weapon.PDuration();
		float duration = num7 * 0.5f;
		tweenConfig.duration = duration;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Song2Projectile>)+370]");
		TweenCallback onComplete2 = new TweenCallback(this, (IntPtr)0);
		nint num9 = (nint)this;
		tweenConfig.onComplete = onComplete2;
		MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig);
		_fadeOutTween = fadeOutTween;
	}

	private void UpdateBlitter(Blitter blitter, float factor = 0.01f)
	{
		//IL_000e: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_0282: Expected O, but got F4
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_02b0: Expected O, but got F4
		//IL_02c3: Expected I, but got O
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_0309->IL0309: Incompatible stack heights: 1 vs 0
		object obj = 0;
		Blitter blitter2 = blitter;
		object obj2 = 0;
		while (true)
		{
			List<Bob> bobs = blitter._bobs;
			if ((nint)obj2 < bobs._size)
			{
				bool flag = (nint)obj >= bobs._size;
				Bob[] items = bobs._items;
				Bob bob = items[obj];
				object obj3 = UnityEngine.Random.value;
				float num = (float)Vector2.zeroVector * (float)Math.PI;
				float num2 = num + num;
				BobData bobData = bob._bobData;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebx\"");
				object obj4 = (object)blitter2 >> 1;
				object obj5 = obj4 >> 31;
				object obj6 = obj4 + obj5;
				object obj7 = obj6 * 4;
				object obj8 = obj6 + obj7;
				object obj9 = obj - obj8;
				float num3 = (float)obj9 + 1f;
				float num4 = num3 * 0.125f;
				float num5 = num2 * num4;
				float num6 = num5 * 5f;
				float num7 = num6 * factor;
				bobData._003CVx_003Ek__BackingField = num7;
				BobData bobData2 = bob._bobData;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebx\"");
				object obj10 = obj6 >> 1;
				object obj11 = obj10 >> 31;
				blitter2 = (Blitter)(object)(obj10 + obj11);
				object obj12 = blitter2 * 4;
				object obj13 = (object)blitter2 + obj12;
				object obj14 = obj - obj13;
				float num8 = (float)obj14 + 1f;
				float num9 = num8 * 0.125f;
				float num10 = num2 * num9;
				float num11 = num10 * 5f;
				float num12 = num11 * factor;
				bobData2._003CVy_003Ek__BackingField = num12;
				BobData bobData3 = bob._bobData;
				object obj15 = UnityEngine.Random.value;
				float num13 = num9 * 0.2f;
				float num14 = num13 + 0.8f;
				bobData3._003CBounce_003Ek__BackingField = num14;
				nint num15 = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v31 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num16 = 0;
				obj++;
				bob._position = Vector2.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ rcx_v18 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				_ = 0;
				obj2 = obj;
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
			AddBobs(_blitter, 800);
			List<Sprite> spriteList3 = _spriteList;
			if (spriteList3._size > 0)
			{
				Sprite[] items2 = spriteList3._items;
				Texture2D texture2 = items2[0].texture;
				Blitter blitterBg = Blitter.CreateBlitter(BlendMode.Add, texture2);
				_blitterBg = blitterBg;
				AddBobs(_blitterBg, 800);
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

	public Song2Projectile()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A109F8h]\"");
		_frameTimeMS = _frameTime;
		base._002Ector();
	}

	static Song2Projectile()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
		_frameTime = 1.0;
	}

	private void _003CInitProjectile_003Eb__16_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CShoot_003Eb__20_0()
	{
		BaseBody baseBody = body;
		_isBroken = true;
		baseBody._enable = false;
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
	}
}
