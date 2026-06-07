using UnityEngine;

public class MoveObjToY : MonoBehaviour
{
	public GameObject objToMove;

	private void Update()
	{
		if (objToMove != null)
		{
			Vector3 position = base.transform.position;
			position.y = objToMove.transform.position.y;
			base.transform.position = position;
		}
		else
		{
			Object.Destroy(this);
		}
	}
}
