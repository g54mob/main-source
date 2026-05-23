using UnityEngine;

public class AirPlane : MonoBehaviour
{
	public float speed = 10f;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Vector3 position = rb.position + base.transform.forward * speed * Time.fixedDeltaTime;
		rb.MovePosition(position);
	}
}
