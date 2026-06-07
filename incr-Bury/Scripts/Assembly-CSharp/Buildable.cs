using MoreMountains.Feedbacks;
using UnityEngine;

public class Buildable : MonoBehaviour
{
	public BuildableIdentity buildableIdentity;

	public BuildModeRotationMode rotationSnap;

	public bool canSell;

	[Header("Feedbacks")]
	[SerializeField]
	private MMF_Player feedback_DeletionWiggle;

	private void Start()
	{
		GameManager.Singleton.allSpawnedBuildables.Add(this);
		StopDeletionWiggle_Feedback();
	}

	private void OnDestroy()
	{
		GameManager.Singleton.allSpawnedBuildables.Remove(this);
	}

	public void PlayDeletionWiggle_Feedback()
	{
		feedback_DeletionWiggle?.PlayFeedbacks();
	}

	public void StopDeletionWiggle_Feedback()
	{
		feedback_DeletionWiggle?.StopFeedbacks();
		feedback_DeletionWiggle?.RestoreInitialValues();
	}

	public bool IsPlayingDeletionWiggleFeedback()
	{
		return feedback_DeletionWiggle.IsPlaying;
	}
}
