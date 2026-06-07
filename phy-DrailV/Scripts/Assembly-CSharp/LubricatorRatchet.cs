using UnityEngine;

public class LubricatorRatchet : MonoBehaviour
{
	public Vector3 localAxis;

	private Transform ratchetDriverTransform;

	private float prevAngle;

	private void Start()
	{
		LubricatorRatchetDriver componentInChildren = TrainCar.Resolve(base.gameObject).transform.GetComponentInChildren<LubricatorRatchetDriver>();
		if (!componentInChildren)
		{
			Debug.LogError("Could not find LubricatorRatchetDriver", this);
			Object.Destroy(this);
		}
		else
		{
			ratchetDriverTransform = componentInChildren.transform;
			prevAngle = ratchetDriverTransform.localEulerAngles.x;
		}
	}

	private void Update()
	{
		float num = Mathf.Repeat(ratchetDriverTransform.localEulerAngles.x + 90f, 360f);
		float num2 = num - prevAngle;
		if (num2 > 0f)
		{
			base.transform.Rotate(localAxis * num2);
		}
		prevAngle = num;
	}
}
