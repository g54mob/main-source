using UnityEngine;

public class WinchController : MonoBehaviour
{
	public Rigidbody planeRigidbody;

	public WinchCable[] cables;

	[Header("Winch control")]
	public float winchSpeed = 2f;

	public KeyCode winchInKey = KeyCode.E;

	public KeyCode winchOutKey = KeyCode.Q;

	public bool autoAttachWhenClose = true;

	public float attachDistanceThreshold = 1.5f;

	private void Reset()
	{
		planeRigidbody = GetComponentInChildren<Rigidbody>();
	}

	private void Start()
	{
		WinchCable[] array = cables;
		foreach (WinchCable winchCable in array)
		{
			if (winchCable.lineRenderer != null)
			{
				winchCable.lineRenderer.positionCount = 2;
				winchCable.lineRenderer.enabled = winchCable.attached;
			}
		}
	}

	private void Update()
	{
		float num = 0f;
		if (Input.GetKey(winchInKey))
		{
			num = (0f - winchSpeed) * Time.deltaTime;
		}
		if (Input.GetKey(winchOutKey))
		{
			num = winchSpeed * Time.deltaTime;
		}
		WinchCable[] array = cables;
		foreach (WinchCable winchCable in array)
		{
			if (!winchCable.attached)
			{
				if (autoAttachWhenClose && winchCable.planeAttachPoint != null && winchCable.winchAnchor != null && Vector3.Distance(winchCable.planeAttachPoint.position, winchCable.winchAnchor.position) < attachDistanceThreshold)
				{
					winchCable.attached = true;
				}
			}
			else
			{
				winchCable.restLength = Mathf.Clamp(winchCable.restLength + num, winchCable.minLength, winchCable.maxLength);
			}
		}
	}

	private void FixedUpdate()
	{
		if (planeRigidbody == null)
		{
			return;
		}
		WinchCable[] array = cables;
		foreach (WinchCable winchCable in array)
		{
			if (!winchCable.attached || winchCable.planeAttachPoint == null || winchCable.winchAnchor == null)
			{
				continue;
			}
			Vector3 position = winchCable.planeAttachPoint.position;
			Vector3 position2 = winchCable.winchAnchor.position;
			Vector3 vector = position2 - position;
			float magnitude = vector.magnitude;
			if (!(magnitude < 0.0001f))
			{
				Vector3 vector2 = vector / magnitude;
				float num = Mathf.Max(0f, magnitude - winchCable.restLength);
				Vector3 pointVelocity = planeRigidbody.GetPointVelocity(position);
				Vector3 vector3 = Vector3.zero;
				Rigidbody component = winchCable.winchAnchor.GetComponent<Rigidbody>();
				if (component != null)
				{
					vector3 = component.GetPointVelocity(position2);
				}
				float b = Vector3.Dot(pointVelocity - vector3, vector2);
				float value = winchCable.stiffness * num + winchCable.damping * Mathf.Max(0f, b);
				value = Mathf.Clamp(value, 0f, winchCable.maxTension);
				Vector3 vector4 = vector2 * value;
				planeRigidbody.AddForceAtPosition(vector4, position, ForceMode.Force);
				if (component != null)
				{
					component.AddForceAtPosition(-vector4, position2, ForceMode.Force);
				}
				if (winchCable.lineRenderer != null)
				{
					winchCable.lineRenderer.SetPosition(0, position2);
					winchCable.lineRenderer.SetPosition(1, position);
				}
			}
		}
	}

	public void AttachCable(int index)
	{
		if (index >= 0 && index < cables.Length)
		{
			cables[index].attached = true;
		}
	}

	public void DetachCable(int index)
	{
		if (index >= 0 && index < cables.Length)
		{
			cables[index].attached = false;
		}
	}
}
