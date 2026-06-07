using UnityEngine;

public class CharacterControl2D : MonoBehaviour
{
	public float acceleration = 10f;

	public float maxSpeed = 8f;

	public float jumpPower = 2f;

	public float floorRaycastDistance = 1.2f;

	private Rigidbody unityRigidbody;

	public void Awake()
	{
		unityRigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		unityRigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * acceleration, 0f, 0f));
		bool flag = Physics.Raycast(new Ray(base.transform.position, -Vector3.up), floorRaycastDistance);
		if (Input.GetButtonDown("Jump") && flag)
		{
			unityRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
		}
	}

	private void FixedUpdate()
	{
		unityRigidbody.velocity = Vector3.ClampMagnitude(unityRigidbody.velocity, maxSpeed);
	}
}
