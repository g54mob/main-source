using UnityEngine;

public class HygienePenalty : MonoBehaviour
{
	private void OnEnable()
	{
		ReviewsManager.Instance.UpdateHygienePenalty(1);
	}

	private void OnDisable()
	{
		ReviewsManager.Instance.UpdateHygienePenalty(-1);
	}
}
