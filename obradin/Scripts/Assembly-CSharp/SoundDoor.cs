using UnityEngine;

public class SoundDoor : MonoBehaviour
{
	public string openInTag;

	private Animator modelAnimator;

	public bool IsOpen
	{
		get
		{
			if (modelAnimator == null)
			{
				return true;
			}
			return modelAnimator.GetCurrentAnimatorStateInfo(0).IsTag(openInTag);
		}
	}

	private void Start()
	{
		modelAnimator = GetComponentInChildren<Animator>();
	}
}
