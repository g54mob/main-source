using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnitHelper
{
	public static Unit[] GetEnemyUnits(Unit unit)
	{
		if (unit.IsEnemy)
		{
			Unit[] array = Train.Instance.Modules.Where((Module u) => (bool)u && u != unit).ToArray();
			Unit[] array2 = array;
			ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
			if ((object)moduleByType != null && moduleByType.hackedEnemies.Count > 0)
			{
				return array2.Concat(from pair in moduleByType.hackedEnemies
					select pair.Item1 into e
					where e.numberOfCurrentOpponents < e.maxNumberOfOpponents
					select e).ToArray();
			}
			return array2;
		}
		return EnemyManager.Instance.Enemies.Where((EnemyBase u) => u != unit && u.IsEnemy && !u.ignoreProjectiles).ToArray();
	}

	public static Unit[] GetLiveEnemyUnits(Unit unit)
	{
		List<Unit> list = new List<Unit>();
		Unit[] enemyUnits = GetEnemyUnits(unit);
		foreach (Unit unit2 in enemyUnits)
		{
			if (unit2.HealthComponent != null && unit2.HealthComponent.HealthMax > 0f)
			{
				list.Add(unit2);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list.ToArray();
	}

	public static Unit[] GetValidEnemyTargets(Unit unit)
	{
		Unit[] liveEnemyUnits = GetLiveEnemyUnits(unit);
		if (liveEnemyUnits == null || liveEnemyUnits.Length == 0)
		{
			return null;
		}
		return (from u in GetLiveEnemyUnits(unit)
			where !u.HealthComponent.IsImmune && !u.ignoreProjectiles && u.HealthComponent.DamageReductionPercent < 99f && u.HealthComponent.HealthMax > 0f
			select u).ToArray();
	}

	public static Unit GetRandomEnemyUnit(Unit unit, bool sameSide = false)
	{
		Unit[] array = GetEnemyUnits(unit);
		if (sameSide)
		{
			array = array.Where((Unit e) => e.transform.position.y * unit.transform.position.y >= 0f).ToArray();
		}
		Unit unit2 = ((array != null && array.Length != 0) ? array.OrderBy((Unit _) => UnityEngine.Random.value).First() : null);
		if (unit2 == null)
		{
			return null;
		}
		unit2.numberOfCurrentOpponents++;
		return unit2;
	}

	public static Unit GetRandomEnemyUnitExcept(Unit unit, Unit exceptUnit, bool sameSide = false)
	{
		Unit[] array = GetEnemyUnits(unit);
		if (sameSide)
		{
			array = array.Where((Unit e) => e.transform.position.y * unit.transform.position.y >= 0f && e != exceptUnit).ToArray();
		}
		Unit unit2 = ((array != null && array.Length != 0) ? array.OrderBy((Unit _) => UnityEngine.Random.value).First() : null);
		if (unit2 == null)
		{
			return null;
		}
		unit2.numberOfCurrentOpponents++;
		return unit2;
	}

	public static Unit GetRandomLiveEnemyUnit(Unit unit, bool sameSide = false)
	{
		Unit[] array = GetLiveEnemyUnits(unit);
		if (sameSide)
		{
			array = array.Where((Unit e) => e.transform.position.y * unit.transform.position.y >= 0f).ToArray();
		}
		Unit unit2 = ((array != null && array.Length != 0) ? array.OrderBy((Unit _) => UnityEngine.Random.value).First() : GetRandomEnemyUnit(unit));
		if (unit2 == null)
		{
			return null;
		}
		unit2.numberOfCurrentOpponents++;
		return unit2;
	}

	public static Unit GetRandomLiveEnemyUnitExcept(Unit unit, Unit exceptionUnit, bool sameSide = false)
	{
		Unit[] array = GetLiveEnemyUnits(unit);
		if (sameSide)
		{
			array = array.Where((Unit e) => e.transform.position.y * unit.transform.position.y >= 0f && e != exceptionUnit).ToArray();
		}
		Unit unit2 = ((array != null && array.Length != 0) ? array.OrderBy((Unit _) => UnityEngine.Random.value).First() : GetRandomEnemyUnit(unit));
		if (unit2 == null)
		{
			return null;
		}
		unit2.numberOfCurrentOpponents++;
		return unit2;
	}

	public static Module[] GetRandomUnbrokenModule(Unit unit)
	{
		List<Module> list = new List<Module>();
		foreach (Module module in Train.Instance.Modules)
		{
			if (module != null && module.HealthComponent != null && module.HealthComponent.HealthMax > 0f && !module.IsFullyBroken)
			{
				list.Add(module);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list.ToArray();
	}

	public static Module GetRandomUnBrokenModuleExcept<T>(Unit unit)
	{
		List<Module> list = new List<Module>(GetRandomUnbrokenModule(unit));
		if (list != null && list.Count == 0)
		{
			return null;
		}
		foreach (Module item in list)
		{
			if (item is T)
			{
				list.Remove(item);
				break;
			}
		}
		Module module = ((list != null && list.Count > 0) ? list.OrderBy((Module _) => UnityEngine.Random.value).First() : null);
		if (module == null)
		{
			return null;
		}
		module.numberOfCurrentOpponents++;
		return module;
	}

	public static (Unit, Unit) GetTwoModulesByDstApart(float dst)
	{
		Module[] array = Train.Instance.Modules.Where((Module m) => m).ToArray();
		if (array.Length < 2)
		{
			return (null, null);
		}
		dst = Mathf.Clamp(dst, 1f, array.Length - 1);
		float num = UnityEngine.Random.Range(0f, (float)array.Length - dst);
		float num2 = num + dst;
		if (UnityEngine.Random.Range(0, 2) == 0)
		{
			return (array[(int)num], array[(int)num2]);
		}
		return (array[(int)num2], array[(int)num]);
	}

	public static bool HackedEnemyKilledAnEnemy(EnemyBase enemy, Unit killer)
	{
		if (!enemy.IsEnemy)
		{
			return false;
		}
		if (killer.IsHacked || (killer is APCMissile aPCMissile && aPCMissile.parentEnemy.IsHacked))
		{
			return true;
		}
		return false;
	}

	public static Unit GetClosestEnemyOnSameSide(Unit unit)
	{
		if (unit == null)
		{
			return null;
		}
		Unit[] enemyUnits = GetEnemyUnits(unit);
		if (enemyUnits == null || enemyUnits.Length == 0)
		{
			return null;
		}
		Func<Unit, bool> sideFilter;
		if (unit.transform.position.y < 0f)
		{
			sideFilter = (Unit u) => u != null && u.transform.position.y < 0f;
		}
		else
		{
			sideFilter = (Unit u) => u != null && u.transform.position.y > 0f;
		}
		IEnumerable<Unit> source = enemyUnits.Where((Unit u) => sideFilter(u) && u.gameObject.activeInHierarchy);
		if (!source.Any())
		{
			return null;
		}
		Unit unit2 = source.OrderBy((Unit u) => (u.transform.position - unit.transform.position).sqrMagnitude).FirstOrDefault();
		if (unit2 == null)
		{
			return null;
		}
		unit2.numberOfCurrentOpponents++;
		return unit2;
	}

	public static EnemyBase[] GetAlliedUnits(EnemyBase enemy)
	{
		return (from e in EnemyManager.Instance.Enemies
			where e != enemy
			where e.IsEnemy && !e.ignoreProjectiles
			select e).ToArray();
	}

	public static EnemyBase[] GetLiveAlliedUnits(EnemyBase enemy)
	{
		List<EnemyBase> list = new List<EnemyBase>();
		EnemyBase[] alliedUnits = GetAlliedUnits(enemy);
		foreach (EnemyBase enemyBase in alliedUnits)
		{
			if (enemyBase.HealthComponent != null && enemyBase.HealthComponent.HealthMax > 0f)
			{
				list.Add(enemyBase);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list.ToArray();
	}

	public static List<EnemyBase> GetAlliesInRange(EnemyBase enemy, float range)
	{
		if (enemy == null)
		{
			return null;
		}
		EnemyBase[] liveAlliedUnits = GetLiveAlliedUnits(enemy);
		if (liveAlliedUnits == null)
		{
			return null;
		}
		List<EnemyBase> list = new List<EnemyBase>();
		EnemyBase[] array = liveAlliedUnits;
		foreach (EnemyBase enemyBase in array)
		{
			if (Vector2.SqrMagnitude(enemyBase.transform.position - enemy.transform.position) <= range * range)
			{
				list.Add(enemyBase);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list;
	}
}
