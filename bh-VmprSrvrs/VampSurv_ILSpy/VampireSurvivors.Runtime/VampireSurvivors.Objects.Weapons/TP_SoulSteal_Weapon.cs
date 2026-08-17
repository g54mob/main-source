using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_SoulSteal_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public TP_SoulSteal_Weapon _003C_003E4__this;

		public TP_SoulSteal_Projectile p;

		public List<EnemyController> enemies;
	}

	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_003Eb__0()
		{
			//IL_0378: Expected O, but got I4
			//IL_0194: Expected I, but got O
			//IL_01a2: Expected I, but got O
			//IL_01b2: Expected O, but got I
			//IL_0232: Expected O, but got I4
			//IL_01ee: Expected O, but got I
			//IL_0224: Expected O, but got I4
			//IL_0084->IL0318: Incompatible stack heights: 1 vs 0
			//IL_00b3->IL0318: Incompatible stack heights: 1 vs 0
			//IL_00d5->IL0318: Incompatible stack heights: 1 vs 0
			//IL_0110->IL0318: Incompatible stack heights: 1 vs 0
			//IL_013f->IL0318: Incompatible stack heights: 1 vs 0
			//IL_0268->IL0318: Incompatible stack heights: 1 vs 0
			//IL_02d4->IL0318: Incompatible stack heights: 1 vs 0
			//IL_02f6->IL0318: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass4_0 obj = CS_0024_003C_003E8__locals1;
			_003C_003Ec__DisplayClass4_0 obj3;
			GameObject gameObject2;
			GameObject p;
			object obj7;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_SoulSteal_Weapon tP_SoulSteal_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)((Equipment)tP_SoulSteal_Weapon)._003COwner_003Ek__BackingField != null)
						{
							float2 position = ((Equipment)tP_SoulSteal_Weapon)._003COwner_003Ek__BackingField.position;
							_003C_003Ec__DisplayClass4_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								TP_SoulSteal_Weapon tP_SoulSteal_Weapon2 = obj4._003C_003E4__this;
								if ((object)obj4._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									gameObject2 = (GameObject)(object)obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_SoulSteal_Weapon2._targetTransform);
									bool flag2 = (object)gameObject2 == null;
									p = null;
									if (flag2)
									{
										goto IL_0395;
									}
									nint num = (nint)gameObject2;
									nint num2 = (nint)typeof(TP_SoulSteal_Projectile);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SoulSteal_Projectile>)+130]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r8_v13 (Il2CppClass<UnityEngine.GameObject>)+130]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SoulSteal_Projectile>)+130]");
									if (num3 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r8_v13 (Il2CppClass<UnityEngine.GameObject>)+C8]");
										object obj6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v44+FFFFFFF8+v487 @ rax_v40*8]");
										if (0 == (nint)typeof(TP_SoulSteal_Projectile))
										{
											obj7 = 1;
											goto IL_03a7;
										}
									}
									obj7 = 0;
									goto IL_03a7;
								}
							}
						}
					}
				}
			}
			goto IL_0318;
			IL_0395:
			obj3.p = (TP_SoulSteal_Projectile)(object)p;
			_003C_003Ec__DisplayClass4_0 obj8 = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				GameObject p2 = (GameObject)(object)obj8.p;
				if ((object)obj8.p == null || ((UnityEngine.Object)p2).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				_003C_003Ec__DisplayClass4_0 obj9 = CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null && (object)obj9.p != null)
				{
					obj9.p.DoSoulSteal(obj9.enemies);
					return;
				}
			}
			goto IL_0318;
			IL_0318:
			throw new NullReferenceException();
			IL_03a7:
			bool flag3 = obj7 == null;
			p = null;
			if (!flag3)
			{
				p = gameObject2;
			}
			goto IL_0395;
		}
	}

	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public PhaserSprite exp;

		internal void _003CAwake_003Eb__0()
		{
			PhaserSprite phaserSprite = exp.setVisible(visible: false);
		}
	}

	private List<PhaserSprite> explosionSprites;

	private int _exploIndex;

	private bool _isManualFire;

	public void SetManualFire()
	{
		_isManualFire = true;
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_00bd: Expected I, but got O
		//IL_00cb: Expected I, but got O
		//IL_00db: Expected O, but got I
		//IL_015b: Expected O, but got I4
		//IL_0117: Expected O, but got I
		//IL_0544: Expected O, but got I4
		//IL_0168: Expected I4, but got O
		//IL_014d: Expected O, but got I4
		//IL_01df: Invalid comparison between O and F4
		//IL_01f0: Expected F4, but got O
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Expected O, but got Unknown
		//IL_04e2: Invalid comparison between O and F4
		//IL_0211: Invalid comparison between O and F4
		//IL_0222: Expected F4, but got O
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_02af: Expected O, but got I4
		//IL_02bd: Expected I, but got O
		//IL_02cd: Expected O, but got I
		//IL_0495: Invalid comparison between F4 and I4
		//IL_034d: Expected O, but got I4
		//IL_0309: Expected O, but got I
		//IL_05a3: Expected O, but got I4
		//IL_033f: Expected O, but got I4
		//IL_05fc: Expected F4, but got O
		//IL_038a: Expected F4, but got O
		//IL_03b7: Expected F4, but got O
		_003C_003Ec__DisplayClass4_0 obj = new _003C_003Ec__DisplayClass4_0();
		obj._003C_003E4__this = this;
		GameManager core = GM.Core;
		List<EnemyController> allEnemiesInScreenBounds = core._stage.GetAllEnemiesInScreenBounds(0f);
		obj.enemies = allEnemiesInScreenBounds;
		Extensions.Shuffle((IList<object>)obj.enemies);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		bool flag;
		if ((object)projectile == null)
		{
			flag = false;
			goto IL_0537;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(TP_SoulSteal_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v545 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SoulSteal_Projectile>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v545 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SoulSteal_Projectile>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rax_v89+FFFFFFF8+v546 @ rax_v84*8]");
			if (0 == (nint)typeof(TP_SoulSteal_Projectile))
			{
				obj4 = 1;
				goto IL_0549;
			}
		}
		obj4 = 0;
		goto IL_0549;
		IL_0549:
		bool flag2 = obj4 == null;
		flag = false;
		if (!flag2)
		{
			flag = (byte)(int)projectile != 0;
		}
		goto IL_0537;
		IL_0537:
		obj.p = (TP_SoulSteal_Projectile)flag;
		TP_SoulSteal_Projectile p = obj.p;
		if ((object)obj.p != null && ((UnityEngine.Object)p).m_CachedPtr != (IntPtr)0)
		{
			obj.p.DoSoulSteal(obj.enemies);
		}
		float num4 = base.PAmount();
		bool flag3 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		float num5 = (float)vector;
		if (!flag3)
		{
			float num6 = base.PAmount();
			bool flag4 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			num5 = (float)vector;
			if (!flag4)
			{
				int num7 = 1;
				bool flag5 = default(bool);
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj5 = num7 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					Vector2 playerPos;
					bool flag6;
					object obj8;
					if ((nint)obj5 <= 0)
					{
						playerPos = base.PlayerPos;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						if (!flag5)
						{
							flag6 = false;
							goto IL_0596;
						}
						Vector2 vector2 = (Vector2)((bool*)(flag5 ? 1 : 0))->m_value;
						nint num8 = (nint)typeof(TP_SoulSteal_Projectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SoulSteal_Projectile>)+130]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v975 @ r8_v19 (UnityEngine.Vector2)+130]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SoulSteal_Projectile>)+130]");
						if (num9 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v975 @ r8_v19 (UnityEngine.Vector2)+C8]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1020 @ rax_v71+FFFFFFF8+v977 @ rax_v66*8]");
							if (0 == (nint)typeof(TP_SoulSteal_Projectile))
							{
								obj8 = 1;
								goto IL_05b5;
							}
						}
						obj8 = 0;
						goto IL_05b5;
					}
					_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass4_1();
					CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 = obj;
					CS_0024_003C_003E8__locals13.localIndex = num7;
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						//IL_0378: Expected O, but got I4
						//IL_0194: Expected I, but got O
						//IL_01a2: Expected I, but got O
						//IL_01b2: Expected O, but got I
						//IL_0232: Expected O, but got I4
						//IL_01ee: Expected O, but got I
						//IL_0224: Expected O, but got I4
						//IL_0084->IL0318: Incompatible stack heights: 1 vs 0
						//IL_00b3->IL0318: Incompatible stack heights: 1 vs 0
						//IL_00d5->IL0318: Incompatible stack heights: 1 vs 0
						//IL_0110->IL0318: Incompatible stack heights: 1 vs 0
						//IL_013f->IL0318: Incompatible stack heights: 1 vs 0
						//IL_0268->IL0318: Incompatible stack heights: 1 vs 0
						//IL_02d4->IL0318: Incompatible stack heights: 1 vs 0
						//IL_02f6->IL0318: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass4_0 obj10 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
						_003C_003Ec__DisplayClass4_0 obj12;
						GameObject gameObject2;
						GameObject p3;
						object obj16;
						if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null && (object)obj10._003C_003E4__this != null)
						{
							GameObject gameObject = obj10._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag10 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj11 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj11 == null)
								{
									return;
								}
								obj12 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null)
								{
									TP_SoulSteal_Weapon tP_SoulSteal_Weapon = obj12._003C_003E4__this;
									if ((object)obj12._003C_003E4__this != null && (object)((Equipment)tP_SoulSteal_Weapon)._003COwner_003Ek__BackingField != null)
									{
										float2 position2 = ((Equipment)tP_SoulSteal_Weapon)._003COwner_003Ek__BackingField.position;
										_003C_003Ec__DisplayClass4_0 obj13 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null)
										{
											TP_SoulSteal_Weapon tP_SoulSteal_Weapon2 = obj13._003C_003E4__this;
											if ((object)obj13._003C_003E4__this != null)
											{
												Vector2 pos = default(Vector2);
												gameObject2 = (GameObject)(object)obj12._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals13.localIndex, tP_SoulSteal_Weapon2._targetTransform);
												bool flag11 = (object)gameObject2 == null;
												p3 = null;
												if (flag11)
												{
													goto IL_0395;
												}
												nint num15 = (nint)gameObject2;
												nint num16 = (nint)typeof(TP_SoulSteal_Projectile);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SoulSteal_Projectile>)+130]");
												object obj14 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r8_v13 (Il2CppClass<UnityEngine.GameObject>)+130]");
												nint num17 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SoulSteal_Projectile>)+130]");
												if (num17 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r8_v13 (Il2CppClass<UnityEngine.GameObject>)+C8]");
													object obj15 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v44+FFFFFFF8+v487 @ rax_v40*8]");
													if (0 == (nint)typeof(TP_SoulSteal_Projectile))
													{
														obj16 = 1;
														goto IL_03a7;
													}
												}
												obj16 = 0;
												goto IL_03a7;
											}
										}
									}
								}
							}
						}
						goto IL_0318;
						IL_0395:
						obj12.p = (TP_SoulSteal_Projectile)(object)p3;
						_003C_003Ec__DisplayClass4_0 obj17 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null)
						{
							GameObject p4 = (GameObject)(object)obj17.p;
							if ((object)obj17.p == null || ((UnityEngine.Object)p4).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							_003C_003Ec__DisplayClass4_0 obj18 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null && (object)obj18.p != null)
							{
								obj18.p.DoSoulSteal(obj18.enemies);
								return;
							}
						}
						goto IL_0318;
						IL_0318:
						throw new NullReferenceException();
						IL_03a7:
						bool flag12 = obj16 == null;
						p3 = null;
						if (!flag12)
						{
							p3 = gameObject2;
						}
						goto IL_0395;
					};
					float num10 = (float)num7 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					num5 = num10 * 0.001f;
					Timer lastShotTimer = Timers.Register(num5, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
					goto IL_0475;
					IL_0596:
					obj.p = (TP_SoulSteal_Projectile)flag6;
					TP_SoulSteal_Projectile p2 = obj.p;
					bool flag7 = (object)obj.p == null;
					num5 = (float)playerPos;
					if (!flag7)
					{
						bool flag8 = ((UnityEngine.Object)p2).m_CachedPtr == (IntPtr)0;
						num5 = (float)playerPos;
						if (!flag8)
						{
							obj.p.DoSoulSteal(obj.enemies);
							num5 = (float)playerPos;
						}
					}
					goto IL_0475;
					IL_0475:
					num7++;
					float num11 = base.PAmount();
					continue;
					IL_05b5:
					bool flag9 = obj8 == null;
					flag6 = false;
					if (!flag9)
					{
						flag6 = flag5;
					}
					goto IL_0596;
				}
				while (num5 > (float)num7);
			}
		}
		float num12 = base.PInterval();
		float num13 = _lastFiringInterval - num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj9 = num13 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num14 = base.PInterval();
			_lastFiringInterval = num5;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	protected unsafe override void Awake()
	{
		//IL_006a: Expected O, but got I4
		//IL_011a: Expected I, but got O
		//IL_0130: Expected O, but got I
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_01a7: Expected I, but got O
		//IL_0402: Expected O, but got I4
		//IL_0419: Expected I, but got I8
		//IL_0190: Expected I, but got I8
		//IL_0471: Expected I, but got O
		//IL_048e->IL03e7: Incompatible stack heights: 1 vs 0
		//IL_02f1->IL03e7: Incompatible stack heights: 1 vs 0
		//IL_0340->IL03e7: Incompatible stack heights: 1 vs 0
		//IL_03d6->IL0493: Incompatible stack heights: 1 vs 0
		base.Awake();
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_SoulSteal0", 1, 3, "ThosePeople", num);
		List<PhaserSprite> list = new List<PhaserSprite>();
		explosionSprites = list;
		int num2 = 0;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		while (true)
		{
			_003C_003Ec__DisplayClass5_0 obj = new _003C_003Ec__DisplayClass5_0();
			PhaserWorld instance = PhaserWorld.Instance;
			if ((object)instance == null)
			{
				break;
			}
			PhaserSprite exp = instance.AddPhaserSprite((Vector2)0, "ThosePeople", "TP_SoulSteal01");
			if (obj == null)
			{
				break;
			}
			obj.exp = exp;
			PhaserSprite exp2 = obj.exp;
			if ((object)obj.exp == null)
			{
				break;
			}
			Action action = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass5_0._003CAwake_003Eb__0);
			((Delegate)action).m_target = obj;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num4;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num4 = unchecked((nint)6447293664L);
					goto IL_03f9;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num4 = ((Delegate)action).method_ptr;
			goto IL_03f9;
			IL_03f9:
			object obj4 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			if ((object)exp2._spriteAnimation == null)
			{
				break;
			}
			exp2._spriteAnimation.AddAnimation("bang", animationFrames, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			if ((object)obj.exp == null)
			{
				break;
			}
			PhaserSprite phaserSprite = obj.exp.setVisible(visible: false);
			if ((object)obj.exp == null)
			{
				break;
			}
			Transform transform = obj.exp.transform;
			if ((object)transform == null)
			{
				break;
			}
			bool flag = ((List<PhaserSprite>)(object)transform)._items == null;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v731 @ rcx_v29 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			Transform.SetParent_Injected((IntPtr)((List<PhaserSprite>)(object)transform)._items, (IntPtr)0, true);
			if ((object)obj.exp == null)
			{
				break;
			}
			PhaserSprite phaserSprite2 = obj.exp.setDepth(3000);
			List<object> list2 = (List<object>)(object)explosionSprites;
			if (explosionSprites == null)
			{
				break;
			}
			int version = list2._version + 1;
			list2._version = version;
			object[] items = list2._items;
			if (list2._items == null)
			{
				break;
			}
			if (list2._size >= items.Length)
			{
				((List<object>)(object)explosionSprites).AddWithResize((object)obj.exp);
			}
			else
			{
				int size = list2._size + 1;
				list2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num2++;
			if (num2 >= 200)
			{
				_exploIndex = 0;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void Hit(EnemyController enemyController)
	{
		//IL_00bb: Expected O, but got I4
		List<PhaserSprite> list = explosionSprites;
		int num = ++_exploIndex % list._size;
		if (num < list._size)
		{
			PhaserSprite[] items = list._items;
			PhaserSprite phaserSprite = items[num];
			float2 position = enemyController.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			PhaserSprite phaserSprite2 = items[num].setVisible(visible: true);
			PhaserSprite phaserSprite3 = items[num].setScale(2f, (float?)(object)0);
			phaserSprite._spriteAnimation.SetAnimation("bang");
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public override void ParadoxFire()
	{
		Action onComplete = delegate
		{
			Fire(skipTriggers: true);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Magic;
	}

	public override void ResetFiringTimer()
	{
		if (!_isManualFire)
		{
			base.ResetFiringTimer();
		}
		else if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if (!visible)
		{
			List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
			while (enumerator.MoveNext())
			{
			}
		}
	}

	private void _003CParadoxFire_003Eb__7_0()
	{
		Fire(skipTriggers: true);
	}
}
