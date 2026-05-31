using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	public List<AudioControllerData> Audio;

	[ContextMenu("Update AudioSource")]
	public void UpdateAudioSource()
	{
	}

	private void Start()
	{
	}

	public static void PlayClipFromTime(AudioSource source, AudioClip clip, float startTime)
	{
	}
}
