using UnityEngine;

public class FollowCenter : MonoBehaviour
{
	public GameObject follow;

	private void Update()
	{
		base.transform.position = follow.transform.position;
	}
}
