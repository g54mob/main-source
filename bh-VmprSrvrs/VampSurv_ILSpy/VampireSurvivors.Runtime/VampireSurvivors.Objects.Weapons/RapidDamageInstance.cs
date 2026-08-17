using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Objects.Weapons;

public struct RapidDamageInstance
{
	public float RemainingDamage;

	private readonly Weapon _parentWeapon;

	public readonly EnemyController Target;

	private readonly float DamagePerHit;

	private readonly float DamageInterval;

	private float _timeUntilNextDamage;

	public RapidDamageInstance(Weapon parentWeapon, EnemyController target, float remainingDamage, float damagePerHit, float damageInterval)
	{
		_parentWeapon = parentWeapon;
		Target = target;
		float damagePerHit2 = default(float);
		DamagePerHit = damagePerHit2;
		float num = default(float);
		DamageInterval = num;
		_timeUntilNextDamage = num;
		RemainingDamage = remainingDamage;
	}

	public unsafe RapidDamageInstance Update(float deltaTime, SignalBus signalBus, bool showDamageNumbers)
	{
		//IL_0238: Expected native int or pointer, but got O
		//IL_0247: Expected native int or pointer, but got O
		//IL_0256: Expected native int or pointer, but got O
		//IL_00a5: Invalid comparison between F4 and I4
		//IL_02a0: Expected O, but got Ref
		//IL_01de: Expected O, but got Ref
		//IL_02c2->IL01f4: Incompatible stack heights: 1 vs 0
		//IL_0175->IL01f4: Incompatible stack heights: 1 vs 0
		//IL_01a4->IL01f4: Incompatible stack heights: 1 vs 0
		//IL_01f4->IL022e: Incompatible stack heights: 1 vs 0
		//IL_02e0->IL01f4: Incompatible stack heights: 1 vs 0
		EnemyController target = Target;
		if ((object)Target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0)
		{
			EnemyController target2 = Target;
			if ((object)Target != null)
			{
				if (target2.body == null || (_timeUntilNextDamage -= deltaTime) > 0f)
				{
					goto IL_022e;
				}
				if ((object)Target != null)
				{
					Vector2 insideUnitCircle = UnityEngine.Random.insideUnitCircle;
					if (target2.body != null && (object)Target != null)
					{
						Transform transform = Target.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
							DoDamage(DamagePerHit, (Vector3)(&ret));
							GameManager core = GM.Core;
							if ((object)GM.Core != null && core._playerOptions != null)
							{
								PlayerOptionsData config = core._playerOptions.Config;
								if (config != null)
								{
									if (config._003CDamageNumbersEnabled_003Ek__BackingField)
									{
										if ((object)GameManager.DamageNumberManager == null)
										{
											goto IL_01f4;
										}
										GameManager.DamageNumberManager.AddBob_Number1((Vector3)(&ret));
									}
									_timeUntilNextDamage = DamageInterval;
									goto IL_022e;
								}
							}
						}
					}
				}
			}
			goto IL_01f4;
		}
		goto IL_022e;
		IL_022e:
		RapidDamageInstance rapidDamageInstance = default(RapidDamageInstance);
		((RapidDamageInstance*)(nint)rapidDamageInstance)->RemainingDamage = RemainingDamage;
		System.Runtime.CompilerServices.Unsafe.Write(&((RapidDamageInstance*)(nint)rapidDamageInstance)->Target, Target);
		((RapidDamageInstance*)(nint)rapidDamageInstance)->_timeUntilNextDamage = _timeUntilNextDamage;
		return rapidDamageInstance;
		IL_01f4:
		throw new NullReferenceException();
	}

	private void DoDamage(float damageAmount, Vector3 damagePosition)
	{
		//IL_0030: Expected O, but got I4
		bool flag = !(damageAmount < RemainingDamage);
		float num = damageAmount;
		if (!flag)
		{
			num = RemainingDamage;
		}
		Target.GetDamagedSpecial(num, HitVfxType.Default, 1f, WeaponType.VOID, hasKb: false, (Vector3?)(object)0);
		Weapon parentWeapon = _parentWeapon;
		float remainingDamage = RemainingDamage - damageAmount;
		RemainingDamage = remainingDamage;
		float num2 = num + parentWeapon._003CStatsInflictedDamage_003Ek__BackingField;
		parentWeapon._003CStatsInflictedDamage_003Ek__BackingField = num2;
	}
}
