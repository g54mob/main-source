using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Extractor))]
public class ExtractorAudioComponent : MonoBehaviour
{
	[SerializeField]
	private AudioClip startExtractingAudio;

	[SerializeField]
	private AudioClip loopExtractingAudio;

	[SerializeField]
	private AudioClip endExtractingAudio;

	[SerializeField]
	private float volume = 1f;

	[SerializeField]
	private float maxRolloffDistance = 35f;

	[SerializeField]
	private Vector2 minMaxPitch = Vector2.one;

	private float currentPitch;

	private Extractor extractor;

	private AudioSource currentAudioSource;

	private Coroutine startExtractingCoroutine;

	private WaitForSeconds startExtractingAudioWFS;

	private void Awake()
	{
		extractor = GetComponent<Extractor>();
		currentPitch = Random.Range(minMaxPitch.x, minMaxPitch.y);
		startExtractingAudioWFS = new WaitForSeconds(startExtractingAudio.length - 0.25f);
		extractor.onStartExtracting += OnStartExtracting;
		extractor.onStopExtracting += OnStopExtracting;
	}

	private void OnStartExtracting()
	{
		this.StartCoroutineCheckingVar(StartExtractingCoroutine(), ref startExtractingCoroutine, stopCoroutineIfRunning: true);
	}

	private void OnStopExtracting()
	{
		if ((bool)currentAudioSource && (currentAudioSource.clip == loopExtractingAudio || currentAudioSource.clip == startExtractingAudio))
		{
			this.StopCoroutineCheckingVar(ref startExtractingCoroutine);
			currentAudioSource = AudioSystem.Instance.CrossfadeSounds(currentAudioSource, endExtractingAudio, 0.25f);
			currentAudioSource.loop = false;
			currentAudioSource = null;
		}
	}

	private IEnumerator StartExtractingCoroutine()
	{
		if (!currentAudioSource)
		{
			currentAudioSource = AudioSystem.Instance.PlaySound3D(startExtractingAudio, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, volume, currentPitch, AudioRolloffMode.Custom, 1f, maxRolloffDistance);
			currentAudioSource.loop = true;
			yield return startExtractingAudioWFS;
			currentAudioSource = AudioSystem.Instance.CrossfadeSounds(currentAudioSource, loopExtractingAudio, 0.25f);
		}
	}
}
