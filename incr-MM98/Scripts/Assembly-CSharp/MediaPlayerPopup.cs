using Cysharp.Text;
using Cysharp.Threading.Tasks;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class MediaPlayerPopup : Popup
{
	private const string NoClipName = "missing";

	[SerializeField]
	private LocalizeStringHandler clipNameHandler;

	[SerializeField]
	private Slider progressSlider;

	[SerializeField]
	private TMP_Text timeField;

	[SerializeField]
	private TMP_Text durationField;

	[SerializeField]
	private MusicVisualizer visualizer;

	[SerializeField]
	private Button previousButton;

	[SerializeField]
	private Button pauseButton;

	[SerializeField]
	private Button resumeButton;

	[SerializeField]
	private Button loopButton;

	[SerializeField]
	private Button shuffleButton;

	[SerializeField]
	private Button nextButton;

	[SerializeField]
	private MilkdropVisualizer milkDropVisualizer;

	[SerializeField]
	private Image milkDropPanel;

	[SerializeField]
	private Button controlsVisualizer;

	[SerializeField]
	private Button closeVisualizer;

	[SerializeField]
	private Image indicator;

	[SerializeField]
	private Sprite indicatorDisabled;

	[SerializeField]
	private Sprite indicatorEnabled;

	private SliderDragHandler _sliderDragHandler;

	private bool _isVisible;

	public void ToggleContent()
	{
		if (_isVisible)
		{
			HideContent();
		}
		else
		{
			ShowContent();
		}
	}

	public override void ShowContent()
	{
		_isVisible = true;
		base.ShowContent();
	}

	public override void HideContent()
	{
		_isVisible = false;
		base.HideContent();
	}

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		_sliderDragHandler = progressSlider.gameObject.AddComponent<SliderDragHandler>();
		_sliderDragHandler.OnPointerReleased += OnProgressSliderReleased;
		Audio.Playlist.CurrentProgress.Subscribe(this, delegate(float x, MediaPlayerPopup self)
		{
			if (!self._sliderDragHandler.IsDragging)
			{
				self.progressSlider.normalizedValue = x;
			}
		}).AddTo(this);
		progressSlider.onValueChanged.AddListener(OnProgressSliderDragged);
		Audio.Playlist.IsPaused.SubscribeToSetToggle(resumeButton, pauseButton).AddTo(this);
		(from x in Audio.Playlist.CurrentClip.DistinctUntilChanged()
			select x?.name ?? "missing" into x
			select LocalizationUtility.Find(LocTable.General, ZString.Format("playlist_song_{0}", x.Replace(" ", "").ToLower()))).Subscribe(clipNameHandler, delegate(LocalizedString x, LocalizeStringHandler handler)
		{
			handler.SetLocalizedString(x);
		}).AddTo(this);
		Audio.Playlist.CurrentTime.DistinctUntilChanged().FormatTimeMinutes().SubscribeToText(timeField)
			.AddTo(this);
		Audio.Playlist.CurrentDuration.DistinctUntilChanged().FormatTimeMinutes().SubscribeToText(durationField)
			.AddTo(this);
		previousButton.onClick.AddListener(Audio.Playlist.Previous);
		pauseButton.onClick.AddListener(Audio.Playlist.Pause);
		resumeButton.onClick.AddListener(Audio.Playlist.Resume);
		nextButton.onClick.AddListener(Audio.Playlist.Next);
		loopButton.onClick.AddListener(Audio.Playlist.ToggleLoop);
		shuffleButton.onClick.AddListener(Audio.Playlist.ToggleShuffle);
		Audio.Playlist.IsLooping.Subscribe(loopButton, delegate(bool looping, Button btn)
		{
			btn.targetGraphic.color = (looping ? btn.colors.selectedColor : btn.colors.normalColor);
		}).AddTo(this);
		Audio.Playlist.IsShuffling.Subscribe(shuffleButton, delegate(bool shuffling, Button btn)
		{
			btn.targetGraphic.color = (shuffling ? btn.colors.selectedColor : btn.colors.normalColor);
		}).AddTo(this);
		visualizer.Initialize(Audio.Playlist, this.GetCancellationTokenOnDestroy());
		if (milkDropVisualizer != null)
		{
			milkDropVisualizer.Initialize(Audio.Playlist, this.GetCancellationTokenOnDestroy());
		}
		controlsVisualizer.onClick.AddListener(ToggleMilkDrop);
		closeVisualizer.onClick.AddListener(HideMilkDrop);
		SetMilkDropActive(active: false);
	}

	private void OnProgressSliderDragged(float value)
	{
		if (_sliderDragHandler.IsDragging)
		{
			Audio.Playlist.Seek(value);
		}
	}

	private void OnProgressSliderReleased()
	{
		Audio.Playlist.Seek(progressSlider.normalizedValue);
	}

	private void ToggleMilkDrop()
	{
		SetMilkDropActive(!milkDropPanel.gameObject.activeSelf);
	}

	private void HideMilkDrop()
	{
		SetMilkDropActive(active: false);
	}

	private void SetMilkDropActive(bool active)
	{
		milkDropPanel.gameObject.SetActive(active);
		indicator.sprite = (active ? indicatorEnabled : indicatorDisabled);
	}
}
