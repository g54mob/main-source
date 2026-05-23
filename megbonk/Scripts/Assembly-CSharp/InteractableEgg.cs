using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableEgg : BaseInteractable
{
	public class FrogContainer
	{
		public Transform target;

		public float lastFoundRandomPositionTime;

		public float lockDirectionUntilTime;

		public FrogContainer(Transform t)
		{
		}
	}

	public EnemyData frogEnemyData;

	public MyAchievement unlockAchievement;

	public LocalizedString localizationEgg;

	public MeshRenderer renderer;

	public Collider collider;

	public Material frogMinimapMaterial;

	private List<Enemy> frogEnemies;

	private Dictionary<Enemy, FrogContainer> frogTargets;

	public GameObject breakFx;

	private bool done;

	private float playerDistanceThreshold;

	private float edgeDistanceThreshold;

	private float lockDirectionTime;

	private float newRandomDirectionInterval;

	private void Awake()
	{
	}

	private new void OnDestroy()
	{
	}

	public override bool Interact()
	{
		return false;
	}

	private void Update()
	{
	}

	private void OnEnemyReleasedFromPool(Enemy enemy)
	{
	}

	public override string GetInteractString()
	{
		return null;
	}

	public override bool CanInteract()
	{
		return false;
	}
}
