using System;
using System.Collections;
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
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LoopProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public LoopProjectile _003C_003E4__this;

		public Transform target;

		internal void _003CInitProjectile_003Eb__0()
		{
			_003C_003E4__this.Strike(target);
		}
	}

	private sealed class _003CDespawnInAFrame_003Ed__15(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LoopProjectile _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00bc: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.Despawn();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private SpriteScroller _SpriteScroller;

	private SpriteRenderer _Graphics;

	private SpriteRenderer _Graphics2;

	private ParticleEmitterManager _PfxEmitterManager;

	private Tween _moveTween;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _hitGroundTween;

	private MultiTargetTween _chargeTween;

	private MultiTargetTween _secondMoveTween;

	private MultiTargetTween _finalScaleGroundTween;

	private bool _isGrounded;

	private ParticleSystem _PfxEmitter1;

	private Circle _explosionCircle;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0155: Expected I4, but got I8
		//IL_0183: Expected O, but got I4
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected I4, but got Unknown
		//IL_027e: Expected I4, but got I8
		//IL_02ac: Expected O, but got I4
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected I4, but got Unknown
		//IL_046f: Expected O, but got I
		//IL_051a: Expected O, but got I
		//IL_05c5: Expected O, but got I
		//IL_0616: Expected O, but got Ref
		//IL_0630: Expected native int or pointer, but got O
		//IL_08ed: Expected O, but got I4
		//IL_0648: Expected O, but got Ref
		//IL_066f: Expected O, but got I
		//IL_0689: Expected native int or pointer, but got O
		//IL_06a3: Expected O, but got I
		//IL_06c3: Expected O, but got Ref
		//IL_06d8: Expected native int or pointer, but got O
		//IL_06f2: Expected O, but got I
		//IL_0712: Expected O, but got Ref
		//IL_072c: Expected native int or pointer, but got O
		//IL_090a: Expected O, but got I4
		//IL_0744: Expected O, but got Ref
		//IL_075e: Expected native int or pointer, but got O
		//IL_0934: Expected O, but got I
		//IL_0896->IL0805: Incompatible stack heights: 1 vs 0
		//IL_00c6->IL0805: Incompatible stack heights: 1 vs 0
		//IL_013c->IL0805: Incompatible stack heights: 1 vs 0
		//IL_01f5->IL0805: Incompatible stack heights: 2 vs 0
		//IL_0265->IL0805: Incompatible stack heights: 2 vs 0
		//IL_0319->IL0805: Incompatible stack heights: 3 vs 0
		//IL_0377->IL0805: Incompatible stack heights: 3 vs 0
		//IL_03d3->IL0805: Incompatible stack heights: 3 vs 0
		//IL_0415->IL0805: Incompatible stack heights: 3 vs 0
		//IL_04c0->IL0805: Incompatible stack heights: 3 vs 0
		//IL_056b->IL0805: Incompatible stack heights: 3 vs 0
		//IL_05f1->IL0805: Incompatible stack heights: 3 vs 0
		//IL_07db->IL0805: Incompatible stack heights: 3 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		_explosionCircle = circle;
		if ((object)_SpriteScroller != null)
		{
			Transform transform = _SpriteScroller.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rcx_v14 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, false);
				if ((object)_SpriteScroller != null)
				{
					Renderer component = _SpriteScroller.GetComponent<Renderer>();
					if ((object)component != null)
					{
						component.enabled = false;
						ArcadeSprite arcadeSprite = setVisible(visible: false);
						_isCullable = false;
						_speed = 0f;
						uint[] array = new uint[4] { 16776960u, 16746496u, 16777096u, 16746632u };
						if (array != null)
						{
							int num2 = (int)(_indexInWeapon & 0x80000003L);
							if ((nint)array < 0)
							{
								object obj3 = num2 - 1;
								object obj4 = obj3 | -4;
								num2 = obj4 + 1;
							}
							bool flag2 = num2 >= array.Length;
							SpriteRenderer spriteRenderer = RenderingExtensions.FillStyle(_Graphics, array[num2], 1f);
							Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
							if ((object)spriteRenderer != null)
							{
								((Renderer)spriteRenderer).SetMaterial(material);
								spriteRenderer.enabled = false;
								SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 0.075f);
								uint[] array2 = new uint[4] { 16777215u, 16777215u, 16777215u, 16777215u };
								if (array2 != null)
								{
									int num3 = (int)(_indexInWeapon & 0x80000003L);
									if ((nint)array2 < 0)
									{
										object obj5 = num3 - 1;
										object obj6 = obj5 | -4;
										num3 = obj6 + 1;
									}
									bool flag3 = num3 >= array2.Length;
									SpriteRenderer spriteRenderer3 = RenderingExtensions.FillStyle(_Graphics2, array2[num3], 1f);
									Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
									if ((object)spriteRenderer3 != null)
									{
										((Renderer)spriteRenderer3).SetMaterial(material2);
										spriteRenderer3.enabled = false;
										SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(spriteRenderer3, 0.075f);
										GameObject gameObject = base.gameObject;
										if ((object)gameObject != null)
										{
											ParticleEmitterManager pfxEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
											_PfxEmitterManager = pfxEmitterManager;
											ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
											List<string> list = new List<string>();
											if (list != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v49 (System.Collections.Generic.List`1<System.String>)+1C]");
												_ = (nint)0 + (nint)1;
												IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
												if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v49 (System.Collections.Generic.List`1<System.String>)+18]");
													nint num4 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v46 (System.IntPtr)+18]");
													if (num4 >= 0)
													{
														((List<object>)(object)list).AddWithResize((object)"PfxYellow");
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v49 (System.Collections.Generic.List`1<System.String>)+18]");
														object obj7 = (nint)0 + (nint)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v49 (System.Collections.Generic.List`1<System.String>)+1C]");
													_ = (nint)0 + (nint)1;
													IntPtr cachedPtr2 = ((UnityEngine.Object)(object)list).m_CachedPtr;
													if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v49 (System.Collections.Generic.List`1<System.String>)+18]");
														nint num5 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rcx_v48 (System.IntPtr)+18]");
														if (num5 >= 0)
														{
															((List<object>)(object)list).AddWithResize((object)"PfxRed");
														}
														else
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v49 (System.Collections.Generic.List`1<System.String>)+18]");
															object obj8 = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v49 (System.Collections.Generic.List`1<System.String>)+1C]");
														_ = (nint)0 + (nint)1;
														IntPtr cachedPtr3 = ((UnityEngine.Object)(object)list).m_CachedPtr;
														if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v49 (System.Collections.Generic.List`1<System.String>)+18]");
															nint num6 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rcx_v50 (System.IntPtr)+18]");
															if (num6 >= 0)
															{
																((List<object>)(object)list).AddWithResize((object)"PfxLine");
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v49 (System.Collections.Generic.List`1<System.String>)+18]");
																object obj9 = (nint)0 + (nint)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															if (particleSystemConfig != null)
															{
																particleSystemConfig._frame = list;
																ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 1f));
																particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
																ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
																_ = 0;
																_ = 1;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
																particleSystemConfig._quantity = (int?)(object)0;
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(90f, 90f));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
																particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(600f));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
																particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
																particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
																ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 1f));
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
																particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
																_ = 0;
																particleSystemConfig._emitZone = new EmitZone
																{
																	_type = EmitZoneType.Random,
																	_source = _explosionCircle
																};
																particleSystemConfig._on = false;
																if ((object)_PfxEmitterManager != null)
																{
																	ParticleSystem pfxEmitter = _PfxEmitterManager.CreateEmitter(particleSystemConfig);
																	_PfxEmitter1 = pfxEmitter;
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
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_009a: Expected O, but got I
		//IL_009a: Expected O, but got I
		//IL_02a2: Expected O, but got I4
		//IL_034e: Expected I4, but got O
		//IL_0805: Expected O, but got F4
		//IL_0500: Expected I4, but got O
		//IL_055f: Expected O, but got I
		//IL_056c: Expected I4, but got O
		//IL_087d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Expected O, but got Unknown
		//IL_08f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Expected O, but got Unknown
		//IL_092b: Expected O, but got I
		//IL_0948: Expected O, but got I
		//IL_0970: Unknown result type (might be due to invalid IL or missing references)
		//IL_0975: Expected O, but got Unknown
		//IL_097e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0983: Expected O, but got Unknown
		//IL_09d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d8: Expected I4, but got Unknown
		//IL_062f: Expected I4, but got O
		//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a48: Expected O, but got Unknown
		//IL_0a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6b: Expected O, but got Unknown
		//IL_08b9->IL077f: Incompatible stack heights: 1 vs 0
		//IL_0962->IL077f: Incompatible stack heights: 2 vs 0
		//IL_064c->IL077f: Incompatible stack heights: 4 vs 0
		//IL_0ad3->IL077f: Incompatible stack heights: 5 vs 0
		//IL_0708->IL0708: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass14_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			base.InitProjectile(pool, weapon, index);
			_ = 0;
			_ = 0;
			_ = 3230662656L;
			_ = 1;
			_ = 3230662656L;
			_ = 1;
			if (body != null)
			{
				BaseBody baseBody = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
				BaseBody baseBody2 = baseBody.setCircle(16f, (float?)(object)num, (float?)(object)0);
				if ((object)_weapon != null)
				{
					float num2 = _weapon.PArea();
					Circle circle = new Circle();
					object obj = default(object);
					float radius = (float)obj * 8f;
					circle._x = 0f;
					circle._radius = radius;
					_explosionCircle = circle;
					EmitZone emitZone = new EmitZone();
					emitZone._type = EmitZoneType.Random;
					emitZone._source = _explosionCircle;
					RenderingExtensions.SetEmitZone(_PfxEmitter1, emitZone);
					if (_moveTween != null)
					{
						TweenExtensions.Kill(_moveTween);
					}
					if (_despawnTween != null)
					{
						_despawnTween.Kill();
					}
					ArcadeSprite arcadeSprite = setVisible(visible: false);
					SpriteScroller spriteScroller = _SpriteScroller;
					if ((object)_SpriteScroller != null && (object)spriteScroller._spriteRenderer != null)
					{
						spriteScroller._spriteRenderer.enabled = false;
						BaseBody baseBody3 = body;
						if (body != null)
						{
							baseBody3._enable = false;
							if ((object)_weapon != null)
							{
								float num3 = _weapon.PArea();
								float num4 = (float)obj * 0.5f;
								ArcadeSprite arcadeSprite2 = setScale(num4, (float?)(object)0);
								CS_0024_003C_003E8__locals13.target = null;
								Weapon weapon2 = _weapon;
								if ((object)_weapon != null)
								{
									if (!weapon2.IsHoming)
									{
										Transform target = base.AimForRandomEnemyInScreen();
										CS_0024_003C_003E8__locals13.target = target;
									}
									else
									{
										Transform nearestEnemyTransform = base.GetNearestEnemyTransform();
										CS_0024_003C_003E8__locals13.target = nearestEnemyTransform;
									}
									int num5 = (int)CS_0024_003C_003E8__locals13.target;
									if ((object)CS_0024_003C_003E8__locals13.target != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ r14_v15 (System.Int32)+10]");
										if ((nint)0 != 0)
										{
											Weapon weapon3 = _weapon;
											if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
											{
												float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
												PhaserScene s_scene = ArcadePhysics.s_scene;
												if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
												{
													object obj2 = UnityEngine.Random.value;
													if (num4 < 0.5f)
													{
													}
													PhaserScene s_scene2 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
													{
														float2 float6 = default(float2);
														base.position = float6;
														SpriteScroller spriteScroller2 = _SpriteScroller;
														if ((object)_SpriteScroller != null && (object)spriteScroller2._spriteRenderer != null)
														{
															Sprite sprite = spriteScroller2._spriteRenderer.sprite;
															if ((object)sprite != null)
															{
																Texture2D texture = sprite.texture;
																if ((object)texture != null)
																{
																	texture.wrapMode = TextureWrapMode.Repeat;
																	int num6 = (int)_SpriteScroller;
																	if ((object)_SpriteScroller != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r14_v18 (System.Int32)+40]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r14_v18 (System.Int32)+40]");
																			((Renderer)0).enabled = true;
																			int num7 = (int)CS_0024_003C_003E8__locals13.target;
																			if ((object)CS_0024_003C_003E8__locals13.target != null)
																			{
																				_ = 0;
																				_ = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r14_v20 (System.Int32)+10]");
																				bool flag = (nint)0 == 0;
																				object obj4 = default(object);
																				object obj3 = obj4 - 64;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r14_v20 (System.Int32)+10]");
																				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
																				Transform transform = base.transform;
																				if ((object)transform != null)
																				{
																					_ = 0;
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v98 (UnityEngine.Transform)+10]");
																					bool flag2 = (nint)0 == 0;
																					object obj5 = obj4 - 80;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v98 (UnityEngine.Transform)+10]");
																					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
																					nint num8 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
																					object obj6 = num8 - 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-3C]");
																					nint num9 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-4C]");
																					object obj7 = num9 - 0;
																					if ((object)_SpriteScroller != null)
																					{
																						Transform transform2 = _SpriteScroller.transform;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
																						float num10 = (float)obj7 * 57.29578f;
																						float num11 = num10 * ((float)Math.PI / 180f);
																						_ = 0;
																						object obj8 = obj4 - 80;
																						object obj9 = obj4 - 64;
																						Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj9, out *(Quaternion*)obj8);
																						bool flag3 = (object)transform2 == null;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
																						_ = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2007 @ rax_v104 (UnityEngine.Transform)+10]");
																						bool flag4 = (nint)0 == 0;
																						bool flag5 = (byte)(obj4 - 48) != 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2007 @ rax_v104 (UnityEngine.Transform)+10]");
																						Transform.set_rotation_Injected((IntPtr)0, ref *(flag5 ? ((Quaternion*)1) : ((Quaternion*)null)));
																						if (_moveTween != null)
																						{
																							TweenExtensions.Kill(_moveTween);
																						}
																						int num12 = (int)CS_0024_003C_003E8__locals13.target;
																						if ((object)CS_0024_003C_003E8__locals13.target != null)
																						{
																							_ = 0;
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ r14_v23 (System.Int32)+10]");
																							bool flag6 = (nint)0 == 0;
																							object obj10 = obj4 - 64;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ r14_v23 (System.Int32)+10]");
																							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj10);
																							Vector3 endValue = (Vector3)(obj4 - 80);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-38]");
																							_ = 0;
																							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, endValue, 0.07f);
																							TweenCallback tweenCallback = delegate
																							{
																								CS_0024_003C_003E8__locals13._003C_003E4__this.Strike(CS_0024_003C_003E8__locals13.target);
																							};
																							if (tweenerCore != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2135 @ rax_v120 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																								if ((nint)0 == 0)
																								{
																								}
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																							if ((nint)0 == 0)
																							{
																								_ = 1;
																							}
																							if (tweenerCore != null)
																							{
																								_moveTween = tweenerCore;
																								Tween tween = TweenExtensions.Play(_moveTween);
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
											goto IL_077f;
										}
									}
									SpriteScroller spriteScroller3 = _SpriteScroller;
									if ((object)_SpriteScroller != null && (object)spriteScroller3._spriteRenderer != null)
									{
										spriteScroller3._spriteRenderer.enabled = false;
										_003CDespawnInAFrame_003Ed__15 obj11 = null;
										obj11._003C_003E1__state = 0;
										obj11._003C_003E4__this = this;
										Coroutine coroutine = StartCoroutine(obj11);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_077f;
		IL_077f:
		throw new NullReferenceException();
	}

	private IEnumerator DespawnInAFrame()
	{
		_003CDespawnInAFrame_003Ed__15 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public override void Despawn()
	{
		if (_moveTween != null)
		{
			TweenExtensions.Kill(_moveTween);
		}
		_moveTween = null;
		base.Despawn();
	}

	private void Strike(Transform target)
	{
		//IL_0305: Expected O, but got I4
		//IL_0739: Expected O, but got I4
		//IL_034c: Expected I, but got O
		//IL_0403: Expected I, but got O
		//IL_0483: Expected I, but got O
		//IL_0171: Expected O, but got I4
		//IL_0183: Unsupported input type for neg.
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_04fb: Expected O, but got I4
		//IL_02b9: Expected I, but got O
		//IL_0426->IL0426: Incompatible stack heights: 1 vs 0
		//IL_04a6->IL04a6: Incompatible stack heights: 1 vs 0
		//IL_065d->IL05a3: Incompatible stack heights: 1 vs 0
		//IL_02bf->IL02bf: Incompatible stack heights: 10 vs 0
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			BaseBody baseBody = body;
			if (body != null)
			{
				baseBody._enable = true;
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._playerOptions != null)
				{
					PlayerOptionsData config = core._playerOptions.Config;
					if (config != null)
					{
						if (!config._003CFlashingVFXEnabled_003Ek__BackingField || (object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
						{
							goto IL_02bf;
						}
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer = s_scene._renderer;
							if (s_scene._renderer != null)
							{
								int num = renderer.pixelHeight >> 31;
								object obj = renderer.pixelHeight - num;
								object obj2 = obj >> 1;
								object obj3 = 0 - obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
								bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)target).m_CachedPtr, out Vector3 ret);
								if ((object)_Graphics != null)
								{
									Transform transform = _Graphics.transform;
									bool flag2 = (object)transform == null;
									bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
									bool flag4 = (object)_Graphics == null;
									_Graphics.enabled = true;
									SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_Graphics, 0f);
									bool flag5 = (object)_Graphics == null;
									int sortingOrder = default(int);
									_Graphics.sortingOrder = sortingOrder;
									bool flag6 = (object)_Graphics2 == null;
									Transform transform2 = _Graphics2.transform;
									bool flag7 = (object)transform2 == null;
									bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
									bool flag9 = (object)_Graphics2 == null;
									_Graphics2.enabled = true;
									SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_Graphics2, 0f);
									bool flag10 = (object)_Graphics2 == null;
									_Graphics2.sortingOrder = sortingOrder;
									nint num2 = unchecked((nint)null);
									goto IL_02bf;
								}
							}
						}
					}
				}
			}
		}
		goto IL_05a3;
		IL_05a3:
		throw new NullReferenceException();
		IL_02bf:
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			bool flag11 = !weapon._explodeOnExpire;
			float2 float5 = (float2)0;
			if (!flag11)
			{
				float2 float6 = base.position;
				Projectile projectile = _weapon.SpawnExplosionAt(float6, 0, 1, 0f);
				float5 = float6;
				nint num2 = unchecked((nint)null);
			}
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * 200f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning, soundConfig, 200f, 8, time);
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[2];
			if ((object)_Graphics != null)
			{
				Transform transform3 = _Graphics.transform;
				if (array != null)
				{
					if ((object)transform3 != null)
					{
						nint num3 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj4 = default(object);
						bool flag12 = obj4 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if ((object)_Graphics2 != null)
					{
						Transform transform4 = _Graphics2.transform;
						if ((object)transform4 != null)
						{
							nint num4 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj5 = default(object);
							bool flag13 = obj5 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							tweenConfig.duration = 60f;
							tweenConfig.scale = (float?)(object)1;
							TweenCallback onComplete = delegate
							{
								//IL_00c1: Expected I, but got O
								//IL_0125: Expected O, but got I4
								//IL_0283: Expected O, but got I4
								//IL_0232: Expected I, but got O
								BaseBody baseBody2 = body;
								baseBody2._enable = false;
								_isGrounded = true;
								Action onComplete2 = delegate
								{
									SpriteScroller spriteScroller = _SpriteScroller;
									spriteScroller._spriteRenderer.enabled = false;
								};
								bool useRealTime = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer timer = Timers.Register(0.05f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								Transform transform5 = _Graphics2.transform;
								if ((object)transform5 != null)
								{
									nint num5 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj6 = default(object);
									if (obj6 == null)
									{
										ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
										throw ex;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								tweenConfig2.targets = array2;
								tweenConfig2.duration = 1500f;
								tweenConfig2.scale = (float?)(object)1;
								TweenCallback onComplete3 = delegate
								{
									_isGrounded = false;
								};
								tweenConfig2.onComplete = onComplete3;
								MultiTargetTween chargeTween = Tweens.Add(tweenConfig2);
								_chargeTween = chargeTween;
								Action onComplete4 = delegate
								{
									Transform transform7 = _SpriteScroller.transform;
									Vector3 euler = default(Vector3);
									Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
									bool flag14 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
									Quaternion value2 = default(Quaternion);
									Transform.set_rotation_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref value2);
									SpriteScroller spriteScroller = _SpriteScroller;
									spriteScroller._spriteRenderer.enabled = true;
								};
								Timer timer2 = Timers.Register(1.25f, onComplete4, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								TweenConfig tweenConfig3 = new TweenConfig();
								tweenConfig3.delay = 1300f;
								tweenConfig3.duration = 60f;
								object[] array3 = new object[1];
								Transform transform6 = _Graphics.transform;
								if ((object)transform6 != null)
								{
									nint num6 = (nint)array3;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj7 = default(object);
									if (obj7 == null)
									{
										ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
										throw ex2;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								tweenConfig3.targets = array3;
								tweenConfig3.scale = (float?)(object)1;
								TweenCallback onStart = delegate
								{
									//IL_0039: Expected O, but got I4
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
									SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
									soundConfig2.Rate = 1f;
									soundConfig2.Volume = (float?)(object)1;
									float detune2 = (float)_indexInWeapon * -100f;
									soundConfig2.Detune = detune2;
									float time2 = default(float);
									PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Lightning2, soundConfig2, 200f, 8, time2);
									BaseBody baseBody3 = body;
									baseBody3._enable = true;
								};
								tweenConfig3.onStart = onStart;
								TweenCallback onComplete5 = delegate
								{
									//IL_0064: Expected I, but got O
									//IL_00d7: Expected O, but got I4
									BaseBody baseBody3 = body;
									baseBody3._enable = false;
									TweenConfig tweenConfig4 = new TweenConfig();
									object[] array4 = new object[1];
									Transform transform7 = base.transform;
									if ((object)transform7 != null)
									{
										nint num7 = (nint)array4;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj8 = default(object);
										if (obj8 == null)
										{
											ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
											throw ex3;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									tweenConfig4.targets = array4;
									float2 float7 = base.position;
									tweenConfig4.duration = 90f;
									tweenConfig4.y = (float?)(object)1;
									TweenCallback onComplete6 = delegate
									{
										//IL_003e: Expected I, but got O
										//IL_00a8: Expected I, but got O
										//IL_010c: Expected O, but got I4
										TweenConfig tweenConfig5 = new TweenConfig();
										object[] array5 = new object[2];
										Transform transform8 = _Graphics.transform;
										if ((object)transform8 != null)
										{
											nint num8 = (nint)array5;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj9 = default(object);
											if (obj9 == null)
											{
												ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
												throw ex4;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										Transform transform9 = _Graphics2.transform;
										if ((object)transform9 != null)
										{
											nint num9 = (nint)array5;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj10 = default(object);
											if (obj10 == null)
											{
												ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
												throw ex5;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										tweenConfig5.targets = array5;
										tweenConfig5.duration = 60f;
										tweenConfig5.scale = (float?)(object)1;
										TweenCallback onComplete7 = delegate
										{
											SpriteScroller spriteScroller = _SpriteScroller;
											spriteScroller._spriteRenderer.enabled = false;
											_Graphics.enabled = false;
											_Graphics2.enabled = false;
											Despawn();
										};
										tweenConfig5.onComplete = onComplete7;
										MultiTargetTween despawnTween = Tweens.Add(tweenConfig5);
										_despawnTween = despawnTween;
									};
									tweenConfig4.onComplete = onComplete6;
									MultiTargetTween secondMoveTween = Tweens.Add(tweenConfig4);
									_secondMoveTween = secondMoveTween;
								};
								tweenConfig3.onComplete = onComplete5;
								MultiTargetTween finalScaleGroundTween = Tweens.Add(tweenConfig3);
								_finalScaleGroundTween = finalScaleGroundTween;
							};
							tweenConfig.onComplete = onComplete;
							MultiTargetTween hitGroundTween = Tweens.Add(tweenConfig);
							_hitGroundTween = hitGroundTween;
							if ((object)_SpriteScroller != null)
							{
								_SpriteScroller.SetScrollSpeedX(-10f);
								if ((object)_SpriteScroller != null)
								{
									_SpriteScroller.SetScrollOffsetY(2.47f);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_05a3;
	}

	public override void InternalUpdate()
	{
		//IL_00cd->IL0073: Incompatible stack heights: 1 vs 0
		//IL_011c->IL0073: Incompatible stack heights: 2 vs 0
		//IL_0073->IL007a: Incompatible stack heights: 2 vs 0
		if (!_isGrounded)
		{
			return;
		}
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				if ((object)_PfxEmitterManager != null)
				{
					Vector2 pos = default(Vector2);
					_PfxEmitterManager.EmitParticleAt(pos);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		//IL_0113->IL00c2: Incompatible stack heights: 1 vs 0
		//IL_008b->IL00c2: Incompatible stack heights: 1 vs 0
		if ((object)_SpriteScroller != null)
		{
			Transform transform = _SpriteScroller.transform;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
				if ((object)_SpriteScroller != null)
				{
					Transform transform3 = _SpriteScroller.transform;
					if ((object)transform3 != null)
					{
						Vector3 right = transform3.right;
						bool flag2 = (object)transform == null;
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CStrike_003Eb__17_0()
	{
		//IL_00c1: Expected I, but got O
		//IL_0125: Expected O, but got I4
		//IL_0283: Expected O, but got I4
		//IL_0232: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		_isGrounded = true;
		Action onComplete = delegate
		{
			SpriteScroller spriteScroller = _SpriteScroller;
			spriteScroller._spriteRenderer.enabled = false;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.05f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = _Graphics2.transform;
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
		tweenConfig.duration = 1500f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete2 = delegate
		{
			_isGrounded = false;
		};
		tweenConfig.onComplete = onComplete2;
		MultiTargetTween chargeTween = Tweens.Add(tweenConfig);
		_chargeTween = chargeTween;
		Action onComplete3 = delegate
		{
			Transform transform3 = _SpriteScroller.transform;
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
			SpriteScroller spriteScroller = _SpriteScroller;
			spriteScroller._spriteRenderer.enabled = true;
		};
		Timer timer2 = Timers.Register(1.25f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		TweenConfig tweenConfig2 = new TweenConfig();
		tweenConfig2.delay = 1300f;
		tweenConfig2.duration = 60f;
		object[] array2 = new object[1];
		Transform transform2 = _Graphics.transform;
		if ((object)transform2 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0039: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * -100f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning2, soundConfig, 200f, 8, time);
			BaseBody baseBody2 = body;
			baseBody2._enable = true;
		};
		tweenConfig2.onStart = onStart;
		TweenCallback onComplete4 = delegate
		{
			//IL_0064: Expected I, but got O
			//IL_00d7: Expected O, but got I4
			BaseBody baseBody2 = body;
			baseBody2._enable = false;
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			Transform transform3 = base.transform;
			if ((object)transform3 != null)
			{
				nint num3 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			float2 float5 = base.position;
			tweenConfig3.duration = 90f;
			tweenConfig3.y = (float?)(object)1;
			TweenCallback onComplete5 = delegate
			{
				//IL_003e: Expected I, but got O
				//IL_00a8: Expected I, but got O
				//IL_010c: Expected O, but got I4
				TweenConfig tweenConfig4 = new TweenConfig();
				object[] array4 = new object[2];
				Transform transform4 = _Graphics.transform;
				if ((object)transform4 != null)
				{
					nint num4 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
						throw ex4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Transform transform5 = _Graphics2.transform;
				if ((object)transform5 != null)
				{
					nint num5 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
						throw ex5;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig4.targets = array4;
				tweenConfig4.duration = 60f;
				tweenConfig4.scale = (float?)(object)1;
				TweenCallback onComplete6 = delegate
				{
					SpriteScroller spriteScroller = _SpriteScroller;
					spriteScroller._spriteRenderer.enabled = false;
					_Graphics.enabled = false;
					_Graphics2.enabled = false;
					Despawn();
				};
				tweenConfig4.onComplete = onComplete6;
				MultiTargetTween despawnTween = Tweens.Add(tweenConfig4);
				_despawnTween = despawnTween;
			};
			tweenConfig3.onComplete = onComplete5;
			MultiTargetTween secondMoveTween = Tweens.Add(tweenConfig3);
			_secondMoveTween = secondMoveTween;
		};
		tweenConfig2.onComplete = onComplete4;
		MultiTargetTween finalScaleGroundTween = Tweens.Add(tweenConfig2);
		_finalScaleGroundTween = finalScaleGroundTween;
	}

	private void _003CStrike_003Eb__17_1()
	{
		SpriteScroller spriteScroller = _SpriteScroller;
		spriteScroller._spriteRenderer.enabled = false;
	}

	private void _003CStrike_003Eb__17_3()
	{
		_isGrounded = false;
	}

	private void _003CStrike_003Eb__17_2()
	{
		Transform transform = _SpriteScroller.transform;
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		SpriteScroller spriteScroller = _SpriteScroller;
		spriteScroller._spriteRenderer.enabled = true;
	}

	private void _003CStrike_003Eb__17_4()
	{
		//IL_0039: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning2, soundConfig, 200f, 8, time);
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private void _003CStrike_003Eb__17_5()
	{
		//IL_0064: Expected I, but got O
		//IL_00d7: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = false;
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
		float2 float5 = base.position;
		tweenConfig.duration = 90f;
		tweenConfig.y = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_003e: Expected I, but got O
			//IL_00a8: Expected I, but got O
			//IL_010c: Expected O, but got I4
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[2];
			Transform transform2 = _Graphics.transform;
			if ((object)transform2 != null)
			{
				nint num2 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Transform transform3 = _Graphics2.transform;
			if ((object)transform3 != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 60f;
			tweenConfig2.scale = (float?)(object)1;
			TweenCallback onComplete2 = delegate
			{
				SpriteScroller spriteScroller = _SpriteScroller;
				spriteScroller._spriteRenderer.enabled = false;
				_Graphics.enabled = false;
				_Graphics2.enabled = false;
				Despawn();
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween despawnTween = Tweens.Add(tweenConfig2);
			_despawnTween = despawnTween;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween secondMoveTween = Tweens.Add(tweenConfig);
		_secondMoveTween = secondMoveTween;
	}

	private void _003CStrike_003Eb__17_6()
	{
		//IL_003e: Expected I, but got O
		//IL_00a8: Expected I, but got O
		//IL_010c: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		Transform transform = _Graphics.transform;
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
		Transform transform2 = _Graphics2.transform;
		if ((object)transform2 != null)
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
		tweenConfig.duration = 60f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			SpriteScroller spriteScroller = _SpriteScroller;
			spriteScroller._spriteRenderer.enabled = false;
			_Graphics.enabled = false;
			_Graphics2.enabled = false;
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween despawnTween = Tweens.Add(tweenConfig);
		_despawnTween = despawnTween;
	}

	private void _003CStrike_003Eb__17_7()
	{
		SpriteScroller spriteScroller = _SpriteScroller;
		spriteScroller._spriteRenderer.enabled = false;
		_Graphics.enabled = false;
		_Graphics2.enabled = false;
		Despawn();
	}
}
