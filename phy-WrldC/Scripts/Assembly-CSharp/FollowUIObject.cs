using UnityEngine;

public class FollowUIObject : MonoBehaviour
{
	[SerializeField]
	private GameObject objectToFollow;

	private Vector3 thisInitialPos;

	private Vector3 objectInitialPos;

	private void Awake()
	{
		thisInitialPos = base.transform.position;
		if (objectToFollow != null)
		{
			objectInitialPos = objectToFollow.transform.position;
		}
	}

	private void Update()
	{
		RefreshPosition();
	}

	private void OnEnable()
	{
		RefreshPosition();
	}

	private void RefreshPosition()
	{
		if (!(objectToFollow == null))
		{
			Vector3 vector = objectToFollow.transform.position - objectInitialPos;
			base.transform.position = thisInitialPos + vector;
		}
	}
}
