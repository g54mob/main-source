using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
	[SerializeField]
	private AudioClip audioClip;

	[SerializeField]
	private float fadeDuration = 4f;

	[SerializeField]
	private bool destroyEntireGameObject = true;

	private void Start()
	{
		MusicManager instance = MusicManager.instance;
		if (instance != null)
		{
			instance.PlayMusic(audioClip, fadeDuration);
		}
		else
		{
			Debug.LogWarning("MusicManager instance not found.");
		}
		Object.Destroy(this);
		if (destroyEntireGameObject)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
