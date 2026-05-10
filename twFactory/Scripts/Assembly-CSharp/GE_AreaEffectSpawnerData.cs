using UnityEngine;

[CreateAssetMenu(fileName = "GE_areaEffectSpawnerData_default", menuName = "Tower Factory/GameplayEffect/TowerEffects/Area Effect Spawner")]
public class GE_AreaEffectSpawnerData : GameplayEffectData
{
	public enum ESpawnMode
	{
		EnemyPosition = 0,
		ProjectilePosition = 1
	}

	[Header("Area Effect Spawner")]
	[SerializeField]
	private AreaEffect areaEffectPrefab;

	[SerializeField]
	private ESpawnMode spawnMode = ESpawnMode.ProjectilePosition;

	public AreaEffect AreaEffectPrefab => areaEffectPrefab;

	public ESpawnMode SpawnMode => spawnMode;

	public override string DisplayName => areaEffectPrefab.DisplayName;

	public override string Description => areaEffectPrefab.Description;

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_AreaEffectSpawner();
	}

	protected override bool ShowNameInInspector()
	{
		return false;
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}
}
