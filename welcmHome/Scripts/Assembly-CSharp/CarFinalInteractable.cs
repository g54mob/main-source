using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class CarFinalInteractable : MonoBehaviour, IInteractable
{
	[SerializeField]
	private NoiseManager noiseManager;

	[SerializeField]
	protected string itemName;

	[SerializeField]
	protected string actionName;

	[SerializeField]
	protected EventReference soundToPlayOnInteract;

	private void Start()
	{
	}

	public string GetActionType()
	{
		return "";
	}

	public void Activate()
	{
	}

	public void Deactivate()
	{
	}

	public virtual string GetName()
	{
		return itemName;
	}

	public virtual string GetActionName()
	{
		return actionName;
	}

	public void Interact()
	{
		noiseManager.TriggerNPCs();
		noiseManager.IncreaseGlobalNoise();
		noiseManager.IncreaseGlobalNoise();
		PlayInteractSound();
		Debug.Log("NPCs alerted by car");
	}

	public void PlayInteractSound()
	{
		if (!soundToPlayOnInteract.Equals(null))
		{
			EventInstance instance = RuntimeManager.CreateInstance(soundToPlayOnInteract);
			RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
			instance.start();
			instance.release();
		}
	}
}
