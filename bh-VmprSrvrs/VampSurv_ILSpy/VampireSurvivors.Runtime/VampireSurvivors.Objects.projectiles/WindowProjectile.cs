using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class WindowProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public WindowProjectile _003C_003E4__this;

		public float bodyWidth;

		internal float _003CInitProjectile_003Eb__0()
		{
			//IL_002e: Expected F4, but got I
			WindowProjectile windowProjectile = _003C_003E4__this;
			BaseBody body = windowProjectile.body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rax_v4 (BaseBody)+5C]");
			return 0f;
		}

		internal void _003CInitProjectile_003Eb__1(float val)
		{
			//IL_0022: Expected O, but got I4
			//IL_0022: Expected O, but got I4
			//IL_0045: Expected O, but got F4
			//IL_006c: Expected O, but got I4
			WindowProjectile windowProjectile = _003C_003E4__this;
			BaseBody baseBody = windowProjectile.body.setSize((float?)(object)1, (float?)(object)1);
			WindowProjectile windowProjectile2 = _003C_003E4__this;
			object obj = bodyWidth ^ -0f;
			float x = (float)obj * 0.5f;
			BaseBody baseBody2 = windowProjectile2.body.setOffset(x, (float?)(object)1);
		}

		internal void _003CInitProjectile_003Eb__2()
		{
			//IL_004e: Expected O, but got I
			//IL_0102: Expected I, but got O
			//IL_01ea->IL015a: Incompatible stack heights: 1 vs 0
			//IL_006e->IL015a: Incompatible stack heights: 1 vs 0
			//IL_024f->IL015a: Incompatible stack heights: 2 vs 0
			//IL_009a->IL015a: Incompatible stack heights: 2 vs 0
			//IL_00f5->IL015a: Incompatible stack heights: 2 vs 0
			WindowProjectile windowProjectile = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				object pfxEmitter = windowProjectile._pfxEmitter;
				if ((object)windowProjectile._pfxEmitter != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v7 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v7 (System.Object)+10]");
					ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
					object obj = _003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v8 (System.Object)+E0]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v8 (System.Object)+E0]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v9 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v9 (System.Object)+10]");
							ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
							WindowProjectile windowProjectile2 = _003C_003E4__this;
							if ((object)_003C_003E4__this != null && (object)windowProjectile2._particlesManager != null)
							{
								float remainingLifetime = windowProjectile2._particlesManager.GetRemainingLifetime();
								object obj3 = _003C_003E4__this;
								WindowProjectile windowProjectile3 = _003C_003E4__this;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ r8_v8 (Il2CppClass<System.Object>)+370]");
								Action onComplete = new Action(windowProjectile3, (IntPtr)0);
								if ((object)_003C_003E4__this != null)
								{
									nint num = (nint)obj3;
									float num2 = remainingLifetime * 1000f;
									float duration = num2 * 0.001f;
									bool useRealTime = default(bool);
									MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
									int repeat = default(int);
									TimerType type = default(TimerType);
									Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CInitProjectile_003Eb__3()
		{
			WindowProjectile windowProjectile = _003C_003E4__this;
			windowProjectile._exploSprite.enabled = false;
		}

		internal void _003CInitProjectile_003Eb__4()
		{
			WindowProjectile windowProjectile = _003C_003E4__this;
			windowProjectile._windowVfx.enabled = false;
			WindowProjectile windowProjectile2 = _003C_003E4__this;
			Transform transform = windowProjectile2._windowVfx.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _well;

	private uint[] _onEmitCustomTint = new uint[6] { 15722253u, 15713226u, 15038228u, 11520777u, 10470624u, 10377469u };

	private SpriteRenderer _windowVfx;

	private SpriteAnimation _windowVfxAnimation;

	private SpriteRenderer _exploSprite;

	private Tween _scaleTween;

	private MultiTargetTween _scaleTween2;

	private MultiTargetTween _exploTween;

	private Transform _cachedRendererTransform;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0234: Expected O, but got I4
		//IL_0234: Expected I4, but got O
		//IL_02cf: Expected O, but got I4
		//IL_02cf: Expected I4, but got O
		//IL_05ea: Expected O, but got I4
		//IL_0611: Expected O, but got I4
		//IL_0638: Expected O, but got I4
		//IL_0651: Expected O, but got Ref
		//IL_066b: Expected native int or pointer, but got O
		//IL_0685: Expected O, but got I
		//IL_06a5: Expected O, but got Ref
		//IL_06bf: Expected native int or pointer, but got O
		//IL_06d9: Expected O, but got I
		//IL_06f9: Expected O, but got Ref
		//IL_0713: Expected native int or pointer, but got O
		//IL_0f2e: Expected O, but got I
		//IL_074b: Expected O, but got Ref
		//IL_0765: Expected native int or pointer, but got O
		//IL_0f68: Expected O, but got I
		//IL_079d: Expected O, but got Ref
		//IL_07b7: Expected native int or pointer, but got O
		//IL_0fa2: Expected O, but got I
		//IL_07ef: Expected O, but got Ref
		//IL_0809: Expected native int or pointer, but got O
		//IL_0824: Expected O, but got I
		//IL_0fdc: Expected O, but got I
		//IL_086f: Expected O, but got I
		//IL_0884: Expected O, but got I
		//IL_0a08: Expected O, but got I4
		//IL_0a2f: Expected O, but got I4
		//IL_0a56: Expected O, but got I4
		//IL_0a6f: Expected O, but got Ref
		//IL_0a89: Expected native int or pointer, but got O
		//IL_0aa3: Expected O, but got I
		//IL_0ac3: Expected O, but got Ref
		//IL_0add: Expected native int or pointer, but got O
		//IL_0af7: Expected O, but got I
		//IL_0b17: Expected O, but got Ref
		//IL_0b31: Expected native int or pointer, but got O
		//IL_1016: Expected O, but got I
		//IL_0b69: Expected O, but got Ref
		//IL_0b83: Expected native int or pointer, but got O
		//IL_1050: Expected O, but got I
		//IL_0bbb: Expected O, but got Ref
		//IL_0bd5: Expected native int or pointer, but got O
		//IL_0c1a: Expected O, but got I
		//IL_0c47: Expected O, but got Ref
		//IL_0c61: Expected native int or pointer, but got O
		//IL_108a: Expected O, but got I
		//IL_0cc4: Expected O, but got I
		//IL_0ceb: Expected O, but got I
		//IL_0d00: Expected O, but got I
		//IL_0db6: Expected O, but got I
		//IL_0dcb: Expected O, but got I
		//IL_00bf->IL0e64: Incompatible stack heights: 1 vs 0
		//IL_00fa->IL0e64: Incompatible stack heights: 1 vs 0
		//IL_0126->IL0e64: Incompatible stack heights: 1 vs 0
		//IL_0171->IL0e64: Incompatible stack heights: 1 vs 0
		//IL_019f->IL0e64: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL0e64: Incompatible stack heights: 1 vs 0
		//IL_0206->IL0e64: Incompatible stack heights: 1 vs 0
		//IL_0278->IL0e64: Incompatible stack heights: 1 vs 0
		//IL_02a1->IL0e64: Incompatible stack heights: 1 vs 0
		//IL_02f8->IL0e64: Incompatible stack heights: 1 vs 0
		//IL_032d->IL0e64: Incompatible stack heights: 2 vs 0
		//IL_0368->IL0e64: Incompatible stack heights: 2 vs 0
		//IL_0394->IL0e64: Incompatible stack heights: 2 vs 0
		//IL_03df->IL0e64: Incompatible stack heights: 2 vs 0
		//IL_0420->IL0e64: Incompatible stack heights: 2 vs 0
		//IL_044e->IL0e64: Incompatible stack heights: 2 vs 0
		//IL_048a->IL0e64: Incompatible stack heights: 2 vs 0
		//IL_04e6->IL0e64: Incompatible stack heights: 2 vs 0
		//IL_0535->IL0e64: Incompatible stack heights: 2 vs 0
		//IL_05b7->IL0e64: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		if ((object)_renderer != null)
		{
			Transform cachedRendererTransform = _renderer.transform;
			_cachedRendererTransform = cachedRendererTransform;
			GameObject cachedRendererTransform2 = (GameObject)(object)_cachedRendererTransform;
			if ((object)_cachedRendererTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedRendererTransform2).m_CachedPtr == (IntPtr)0;
				Vector2 value = default(Vector2);
				Transform.set_localScale_Injected(((UnityEngine.Object)cachedRendererTransform2).m_CachedPtr, ref *(Vector3*)(&value));
				Vector2 pivot = default(Vector2);
				string text = default(string);
				int num = default(int);
				bool flag2 = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("window_", 0, 29, pivot, text, num, flag2);
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, "windowVfx");
				if ((object)gameObject != null)
				{
					SpriteRenderer windowVfx = gameObject.AddComponent<SpriteRenderer>();
					_windowVfx = windowVfx;
					if ((object)_windowVfx != null)
					{
						Transform transform = _windowVfx.transform;
						if ((object)transform != null)
						{
							transform.parent = _cachedTransform;
							Sprite sprite = SpriteManager.GetSprite("window_0", "vfx");
							if ((object)_windowVfx != null)
							{
								_windowVfx.sprite = sprite;
								if ((object)_windowVfx != null)
								{
									GameObject gameObject2 = _windowVfx.gameObject;
									if ((object)gameObject2 != null)
									{
										SpriteAnimation windowVfxAnimation = gameObject2.AddComponent<SpriteAnimation>();
										_windowVfxAnimation = windowVfxAnimation;
										if ((object)_windowVfxAnimation != null)
										{
											bool autoSetAnimation = default(bool);
											_windowVfxAnimation.AddAnimation("strike", animationFrames, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag2, autoSetAnimation);
											List<Sprite> list = new List<Sprite>();
											Sprite sprite2 = SpriteManager.GetSprite("window_0", "vfx");
											if (list != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
												if ((object)_windowVfxAnimation != null)
												{
													_windowVfxAnimation.AddAnimation("idle", list, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag2, autoSetAnimation);
													GameObject windowVfx2 = (GameObject)(object)_windowVfx;
													if ((object)_windowVfx != null)
													{
														bool flag3 = ((UnityEngine.Object)windowVfx2).m_CachedPtr == (IntPtr)0;
														Renderer.set_sortingOrder_Injected(((UnityEngine.Object)windowVfx2).m_CachedPtr, 9001);
														GameObject gameObject3 = new GameObject();
														GameObject.Internal_CreateGameObject(gameObject3, "exploSprite");
														if ((object)gameObject3 != null)
														{
															SpriteRenderer exploSprite = gameObject3.AddComponent<SpriteRenderer>();
															_exploSprite = exploSprite;
															if ((object)_exploSprite != null)
															{
																Transform transform2 = _exploSprite.transform;
																if ((object)transform2 != null)
																{
																	transform2.parent = _cachedTransform;
																	Sprite sprite3 = SpriteManager.GetSprite("s_pfx_rainbow_64", "vfx");
																	if ((object)_exploSprite != null)
																	{
																		_exploSprite.sprite = sprite3;
																		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
																		if ((object)_exploSprite != null)
																		{
																			((Renderer)_exploSprite).SetMaterial(material);
																			if ((object)_exploSprite != null)
																			{
																				_exploSprite.enabled = false;
																				GameObject gameObject4 = base.gameObject;
																				if ((object)gameObject4 != null)
																				{
																					ParticleEmitterManager particlesManager = gameObject4.AddComponent<ParticleEmitterManager>();
																					_particlesManager = particlesManager;
																					ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
																					List<string> list2 = new List<string>();
																					if (list2 != null)
																					{
																						int version = list2._version + 1;
																						list2._version = version;
																						string[] items = list2._items;
																						if (list2._items != null)
																						{
																							if (list2._size >= items.Length)
																							{
																								((List<object>)(object)list2).AddWithResize((object)"PfxLine2");
																							}
																							else
																							{
																								int num2 = list2._size + 1;
																								list2._size = num2;
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																							}
																							if (particleSystemConfig != null)
																							{
																								particleSystemConfig._frame = list2;
																								ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																								particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
																								_ = 0;
																								minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																								particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
																								_ = 0;
																								minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
																								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 0f));
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
																								particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
																								particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(80f, 100f));
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
																								_ = 0;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
																								particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(4f, 0f));
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
																								_ = 0;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
																								particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(4f, 12f));
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
																								_ = 0;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
																								particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0.75f, 0f));
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
																								obj = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																								_ = 0;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
																								particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
																								_ = 0;
																								particleSystemConfig._tintRandom = _onEmitCustomTint;
																								_ = 0;
																								_ = 1;
																								_ = 1;
																								_ = 0;
																								_ = 1065353216;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2A0]");
																								particleSystemConfig._quantity = (int?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2A0]");
																								particleSystemConfig._frequency = (float?)(object)0;
																								particleSystemConfig._on = false;
																								bool flag4 = (object)_particlesManager == null;
																								ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "_pfxEmitter");
																								_pfxEmitter = pfxEmitter;
																								ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
																								List<string> list3 = new List<string>();
																								bool flag5 = list3 == null;
																								int version2 = list3._version + 1;
																								list3._version = version2;
																								string[] items2 = list3._items;
																								bool flag6 = list3._items == null;
																								if (list3._size >= items2.Length)
																								{
																									((List<object>)(object)list3).AddWithResize((object)"PfxLine2");
																								}
																								else
																								{
																									int num3 = list3._size + 1;
																									list3._size = num3;
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																								}
																								bool flag7 = particleSystemConfig2 == null;
																								particleSystemConfig2._frame = list3;
																								minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																								particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
																								_ = 0;
																								minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																								particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
																								_ = 0;
																								minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
																								particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 0f));
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
																								particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 416));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 360f));
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
																								particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1B0]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(160f, 200f));
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1C0]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1D0]");
																								_ = 0;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
																								particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 480));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(4f, 6f));
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
																								_ = 0;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
																								particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 512));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(4f, 12f));
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
																								_ = 0;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
																								particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 544));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(0.75f, 0f));
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+220]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+230]");
																								_ = 0;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+98]");
																								particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A8]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B8]");
																								_ = 0;
																								particleSystemConfig2._tintRandom = _onEmitCustomTint;
																								_ = 0;
																								_ = 1;
																								_ = 1;
																								_ = 0;
																								_ = 1065353216;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2A0]");
																								particleSystemConfig2._quantity = (int?)(object)0;
																								_ = 0;
																								_ = 1;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2A0]");
																								particleSystemConfig2._frequency = (float?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2A0]");
																								particleSystemConfig2._blendMode = (BlendMode?)(object)0;
																								particleSystemConfig2._on = false;
																								bool flag8 = (object)_particlesManager == null;
																								ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "_pfxEmitter");
																								_pfxEmitter2 = pfxEmitter2;
																								GravityWellConfig gravityWellConfig = new GravityWellConfig();
																								_ = 0;
																								_ = 0;
																								_ = 1;
																								bool flag9 = gravityWellConfig == null;
																								_ = 0;
																								_ = 3192704204L;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2A0]");
																								gravityWellConfig._y = (float?)(object)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2A0]");
																								gravityWellConfig._x = (float?)(object)0;
																								gravityWellConfig._power = 1f;
																								gravityWellConfig._epsilon = 50f;
																								gravityWellConfig._gravity = 20f;
																								bool flag10 = (object)_particlesManager == null;
																								GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
																								_well = well;
																								bool flag11 = (object)_particlesManager == null;
																								ParticleEmitterManager particleEmitterManager = _particlesManager.SetDepth(9000);
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

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0095: Expected I4, but got O
		//IL_011d: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_09ce: Expected O, but got F4
		//IL_0a20: Expected O, but got I4
		//IL_0172: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_0280: Expected O, but got Ref
		//IL_02a9: Expected native int or pointer, but got O
		//IL_02cf: Expected O, but got Ref
		//IL_02dd: Expected O, but got Ref
		//IL_0306: Expected native int or pointer, but got O
		//IL_0320: Expected F4, but got I
		//IL_033c: Expected O, but got Ref
		//IL_0579: Expected O, but got I4
		//IL_0910: Expected O, but got I4
		//IL_05da: Expected I4, but got O
		//IL_0704: Expected O, but got I4
		//IL_0725: Expected F4, but got O
		//IL_0788: Expected O, but got I4
		//IL_07de: Expected O, but got I4
		//IL_00fe->IL095d: Incompatible stack heights: 1 vs 0
		//IL_022e->IL095d: Incompatible stack heights: 1 vs 0
		//IL_025d->IL095d: Incompatible stack heights: 1 vs 0
		//IL_08bf->IL08bf: Incompatible stack heights: 8 vs 7
		//IL_06c1->IL06c1: Incompatible stack heights: 14 vs 13
		//IL_07e3->IL07e3: Incompatible stack heights: 14 vs 5
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass13_0();
		if (CS_0024_003C_003E8__locals15 != null)
		{
			CS_0024_003C_003E8__locals15._003C_003E4__this = this;
			base.InitProjectile(pool, weapon, index);
			if ((object)_windowVfx != null)
			{
				_windowVfx.enabled = false;
				if ((object)_weapon != null)
				{
					float num = _weapon.PArea();
					int num2 = (int)_cachedRendererTransform;
					if ((object)_cachedRendererTransform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rbx_v14 (System.Int32)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rbx_v14 (System.Int32)+10]");
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected((IntPtr)0, ref value);
						SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 0f);
						object obj3 = default(object);
						float num3 = (float)obj3 * 96f;
						if (body != null)
						{
							BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
							object obj4 = UnityEngine.Random.value;
							float num4 = num3 - 0.5f;
							float num5 = num4 * 1000f;
							float time = default(float);
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Window, new SoundManager.SoundConfig
							{
								Detune = num5,
								Rate = 1f,
								Volume = (float?)(object)1
							}, 150f, 6, time);
							SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
							float detune = num5 - 400f;
							soundConfig.Volume = (float?)(object)1;
							soundConfig.Detune = detune;
							soundConfig.Rate = 1f;
							PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Window, soundConfig, 150f, 6, time);
							SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
							float detune2 = num5 - 800f;
							soundConfig2.Volume = (float?)(object)1;
							soundConfig2.Detune = detune2;
							soundConfig2.Rate = 1f;
							PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Window, soundConfig2, 150f, 6, time);
							if ((object)_windowVfx != null)
							{
								_windowVfx.enabled = true;
								if ((object)_windowVfxAnimation != null)
								{
									_windowVfxAnimation.SetAnimation("strike");
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
									float max = (float)obj3 * 12f;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(4f, max));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
									_ = 0;
									object obj5 = default(object);
									RenderingExtensions.SetScaleY(_pfxEmitter, (ParticleSystem.MinMaxCurve)(&obj5));
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
									float max2 = (float)obj3 * 12f;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(4f, max2));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
									float val = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
									_ = 0;
									RenderingExtensions.SetScaleY(_pfxEmitter2, (ParticleSystem.MinMaxCurve)(&obj5));
									RenderingExtensions.Start(_pfxEmitter);
									RenderingExtensions.Start(_pfxEmitter2);
									Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1518 @ rax_v65 (UnityEngine.Bounds)+10]");
									float num6 = 0f * 2f;
									float num7 = num6 * 0.5f;
									float bodyWidth = (float)obj3 * 96f;
									float num8 = num7 * (float)obj3;
									CS_0024_003C_003E8__locals15.bodyWidth = bodyWidth;
									float endValue = num8 * 100f;
									if (_scaleTween != null)
									{
										DG.Tweening.TweenExtensions.Kill(_scaleTween);
									}
									DOGetter<float> getter = null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
									DOSetter<float> dOSetter = null;
									((_003C_003Ec__DisplayClass13_0)(object)dOSetter)._003CInitProjectile_003Eb__1(val);
									TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, endValue, 0.120000005f);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									bool flag2 = tweenerCore == null;
									TweenCallback tweenCallback = delegate
									{
										//IL_004e: Expected O, but got I
										//IL_0102: Expected I, but got O
										//IL_01ea->IL015a: Incompatible stack heights: 1 vs 0
										//IL_006e->IL015a: Incompatible stack heights: 1 vs 0
										//IL_024f->IL015a: Incompatible stack heights: 2 vs 0
										//IL_009a->IL015a: Incompatible stack heights: 2 vs 0
										//IL_00f5->IL015a: Incompatible stack heights: 2 vs 0
										WindowProjectile windowProjectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
										{
											object pfxEmitter = windowProjectile._pfxEmitter;
											if ((object)windowProjectile._pfxEmitter != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v7 (System.Object)+10]");
												bool flag22 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v7 (System.Object)+10]");
												ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
												object obj9 = CS_0024_003C_003E8__locals15._003C_003E4__this;
												if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v8 (System.Object)+E0]");
													object obj10 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v8 (System.Object)+E0]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v9 (System.Object)+10]");
														bool flag23 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v9 (System.Object)+10]");
														ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
														WindowProjectile windowProjectile2 = CS_0024_003C_003E8__locals15._003C_003E4__this;
														if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null && (object)windowProjectile2._particlesManager != null)
														{
															float remainingLifetime = windowProjectile2._particlesManager.GetRemainingLifetime();
															object obj11 = CS_0024_003C_003E8__locals15._003C_003E4__this;
															WindowProjectile windowProjectile3 = CS_0024_003C_003E8__locals15._003C_003E4__this;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ r8_v8 (Il2CppClass<System.Object>)+370]");
															Action onComplete3 = new Action(windowProjectile3, (IntPtr)0);
															if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
															{
																nint num14 = (nint)obj11;
																float num15 = remainingLifetime * 1000f;
																float duration = num15 * 0.001f;
																bool useRealTime = default(bool);
																MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																int repeat = default(int);
																TimerType type = default(TimerType);
																Timer timer = Timers.Register(duration, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																return;
															}
														}
													}
												}
											}
										}
										throw new NullReferenceException();
									};
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v72 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
									bool flag3 = (nint)0 == 0;
									nint num9 = 0;
									if (!flag3)
									{
										num9 = 0;
									}
									_scaleTween = tweenerCore;
									Weapon weapon2 = _weapon;
									bool flag4 = (object)_weapon == null;
									bool flag5 = weapon2._playerOptions == null;
									PlayerOptionsData config = weapon2._playerOptions.Config;
									bool flag6 = config == null;
									bool flag7 = !config._003CFlashingVFXEnabled_003Ek__BackingField;
									object obj6 = 0;
									if (!flag7)
									{
										bool flag8 = (object)_exploSprite == null;
										Transform transform = _exploSprite.transform;
										bool flag9 = (object)transform == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1863 @ rax_v112 (UnityEngine.Transform)+10]");
										bool flag10 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1863 @ rax_v112 (UnityEngine.Transform)+10]");
										Vector3 value2 = default(Vector3);
										Transform.set_localScale_Injected((IntPtr)0, ref value2);
										bool flag11 = (object)_exploSprite == null;
										_exploSprite.enabled = true;
										int num10 = (int)_exploSprite;
										bool flag12 = (object)_exploSprite == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v853 @ rbx_v27 (System.Int32)+10]");
										bool flag13 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v853 @ rbx_v27 (System.Int32)+10]");
										Renderer.set_sortingOrder_Injected((IntPtr)0, 9000);
										if (_exploTween != null)
										{
											_exploTween.Kill();
										}
										TweenConfig tweenConfig = new TweenConfig();
										object[] array = new object[1];
										bool flag14 = (object)_exploSprite == null;
										Transform transform2 = _exploSprite.transform;
										bool flag15 = array == null;
										if ((object)transform2 != null)
										{
											int value3 = ((int*)(&array))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj7 = default(object);
											bool flag16 = obj7 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										bool flag17 = tweenConfig == null;
										tweenConfig.targets = array;
										tweenConfig.scaleX = (float?)(object)1;
										bodyWidth = (float)CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2335 @ rax_v136 (UnityEngine.Bounds)+10]");
										float num11 = 0f * 2f;
										float num12 = num11 * 0.75f;
										tweenConfig.duration = 250f;
										float num13 = num12 * (float)obj3;
										val = num13 / 0.64f;
										tweenConfig.scaleY = (float?)(object)1;
										TweenCallback onComplete = delegate
										{
											WindowProjectile windowProjectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
											windowProjectile._exploSprite.enabled = false;
										};
										tweenConfig.onComplete = onComplete;
										num9 = 0;
										MultiTargetTween exploTween = Tweens.Add(tweenConfig);
										_exploTween = exploTween;
										obj6 = 0;
									}
									if (_scaleTween2 != null)
									{
										_scaleTween2.Kill();
									}
									TweenConfig tweenConfig2 = new TweenConfig();
									object[] array2 = new object[1];
									bool flag18 = (object)_windowVfx == null;
									Transform transform3 = _windowVfx.transform;
									bool flag19 = array2 == null;
									if ((object)transform3 != null)
									{
										int value4 = ((int*)(&array2))->m_value;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj8 = default(object);
										bool flag20 = obj8 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									bool flag21 = tweenConfig2 == null;
									tweenConfig2.targets = array2;
									tweenConfig2.duration = 300f;
									tweenConfig2.scale = (float?)(object)1;
									TweenCallback onComplete2 = delegate
									{
										WindowProjectile windowProjectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
										windowProjectile._windowVfx.enabled = false;
										WindowProjectile windowProjectile2 = CS_0024_003C_003E8__locals15._003C_003E4__this;
										Transform transform4 = windowProjectile2._windowVfx.transform;
										bool flag22 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										Vector3 value5 = default(Vector3);
										Transform.set_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value5);
									};
									tweenConfig2.onComplete = onComplete2;
									MultiTargetTween scaleTween = Tweens.Add(tweenConfig2);
									_scaleTween2 = scaleTween;
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
}
