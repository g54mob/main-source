using UnityEngine;

public class PlacedObjectInfo
{
	public ulong? objectID;

	public float scale = 1f;

	public int rotationValue;

	public Vector2Int gridPos;

	public GameObject objectRef;

	public RoomCustomizationObject customizationRef;

	public PlacedObjectInfo(GameObject objectRef, RoomCustomizationObject customizationRef, Vector2Int gridPos, int rotationValue, float scale)
	{
		objectID = null;
		this.scale = scale;
		this.gridPos = gridPos;
		this.objectRef = objectRef;
		this.rotationValue = rotationValue;
		this.customizationRef = customizationRef;
	}
}
