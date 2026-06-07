using MoreMountains.Feedbacks;
using UnityEngine;

public class PlinkoPillar : MonoBehaviour
{
	[SerializeField]
	private Plinko plinko;

	[SerializeField]
	private MMF_Player onHitFb;

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("PlinkoPuck"))
		{
			plinko.ServerPlayPillarFeedbacks(this);
		}
	}

	public void PlayFeedbacks()
	{
		onHitFb.PlayFeedbacks();
	}
}
