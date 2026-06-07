using System.Collections;
using System.IO;
using UltimateReplay;
using UnityEngine;

public class ReplayController : BaseController<ReplayView>
{
	private readonly float[] timeScales = new float[9]
	{
		1f / 32f,
		0.0625f,
		0.125f,
		0.25f,
		0.5f,
		1f,
		2f,
		4f,
		8f
	};

	private int currentTimeScaleIndex;

	private string lastGifFilePath;

	public bool IsGifRecording { get; private set; }

	public bool IsGifSaving { get; private set; }

	public ReplayController(ReplayView view)
		: base(view)
	{
		currentTimeScaleIndex = 5;
		view.SetTimeSpeedLabel(ReplayTime.TimeScale);
		view.GifRecordingView.SetVisibility(isVisible: false);
		IsGifRecording = false;
		IsGifSaving = false;
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "ReplayView.CloseButtonEvent":
			ReplayState.Instance.ExitFromReplay();
			break;
		case "ReplayView.CameraButtonEvent":
		{
			GameManager.Instance.CameraManager.RestoresMainCamera();
			BlockBodyView blockBodyView = GameManager.Instance.MainCreationController.view.BrainBlockView.GetBlockBodyView(0);
			GameManager.Instance.CameraManager.OrbitCamera.SetTarget(blockBodyView.transform);
			break;
		}
		case "ReplayView.GifPanelToggleEvent":
		{
			bool visibility = (bool)data[0];
			view.GifRecordingView.SetVisibility(visibility);
			break;
		}
		case "ReplayView.MinusSpeedButtonEvent":
		{
			currentTimeScaleIndex = Mathf.Clamp(--currentTimeScaleIndex, 0, timeScales.Length - 1);
			float num = Mathf.Sign(ReplayTime.TimeScale);
			ReplayTime.TimeScale = timeScales[currentTimeScaleIndex] * num;
			view.SetTimeSpeedLabel(Mathf.Abs(ReplayTime.TimeScale));
			break;
		}
		case "ReplayView.PlusSpeedButtonEvent":
		{
			currentTimeScaleIndex = Mathf.Clamp(++currentTimeScaleIndex, 0, timeScales.Length - 1);
			float num = Mathf.Sign(ReplayTime.TimeScale);
			ReplayTime.TimeScale = timeScales[currentTimeScaleIndex] * num;
			view.SetTimeSpeedLabel(Mathf.Abs(ReplayTime.TimeScale));
			break;
		}
		case "ReplayView.ReverseToggleEvent":
		{
			bool num5 = (bool)data[0];
			bool flag = ReplayManager.IsReplaying && !ReplayManager.IsPaused;
			ReplayManager.PausePlayback();
			float num6 = Mathf.Abs(ReplayTime.TimeScale);
			ReplayTime.TimeScale = (num5 ? (-1f * num6) : num6);
			if (flag)
			{
				ReplayManager.BeginPlayback(fromStart: false);
			}
			view.SetPlayPauseButtonState(flag);
			break;
		}
		case "ReplayView.PlayPauseButtonEvent":
			InvertPlayPauseStatus();
			break;
		case "ReplayView.TimerSliderChangedEvent":
			ReplayManager.SetPlaybackFrameNormalized((float)data[0]);
			break;
		case "ReplayView.GifRecordButtonEvent":
		{
			float duration = (float)data[0];
			float num2 = (float)data[1];
			float num3 = (float)data[2];
			float num4 = (float)data[3];
			int width = (int)((float)Screen.width * num3);
			int height = (int)((float)Screen.height * num3);
			int quality = 101 - (int)num4;
			view.GifRecordingView.SetGifViewMode(GifRecordingView.GifViewMode.Recording);
			ClearLastGifRecording();
			ProGifManager.Instance.SetRecordSettings(autoAspect: false, width, height, duration, (int)num2, 0, quality);
			GameManager.Instance.StartCoroutine(StartGifRecordingProcess());
			IsGifRecording = true;
			break;
		}
		case "ReplayView.GifSaveButtonEvent":
			view.GifRecordingView.SetGifViewMode(GifRecordingView.GifViewMode.Saving);
			if (!Directory.Exists(PathNames.UserGifs))
			{
				Directory.CreateDirectory(PathNames.UserGifs);
			}
			ProGifManager.Instance.m_GifRecorder.recorderCom.SaveFolder = PathNames.UserGifs;
			ProGifManager.Instance.SaveRecord(null, GifSavingProgressHandler, EndOfGifSavingHandler);
			IsGifSaving = true;
			break;
		case "ReplayView.GifOpenButtonEvent":
			if (!string.IsNullOrEmpty(lastGifFilePath))
			{
				Application.OpenURL(Path.GetDirectoryName(lastGifFilePath));
			}
			break;
		}
	}

	private IEnumerator StartGifRecordingProcess()
	{
		yield return new WaitForEndOfFrame();
		ReplayManager.ResumePlayback();
		view.SetPlayPauseButtonState(isReplayPlaying: true);
		Camera frontCamera = GameManager.Instance.CameraManager.FrontCamera;
		ProGifManager.Instance.StartRecord(frontCamera, GifRecordProgressHandler, EndOfGifRecordingHandler);
	}

	private void GifRecordProgressHandler(float progress)
	{
		view.GifRecordingView.SetRecordingProgress(progress);
	}

	private void EndOfGifRecordingHandler()
	{
		view.GifRecordingView.SetGifViewMode(GifRecordingView.GifViewMode.Recorded);
		ReplayManager.PausePlayback();
		view.SetPlayPauseButtonState(isReplayPlaying: false);
		ProGifManager.Instance.StopRecord();
		ProGifManager.Instance.PlayGif(view.GifRecordingView.PreviewRawImage);
		IsGifRecording = false;
	}

	private void GifSavingProgressHandler(int id, float progress)
	{
		view.GifRecordingView.SetSavingProgress(progress);
	}

	private void EndOfGifSavingHandler(int id, string filePath)
	{
		view.GifRecordingView.SetGifViewMode(GifRecordingView.GifViewMode.Saved);
		lastGifFilePath = filePath;
		IsGifSaving = false;
	}

	public void InvertPlayPauseStatus()
	{
		if (ReplayManager.IsReplaying && !ReplayManager.IsPaused)
		{
			ReplayManager.PausePlayback();
			view.SetPlayPauseButtonState(isReplayPlaying: false);
		}
		else if (ReplayManager.IsReplaying)
		{
			if (ReplayTime.TimeScale < 0f && ReplayManager.CurrentPlaybackTimeNormalized == 1f)
			{
				float num = 1f / (float)ReplayManager.Instance.recordFPS;
				ReplayManager.SetPlaybackFrame(ReplayManager.CurrentPlaybackTime - num);
			}
			ReplayManager.ResumePlayback();
			view.SetPlayPauseButtonState(isReplayPlaying: true);
		}
	}

	public void ClearLastGifRecording()
	{
		if (ProGifManager.Instance.m_GifPlayer != null && ProGifManager.Instance.m_GifPlayer.State == ProGifPlayerComponent.PlayerState.Playing)
		{
			ProGifManager.Instance.StopPlayer();
		}
		ProGifManager.Instance.Clear();
	}

	public void CheckAndSaveRecordingSettings()
	{
		if (view.GifRecordingView.ShouldSaveOptions)
		{
			var (gifDuration, gifFPS, gifSize, gifQuality) = view.GifRecordingView.GetRecordingSettings();
			GameManager.Instance.OptionsModel.GifDuration = gifDuration;
			GameManager.Instance.OptionsModel.GifFPS = gifFPS;
			GameManager.Instance.OptionsModel.GifSize = gifSize;
			GameManager.Instance.OptionsModel.GifQuality = gifQuality;
			GameManager.Instance.OptionsModel.SaveValuesOnDisk();
			view.GifRecordingView.ShouldSaveOptions = false;
		}
	}
}
