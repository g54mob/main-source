using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	[SerializeField]
	private Transform target;

	[SerializeField]
	private Vector3 offset;

	private void Update()
	{
		base.transform.position = target.position + offset;
	}
}
