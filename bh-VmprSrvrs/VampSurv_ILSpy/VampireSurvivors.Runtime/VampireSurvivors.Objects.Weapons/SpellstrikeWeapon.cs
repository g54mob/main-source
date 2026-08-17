using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class SpellstrikeWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public EnemyController closest;

		public SpellstrikeWeapon _003C_003E4__this;

		public Action _003C_003E9__0;

		internal unsafe void _003CFire_003Eb__0()
		{
			//IL_004c: Expected O, but got Ref
			GameManager core = GM.Core;
			SpellstrikeWeapon spellstrikeWeapon = _003C_003E4__this;
			object cachedTransform = spellstrikeWeapon._cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdi_v4 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdi_v4 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				object obj = default(object);
				EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
				closest = enemyController;
				EnemyController enemyController2 = closest;
				if ((object)closest != null && ((UnityEngine.Object)enemyController2).m_CachedPtr != (IntPtr)0)
				{
					float2 position = closest.position;
					float2 position2 = closest.position;
					Transform transform = closest.transform;
					Vector2 pos = default(Vector2);
					Projectile projectile = _003C_003E4__this.FireOneProjectile(pos, 0, transform);
					_003C_003E4__this.DealDamage(closest);
				}
				return;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
			throw new NullReferenceException();
		}
	}

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPower();
			float num3 = default(float);
			float num2 = num3 * 1.25f;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = num2 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num5 = num4 * num3;
					return num3 + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0057: Expected O, but got Ref
		//IL_03ff: Expected F4, but got O
		//IL_00aa: Expected F4, but got O
		//IL_0161: Expected O, but got I4
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_010c: Expected O, but got F4
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_0305: Invalid comparison between F4 and O
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals26._003C_003E4__this = this;
		GameManager core = GM.Core;
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rsi_v3 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rsi_v3 (System.Object)+10]");
			float2 ret;
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
			object obj = default(object);
			EnemyController closest = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
			CS_0024_003C_003E8__locals26.closest = closest;
			EnemyController closest2 = CS_0024_003C_003E8__locals26.closest;
			bool flag = (object)CS_0024_003C_003E8__locals26.closest == null;
			float num = (float)ret;
			float num2 = default(float);
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)closest2).m_CachedPtr == (IntPtr)0;
				num = (float)ret;
				if (!flag2)
				{
					float2 position = CS_0024_003C_003E8__locals26.closest.position;
					float2 position2 = CS_0024_003C_003E8__locals26.closest.position;
					Transform target = CS_0024_003C_003E8__locals26.closest.transform;
					Projectile projectile = base.FireOneProjectile((Vector2)num2, 0, target);
					base.DealDamage(CS_0024_003C_003E8__locals26.closest);
					num = num2;
				}
			}
			float num3 = base.PAmount();
			if (num > 1f)
			{
				float num4 = base.PAmount();
				if (num > 1f)
				{
					object obj2 = 1;
					Action closest3 = (Action)(object)CS_0024_003C_003E8__locals26.closest;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					do
					{
						WeaponData currentWeaponData = _currentWeaponData;
						object obj3 = obj2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
						if ((nint)obj3 <= 0)
						{
							float2 position3 = CS_0024_003C_003E8__locals26.closest.position;
							float2 position4 = CS_0024_003C_003E8__locals26.closest.position;
							Transform transform = CS_0024_003C_003E8__locals26.closest.transform;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
							base.DealDamage(CS_0024_003C_003E8__locals26.closest);
							num = num2;
						}
						else
						{
							closest3 = CS_0024_003C_003E8__locals26._003C_003E9__0;
							if (CS_0024_003C_003E8__locals26._003C_003E9__0 == null)
							{
								closest3 = (CS_0024_003C_003E8__locals26._003C_003E9__0 = delegate
								{
									//IL_004c: Expected O, but got Ref
									GameManager core2 = GM.Core;
									SpellstrikeWeapon spellstrikeWeapon = CS_0024_003C_003E8__locals26._003C_003E4__this;
									object cachedTransform2 = spellstrikeWeapon._cachedTransform;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdi_v4 (System.Object)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdi_v4 (System.Object)+10]");
										Transform.get_position_Injected((IntPtr)0, out Vector3 _);
										object obj4 = default(object);
										EnemyController closest4 = core2._stage.FindClosestEnemy((Vector3)(&obj4), excludeDead: true);
										CS_0024_003C_003E8__locals26.closest = closest4;
										EnemyController closest5 = CS_0024_003C_003E8__locals26.closest;
										if ((object)CS_0024_003C_003E8__locals26.closest != null && ((UnityEngine.Object)closest5).m_CachedPtr != (IntPtr)0)
										{
											float2 position5 = CS_0024_003C_003E8__locals26.closest.position;
											float2 position6 = CS_0024_003C_003E8__locals26.closest.position;
											Transform target2 = CS_0024_003C_003E8__locals26.closest.transform;
											Vector2 pos = default(Vector2);
											Projectile projectile2 = CS_0024_003C_003E8__locals26._003C_003E4__this.FireOneProjectile(pos, 0, target2);
											CS_0024_003C_003E8__locals26._003C_003E4__this.DealDamage(CS_0024_003C_003E8__locals26.closest);
										}
										return;
									}
									UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform2);
									throw new NullReferenceException();
								});
							}
							float num5 = currentWeaponData._003CrepeatInterval_003Ek__BackingField * (float)obj2;
							float num6 = num5 * 0.001f;
							Timer lastShotTimer = Timers.Register(num6, closest3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_lastShotTimer = lastShotTimer;
							num = num6;
						}
						obj2++;
						float num7 = base.PAmount();
					}
					while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2));
				}
			}
			float num8 = base.PInterval();
			bool flag3 = _lastFiringInterval == num;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873B33CAh\"");
			if (!flag3)
			{
				float num9 = base.PInterval();
				_lastFiringInterval = num;
				base.ResetFiringTimer();
			}
			if (!skipTriggers)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
			}
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
		throw new NullReferenceException();
	}
}
