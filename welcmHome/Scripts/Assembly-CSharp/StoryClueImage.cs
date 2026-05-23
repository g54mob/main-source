using System.Collections;
using FMOD.Studio;
using FMODUnity;
using Febucci.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryClueImage : MonoBehaviour, IInteractable
{
	[SerializeField]
	private bool isLongTextClue;

	[SerializeField]
	private string storyclueName;

	[SerializeField]
	private Sprite clueImage;

	[SerializeField]
	[TextArea]
	private string monologueText;

	public EventReference eventToPlay;

	private GameObject storyclueUI;

	private TMP_Text titleText;

	private Image displayImage;

	private TMP_Text monologueTextArea;

	private Image displayImage2;

	private TMP_Text monologueTextArea2;

	private bool isInteracting;

	private bool inputLocked;

	private PlayerController playerController;

	private FirstPersonController firstPersonController;

	private TypewriterCore typewriterCore;

	private void Start()
	{
		storyclueUI = GameObject.FindGameObjectWithTag("StoryClueUI");
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
		if (!(storyclueUI != null))
		{
			return;
		}
		titleText = storyclueUI.transform.Find("TitleText").GetComponent<TMP_Text>();
		displayImage = storyclueUI.transform.Find("ClueImage").GetComponent<Image>();
		monologueTextArea = storyclueUI.transform.Find("MonologueText").GetComponent<TMP_Text>();
		displayImage2 = storyclueUI.transform.Find("ClueImage_TEXT").GetComponent<Image>();
		monologueTextArea2 = storyclueUI.transform.Find("MonologueText_TEXT").GetComponent<TMP_Text>();
		foreach (Transform item in storyclueUI.transform)
		{
			item.gameObject.SetActive(value: false);
		}
		typewriterCore = monologueTextArea2.transform.GetComponent<TypewriterCore>();
	}

	private void Update()
	{
		if (!(storyclueUI != null))
		{
			return;
		}
		if (!inputLocked && isInteracting && storyclueUI.activeSelf && Input.GetKeyDown(KeyCode.E))
		{
			foreach (Transform item in storyclueUI.transform)
			{
				item.gameObject.SetActive(value: false);
			}
			isInteracting = false;
			playerController.EnableInput();
			firstPersonController.EnableInput();
		}
		if (storyclueUI.activeSelf && isLongTextClue && Input.GetKeyDown(KeyCode.Space))
		{
			typewriterCore.SkipTypewriter();
		}
	}

	public void Activate()
	{
	}

	public void Deactivate()
	{
	}

	public string GetActionName()
	{
		return "Pick Up";
	}

	public string GetName()
	{
		return storyclueName;
	}

	public void Interact()
	{
		firstPersonController.isWalking = false;
		if (!(storyclueUI != null) || isInteracting)
		{
			return;
		}
		UpdateUI();
		PlayInteractSound();
		int childCount = storyclueUI.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = storyclueUI.transform.GetChild(i);
			if (isLongTextClue && i >= 4)
			{
				child.gameObject.SetActive(value: true);
			}
			else if (!isLongTextClue && i < 5)
			{
				child.gameObject.SetActive(value: true);
			}
			else
			{
				child.gameObject.SetActive(value: false);
			}
		}
		isInteracting = true;
		playerController.DisableInput();
		firstPersonController.DisableInput();
		StartCoroutine(LockInputForDuration(0.2f));
	}

	public void PlayInteractSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(eventToPlay);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	private void UpdateUI()
	{
		if (titleText != null)
		{
			titleText.text = storyclueName;
		}
		if (displayImage != null)
		{
			displayImage.sprite = clueImage;
		}
		if (monologueTextArea != null)
		{
			monologueTextArea.text = monologueText;
		}
		if (displayImage2 != null)
		{
			displayImage2.sprite = clueImage;
		}
		if (monologueTextArea2 != null)
		{
			monologueTextArea2.text = monologueText;
		}
	}

	private IEnumerator LockInputForDuration(float duration)
	{
		inputLocked = true;
		yield return new WaitForSeconds(duration);
		inputLocked = false;
	}

	public string GetActionType()
	{
		return "Press";
	}
}
