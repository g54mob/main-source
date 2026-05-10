using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EnemyAbility_targeting : EnemyAbility
{
	private enum ETargetType
	{
		Tower = 0,
		Enemy = 1
	}

	private const float FAILCHECK_TIME = 3f;

	[Header("Targeting")]
	[SerializeField]
	private ETargetType targetType;

	[SerializeField]
	[Tooltip("Enemigos a los que puede afectar la habilidad. Dejar vacío si afecta a todos")]
	private EnemyData[] affectedEnemies;

	[SerializeField]
	private bool canTargetItself;

	[SerializeField]
	private bool isSingleTarget = true;

	[SerializeField]
	[Tooltip("0 = inifnito")]
	private int maxTargets;

	[SerializeField]
	private float searchRadius = 1f;

	[SerializeField]
	private float searchAngle = 360f;

	[SerializeField]
	private bool prioritizeStrongestTower;

	private float lastFailcheckTime;

	private List<GameplayEffectsComponent> cachedTargets;

	protected List<GameplayEffectsComponent> CachedTargets => cachedTargets;

	protected List<GameplayEffectsComponent> GetTargets()
	{
		List<GameplayEffectsComponent> list = new List<GameplayEffectsComponent>();
		if (targetType == ETargetType.Tower)
		{
			Collider[] array = Physics.OverlapSphere(abilityManager.transform.position, searchRadius, LayerMask.GetMask("Gameplay"));
			foreach (Collider collider in array)
			{
				if ((bool)collider.attachedRigidbody && collider.attachedRigidbody.CompareTag("Tower") && IsInAngle(collider.attachedRigidbody.gameObject) && collider.attachedRigidbody.TryGetComponent<Tower>(out var component) && component.PlacementComponent.IsPlaced && IsTargetValid(component.GameplayEffectsComponent))
				{
					list.AddUnique(component.GameplayEffectsComponent);
				}
			}
		}
		else
		{
			Collider[] array = Physics.OverlapSphere(abilityManager.transform.position, searchRadius, LayerMask.GetMask("Enemy"));
			foreach (Collider collider2 in array)
			{
				if ((bool)collider2.attachedRigidbody && (canTargetItself || collider2.attachedRigidbody.gameObject != owner) && IsInAngle(collider2.attachedRigidbody.gameObject) && collider2.attachedRigidbody.TryGetComponent<Enemy>(out var component2) && component2.CombatComponent.IsAlive() && (affectedEnemies == null || affectedEnemies.Length == 0 || affectedEnemies.Contains(component2.Data)) && IsTargetValid(component2.GameplayEffectsComponent))
				{
					list.AddUnique(component2.GameplayEffectsComponent);
				}
			}
		}
		if (list.Count > 0 && (isSingleTarget || maxTargets > 0))
		{
			list.Shuffle();
			if (targetType == ETargetType.Tower && prioritizeStrongestTower)
			{
				list = list.OrderByDescending((GameplayEffectsComponent x) => x.GetComponent<GameplayObject>().ObjectData.TotalValue()).ToList();
			}
			return list.GetRange(0, isSingleTarget ? 1 : Mathf.Min(list.Count, maxTargets));
		}
		return list;
	}

	protected virtual bool IsTargetValid(GameplayEffectsComponent geComp)
	{
		return true;
	}

	private bool IsInAngle(GameObject target)
	{
		Vector3 to = target.transform.position - owner.transform.position;
		to.Scale(new Vector3(1f, 0f, 1f));
		return Vector3.Angle(owner.transform.forward, to) <= searchAngle * 0.5f;
	}

	public override bool CanActivate(FActiveAbilityInputData inputData)
	{
		if (Time.time - lastFailcheckTime < 3f)
		{
			return false;
		}
		cachedTargets = GetTargets();
		if (CachedTargets == null || CachedTargets.Count == 0)
		{
			lastFailcheckTime = Time.time;
			return false;
		}
		return base.CanActivate(inputData);
	}
}
