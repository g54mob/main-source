using UnityEngine;

public class SoundMaker : MonoBehaviour
{
	public void PlaySFX(AudioClip clip)
	{
		AudioManager.S.PlaySFX(clip);
	}
}
