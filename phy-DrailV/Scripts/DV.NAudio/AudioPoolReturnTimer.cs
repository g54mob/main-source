using System;
using System.Collections;
using UnityEngine;

public class AudioPoolReturnTimer : MonoBehaviour
{
	public event Action<AudioReferences> SourceStopped;

	private void OnDestroy()
	{
		NAudio.ClearPoolReferences();
	}

	public void RequestInformWhenSourceStopsPlaying(AudioReferences audioSource, float delay, bool playDuringPause = false)
	{
		StartCoroutine(CallSourceStoppedEventAfterDelay(audioSource, delay, playDuringPause));
	}

	private IEnumerator CallSourceStoppedEventAfterDelay(AudioReferences source, float delay, bool playDuringPause = false)
	{
		if (playDuringPause)
		{
			yield return WaitFor.SecondsRealtime(delay);
		}
		else
		{
			yield return WaitFor.Seconds(delay);
		}
		this.SourceStopped?.Invoke(source);
	}
}
