using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class CollectibleWithAnFunctionCall : MonoBehaviour, IInteractable
{
	[SerializeField]
	private string collectibleName;

	[SerializeField]
	private float moveSpeed = 3f;

	[SerializeField]
	private float rotationAmount = 360f;

	[SerializeField]
	private bool activeFromStart = true;

	private bool isCollected;

	private GameObject player;

	protected FirstPersonController firstPersonController;

	protected PlayerController playerController;

	public EventReference eventToPlay;

	protected bool shouldEnableInput = true;

	protected void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		firstPersonController = player.GetComponent<FirstPersonController>();
		playerController = player.GetComponent<PlayerController>();
		PlayerController obj = playerController;
		obj.ActivateQuestItemsCallback = (PlayerController.ActivateQuestItems)Delegate.Combine(obj.ActivateQuestItemsCallback, (PlayerController.ActivateQuestItems)delegate
		{
			activeFromStart = true;
		});
	}

	protected void Update()
	{
		if (isCollected)
		{
			firstPersonController.DisableInput();
			if ((bool)GetComponent<BoxCollider>())
			{
				UnityEngine.Object.Destroy(GetComponent<BoxCollider>());
			}
			base.transform.position = Vector3.MoveTowards(base.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
			base.transform.RotateAround(base.transform.position, Vector3.up, rotationAmount * Time.deltaTime);
		}
		if (Vector3.Distance(base.transform.position, player.transform.position) < 0.1f)
		{
			if (!playerController.inventory.Contains(collectibleName))
			{
				playerController.AddToInventory(collectibleName);
			}
			if (shouldEnableInput)
			{
				firstPersonController.EnableInput();
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public virtual void Interact()
	{
		isCollected = true;
		GetComponent<GenericScriptForDisablingObjects>().OnTriggerEnter(null);
	}

	public void PlayInteractSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(eventToPlay);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public virtual void Activate()
	{
	}

	public virtual void Deactivate()
	{
	}

	public string GetName()
	{
		return collectibleName;
	}

	public virtual string GetActionName()
	{
		return "collect";
	}

	protected void DisableInputEnabling()
	{
		shouldEnableInput = false;
	}

	public bool IsInteractable()
	{
		return activeFromStart;
	}

	public string GetActionType()
	{
		return "Press";
	}
}
