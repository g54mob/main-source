using UnityEngine;

public class FollowObject : MonoBehaviour
{
	[SerializeField]
	private GameObject objectToFollow;

	private Vector3 relativePos;

	private Vector3 relativeUpDir;

	private Vector3 relativeFwDir;

	public GameObject ObjectToFollow
	{
		get
		{
			return objectToFollow;
		}
		set
		{
			objectToFollow = value;
			SetInitialVectors();
		}
	}

	private void Awake()
	{
		if (objectToFollow != null)
		{
			SetInitialVectors();
		}
	}

	private void Update()
	{
		RefreshPosition();
	}

	private void RefreshPosition()
	{
		if (!(objectToFollow == null))
		{
			base.transform.position = objectToFollow.transform.TransformPoint(relativePos);
			Vector3 upwards = objectToFollow.transform.TransformDirection(relativeUpDir);
			Vector3 forward = objectToFollow.transform.TransformDirection(relativeFwDir);
			base.transform.rotation = Quaternion.LookRotation(forward, upwards);
		}
	}

	private void SetInitialVectors()
	{
		relativePos = objectToFollow.transform.InverseTransformPoint(base.transform.position);
		relativeUpDir = objectToFollow.transform.InverseTransformDirection(base.transform.up);
		relativeFwDir = objectToFollow.transform.InverseTransformDirection(base.transform.forward);
	}
}
