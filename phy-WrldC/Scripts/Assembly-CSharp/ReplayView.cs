using System.Text.RegularExpressions;
using TMPro;
using UnityEngine.UI;

public class ReplayView : BaseGUIView
{
	public const string CloseButtonEvent = "ReplayView.CloseButtonEvent";

	public const string CameraButtonEvent = "ReplayView.CameraButtonEvent";

	public const string GifPanelToggleEvent = "ReplayView.GifPanelToggleEvent";

	public const string MinusSpeedButtonEvent = "ReplayView.MinusSpeedButtonEvent";

	public const string PlusSpeedButtonEvent = "ReplayView.PlusSpeedButtonEvent";

	public const string ReverseToggleEvent = "ReplayView.ReverseToggleEvent";

	public const string PlayPauseButtonEvent = "ReplayView.PlayPauseButtonEvent";

	public const string TimerSliderChangedEvent = "ReplayView.TimerSliderChangedEvent";

	public const string GifRecordButtonEvent = "ReplayView.GifRecordButtonEvent";

	public const string GifSaveButtonEvent = "ReplayView.GifSaveButtonEvent";

	public const string GifOpenButtonEvent = "ReplayView.GifOpenButtonEvent";

	private Button closeButton;

	private Button cameraButton;

	private Toggle gifVisibilityToggle;

	private TextMeshProUGUI timeSpeedLabel;

	private Button minusSpeedButton;

	private Button plusSpeedButton;

	private Toggle reverseToggle;

	private Button playPauseButton;

	private TextMeshProUGUI playPauseIcon;

	private SliderManager timerSlider;

	public GifRecordingView GifRecordingView { get; private set; }

	public override void Initialize()
	{
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		cameraButton = mainPanel.transform.FindComponent<Button>("CameraButton", isRecursively: true);
		gifVisibilityToggle = mainPanel.transform.FindComponent<Toggle>("GifVisibilityToggle", isRecursively: true);
		timeSpeedLabel = mainPanel.transform.FindComponent<TextMeshProUGUI>("TimeSpeedLabel", isRecursively: true);
		minusSpeedButton = mainPanel.transform.FindComponent<Button>("MinusSpeedButton", isRecursively: true);
		plusSpeedButton = mainPanel.transform.FindComponent<Button>("PlusSpeedButton", isRecursively: true);
		reverseToggle = mainPanel.transform.FindComponent<Toggle>("ReverseToggle", isRecursively: true);
		playPauseButton = mainPanel.transform.FindComponent<Button>("PlayPauseButton", isRecursively: true);
		playPauseIcon = playPauseButton.gameObject.GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
		timerSlider = mainPanel.transform.FindComponent<SliderManager>("TimerSlider", isRecursively: true);
		timerSlider.ConfigureProperties(0f, 0f, 1f, 1f, "{0:0.00}");
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("ReplayView.CloseButtonEvent");
		});
		cameraButton.onClick.AddListener(delegate
		{
			NotifyChange("ReplayView.CameraButtonEvent");
		});
		minusSpeedButton.onClick.AddListener(delegate
		{
			NotifyChange("ReplayView.MinusSpeedButtonEvent");
		});
		plusSpeedButton.onClick.AddListener(delegate
		{
			NotifyChange("ReplayView.PlusSpeedButtonEvent");
		});
		reverseToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("ReplayView.ReverseToggleEvent", isOn);
		});
		playPauseButton.onClick.AddListener(delegate
		{
			NotifyChange("ReplayView.PlayPauseButtonEvent");
		});
		timerSlider.OnValueChangedEvent += delegate(float value)
		{
			NotifyChange("ReplayView.TimerSliderChangedEvent", value);
		};
		gifVisibilityToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("ReplayView.GifPanelToggleEvent", isOn);
		});
		GifRecordingView = new GifRecordingView(this);
	}

	public void StartGifRecording(float targetDuration, float targetFps, float targetSize, float targetQuality)
	{
		NotifyChange("ReplayView.GifRecordButtonEvent", targetDuration, targetFps, targetSize, targetQuality);
	}

	public void SaveRecordedGif()
	{
		NotifyChange("ReplayView.GifSaveButtonEvent");
	}

	public void OpenRecordedGif()
	{
		NotifyChange("ReplayView.GifOpenButtonEvent");
	}

	public void SetTimeSpeedLabel(float timeSpeedValue)
	{
		if (timeSpeedValue >= 1f)
		{
			timeSpeedLabel.SetText("+" + timeSpeedValue + "x");
		}
		else
		{
			timeSpeedLabel.SetText("-" + 1f / timeSpeedValue + "x");
		}
	}

	public void SetPlayPauseButtonState(bool isReplayPlaying)
	{
		playPauseIcon.SetText(isReplayPlaying ? Regex.Unescape("\\uf04c") : Regex.Unescape("\\uf04b"));
	}

	public void SetTimerSliderValue(float value, float timerLength)
	{
		timerSlider.SetCurrentValue(value, timerLength);
	}
}
