using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DG.Tweening;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	[ExecuteInEditMode]
	public class TextBlock3DUIView : BaseBlock3DUIView, BaseBlock3DUIView.IColliderResizable, BaseBlock3DUIView.IRectResizable, BaseBlock3DUIView.IFullWidthResizeable, IDisplaysText, IAutoFontSizeElement, ITextChanged, IRegistersFont
	{
		private struct LinkPositionData
		{
			public TMP_LinkInfo linkInfo;

			public Vector3 topLeftPosition;

			public Vector3 bottomRightPosition;
		}

		public abstract class TextEffect
		{
			public List<TMP_CharacterInfo> characterInfos;

			public float delayDuration;

			public float delayRemaining;

			public bool onlyReduceDelayWhenHovered;
		}

		public class CharacterFadeEffect : TextEffect
		{
			public int currentIndex;

			public int charactersEffectedPerFade;

			public List<float> currentDurations;

			public float durationPerCharacter;

			public float alphaStart;

			public float alphaEnd;

			public Sequence charSequence;

			public Action onComplete;
		}

		public class SectionFadeEffect : TextEffect
		{
			public float durationMax;

			public float durationCurrent;

			public string originalString;

			public float alphaStart;

			public float alphaEnd;

			public float CurrentAlpha => 0f;

			public bool IsFinished => false;
		}

		public const string TEXT_NOT_SET = "$NOTSET$";

		private string _currentTextKeyString;

		private bool _dirty;

		private string _gender;

		private int _fontIndex;

		private bool _isStarted;

		public float inlineElementFontScaleRatio;

		[SerializeField]
		public TMP_Text _text;

		protected string _rawTextCache;

		private RectTransform _textRect;

		public TextStyleId textStyleId;

		private List<TextFormatting.TextProcessor> _customTextProcessors;

		private static string InlineElementMatchTemplate;

		private bool _isInlineElementsActive;

		private bool _isTextMeshDirty;

		private List<GameObject> _bindingVisuals;

		public GameObject bindingVisualPrefab;

		private const string _bindingVisualStartingPosition = "&BV";

		private const float _bindingVisualCharacterWidth = 0.1f;

		private const float _bindingVisualTMPMonospaceWidth = 0.088f;

		private List<GameObject> _inlineIcons;

		private string _inlineIconTextReplacement;

		public const string InlineIconStartingPositionText = "&II";

		private List<GameObject> _checkBoxes;

		private string _checkBoxTextReplacement;

		private string _checkBoxStartingPosition;

		private List<GameObject> _progressBars;

		public GameObject progressBarPrefab;

		private string _progressBarTextReplacement;

		private string _progressBarStartingPosition;

		protected string _previousRawText;

		protected float _previousMaxWidth;

		public bool resizeColliderX;

		public bool resizeColliderY;

		public EventHandler ColliderResized;

		public List<NestedTooltipInteractable3DUIView> NestedTooltipProviders;

		public List<BaseInteractable3DUIView> TooltipProviders;

		private Tuple<NestedTooltipInteractable3DUIView, Tooltip3DUIView> _oldOpenTooltip;

		private List<SpoilerText3DUIView> _spoilerTexts;

		private List<NestedTooltipButton3DUIView> _nestedTooltipButtons;

		private int _indexOfOldOpenTooltip;

		private static PrefabObjectPool _spoilerTextPrefab;

		private static PrefabObjectPool _nestedTooltipButton;

		public const string SPOILER_TEXT_LINK_ID = "SPOILER_TEXT";

		private List<TextEffect> _textEffects;

		private PrefabObjectPool _characterFadeParticlePool;

		public GameObject characterFadeParticlePrefab;

		private List<Action> _textEffectCleanUpActions;

		private PrefabObjectPool _characterHighlightParticlePool;

		public GameObject characterHighlightParticlePrefab;

		private List<Action> _delayedActions;

		public bool SilenceChangedEventsOnce { get; set; }

		public int FontIndex => 0;

		public bool EnableAutoSizing
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float FontSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float FontSizeWithoutScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxFontSizeWithoutScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected RectTransform TextRect => null;

		public event EventHandler LanguageChanged
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

		public event EventHandler TextChanged
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

		protected virtual void OnEnable()
		{
		}

		public void DisplayText(string keyString, string gender = "male")
		{
		}

		public void ClearTextKey()
		{
		}

		public FontData GetFontData()
		{
			return null;
		}

		public string GetCurrentTextKeyString()
		{
			return null;
		}

		protected void Start()
		{
		}

		public void ForceUpdateText()
		{
		}

		private void UpdateText()
		{
		}

		private void UpdateEnsureCorrectFont()
		{
		}

		private void OnLanguageChanged(object sender, EventArgs e)
		{
		}

		public void RaiseTextChangedEvent()
		{
		}

		public void ForceMeshUpdate()
		{
		}

		public float CalculateInlineElementScale()
		{
			return 0f;
		}

		public override void SetBlockData(string data)
		{
		}

		private void SetBasicText(string text)
		{
		}

		private void SetRichText(string text)
		{
		}

		protected virtual void ApplyText(string text)
		{
		}

		public string GetRawText()
		{
			return null;
		}

		public string GetText()
		{
			return null;
		}

		public float GetRectWidth()
		{
			return 0f;
		}

		public void AddCustomPreProcessor(TextFormatting.TextProcessor textProcessor)
		{
		}

		private StringBuilder ProcessInlineTextAliases(StringBuilder sb)
		{
			return null;
		}

		private void CleanUpInlineElements()
		{
		}

		private void ParseInlineElements()
		{
		}

		public void SetInlineElementsActive(bool active)
		{
		}

		public void UpdateInlineElements()
		{
		}

		public void PositionInlineElements()
		{
		}

		private void PositionInlineElements(string startingPositionString, List<GameObject> elements, bool centerAlign = false)
		{
		}

		private void RebuildMesh()
		{
		}

		private GameObject NewBindingVisual(Dictionary<string, string> attributes)
		{
			return null;
		}

		private void ParseBindingVisual()
		{
		}

		private GameObject NewInlineIcon(Dictionary<string, string> attributes, ref string textReplacement)
		{
			return null;
		}

		private void ParseInlineIcons()
		{
		}

		private GameObject NewCheckBox(Dictionary<string, string> attributes)
		{
			return null;
		}

		private void ParseCheckBoxes()
		{
		}

		private GameObject NewProgressBar(Dictionary<string, string> attributes)
		{
			return null;
		}

		private void ParseProgressBar()
		{
		}

		public virtual void ResizeToContent(float maxWidth)
		{
		}

		public virtual void ResizeToWidth(float width)
		{
		}

		public virtual void ResizeColliderToContent()
		{
		}

		public float GetColliderWidth()
		{
			return 0f;
		}

		private bool IsCharacterVisible(TMP_CharacterInfo charInfo)
		{
			return false;
		}

		private void UpdateTooltipLinks()
		{
		}

		private void PositionLinkObject(LinkPositionData linkPositionData, GameObject nestedObj, float zSize)
		{
		}

		private float GetZSize()
		{
			return 0f;
		}

		private List<LinkPositionData> GetLinkPositionData(TMP_TextInfo textInfo)
		{
			return null;
		}

		public SectionFadeEffect FadeInSection(string effectedText, float duration, float delay = 0f, bool onlyReduceDelayWhenHovered = false)
		{
			return null;
		}

		public SectionFadeEffect FadeOutSection(string effectedText, float duration, float delay = 0f, bool onlyReduceDelayWhenHovered = false)
		{
			return null;
		}

		public SectionFadeEffect FadeSection(string effectedText, float duration, float delay = 0f, bool onlyReduceDelayWhenHovered = false, float alphaStart = 0f, float alphaEnd = 1f)
		{
			return null;
		}

		public CharacterFadeEffect FadeOutAllCharacters(float delay = 0f, float durationPerCharacter = 0.1f, Action onComplete = null)
		{
			return null;
		}

		public CharacterFadeEffect FadeInAllCharacters(float delay = 0f, float durationPerCharacter = 0.1f, Action onComplete = null)
		{
			return null;
		}

		public void HideAllCharacters()
		{
		}

		private void UpdateCharacterFadeEffect(CharacterFadeEffect effect)
		{
		}

		public List<ParticleCleanUp> HighlightAll()
		{
			return null;
		}

		private void UpdateTextEffectData()
		{
		}

		private void UpdateSectionFadeEffect(SectionFadeEffect effect)
		{
		}

		private void UpdateCharacterAlphaValues(IEnumerable<TMP_CharacterInfo> charInfos, byte alphaByteValue)
		{
		}

		public void SetColor(Color color)
		{
		}

		private void UpdateCharacterRGBAValue(TMP_CharacterInfo charInfo, byte? r, byte? g, byte? b, byte? a, bool updateVertexData = true)
		{
		}

		private void UpdateTextEffects()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public void ResetTextEffects()
		{
		}

		private void OnDestroy()
		{
		}

		public void ReregisterFontWith(Material material)
		{
		}
	}
}
