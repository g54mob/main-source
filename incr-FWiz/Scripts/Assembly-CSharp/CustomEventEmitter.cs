using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class CustomEventEmitter : MonoBehaviour
{
	[SerializeField]
	private EventReference eventReference;

	[SerializeField]
	public bool startAtRandomPoint;

	private EventInstance instance;

	public EventInstance EventInstance => default(EventInstance);

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void SetVolume(float volume)
	{
	}

	public float GetVolume()
	{
		return 0f;
	}

	public bool IsPlaying()
	{
		return false;
	}
}
