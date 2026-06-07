using MoreMountains.Feedbacks;
using UnityEngine;

public class SpawnEffectBloopIn : MonoBehaviour
{
	[SerializeField]
	private MMF_Player feedback_Spawning;

	[SerializeField]
	private GameObject artToBloop;

	private void Start()
	{
		feedback_Spawning.PlayFeedbacks();
	}
}
