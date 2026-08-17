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

public class TP_SpiritTornado2_SpiritGemExplosionProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public TP_SpiritTornado2_SpiritGemExplosionProjectile _003C_003E4__this;

		public int bodyWidth;

		internal float _003CInitProjectile_003Eb__0()
		{
			//IL_002e: Expected F4, but got I
			TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile = _003C_003E4__this;
			BaseBody body = tP_SpiritTornado2_SpiritGemExplosionProjectile.body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rax_v4 (BaseBody)+5C]");
			return 0f;
		}

		internal void _003CInitProjectile_003Eb__1(float val)
		{
			//IL_0022: Expected O, but got I4
			//IL_0022: Expected O, but got I4
			//IL_0067: Expected O, but got I4
			TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile = _003C_003E4__this;
			BaseBody baseBody = tP_SpiritTornado2_SpiritGemExplosionProjectile.body.setSize((float?)(object)1, (float?)(object)1);
			TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile2 = _003C_003E4__this;
			int num = -bodyWidth;
			float x = (float)num * 0.5f;
			BaseBody baseBody2 = tP_SpiritTornado2_SpiritGemExplosionProjectile2.body.setOffset(x, (float?)(object)1);
		}

		internal void _003CInitProjectile_003Eb__2()
		{
			//IL_004e: Expected O, but got I
			//IL_0085: Expected I, but got O
			//IL_0168->IL00d8: Incompatible stack heights: 1 vs 0
			//IL_006e->IL00d8: Incompatible stack heights: 1 vs 0
			//IL_01e8->IL00d8: Incompatible stack heights: 2 vs 0
			TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				object pfxEmitter = tP_SpiritTornado2_SpiritGemExplosionProjectile._pfxEmitter;
				if ((object)tP_SpiritTornado2_SpiritGemExplosionProjectile._pfxEmitter != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rbx_v7 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rbx_v7 (System.Object)+10]");
					ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
					object obj = _003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v8 (System.Object)+E0]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v8 (System.Object)+E0]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v9 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v9 (System.Object)+10]");
							ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
							object obj3 = _003C_003E4__this;
							TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile2 = _003C_003E4__this;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ r8_v8 (Il2CppClass<System.Object>)+370]");
							Action action = new Action(tP_SpiritTornado2_SpiritGemExplosionProjectile2, (IntPtr)0);
							if ((object)_003C_003E4__this != null)
							{
								nint num = (nint)obj3;
								TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile3 = _003C_003E4__this;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ r8_v8 (Il2CppClass<System.Object>)+370]");
								action._002Ector(tP_SpiritTornado2_SpiritGemExplosionProjectile3, (IntPtr)0);
								bool useRealTime = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer timer = Timers.Register(0.5f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CInitProjectile_003Eb__3()
		{
			TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile = _003C_003E4__this;
			tP_SpiritTornado2_SpiritGemExplosionProjectile._windowVfx.enabled = false;
			TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile2 = _003C_003E4__this;
			Transform transform = tP_SpiritTornado2_SpiritGemExplosionProjectile2._windowVfx.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private const float _pfxAlpha = 0.75f;

	private readonly uint[] _onEmitCustomTint = new uint[5] { 16777152u, 16777088u, 16777088u, 16777088u, 16777024u };

	private readonly uint[] _onEmitCustomTint2 = new uint[5] { 16761087u, 16744703u, 16744703u, 16746751u, 16728319u };

	private SpriteRenderer _windowVfx;

	private SpriteAnimation _windowVfxAnimation;

	private SpriteRenderer _exploSprite;

	private Tween _scaleTween;

	private MultiTargetTween _scaleTween2;

	private const float ExplosionDuration = 500f;

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
		//IL_0e11: Expected O, but got I
		//IL_074b: Expected O, but got Ref
		//IL_0765: Expected native int or pointer, but got O
		//IL_0e4b: Expected O, but got I
		//IL_079d: Expected O, but got Ref
		//IL_07b7: Expected native int or pointer, but got O
		//IL_0e85: Expected O, but got I
		//IL_07ef: Expected O, but got Ref
		//IL_0809: Expected native int or pointer, but got O
		//IL_0824: Expected O, but got I
		//IL_0ebf: Expected O, but got I
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
		//IL_0ef9: Expected O, but got I
		//IL_0b69: Expected O, but got Ref
		//IL_0b83: Expected native int or pointer, but got O
		//IL_0f33: Expected O, but got I
		//IL_0bbb: Expected O, but got Ref
		//IL_0bd5: Expected native int or pointer, but got O
		//IL_0f6d: Expected O, but got I
		//IL_0c0d: Expected O, but got Ref
		//IL_0c27: Expected native int or pointer, but got O
		//IL_0fa7: Expected O, but got I
		//IL_0c8a: Expected O, but got I
		//IL_0cb1: Expected O, but got I
		//IL_0cc6: Expected O, but got I
		//IL_00bf->IL0d47: Incompatible stack heights: 1 vs 0
		//IL_00fa->IL0d47: Incompatible stack heights: 1 vs 0
		//IL_0126->IL0d47: Incompatible stack heights: 1 vs 0
		//IL_0171->IL0d47: Incompatible stack heights: 1 vs 0
		//IL_019f->IL0d47: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL0d47: Incompatible stack heights: 1 vs 0
		//IL_0206->IL0d47: Incompatible stack heights: 1 vs 0
		//IL_0278->IL0d47: Incompatible stack heights: 1 vs 0
		//IL_02a1->IL0d47: Incompatible stack heights: 1 vs 0
		//IL_02f8->IL0d47: Incompatible stack heights: 1 vs 0
		//IL_032d->IL0d47: Incompatible stack heights: 2 vs 0
		//IL_0368->IL0d47: Incompatible stack heights: 2 vs 0
		//IL_0394->IL0d47: Incompatible stack heights: 2 vs 0
		//IL_03df->IL0d47: Incompatible stack heights: 2 vs 0
		//IL_0420->IL0d47: Incompatible stack heights: 2 vs 0
		//IL_044e->IL0d47: Incompatible stack heights: 2 vs 0
		//IL_048a->IL0d47: Incompatible stack heights: 2 vs 0
		//IL_04e6->IL0d47: Incompatible stack heights: 2 vs 0
		//IL_0535->IL0d47: Incompatible stack heights: 2 vs 0
		//IL_05b7->IL0d47: Incompatible stack heights: 2 vs 0
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
																								particleSystemConfig2._tintRandom = _onEmitCustomTint2;
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
																								bool flag9 = (object)_particlesManager == null;
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
		//IL_0067: Expected I4, but got O
		//IL_00dd: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_0681: Expected O, but got F4
		//IL_06b8: Expected O, but got I4
		//IL_0132: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_0201: Expected O, but got Ref
		//IL_020f: Expected O, but got Ref
		//IL_0229: Expected native int or pointer, but got O
		//IL_0242: Expected O, but got Ref
		//IL_025f: Expected O, but got Ref
		//IL_0278: Expected native int or pointer, but got O
		//IL_0291: Expected O, but got Ref
		//IL_02a4: Expected O, but got Ref
		//IL_02bd: Expected native int or pointer, but got O
		//IL_02d6: Expected O, but got Ref
		//IL_06e1: Expected O, but got F4
		//IL_06e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Expected Ref, but got Unknown
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f7: Expected Ref, but got Unknown
		//IL_0708: Invalid comparison between F4 and I
		//IL_076a: Invalid comparison between F4 and I
		//IL_03d1: Expected F4, but got I
		//IL_05c3: Expected O, but got I4
		//IL_00be->IL0610: Incompatible stack heights: 1 vs 0
		//IL_0572->IL0572: Incompatible stack heights: 5 vs 4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass14_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			base.InitProjectile(pool, weapon, index);
			if ((object)_windowVfx != null)
			{
				_windowVfx.enabled = false;
				int num = (int)_cachedRendererTransform;
				if ((object)_cachedRendererTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v9 (System.Int32)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v9 (System.Int32)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)0, ref value);
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 0f);
					if (body != null)
					{
						BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
						object obj3 = UnityEngine.Random.value;
						object obj4 = default(object);
						float num2 = (float)obj4 - 0.5f;
						float num3 = num2 * 1000f;
						float time = default(float);
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Window, new SoundManager.SoundConfig
						{
							Volume = (float?)(object)1,
							Detune = num3,
							Rate = 1f
						}, 150f, 1, time);
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						float detune = num3 - 400f;
						soundConfig.Volume = (float?)(object)1;
						soundConfig.Detune = detune;
						soundConfig.Rate = 1f;
						PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Window, soundConfig, 150f, 1, time);
						SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
						float detune2 = num3 - 800f;
						soundConfig2.Volume = (float?)(object)1;
						soundConfig2.Detune = detune2;
						soundConfig2.Rate = 1f;
						PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Window, soundConfig2, 150f, 1, time);
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(4f, 12f);
						object obj5 = default(object);
						RenderingExtensions.SetScaleY(_pfxEmitter, (ParticleSystem.MinMaxCurve)(&obj5));
						ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(4f, 12f));
						RenderingExtensions.SetScaleY(_pfxEmitter2, (ParticleSystem.MinMaxCurve)(&obj5));
						float scaledPfxAlpha = GetScaledPfxAlpha();
						ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(scaledPfxAlpha, 0f));
						RenderingExtensions.SetAlpha(_pfxEmitter, (ParticleSystem.MinMaxCurve)(&obj5));
						ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(scaledPfxAlpha, 0f));
						RenderingExtensions.SetAlpha(_pfxEmitter2, (ParticleSystem.MinMaxCurve)(&obj5));
						object obj6 = UnityEngine.Random.value;
						ref ParticleSystem reference = ref *(ParticleSystem*)(this + 216);
						ref ParticleSystem reference2 = ref *(ParticleSystem*)(this + 224);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-30]");
						bool flag2 = !(0.5f > 0f);
						ref ParticleSystem dominantPfx = ref reference2;
						if (!flag2)
						{
							dominantPfx = ref reference;
						}
						SetDominantPfx(ref dominantPfx);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-30]");
						bool flag3 = !(0.5f > 0f);
						ref ParticleSystem nonDominantPfx = ref reference;
						if (!flag3)
						{
							nonDominantPfx = ref reference2;
						}
						SetNonDominantPfx(ref nonDominantPfx);
						RenderingExtensions.Start(_pfxEmitter);
						RenderingExtensions.Start(_pfxEmitter2);
						Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1124 @ rax_v59 (UnityEngine.Bounds)+10]");
						float num4 = 0f * 2f;
						float num5 = num4 * 0.5f;
						CS_0024_003C_003E8__locals13.bodyWidth = 96;
						float endValue = num5 * 100f;
						if (_scaleTween != null)
						{
							DG.Tweening.TweenExtensions.Kill(_scaleTween);
						}
						DOGetter<float> getter = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
						DOSetter<float> dOSetter = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-20]");
						((_003C_003Ec__DisplayClass14_0)(object)dOSetter)._003CInitProjectile_003Eb__1(0f);
						TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, endValue, 0.08f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag4 = tweenerCore == null;
						TweenCallback tweenCallback = delegate
						{
							//IL_004e: Expected O, but got I
							//IL_0085: Expected I, but got O
							//IL_0168->IL00d8: Incompatible stack heights: 1 vs 0
							//IL_006e->IL00d8: Incompatible stack heights: 1 vs 0
							//IL_01e8->IL00d8: Incompatible stack heights: 2 vs 0
							TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile = CS_0024_003C_003E8__locals13._003C_003E4__this;
							if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
							{
								object pfxEmitter = tP_SpiritTornado2_SpiritGemExplosionProjectile._pfxEmitter;
								if ((object)tP_SpiritTornado2_SpiritGemExplosionProjectile._pfxEmitter != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rbx_v7 (System.Object)+10]");
									bool flag10 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rbx_v7 (System.Object)+10]");
									ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
									object obj8 = CS_0024_003C_003E8__locals13._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v8 (System.Object)+E0]");
										object obj9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v8 (System.Object)+E0]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v9 (System.Object)+10]");
											bool flag11 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v9 (System.Object)+10]");
											ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
											object obj10 = CS_0024_003C_003E8__locals13._003C_003E4__this;
											TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ r8_v8 (Il2CppClass<System.Object>)+370]");
											Action action = new Action(tP_SpiritTornado2_SpiritGemExplosionProjectile2, (IntPtr)0);
											if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
											{
												nint num7 = (nint)obj10;
												TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile3 = CS_0024_003C_003E8__locals13._003C_003E4__this;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ r8_v8 (Il2CppClass<System.Object>)+370]");
												action._002Ector(tP_SpiritTornado2_SpiritGemExplosionProjectile3, (IntPtr)0);
												bool useRealTime = default(bool);
												MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
												int repeat = default(int);
												TimerType type = default(TimerType);
												Timer timer = Timers.Register(0.5f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
												return;
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1172 @ rax_v66 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						bool flag5 = (nint)0 == 0;
						nint num6 = 0;
						if (!flag5)
						{
							num6 = 0;
						}
						_scaleTween = tweenerCore;
						if (_scaleTween2 != null)
						{
							_scaleTween2.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						bool flag6 = (object)_windowVfx == null;
						Transform transform = _windowVfx.transform;
						bool flag7 = array == null;
						if ((object)transform != null)
						{
							int value2 = ((int*)(&array))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj7 = default(object);
							bool flag8 = obj7 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						bool flag9 = tweenConfig == null;
						tweenConfig.targets = array;
						tweenConfig.duration = 300f;
						tweenConfig.scale = (float?)(object)1;
						TweenCallback onComplete = delegate
						{
							TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile = CS_0024_003C_003E8__locals13._003C_003E4__this;
							tP_SpiritTornado2_SpiritGemExplosionProjectile._windowVfx.enabled = false;
							TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
							Transform transform2 = tP_SpiritTornado2_SpiritGemExplosionProjectile2._windowVfx.transform;
							bool flag10 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value3 = default(Vector3);
							Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value3);
						};
						tweenConfig.onComplete = onComplete;
						MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
						_scaleTween2 = scaleTween;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SetDominantPfx(ref ParticleSystem pfx)
	{
		//IL_003f: Expected O, but got Ref
		RenderingExtensions.SetSpeed(pfx, 160f, 200f);
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(4f, 6f);
		object obj = default(object);
		RenderingExtensions.SetScaleX(pfx, (ParticleSystem.MinMaxCurve)(&obj));
		Material material = MaterialManager.GetMaterial(MaterialType.ParticlesAdditive);
		ParticleSystemRenderer component = pfx.GetComponent<ParticleSystemRenderer>();
		Material material2 = ((Renderer)component).GetMaterial();
		Shader shader = material.shader;
		material2.shader = shader;
	}

	private unsafe void SetNonDominantPfx(ref ParticleSystem pfx)
	{
		//IL_003f: Expected O, but got Ref
		RenderingExtensions.SetSpeed(pfx, 80f, 100f);
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(4f, 0f);
		object obj = default(object);
		RenderingExtensions.SetScaleX(pfx, (ParticleSystem.MinMaxCurve)(&obj));
		Material material = MaterialManager.GetMaterial(MaterialType.Particles);
		ParticleSystemRenderer component = pfx.GetComponent<ParticleSystemRenderer>();
		Material material2 = ((Renderer)component).GetMaterial();
		Shader shader = material.shader;
		material2.shader = shader;
	}

	private float GetScaledPfxAlpha()
	{
		//IL_000d: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_0096: Expected O, but got I
		//IL_00b4: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0119: Expected O, but got I4
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			nint num = (nint)weapon;
			nint num2 = (nint)typeof(TP_SpiritTornado2_Weapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
			TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile = (TP_SpiritTornado2_SpiritGemExplosionProjectile)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v8+FFFFFFF8+v54 @ rax_v7 (VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_SpiritGemExplosionProjectile)*8]");
				bool flag = 0 != (nint)typeof(TP_SpiritTornado2_Weapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
				TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile2 = (TP_SpiritTornado2_SpiritGemExplosionProjectile)0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v8+FFFFFFF8+v180 @ rcx_v5*8]");
					object obj3 = 0 - typeof(TP_SpiritTornado2_Weapon);
					bool flag2 = obj3 == null;
					bool flag3 = !flag2;
					tP_SpiritTornado2_SpiritGemExplosionProjectile2 = null;
					if (!flag3)
					{
						tP_SpiritTornado2_SpiritGemExplosionProjectile2 = (TP_SpiritTornado2_SpiritGemExplosionProjectile)(object)_weapon;
					}
					if ((object)_spriteTrail != null)
					{
						object obj4 = 0;
						List<Projectile>.Enumerator enumerator = default(List<Projectile>.Enumerator);
						if (enumerator.MoveNext())
						{
							TP_SpiritTornado2_SpiritGemExplosionProjectile tP_SpiritTornado2_SpiritGemExplosionProjectile3 = null;
							tP_SpiritTornado2_SpiritGemExplosionProjectile2 = null;
							throw new NullReferenceException();
						}
						object obj5 = obj4 - 1;
						float num4 = (float)obj5 * 0.06f;
						float num5 = 0.75f - num4;
						if (!(num5 > 0.45f))
						{
							num5 = 0.45f;
						}
						return num5;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_scaleTween);
		}
		if (_scaleTween2 != null)
		{
			_scaleTween2.Kill();
		}
		base.Despawn();
	}
}
