using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CombatComponent))]
public class EnemyTower : GameplayObject, ISelectable
{
	[SerializeField]
	private List<Cost> damageCost;

	[Header("Victory animation")]
	[SerializeField]
	private GameObject mainModel;

	[SerializeField]
	private GameObject destroyedModel;

	[SerializeField]
	private GameObject[] victoryAnimationCrystals;

	[SerializeField]
	private ParticleSystem[] crystalImpactPS;

	[SerializeField]
	private ParticleSystem explosionPS;

	[SerializeField]
	private GameObject purpleCrystal;

	private CombatComponent combatComponent;

	public CombatComponent CombatComponent
	{
		get
		{
			return combatComponent;
		}
		set
		{
			combatComponent = value;
		}
	}

	public List<Cost> DamageCost => damageCost;

	public GameObject[] VictoryAnimationCrystals => victoryAnimationCrystals;

	public GameObject MainModel => mainModel;

	public GameObject DestroyedModel => destroyedModel;

	public ParticleSystem ExplosionPS => explosionPS;

	public ParticleSystem[] CrystalImpactPS => crystalImpactPS;

	public GameObject PurpleCrystal => purpleCrystal;

	private void Awake()
	{
		CombatComponent = GetComponent<CombatComponent>();
	}

	public void SetDamageCostAmount(int damageAmount)
	{
		damageCost[0].Amount = damageAmount;
	}

	public void Deselect()
	{
	}

	public void Select()
	{
	}
}
