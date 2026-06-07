using UnityEngine;

public class DebugPusher : MonoBehaviour
{
	public Vector3 axis;

	public float force;

	[InspectorButton("DebugPushAngular", true, true)]
	public bool AngularPush;

	private void DebugPushAngular()
	{
		GetComponent<Rigidbody>().AddTorque(axis * force);
	}
}
