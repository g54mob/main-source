using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AssistantDialogue : MonoBehaviour
{
	private static int MIN_WIDTH = 300;

	private static int MAX_WIDTH = 480;

	private static int CHARACTER_WIDTH = 15;

	private static int DEFAULT_HEIGHT = 110;

	private static int TEXT_LINE_HEIGHT = 30;

	private static int ICON_HEIGHT = 90;

	private static int HELP_BUTTON_HEIGHT = 38;

	private static int DEFAULT_QUESTIONS_Y_AXIS = -75;

	[SerializeField]
	private GameObject questionPrompts;

	[SerializeField]
	private GameObject questionButtonPrefab;

	[SerializeField]
	private GameObject nextPrompts;

	[SerializeField]
	private TextMeshProUGUI dialogueText;

	[SerializeField]
	private Button leftButton;

	[SerializeField]
	private TextMeshProUGUI leftButtonText;

	[SerializeField]
	private Button rightButton;

	[SerializeField]
	private TextMeshProUGUI rightButtonText;

	[SerializeField]
	private Image iconDemo;

	private RectTransform bubble;

	private bool isIconDisplayed;

	private Animator animator;

	private Button[] questionButtons;

	private int questionButtonCount;

	private bool promptsDisabled;

	private void OnEnable()
	{
		questionButtonCount = 0;
		isIconDisplayed = false;
		bubble = GetComponent<RectTransform>();
		animator = GetComponent<Animator>();
		DisableIcon();
	}

	public void CreateQuestionAnswer(string text, UnityAction action)
	{
		GameObject gameObject = Object.Instantiate(questionButtonPrefab, questionPrompts.transform.position, Quaternion.identity, questionPrompts.transform);
		gameObject.GetComponentInChildren<TextMeshProUGUI>().text = text;
		SetAction(gameObject.GetComponent<Button>(), action);
		questionButtonCount++;
	}

	public void ClearQuestionAnswers()
	{
		questionButtonCount = 0;
		foreach (Transform item in questionPrompts.transform)
		{
			Object.Destroy(item.gameObject);
		}
	}

	public void PlayOpen()
	{
		animator.Play("Open");
	}

	public void SetText(string text)
	{
		dialogueText.text = text;
		Resize();
		PlayOpen();
	}

	public void DisplayIcon(Sprite icon)
	{
		iconDemo.gameObject.SetActive(value: true);
		iconDemo.sprite = icon;
		isIconDisplayed = true;
	}

	public void DisableIcon()
	{
		iconDemo.gameObject.SetActive(value: false);
		isIconDisplayed = false;
	}

	private void Resize()
	{
		string[] array = dialogueText.text.Split("\n");
		int num = array.Length;
		Debug.Log("Line: " + dialogueText.text);
		Debug.Log($"Line count: {num}");
		int item = MaxLineLength(array).Item1;
		float num2 = ((item > MAX_WIDTH / CHARACTER_WIDTH) ? ((float)MAX_WIDTH) : ((item >= MIN_WIDTH / CHARACTER_WIDTH) ? ((float)(item * CHARACTER_WIDTH)) : ((float)MIN_WIDTH)));
		bubble.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 + (float)(promptsDisabled ? (-80) : 0));
		bubble.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, DEFAULT_HEIGHT + num * TEXT_LINE_HEIGHT + (promptsDisabled ? (-TEXT_LINE_HEIGHT) : 0) + (isIconDisplayed ? ICON_HEIGHT : 0) + (questionPrompts.activeSelf ? (questionButtonCount * HELP_BUTTON_HEIGHT) : 0));
		RectTransform component = questionPrompts.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(component.anchoredPosition.x, DEFAULT_QUESTIONS_Y_AXIS - num * TEXT_LINE_HEIGHT);
	}

	private (int, int) MaxLineLength(string[] lines)
	{
		int num = 0;
		int num2 = 0;
		foreach (string text in lines)
		{
			if (text.Length > num)
			{
				num = text.Length;
			}
			if (text.Length > MAX_WIDTH / CHARACTER_WIDTH)
			{
				num2 += text.Length / (MAX_WIDTH / CHARACTER_WIDTH);
			}
		}
		return (num, num2);
	}

	public void Disable()
	{
		base.gameObject.SetActive(value: false);
	}

	public void Enable()
	{
		base.gameObject.SetActive(value: true);
	}

	public void EnableQuestions()
	{
		promptsDisabled = false;
		questionPrompts.SetActive(value: true);
		nextPrompts.SetActive(value: false);
	}

	private void EnableNextPrompt()
	{
		promptsDisabled = false;
		questionPrompts.SetActive(value: false);
		nextPrompts.SetActive(value: true);
	}

	public void SetYesNoPrompt()
	{
		EnableNextPrompt();
		SetPrompt("No", "Yes");
		leftButton.gameObject.SetActive(value: true);
	}

	public void SetNextPrompt()
	{
		EnableNextPrompt();
		SetPrompt("Skip", "Next");
		leftButton.gameObject.SetActive(value: true);
	}

	public void DisablePrompts()
	{
		ClearQuestionAnswers();
		promptsDisabled = true;
		leftButton.gameObject.SetActive(value: false);
		rightButton.gameObject.SetActive(value: false);
	}

	public void SetThanksPrompt()
	{
		EnableNextPrompt();
		SetPrompt("", "Thanks");
		leftButton.gameObject.SetActive(value: false);
	}

	private void SetPrompt(string left, string right)
	{
		leftButtonText.text = left;
		rightButtonText.text = right;
	}

	public void SetRightDialogueAction(UnityAction action)
	{
		SetAction(rightButton, action);
	}

	public void SetLeftDialogueAction(UnityAction action)
	{
		SetAction(leftButton, action);
	}

	public UnityEvent GetRightButtonAction()
	{
		return rightButton.onClick;
	}

	private void SetAction(Button button, UnityAction action)
	{
		button.gameObject.SetActive(value: true);
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(action);
	}
}
