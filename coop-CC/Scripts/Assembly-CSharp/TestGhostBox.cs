using Unity.Mathematics;
using UnityEngine;

public class TestGhostBox : MonoBehaviour
{
	public bool turnOnGhosting;

	public float verticalSpeed;

	[Space]
	public float horizontalSpeed;

	public float horizontalNoiseScale;

	[Space]
	public float angularSpeed;

	public float angularNoiseScale;

	public float duration = 5f;

	public Rigidbody rb;

	private float _t;

	private void FixedUpdate()
	{
		if (!turnOnGhosting)
		{
			_t = 0f;
			return;
		}
		_t += 1f / 60f;
		float num = EasingFunction.EaseInQuad(0f, 1f, math.saturate(_t / duration));
		Vector3 force = -Physics.gravity + Vector3.up * verticalSpeed * num;
		float num2 = math.sin(Time.time * horizontalNoiseScale);
		force += Vector3.right * num2 * horizontalSpeed * num;
		rb.AddForce(force, ForceMode.Acceleration);
		float num3 = math.sin(Time.time * angularNoiseScale);
		float z = num * num3 * angularSpeed;
		rb.AddTorque(new Vector3(0f, 0f, z), ForceMode.Acceleration);
	}
}
