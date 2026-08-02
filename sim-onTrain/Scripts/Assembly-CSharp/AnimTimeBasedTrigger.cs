using UnityEngine;

public class AnimTimeBasedTrigger : MonoBehaviour
{
	[SerializeField]
	private float repeatTime;

	[SerializeField]
	private string animationName;

	private void OnEnable()
	{
		InvokeRepeating("PlayAnimation", repeatTime, 1f);
	}

	private void OnDisable()
	{
		CancelInvoke("PlayAnimation");
	}

	private void PlayAnimation()
	{
	}
}
