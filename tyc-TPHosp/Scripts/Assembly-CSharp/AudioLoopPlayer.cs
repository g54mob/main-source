using TH20;
using UnityEngine;

public class AudioLoopPlayer : MonoBehaviour
{
	public GameObject SourceGameObject;

	public string AudioLoop;

	public bool OnlyPlayIfActive;

	private bool _lLoopPlaying;

	private AudioEmitter _emitter;

	private void Start()
	{
	}

	protected virtual void Update()
	{
		UpdateAudioState();
	}

	public void UpdateAudioState()
	{
		if (!_lLoopPlaying && (!OnlyPlayIfActive || base.gameObject.activeSelf))
		{
			_emitter = AudioManager.Instance.Play(AudioLoop, SourceGameObject);
			_lLoopPlaying = true;
		}
		else if (_lLoopPlaying && OnlyPlayIfActive && !base.gameObject.activeSelf)
		{
			AudioManager.Instance.Stop(_emitter);
			_lLoopPlaying = false;
		}
	}
}
