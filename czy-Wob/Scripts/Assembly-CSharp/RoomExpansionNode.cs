using UnityEngine;

public class RoomExpansionNode : MonoBehaviour
{
	public RoomBase attachedRoom;

	public WallBase attachedWall;

	public WallDirection direction;

	public Vector3 GetPositionForNode()
	{
		BoundingBoxComponent boundingBoxComponent = attachedRoom.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = attachedRoom.gameObject.AddComponent<BoundingBoxComponent>();
		}
		float num = ConstructionManager.pipeSize - 2f;
		Vector3 vector = boundingBoxComponent.GetBoxSize() * 2f;
		Vector3 position = attachedRoom.transform.position;
		switch (direction)
		{
		case WallDirection.BACK:
			position += new Vector3(0f, 0f, vector.z + num);
			break;
		case WallDirection.DOWN:
			position += new Vector3(0f, 0f - vector.y - num, 0f);
			break;
		case WallDirection.FRONT:
			position += new Vector3(0f, 0f, 0f - vector.z - num);
			break;
		case WallDirection.LEFT:
			position += new Vector3(0f - vector.x - num + 1f, 0f, 0f);
			break;
		case WallDirection.RIGHT:
			position += new Vector3(vector.x + num - 1f, 0f, 0f);
			break;
		case WallDirection.UP:
			position += new Vector3(0f, vector.y + num, 0f);
			break;
		}
		return position;
	}
}
