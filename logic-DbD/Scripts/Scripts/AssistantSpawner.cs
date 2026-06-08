using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AssistantSpawner : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private GameObject dialogue;

	[SerializeField]
	private AssistantController assistant;

	[SerializeField]
	private Settings settings;

	[SerializeField]
	private GameObject dialogueButton;

	[SerializeField]
	private GameObject yesNoDialogueButtons;

	[SerializeField]
	private AssistantAudioManager audioManager;

	[SerializeField]
	private Button peeker;

	[SerializeField]
	private Eye leftEye;

	[SerializeField]
	private Eye rightEye;

	private Animator animator;

	private Animator dialogueAnim;

	private bool isPeeking;

	private static bool isLooking;

	private void OnEnable()
	{
		animator = GetComponentInParent<Animator>();
		dialogueAnim = dialogue.GetComponent<Animator>();
	}

	public IEnumerator PlayDialogue(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		EnableDialogue();
	}

	private void EnableDialogue()
	{
		if (ShouldEnableDialogue())
		{
			SetPeekDialogue();
			dialogue.SetActive(value: true);
			dialogueAnim.Play("Open");
		}
	}

	private bool ShouldEnableDialogue()
	{
		if (LevelManager.IsCredits() || Save.GetHasBeenWrong())
		{
			return true;
		}
		if (!settings.IsAssistantDisabled() && !assistant.IsDancing())
		{
			return isPeeking;
		}
		return false;
	}

	public void DisableDialogue()
	{
		dialogue.SetActive(value: false);
	}

	public void DisableDialogueButton()
	{
		audioManager.PlayClick();
		DisableDialogue();
	}

	public void OnPointerEnter(PointerEventData data)
	{
		isLooking = true;
		StartCoroutine(StartLooking());
	}

	public void OnPointerExit(PointerEventData data)
	{
		isLooking = false;
	}

	public float Cower(bool playAudio = false)
	{
		if (animator == null)
		{
			animator = GetComponentInParent<Animator>();
		}
		animator.Play("Cower");
		if (playAudio)
		{
			audioManager.PlayHmm();
		}
		dialogue.SetActive(value: false);
		isLooking = false;
		isPeeking = false;
		SetInteractable(interactable: false);
		return 1.2f;
	}

	public bool IsPeeking()
	{
		return isPeeking;
	}

	public static bool IsLooking()
	{
		return isLooking;
	}

	public void Spawn()
	{
		float waitTime = Cower(playAudio: true);
		StartCoroutine(assistant.Spawn(waitTime));
	}

	public IEnumerator StartLooking()
	{
		while (isLooking)
		{
			leftEye.CalculateVectorFromMouse(Mouse.current.position.ReadValue());
			rightEye.CalculateVectorFromMouse(Mouse.current.position.ReadValue());
			yield return Eye.EYE_WAIT_TIME;
		}
		leftEye.ResetPosition();
		rightEye.ResetPosition();
	}

	public IEnumerator PeekRoutine(float additionalWaitTime = 0f)
	{
		float num = 2f;
		isPeeking = true;
		SetInteractable(interactable: true);
		yield return new WaitForSeconds(num + additionalWaitTime);
		if (!assistant.IsDancing())
		{
			Peek();
		}
	}

	private void SetInteractable(bool interactable)
	{
		peeker.enabled = interactable;
	}

	private void SetPeekDialogue()
	{
		TextMeshProUGUI componentInChildren = dialogue.GetComponentInChildren<TextMeshProUGUI>();
		if (LevelManager.IsCredits())
		{
			componentInChildren.text = "Thanks for playing!";
			RectTransform component = dialogue.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(component.sizeDelta.x, 105f);
			SetInteractable(interactable: false);
			dialogueButton.SetActive(value: false);
			peeker.GetComponent<CursorChangerAsk>().enabled = false;
		}
	}

	public void Peek()
	{
		if (!settings.IsAssistantDisabled())
		{
			isPeeking = true;
			float waitTime = 2f;
			base.gameObject.SetActive(value: true);
			animator.Play("Peek");
			if (!Save.HasSeenTutorial() || LevelManager.IsCredits())
			{
				StartCoroutine(PlayDialogue(waitTime));
				Save.SetTutorialSeen();
				audioManager.PlayHey(1.95f);
			}
			else
			{
				audioManager.PlayHey(1.45f);
			}
		}
	}
}
