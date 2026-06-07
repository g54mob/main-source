using Client;
using Motorways;
using Motorways.Audio;
using Motorways.Themes;
using UnityEngine;
using UnityEngine.UI;

public class DrawModeToggle : MonoBehaviour, IThemeComponent
{
	public enum VisibleState
	{
		AlwaysShowing = 0,
		ShowWhenFocused = 1,
		NeverShow = 2
	}

	public Image drawIcon;

	public Image deleteIcon;

	public RectTransform selectionCircle;

	public TouchButton touchButton;

	public float toggleAnimationSpeed = 15f;

	private float _circleY;

	[SerializeField]
	private ThemedMaterialType _darkColor = ThemedMaterialType.Dark;

	[SerializeField]
	private ThemedMaterialType _lightColor;

	private Color _resolvedDarkColor = Color.black;

	private Color _resolvedLightColor = Color.white;

	[SerializeField]
	private Animator _animator;

	private static readonly int PulseTrigger = Animator.StringToHash("Pulse");

	private float _crossFadeDuration = 0.1f;

	public RoadDrawMode DrawMode { get; private set; }

	private void Awake()
	{
		_circleY = selectionCircle.anchoredPosition.y;
	}

	private void Update()
	{
		if (DrawMode == RoadDrawMode.Add && selectionCircle.anchoredPosition.y < _circleY)
		{
			Vector2 anchoredPosition = selectionCircle.anchoredPosition;
			anchoredPosition.y += _circleY * toggleAnimationSpeed * Time.deltaTime;
			anchoredPosition.y = Mathf.Min(_circleY, anchoredPosition.y);
			selectionCircle.anchoredPosition = anchoredPosition;
		}
		else if (DrawMode == RoadDrawMode.Remove && selectionCircle.anchoredPosition.y > 0f - _circleY)
		{
			Vector2 anchoredPosition2 = selectionCircle.anchoredPosition;
			anchoredPosition2.y -= _circleY * toggleAnimationSpeed * Time.deltaTime;
			anchoredPosition2.y = Mathf.Max(0f - _circleY, anchoredPosition2.y);
			selectionCircle.anchoredPosition = anchoredPosition2;
		}
	}

	public void Pulse()
	{
		_animator.SetTrigger(PulseTrigger);
	}

	public void SetDrawMode(RoadDrawMode mode)
	{
		DrawMode = mode;
		UpdateColors();
		AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.DrawMode, 0.75f, _crossFadeDuration, mode == RoadDrawMode.Add));
	}

	public void OnToggleAudio()
	{
		AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.Click, UIAudioProfile.DrawModeToggle, -1f, DrawMode == RoadDrawMode.Add));
	}

	public void UpdateColors(bool instantly = false)
	{
		drawIcon.CrossFadeColor((DrawMode == RoadDrawMode.Add) ? _resolvedDarkColor : _resolvedLightColor, instantly ? 0f : _crossFadeDuration, ignoreTimeScale: true, useAlpha: false);
		deleteIcon.CrossFadeColor((DrawMode == RoadDrawMode.Remove) ? _resolvedDarkColor : _resolvedLightColor, instantly ? 0f : _crossFadeDuration, ignoreTimeScale: true, useAlpha: false);
	}

	public void InitializeTheme(IThemeDatabase themeDatabase)
	{
	}

	public void ApplyTheme(ITheme targetTheme)
	{
		Theme theme = (Theme)targetTheme;
		_resolvedDarkColor = theme.GetColor(_darkColor);
		_resolvedLightColor = theme.GetColor(_lightColor);
		UpdateColors(instantly: true);
	}

	public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
	{
		Theme theme = (Theme)newTheme;
		_resolvedDarkColor = theme.GetColor(_darkColor);
		_resolvedLightColor = theme.GetColor(_lightColor);
		UpdateColors();
		return ThemeBlendingResult.StopBlending;
	}

	public void ReleaseTheme(IThemeDatabase themeDatabase)
	{
	}
}
