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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Ice2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__12_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__12_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1457;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public float __firstX;

		public float __firstY;

		public TP_Ice2_Weapon _003C_003E4__this;

		public float __repeatInterval;

		public float __unit;

		public float _fixedAmount;
	}

	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_0035: Expected O, but got F4
			_003C_003Ec__DisplayClass16_2 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass16_2();
			CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2 = this;
			_003C_003Ec__DisplayClass16_0 obj = CS_0024_003C_003E8__locals1;
			CS_0024_003C_003E8__locals17.__pos = (Vector2)obj.__firstX;
			_ = obj.__firstY;
			_003C_003Ec__DisplayClass16_0 obj2 = CS_0024_003C_003E8__locals1;
			TP_Ice2_Weapon tP_Ice2_Weapon = obj2._003C_003E4__this;
			Vector2 vector = default(Vector2);
			Projectile projectile = obj2._003C_003E4__this.FireOneProjectile(vector, localIndex, tP_Ice2_Weapon._targetTransform);
			_003C_003Ec__DisplayClass16_0 obj3 = CS_0024_003C_003E8__locals1;
			float num = obj3._003C_003E4__this.PAmount();
			if ((nint)vector <= 0)
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
				_003C_003Ec__DisplayClass16_0 obj4 = CS_0024_003C_003E8__locals1;
				Action onComplete = CS_0024_003C_003E8__locals17._003C_003E9__1;
				TP_Ice2_Weapon tP_Ice2_Weapon2 = obj4._003C_003E4__this;
				if (CS_0024_003C_003E8__locals17._003C_003E9__1 == null)
				{
					onComplete = (CS_0024_003C_003E8__locals17._003C_003E9__1 = delegate
					{
						//IL_0300: Expected O, but got I4
						//IL_010a: Invalid comparison between F4 and O
						//IL_017a: Unknown result type (might be due to invalid IL or missing references)
						//IL_017f: Expected O, but got Unknown
						//IL_0196: Unknown result type (might be due to invalid IL or missing references)
						//IL_019b: Expected O, but got Unknown
						//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
						//IL_01ad: Expected O, but got Unknown
						//IL_01bc: Expected O, but got F4
						//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
						//IL_02a7: Expected O, but got Unknown
						//IL_011c->IL02cf: Incompatible stack heights: 7 vs 5
						//IL_02cf->IL00d2: Incompatible stack heights: 14 vs 6
						_003C_003Ec__DisplayClass16_1 obj5 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2;
						bool flag2 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2 == null;
						_003C_003Ec__DisplayClass16_0 obj6 = obj5.CS_0024_003C_003E8__locals1;
						bool flag3 = obj5.CS_0024_003C_003E8__locals1 == null;
						bool flag4 = (object)obj6._003C_003E4__this == null;
						GameObject gameObject = obj6._003C_003E4__this.gameObject;
						bool flag5 = (object)gameObject == null;
						bool flag6 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj7 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj7 != null)
						{
							_003C_003Ec__DisplayClass16_1 obj8 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2;
							bool flag7 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2 == null;
							GameObject gameObject2 = null;
							GameObject gameObject3 = null;
							float2 pos = default(float2);
							while (true)
							{
								_003C_003Ec__DisplayClass16_0 obj9 = obj8.CS_0024_003C_003E8__locals1;
								bool flag8 = obj8.CS_0024_003C_003E8__locals1 == null;
								float fixedAmount = obj9._fixedAmount;
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)fixedAmount) <= System.Runtime.CompilerServices.Unsafe.As<GameObject, UIntPtr>(ref gameObject3))
								{
									break;
								}
								_003C_003Ec__DisplayClass16_1 obj10 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2;
								bool flag9 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2 == null;
								_003C_003Ec__DisplayClass16_0 obj11 = obj10.CS_0024_003C_003E8__locals1;
								bool flag10 = obj10.CS_0024_003C_003E8__locals1 == null;
								object obj12 = gameObject2 + 1;
								_003C_003Ec__DisplayClass16_1 obj13 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2;
								object obj14 = obj12 * obj11.__unit;
								object obj15 = obj14 + obj11.__firstY;
								CS_0024_003C_003E8__locals17.__pos = (Vector2)obj11.__firstX;
								bool flag11 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2 == null;
								_003C_003Ec__DisplayClass16_0 obj16 = obj13.CS_0024_003C_003E8__locals1;
								bool flag12 = obj13.CS_0024_003C_003E8__locals1 == null;
								TP_Ice2_Weapon tP_Ice2_Weapon3 = obj16._003C_003E4__this;
								bool flag13 = (object)obj16._003C_003E4__this == null;
								_003C_003Ec__DisplayClass16_1 obj17 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2;
								_003C_003Ec__DisplayClass16_0 obj18 = obj17.CS_0024_003C_003E8__locals1;
								bool flag14 = tP_Ice2_Weapon3._invisibleProjectilePool == null;
								Projectile projectile2 = tP_Ice2_Weapon3._invisibleProjectilePool.SpawnAt(pos, obj18._003C_003E4__this, obj17.localIndex);
								obj8 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2;
								gameObject2 = (GameObject)(gameObject2 + 1);
								bool flag15 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals2 == null;
								gameObject3 = gameObject2;
							}
						}
					});
				}
				float num2 = (float)(flag ? 1 : 0) * obj4.__repeatInterval;
				float num3 = num2 + 1f;
				float duration = num3 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				tP_Ice2_Weapon2._lastShotTimer = lastShotTimer;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while ((nint)vector > (flag ? 1 : 0));
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_2
	{
		public Vector2 __pos;

		public _003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals2;

		public Action _003C_003E9__1;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_0300: Expected O, but got I4
			//IL_010a: Invalid comparison between F4 and O
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Expected O, but got Unknown
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Expected O, but got Unknown
			//IL_01bc: Expected O, but got F4
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Expected O, but got Unknown
			//IL_011c->IL02cf: Incompatible stack heights: 7 vs 5
			//IL_02cf->IL00d2: Incompatible stack heights: 14 vs 6
			_003C_003Ec__DisplayClass16_1 obj = CS_0024_003C_003E8__locals2;
			bool flag = CS_0024_003C_003E8__locals2 == null;
			_003C_003Ec__DisplayClass16_0 obj2 = obj.CS_0024_003C_003E8__locals1;
			bool flag2 = obj.CS_0024_003C_003E8__locals1 == null;
			bool flag3 = (object)obj2._003C_003E4__this == null;
			GameObject gameObject = obj2._003C_003E4__this.gameObject;
			bool flag4 = (object)gameObject == null;
			bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj3 == null)
			{
				return;
			}
			_003C_003Ec__DisplayClass16_1 obj4 = CS_0024_003C_003E8__locals2;
			bool flag6 = CS_0024_003C_003E8__locals2 == null;
			GameObject gameObject2 = null;
			GameObject gameObject3 = null;
			float2 pos = default(float2);
			while (true)
			{
				_003C_003Ec__DisplayClass16_0 obj5 = obj4.CS_0024_003C_003E8__locals1;
				bool flag7 = obj4.CS_0024_003C_003E8__locals1 == null;
				float fixedAmount = obj5._fixedAmount;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)fixedAmount) > System.Runtime.CompilerServices.Unsafe.As<GameObject, UIntPtr>(ref gameObject3))
				{
					_003C_003Ec__DisplayClass16_1 obj6 = CS_0024_003C_003E8__locals2;
					bool flag8 = CS_0024_003C_003E8__locals2 == null;
					_003C_003Ec__DisplayClass16_0 obj7 = obj6.CS_0024_003C_003E8__locals1;
					bool flag9 = obj6.CS_0024_003C_003E8__locals1 == null;
					object obj8 = gameObject2 + 1;
					_003C_003Ec__DisplayClass16_1 obj9 = CS_0024_003C_003E8__locals2;
					object obj10 = obj8 * obj7.__unit;
					object obj11 = obj10 + obj7.__firstY;
					__pos = (Vector2)obj7.__firstX;
					bool flag10 = CS_0024_003C_003E8__locals2 == null;
					_003C_003Ec__DisplayClass16_0 obj12 = obj9.CS_0024_003C_003E8__locals1;
					bool flag11 = obj9.CS_0024_003C_003E8__locals1 == null;
					TP_Ice2_Weapon tP_Ice2_Weapon = obj12._003C_003E4__this;
					bool flag12 = (object)obj12._003C_003E4__this == null;
					_003C_003Ec__DisplayClass16_1 obj13 = CS_0024_003C_003E8__locals2;
					_003C_003Ec__DisplayClass16_0 obj14 = obj13.CS_0024_003C_003E8__locals1;
					bool flag13 = tP_Ice2_Weapon._invisibleProjectilePool == null;
					Projectile projectile = tP_Ice2_Weapon._invisibleProjectilePool.SpawnAt(pos, obj14._003C_003E4__this, obj13.localIndex);
					obj4 = CS_0024_003C_003E8__locals2;
					gameObject2 = (GameObject)(gameObject2 + 1);
					bool flag14 = CS_0024_003C_003E8__locals2 == null;
					gameObject3 = gameObject2;
					continue;
				}
				break;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_3
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals3;

		internal void _003CFireProjectiles_003Eb__2()
		{
			//IL_0035: Expected O, but got F4
			_003C_003Ec__DisplayClass16_4 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass16_4();
			CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4 = this;
			_003C_003Ec__DisplayClass16_0 obj = CS_0024_003C_003E8__locals3;
			CS_0024_003C_003E8__locals17.__pos = (Vector2)obj.__firstX;
			_ = obj.__firstY;
			_003C_003Ec__DisplayClass16_0 obj2 = CS_0024_003C_003E8__locals3;
			TP_Ice2_Weapon tP_Ice2_Weapon = obj2._003C_003E4__this;
			Vector2 vector = default(Vector2);
			Projectile projectile = obj2._003C_003E4__this.FireOneProjectile(vector, localIndex, tP_Ice2_Weapon._targetTransform);
			_003C_003Ec__DisplayClass16_0 obj3 = CS_0024_003C_003E8__locals3;
			float num = obj3._003C_003E4__this.PAmount();
			if ((nint)vector <= 0)
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
				_003C_003Ec__DisplayClass16_0 obj4 = CS_0024_003C_003E8__locals3;
				Action onComplete = CS_0024_003C_003E8__locals17._003C_003E9__3;
				TP_Ice2_Weapon tP_Ice2_Weapon2 = obj4._003C_003E4__this;
				if (CS_0024_003C_003E8__locals17._003C_003E9__3 == null)
				{
					onComplete = (CS_0024_003C_003E8__locals17._003C_003E9__3 = delegate
					{
						//IL_0300: Expected O, but got I4
						//IL_010a: Invalid comparison between F4 and O
						//IL_017a: Unknown result type (might be due to invalid IL or missing references)
						//IL_017f: Expected O, but got Unknown
						//IL_0196: Unknown result type (might be due to invalid IL or missing references)
						//IL_019b: Expected O, but got Unknown
						//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
						//IL_01ad: Expected O, but got Unknown
						//IL_01bc: Expected O, but got F4
						//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
						//IL_02a7: Expected O, but got Unknown
						//IL_011c->IL02cf: Incompatible stack heights: 7 vs 5
						//IL_02cf->IL00d2: Incompatible stack heights: 14 vs 6
						_003C_003Ec__DisplayClass16_3 obj5 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4;
						bool flag2 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4 == null;
						_003C_003Ec__DisplayClass16_0 obj6 = obj5.CS_0024_003C_003E8__locals3;
						bool flag3 = obj5.CS_0024_003C_003E8__locals3 == null;
						bool flag4 = (object)obj6._003C_003E4__this == null;
						GameObject gameObject = obj6._003C_003E4__this.gameObject;
						bool flag5 = (object)gameObject == null;
						bool flag6 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj7 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj7 != null)
						{
							_003C_003Ec__DisplayClass16_3 obj8 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4;
							bool flag7 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4 == null;
							GameObject gameObject2 = null;
							GameObject gameObject3 = null;
							float2 pos = default(float2);
							while (true)
							{
								_003C_003Ec__DisplayClass16_0 obj9 = obj8.CS_0024_003C_003E8__locals3;
								bool flag8 = obj8.CS_0024_003C_003E8__locals3 == null;
								float fixedAmount = obj9._fixedAmount;
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)fixedAmount) <= System.Runtime.CompilerServices.Unsafe.As<GameObject, UIntPtr>(ref gameObject3))
								{
									break;
								}
								_003C_003Ec__DisplayClass16_3 obj10 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4;
								bool flag9 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4 == null;
								_003C_003Ec__DisplayClass16_0 obj11 = obj10.CS_0024_003C_003E8__locals3;
								bool flag10 = obj10.CS_0024_003C_003E8__locals3 == null;
								object obj12 = gameObject2 + 1;
								_003C_003Ec__DisplayClass16_3 obj13 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4;
								object obj14 = obj12 * obj11.__unit;
								object obj15 = obj14 + obj11.__firstY;
								CS_0024_003C_003E8__locals17.__pos = (Vector2)obj11.__firstX;
								bool flag11 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4 == null;
								_003C_003Ec__DisplayClass16_0 obj16 = obj13.CS_0024_003C_003E8__locals3;
								bool flag12 = obj13.CS_0024_003C_003E8__locals3 == null;
								TP_Ice2_Weapon tP_Ice2_Weapon3 = obj16._003C_003E4__this;
								bool flag13 = (object)obj16._003C_003E4__this == null;
								_003C_003Ec__DisplayClass16_3 obj17 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4;
								_003C_003Ec__DisplayClass16_0 obj18 = obj17.CS_0024_003C_003E8__locals3;
								bool flag14 = tP_Ice2_Weapon3._invisibleProjectilePool == null;
								Projectile projectile2 = tP_Ice2_Weapon3._invisibleProjectilePool.SpawnAt(pos, obj18._003C_003E4__this, obj17.localIndex);
								obj8 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4;
								gameObject2 = (GameObject)(gameObject2 + 1);
								bool flag15 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals4 == null;
								gameObject3 = gameObject2;
							}
						}
					});
				}
				float num2 = (float)(flag ? 1 : 0) * obj4.__repeatInterval;
				float duration = num2 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				tP_Ice2_Weapon2._lastShotTimer = lastShotTimer;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while ((nint)vector > (flag ? 1 : 0));
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_4
	{
		public Vector2 __pos;

		public _003C_003Ec__DisplayClass16_3 CS_0024_003C_003E8__locals4;

		public Action _003C_003E9__3;

		internal void _003CFireProjectiles_003Eb__3()
		{
			//IL_0300: Expected O, but got I4
			//IL_010a: Invalid comparison between F4 and O
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Expected O, but got Unknown
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Expected O, but got Unknown
			//IL_01bc: Expected O, but got F4
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Expected O, but got Unknown
			//IL_011c->IL02cf: Incompatible stack heights: 7 vs 5
			//IL_02cf->IL00d2: Incompatible stack heights: 14 vs 6
			_003C_003Ec__DisplayClass16_3 obj = CS_0024_003C_003E8__locals4;
			bool flag = CS_0024_003C_003E8__locals4 == null;
			_003C_003Ec__DisplayClass16_0 obj2 = obj.CS_0024_003C_003E8__locals3;
			bool flag2 = obj.CS_0024_003C_003E8__locals3 == null;
			bool flag3 = (object)obj2._003C_003E4__this == null;
			GameObject gameObject = obj2._003C_003E4__this.gameObject;
			bool flag4 = (object)gameObject == null;
			bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj3 == null)
			{
				return;
			}
			_003C_003Ec__DisplayClass16_3 obj4 = CS_0024_003C_003E8__locals4;
			bool flag6 = CS_0024_003C_003E8__locals4 == null;
			GameObject gameObject2 = null;
			GameObject gameObject3 = null;
			float2 pos = default(float2);
			while (true)
			{
				_003C_003Ec__DisplayClass16_0 obj5 = obj4.CS_0024_003C_003E8__locals3;
				bool flag7 = obj4.CS_0024_003C_003E8__locals3 == null;
				float fixedAmount = obj5._fixedAmount;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)fixedAmount) > System.Runtime.CompilerServices.Unsafe.As<GameObject, UIntPtr>(ref gameObject3))
				{
					_003C_003Ec__DisplayClass16_3 obj6 = CS_0024_003C_003E8__locals4;
					bool flag8 = CS_0024_003C_003E8__locals4 == null;
					_003C_003Ec__DisplayClass16_0 obj7 = obj6.CS_0024_003C_003E8__locals3;
					bool flag9 = obj6.CS_0024_003C_003E8__locals3 == null;
					object obj8 = gameObject2 + 1;
					_003C_003Ec__DisplayClass16_3 obj9 = CS_0024_003C_003E8__locals4;
					object obj10 = obj8 * obj7.__unit;
					object obj11 = obj10 + obj7.__firstY;
					__pos = (Vector2)obj7.__firstX;
					bool flag10 = CS_0024_003C_003E8__locals4 == null;
					_003C_003Ec__DisplayClass16_0 obj12 = obj9.CS_0024_003C_003E8__locals3;
					bool flag11 = obj9.CS_0024_003C_003E8__locals3 == null;
					TP_Ice2_Weapon tP_Ice2_Weapon = obj12._003C_003E4__this;
					bool flag12 = (object)obj12._003C_003E4__this == null;
					_003C_003Ec__DisplayClass16_3 obj13 = CS_0024_003C_003E8__locals4;
					_003C_003Ec__DisplayClass16_0 obj14 = obj13.CS_0024_003C_003E8__locals3;
					bool flag13 = tP_Ice2_Weapon._invisibleProjectilePool == null;
					Projectile projectile = tP_Ice2_Weapon._invisibleProjectilePool.SpawnAt(pos, obj14._003C_003E4__this, obj13.localIndex);
					obj4 = CS_0024_003C_003E8__locals4;
					gameObject2 = (GameObject)(gameObject2 + 1);
					bool flag14 = CS_0024_003C_003E8__locals4 == null;
					gameObject3 = gameObject2;
					continue;
				}
				break;
			}
		}
	}

	private BulletPool _invisibleProjectilePool;

	private Projectile _invisibleProjectilePrefab;

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private bool _hasGemini;

	private Timer rainStopTimer;

	private TP_Ice1_Weapon _ice1Weapon;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	protected override void Awake()
	{
		//IL_00cf: Expected I, but got O
		//IL_0172: Expected I, but got O
		base.Awake();
		_hasGemini = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Ice07");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
		BulletPool invisibleProjectilePool = new BulletPool(_invisibleProjectilePrefab);
		_invisibleProjectilePool = invisibleProjectilePool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Ice2_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_invisibleProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Ice2_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_invisibleProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				return;
			}
		}
		throw new NullReferenceException();
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
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__12_0;
		bool flag = _003C_003Ec._003C_003E9__12_0 != null;
		nint num3 = unchecked((nint)null);
		if (!flag)
		{
			Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__12_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = x._equipmentType - 1457;
				return obj6 == null;
			});
			num3 = unchecked((nint)null);
			match = predicate;
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		bool flag2 = (object)equipment == null;
		Equipment ice1Weapon = equipment;
		if (flag2)
		{
			goto IL_0341;
		}
		num3 = (nint)equipment;
		nint num4 = (nint)typeof(TP_Ice1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Ice1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Ice1_Weapon>)+130]");
		object obj4;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v47+FFFFFFF8+v458 @ rax_v42*8]");
			if (0 == (nint)typeof(TP_Ice1_Weapon))
			{
				obj4 = 1;
				goto IL_0350;
			}
		}
		obj4 = 0;
		goto IL_0350;
		IL_0341:
		_ice1Weapon = (TP_Ice1_Weapon)ice1Weapon;
		TP_Ice1_Weapon ice1Weapon2 = _ice1Weapon;
		if ((object)_ice1Weapon != null && ((UnityEngine.Object)ice1Weapon2).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager2 = characterController3._weaponsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
			object obj5 = default(object);
			if (obj5 != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
				CharacterWeaponsManager weaponsManager3 = characterController4._weaponsManager;
				bool flag3 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField).Remove((object)_ice1Weapon);
			}
			_ice1Weapon.Cleanup();
			VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager4 = characterController5._weaponsManager;
			bool flag4 = ((EquipmentManager)weaponsManager4)._003CHiddenEquipment_003Ek__BackingField.Remove(_ice1Weapon);
			TP_Ice1_Weapon ice1Weapon3 = _ice1Weapon;
			ice1Weapon3._003CCanFireNormally_003Ek__BackingField = false;
			GameObject gameObject = _ice1Weapon.gameObject;
			gameObject.SetActive(value: true);
		}
		return;
		IL_0350:
		bool flag5 = obj4 == null;
		ice1Weapon = null;
		if (!flag5)
		{
			ice1Weapon = equipment;
		}
		goto IL_0341;
	}

	public override void InternalUpdate()
	{
		//IL_0296: Invalid comparison between I4 and F4
		//IL_03d7->IL02d9: Incompatible stack heights: 1 vs 0
		//IL_01d1->IL02d9: Incompatible stack heights: 1 vs 0
		//IL_0200->IL02d9: Incompatible stack heights: 1 vs 0
		//IL_0464->IL02d9: Incompatible stack heights: 2 vs 0
		//IL_043a->IL02d9: Incompatible stack heights: 2 vs 0
		//IL_0238->IL02d9: Incompatible stack heights: 2 vs 0
		//IL_026a->IL02d9: Incompatible stack heights: 2 vs 0
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
				TP_Ice1_Weapon ice1Weapon = _ice1Weapon;
				if ((object)_ice1Weapon != null && ((UnityEngine.Object)ice1Weapon).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_ice1Weapon == null)
					{
						goto IL_02d9;
					}
					_ice1Weapon.Fire();
				}
			}
		}
		bool flipX2 = default(bool);
		if ((object)_cursor != null)
		{
			float num3 = base._003CTotalTime_003Ek__BackingField * 0.85f;
			float num4 = num3 / deltaTime;
			float alpha = num4 + 0.15f;
			PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
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
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
							ArcadeSprite arcadeSprite2 = ((Equipment)this)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
								if ((object)arcadeSprite2._spriteRenderer != null)
								{
									Sprite sprite2 = arcadeSprite2._spriteRenderer.sprite;
									if ((object)sprite2 != null)
									{
										bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret);
										if (flipX)
										{
											goto IL_0420;
										}
										float playerFacing = PlayerFacing;
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
													float playerFacing2 = PlayerFacing;
													bool flag3 = 0f > -1f;
													flipX2 = flipX;
													if (!flag3)
													{
														flipX2 = (byte)((flipX ? 1u : 0u) ^ 1u) != 0;
													}
													goto IL_0420;
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
		goto IL_02d9;
		IL_02d9:
		throw new NullReferenceException();
		IL_0420:
		if ((object)_cursor != null)
		{
			PhaserSprite phaserSprite4 = _cursor.setFlipX(flipX2);
			return;
		}
		goto IL_02d9;
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
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005c: Invalid comparison between O and F4
		//IL_0087: Expected F4, but got O
		float2 position = _cursor.position;
		Vector2 vector = default(Vector2);
		FireProjectiles(vector);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public unsafe void FireProjectiles(Vector2 pos)
	{
		//IL_002d: Expected I, but got O
		//IL_009b: Expected F4, but got O
		//IL_0215: Expected I, but got O
		//IL_022b: Expected O, but got I
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_02a2: Expected I, but got O
		//IL_044b: Expected O, but got I4
		//IL_0462: Expected I, but got I8
		//IL_0394: Expected I, but got O
		//IL_03aa: Expected O, but got I
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_0421: Expected I, but got O
		//IL_028b: Expected I, but got I8
		//IL_04f5: Expected O, but got I4
		//IL_050c: Expected I, but got I8
		//IL_040a: Expected I, but got I8
		_003C_003Ec__DisplayClass16_0 obj = new _003C_003Ec__DisplayClass16_0();
		obj._003C_003E4__this = this;
		float hitBoxDelay = base.HitBoxDelay;
		float num = base.PSpeed();
		nint num2 = (nint)this;
		float num3 = 1f / hitBoxDelay;
		float num4 = num3 * hitBoxDelay;
		float num5 = base.PDuration();
		float num6 = hitBoxDelay / num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		float num7 = base.PArea();
		float num8 = num6 * 0.48f;
		obj.__firstX = (float)pos;
		float num9 = num8 + num8;
		float num10 = num9 / 0.22f;
		float num11 = num9 * 0.5f;
		obj._fixedAmount = num10;
		float num12 = num10 + 1f;
		object obj2 = default(object);
		float _firstY = (float)obj2 - num11;
		float _unit = num9 / num12;
		obj.__firstY = _firstY;
		obj.__unit = _unit;
		WeaponData currentWeaponData = _currentWeaponData;
		obj.__repeatInterval = currentWeaponData._003CrepeatInterval_003Ek__BackingField;
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		float hitBoxDelay2 = base.HitBoxDelay;
		int num13 = default(int);
		DisplayCursorVFX(num13, hitBoxDelay2);
		bool flag = num13 <= 0;
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (!flag)
		{
			do
			{
				_003C_003Ec__DisplayClass16_1 obj3 = new _003C_003Ec__DisplayClass16_1();
				obj3.CS_0024_003C_003E8__locals1 = obj;
				obj3.localIndex = (flipX ? 1 : 0);
				Action action = null;
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ r10_v7 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass16_1._003CFireProjectiles_003Eb__0);
				((Delegate)action).m_target = obj3;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ r10_v7 (Il2CppMethodInfo)+4C]");
				object obj4 = (nint)0 >> 4;
				object obj5 = obj4 & 1;
				nint num15;
				if (obj5 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ r10_v7 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num15 = unchecked((nint)6447293664L);
						goto IL_0442;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num15 = ((Delegate)action).method_ptr;
				goto IL_0442;
				IL_0442:
				object obj6 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				float num16 = (float)(flag2 ? 1 : 0) * num4;
				float num17 = num16 + 1f;
				float duration = num17 * 0.001f;
				Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			}
			while ((flag2 ? 1 : 0) < num13);
		}
		if (!_hasGemini)
		{
			return;
		}
		bool flipX2 = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		int localIndex = (flipX2 ? 1 : 0) ^ 1;
		bool flag3 = num13 <= 0;
		bool flag4 = false;
		if (flag3)
		{
			return;
		}
		do
		{
			_003C_003Ec__DisplayClass16_3 obj7 = new _003C_003Ec__DisplayClass16_3();
			obj7.CS_0024_003C_003E8__locals3 = obj;
			obj7.localIndex = localIndex;
			Action action2 = null;
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action2).method_ptr = (IntPtr)0;
			((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass16_3._003CFireProjectiles_003Eb__2);
			((Delegate)action2).m_target = obj7;
			((Delegate)action2).method_code = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj8 = (nint)0 >> 4;
			object obj9 = obj8 & 1;
			nint num19;
			if (obj9 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num19 = unchecked((nint)6447293664L);
					goto IL_04ec;
				}
			}
			((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
			num19 = ((Delegate)action2).method_ptr;
			goto IL_04ec;
			IL_04ec:
			object obj10 = 24;
			((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
			float num20 = (float)(flag4 ? 1 : 0) * num4;
			float num21 = num20 + 1f;
			float duration2 = num21 * 0.001f;
			Timer timer2 = Timers.Register(duration2, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag4 = (byte)((flag4 ? 1u : 0u) + 1u) != 0;
		}
		while ((flag4 ? 1 : 0) < num13);
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CFreezeChance_003Ek__BackingField = 0.1f;
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
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
		TP_Ice1_Weapon ice1Weapon = _ice1Weapon;
		if ((object)_ice1Weapon != null && ((UnityEngine.Object)ice1Weapon).m_CachedPtr != (IntPtr)0)
		{
			_ice1Weapon.SetVisible(visible);
		}
	}
}
