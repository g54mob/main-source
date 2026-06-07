using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class SingleUseSoundTrigger : MonoBehaviour
{
	public EventReference soundToPlay;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider c)
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlay);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
		Object.Destroy(this);
	}

	private void Update()
	{
	}
}
