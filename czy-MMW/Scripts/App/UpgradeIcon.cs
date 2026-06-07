using System;
using Client;
using Easing;
using Motorways;
using Motorways.Themes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup), typeof(Animator))]
public class UpgradeIcon : MonoBehaviour, IThemeComponent
{
	[SerializeField]
	private RectTransform _rectTransform;

	public Image iconRenderer;

	public Image fillRenderer;

	public Image outlineRenderer;

	[SerializeField]
	private Image[] _highlightTargets;

	[SerializeField]
	private Material circleMaterial;

	[SerializeField]
	private Material circleOutlineMaterial;

	[SerializeField]
	private Material diamondMaterial;

	[SerializeField]
	private Material diamondOutlineMaterial;

	[Range(0f, 1f)]
	[SerializeField]
	private float _cutoutRadiusPadding = 0.15f;

	[SerializeField]
	private bool _isStackIcon = true;

	private ThemedComponent[] _themedComponents;

	private Animator _animator;

	private TweenFloat _scaleTween = new TweenFloat();

	private const float BounceTweenDuration = 0.5f;

	private const float ShrinkTweenDuration = 0.1f;

	private const float BounceTweenScaleStart = 0.7f;

	private const float BounceTweenScaleEnd = 1f;

	private static readonly int PulseTrigger = Animator.StringToHash("Pulse");

	[SerializeField]
	[StringEnumSearch(typeof(ThemedMaterialType))]
	private string _baseThemeColor = ThemedMaterialType.Dark.ToString();

	private ThemedMaterialType _baseThemeColorEnum = ThemedMaterialType.Dark;

	[StringEnumSearch(typeof(ThemedMaterialType))]
	[SerializeField]
	private string _highlightThemeColor = ThemedMaterialType.HighlightedButton.ToString();

	private ThemedMaterialType _highlightThemeColorEnum = ThemedMaterialType.HighlightedButton;

	private Color _darkColor = Color.black;

	private Color _highlightColor = Color.yellow;

	private bool _isVisible = true;

	private bool _isHighlighted;

	public bool IsDisabled;

	private int _outlineIndex;

	private RectTransform _cutoutRect;

	private CanvasGroup _canvasGroup;

	private static readonly int CircleRadiusPropertyId = Shader.PropertyToID("_CircleSize");

	private static readonly int CutoutPositionPropertyId = Shader.PropertyToID("_CutoutPosition");

	private static readonly int CutoutRadiusPropertyId = Shader.PropertyToID("_CutoutRadius");

	public bool IsHighlighted
	{
		get
		{
			return _isHighlighted;
		}
		set
		{
			_isHighlighted = value;
			UpdateColors();
		}
	}

	public RectTransform Rect { get; private set; }

	private float Alpha
	{
		get
		{
			return _canvasGroup.alpha;
		}
		set
		{
			if (_canvasGroup == null)
			{
				_canvasGroup = GetComponent<CanvasGroup>();
			}
			_canvasGroup.alpha = Math.Min(value, _canvasGroup.alpha);
		}
	}

	public void SetToCircle()
	{
		if (fillRenderer != null)
		{
			fillRenderer.material = circleMaterial;
		}
		if (outlineRenderer != null)
		{
			outlineRenderer.material = circleOutlineMaterial;
		}
	}

	public void SetToDiamond()
	{
		if (fillRenderer != null)
		{
			fillRenderer.material = diamondMaterial;
		}
		if (outlineRenderer != null)
		{
			outlineRenderer.material = diamondOutlineMaterial;
		}
	}

	public void Bounce()
	{
		_scaleTween.Start(0.7f, 1f, 0.5f, Easings.Functions.BounceEaseOut);
	}

	public void SetVisible(bool nowVisible, TransitionStyle animate = TransitionStyle.Snap)
	{
		if (fillRenderer != null)
		{
			fillRenderer.enabled = nowVisible || animate == TransitionStyle.Tween;
		}
		if (outlineRenderer != null)
		{
			outlineRenderer.enabled = nowVisible || animate == TransitionStyle.Tween;
		}
		if (iconRenderer != null)
		{
			iconRenderer.enabled = nowVisible || animate == TransitionStyle.Tween;
		}
		if (nowVisible)
		{
			UpdateColors();
		}
		if (animate == TransitionStyle.Tween)
		{
			if (nowVisible && !_isVisible)
			{
				_scaleTween.Start(0.7f, 1f, 0.5f, Easings.Functions.BounceEaseOut);
			}
			else if (!nowVisible && _isVisible)
			{
				_scaleTween.Start(1f, 0f, 0.1f, Easings.Functions.Linear);
			}
		}
		_isVisible = nowVisible;
	}

