using System.Collections.Generic;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class LookScript : MonoBehaviour, ITalkable, IInteractable
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
		firstPersonController.isWalking = false;
		float cameraLookAtTweenDuration = playerController.CameraLookAtTweenDuration;
		firstPersonController.transform.localScale = new Vector3(firstPersonController.originalScale.x, firstPersonController.originalScale.y, firstPersonController.originalScale.z);
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
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

	private void EndDialogue()
	{
		firstPersonController.playerCamera.transform.DOComplete();
		firstPersonController.transform.DOComplete();
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		firstPersonController.EnableInput(resetPitch: true);
		playerController.EnableInput();
	}

	public string GetActionType()
	{
		return "Press";
	}
}
