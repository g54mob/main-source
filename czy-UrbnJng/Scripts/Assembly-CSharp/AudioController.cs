using UnityEngine;

public class AudioController : MonoBehaviour
{
	[SerializeField]
	private GameObject musicManager;

	public static AudioController Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public void MuteMusic(bool muted)
	{
		musicManager.GetComponent<AudioSource>().mute = muted;
	}

	public void MuteSound(bool muted)
	{
		SoundManager.Instance.MuteSounds(muted);
	}
}
