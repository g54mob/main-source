using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class FirstDayQuest : MonoBehaviour, ITalkable, IInteractable
{
	[SerializeField]
	private string npcName;

	[SerializeField]
	private Transform pointToFace;

	[SerializeField]
	private bool facePlayerOnInteraction = true;

	[Space]
	[SerializeField]
	private List<DialogueNode> mainDialogue;

	[Space]
	[Header("Quest related variables")]
	[SerializeField]
	private Quest quest;

	[Space]
	[SerializeField]
	private List<DialogueNode> dialogueAfterQuestAssigned;

	[Header("Other")]
	[SerializeField]
	private GameObject fadeToBlack;

	[SerializeField]
	private GameObject clothes;

	private List<SceneChange> sceneChangers;

	private EActivity activity;

	private GameObject player;

	private FirstPersonController firstPersonController;

	private PlayerController playerController;

	private Animator anim;

	private NPCWalking npcWalking;

	private Collider colliderObj;

	private NPCBaseController npcBaseController;

	public bool undergroundScareConvo;

	private Quaternion defaultRotation;

	public EventReference soundToPlayOnInteract;

	private bool dialogueStarted;

	private bool hasTriggered;

	public EActivity Activity => activity;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		firstPersonController = player.GetComponent<FirstPersonController>();
		playerController = player.GetComponent<PlayerController>();
		activity = EActivity.IDLE;
		anim = GetComponent<Animator>();
		npcWalking = GetComponent<NPCWalking>();
		colliderObj = GetComponent<Collider>();
		colliderObj.enabled = false;
		npcBaseController = GetComponent<NPCBaseController>();
		if (quest != null)
		{
			sceneChangers = (from sceneChanger in Object.FindObjectsByType<SceneChange>(FindObjectsSortMode.None)
				where sceneChanger.UnlockRequirement == UnlockRequirementType.QuestCompletionRequired
				select sceneChanger).ToList();
		}
	}

	private void Update()
	{
		if (playerController.DialogueBox.activeSelf && !hasTriggered)
		{
			dialogueStarted = true;
		}
		if (dialogueStarted && !playerController.DialogueBox.activeSelf && !hasTriggered)
		{
			hasTriggered = true;
			EndDialogue();
			StartCoroutine(MetaFade());
		}
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
			player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			firstPersonController.isWalking = false;
		}
	}

	private void StartDialogue()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		firstPersonController.transform.localScale = new Vector3(firstPersonController.originalScale.x, firstPersonController.originalScale.y, firstPersonController.originalScale.z);
		if (npcWalking != null)
		{
			npcWalking.canWalk = false;
		}
		defaultRotation = base.transform.rotation;
		activity = EActivity.TALKING;
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		firstPersonController.DisableInput();
		if (facePlayerOnInteraction)
		{
			Vector3 normalized = (player.transform.position - base.transform.position).normalized;
			normalized.y = 0f;
			Quaternion endValue = Quaternion.LookRotation(normalized);
			float cameraLookAtTweenDuration = playerController.CameraLookAtTweenDuration;
			base.transform.DORotateQuaternion(endValue, cameraLookAtTweenDuration);
		}
		if (anim != null)
		{
			anim.SetBool("isTalking", value: true);
		}
		playerController.DisableInput();
		Invoke("LookAtNPC", 0.5f);
		GameObject dialogueBox = playerController.DialogueBox;
		DialogueSystem component = dialogueBox.GetComponent<DialogueSystem>();
		component.DialogueEndCallback = EndDialogue;
		component.QuestFromDialogueCallback = AssignQuest;
		component.PlayDialogue(mainDialogue);
		Animator component2 = dialogueBox.GetComponent<Animator>();
		if (component2.transform.gameObject.activeSelf)
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
		return npcName;
	}

	private void EndDialogue()
	{
		firstPersonController.playerCamera.transform.DOComplete();
		firstPersonController.transform.DOComplete();
		if (!undergroundScareConvo)
		{
			player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		}
		if (anim != null)
		{
			anim.SetBool("isTalking", value: false);
		}
		if (npcWalking != null)
		{
			npcWalking.canWalk = true;
		}
		float cameraLookAtTweenDuration = playerController.CameraLookAtTweenDuration;
		base.transform.DORotateQuaternion(defaultRotation, cameraLookAtTweenDuration);
		firstPersonController.EnableInput(resetPitch: true);
		playerController.EnableInput();
		activity = EActivity.IDLE;
	}

	private void AssignQuest()
	{
		quest.OnQuestFinished = QuestComplete;
		playerController.AssignQuest(quest);
		mainDialogue = dialogueAfterQuestAssigned;
	}

	private void QuestComplete(List<DialogueNode> newDialogue)
	{
		mainDialogue = newDialogue;
		if (quest.ShouldNotify)
		{
			playerController.ScreenNoteManagerScript.ShowNoteNotification(quest.NotificationText, quest.NotificationDuration);
		}
		playerController.ResetInteractionTarget();
		foreach (SceneChange sceneChanger in sceneChangers)
		{
			sceneChanger.OnQuestCompleted();
		}
	}

	private void LookAtNPC()
	{
		float cameraLookAtTweenDuration = playerController.CameraLookAtTweenDuration;
		firstPersonController.playerCamera.transform.DOLookAt(pointToFace.position, cameraLookAtTweenDuration);
		firstPersonController.transform.DOLookAt(pointToFace.position, cameraLookAtTweenDuration);
	}

	public string GetActionType()
	{
		return "Press";
	}

	private IEnumerator MetaFade()
	{
		Cursor.visible = false;
		firstPersonController.DisableInput();
		yield return StartCoroutine(Fade(0f, 1f, 1f));
		yield return new WaitForSeconds(1f);
		clothes.SetActive(value: false);
		anim.SetTrigger("Clothes");
		yield return StartCoroutine(Fade(1f, 0f, 1f));
		firstPersonController.EnableInput(resetPitch: true);
		npcBaseController.enabled = true;
		npcBaseController.Interact();
		base.transform.GetComponent<FirstDayQuest>().enabled = false;
		colliderObj.enabled = true;
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
