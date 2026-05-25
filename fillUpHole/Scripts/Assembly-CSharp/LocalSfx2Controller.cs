using System.Collections.Generic;
using UnityEngine;

public class LocalSfx2Controller : MonoBehaviour
{
	private SoundManager _manager;

	public List<AudioSource> AudioSources;

	private int _nextIndex;

	private Dictionary<SoundManager.SoundTypeEnum, float> _lastPlay = new Dictionary<SoundManager.SoundTypeEnum, float>();

	private Camera _cam;

	private bool _isLoopPlaying;

	private float _loopLocation;

	private void Awake()
	{
		_manager = GetComponent<SoundManager>();
		_cam = Camera.main;
		Init();
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
		if (_isLoopPlaying)
		{
			AudioSource source = AudioSources[AudioSources.Count - 1];
			_manager.SetVolumeByDistance(source, _cam.orthographicSize, _loopLocation - _cam.transform.position.x);
		}
	}

	protected virtual void Init()
	{
	}

	public void PlayFromDistance(SoundManager.SoundTypeEnum clip, float distanceX)
	{
		_manager.PlayClip(GetNewSource(), clip, _cam.orthographicSize, distanceX - _cam.transform.position.x);
	}

	public void Play(SoundManager.SoundTypeEnum clip)
	{
		_manager.PlayClip(GetNewSource(), clip);
	}

	public void PlayOne(SoundManager.SoundTypeEnum clip)
	{
		if (_lastPlay.ContainsKey(clip))
		{
			if (!((double)(Time.time - _lastPlay[clip]) > 0.05))
			{
				return;
			}
			_lastPlay[clip] = Time.time;
		}
		else
		{
			_lastPlay.Add(clip, Time.time);
		}
		_manager.PlayClip(GetNewSource(), clip);
	}

	public void PlayOneFromDistance(SoundManager.SoundTypeEnum clip, float distanceX)
	{
		if (_lastPlay.ContainsKey(clip))
		{
			if (!((double)(Time.time - _lastPlay[clip]) > 0.05))
			{
				return;
			}
			_lastPlay[clip] = Time.time;
		}
		else
		{
			_lastPlay.Add(clip, Time.time);
		}
		AudioSource newSource = GetNewSource();
		_manager.PlayClip(newSource, clip);
		_manager.SetVolumeByDistance(newSource, _cam.orthographicSize, distanceX - _cam.transform.position.x);
	}

	public void PlayOneWithPitch(SoundManager.SoundTypeEnum clip)
	{
		if (_lastPlay.ContainsKey(clip))
		{
			if (!((double)(Time.time - _lastPlay[clip]) > 0.05))
			{
				return;
			}
			_lastPlay[clip] = Time.time;
		}
		else
		{
			_lastPlay.Add(clip, Time.time);
		}
		_manager.PlayClipWithPitch(GetNewSource(), clip);
	}

	public void PlayLoopFromDistance(SoundManager.SoundTypeEnum clip, float distanceX)
	{
		AudioSource source = AudioSources[AudioSources.Count - 1];
		_isLoopPlaying = true;
		_loopLocation = distanceX;
		_manager.PlayLoop(source, clip);
		_manager.SetVolumeByDistance(source, _cam.orthographicSize, _loopLocation - _cam.transform.position.x);
	}

	public void ChangeLoopDistance(float distanceX)
	{
		AudioSource source = AudioSources[AudioSources.Count - 1];
		_loopLocation = distanceX;
		_manager.SetVolumeByDistance(source, _cam.orthographicSize, _loopLocation - _cam.transform.position.x);
	}

	public void StopLoop()
	{
		AudioSource audioSource = AudioSources[AudioSources.Count - 1];
		_isLoopPlaying = false;
		audioSource.Stop();
	}

	private AudioSource GetNewSource()
	{
		AudioSource result = AudioSources[_nextIndex];
		_nextIndex++;
		if (_nextIndex >= AudioSources.Count - 1)
		{
			_nextIndex = 0;
		}
		return result;
	}
}
