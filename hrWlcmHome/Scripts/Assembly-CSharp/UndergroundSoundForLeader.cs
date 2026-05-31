using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class UndergroundSoundForLeader : MonoBehaviour
{
	public EventReference soundToPlayLeader;

	public EventReference soundToPlayDoorOpen;

	public EventReference soundToPlayDoorClose;

	public EventReference soundToPlayFootstep;

	private void Start()
	{
	}

	public void PlayLeaderSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayLeader);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void PlayDoorOpenSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayDoorOpen);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void PlayDoorCloseSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayDoorClose);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void PlayFootstepSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayFootstep);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	private void Update()
	{
	}
}
