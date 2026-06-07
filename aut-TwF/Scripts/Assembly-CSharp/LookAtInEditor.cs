using UnityEngine;

[ExecuteAlways]
public class LookAtInEditor : MonoBehaviour
{
	[SerializeField]
	private Transform lookAtTransform;

	private void Update()
	{
		if ((bool)lookAtTransform)
		{
			base.transform.LookAt(lookAtTransform, Vector3.up);
		}
	}
}
