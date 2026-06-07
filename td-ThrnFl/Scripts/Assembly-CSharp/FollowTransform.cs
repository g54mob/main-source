using UnityEngine;

public class FollowTransform : MonoBehaviour
{
	public Transform target;

	private void Update()
	{
		if ((bool)target)
		{
			base.transform.position = target.position;
		}
	}
}
