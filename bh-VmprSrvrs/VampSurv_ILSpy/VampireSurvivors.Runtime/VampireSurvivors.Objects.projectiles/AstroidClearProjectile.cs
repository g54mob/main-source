using System;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class AstroidClearProjectile : Projectile
{
	private SpriteRenderer _baseSpriteRenderer;

	private SpriteRenderer _ringRenderer;

	private SpriteRenderer _rainbowRenderer;

	private SpriteRenderer _raysRenderer;

	private MultiTargetTween _ttween6;

	private MultiTargetTween _ttween5;

	private MultiTargetTween _ttween3;

	private MultiTargetTween _ttween4;

	private MultiTargetTween _ttween4Alpha;

	private MultiTargetTween _ttween2;

	private MultiTargetTween _ttween1;

	private AstroidClearWeapon _trueWeapon;

	private bool _alreadyRecycled;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("slash", "vfx");
		_baseSpriteRenderer.sprite = sprite;
		Sprite sprite2 = SpriteManager.GetSprite("sPFX_ring_64", "vfx");
		_ringRenderer.sprite = sprite2;
		Sprite sprite3 = SpriteManager.GetSprite("rockBreak_07", "vfx");
		_rainbowRenderer.sprite = sprite3;
		Sprite sprite4 = SpriteManager.GetSprite("HitStarWhite2", "vfx");
		_raysRenderer.sprite = sprite4;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_005e: Expected I, but got O
		//IL_0066: Expected I, but got O
		//IL_0076: Expected O, but got I
		//IL_00f6: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		//IL_0252: Expected O, but got I4
		//IL_00b2: Expected O, but got I
		//IL_0123: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_0185: Expected O, but got I4
		if (_alreadyRecycled)
		{
			return;
		}
		_alreadyRecycled = true;
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_022b;
		}
		nint num = (nint)typeof(AstroidClearWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.AstroidClearWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.AstroidClearWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v30+FFFFFFF8+v213 @ rax_v25*8]");
			if (0 == (nint)typeof(AstroidClearWeapon))
			{
				obj3 = 1;
				goto IL_023a;
			}
		}
		obj3 = 0;
		goto IL_023a;
		IL_022b:
		_trueWeapon = (AstroidClearWeapon)trueWeapon;
		BaseBody baseBody = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		ArcadeSprite arcadeSprite2 = setAlpha(1f);
		float num4 = _trueWeapon.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite3 = setScale(xScale, (float?)(object)0);
		_isCullable = false;
		if (index != 0)
		{
			Action onComplete = delegate
			{
				Despawn();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.120000005f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
		else
		{
			Detonate();
		}
		return;
		IL_023a:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_022b;
	}

	private unsafe void Detonate()
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_0c54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c59: Expected O, but got Unknown
		//IL_01cb: Expected O, but got I4
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected O, but got Unknown
		//IL_055c: Expected I, but got O
		//IL_0cc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc7: Expected O, but got Unknown
		//IL_06dc: Expected I, but got O
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		//IL_0462: Expected F4, but got I
		//IL_0d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d25: Expected O, but got Unknown
		//IL_0d48: Expected O, but got I4
		//IL_080b: Expected I, but got O
		//IL_090e: Expected I, but got O
		//IL_09e1: Expected I, but got O
		//IL_0a6a: Expected O, but got I
		//IL_0a99: Expected O, but got I
		//IL_0b1f: Expected I, but got O
		//IL_0ba8: Expected O, but got I
		//IL_0bd7: Expected O, but got I
		//IL_01ef->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_0247->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_04aa->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_0271->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_04d6->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_054a->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_0528->IL0528: Incompatible stack heights: 2 vs 1
		//IL_02db->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_05fb->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_06ca->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_064f->IL064f: Incompatible stack heights: 2 vs 1
		//IL_06a8->IL06a8: Incompatible stack heights: 2 vs 1
		//IL_0759->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_0785->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_07f9->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_07d7->IL07d7: Incompatible stack heights: 2 vs 1
		//IL_0d4d->IL0c79: Incompatible stack heights: 9 vs 1
		//IL_0886->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_08fc->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_08da->IL08da: Incompatible stack heights: 2 vs 1
		//IL_098b->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_09b7->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_0a26->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_0a04->IL0a04: Incompatible stack heights: 2 vs 1
		//IL_0b12->IL0c1c: Incompatible stack heights: 1 vs 0
		//IL_0b64->IL0c1c: Incompatible stack heights: 2 vs 0
		if ((object)_ringRenderer != null)
		{
			_ringRenderer.enabled = true;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringRenderer, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 1f);
			if ((object)spriteRenderer2 != null)
			{
				Transform transform = spriteRenderer2.transform;
				if ((object)transform != null)
				{
					_ = -0f;
					object obj = default(object);
					Vector3 localEulerAngles = (Vector3)(obj - 80);
					transform.localEulerAngles = localEulerAngles;
					Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
					((Renderer)spriteRenderer2).SetMaterial(material);
					if ((object)_ringRenderer != null)
					{
						Transform transform2 = _ringRenderer.transform;
						float2 float5 = base.position;
						float2 float6 = base.position;
						_ = 0;
						bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						object obj2 = obj - 80;
						Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj2);
						GameManager core = GM.Core;
						PlayerOptionsData config = core._playerOptions.Config;
						object obj4 = default(object);
						if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
						{
							SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_raysRenderer, 0.5f);
							object obj3 = obj4;
							float num = 0.5f;
							object obj5 = 0;
							goto IL_0c79;
						}
						if ((object)_rainbowRenderer != null)
						{
							_rainbowRenderer.enabled = true;
							SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(_rainbowRenderer, 0f);
							SpriteRenderer spriteRenderer5 = RenderingExtensions.SetAlpha(spriteRenderer4, 1f);
							if ((object)spriteRenderer5 != null)
							{
								Transform transform3 = spriteRenderer5.transform;
								if ((object)transform3 != null)
								{
									_ = -0f;
									Vector3 localEulerAngles2 = (Vector3)(obj - 80);
									transform3.localEulerAngles = localEulerAngles2;
									Material material2 = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
									((Renderer)spriteRenderer5).SetMaterial(material2);
									if ((object)_rainbowRenderer != null)
									{
										Transform transform4 = _rainbowRenderer.transform;
										float2 float7 = base.position;
										float2 float8 = base.position;
										bool flag2 = (object)transform4 == null;
										_ = 0;
										bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										object obj6 = obj - 80;
										Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj6);
										bool flag4 = (object)_raysRenderer == null;
										_raysRenderer.enabled = true;
										SpriteRenderer spriteRenderer6 = RenderingExtensions.SetScale(_raysRenderer, 0f);
										SpriteRenderer spriteRenderer7 = RenderingExtensions.SetAlpha(spriteRenderer6, 1f);
										bool flag5 = (object)spriteRenderer7 == null;
										Transform transform5 = spriteRenderer7.transform;
										bool flag6 = (object)transform5 == null;
										_ = -0f;
										Vector3 localEulerAngles3 = (Vector3)(obj - 64);
										transform5.localEulerAngles = localEulerAngles3;
										Material material3 = MaterialManager.GetMaterial(MaterialType.Vfx);
										((Renderer)spriteRenderer7).SetMaterial(material3);
										bool flag7 = (object)_raysRenderer == null;
										Transform transform6 = _raysRenderer.transform;
										float2 float9 = base.position;
										float2 float10 = base.position;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+24]");
										float num = 0f;
										bool flag8 = (object)transform6 == null;
										_ = 0;
										bool flag9 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
										object obj7 = obj - 64;
										Transform.set_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj7);
										object obj3 = obj4;
										object obj5 = 0;
										goto IL_0c79;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0c1c;
		IL_0c79:
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_ringRenderer != null)
		{
			Transform transform7 = _ringRenderer.transform;
			if (array != null)
			{
				if ((object)transform7 != null)
				{
					void* value = ((IntPtr*)(&array))->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj8 = default(object);
					bool flag10 = obj8 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
					_ = 1120403456;
					_ = 0;
					_ = 1082130432;
					_ = 1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
					_ = 0;
					_ = 1135869952;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
					_ = 0;
					MultiTargetTween ttween = Tweens.Add(tweenConfig);
					_ttween1 = ttween;
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[2];
					if (array2 != null)
					{
						if ((object)_ringRenderer != null)
						{
							void* value2 = ((IntPtr*)(&array2))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj9 = default(object);
							bool flag11 = obj9 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if ((object)_raysRenderer != null)
						{
							void* value3 = ((IntPtr*)(&array2))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj10 = default(object);
							bool flag12 = obj10 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig2 != null)
						{
							((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
							_ = 0;
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
							_ = 0;
							_ = 1120403456;
							MultiTargetTween ttween2 = Tweens.Add(tweenConfig2);
							_ttween2 = ttween2;
							TweenConfig tweenConfig3 = new TweenConfig();
							object[] array3 = new object[1];
							if ((object)_raysRenderer != null)
							{
								Transform transform8 = _raysRenderer.transform;
								if (array3 != null)
								{
									if ((object)transform8 != null)
									{
										void* value4 = ((IntPtr*)(&array3))->m_value;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj11 = default(object);
										bool flag13 = obj11 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig3 != null)
									{
										((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
										_ = 0;
										_ = 1077936128;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
										_ = 0;
										_ = 1120403456;
										MultiTargetTween ttween3 = Tweens.Add(tweenConfig3);
										_ttween3 = ttween3;
										TweenConfig tweenConfig4 = new TweenConfig();
										object[] array4 = new object[1];
										if (array4 != null)
										{
											if ((object)_rainbowRenderer != null)
											{
												void* value5 = ((IntPtr*)(&array4))->m_value;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj12 = default(object);
												bool flag14 = obj12 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig4 != null)
											{
												((UnityEngine.Object)(object)tweenConfig4).m_CachedPtr = (IntPtr)array4;
												_ = 0;
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
												_ = 0;
												_ = 1133903872;
												MultiTargetTween ttween4Alpha = Tweens.Add(tweenConfig4);
												_ttween4Alpha = ttween4Alpha;
												TweenConfig tweenConfig5 = new TweenConfig();
												object[] array5 = new object[1];
												if ((object)_rainbowRenderer != null)
												{
													Transform transform9 = _rainbowRenderer.transform;
													if (array5 != null)
													{
														if ((object)transform9 != null)
														{
															nint num2 = (nint)array5;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj13 = default(object);
															bool flag15 = obj13 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig5 != null)
														{
															tweenConfig5.targets = array5;
															_ = 0;
															_ = 1084227584;
															_ = 1;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
															tweenConfig5.scale = (float?)(object)0;
															tweenConfig5.duration = 300f;
															_ = 1132920832;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
															tweenConfig5.angle = (float?)(object)0;
															TweenCallback onComplete = delegate
															{
																Despawn();
															};
															tweenConfig5.onComplete = onComplete;
															MultiTargetTween ttween4 = Tweens.Add(tweenConfig5);
															_ttween4 = ttween4;
															TweenConfig tweenConfig6 = new TweenConfig();
															object[] array6 = new object[1];
															if (array6 != null)
															{
																nint num3 = (nint)array6;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj14 = default(object);
																bool flag16 = obj14 == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig6 != null)
																{
																	tweenConfig6.targets = array6;
																	_ = 0;
																	_ = 1065353216;
																	_ = 1;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
																	tweenConfig6.scale = (float?)(object)0;
																	tweenConfig6.duration = 120f;
																	_ = 1036831949;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
																	tweenConfig6.alpha = (float?)(object)0;
																	TweenCallback onComplete2 = delegate
																	{
																		BaseBody baseBody = body;
																		baseBody._enable = false;
																	};
																	tweenConfig6.onComplete = onComplete2;
																	MultiTargetTween ttween5 = Tweens.Add(tweenConfig6);
																	_ttween5 = ttween5;
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
		goto IL_0c1c;
		IL_0c1c:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		bool flag = _ttween1 == null;
		_alreadyRecycled = false;
		_isCullable = true;
		if (!flag)
		{
			_ttween1.Kill();
		}
		if (_ttween2 != null)
		{
			_ttween2.Kill();
		}
		if (_ttween3 != null)
		{
			_ttween3.Kill();
		}
		if (_ttween4 != null)
		{
			_ttween4.Kill();
		}
		if (_ttween5 != null)
		{
			_ttween5.Kill();
		}
		if (_ttween6 != null)
		{
			_ttween6.Kill();
		}
		if (_ttween4Alpha != null)
		{
			_ttween4Alpha.Kill();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__14_0()
	{
		Despawn();
	}

	private void _003CDetonate_003Eb__15_0()
	{
		Despawn();
	}

	private void _003CDetonate_003Eb__15_1()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}
}
