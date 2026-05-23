using UnityEngine;

public class PropStartup : MonoBehaviour
{
	public string afterViewingMomentId;

	public string setBool;

	public string jumpToState;

	private void Start()
	{
		Animator componentInChildren = GetComponentInChildren<Animator>();
		if (!(componentInChildren == null))
		{
			if (!string.IsNullOrEmpty(setBool))
			{
				componentInChildren.SetBool(setBool, true);
			}
			if (!string.IsNullOrEmpty(jumpToState))
			{
				componentInChildren.Play(jumpToState);
			}
		}
	}
}
