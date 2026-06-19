using UnityEngine;

public class SoundEffects_AE : MonoBehaviour
{
	public bool playSoundOnStart;

	public SfxUnityInspectorFriendlyID soundToPlay;

	public float volume = 1f;

	public float pitch = 1f;

	public float pitchDev;

	private void Start()
	{
		if (playSoundOnStart)
		{
			AudioManager.SfxFollowTransform(Manager.audio.InspectorFriendlySfxIDToSfxID(soundToPlay), base.transform, pitch: pitch, pitchDev: pitchDev, volume: volume);
		}
	}

	public void BridgeBreak_AE()
	{
		AudioManager.SfxFollowTransform(SfxID.wall, base.transform, 1f, 1f, 0.1f);
	}

	public void BridgePieceFall_AE()
	{
		AudioManager.SfxFollowTransform(SfxID.burrow, base.transform, 0.7f, 0.7f, 0.2f);
	}
}
