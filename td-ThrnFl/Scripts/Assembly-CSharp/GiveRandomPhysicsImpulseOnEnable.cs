using UnityEngine;

public class GiveRandomPhysicsImpulseOnEnable : MonoBehaviour
{
	public float velRange = 10f;

	public float angVelRange = 90f;

	private void Start()
	{
		Rigidbody component = GetComponent<Rigidbody>();
		Vector3 normalized = new Vector3(Random.value, Random.value, Random.value).normalized;
		normalized *= Random.Range(0f - velRange, velRange);
		component.velocity = normalized;
		Vector3 normalized2 = new Vector3(Random.value, Random.value, Random.value).normalized;
		normalized2 *= Random.Range(0f - angVelRange, angVelRange);
		component.angularVelocity = normalized2;
	}
}
