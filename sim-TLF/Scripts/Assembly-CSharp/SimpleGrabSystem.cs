using UnityEngine;

public class SimpleGrabSystem : MonoBehaviour
{
	[Header("Grab Settings")]
	public float grabRange = 3f;

	public float holdDistance = 2f;

	public float maxLiftWeight = 50f;

	[Header("Weight Curves")]
	public AnimationCurve weightLiftCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0.1f);

	public AnimationCurve speedCurve = AnimationCurve.Linear(0f, 1f, 1f, 0.3f);

	[Header("Physics")]
	public float liftForce = 10f;

	public float pushForce = 5f;

	private Rigidbody grabbedObject;

	private float objectWeight;

	private Camera cam;

	private void Start()
	{
		cam = Camera.main;
	}

	private void Update()
	{
		if (grabbedObject != null)
		{
			Vector3 vector = cam.transform.position + cam.transform.forward * holdDistance - grabbedObject.position;
			float time = objectWeight / maxLiftWeight;
			float num = weightLiftCurve.Evaluate(time);
			grabbedObject.linearVelocity = vector * liftForce * num;
		}
	}

	private void TryGrab()
	{
		if (!Physics.Raycast(new Ray(cam.transform.position, cam.transform.forward), out var hitInfo, grabRange))
		{
			return;
		}
		Rigidbody component = hitInfo.collider.GetComponent<Rigidbody>();
		if (component != null)
		{
			objectWeight = component.mass;
			if (objectWeight <= maxLiftWeight)
			{
				grabbedObject = component;
				component.useGravity = false;
				component.linearDamping = 5f;
				Debug.Log($"Grabbed: {objectWeight}kg");
			}
			else
			{
				component.AddForce(cam.transform.forward * pushForce, ForceMode.Impulse);
				Debug.Log($"Pushed: {objectWeight}kg (too heavy!)");
			}
		}
	}

	private void Release()
	{
		if (grabbedObject != null)
		{
			grabbedObject.useGravity = true;
			grabbedObject.linearDamping = 0.5f;
			grabbedObject = null;
			Debug.Log("Released");
		}
	}

	private void OnDrawGizmos()
	{
		if (cam != null)
		{
			Gizmos.color = ((grabbedObject != null) ? Color.green : Color.yellow);
			Gizmos.DrawRay(cam.transform.position, cam.transform.forward * grabRange);
		}
	}
}
