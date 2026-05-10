using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Processor))]
public class ProcessorAudioComponent : MonoBehaviour
{
	[SerializeField]
	private AudioClip startProcessingAudio;

	[SerializeField]
	private AudioClip loopProcessingAudio;

	[SerializeField]
	private AudioClip endProcessingAudio;

	[SerializeField]
	private float volume = 1f;

	[SerializeField]
	private float maxRolloffDistance = 35f;

	[SerializeField]
	private Vector2 minMaxPitch = Vector2.one;

	private float currentPitch;

	private Processor processor;

	private AudioSource currentAudioSource;

	private Coroutine startProcessingCoroutine;

	private WaitForSeconds startProcessingAudioWFS;

	private void Awake()
	{
		processor = GetComponent<Processor>();
		currentPitch = Random.Range(minMaxPitch.x, minMaxPitch.y);
		startProcessingAudioWFS = new WaitForSeconds(startProcessingAudio ? (startProcessingAudio.length - 0.25f) : 0f);
		processor.onStartProcessingAnimation += OnStartProcessing;
		processor.onStopProcessingAnimation += OnStopProcessing;
	}

	private void OnStartProcessing()
	{
		this.StartCoroutineCheckingVar(StartProcessingCoroutine(), ref startProcessingCoroutine, stopCoroutineIfRunning: true);
	}

	private void OnStopProcessing()
	{
		if ((bool)currentAudioSource && (currentAudioSource.clip == loopProcessingAudio || currentAudioSource.clip == startProcessingAudio))
		{
			this.StopCoroutineCheckingVar(ref startProcessingCoroutine);
			currentAudioSource = AudioSystem.Instance.CrossfadeSounds(currentAudioSource, endProcessingAudio, 0.25f);
			currentAudioSource.loop = false;
			currentAudioSource = null;
		}
	}

	private IEnumerator StartProcessingCoroutine()
	{
		if (!currentAudioSource)
		{
			if ((bool)startProcessingAudio)
			{
				currentAudioSource = AudioSystem.Instance.PlaySound3D(startProcessingAudio, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, volume, currentPitch, AudioRolloffMode.Custom, 1f, maxRolloffDistance);
				currentAudioSource.loop = true;
				yield return startProcessingAudioWFS;
				currentAudioSource = AudioSystem.Instance.CrossfadeSounds(currentAudioSource, loopProcessingAudio, 0.25f);
			}
			else
			{
				currentAudioSource = AudioSystem.Instance.PlaySound3D(loopProcessingAudio, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, 0f, currentPitch, AudioRolloffMode.Custom, 1f, maxRolloffDistance);
				currentAudioSource.loop = true;
				AudioSystem.Instance.FadeAudioSource(currentAudioSource, volume, 0.25f);
			}
		}
	}
}
