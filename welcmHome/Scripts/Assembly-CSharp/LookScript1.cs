using System.Collections.Generic;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class LookScript1 : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Transform pointToFace;

	[Space]
	[SerializeField]
	private List<DialogueNode> mainDialogue;

	private GameObject player;

	private FirstPersonController firstPersonController;

	private PlayerController playerController;

	public EventReference soundToPlayOnInteract;

	public GameObject activateStealthSection;

	public IInteractable interactable;

	public DoorController doorToClose;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		firstPersonController = player.GetComponent<FirstPersonController>();
		playerController = player.GetComponent<PlayerController>();
	}

	private void Update()
	{
	}

	public void PlayInteractSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayOnInteract);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void Interact()
	{
		if (mainDialogue.Count > 0)
		{
			PlayInteractSound();
			StartDialogue();
		}
	}

	private void StartDialogue()
	{
		firstPersonController.DisableInput();
		float cameraLookAtTweenDuration = playerController.CameraLookAtTweenDuration;
		firstPersonController.isWalking = false;
		firstPersonController.playerCamera.transform.DOLookAt(pointToFace.position, cameraLookAtTweenDuration);
		firstPersonController.transform.DOLookAt(pointToFace.position, cameraLookAtTweenDuration);
		playerController.DisableInput();
		GameObject dialogueBox = playerController.DialogueBox;
		DialogueSystem component = dialogueBox.GetComponent<DialogueSystem>();
		component.DialogueEndCallback = EndDialogue;
		component.PlayDialogue(mainDialogue);
		Animator component2 = dialogueBox.GetComponent<Animator>();
		if (component2.gameObject.activeSelf)
		{
			component2.SetBool("DialogueBars", value: true);
		}
	}

	public void Activate()
	{
	}

	public void Deactivate()
	{
	}

	public string GetName()
	{
		return "";
	}

	public string GetActionName()
	{
		return "sleep";
	}

	private void EndDialogue()
	{
		firstPersonController.playerCamera.transform.DOComplete();
		firstPersonController.transform.DOComplete();
		firstPersonController.EnableInput(resetPitch: true);
		playerController.EnableInput();
		activateStealthSection.gameObject.SetActive(value: true);
		if (doorToClose.doorOpen)
		{
			doorToClose.Interact();
		}
		Object.Destroy(this);
	}

	public string GetActionType()
	{
		return "Press";
	}
}
