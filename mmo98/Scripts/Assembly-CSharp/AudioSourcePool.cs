using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;

public class AudioSourcePool : ObjectPoolBase<AudioSource>
{
	private readonly Transform _parent;

	private readonly Observable<float> _volumeObservable;

	public AudioSourcePool(Transform parent = null)
	{
		_parent = parent;
		_volumeObservable = ReactiveSettings.AudioSfx.CombineLatest(ReactiveSettings.AudioMaster, (float c, float m) => c * m).Share();
	}

	protected override AudioSource CreateInstance()
	{
		GameObject gameObject = new GameObject($"AudioSource [{base.Count}]");
		gameObject.transform.SetParent(_parent, worldPositionStays: false);
		gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.playOnAwake = false;
		audioSource.dopplerLevel = 0f;
		_volumeObservable.Subscribe(audioSource, delegate(float a, AudioSource s)
		{
			s.volume = a;
		}).AddTo(gameObject);
		return audioSource;
	}

	protected override void OnRent(AudioSource instance)
	{
		instance.gameObject.SetActive(value: true);
	}

	protected override void OnReturn(AudioSource instance)
	{
		instance.Stop();
		instance.transform.SetParent(_parent, worldPositionStays: false);
		instance.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		instance.gameObject.SetActive(value: false);
	}

	protected override void OnDestroy(AudioSource instance)
	{
		Object.Destroy(instance.gameObject);
	}

	public async UniTaskVoid HandleFinishedAudioSourcesAsync(float interval, CancellationToken cts)
	{
		while (!cts.IsCancellationRequested)
		{
			for (int num = base.Rented.Count - 1; num >= 0; num--)
			{
				AudioSource audioSource = base.Rented[num];
				if (!audioSource.isPlaying)
				{
					Return(audioSource);
				}
			}
			await UniTask.WaitForSeconds(interval, ignoreTimeScale: false, PlayerLoopTiming.Update, cts, cancelImmediately: true);
		}
	}
}
