using MoreMountains.Feedbacks;
using UnityEngine;

public class Coinslot : MonoBehaviour
{
	public Transform fillTarget;

	public AnimationCurve fillCurve;

	public MMF_Player fullFeedback;

	public MMF_Player deniedFeedback;

	public MMF_Player appearFeedback;

	public MMF_Player disappearFeedback;

	public MMF_Player fullCompleteFeedback;

	private float fill01;

	public bool isFull => fill01 >= 1f;

	public float CurrentFill01 => fill01;

	public bool AddFill(float percentage, bool isLastCoin)
	{
		fill01 += percentage;
		fillTarget.localScale = Vector3.one * fillCurve.Evaluate(Mathf.Clamp01(fill01));
		if (isFull)
		{
			if (!isLastCoin)
			{
				fullFeedback.PlayFeedbacks();
			}
			else
			{
				fullCompleteFeedback.PlayFeedbacks();
			}
			return true;
		}
		return false;
	}

	public void SetEmpty()
	{
		fill01 = 0f;
		fillTarget.localScale = Vector3.zero;
	}

	public void PlayDeny()
	{
		deniedFeedback.PlayFeedbacks();
	}

	public void Appear()
	{
		fullFeedback.StopFeedbacks();
		deniedFeedback.StopFeedbacks();
		appearFeedback.StopFeedbacks();
		disappearFeedback.StopFeedbacks();
		fill01 = 0f;
		fillTarget.localScale = Vector3.zero;
		base.transform.localScale = Vector3.zero;
		appearFeedback.PlayFeedbacks();
	}

	public void Disappear()
	{
		fullFeedback.StopFeedbacks();
		deniedFeedback.StopFeedbacks();
		appearFeedback.StopFeedbacks();
		disappearFeedback.StopFeedbacks();
		disappearFeedback.PlayFeedbacks();
	}
}
