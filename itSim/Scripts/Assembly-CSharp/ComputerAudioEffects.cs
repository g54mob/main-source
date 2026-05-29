using UnityEngine;

public class ComputerAudioEffects : MonoBehaviour
{
	[Header("Components")]
	public ComputerStation computerStation;

	[Header("Audio Settings")]
	public AudioSource audioSource;

	public AudioClip keyboardClickClip;

	public float keyboardClipStartTime;

	public AudioClip mouseClickClip;

	public float mouseClipStartTime;

	private void OnValidate()
	{
	}

	public void PlayKeyboardClick()
	{
	}

	public void PlayMouseClick()
	{
	}

	private void Update()
	{
	}
}
