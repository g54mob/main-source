using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class InsideCultistTrigger : MonoBehaviour
{
	[SerializeField]
	private CultistInsideRun cultist;

	[SerializeField]
	private EventReference soundToPlayOnPickUp;

	private void Start()
	{
		if (cultist != null)
		{
			cultist.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (cultist != null)
			{
				cultist.gameObject.SetActive(value: true);
				cultist.canWalk = true;
			}
			PlayInteractSound();
			base.transform.gameObject.SetActive(value: false);
		}
	}

	private void PlayInteractSound()
	{
		if (!soundToPlayOnPickUp.IsNull)
		{
			EventInstance instance = RuntimeManager.CreateInstance(soundToPlayOnPickUp);
			RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
			instance.start();
			instance.release();
		}
	}
}
