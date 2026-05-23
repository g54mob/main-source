using UnityEngine;

public class CustomPositionConstraint : MonoBehaviour
{
	public Transform followTransform;

	private void Update()
	{
		if (followTransform != null)
		{
			base.transform.position = followTransform.position;
		}
	}
}
