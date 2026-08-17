using System;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FixWiringProjectile : Projectile
{
	private PhaserSprite _line;

	private PhaserSprite _wireCap;

	private FixWiringWeapon _trueWeapon;

	private bool _followCap;

	private MultiTargetTween _lineTween;

	private MultiTargetTween _wireCapTween;

	[NonSerialized]
	public bool Connected;

	[NonSerialized]
	public uint Color;

	[NonSerialized]
	public float2 StartPos;

	[NonSerialized]
	public float2 TargetPos;

	[NonSerialized]
	public int Num;

	protected override void Awake()
	{
		base.Awake();
		_isCullable = false;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00e2: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_021d: Expected O, but got I4
		//IL_02f3: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		Weapon trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = null;
			goto IL_0386;
		}
		nint num = (nint)typeof(FixWiringWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Weapons.FixWiringWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Weapons.FixWiringWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v78+FFFFFFF8+v70 @ rax_v73*8]");
			if (0 == (nint)typeof(FixWiringWeapon))
			{
				obj3 = 1;
				goto IL_0395;
			}
		}
		obj3 = 0;
		goto IL_0395;
		IL_0395:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_0386;
		IL_0386:
		_trueWeapon = (FixWiringWeapon)trueWeapon;
		BaseBody baseBody = body.setCircle(10f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		PhaserSprite line = _line;
		_isCullable = false;
		Vector2 pos = default(Vector2);
		if ((object)_line != null && ((UnityEngine.Object)line).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _line.setVisible(visible: true);
		}
		else
		{
			PhaserWorld instance = PhaserWorld.Instance;
			PhaserSprite component = instance.AddPhaserSprite(pos, "vfx", "wire_Greyscale");
			PhaserSprite phaserSprite2 = RenderingExtensions.SetScrollFactor(component, 0f);
			if ((object)GM.Core == null)
			{
				goto IL_034d;
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			int num4 = renderer.pixelHeight - 1;
			PhaserSprite phaserSprite3 = phaserSprite2.setDepth(num4);
			PhaserSprite line2 = phaserSprite3.setOrigin(0f, (float?)(object)1);
			_line = line2;
		}
		PhaserSprite wireCap = _wireCap;
		if ((object)_wireCap != null && ((UnityEngine.Object)wireCap).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite4 = _wireCap.setVisible(visible: true);
			return;
		}
		PhaserWorld instance2 = PhaserWorld.Instance;
		PhaserSprite component2 = instance2.AddPhaserSprite(pos, "vfx", "wire_CopperEnd");
		PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor(component2, 0f);
		Transform transform = phaserSprite5.transform;
		object obj4 = default(object);
		transform.localEulerAngles = (Vector3)(&obj4);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			PhaserSprite wireCap2 = phaserSprite5.setDepth(renderer2.pixelHeight);
			_wireCap = wireCap2;
			return;
		}
		goto IL_034d;
		IL_034d:
		throw new NullReferenceException();
	}

	public void Cleanup()
	{
		clearLine();
		PhaserSprite line = _line;
		if ((object)_line != null && ((UnityEngine.Object)line).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _line.setVisible(visible: false);
		}
		PhaserSprite wireCap = _wireCap;
		if ((object)_wireCap != null && ((UnityEngine.Object)wireCap).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _wireCap.setVisible(visible: false);
		}
		if (_lineTween != null)
		{
			_lineTween.Kill();
		}
		if (_wireCapTween != null)
		{
			_wireCapTween.Kill();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	public void setWireCapPos(float2 worldPos)
	{
		float2 float5 = default(float2);
		PhaserSprite phaserSprite = _wireCap.setPosition(float5);
	}

	public unsafe void startLine(float2 from, float2 to, uint color, int num)
	{
		//IL_06b0: Expected O, but got F4
		//IL_06ce: Expected O, but got F4
		//IL_0140: Expected O, but got Ref
		//IL_01a6: Expected O, but got I4
		//IL_01c7: Expected O, but got I
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_0244: Expected O, but got I4
		//IL_02ab: Expected O, but got I4
		//IL_0341: Expected I, but got O
		//IL_03ca: Expected O, but got I4
		//IL_0443: Expected O, but got Ref
		//IL_0511: Expected I, but got O
		//IL_057b: Expected O, but got I4
		//IL_05a4: Expected O, but got I4
		//IL_07d1->IL0668: Incompatible stack heights: 1 vs 0
		//IL_04e5->IL0668: Incompatible stack heights: 1 vs 0
		//IL_0556->IL0668: Incompatible stack heights: 1 vs 0
		//IL_0534->IL0534: Incompatible stack heights: 2 vs 1
		//IL_0602->IL0668: Incompatible stack heights: 1 vs 0
		//IL_0649->IL0668: Incompatible stack heights: 1 vs 0
		float num2 = (float)to - 0.22999999f;
		float num3 = (float)from + 0.099999994f;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		TargetPos = (float2)num2;
		float num4 = num2 - num3;
		StartPos = (float2)num3;
		Color = color;
		Connected = false;
		int num5 = default(int);
		Num = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)_line != null)
				{
					int num6 = renderer.pixelHeight - 1;
					PhaserSprite phaserSprite = _line.setDepth(num6);
					if ((object)_line != null)
					{
						PhaserSprite phaserSprite2 = _line.setAlpha(1f);
						if ((object)_line != null)
						{
							PhaserSprite phaserSprite3 = _line.setTint(color);
							if ((object)_line != null)
							{
								Transform transform = _line.transform;
								if ((object)transform != null)
								{
									float2 ret = default(float2);
									transform.localEulerAngles = (Vector3)(&ret);
									if ((object)_line != null)
									{
										float2 float5 = default(float2);
										PhaserSprite phaserSprite4 = _line.setPosition(float5);
										if ((object)_line != null)
										{
											PhaserSprite phaserSprite5 = _line.setScale(0f, (float?)(object)1);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rcx_v1 (VampireSurvivors.Objects.Projectiles.FixWiringProjectile)+114]");
											nint num7 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rcx_v1 (VampireSurvivors.Objects.Projectiles.FixWiringProjectile)+10C]");
											object obj4 = num7 - 0;
											object obj5 = TargetPos - StartPos;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
											object obj6 = obj4 & 0;
											object obj7 = obj6 * obj6;
											object obj8 = obj5 * obj5;
											object obj9 = obj8 + obj7;
											object obj10;
											if (0 <= (nint)obj9)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm6,xmm1\"");
												obj10 = 0;
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
												obj10 = obj9;
											}
											if ((object)_trueWeapon != null)
											{
												float num8 = _trueWeapon.PSpeed();
												FixWiringWeapon trueWeapon = _trueWeapon;
												if ((object)_trueWeapon != null)
												{
													object obj11 = trueWeapon.failedAttempts * 500;
													float num9 = 2500f / (float)obj10;
													float num10 = num9 - (float)obj11;
													bool flag = 500f > num10;
													float duration = 500f;
													if (!flag)
													{
														duration = num10;
													}
													TweenConfig tweenConfig = new TweenConfig();
													object[] array = new object[1];
													if (array != null)
													{
														if ((object)_line != null)
														{
															nint num11 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj12 = default(object);
															if (obj12 == null)
															{
																ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
																throw ex;
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig != null)
														{
															tweenConfig.targets = array;
															tweenConfig.duration = duration;
															tweenConfig.ease = Ease.InOutSine;
															tweenConfig.scaleX = (float?)(object)1;
															MultiTargetTween lineTween = Tweens.Add(tweenConfig);
															_lineTween = lineTween;
															if ((object)_wireCap != null)
															{
																Transform transform2 = _wireCap.transform;
																if ((object)transform2 != null)
																{
																	transform2.localEulerAngles = (Vector3)(&ret);
																	if ((object)_mainCamera != null)
																	{
																		Transform transform3 = _mainCamera.transform;
																		if ((object)transform3 != null)
																		{
																			bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																			Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)(&ret));
																			if ((object)_wireCap != null)
																			{
																				PhaserSprite phaserSprite6 = _wireCap.setPosition(float5);
																				TweenConfig tweenConfig2 = new TweenConfig();
																				object[] array2 = new object[1];
																				if (array2 != null)
																				{
																					if ((object)_wireCap != null)
																					{
																						nint num12 = (nint)array2;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																						object obj13 = default(object);
																						bool flag3 = obj13 == null;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					if (tweenConfig2 != null)
																					{
																						tweenConfig2.targets = array2;
																						tweenConfig2.localX = (float?)(object)1;
																						tweenConfig2.duration = duration;
																						tweenConfig2.ease = Ease.InOutSine;
																						tweenConfig2.localY = (float?)(object)1;
																						TweenCallback onComplete = delegate
																						{
																							BaseBody baseBody2 = body;
																							_followCap = false;
																							baseBody2._enable = false;
																							_trueWeapon.LineComplete();
																						};
																						tweenConfig2.onComplete = onComplete;
																						MultiTargetTween wireCapTween = Tweens.Add(tweenConfig2);
																						_wireCapTween = wireCapTween;
																						if ((object)_wireCap != null)
																						{
																							float2 float6 = _wireCap.position;
																							base.position = float6;
																							BaseBody baseBody = body;
																							if (body != null)
																							{
																								baseBody._enable = true;
																								_followCap = true;
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

	protected override void OnUpdate()
	{
		if (_followCap)
		{
			float2 float5 = _wireCap.position;
			base.position = float5;
		}
	}

	public unsafe void connectLine()
	{
		//IL_0026: Expected O, but got Ref
		Connected = true;
		Transform transform = _wireCap.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite = _line.setAlpha(0.35f);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = -renderer.pixelHeight;
		PhaserSprite phaserSprite2 = _line.setDepth(num);
	}

	public void SetCapVisible(bool visible)
	{
		PhaserSprite wireCap = _wireCap;
		if ((object)_wireCap != null && ((UnityEngine.Object)wireCap).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _wireCap.setVisible(visible);
		}
	}

	public unsafe void clearLine()
	{
		//IL_0075: Expected O, but got Ref
		//IL_009b: Expected O, but got Ref
		//IL_00cd: Expected O, but got I4
		if (_lineTween != null)
		{
			_lineTween.Kill();
		}
		if (_wireCapTween != null)
		{
			_wireCapTween.Kill();
		}
		Connected = false;
		Transform transform = _wireCap.transform;
		float2 float5 = default(float2);
		transform.localEulerAngles = (Vector3)(&float5);
		Transform transform2 = _line.transform;
		transform2.localEulerAngles = (Vector3)(&float5);
		float2 float6 = default(float2);
		PhaserSprite phaserSprite = _line.setPosition(float6);
		PhaserSprite phaserSprite2 = _line.setScale(0f, (float?)(object)1);
		BaseBody baseBody = body;
		_followCap = false;
		baseBody._enable = false;
	}

	public override void Despawn()
	{
		Cleanup();
		base.Despawn();
	}

	private void _003CstartLine_003Eb__15_0()
	{
		BaseBody baseBody = body;
		_followCap = false;
		baseBody._enable = false;
		_trueWeapon.LineComplete();
	}
}
