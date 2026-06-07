using UnityEngine;

public class FollowTransform : MonoBehaviour
{
	public Transform Target;

	private void Update()
	{
		base.transform.position = Target.position;
	}
}
