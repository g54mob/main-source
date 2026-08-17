using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FireballProjectile : Projectile
{
	private ParticleSystem _pfxEmitter;

	private Tween _scaleTween;

	protected override void Awake()
	{
		base.Awake();
		GenerateParticleSystem();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002a: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		BaseBody baseBody = body.setCircle(12f, (float?)(object)0, (float?)(object)0);
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		Tween scaleTween = _scaleTween;
		_speed = 0.8f;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		bool flag2 = (object)_weapon == null;
		float num = _weapon.PArea();
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, 0f, 0.2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		_scaleTween = tweenerCore;
		Tween scaleTween2 = _scaleTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag3 = _scaleTween == null;
		scaleTween2.stringId = "DefaultGameTweenId";
	}

	public override void SetTarget(Transform target)
	{
		//IL_00ca: Expected O, but got I
		//IL_0144: Expected O, but got I
		//IL_0a12: Expected O, but got I
		//IL_01ae: Expected O, but got I
		//IL_0a5a: Expected O, but got I
		//IL_021c: Expected O, but got I
		//IL_0201: Expected I4, but got I8
		//IL_0aa2: Expected O, but got I
		//IL_028a: Expected O, but got I
		//IL_0aea: Expected O, but got I
		//IL_02f8: Expected O, but got I
		//IL_02dd: Expected I4, but got I8
		//IL_0b32: Expected O, but got I
		//IL_0366: Expected O, but got I
		//IL_0b7a: Expected O, but got I
		//IL_03d4: Expected O, but got I
		//IL_03b9: Expected I4, but got I8
		//IL_0bc2: Expected O, but got I
		//IL_0442: Expected O, but got I
		//IL_0c0a: Expected O, but got I
		//IL_04b0: Expected O, but got I
		//IL_0495: Expected I4, but got I8
		//IL_0c52: Expected O, but got I
		//IL_051e: Expected O, but got I
		//IL_0c9a: Expected O, but got I
		//IL_058c: Expected O, but got I
		//IL_0571: Expected I4, but got I8
		//IL_0ce2: Expected O, but got I
		//IL_05fa: Expected O, but got I
		//IL_0d2a: Expected O, but got I
		//IL_0668: Expected O, but got I
		//IL_064d: Expected I4, but got I8
		//IL_0d72: Expected O, but got I
		//IL_06d6: Expected O, but got I
		//IL_0dba: Expected O, but got I
		//IL_0744: Expected O, but got I
		//IL_0729: Expected I4, but got I8
		//IL_0e02: Expected O, but got I
		//IL_07b2: Expected O, but got I
		//IL_0e4a: Expected O, but got I
		//IL_0820: Expected O, but got I
		//IL_0805: Expected I4, but got I8
		//IL_0e92: Expected O, but got I
		//IL_088e: Expected O, but got I
		//IL_0eda: Expected O, but got I
		//IL_08fd: Expected O, but got I
		//IL_08e1: Expected I4, but got I8
		//IL_0927: Expected O, but got I
		//IL_0f7d: Expected F4, but got O
		//IL_0947->IL09d9: Incompatible stack heights: 1 vs 0
		//IL_09aa->IL09d9: Incompatible stack heights: 1 vs 0
		_targetTransform = target;
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			float num = AngleFromTargetRadians(_targetTransform, playerTransform);
			List<int> list = new List<int>();
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v15+18]");
					if (num2 >= 0)
					{
						list.AddWithResize(0);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
						object obj2 = (nint)0 + (nint)1;
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v17+18]");
						if (num3 >= 0)
						{
							list.AddWithResize(5);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
							object obj4 = (nint)0 + (nint)1;
							_ = 5;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v19+18]");
							if (num4 >= 0)
							{
								list.AddWithResize(-5);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
								object obj6 = (nint)0 + (nint)1;
								_ = 4294967291L;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v21+18]");
								if (num5 >= 0)
								{
									list.AddWithResize(10);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
									object obj8 = (nint)0 + (nint)1;
									_ = 10;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v23+18]");
									if (num6 >= 0)
									{
										list.AddWithResize(-10);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
										object obj10 = (nint)0 + (nint)1;
										_ = 4294967286L;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v25+18]");
										if (num7 >= 0)
										{
											list.AddWithResize(15);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
											object obj12 = (nint)0 + (nint)1;
											_ = 15;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
										object obj13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
											nint num8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v27+18]");
											if (num8 >= 0)
											{
												list.AddWithResize(-15);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
												object obj14 = (nint)0 + (nint)1;
												_ = 4294967281L;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
											object obj15 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
												nint num9 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v29+18]");
												if (num9 >= 0)
												{
													list.AddWithResize(20);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
													object obj16 = (nint)0 + (nint)1;
													_ = 20;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
												_ = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
												object obj17 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
													nint num10 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v31+18]");
													if (num10 >= 0)
													{
														list.AddWithResize(-20);
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
														object obj18 = (nint)0 + (nint)1;
														_ = 4294967276L;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
													_ = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
													object obj19 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
														nint num11 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v33+18]");
														if (num11 >= 0)
														{
															list.AddWithResize(25);
														}
														else
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
															object obj20 = (nint)0 + (nint)1;
															_ = 25;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
														_ = (nint)0 + (nint)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
														object obj21 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
															nint num12 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v35+18]");
															if (num12 >= 0)
															{
																list.AddWithResize(-25);
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																object obj22 = (nint)0 + (nint)1;
																_ = 4294967271L;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
															_ = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
															object obj23 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																nint num13 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v37+18]");
																if (num13 >= 0)
																{
																	list.AddWithResize(30);
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																	object obj24 = (nint)0 + (nint)1;
																	_ = 30;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																_ = (nint)0 + (nint)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																object obj25 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																	nint num14 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v39+18]");
																	if (num14 >= 0)
																	{
																		list.AddWithResize(-30);
																	}
																	else
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																		object obj26 = (nint)0 + (nint)1;
																		_ = 4294967266L;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																	_ = (nint)0 + (nint)1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																	object obj27 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																		nint num15 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v41+18]");
																		if (num15 >= 0)
																		{
																			list.AddWithResize(35);
																		}
																		else
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																			object obj28 = (nint)0 + (nint)1;
																			_ = 35;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																		_ = (nint)0 + (nint)1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																		object obj29 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																			nint num16 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v43+18]");
																			if (num16 >= 0)
																			{
																				list.AddWithResize(-35);
																			}
																			else
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																				object obj30 = (nint)0 + (nint)1;
																				_ = 4294967261L;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																			_ = (nint)0 + (nint)1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																			object obj31 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																				nint num17 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v45+18]");
																				if (num17 >= 0)
																				{
																					list.AddWithResize(40);
																				}
																				else
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																					object obj32 = (nint)0 + (nint)1;
																					_ = 40;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																				_ = (nint)0 + (nint)1;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																				object obj33 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																				if ((nint)0 != 0)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																					nint num18 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v47+18]");
																					if (num18 >= 0)
																					{
																						list.AddWithResize(-40);
																					}
																					else
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																						object obj34 = (nint)0 + (nint)1;
																						_ = 4294967256L;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																					_ = (nint)0 + (nint)1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																					object obj35 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																					if ((nint)0 != 0)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																						nint num19 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v49+18]");
																						if (num19 >= 0)
																						{
																							list.AddWithResize(45);
																						}
																						else
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																							object obj36 = (nint)0 + (nint)1;
																							_ = 45;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																						_ = (nint)0 + (nint)1;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																						object obj37 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																						if ((nint)0 != 0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																							nint num20 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v51+18]");
																							if (num20 >= 0)
																							{
																								list.AddWithResize(-45);
																							}
																							else
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																								object obj38 = (nint)0 + (nint)1;
																								_ = 4294967251L;
																							}
																							int indexInWeapon = _indexInWeapon;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																							int num21 = (int)((nint)indexInWeapon % (nint)0);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																							bool flag = (nint)num21 >= (nint)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																							Transform transform = (Transform)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																							if ((nint)0 != 0)
																							{
																								float projectileSpeed = base.ProjectileSpeed;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rbx_v11 (UnityEngine.Transform)+20+v148 @ rdx_v54 (System.Int32)*4]");
																								float num22 = 0f * ((float)Math.PI / 180f);
																								float rotation = num22 + num;
																								Vector2 vector = SetVelocityFromRotation(rotation, num);
																								if (body != null)
																								{
																									Transform transform2 = base.transform;
																									((List<int>)(object)this).Add(0);
																									Vector3 axis = default(Vector3);
																									Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
																									bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																									Quaternion value = default(Quaternion);
																									Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
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
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		OnHasHitAnObjectLogic(other, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_0056: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			Transform transform = base.AimForRandomEnemy();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	private void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		//IL_013b: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (triggerHit && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				Despawn();
			}
		}
		else
		{
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			Transform transform = base.AimForRandomEnemy();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				Weapon weapon2 = _weapon;
				GameManager gameMan2 = weapon2._gameMan;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				gameMan2._arcanaManager.TriggerFireExplosion(pos);
			}
		}
		Despawn();
	}

	public override void Despawn()
	{
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		_scaleTween = null;
		base.Despawn();
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0169: Expected O, but got Ref
		//IL_0183: Expected native int or pointer, but got O
		//IL_019d: Expected O, but got I
		//IL_01bd: Expected O, but got Ref
		//IL_01e4: Expected O, but got I
		//IL_01f9: Expected native int or pointer, but got O
		//IL_0213: Expected O, but got I
		//IL_0233: Expected O, but got Ref
		//IL_024d: Expected native int or pointer, but got O
		//IL_02e6: Expected O, but got I
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
			((List<object>)(object)list).AddWithResize((object)"HitBoom1");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HitBoom2");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-11]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 15));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1F]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 47));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2F]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
		_ = 0;
		particleSystemConfig._on = true;
		ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfxEmitter = pfxEmitter;
	}
}
