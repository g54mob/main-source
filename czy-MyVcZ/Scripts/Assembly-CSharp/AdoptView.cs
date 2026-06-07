using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdoptView : MonoBehaviour
{
	private enum UIState
	{
		Idle = 0,
		Recording = 1,
		Recorded = 2,
		PlayingPreview = 3
	}

	[SerializeField]
	private VoiceRecorder _voiceRecorder;

	[SerializeField]
	private AudioSource _previewAudioSource;

	[SerializeField]
	private TMP_InputField _nameInputField;

	[SerializeField]
	private GameObject _recordStartGO;

	[SerializeField]
	private GameObject _recordingGO;

	[SerializeField]
	private GameObject _uiBlockGO;

	[SerializeField]
	private Button _recordStartButton;

	[SerializeField]
	private Button _playButton;

	[SerializeField]
	private Button _bottomPlayButton;

	[SerializeField]
	private Button _confirmButton;

	[SerializeField]
	private Image _waveImage;

	[SerializeField]
	private TextMeshProUGUI _timerText;

	[SerializeField]
	private TextMeshProUGUI _micGuideText;

	private UIState _state;

	private Animal _animal;

	private AudioClip _lastTrimmedClip;

	private float _maxTimerSeconds = 3f;

	private Coroutine _recordTimerRoutine;

	private float _recordStartTime;

	private const int NAME_LENGTH_LIMIT = 16;

	public void Show(Animal animal)
	{
		_animal = animal;
		_animal.ChangeIsAdoptProcessing(isAdoptProcessing: true);
		_nameInputField.onValueChanged.AddListener(OnNameInputValueChanged);
		_voiceRecorder.OnRecordingEnd += OnRecordingEnd;
		_voiceRecorder.OnLevelChanged += OnMicLevelChanged;
		if (_animal.Name == string.Empty)
		{
			_nameInputField.text = string.Empty;
		}
		else
		{
			_nameInputField.text = _animal.Name;
		}
		_waveImage.fillAmount = 0f;
		_timerText.text = "00:00";
		LimitNameLength();
		SetState(UIState.Idle);
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_PaperShow);
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		_animal.ChangeIsAdoptProcessing(isAdoptProcessing: false);
		_nameInputField.onValueChanged.RemoveListener(OnNameInputValueChanged);
		_voiceRecorder.OnRecordingEnd -= OnRecordingEnd;
		_voiceRecorder.OnLevelChanged -= OnMicLevelChanged;
		StopTimerCoroutine();
		_timerText.text = "00:00";
		_previewAudioSource.clip = null;
		_animal = null;
		base.gameObject.SetActive(value: false);
	}

	private void OnNameInputValueChanged(string value)
	{
		if (_animal != null)
		{
			_animal.SetName(value);
		}
	}

	public void OnClickRecordStartButton()
	{
		MonoSingleton<SoundManager>.Instance.MuteBGM(mute: true);
		_voiceRecorder.StartRecording();
		SetState(UIState.Recording);
		StartTimerCoroutine();
	}

	public void OnRecordingEnd(AudioClip trimmedAudioClip)
	{
		_lastTrimmedClip = trimmedAudioClip;
		_animal.SetVoice(trimmedAudioClip);
		MonoSingleton<GameManager>.Instance.SaveGame(lightweight: false);
		SetState(UIState.Recorded);
		StopTimerCoroutine();
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_RecordEnd);
		MonoSingleton<SoundManager>.Instance.MuteBGM(mute: false);
	}

	public void OnClickPlayButton()
	{
		if (!(_lastTrimmedClip == null) && !_previewAudioSource.isPlaying)
		{
			_previewAudioSource.clip = _lastTrimmedClip;
			_previewAudioSource.Play();
			_animal.PlayVoice();
			SetState(UIState.PlayingPreview);
			StartCoroutine(ReEnablePlayButtonWhenDone());
			StartCoroutine(UpdateWaveFill_WhilePreviewPlaying());
		}
	}

	private IEnumerator ReEnablePlayButtonWhenDone()
	{
		yield return new WaitWhile(() => _previewAudioSource.isPlaying);
		yield return new WaitForSeconds(0.1f);
		SetState(UIState.Recorded);
	}

	public void OnClickCompleteButton()
	{
		if (_animal != null)
		{
			_animal.ChangeIsAdoptProcessing(isAdoptProcessing: false);
		}
		AnimalManager.Instance.Notify_OnAdoptEditProcessEnd(_animal);
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_AdoptComplete);
		Hide();
	}

	private void OnMicLevelChanged(float level01)
	{
		if (_waveImage != null)
		{
			_waveImage.fillAmount = level01;
		}
	}

	private IEnumerator UpdateWaveFill_WhilePreviewPlaying()
	{
		float[] samples = new float[256];
		while (_previewAudioSource.isPlaying)
		{
			_previewAudioSource.GetOutputData(samples, 0);
			float num = 0f;
			for (int i = 0; i < samples.Length; i++)
			{
				num += samples[i] * samples[i];
			}
			float num2 = Mathf.Sqrt(num / (float)samples.Length);
			_waveImage.fillAmount = Mathf.Clamp01(num2 * 10f);
			yield return null;
		}
		_waveImage.fillAmount = 0f;
	}

	private void StartTimerCoroutine()
	{
		_timerText.text = "00:00";
		_recordStartTime = Time.time;
		if (_recordTimerRoutine != null)
		{
			StopCoroutine(_recordTimerRoutine);
		}
		_recordTimerRoutine = StartCoroutine(UpdateRecordTimerText());
	}

	private IEnumerator UpdateRecordTimerText()
	{
		while (_state == UIState.Recording)
		{
			float num = Time.time - _recordStartTime;
			if (num > _maxTimerSeconds)
			{
				num = _maxTimerSeconds;
			}
			int num2 = Mathf.FloorToInt(num);
			int num3 = Mathf.FloorToInt((num - (float)num2) * 100f);
			_timerText.text = $"{num2:00}:{num3:00}";
			yield return null;
		}
	}

	private void StopTimerCoroutine()
	{
		if (_recordTimerRoutine != null)
		{
			StopCoroutine(_recordTimerRoutine);
			_recordTimerRoutine = null;
		}
	}

	private void LimitNameLength()
	{
		_nameInputField.characterLimit = 16;
	}

	private void SetState(UIState next)
	{
		_state = next;
		ApplyState();
	}

	private void ApplyState()
	{
		bool active = false;
		bool active2 = false;
		bool active3 = false;
		bool interactable = false;
		bool interactable2 = false;
		bool active4 = false;
		bool interactable3 = false;
		bool active5 = false;
		bool interactable4 = false;
		bool active6 = false;
		switch (_state)
		{
		case UIState.Idle:
			active = false;
			active2 = true;
			interactable = true;
			active3 = false;
			interactable2 = false;
			active4 = false;
			interactable3 = false;
			active5 = false;
			interactable4 = false;
			active6 = true;
			break;
		case UIState.Recording:
			active = true;
			active2 = false;
			active3 = true;
			interactable2 = false;
			active4 = false;
			interactable3 = false;
			active5 = false;
			interactable4 = false;
			active6 = false;
			break;
		case UIState.Recorded:
			active = false;
			active2 = true;
			interactable = true;
			interactable2 = _lastTrimmedClip != null;
			active4 = _lastTrimmedClip != null;
			interactable3 = _lastTrimmedClip != null;
			active5 = _lastTrimmedClip != null;
			interactable4 = _lastTrimmedClip != null;
			active6 = false;
			break;
		case UIState.PlayingPreview:
			active = true;
			active2 = true;
			interactable = false;
			active3 = false;
			interactable2 = false;
			active4 = _lastTrimmedClip != null;
			interactable3 = false;
			active5 = _lastTrimmedClip != null;
			interactable4 = false;
			active6 = false;
			break;
		}
		Set_Active(_uiBlockGO, active);
		Set_Active(_recordStartGO, active2);
		Set_Interactable(_recordStartButton, interactable);
		Set_Active(_recordingGO, active3);
		Set_Interactable(_playButton, interactable2);
		Set_Active(_confirmButton.gameObject, active4);
		Set_Interactable(_confirmButton, interactable3);
		Set_Active(_bottomPlayButton.gameObject, active5);
		Set_Interactable(_bottomPlayButton, interactable4);
		Set_Active(_micGuideText.gameObject, active6);
	}

	private void Set_Active(GameObject go, bool active)
	{
		go.SetActive(active);
	}

	private void Set_Interactable(Selectable sel, bool interactable)
	{
		sel.interactable = interactable;
	}
}
