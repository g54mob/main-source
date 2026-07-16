using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
	[SerializeField]
	private Transform source;

	[SerializeField]
	private float lookHeight = 1f;

	private void Update()
	{
		Vector3 vector = base.transform.position - (GlobalReferences.GetCameraController().transform.position + Vector3.up * (0.1f * lookHeight));
		vector.Normalize();
		source.rotation = Quaternion.LookRotation(-vector);
	}
}
