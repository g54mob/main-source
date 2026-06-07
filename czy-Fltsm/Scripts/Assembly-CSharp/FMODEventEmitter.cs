using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class FMODEventEmitter : MonoBehaviour
{
	private bool _initialized;

	private bool _isQuitting;

	private Dictionary<string, FMODEvent> _events;

	private Dictionary<AudioClipProperties, FMODEvent> _audioClipPropertiesEvents;

	private void Start()
	{
		Initialize();
	}

	private void Initialize()
	{
		if (!_initialized)
		{
			RuntimeUtils.EnforceLibraryOrder();
			_events = new Dictionary<string, FMODEvent>(5);
			_audioClipPropertiesEvents = new Dictionary<AudioClipProperties, FMODEvent>(5);
		}
	}

	private void OnDestroy()
	{
		if (!_isQuitting && !_audioClipPropertiesEvents.IsNullOrEmpty())
		{
			Dictionary<AudioClipProperties, FMODEvent>.Enumerator enumerator = _audioClipPropertiesEvents.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value.Dispose();
			}
			_audioClipPropertiesEvents.Clear();
		}
	}

	private void OnApplicationQuit()
	{
		_isQuitting = true;
	}

	public bool Play(AudioClipProperties properties, GameObject source = null)
	{
		Initialize();
		if (!_audioClipPropertiesEvents.TryGetValue(properties, out var value))
		{
			value = new FMODEvent(properties);
			_audioClipPropertiesEvents.Add(properties, value);
		}
		return value.Start((source == null) ? base.gameObject : source);
	}

	public bool StopAllAndPlay(AudioClipProperties properties, GameObject source = null)
	{
		Stop();
		return Play(properties, source);
	}

	public void Pause(AudioClipProperties properties)
	{
		if (_audioClipPropertiesEvents != null && _audioClipPropertiesEvents.TryGetValue(properties, out var value))
		{
			value.Pause();
		}
	}

	public void Stop(AudioClipProperties properties)
	{
		if (_audioClipPropertiesEvents != null && _audioClipPropertiesEvents.TryGetValue(properties, out var value))
		{
			value.Stop();
		}
	}

	public bool Emit(EventReference eventReference, GameObject source = null)
	{
		if (eventReference.IsNull)
		{
			return false;
		}
		Initialize();
		string key = eventReference.ToString();
		if (!_events.TryGetValue(key, out var value))
		{
			value = new FMODEvent(eventReference);
			_events.Add(key, value);
		}
		return value.Start((source == null) ? base.gameObject : source);
	}

	public void Stop(EventReference eventReference)
	{
		if (!eventReference.IsNull && !_events.IsNullOrEmpty() && _events.TryGetValue(eventReference.ToString(), out var value))
		{
			value.Stop();
		}
	}

	public void Stop()
	{
		if (!_isQuitting && _audioClipPropertiesEvents != null)
		{
			Dictionary<AudioClipProperties, FMODEvent>.Enumerator enumerator = _audioClipPropertiesEvents.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value.Stop();
			}
		}
	}

	public bool ReturnIsPlaying(EventReference eventReference)
	{
		if (_events.TryGetValue(eventReference.ToString(), out var value))
		{
			return value.ReturnIsPlaying();
		}
		return false;
	}

	public bool ReturnIsPlaying(AudioClipProperties properties)
	{
		if (_audioClipPropertiesEvents == null)
		{
			return false;
		}
		if (_audioClipPropertiesEvents.TryGetValue(properties, out var value))
		{
			return value.ReturnIsPlaying();
		}
		return false;
	}
}
