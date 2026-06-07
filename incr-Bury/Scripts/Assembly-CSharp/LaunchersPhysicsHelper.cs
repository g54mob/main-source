using System;
using UnityEngine;

public class LaunchersPhysicsHelper : MonoBehaviour
{
	public static LaunchersPhysicsHelper Singleton;

	[Header("Test Launch Params")]
	[SerializeField]
	private Rigidbody test_RbToLaunch;

	[SerializeField]
	private float test_launchAngle;

	[SerializeField]
	private GameObject test_LaunchTarget;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			Vector3 force = CalculateLaunchForce(test_RbToLaunch.gameObject.transform.position, test_LaunchTarget.transform.position, test_launchAngle, test_RbToLaunch);
			test_RbToLaunch.linearVelocity = Vector3.zero;
			test_RbToLaunch.AddForce(force, ForceMode.Impulse);
		}
	}

	public static Vector3 CalculateLaunchForce(Vector3 start, Vector3 target, float launchAngle, Rigidbody rb)
	{
		Vector3 vector = target - start;
		float magnitude = new Vector3(vector.x, 0f, vector.z).magnitude;
		float y = vector.y;
		float f = launchAngle * (MathF.PI / 180f);
		float num = Physics.gravity.magnitude * magnitude * magnitude / (2f * (y - Mathf.Tan(f) * magnitude) * Mathf.Cos(f) * Mathf.Cos(f));
		if (num <= 0f)
		{
			Debug.LogWarning("Invalid trajectory: Check the target position and launch angle.");
			return Vector3.zero;
		}
		float num2 = Mathf.Sqrt(num);
		return (new Vector3(vector.x, 0f, vector.z).normalized * num2 * Mathf.Cos(f) + Vector3.up * num2 * Mathf.Sin(f)) * rb.mass;
	}
}
