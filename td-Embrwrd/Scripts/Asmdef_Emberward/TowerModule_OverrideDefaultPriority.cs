using UnityEngine;

[RequireComponent(typeof(ABaseTower))]
public class TowerModule_OverrideDefaultPriority : MonoBehaviour
{
	[SerializeField]
	private eTowerTargetPriority priority;

	[SerializeField]
	private ABaseTower tower;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTowerSpawn(ABaseTower tower)
	{
	}
}
