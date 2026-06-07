using UnityEngine;

public class QuickInventoryAudioEffect : UIAudioEffectBase
{
	[SerializeField]
	private AudioClip toggleOnClip;

	public AudioClip ToggleOnClip
	{
		set
		{
			toggleOnClip = value;
		}
	}

	public void TabOrSlotChangedApplyAudio()
	{
		if (toggleOnClip != null)
		{
			PlayAudio(toggleOnClip);
		}
	}
}
