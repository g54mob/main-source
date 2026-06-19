using UnityEngine;

public class PipeExpansionNode : MonoBehaviour
{
	public RoomBase attachedRoom;

	public WallBase attachedWall;

	public ConnectorLabel label;

	public WallDirection direction;

	public Vector3 GetPositionForNode()
	{
		BoundingBoxComponent boundingBoxComponent = attachedRoom.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = attachedRoom.gameObject.AddComponent<BoundingBoxComponent>();
		}
		float num = ConstructionManager.pipeSize - 2f;
		Vector3 boxSize = boundingBoxComponent.GetBoxSize();
		Vector3 position = attachedRoom.transform.position;
		switch (direction)
		{
		case WallDirection.BACK:
			position += new Vector3(0f, 0f, boxSize.z + num);
			break;
		case WallDirection.DOWN:
			position += new Vector3(0f, 0f - boxSize.y - num, 0f);
			break;
		case WallDirection.FRONT:
			position += new Vector3(0f, 0f, 0f - boxSize.z - num);
			break;
		case WallDirection.LEFT:
			position += new Vector3(0f - boxSize.x - num, 0f, 0f);
			break;
		case WallDirection.RIGHT:
			position += new Vector3(boxSize.x + num, 0f, 0f);
			break;
		case WallDirection.UP:
			position += new Vector3(0f, boxSize.y + num, 0f);
			break;
		}
		return position;
	}
}
