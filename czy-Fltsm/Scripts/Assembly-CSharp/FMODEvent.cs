using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FMODEvent
{
	private GameObject _source;

	private EventDescription _eventDescription;

	private EventInstance _instance;

	private bool _isOneShot;

	public EventReference EventReference { get; private set; }

	public AudioClipProperties Properties { get; private set; }

	public FMODEvent(EventReference eventReference)
	{
		EventReference = eventReference;
	}

	public FMODEvent(AudioClipProperties properties)
	{
		Properties = properties;
	}

	public void Dispose()
	{
		if (_instance.isValid())
		{
			RuntimeManager.DetachInstanceFromGameObject(_instance);
			if (_eventDescription.isValid() && _isOneShot)
			{
				_instance.release();
				_instance.clearHandle();
			}
		}
	}

	public bool Start(GameObject source = null)
	{
		if (!_eventDescription.isValid() && !TryReturnEventDescription(out _eventDescription))
		{
			return false;
		}
		bool is3D = false;
		_eventDescription.isSnapshot(out var snapshot);
		if (!snapshot)
		{
			_eventDescription.isOneshot(out _isOneShot);
		}
		if (source != null)
		{
			_eventDescription.is3D(out is3D);
		}
		if (_instance.isValid())
		{
			if (_isOneShot)
			{
				_instance.release();
				_instance.clearHandle();
			}
		}
		else
		{
			_instance.clearHandle();
		}
		if (!_instance.isValid())
		{
			_eventDescription.createInstance(out _instance);
			if (is3D)
			{
				Rigidbody component = source.GetComponent<Rigidbody>();
				Transform transform = source.transform;
				_source = source;
				_instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform, component));
				RuntimeManager.AttachInstanceToGameObject(_instance, transform, component);
			}
		}
		_instance.start();
		return true;
	}

	public void Pause()
	{
		if (ReturnIsPlaying())
		{
			Pause(paused: true);
		}
	}

	public void Unpause(bool start = false)
	{
		if (ReturnIsPlaying())
		{
			Pause(paused: false);
		}
		else if (start)
		{
			Start();
		}
	}

	private void Pause(bool paused)
	{
		if (_instance.isValid())
		{
			_instance.getPaused(out var paused2);
			if (paused2 != paused)
			{
				_instance.setPaused(paused);
			}
		}
	}

	public void Stop()
	{
		if (_instance.isValid())
		{
			_instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			_instance.release();
			_instance.clearHandle();
		}
	}

	public bool ReturnIsPlaying()
	{
		if (_instance.isValid())
		{
			_instance.getPlaybackState(out var state);
			return state != PLAYBACK_STATE.STOPPED;
		}
		return false;
	}

	private bool TryReturnEventDescription(out EventDescription eventDescription)
	{
		if (!EventReference.IsNull)
		{
			RuntimeUtils.EnforceLibraryOrder();
			eventDescription = RuntimeManager.GetEventDescription(EventReference);
			return eventDescription.isValid();
		}
		if (Properties != null)
		{
			return Properties.TryReturnFMODEventDescription(out eventDescription);
		}
		eventDescription = default(EventDescription);
		return false;
	}
}
