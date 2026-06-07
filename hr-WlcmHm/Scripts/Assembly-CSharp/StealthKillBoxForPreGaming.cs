using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class StealthKillBoxForPreGaming : MonoBehaviour
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

	public LeaderIntroWalk leaderLookingToKill;

	public NPCBaseController leader;

	public EventReference killSounds;

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

	private void OnTriggerEnter(Collider other)
	{
		if (!firstPersonController.isHiding && other.name == "Player")
		{
			StartDialogue();
		}
	}

	private void StartDialogue()
	{
		firstPersonController.DisableInput();
		PlayInteractSound();
		leaderLookingToKill.canWalk = false;
		leaderLookingToKill.anim.SetBool("isWalking", value: false);
		leaderLookingToKill.RotateTowardsDestination(base.transform);
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

	public string GetName()
	{
		return "";
	}

	private void EndDialogue()
	{
		firstPersonController.playerCamera.transform.DOComplete();
		firstPersonController.transform.DOComplete();
		StartCoroutine(StartKillTransition());
	}

	private IEnumerator StartKillTransition()
	{
		playerController.GetComponentInChildren<PauseMenu>().StartGameOver();
		yield return new WaitForSeconds(4f);
		playKillSound();
		yield return new WaitForSeconds(2f);
	}

	private void playKillSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(killSounds);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}
}
