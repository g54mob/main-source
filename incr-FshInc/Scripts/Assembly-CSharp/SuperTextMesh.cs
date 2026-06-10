using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

[HelpURL("Assets/Clavian/SuperTextMesh/Documentation/SuperTextMesh.html")]
[AddComponentMenu("Mesh/Super Text Mesh", 3)]
[ExecuteInEditMode]
[DisallowMultipleComponent]
public class SuperTextMesh : MonoBehaviour, ILayoutElement, IMaskable
{
	public enum PitchMode
	{
		Normal = 0,
		Single = 1,
		Random = 2,
		Perlin = 3
	}

	public enum MaskMode
	{
		Inside = 0,
		Outside = 1,
		Ignore = 2
	}

	public enum Alignment
	{
		Left = 0,
		Center = 1,
		Right = 2,
		Justified = 3,
		ForceJustified = 4
	}

	public enum VerticalLimitMode
	{
		ShowLast = 0,
		CutOff = 1,
		Ignore = 2,
		AutoPause = 3,
		AutoPauseFull = 4,
		SquishBETA = 5
	}

	public delegate void OnCompleteAction();

	public delegate void OnUndrawnAction();

	public delegate void OnRebuildAction();

	public delegate void OnPrintAction();

	[Serializable]
	public class CustomEvent : UnityEvent<string, STMTextInfo>
	{
	}

	public delegate void OnCustomAction(string text, STMTextInfo info);

	[Serializable]
	public class VertexMod : UnityEvent<Vector3[], Vector3[], Vector3[]>
	{
	}

	public delegate void OnVertexModAction(Vector3[] verts, Vector3[] middles, Vector3[] positions);

	[Serializable]
	public class PreParse : UnityEvent<STMTextContainer>
	{
	}

	public delegate void OnPreParseAction(STMTextContainer container);

	public enum DrawOrder
	{
		LeftToRight = 0,
		AllAtOnce = 1,
		OneWordAtATime = 2,
		Random = 3,
		RightToLeft = 4,
		ReverseLTR = 5,
		RTLOneWordAtATime = 6,
		OneLineAtATime = 7
	}

	[Serializable]
	public enum BestFitMode
	{
		Off = 0,
		Always = 1,
		OverLimit = 2,
		SquishAlways = 3,
		SquishOverLimit = 4,
		MultilineBETA = 5
	}

	public bool showTextFoldout = true;

	public bool showAppearanceFoldout = true;

	public bool showMaterialFoldout = true;

	public bool showPositionFoldout = true;

	public bool showTimingFoldout;

	public bool showFunctionalityFoldout;

	public bool showAudioFoldout;

	public bool showEventFoldout;

	public bool showBetaFoldout;

	private static SuperTextMeshData _data;

	private Transform _t;

	private MeshFilter _f;

	private MeshRenderer _r;

	private CanvasRenderer _c;

	public List<STMTextInfo> info = new List<STMTextInfo>();

	private List<int> lineBreaks = new List<int>();

	public List<float> lineHeights = new List<float>();

	internal List<float> boxHeights = new List<float>();

	[TextArea(3, 10)]
	[FormerlySerializedAs("text")]
	public string _text = "<c=rainbow><w>Hello, World!";

	[HideInInspector]
	public string drawText;

	[HideInInspector]
	public string hyphenedText;

	[Tooltip("Font to be used by this text mesh. .rtf, .otf, and Unity fonts are supported.")]
	public Font font;

	[FormerlySerializedAs("color")]
	[Tooltip("this was the old value for colour as isn't used by STM anymore. Don't use it!")]
	public Color32 _color32 = Color.white;

	[Tooltip("Default color of the text mesh. This can be changed with the <c> tag! See the docs for more info.")]
	public Color _color = Color.white;

	[Tooltip("If true, Super Text Mesh will call SetMesh() every frame it is active. This is primarily to be used together with animating a changing color value.")]
	public bool forceAnimation;

	[Tooltip("Will the text listen to tags like <b> and <i>? See docs for a full list of tags.")]
	public bool richText = true;

	[Tooltip("Delay in seconds between letters getting read out. Disabled if set to 0.")]
	public float readDelay;

	[Tooltip("Multiple of time for when speeding up text. Set it to a big number like 1000 to show all text immediately.")]
	public float speedReadScale = 2f;

	[Tooltip("Whether reading uses deltaTime or fixedDeltaTime")]
	public bool ignoreTimeScale = true;

	public bool disableAnimatedText;

	[Tooltip("Name of what draw animation will be used. Case-sensitive.")]
	public string drawAnimName = "Appear";

	[Tooltip("Delay between letters, for undrawing.")]
	public float unreadDelay = 0.05f;

	[Tooltip("Undraw order.")]
	public DrawOrder undrawOrder = DrawOrder.AllAtOnce;

	[Tooltip("Undraw animation name.")]
	public string undrawAnimName = "Appear";

	[Tooltip("Audio source for read sound clips. Sound won't be played if null.")]
	public AudioSource audioSource;

	[Tooltip("Default sound to be read by the above audio source. Can be left null to make no sound by default.")]
	public AudioClip[] audioClips;

	[Tooltip("Should a new letter's sound stop a previous one and play, or let the old one keep playing?")]
	public bool stopPreviousSound = true;

	[Tooltip("Pitch options for reading out text.")]
	public PitchMode pitchMode;

	[Tooltip("New pitch for the sound clip.")]
	[Range(0f, 3f)]
	public float overridePitch = 1f;

	[Tooltip("Minimum pitch for random pitches. If same or greater than max pitch, this will be the pitch.")]
	[Range(0f, 3f)]
	public float minPitch = 0.9f;

	[Tooltip("Maximum pitch for random pitches.")]
	[Range(0f, 3f)]
	public float maxPitch = 1.2f;

	[Range(-2f, 2f)]
	[Tooltip("This amount will be ADDED to the pitch when speedreading. Speedreading uses the delay from 'Fast Delay'")]
	public float speedReadPitch;

	[Tooltip("Multiple for how fast the perlin noise will advance.")]
	public float perlinPitchMulti = 1f;

	private bool speedReading;

	private bool skippingToEnd;

	[HideInInspector]
	public bool reading;

	private Coroutine readRoutine;

	[HideInInspector]
	public bool unreading;

	[Tooltip("Size in local space for letters, by default. Can be changed with the <s> tag.")]
	public float size = 1f;

	public float minSize;

	[HideInInspector]
	public float bestFitMulti = 1f;

	[Range(1f, 500f)]
	[Tooltip("Point size of text. Try to keep it as small as possible while looking crisp!")]
	public int quality = 64;

	[Tooltip("Choose 'Point' for a crisp look. You'll probably want that for pixel fonts!")]
	public FilterMode filterMode = FilterMode.Bilinear;

	[Tooltip("This value is used with how UI Text reacts to masking.")]
	public MaskMode maskMode;

	[Tooltip("Default letter style. Can be changed with the <i> and <b> tags, using rich text.")]
	public FontStyle style;

	[Tooltip("Additional offset for text from the transform, in local space. This does not effect the bounding box, and can be used to better align text with other elements.")]
	public Vector3 baseOffset = Vector3.zero;

	public bool relativeBaseOffset = true;

	[Tooltip("Adjust line spacing between multiple lines of text. 1 is the default for the font.")]
	public float lineSpacing = 1f;

	[Tooltip("Adjust additional spacing between characters. 0 is default.")]
	public float characterSpacing;

	[Tooltip("How far tabs indent.")]
	public float tabSize = 4f;

	[Tooltip("Distance in local space before a line break is automatically inserted at the previous space. Disabled if set to 0.")]
	public float autoWrap = 12f;

	[Tooltip("If true, STM will set its bounds based on RectTransform, without need for Content Size Fitter.")]
	public bool uiWrap = true;

	[Tooltip("If true, STM will set its bounds based on RectTransform, without need for Content Size Fitter.")]
	public bool uiLimit = true;

	[Tooltip("With auto wrap, should large words be split to fit in the box?")]
	public bool breakText;

	[Tooltip("When large words are split, Should a hyphen be inserted?")]
	public bool insertHyphens = true;

	[Tooltip("The anchor point of the mesh. For UI text, this also controls the alignment.")]
	public TextAnchor anchor;

	[Tooltip("Decides where text should align to. Uses the Auto Wrap box as bounds.")]
	public Alignment alignment;

	[Tooltip("Maximum vertical space for this text box. Infinite if set to 0.")]
	public float verticalLimit;

	[Tooltip("How to treat text that goes over the vertical limit.")]
	public VerticalLimitMode verticalLimitMode = VerticalLimitMode.Ignore;

	public string leftoverText;

	[Tooltip("The material to be used by this text mesh. This is a Material so settings can be shared between multiple text meshes easily.")]
	[FormerlySerializedAs("textMat")]
	public Material textMaterial;

	public Mesh textMesh;

	private bool areWeAnimating;

	[HideInInspector]
	public Vector3 rawTopLeftBounds;

	[HideInInspector]
	public Vector3 rawBottomRightBounds;

	[HideInInspector]
	public Vector3 rawBottomRightTextBounds;

	[HideInInspector]
	public Vector3 topLeftBounds;

	[HideInInspector]
	public Vector3 topRightBounds;

	[HideInInspector]
	public Vector3 bottomLeftBounds;

	[HideInInspector]
	public Vector3 bottomRightBounds;

	[HideInInspector]
	public Vector3 centerBounds;

	[HideInInspector]
	public Vector3 topLeftTextBounds;

	[HideInInspector]
	public Vector3 topRightTextBounds;

	[HideInInspector]
	public Vector3 bottomLeftTextBounds;

	[HideInInspector]
	public Vector3 bottomRightTextBounds;

	[HideInInspector]
	public Vector3 centerTextBounds;

	[HideInInspector]
	public Vector3 finalTopLeftTextBounds;

	[HideInInspector]
	public Vector3 finalTopRightTextBounds;

	[HideInInspector]
	public Vector3 finalBottomLeftTextBounds;

	[HideInInspector]
	public Vector3 finalBottomRightTextBounds;

	[HideInInspector]
	public Vector3 finalCenterTextBounds;

	private float lowestPosition;

	private float lowestDrawnPosition;

	private float lowestDrawnPositionRaw;

	private float furthestDrawnPosition;

	private float totalWidth;

	public Vector3 unwrappedBottomRightTextBounds;

	public UnityEvent onCompleteEvent;

	public UnityEvent onUndrawnEvent;

	public UnityEvent onRebuildEvent;

	public UnityEvent onPrintEvent;

	[FormerlySerializedAs("customEvent")]
	public CustomEvent onCustomEvent;

	[FormerlySerializedAs("vertexMod")]
	public VertexMod onVertexMod;

	[FormerlySerializedAs("preParse")]
	public PreParse onPreParse;

	public bool debugMode;

	[HideInInspector]
	public float totalReadTime;

	[HideInInspector]
	public float totalUnreadTime;

	[HideInInspector]
	public float currentReadTime;

	private Vector3[] endVerts = new Vector3[0];

	private Color32[] endCol32 = new Color32[0];

	private Vector2[] endUv = new Vector2[0];

	private Vector2[] endUv2 = new Vector2[0];

	private List<Vector4> ratiosAndUvMids = new List<Vector4>();

	private List<Vector4> isUvRotated = new List<Vector4>();

	private Vector3[] startVerts = new Vector3[0];

	private Color32[] startCol32 = new Color32[0];

	private Vector3[] midVerts = new Vector3[0];

	private Color32[] midCol32 = new Color32[0];

	private float timeDrawn;

	[Tooltip("Decides if the mesh will read out automatically when rebuilt.")]
	public bool autoRead = true;

	[Tooltip("Decides if the mesh will remember where it was if disabled/enabled while reading.")]
	public bool rememberReadPosition = true;

	[Tooltip("For UI text. If true, quality is automatically set to be the same as size.")]
	public bool autoQuality;

	[Tooltip("What order the text will draw in. 'All At Once' will ignore read delay. 'Robot' displays one word at a time. If set to 'Random', Read Delay becomes the time it'll take to draw the whole mesh.")]
	public DrawOrder drawOrder;

	private bool callReadFunction;

	public bool removeEmoji = true;

	private int _pauseCount;

	private int _currentPauseCount;

	private float autoPauseStopPoint;

	private List<KeyValuePair<int, string>> allTags = new List<KeyValuePair<int, string>>();

	private List<Font> allFonts = new List<Font>();

	private static List<char> linebreakFriendlyChars = new List<char> { ' ', '\n', '\t', '-', '\u00ad', '\u200a', '\u200b', '\u3000' };

	private static List<char> linebreakUnfriendlyChars = new List<char>
	{
		'$', '(', '£', '¥', '·', '\'', '"', '〈', '《', '「',
		'『', '【', '〔', '〖', '〝', '﹙', '﹛', '＄', '（', '．',
		'［', '｛', '￡', '￥', '(', '[', '{', '£', '¥', '\'',
		'"', '‵', '〈', '《', '「', '『', '〔', '〝', '\ufe34', '﹙',
		'﹛', '（', '｛', '︵', '︷', '︹', '︻', '︽', '︿', '﹁',
		'﹃', '\ufe4f', '(', '[', '｛', '〔', '〈', '《', '「', '『',
		'【', '〘', '〖', '〝', '\'', '"', '｟', '«'
	};

	private static List<char> linestartUnfriendlyChars = new List<char>
	{
		'!', '%', ')', ',', '.', ':', ';', '?', ']', '}',
		'¢', '°', '·', '\'', '"', '†', '‡', '›', '℃', '∶',
		'、', '。', '〃', '〆', '〕', '〗', '〞', '﹚', '﹜', '！',
		'＂', '％', '＇', '）', '，', '．', '：', '；', '？', '！',
		'］', '｝', '～', '!', ')', ',', '.', ':', ';', '?',
		']', '}', '¢', '·', '–', '—', ' ', '\'', '"', '•',
		' ', '、', '。', '〆', '〞', '〕', '〉', '》', '」', '︰',
		'︱', '︲', '\ufe33', '﹐', '﹑', '﹒', '\ufe53', '﹔', '﹕', '﹖',
		'﹘', '﹚', '﹜', '！', '）', '，', '．', '：', '；', '？',
		'︶', '︸', '︺', '︼', '︾', '﹀', '﹂', '﹗', '］', '｜',
		'｝', '､', ')', ']', '｝', '〕', '〉', '》', '」', '』',
		'】', '〙', '〗', '〟', '\'', '"', '｠', '»', 'ヽ', 'ヾ',
		'ー', 'ァ', 'ィ', 'ゥ', 'ェ', 'ォ', 'ッ', 'ャ', 'ュ', 'ョ',
		'ヮ', 'ヵ', 'ヶ', 'ぁ', 'ぃ', 'ぅ', 'ぇ', 'ぉ', 'っ', 'ゃ',
		'ゅ', 'ょ', 'ゎ', 'ゕ', 'ゖ', 'ㇰ', 'ㇱ', 'ㇲ', 'ㇳ', 'ㇴ',
		'ㇵ', 'ㇶ', 'ㇷ', 'ㇸ', 'ㇹ', 'ㇺ', 'ㇻ', 'ㇼ', 'ㇽ', 'ㇾ',
		'ㇿ', '々', '〻', '‐', '゠', '–', '〜', '？', '?', '！',
		'!', '‼', '⁇', '⁈', '⁉', '・', '、', ':', ';', ',',
		'。', '.', '—', '.', '‥', '〳', '〴', '〵', '0', '1',
		'2', '3', '4', '5', '6', '7', '8', '9', '０', '１',
		'２', '３', '４', '５', '６', '７', '８', '９'
	};

	[Tooltip("Adjusts paragraphs for text that was input right-to-left.")]
	public bool rtl;

	[Tooltip("All alpha values on this SUper Text Mesh will be multiplied by this value.")]
	[Range(0f, 1f)]
	[SerializeField]
	private float _fade = 1f;

	public BestFitMode bestFit;

	private bool applicationFocused = true;

	private bool fontTextureJustRebuilt = true;

	private bool doEvents = true;

	private bool currentlyRebuilding;

	private static int myColorSpace = -1;

	private STMTextInfo UpdateMesh_info;

	private bool wasReadingBefore;

	public int latestNumber = -1;

	public float currentUnReadTime;

	private STMTextInfo DoEvent_info;

	private STMTextInfo PlaySound_info;

	public string preParsedText = "";

	private STMTextInfo ParseText_info = new STMTextInfo();

	private string[] ParseText_dividedString;

	private string ParseText_myString;

	private string ParseText_myTag;

	private STMTextInfo RequestAllCharacters_info;

	private Font Limits_font;

	private CharacterInfo Limits_ch;

	private STMTextInfo Limits_info;

	private int Limits_lineBreaks;

	private float Limits_currentWordWidth;

	private float Limits_longestWordWidth;

	private float BestFit_vertLimit;

	internal float Rebuild_verticalLimit;

	private int[] allLinebreakIndexes;

	private Vector3 Rebuild_pos = Vector3.zero;

	private Font Rebuild_font;

	private CharacterInfo Rebuild_ch;

	private CharacterInfo Rebuild_hyphenCh;

	private CharacterInfo Rebuild_breakCh;

	private CharacterInfo Rebuild_zeroWidthCh;

	private float Rebuild_autoWrap;

	private int infoCount;

	private STMTextInfo Rebuild_info;

	private Vector3 offset = Vector3.zero;

	private Vector3 uiOffset = Vector3.zero;

	private float OffsetData_VerticalLimit;

	private int OffsetData_rowStart;

	private float OffsetData_offsetRight;

	private int OffsetData_spaceCount;

	private float OffsetData_maxHeight;

	private float OffsetData_maxWidth;

	private Vector3 anchorOffset = Vector3.zero;

	private Vector3 RecalculateBounds_point;

	private Vector3 TextBounds_leftOffset = Vector3.zero;

	private Vector3 TextBounds_rightOffset = Vector3.zero;

	private float TextBounds_diff;

	private float RecalculateBounds_textBottom;

	private Transform RecalculateBounds_t;

	private int[] drawOrderRTL = new int[0];

	private int RTL_currentLine = -1;

	private int RTL_lastEnd = -1;

	private STMTextInfo Timing_textInfo;

	private STMTextInfo UnreadTiming_textInfo;

	private Vector3 WavePosition_Vect = Vector3.zero;

	private float WavePosition_multi;

	private Vector3 WaveRotation_Pivot = Vector3.zero;

	private Vector3 WaveRotation_Offset = Vector3.zero;

	private Vector3 WaveRotation_ReturnVal = Vector3.zero;

	private Vector3 WaveRotation_myRotation = Vector3.zero;

	private Quaternion WaveRotation_myQuaternion;

	private Vector3 JitterValue_MyJit = Vector3.zero;

	private Vector3 UpdateMesh_waveValue = Vector3.zero;

	private Vector3 UpdateMesh_waveValueTopLeft = Vector3.zero;

	private Vector3 UpdateMesh_waveValueTopRight = Vector3.zero;

	private Vector3 UpdateMesh_waveValueBottomRight = Vector3.zero;

	private Vector3 UpdateMesh_waveValueBottomLeft = Vector3.zero;

	private Vector3 UpdateMesh_lowestLineOffset = Vector3.zero;

	private Vector3 UpdateMesh_wavePosition;

	private Vector2 UpdateMesh_uvOffset;

	private STMTextInfo CurrentTextInfo;

	private Vector3[] UpdateMesh_Middles = new Vector3[0];

	private Vector3[] UpdateMesh_Positions = new Vector3[0];

	private Vector3 cacheVectThree;

	private Vector3 jitterValue;

	private Vector2 vectA;

	private Vector2 vectAA;

	private Vector2 vectB;

	private Vector2 vectBB;

	private Vector2 vectC;

	private Vector2 vectCC;

	private Vector2 vectD;

	private Vector2 vectDD;

	private Vector2 infoVect;

	private Vector2 uvMidHold;

	private Vector4 ratioAndUvHold;

	private bool doPrintEventAfter;

	private bool doEventAfter;

	private Vector3 realBaseOffset = Vector3.zero;

	private Canvas parentCanvas;

	private List<SubmeshData> submeshes = new List<SubmeshData>();

	private Material[] submeshMaterials = new Material[1];

	private SharedMaterialData Submesh_sharedMaterial;

	private SubmeshData Submesh_submeshData;

	private STMTextInfo Submesh_info;

	public SuperTextMeshData data
	{
		get
		{
			if (_data == null)
			{
				_data = Resources.Load("SuperTextMeshData") as SuperTextMeshData;
				if (_data != null)
				{
					_data.RebuildDictionaries();
				}
				else
				{
					Debug.Log("Super Text Mesh Data not initialized. This might happen when first importing or updating Super Text Mesh. If this persists, please make sure Super Text Mesh's 'Resources' folders are left where they were upon import.");
				}
			}
			return _data;
		}
		set
		{
			_data = value;
		}
	}

	public Transform t
	{
		get
		{
			if (_t == null && this != null)
			{
				_t = base.transform;
			}
			return _t;
		}
	}

	public MeshFilter f
	{
		get
		{
			if (_f == null)
			{
				_f = t.GetComponent<MeshFilter>();
			}
			if (_f == null)
			{
				_f = t.gameObject.AddComponent<MeshFilter>();
			}
			return _f;
		}
	}

	public MeshRenderer r
	{
		get
		{
			if (_r == null)
			{
				_r = t.GetComponent<MeshRenderer>();
			}
			if (_r == null)
			{
				_r = t.gameObject.AddComponent<MeshRenderer>();
			}
			return _r;
		}
	}

	public CanvasRenderer c
	{
		get
		{
			if (_c == null)
			{
				_c = t.GetComponent<CanvasRenderer>();
			}
			if (_c == null)
			{
				_c = t.gameObject.AddComponent<CanvasRenderer>();
			}
			return _c;
		}
	}

	public bool uiMode
	{
		get
		{
			if (t != null)
			{
				return t is RectTransform;
			}
			return false;
		}
	}

