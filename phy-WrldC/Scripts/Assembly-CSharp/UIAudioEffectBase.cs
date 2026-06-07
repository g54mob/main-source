using UnityEngine;

public abstract class UIAudioEffectBase : MonoBehaviour
{
	[SerializeField]
	private UIAudioEffectsManager uiAudioEffectsManager;

	[SerializeField]
	private float volume = 1f;

	public float Volume
	{
		set
		{
			volume = value;
		}
	}

	private UIAudioEffectsManager UIAudioEffectsManager
	{
		get
		{
			if (uiAudioEffectsManager == null && GameManager.Exist)
			{
				uiAudioEffectsManager = GameManager.Instance.UIAudioEffectsManager;
			}
			return uiAudioEffectsManager;
		}
	}

	protected virtual void Awake()
	{
		uiAudioEffectsManager = GameManager.Instance.UIAudioEffectsManager;
	}

	protected void PlayAudio(AudioClip audioClip)
	{
		if (UIAudioEffectsManager != null)
		{
			UIAudioEffectsManager.PlayAudio(audioClip, volume);
		}
	}
}
