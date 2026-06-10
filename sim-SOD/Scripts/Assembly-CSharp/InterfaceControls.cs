using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceControls : MonoBehaviour
{
	public enum Icon
	{
		lookingGlass = 0,
		lightBulb = 1,
		key = 2,
		agent = 3,
		citizen = 4,
		pin = 5,
		footprint = 6,
		document = 7,
		door = 8,
		location = 9,
		questionMark = 10,
		eye = 11,
		books = 12,
		star = 13,
		building = 14,
		hand = 15,
		run = 16,
		money = 17,
		message = 18,
		lockpick = 19,
		notebook = 20,
		empty = 21,
		skull = 22,
		passedOut = 23,
		telephone = 24,
		printScanner = 25,
		resolve = 26,
		time = 27,
		tick = 28,
		cross = 29,
		camera = 30,
		vandalism = 31,
		robbery = 32,
		picture = 33,
		fist = 34,
		handcuffs = 35,
		trash = 36,
		food = 37
	}

	[Serializable]
	public class IconConfig
	{
		public Icon iconType;

		public Sprite sprite;
	}

	public enum EvidenceColours
	{
		red = 0,
		blue = 1,
		yellow = 2,
		green = 3,
		purple = 4,
		white = 5,
		black = 6
	}

	[Serializable]
	public class PinColours
	{
		public EvidenceColours colour;

		public Color actualColour;
	}

	[Header("First Person")]
	[Tooltip("Minimum size of the first person interaction cursor")]
	public Vector2 interactionCursorMin;

	[Tooltip("Maximum size of the first person interaction cursor")]
	public Vector2 interactionCursorMax;

	[Tooltip("Speed of the first person interaction cursor")]
	public float interactionCursorSpeed;

	[Tooltip("Interaction text normal colour")]
	public Color interactionTextColour;

	public Color interactionTextDistanceColour;

	public Color interactionTextIllegalColour;

	[Tooltip("Low health indicator displays if player health is under this (normalized)")]
	public float lowHealthIndicatorThreshold;

	[Tooltip("Display control icons for this long (seconds)")]
	public float controlIconDisplayTime;

	[Header("Tooltips")]
	[Tooltip("Globally enable tooltips")]
	public bool enableTooltips;

	[Tooltip("The default tooltip width")]
	public float tooltipWidth;

	[Tooltip("The tooltip prefab")]
	public GameObject tooltipObjectPrefab;

	[Tooltip("Delay before tooltip appears")]
	public float toolTipDelay;

	[Tooltip("How fast the tooltip fades in")]
	public float toolTipFadeInSpeed;

	[Tooltip("Default colour")]
	public Color defaultTextColour;

	public float contextMenuWidth;

	[Header("Map")]
	public RectTransform minimapRootParent;

	public Sprite playerApartmentSprite;

	public GameObject mapLoadingGraphic;

	[Tooltip("Unknown icon")]
	[Header("Buttons & Icons")]
	public Sprite unknownIconLarge;

	[Tooltip("Default company icon")]
	public Sprite companyIconLarge;

	[Tooltip("Double click delay")]
	public float doubleClickDelay;

	public Sprite stickyNoteButtonSprite;

	public Sprite lockedSprite;

	public Sprite unlockedSprite;

	[Header("References")]
	[Tooltip("The HUD Canvas")]
	public Canvas hudCanvas;

	[Tooltip("The HUD Canvas Rect")]
	public RectTransform hudCanvasRect;

	[Tooltip("The parent of speech bubbles")]
	public RectTransform speechBubbleParent;

	[Tooltip("Container for reticle")]
	public RectTransform reticleContainer;

	[Tooltip("Container for location text")]
	public RectTransform locationTextContainer;

	[Tooltip("Toggles on/off for screenshot mode")]
	public List<RectTransform> screenshotModeToggleObjects;

	public List<RectTransform> screenShotModeAllowDialogObjects;

	[Header("HUD")]
	[Tooltip("Interaction control text colour")]
	public Color interactionControlTextColourNormal;

	public Color windowTakeItemIconDefaultColor;

	[NonSerialized]
	public string interactionControlTextNormalHex;

	[Tooltip("Interaction control text colour")]
	public Color interactionControlTextColourIllegal;

	[NonSerialized]
	public string interactionControlTextIllegalHex;

	[Tooltip("Game message system text display speed")]
	public float gameMessageTextRevealSpeed;

	[Tooltip("How long to display game message before removing")]
	public float gameMessageDestroyDelay;

	[Tooltip("Anchor for the weapon switch display")]
	public RectTransform weaponSwitchAnchor;

	[Tooltip("Anchor of the first person item")]
	public Transform firstPersonItemsParent;

	public Color interactionTextNormalColour;

	[Tooltip("Colour of trespassing alert escalaction 0")]
	public Color trespassingEscalationZero;

	[Tooltip("Colour of trespassing alert escalaction 1")]
	public Color trespassingEscalationOne;

	public RectTransform fastForwardArrow;

	[Tooltip("Height of the movie bars when spotted")]
	public float movieBarHeight;

	[Header("UI References")]
	public TextMeshProUGUI lockpicksText;

	public TextMeshProUGUI cashText;

	public TextMeshProUGUI socialRankText;

	public TextMeshProUGUI plottedRouteText;

	[Space(7f)]
	public AnimationCurve notificationGlowCurve;

	public Color notificationColorMax;

	public Color notificationColorMin;

	[Space(7f)]
	public Color messageGrey;

	public Color messageRed;

	public Color messageGreen;

	public Color messageBlue;

	public Color messageYellow;

	[Header("Icons")]
	public Sprite starchLogo;

	public Sprite elGenLogo;

	public Sprite kensingtonLogo;

	public Sprite KaizenLogo;

	public Sprite candorLogo;

	public Sprite blackMarketLogo;

	public List<IconConfig> iconReference;

	[Header("Awareness HUD")]
	public Material arrow;

	public Material spotted;

	public Material speech;

	public float awarenessDistanceThreshold;

	[ColorUsage(true, true)]
	public Color spottedNormalEmission;

	[ColorUsage(true, true)]
	public Color arrowNormalEmission;

	[ColorUsage(true, true)]
	public Color awarenessAlertEmission;

	[Header("UI Speech")]
	public Vector2 textSpaceBuffer;

	public float textBubbleMinWidth;

	public float textBubbleMaxWidth;

	public Color playerSpeechColour;

	public Color callerSpeechColour;

	[Tooltip("On-screen speech talk speed")]
	public float visualTalkDisplaySpeed;

	[Tooltip("How long to display speech before removing")]
	public float visualTalkDisplayDestroyDelay;

	[Tooltip("Give extra on-screen time adding this amount per character")]
	public float visualTalkDisplayStringLengthModifier;

	[Tooltip("On-screen speech text size")]
	public float visualTalkTextSize;

	[Tooltip("The min and max scale of the speech bubble based on distance")]
	public Vector2 speechMinMaxScale;

	[Tooltip("The min and max scale of the ai indicator based on distance")]
	public Vector2 indicatorMinMaxScale;

	[Tooltip("The max distance at which ai indicators are active")]
	public float maxIndicatorDistance;

	[Header("Objectives")]
	public Vector2 uiPointerDistanceRange;

	public TextMeshProUGUI caseSolvedText;

	public List<CanvasRenderer> screenMessageFadeRenderers;

	public RectTransform resolveQuestionsDisplayParent;

	public AnimationCurve caseSolvedAlphaAnim;

	public AnimationCurve caseSolvedKerningAnim;

	[Header("Handbook")]
	public Vector2 handbookWindowPosition;

	[Header("Player")]
	public Vector2 lightOrbSize;

	public AnimationCurve stealthModeOrbSizeTransitionIn;

	public AnimationCurve stealthModeOrbSizeTransitionOut;

	public RectTransform lightOrbRect;

	public Image lightOrbFillImg;

	public Image lightOrbOutline;

	public Image seenImg;

	public CanvasRenderer seenRenderer;

	public JuiceController seenJuice;

	[Space(7f)]
	public RectTransform interactionRect;

	public RectTransform interactionULRect;

	public RectTransform interactionURRect;

	public RectTransform interactionBLRect;

	public RectTransform interactionBRRect;

	public List<Image> interactionFadeInImages;

	public List<Image> interactionBoundImages;

	public RectTransform interactionTextContainer;

	public TextMeshProUGUI interactionText;

	public RectTransform readingTextContainer;

	public CanvasRenderer readingContainerRend;

	public TextMeshProUGUI readingText;

	public CanvasRenderer readingTextRend;

	public Vector2 readingBoxMaxSize;

	public RectTransform haveKeyIcon;

	public RectTransform lockedIcon;

	public Image lockedImg;

	public RectTransform forbiddenIcon;

	public RectTransform seenIcon;

	public TextMeshProUGUI lockStrengthText;

	[Space(7f)]
	public RectTransform actionInteractionDisplay;

	public RectTransform actionInteractionAnchor;

	public TextMeshProUGUI actionInteractionText;

	[Space(7f)]
	public Color unheardSoundIconColour;

	public Color heardSoundIconColour;

	[Tooltip("Width of the string")]
	[Header("Case Panel")]
	public Vector2 stringWidthRange;

	[Tooltip("How far away another evidence entry is pinned automatically")]
	public float autoPinDistance;

	[Tooltip("When auto-pinning, the radius space needed to spawn evidence")]
	public float pinnedEvidenceRadius;

	[Tooltip("When auto-pinning, the number of possible angle steps to position test")]
	public int angleStepsCount;

	public Rigidbody2D caseBoardRigidbody;

	public RectTransform caseBoardCursorRBContainer;

	public Rigidbody2D caseBoardCursorRigidbody;

	public RectTransform caseBoardContentContainer;

	public float pinnedLinearDrag;

	public float movingLinearDrag;

	[Tooltip("Image displayed as a screenshot to replace the rendered camera when in case mode")]
	public RawImage cameraScreenshot;

	public RenderTexture cameraScreenshotRenderTex;

	public float pinnedMovementIntertiaMultiplier;

	[Header("Evidence")]
	[Tooltip("Default case file colour")]
	public Color defaultCaseFileColour;

	[Tooltip("Maximum number of item entries in evidence history")]
	public int maximumEvidenceItemHistory;

	[Tooltip("Interface customisable colours")]
	[ReorderableList]
	public List<PinColours> pinColours;

	[Tooltip("Displayed when the player has photograph information for a citizen")]
	public Sprite citizenPhoto;

	[Tooltip("When true minimize evidence as soon as you pin it")]
	public bool minimizeEvidenceOnPinned;

	[Tooltip("Evidence link colour")]
	public Color markedLinkColour;

	[Tooltip("Neutral/Inactive colour")]
	public Color neutralColour;

	[Tooltip("Incriminating colour")]
	public Color incriminatingColour;

	[Tooltip("Innocent colour")]
	public Color innocentColour;

	public Texture2D nullPhotoReference;

	[Header("Windows")]
	[Tooltip("The default window location")]
	public Vector2 defaultWindowLocation;

	[Tooltip("Offset applied to default window location per active window")]
	public Vector2 windowCountOffset;

	[Tooltip("Speed of the minimize/restore animation")]
	public float minimizingAnimationSpeed;

	[Tooltip("Colour of selection buttons when selected")]
	public Color selectionColour;

	[Tooltip("Colour of selection buttons when not selected")]
	public Color nonSelectionColour;

	[Tooltip("The close button X")]
	public Sprite closeSprite;

	public Color closeColour;

	[Tooltip("The minimize sprite for the close button")]
	public Sprite minimizeSprite;

	public Color minimizeColour;

	[Header("Cursor Sprites")]
	public Texture2D normalCursor;

	[Tooltip("Displayed when mousing over something that moves")]
	public Texture2D cursorMove;

	[Tooltip("Displayed when mousing over something that can be resized")]
	public Texture2D cursorResizeHorizonal;

	[Tooltip("Displayed when mousing over something that can be resized")]
	public Texture2D cursorResizeVertical;

	[Tooltip("Displayed when mousing over something that can be resized")]
	public Texture2D cursorResizeDiagonalRightLeft;

	[Tooltip("Displayed when mousing over something that can be resized")]
	public Texture2D cursorResizeDiagonalLeftRight;

	[Tooltip("Displayed when mousing over something that needs targeting")]
	public Texture2D cursorTarget;

	[Tooltip("Displayed when mousing over a button by default")]
	public Texture2D cursorButton;

	[Tooltip("Displayed when mousing over text input field")]
	public Texture2D cursorTextEdit;

	[Space(7f)]
	public Sprite reactionInvestigateSightSprite;

	public Sprite reactionInvestigateSoundSprite;

	public Sprite reactionPersueSprite;

	public Sprite reactionSearchSprite;

	public Sprite reactionAvoidSprite;

	[Space(7f)]
	public Texture reactionInvestigateSightTex;

	public Texture reactionInvestigateSoundTex;

	public Texture reactionPersueTex;

	public Texture reactionSearchTex;

	public Texture reactionAvoidTex;

	private static InterfaceControls _instance;

	public static InterfaceControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
