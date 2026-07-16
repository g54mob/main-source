using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class ModuleHealthbarsDisplay : MonoBehaviour
{
	private Dictionary<Unit, BarController> bars;

	[SerializeField]
	private GameObject healthbarPrefab;

	[SerializeField]
	private float yOffset = 0.16f;

	private void Awake()
	{
		bars = new Dictionary<Unit, BarController>();
	}

	private void OnEnable()
	{
		CombatManager.Instance.HealthChanged += UnitHealthChangedHandler;
		Train.Instance.ModuleEnabled += UnitEnabledHandler;
		LevelManager.Instance.LevelStarted += RefreshModules;
	}

	private void OnDisable()
	{
		CombatManager.Instance.HealthChanged -= UnitHealthChangedHandler;
		Train.Instance.ModuleEnabled -= UnitEnabledHandler;
		LevelManager.Instance.LevelStarted -= RefreshModules;
		for (int i = 0; i < bars.Count; i++)
		{
			Object.Destroy(bars.ElementAt(i).Value.gameObject);
		}
		bars.Clear();
	}

	private void RefreshModules()
	{
		bars.Clear();
		List<Module> modules = Train.Instance.Modules;
		for (int i = 0; i < modules.Count; i++)
		{
			Unit unit = modules[i];
			if ((bool)unit && !bars.TryGetValue(unit, out var _))
			{
				UnitEnabledHandler(unit);
			}
		}
	}

	private void UnitEnabledHandler(Unit unit)
	{
		if (!bars.TryGetValue(unit, out var _))
		{
			Vector3 vector = new Vector3(0f, yOffset);
			BarController component = Object.Instantiate(healthbarPrefab, unit.transform.position + vector, quaternion.identity, base.transform).GetComponent<BarController>();
			bars.Add(unit, component);
			Health healthComponent = unit.HealthComponent;
			float values = healthComponent.HealthCurrent / healthComponent.HealthMax;
			component.SetValues(values);
		}
	}

	private void UnitDisabledHandler(Unit unit)
	{
		bars.TryGetValue(unit, out var value);
		Object.Destroy(value.gameObject);
		bars.Remove(unit);
	}

	private void UnitHealthChangedHandler(HealthChangeInfo info)
	{
		if (!(info.Target == null))
		{
			Unit component = info.Target.GetComponent<Unit>();
			if (!(component == null) && bars.TryGetValue(component, out var value))
			{
				Health healthComponent = component.HealthComponent;
				float values = healthComponent.HealthCurrent / healthComponent.HealthMax;
				value.SetValues(values);
			}
		}
	}
}
