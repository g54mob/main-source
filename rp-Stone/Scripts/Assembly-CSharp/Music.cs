using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
	public enum FadeOutResult
	{
		PauseMusic = 0,
		StopMusic = 1
	}

	public enum State
	{
		Off = 0,
		FadingIn = 1,
		Playing = 2,
		FadingOut = 3
	}

	public string id;

	public bool destroyOnStop;

	private FadeOutResult _fadeOutResult;

	private State _currentState;

	private float _stateElapsedTime;

	private AudioSource _audioSource;

	private float _fadeInDuration;

	private float _fadeOutDuration;

	public State currentState => _currentState;

	public AudioSource audioSource => _audioSource;

	public float defaultVolume { get; private set; }

	public float targetVolume { get; set; }

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Off:
			if (_fadeOutResult == FadeOutResult.PauseMusic)
			{
				_audioSource.Pause();
				break;
			}
			_audioSource.Stop();
			if (destroyOnStop)
			{
				Object.Destroy(base.gameObject);
			}
			break;
		case State.Playing:
			_audioSource.volume = targetVolume;
			break;
		}
		switch (newState)
		{
		case State.FadingIn:
			if (currentState == State.FadingOut)
			{
				float num2 = Mathf.Clamp01(_stateElapsedTime / _fadeOutDuration);
				_stateElapsedTime = (1f - num2) * _fadeInDuration;
			}
			else
			{
				_audioSource.volume = 0f;
				_stateElapsedTime = 0f;
			}
			break;
		case State.FadingOut:
			if (currentState == State.FadingIn)
			{
				float num = Mathf.Clamp01(_stateElapsedTime / _fadeInDuration);
				_stateElapsedTime = (1f - num) * _fadeOutDuration;
			}
			else
			{
				_audioSource.volume = targetVolume;
				_stateElapsedTime = 0f;
			}
			break;
		default:
			_stateElapsedTime = 0f;
			break;
		}
		_currentState = newState;
	}

	private void Update()
	{
		_stateElapsedTime += Utils.deltaTime;
		if (_currentState == State.FadingIn)
		{
			float num = _stateElapsedTime / _fadeInDuration;
			if (num >= 1f)
			{
				_audioSource.volume = targetVolume;
				SetState(State.Playing);
			}
			else
			{
				_audioSource.volume = num * targetVolume;
			}
		}
		else if (_currentState == State.FadingOut)
		{
			float num2 = _stateElapsedTime / _fadeOutDuration;
			if (num2 >= 1f)
			{
				_audioSource.volume = 0f;
				SetState(State.Off);
			}
			else
			{
				_audioSource.volume = (1f - num2) * targetVolume;
			}
		}
		else if (_currentState == State.Playing && _audioSource.volume != targetVolume)
		{
			_audioSource.volume = Mathf.Lerp(_audioSource.volume, targetVolume, Utils.deltaTime * 8f);
			if (Mathf.Abs(_audioSource.volume - targetVolume) < 0.01f)
			{
				_audioSource.volume = targetVolume;
			}
		}
	}

	public void Play(float fadeInDuration, float delay = 0f)
	{
		_fadeInDuration = fadeInDuration;
		if (fadeInDuration >= 0f)
		{
			SetState(State.FadingIn);
		}
		else
		{
			SetState(State.Playing);
		}
		_audioSource.PlayDelayed(delay);
	}

	public void Pause(float fadeOutDuration)
	{
		Stop(fadeOutDuration);
		_fadeOutResult = FadeOutResult.PauseMusic;
	}

	public void Stop(float fadeOutDuration)
	{
		_fadeOutDuration = fadeOutDuration;
		if (fadeOutDuration >= 0f)
		{
			SetState(State.FadingOut);
		}
		else
		{
			SetState(State.Off);
		}
		_fadeOutResult = FadeOutResult.StopMusic;
	}

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		defaultVolume = _audioSource.volume;
		targetVolume = defaultVolume;
	}
}
