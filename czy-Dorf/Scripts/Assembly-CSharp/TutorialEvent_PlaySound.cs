using UnityEngine;

public class TutorialEvent_PlaySound : TutorialEvent
{
	[SerializeField]
	private AudioClipOptions audioClip;

	public override void Begin()
	{
		AudioManager.Instance.PlayGlobalSound(audioClip);
	}

	public override void Finish()
	{
	}

	public override void Skip()
	{
	}
}
