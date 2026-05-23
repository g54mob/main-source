using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class StealthKillBox : MonoBehaviour
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

	public NightTimeLeaderWalk leaderLookingToKill;

	public NPCBaseController leader;

	public EventReference killSounds;

	public StoryClueImage objectToDestroy;

	public StoryClueImage objectToDestroy2;

	public StoryClueImage objectToDestroy3;

	private GameObject storyClueUI;

	private void Start()
	{
		storyClueUI = GameObject.FindGameObjectWithTag("StoryClueUI");
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

	private void OnTriggerEnter(Collider other)
	{
		if (firstPersonController.isHiding || !(other.name == "Player"))
		{
			return;
		}
		foreach (Transform item in storyClueUI.transform)
		{
			Object.Destroy(item.gameObject);
		}
		StartDialogue();
	}

	private void StartDialogue()
	{
		Object.Destroy(objectToDestroy);
		Object.Destroy(objectToDestroy2);
		Object.Destroy(objectToDestroy3);
		leaderLookingToKill.GetComponentInChildren<BoxCollider>().enabled = false;
		leaderLookingToKill.AI.Activity = EActivity.TALKING;
		leaderLookingToKill.enabled = false;
		firstPersonController.DisableInput();
		PlayInteractSound();
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		leaderLookingToKill.canWalk = false;
		leaderLookingToKill.anim.SetBool("isWalking", value: false);
		leaderLookingToKill.RotateTowardsDestination(base.transform);
		float cameraLookAtTweenDuration = playerController.CameraLookAtTweenDuration;
		firstPersonController.playerCamera.transform.DOLookAt(pointToFace.position, cameraLookAtTweenDuration);
		firstPersonController.isWalking = false;
		firstPersonController.transform.DOLookAt(pointToFace.position, cameraLookAtTweenDuration);
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
