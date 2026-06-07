using UnityEngine;

public class LayeredAudioTest : MonoBehaviour
{
	public LayeredAudio layeredAudio;

	[Range(0f, 1f)]
	public float volumeValue;

	[Range(0f, 1f)]
	public float pitchValue;

	private void Start()
	{
		if (!layeredAudio)
		{
			layeredAudio = GetComponent<LayeredAudio>();
		}
		if ((bool)layeredAudio)
		{
			layeredAudio.Reset();
		}
	}

	private void Update()
	{
		if ((bool)layeredAudio && layeredAudio.type == LayeredAudio.Type.Continuous)
		{
			layeredAudio.SetVolume(volumeValue);
			layeredAudio.SetPitch(pitchValue);
		}
	}

	public void Fire()
	{
		if (!Application.isPlaying)
		{
			Debug.LogWarning("Only works while the scene is playing");
		}
		else if (layeredAudio.type == LayeredAudio.Type.OneTime)
		{
			layeredAudio.PlayOnce(base.transform.position, volumeValue);
		}
		else
		{
			Debug.LogWarning("Layered Audio is not One Time");
		}
	}
}
