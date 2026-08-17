using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Wind2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__10_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__10_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1459;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public float __repeatInterval;

		public TP_Wind2_Weapon _003C_003E4__this;

		public bool __flip;

		public bool __horizontalMirror;

		public float __amount;
	}

	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public int invert;

		public _003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_02ef: Invalid comparison between F4 and I4
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Expected O, but got Unknown
			//IL_00a9: Expected I, but got O
			//IL_00bf: Expected O, but got I
			//IL_00fe: Expected I, but got O
			//IL_0106: Expected I, but got O
			//IL_0199: Expected O, but got I4
			//IL_0153: Expected O, but got I
			//IL_018b: Expected O, but got I4
			_003C_003Ec__DisplayClass14_0 obj = CS_0024_003C_003E8__locals1;
			bool flag = false;
			bool flag2 = false;
			TP_Wind2_Projectile tP_Wind2_Projectile = default(TP_Wind2_Projectile);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			for (bool flag3 = false; obj.__amount > (float)(flag3 ? 1 : 0); obj = CS_0024_003C_003E8__locals1, flag = (byte)((flag ? 1u : 0u) + 1u) != 0, flag2 = (byte)((flag2 ? 1u : 0u) + 2u) != 0, flag3 = flag)
			{
				_003C_003Ec__DisplayClass14_2 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass14_2();
				CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2 = this;
				int localIndex = invert + (flag2 ? 1 : 0);
				CS_0024_003C_003E8__locals11.localIndex = localIndex;
				_003C_003Ec__DisplayClass14_0 obj2 = CS_0024_003C_003E8__locals1;
				object obj3 = flag * obj2.__repeatInterval;
				object obj5;
				if ((nint)obj3 <= 0)
				{
					nint num = (nint)obj2._003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v6 (Il2CppMethodInfo)+160]");
					float2 position = ((PhaserSprite)0).position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					if ((object)tP_Wind2_Projectile == null)
					{
						continue;
					}
					nint num2 = (nint)typeof(TP_Wind2_Projectile);
					nint num3 = (nint)tP_Wind2_Projectile;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
					if (num5 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rcx_v22+FFFFFFF8+v549 @ rcx_v16 (Il2CppMethodInfo)*8]");
						if (0 == (nint)typeof(TP_Wind2_Projectile))
						{
							obj5 = 1;
							goto IL_02c0;
						}
					}
					obj5 = 0;
					goto IL_02c0;
				}
				TP_Wind2_Weapon tP_Wind2_Weapon = obj2._003C_003E4__this;
				Action onComplete = delegate
				{
					//IL_03a5: Expected O, but got I4
					//IL_0222: Expected I, but got O
					//IL_022a: Expected I, but got O
					//IL_023a: Expected O, but got I
					//IL_02ba: Expected O, but got I4
					//IL_0276: Expected O, but got I
					//IL_02ac: Expected O, but got I4
					//IL_00b3->IL0345: Incompatible stack heights: 1 vs 0
					//IL_00e2->IL0345: Incompatible stack heights: 1 vs 0
					//IL_0111->IL0345: Incompatible stack heights: 1 vs 0
					//IL_0133->IL0345: Incompatible stack heights: 1 vs 0
					//IL_016e->IL0345: Incompatible stack heights: 1 vs 0
					//IL_019d->IL0345: Incompatible stack heights: 1 vs 0
					//IL_01cc->IL0345: Incompatible stack heights: 1 vs 0
					//IL_02f0->IL0345: Incompatible stack heights: 1 vs 0
					//IL_031f->IL0345: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass14_1 obj7 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2;
					TP_Wind2_Projectile tP_Wind2_Projectile3;
					object obj16;
					if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2 != null)
					{
						_003C_003Ec__DisplayClass14_0 obj8 = obj7.CS_0024_003C_003E8__locals1;
						if (obj7.CS_0024_003C_003E8__locals1 != null && (object)obj8._003C_003E4__this != null)
						{
							GameObject gameObject = obj8._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj9 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj9 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass14_1 obj10 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2;
								if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2 != null)
								{
									_003C_003Ec__DisplayClass14_0 obj11 = obj10.CS_0024_003C_003E8__locals1;
									if (obj10.CS_0024_003C_003E8__locals1 != null)
									{
										TP_Wind2_Weapon tP_Wind2_Weapon2 = obj11._003C_003E4__this;
										if ((object)obj11._003C_003E4__this != null && (object)tP_Wind2_Weapon2._cursor != null)
										{
											float2 position2 = tP_Wind2_Weapon2._cursor.position;
											_003C_003Ec__DisplayClass14_1 obj12 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2;
											if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2 != null)
											{
												_003C_003Ec__DisplayClass14_0 obj13 = obj12.CS_0024_003C_003E8__locals1;
												if (obj12.CS_0024_003C_003E8__locals1 != null)
												{
													TP_Wind2_Weapon tP_Wind2_Weapon3 = obj13._003C_003E4__this;
													if ((object)obj13._003C_003E4__this != null)
													{
														Vector2 pos = default(Vector2);
														tP_Wind2_Projectile3 = (TP_Wind2_Projectile)obj11._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals11.localIndex, tP_Wind2_Weapon3._targetTransform);
														if ((object)tP_Wind2_Projectile3 == null)
														{
															return;
														}
														nint num7 = (nint)typeof(TP_Wind2_Projectile);
														nint num8 = (nint)tP_Wind2_Projectile3;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
														object obj14 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
														nint num9 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
														if (num9 >= 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+C8]");
															object obj15 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rcx_v21+FFFFFFF8+v479 @ rcx_v17*8]");
															if (0 == (nint)typeof(TP_Wind2_Projectile))
															{
																obj16 = 1;
																goto IL_03c2;
															}
														}
														obj16 = 0;
														goto IL_03c2;
													}
												}
											}
										}
									}
								}
							}
						}
					}
					goto IL_0345;
					IL_0345:
					throw new NullReferenceException();
					IL_03c2:
					bool flag6 = obj16 == null;
					TP_Wind2_Projectile tP_Wind2_Projectile4 = null;
					if (!flag6)
					{
						tP_Wind2_Projectile4 = tP_Wind2_Projectile3;
					}
					if ((object)tP_Wind2_Projectile4 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass14_1 obj17 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2;
					if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2 != null)
					{
						_003C_003Ec__DisplayClass14_0 obj18 = obj17.CS_0024_003C_003E8__locals1;
						if (obj17.CS_0024_003C_003E8__locals1 != null)
						{
							tP_Wind2_Projectile4.SetFlip(obj18.__flip, obj18.__horizontalMirror);
							return;
						}
					}
					goto IL_0345;
				};
				float num6 = (float)(flag ? 1 : 0) * obj2.__repeatInterval;
				float duration = num6 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				tP_Wind2_Weapon._lastShotTimer = lastShotTimer;
				continue;
				IL_02c0:
				bool flag4 = obj5 == null;
				TP_Wind2_Projectile tP_Wind2_Projectile2 = null;
				if (!flag4)
				{
					tP_Wind2_Projectile2 = tP_Wind2_Projectile;
				}
				if ((object)tP_Wind2_Projectile2 != null)
				{
					_003C_003Ec__DisplayClass14_0 obj6 = CS_0024_003C_003E8__locals1;
					tP_Wind2_Projectile2.SetFlip(obj6.__flip, obj6.__horizontalMirror);
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_2
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals2;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_03a5: Expected O, but got I4
			//IL_0222: Expected I, but got O
			//IL_022a: Expected I, but got O
			//IL_023a: Expected O, but got I
			//IL_02ba: Expected O, but got I4
			//IL_0276: Expected O, but got I
			//IL_02ac: Expected O, but got I4
			//IL_00b3->IL0345: Incompatible stack heights: 1 vs 0
			//IL_00e2->IL0345: Incompatible stack heights: 1 vs 0
			//IL_0111->IL0345: Incompatible stack heights: 1 vs 0
			//IL_0133->IL0345: Incompatible stack heights: 1 vs 0
			//IL_016e->IL0345: Incompatible stack heights: 1 vs 0
			//IL_019d->IL0345: Incompatible stack heights: 1 vs 0
			//IL_01cc->IL0345: Incompatible stack heights: 1 vs 0
			//IL_02f0->IL0345: Incompatible stack heights: 1 vs 0
			//IL_031f->IL0345: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass14_1 obj = CS_0024_003C_003E8__locals2;
			TP_Wind2_Projectile tP_Wind2_Projectile;
			object obj10;
			if (CS_0024_003C_003E8__locals2 != null)
			{
				_003C_003Ec__DisplayClass14_0 obj2 = obj.CS_0024_003C_003E8__locals1;
				if (obj.CS_0024_003C_003E8__locals1 != null && (object)obj2._003C_003E4__this != null)
				{
					GameObject gameObject = obj2._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj3 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass14_1 obj4 = CS_0024_003C_003E8__locals2;
						if (CS_0024_003C_003E8__locals2 != null)
						{
							_003C_003Ec__DisplayClass14_0 obj5 = obj4.CS_0024_003C_003E8__locals1;
							if (obj4.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Wind2_Weapon tP_Wind2_Weapon = obj5._003C_003E4__this;
								if ((object)obj5._003C_003E4__this != null && (object)tP_Wind2_Weapon._cursor != null)
								{
									float2 position = tP_Wind2_Weapon._cursor.position;
									_003C_003Ec__DisplayClass14_1 obj6 = CS_0024_003C_003E8__locals2;
									if (CS_0024_003C_003E8__locals2 != null)
									{
										_003C_003Ec__DisplayClass14_0 obj7 = obj6.CS_0024_003C_003E8__locals1;
										if (obj6.CS_0024_003C_003E8__locals1 != null)
										{
											TP_Wind2_Weapon tP_Wind2_Weapon2 = obj7._003C_003E4__this;
											if ((object)obj7._003C_003E4__this != null)
											{
												Vector2 pos = default(Vector2);
												tP_Wind2_Projectile = (TP_Wind2_Projectile)obj5._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Wind2_Weapon2._targetTransform);
												if ((object)tP_Wind2_Projectile == null)
												{
													return;
												}
												nint num = (nint)typeof(TP_Wind2_Projectile);
												nint num2 = (nint)tP_Wind2_Projectile;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
												object obj8 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
												nint num3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
												if (num3 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+C8]");
													object obj9 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rcx_v21+FFFFFFF8+v479 @ rcx_v17*8]");
													if (0 == (nint)typeof(TP_Wind2_Projectile))
													{
														obj10 = 1;
														goto IL_03c2;
													}
												}
												obj10 = 0;
												goto IL_03c2;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_0345;
			IL_0345:
			throw new NullReferenceException();
			IL_03c2:
			bool flag2 = obj10 == null;
			TP_Wind2_Projectile tP_Wind2_Projectile2 = null;
			if (!flag2)
			{
				tP_Wind2_Projectile2 = tP_Wind2_Projectile;
			}
			if ((object)tP_Wind2_Projectile2 == null)
			{
				return;
			}
			_003C_003Ec__DisplayClass14_1 obj11 = CS_0024_003C_003E8__locals2;
			if (CS_0024_003C_003E8__locals2 != null)
			{
				_003C_003Ec__DisplayClass14_0 obj12 = obj11.CS_0024_003C_003E8__locals1;
				if (obj11.CS_0024_003C_003E8__locals1 != null)
				{
					tP_Wind2_Projectile2.SetFlip(obj12.__flip, obj12.__horizontalMirror);
					return;
				}
			}
			goto IL_0345;
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_3
	{
		public bool __horizontalMirror2;

		public _003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals3;
	}

	private sealed class _003C_003Ec__DisplayClass14_4
	{
		public int invert;

		public _003C_003Ec__DisplayClass14_3 CS_0024_003C_003E8__locals4;

		internal void _003CFireProjectiles_003Eb__2()
		{
			//IL_0032: Invalid comparison between F4 and I4
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_0130: Expected I, but got O
			//IL_0138: Expected I, but got O
			//IL_0148: Expected O, but got I
			//IL_01c8: Expected O, but got I4
			//IL_0184: Expected O, but got I
			//IL_01ba: Expected O, but got I4
			_003C_003Ec__DisplayClass14_3 obj = CS_0024_003C_003E8__locals4;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			TP_Wind2_Projectile tP_Wind2_Projectile = default(TP_Wind2_Projectile);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				_003C_003Ec__DisplayClass14_0 obj2 = obj.CS_0024_003C_003E8__locals3;
				if (!(obj2.__amount > (float)(flag2 ? 1 : 0)))
				{
					break;
				}
				_003C_003Ec__DisplayClass14_5 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass14_5();
				CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals5 = this;
				int localIndex = invert + (flag3 ? 1 : 0);
				CS_0024_003C_003E8__locals12.localIndex = localIndex;
				_003C_003Ec__DisplayClass14_3 obj3 = CS_0024_003C_003E8__locals4;
				_003C_003Ec__DisplayClass14_0 obj4 = obj3.CS_0024_003C_003E8__locals3;
				object obj5 = flag * obj4.__repeatInterval;
				object obj8;
				if ((nint)obj5 <= 0)
				{
					TP_Wind2_Weapon tP_Wind2_Weapon = obj4._003C_003E4__this;
					float2 position = tP_Wind2_Weapon._cursor.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					if ((object)tP_Wind2_Projectile == null)
					{
						goto IL_02b7;
					}
					nint num = (nint)typeof(TP_Wind2_Projectile);
					nint num2 = (nint)tP_Wind2_Projectile;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+C8]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rcx_v22+FFFFFFF8+v586 @ rcx_v16*8]");
						if (0 == (nint)typeof(TP_Wind2_Projectile))
						{
							obj8 = 1;
							goto IL_02ff;
						}
					}
					obj8 = 0;
					goto IL_02ff;
				}
				TP_Wind2_Weapon tP_Wind2_Weapon2 = obj4._003C_003E4__this;
				Action onComplete = delegate
				{
					//IL_0485: Expected O, but got I4
					//IL_02d3: Expected I, but got O
					//IL_02db: Expected I, but got O
					//IL_02eb: Expected O, but got I
					//IL_036b: Expected O, but got I4
					//IL_0327: Expected O, but got I
					//IL_035d: Expected O, but got I4
					//IL_00e2->IL0425: Incompatible stack heights: 1 vs 0
					//IL_0111->IL0425: Incompatible stack heights: 1 vs 0
					//IL_0140->IL0425: Incompatible stack heights: 1 vs 0
					//IL_0193->IL0425: Incompatible stack heights: 1 vs 0
					//IL_01b5->IL0425: Incompatible stack heights: 1 vs 0
					//IL_01f0->IL0425: Incompatible stack heights: 1 vs 0
					//IL_021f->IL0425: Incompatible stack heights: 1 vs 0
					//IL_024e->IL0425: Incompatible stack heights: 1 vs 0
					//IL_027d->IL0425: Incompatible stack heights: 1 vs 0
					//IL_03a1->IL0425: Incompatible stack heights: 1 vs 0
					//IL_03d0->IL0425: Incompatible stack heights: 1 vs 0
					//IL_03ff->IL0425: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass14_4 obj11 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals5;
					TP_Wind2_Projectile tP_Wind2_Projectile3;
					object obj26;
					if (CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals5 != null)
					{
						_003C_003Ec__DisplayClass14_3 obj12 = obj11.CS_0024_003C_003E8__locals4;
						if (obj11.CS_0024_003C_003E8__locals4 != null)
						{
							_003C_003Ec__DisplayClass14_0 obj13 = obj12.CS_0024_003C_003E8__locals3;
							if (obj12.CS_0024_003C_003E8__locals3 != null && (object)obj13._003C_003E4__this != null)
							{
								GameObject gameObject = obj13._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj14 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj14 == null)
									{
										return;
									}
									_003C_003Ec__DisplayClass14_4 obj15 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals5;
									if (CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals5 != null)
									{
										_003C_003Ec__DisplayClass14_3 obj16 = obj15.CS_0024_003C_003E8__locals4;
										if (obj15.CS_0024_003C_003E8__locals4 != null)
										{
											_003C_003Ec__DisplayClass14_0 obj17 = obj16.CS_0024_003C_003E8__locals3;
											if (obj16.CS_0024_003C_003E8__locals3 != null)
											{
												_003C_003Ec__DisplayClass14_4 obj18 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals5;
												_003C_003Ec__DisplayClass14_3 obj19 = obj18.CS_0024_003C_003E8__locals4;
												_003C_003Ec__DisplayClass14_0 obj20 = obj19.CS_0024_003C_003E8__locals3;
												TP_Wind2_Weapon tP_Wind2_Weapon3 = obj20._003C_003E4__this;
												if ((object)obj20._003C_003E4__this != null && (object)tP_Wind2_Weapon3._cursor != null)
												{
													float2 position2 = tP_Wind2_Weapon3._cursor.position;
													_003C_003Ec__DisplayClass14_4 obj21 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals5;
													if (CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals5 != null)
													{
														_003C_003Ec__DisplayClass14_3 obj22 = obj21.CS_0024_003C_003E8__locals4;
														if (obj21.CS_0024_003C_003E8__locals4 != null)
														{
															_003C_003Ec__DisplayClass14_0 obj23 = obj22.CS_0024_003C_003E8__locals3;
															if (obj22.CS_0024_003C_003E8__locals3 != null)
															{
																TP_Wind2_Weapon tP_Wind2_Weapon4 = obj23._003C_003E4__this;
																if ((object)obj23._003C_003E4__this != null)
																{
																	Vector2 pos = default(Vector2);
																	tP_Wind2_Projectile3 = (TP_Wind2_Projectile)obj17._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals12.localIndex, tP_Wind2_Weapon4._targetTransform);
																	if ((object)tP_Wind2_Projectile3 == null)
																	{
																		return;
																	}
																	nint num5 = (nint)typeof(TP_Wind2_Projectile);
																	nint num6 = (nint)tP_Wind2_Projectile3;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
																	object obj24 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
																	nint num7 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
																	if (num7 >= 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+C8]");
																		object obj25 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rcx_v25+FFFFFFF8+v527 @ rcx_v20*8]");
																		if (0 == (nint)typeof(TP_Wind2_Projectile))
																		{
																			obj26 = 1;
																			goto IL_04a2;
																		}
																	}
																	obj26 = 0;
																	goto IL_04a2;
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
					goto IL_0425;
					IL_04a2:
					bool flag6 = obj26 == null;
					TP_Wind2_Projectile tP_Wind2_Projectile4 = null;
					if (!flag6)
					{
						tP_Wind2_Projectile4 = tP_Wind2_Projectile3;
					}
					if ((object)tP_Wind2_Projectile4 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass14_4 obj27 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals5;
					if (CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals5 != null)
					{
						_003C_003Ec__DisplayClass14_3 obj28 = obj27.CS_0024_003C_003E8__locals4;
						if (obj27.CS_0024_003C_003E8__locals4 != null)
						{
							_003C_003Ec__DisplayClass14_0 obj29 = obj28.CS_0024_003C_003E8__locals3;
							if (obj28.CS_0024_003C_003E8__locals3 != null)
							{
								tP_Wind2_Projectile4.SetFlip(obj29.__flip, obj28.__horizontalMirror2);
								return;
							}
						}
					}
					goto IL_0425;
					IL_0425:
					throw new NullReferenceException();
				};
				float num4 = (float)(flag ? 1 : 0) * obj4.__repeatInterval;
				float duration = num4 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				tP_Wind2_Weapon2._lastShotTimer = lastShotTimer;
				goto IL_02b7;
				IL_02ff:
				bool flag4 = obj8 == null;
				TP_Wind2_Projectile tP_Wind2_Projectile2 = null;
				if (!flag4)
				{
					tP_Wind2_Projectile2 = tP_Wind2_Projectile;
				}
				if ((object)tP_Wind2_Projectile2 != null)
				{
					_003C_003Ec__DisplayClass14_3 obj9 = CS_0024_003C_003E8__locals4;
					_003C_003Ec__DisplayClass14_0 obj10 = obj9.CS_0024_003C_003E8__locals3;
					tP_Wind2_Projectile2.SetFlip(obj10.__flip, obj9.__horizontalMirror2);
				}
				goto IL_02b7;
				IL_02b7:
				obj = CS_0024_003C_003E8__locals4;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				flag3 = (byte)((flag3 ? 1u : 0u) + 2u) != 0;
				flag2 = flag;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_5
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass14_4 CS_0024_003C_003E8__locals5;

		internal void _003CFireProjectiles_003Eb__3()
		{
			//IL_0485: Expected O, but got I4
			//IL_02d3: Expected I, but got O
			//IL_02db: Expected I, but got O
			//IL_02eb: Expected O, but got I
			//IL_036b: Expected O, but got I4
			//IL_0327: Expected O, but got I
			//IL_035d: Expected O, but got I4
			//IL_00e2->IL0425: Incompatible stack heights: 1 vs 0
			//IL_0111->IL0425: Incompatible stack heights: 1 vs 0
			//IL_0140->IL0425: Incompatible stack heights: 1 vs 0
			//IL_0193->IL0425: Incompatible stack heights: 1 vs 0
			//IL_01b5->IL0425: Incompatible stack heights: 1 vs 0
			//IL_01f0->IL0425: Incompatible stack heights: 1 vs 0
			//IL_021f->IL0425: Incompatible stack heights: 1 vs 0
			//IL_024e->IL0425: Incompatible stack heights: 1 vs 0
			//IL_027d->IL0425: Incompatible stack heights: 1 vs 0
			//IL_03a1->IL0425: Incompatible stack heights: 1 vs 0
			//IL_03d0->IL0425: Incompatible stack heights: 1 vs 0
			//IL_03ff->IL0425: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass14_4 obj = CS_0024_003C_003E8__locals5;
			TP_Wind2_Projectile tP_Wind2_Projectile;
			object obj16;
			if (CS_0024_003C_003E8__locals5 != null)
			{
				_003C_003Ec__DisplayClass14_3 obj2 = obj.CS_0024_003C_003E8__locals4;
				if (obj.CS_0024_003C_003E8__locals4 != null)
				{
					_003C_003Ec__DisplayClass14_0 obj3 = obj2.CS_0024_003C_003E8__locals3;
					if (obj2.CS_0024_003C_003E8__locals3 != null && (object)obj3._003C_003E4__this != null)
					{
						GameObject gameObject = obj3._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj4 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass14_4 obj5 = CS_0024_003C_003E8__locals5;
							if (CS_0024_003C_003E8__locals5 != null)
							{
								_003C_003Ec__DisplayClass14_3 obj6 = obj5.CS_0024_003C_003E8__locals4;
								if (obj5.CS_0024_003C_003E8__locals4 != null)
								{
									_003C_003Ec__DisplayClass14_0 obj7 = obj6.CS_0024_003C_003E8__locals3;
									if (obj6.CS_0024_003C_003E8__locals3 != null)
									{
										_003C_003Ec__DisplayClass14_4 obj8 = CS_0024_003C_003E8__locals5;
										_003C_003Ec__DisplayClass14_3 obj9 = obj8.CS_0024_003C_003E8__locals4;
										_003C_003Ec__DisplayClass14_0 obj10 = obj9.CS_0024_003C_003E8__locals3;
										TP_Wind2_Weapon tP_Wind2_Weapon = obj10._003C_003E4__this;
										if ((object)obj10._003C_003E4__this != null && (object)tP_Wind2_Weapon._cursor != null)
										{
											float2 position = tP_Wind2_Weapon._cursor.position;
											_003C_003Ec__DisplayClass14_4 obj11 = CS_0024_003C_003E8__locals5;
											if (CS_0024_003C_003E8__locals5 != null)
											{
												_003C_003Ec__DisplayClass14_3 obj12 = obj11.CS_0024_003C_003E8__locals4;
												if (obj11.CS_0024_003C_003E8__locals4 != null)
												{
													_003C_003Ec__DisplayClass14_0 obj13 = obj12.CS_0024_003C_003E8__locals3;
													if (obj12.CS_0024_003C_003E8__locals3 != null)
													{
														TP_Wind2_Weapon tP_Wind2_Weapon2 = obj13._003C_003E4__this;
														if ((object)obj13._003C_003E4__this != null)
														{
															Vector2 pos = default(Vector2);
															tP_Wind2_Projectile = (TP_Wind2_Projectile)obj7._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Wind2_Weapon2._targetTransform);
															if ((object)tP_Wind2_Projectile == null)
															{
																return;
															}
															nint num = (nint)typeof(TP_Wind2_Projectile);
															nint num2 = (nint)tP_Wind2_Projectile;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
															object obj14 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
															nint num3 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
															if (num3 >= 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+C8]");
																object obj15 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rcx_v25+FFFFFFF8+v527 @ rcx_v20*8]");
																if (0 == (nint)typeof(TP_Wind2_Projectile))
																{
																	obj16 = 1;
																	goto IL_04a2;
																}
															}
															obj16 = 0;
															goto IL_04a2;
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
			goto IL_0425;
			IL_04a2:
			bool flag2 = obj16 == null;
			TP_Wind2_Projectile tP_Wind2_Projectile2 = null;
			if (!flag2)
			{
				tP_Wind2_Projectile2 = tP_Wind2_Projectile;
			}
			if ((object)tP_Wind2_Projectile2 == null)
			{
				return;
			}
			_003C_003Ec__DisplayClass14_4 obj17 = CS_0024_003C_003E8__locals5;
			if (CS_0024_003C_003E8__locals5 != null)
			{
				_003C_003Ec__DisplayClass14_3 obj18 = obj17.CS_0024_003C_003E8__locals4;
				if (obj17.CS_0024_003C_003E8__locals4 != null)
				{
					_003C_003Ec__DisplayClass14_0 obj19 = obj18.CS_0024_003C_003E8__locals3;
					if (obj18.CS_0024_003C_003E8__locals3 != null)
					{
						tP_Wind2_Projectile2.SetFlip(obj19.__flip, obj18.__horizontalMirror2);
						return;
					}
				}
			}
			goto IL_0425;
			IL_0425:
			throw new NullReferenceException();
		}
	}

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private bool _hasGemini;

	private TP_Wind1_Weapon _wind1Weapon;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	public override float PSpeed()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
		float num2 = default(float);
		bool flag = !(4f > num2);
		float num3 = 4f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = num3 * currentWeaponData._003Cspeed_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController2._sineSpeed != null)
			{
				float value = characterController2._sineSpeed.Value;
				num4 *= value;
			}
		}
		return num4;
	}

	protected override void Awake()
	{
		base.Awake();
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Wind05");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0303: Expected I, but got O
		//IL_0074: Expected I, but got O
		//IL_0082: Expected I, but got O
		//IL_0092: Expected O, but got I
		//IL_0334: Expected I, but got O
		//IL_0112: Expected O, but got I4
		//IL_00ce: Expected O, but got I
		//IL_0104: Expected O, but got I4
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__10_0;
		bool flag = _003C_003Ec._003C_003E9__10_0 != null;
		nint num3 = unchecked((nint)null);
		if (!flag)
		{
			Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__10_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = x._equipmentType - 1459;
				return obj6 == null;
			});
			num3 = unchecked((nint)null);
			match = predicate;
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		bool flag2 = (object)equipment == null;
		Equipment wind1Weapon = equipment;
		if (flag2)
		{
			goto IL_0341;
		}
		num3 = (nint)equipment;
		nint num4 = (nint)typeof(TP_Wind1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Wind1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Wind1_Weapon>)+130]");
		object obj4;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v47+FFFFFFF8+v458 @ rax_v42*8]");
			if (0 == (nint)typeof(TP_Wind1_Weapon))
			{
				obj4 = 1;
				goto IL_0350;
			}
		}
		obj4 = 0;
		goto IL_0350;
		IL_0341:
		_wind1Weapon = (TP_Wind1_Weapon)wind1Weapon;
		TP_Wind1_Weapon wind1Weapon2 = _wind1Weapon;
		if ((object)_wind1Weapon != null && ((UnityEngine.Object)wind1Weapon2).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager2 = characterController3._weaponsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
			object obj5 = default(object);
			if (obj5 != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
				CharacterWeaponsManager weaponsManager3 = characterController4._weaponsManager;
				bool flag3 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField).Remove((object)_wind1Weapon);
			}
			_wind1Weapon.Cleanup();
			VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager4 = characterController5._weaponsManager;
			bool flag4 = ((EquipmentManager)weaponsManager4)._003CHiddenEquipment_003Ek__BackingField.Remove(_wind1Weapon);
			TP_Wind1_Weapon wind1Weapon3 = _wind1Weapon;
			wind1Weapon3._003CCanFireNormally_003Ek__BackingField = false;
			GameObject gameObject = _wind1Weapon.gameObject;
			gameObject.SetActive(value: true);
		}
		return;
		IL_0350:
		bool flag5 = obj4 == null;
		wind1Weapon = null;
		if (!flag5)
		{
			wind1Weapon = equipment;
		}
		goto IL_0341;
	}

	public override void InternalUpdate()
	{
		//IL_02e3->IL01ef: Incompatible stack heights: 1 vs 0
		//IL_01a4->IL01ef: Incompatible stack heights: 1 vs 0
		//IL_01d6->IL01ef: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
				TP_Wind1_Weapon wind1Weapon = _wind1Weapon;
				if ((object)_wind1Weapon != null && ((UnityEngine.Object)wind1Weapon).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_wind1Weapon == null)
					{
						goto IL_01ef;
					}
					_wind1Weapon.Fire();
				}
			}
		}
		if ((object)_cursor != null)
		{
			float num3 = base._003CTotalTime_003Ek__BackingField * 0.85f;
			float num4 = num3 / deltaTime;
			float alpha = num4 + 0.15f;
			PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
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
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
							if ((object)_cursor != null)
							{
								PhaserSprite phaserSprite2 = _cursor.setPosition(position);
								if ((object)_cursor != null)
								{
									float2 localPosition = default(float2);
									PhaserSprite phaserSprite3 = _cursor.setLocalPosition(localPosition);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_01ef;
		IL_01ef:
		throw new NullReferenceException();
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
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0074: Invalid comparison between O and F4
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
	}

	public void FireProjectiles()
	{
		_003C_003Ec__DisplayClass14_0 obj = new _003C_003Ec__DisplayClass14_0();
		obj._003C_003E4__this = this;
		float playerFacing = PlayerFacing;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018747F596h\"");
		float num = default(float);
		bool _flip;
		if (num == 1f)
		{
			_flip = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		}
		else
		{
			bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
			_flip = (byte)((flipX ? 1u : 0u) ^ 1u) != 0;
		}
		obj.__flip = _flip;
		float num2 = base.PAmount();
		obj.__amount = num;
		float num3 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float _repeatInterval = num / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		float num4 = base.PSpeedRepeatInterval();
		obj.__repeatInterval = _repeatInterval;
		obj.__horizontalMirror = false;
		object obj2 = default(object);
		bool flag = (nint)obj2 <= 0;
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (!flag)
		{
			do
			{
				_003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass14_1();
				CS_0024_003C_003E8__locals14.CS_0024_003C_003E8__locals1 = obj;
				bool isPrimaryWeapon = IsPrimaryWeapon;
				bool invert = !isPrimaryWeapon;
				CS_0024_003C_003E8__locals14.invert = (invert ? 1 : 0);
				float hitBoxDelay2 = base.HitBoxDelay;
				Action onComplete = delegate
				{
					//IL_02ef: Invalid comparison between F4 and I4
					//IL_007a: Unknown result type (might be due to invalid IL or missing references)
					//IL_007f: Expected O, but got Unknown
					//IL_00a9: Expected I, but got O
					//IL_00bf: Expected O, but got I
					//IL_00fe: Expected I, but got O
					//IL_0106: Expected I, but got O
					//IL_0199: Expected O, but got I4
					//IL_0153: Expected O, but got I
					//IL_018b: Expected O, but got I4
					_003C_003Ec__DisplayClass14_0 obj4 = CS_0024_003C_003E8__locals14.CS_0024_003C_003E8__locals1;
					bool flag5 = false;
					bool flag6 = false;
					bool useRealTime2 = default(bool);
					MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
					int repeat2 = default(int);
					TimerType type2 = default(TimerType);
					TP_Wind2_Projectile tP_Wind2_Projectile = default(TP_Wind2_Projectile);
					for (bool flag7 = false; obj4.__amount > (float)(flag7 ? 1 : 0); obj4 = CS_0024_003C_003E8__locals14.CS_0024_003C_003E8__locals1, flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0, flag6 = (byte)((flag6 ? 1u : 0u) + 2u) != 0, flag7 = flag5)
					{
						_003C_003Ec__DisplayClass14_2 CS_0024_003C_003E8__locals32 = new _003C_003Ec__DisplayClass14_2();
						CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals14;
						int localIndex = CS_0024_003C_003E8__locals14.invert + (flag6 ? 1 : 0);
						CS_0024_003C_003E8__locals32.localIndex = localIndex;
						_003C_003Ec__DisplayClass14_0 obj5 = CS_0024_003C_003E8__locals14.CS_0024_003C_003E8__locals1;
						object obj6 = flag5 * obj5.__repeatInterval;
						if ((nint)obj6 > 0)
						{
							TP_Wind2_Weapon tP_Wind2_Weapon = obj5._003C_003E4__this;
							Action onComplete3 = delegate
							{
								//IL_03a5: Expected O, but got I4
								//IL_0222: Expected I, but got O
								//IL_022a: Expected I, but got O
								//IL_023a: Expected O, but got I
								//IL_02ba: Expected O, but got I4
								//IL_0276: Expected O, but got I
								//IL_02ac: Expected O, but got I4
								//IL_00b3->IL0345: Incompatible stack heights: 1 vs 0
								//IL_00e2->IL0345: Incompatible stack heights: 1 vs 0
								//IL_0111->IL0345: Incompatible stack heights: 1 vs 0
								//IL_0133->IL0345: Incompatible stack heights: 1 vs 0
								//IL_016e->IL0345: Incompatible stack heights: 1 vs 0
								//IL_019d->IL0345: Incompatible stack heights: 1 vs 0
								//IL_01cc->IL0345: Incompatible stack heights: 1 vs 0
								//IL_02f0->IL0345: Incompatible stack heights: 1 vs 0
								//IL_031f->IL0345: Incompatible stack heights: 1 vs 0
								_003C_003Ec__DisplayClass14_1 obj10 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2;
								TP_Wind2_Projectile tP_Wind2_Projectile3;
								object obj19;
								if (CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2 != null)
								{
									_003C_003Ec__DisplayClass14_0 obj11 = obj10.CS_0024_003C_003E8__locals1;
									if (obj10.CS_0024_003C_003E8__locals1 != null && (object)obj11._003C_003E4__this != null)
									{
										GameObject gameObject = obj11._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag9 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj12 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj12 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass14_1 obj13 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2;
											if (CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2 != null)
											{
												_003C_003Ec__DisplayClass14_0 obj14 = obj13.CS_0024_003C_003E8__locals1;
												if (obj13.CS_0024_003C_003E8__locals1 != null)
												{
													TP_Wind2_Weapon tP_Wind2_Weapon2 = obj14._003C_003E4__this;
													if ((object)obj14._003C_003E4__this != null && (object)tP_Wind2_Weapon2._cursor != null)
													{
														float2 position2 = tP_Wind2_Weapon2._cursor.position;
														_003C_003Ec__DisplayClass14_1 obj15 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2;
														if (CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2 != null)
														{
															_003C_003Ec__DisplayClass14_0 obj16 = obj15.CS_0024_003C_003E8__locals1;
															if (obj15.CS_0024_003C_003E8__locals1 != null)
															{
																TP_Wind2_Weapon tP_Wind2_Weapon3 = obj16._003C_003E4__this;
																if ((object)obj16._003C_003E4__this != null)
																{
																	Vector2 pos = default(Vector2);
																	tP_Wind2_Projectile3 = (TP_Wind2_Projectile)obj14._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals32.localIndex, tP_Wind2_Weapon3._targetTransform);
																	if ((object)tP_Wind2_Projectile3 == null)
																	{
																		return;
																	}
																	nint num15 = (nint)typeof(TP_Wind2_Projectile);
																	nint num16 = (nint)tP_Wind2_Projectile3;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
																	object obj17 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
																	nint num17 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
																	if (num17 >= 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+C8]");
																		object obj18 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rcx_v21+FFFFFFF8+v479 @ rcx_v17*8]");
																		if (0 == (nint)typeof(TP_Wind2_Projectile))
																		{
																			obj19 = 1;
																			goto IL_03c2;
																		}
																	}
																	obj19 = 0;
																	goto IL_03c2;
																}
															}
														}
													}
												}
											}
										}
									}
								}
								goto IL_0345;
								IL_0345:
								throw new NullReferenceException();
								IL_03c2:
								bool flag10 = obj19 == null;
								TP_Wind2_Projectile tP_Wind2_Projectile4 = null;
								if (!flag10)
								{
									tP_Wind2_Projectile4 = tP_Wind2_Projectile3;
								}
								if ((object)tP_Wind2_Projectile4 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass14_1 obj20 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2;
								if (CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2 != null)
								{
									_003C_003Ec__DisplayClass14_0 obj21 = obj20.CS_0024_003C_003E8__locals1;
									if (obj20.CS_0024_003C_003E8__locals1 != null)
									{
										tP_Wind2_Projectile4.SetFlip(obj21.__flip, obj21.__horizontalMirror);
										return;
									}
								}
								goto IL_0345;
							};
							float num9 = (float)(flag5 ? 1 : 0) * obj5.__repeatInterval;
							float duration3 = num9 * 0.001f;
							Timer lastShotTimer = Timers.Register(duration3, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
							tP_Wind2_Weapon._lastShotTimer = lastShotTimer;
							continue;
						}
						nint num10 = (nint)obj5._003C_003E4__this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v6 (Il2CppMethodInfo)+160]");
						float2 position = ((PhaserSprite)0).position;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						if ((object)tP_Wind2_Projectile == null)
						{
							continue;
						}
						nint num11 = (nint)typeof(TP_Wind2_Projectile);
						nint num12 = (nint)tP_Wind2_Projectile;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
						nint num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
						nint num14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
						object obj8;
						if (num14 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+C8]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rcx_v22+FFFFFFF8+v549 @ rcx_v16 (Il2CppMethodInfo)*8]");
							if (0 == (nint)typeof(TP_Wind2_Projectile))
							{
								obj8 = 1;
								goto IL_02c0;
							}
						}
						obj8 = 0;
						goto IL_02c0;
						IL_02c0:
						bool flag8 = obj8 == null;
						TP_Wind2_Projectile tP_Wind2_Projectile2 = null;
						if (!flag8)
						{
							tP_Wind2_Projectile2 = tP_Wind2_Projectile;
						}
						if ((object)tP_Wind2_Projectile2 != null)
						{
							_003C_003Ec__DisplayClass14_0 obj9 = CS_0024_003C_003E8__locals14.CS_0024_003C_003E8__locals1;
							tP_Wind2_Projectile2.SetFlip(obj9.__flip, obj9.__horizontalMirror);
						}
					}
				};
				float num5 = (float)(flag2 ? 1 : 0) * hitBoxDelay2;
				float num6 = num5 + 1f;
				float duration = num6 * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			}
			while ((flag2 ? 1 : 0) < (nint)obj2);
		}
		if (!_hasGemini)
		{
			return;
		}
		_003C_003Ec__DisplayClass14_3 obj3 = new _003C_003Ec__DisplayClass14_3();
		obj3.CS_0024_003C_003E8__locals3 = obj;
		obj3.__horizontalMirror2 = true;
		bool flag3 = (nint)obj2 <= 0;
		bool flag4 = false;
		if (flag3)
		{
			return;
		}
		do
		{
			_003C_003Ec__DisplayClass14_4 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass14_4();
			CS_0024_003C_003E8__locals23.CS_0024_003C_003E8__locals4 = obj3;
			bool isPrimaryWeapon2 = IsPrimaryWeapon;
			bool invert2 = !isPrimaryWeapon2;
			CS_0024_003C_003E8__locals23.invert = (invert2 ? 1 : 0);
			float hitBoxDelay3 = base.HitBoxDelay;
			Action onComplete2 = delegate
			{
				//IL_0032: Invalid comparison between F4 and I4
				//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b5: Expected O, but got Unknown
				//IL_0130: Expected I, but got O
				//IL_0138: Expected I, but got O
				//IL_0148: Expected O, but got I
				//IL_01c8: Expected O, but got I4
				//IL_0184: Expected O, but got I
				//IL_01ba: Expected O, but got I4
				_003C_003Ec__DisplayClass14_3 obj4 = CS_0024_003C_003E8__locals23.CS_0024_003C_003E8__locals4;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				bool useRealTime2 = default(bool);
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				TimerType type2 = default(TimerType);
				TP_Wind2_Projectile tP_Wind2_Projectile = default(TP_Wind2_Projectile);
				while (true)
				{
					_003C_003Ec__DisplayClass14_0 obj5 = obj4.CS_0024_003C_003E8__locals3;
					if (!(obj5.__amount > (float)(flag6 ? 1 : 0)))
					{
						break;
					}
					_003C_003Ec__DisplayClass14_5 CS_0024_003C_003E8__locals42 = new _003C_003Ec__DisplayClass14_5();
					CS_0024_003C_003E8__locals42.CS_0024_003C_003E8__locals5 = CS_0024_003C_003E8__locals23;
					int localIndex = CS_0024_003C_003E8__locals23.invert + (flag7 ? 1 : 0);
					CS_0024_003C_003E8__locals42.localIndex = localIndex;
					_003C_003Ec__DisplayClass14_3 obj6 = CS_0024_003C_003E8__locals23.CS_0024_003C_003E8__locals4;
					_003C_003Ec__DisplayClass14_0 obj7 = obj6.CS_0024_003C_003E8__locals3;
					object obj8 = flag5 * obj7.__repeatInterval;
					if ((nint)obj8 > 0)
					{
						TP_Wind2_Weapon tP_Wind2_Weapon = obj7._003C_003E4__this;
						Action onComplete3 = delegate
						{
							//IL_0485: Expected O, but got I4
							//IL_02d3: Expected I, but got O
							//IL_02db: Expected I, but got O
							//IL_02eb: Expected O, but got I
							//IL_036b: Expected O, but got I4
							//IL_0327: Expected O, but got I
							//IL_035d: Expected O, but got I4
							//IL_00e2->IL0425: Incompatible stack heights: 1 vs 0
							//IL_0111->IL0425: Incompatible stack heights: 1 vs 0
							//IL_0140->IL0425: Incompatible stack heights: 1 vs 0
							//IL_0193->IL0425: Incompatible stack heights: 1 vs 0
							//IL_01b5->IL0425: Incompatible stack heights: 1 vs 0
							//IL_01f0->IL0425: Incompatible stack heights: 1 vs 0
							//IL_021f->IL0425: Incompatible stack heights: 1 vs 0
							//IL_024e->IL0425: Incompatible stack heights: 1 vs 0
							//IL_027d->IL0425: Incompatible stack heights: 1 vs 0
							//IL_03a1->IL0425: Incompatible stack heights: 1 vs 0
							//IL_03d0->IL0425: Incompatible stack heights: 1 vs 0
							//IL_03ff->IL0425: Incompatible stack heights: 1 vs 0
							_003C_003Ec__DisplayClass14_4 obj14 = CS_0024_003C_003E8__locals42.CS_0024_003C_003E8__locals5;
							TP_Wind2_Projectile tP_Wind2_Projectile3;
							object obj29;
							if (CS_0024_003C_003E8__locals42.CS_0024_003C_003E8__locals5 != null)
							{
								_003C_003Ec__DisplayClass14_3 obj15 = obj14.CS_0024_003C_003E8__locals4;
								if (obj14.CS_0024_003C_003E8__locals4 != null)
								{
									_003C_003Ec__DisplayClass14_0 obj16 = obj15.CS_0024_003C_003E8__locals3;
									if (obj15.CS_0024_003C_003E8__locals3 != null && (object)obj16._003C_003E4__this != null)
									{
										GameObject gameObject = obj16._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag9 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj17 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj17 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass14_4 obj18 = CS_0024_003C_003E8__locals42.CS_0024_003C_003E8__locals5;
											if (CS_0024_003C_003E8__locals42.CS_0024_003C_003E8__locals5 != null)
											{
												_003C_003Ec__DisplayClass14_3 obj19 = obj18.CS_0024_003C_003E8__locals4;
												if (obj18.CS_0024_003C_003E8__locals4 != null)
												{
													_003C_003Ec__DisplayClass14_0 obj20 = obj19.CS_0024_003C_003E8__locals3;
													if (obj19.CS_0024_003C_003E8__locals3 != null)
													{
														_003C_003Ec__DisplayClass14_4 obj21 = CS_0024_003C_003E8__locals42.CS_0024_003C_003E8__locals5;
														_003C_003Ec__DisplayClass14_3 obj22 = obj21.CS_0024_003C_003E8__locals4;
														_003C_003Ec__DisplayClass14_0 obj23 = obj22.CS_0024_003C_003E8__locals3;
														TP_Wind2_Weapon tP_Wind2_Weapon3 = obj23._003C_003E4__this;
														if ((object)obj23._003C_003E4__this != null && (object)tP_Wind2_Weapon3._cursor != null)
														{
															float2 position2 = tP_Wind2_Weapon3._cursor.position;
															_003C_003Ec__DisplayClass14_4 obj24 = CS_0024_003C_003E8__locals42.CS_0024_003C_003E8__locals5;
															if (CS_0024_003C_003E8__locals42.CS_0024_003C_003E8__locals5 != null)
															{
																_003C_003Ec__DisplayClass14_3 obj25 = obj24.CS_0024_003C_003E8__locals4;
																if (obj24.CS_0024_003C_003E8__locals4 != null)
																{
																	_003C_003Ec__DisplayClass14_0 obj26 = obj25.CS_0024_003C_003E8__locals3;
																	if (obj25.CS_0024_003C_003E8__locals3 != null)
																	{
																		TP_Wind2_Weapon tP_Wind2_Weapon4 = obj26._003C_003E4__this;
																		if ((object)obj26._003C_003E4__this != null)
																		{
																			Vector2 pos = default(Vector2);
																			tP_Wind2_Projectile3 = (TP_Wind2_Projectile)obj20._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals42.localIndex, tP_Wind2_Weapon4._targetTransform);
																			if ((object)tP_Wind2_Projectile3 == null)
																			{
																				return;
																			}
																			nint num13 = (nint)typeof(TP_Wind2_Projectile);
																			nint num14 = (nint)tP_Wind2_Projectile3;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
																			object obj27 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
																			nint num15 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
																			if (num15 >= 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+C8]");
																				object obj28 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rcx_v25+FFFFFFF8+v527 @ rcx_v20*8]");
																				if (0 == (nint)typeof(TP_Wind2_Projectile))
																				{
																					obj29 = 1;
																					goto IL_04a2;
																				}
																			}
																			obj29 = 0;
																			goto IL_04a2;
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
							goto IL_0425;
							IL_04a2:
							bool flag10 = obj29 == null;
							TP_Wind2_Projectile tP_Wind2_Projectile4 = null;
							if (!flag10)
							{
								tP_Wind2_Projectile4 = tP_Wind2_Projectile3;
							}
							if ((object)tP_Wind2_Projectile4 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass14_4 obj30 = CS_0024_003C_003E8__locals42.CS_0024_003C_003E8__locals5;
							if (CS_0024_003C_003E8__locals42.CS_0024_003C_003E8__locals5 != null)
							{
								_003C_003Ec__DisplayClass14_3 obj31 = obj30.CS_0024_003C_003E8__locals4;
								if (obj30.CS_0024_003C_003E8__locals4 != null)
								{
									_003C_003Ec__DisplayClass14_0 obj32 = obj31.CS_0024_003C_003E8__locals3;
									if (obj31.CS_0024_003C_003E8__locals3 != null)
									{
										tP_Wind2_Projectile4.SetFlip(obj32.__flip, obj31.__horizontalMirror2);
										return;
									}
								}
							}
							goto IL_0425;
							IL_0425:
							throw new NullReferenceException();
						};
						float num9 = (float)(flag5 ? 1 : 0) * obj7.__repeatInterval;
						float duration3 = num9 * 0.001f;
						Timer lastShotTimer = Timers.Register(duration3, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
						tP_Wind2_Weapon._lastShotTimer = lastShotTimer;
						goto IL_02b7;
					}
					TP_Wind2_Weapon tP_Wind2_Weapon2 = obj7._003C_003E4__this;
					float2 position = tP_Wind2_Weapon2._cursor.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					if ((object)tP_Wind2_Projectile == null)
					{
						goto IL_02b7;
					}
					nint num10 = (nint)typeof(TP_Wind2_Projectile);
					nint num11 = (nint)tP_Wind2_Projectile;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+130]");
					object obj11;
					if (num12 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+C8]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rcx_v22+FFFFFFF8+v586 @ rcx_v16*8]");
						if (0 == (nint)typeof(TP_Wind2_Projectile))
						{
							obj11 = 1;
							goto IL_02ff;
						}
					}
					obj11 = 0;
					goto IL_02ff;
					IL_02ff:
					bool flag8 = obj11 == null;
					TP_Wind2_Projectile tP_Wind2_Projectile2 = null;
					if (!flag8)
					{
						tP_Wind2_Projectile2 = tP_Wind2_Projectile;
					}
					if ((object)tP_Wind2_Projectile2 != null)
					{
						_003C_003Ec__DisplayClass14_3 obj12 = CS_0024_003C_003E8__locals23.CS_0024_003C_003E8__locals4;
						_003C_003Ec__DisplayClass14_0 obj13 = obj12.CS_0024_003C_003E8__locals3;
						tP_Wind2_Projectile2.SetFlip(obj13.__flip, obj12.__horizontalMirror2);
					}
					goto IL_02b7;
					IL_02b7:
					obj4 = CS_0024_003C_003E8__locals23.CS_0024_003C_003E8__locals4;
					flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
					flag7 = (byte)((flag7 ? 1u : 0u) + 2u) != 0;
					flag6 = flag5;
				}
			};
			float num7 = (float)(flag4 ? 1 : 0) * hitBoxDelay3;
			float num8 = num7 + 1f;
			float duration2 = num8 * 0.001f;
			Timer timer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag4 = (byte)((flag4 ? 1u : 0u) + 1u) != 0;
		}
		while ((flag4 ? 1 : 0) < (nint)obj2);
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			_hasGemini = true;
		}
	}

	private unsafe void DisplayCursorVFX(int _times, float _duration)
	{
		//IL_0112: Expected O, but got Ref
		//IL_0169->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00e8->IL0113: Incompatible stack heights: 1 vs 0
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.SpellcastingCursor);
			if ((object)pool != null)
			{
				SpellcastingCursorVFX objectComponent = pool.GetObjectComponent<SpellcastingCursorVFX>();
				if ((object)_cursor != null)
				{
					Transform transform = _cursor.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)_cursor != null)
						{
							Transform transform2 = _cursor.transform;
							if ((object)transform2 != null)
							{
								Vector3 localEulerAngles = transform2.localEulerAngles;
								if ((object)objectComponent != null)
								{
									object obj = default(object);
									float angle = default(float);
									string texture = default(string);
									string frame = default(string);
									bool flip = default(bool);
									objectComponent.Display(_times, _duration, (Vector3)(&obj), angle, texture, frame, flip);
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

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _cursor.setVisible(visible);
		TP_Wind1_Weapon wind1Weapon = _wind1Weapon;
		if ((object)_wind1Weapon != null && ((UnityEngine.Object)wind1Weapon).m_CachedPtr != (IntPtr)0)
		{
			_wind1Weapon.SetVisible(visible);
		}
	}
}
