using FMODUnity;
using UnityEngine;

public class FMODUIEventEmitter : FMODEventEmitter
{
	private static FMODUIEventEmitter _instance;

	public static bool PlayAudioClipProperties(AudioClipProperties audioClipProperties)
	{
		FMODUIEventEmitter instance = GetInstance();
		if (audioClipProperties == null || (audioClipProperties.Loop && instance.ReturnIsPlaying(audioClipProperties)))
		{
			return false;
		}
		return instance.Play(audioClipProperties);
	}

	public static void PauseAudioClipProperties(AudioClipProperties audioClipProperties)
	{
		if ((bool)audioClipProperties && audioClipProperties.Loop)
		{
			GetInstance().Pause(audioClipProperties);
		}
	}

	public static void StopAudioClipProperties(AudioClipProperties audioClipProperties)
	{
		if ((bool)audioClipProperties && audioClipProperties.Loop)
		{
			GetInstance().Stop(audioClipProperties);
		}
	}

	public static bool PlayEventReferenceUnique(EventReference eventReference)
	{
		FMODUIEventEmitter instance = GetInstance();
		if (instance.ReturnIsPlaying(eventReference))
		{
			return false;
		}
		return instance.Emit(eventReference);
	}

	public static void StopEventReference(EventReference eventReference)
	{
		GetInstance().Stop(eventReference);
	}

	private static FMODUIEventEmitter GetInstance()
	{
		if (_instance == null)
		{
			_instance = new GameObject().AddComponent<FMODUIEventEmitter>();
		}
		return _instance;
	}
}
