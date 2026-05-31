using System.Collections.Generic;
using Febucci.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	public delegate void DialogueEnd();

	public delegate void QuestFromDialogue();

	public DialogueEnd DialogueEndCallback;

	public QuestFromDialogue QuestFromDialogueCallback;

	[SerializeField]
	private GameObject mainTextGameObject;

	[SerializeField]
	private GameObject buttonChoice1;

	[SerializeField]
	private GameObject buttonChoice2;

	[SerializeField]
	private GameObject buttonContinue;

	private TMP_Text mainText;

	private TMP_Text button1Text;

	private TMP_Text button2Text;

	private List<DialogueNode> dialogueNodes;

	private int currentDialogueNodeIdx = -1;

	private TypewriterCore typewriter;

	private InputAction navigateAction;

	[SerializeField]
	private ScreenNoteManager screenNoteManager;

	private void Awake()
	{
		mainText = mainTextGameObject.GetComponent<TMP_Text>();
		button1Text = buttonChoice1.GetComponentInChildren<TMP_Text>();
		button2Text = buttonChoice2.GetComponentInChildren<TMP_Text>();
		typewriter = GetComponentInChildren<TypewriterCore>();
		navigateAction = GetComponent<PlayerInput>().actions["navigate"];
	}

	private void Start()
	{
	}

	private void Update()
	{
		CheckForInput();
		if (Input.GetKeyDown(KeyCode.Space) && mainTextGameObject.activeSelf)
		{
			typewriter.SkipTypewriter();
		}
	}

	private void CheckForInput()
	{
		if (navigateAction.WasPressedThisFrame() && EventSystem.current.currentSelectedGameObject == null)
		{
			EventSystem.current.SetSelectedGameObject(buttonContinue.activeSelf ? buttonContinue : buttonChoice1);
		}
		if (Input.GetKeyDown(KeyCode.E) && EventSystem.current.currentSelectedGameObject != null)
		{
			EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
		}
	}

	public void NextText()
	{
		if (dialogueNodes[currentDialogueNodeIdx].givesQuest)
		{
			QuestFromDialogueCallback();
		}
		LoadDialogueNode(currentDialogueNodeIdx + 1);
	}

	public void PlayDialogue(List<DialogueNode> dialogueFromNpc)
	{
		dialogueNodes = dialogueFromNpc;
		screenNoteManager.DisableNote();
		Invoke("DelayedStart", 0.1f);
	}

	private void DelayedStart()
	{
		base.gameObject.SetActive(value: true);
		LoadDialogueNode(0);
	}

	private void LoadDialogueNode(int idx)
	{
		if (idx >= dialogueNodes.Count)
		{
			MonoBehaviour.print("Closing dialogue");
			mainText.text = string.Empty;
			EventSystem.current.SetSelectedGameObject(null);
			base.gameObject.SetActive(value: false);
			DialogueEndCallback();
		}
		else
		{
			DialogueNode dialogueNode = dialogueNodes[idx];
			mainText.text = dialogueNode.mainText;
			buttonChoice1.SetActive(dialogueNode.isQuestion);
			button1Text.text = dialogueNode.option1Text;
			buttonChoice2.SetActive(dialogueNode.isQuestion);
			button2Text.text = dialogueNode.option2Text;
			buttonContinue.SetActive(!dialogueNode.isQuestion);
			Invoke(dialogueNode.isQuestion ? "SelectChoice1Button" : "SelectContinueButton", 0.01f);
			currentDialogueNodeIdx = idx;
		}
	}

	public void ChooseDialogueOption(int option)
	{
		if (option == 1)
		{
			mainText.text = dialogueNodes[currentDialogueNodeIdx].option1FollowUp;
		}
		else
		{
			mainText.text = dialogueNodes[currentDialogueNodeIdx].option2FollowUp;
		}
		buttonChoice1.SetActive(value: false);
		buttonChoice2.SetActive(value: false);
		buttonContinue.SetActive(value: true);
		Invoke("SelectContinueButton", 0.01f);
	}

	private void SelectContinueButton()
	{
		EventSystem.current.SetSelectedGameObject(buttonContinue);
	}

	private void SelectChoice1Button()
	{
		EventSystem.current.SetSelectedGameObject(buttonChoice1);
	}
}
