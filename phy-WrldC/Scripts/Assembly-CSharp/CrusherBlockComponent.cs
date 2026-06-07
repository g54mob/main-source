using UnityEngine;

public class CrusherBlockComponent : MainMenuComponentBase
{
	private Vector3 initialPosition;

	private Quaternion initialRotation;

	private Rigidbody rb;

	private void Awake()
	{
		initialPosition = base.transform.position;
		initialRotation = base.transform.rotation;
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
	}

	protected override void InternalOnSpawnCreationStartingHandler()
	{
		rb.mass = Random.Range(100f, 1000f);
		rb.isKinematic = false;
	}

	protected override void InternalOnSpawnCreationEndingHandler()
	{
		base.transform.position = initialPosition;
		base.transform.rotation = initialRotation;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.isKinematic = true;
	}
}
