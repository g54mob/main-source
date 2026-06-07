using MoreMountains.Feedbacks;
using UnityEngine;

public class TrampolineTrigger : MonoBehaviour
{
	[SerializeField]
	private Collider triggerCol;

	[SerializeField]
	private Collider ignoreThisCol;

	[SerializeField]
	private MMF_Player Feedback_Bounce;

	[SerializeField]
	private Vector2 arcHeight_DistanceSpectrum;

	[SerializeField]
	private float arcHeightDistMulti;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnTriggerEnter(Collider _other)
	{
		if (!(_other == ignoreThisCol) && _other.gameObject.CompareTag("PickUp"))
		{
			Rigidbody componentInParent = _other.GetComponentInParent<Rigidbody>();
			componentInParent.linearVelocity = Vector3.zero;
			float value = Vector3.Distance(base.transform.position, GameManager.Singleton.GetYardObject().transform.position) * arcHeightDistMulti;
			componentInParent.linearVelocity = FlingUtility.CalculateArcVelocity(arcHeight: Mathf.Clamp(value, arcHeight_DistanceSpectrum.x, arcHeight_DistanceSpectrum.y), start: base.transform.position, end: GameManager.Singleton.GetYardObject().transform.position + Vector3.up * 2f);
			PlayBounceFeedbacks();
		}
	}

	public void PlayBounceFeedbacks()
	{
		Feedback_Bounce?.PlayFeedbacks();
	}
}
