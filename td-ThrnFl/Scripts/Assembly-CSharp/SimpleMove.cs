using UnityEngine;

public class SimpleMove : MonoBehaviour
{
	public Vector3 movementSpeed;

	private void Update()
	{
		base.transform.position += movementSpeed * Time.deltaTime;
	}
}
