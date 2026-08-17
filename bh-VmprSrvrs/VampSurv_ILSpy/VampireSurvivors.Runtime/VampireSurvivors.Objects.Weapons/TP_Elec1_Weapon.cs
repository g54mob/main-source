using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Elec1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public float __repeatInterval;

		public TP_Elec1_Weapon _003C_003E4__this;

		public float charHeight;

		public float __amount;

		public Action _003C_003E9__1;

		public Action _003C_003E9__0;

		internal unsafe void _003CFireProjectiles_003Eb__0()
		{
			//IL_0545: Invalid comparison between F4 and I4
			//IL_05de: Expected I, but got O
			//IL_05f4: Expected O, but got I
			//IL_05fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0602: Expected O, but got Unknown
			//IL_04c9: Expected I, but got O
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0628: Expected O, but got I4
			//IL_063f: Expected I, but got I8
			//IL_04a5: Expected I, but got I8
			//IL_03c3: Expected I, but got O
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_03e0: Invalid comparison between F4 and I4
			//IL_00ce: Expected O, but got I
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected O, but got Unknown
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected I4, but got Unknown
			//IL_014b: Expected O, but got I
			//IL_014f: Expected I4, but got O
			//IL_018e: Expected I, but got O
			//IL_019e: Expected O, but got I
			//IL_021e: Expected O, but got I4
			//IL_0587: Expected I, but got O
			//IL_01da: Expected O, but got I
			//IL_0239: Expected I, but got O
			//IL_0210: Expected O, but got I4
			//IL_031e: Expected O, but got Ref
			//IL_031e: Expected O, but got I4
			bool flag4 = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			if (__amount > 0f)
			{
				bool flag = false;
				object obj3 = default(object);
				nint num = default(nint);
				IntPtr intPtr = default(IntPtr);
				IntPtr intPtr2 = default(IntPtr);
				bool flag5;
				do
				{
					_003C_003Ec__DisplayClass23_1 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass23_1();
					CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 = this;
					CS_0024_003C_003E8__locals26.localIndex = (flag ? 1 : 0);
					TP_Elec1_Weapon tP_Elec1_Weapon = _003C_003E4__this;
					object obj = flag * __repeatInterval;
					bool flag2;
					bool flag3;
					object obj10;
					if ((nint)obj <= 0)
					{
						float2 position = ((Equipment)tP_Elec1_Weapon)._003COwner_003Ek__BackingField.position;
						TP_Elec1_Weapon tP_Elec1_Weapon2 = _003C_003E4__this;
						float2 position2 = ((Equipment)tP_Elec1_Weapon2)._003COwner_003Ek__BackingField.position;
						TP_Elec1_Weapon tP_Elec1_Weapon3 = _003C_003E4__this;
						object obj2 = obj3 + charHeight;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
						object obj4 = num >> 31;
						object obj5 = num + obj4;
						object obj6 = obj5 * 2;
						object obj7 = obj5 + obj6;
						int cursorActiveIndex = CS_0024_003C_003E8__locals26.localIndex - obj7;
						tP_Elec1_Weapon3._cursorActiveIndex = cursorActiveIndex;
						TP_Elec1_Weapon tP_Elec1_Weapon4 = _003C_003E4__this;
						int localIndex = CS_0024_003C_003E8__locals26.localIndex;
						flag2 = (byte)(int)tP_Elec1_Weapon4.FireOneProjectile((Vector2)(nint)intPtr, CS_0024_003C_003E8__locals26.localIndex) != 0;
						if (!flag2)
						{
							flag3 = false;
							num = intPtr;
							goto IL_059a;
						}
						localIndex = (((bool*)(flag2 ? 1 : 0))->m_value ? 1 : 0);
						nint num2 = (nint)typeof(TP_Elec1_Projectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+130]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ r8_v24 (System.Int32)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ r8_v24 (System.Int32)+C8]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1109 @ rax_v72+FFFFFFF8+v1055 @ rax_v68*8]");
							if (0 == (nint)typeof(TP_Elec1_Projectile))
							{
								obj10 = 1;
								goto IL_0561;
							}
						}
						obj10 = 0;
						goto IL_0561;
					}
					Action action = delegate
					{
						//IL_0164: Expected O, but got I
						//IL_016c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0171: Expected O, but got Unknown
						//IL_017a: Unknown result type (might be due to invalid IL or missing references)
						//IL_017f: Expected O, but got Unknown
						//IL_0196: Unknown result type (might be due to invalid IL or missing references)
						//IL_019b: Expected I4, but got Unknown
						//IL_0792: Expected O, but got I4
						//IL_0291: Expected O, but got I
						//IL_02c0: Expected I4, but got O
						//IL_02ce: Expected I, but got O
						//IL_02de: Expected O, but got I
						//IL_035e: Expected O, but got I4
						//IL_031a: Expected O, but got I
						//IL_0350: Expected O, but got I4
						//IL_04fa: Expected O, but got I
						//IL_06d2: Expected O, but got I
						//IL_072c: Expected O, but got Ref
						//IL_0250->IL0732: Incompatible stack heights: 1 vs 0
						//IL_0272->IL0732: Incompatible stack heights: 1 vs 0
						//IL_03c6->IL0732: Incompatible stack heights: 1 vs 0
						//IL_03f5->IL0732: Incompatible stack heights: 1 vs 0
						//IL_0417->IL0732: Incompatible stack heights: 1 vs 0
						//IL_0452->IL0732: Incompatible stack heights: 1 vs 0
						//IL_0481->IL0732: Incompatible stack heights: 1 vs 0
						//IL_04bd->IL0732: Incompatible stack heights: 1 vs 0
						//IL_051a->IL0732: Incompatible stack heights: 2 vs 0
						//IL_056e->IL0732: Incompatible stack heights: 3 vs 0
						//IL_05a9->IL0732: Incompatible stack heights: 3 vs 0
						//IL_05d8->IL0732: Incompatible stack heights: 3 vs 0
						//IL_05fa->IL0732: Incompatible stack heights: 3 vs 0
						//IL_081d->IL0732: Incompatible stack heights: 3 vs 0
						//IL_0659->IL0732: Incompatible stack heights: 3 vs 0
						//IL_0695->IL0732: Incompatible stack heights: 3 vs 0
						//IL_06f2->IL0732: Incompatible stack heights: 4 vs 0
						//IL_0731->IL0731: Incompatible stack heights: 5 vs 1
						_003C_003Ec__DisplayClass23_0 obj14 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
						TP_Elec1_Projectile tP_Elec1_Projectile;
						TP_Elec1_Projectile tP_Elec1_Projectile2;
						object obj26;
						if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null)
						{
							TP_Elec1_Weapon tP_Elec1_Weapon10 = obj14._003C_003E4__this;
							if ((object)obj14._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon10)._003COwner_003Ek__BackingField != null)
							{
								float2 position4 = ((Equipment)tP_Elec1_Weapon10)._003COwner_003Ek__BackingField.position;
								_003C_003Ec__DisplayClass23_0 obj15 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Elec1_Weapon tP_Elec1_Weapon11 = obj15._003C_003E4__this;
									if ((object)obj15._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon11)._003COwner_003Ek__BackingField != null)
									{
										float2 position5 = ((Equipment)tP_Elec1_Weapon11)._003COwner_003Ek__BackingField.position;
										_003C_003Ec__DisplayClass23_0 obj16 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null)
										{
											TP_Elec1_Weapon tP_Elec1_Weapon12 = obj16._003C_003E4__this;
											if ((object)obj16._003C_003E4__this != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
												nint num8 = default(nint);
												object obj17 = num8 >> 31;
												object obj18 = num8 + obj17;
												object obj19 = obj18 * 2;
												object obj20 = obj18 + obj19;
												int cursorActiveIndex2 = CS_0024_003C_003E8__locals26.localIndex - obj20;
												tP_Elec1_Weapon12._cursorActiveIndex = cursorActiveIndex2;
												_003C_003Ec__DisplayClass23_0 obj21 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
												if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null && (object)obj21._003C_003E4__this != null)
												{
													GameObject gameObject = obj21._003C_003E4__this.gameObject;
													if ((object)gameObject != null)
													{
														bool flag7 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
														object obj22 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
														if (obj22 == null)
														{
															return;
														}
														_003C_003Ec__DisplayClass23_0 obj23 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
														if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null && (object)obj23._003C_003E4__this != null)
														{
															IntPtr intPtr3 = default(IntPtr);
															tP_Elec1_Projectile = (TP_Elec1_Projectile)obj23._003C_003E4__this.FireOneProjectile((Vector2)(nint)intPtr3, CS_0024_003C_003E8__locals26.localIndex);
															bool flag8 = (object)tP_Elec1_Projectile == null;
															tP_Elec1_Projectile2 = null;
															if (!flag8)
															{
																int num9 = (int)tP_Elec1_Projectile;
																nint num10 = (nint)typeof(TP_Elec1_Projectile);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+130]");
																object obj24 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ r8_v11 (System.Int32)+130]");
																nint num11 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+130]");
																if (num11 >= 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ r8_v11 (System.Int32)+C8]");
																	object obj25 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v61+FFFFFFF8+v836 @ rax_v57*8]");
																	if (0 == (nint)typeof(TP_Elec1_Projectile))
																	{
																		obj26 = 1;
																		goto IL_07b4;
																	}
																}
																obj26 = 0;
																goto IL_07b4;
															}
															goto IL_07dc;
														}
													}
												}
											}
										}
									}
								}
							}
						}
						goto IL_0732;
						IL_0732:
						throw new NullReferenceException();
						IL_07b4:
						bool flag9 = obj26 == null;
						tP_Elec1_Projectile2 = null;
						if (!flag9)
						{
							tP_Elec1_Projectile2 = tP_Elec1_Projectile;
						}
						goto IL_07dc;
						IL_07dc:
						if ((object)tP_Elec1_Projectile2 == null || ((UnityEngine.Object)tP_Elec1_Projectile2).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						_003C_003Ec__DisplayClass23_0 obj27 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null)
						{
							TP_Elec1_Weapon tP_Elec1_Weapon13 = obj27._003C_003E4__this;
							if ((object)obj27._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon13)._003COwner_003Ek__BackingField != null)
							{
								float2 position6 = ((Equipment)tP_Elec1_Weapon13)._003COwner_003Ek__BackingField.position;
								_003C_003Ec__DisplayClass23_0 obj28 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Elec1_Weapon tP_Elec1_Weapon14 = obj28._003C_003E4__this;
									if ((object)obj28._003C_003E4__this != null)
									{
										TP_Elec1_Weapon tP_Elec1_Weapon15 = obj28._003C_003E4__this;
										List<float2> cursorOffsets = tP_Elec1_Weapon14._cursorOffsets;
										if (tP_Elec1_Weapon14._cursorOffsets != null)
										{
											int cursorActiveIndex3 = tP_Elec1_Weapon15._cursorActiveIndex;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
											bool flag10 = (nint)cursorActiveIndex3 >= (nint)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
											object obj29 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
											if ((nint)0 != 0)
											{
												int cursorActiveIndex4 = tP_Elec1_Weapon15._cursorActiveIndex;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v32+18]");
												bool flag11 = (nint)cursorActiveIndex4 >= (nint)0;
												_003C_003Ec__DisplayClass23_0 obj30 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
												if ((object)obj30._003C_003E4__this != null)
												{
													float playerFacing2 = obj30._003C_003E4__this.PlayerFacing;
													_003C_003Ec__DisplayClass23_0 obj31 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
													if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null)
													{
														TP_Elec1_Weapon tP_Elec1_Weapon16 = obj31._003C_003E4__this;
														if ((object)obj31._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon16)._003COwner_003Ek__BackingField != null)
														{
															if (((Equipment)tP_Elec1_Weapon16)._003COwner_003Ek__BackingField.flipX)
															{
															}
															_003C_003Ec__DisplayClass23_0 obj32 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
															if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null)
															{
																TP_Elec1_Weapon tP_Elec1_Weapon17 = obj32._003C_003E4__this;
																if ((object)obj32._003C_003E4__this != null)
																{
																	TP_Elec1_Weapon tP_Elec1_Weapon18 = obj32._003C_003E4__this;
																	List<float2> cursorOffsets2 = tP_Elec1_Weapon17._cursorOffsets;
																	if (tP_Elec1_Weapon17._cursorOffsets != null)
																	{
																		int cursorActiveIndex5 = tP_Elec1_Weapon18._cursorActiveIndex;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
																		bool flag12 = (nint)cursorActiveIndex5 >= (nint)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
																		object obj33 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
																		if ((nint)0 != 0)
																		{
																			int cursorActiveIndex6 = tP_Elec1_Weapon18._cursorActiveIndex;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v36+18]");
																			bool flag13 = (nint)cursorActiveIndex6 >= (nint)0;
																			object obj34 = default(object);
																			tP_Elec1_Projectile2.SetTargetPosition((Vector3)(&obj34));
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
						goto IL_0732;
					};
					float num4 = (float)(flag ? 1 : 0) * __repeatInterval;
					float duration = num4 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, action, null, isLooped: false, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Elec1_Weapon._lastShotTimer = lastShotTimer;
					num = (nint)action;
					goto IL_03c8;
					IL_059a:
					if (flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rbx_v8 (System.Boolean)+10]");
						if ((nint)0 != 0)
						{
							TP_Elec1_Weapon tP_Elec1_Weapon5 = _003C_003E4__this;
							float2 position3 = ((Equipment)tP_Elec1_Weapon5)._003COwner_003Ek__BackingField.position;
							TP_Elec1_Weapon tP_Elec1_Weapon6 = _003C_003E4__this;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
							float playerFacing = _003C_003E4__this.PlayerFacing;
							TP_Elec1_Weapon tP_Elec1_Weapon7 = _003C_003E4__this;
							if (((Equipment)tP_Elec1_Weapon7)._003COwner_003Ek__BackingField.flipX)
							{
							}
							TP_Elec1_Weapon tP_Elec1_Weapon8 = _003C_003E4__this;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
							((TP_Elec1_Projectile)flag3).SetTargetPosition((Vector3)(&intPtr2));
							intPtr2 = intPtr;
							num = (nint)(&intPtr2);
						}
					}
					goto IL_03c8;
					IL_03c8:
					flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
					flag5 = __amount > (float)(flag ? 1 : 0);
					flag4 = flag4;
					continue;
					IL_0561:
					bool flag6 = obj10 == null;
					flag3 = false;
					num = (nint)typeof(TP_Elec1_Projectile);
					if (!flag6)
					{
						flag3 = flag2;
						num = (nint)typeof(TP_Elec1_Projectile);
					}
					goto IL_059a;
				}
				while (flag5);
			}
			Action onComplete = _003C_003E9__1;
			TP_Elec1_Weapon tP_Elec1_Weapon9 = _003C_003E4__this;
			if (_003C_003E9__1 != null)
			{
				goto IL_04ce;
			}
			Action action2 = null;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action2).method_ptr = (IntPtr)0;
			((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass23_0._003CFireProjectiles_003Eb__1);
			((Delegate)action2).m_target = this;
			((Delegate)action2).method_code = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj11 = (nint)0 >> 4;
			object obj12 = obj11 & 1;
			nint num6;
			if (obj12 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num6 = unchecked((nint)6447293664L);
					goto IL_061f;
				}
			}
			num6 = ((Delegate)action2).method_ptr;
			((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
			goto IL_061f;
			IL_04ce:
			float num7 = __amount * __repeatInterval;
			float duration2 = num7 * 0.001f;
			Timer cursorResetTimer = Timers.Register(duration2, onComplete, null, isLooped: false, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			tP_Elec1_Weapon9._cursorResetTimer = cursorResetTimer;
			return;
			IL_061f:
			object obj13 = 24;
			((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
			_003C_003E9__1 = action2;
			onComplete = action2;
			goto IL_04ce;
		}

		internal void _003CFireProjectiles_003Eb__1()
		{
			TP_Elec1_Weapon tP_Elec1_Weapon = _003C_003E4__this;
			tP_Elec1_Weapon._cursorActiveIndex = 1;
			TP_Elec1_Weapon tP_Elec1_Weapon2 = _003C_003E4__this;
			PhaserSprite phaserSprite = tP_Elec1_Weapon2._cursor.setAlpha(0.8f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CFireProjectiles_003Eb__2()
		{
			//IL_0164: Expected O, but got I
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected O, but got Unknown
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Expected I4, but got Unknown
			//IL_0792: Expected O, but got I4
			//IL_0291: Expected O, but got I
			//IL_02c0: Expected I4, but got O
			//IL_02ce: Expected I, but got O
			//IL_02de: Expected O, but got I
			//IL_035e: Expected O, but got I4
			//IL_031a: Expected O, but got I
			//IL_0350: Expected O, but got I4
			//IL_04fa: Expected O, but got I
			//IL_06d2: Expected O, but got I
			//IL_072c: Expected O, but got Ref
			//IL_0250->IL0732: Incompatible stack heights: 1 vs 0
			//IL_0272->IL0732: Incompatible stack heights: 1 vs 0
			//IL_03c6->IL0732: Incompatible stack heights: 1 vs 0
			//IL_03f5->IL0732: Incompatible stack heights: 1 vs 0
			//IL_0417->IL0732: Incompatible stack heights: 1 vs 0
			//IL_0452->IL0732: Incompatible stack heights: 1 vs 0
			//IL_0481->IL0732: Incompatible stack heights: 1 vs 0
			//IL_04bd->IL0732: Incompatible stack heights: 1 vs 0
			//IL_051a->IL0732: Incompatible stack heights: 2 vs 0
			//IL_056e->IL0732: Incompatible stack heights: 3 vs 0
			//IL_05a9->IL0732: Incompatible stack heights: 3 vs 0
			//IL_05d8->IL0732: Incompatible stack heights: 3 vs 0
			//IL_05fa->IL0732: Incompatible stack heights: 3 vs 0
			//IL_081d->IL0732: Incompatible stack heights: 3 vs 0
			//IL_0659->IL0732: Incompatible stack heights: 3 vs 0
			//IL_0695->IL0732: Incompatible stack heights: 3 vs 0
			//IL_06f2->IL0732: Incompatible stack heights: 4 vs 0
			//IL_0731->IL0731: Incompatible stack heights: 5 vs 1
			_003C_003Ec__DisplayClass23_0 obj = CS_0024_003C_003E8__locals1;
			TP_Elec1_Projectile tP_Elec1_Projectile;
			TP_Elec1_Projectile tP_Elec1_Projectile2;
			object obj13;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				TP_Elec1_Weapon tP_Elec1_Weapon = obj._003C_003E4__this;
				if ((object)obj._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon)._003COwner_003Ek__BackingField != null)
				{
					float2 position = ((Equipment)tP_Elec1_Weapon)._003COwner_003Ek__BackingField.position;
					_003C_003Ec__DisplayClass23_0 obj2 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Elec1_Weapon tP_Elec1_Weapon2 = obj2._003C_003E4__this;
						if ((object)obj2._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon2)._003COwner_003Ek__BackingField != null)
						{
							float2 position2 = ((Equipment)tP_Elec1_Weapon2)._003COwner_003Ek__BackingField.position;
							_003C_003Ec__DisplayClass23_0 obj3 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								TP_Elec1_Weapon tP_Elec1_Weapon3 = obj3._003C_003E4__this;
								if ((object)obj3._003C_003E4__this != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
									nint num = default(nint);
									object obj4 = num >> 31;
									object obj5 = num + obj4;
									object obj6 = obj5 * 2;
									object obj7 = obj5 + obj6;
									int cursorActiveIndex = localIndex - obj7;
									tP_Elec1_Weapon3._cursorActiveIndex = cursorActiveIndex;
									_003C_003Ec__DisplayClass23_0 obj8 = CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals1 != null && (object)obj8._003C_003E4__this != null)
									{
										GameObject gameObject = obj8._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj9 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj9 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass23_0 obj10 = CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals1 != null && (object)obj10._003C_003E4__this != null)
											{
												IntPtr intPtr = default(IntPtr);
												tP_Elec1_Projectile = (TP_Elec1_Projectile)obj10._003C_003E4__this.FireOneProjectile((Vector2)(nint)intPtr, localIndex);
												bool flag2 = (object)tP_Elec1_Projectile == null;
												tP_Elec1_Projectile2 = null;
												if (!flag2)
												{
													int num2 = (int)tP_Elec1_Projectile;
													nint num3 = (nint)typeof(TP_Elec1_Projectile);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+130]");
													object obj11 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ r8_v11 (System.Int32)+130]");
													nint num4 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+130]");
													if (num4 >= 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ r8_v11 (System.Int32)+C8]");
														object obj12 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v61+FFFFFFF8+v836 @ rax_v57*8]");
														if (0 == (nint)typeof(TP_Elec1_Projectile))
														{
															obj13 = 1;
															goto IL_07b4;
														}
													}
													obj13 = 0;
													goto IL_07b4;
												}
												goto IL_07dc;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_0732;
			IL_0732:
			throw new NullReferenceException();
			IL_07b4:
			bool flag3 = obj13 == null;
			tP_Elec1_Projectile2 = null;
			if (!flag3)
			{
				tP_Elec1_Projectile2 = tP_Elec1_Projectile;
			}
			goto IL_07dc;
			IL_07dc:
			if ((object)tP_Elec1_Projectile2 == null || ((UnityEngine.Object)tP_Elec1_Projectile2).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			_003C_003Ec__DisplayClass23_0 obj14 = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				TP_Elec1_Weapon tP_Elec1_Weapon4 = obj14._003C_003E4__this;
				if ((object)obj14._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon4)._003COwner_003Ek__BackingField != null)
				{
					float2 position3 = ((Equipment)tP_Elec1_Weapon4)._003COwner_003Ek__BackingField.position;
					_003C_003Ec__DisplayClass23_0 obj15 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Elec1_Weapon tP_Elec1_Weapon5 = obj15._003C_003E4__this;
						if ((object)obj15._003C_003E4__this != null)
						{
							TP_Elec1_Weapon tP_Elec1_Weapon6 = obj15._003C_003E4__this;
							List<float2> cursorOffsets = tP_Elec1_Weapon5._cursorOffsets;
							if (tP_Elec1_Weapon5._cursorOffsets != null)
							{
								int cursorActiveIndex2 = tP_Elec1_Weapon6._cursorActiveIndex;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
								bool flag4 = (nint)cursorActiveIndex2 >= (nint)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
								object obj16 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
								if ((nint)0 != 0)
								{
									int cursorActiveIndex3 = tP_Elec1_Weapon6._cursorActiveIndex;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v32+18]");
									bool flag5 = (nint)cursorActiveIndex3 >= (nint)0;
									_003C_003Ec__DisplayClass23_0 obj17 = CS_0024_003C_003E8__locals1;
									if ((object)obj17._003C_003E4__this != null)
									{
										float playerFacing = obj17._003C_003E4__this.PlayerFacing;
										_003C_003Ec__DisplayClass23_0 obj18 = CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals1 != null)
										{
											TP_Elec1_Weapon tP_Elec1_Weapon7 = obj18._003C_003E4__this;
											if ((object)obj18._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon7)._003COwner_003Ek__BackingField != null)
											{
												if (((Equipment)tP_Elec1_Weapon7)._003COwner_003Ek__BackingField.flipX)
												{
												}
												_003C_003Ec__DisplayClass23_0 obj19 = CS_0024_003C_003E8__locals1;
												if (CS_0024_003C_003E8__locals1 != null)
												{
													TP_Elec1_Weapon tP_Elec1_Weapon8 = obj19._003C_003E4__this;
													if ((object)obj19._003C_003E4__this != null)
													{
														TP_Elec1_Weapon tP_Elec1_Weapon9 = obj19._003C_003E4__this;
														List<float2> cursorOffsets2 = tP_Elec1_Weapon8._cursorOffsets;
														if (tP_Elec1_Weapon8._cursorOffsets != null)
														{
															int cursorActiveIndex4 = tP_Elec1_Weapon9._cursorActiveIndex;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
															bool flag6 = (nint)cursorActiveIndex4 >= (nint)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
															object obj20 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
															if ((nint)0 != 0)
															{
																int cursorActiveIndex5 = tP_Elec1_Weapon9._cursorActiveIndex;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v36+18]");
																bool flag7 = (nint)cursorActiveIndex5 >= (nint)0;
																object obj21 = default(object);
																tP_Elec1_Projectile2.SetTargetPosition((Vector3)(&obj21));
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
			goto IL_0732;
		}
	}

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private float _mul;

	private bool _cooldownAffectedByMovement;

	private bool _003CCanFireNormally_003Ek__BackingField;

	private List<float2> _cursorOffsets;

	private List<float> _cursorRotations;

	private int _cursorActiveIndex;

	private Timer _cursorResetTimer;

	private Timer _explosionResetTimer;

	[NonSerialized]
	public static float staticTotalTime;

	protected WeaponType _counterWeaponType;

	protected Weapon _counterWeapon;

	protected SantaJavelinCounterWeapon _counterSet;

	protected bool _hasCounterSet;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	public bool CanFireNormally
	{
		get
		{
			return _003CCanFireNormally_003Ek__BackingField;
		}
		set
		{
			_003CCanFireNormally_003Ek__BackingField = value;
		}
	}

	protected override void Awake()
	{
		//IL_009e: Expected O, but got I
		//IL_00ba: Expected F4, but got I
		base.Awake();
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Elec01");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
		List<float> cursorRotations = _cursorRotations;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v18 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)0 > (nint)1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v18 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			PhaserSprite cursor2 = _cursor;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v19+24]");
			cursor2.angle = 0f;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_02ea->IL022e: Incompatible stack heights: 1 vs 0
		//IL_0311->IL022e: Incompatible stack heights: 1 vs 0
		//IL_00ad->IL022e: Incompatible stack heights: 1 vs 0
		//IL_00cb->IL022e: Incompatible stack heights: 1 vs 0
		//IL_0338->IL022e: Incompatible stack heights: 1 vs 0
		//IL_00f2->IL022e: Incompatible stack heights: 1 vs 0
		//IL_0110->IL022e: Incompatible stack heights: 1 vs 0
		//IL_035f->IL022e: Incompatible stack heights: 1 vs 0
		//IL_0137->IL022e: Incompatible stack heights: 1 vs 0
		//IL_0155->IL022e: Incompatible stack heights: 1 vs 0
		//IL_0386->IL022e: Incompatible stack heights: 1 vs 0
		//IL_017c->IL022e: Incompatible stack heights: 1 vs 0
		//IL_019a->IL022e: Incompatible stack heights: 1 vs 0
		//IL_03ad->IL022e: Incompatible stack heights: 1 vs 0
		//IL_01c1->IL022e: Incompatible stack heights: 1 vs 0
		//IL_01ed->IL022e: Incompatible stack heights: 1 vs 0
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!IsPrimaryWeapon)
		{
			base._003CTotalTime_003Ek__BackingField = staticTotalTime;
		}
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
		ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
			if ((object)arcadeSprite._spriteRenderer != null)
			{
				Sprite sprite = arcadeSprite._spriteRenderer.sprite;
				if ((object)sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
						{
							PhaserScene s_scene2 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)GM.Core != null)
							{
								PhaserScene s_scene3 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene3._renderer != null && (object)GM.Core != null)
								{
									PhaserScene s_scene4 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null && s_scene4._renderer != null && (object)GM.Core != null)
									{
										PhaserScene s_scene5 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null && s_scene5._renderer != null)
										{
											List<float2> list = new List<float2>();
											if (list != null)
											{
												float2 item = default(float2);
												list.Add(item);
												list.Add(item);
												list.Add(item);
												_cursorOffsets = list;
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
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0257: Expected O, but got Ref
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = base.PInterval();
		bool flag = !_cooldownAffectedByMovement;
		float num3 = deltaTime;
		if (!flag)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num4 = frameWalk * 100f;
			float num5 = deltaTime2 * 1000f;
			float num6 = num5 / _mul;
			float num7 = num6 * num4;
			num3 = (base._003CTotalTime_003Ek__BackingField = num7 + base._003CTotalTime_003Ek__BackingField);
		}
		if (!((base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon && _003CCanFireNormally_003Ek__BackingField)
			{
				base.Fire();
			}
		}
		if (IsPrimaryWeapon)
		{
			staticTotalTime = base._003CTotalTime_003Ek__BackingField;
		}
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		float playerFacing = PlayerFacing;
		bool flag2 = num3 > -1f;
		bool flipX2 = flipX;
		if (!flag2)
		{
			flipX2 = (byte)((flipX ? 1u : 0u) ^ 1u) != 0;
		}
		List<float2> cursorOffsets = _cursorOffsets;
		int cursorActiveIndex = _cursorActiveIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v15 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		if ((nint)cursorActiveIndex < (nint)0)
		{
			float playerFacing2 = PlayerFacing;
			if (!((Equipment)this)._003COwner_003Ek__BackingField.flipX)
			{
			}
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			PhaserSprite phaserSprite = _cursor.setPosition(position);
			float playerFacing3 = PlayerFacing;
			List<float> cursorRotations = _cursorRotations;
			if (flipX)
			{
				int cursorActiveIndex2 = _cursorActiveIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v23 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)cursorActiveIndex2 < (nint)0)
				{
					goto IL_0236;
				}
			}
			else
			{
				int cursorActiveIndex3 = _cursorActiveIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v23 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)cursorActiveIndex3 < (nint)0)
				{
					goto IL_0236;
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0236:
		Transform transform = _cursor.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite2 = _cursor.setLocalPosition(localPosition);
		PhaserSprite phaserSprite3 = _cursor.setFlipX(flipX2);
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0084: Invalid comparison between O and F4
		FireProjectiles();
		float num = base.PInterval();
		float num3 = default(float);
		float num2 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num4 = base.PInterval();
			_lastFiringInterval = num3;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		if (IsPrimaryWeapon)
		{
			Fire_FireCounter(skipTriggers);
		}
	}

	public unsafe void FireProjectiles()
	{
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_00fc->IL0218: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals36 = new _003C_003Ec__DisplayClass23_0();
		if (CS_0024_003C_003E8__locals36 != null)
		{
			CS_0024_003C_003E8__locals36._003C_003E4__this = this;
			ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
				if ((object)arcadeSprite._spriteRenderer != null)
				{
					Sprite sprite = arcadeSprite._spriteRenderer.sprite;
					if ((object)sprite != null)
					{
						bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
						Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
						object obj = default(object);
						float num = (CS_0024_003C_003E8__locals36.charHeight = (float)obj * 0.0065f);
						float num2 = base.PAmount();
						CS_0024_003C_003E8__locals36.__amount = num;
						float num3 = base.PDuration();
						float hitBoxDelay = base.HitBoxDelay;
						float num4 = num / hitBoxDelay;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
						float num5 = base.PSpeedRepeatInterval();
						CS_0024_003C_003E8__locals36.__repeatInterval = num4;
						float num6 = base.PHitBoxDelayOverSpeed();
						if (_cursorResetTimer != null)
						{
							_cursorResetTimer.Cancel();
						}
						if (_explosionResetTimer != null)
						{
							_explosionResetTimer.Cancel();
						}
						if ((object)_cursor != null)
						{
							PhaserSprite phaserSprite = _cursor.setAlpha(0.2f);
							object obj2 = default(object);
							if ((nint)obj2 <= 0)
							{
								return;
							}
							object obj3 = this + 400;
							bool flag2 = false;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							do
							{
								Action onComplete = CS_0024_003C_003E8__locals36._003C_003E9__0;
								if (CS_0024_003C_003E8__locals36._003C_003E9__0 == null)
								{
									onComplete = (CS_0024_003C_003E8__locals36._003C_003E9__0 = delegate
									{
										//IL_0545: Invalid comparison between F4 and I4
										//IL_05de: Expected I, but got O
										//IL_05f4: Expected O, but got I
										//IL_05fd: Unknown result type (might be due to invalid IL or missing references)
										//IL_0602: Expected O, but got Unknown
										//IL_04c9: Expected I, but got O
										//IL_0043: Unknown result type (might be due to invalid IL or missing references)
										//IL_0048: Expected O, but got Unknown
										//IL_0628: Expected O, but got I4
										//IL_063f: Expected I, but got I8
										//IL_04a5: Expected I, but got I8
										//IL_03c3: Expected I, but got O
										//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
										//IL_00b1: Expected O, but got Unknown
										//IL_03e0: Invalid comparison between F4 and I4
										//IL_00ce: Expected O, but got I
										//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
										//IL_00db: Expected O, but got Unknown
										//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
										//IL_00e9: Expected O, but got Unknown
										//IL_0103: Unknown result type (might be due to invalid IL or missing references)
										//IL_0108: Expected I4, but got Unknown
										//IL_014b: Expected O, but got I
										//IL_014f: Expected I4, but got O
										//IL_018e: Expected I, but got O
										//IL_019e: Expected O, but got I
										//IL_021e: Expected O, but got I4
										//IL_0587: Expected I, but got O
										//IL_01da: Expected O, but got I
										//IL_0239: Expected I, but got O
										//IL_0210: Expected O, but got I4
										//IL_031e: Expected O, but got Ref
										//IL_031e: Expected O, but got I4
										bool flag4 = default(bool);
										MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
										int repeat2 = default(int);
										TimerType type2 = default(TimerType);
										if (CS_0024_003C_003E8__locals36.__amount > 0f)
										{
											bool flag3 = false;
											nint num10 = default(nint);
											object obj6 = default(object);
											IntPtr intPtr = default(IntPtr);
											IntPtr intPtr2 = default(IntPtr);
											bool flag7;
											do
											{
												_003C_003Ec__DisplayClass23_1 CS_0024_003C_003E8__locals57 = new _003C_003Ec__DisplayClass23_1();
												CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals36;
												CS_0024_003C_003E8__locals57.localIndex = (flag3 ? 1 : 0);
												TP_Elec1_Weapon tP_Elec1_Weapon = CS_0024_003C_003E8__locals36._003C_003E4__this;
												object obj4 = flag3 * CS_0024_003C_003E8__locals36.__repeatInterval;
												if ((nint)obj4 > 0)
												{
													Action action = delegate
													{
														//IL_0164: Expected O, but got I
														//IL_016c: Unknown result type (might be due to invalid IL or missing references)
														//IL_0171: Expected O, but got Unknown
														//IL_017a: Unknown result type (might be due to invalid IL or missing references)
														//IL_017f: Expected O, but got Unknown
														//IL_0196: Unknown result type (might be due to invalid IL or missing references)
														//IL_019b: Expected I4, but got Unknown
														//IL_0792: Expected O, but got I4
														//IL_0291: Expected O, but got I
														//IL_02c0: Expected I4, but got O
														//IL_02ce: Expected I, but got O
														//IL_02de: Expected O, but got I
														//IL_035e: Expected O, but got I4
														//IL_031a: Expected O, but got I
														//IL_0350: Expected O, but got I4
														//IL_04fa: Expected O, but got I
														//IL_06d2: Expected O, but got I
														//IL_072c: Expected O, but got Ref
														//IL_0250->IL0732: Incompatible stack heights: 1 vs 0
														//IL_0272->IL0732: Incompatible stack heights: 1 vs 0
														//IL_03c6->IL0732: Incompatible stack heights: 1 vs 0
														//IL_03f5->IL0732: Incompatible stack heights: 1 vs 0
														//IL_0417->IL0732: Incompatible stack heights: 1 vs 0
														//IL_0452->IL0732: Incompatible stack heights: 1 vs 0
														//IL_0481->IL0732: Incompatible stack heights: 1 vs 0
														//IL_04bd->IL0732: Incompatible stack heights: 1 vs 0
														//IL_051a->IL0732: Incompatible stack heights: 2 vs 0
														//IL_056e->IL0732: Incompatible stack heights: 3 vs 0
														//IL_05a9->IL0732: Incompatible stack heights: 3 vs 0
														//IL_05d8->IL0732: Incompatible stack heights: 3 vs 0
														//IL_05fa->IL0732: Incompatible stack heights: 3 vs 0
														//IL_081d->IL0732: Incompatible stack heights: 3 vs 0
														//IL_0659->IL0732: Incompatible stack heights: 3 vs 0
														//IL_0695->IL0732: Incompatible stack heights: 3 vs 0
														//IL_06f2->IL0732: Incompatible stack heights: 4 vs 0
														//IL_0731->IL0731: Incompatible stack heights: 5 vs 1
														_003C_003Ec__DisplayClass23_0 obj17 = CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1;
														TP_Elec1_Projectile tP_Elec1_Projectile;
														TP_Elec1_Projectile tP_Elec1_Projectile2;
														object obj29;
														if (CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1 != null)
														{
															TP_Elec1_Weapon tP_Elec1_Weapon10 = obj17._003C_003E4__this;
															if ((object)obj17._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon10)._003COwner_003Ek__BackingField != null)
															{
																float2 position4 = ((Equipment)tP_Elec1_Weapon10)._003COwner_003Ek__BackingField.position;
																_003C_003Ec__DisplayClass23_0 obj18 = CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1;
																if (CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1 != null)
																{
																	TP_Elec1_Weapon tP_Elec1_Weapon11 = obj18._003C_003E4__this;
																	if ((object)obj18._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon11)._003COwner_003Ek__BackingField != null)
																	{
																		float2 position5 = ((Equipment)tP_Elec1_Weapon11)._003COwner_003Ek__BackingField.position;
																		_003C_003Ec__DisplayClass23_0 obj19 = CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1;
																		if (CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1 != null)
																		{
																			TP_Elec1_Weapon tP_Elec1_Weapon12 = obj19._003C_003E4__this;
																			if ((object)obj19._003C_003E4__this != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
																				nint num16 = default(nint);
																				object obj20 = num16 >> 31;
																				object obj21 = num16 + obj20;
																				object obj22 = obj21 * 2;
																				object obj23 = obj21 + obj22;
																				int cursorActiveIndex2 = CS_0024_003C_003E8__locals57.localIndex - obj23;
																				tP_Elec1_Weapon12._cursorActiveIndex = cursorActiveIndex2;
																				_003C_003Ec__DisplayClass23_0 obj24 = CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1;
																				if (CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1 != null && (object)obj24._003C_003E4__this != null)
																				{
																					GameObject gameObject = obj24._003C_003E4__this.gameObject;
																					if ((object)gameObject != null)
																					{
																						bool flag9 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
																						object obj25 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
																						if (obj25 == null)
																						{
																							return;
																						}
																						_003C_003Ec__DisplayClass23_0 obj26 = CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1;
																						if (CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1 != null && (object)obj26._003C_003E4__this != null)
																						{
																							IntPtr intPtr3 = default(IntPtr);
																							tP_Elec1_Projectile = (TP_Elec1_Projectile)obj26._003C_003E4__this.FireOneProjectile((Vector2)(nint)intPtr3, CS_0024_003C_003E8__locals57.localIndex);
																							bool flag10 = (object)tP_Elec1_Projectile == null;
																							tP_Elec1_Projectile2 = null;
																							if (!flag10)
																							{
																								int num17 = (int)tP_Elec1_Projectile;
																								nint num18 = (nint)typeof(TP_Elec1_Projectile);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+130]");
																								object obj27 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ r8_v11 (System.Int32)+130]");
																								nint num19 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+130]");
																								if (num19 >= 0)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ r8_v11 (System.Int32)+C8]");
																									object obj28 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v61+FFFFFFF8+v836 @ rax_v57*8]");
																									if (0 == (nint)typeof(TP_Elec1_Projectile))
																									{
																										obj29 = 1;
																										goto IL_07b4;
																									}
																								}
																								obj29 = 0;
																								goto IL_07b4;
																							}
																							goto IL_07dc;
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
														goto IL_0732;
														IL_0732:
														throw new NullReferenceException();
														IL_07b4:
														bool flag11 = obj29 == null;
														tP_Elec1_Projectile2 = null;
														if (!flag11)
														{
															tP_Elec1_Projectile2 = tP_Elec1_Projectile;
														}
														goto IL_07dc;
														IL_07dc:
														if ((object)tP_Elec1_Projectile2 == null || ((UnityEngine.Object)tP_Elec1_Projectile2).m_CachedPtr == (IntPtr)0)
														{
															return;
														}
														_003C_003Ec__DisplayClass23_0 obj30 = CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1;
														if (CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1 != null)
														{
															TP_Elec1_Weapon tP_Elec1_Weapon13 = obj30._003C_003E4__this;
															if ((object)obj30._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon13)._003COwner_003Ek__BackingField != null)
															{
																float2 position6 = ((Equipment)tP_Elec1_Weapon13)._003COwner_003Ek__BackingField.position;
																_003C_003Ec__DisplayClass23_0 obj31 = CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1;
																if (CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1 != null)
																{
																	TP_Elec1_Weapon tP_Elec1_Weapon14 = obj31._003C_003E4__this;
																	if ((object)obj31._003C_003E4__this != null)
																	{
																		TP_Elec1_Weapon tP_Elec1_Weapon15 = obj31._003C_003E4__this;
																		List<float2> cursorOffsets = tP_Elec1_Weapon14._cursorOffsets;
																		if (tP_Elec1_Weapon14._cursorOffsets != null)
																		{
																			int cursorActiveIndex3 = tP_Elec1_Weapon15._cursorActiveIndex;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
																			bool flag12 = (nint)cursorActiveIndex3 >= (nint)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
																			object obj32 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
																			if ((nint)0 != 0)
																			{
																				int cursorActiveIndex4 = tP_Elec1_Weapon15._cursorActiveIndex;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v32+18]");
																				bool flag13 = (nint)cursorActiveIndex4 >= (nint)0;
																				_003C_003Ec__DisplayClass23_0 obj33 = CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1;
																				if ((object)obj33._003C_003E4__this != null)
																				{
																					float playerFacing2 = obj33._003C_003E4__this.PlayerFacing;
																					_003C_003Ec__DisplayClass23_0 obj34 = CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1;
																					if (CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1 != null)
																					{
																						TP_Elec1_Weapon tP_Elec1_Weapon16 = obj34._003C_003E4__this;
																						if ((object)obj34._003C_003E4__this != null && (object)((Equipment)tP_Elec1_Weapon16)._003COwner_003Ek__BackingField != null)
																						{
																							if (((Equipment)tP_Elec1_Weapon16)._003COwner_003Ek__BackingField.flipX)
																							{
																							}
																							_003C_003Ec__DisplayClass23_0 obj35 = CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1;
																							if (CS_0024_003C_003E8__locals57.CS_0024_003C_003E8__locals1 != null)
																							{
																								TP_Elec1_Weapon tP_Elec1_Weapon17 = obj35._003C_003E4__this;
																								if ((object)obj35._003C_003E4__this != null)
																								{
																									TP_Elec1_Weapon tP_Elec1_Weapon18 = obj35._003C_003E4__this;
																									List<float2> cursorOffsets2 = tP_Elec1_Weapon17._cursorOffsets;
																									if (tP_Elec1_Weapon17._cursorOffsets != null)
																									{
																										int cursorActiveIndex5 = tP_Elec1_Weapon18._cursorActiveIndex;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
																										bool flag14 = (nint)cursorActiveIndex5 >= (nint)0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
																										object obj36 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
																										if ((nint)0 != 0)
																										{
																											int cursorActiveIndex6 = tP_Elec1_Weapon18._cursorActiveIndex;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v36+18]");
																											bool flag15 = (nint)cursorActiveIndex6 >= (nint)0;
																											object obj37 = default(object);
																											tP_Elec1_Projectile2.SetTargetPosition((Vector3)(&obj37));
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
														goto IL_0732;
													};
													float num9 = (float)(flag3 ? 1 : 0) * CS_0024_003C_003E8__locals36.__repeatInterval;
													float duration2 = num9 * 0.001f;
													Timer lastShotTimer = Timers.Register(duration2, action, null, isLooped: false, flag4, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
													tP_Elec1_Weapon._lastShotTimer = lastShotTimer;
													num10 = (nint)action;
													goto IL_03c8;
												}
												float2 position = ((Equipment)tP_Elec1_Weapon)._003COwner_003Ek__BackingField.position;
												TP_Elec1_Weapon tP_Elec1_Weapon2 = CS_0024_003C_003E8__locals36._003C_003E4__this;
												float2 position2 = ((Equipment)tP_Elec1_Weapon2)._003COwner_003Ek__BackingField.position;
												TP_Elec1_Weapon tP_Elec1_Weapon3 = CS_0024_003C_003E8__locals36._003C_003E4__this;
												object obj5 = obj6 + CS_0024_003C_003E8__locals36.charHeight;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
												object obj7 = num10 >> 31;
												object obj8 = num10 + obj7;
												object obj9 = obj8 * 2;
												object obj10 = obj8 + obj9;
												int cursorActiveIndex = CS_0024_003C_003E8__locals57.localIndex - obj10;
												tP_Elec1_Weapon3._cursorActiveIndex = cursorActiveIndex;
												TP_Elec1_Weapon tP_Elec1_Weapon4 = CS_0024_003C_003E8__locals36._003C_003E4__this;
												int localIndex = CS_0024_003C_003E8__locals57.localIndex;
												bool flag5 = (byte)(int)tP_Elec1_Weapon4.FireOneProjectile((Vector2)(nint)intPtr, CS_0024_003C_003E8__locals57.localIndex) != 0;
												object obj13;
												if (flag5)
												{
													localIndex = (((bool*)(flag5 ? 1 : 0))->m_value ? 1 : 0);
													nint num11 = (nint)typeof(TP_Elec1_Projectile);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+130]");
													object obj11 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ r8_v24 (System.Int32)+130]");
													nint num12 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+130]");
													if (num12 >= 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ r8_v24 (System.Int32)+C8]");
														object obj12 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1109 @ rax_v72+FFFFFFF8+v1055 @ rax_v68*8]");
														if (0 == (nint)typeof(TP_Elec1_Projectile))
														{
															obj13 = 1;
															goto IL_0561;
														}
													}
													obj13 = 0;
													goto IL_0561;
												}
												bool flag6 = false;
												num10 = intPtr;
												goto IL_059a;
												IL_059a:
												if (flag6)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rbx_v8 (System.Boolean)+10]");
													if ((nint)0 != 0)
													{
														TP_Elec1_Weapon tP_Elec1_Weapon5 = CS_0024_003C_003E8__locals36._003C_003E4__this;
														float2 position3 = ((Equipment)tP_Elec1_Weapon5)._003COwner_003Ek__BackingField.position;
														TP_Elec1_Weapon tP_Elec1_Weapon6 = CS_0024_003C_003E8__locals36._003C_003E4__this;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
														float playerFacing = CS_0024_003C_003E8__locals36._003C_003E4__this.PlayerFacing;
														TP_Elec1_Weapon tP_Elec1_Weapon7 = CS_0024_003C_003E8__locals36._003C_003E4__this;
														if (((Equipment)tP_Elec1_Weapon7)._003COwner_003Ek__BackingField.flipX)
														{
														}
														TP_Elec1_Weapon tP_Elec1_Weapon8 = CS_0024_003C_003E8__locals36._003C_003E4__this;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
														((TP_Elec1_Projectile)flag6).SetTargetPosition((Vector3)(&intPtr2));
														intPtr2 = intPtr;
														num10 = (nint)(&intPtr2);
													}
												}
												goto IL_03c8;
												IL_03c8:
												flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
												flag7 = CS_0024_003C_003E8__locals36.__amount > (float)(flag3 ? 1 : 0);
												flag4 = flag4;
												continue;
												IL_0561:
												bool flag8 = obj13 == null;
												flag6 = false;
												num10 = (nint)typeof(TP_Elec1_Projectile);
												if (!flag8)
												{
													flag6 = flag5;
													num10 = (nint)typeof(TP_Elec1_Projectile);
												}
												goto IL_059a;
											}
											while (flag7);
										}
										Action onComplete2 = CS_0024_003C_003E8__locals36._003C_003E9__1;
										TP_Elec1_Weapon tP_Elec1_Weapon9 = CS_0024_003C_003E8__locals36._003C_003E4__this;
										if (CS_0024_003C_003E8__locals36._003C_003E9__1 != null)
										{
											goto IL_04ce;
										}
										Action action2 = null;
										nint num13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r10_v4 (Il2CppMethodInfo)+8]");
										((Delegate)action2).method_ptr = (IntPtr)0;
										((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass23_0._003CFireProjectiles_003Eb__1);
										((Delegate)action2).m_target = CS_0024_003C_003E8__locals36;
										((Delegate)action2).method_code = (IntPtr)action2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r10_v4 (Il2CppMethodInfo)+4C]");
										object obj14 = (nint)0 >> 4;
										object obj15 = obj14 & 1;
										nint num14;
										if (obj15 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r10_v4 (Il2CppMethodInfo)+52]");
											if ((nint)0 == 0)
											{
												num14 = unchecked((nint)6447293664L);
												goto IL_061f;
											}
										}
										num14 = ((Delegate)action2).method_ptr;
										((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
										goto IL_061f;
										IL_04ce:
										float num15 = CS_0024_003C_003E8__locals36.__amount * CS_0024_003C_003E8__locals36.__repeatInterval;
										float duration3 = num15 * 0.001f;
										Timer cursorResetTimer = Timers.Register(duration3, onComplete2, null, isLooped: false, flag4, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
										tP_Elec1_Weapon9._cursorResetTimer = cursorResetTimer;
										return;
										IL_061f:
										object obj16 = 24;
										((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
										CS_0024_003C_003E8__locals36._003C_003E9__1 = action2;
										onComplete2 = action2;
										goto IL_04ce;
									});
								}
								float num7 = (float)(flag2 ? 1 : 0) * num4;
								float num8 = num7 + 1f;
								float duration = num8 * 0.001f;
								Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								obj3 = timer;
								flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
							}
							while ((flag2 ? 1 : 0) < (nint)obj2);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected void Fire_FireCounter(bool skipTriggers = false)
	{
		if (!_hasCounterSet)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				_hasCounterSet = true;
				_counterWeapon = weaponByType;
				_counterWeapon.Cleanup();
				GameObject gameObject = _counterWeapon.gameObject;
				gameObject.SetActive(value: true);
			}
		}
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			_counterWeapon.Fire(skipTriggers);
		}
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		if (!IsPrimaryWeapon)
		{
			return;
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 <= -1)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType == null || ((UnityEngine.Object)weaponByType).m_CachedPtr == (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			bool allowDuplicates = default(bool);
			Weapon weapon = (_counterWeapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates));
			while (((Equipment)weapon)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
			{
				bool flag = weapon.LevelUp(skipFire: true);
			}
			GM.Core.SetSeenWeapon(_counterWeaponType);
		}
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			if (core._stage.IsCharacterNearYourPlayer(((Equipment)this)._003COwner_003Ek__BackingField))
			{
				BulletPool bulletPool = default(BulletPool);
				bool flag = bulletPool != null;
				BulletPool bulletPool2 = bulletPool;
				if (!flag)
				{
					bulletPool2 = _projectilePool;
					if (_projectilePool == null)
					{
						goto IL_0160;
					}
				}
				float2 pos2 = default(float2);
				Projectile projectile = bulletPool2.SpawnAt(pos2, this, index);
				if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
				{
					BaseBody body = projectile.body;
					if (projectile.body != null)
					{
						if (body._transform == null)
						{
							goto IL_0160;
						}
						body._transform.ForceFullReupdate();
					}
				}
				return projectile;
			}
			return null;
		}
		goto IL_0160;
		IL_0160:
		return (Projectile)(object)new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _cursor.setVisible(visible);
	}

	public override void Cleanup()
	{
		if (_cursorResetTimer != null)
		{
			_cursorResetTimer.Cancel();
		}
		if (_explosionResetTimer != null)
		{
			_explosionResetTimer.Cancel();
		}
		base.Cleanup();
	}

	public TP_Elec1_Weapon()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_01e1: Expected O, but got I
		//IL_00f0: Expected O, but got I
		//IL_0209: Expected O, but got I
		//IL_015e: Expected O, but got I
		_mul = 333.33334f;
		_003CCanFireNormally_003Ek__BackingField = true;
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(-135f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 3272015872L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v5+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(-90f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 3266576384L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(-45f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 3258187776L;
		}
		_cursorRotations = list;
		_cursorActiveIndex = 1;
		_counterWeaponType = WeaponType.TP_ELEC1_COUNTER;
		base._002Ector();
	}
}
