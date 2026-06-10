using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupMessageController : MonoBehaviour
{
	public enum AffectPauseState
	{
		automatic = 0,
		yes = 1,
		no = 2
	}

	public delegate void LeftButton();

	public delegate void RightButton();

	public delegate void LeftButton2();

	public delegate void RightButton2();

	public delegate void OptionButton();

	[Header("References")]
	public RectTransform rect;

	public TextMeshProUGUI titleText;

	public TextMeshProUGUI bodyText;

	public ButtonController leftButton;

	public ButtonController rightButton;

	public ButtonController leftButton2;

	public ButtonController rightButton2;

	public ButtonController optionButton;

	public CustomScrollRect textScrollView;

	public RectTransform textScrollViewContent;

	public TextMeshProUGUI scrollViewTextObject;

	public TMP_InputField inputField;

	public MultiSelectController colourPicker;

	public List<LayoutGroup> buttonLayouts;

	public CanvasGroup canvasGroup;

	public CanvasRenderer vignetteRenderer;

	public GameObject vignetteObject;

	public List<GraphicRaycaster> otherCanvasRaycasters;

	[Space(7f)]
	public RectTransform tutorialRect;

	public TextMeshProUGUI tutorialTitleText;

	public TextMeshProUGUI tutorialBodyText;

	public ButtonController tutorialLeftButton;

	public ButtonController tutorialRightButton;

	public InterfaceVideoController tutorialVideoPlayer;

	public List<LayoutGroup> tutorialButtonLayouts;

	public HelpContentPage helpPage;

	public int helpPageNumber;

	public int maxHelpPageNumber;

	public List<string> skipBlocks;

	public CanvasGroup tutorialCanvasGroup;

	[Header("State")]
	public bool active;

	public bool tutorialActive;

	public float appearProgress;

	public List<string> buttonActions;

	public bool anyButtonPressCloses;

	public bool allowEmptyInputField;

	private float inputFieldValidationTimer;

	public bool previouslyEnabledVirtualCursor;

	public bool affectPauseState;

	private bool setupNav;

	private static PopupMessageController _instance;

	public static PopupMessageController Instance => null;

	public event LeftButton OnLeftButton
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event RightButton OnRightButton
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event LeftButton2 OnLeftButton2
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event RightButton2 OnRightButton2
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event OptionButton OnOptionButton
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Setup()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void PopupMessage(string newMsgString, bool enableLeftButton = true, bool enableRightButton = false, string LButton = "Cancel", string RButton = "", bool anyButtonClosesMsg = true, AffectPauseState newPauseState = AffectPauseState.automatic, bool enableInputField = false, string inputFieldDefault = "", bool closeMap = false, bool enableColourPicker = false, bool enableSecondaryLeftButton = false, bool enableSecondaryRightButton = false, string LButton2 = "", string RButton2 = "", bool enableOptionButton = false, string OButton = "", bool enableTextScrollView = false, string scrollViewText = "", string mainTextPreWrittenOverride = "", bool newAllowEmptyInputField = false)
	{
	}

	public void TutorialMessage(string newHelpSection, AffectPauseState newPauseState = AffectPauseState.automatic, bool closeMap = false, List<string> newSkipBlocks = null)
	{
	}

	public void SetHelpPage(int newNumber)
	{
	}

	public void RemoveMessage()
	{
	}

	public void OnButtonPress(int buttonVal)
	{
	}

	public void OnInputFieldSelect()
	{
	}

	public void SelectDefault()
	{
	}

	public void SelectDefaultTutorial()
	{
	}

	public void InputFieldValidation()
	{
	}
}
