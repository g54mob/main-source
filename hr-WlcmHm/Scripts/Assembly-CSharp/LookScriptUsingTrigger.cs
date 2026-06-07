using System.Collections.Generic;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class LookScriptUsingTrigger : MonoBehaviour
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

	public EventInstance soundOnInteract;

	public GameObject jumpScareCollection;

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
		soundOnInteract = RuntimeManager.CreateInstance(soundToPlayOnInteract);
		RuntimeManager.AttachInstanceToGameObject(soundOnInteract, base.transform);
		soundOnInteract.start();
		soundOnInteract.release();
	}

	public void Interact()
	{
		if (mainDialogue.Count > 0)
		{
			PlayInteractSound();
			StartDialogue();
		}
	}

	private void OnTriggerEnter(Collider c)
	{
		StartDialogue();
	}

	private void StartDialogue()
	{
		firstPersonController.DisableInput();
		PlayInteractSound();
		float cameraLookAtTweenDuration = playerController.CameraLookAtTweenDuration;
		firstPersonController.playerCamera.transform.DOLookAt(pointToFace.position, cameraLookAtTweenDuration);
		firstPersonController.isWalking = false;
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

	private void OnDestroy()
	{
		soundOnInteract.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	public string GetName()
	{
		return "";
	}

	private void EndDialogue()
	{
		firstPersonController.playerCamera.transform.DOComplete();
		firstPersonController.transform.DOComplete();
		firstPersonController.EnableInput(resetPitch: true);
		playerController.EnableInput();
		jumpScareCollection.SetActive(value: true);
		base.gameObject.SetActive(value: false);
	}
}
