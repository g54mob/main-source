using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public abstract class QuestItemBase : MonoBehaviour, IInteractable
{
	[SerializeField]
	protected string itemName;

	[SerializeField]
	protected string actionName;

	[SerializeField]
	protected EventReference soundToPlayOnPickUp;

	protected bool isActive;

	protected PlayerController playerController;

	protected void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		PlayerController obj = playerController;
		obj.ActivateQuestItemsCallback = (PlayerController.ActivateQuestItems)Delegate.Combine(obj.ActivateQuestItemsCallback, (PlayerController.ActivateQuestItems)delegate
		{
			isActive = true;
		});
	}

	public abstract void Interact();

	public void PlayInteractSound()
	{
		if (!soundToPlayOnPickUp.Equals(null))
		{
			EventInstance instance = RuntimeManager.CreateInstance(soundToPlayOnPickUp);
			RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
			instance.start();
			instance.release();
		}
	}

	public abstract void Activate();

	public abstract void Deactivate();

	public virtual string GetName()
	{
		return itemName;
	}

	public virtual string GetActionName()
	{
		return actionName;
	}

	public virtual string GetActionType()
	{
		return "Press";
	}

	public virtual bool IsInteractable()
	{
		return isActive;
	}

	public void DeactivateItem()
	{
		isActive = false;
	}
}
