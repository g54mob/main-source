using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class EnemyHealthbarsDisplay : MonoBehaviour
{
	[NonSerialized]
	public Dictionary<Unit, EnemyUI> enemyUis;

	[SerializeField]
	private GameObject EnemyUI;

	[SerializeField]
	private float yOffset;

	[SerializeField]
	private float xOffset;

	[NonSerialized]
	public bool isEnabled;

	private void Awake()
	{
		enemyUis = new Dictionary<Unit, EnemyUI>();
		EnemyManager.Instance.EnemySpawned += UnitEnabledHandler;
		EnemyManager.Instance.EnemyDestroyed += UnitDisabledHandler;
		EnemyManager.Instance.EnemyDespawned += UnitDisabledHandler;
		HUD.OnScramble += ScrambleHealthBars;
		HUD.OnUnscramble += UnscrambleHealthBars;
	}

	private void OnDestroy()
	{
		EnemyManager.Instance.EnemySpawned -= UnitEnabledHandler;
		EnemyManager.Instance.EnemyDestroyed -= UnitDisabledHandler;
		EnemyManager.Instance.EnemyDespawned -= UnitDisabledHandler;
		HUD.OnScramble -= ScrambleHealthBars;
		HUD.OnUnscramble -= UnscrambleHealthBars;
	}

	private void UnscrambleHealthBars()
	{
		if (enemyUis == null || enemyUis.Count == 0)
		{
			return;
		}
		for (int i = 0; i < enemyUis.Count; i++)
		{
			if (enemyUis.Keys.ElementAt(i) == null || enemyUis.Values.ElementAt(i) == null)
			{
				continue;
			}
			Unit unit = enemyUis.Keys.ElementAt(i);
			EnemyUI enemyUI = enemyUis.Values.ElementAt(i);
			if (unit == null || unit.HealthComponent == null)
			{
				if ((bool)enemyUI)
				{
					UnityEngine.Object.Destroy(enemyUI.gameObject);
				}
				enemyUis.Remove(unit);
			}
			else
			{
				Health healthComponent = unit.HealthComponent;
				float values = healthComponent.HealthCurrent / healthComponent.HealthMax;
				enemyUI.healthBar.SetValues(values);
			}
		}
	}

	private void ScrambleHealthBars()
	{
		foreach (EnemyUI value in enemyUis.Values)
		{
			float values = UnityEngine.Random.Range(0f, 1f);
			value.healthBar.SetValues(values);
		}
	}

	public void ActivateHealthBars()
	{
		CombatManager.Instance.HealthChanged += UnitHealthChangedHandler;
		isEnabled = true;
	}

	public void DeactivateHealthBars()
	{
		CombatManager.Instance.HealthChanged -= UnitHealthChangedHandler;
		isEnabled = false;
	}

	private void UnitEnabledHandler(Unit unit)
	{
		if (unit == null || HUD.Instance.IsScrambled || unit is EnemyComponent || unit.HealthComponent == null || enemyUis.TryGetValue(unit, out var _))
		{
			return;
		}
		Vector3 vector = new Vector3(xOffset, yOffset);
		GameObject gameObject = UnityEngine.Object.Instantiate(EnemyUI, unit.transform.position + vector, quaternion.identity, base.transform);
		EnemyUI component = gameObject.GetComponent<EnemyUI>();
		component.sunder.Initialize(unit);
		BarController healthBar = component.healthBar;
		enemyUis.Add(unit, component);
		unit.gameObject.GetComponent<EnemyBase>().enemyUI = component;
		Health healthComponent = unit.HealthComponent;
		float values = healthComponent.HealthCurrent / healthComponent.HealthMax;
		healthBar.SetValues(values);
		FollowTransform(unit.transform, gameObject.transform);
		if (unit is E4_5Hunter e4_5Hunter)
		{
			{
				foreach (E4_5Pet pet in e4_5Hunter.Pets)
				{
					UnitEnabledHandler(pet);
				}
				return;
			}
		}
		if (unit is E4_6BigGuy e4_6BigGuy)
		{
			UnitEnabledHandler(e4_6BigGuy.SmallGuy);
		}
	}

	private void FollowTransform(Transform enemyTf, Transform uiTf)
	{
		if (!(enemyTf == null))
		{
			Vector3 vector = new Vector3(xOffset, yOffset);
			LeanTween.move(uiTf.gameObject, enemyTf.position + vector, 0.1f).setOnComplete((Action)delegate
			{
				FollowTransform(enemyTf, uiTf);
			});
		}
	}

	private void UnitDisabledHandler(Unit unit)
	{
		if (!(unit == null) && enemyUis.TryGetValue(unit, out var value))
		{
			UnityEngine.Object.Destroy(value.gameObject);
			enemyUis.Remove(unit);
		}
	}

	private void UnitHealthChangedHandler(HealthChangeInfo info)
	{
		if (!(info.Target == null))
		{
			Unit component = info.Target.GetComponent<Unit>();
			if (!(component == null) && enemyUis.TryGetValue(component, out var value))
			{
				Health healthComponent = component.HealthComponent;
				float values = healthComponent.HealthCurrent / healthComponent.HealthMax;
				value.healthBar.SetValues(values);
			}
		}
	}

	public void ApplySunder(Unit unit, bool apply)
	{
		if (unit == null)
		{
			return;
		}
		EnemyUI value2;
		if (apply)
		{
			if (enemyUis.TryGetValue(unit, out var value))
			{
				value.sunder.SetIcon(active: true);
			}
		}
		else if (enemyUis.TryGetValue(unit, out value2))
		{
			value2.sunder.SetIcon(active: false);
		}
	}

	public GameObject ApplyWeaken(Unit unit, bool apply)
	{
		if (unit == null)
		{
			return null;
		}
		if (apply)
		{
			if (enemyUis.TryGetValue(unit, out var value))
			{
				value.weaken.SetIcon(active: true);
				return value.weaken.gameObject;
			}
			return null;
		}
		if (enemyUis.TryGetValue(unit, out var value2))
		{
			value2.weaken.SetIcon(active: false);
			return value2.weaken.gameObject;
		}
		return null;
	}

	public void ApplyArmor(Unit unit, bool apply)
	{
		if (unit == null)
		{
			return;
		}
		EnemyUI value2;
		if (apply)
		{
			if (enemyUis.TryGetValue(unit, out var value))
			{
				value.armor.SetIcon(active: true);
			}
		}
		else if (enemyUis.TryGetValue(unit, out value2))
		{
			value2.armor.SetIcon(active: false);
		}
	}
}
