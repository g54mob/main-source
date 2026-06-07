using Dissonance;
using UnityEngine;

public class VoiceVolumeController : MonoBehaviour
{
	[SerializeField]
	private DissonanceComms comms;

	[Range(0f, 2f)]
	[SerializeField]
	private float micGain = 1f;

	public void SetMicVolume(float volume)
	{
		micGain = Mathf.Clamp(volume, 0f, 2f);
		Debug.Log($"Outgoing mic volume set to {micGain}");
	}

	private void Start()
	{
		if (comms == null)
		{
			comms = Object.FindObjectOfType<DissonanceComms>();
		}
		if (comms == null)
		{
			Debug.LogError("[VoiceVolumeController] No DissonanceComms found in scene.");
			base.enabled = false;
		}
	}

	private void OnAudioFilterRead(float[] data, int channels)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] *= micGain;
		}
	}
}
