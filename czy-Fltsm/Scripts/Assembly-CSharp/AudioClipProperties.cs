using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Audio/Audio Clip Properties")]
public class AudioClipProperties : ScriptableObject
{
	[Header("General")]
	public bool Loop;

	[Header("FMOD")]
	public EventReference FMODEventReference;

	[NonSerialized]
	private EventDescription _eventDescription;

	public bool TryFMODOneShot(Vector3 position = default(Vector3))
	{
		if (FMODEventReference.IsNull)
		{
			return false;
		}
		RuntimeManager.PlayOneShot(FMODEventReference, position);
		return true;
	}

	public bool TryReturnFMODEventDescription(out EventDescription eventDescription)
	{
		if (_eventDescription.isValid())
		{
			eventDescription = _eventDescription;
			return true;
		}
		if (FMODEventReference.IsNull)
		{
			eventDescription = default(EventDescription);
			return false;
		}
		RuntimeUtils.EnforceLibraryOrder();
		_eventDescription = (eventDescription = RuntimeManager.GetEventDescription(FMODEventReference));
		return _eventDescription.isValid();
	}
}
