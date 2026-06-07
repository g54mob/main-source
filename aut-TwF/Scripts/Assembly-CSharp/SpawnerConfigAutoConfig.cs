using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerConfigAutoConfig", menuName = "Tower Factory/Spawners/SpawnerConfig AutoConfig")]
public class SpawnerConfigAutoConfig : ScriptableObject
{
	[SerializeField]
	private FSpawnerConfigAutoConfigData autoConfigData;

	public FSpawnerConfigAutoConfigData AutoConfigData => autoConfigData;
}
