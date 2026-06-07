using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GifRecordingView : BaseGUIPanelView
{
	public enum GifViewMode
	{
		New = 0,
		Recording = 1,
		Recorded = 2,
		Saving = 3,
		Saved = 4
	}

	private Button recordButton;

	private Button saveButton;

	private Button openButton;

	private SliderManager durationSlider;

	private SliderManager fpsSlider;

	private SliderManager sizeSlider;

	private SliderManager qualitySlider;

	private RectTransform previewPanelRect;

	private TextMeshProUGUI progressText;

	private TextMeshProUGUI statusText;

	public bool ShouldSaveOptions;

	private string previewStr;

	private string progressStr;

	private string savingStr;

	public ReplayView ReplayView { get; private set; }

	public RawImage PreviewRawImage { get; }

	public GifRecordingView(ReplayView replayView)
	{
		ReplayView = replayView;
		base.MainPanel = replayView.mainPanel.transform.FindChildRecursively("GifRecordingPanel").gameObject;
		recordButton = base.MainPanel.transform.FindComponent<Button>("GifRecordButton", isRecursively: true);
		saveButton = base.MainPanel.transform.FindComponent<Button>("GifSaveButton", isRecursively: true);
		openButton = base.MainPanel.transform.FindComponent<Button>("GifOpenButton", isRecursively: true);
		durationSlider = base.MainPanel.transform.FindComponent<SliderManager>("GifDurationSlider", isRecursively: true);
		fpsSlider = base.MainPanel.transform.FindComponent<SliderManager>("GifFPSSlider", isRecursively: true);
		sizeSlider = base.MainPanel.transform.FindComponent<SliderManager>("GifSizeSlider", isRecursively: true);
		qualitySlider = base.MainPanel.transform.FindComponent<SliderManager>("GifQualitySlider", isRecursively: true);
		previewPanelRect = base.MainPanel.transform.FindComponent<RectTransform>("GifPreviewPanel", isRecursively: true);
		progressText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("GifProgressText", isRecursively: true);
		statusText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("GifStatusText", isRecursively: true);
		PreviewRawImage = base.MainPanel.transform.FindComponent<RawImage>("GifPreviewImage", isRecursively: true);
		durationSlider.ConfigureProperties(5f, 1f, 10f, 1f, "{0} s");
		fpsSlider.ConfigureProperties(20f, 5f, 30f, 5f);
		sizeSlider.ConfigureProperties(0.25f, 0.1f, 0.5f, 0.05f);
		qualitySlider.ConfigureProperties(80f, 0f, 100f, 5f, "{0} %");
		recordButton.onClick.AddListener(delegate
		{
			ReplayView.StartGifRecording(durationSlider.CurrentValue, fpsSlider.CurrentValue, sizeSlider.CurrentValue, qualitySlider.CurrentValue);
		});
		saveButton.onClick.AddListener(delegate
		{
			ReplayView.SaveRecordedGif();
		});
		openButton.onClick.AddListener(delegate
		{
			ReplayView.OpenRecordedGif();
		});
		sizeSlider.OnValueChangedEvent += SetPreviewPanelSize;
		sizeSlider.SetCustomLabelChangedCallback((float value) => (int)((float)Screen.width * value) + "x" + (int)((float)Screen.height * value));
		SetPreviewPanelSize(sizeSlider.CurrentValue);
		SetLabelTexts();
		LanguagesManager.Instance.OnLanguageChangedEvent += SetLabelTexts;
		durationSlider.OnValueChangedEvent += delegate
		{
			ShouldSaveOptions = true;
		};
		fpsSlider.OnValueChangedEvent += delegate
		{
			ShouldSaveOptions = true;
		};
		sizeSlider.OnValueChangedEvent += delegate
		{
			ShouldSaveOptions = true;
		};
		qualitySlider.OnValueChangedEvent += delegate
		{
			ShouldSaveOptions = true;
		};
		ShouldSaveOptions = false;
	}

	private void SetLabelTexts()
	{
		previewStr = LanguagesManager.Instance.GetText("label.text.replay.gif.ppreview", "Preview");
		progressStr = LanguagesManager.Instance.GetText("label.text.replay.gif.pprogress", "Progress:");
		savingStr = LanguagesManager.Instance.GetText("label.text.replay.gif.psaving", "Saving:");
	}

	public void SetRecordingSettings(int duration, int fps, float size, int quality)
	{
		durationSlider.SetCurrentValue(duration);
		fpsSlider.SetCurrentValue(fps);
		sizeSlider.SetCurrentValue(size);
		qualitySlider.SetCurrentValue(quality);
		SetPreviewPanelSize(sizeSlider.CurrentValue);
	}

	public (int duration, int fps, float size, int quality) GetRecordingSettings()
	{
		return (duration: (int)durationSlider.CurrentValue, fps: (int)fpsSlider.CurrentValue, size: sizeSlider.CurrentValue, quality: (int)qualitySlider.CurrentValue);
	}

	public void SetRecordingProgress(float progress)
	{
		int num = (int)(progress * 100f);
		string sourceText = progressStr + " " + num + "%";
		if (progress <= 0f)
		{
			sourceText = previewStr;
		}
		progressText.SetText(sourceText);
	}

	public void SetSavingProgress(float progress)
	{
		int num = (int)(progress * 100f);
		statusText.SetText(savingStr + " " + num + "%");
	}

	public void SetPreviewPanelSize(float sizeFactor)
	{
		int num = (int)((float)Screen.width * sizeFactor);
		int num2 = (int)((float)Screen.height * sizeFactor);
		previewPanelRect.sizeDelta = new Vector2(num + 12, num2 + 12);
	}

	public void SetGifViewMode(GifViewMode gifViewMode)
	{
		switch (gifViewMode)
		{
		case GifViewMode.New:
			recordButton.interactable = true;
			saveButton.interactable = false;
			openButton.gameObject.SetActive(value: false);
			statusText.enabled = false;
			PreviewRawImage.gameObject.SetActive(value: false);
			SetRecordingProgress(0f);
			break;
		case GifViewMode.Recording:
			recordButton.interactable = false;
			saveButton.interactable = false;
			openButton.gameObject.SetActive(value: false);
			PreviewRawImage.gameObject.SetActive(value: false);
			SetRecordingProgress(0f);
			break;
		case GifViewMode.Recorded:
			recordButton.interactable = true;
			saveButton.interactable = true;
			PreviewRawImage.gameObject.SetActive(value: true);
			break;
		case GifViewMode.Saving:
			recordButton.interactable = false;
			saveButton.interactable = false;
			statusText.enabled = true;
			SetSavingProgress(0f);
			break;
		case GifViewMode.Saved:
			recordButton.interactable = true;
			openButton.gameObject.SetActive(value: true);
			statusText.enabled = false;
			break;
		}
	}
}
