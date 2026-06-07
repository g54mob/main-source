using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class SteamVR_TestThrow : MonoBehaviour
{
	public GameObject prefab;

	public Rigidbody attachPoint;

	private SteamVR_TrackedObject trackedObj;

	private FixedJoint joint;

	private void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	private void FixedUpdate()
	{
		SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
		if (joint == null && device.GetTouchDown(8589934592uL))
		{
			GameObject gameObject = Object.Instantiate(prefab);
			gameObject.transform.position = attachPoint.transform.position;
			joint = gameObject.AddComponent<FixedJoint>();
			joint.connectedBody = attachPoint;
		}
		else if (joint != null && device.GetTouchUp(8589934592uL))
		{
			GameObject obj = joint.gameObject;
			Rigidbody component = obj.GetComponent<Rigidbody>();
			Object.DestroyImmediate(joint);
			joint = null;
			Object.Destroy(obj, 15f);
			Transform transform = (trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent);
			if (transform != null)
			{
				component.velocity = transform.TransformVector(device.velocity);
				component.angularVelocity = transform.TransformVector(device.angularVelocity);
			}
			else
			{
				component.velocity = device.velocity;
				component.angularVelocity = device.angularVelocity;
			}
			component.maxAngularVelocity = component.angularVelocity.magnitude;
		}
	}
}
