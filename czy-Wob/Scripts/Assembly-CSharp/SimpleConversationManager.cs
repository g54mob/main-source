using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleConversationManager : MonoBehaviour
{
	private enum AlignmentType
	{
		TOP_LEFT = 0,
		MIDDLE = 1
	}

	private enum ExpressionType
	{
		DEFAULT = 0,
		HAPPY = 1,
		SAD = 2,
		ANGRY = 3,
		SURPRISED = 4,
		WINKY = 5
	}

	public delegate void ConversationFinishedCallback();

	[Serializable]
	private class ScaleClass
	{
		public int index;

		public float currentTime;

		public Vector3 startingPosBotLeft;

		public Vector3 startingPosTopLeft;

		public Vector3 startingPosTopRight;

		public Vector3 startingPosBotRight;

		public Vector3 boxCenter;

		public ScaleClass(int index, float currentTime, Vector3 startingPosBotLeft, Vector3 startingPosTopLeft, Vector3 startingPosTopRight, Vector3 startingPosBotRight, Vector3 boxCenter)
		{
			this.index = index;
			this.currentTime = currentTime;
			this.startingPosBotLeft = startingPosBotLeft;
			this.startingPosTopLeft = startingPosTopLeft;
			this.startingPosTopRight = startingPosTopRight;
			this.startingPosBotRight = startingPosBotRight;
			this.boxCenter = boxCenter;
		}
	}

	private static string DEFAULT_EXPRESSION = ":)";

	private static string HAPPY_EXPRESSION = ":D";

	private static string SAD_EXPRESSION = ":(";

	private static string ANGRY_EXPRESSION = ">:(";

	private static string SURPRISED_EXPRESSION = ":o";

	private static string WINKY_EXPRESSION = ";)";

	private static string MIDDLE_ALIGN_SYMBOL = "ALIGN_MIDDLE";

	private static string TOP_LEFT_ALIGN_SYMBOL = "ALIGN_TOP_LEFT";

	public Animator characterAnimator;

	public GameObject characterPortrait;

	public InchwormBounce characterBouncer;

	public GameObject characterTextBox;

	public TextMeshProUGUI characterText;

	public ConversationBoxArrow arrowRef;

	public GameObject defaultExpression;

	public GameObject happyExpression;

	public GameObject sadExpression;

	public GameObject angryExpression;

	public GameObject surprisedExpression;

	public GameObject winkyExpression;

	private ExpressionType currentExpressionType;

	private ConversationFinishedCallback currentCallback;

	private Vector3 localPortratiPos = new Vector3(0f, 362f, 0f);

	private Vector3 textBoxSlideInVector = new Vector3(300f, 0f, 0f);

	private Vector3 characterSlideInVector = new Vector3(-100f, 0f, 0f);

	private const string triggerTalk = "Talk";

	private const string triggerIdle = "Idle";

	private float textBoxSlideInTime = 0.15f;

	private float characterSlideInTime = 0.15f;

	private Vector3 startingTextBoxPos;

	private Vector3 startingPortraitPos;

	private bool isLoading;

	private bool isUnloading;

	private bool inConversation;

	private int convoIndex = -1;

	private string[] conversationDialogueList;

	private List<bool> expressionIndex = new List<bool>();

	private ulong? currentTextInKey;

	private int elementsLoaded;

	private int elementsNeeded = 2;

	private Inchworm inchwormRef;

	private PenFocus penFocusRef;

	private GUIManagerPens guiRef;

	private void Awake()
	{
		characterPortrait.SetActive(value: false);
		characterText.text = "";
		characterTextBox.SetActive(value: false);
		happyExpression.SetActive(value: false);
		sadExpression.SetActive(value: false);
		angryExpression.SetActive(value: false);
		surprisedExpression.SetActive(value: false);
		winkyExpression.SetActive(value: false);
		defaultExpression.SetActive(value: true);
		currentExpressionType = ExpressionType.DEFAULT;
		happyExpression.transform.localPosition = localPortratiPos;
		sadExpression.transform.localPosition = localPortratiPos;
		angryExpression.transform.localPosition = localPortratiPos;
		surprisedExpression.transform.localPosition = localPortratiPos;
		winkyExpression.transform.localPosition = localPortratiPos;
		defaultExpression.transform.localPosition = localPortratiPos;
		arrowRef.enabled = false;
		characterAnimator.enabled = false;
	}

	private void Start()
	{
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		inchwormRef = registrationScript.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		startingTextBoxPos = characterTextBox.transform.localPosition;
		startingPortraitPos = characterPortrait.transform.localPosition;
	}

	private void Update()
	{
		if (!isLoading && !isUnloading && inConversation && GameControls.actions.Interact.WasPressed)
		{
			AdvanceConversation();
		}
	}

	public void RequestConversation(TextAsset conversationFile, ConversationFinishedCallback callback = null)
	{
		if (inConversation || isLoading || isUnloading)
		{
			Debug.LogError("Already in a conversation but attempting to start another!");
			return;
		}
		if (callback != null)
		{
			currentCallback = callback;
		}
		isLoading = true;
		characterText.text = "";
		conversationDialogueList = conversationFile.text.Split("\n"[0]);
		expressionIndex.Clear();
		for (int i = 0; i < conversationDialogueList.Length; i++)
		{
			expressionIndex.Add(item: false);
		}
		CheckForExpressions(conversationDialogueList[0], fromLoad: true);
		convoIndex = -1;
		elementsLoaded = 0;
		characterTextBox.SetActive(value: true);
		characterPortrait.SetActive(value: true);
		inchwormRef.RequestEase(characterTextBox, textBoxSlideInVector, textBoxSlideInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnElementLoaded, Inchworm.EasePriority.Normal, keepSameParent: true);
		inchwormRef.RequestEase(characterPortrait, characterSlideInVector, characterSlideInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnElementLoaded, Inchworm.EasePriority.Normal, keepSameParent: true);
	}

	private void OnElementLoaded()
	{
		elementsLoaded++;
		if (elementsLoaded >= elementsNeeded)
		{
			OnAllElementsLoaded();
		}
	}

	private void OnAllElementsLoaded()
	{
		isLoading = false;
		inConversation = true;
		arrowRef.enabled = true;
		characterAnimator.enabled = true;
		AdvanceConversation();
	}

	public void EndConversation()
	{
		if (isLoading || isUnloading || !inConversation)
		{
			Debug.LogError("Attempting to unload a conversation that doesn't exist or isn't yet ready to be unloaded.");
			return;
		}
		isUnloading = true;
		arrowRef.enabled = false;
		characterBouncer.StopBounce();
		characterAnimator.enabled = false;
		inchwormRef.RequestEase(characterTextBox, -textBoxSlideInVector, textBoxSlideInTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnElementUnloaded, Inchworm.EasePriority.Normal, keepSameParent: true);
		inchwormRef.RequestEase(characterPortrait, -characterSlideInVector, characterSlideInTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnElementUnloaded, Inchworm.EasePriority.Normal, keepSameParent: true);
	}

	private void OnElementUnloaded()
	{
		elementsLoaded--;
		if (elementsLoaded <= 0)
		{
			OnAllElementsUnloaded();
		}
	}

	private void OnAllElementsUnloaded()
	{
		characterTextBox.SetActive(value: false);
		characterPortrait.SetActive(value: false);
		characterTextBox.transform.localScale = Vector3.one;
		characterTextBox.transform.localPosition = startingTextBoxPos;
		characterPortrait.transform.localPosition = startingPortraitPos;
		isUnloading = false;
		inConversation = false;
		penFocusRef.UnblurUI();
		guiRef.EnableBG(LockReason.TUTORIAL_DOG_CONVO);
		if (currentCallback != null)
		{
			currentCallback();
			currentCallback = null;
		}
	}

	private void OnTextInComplete(ulong key)
	{
		currentTextInKey = null;
	}

	private void AdvanceConversation()
	{
		if (currentTextInKey.HasValue)
		{
			TextScaleInEffect.RequestEffectEnd(currentTextInKey.Value, characterText, this);
			return;
		}
		AdvanceConversationIndex();
		if (convoIndex >= conversationDialogueList.Length)
		{
			EndConversation();
			return;
		}
		string text = conversationDialogueList[convoIndex];
		bool flag = true;
		if (CheckForExpressions(text) || CheckForAlignment(text))
		{
			flag = false;
		}
		if (!flag)
		{
			AdvanceConversation();
			return;
		}
		characterText.text = text;
		currentTextInKey = TextScaleInEffect.ScaleInText(characterText, this, OnTextInComplete);
	}

	private bool CheckForAlignment(string nextLine, bool fromLoad = false)
	{
		nextLine = nextLine.Replace("\r", "");
		if (nextLine == MIDDLE_ALIGN_SYMBOL)
		{
			ChangeAlignment(AlignmentType.MIDDLE);
			return true;
		}
		if (nextLine == TOP_LEFT_ALIGN_SYMBOL)
		{
			ChangeAlignment(AlignmentType.TOP_LEFT);
			return true;
		}
		return false;
	}

	private void ChangeAlignment(AlignmentType alignment)
	{
		switch (alignment)
		{
		case AlignmentType.TOP_LEFT:
			characterText.alignment = TextAlignmentOptions.TopLeft;
			break;
		case AlignmentType.MIDDLE:
			characterText.alignment = TextAlignmentOptions.Center;
			break;
		}
	}

	private bool CheckForExpressions(string nextLine, bool fromLoad = false)
	{
		nextLine = nextLine.Replace("\r", "");
		if (nextLine == DEFAULT_EXPRESSION)
		{
			ChangeExpression(ExpressionType.DEFAULT, fromLoad);
			return true;
		}
		if (nextLine == HAPPY_EXPRESSION)
		{
			ChangeExpression(ExpressionType.HAPPY, fromLoad);
			return true;
		}
		if (nextLine == SAD_EXPRESSION)
		{
			ChangeExpression(ExpressionType.SAD, fromLoad);
			return true;
		}
		if (nextLine == ANGRY_EXPRESSION)
		{
			ChangeExpression(ExpressionType.ANGRY, fromLoad);
			return true;
		}
		if (nextLine == SURPRISED_EXPRESSION)
		{
			ChangeExpression(ExpressionType.SURPRISED, fromLoad);
			return true;
		}
		if (nextLine == WINKY_EXPRESSION)
		{
			ChangeExpression(ExpressionType.WINKY, fromLoad);
			return true;
		}
		return false;
	}

	private void ChangeExpression(ExpressionType newType, bool fromLoad = false)
	{
		if (currentExpressionType == newType)
		{
			return;
		}
		GetGraphicForExpressionType(currentExpressionType).SetActive(value: false);
		GetGraphicForExpressionType(newType).SetActive(value: true);
		currentExpressionType = newType;
		if (currentExpressionType != ExpressionType.DEFAULT && !fromLoad)
		{
			if (convoIndex != 0)
			{
				RequestBounce();
			}
			expressionIndex[convoIndex] = true;
		}
	}

	private void RequestBounce()
	{
		characterBouncer.RequestBounce();
	}

	private GameObject GetGraphicForExpressionType(ExpressionType newType)
	{
		switch (newType)
		{
		case ExpressionType.DEFAULT:
			return defaultExpression;
		case ExpressionType.HAPPY:
			return happyExpression;
		case ExpressionType.SAD:
			return sadExpression;
		case ExpressionType.ANGRY:
			return angryExpression;
		case ExpressionType.SURPRISED:
			return surprisedExpression;
		case ExpressionType.WINKY:
			return winkyExpression;
		default:
			Debug.LogError(string.Concat("Invalid ExpressionType: ", newType, " requested."));
			return defaultExpression;
		}
	}

	public void RequestTalkAnimation()
	{
		if (convoIndex - 1 < 0 || !expressionIndex[convoIndex - 1])
		{
			characterAnimator.SetTrigger("Talk");
			characterAnimator.ResetTrigger("Idle");
		}
	}

	public void RequestIdleAnimation()
	{
		characterAnimator.SetTrigger("Idle");
		characterAnimator.ResetTrigger("Talk");
	}

	private void AdvanceConversationIndex()
	{
		convoIndex++;
	}
}
