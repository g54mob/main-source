using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Dominus1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public float __firstX;

		public float __firstY;

		public TP_Dominus1_Weapon _003C_003E4__this;

		public Vector2 velocity;

		public float __amount;

		public Action _003C_003E9__0;

		internal unsafe void _003CFireProjectiles_003Eb__0()
		{
			//IL_0036: Expected O, but got F4
			//IL_0086: Expected I4, but got O
			//IL_00cc: Expected I, but got O
			//IL_00dc: Expected O, but got I
			//IL_015c: Expected O, but got I4
			//IL_0118: Expected O, but got I
			//IL_0169: Expected O, but got I4
			//IL_014e: Expected O, but got I4
			//IL_0579: Expected I, but got O
			//IL_058f: Expected O, but got I
			//IL_0598: Unknown result type (might be due to invalid IL or missing references)
			//IL_059d: Expected O, but got Unknown
			//IL_0613: Expected I, but got O
			//IL_07ae: Expected O, but got I4
			//IL_07c5: Expected I, but got I8
			//IL_05ef: Expected I, but got I8
			//IL_01df: Invalid comparison between F4 and I4
			//IL_06ec: Expected I, but got O
			//IL_073e: Expected I, but got O
			//IL_04f6: Invalid comparison between F4 and I4
			//IL_0433: Expected I, but got O
			//IL_043b: Expected I, but got O
			//IL_044b: Expected O, but got I
			//IL_04cb: Expected O, but got I4
			//IL_0487: Expected O, but got I
			//IL_04bd: Expected O, but got I4
			//IL_083a->IL062b: Incompatible stack heights: 1 vs 0
			//IL_02d9->IL062b: Incompatible stack heights: 1 vs 0
			//IL_0320->IL062b: Incompatible stack heights: 1 vs 0
			//IL_034f->IL062b: Incompatible stack heights: 1 vs 0
			//IL_085c->IL062b: Incompatible stack heights: 2 vs 0
			//IL_0395->IL062b: Incompatible stack heights: 2 vs 0
			//IL_0507->IL0211: Incompatible stack heights: 2 vs 0
			//IL_0521->IL06aa: Incompatible stack heights: 2 vs 0
			//IL_0420->IL062b: Incompatible stack heights: 2 vs 0
			_003C_003Ec__DisplayClass19_1 obj = new _003C_003Ec__DisplayClass19_1();
			int num2;
			float2 pos = default(float2);
			TP_Dominus1_Projectile tP_Dominus1_Projectile;
			object obj4;
			if (obj != null)
			{
				obj.CS_0024_003C_003E8__locals1 = this;
				float num = __firstY - 0.16f;
				obj.__pos2 = (Vector2)__firstX;
				TP_Dominus1_Weapon tP_Dominus1_Weapon = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					num2 = (int)_003C_003E4__this.FireOneProjectile(pos, 0, tP_Dominus1_Weapon._targetTransform);
					if (num2 == 0)
					{
						tP_Dominus1_Projectile = null;
						goto IL_0685;
					}
					int value = ((int*)num2)->m_value;
					nint num3 = (nint)typeof(TP_Dominus1_Projectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Dominus1_Projectile>)+130]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ r8_v27 (System.Int32)+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Dominus1_Projectile>)+130]");
					if (num4 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ r8_v27 (System.Int32)+C8]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rax_v99+FFFFFFF8+v537 @ rax_v95*8]");
						if (0 == (nint)typeof(TP_Dominus1_Projectile))
						{
							obj4 = 1;
							goto IL_065d;
						}
					}
					obj4 = 0;
					goto IL_065d;
				}
			}
			goto IL_062b;
			IL_062b:
			throw new NullReferenceException();
			IL_0685:
			bool flag = (object)tP_Dominus1_Projectile == null;
			_003C_003Ec__DisplayClass19_1 target = obj;
			List<InvisibleProjectile> list;
			bool useRealTime = default(bool);
			bool flag4 = default(bool);
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)tP_Dominus1_Projectile).m_CachedPtr == (IntPtr)0;
				target = obj;
				if (!flag2)
				{
					tP_Dominus1_Projectile._initialVelocity = velocity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon+<>c__DisplayClass19_0)+24]");
					_ = 0;
					list = new List<InvisibleProjectile>();
					bool flag3 = !(__amount > 0f);
					int num5 = 0;
					target = obj;
					useRealTime = flag4;
					if (!flag3)
					{
						while (true)
						{
							TP_Dominus1_Weapon tP_Dominus1_Weapon2 = _003C_003E4__this;
							if ((object)_003C_003E4__this == null)
							{
								break;
							}
							ArcadeSprite arcadeSprite = ((Equipment)tP_Dominus1_Weapon2)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)tP_Dominus1_Weapon2)._003COwner_003Ek__BackingField == null)
							{
								break;
							}
							Transform cachedTrans = ((ArcadeSprite)((Equipment)tP_Dominus1_Weapon2)._003COwner_003Ek__BackingField).CachedTrans;
							if ((object)cachedTrans == null)
							{
								break;
							}
							bool flag5 = (object)((_003C_003Ec__DisplayClass19_1)(object)cachedTrans).__pos2 == null;
							float2 ret;
							Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass19_1)(object)cachedTrans).__pos2, out *(Vector3*)(&ret));
							if (arcadeSprite.body != null)
							{
								BaseBody body = arcadeSprite.body;
								ArcadeTransform transform = body._transform;
								if (body._transform == null)
								{
									break;
								}
								transform.position = ret;
							}
							TP_Dominus1_Weapon tP_Dominus1_Weapon3 = _003C_003E4__this;
							if ((object)_003C_003E4__this == null)
							{
								break;
							}
							ArcadeSprite arcadeSprite2 = ((Equipment)tP_Dominus1_Weapon3)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)tP_Dominus1_Weapon3)._003COwner_003Ek__BackingField == null)
							{
								break;
							}
							Transform cachedTrans2 = ((ArcadeSprite)((Equipment)tP_Dominus1_Weapon3)._003COwner_003Ek__BackingField).CachedTrans;
							if ((object)cachedTrans2 == null)
							{
								break;
							}
							bool flag6 = (object)((_003C_003Ec__DisplayClass19_1)(object)cachedTrans2).__pos2 == null;
							float2 ret2;
							Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass19_1)(object)cachedTrans2).__pos2, out *(Vector3*)(&ret2));
							if (arcadeSprite2.body != null)
							{
								BaseBody body2 = arcadeSprite2.body;
								ArcadeTransform transform2 = body2._transform;
								if (body2._transform == null)
								{
									break;
								}
								transform2.position = ret2;
							}
							if (tP_Dominus1_Weapon2._invisibleProjectilePool == null)
							{
								break;
							}
							Projectile projectile = tP_Dominus1_Weapon2._invisibleProjectilePool.SpawnAt(pos, _003C_003E4__this, num5);
							if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
							{
								goto IL_04dd;
							}
							if (list == null)
							{
								break;
							}
							nint num6 = (nint)typeof(InvisibleProjectile);
							nint num7 = (nint)projectile;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1514 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+130]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1515 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1514 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+130]");
							object obj7;
							if (num8 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1515 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1530 @ rax_v77+FFFFFFF8+v1516 @ rax_v72*8]");
								if (0 == (nint)typeof(InvisibleProjectile))
								{
									obj7 = 1;
									goto IL_0783;
								}
							}
							obj7 = 0;
							goto IL_0783;
							IL_0783:
							bool flag7 = obj7 == null;
							InvisibleProjectile item = null;
							if (!flag7)
							{
								item = (InvisibleProjectile)projectile;
							}
							list.Add(item);
							goto IL_04dd;
							IL_04dd:
							num5++;
							if (__amount > (float)num5)
							{
								continue;
							}
							goto IL_050c;
						}
						goto IL_062b;
					}
					goto IL_06aa;
				}
			}
			goto IL_0521;
			IL_07a5:
			object obj8 = 24;
			Action action;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer lastShotTimer = Timers.Register(0.15f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			TP_Dominus1_Weapon tP_Dominus1_Weapon4;
			if ((object)_003C_003E4__this != null)
			{
				tP_Dominus1_Weapon4._lastShotTimer = lastShotTimer;
				return;
			}
			goto IL_062b;
			IL_0521:
			tP_Dominus1_Weapon4 = _003C_003E4__this;
			action = null;
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v7 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass19_1._003CFireProjectiles_003Eb__1);
			((Delegate)action).m_target = target;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v7 (Il2CppMethodInfo)+4C]");
			object obj9 = (nint)0 >> 4;
			object obj10 = obj9 & 1;
			nint num10;
			if (obj10 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v7 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num10 = unchecked((nint)6447293664L);
					goto IL_07a5;
				}
			}
			num10 = ((Delegate)action).method_ptr;
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			goto IL_07a5;
			IL_06aa:
			tP_Dominus1_Projectile.SetDamageBoxes(list);
			goto IL_0521;
			IL_050c:
			target = obj;
			useRealTime = flag4;
			goto IL_06aa;
			IL_065d:
			bool flag8 = obj4 == null;
			tP_Dominus1_Projectile = null;
			if (!flag8)
			{
				tP_Dominus1_Projectile = (TP_Dominus1_Projectile)num2;
			}
			goto IL_0685;
		}
	}

	private sealed class _003C_003Ec__DisplayClass19_1
	{
		public Vector2 __pos2;

		public _003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CFireProjectiles_003Eb__1()
		{
			//IL_063d: Expected O, but got I4
			//IL_00cd: Expected I4, but got O
			//IL_0113: Expected I, but got O
			//IL_0123: Expected O, but got I
			//IL_01a3: Expected O, but got I4
			//IL_015f: Expected O, but got I
			//IL_01b0: Expected O, but got I4
			//IL_0195: Expected O, but got I4
			//IL_07ab: Invalid comparison between F4 and I4
			//IL_04dc: Expected I, but got O
			//IL_04e4: Expected I, but got O
			//IL_04f4: Expected O, but got I
			//IL_0574: Expected O, but got I4
			//IL_0530: Expected O, but got I
			//IL_0566: Expected O, but got I4
			//IL_05e4->IL05e4: Incompatible stack heights: 3 vs 0
			//IL_06a9->IL05d9: Incompatible stack heights: 5 vs 3
			//IL_01e2->IL05d9: Incompatible stack heights: 5 vs 3
			//IL_05d9->IL05d9: Incompatible stack heights: 7 vs 3
			//IL_0363->IL07c2: Incompatible stack heights: 13 vs 12
			//IL_043d->IL07e7: Incompatible stack heights: 18 vs 17
			//IL_05c7->IL079d: Incompatible stack heights: 20 vs 7
			//IL_081f->IL0586: Incompatible stack heights: 20 vs 19
			GameObject gameObject;
			while (true)
			{
				_003C_003Ec__DisplayClass19_0 obj = CS_0024_003C_003E8__locals1;
				bool flag = CS_0024_003C_003E8__locals1 == null;
				bool flag2 = (object)obj._003C_003E4__this == null;
				gameObject = obj._003C_003E4__this.gameObject;
				bool flag3 = (object)gameObject == null;
				if (((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
				{
					break;
				}
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(gameObject);
			}
			object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj2 == null)
			{
				return;
			}
			_003C_003Ec__DisplayClass19_0 obj3 = CS_0024_003C_003E8__locals1;
			bool flag4 = CS_0024_003C_003E8__locals1 == null;
			TP_Dominus1_Weapon tP_Dominus1_Weapon = obj3._003C_003E4__this;
			bool flag5 = (object)obj3._003C_003E4__this == null;
			float2 pos = default(float2);
			int num = (int)obj3._003C_003E4__this.FireOneProjectile(pos, 1, tP_Dominus1_Weapon._targetTransform);
			TP_Dominus1_Projectile tP_Dominus1_Projectile;
			if (num == 0)
			{
				tP_Dominus1_Projectile = null;
				goto IL_065a;
			}
			int value = ((int*)num)->m_value;
			nint num2 = (nint)typeof(TP_Dominus1_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v884 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Dominus1_Projectile>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ r8_v16 (System.Int32)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v884 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Dominus1_Projectile>)+130]");
			object obj6;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ r8_v16 (System.Int32)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v947 @ rax_v92+FFFFFFF8+v885 @ rax_v88*8]");
				if (0 == (nint)typeof(TP_Dominus1_Projectile))
				{
					obj6 = 1;
					goto IL_0669;
				}
			}
			obj6 = 0;
			goto IL_0669;
			IL_0669:
			bool flag6 = obj6 == null;
			tP_Dominus1_Projectile = null;
			if (!flag6)
			{
				tP_Dominus1_Projectile = (TP_Dominus1_Projectile)num;
			}
			goto IL_065a;
			IL_065a:
			List<InvisibleProjectile> list = new List<InvisibleProjectile>();
			if ((object)tP_Dominus1_Projectile == null || ((UnityEngine.Object)tP_Dominus1_Projectile).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			_003C_003Ec__DisplayClass19_0 obj7 = CS_0024_003C_003E8__locals1;
			bool flag7 = CS_0024_003C_003E8__locals1 == null;
			tP_Dominus1_Projectile._initialVelocity = obj7.velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v37 (VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon+<>c__DisplayClass19_0)+24]");
			_ = 0;
			_003C_003Ec__DisplayClass19_0 obj8 = CS_0024_003C_003E8__locals1;
			bool flag8 = CS_0024_003C_003E8__locals1 == null;
			int i = 0;
			bool flag25;
			for (int num4 = 0; obj8.__amount > (float)num4; obj8 = CS_0024_003C_003E8__locals1, i++, flag25 = CS_0024_003C_003E8__locals1 == null, num4 = i)
			{
				_003C_003Ec__DisplayClass19_0 obj9 = CS_0024_003C_003E8__locals1;
				bool flag9 = CS_0024_003C_003E8__locals1 == null;
				TP_Dominus1_Weapon tP_Dominus1_Weapon2 = obj9._003C_003E4__this;
				bool flag10 = (object)obj9._003C_003E4__this == null;
				ArcadeSprite arcadeSprite = ((Equipment)tP_Dominus1_Weapon2)._003COwner_003Ek__BackingField;
				bool flag11 = (object)((Equipment)tP_Dominus1_Weapon2)._003COwner_003Ek__BackingField == null;
				Transform cachedTrans = ((ArcadeSprite)((Equipment)tP_Dominus1_Weapon2)._003COwner_003Ek__BackingField).CachedTrans;
				bool flag12 = (object)cachedTrans == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v42 (UnityEngine.Transform)+10]");
				bool flag13 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v42 (UnityEngine.Transform)+10]");
				float2 ret;
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
				if (arcadeSprite.body != null)
				{
					BaseBody body = arcadeSprite.body;
					ArcadeTransform transform = body._transform;
					bool flag14 = body._transform == null;
					transform.position = ret;
				}
				_003C_003Ec__DisplayClass19_0 obj10 = CS_0024_003C_003E8__locals1;
				bool flag15 = CS_0024_003C_003E8__locals1 == null;
				TP_Dominus1_Weapon tP_Dominus1_Weapon3 = obj10._003C_003E4__this;
				bool flag16 = (object)obj10._003C_003E4__this == null;
				ArcadeSprite arcadeSprite2 = ((Equipment)tP_Dominus1_Weapon3)._003COwner_003Ek__BackingField;
				bool flag17 = (object)((Equipment)tP_Dominus1_Weapon3)._003COwner_003Ek__BackingField == null;
				Transform cachedTrans2 = ((ArcadeSprite)((Equipment)tP_Dominus1_Weapon3)._003COwner_003Ek__BackingField).CachedTrans;
				bool flag18 = (object)cachedTrans2 == null;
				bool flag19 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
				float2 ret2;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out *(Vector3*)(&ret2));
				if (arcadeSprite2.body != null)
				{
					BaseBody body2 = arcadeSprite2.body;
					ArcadeTransform transform2 = body2._transform;
					bool flag20 = body2._transform == null;
					transform2.position = ret2;
				}
				_003C_003Ec__DisplayClass19_0 obj11 = CS_0024_003C_003E8__locals1;
				bool flag21 = CS_0024_003C_003E8__locals1 == null;
				bool flag22 = tP_Dominus1_Weapon2._invisibleProjectilePool == null;
				Projectile projectile = tP_Dominus1_Weapon2._invisibleProjectilePool.SpawnAt(pos, obj11._003C_003E4__this, i);
				if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
				{
					continue;
				}
				bool flag23 = list == null;
				nint num5 = (nint)typeof(InvisibleProjectile);
				nint num6 = (nint)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1318 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+130]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1319 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1318 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+130]");
				object obj14;
				if (num7 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1319 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ rax_v70+FFFFFFF8+v1320 @ rax_v65*8]");
					if (0 == (nint)typeof(InvisibleProjectile))
					{
						obj14 = 1;
						goto IL_077b;
					}
				}
				obj14 = 0;
				goto IL_077b;
				IL_077b:
				bool flag24 = obj14 == null;
				InvisibleProjectile item = null;
				if (!flag24)
				{
					item = (InvisibleProjectile)projectile;
				}
				list.Add(item);
			}
			tP_Dominus1_Projectile.SetDamageBoxes(list);
		}
	}

	private BulletPool _invisibleProjectilePool;

	private Projectile _invisibleProjectilePrefab;

	private bool _003CInverted_003Ek__BackingField;

	private bool _initialisedParticles;

	private bool _isManualFire;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	public bool Inverted
	{
		get
		{
			return _003CInverted_003Ek__BackingField;
		}
		set
		{
			_003CInverted_003Ek__BackingField = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		_003CInverted_003Ek__BackingField = false;
	}

	public void SetManualFire()
	{
		_isManualFire = true;
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0055: Expected I, but got O
		//IL_00f8: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
		BulletPool invisibleProjectilePool = new BulletPool(_invisibleProjectilePrefab);
		_invisibleProjectilePool = invisibleProjectilePool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num3 = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_invisibleProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num4 = (nint)this;
			Collider collider2 = physics2.add.overlap(_invisibleProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if (_isManualFire)
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
			}
		}
	}

	public override bool LevelUp()
	{
		//IL_0078: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		if (((Equipment)this)._003CLevel_003Ek__BackingField >= 6)
		{
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			currentWeaponData._003Cpenetrating_003Ek__BackingField = 65535;
		}
		return result;
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
		//IL_014c: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_DarkInferno, soundConfig, 200f, 2, time);
		if (!((Equipment)this)._003COwner_003Ek__BackingField.DrainWeaponsImmunity)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num2 = characterController._currentHp / 0f;
			float num3 = num2 * 4f;
			bool flag = !(1f < num3);
			float num4 = 1f;
			if (!flag)
			{
				num4 = num3;
			}
			float num5 = num4 + 1f;
			if (characterController2._currentHp > num5)
			{
				characterController2.TriggerGetDamagedByOwnWeapon(num4);
			}
		}
		FireProjectiles();
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public unsafe void FireProjectiles()
	{
		//IL_0079: Expected F4, but got O
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals24 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals24._003C_003E4__this = this;
		float num = base.PAmount();
		float num2 = default(float);
		CS_0024_003C_003E8__locals24.__amount = num2;
		float num3 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float num4 = num2 / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		CS_0024_003C_003E8__locals24.__firstX = (float)position;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num5 = default(float);
		CS_0024_003C_003E8__locals24.__firstY = num5;
		Vector2 velocityToNearestEnemy = GetVelocityToNearestEnemy();
		CS_0024_003C_003E8__locals24.velocity = velocityToNearestEnemy;
		object obj = default(object);
		if ((nint)obj <= 0)
		{
			return;
		}
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float num6 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num5);
			Action onComplete = CS_0024_003C_003E8__locals24._003C_003E9__0;
			if (CS_0024_003C_003E8__locals24._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals24._003C_003E9__0 = delegate
				{
					//IL_0036: Expected O, but got F4
					//IL_0086: Expected I4, but got O
					//IL_00cc: Expected I, but got O
					//IL_00dc: Expected O, but got I
					//IL_015c: Expected O, but got I4
					//IL_0118: Expected O, but got I
					//IL_0169: Expected O, but got I4
					//IL_014e: Expected O, but got I4
					//IL_0579: Expected I, but got O
					//IL_058f: Expected O, but got I
					//IL_0598: Unknown result type (might be due to invalid IL or missing references)
					//IL_059d: Expected O, but got Unknown
					//IL_0613: Expected I, but got O
					//IL_07ae: Expected O, but got I4
					//IL_07c5: Expected I, but got I8
					//IL_05ef: Expected I, but got I8
					//IL_01df: Invalid comparison between F4 and I4
					//IL_06ec: Expected I, but got O
					//IL_073e: Expected I, but got O
					//IL_04f6: Invalid comparison between F4 and I4
					//IL_0433: Expected I, but got O
					//IL_043b: Expected I, but got O
					//IL_044b: Expected O, but got I
					//IL_04cb: Expected O, but got I4
					//IL_0487: Expected O, but got I
					//IL_04bd: Expected O, but got I4
					//IL_083a->IL062b: Incompatible stack heights: 1 vs 0
					//IL_02d9->IL062b: Incompatible stack heights: 1 vs 0
					//IL_0320->IL062b: Incompatible stack heights: 1 vs 0
					//IL_034f->IL062b: Incompatible stack heights: 1 vs 0
					//IL_085c->IL062b: Incompatible stack heights: 2 vs 0
					//IL_0395->IL062b: Incompatible stack heights: 2 vs 0
					//IL_0507->IL0211: Incompatible stack heights: 2 vs 0
					//IL_0521->IL06aa: Incompatible stack heights: 2 vs 0
					//IL_0420->IL062b: Incompatible stack heights: 2 vs 0
					_003C_003Ec__DisplayClass19_1 obj2 = new _003C_003Ec__DisplayClass19_1();
					int num10;
					float2 pos = default(float2);
					object obj5;
					TP_Dominus1_Projectile tP_Dominus1_Projectile;
					if (obj2 != null)
					{
						obj2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals24;
						float num9 = CS_0024_003C_003E8__locals24.__firstY - 0.16f;
						obj2.__pos2 = (Vector2)CS_0024_003C_003E8__locals24.__firstX;
						TP_Dominus1_Weapon tP_Dominus1_Weapon = CS_0024_003C_003E8__locals24._003C_003E4__this;
						if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this != null)
						{
							num10 = (int)CS_0024_003C_003E8__locals24._003C_003E4__this.FireOneProjectile(pos, 0, tP_Dominus1_Weapon._targetTransform);
							if (num10 != 0)
							{
								int value = ((int*)num10)->m_value;
								nint num11 = (nint)typeof(TP_Dominus1_Projectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Dominus1_Projectile>)+130]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ r8_v27 (System.Int32)+130]");
								nint num12 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Dominus1_Projectile>)+130]");
								if (num12 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ r8_v27 (System.Int32)+C8]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rax_v99+FFFFFFF8+v537 @ rax_v95*8]");
									if (0 == (nint)typeof(TP_Dominus1_Projectile))
									{
										obj5 = 1;
										goto IL_065d;
									}
								}
								obj5 = 0;
								goto IL_065d;
							}
							tP_Dominus1_Projectile = null;
							goto IL_0685;
						}
					}
					goto IL_062b;
					IL_062b:
					throw new NullReferenceException();
					IL_0685:
					bool flag2 = (object)tP_Dominus1_Projectile == null;
					_003C_003Ec__DisplayClass19_1 target = obj2;
					List<InvisibleProjectile> list;
					bool useRealTime2 = default(bool);
					bool flag5 = default(bool);
					if (!flag2)
					{
						bool flag3 = ((UnityEngine.Object)tP_Dominus1_Projectile).m_CachedPtr == (IntPtr)0;
						target = obj2;
						if (!flag3)
						{
							tP_Dominus1_Projectile._initialVelocity = CS_0024_003C_003E8__locals24.velocity;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon+<>c__DisplayClass19_0)+24]");
							_ = 0;
							list = new List<InvisibleProjectile>();
							bool flag4 = !(CS_0024_003C_003E8__locals24.__amount > 0f);
							int num13 = 0;
							target = obj2;
							useRealTime2 = flag5;
							if (!flag4)
							{
								while (true)
								{
									TP_Dominus1_Weapon tP_Dominus1_Weapon2 = CS_0024_003C_003E8__locals24._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this == null)
									{
										break;
									}
									ArcadeSprite arcadeSprite = ((Equipment)tP_Dominus1_Weapon2)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)tP_Dominus1_Weapon2)._003COwner_003Ek__BackingField == null)
									{
										break;
									}
									Transform cachedTrans = ((ArcadeSprite)((Equipment)tP_Dominus1_Weapon2)._003COwner_003Ek__BackingField).CachedTrans;
									if ((object)cachedTrans == null)
									{
										break;
									}
									bool flag6 = (object)((_003C_003Ec__DisplayClass19_1)(object)cachedTrans).__pos2 == null;
									float2 ret;
									Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass19_1)(object)cachedTrans).__pos2, out *(Vector3*)(&ret));
									if (arcadeSprite.body != null)
									{
										BaseBody body = arcadeSprite.body;
										ArcadeTransform arcadeTransform = body._transform;
										if (body._transform == null)
										{
											break;
										}
										arcadeTransform.position = ret;
									}
									TP_Dominus1_Weapon tP_Dominus1_Weapon3 = CS_0024_003C_003E8__locals24._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this == null)
									{
										break;
									}
									ArcadeSprite arcadeSprite2 = ((Equipment)tP_Dominus1_Weapon3)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)tP_Dominus1_Weapon3)._003COwner_003Ek__BackingField == null)
									{
										break;
									}
									Transform cachedTrans2 = ((ArcadeSprite)((Equipment)tP_Dominus1_Weapon3)._003COwner_003Ek__BackingField).CachedTrans;
									if ((object)cachedTrans2 == null)
									{
										break;
									}
									bool flag7 = (object)((_003C_003Ec__DisplayClass19_1)(object)cachedTrans2).__pos2 == null;
									float2 ret2;
									Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass19_1)(object)cachedTrans2).__pos2, out *(Vector3*)(&ret2));
									if (arcadeSprite2.body != null)
									{
										BaseBody body2 = arcadeSprite2.body;
										ArcadeTransform arcadeTransform2 = body2._transform;
										if (body2._transform == null)
										{
											break;
										}
										arcadeTransform2.position = ret2;
									}
									if (tP_Dominus1_Weapon2._invisibleProjectilePool == null)
									{
										break;
									}
									Projectile projectile = tP_Dominus1_Weapon2._invisibleProjectilePool.SpawnAt(pos, CS_0024_003C_003E8__locals24._003C_003E4__this, num13);
									if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
									{
										goto IL_04dd;
									}
									if (list == null)
									{
										break;
									}
									nint num14 = (nint)typeof(InvisibleProjectile);
									nint num15 = (nint)projectile;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1514 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+130]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1515 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
									nint num16 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1514 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+130]");
									object obj8;
									if (num16 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1515 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
										object obj7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1530 @ rax_v77+FFFFFFF8+v1516 @ rax_v72*8]");
										if (0 == (nint)typeof(InvisibleProjectile))
										{
											obj8 = 1;
											goto IL_0783;
										}
									}
									obj8 = 0;
									goto IL_0783;
									IL_0783:
									bool flag8 = obj8 == null;
									InvisibleProjectile item = null;
									if (!flag8)
									{
										item = (InvisibleProjectile)projectile;
									}
									list.Add(item);
									goto IL_04dd;
									IL_04dd:
									num13++;
									if (CS_0024_003C_003E8__locals24.__amount > (float)num13)
									{
										continue;
									}
									goto IL_050c;
								}
								goto IL_062b;
							}
							goto IL_06aa;
						}
					}
					goto IL_0521;
					IL_07a5:
					object obj9 = 24;
					Action action;
					((Delegate)action).extra_arg = unchecked((nint)6447293568L);
					MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
					int repeat2 = default(int);
					TimerType type2 = default(TimerType);
					Timer lastShotTimer = Timers.Register(0.15f, action, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
					TP_Dominus1_Weapon tP_Dominus1_Weapon4;
					if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this != null)
					{
						tP_Dominus1_Weapon4._lastShotTimer = lastShotTimer;
						return;
					}
					goto IL_062b;
					IL_0521:
					tP_Dominus1_Weapon4 = CS_0024_003C_003E8__locals24._003C_003E4__this;
					action = null;
					nint num17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v7 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass19_1._003CFireProjectiles_003Eb__1);
					((Delegate)action).m_target = target;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v7 (Il2CppMethodInfo)+4C]");
					object obj10 = (nint)0 >> 4;
					object obj11 = obj10 & 1;
					nint num18;
					if (obj11 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v7 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num18 = unchecked((nint)6447293664L);
							goto IL_07a5;
						}
					}
					num18 = ((Delegate)action).method_ptr;
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					goto IL_07a5;
					IL_06aa:
					tP_Dominus1_Projectile.SetDamageBoxes(list);
					goto IL_0521;
					IL_050c:
					target = obj2;
					useRealTime2 = flag5;
					goto IL_06aa;
					IL_065d:
					bool flag9 = obj5 == null;
					tP_Dominus1_Projectile = null;
					if (!flag9)
					{
						tP_Dominus1_Projectile = (TP_Dominus1_Projectile)num10;
					}
					goto IL_0685;
				});
			}
			float num7 = (float)(flag ? 1 : 0) * num6;
			float num8 = num7 + 1f;
			float duration = num8 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < (nint)obj);
	}

	protected unsafe Vector2 GetVelocityToNearestEnemy()
	{
		//IL_003f: Expected O, but got Ref
		//IL_00ea: Invalid comparison between O and F4
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_01f0: Expected I, but got O
		//IL_0219: Expected O, but got I
		//IL_00aa: Invalid comparison between O and F4
		GameManager core = GM.Core;
		Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
		if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
		{
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
			throw new NullReferenceException();
		}
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		object obj = default(object);
		EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj));
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if ((object)enemyController != null)
		{
			bool flag = ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0;
			characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (!flag)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
				if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
				{
				}
				goto IL_01dd;
			}
		}
		else
		{
			characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		Vector2 vector;
		object obj2;
		if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
		{
			vector = (Vector2)((object)characterController._lastFacingDirection / (object)ret);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v24 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
			obj2 = 0 / ret;
		}
		else
		{
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v28 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			vector = Vector2.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rcx_v22 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
			obj2 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187411C45h\"");
		if ((object)vector == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187411C45h\"");
			if (obj2 != null)
			{
			}
		}
		goto IL_01dd;
		IL_01dd:
		Vector2 result = default(Vector2);
		return result;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
	}
}
