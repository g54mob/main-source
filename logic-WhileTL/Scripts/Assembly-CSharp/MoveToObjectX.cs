using UnityEngine;

public class MoveToObjectX : MonoBehaviour
{
	public GameObject objToMove;

	public float addX;

	private void Start()
	{
	}

	private void Update()
	{
		if (objToMove != null)
		{
			Vector3 position = base.transform.position;
			position.x = objToMove.transform.position.x + addX;
			base.transform.position = position;
		}
		else
		{
			Object.Destroy(this);
		}
	}
}
