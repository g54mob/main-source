using UnityEngine;

public class CommonAudioHelper : MonoBehaviour
{
	public static CommonAudioHelper Instance;

	private void Awake()
	{
		Instance = this;
	}

	public void PlayErrorSound()
	{
		GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
	}
}
