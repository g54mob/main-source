using UnityEngine;

public class FloorItemsHandler : MonoBehaviour
{
	public static FloorItemsHandler Instance;

	[SerializeField]
	private FloorItem _floorItemPrefab;

	[field: SerializeField]
	public FloorItemChunksHandler Chunks { get; private set; }

	[field: SerializeField]
	public FloorItemsBobAnimator BobAnimator { get; private set; }

	public void Initiate()
	{
	}

	public FloorItem SpawnFloorItem(ItemType type, Vector2 position)
	{
		return null;
	}

	public FloorItem SpawnFloorItem(ItemType type, Vector2 position, float dist, float dirAngle, float dirAngleRand, float floatDuration = 0.3f)
	{
		return null;
	}
}
