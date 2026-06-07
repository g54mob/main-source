using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class QuestDeliveryLocation : MonoBehaviour, IInteractable
{
	[SerializeField]
	private string itemName;

	[SerializeField]
	private string actionName;

	[SerializeField]
	private Light light;

	[Space]
	[SerializeField]
	private List<Transform> goalLocations;

	[SerializeField]
	protected EventReference soundToPlayOnDelivery;

	private PlayerController playerController;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		light.enabled = false;
	}

	private void Update()
	{
	}

	public void Interact()
	{
		if (!soundToPlayOnDelivery.Equals(null))
		{
			PlayInteractSound();
		}
		GameObject gameObject = playerController.StopCarryingItem();
		if (gameObject == null)
		{
			MonoBehaviour.print("No quest item found!");
			return;
		}
		Transform transform = goalLocations[playerController.GetCurrentQuest().currentAmount++];
		gameObject.transform.position = transform.position;
		gameObject.transform.rotation = transform.rotation;
	}

	public void PlayInteractSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayOnDelivery);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void Activate()
	{
		light.enabled = true;
	}

	public void Deactivate()
	{
		light.enabled = false;
	}

	public string GetActionType()
	{
		return "Press";
	}

	public string GetName()
	{
		return itemName;
	}

	public string GetActionName()
	{
		return actionName;
	}
}
