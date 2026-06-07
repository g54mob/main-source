using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class LookScriptInsideDay1 : MonoBehaviour, ITalkable, IInteractable
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

	public EventReference soundToPlayOnClothes;

	public GameObject clothes;

	public GameObject triggerToEnable;

	public GameObject wallOfNonInteraction;

	public GameObject fadeToBlack;

	public Animator aiAnimator;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		firstPersonController = player.GetComponent<FirstPersonController>();
		playerController = player.GetComponent<PlayerController>();
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		Interact();
		firstPersonController.isWalking = false;
	}

	public void PlayInteractSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayOnInteract);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void PlayClothesSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayOnClothes);
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
		StartCoroutine(MetaFade());
	}

	public string GetActionType()
	{
		return "Press";
	}

	private IEnumerator MetaFade()
	{
		firstPersonController.DisableInput();
		yield return StartCoroutine(Fade(0f, 1f, 1f));
		PlayClothesSound();
		yield return new WaitForSeconds(3f);
		clothes.SetActive(value: false);
		aiAnimator.Play("Woman2_Idle");
		yield return StartCoroutine(Fade(1f, 0f, 1f));
		firstPersonController.EnableInput(resetPitch: true);
		triggerToEnable.SetActive(value: true);
		Object.Destroy(base.gameObject);
		Object.Destroy(wallOfNonInteraction);
	}

	private IEnumerator Fade(float startAlpha, float targetAlpha, float duration)
	{
		Image image = fadeToBlack.GetComponent<Image>();
		Color color = image.color;
		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			elapsedTime += Time.deltaTime;
			color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
			image.color = color;
			yield return null;
		}
		color.a = targetAlpha;
		image.color = color;
	}
}
