using UnityEngine;

public class SmoothPivotRotation : MonoBehaviour
{
	public float swaySpeed = 2f;

	private Quaternion targetRotation;

	public GameObject emptyGameObject;

	public Transform rotationGizmoTransform;

	public Transform highestParent;

	private void Start()
	{
		rotationGizmoTransform = Object.Instantiate(emptyGameObject, base.transform.position, Quaternion.identity).transform;
	}

	private void FixedUpdate()
	{
		rotationGizmoTransform.position = Vector3.Lerp(rotationGizmoTransform.position, base.transform.position, Time.deltaTime * swaySpeed);
		Vector3 vector = rotationGizmoTransform.position - base.transform.position;
		base.transform.eulerAngles = new Vector3(vector.x * 130f, 0f, vector.z * 130f);
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, 0f, base.transform.localEulerAngles.z);
	}
}
