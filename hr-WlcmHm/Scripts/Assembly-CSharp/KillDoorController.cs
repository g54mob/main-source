using System;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class KillDoorController : MonoBehaviour, IInteractable
{
	[SerializeField]
	private float rotationAngle = 90f;

	[SerializeField]
	private float rotationDuration = 1f;

	[SerializeField]
	private Ease rotationEase = Ease.OutBounce;

	[Space]
	[SerializeField]
	private bool doorLocked;

	[SerializeField]
	private StoryClue requiredStoryClue;

	public GameObject killBoxToEnable;

	public bool doorOpen;

	private bool interactable = true;

	private BoxCollider doorCollider;

	private PlayerController playerController;

	public EventReference eventToPlayWhenOpen;

	public EventReference eventToPlayWhenClose;

	public EventReference eventToPlayWhenLocked;

	public int magicNr;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		doorCollider = GetComponent<BoxCollider>();
		if ((bool)requiredStoryClue)
		{
			StoryClue storyClue = requiredStoryClue;
			storyClue.OnStoryCluePickup = (StoryClue.StoryCluePickup)Delegate.Combine(storyClue.OnStoryCluePickup, (StoryClue.StoryCluePickup)delegate
			{
				doorLocked = false;
			});
		}
	}

	private void Update()
	{
	}

	public void Interact()
	{
		magicNr++;
		if (magicNr > 2)
		{
			killBoxToEnable.SetActive(value: true);
		}
		if (!interactable)
		{
			return;
		}
		if (doorLocked)
		{
			playerController.LockedDoorText();
			MonoBehaviour.print("Door is locked");
			return;
		}
		base.transform.DOComplete();
		PlayInteractSound();
		Vector3 vector = new Vector3(0f, rotationAngle, 0f);
		if (doorOpen)
		{
			vector *= -1f;
		}
		doorOpen = !doorOpen;
		interactable = false;
		doorCollider.enabled = false;
		base.transform.DORotate(base.transform.eulerAngles + vector, rotationDuration).OnComplete(delegate
		{
			interactable = true;
			doorCollider.enabled = true;
		}).SetEase(rotationEase);
	}

	public void PlayInteractSound()
	{
		if (!doorOpen)
		{
			EventInstance instance = RuntimeManager.CreateInstance(eventToPlayWhenOpen);
			RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
			instance.start();
			instance.release();
		}
		if (doorOpen)
		{
			EventInstance instance2 = RuntimeManager.CreateInstance(eventToPlayWhenClose);
			RuntimeManager.AttachInstanceToGameObject(instance2, base.transform);
			instance2.start();
			instance2.release();
		}
	}

	public void PlayLockedSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(eventToPlayWhenLocked);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void Activate()
	{
	}

	public void Deactivate()
	{
	}

	public string GetName()
	{
		return "door";
	}

	public string GetActionName()
	{
		if (!doorOpen)
		{
			return "open";
		}
		return "close";
	}

	public string GetActionType()
	{
		return "Press";
	}
}
