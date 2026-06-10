using UnityEngine;

public class RotatingFan : MonoBehaviour
{
	[Tooltip("The transform representing the pivot of the fan")]
	[SerializeField]
	private Transform pivotTransform;

	[Tooltip("Rotation speed in degrees per second")]
	[SerializeField]
	private float rotationSpeed = 100f;

	private void Start()
	{
		float z = Random.Range(0f, 360f);
		Transform transform = ((pivotTransform != null) ? pivotTransform : base.transform);
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, z);
	}

	private void Update()
	{
		if (pivotTransform != null)
		{
			pivotTransform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime), Space.Self);
		}
		else
		{
			base.transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime), Space.Self);
		}
	}
}
