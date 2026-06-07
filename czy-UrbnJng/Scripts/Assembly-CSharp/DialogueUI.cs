using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
	[SerializeField]
	private Image characterImageLeft;

	[SerializeField]
	private Transform characterNameLeftTransform;

	private TextMeshProUGUI characterNameLeft;

	[SerializeField]
	private Image characterImageRight;

	[SerializeField]
	private Transform characterNameRightTransform;

	private TextMeshProUGUI characterNameRight;

	[SerializeField]
	private TextMeshProUGUI dialogueText;

	[SerializeField]
	private Button answer_1;

	[SerializeField]
	private Button answer_2;

	[SerializeField]
	private Transform skipTextTransform;

	private TextMeshProUGUI answer_1_text;

	private TextMeshProUGUI answer_2_text;

	private bool skipEnabled;

	private bool isSkipped;

	private int visibleCounter;

	private float speed = 20f;

	[SerializeField]
	private Transform darkBG;

	[SerializeField]
	private Transform textBubbleLeft;

	[SerializeField]
	private Transform textBubbleRight;

	[SerializeField]
	private Transform scalePivotTransform;

	private CanvasGroup darkBGCanvasGroup;

	private Transform currentCharacterTransform;

	private Transform characterTransformLeft;

	private Transform characterTransformRight;

	private Sequence showAnimation;

	private Sequence answerShowAnimation;

	private PlayerInputActions playerInputActions;

	private int currentSelectedAnswerIndex;

	private Button[] answerButtons;

	public static DialogueUI Instance { get; private set; }

	public event EventHandler OnNextDialogue;

	private void Awake()
	{
		Instance = this;
		answer_1_text = answer_1.GetComponentInChildren<TextMeshProUGUI>();
		answer_2_text = answer_2.GetComponentInChildren<TextMeshProUGUI>();
		characterNameLeft = characterNameLeftTransform.GetComponentInChildren<TextMeshProUGUI>();
		characterNameRight = characterNameRightTransform.GetComponentInChildren<TextMeshProUGUI>();
		characterTransformLeft = characterImageLeft.transform;
		characterTransformRight = characterImageRight.transform;
		currentCharacterTransform = characterTransformLeft;
		darkBGCanvasGroup = darkBG.GetComponent<CanvasGroup>();
		playerInputActions = new PlayerInputActions();
		playerInputActions.Dialogs.Enable();
		answerButtons = new Button[2] { answer_1, answer_2 };
	}

	private void OnEnable()
	{
		playerInputActions.Dialogs.Enable();
	}

	private void OnDisable()
	{
		playerInputActions.Dialogs.Disable();
	}

	private void Start()
	{
		answer_1.onClick.AddListener(delegate
		{
			NextDialogue();
		});
		answer_2.onClick.AddListener(delegate
		{
			NextDialogue();
		});
		DialogueManager.Instance.OnDialogueStart += DialogueManager_OnDialogueStart;
		DialogueManager.Instance.OnDialogueFinish += DialogueManager_OnDialogueFinish;
		InputManager.Instance.OnInteract += InputManager_OnInteract;
		InputManager.Instance.OnSpace += InputManager_OnSpace;
		playerInputActions.Dialogs.AnswerDown.performed += AnswerDownAction;
		playerInputActions.Dialogs.AnswerUp.performed += AnswerUpAction;
		playerInputActions.Dialogs.ConfirmChoice.performed += ConfirmChoiceAction;
		Clear();
		Hide();
	}

	private void ConfirmChoiceAction(InputAction.CallbackContext obj)
	{
		answerButtons[currentSelectedAnswerIndex].onClick.Invoke();
	}

	private void AnswerUpAction(InputAction.CallbackContext obj)
	{
		currentSelectedAnswerIndex = (currentSelectedAnswerIndex - 1 + answerButtons.Length) % answerButtons.Length;
		UpdateSelectedAnswerVisual();
	}

	private void AnswerDownAction(InputAction.CallbackContext obj)
	{
		currentSelectedAnswerIndex = (currentSelectedAnswerIndex + 1) % answerButtons.Length;
		UpdateSelectedAnswerVisual();
	}

	private void InputManager_OnSpace(object sender, EventArgs e)
	{
		if (DialogueManager.Instance.IsActive())
		{
			TryToAdvanceDialogue();
		}
	}

	private void InputManager_OnInteract(object sender, EventArgs e)
	{
		if (DialogueManager.Instance.IsActive())
		{
			TryToAdvanceDialogue();
		}
	}

	private void DialogueManager_OnDialogueStart(object sender, EventArgs e)
	{
		Show();
	}

	private void DialogueManager_OnDialogueFinish(object sender, EventArgs e)
	{
		FinishDialogue();
	}

	private void TryToAdvanceDialogue()
	{
		if (isSkipped)
		{
			if (skipEnabled)
			{
				DialogueManager.Instance.NextDialogue();
			}
		}
		else
		{
			StopAllCoroutines();
			dialogueText.maxVisibleCharacters = 1000;
			isSkipped = true;
		}
	}

	private void SetCharacter(CharacterSO characterSO, string characterName, Sprite characterSprite, bool onRight)
	{
		if (!onRight)
		{
			ShowElement(characterImageLeft.transform);
			ShowElement(characterNameLeftTransform);
			ShowElement(textBubbleLeft);
			HideElement(characterImageRight.transform);
			HideElement(characterNameRightTransform);
			HideElement(textBubbleRight);
			characterImageLeft.sprite = characterSprite;
			characterNameLeft.text = characterName;
			currentCharacterTransform = characterTransformLeft;
		}
		else
		{
			HideElement(characterImageLeft.transform);
			HideElement(characterNameLeftTransform);
			HideElement(textBubbleLeft);
			ShowElement(characterImageRight.transform);
			ShowElement(characterNameRightTransform);
			ShowElement(textBubbleRight);
			characterImageRight.sprite = characterSprite;
			characterNameRight.text = characterName;
			currentCharacterTransform = characterTransformRight;
		}
	}

	public void SetDialogue(CharacterSO characterSO, string characterName, Sprite characterSprite, bool onRight, string text, string answer_1_string, string answer_2_string)
	{
		SetCharacter(characterSO, characterName, characterSprite, onRight);
		skipEnabled = false;
		isSkipped = false;
		SetText(text);
		SetAnswers(answer_1_string, answer_2_string);
	}

	private void SetAnswers(string answer_1_string, string answer_2_string)
	{
		skipEnabled = true;
		if (answer_1_string != "")
		{
			ShowElement(answer_1.transform);
			answer_1_text.text = answer_1_string;
			skipEnabled = false;
		}
		if (answer_2_string != "")
		{
			ShowElement(answer_2.transform);
			answer_2_text.text = answer_2_string;
			skipEnabled = false;
		}
		AnswerShowAnimation();
		currentSelectedAnswerIndex = 0;
		UpdateSelectedAnswerVisual();
		if (skipEnabled)
		{
			ShowElement(skipTextTransform);
		}
		else
		{
			HideElement(skipTextTransform);
		}
	}

	private void UpdateSelectedAnswerVisual()
	{
		if (currentSelectedAnswerIndex == 0)
		{
			answer_1.GetComponent<ScaleWhenHover>().ActivateButton();
			answer_2.GetComponent<ScaleWhenHover>().DeactivateButton();
		}
		else
		{
			answer_1.GetComponent<ScaleWhenHover>().DeactivateButton();
			answer_2.GetComponent<ScaleWhenHover>().ActivateButton();
		}
	}

	private void SetText(string text)
	{
		dialogueText.text = text;
		StartCoroutine(Read(text));
	}

	private IEnumerator Read(string text)
	{
		visibleCounter = 0;
		string[] subTexts = text.Split(" ");
		int currentSubTextIndex = 0;
		int charactersBeforeSpace = 0;
		bool playSound = false;
		while (visibleCounter < text.Length)
		{
			visibleCounter++;
			dialogueText.maxVisibleCharacters = visibleCounter;
			if (currentSubTextIndex < subTexts.Length)
			{
				if (charactersBeforeSpace < subTexts[currentSubTextIndex].Length)
				{
					if (!playSound)
					{
						playSound = true;
					}
					else
					{
						SoundManager.Instance.OnTyping();
					}
					charactersBeforeSpace++;
				}
				else
				{
					currentSubTextIndex++;
					charactersBeforeSpace = 0;
				}
			}
			yield return new WaitForSeconds(1f / speed);
		}
		isSkipped = true;
	}

	private void NextDialogue()
	{
		Clear();
		this.OnNextDialogue?.Invoke(this, EventArgs.Empty);
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		ShowAnimation();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void ShowElement(Transform transform)
	{
		transform.gameObject.SetActive(value: true);
	}

	private void HideElement(Transform transform)
	{
		transform.gameObject.SetActive(value: false);
	}

	private void Clear()
	{
		HideElement(answer_1.transform);
		HideElement(answer_2.transform);
	}

	public void FinishDialogue()
	{
		InputManager.Instance.gamePause = false;
		Hide();
		Clear();
	}

	private void ShowAnimation()
	{
		showAnimation = DOTween.Sequence();
		scalePivotTransform.localScale = new Vector3(0f, 0f, 0f);
		darkBGCanvasGroup.alpha = 0f;
		showAnimation.Append(darkBGCanvasGroup.DOFade(1f, 0.05f)).Append(scalePivotTransform.DOScale(1.05f, 0.1f).SetEase(Ease.InOutSine)).Append(scalePivotTransform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
			.Play();
	}

	private void AnswerShowAnimation()
	{
		answerShowAnimation = DOTween.Sequence();
		answer_1.transform.localScale = new Vector3(0f, 0f, 0f);
		answer_2.transform.localScale = new Vector3(0f, 0f, 0f);
		answerShowAnimation.Append(answer_1.transform.DOScale(1.05f, 0.1f).SetEase(Ease.InOutSine)).Append(answer_1.transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine)).Append(answer_2.transform.DOScale(1.05f, 0.1f).SetEase(Ease.InOutSine))
			.Append(answer_2.transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
			.Play();
	}

	private void OnDestroy()
	{
		answer_1.onClick.RemoveAllListeners();
		answer_2.onClick.RemoveAllListeners();
		DialogueManager.Instance.OnDialogueStart -= DialogueManager_OnDialogueStart;
		DialogueManager.Instance.OnDialogueFinish -= DialogueManager_OnDialogueFinish;
		showAnimation.Kill();
		answerShowAnimation.Kill();
	}
}
