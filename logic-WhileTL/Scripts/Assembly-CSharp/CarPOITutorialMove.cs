using UnityEngine;

public class CarPOITutorialMove : MonoBehaviour
{
	public bool moveY;

	public RectTransform defaultPosition;

	public RectTransform newPosition;

	private void Start()
	{
		Move();
	}

	private void Move()
	{
		Vector3 position = base.transform.position;
		if (!moveY)
		{
			position.x = base.transform.parent.position.x;
			position.x += defaultPosition.transform.position.x - newPosition.transform.position.x;
			base.transform.position = position;
		}
		else
		{
			position.y = base.transform.parent.position.y;
			position.y += defaultPosition.transform.position.y - newPosition.transform.position.y;
			base.transform.position = position;
		}
	}

	private void LateUpdate()
	{
		Move();
	}
}