	public string text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value ?? "";
			if (t.gameObject.activeInHierarchy)
			{
				Rebuild();
			}
		}
	}

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value ?? "";
			if (t.gameObject.activeInHierarchy)
			{
				Rebuild();
			}
		}
	}

	public Color color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
		}
	}

	public float GetDeltaTime
	{
		get
		{
			if (!data.disableAnimatedText && !disableAnimatedText && applicationFocused)
			{
				if (!ignoreTimeScale)
				{
					return Time.deltaTime;
				}
				return Time.unscaledDeltaTime;
			}
			return 0f;
		}
	}

	public float GetTime
	{
		get
		{
			if (!data.disableAnimatedText && !disableAnimatedText && applicationFocused)
			{
				if (!ignoreTimeScale)
				{
					return Time.time;
				}
				return Time.unscaledTime;
			}
			return 0f;
		}
	}

	public float GetDeltaTime2
	{
		get
		{
			if (applicationFocused)
			{
				if (!ignoreTimeScale)
				{
					return Time.deltaTime;
				}
				return Time.unscaledDeltaTime;
			}
			return 0f;
		}
	}

	public float AutoWrap
	{
		get
		{
			if (uiMode && uiWrap)
			{
				return tr.rect.width;
			}
			if (uiMode && !uiWrap)
			{
				return 0f;
			}
			return autoWrap;
		}
	}

	public RectTransform tr => t as RectTransform;

	private float VerticalLimit
	{
		get
		{
			if (uiMode && uiLimit)
			{
				return tr.rect.height;
			}
			if (uiMode && !uiLimit)
			{
				return 0f;
			}
			return verticalLimit;
		}
	}

	public int pauseCount => _pauseCount;

	public int currentPauseCount => _currentPauseCount;

	public bool canContinue
	{
		get
		{
			if (currentPauseCount > 0)
			{
				return pauseCount < currentPauseCount;
			}
			return false;
		}
	}

	public bool canUndoContinue
	{
		get
		{
			if (pauseCount > 0)
			{
				return currentPauseCount > 0;
			}
			return false;
		}
	}

	public float fade
	{
		get
		{
			return _fade;
		}
		set
		{
			_fade = value;
			SetMesh(currentReadTime);
		}
	}

	private STMDrawAnimData UndrawAnim
	{
		get
		{
			if (data.drawAnims.ContainsKey(undrawAnimName))
			{
				return data.drawAnims[undrawAnimName];
			}
			if (data.drawAnims.ContainsKey("Appear"))
			{
				return data.drawAnims["Appear"];
			}
			data = null;
			return null;
		}
	}

	public virtual float minWidth => 0f;

	public virtual float preferredWidth => unwrappedBottomRightTextBounds.x;

	public virtual float flexibleWidth => -1f;

	public virtual float minHeight => 0f;

	public virtual float preferredHeight => 0f - rawBottomRightTextBounds.y;

	public virtual float flexibleHeight => 0f - rawBottomRightTextBounds.y;

	public virtual int layoutPriority => 0;

	public event OnCompleteAction OnCompleteEvent;

	public event OnUndrawnAction OnUndrawnEvent;

	public event OnRebuildAction OnRebuildEvent;

	public event OnPrintAction OnPrintEvent;

	public event OnCustomAction OnCustomEvent;

	public event OnVertexModAction OnVertexMod;

	public event OnPreParseAction OnPreParse;

	private void OnApplicationFocus(bool focused)
	{
		if (!Application.runInBackground)
		{
			applicationFocused = focused;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = data.boundsColor;
		RecalculateBounds();
		Gizmos.DrawLine(topLeftBounds, topRightBounds);
		Gizmos.DrawLine(topLeftBounds, bottomLeftBounds);
		Gizmos.DrawLine(topRightBounds, bottomRightBounds);
		Gizmos.DrawLine(bottomLeftBounds, bottomRightBounds);
		Gizmos.color = data.textBoundsColor;
		Gizmos.DrawLine(topLeftTextBounds, topRightTextBounds);
		Gizmos.DrawLine(topLeftTextBounds, bottomLeftTextBounds);
		Gizmos.DrawLine(topRightTextBounds, bottomRightTextBounds);
		Gizmos.DrawLine(bottomLeftTextBounds, bottomRightTextBounds);
		Gizmos.color = data.finalTextBoundsColor;
		Gizmos.DrawLine(finalTopLeftTextBounds, finalTopRightTextBounds);
		Gizmos.DrawLine(finalTopLeftTextBounds, finalBottomLeftTextBounds);
		Gizmos.DrawLine(finalTopRightTextBounds, finalBottomRightTextBounds);
		Gizmos.DrawLine(finalBottomLeftTextBounds, finalBottomRightTextBounds);
		Gizmos.color = data.boundsColor;
	}

	public string RemoveEmoji(string x)
	{
		return Regex.Replace(x, "[#*0-9]\\uFE0F\\u20E3|[\\u00A9\\u00AE\\u203C\\u2049\\u2122\\u2139\\u2194-\\u2199\\u21A9\\u21AA\\u231A\\u231B\\u2328\\u23CF\\u23E9-\\u23F3\\u23F8-\\u23FA\\u24C2\\u25AA\\u25AB\\u25B6\\u25C0\\u25FB-\\u25FE\\u2600-\\u2604\\u260E\\u2611\\u2614\\u2615\\u2618]|\\u261D(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\u2620\\u2622\\u2623\\u2626\\u262A\\u262E\\u262F\\u2638-\\u263A\\u2640\\u2642\\u2648-\\u2653\\u265F\\u2660\\u2663\\u2665\\u2666\\u2668\\u267B\\u267E\\u267F\\u2692-\\u2697\\u2699\\u269B\\u269C\\u26A0\\u26A1\\u26AA\\u26AB\\u26B0\\u26B1\\u26BD\\u26BE\\u26C4\\u26C5\\u26C8\\u26CE\\u26CF\\u26D1\\u26D3\\u26D4\\u26E9\\u26EA\\u26F0-\\u26F5\\u26F7\\u26F8]|\\u26F9(?:\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?|\\uFE0F\\u200D[\\u2640\\u2642]\\uFE0F)?|[\\u26FA\\u26FD\\u2702\\u2705\\u2708\\u2709]|[\\u270A-\\u270D](?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\u270F\\u2712\\u2714\\u2716\\u271D\\u2721\\u2728\\u2733\\u2734\\u2744\\u2747\\u274C\\u274E\\u2753-\\u2755\\u2757\\u2763\\u2764\\u2795-\\u2797\\u27A1\\u27B0\\u27BF\\u2934\\u2935\\u2B05-\\u2B07\\u2B1B\\u2B1C\\u2B50\\u2B55\\u3030\\u303D\\u3297\\u3299]|\\uD83C(?:[\\uDC04\\uDCCF\\uDD70\\uDD71\\uDD7E\\uDD7F\\uDD8E\\uDD91-\\uDD9A]|\\uDDE6\\uD83C[\\uDDE8-\\uDDEC\\uDDEE\\uDDF1\\uDDF2\\uDDF4\\uDDF6-\\uDDFA\\uDDFC\\uDDFD\\uDDFF]|\\uDDE7\\uD83C[\\uDDE6\\uDDE7\\uDDE9-\\uDDEF\\uDDF1-\\uDDF4\\uDDF6-\\uDDF9\\uDDFB\\uDDFC\\uDDFE\\uDDFF]|\\uDDE8\\uD83C[\\uDDE6\\uDDE8\\uDDE9\\uDDEB-\\uDDEE\\uDDF0-\\uDDF5\\uDDF7\\uDDFA-\\uDDFF]|\\uDDE9\\uD83C[\\uDDEA\\uDDEC\\uDDEF\\uDDF0\\uDDF2\\uDDF4\\uDDFF]|\\uDDEA\\uD83C[\\uDDE6\\uDDE8\\uDDEA\\uDDEC\\uDDED\\uDDF7-\\uDDFA]|\\uDDEB\\uD83C[\\uDDEE-\\uDDF0\\uDDF2\\uDDF4\\uDDF7]|\\uDDEC\\uD83C[\\uDDE6\\uDDE7\\uDDE9-\\uDDEE\\uDDF1-\\uDDF3\\uDDF5-\\uDDFA\\uDDFC\\uDDFE]|\\uDDED\\uD83C[\\uDDF0\\uDDF2\\uDDF3\\uDDF7\\uDDF9\\uDDFA]|\\uDDEE\\uD83C[\\uDDE8-\\uDDEA\\uDDF1-\\uDDF4\\uDDF6-\\uDDF9]|\\uDDEF\\uD83C[\\uDDEA\\uDDF2\\uDDF4\\uDDF5]|\\uDDF0\\uD83C[\\uDDEA\\uDDEC-\\uDDEE\\uDDF2\\uDDF3\\uDDF5\\uDDF7\\uDDFC\\uDDFE\\uDDFF]|\\uDDF1\\uD83C[\\uDDE6-\\uDDE8\\uDDEE\\uDDF0\\uDDF7-\\uDDFB\\uDDFE]|\\uDDF2\\uD83C[\\uDDE6\\uDDE8-\\uDDED\\uDDF0-\\uDDFF]|\\uDDF3\\uD83C[\\uDDE6\\uDDE8\\uDDEA-\\uDDEC\\uDDEE\\uDDF1\\uDDF4\\uDDF5\\uDDF7\\uDDFA\\uDDFF]|\\uDDF4\\uD83C\\uDDF2|\\uDDF5\\uD83C[\\uDDE6\\uDDEA-\\uDDED\\uDDF0-\\uDDF3\\uDDF7-\\uDDF9\\uDDFC\\uDDFE]|\\uDDF6\\uD83C\\uDDE6|\\uDDF7\\uD83C[\\uDDEA\\uDDF4\\uDDF8\\uDDFA\\uDDFC]|\\uDDF8\\uD83C[\\uDDE6-\\uDDEA\\uDDEC-\\uDDF4\\uDDF7-\\uDDF9\\uDDFB\\uDDFD-\\uDDFF]|\\uDDF9\\uD83C[\\uDDE6\\uDDE8\\uDDE9\\uDDEB-\\uDDED\\uDDEF-\\uDDF4\\uDDF7\\uDDF9\\uDDFB\\uDDFC\\uDDFF]|\\uDDFA\\uD83C[\\uDDE6\\uDDEC\\uDDF2\\uDDF3\\uDDF8\\uDDFE\\uDDFF]|\\uDDFB\\uD83C[\\uDDE6\\uDDE8\\uDDEA\\uDDEC\\uDDEE\\uDDF3\\uDDFA]|\\uDDFC\\uD83C[\\uDDEB\\uDDF8]|\\uDDFD\\uD83C\\uDDF0|\\uDDFE\\uD83C[\\uDDEA\\uDDF9]|\\uDDFF\\uD83C[\\uDDE6\\uDDF2\\uDDFC]|[\\uDE01\\uDE02\\uDE1A\\uDE2F\\uDE32-\\uDE3A\\uDE50\\uDE51\\uDF00-\\uDF21\\uDF24-\\uDF84]|\\uDF85(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDF86-\\uDF93\\uDF96\\uDF97\\uDF99-\\uDF9B\\uDF9E-\\uDFC1]|\\uDFC2(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDFC3\\uDFC4](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDFC5\\uDFC6]|\\uDFC7(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDFC8\\uDFC9]|\\uDFCA(?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDFCB\\uDFCC](?:\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?|\\uFE0F\\u200D[\\u2640\\u2642]\\uFE0F)?|[\\uDFCD-\\uDFF0]|\\uDFF3(?:\\uFE0F\\u200D\\uD83C\\uDF08)?|\\uDFF4(?:\\u200D\\u2620\\uFE0F|\\uDB40\\uDC67\\uDB40\\uDC62\\uDB40(?:\\uDC65\\uDB40\\uDC6E\\uDB40\\uDC67|\\uDC73\\uDB40\\uDC63\\uDB40\\uDC74|\\uDC77\\uDB40\\uDC6C\\uDB40\\uDC73)\\uDB40\\uDC7F)?|[\\uDFF5\\uDFF7-\\uDFFF])|\\uD83D(?:[\\uDC00-\\uDC14]|\\uDC15(?:\\u200D\\uD83E\\uDDBA)?|[\\uDC16-\\uDC40]|\\uDC41(?:\\uFE0F\\u200D\\uD83D\\uDDE8\\uFE0F)?|[\\uDC42\\uDC43](?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDC44\\uDC45]|[\\uDC46-\\uDC50](?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDC51-\\uDC65]|[\\uDC66\\uDC67](?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDC68(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\u2764\\uFE0F\\u200D\\uD83D(?:\\uDC8B\\u200D\\uD83D)?\\uDC68|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D(?:\\uDC66(?:\\u200D\\uD83D\\uDC66)?|\\uDC67(?:\\u200D\\uD83D[\\uDC66\\uDC67])?|[\\uDC68\\uDC69]\\u200D\\uD83D(?:\\uDC66(?:\\u200D\\uD83D\\uDC66)?|\\uDC67(?:\\u200D\\uD83D[\\uDC66\\uDC67])?)|[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92])|\\uD83E[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])|\\uD83C(?:\\uDFFB(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92]|\\uD83E[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD]))?|\\uDFFC(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92]|\\uD83E(?:\\uDD1D\\u200D\\uD83D\\uDC68\\uD83C\\uDFFB|[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])))?|\\uDFFD(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92]|\\uD83E(?:\\uDD1D\\u200D\\uD83D\\uDC68\\uD83C[\\uDFFB\\uDFFC]|[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])))?|\\uDFFE(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92]|\\uD83E(?:\\uDD1D\\u200D\\uD83D\\uDC68\\uD83C[\\uDFFB-\\uDFFD]|[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])))?|\\uDFFF(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92]|\\uD83E(?:\\uDD1D\\u200D\\uD83D\\uDC68\\uD83C[\\uDFFB-\\uDFFE]|[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])))?))?|\\uDC69(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\u2764\\uFE0F\\u200D\\uD83D(?:\\uDC8B\\u200D\\uD83D)?[\\uDC68\\uDC69]|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D(?:\\uDC66(?:\\u200D\\uD83D\\uDC66)?|\\uDC67(?:\\u200D\\uD83D[\\uDC66\\uDC67])?|\\uDC69\\u200D\\uD83D(?:\\uDC66(?:\\u200D\\uD83D\\uDC66)?|\\uDC67(?:\\u200D\\uD83D[\\uDC66\\uDC67])?)|[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92])|\\uD83E[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])|\\uD83C(?:\\uDFFB(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92]|\\uD83E(?:\\uDD1D\\u200D\\uD83D\\uDC68\\uD83C[\\uDFFC-\\uDFFF]|[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])))?|\\uDFFC(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92]|\\uD83E(?:\\uDD1D\\u200D\\uD83D(?:\\uDC68\\uD83C[\\uDFFB\\uDFFD-\\uDFFF]|\\uDC69\\uD83C\\uDFFB)|[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])))?|\\uDFFD(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92]|\\uD83E(?:\\uDD1D\\u200D\\uD83D(?:\\uDC68\\uD83C[\\uDFFB\\uDFFC\\uDFFE\\uDFFF]|\\uDC69\\uD83C[\\uDFFB\\uDFFC])|[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])))?|\\uDFFE(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92]|\\uD83E(?:\\uDD1D\\u200D\\uD83D(?:\\uDC68\\uD83C[\\uDFFB-\\uDFFD\\uDFFF]|\\uDC69\\uD83C[\\uDFFB-\\uDFFD])|[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])))?|\\uDFFF(?:\\u200D(?:[\\u2695\\u2696\\u2708]\\uFE0F|\\uD83C[\\uDF3E\\uDF73\\uDF93\\uDFA4\\uDFA8\\uDFEB\\uDFED]|\\uD83D[\\uDCBB\\uDCBC\\uDD27\\uDD2C\\uDE80\\uDE92]|\\uD83E(?:\\uDD1D\\u200D\\uD83D[\\uDC68\\uDC69]\\uD83C[\\uDFFB-\\uDFFE]|[\\uDDAF-\\uDDB3\\uDDBC\\uDDBD])))?))?|\\uDC6A|[\\uDC6B-\\uDC6D](?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDC6E(?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|\\uDC6F(?:\\u200D[\\u2640\\u2642]\\uFE0F)?|\\uDC70(?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDC71(?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|\\uDC72(?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDC73(?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDC74-\\uDC76](?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDC77(?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|\\uDC78(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDC79-\\uDC7B]|\\uDC7C(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDC7D-\\uDC80]|[\\uDC81\\uDC82](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|\\uDC83(?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDC84|\\uDC85(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDC86\\uDC87](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDC88-\\uDCA9]|\\uDCAA(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDCAB-\\uDCFD\\uDCFF-\\uDD3D\\uDD49-\\uDD4E\\uDD50-\\uDD67\\uDD6F\\uDD70\\uDD73]|\\uDD74(?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDD75(?:\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?|\\uFE0F\\u200D[\\u2640\\u2642]\\uFE0F)?|[\\uDD76-\\uDD79]|\\uDD7A(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDD87\\uDD8A-\\uDD8D]|[\\uDD90\\uDD95\\uDD96](?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDDA4\\uDDA5\\uDDA8\\uDDB1\\uDDB2\\uDDBC\\uDDC2-\\uDDC4\\uDDD1-\\uDDD3\\uDDDC-\\uDDDE\\uDDE1\\uDDE3\\uDDE8\\uDDEF\\uDDF3\\uDDFA-\\uDE44]|[\\uDE45-\\uDE47](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDE48-\\uDE4A]|\\uDE4B(?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|\\uDE4C(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDE4D\\uDE4E](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|\\uDE4F(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDE80-\\uDEA2]|\\uDEA3(?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDEA4-\\uDEB3]|[\\uDEB4-\\uDEB6](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDEB7-\\uDEBF]|\\uDEC0(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDEC1-\\uDEC5\\uDECB]|\\uDECC(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDECD-\\uDED2\\uDED5\\uDEE0-\\uDEE5\\uDEE9\\uDEEB\\uDEEC\\uDEF0\\uDEF3-\\uDEFA\\uDFE0-\\uDFEB])|\\uD83E(?:[\\uDD0D\\uDD0E]|\\uDD0F(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDD10-\\uDD17]|[\\uDD18-\\uDD1C](?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDD1D|[\\uDD1E\\uDD1F](?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDD20-\\uDD25]|\\uDD26(?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDD27-\\uDD2F]|[\\uDD30-\\uDD36](?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDD37(?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDD38\\uDD39](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|\\uDD3A|\\uDD3C(?:\\u200D[\\u2640\\u2642]\\uFE0F)?|[\\uDD3D\\uDD3E](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDD3F-\\uDD45\\uDD47-\\uDD71\\uDD73-\\uDD76\\uDD7A-\\uDDA2\\uDDA5-\\uDDAA\\uDDAE-\\uDDB4]|[\\uDDB5\\uDDB6](?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDDB7|[\\uDDB8\\uDDB9](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|\\uDDBA|\\uDDBB(?:\\uD83C[\\uDFFB-\\uDFFF])?|[\\uDDBC-\\uDDCA]|[\\uDDCD-\\uDDCF](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|\\uDDD0|\\uDDD1(?:\\u200D\\uD83E\\uDD1D\\u200D\\uD83E\\uDDD1|\\uD83C(?:\\uDFFB(?:\\u200D\\uD83E\\uDD1D\\u200D\\uD83E\\uDDD1\\uD83C\\uDFFB)?|\\uDFFC(?:\\u200D\\uD83E\\uDD1D\\u200D\\uD83E\\uDDD1\\uD83C[\\uDFFB\\uDFFC])?|\\uDFFD(?:\\u200D\\uD83E\\uDD1D\\u200D\\uD83E\\uDDD1\\uD83C[\\uDFFB-\\uDFFD])?|\\uDFFE(?:\\u200D\\uD83E\\uDD1D\\u200D\\uD83E\\uDDD1\\uD83C[\\uDFFB-\\uDFFE])?|\\uDFFF(?:\\u200D\\uD83E\\uDD1D\\u200D\\uD83E\\uDDD1\\uD83C[\\uDFFB-\\uDFFF])?))?|[\\uDDD2-\\uDDD5](?:\\uD83C[\\uDFFB-\\uDFFF])?|\\uDDD6(?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDDD7-\\uDDDD](?:\\u200D[\\u2640\\u2642]\\uFE0F|\\uD83C[\\uDFFB-\\uDFFF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?)?|[\\uDDDE\\uDDDF](?:\\u200D[\\u2640\\u2642]\\uFE0F)?|[\\uDDE0-\\uDDFF\\uDE70-\\uDE73\\uDE78-\\uDE7A\\uDE80-\\uDE82\\uDE90-\\uDE95])", string.Empty);
	}

	private void RemoveLastCharacter()
	{
	}

	private void OnFontTextureRebuilt(Font changedFont)
	{
		if (textMesh != null && hyphenedText.Length > 0 && allFonts.Contains(changedFont))
		{
			fontTextureJustRebuilt = true;
			float startUnReadTime = currentUnReadTime;
			if (unreading)
			{
				Rebuild(currentReadTime, reading || autoRead);
				UnRead(startUnReadTime);
			}
			else
			{
				Rebuild(currentReadTime, reading || autoRead);
			}
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if (this != null && t.gameObject.activeInHierarchy && base.enabled)
		{
			StartCoroutine(WaitFrameThenRebuild());
		}
	}

	private IEnumerator WaitFrameThenRebuild()
	{
		yield return null;
		SpecialRebuild();
	}

	private void Awake()
	{
	}

	private void SpecialRebuild()
	{
		if (Application.isPlaying)
		{
			if (unreading)
			{
				if (currentUnReadTime <= 0f)
				{
					Rebuild(-1f, readAutomatically: false, executeEvents: false);
					UnRead();
				}
				else
				{
					float startUnReadTime = currentUnReadTime;
					Rebuild(-1f, readAutomatically: false, executeEvents: false);
					UnRead(startUnReadTime);
				}
			}
			else if (callReadFunction && rememberReadPosition)
			{
				if (currentReadTime == 0f)
				{
					Rebuild(autoRead || reading);
				}
				else if (currentReadTime >= totalReadTime)
				{
					Rebuild(currentReadTime, readAutomatically: true, executeEvents: false);
				}
				else
				{
					Rebuild(currentReadTime, autoRead || reading);
				}
			}
			else
			{
				Rebuild(autoRead);
			}
		}
		else
		{
			Rebuild();
		}
	}

	private void OnEnable()
	{
		Init();
		SpecialRebuild();
	}

	private void Start()
	{
		textMesh = new Mesh();
		textMesh.MarkDynamic();
	}

	private void OnDisable()
	{
		UnInit();
		if (uiMode)
		{
			UnityEngine.Object.DestroyImmediate(textMesh);
			c.Clear();
		}
		else
		{
			UnityEngine.Object.DestroyImmediate(f.sharedMesh);
		}
	}

	private void OnDestroy()
	{
	}

	private void Init()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
		Font.textureRebuilt += OnFontTextureRebuilt;
	}

	private void UnInit()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		Font.textureRebuilt -= OnFontTextureRebuilt;
		StopReadRoutine();
	}

	private void OnUndoRedo()
	{
		Rebuild();
	}

	private void StopReadRoutine()
	{
		reading = false;
		if (readRoutine != null)
		{
			StopCoroutine(readRoutine);
		}
	}

	public void OnValidate()
	{
		if (_color32 != Color.white)
		{
			_color = _color32;
			_color32 = Color.white;
		}
		if (font != null && !font.dynamic)
		{
			if (font.fontSize > 0)
			{
				quality = font.fontSize;
			}
			else
			{
				Debug.Log("You're probably using a custom font! \n Unity's got a bug where custom fonts have their size set to 0 by default and there's no way to change that! So to avoid this error, here's a solution: \n * Drag any font into Unity. Set it to be 'Unicode' or 'ASCII' in the inspector, depending on the characters you want your font to have. \n * Set 'Font Size' to whatever size you want 'quality' to be locked at. \n * Click the gear in the corner of the inspector and 'Create Editable Copy'. \n * Now, under the array of 'Character Rects', change size to 0 to clear everything. \n * Now you have a brand new font to edit that has a font size that's not zero! Yeah!");
			}
			style = FontStyle.Normal;
		}
		if (size < 0.0001f)
		{
			size = 0.0001f;
		}
		if (readDelay < 0f)
		{
			readDelay = 0f;
		}
		if (autoWrap < 0f)
		{
			autoWrap = 0f;
		}
		if (verticalLimit < 0f)
		{
			verticalLimit = 0f;
		}
		if (minPitch > maxPitch)
		{
			minPitch = maxPitch;
		}
		if (maxPitch < minPitch)
		{
			maxPitch = minPitch;
		}
		if (speedReadScale < 0.01f)
		{
			speedReadScale = 0.01f;
		}
	}

	public void InitializeFont()
	{
		if (uiMode)
		{
			if (font == null && textMaterial == null)
			{
				size = 32f;
				color = new Color32(50, 50, 50, byte.MaxValue);
			}
			if (textMaterial == null)
			{
				textMaterial = Resources.Load<Material>("DefaultSTMMaterials/UIDefault");
			}
			if (font == null)
			{
				if (data.defaultFont != null)
				{
					font = data.defaultFont;
				}
				else
				{
					font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				}
			}
			return;
		}
		if (font == null)
		{
			if (data.defaultFont != null)
			{
				font = data.defaultFont;
			}
			else
			{
				font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			}
		}
		if (textMaterial == null)
		{
			textMaterial = Resources.Load<Material>("DefaultSTMMaterials/Default");
		}
	}

	public static void RebuildAll()
	{
		SuperTextMesh[] array = UnityEngine.Object.FindObjectsByType<SuperTextMesh>(FindObjectsSortMode.InstanceID);
		int i = 0;
		for (int num = array.Length; i < num; i++)
		{
			array[i].Rebuild();
		}
	}

	public void Rebuild()
	{
		Rebuild(0f, autoRead);
	}

	public void Rebuild(bool readAutomatically)
	{
		Rebuild(0f, readAutomatically);
	}

	public void Rebuild(float startTime)
	{
		Rebuild(startTime, readAutomatically: true);
	}

	public void Rebuild(float startTime, bool readAutomatically)
	{
		Rebuild(startTime, readAutomatically, executeEvents: true);
	}

	public void Rebuild(float startTime, bool readAutomatically, bool executeEvents)
	{
		if (currentlyRebuilding)
		{
			return;
		}
		currentlyRebuilding = true;
		doEvents = executeEvents;
		if (uiMode)
		{
			LayoutRebuilder.MarkLayoutForRebuild(tr);
		}
		if (uiMode && autoQuality)
		{
			parentCanvas = t.GetComponentInParent<Canvas>();
			if (parentCanvas != null)
			{
				quality = (int)Mathf.Ceil(size * parentCanvas.scaleFactor);
			}
			else
			{
				quality = (int)Mathf.Ceil(size);
			}
		}
		if (!fontTextureJustRebuilt)
		{
			if (onRebuildEvent != null && onRebuildEvent.GetPersistentEventCount() > 0)
			{
				onRebuildEvent.Invoke();
			}
			if (this.OnRebuildEvent != null)
			{
				this.OnRebuildEvent();
			}
		}
		if (startTime < totalReadTime)
		{
			_pauseCount = 0;
		}
		autoPauseStopPoint = 0f;
		_currentPauseCount = 0;
		timeDrawn = ((GetTime - startTime < 0f) ? 0f : startTime);
		currentReadTime = startTime;
		totalReadTime = 0f;
		reading = false;
		unreading = false;
		speedReading = false;
		skippingToEnd = false;
		InitializeFont();
		RebuildTextInfo();
		if (audioSource != null)
		{
			audioSource.loop = false;
			audioSource.playOnAwake = false;
		}
		if (callReadFunction && Application.isPlaying)
		{
			if (readAutomatically)
			{
				Read(startTime);
			}
			else
			{
				SetMesh(0f);
			}
		}
		else
		{
			StopReadRoutine();
			ShowAllText(unreadingMesh: false, forceCompleteEvent: true);
		}
		ApplyMaterials();
		currentlyRebuilding = false;
		fontTextureJustRebuilt = false;
	}

	internal void Update()
	{
		if (font != null && textMaterial != null && textMesh != null)
		{
			if (!reading && (areWeAnimating || forceAnimation) && currentReadTime >= totalReadTime)
			{
				currentReadTime += GetDeltaTime;
			}
			if (!reading && !unreading && (areWeAnimating || forceAnimation) && (readDelay == 0f || currentReadTime >= totalReadTime))
			{
				SetMesh(-1f);
			}
		}
	}

	private void UpdatePreReadMesh(bool undrawingMesh)
	{
		UpdateMesh(0f);
		int num = hyphenedText.Length * 4;
		if (startCol32.Length != num)
		{
			Array.Resize(ref startCol32, num);
		}
		if (startVerts.Length != num)
		{
			Array.Resize(ref startVerts, num);
		}
		STMDrawAnimData undrawAnim = UndrawAnim;
		int i = 0;
		for (int length = hyphenedText.Length; i < length; i++)
		{
			UpdateMesh_info = info[i];
			STMDrawAnimData sTMDrawAnimData = (undrawingMesh ? undrawAnim : UpdateMesh_info.drawAnimData);
			if (UpdateMesh_info.drawAnimData.startColor != Color.clear)
			{
				startCol32[4 * i] = sTMDrawAnimData.startColor;
				startCol32[4 * i + 1] = sTMDrawAnimData.startColor;
				startCol32[4 * i + 2] = sTMDrawAnimData.startColor;
				startCol32[4 * i + 3] = sTMDrawAnimData.startColor;
			}
			else
			{
				startCol32[4 * i].r = endCol32[4 * i].r;
				startCol32[4 * i].g = endCol32[4 * i].g;
				startCol32[4 * i].b = endCol32[4 * i].b;
				startCol32[4 * i].a = 0;
				startCol32[4 * i + 1].r = endCol32[4 * i + 1].r;
				startCol32[4 * i + 1].g = endCol32[4 * i + 1].g;
				startCol32[4 * i + 1].b = endCol32[4 * i + 1].b;
				startCol32[4 * i + 1].a = 0;
				startCol32[4 * i + 2].r = endCol32[4 * i + 2].r;
				startCol32[4 * i + 2].g = endCol32[4 * i + 2].g;
				startCol32[4 * i + 2].b = endCol32[4 * i + 2].b;
				startCol32[4 * i + 2].a = 0;
				startCol32[4 * i + 3].r = endCol32[4 * i + 3].r;
				startCol32[4 * i + 3].g = endCol32[4 * i + 3].g;
				startCol32[4 * i + 3].b = endCol32[4 * i + 3].b;
				startCol32[4 * i + 3].a = 0;
			}
			Vector3 vector = new Vector3((endVerts[4 * i].x + endVerts[4 * i + 1].x + endVerts[4 * i + 2].x + endVerts[4 * i + 3].x) * 0.25f, (endVerts[4 * i].y + endVerts[4 * i + 1].y + endVerts[4 * i + 2].y + endVerts[4 * i + 3].y) * 0.25f, (endVerts[4 * i].z + endVerts[4 * i + 1].z + endVerts[4 * i + 2].z + endVerts[4 * i + 3].z) * 0.25f);
			startVerts[4 * i] = Vector3.Scale(endVerts[4 * i] - vector, sTMDrawAnimData.startScale) + vector + sTMDrawAnimData.startOffset * UpdateMesh_info.size.y;
			startVerts[4 * i + 1] = Vector3.Scale(endVerts[4 * i + 1] - vector, sTMDrawAnimData.startScale) + vector + sTMDrawAnimData.startOffset * UpdateMesh_info.size.y;
			startVerts[4 * i + 2] = Vector3.Scale(endVerts[4 * i + 2] - vector, sTMDrawAnimData.startScale) + vector + sTMDrawAnimData.startOffset * UpdateMesh_info.size.y;
			startVerts[4 * i + 3] = Vector3.Scale(endVerts[4 * i + 3] - vector, sTMDrawAnimData.startScale) + vector + sTMDrawAnimData.startOffset * UpdateMesh_info.size.y;
		}
	}

	public void Read()
	{
		Read(0f);
	}

	public void Read(float startTime)
	{
		StopReadRoutine();
		readRoutine = StartCoroutine(ReadOutText(startTime));
	}

	public void Unread(float startUnReadTime = 0f)
	{
		UnRead(startUnReadTime);
	}

	public void Undraw(float startUnReadTime = 0f)
	{
		UnRead(startUnReadTime);
	}

	public void UnDraw(float startUnReadTime = 0f)
	{
		UnRead(startUnReadTime);
	}

	public void UnRead(float startUnReadTime = 0f)
	{
		readRoutine = StartCoroutine(UnReadOutText(startUnReadTime));
	}

	public void SpeedRead()
	{
		if (reading)
		{
			speedReading = true;
		}
	}

	public void SkipToEnd()
	{
		if (reading)
		{
			skippingToEnd = true;
		}
	}

	public void RegularRead()
	{
		speedReading = false;
	}

	public void ShowAllText()
	{
		ShowAllText(unreadingMesh: false, forceCompleteEvent: false);
	}

	private void ShowAllText(bool unreadingMesh, bool forceCompleteEvent)
	{
		speedReading = false;
		if (unreadingMesh)
		{
			unreading = false;
			if (currentUnReadTime < totalUnreadTime)
			{
				currentUnReadTime = totalUnreadTime;
			}
		}
		else if (currentReadTime < totalReadTime)
		{
			currentReadTime = totalReadTime;
		}
		wasReadingBefore = reading;
		SetMesh(unreadingMesh ? totalUnreadTime : totalReadTime, unreadingMesh);
		StopReadRoutine();
		if (!unreadingMesh)
		{
			if (wasReadingBefore || forceCompleteEvent)
			{
				if (onCompleteEvent != null)
				{
					onCompleteEvent.Invoke();
				}
				if (this.OnCompleteEvent != null)
				{
					this.OnCompleteEvent();
				}
			}
		}
		else
		{
			unreading = true;
			if (onUndrawnEvent != null)
			{
				onUndrawnEvent.Invoke();
			}
			if (this.OnUndrawnEvent != null)
			{
				this.OnUndrawnEvent();
			}
		}
	}

	public void Append(string newText)
	{
		_text += newText;
		Rebuild(totalReadTime, readAutomatically: true);
	}

	public bool Continue()
	{
		if (currentPauseCount > pauseCount)
		{
			_pauseCount++;
			Rebuild(totalReadTime, readAutomatically: true);
			return true;
		}
		return false;
	}

	public bool UndoContinue()
	{
		if (pauseCount > 0)
		{
			int num = pauseCount - 1;
			Rebuild(0f, readAutomatically: true);
			for (int i = 0; i < num; i++)
			{
				Continue();
			}
			return true;
		}
		return false;
	}

	private void UpdateDrawnMesh(float myTime, bool undrawingMesh)
	{
		UpdateMesh(myTime);
		UpdatePreReadMesh(undrawingMesh);
		STMDrawAnimData undrawAnim = UndrawAnim;
		int num = hyphenedText.Length * 4;
		if (midVerts.Length != num)
		{
			Array.Resize(ref midVerts, num);
		}
		if (midCol32.Length != num)
		{
			Array.Resize(ref midCol32, num);
		}
		int i = 0;
		for (int length = hyphenedText.Length; i < length; i++)
		{
			UpdateMesh_info = info[i];
			STMDrawAnimData sTMDrawAnimData = (undrawingMesh ? undrawAnim : UpdateMesh_info.drawAnimData);
			float num2 = (undrawingMesh ? UpdateMesh_info.unreadTime : UpdateMesh_info.readTime);
			float num3 = ((sTMDrawAnimData.animTime == 0f) ? 1E-07f : sTMDrawAnimData.animTime);
			float num4 = ((sTMDrawAnimData.fadeTime == 0f) ? 1E-07f : sTMDrawAnimData.fadeTime);
			float num5 = (myTime - num2) / num3;
			float num6 = (myTime - num2) / num4;
			if (undrawingMesh)
			{
				num5 = 1f - num5;
				num6 = ((sTMDrawAnimData.fadeTime != 0f) ? (1f - num6) : 1f);
			}
			midVerts[4 * i] = LerpWithoutClamp(startVerts[4 * i], endVerts[4 * i], sTMDrawAnimData.animCurve.Evaluate(num5));
			midVerts[4 * i + 1] = LerpWithoutClamp(startVerts[4 * i + 1], endVerts[4 * i + 1], sTMDrawAnimData.animCurve.Evaluate(num5));
			midVerts[4 * i + 2] = LerpWithoutClamp(startVerts[4 * i + 2], endVerts[4 * i + 2], sTMDrawAnimData.animCurve.Evaluate(num5));
			midVerts[4 * i + 3] = LerpWithoutClamp(startVerts[4 * i + 3], endVerts[4 * i + 3], sTMDrawAnimData.animCurve.Evaluate(num5));
			midCol32[4 * i] = Color.Lerp(startCol32[4 * i], endCol32[4 * i], sTMDrawAnimData.fadeCurve.Evaluate(num6));
			midCol32[4 * i + 1] = Color.Lerp(startCol32[4 * i + 1], endCol32[4 * i + 1], sTMDrawAnimData.fadeCurve.Evaluate(num6));
			midCol32[4 * i + 2] = Color.Lerp(startCol32[4 * i + 2], endCol32[4 * i + 2], sTMDrawAnimData.fadeCurve.Evaluate(num6));
			midCol32[4 * i + 3] = Color.Lerp(startCol32[4 * i + 3], endCol32[4 * i + 3], sTMDrawAnimData.fadeCurve.Evaluate(num6));
		}
	}

	private Vector3 LerpWithoutClamp(Vector3 A, Vector3 B, float t)
	{
		return A + (B - A) * t;
	}

	private bool AreColorsTheSame(Color32 col1, Color32 col2)
	{
		if (col1.r == col2.r && col1.g == col2.g && col1.b == col2.b && col1.a == col2.a)
		{
			return true;
		}
		return false;
	}

	private IEnumerator ReadOutText(float startTime)
	{
		reading = true;
		currentReadTime = startTime;
		if (startTime.Equals(0f))
		{
			latestNumber = -1;
			lowestDrawnPosition = 0f;
			lowestDrawnPositionRaw = 0f;
			furthestDrawnPosition = 0f;
		}
		for (int i = 0; i < infoCount; i++)
		{
			if (i > latestNumber)
			{
				info[i].invoked = false;
			}
		}
		while (currentReadTime < totalReadTime)
		{
			float getDeltaTime = GetDeltaTime2;
			getDeltaTime *= (speedReading ? speedReadScale : 1f);
			currentReadTime += getDeltaTime;
			if (skippingToEnd)
			{
				currentReadTime = totalReadTime;
			}
			SetMesh(currentReadTime);
			yield return null;
		}
		if (latestNumber != hyphenedText.Length - 1)
		{
			PlaySound(hyphenedText.Length - 1);
			DoEvent(hyphenedText.Length - 1);
		}
		ShowAllText();
	}

	private IEnumerator UnReadOutText(float startUnReadTime = 0f)
	{
		unreading = true;
		currentUnReadTime = startUnReadTime;
		while (currentUnReadTime < totalUnreadTime)
		{
			SetMesh(currentUnReadTime, undrawingMesh: true);
			currentUnReadTime += GetDeltaTime2;
			yield return null;
		}
		ShowAllText(unreadingMesh: true, forceCompleteEvent: false);
	}

	private void DoEvent(int i)
	{
		if (!doEvents)
		{
			return;
		}
		DoEvent_info = info[i];
		if (DoEvent_info.ev.Count > 0)
		{
			int j = 0;
			for (int count = DoEvent_info.ev.Count; j < count; j++)
			{
				if (onCustomEvent != null)
				{
					onCustomEvent.Invoke(DoEvent_info.ev[j], DoEvent_info);
				}
				if (this.OnCustomEvent != null)
				{
					this.OnCustomEvent(DoEvent_info.ev[j], DoEvent_info);
				}
			}
			DoEvent_info.ev.Clear();
		}
		if (DoEvent_info.ev2.Count <= 0)
		{
			return;
		}
		int k = 0;
		for (int count2 = DoEvent_info.ev2.Count; k < count2; k++)
		{
			if (onCustomEvent != null)
			{
				onCustomEvent.Invoke(DoEvent_info.ev2[k], DoEvent_info);
			}
			if (this.OnCustomEvent != null)
			{
				this.OnCustomEvent(DoEvent_info.ev2[k], DoEvent_info);
			}
		}
		DoEvent_info.ev2.Clear();
	}

	public virtual void PlaySound(int i)
	{
		if (!(audioSource != null))
		{
			return;
		}
		PlaySound_info = info[i];
		if (!PlaySound_info.stopPreviousSound && audioSource.isPlaying)
		{
			return;
		}
		audioSource.Stop();
		string nameToSearch = (PlaySound_info.isQuad ? PlaySound_info.quadData.name : hyphenedText[i].ToString());
		AudioClip audioClip = null;
		if (PlaySound_info.soundClipData != null)
		{
			STMSoundClipData.AutoClip autoClip = PlaySound_info.soundClipData.clips.Find((STMSoundClipData.AutoClip x) => ((x.type == STMSoundClipData.AutoClip.Type.Quad) ? x.quadName.ToLower() : x.character.ToString().ToLower()) == nameToSearch);
			if (autoClip != null)
			{
				audioClip = autoClip.clip;
			}
		}
		STMAutoClipData sTMAutoClipData = null;
		if (data.autoClips.ContainsKey(nameToSearch.ToUpper()))
		{
			sTMAutoClipData = data.autoClips[nameToSearch.ToUpper()];
		}
		else if (data.autoClips.ContainsKey(nameToSearch))
		{
			sTMAutoClipData = data.autoClips[nameToSearch];
		}
		if (audioClip != null)
		{
			audioSource.clip = audioClip;
		}
		else if (sTMAutoClipData != null)
		{
			audioSource.clip = sTMAutoClipData.clip;
		}
		else if (PlaySound_info.audioClipData != null)
		{
			audioSource.clip = ((PlaySound_info.audioClipData.clips.Length != 0) ? PlaySound_info.audioClipData.clips[UnityEngine.Random.Range(0, PlaySound_info.audioClipData.clips.Length)] : null);
		}
		else if (audioClips.Length != 0)
		{
			audioSource.clip = ((audioClips.Length != 0) ? audioClips[UnityEngine.Random.Range(0, audioClips.Length)] : null);
		}
		else
		{
			audioSource.clip = null;
		}
		if (audioSource.clip != null)
		{
			switch (PlaySound_info.pitchMode)
			{
			case PitchMode.Perlin:
				audioSource.pitch = Mathf.PerlinNoise(GetTime * perlinPitchMulti, 0f) * (PlaySound_info.maxPitch - PlaySound_info.minPitch) + PlaySound_info.minPitch;
				break;
			case PitchMode.Random:
				audioSource.pitch = UnityEngine.Random.Range(PlaySound_info.minPitch, PlaySound_info.maxPitch);
				break;
			case PitchMode.Single:
				audioSource.pitch = PlaySound_info.overridePitch;
				break;
			default:
				audioSource.pitch = 1f;
				break;
			}
			if (speedReading)
			{
				audioSource.pitch += PlaySound_info.speedReadPitch;
			}
			audioSource.Play();
		}
	}

	private FontStyle AddStyle(FontStyle original, FontStyle newStyle)
	{
		if (font.dynamic)
		{
			switch (original)
			{
			case FontStyle.Bold:
				if (newStyle == FontStyle.Italic)
				{
					return FontStyle.BoldAndItalic;
				}
				return original;
			case FontStyle.Italic:
				if (newStyle == FontStyle.Bold)
				{
					return FontStyle.BoldAndItalic;
				}
				return original;
			case FontStyle.BoldAndItalic:
				return original;
			default:
				return newStyle;
			}
		}
		return FontStyle.Normal;
	}

	private FontStyle SubtractStyle(FontStyle original, FontStyle subStyle)
	{
		if (font.dynamic)
		{
			switch (original)
			{
			case FontStyle.Bold:
				if (subStyle == FontStyle.Bold)
				{
					return FontStyle.Normal;
				}
				return original;
			case FontStyle.Italic:
				if (subStyle == FontStyle.Italic)
				{
					return FontStyle.Normal;
				}
				return original;
			case FontStyle.BoldAndItalic:
				return subStyle switch
				{
					FontStyle.Bold => FontStyle.Italic, 
					FontStyle.Italic => FontStyle.Bold, 
					_ => original, 
				};
			default:
				return FontStyle.Normal;
			}
		}
		return FontStyle.Normal;
	}

	private bool ValidHexcode(string hex)
	{
		if (hex.Length < 3)
		{
			return false;
		}
		if (hex.Substring(0, 1) == "#")
		{
			hex = hex.Substring(1, hex.Length - 1);
		}
		if (hex.Length != 3 && hex.Length != 4 && hex.Length != 6 && hex.Length != 8)
		{
			return false;
		}
		string text = "0123456789ABCDEFabcdef";
		for (int i = 0; i < hex.Length; i++)
		{
			if (!text.Contains(hex[i].ToString(CultureInfo.InvariantCulture)))
			{
				return false;
			}
		}
		return true;
	}

	private Color32 HexToColor(string hex)
	{
		if (hex.Substring(0, 1) == "#")
		{
			hex = hex.Substring(1, hex.Length - 1);
		}
		if (hex.Length == 8)
		{
			byte num = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
			byte a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
			return new Color32(num, g, b, a);
		}
		if (hex.Length == 4)
		{
			byte num2 = byte.Parse(hex.Substring(0, 1) + hex.Substring(0, 1), NumberStyles.HexNumber);
			byte g2 = byte.Parse(hex.Substring(1, 1) + hex.Substring(1, 1), NumberStyles.HexNumber);
			byte b2 = byte.Parse(hex.Substring(2, 1) + hex.Substring(2, 1), NumberStyles.HexNumber);
			byte a2 = byte.Parse(hex.Substring(3, 1) + hex.Substring(3, 1), NumberStyles.HexNumber);
			return new Color32(num2, g2, b2, a2);
		}
		if (hex.Length == 3)
		{
			byte num3 = byte.Parse(hex.Substring(0, 1) + hex.Substring(0, 1), NumberStyles.HexNumber);
			byte g3 = byte.Parse(hex.Substring(1, 1) + hex.Substring(1, 1), NumberStyles.HexNumber);
			byte b3 = byte.Parse(hex.Substring(2, 1) + hex.Substring(2, 1), NumberStyles.HexNumber);
			return new Color32(num3, g3, b3, byte.MaxValue);
		}
		byte num4 = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
		byte g4 = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
		byte b4 = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
		return new Color32(num4, g4, b4, byte.MaxValue);
	}

	private STMColorData GetColor(string myCol)
	{
		if (data.colors.ContainsKey(myCol))
		{
			return data.colors[myCol];
		}
		if (ValidHexcode(myCol))
		{
			STMColorData sTMColorData = ScriptableObject.CreateInstance<STMColorData>();
			sTMColorData.color = HexToColor(myCol);
			return sTMColorData;
		}
		STMColorData sTMColorData2 = ScriptableObject.CreateInstance<STMColorData>();
		switch (myCol)
		{
		case "red":
			sTMColorData2.color = Color.red;
			break;
		case "green":
			sTMColorData2.color = Color.green;
			break;
		case "blue":
			sTMColorData2.color = Color.blue;
			break;
		case "yellow":
			sTMColorData2.color = Color.yellow;
			break;
		case "cyan":
			sTMColorData2.color = Color.cyan;
			break;
		case "magenta":
			sTMColorData2.color = Color.magenta;
			break;
		case "grey":
			sTMColorData2.color = Color.grey;
			break;
		case "gray":
			sTMColorData2.color = Color.gray;
			break;
		case "black":
			sTMColorData2.color = Color.black;
			break;
		case "clear":
			sTMColorData2.color = Color.clear;
			break;
		case "white":
			sTMColorData2.color = Color.white;
			break;
		default:
			sTMColorData2.color = color;
			break;
		}
		return sTMColorData2;
	}

	private string FlipParagraphs(string myText, bool flipInfo)
	{
		List<List<string>> list = new List<List<string>>();
		List<List<List<STMTextInfo>>> list2 = new List<List<List<STMTextInfo>>>();
		List<STMTextInfo> list3 = new List<STMTextInfo>();
		int num = 0;
		int num2 = 0;
		list.Add(new List<string> { "" });
		list2.Add(new List<List<STMTextInfo>>
		{
			new List<STMTextInfo>()
		});
		for (int i = 0; i < myText.Length; i++)
		{
			if (myText[i] == '\n')
			{
				num++;
				num2 = 0;
				list.Add(new List<string> { "\n" });
				if (flipInfo)
				{
					list2.Add(new List<List<STMTextInfo>>
					{
						new List<STMTextInfo> { info[i] }
					});
				}
				num++;
				list.Add(new List<string> { "" });
				if (flipInfo)
				{
					list2.Add(new List<List<STMTextInfo>>
					{
						new List<STMTextInfo>()
					});
				}
			}
			else if (myText[i] == ' ')
			{
				num2++;
				list[num].Add(" ");
				if (flipInfo)
				{
					list2[num].Add(new List<STMTextInfo> { info[i] });
				}
				num2++;
				list[num].Add("");
				if (flipInfo)
				{
					list2[num].Add(new List<STMTextInfo>());
				}
			}
			else
			{
				if (num < list.Count && num2 < list[num].Count)
				{
					list[num][num2] += myText[i].ToString(CultureInfo.InvariantCulture);
				}
				if (flipInfo && num < list2.Count && num2 < list2[num].Count)
				{
					list2[num][num2].Add(info[i]);
				}
			}
		}
		if (flipInfo)
		{
			for (int j = 0; j < list2.Count; j++)
			{
				list2[j].Reverse();
				for (int k = 0; k < list2[j].Count; k++)
				{
					for (int l = 0; l < list2[j][k].Count; l++)
					{
						list3.Add(list2[j][k][l]);
					}
				}
			}
			if (info.Count == list3.Count)
			{
				info = list3;
			}
			else
			{
				Debug.Log("Something went wrong with the RTL system. Old info length was " + info.Count + " new length is " + list3.Count);
			}
		}
		string text = "";
		for (int m = 0; m < list.Count; m++)
		{
			list[m].Reverse();
			for (int n = 0; n < list[m].Count; n++)
			{
				for (int num3 = 0; num3 < list[m][n].Length; num3++)
				{
					text += list[m][n][num3];
				}
			}
		}
		if (myText.Length == text.Length)
		{
			return text;
		}
		Debug.Log("Something went wrong with the RTL system. Old info length was " + info.Count + " new length is " + list3.Count);
		return myText;
	}

	private string ParseText(string myText)
	{
		info.Clear();
		preParsedText = myText;
		if ((onPreParse != null && onPreParse.GetPersistentEventCount() > 0) || this.OnPreParse != null)
		{
			STMTextContainer sTMTextContainer = new STMTextContainer(myText);
			if (onPreParse != null)
			{
				onPreParse.Invoke(sTMTextContainer);
			}
			if (this.OnPreParse != null)
			{
				this.OnPreParse(sTMTextContainer);
			}
			myText = sTMTextContainer.text;
			preParsedText = sTMTextContainer.text;
		}
		if (removeEmoji)
		{
			myText = RemoveEmoji(myText);
		}
		ParseText_info.SetValues(this);
		allTags.Clear();
		int num = 0;
		string text = "";
		infoCount = 0;
		for (int i = 0; i < myText.Length; i++)
		{
			if (readDelay > 0f && infoCount == i && i > 0)
			{
				if (info[i - 1].isQuad)
				{
					if (data.autoDelays.ContainsKey(info[i - 1].quadData.name))
					{
						ParseText_info.delayData = data.autoDelays[info[i - 1].quadData.name];
					}
				}
				else if (data.autoDelays.ContainsKey(myText[i - 1].ToString()))
				{
					char c = myText[i - 1];
					char c2 = myText[i];
					STMAutoDelayData sTMAutoDelayData = data.autoDelays[c.ToString()];
					switch (sTMAutoDelayData.ruleset)
					{
					case STMAutoDelayData.Ruleset.FollowedBySpace:
						if (c2 == ' ' || c2 == '\n' || c2 == '\t' || (myText.Length - i > 4 && myText.Substring(i, 4) == "<br>"))
						{
							ParseText_info.delayData = sTMAutoDelayData;
						}
						break;
					case STMAutoDelayData.Ruleset.FollowedByDifferentCharacter:
						if (c2 != c)
						{
							ParseText_info.delayData = sTMAutoDelayData;
						}
						break;
					case STMAutoDelayData.Ruleset.FollowedBySameCharacterOrSpace:
						if (c2 == c || c2 == ' ' || c2 == '\n' || c2 == '\t' || (myText.Length - i > 4 && myText.Substring(i, 4) == "<br>"))
						{
							ParseText_info.delayData = sTMAutoDelayData;
						}
						break;
					default:
						ParseText_info.delayData = sTMAutoDelayData;
						break;
					}
				}
			}
			if (myText[i] == '\n')
			{
				ParseText_info.isEndOfParagraph = true;
			}
			else
			{
				ParseText_info.isEndOfParagraph = false;
			}
			bool flag = false;
			if (richText && myText[i] == '<')
			{
				int num2 = myText.IndexOf(">", i);
				int num3 = ((num2 > -1) ? myText.IndexOf("=", i, num2 - i) : (-1));
				int num4 = ((num3 > -1 && num2 > -1) ? Mathf.Min(num3, num2) : num2);
				if (num2 != -1)
				{
					ParseText_myTag = myText.Substring(i, num4 - i + 1);
					ParseText_myString = ((num3 > -1) ? myText.Substring(num3 + 1, num2 - num3 - 1) : "");
					bool flag2 = true;
					bool flag3 = false;
					text = "";
					switch (ParseText_myTag)
					{
					case "<br>":
						text = '\n'.ToString(CultureInfo.InvariantCulture);
						break;
					case "<c=":
					{
						ParseText_info.colorData = null;
						ParseText_info.gradientData = null;
						ParseText_info.textureData = null;
						ParseText_dividedString = ParseText_myString.Split(',');
						for (int j = 0; j < ParseText_dividedString.Length; j++)
						{
							if (data.textures.ContainsKey(ParseText_dividedString[j]))
							{
								ParseText_info.textureData = data.textures[ParseText_dividedString[j]];
								ParseText_info.submeshChange = true;
							}
							else if (data.gradients.ContainsKey(ParseText_dividedString[j]))
							{
								ParseText_info.gradientData = data.gradients[ParseText_dividedString[j]];
							}
							else
							{
								ParseText_info.colorData = GetColor(ParseText_dividedString[j]);
							}
						}
						break;
					}
					case "</c>":
						ParseText_info.colorData = null;
						ParseText_info.gradientData = null;
						if (ParseText_info.textureData != null)
						{
							ParseText_info.submeshChange = true;
						}
						ParseText_info.textureData = null;
						break;
					case "<s=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result11))
						{
							ParseText_info.size.x = result11 * size;
							ParseText_info.size.y = result11 * size;
						}
						break;
					}
					case "<size=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result5))
						{
							ParseText_info.size.x = result5;
							ParseText_info.size.y = result5;
						}
						break;
					}
					case "</s>":
					case "</size>":
						ParseText_info.size.x = size;
						ParseText_info.size.y = size;
						break;
					case "<d=":
					{
						int result6;
						if (data.delays.ContainsKey(ParseText_myString))
						{
							ParseText_info.delayData = data.delays[ParseText_myString];
						}
						else if (int.TryParse(ParseText_myString, out result6))
						{
							ParseText_info.delayData = ScriptableObject.CreateInstance<STMDelayData>();
							ParseText_info.delayData.count = result6;
						}
						break;
					}
					case "<d>":
						if (data.delays.ContainsKey("default"))
						{
							ParseText_info.delayData = data.delays["default"];
						}
						else
						{
							Debug.Log("Default delay isn't defined!");
						}
						break;
					case "<t=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result16))
						{
							if (result16 < 0f)
							{
								result16 = 0f;
							}
							ParseText_info.readTime = result16;
						}
						break;
					}
					case "<e=":
						ParseText_info.ev.Add(ParseText_myString);
						break;
					case "<e2=":
						ParseText_info.ev2.Add(ParseText_myString);
						break;
					case "</e>":
					case "</e2>":
						ParseText_info.ev2.Clear();
						break;
					case "<v=":
						if (data.voices.ContainsKey(ParseText_myString))
						{
							text = data.voices[ParseText_myString].text;
						}
						break;
					case "</v>":
						ParseText_info = new STMTextInfo(this);
						break;
					case "<f=":
					case "<font=":
						if (data.fonts.ContainsKey(ParseText_myString))
						{
							ParseText_info.fontData = data.fonts[ParseText_myString];
						}
						else
						{
							Debug.Log("Unknown font: '" + ParseText_myString + "'. Fonts can be defined within the Text Data Inspector and are case-sensitive.");
						}
						ParseText_info.submeshChange = true;
						break;
					case "</f>":
					case "</font>":
						ParseText_info.fontData = null;
						ParseText_info.submeshChange = true;
						break;
					case "<q=":
					case "<quad=":
						ParseText_dividedString = ParseText_myString.Split(',');
						if (data.quads.ContainsKey(ParseText_dividedString[0]) && ParseText_info.quadData == null)
						{
							int result8;
							int result9;
							if (ParseText_dividedString.Length == 1)
							{
								ParseText_info.quadData = data.quads[ParseText_myString];
								ParseText_info.isQuad = true;
								text = "\u2000";
							}
							else if (ParseText_dividedString.Length == 2)
							{
								if (int.TryParse(ParseText_dividedString[1], out var result7))
								{
									ParseText_info.quadData = data.quads[ParseText_dividedString[0]];
									ParseText_info.isQuad = true;
									ParseText_info.quadIndex = result7;
									text = "\u2000";
								}
							}
							else if (ParseText_dividedString.Length == 3 && int.TryParse(ParseText_dividedString[1], out result8) && int.TryParse(ParseText_dividedString[2], out result9))
							{
								ParseText_info.quadData = data.quads[ParseText_dividedString[0]];
								ParseText_info.isQuad = true;
								ParseText_info.quadIndex = ParseText_info.quadData.columns * result8 + result9;
								text = "\u2000";
							}
						}
						ParseText_info.submeshChange = true;
						break;
					case "<m=":
					case "<material=":
						if (data.materials.ContainsKey(ParseText_myString))
						{
							ParseText_info.materialData = data.materials[ParseText_myString];
						}
						ParseText_info.submeshChange = true;
						break;
					case "</m>":
					case "</material>":
						ParseText_info.materialData = null;
						ParseText_info.submeshChange = true;
						break;
					case "<b>":
						ParseText_info.ch.style = AddStyle(ParseText_info.ch.style, FontStyle.Bold);
						break;
					case "</b>":
						ParseText_info.ch.style = SubtractStyle(ParseText_info.ch.style, FontStyle.Bold);
						break;
					case "<i>":
						ParseText_info.ch.style = AddStyle(ParseText_info.ch.style, FontStyle.Italic);
						break;
					case "</i>":
						ParseText_info.ch.style = SubtractStyle(ParseText_info.ch.style, FontStyle.Italic);
						break;
					case "<w=":
						if (data.waves.ContainsKey(ParseText_myString))
						{
							ParseText_info.waveData = data.waves[ParseText_myString];
						}
						break;
					case "<w>":
						if (data.waves.ContainsKey("default"))
						{
							ParseText_info.waveData = data.waves["default"];
						}
						break;
					case "</w>":
						ParseText_info.waveData = null;
						break;
					case "<j=":
						if (data.jitters.ContainsKey(ParseText_myString))
						{
							ParseText_info.jitterData = data.jitters[ParseText_myString];
						}
						break;
					case "<j>":
						if (data.jitters.ContainsKey("default"))
						{
							ParseText_info.jitterData = data.jitters["default"];
						}
						else
						{
							Debug.Log("Default jitter isn't defined!");
						}
						break;
					case "</j>":
						ParseText_info.jitterData = null;
						break;
					case "<a=":
						switch (ParseText_myString.ToLower())
						{
						case "left":
							ParseText_info.alignment = Alignment.Left;
							break;
						case "right":
							ParseText_info.alignment = Alignment.Right;
							break;
						case "center":
						case "centre":
							ParseText_info.alignment = Alignment.Center;
							break;
						case "just":
						case "justify":
						case "justified":
							ParseText_info.alignment = Alignment.Justified;
							break;
						case "just2":
						case "justify2":
						case "justified2":
							ParseText_info.alignment = Alignment.ForceJustified;
							break;
						}
						break;
					case "</a>":
						ParseText_info.alignment = alignment;
						break;
					case "<stopPreviousSound=":
					{
						string text2 = ParseText_myString.ToLower();
						if (!(text2 == "true"))
						{
							if (text2 == "false")
							{
								ParseText_info.stopPreviousSound = false;
							}
						}
						else
						{
							ParseText_info.stopPreviousSound = true;
						}
						break;
					}
					case "</stopPreviousSound>":
						ParseText_info.stopPreviousSound = stopPreviousSound;
						break;
					case "<pitchMode=":
						switch (ParseText_myString.ToLower())
						{
						case "normal":
							ParseText_info.pitchMode = PitchMode.Normal;
							break;
						case "single":
							ParseText_info.pitchMode = PitchMode.Single;
							break;
						case "random":
							ParseText_info.pitchMode = PitchMode.Random;
							break;
						case "perlin":
							ParseText_info.pitchMode = PitchMode.Perlin;
							break;
						}
						break;
					case "</pitchMode>":
						ParseText_info.pitchMode = pitchMode;
						break;
					case "<overridePitch=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result15))
						{
							ParseText_info.overridePitch = result15;
						}
						break;
					}
					case "</overridePitch>":
						ParseText_info.overridePitch = overridePitch;
						break;
					case "<minPitch=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result14))
						{
							ParseText_info.minPitch = result14;
						}
						break;
					}
					case "</minPitch>":
						ParseText_info.minPitch = minPitch;
						break;
					case "<maxPitch=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result13))
						{
							ParseText_info.maxPitch = result13;
						}
						break;
					}
					case "</maxPitch>":
						ParseText_info.maxPitch = maxPitch;
						break;
					case "<speedReadPitch=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result12))
						{
							ParseText_info.speedReadPitch = result12;
						}
						break;
					}
					case "</speedReadPitch>":
						ParseText_info.speedReadPitch = speedReadPitch;
						break;
					case "<readDelay=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result10))
						{
							ParseText_info.readDelay = result10;
						}
						break;
					}
					case "</readDelay>":
						ParseText_info.readDelay = readDelay;
						break;
					case "<drawAnim=":
						if (data.drawAnims.ContainsKey(ParseText_myString))
						{
							ParseText_info.drawAnimData = data.drawAnims[ParseText_myString];
						}
						else if (data.drawAnims.ContainsKey("Appear"))
						{
							ParseText_info.drawAnimData = data.drawAnims["Appear"];
						}
						else
						{
							Debug.Log("'Appear' draw animation isn't defined!");
						}
						break;
					case "</drawAnim>":
						if (data.drawAnims.ContainsKey(drawAnimName))
						{
							ParseText_info.drawAnimData = data.drawAnims[drawAnimName];
						}
						else if (data.drawAnims.ContainsKey("Appear"))
						{
							ParseText_info.drawAnimData = data.drawAnims["Appear"];
						}
						else
						{
							Debug.Log("'Appear' draw animation isn't defined!");
						}
						break;
					case "<drawOrder=":
						switch (ParseText_myString.ToLower())
						{
						case "lefttoright":
						case "ltr":
							ParseText_info.drawOrder = DrawOrder.LeftToRight;
							break;
						case "allatonce":
						case "all":
							ParseText_info.drawOrder = DrawOrder.AllAtOnce;
							break;
						case "onewordatatime":
						case "robot":
							ParseText_info.drawOrder = DrawOrder.OneWordAtATime;
							break;
						case "random":
							ParseText_info.drawOrder = DrawOrder.Random;
							break;
						case "righttoleft":
						case "rtl":
							ParseText_info.drawOrder = DrawOrder.RightToLeft;
							break;
						case "reverseltr":
							ParseText_info.drawOrder = DrawOrder.ReverseLTR;
							break;
						case "rtlonewordatatime":
						case "rtlrobot":
							ParseText_info.drawOrder = DrawOrder.RTLOneWordAtATime;
							break;
						case "onelineatatime":
						case "computer":
							ParseText_info.drawOrder = DrawOrder.OneLineAtATime;
							break;
						}
						break;
					case "</drawOrder>":
						ParseText_info.drawOrder = drawOrder;
						break;
					case "<clips=":
						if (data.soundClips.ContainsKey(ParseText_myString))
						{
							ParseText_info.soundClipData = data.soundClips[ParseText_myString];
						}
						break;
					case "</clips>":
						ParseText_info.soundClipData = null;
						break;
					case "<audioClips=":
						if (data.audioClips.ContainsKey(ParseText_myString))
						{
							ParseText_info.audioClipData = data.audioClips[ParseText_myString];
						}
						break;
					case "</audioClips>":
						ParseText_info.audioClipData = null;
						break;
					case "<indent=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result4))
						{
							ParseText_info.indent = result4;
						}
						break;
					}
					case "</indent>":
						ParseText_info.indent = 0f;
						break;
					case "<pause>":
						_currentPauseCount++;
						if (Application.isPlaying && currentPauseCount > pauseCount)
						{
							flag3 = true;
						}
						else if (Application.isPlaying)
						{
							text = "\u200b";
						}
						break;
					case "<clear>":
						ParseText_info.colorData = null;
						ParseText_info.gradientData = null;
						ParseText_info.textureData = null;
						ParseText_info.size.x = size;
						ParseText_info.size.y = size;
						ParseText_info.ev2.Clear();
						ParseText_info.offset.y = 0f;
						break;
					case "<y=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result3))
						{
							ParseText_info.offset.y = result3 * ParseText_info.size.y;
						}
						break;
					}
					case "</y>":
						ParseText_info.offset.y = 0f;
						break;
					case "<sup>":
						ParseText_info.offset.y = data.superscriptOffset * ParseText_info.size.y;
						ParseText_info.size.x = data.superscriptSize * ParseText_info.size.x;
						ParseText_info.size.y = data.superscriptSize * ParseText_info.size.y;
						break;
					case "</sup>":
						ParseText_info.offset.y = 0f;
						ParseText_info.size.x = size;
						ParseText_info.size.y = size;
						break;
					case "<sub>":
						ParseText_info.offset.y = data.subscriptOffset * ParseText_info.size.y;
						ParseText_info.size.x = data.subscriptSize * ParseText_info.size.x;
						ParseText_info.size.y = data.subscriptSize * ParseText_info.size.y;
						break;
					case "</sub>":
						ParseText_info.offset.y = 0f;
						ParseText_info.size.x = size;
						ParseText_info.size.y = size;
						break;
					case "<u=":
						text = char.ConvertFromUtf32(int.Parse(ParseText_myString, NumberStyles.HexNumber));
						break;
					case "<linespacing=":
					case "<lineSpacing=":
					case "<ls=":
					{
						if (float.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result2))
						{
							ParseText_info.lineSpacing = result2;
						}
						break;
					}
					case "<quality=":
					{
						if (int.TryParse(ParseText_myString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
						{
							ParseText_info.chSize = result;
						}
						break;
					}
					case "</quality>":
						ParseText_info.chSize = quality;
						break;
					default:
						flag2 = false;
						break;
					}
					if (flag2)
					{
						switch (ParseText_myTag)
						{
						default:
							allTags.Add(new KeyValuePair<int, string>(i, myText.Substring(i, num2 + 1 - i)));
							break;
						case "<br>":
						case "<d>":
						case "<d=":
						case "<t=":
						case "<e=":
						case "<q=":
						case "<pause>":
						case "<u=":
							break;
						}
						myText = myText.Remove(i, num2 - i + 1);
						num += num2 - i;
						myText = myText.Insert(i, text);
						flag = true;
					}
					if (flag3)
					{
						myText = myText.Remove(i, myText.Length - i);
						break;
					}
				}
			}
			if (infoCount - 1 == i)
			{
				info[i] = new STMTextInfo(ParseText_info);
			}
			else
			{
				info.Add(new STMTextInfo(ParseText_info));
				infoCount++;
			}
			if (flag)
			{
				i--;
			}
			else
			{
				ParseText_info.delayData = null;
				ParseText_info.quadData = null;
				ParseText_info.ev.Clear();
				ParseText_info.readTime = -1f;
				ParseText_info.quadIndex = -1;
				if (ParseText_info.isQuad)
				{
					ParseText_info.submeshChange = true;
				}
				else
				{
					ParseText_info.submeshChange = false;
				}
				ParseText_info.isQuad = false;
			}
			ParseText_info.rawIndex = i + num + allTags.Count + 1;
		}
		if (infoCount > myText.Length)
		{
			myText += "\u200b";
		}
		return myText;
	}

	private int GetFontSize(Font myFont, STMTextInfo myInfo)
	{
		if (!myFont.dynamic && myFont.fontSize != 0)
		{
			return myFont.fontSize;
		}
		if (myInfo.fontData != null)
		{
			if (myInfo.fontData.overrideQuality)
			{
				return myInfo.fontData.quality;
			}
			return myInfo.chSize;
		}
		if (myInfo.ch.size != 0)
		{
			return myInfo.ch.size;
		}
		return myInfo.chSize;
	}

	private void RequestAllCharacters()
	{
		int i = 0;
		for (int length = hyphenedText.Length; i < length; i++)
		{
			RequestAllCharacters_info = info[i];
			Font font = ((RequestAllCharacters_info.fontData != null) ? RequestAllCharacters_info.fontData.font : this.font);
			font.RequestCharactersInTexture(hyphenedText[i].ToString(CultureInfo.InvariantCulture), GetFontSize(font, RequestAllCharacters_info), RequestAllCharacters_info.ch.style);
			font.RequestCharactersInTexture("-", GetFontSize(font, info[i]), FontStyle.Normal);
		}
	}

	private void FigureOutUnwrappedLimits(Vector3 pos)
	{
		unwrappedBottomRightTextBounds.x = 0f;
		unwrappedBottomRightTextBounds.y = 0f;
		Limits_longestWordWidth = 0f;
		Limits_currentWordWidth = 0f;
		int i = 0;
		for (int length = hyphenedText.Length; i < length; i++)
		{
			if (hyphenedText.Length != length)
			{
				return;
			}
			Limits_info = info[i];
			Limits_font = ((Limits_info.fontData != null) ? Limits_info.fontData.font : font);
			Limits_font.RequestCharactersInTexture(hyphenedText[i].ToString(CultureInfo.InvariantCulture), GetFontSize(Limits_font, Limits_info), Limits_info.ch.style);
			if (Limits_font.GetCharacterInfo(hyphenedText[i], out Limits_ch, GetFontSize(Limits_font, Limits_info), Limits_info.ch.style))
			{
				Limits_info.ch = Limits_ch;
				Limits_info.UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
				continue;
			}
			Limits_font = data.defaultFont;
			if (Limits_font.GetCharacterInfo(hyphenedText[i], out Limits_ch, GetFontSize(Limits_font, Limits_info), Limits_info.ch.style))
			{
				Limits_info.fontData = new STMFontData(data.defaultFont);
				Limits_info.ch = Limits_ch;
				Limits_info.UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
			}
		}
		Limits_lineBreaks = 0;
		int j = 0;
		for (int length2 = hyphenedText.Length; j < length2; j++)
		{
			Limits_info = info[j];
			Limits_font = ((Limits_info.fontData != null) ? Limits_info.fontData.font : font);
			float num = GetFontSize(Limits_font, Limits_info);
			if (hyphenedText[j] == '\n')
			{
				pos.x = Limits_info.indent;
				if (lineHeights.Count > Limits_lineBreaks)
				{
					pos.y -= lineHeights[Limits_lineBreaks + 1];
				}
				Limits_lineBreaks++;
			}
			else if (hyphenedText[j] == '\r')
			{
				pos.x = Limits_info.indent;
			}
			else if (hyphenedText[j] == '\t')
			{
				pos.x += num * 0.5f * tabSize * (Limits_info.size.x / num);
				Limits_currentWordWidth += num * 0.5f * tabSize * (Limits_info.size.x / num);
			}
			else
			{
				pos.x += Limits_info.Advance(characterSpacing, num).x;
				Limits_currentWordWidth += Limits_info.Advance(characterSpacing, num).x;
			}
			for (int k = 0; k < linebreakFriendlyChars.Count; k++)
			{
				if (hyphenedText[j] == linebreakFriendlyChars[k])
				{
					Limits_currentWordWidth = 0f;
				}
			}
			unwrappedBottomRightTextBounds.x = Mathf.Max(unwrappedBottomRightTextBounds.x, pos.x);
			unwrappedBottomRightTextBounds.y = Mathf.Min(unwrappedBottomRightTextBounds.y, pos.y);
			Limits_longestWordWidth = Mathf.Max(Limits_longestWordWidth, Limits_currentWordWidth);
		}
	}

	private void CalculateBestFitMulti()
	{
		BestFit_vertLimit = VerticalLimit;
		bestFitMulti = 1f;
		if (bestFit == BestFitMode.Off)
		{
			return;
		}
		if (Rebuild_autoWrap > 0f)
		{
			bestFitMulti = Rebuild_autoWrap / unwrappedBottomRightTextBounds.x * 0.99999f;
		}
		if (bestFit != BestFitMode.SquishAlways && bestFit != BestFitMode.SquishOverLimit && BestFit_vertLimit > 0f && 0f - unwrappedBottomRightTextBounds.y > BestFit_vertLimit / bestFitMulti)
		{
			bestFitMulti = BestFit_vertLimit / (0f - unwrappedBottomRightTextBounds.y) * 0.99999f;
		}
		if ((bestFit == BestFitMode.OverLimit || bestFit == BestFitMode.SquishOverLimit) && bestFitMulti > 1f)
		{
			bestFitMulti = 1f;
		}
		if (bestFit == BestFitMode.MultilineBETA)
		{
			float num = bestFitMulti;
			bestFitMulti = Mathf.Lerp(num, BestFit_vertLimit / (0f - unwrappedBottomRightTextBounds.y), 0.1f);
			if (bestFitMulti > size)
			{
				bestFitMulti = size;
			}
			else if (bestFitMulti < num)
			{
				bestFitMulti = num;
			}
		}
		bestFitMulti = Mathf.Max(minSize / size, bestFitMulti);
	}

	private void CalculateLineHeights()
	{
		lineHeights.Clear();
		float num = ((infoCount > 0) ? (info[0].size.y * info[0].lineSpacing) : (size * lineSpacing));
		int i = 0;
		for (int num2 = infoCount; i < num2; i++)
		{
			if (hyphenedText[i] == '\n' || i == infoCount - 1)
			{
				lineHeights.Add(num);
				if (infoCount - 1 > i)
				{
					num = info[i + 1].size.y * info[i + 1].lineSpacing;
				}
			}
			else
			{
				num = Mathf.Max(num, info[i].size.y * info[i].lineSpacing);
			}
		}
		lineHeights.Add(num);
		boxHeights.Clear();
		float num3 = 0f;
		float num4 = Rebuild_verticalLimit;
		for (int j = 0; j < lineHeights.Count; j++)
		{
			num3 += lineHeights[j];
			if (num3 > num4)
			{
				boxHeights.Add(num3 - lineHeights[j]);
				num4 = num3 - lineHeights[j] + Rebuild_verticalLimit;
			}
		}
		boxHeights.Add(num3);
	}

	private void RebuildTextInfo()
	{
		Rebuild_autoWrap = AutoWrap;
		Rebuild_verticalLimit = VerticalLimit;
		drawText = ParseText(text);
		lineBreaks.Clear();
		hyphenedText = string.Copy(drawText);
		CalculateLineHeights();
		Rebuild_pos.x = ((infoCount > 0) ? info[0].indent : 0f);
		Rebuild_pos.y = ((lineHeights.Count > 0) ? (0f - lineHeights[0]) : (0f - size));
		Rebuild_pos.z = 0f;
		FigureOutUnwrappedLimits(Rebuild_pos);
		CalculateBestFitMulti();
		for (int i = 0; i < hyphenedText.Length; i++)
		{
			if (bestFit == BestFitMode.SquishAlways || bestFit == BestFitMode.SquishOverLimit)
			{
				info[i].size.x *= bestFitMulti;
				continue;
			}
			info[i].size.x *= bestFitMulti;
			info[i].size.y *= bestFitMulti;
			info[i].offset.x *= bestFitMulti;
			info[i].offset.y *= bestFitMulti;
		}
		CalculateLineHeights();
		Rebuild_pos.x = ((infoCount > 0) ? info[0].indent : 0f);
		Rebuild_pos.y = ((lineHeights.Count > 0) ? (0f - lineHeights[0]) : (0f - size));
		totalWidth = 0f;
		allFonts.Clear();
		if (Rebuild_autoWrap > 0f)
		{
			int j = 0;
			for (int length = hyphenedText.Length; j < length; j++)
			{
				Rebuild_info = info[j];
				Rebuild_font = ((Rebuild_info.fontData != null) ? Rebuild_info.fontData.font : font);
				if (!allFonts.Contains(Rebuild_font))
				{
					allFonts.Add(Rebuild_font);
				}
				Rebuild_font.RequestCharactersInTexture(hyphenedText[j].ToString(CultureInfo.InvariantCulture), GetFontSize(Rebuild_font, Rebuild_info), Rebuild_info.ch.style);
				if (Rebuild_font.GetCharacterInfo(hyphenedText[j], out Rebuild_ch, GetFontSize(Rebuild_font, Rebuild_info), Rebuild_info.ch.style))
				{
					Rebuild_info.ch = Rebuild_ch;
					Rebuild_info.UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
					continue;
				}
				Rebuild_font = data.defaultFont;
				if (Rebuild_font.GetCharacterInfo(hyphenedText[j], out Rebuild_ch, GetFontSize(Rebuild_font, Rebuild_info), Rebuild_info.ch.style))
				{
					Rebuild_info.fontData = new STMFontData(data.defaultFont);
					Rebuild_info.ch = Rebuild_ch;
					Rebuild_info.UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
				}
			}
			float num = ((infoCount > 0) ? info[0].indent : 0f);
			int num2 = -1;
			for (int k = 0; k < infoCount; k++)
			{
				Rebuild_info = info[k];
				Rebuild_font = ((Rebuild_info.fontData != null) ? Rebuild_info.fontData.font : font);
				Rebuild_font.GetCharacterInfo('\n', out Rebuild_breakCh, GetFontSize(Rebuild_font, Rebuild_info), style);
				Rebuild_font.RequestCharactersInTexture("\u00ad", GetFontSize(Rebuild_font, Rebuild_info), style);
				Rebuild_font.GetCharacterInfo('\u00ad', out Rebuild_hyphenCh, GetFontSize(Rebuild_font, Rebuild_info), style);
				Rebuild_font.GetCharacterInfo('\u200b', out Rebuild_zeroWidthCh, GetFontSize(Rebuild_font, Rebuild_info), style);
				if (hyphenedText[k] == '\n')
				{
					num = Rebuild_info.indent;
					Rebuild_info.pos.x = Rebuild_info.indent;
				}
				else if (hyphenedText[k] == '\r')
				{
					num = Rebuild_info.indent;
					Rebuild_info.pos.x = Rebuild_info.indent;
				}
				else if (hyphenedText[k] == '\t')
				{
					Rebuild_info.pos.x = num;
					num += 0.5f * tabSize * Rebuild_info.size.x;
					totalWidth += 0.5f * tabSize * Rebuild_info.size.x;
				}
				else
				{
					Rebuild_info.pos.x = num;
					num += Rebuild_info.Advance(characterSpacing).x;
					totalWidth += Rebuild_info.Advance(characterSpacing).x;
				}
				if (!(num > Rebuild_autoWrap) || k <= num2 + 1)
				{
					continue;
				}
				allLinebreakIndexes = new int[linebreakFriendlyChars.Count];
				for (int l = 0; l < linebreakFriendlyChars.Count; l++)
				{
					allLinebreakIndexes[l] = hyphenedText.LastIndexOf(linebreakFriendlyChars[l], k);
				}
				int num3 = Mathf.Max(allLinebreakIndexes);
				int num4 = hyphenedText.LastIndexOf('\n', k);
				if (!breakText && num3 != -1 && num3 > num4)
				{
					if (hyphenedText[num3] == ' ' || hyphenedText[num3] == '\u3000' || hyphenedText[num3] == '\u200b')
					{
						hyphenedText = hyphenedText.Remove(num3, 1);
						hyphenedText = hyphenedText.Insert(num3, '\n'.ToString(CultureInfo.InvariantCulture));
						info[num3].UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
						k = num3;
						num2 = k;
					}
					else if (insertHyphens && hyphenedText[num3] != '-')
					{
						hyphenedText = hyphenedText.Insert(num3 + 1, "\u00ad\n");
						info.Insert(num3 + 1, new STMTextInfo(info[num3], Rebuild_breakCh));
						infoCount++;
						info[num3 + 1].UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
						info.Insert(num3 + 1, new STMTextInfo(info[num3], Rebuild_hyphenCh));
						infoCount++;
						info[num3 + 2].UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
						k = num3 + 2;
						num2 = k;
					}
					else
					{
						hyphenedText = hyphenedText.Insert(num3 + 1, '\n'.ToString(CultureInfo.InvariantCulture));
						info.Insert(num3 + 1, new STMTextInfo(info[num3], Rebuild_breakCh));
						infoCount++;
						info[num3 + 1].UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
						k = num3 + 1;
						num2 = k;
					}
				}
				else if (k > 0)
				{
					int num5 = k;
					int num6 = -1;
					int num7 = k;
					while (num7-- > num2 + 1)
					{
						if (!linebreakUnfriendlyChars.Contains(hyphenedText[num7]) && hyphenedText.Length > num7 + 1 && !linestartUnfriendlyChars.Contains(hyphenedText[num7 + 1]))
						{
							num6 = num7 + 1;
							break;
						}
					}
					int num8 = -1;
					int num9 = num6;
					while (num9-- > num2 + 1)
					{
						if (info[num9].pos.x / Rebuild_autoWrap > 0.6f && hyphenedText.Length > num9 + 1 && linebreakUnfriendlyChars.Contains(hyphenedText[num9 + 1]) && !linebreakUnfriendlyChars.Contains(hyphenedText[num9]) && hyphenedText.Length > num9 + 1 && !linestartUnfriendlyChars.Contains(hyphenedText[num9 + 1]))
						{
							num8 = num9 + 1;
							break;
						}
					}
					if (num6 > -1 && num8 > -1)
					{
						num5 = ((!breakText) ? Mathf.Min(num6, num8) : Mathf.Max(num6, num8));
					}
					else if (num6 > -1)
					{
						num5 = num6;
					}
					if (insertHyphens)
					{
						hyphenedText = hyphenedText.Insert(num5, "\u00ad\n");
						info.Insert(num5, new STMTextInfo(info[num5], Rebuild_breakCh));
						infoCount++;
						info[num5].UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
						info.Insert(num5, new STMTextInfo(info[num5], Rebuild_hyphenCh));
						infoCount++;
						info[num5].UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
						k = num5 + 1;
						num2 = k;
					}
					else
					{
						hyphenedText = hyphenedText.Insert(num5, "\u200b\n");
						info.Insert(num5, new STMTextInfo(info[num5], Rebuild_breakCh));
						infoCount++;
						info[num5].UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
						info.Insert(num5, new STMTextInfo(info[num5], Rebuild_zeroWidthCh));
						infoCount++;
						info[num5].UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
						k = num5 + 1;
						num2 = k;
					}
				}
				num = Rebuild_info.indent;
			}
		}
		else
		{
			int m = 0;
			for (int length2 = hyphenedText.Length; m < length2; m++)
			{
				Rebuild_info = info[m];
				Rebuild_font = ((Rebuild_info.fontData != null) ? Rebuild_info.fontData.font : font);
				Rebuild_font.RequestCharactersInTexture(hyphenedText[m].ToString(CultureInfo.InvariantCulture), GetFontSize(Rebuild_font, Rebuild_info), Rebuild_info.ch.style);
				if (Rebuild_font.GetCharacterInfo(hyphenedText[m], out Rebuild_ch, GetFontSize(Rebuild_font, Rebuild_info), Rebuild_info.ch.style))
				{
					Rebuild_info.ch = Rebuild_ch;
					Rebuild_info.UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
				}
				else
				{
					Rebuild_font = data.defaultFont;
					if (Rebuild_font.GetCharacterInfo(hyphenedText[m], out Rebuild_ch, GetFontSize(Rebuild_font, Rebuild_info), Rebuild_info.ch.style))
					{
						Rebuild_info.fontData = new STMFontData(data.defaultFont);
						Rebuild_info.ch = Rebuild_ch;
						Rebuild_info.UpdateCachedValuesIfChanged(fontTextureJustRebuilt);
					}
				}
				if (!allFonts.Contains(Rebuild_font))
				{
					allFonts.Add(Rebuild_font);
				}
			}
		}
		if (rtl)
		{
			hyphenedText = FlipParagraphs(hyphenedText, flipInfo: true);
		}
		CalculateLineHeights();
		Rebuild_pos.x = ((infoCount > 0) ? info[0].indent : 0f);
		Rebuild_pos.y = ((lineHeights.Count > 0) ? (0f - lineHeights[0]) : (0f - size));
		int num10 = 0;
		int n = 0;
		for (int length3 = hyphenedText.Length; n < length3; n++)
		{
			Rebuild_info = info[n];
			Rebuild_font = ((Rebuild_info.fontData != null) ? Rebuild_info.fontData.font : font);
			float num11 = GetFontSize(Rebuild_font, Rebuild_info);
			Rebuild_info.pos.x = Rebuild_pos.x;
			Rebuild_info.pos.y = Rebuild_pos.y;
			Rebuild_info.pos.z = Rebuild_pos.z;
			if (hyphenedText[n] == '\n')
			{
				lineBreaks.Add((n != 0) ? (n - 1) : 0);
				Rebuild_pos.x = Rebuild_info.indent;
				if (lineHeights.Count > num10)
				{
					Rebuild_pos.y -= lineHeights[num10 + 1];
				}
				num10++;
			}
			else if (hyphenedText[n] == '\r')
			{
				lineBreaks.Add((n != 0) ? (n - 1) : 0);
				Rebuild_pos.x = Rebuild_info.indent;
			}
			else if (length3 - 1 == n)
			{
				lineBreaks.Add(n);
			}
			else if (hyphenedText[n] == '\t')
			{
				Rebuild_pos.x += num11 * 0.5f * tabSize * (Rebuild_info.size.x / num11);
			}
			else
			{
				Rebuild_pos.x += Rebuild_info.Advance(characterSpacing, num11).x;
			}
		}
		lineBreaks = lineBreaks.Distinct().ToList();
		ApplyOffsetDataToTextInfo();
		if (verticalLimitMode == VerticalLimitMode.SquishBETA && BestFit_vertLimit < 0f - rawBottomRightTextBounds.y)
		{
			for (int num12 = 0; num12 < hyphenedText.Length; num12++)
			{
				info[num12].size.y *= BestFit_vertLimit / (0f - rawBottomRightTextBounds.y) * 0.99999f;
				info[num12].pos.y *= BestFit_vertLimit / (0f - rawBottomRightTextBounds.y) * 0.99999f;
				info[num12].offset.y *= BestFit_vertLimit / (0f - rawBottomRightTextBounds.y) * 0.99999f;
			}
			RecalculateBounds();
		}
		TrimCutoffText();
		UpdateRTLDrawOrder();
		ApplyUnreadTimingDataToTextInfo();
		ApplyTimingDataToTextInfo();
		PrepareSubmeshes();
	}

	private void TrimCutoffText()
	{
		leftoverText = "";
		if (VerticalLimit > 0f && verticalLimitMode == VerticalLimitMode.CutOff)
		{
			float num = 0f - VerticalLimit;
			switch (anchor)
			{
			case TextAnchor.MiddleLeft:
			case TextAnchor.MiddleCenter:
			case TextAnchor.MiddleRight:
				num *= 0.5f;
				break;
			case TextAnchor.LowerLeft:
			case TextAnchor.LowerCenter:
			case TextAnchor.LowerRight:
				num = 0f;
				break;
			}
			num += uiOffset.y;
			for (int i = 0; i < hyphenedText.Length; i++)
			{
				if (info[i].pos.y < num)
				{
					hyphenedText = hyphenedText.Remove(i, hyphenedText.Length - i);
					AssembleLeftoverText();
					return;
				}
			}
		}
		else if (VerticalLimit > 0f && (verticalLimitMode == VerticalLimitMode.AutoPause || verticalLimitMode == VerticalLimitMode.AutoPauseFull))
		{
			autoPauseStopPoint = 0f - boxHeights[0];
			int num2 = 0;
			for (int j = 0; j < hyphenedText.Length; j++)
			{
				while (info[j].pos.y < autoPauseStopPoint - offset.y)
				{
					num2++;
					float num3 = 0f;
					num3 = ((num2 >= boxHeights.Count) ? (num3 - lineHeights[lineHeights.Count - 1]) : (0f - boxHeights[num2]));
					if (Application.isPlaying && currentPauseCount + num2 > pauseCount)
					{
						hyphenedText = hyphenedText.Remove(j, hyphenedText.Length - j);
						AssembleLeftoverText();
						_currentPauseCount += num2;
						return;
					}
					autoPauseStopPoint = num3;
				}
			}
		}
		_ = info.Count;
		_ = 0;
	}

	private void AssembleLeftoverText()
	{
		int length = hyphenedText.Length;
		if (length > 0)
		{
			for (int i = 0; i < allTags.Count && allTags[i].Key <= length; i++)
			{
				leftoverText += allTags[i].Value;
			}
			length = info[length].rawIndex;
			if (length <= preParsedText.Length)
			{
				leftoverText += preParsedText.Substring(length);
			}
		}
	}

	private void ApplyOffsetDataToTextInfo()
	{
		OffsetData_VerticalLimit = VerticalLimit;
		float[] array = new float[lineBreaks.Count];
		int i = 0;
		for (int count = lineBreaks.Count; i < count; i++)
		{
			array[i] = info[lineBreaks[i]].BottomRightVert.x;
			if (float.IsNaN(array[i]))
			{
				array[i] = 0f;
			}
		}
		rawBottomRightTextBounds.x = Mathf.Max(array);
		rawBottomRightTextBounds.y = 0f;
		offset.x = 0f;
		offset.y = 0f;
		offset.z = 0f;
		if (uiMode)
		{
			uiOffset.x = 0f;
			uiOffset.y = 0f;
			uiOffset.z = 0f;
			switch (anchor)
			{
			case TextAnchor.UpperLeft:
				uiOffset.x = tr.rect.xMin;
				uiOffset.y = tr.rect.yMax;
				break;
			case TextAnchor.UpperCenter:
				uiOffset.x = (tr.rect.xMin + tr.rect.xMax) / 2f;
				uiOffset.y = tr.rect.yMax;
				break;
			case TextAnchor.UpperRight:
				uiOffset.x = tr.rect.xMax;
				uiOffset.y = tr.rect.yMax;
				break;
			case TextAnchor.MiddleLeft:
				uiOffset.x = tr.rect.xMin;
				uiOffset.y = (tr.rect.yMin + tr.rect.yMax) / 2f;
				break;
			case TextAnchor.MiddleCenter:
				uiOffset.x = (tr.rect.xMin + tr.rect.xMax) / 2f;
				uiOffset.y = (tr.rect.yMin + tr.rect.yMax) / 2f;
				break;
			case TextAnchor.MiddleRight:
				uiOffset.x = tr.rect.xMax;
				uiOffset.y = (tr.rect.yMin + tr.rect.yMax) / 2f;
				break;
			case TextAnchor.LowerLeft:
				uiOffset.x = tr.rect.xMin;
				uiOffset.y = tr.rect.yMin;
				break;
			case TextAnchor.LowerCenter:
				uiOffset.x = (tr.rect.xMin + tr.rect.xMax) / 2f;
				uiOffset.y = tr.rect.yMin;
				break;
			case TextAnchor.LowerRight:
				uiOffset.x = tr.rect.xMax;
				uiOffset.y = tr.rect.yMin;
				break;
			}
			offset.x -= uiOffset.x;
			offset.y -= uiOffset.y;
		}
		OffsetData_rowStart = 0;
		lowestPosition = 0f;
		int j = 0;
		for (int count2 = lineBreaks.Count; j < count2; j++)
		{
			OffsetData_offsetRight = rawBottomRightTextBounds.x - array[j];
			if (Rebuild_autoWrap > 0f)
			{
				OffsetData_offsetRight += Rebuild_autoWrap - rawBottomRightTextBounds.x;
			}
			OffsetData_spaceCount = 0;
			int k = OffsetData_rowStart;
			for (int num = lineBreaks[j] + 1; k < num; k++)
			{
				if (hyphenedText[k] == ' ')
				{
					OffsetData_spaceCount++;
				}
			}
			float num2 = ((OffsetData_spaceCount > 0) ? (OffsetData_offsetRight / (float)OffsetData_spaceCount) : 0f);
			int num3 = 0;
			int l = OffsetData_rowStart;
			for (int num4 = lineBreaks[j] + 1; l < num4; l++)
			{
				info[l].line = j;
				if (hyphenedText[l] == ' ')
				{
					num3++;
				}
				switch (info[l].alignment)
				{
				case Alignment.Center:
					info[l].pos.x += OffsetData_offsetRight / 2f;
					break;
				case Alignment.Right:
					info[l].pos.x += OffsetData_offsetRight;
					break;
				case Alignment.Justified:
					if (num4 != hyphenedText.Length && drawText[num4 - (hyphenedText.Length - drawText.Length)] != '\n')
					{
						info[l].pos.x += num2 * (float)num3;
					}
					break;
				case Alignment.ForceJustified:
					info[l].pos.x += num2 * (float)num3;
					break;
				}
				rawBottomRightTextBounds.y = Mathf.Min(rawBottomRightTextBounds.y, info[l].pos.y);
				if (OffsetData_VerticalLimit == 0f || (OffsetData_VerticalLimit > 0f && verticalLimitMode == VerticalLimitMode.Ignore) || info[l].pos.y >= 0f - OffsetData_VerticalLimit)
				{
					lowestPosition = Mathf.Min(lowestPosition, info[l].pos.y);
				}
			}
			OffsetData_rowStart = lineBreaks[j] + 1;
		}
		OffsetData_maxHeight = ((OffsetData_VerticalLimit > 0f) ? (0f - OffsetData_VerticalLimit) : rawBottomRightTextBounds.y);
		OffsetData_maxWidth = ((Rebuild_autoWrap > 0f) ? Rebuild_autoWrap : rawBottomRightTextBounds.x);
		switch (anchor)
		{
		case TextAnchor.UpperCenter:
			offset.x += OffsetData_maxWidth * 0.5f;
			break;
		case TextAnchor.UpperRight:
			offset.x += OffsetData_maxWidth;
			break;
		case TextAnchor.MiddleLeft:
			offset.y += OffsetData_maxHeight * 0.5f;
			break;
		case TextAnchor.MiddleCenter:
			offset.x += OffsetData_maxWidth * 0.5f;
			offset.y += OffsetData_maxHeight * 0.5f;
			break;
		case TextAnchor.MiddleRight:
			offset.x += OffsetData_maxWidth;
			offset.y += OffsetData_maxHeight * 0.5f;
			break;
		case TextAnchor.LowerLeft:
			offset.y += OffsetData_maxHeight;
			break;
		case TextAnchor.LowerCenter:
			offset.x += OffsetData_maxWidth * 0.5f;
			offset.y += OffsetData_maxHeight;
			break;
		case TextAnchor.LowerRight:
			offset.x += OffsetData_maxWidth;
			offset.y += OffsetData_maxHeight;
			break;
		}
		for (int m = 0; m < infoCount; m++)
		{
			info[m].pos -= offset;
		}
		rawTopLeftBounds.x = offset.x;
		rawTopLeftBounds.y = offset.y;
		rawTopLeftBounds.z = offset.z;
		rawBottomRightBounds.x = ((Rebuild_autoWrap > 0f) ? (offset.x - Rebuild_autoWrap) : (offset.x - rawBottomRightTextBounds.x));
		rawBottomRightBounds.y = ((OffsetData_VerticalLimit > 0f) ? (OffsetData_VerticalLimit + offset.y) : (offset.y - OffsetData_maxHeight));
		rawBottomRightBounds.z = offset.z;
		anchorOffset.x = 0f;
		anchorOffset.y = 0f;
		anchorOffset.z = 0f;
		switch (anchor)
		{
		case TextAnchor.MiddleLeft:
		case TextAnchor.MiddleCenter:
		case TextAnchor.MiddleRight:
			anchorOffset.y = ((OffsetData_VerticalLimit > 0f - rawBottomRightTextBounds.y) ? ((0f - rawBottomRightTextBounds.y + rawTopLeftBounds.y - rawBottomRightBounds.y) * 0.5f) : 0f);
			break;
		case TextAnchor.LowerLeft:
		case TextAnchor.LowerCenter:
		case TextAnchor.LowerRight:
			anchorOffset.y = ((OffsetData_VerticalLimit > 0f - rawBottomRightTextBounds.y) ? (0f - rawBottomRightTextBounds.y + rawTopLeftBounds.y - rawBottomRightBounds.y) : 0f);
			break;
		}
		RecalculateBounds();
	}

	private void RecalculateBounds()
	{
		RecalculateBounds_point.x = 0f - rawTopLeftBounds.x;
		RecalculateBounds_point.y = 0f - rawTopLeftBounds.y;
		RecalculateBounds_point.z = 0f - rawTopLeftBounds.z;
		topLeftBounds = t.TransformPoint(RecalculateBounds_point);
		RecalculateBounds_point.x = 0f - rawBottomRightBounds.x;
		RecalculateBounds_point.y = 0f - rawTopLeftBounds.y;
		RecalculateBounds_point.z = rawTopLeftBounds.z;
		topRightBounds = t.TransformPoint(RecalculateBounds_point);
		RecalculateBounds_point.x = 0f - rawTopLeftBounds.x;
		RecalculateBounds_point.y = 0f - rawBottomRightBounds.y;
		RecalculateBounds_point.z = rawBottomRightBounds.z;
		bottomLeftBounds = t.TransformPoint(RecalculateBounds_point);
		RecalculateBounds_point.x = 0f - rawBottomRightBounds.x;
		RecalculateBounds_point.y = 0f - rawBottomRightBounds.y;
		RecalculateBounds_point.z = 0f - rawBottomRightBounds.z;
		bottomRightBounds = t.TransformPoint(RecalculateBounds_point);
		centerBounds = Vector3.Lerp(topLeftBounds, bottomRightBounds, 0.5f);
		if (hyphenedText.Length == 0)
		{
			RecalculateTextBounds();
		}
		RecalculateFinalTextBounds();
	}

	private void RecalculateBoundsOffsets()
	{
		TextBounds_leftOffset.x = 0f;
		TextBounds_leftOffset.y = 0f;
		TextBounds_leftOffset.z = 0f;
		TextBounds_rightOffset.x = 0f;
		TextBounds_rightOffset.y = 0f;
		TextBounds_rightOffset.z = 0f;
		TextBounds_diff = rawBottomRightTextBounds.x + rawBottomRightBounds.x - offset.x;
		switch (alignment)
		{
		case Alignment.Center:
			TextBounds_leftOffset.x += TextBounds_diff / 2f;
			TextBounds_rightOffset.x += TextBounds_diff / 2f;
			break;
		case Alignment.Right:
			TextBounds_leftOffset.x += TextBounds_diff;
			TextBounds_rightOffset.x += TextBounds_diff;
			break;
		case Alignment.Justified:
		case Alignment.ForceJustified:
			TextBounds_rightOffset.x += TextBounds_diff;
			break;
		}
	}

	private void RecalculateTextBounds()
	{
		if (hyphenedText.Length > 0)
		{
			RecalculateBoundsOffsets();
			RecalculateBounds_t = base.transform;
			RecalculateBounds_textBottom = Mathf.Max(lowestDrawnPositionRaw - offset.y, lowestPosition - rawTopLeftBounds.y);
			RecalculateBounds_point.x = 0f - TextBounds_leftOffset.x - rawTopLeftBounds.x + anchorOffset.x;
			RecalculateBounds_point.y = 0f - TextBounds_leftOffset.y - rawTopLeftBounds.y + anchorOffset.y;
			RecalculateBounds_point.z = 0f - TextBounds_leftOffset.z - rawTopLeftBounds.z + anchorOffset.z;
			topLeftTextBounds = RecalculateBounds_t.TransformPoint(RecalculateBounds_point);
			RecalculateBounds_point.x = furthestDrawnPosition - rawTopLeftBounds.x - TextBounds_rightOffset.x + anchorOffset.x;
			RecalculateBounds_point.y = 0f - rawTopLeftBounds.y - TextBounds_rightOffset.y + anchorOffset.y;
			RecalculateBounds_point.z = 0f - rawTopLeftBounds.z - TextBounds_rightOffset.z + anchorOffset.z;
			topRightTextBounds = RecalculateBounds_t.TransformPoint(RecalculateBounds_point);
			RecalculateBounds_point.x = 0f - rawTopLeftBounds.x - TextBounds_leftOffset.x + anchorOffset.x;
			RecalculateBounds_point.y = RecalculateBounds_textBottom - TextBounds_leftOffset.y + anchorOffset.y;
			RecalculateBounds_point.z = 0f - TextBounds_leftOffset.z + anchorOffset.z;
			bottomLeftTextBounds = RecalculateBounds_t.TransformPoint(RecalculateBounds_point);
			RecalculateBounds_point.x = furthestDrawnPosition - rawTopLeftBounds.x - TextBounds_rightOffset.x + anchorOffset.x;
			RecalculateBounds_point.y = RecalculateBounds_textBottom - TextBounds_rightOffset.y + anchorOffset.y;
			RecalculateBounds_point.z = 0f - TextBounds_rightOffset.z + anchorOffset.z;
			bottomRightTextBounds = RecalculateBounds_t.TransformPoint(RecalculateBounds_point);
			centerTextBounds.x = Mathf.Lerp(topLeftTextBounds.x, bottomRightTextBounds.x, 0.5f);
			centerTextBounds.y = Mathf.Lerp(topLeftTextBounds.y, bottomRightTextBounds.y, 0.5f);
		}
		else
		{
			topLeftTextBounds.x = 0f;
			topLeftTextBounds.y = 0f;
			topLeftTextBounds.z = 0f;
			topRightTextBounds.x = 0f;
			topRightTextBounds.y = 0f;
			topRightTextBounds.z = 0f;
			bottomLeftTextBounds.x = 0f;
			bottomLeftTextBounds.y = 0f;
			bottomLeftTextBounds.z = 0f;
			bottomRightTextBounds.x = 0f;
			bottomRightTextBounds.y = 0f;
			bottomRightTextBounds.z = 0f;
			centerTextBounds.x = 0f;
			centerTextBounds.y = 0f;
			centerTextBounds.z = 0f;
		}
	}

	private void RecalculateFinalTextBounds()
	{
		if (hyphenedText.Length > 0)
		{
			RecalculateBoundsOffsets();
			RecalculateBounds_t = base.transform;
			RecalculateBounds_point.x = 0f - rawTopLeftBounds.x - TextBounds_leftOffset.x + anchorOffset.x;
			RecalculateBounds_point.y = 0f - rawTopLeftBounds.y - TextBounds_leftOffset.y + anchorOffset.y;
			RecalculateBounds_point.z = 0f - rawTopLeftBounds.z - TextBounds_leftOffset.z + anchorOffset.z;
			finalTopLeftTextBounds = RecalculateBounds_t.TransformPoint(RecalculateBounds_point);
			RecalculateBounds_point.x = rawBottomRightTextBounds.x - rawTopLeftBounds.x - TextBounds_rightOffset.x + anchorOffset.x;
			RecalculateBounds_point.y = 0f - rawTopLeftBounds.y - TextBounds_rightOffset.y + anchorOffset.y;
			RecalculateBounds_point.z = 0f - rawTopLeftBounds.z - TextBounds_rightOffset.z + anchorOffset.z;
			finalTopRightTextBounds = RecalculateBounds_t.TransformPoint(RecalculateBounds_point);
			RecalculateBounds_point.x = 0f - rawTopLeftBounds.x - TextBounds_leftOffset.x + anchorOffset.x;
			RecalculateBounds_point.y = lowestPosition - rawTopLeftBounds.y - TextBounds_leftOffset.y + anchorOffset.y;
			RecalculateBounds_point.z = 0f - rawTopLeftBounds.z - TextBounds_leftOffset.z + anchorOffset.z;
			finalBottomLeftTextBounds = RecalculateBounds_t.TransformPoint(RecalculateBounds_point);
			RecalculateBounds_point.x = rawBottomRightTextBounds.x - rawTopLeftBounds.x - TextBounds_rightOffset.x + anchorOffset.x;
			RecalculateBounds_point.y = lowestPosition - rawTopLeftBounds.y - TextBounds_rightOffset.y + anchorOffset.y;
			RecalculateBounds_point.z = 0f - rawTopLeftBounds.z - TextBounds_rightOffset.z + anchorOffset.z;
			finalBottomRightTextBounds = RecalculateBounds_t.TransformPoint(RecalculateBounds_point);
			finalCenterTextBounds.x = Mathf.Lerp(finalTopLeftTextBounds.x, finalBottomRightTextBounds.x, 0.5f);
			finalCenterTextBounds.y = Mathf.Lerp(finalTopLeftTextBounds.y, finalBottomRightTextBounds.y, 0.5f);
		}
		else
		{
			finalTopLeftTextBounds.x = 0f;
			finalTopLeftTextBounds.y = 0f;
			finalTopLeftTextBounds.z = 0f;
			finalTopRightTextBounds.x = 0f;
			finalTopRightTextBounds.y = 0f;
			finalTopRightTextBounds.z = 0f;
			finalBottomLeftTextBounds.x = 0f;
			finalBottomLeftTextBounds.y = 0f;
			finalBottomLeftTextBounds.z = 0f;
			finalBottomRightTextBounds.x = 0f;
			finalBottomRightTextBounds.y = 0f;
			finalBottomRightTextBounds.z = 0f;
			finalCenterTextBounds.x = 0f;
			finalCenterTextBounds.y = 0f;
			finalCenterTextBounds.z = 0f;
		}
	}

	private void UpdateRTLDrawOrder()
	{
		drawOrderRTL = new int[hyphenedText.Length];
		RTL_currentLine = 0;
		int i = 0;
		for (int length = hyphenedText.Length; i < length; i++)
		{
			RTL_lastEnd = ((RTL_currentLine > 0) ? (lineBreaks[RTL_currentLine - 1] + 1) : 0);
			if (RTL_currentLine < lineBreaks.Count)
			{
				drawOrderRTL[i] = -i + lineBreaks[RTL_currentLine] + RTL_lastEnd;
				if (lineBreaks[RTL_currentLine] == i)
				{
					RTL_currentLine++;
				}
			}
		}
	}

	private void ApplyTimingDataToTextInfo()
	{
		float num = 0f;
		float num2 = 0f;
		bool flag = false;
		int i = 0;
		for (int length = hyphenedText.Length; i < length; i++)
		{
			Timing_textInfo = info[i];
			int num3 = GetDrawOrder(Timing_textInfo.drawOrder, i, length);
			Timing_textInfo = info[num3];
			if (Timing_textInfo.readDelay > 0f)
			{
				flag = true;
			}
			float num4 = ((Timing_textInfo.delayData != null) ? ((float)Timing_textInfo.delayData.count) : 0f);
			if (Timing_textInfo.readTime < 0f)
			{
				switch (Timing_textInfo.drawOrder)
				{
				case DrawOrder.AllAtOnce:
					Timing_textInfo.readTime = num;
					break;
				case DrawOrder.Random:
					Timing_textInfo.readTime = UnityEngine.Random.Range(0f, Timing_textInfo.readDelay);
					break;
				case DrawOrder.OneWordAtATime:
					if (hyphenedText[i] == ' ' || hyphenedText[i] == '\n' || hyphenedText[i] == '\t' || hyphenedText[i] == '-')
					{
						num += ((i == 0) ? (num4 * Timing_textInfo.readDelay) : (Timing_textInfo.readDelay + num4 * Timing_textInfo.readDelay));
					}
					Timing_textInfo.readTime = num;
					break;
				case DrawOrder.OneLineAtATime:
					if (hyphenedText[i] == '\n')
					{
						num += ((i == 0) ? (num4 * Timing_textInfo.readDelay) : (Timing_textInfo.readDelay + num4 * Timing_textInfo.readDelay));
					}
					Timing_textInfo.readTime = num;
					break;
				case DrawOrder.RightToLeft:
					Timing_textInfo.readTime = num;
					num += ((num3 == 0) ? (num4 * Timing_textInfo.readDelay) : (Timing_textInfo.readDelay + num4 * Timing_textInfo.readDelay));
					break;
				case DrawOrder.ReverseLTR:
					num += ((i == 0) ? (num4 * Timing_textInfo.readDelay) : (Timing_textInfo.readDelay + num4 * Timing_textInfo.readDelay));
					Timing_textInfo.readTime = num;
					break;
				case DrawOrder.RTLOneWordAtATime:
					Timing_textInfo.readTime = num;
					if (num3 == 0 || hyphenedText[num3] == ' ' || hyphenedText[num3] == '\n' || hyphenedText[num3] == '\t' || hyphenedText[num3] == '-')
					{
						num += Timing_textInfo.readDelay + num4 * Timing_textInfo.readDelay;
					}
					break;
				default:
					num += ((i == 0) ? (num4 * Timing_textInfo.readDelay) : (Timing_textInfo.readDelay + num4 * Timing_textInfo.readDelay));
					Timing_textInfo.readTime = num;
					break;
				}
			}
			else
			{
				num = Timing_textInfo.readTime;
			}
			float num5 = ((Timing_textInfo.drawAnimData != null) ? Mathf.Max(Timing_textInfo.drawAnimData.animTime, Timing_textInfo.drawAnimData.fadeTime) : 0f);
			num2 = Mathf.Max(Timing_textInfo.readTime + num5, num2);
		}
		totalReadTime = num2 + 1E-05f;
		callReadFunction = flag;
	}

	private void ApplyUnreadTimingDataToTextInfo()
	{
		float num = 0f;
		float num2 = 0f;
		STMDrawAnimData undrawAnim = UndrawAnim;
		int i = 0;
		for (int length = hyphenedText.Length; i < length; i++)
		{
			int num3 = GetDrawOrder(undrawOrder, i, length);
			UnreadTiming_textInfo = info[num3];
			switch (undrawOrder)
			{
			case DrawOrder.AllAtOnce:
				UnreadTiming_textInfo.unreadTime = num;
				break;
			case DrawOrder.Random:
				UnreadTiming_textInfo.unreadTime = UnityEngine.Random.Range(0f, unreadDelay);
				break;
			case DrawOrder.OneWordAtATime:
				UnreadTiming_textInfo.unreadTime = num;
				if (hyphenedText[i] == ' ' || hyphenedText[i] == '\n' || hyphenedText[i] == '\t' || hyphenedText[i] == '-')
				{
					num += unreadDelay;
				}
				break;
			case DrawOrder.OneLineAtATime:
				if (hyphenedText[i] == '\n')
				{
					num += unreadDelay;
				}
				UnreadTiming_textInfo.unreadTime = num;
				break;
			case DrawOrder.RightToLeft:
				num += unreadDelay;
				UnreadTiming_textInfo.unreadTime = num;
				break;
			case DrawOrder.ReverseLTR:
				num += unreadDelay;
				UnreadTiming_textInfo.unreadTime = num;
				break;
			case DrawOrder.RTLOneWordAtATime:
				UnreadTiming_textInfo.unreadTime = num;
				if (num3 == 0 || hyphenedText[num3] == ' ' || hyphenedText[num3] == '\n' || hyphenedText[num3] == '\t' || hyphenedText[num3] == '-')
				{
					num += unreadDelay;
				}
				break;
			default:
				UnreadTiming_textInfo.unreadTime = num;
				num += unreadDelay;
				break;
			}
			float num4 = ((undrawAnim != null) ? Mathf.Max(undrawAnim.animTime, undrawAnim.fadeTime) : 0f);
			num2 = Mathf.Max(UnreadTiming_textInfo.unreadTime + num4, num2);
		}
		totalUnreadTime = num2 + 1E-05f;
	}

	private Vector3 WavePosition(STMTextInfo myInfo, STMWaveControl wave, float myTime)
	{
		WavePosition_multi = wave.multiOverTime.Evaluate(myTime);
		WavePosition_Vect.x = wave.curveX.Evaluate(myTime * wave.speed.x + wave.phase * 6f + myInfo.pos.x * wave.density.x / myInfo.size.x) * wave.strength.x * myInfo.size.x * WavePosition_multi;
		WavePosition_Vect.y = wave.curveY.Evaluate(myTime * wave.speed.y + wave.phase * 6f + myInfo.pos.x * wave.density.y / myInfo.size.y) * wave.strength.y * myInfo.size.y * WavePosition_multi;
		WavePosition_Vect.z = wave.curveZ.Evaluate(myTime * wave.speed.z + wave.phase * 6f + myInfo.pos.x * wave.density.z / myInfo.size.y) * wave.strength.z * myInfo.size.y * WavePosition_multi;
		return WavePosition_Vect;
	}

	private Vector3 WaveRotation(STMTextInfo myInfo, STMWaveRotationControl rot, Vector3 vertPos, float myTime)
	{
		WaveRotation_Pivot.x = myInfo.pos.x + rot.pivot.x * myInfo.RelativeWidth;
		WaveRotation_Pivot.y = myInfo.pos.y + rot.pivot.y * myInfo.size.y;
		WaveRotation_Pivot.z = 0f;
		WaveRotation_Offset.x = vertPos.x - WaveRotation_Pivot.x;
		WaveRotation_Offset.y = vertPos.y - WaveRotation_Pivot.y;
		WaveRotation_Offset.z = vertPos.z - WaveRotation_Pivot.z;
		WaveRotation_myRotation.x = 0f;
		WaveRotation_myRotation.y = 0f;
		WaveRotation_myRotation.z = rot.curveZ.Evaluate(myTime * rot.speed + rot.phase * 6f + myInfo.pos.x * rot.density) * rot.strength;
		WaveRotation_myQuaternion = Quaternion.Euler(WaveRotation_myRotation);
		WaveRotation_Offset = WaveRotation_myQuaternion * WaveRotation_Offset;
		WaveRotation_ReturnVal.x = WaveRotation_Offset.x + WaveRotation_Pivot.x - vertPos.x;
		WaveRotation_ReturnVal.y = WaveRotation_Offset.y + WaveRotation_Pivot.y - vertPos.y;
		WaveRotation_ReturnVal.z = WaveRotation_Offset.z + WaveRotation_Pivot.z - vertPos.z;
		return WaveRotation_ReturnVal;
	}

	private Vector3 WaveScale(STMTextInfo myInfo, STMWaveScaleControl scale, Vector3 vertPos, float myTime)
	{
		Vector3 vector = myInfo.pos + new Vector3(scale.pivot.x * myInfo.RelativeWidth, scale.pivot.y * myInfo.size.y, 0f);
		Vector3 a = vertPos - vector;
		Vector3 b = new Vector3(scale.curveX.Evaluate(myTime * scale.speed.x + scale.phase * 6f + myInfo.pos.x * scale.density.x) * scale.strength.x, scale.curveY.Evaluate(myTime * scale.speed.y + scale.phase * 6f + myInfo.pos.x * scale.density.y) * scale.strength.y, 1f);
		return Vector3.Scale(a, b) + vector - vertPos;
	}

	private Vector3 JitterValue(STMTextInfo myInfo, STMJitterData jit)
	{
		float num = currentReadTime - myInfo.readTime;
		if (jit.perlin)
		{
			JitterValue_MyJit.x = jit.distanceOverTime.Evaluate(num / jit.distanceOverTimeMulti) * (jit.distance.Evaluate(Mathf.PerlinNoise(jit.perlinTimeMulti * num + myInfo.pos.x, 0f)) * jit.amount * (Mathf.PerlinNoise(jit.perlinTimeMulti * num + myInfo.pos.x, 0f) - 0.5f)) * myInfo.size.x;
			JitterValue_MyJit.y = jit.distanceOverTime.Evaluate(num / jit.distanceOverTimeMulti) * (jit.distance.Evaluate(Mathf.PerlinNoise(jit.perlinTimeMulti * num + myInfo.pos.x + 30f, 0f)) * jit.amount * (Mathf.PerlinNoise(jit.perlinTimeMulti * num + myInfo.pos.x + 30f, 0f) - 0.5f)) * myInfo.size.y;
			JitterValue_MyJit.z = 0f;
		}
		else
		{
			JitterValue_MyJit.x = jit.distanceOverTime.Evaluate(num / jit.distanceOverTimeMulti) * jit.distance.Evaluate(UnityEngine.Random.value) * jit.amount * (UnityEngine.Random.value - 0.5f) * myInfo.size.x;
			JitterValue_MyJit.y = jit.distanceOverTime.Evaluate(num / jit.distanceOverTimeMulti) * jit.distance.Evaluate(UnityEngine.Random.value) * jit.amount * (UnityEngine.Random.value - 0.5f) * myInfo.size.y;
			JitterValue_MyJit.z = 0f;
		}
		return JitterValue_MyJit;
	}

	private int GetDrawOrder(DrawOrder myDrawOrder, int i, int iL)
	{
		switch (myDrawOrder)
		{
		case DrawOrder.RightToLeft:
		case DrawOrder.RTLOneWordAtATime:
			return drawOrderRTL[i];
		case DrawOrder.ReverseLTR:
			return -i + iL - 1;
		default:
			return i;
		}
	}

	private void UpdateMesh(float myTime)
	{
		float getTime = GetTime;
		float num = VerticalLimit;
		int num2 = hyphenedText.Length * 4;
		areWeAnimating = false;
		if (endVerts.Length != num2)
		{
			Array.Resize(ref endVerts, num2);
		}
		if (endUv.Length != num2)
		{
			Array.Resize(ref endUv, num2);
		}
		if (endUv2.Length != num2)
		{
			Array.Resize(ref endUv2, num2);
		}
		if (endCol32.Length != num2)
		{
			Array.Resize(ref endCol32, num2);
		}
		if (ratiosAndUvMids.Count != num2)
		{
			ratiosAndUvMids = new List<Vector4>(new Vector4[num2]);
		}
		if (isUvRotated.Count != num2)
		{
			isUvRotated = new List<Vector4>(new Vector4[num2]);
		}
		int i = 0;
		for (int length = hyphenedText.Length; i < length; i++)
		{
			CurrentTextInfo = info[i];
			int num3 = GetDrawOrder(CurrentTextInfo.drawOrder, i, length);
			if (num3 <= latestNumber)
			{
				CurrentTextInfo.invoked = true;
			}
			if (readDelay == 0f)
			{
				DoEvent(i);
			}
			doPrintEventAfter = false;
			doEventAfter = false;
			if (reading)
			{
				float num4 = ((CurrentTextInfo.drawAnimData.animTime == 0f) ? 1E-07f : CurrentTextInfo.drawAnimData.animTime);
				if ((myTime - CurrentTextInfo.readTime) / num4 > 0f && !CurrentTextInfo.invoked)
				{
					CurrentTextInfo.invoked = true;
					doEventAfter = true;
					if (hyphenedText[i] != '\u200b')
					{
						doPrintEventAfter = true;
						if (hyphenedText[i] != ' ' && hyphenedText[i] != '\n')
						{
							lowestDrawnPosition = Mathf.Min(lowestDrawnPosition, CurrentTextInfo.pos.y);
							lowestDrawnPositionRaw = Mathf.Min(lowestDrawnPositionRaw, CurrentTextInfo.pos.y + offset.y);
							furthestDrawnPosition = Mathf.Max(furthestDrawnPosition, CurrentTextInfo.RelativeAdvance(characterSpacing).x + offset.x + TextBounds_rightOffset.x);
						}
					}
					latestNumber = Mathf.Max(latestNumber, num3);
				}
			}
			else if (!Application.isPlaying || num == 0f || (verticalLimitMode != VerticalLimitMode.AutoPause && verticalLimitMode != VerticalLimitMode.AutoPauseFull))
			{
				latestNumber = hyphenedText.Length - 1;
				lowestDrawnPosition = info[latestNumber].pos.y;
				lowestDrawnPositionRaw = info[latestNumber].pos.y + offset.y;
				furthestDrawnPosition = rawBottomRightTextBounds.x;
			}
			RecalculateTextBounds();
			if (doEventAfter)
			{
				DoEvent(i);
			}
			if (doPrintEventAfter)
			{
				PlaySound(i);
				if (onPrintEvent != null)
				{
					onPrintEvent.Invoke();
				}
				if (this.OnPrintEvent != null)
				{
					this.OnPrintEvent();
				}
			}
			UpdateMesh_lowestLineOffset.x = 0f;
			UpdateMesh_lowestLineOffset.y = 0f;
			UpdateMesh_lowestLineOffset.z = 0f;
			if (num > 0f && (verticalLimitMode == VerticalLimitMode.ShowLast || verticalLimitMode == VerticalLimitMode.AutoPause || verticalLimitMode == VerticalLimitMode.AutoPauseFull) && lowestDrawnPosition < 0f - rawBottomRightBounds.y)
			{
				if (verticalLimitMode == VerticalLimitMode.AutoPauseFull)
				{
					for (int j = 0; j < boxHeights.Count; j++)
					{
						UpdateMesh_lowestLineOffset.y = boxHeights[j];
						if (UpdateMesh_lowestLineOffset.y >= 0f - lowestDrawnPosition - rawBottomRightBounds.y)
						{
							break;
						}
					}
				}
				else
				{
					for (int k = 0; k < lineHeights.Count; k++)
					{
						UpdateMesh_lowestLineOffset.y += lineHeights[k];
						if (UpdateMesh_lowestLineOffset.y >= 0f - lowestDrawnPosition - rawBottomRightBounds.y)
						{
							break;
						}
					}
				}
			}
			UpdateMesh_lowestLineOffset.x += anchorOffset.x;
			UpdateMesh_lowestLineOffset.y += anchorOffset.y + (info[0].lineSpacing - 1f) * info[0].size.y;
			UpdateMesh_lowestLineOffset.z += anchorOffset.z;
			jitterValue = Vector3.zero;
			if (CurrentTextInfo.jitterData != null && !data.disableAnimatedText && !disableAnimatedText)
			{
				areWeAnimating = true;
				jitterValue = JitterValue(CurrentTextInfo, CurrentTextInfo.jitterData);
			}
			UpdateMesh_waveValue = Vector3.zero;
			UpdateMesh_waveValueTopLeft = Vector3.zero;
			UpdateMesh_waveValueTopRight = Vector3.zero;
			UpdateMesh_waveValueBottomRight = Vector3.zero;
			UpdateMesh_waveValueBottomLeft = Vector3.zero;
			if (CurrentTextInfo.waveData != null && CurrentTextInfo.size.y != 0f && !data.disableAnimatedText && !disableAnimatedText)
			{
				areWeAnimating = true;
				float myTime2 = (CurrentTextInfo.waveData.animateFromTimeDrawn ? (currentReadTime - CurrentTextInfo.readTime) : getTime);
				if (CurrentTextInfo.waveData.positionControl)
				{
					UpdateMesh_waveValue = WavePosition(CurrentTextInfo, CurrentTextInfo.waveData.position, myTime2);
				}
				if (CurrentTextInfo.waveData.individualVertexControl)
				{
					UpdateMesh_wavePosition = WavePosition(CurrentTextInfo, CurrentTextInfo.waveData.topLeft, myTime2);
					UpdateMesh_waveValueTopLeft.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueTopLeft.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueTopLeft.z += UpdateMesh_wavePosition.z;
					UpdateMesh_wavePosition = WavePosition(CurrentTextInfo, CurrentTextInfo.waveData.topRight, myTime2);
					UpdateMesh_waveValueTopRight.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueTopRight.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueTopRight.z += UpdateMesh_wavePosition.z;
					UpdateMesh_wavePosition = WavePosition(CurrentTextInfo, CurrentTextInfo.waveData.bottomRight, myTime2);
					UpdateMesh_waveValueBottomRight.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueBottomRight.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueBottomRight.z += UpdateMesh_wavePosition.z;
					UpdateMesh_wavePosition = WavePosition(CurrentTextInfo, CurrentTextInfo.waveData.bottomLeft, myTime2);
					UpdateMesh_waveValueBottomLeft.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueBottomLeft.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueBottomLeft.z += UpdateMesh_wavePosition.z;
				}
				if (CurrentTextInfo.waveData.rotationControl)
				{
					UpdateMesh_wavePosition = WaveRotation(CurrentTextInfo, CurrentTextInfo.waveData.rotation, CurrentTextInfo.TopLeftVert, myTime2);
					UpdateMesh_waveValueTopLeft.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueTopLeft.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueTopLeft.z += UpdateMesh_wavePosition.z;
					UpdateMesh_wavePosition = WaveRotation(CurrentTextInfo, CurrentTextInfo.waveData.rotation, CurrentTextInfo.TopRightVert, myTime2);
					UpdateMesh_waveValueTopRight.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueTopRight.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueTopRight.z += UpdateMesh_wavePosition.z;
					UpdateMesh_wavePosition = WaveRotation(CurrentTextInfo, CurrentTextInfo.waveData.rotation, CurrentTextInfo.BottomRightVert, myTime2);
					UpdateMesh_waveValueBottomRight.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueBottomRight.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueBottomRight.z += UpdateMesh_wavePosition.z;
					UpdateMesh_wavePosition = WaveRotation(CurrentTextInfo, CurrentTextInfo.waveData.rotation, CurrentTextInfo.BottomLeftVert, myTime2);
					UpdateMesh_waveValueBottomLeft.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueBottomLeft.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueBottomLeft.z += UpdateMesh_wavePosition.z;
				}
				if (CurrentTextInfo.waveData.scaleControl)
				{
					UpdateMesh_wavePosition = WaveScale(CurrentTextInfo, CurrentTextInfo.waveData.scale, CurrentTextInfo.TopLeftVert, myTime2);
					UpdateMesh_waveValueTopLeft.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueTopLeft.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueTopLeft.z += UpdateMesh_wavePosition.z;
					UpdateMesh_wavePosition = WaveScale(CurrentTextInfo, CurrentTextInfo.waveData.scale, CurrentTextInfo.TopRightVert, myTime2);
					UpdateMesh_waveValueTopRight.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueTopRight.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueTopRight.z += UpdateMesh_wavePosition.z;
					UpdateMesh_wavePosition = WaveScale(CurrentTextInfo, CurrentTextInfo.waveData.scale, CurrentTextInfo.BottomRightVert, myTime2);
					UpdateMesh_waveValueBottomRight.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueBottomRight.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueBottomRight.z += UpdateMesh_wavePosition.z;
					UpdateMesh_wavePosition = WaveScale(CurrentTextInfo, CurrentTextInfo.waveData.scale, CurrentTextInfo.BottomLeftVert, myTime2);
					UpdateMesh_waveValueBottomLeft.x += UpdateMesh_wavePosition.x;
					UpdateMesh_waveValueBottomLeft.y += UpdateMesh_wavePosition.y;
					UpdateMesh_waveValueBottomLeft.z += UpdateMesh_wavePosition.z;
				}
			}
			if (num > 0f && verticalLimitMode != VerticalLimitMode.Ignore && CurrentTextInfo.pos.y + CurrentTextInfo.size.y + UpdateMesh_lowestLineOffset.y - anchorOffset.y > 0f - rawTopLeftBounds.y + 1E-05f)
			{
				endVerts[4 * i] = Vector3.zero;
				endVerts[4 * i + 1] = Vector3.zero;
				endVerts[4 * i + 2] = Vector3.zero;
				endVerts[4 * i + 3] = Vector3.zero;
			}
			else
			{
				if (relativeBaseOffset)
				{
					realBaseOffset.x = baseOffset.x * CurrentTextInfo.size.x;
					realBaseOffset.y = baseOffset.y * CurrentTextInfo.size.y;
					realBaseOffset.z = baseOffset.z;
				}
				else
				{
					realBaseOffset.x = baseOffset.x;
					realBaseOffset.y = baseOffset.y;
					realBaseOffset.z = baseOffset.z;
				}
				endVerts[4 * i].x = CurrentTextInfo.TopLeftVert.x + jitterValue.x + UpdateMesh_waveValueTopLeft.x + UpdateMesh_waveValue.x + UpdateMesh_lowestLineOffset.x + realBaseOffset.x;
				endVerts[4 * i].y = CurrentTextInfo.TopLeftVert.y + jitterValue.y + UpdateMesh_waveValueTopLeft.y + UpdateMesh_waveValue.y + UpdateMesh_lowestLineOffset.y + realBaseOffset.y;
				endVerts[4 * i].z = CurrentTextInfo.TopLeftVert.z + jitterValue.z + UpdateMesh_waveValueTopLeft.z + UpdateMesh_waveValue.z + UpdateMesh_lowestLineOffset.z + realBaseOffset.z;
				endVerts[4 * i + 1].x = CurrentTextInfo.TopRightVert.x + jitterValue.x + UpdateMesh_waveValueTopRight.x + UpdateMesh_waveValue.x + UpdateMesh_lowestLineOffset.x + realBaseOffset.x;
				endVerts[4 * i + 1].y = CurrentTextInfo.TopRightVert.y + jitterValue.y + UpdateMesh_waveValueTopRight.y + UpdateMesh_waveValue.y + UpdateMesh_lowestLineOffset.y + realBaseOffset.y;
				endVerts[4 * i + 1].z = CurrentTextInfo.TopRightVert.z + jitterValue.z + UpdateMesh_waveValueTopRight.z + UpdateMesh_waveValue.z + UpdateMesh_lowestLineOffset.z + realBaseOffset.z;
				endVerts[4 * i + 2].x = CurrentTextInfo.BottomRightVert.x + jitterValue.x + UpdateMesh_waveValueBottomRight.x + UpdateMesh_waveValue.x + UpdateMesh_lowestLineOffset.x + realBaseOffset.x;
				endVerts[4 * i + 2].y = CurrentTextInfo.BottomRightVert.y + jitterValue.y + UpdateMesh_waveValueBottomRight.y + UpdateMesh_waveValue.y + UpdateMesh_lowestLineOffset.y + realBaseOffset.y;
				endVerts[4 * i + 2].z = CurrentTextInfo.BottomRightVert.z + jitterValue.z + UpdateMesh_waveValueBottomRight.z + UpdateMesh_waveValue.z + UpdateMesh_lowestLineOffset.z + realBaseOffset.z;
				endVerts[4 * i + 3].x = CurrentTextInfo.BottomLeftVert.x + jitterValue.x + UpdateMesh_waveValueBottomLeft.x + UpdateMesh_waveValue.x + UpdateMesh_lowestLineOffset.x + realBaseOffset.x;
				endVerts[4 * i + 3].y = CurrentTextInfo.BottomLeftVert.y + jitterValue.y + UpdateMesh_waveValueBottomLeft.y + UpdateMesh_waveValue.y + UpdateMesh_lowestLineOffset.y + realBaseOffset.y;
				endVerts[4 * i + 3].z = CurrentTextInfo.BottomLeftVert.z + jitterValue.z + UpdateMesh_waveValueBottomLeft.z + UpdateMesh_waveValue.z + UpdateMesh_lowestLineOffset.z + realBaseOffset.z;
				if (!CurrentTextInfo.isQuad)
				{
					endUv[4 * i] = CurrentTextInfo.ch.uvTopLeft;
					endUv[4 * i + 1] = CurrentTextInfo.ch.uvTopRight;
					endUv[4 * i + 2] = CurrentTextInfo.ch.uvBottomRight;
					endUv[4 * i + 3] = CurrentTextInfo.ch.uvBottomLeft;
					uvMidHold.x = CurrentTextInfo.uvMid.x;
					uvMidHold.y = CurrentTextInfo.uvMid.y;
				}
				else
				{
					endUv[4 * i] = CurrentTextInfo.quadData.UvTopLeft(getTime, CurrentTextInfo.quadIndex);
					endUv[4 * i + 1] = CurrentTextInfo.quadData.UvTopRight(getTime, CurrentTextInfo.quadIndex);
					endUv[4 * i + 2] = CurrentTextInfo.quadData.UvBottomRight(getTime, CurrentTextInfo.quadIndex);
					endUv[4 * i + 3] = CurrentTextInfo.quadData.UvBottomLeft(getTime, CurrentTextInfo.quadIndex);
					uvMidHold = CurrentTextInfo.quadData.UvMiddle(getTime, CurrentTextInfo.quadIndex);
					if (CurrentTextInfo.quadData.columns > 1 && CurrentTextInfo.quadData.animDelay > 0f && CurrentTextInfo.quadIndex < 0)
					{
						areWeAnimating = true;
					}
				}
			}
			Texture texture = ((CurrentTextInfo.fontData != null) ? CurrentTextInfo.fontData.font.material.mainTexture : font.material.mainTexture);
			ratioAndUvHold.x = texture.width;
			ratioAndUvHold.y = texture.height;
			ratioAndUvHold.z = uvMidHold.x;
			ratioAndUvHold.w = uvMidHold.y;
			ratiosAndUvMids[4 * i] = ratioAndUvHold;
			ratiosAndUvMids[4 * i + 1] = ratioAndUvHold;
			ratiosAndUvMids[4 * i + 2] = ratioAndUvHold;
			ratiosAndUvMids[4 * i + 3] = ratioAndUvHold;
			ratioAndUvHold.x = ((endUv[4 * i].x != endUv[4 * i + 3].x) ? 1 : 0);
			float num5 = Mathf.Sign(CurrentTextInfo.chMaxY);
			if (CurrentTextInfo.isQuad)
			{
				num5 = -1f;
			}
			ratioAndUvHold.y = CurrentTextInfo.size.y * num5;
			if (CurrentTextInfo.isQuad)
			{
				ratioAndUvHold.z = CurrentTextInfo.quadData.pixelSize.x / ((float)CurrentTextInfo.quadData.texture.width * CurrentTextInfo.quadData.size.x / 4f);
				ratioAndUvHold.w = CurrentTextInfo.quadData.pixelSize.y / ((float)CurrentTextInfo.quadData.texture.height * CurrentTextInfo.quadData.size.y / 4f);
			}
			else
			{
				ratioAndUvHold.z = (float)CurrentTextInfo.chSize / ((float)texture.width / 4f);
				ratioAndUvHold.w = (float)CurrentTextInfo.chSize / ((float)texture.height / 4f);
			}
			isUvRotated[4 * i] = ratioAndUvHold;
			isUvRotated[4 * i + 1] = ratioAndUvHold;
			isUvRotated[4 * i + 2] = ratioAndUvHold;
			isUvRotated[4 * i + 3] = ratioAndUvHold;
			if (CurrentTextInfo.textureData != null && (i != length - 1 || (i == length - 1 && CurrentTextInfo.TopRightVert != Vector3.zero)))
			{
				if (CurrentTextInfo.textureData.scrollSpeed != Vector2.zero)
				{
					areWeAnimating = true;
				}
				UpdateMesh_uvOffset.x = getTime * CurrentTextInfo.textureData.scrollSpeed.x;
				UpdateMesh_uvOffset.y = getTime * CurrentTextInfo.textureData.scrollSpeed.y;
				float num6 = 1f;
				if (CurrentTextInfo.textureData.scaleWithText)
				{
					num6 = 1f / CurrentTextInfo.size.y;
				}
				cacheVectThree = endVerts[4 * i];
				vectA.x = cacheVectThree.x;
				vectA.y = cacheVectThree.y;
				cacheVectThree = endVerts[4 * i + 1];
				vectB.x = cacheVectThree.x;
				vectB.y = cacheVectThree.y;
				cacheVectThree = endVerts[4 * i + 2];
				vectC.x = cacheVectThree.x;
				vectC.y = cacheVectThree.y;
				cacheVectThree = endVerts[4 * i + 3];
				vectD.x = cacheVectThree.x;
				vectD.y = cacheVectThree.y;
				if (CurrentTextInfo.textureData.relativeToLetter)
				{
					infoVect.x = CurrentTextInfo.pos.x;
					infoVect.y = CurrentTextInfo.pos.y;
					endUv2[4 * i].x = num6 * (vectA.x - infoVect.x) + UpdateMesh_uvOffset.x - CurrentTextInfo.textureData.offset.x;
					endUv2[4 * i].y = num6 * (vectA.y - infoVect.y) + UpdateMesh_uvOffset.y - CurrentTextInfo.textureData.offset.y;
					endUv2[4 * i + 1].x = num6 * (vectB.x - infoVect.x) + UpdateMesh_uvOffset.x - CurrentTextInfo.textureData.offset.x;
					endUv2[4 * i + 1].y = num6 * (vectB.y - infoVect.y) + UpdateMesh_uvOffset.y - CurrentTextInfo.textureData.offset.y;
					endUv2[4 * i + 2].x = num6 * (vectC.x - infoVect.x) + UpdateMesh_uvOffset.x - CurrentTextInfo.textureData.offset.x;
					endUv2[4 * i + 2].y = num6 * (vectC.y - infoVect.y) + UpdateMesh_uvOffset.y - CurrentTextInfo.textureData.offset.y;
					endUv2[4 * i + 3].x = num6 * (vectD.x - infoVect.x) + UpdateMesh_uvOffset.x - CurrentTextInfo.textureData.offset.x;
					endUv2[4 * i + 3].y = num6 * (vectD.y - infoVect.y) + UpdateMesh_uvOffset.y - CurrentTextInfo.textureData.offset.y;
				}
				else
				{
					endUv2[4 * i].x = num6 * vectA.x + UpdateMesh_uvOffset.x - CurrentTextInfo.textureData.offset.x;
					endUv2[4 * i].y = num6 * vectA.y + UpdateMesh_uvOffset.y - CurrentTextInfo.textureData.offset.y;
					endUv2[4 * i + 1].x = num6 * vectB.x + UpdateMesh_uvOffset.x - CurrentTextInfo.textureData.offset.x;
					endUv2[4 * i + 1].y = num6 * vectB.y + UpdateMesh_uvOffset.y - CurrentTextInfo.textureData.offset.y;
					endUv2[4 * i + 2].x = num6 * vectC.x + UpdateMesh_uvOffset.x - CurrentTextInfo.textureData.offset.x;
					endUv2[4 * i + 2].y = num6 * vectC.y + UpdateMesh_uvOffset.y - CurrentTextInfo.textureData.offset.y;
					endUv2[4 * i + 3].x = num6 * vectD.x + UpdateMesh_uvOffset.x - CurrentTextInfo.textureData.offset.x;
					endUv2[4 * i + 3].y = num6 * vectD.y + UpdateMesh_uvOffset.y - CurrentTextInfo.textureData.offset.y;
				}
			}
			if (CurrentTextInfo.isQuad && !CurrentTextInfo.quadData.silhouette)
			{
				endUv2[4 * i] = endUv[4 * i];
				endUv2[4 * i + 1] = endUv[4 * i + 1];
				endUv2[4 * i + 2] = endUv[4 * i + 2];
				endUv2[4 * i + 3] = endUv[4 * i + 3];
			}
			if (CurrentTextInfo.isQuad && !CurrentTextInfo.quadData.silhouette)
			{
				endCol32[4 * i] = Color.white;
				endCol32[4 * i + 1] = Color.white;
				endCol32[4 * i + 2] = Color.white;
				endCol32[4 * i + 3] = Color.white;
			}
			else if (CurrentTextInfo.gradientData != null)
			{
				if (CurrentTextInfo.gradientData.scrollSpeed != 0f)
				{
					areWeAnimating = true;
				}
				if (CurrentTextInfo.gradientData.direction == STMGradientData.GradientDirection.Vertical)
				{
					if (!CurrentTextInfo.gradientData.smoothGradient)
					{
						endCol32[4 * i] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + CurrentTextInfo.pos.y * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
						endCol32[4 * i + 1] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + CurrentTextInfo.pos.y * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
						endCol32[4 * i + 2] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + CurrentTextInfo.pos.y * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
						endCol32[4 * i + 3] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + CurrentTextInfo.pos.y * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
					}
					else
					{
						endCol32[4 * i] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + (CurrentTextInfo.pos.y + CurrentTextInfo.size.y) * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
						endCol32[4 * i + 1] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + (CurrentTextInfo.pos.y + CurrentTextInfo.size.y) * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
						endCol32[4 * i + 2] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + CurrentTextInfo.pos.y * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
						endCol32[4 * i + 3] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + CurrentTextInfo.pos.y * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
					}
				}
				else if (!CurrentTextInfo.gradientData.smoothGradient)
				{
					endCol32[4 * i] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + endVerts[4 * i].x * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
					endCol32[4 * i + 1] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + endVerts[4 * i].x * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
					endCol32[4 * i + 2] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + endVerts[4 * i].x * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
					endCol32[4 * i + 3] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + endVerts[4 * i].x * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
				}
				else
				{
					endCol32[4 * i] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + endVerts[4 * i].x * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
					endCol32[4 * i + 1] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + endVerts[4 * i + 1].x * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
					endCol32[4 * i + 2] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + endVerts[4 * i + 2].x * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
					endCol32[4 * i + 3] = CurrentTextInfo.gradientData.gradient.Evaluate(Mathf.Repeat(getTime * CurrentTextInfo.gradientData.scrollSpeed + endVerts[4 * i + 3].x * CurrentTextInfo.gradientData.gradientSpread / CurrentTextInfo.size.y, 1f));
				}
				if (CurrentTextInfo.colorData != null)
				{
					ref Color32 reference = ref endCol32[4 * i];
					reference *= CurrentTextInfo.colorData.color;
					ref Color32 reference2 = ref endCol32[4 * i + 1];
					reference2 *= CurrentTextInfo.colorData.color;
					ref Color32 reference3 = ref endCol32[4 * i + 2];
					reference3 *= CurrentTextInfo.colorData.color;
					ref Color32 reference4 = ref endCol32[4 * i + 3];
					reference4 *= CurrentTextInfo.colorData.color;
				}
			}
			else if (CurrentTextInfo.textureData != null)
			{
				endCol32[4 * i] = Color.white;
				endCol32[4 * i + 1] = Color.white;
				endCol32[4 * i + 2] = Color.white;
				endCol32[4 * i + 3] = Color.white;
				if (CurrentTextInfo.colorData != null)
				{
					ref Color32 reference5 = ref endCol32[4 * i];
					reference5 *= CurrentTextInfo.colorData.color;
					ref Color32 reference6 = ref endCol32[4 * i + 1];
					reference6 *= CurrentTextInfo.colorData.color;
					ref Color32 reference7 = ref endCol32[4 * i + 2];
					reference7 *= CurrentTextInfo.colorData.color;
					ref Color32 reference8 = ref endCol32[4 * i + 3];
					reference8 *= CurrentTextInfo.colorData.color;
				}
			}
			else if (CurrentTextInfo.colorData != null)
			{
				endCol32[4 * i] = CurrentTextInfo.colorData.color;
				endCol32[4 * i + 1] = CurrentTextInfo.colorData.color;
				endCol32[4 * i + 2] = CurrentTextInfo.colorData.color;
				endCol32[4 * i + 3] = CurrentTextInfo.colorData.color;
			}
			else
			{
				endCol32[4 * i] = color;
				endCol32[4 * i + 1] = color;
				endCol32[4 * i + 2] = color;
				endCol32[4 * i + 3] = color;
			}
			endCol32[4 * i].a = (byte)((float)(int)endCol32[4 * i].a * fade);
			endCol32[4 * i + 1].a = (byte)((float)(int)endCol32[4 * i + 1].a * fade);
			endCol32[4 * i + 2].a = (byte)((float)(int)endCol32[4 * i + 2].a * fade);
			endCol32[4 * i + 3].a = (byte)((float)(int)endCol32[4 * i + 3].a * fade);
			if (!uiMode && myColorSpace == 1)
			{
				endCol32[4 * i] = ((Color)endCol32[4 * i]).linear;
				endCol32[4 * i + 1] = ((Color)endCol32[4 * i + 1]).linear;
				endCol32[4 * i + 2] = ((Color)endCol32[4 * i + 2]).linear;
				endCol32[4 * i + 3] = ((Color)endCol32[4 * i + 3]).linear;
			}
		}
		if ((onVertexMod != null && onVertexMod.GetPersistentEventCount() > 0) || this.OnVertexMod != null)
		{
			if (UpdateMesh_Middles.Length != hyphenedText.Length)
			{
				Array.Resize(ref UpdateMesh_Middles, hyphenedText.Length);
			}
			if (UpdateMesh_Positions.Length != hyphenedText.Length)
			{
				Array.Resize(ref UpdateMesh_Positions, hyphenedText.Length);
			}
			int l = 0;
			for (int length2 = hyphenedText.Length; l < length2; l++)
			{
				CurrentTextInfo = info[l];
				UpdateMesh_Middles[l] = CurrentTextInfo.Middle;
				UpdateMesh_Positions[l] = CurrentTextInfo.pos;
			}
			if (onVertexMod != null)
			{
				onVertexMod.Invoke(endVerts, UpdateMesh_Middles, UpdateMesh_Positions);
			}
			if (this.OnVertexMod != null)
			{
				this.OnVertexMod(endVerts, UpdateMesh_Middles, UpdateMesh_Positions);
			}
			areWeAnimating = true;
		}
		if (data.disableAnimatedText || disableAnimatedText)
		{
			areWeAnimating = false;
		}
	}

	public void SetMesh(float timeValue)
	{
		SetMesh(timeValue, undrawingMesh: false);
	}

	private void SetMesh(float timeValue, bool undrawingMesh)
	{
		if (textMesh == null)
		{
			textMesh = new Mesh();
			textMesh.MarkDynamic();
		}
		textMesh.Clear();
		if (text.Length > 0)
		{
			if (reading || unreading)
			{
				UpdateDrawnMesh(timeValue, undrawingMesh);
				textMesh.vertices = midVerts;
				textMesh.colors32 = midCol32;
			}
			else if (timeValue == 0f || undrawingMesh)
			{
				UpdatePreReadMesh(undrawingMesh);
				textMesh.vertices = startVerts;
				textMesh.colors32 = startCol32;
			}
			else
			{
				UpdateMesh(totalReadTime + 1f);
				textMesh.vertices = endVerts;
				textMesh.colors32 = endCol32;
			}
			textMesh.uv = endUv;
			textMesh.uv2 = endUv2;
			textMesh.SetUVs(2, ratiosAndUvMids);
			textMesh.SetUVs(3, isUvRotated);
			if (submeshes.Count > 1)
			{
				textMesh.subMeshCount = submeshes.Count;
				int i = 0;
				for (int subMeshCount = textMesh.subMeshCount; i < subMeshCount; i++)
				{
					textMesh.SetTriangles(submeshes[i].tris, i);
				}
			}
			else if (submeshes.Count > 0)
			{
				textMesh.subMeshCount = 1;
				textMesh.SetTriangles(submeshes[0].tris, 0);
			}
			textMesh.UploadMeshData(markNoLongerReadable: false);
		}
		ApplyMesh();
	}

	private void ApplyMesh()
	{
		if (uiMode)
		{
			c.SetMesh(textMesh);
		}
		else
		{
			f.sharedMesh = textMesh;
		}
	}

	[ContextMenu("Clear Materials")]
	public void ClearMaterials()
	{
		if (uiMode)
		{
			int i = 0;
			for (int materialCount = c.materialCount; i < materialCount; i++)
			{
				UnityEngine.Object.DestroyImmediate(c.GetMaterial(i));
			}
			c.materialCount = 0;
		}
		else
		{
			int j = 0;
			for (int num = r.sharedMaterials.Length; j < num; j++)
			{
				UnityEngine.Object.DestroyImmediate(r.sharedMaterials[j]);
			}
		}
		SharedMaterialDataStorage.allMaterials.Clear();
	}

	private void ApplyMaterials()
	{
		if (submeshMaterials.Length != submeshes.Count)
		{
			Array.Resize(ref submeshMaterials, submeshes.Count);
		}
		int i = 0;
		for (int num = submeshMaterials.Length; i < num; i++)
		{
			submeshMaterials[i] = submeshes[i].sharedMaterialData.AsMaterial;
		}
		if (uiMode)
		{
			if (this != null && t.gameObject.activeInHierarchy)
			{
				parentCanvas = t.GetComponentInParent<Canvas>();
				if (parentCanvas != null)
				{
					parentCanvas.additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord1;
					parentCanvas.additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord2;
					parentCanvas.additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord3;
				}
				c.materialCount = submeshMaterials.Length + 1;
				for (int j = 0; j < c.materialCount - 1; j++)
				{
					c.SetMaterial(submeshMaterials[j], j);
				}
			}
		}
		else
		{
			r.sharedMaterials = submeshMaterials;
		}
	}

	private SubmeshData DoesSubmeshExist(SharedMaterialData materialData)
	{
		for (int i = 0; i < submeshes.Count; i++)
		{
			if (submeshes[i].sharedMaterialData == materialData)
			{
				return submeshes[i];
			}
		}
		return null;
	}

	private void PrepareSubmeshes()
	{
		submeshes.Clear();
		if (info.Count > 0 && info[0] != null)
		{
			Submesh_sharedMaterial = SharedMaterialDataStorage.DoesSharedMaterialExist(this);
			if (Submesh_sharedMaterial == null)
			{
				SharedMaterialDataStorage.allMaterials.Add(new SharedMaterialData(this));
				Submesh_sharedMaterial = SharedMaterialDataStorage.allMaterials[SharedMaterialDataStorage.allMaterials.Count - 1];
			}
			Submesh_submeshData = DoesSubmeshExist(Submesh_sharedMaterial);
			if (Submesh_submeshData == null)
			{
				submeshes.Add(new SubmeshData(Submesh_sharedMaterial));
				Submesh_submeshData = submeshes[submeshes.Count - 1];
			}
		}
		int i = 0;
		for (int length = hyphenedText.Length; i < length; i++)
		{
			Submesh_info = info[i];
			if (Submesh_info.submeshChange)
			{
				Submesh_sharedMaterial = SharedMaterialDataStorage.DoesSharedMaterialExist(this, Submesh_info);
			}
			if (Submesh_sharedMaterial == null)
			{
				SharedMaterialDataStorage.allMaterials.Add(new SharedMaterialData(this, Submesh_info));
				Submesh_sharedMaterial = SharedMaterialDataStorage.allMaterials[SharedMaterialDataStorage.allMaterials.Count - 1];
			}
			if (Submesh_info.submeshChange)
			{
				Submesh_submeshData = DoesSubmeshExist(Submesh_sharedMaterial);
			}
			if (Submesh_submeshData == null)
			{
				Submesh_submeshData = new SubmeshData(Submesh_sharedMaterial);
				submeshes.Add(Submesh_submeshData);
			}
			Submesh_submeshData.tris.Add(4 * i);
			Submesh_submeshData.tris.Add(4 * i + 1);
			Submesh_submeshData.tris.Add(4 * i + 2);
			Submesh_submeshData.tris.Add(4 * i);
			Submesh_submeshData.tris.Add(4 * i + 2);
			Submesh_submeshData.tris.Add(4 * i + 3);
		}
	}

	public virtual void CalculateLayoutInputHorizontal()
	{
	}

	public virtual void CalculateLayoutInputVertical()
	{
	}

	private void OnRectTransformDimensionsChange()
	{
		if (base.gameObject.activeInHierarchy && uiMode)
		{
			SpecialRebuild();
		}
	}

	public void RecalculateMasking()
	{
		if (base.gameObject.activeInHierarchy)
		{
			UpdateMaskingOnAllSubmeshes();
			ApplyMaterials();
		}
	}

	private void UpdateMaskingOnAllSubmeshes()
	{
		foreach (SubmeshData submesh in submeshes)
		{
			submesh.sharedMaterialData.SetMaskingRelatedValues(this);
		}
	}
}
