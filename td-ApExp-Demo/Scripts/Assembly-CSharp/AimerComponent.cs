using UnityEngine;

public class AimerComponent : MonoBehaviour
{
	private Transform targetTransform;

	private void Update()
	{
		if (targetTransform != null)
		{
			Vector3 upwards = targetTransform.position - base.transform.position;
			Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, Time.deltaTime * 60f);
		}
		else
		{
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.Euler(0f, 1f, 0f), Time.deltaTime * 60f);
		}
	}

	public void SetTarget(Transform target)
	{
		targetTransform = target;
	}

	public Transform GetTarget()
	{
		return targetTransform;
	}
}
