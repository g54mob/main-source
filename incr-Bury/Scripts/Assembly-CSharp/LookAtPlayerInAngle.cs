using UnityEngine;

public class LookAtPlayerInAngle : MonoBehaviour
{
	[SerializeField]
	private float lookAtPlayer_DistanceThreshold;

	[SerializeField]
	private float lookAtPlayer_ViewAngle;

	[SerializeField]
	private float lookAtPlayer_LookSpeed;

	private bool playerIsLookable;

	[SerializeField]
	private Transform forwardFacingHelper;

	[SerializeField]
	private GameObject emptyLookTarget;

	[SerializeField]
	private bool isComputer;

	private void Update()
	{
		if ((bool)GameManager.Singleton.playerCamera)
		{
			HandleVisionAngleChecks();
			HandleLookRotation();
		}
	}

	private void HandleVisionAngleChecks()
	{
		if ((bool)GameManager.Singleton.playerCamera)
		{
			Vector3 to = GameManager.Singleton.playerCamera.transform.position - base.transform.position;
			if (to.magnitude <= lookAtPlayer_DistanceThreshold && Vector3.Angle(forwardFacingHelper.forward, to) <= lookAtPlayer_ViewAngle * 0.5f)
			{
				playerIsLookable = true;
			}
			else
			{
				playerIsLookable = false;
			}
		}
	}

	private void HandleLookRotation()
	{
		if ((bool)GameManager.Singleton.playerCamera && (!isComputer || PcManager.Singleton.pcIsOn))
		{
			if (playerIsLookable)
			{
				Quaternion b = Quaternion.LookRotation(GameManager.Singleton.playerCamera.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, lookAtPlayer_LookSpeed * Time.fixedDeltaTime);
			}
			else
			{
				Quaternion b2 = Quaternion.LookRotation(emptyLookTarget.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, lookAtPlayer_LookSpeed * Time.fixedDeltaTime);
			}
		}
	}
}
