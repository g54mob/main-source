using UnityEngine;

public class ButtonSound : MonoBehaviour
{
	[SerializeField]
	private AudioClip sound;

	public void PlaySound()
	{
		SoundManager.ins.PlaySound(sound);
	}
}
