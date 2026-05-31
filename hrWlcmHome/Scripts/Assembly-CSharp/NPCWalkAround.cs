using UnityEngine;

public class NPCWalkAround : MonoBehaviour
{
	private Vector3 movementVector;

	private Vector3 rotationVector;

	private void Start()
	{
		movementVector = new Vector3(1f, 0f, 0f);
		rotationVector = new Vector3(0f, 1f, 0f);
	}

	private void Update()
	{
		base.transform.Translate(movementVector);
		base.transform.Rotate(rotationVector);
	}
}
