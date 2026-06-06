using PajamaLlama.Flotsam.World;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/World Properties")]
public class WorldProperties : ScriptableObject
{
	public TileProperties DefaultTileProperties;

	[Header("Spawn position providers")]
	[Tooltip("The spawn position provider used when a tile is being activated.")]
	public SpawnPositionProviderBase ActivateTileSpawnPositionProvider;

	[Tooltip("The spawn position provider used while a tile is active.")]
	public SpawnPositionProviderBase ActiveTileSpawnPositionProvider;

	[Header("Roads")]
	public GameObject[] Roads;

	[Header("Misc")]
	public LayerMask MapPlaneCollisionLayer;

	[Header("Regions")]
	public WorldRegionProperties[] RegionProperties;

	public WorldRegionProperties ReturnRegionProperties(WorldRegionType region)
	{
		if (RegionProperties.IsNullOrEmpty())
		{
			return null;
		}
		WorldRegionProperties[] regionProperties = RegionProperties;
		foreach (WorldRegionProperties worldRegionProperties in regionProperties)
		{
			if (worldRegionProperties.Region == region)
			{
				return worldRegionProperties;
			}
		}
		return null;
	}
}
