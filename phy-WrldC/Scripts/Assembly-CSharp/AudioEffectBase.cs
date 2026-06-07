using UnityEngine;

public abstract class AudioEffectBase : MonoBehaviour
{
	[SerializeField]
	private AudioSource audioSource;

	private bool isAlreadyInitialized;

	protected AudioSource AudioSource
	{
		get
		{
			if (audioSource == null && AudioEffectsManager.Exist)
			{
				audioSource = AudioEffectsManager.Instance.RequestAudioSource();
			}
			return audioSource;
		}
	}

	protected AudioEffectsManager AudioEffectsManager => AudioEffectsManager.Instance;

	private void Awake()
	{
		if (!isAlreadyInitialized)
		{
			Initialize();
			isAlreadyInitialized = true;
		}
	}

	protected virtual void Update()
	{
	}

	protected abstract void Initialize();

	public virtual void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		if (!isAlreadyInitialized)
		{
			Initialize();
			isAlreadyInitialized = true;
		}
	}

	protected void PlayOnceEffect(AudioEffectData audioData, Vector3 worldPosition)
	{
		AudioEffectsManager.PlayOnceEffect(audioData, worldPosition);
	}

	protected void RecycleAudioSource()
	{
		if (audioSource != null && AudioEffectsManager.Exist)
		{
			AudioEffectsManager.Instance.RecycleAudioSource(audioSource);
			audioSource = null;
		}
	}

	protected virtual void OnDisable()
	{
		if (audioSource != null)
		{
			audioSource.Stop();
		}
	}

	protected virtual void OnDestroy()
	{
		RecycleAudioSource();
	}

	public virtual void ResetAudioEffect()
	{
		RecycleAudioSource();
	}
}