	public void SetCutoutRect(RectTransform cutoutRect)
	{
		_cutoutRect = cutoutRect;
		fillRenderer.material = new Material(fillRenderer.material);
		UpdateCutoutRect();
	}

	private void UpdateCutoutRect()
	{
		if ((bool)_cutoutRect)
		{
			Material material = _cutoutRect.GetComponent<UpgradeIcon>().fillRenderer.material;
			if (material.HasProperty(CircleRadiusPropertyId))
			{
				float num = material.GetFloat(CircleRadiusPropertyId);
				Vector3 vector = _rectTransform.InverseTransformPoint(_cutoutRect.position) / (_rectTransform.rect.size / 2f);
				vector.x *= -1f;
				float num2 = _cutoutRect.rect.size.x * _cutoutRect.lossyScale.x * num / (_rectTransform.rect.size.x * _rectTransform.lossyScale.x);
				num2 += _cutoutRadiusPadding;
				fillRenderer.material.SetVector(CutoutPositionPropertyId, vector);
				fillRenderer.material.SetFloat(CutoutRadiusPropertyId, num2);
			}
			else
			{
				fillRenderer.material.SetFloat(CutoutRadiusPropertyId, 0f);
			}
		}
	}

	public void Awake()
	{
		Rect = GetComponent<RectTransform>();
		_canvasGroup = GetComponent<CanvasGroup>();
		_animator = GetComponent<Animator>();
		if (!Diagnostics.Verify(Enum.TryParse<ThemedMaterialType>(_highlightThemeColor, out _highlightThemeColorEnum)))
		{
			_highlightThemeColorEnum = ThemedMaterialType.HighlightedButton;
		}
		if (!Diagnostics.Verify(Enum.TryParse<ThemedMaterialType>(_baseThemeColor, out _baseThemeColorEnum)))
		{
			_baseThemeColorEnum = ThemedMaterialType.Dark;
		}
	}

	private void OnEnable()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
		SetVisible(_isVisible);
	}

	public void SetOutlineIndex(int index)
	{
		_outlineIndex = index;
		UpdateColors();
	}

	private void UpdateColors()
	{
		if (!_isVisible || IsDisabled)
		{
			return;
		}
		for (int i = 0; i < _highlightTargets.Length; i++)
		{
			Image image = _highlightTargets[i];
			if (image != null)
			{
				image.color = (IsHighlighted ? _highlightColor : _darkColor);
			}
		}
		if (_isStackIcon)
		{
			Alpha = 1f - (float)_outlineIndex / (float)UpgradeButtonStack.MaxVisibleIcons;
			if (iconRenderer != null)
			{
				iconRenderer.enabled = _outlineIndex == 0;
			}
		}
	}

	public void Pulse()
	{
		_animator.SetTrigger(PulseTrigger);
	}

	public void InitializeTheme(IThemeDatabase themeDatabase)
	{
	}

	public void ApplyTheme(ITheme theme)
	{
		Theme theme2 = (Theme)theme;
		if (!(theme2 == null))
		{
			_darkColor = theme2.GetColor(_baseThemeColorEnum);
			_highlightColor = theme2.GetColor(_highlightThemeColorEnum);
			UpdateColors();
			if (_themedComponents == null)
			{
				_themedComponents = GetComponentsInChildren<ThemedComponent>();
			}
			ThemedComponent[] themedComponents = _themedComponents;
			for (int i = 0; i < themedComponents.Length; i++)
			{
				themedComponents[i].ApplyTheme(theme);
			}
		}
	}

	public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
	{
		Theme theme = (Theme)newTheme;
		_darkColor = theme.GetColor(_baseThemeColorEnum);
		_highlightColor = theme.GetColor(_highlightThemeColorEnum);
		UpdateColors();
		ThemeBlendingResult result = ThemeBlendingResult.StopBlending;
		if (_themedComponents == null)
		{
			_themedComponents = GetComponentsInChildren<ThemedComponent>();
		}
		ThemedComponent[] themedComponents = _themedComponents;
		for (int i = 0; i < themedComponents.Length; i++)
		{
			if (themedComponents[i].ApplyBlendedTheme(oldTheme, newTheme, progress) == ThemeBlendingResult.ContinueBlending)
			{
				result = ThemeBlendingResult.ContinueBlending;
			}
		}
		return result;
	}

	public void ReleaseTheme(IThemeDatabase themeDatabase)
	{
	}

	private void Update()
	{
		if (_scaleTween.IsActive)
		{
			_scaleTween.Tick(Time.deltaTime);
			base.transform.localScale = Vector3.one * _scaleTween.Value;
		}
		UpdateCutoutRect();
	}
}
