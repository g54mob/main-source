using Dissonance;
using UnityEngine;

public class MicAudioCanvas : MonoBehaviour
{
	public GameObject openMic;

	public GameObject activationMic;

	public GameObject pttMic;

	public int activationMode;

	public DissonanceComms comms;

	public static MicAudioCanvas Instance { get; private set; }

	public void FixedUpdate()
	{
		switch (activationMode)
		{
		case 0:
			openMic.SetActive(value: true);
			break;
		case 1:
		{
			openMic.SetActive(value: false);
			bool active = false;
			if (comms != null && !string.IsNullOrEmpty(comms.LocalPlayerName))
			{
				VoicePlayerState voicePlayerState = comms.FindPlayer(comms.LocalPlayerName);
				if (voicePlayerState != null)
				{
					active = voicePlayerState.IsSpeaking;
				}
			}
			activationMic.gameObject.SetActive(active);
			break;
		}
		case 2:
			openMic.SetActive(value: false);
			break;
		}
	}

	private void Awake()
	{
		Instance = this;
	}
}
