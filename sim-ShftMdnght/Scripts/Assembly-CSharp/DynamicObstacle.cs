using Pathfinding;
using UnityEngine;

public class DynamicObstacle : MonoBehaviour
{
	private void Start()
	{
		GraphUpdateObject graphUpdateObject = new GraphUpdateObject(GetComponent<Collider>().bounds);
		graphUpdateObject.modifyWalkability = true;
		graphUpdateObject.setWalkability = false;
		AstarPath.active.UpdateGraphs(graphUpdateObject);
	}
}
