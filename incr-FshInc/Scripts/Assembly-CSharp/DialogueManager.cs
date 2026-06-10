using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	[Header("UI References")]
	public GameObject dialoguePanel;

	public TMP_Text nameText;

	public Image portraitImage;

	public SuperTextMesh dialogueSuperText;

	public GameObject advanceIndicator;

	public RectTransform dialoguePanelRT;

	[Header("Background & Content Split")]
	[Tooltip("The semi-transparent overlay Image (child of DialoguePanel). Fades in/out separately.")]
	public CanvasGroup backgroundCanvasGroup;

	[Tooltip("The content container (portrait + text box). This is what scales in/out.")]
	public RectTransform contentRT;

	[Header("DOTween Settings")]
	public float animationDuration = 0.65f;

	public float backgroundFadeDuration = 0.35f;

	[Tooltip("The scale the content container animates to when the dialogue opens.")]
	public float contentTargetScale = 1f;

	private Vector3 _onScreenPosition;

	private Vector3 _initialPortraitPosition;

	[Header("Testing")]
	public List<DialogueSequenceSO> testSequences;

	[Header("Audio Settings")]
	public AudioSource typingAudioSource;

	public AudioClip[] typingSounds;

	[Range(0.5f, 2f)]
	public float minPitch = 0.95f;

	[Range(0.5f, 2f)]
	public float maxPitch = 1.05f;

	[Range(1f, 10f)]
	public int playSoundEveryNLetters = 2;

	[Range(2f, 10f)]
	public int typingVoicePoolSize = 4;

	[Header("Indicator Components")]
	public AdvanceIndicatorAnimator indicatorAnimator;

	public NPCSpeechMove NPCSpeechMove;

	private DialogueSequenceSO currentSequence;

	private int currentLineIndex;

	public bool isTypingComplete;

	public bool isCutsceneActive;

	private bool _canInput;

	private bool _isPausedByMenu;

	private bool _waitingToType;

	private bool _skipSounds;

	private int _letterAudioCount;

	private string _pendingLineText = "";

	private CharacterVoiceProfile _activeVoiceProfile;

	private AudioSource[] _typingPool;

	private int _nextTypingPoolIndex;

	public static DialogueManager Instance { get; private set; }

	public static event Action OnDialogueEnd;

	public void PauseDialogue()
	{
		_isPausedByMenu = true;
		if (dialogueSuperText != null)
		{
			dialogueSuperText.ignoreTimeScale = false;
		}
		_canInput = false;
	}

	public void UnpauseDialogue()
	{
		_isPausedByMenu = false;
		if (dialogueSuperText != null)
		{
			dialogueSuperText.ignoreTimeScale = true;
		}
		if (_waitingToType)
		{
			_waitingToType = false;
			_canInput = true;
			BeginTypingCurrentLine();
		}
		else if (dialoguePanel.activeSelf)
		{
			_canInput = true;
		}
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		dialoguePanel.SetActive(value: false);
		if (backgroundCanvasGroup != null)
		{
			backgroundCanvasGroup.alpha = 0f;
		}
		if (portraitImage != null)
		{
			_initialPortraitPosition = portraitImage.transform.localPosition;
		}
		NPCSpeechMove.Initialize(dialogueSuperText);
		_typingPool = new AudioSource[typingVoicePoolSize];
		for (int i = 0; i < typingVoicePoolSize; i++)
		{
			if (i == 0 && typingAudioSource != null)
			{
				_typingPool[i] = typingAudioSource;
				continue;
			}
			GameObject obj = new GameObject("TypingVoice_" + i);
			obj.transform.SetParent(base.transform);
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.playOnAwake = false;
			if (typingAudioSource != null)
			{
				audioSource.outputAudioMixerGroup = typingAudioSource.outputAudioMixerGroup;
			}
			_typingPool[i] = audioSource;
		}
		if (dialogueSuperText != null)
		{
			dialogueSuperText.onPrintEvent.AddListener(PlayTypingSound);
		}
	}

	private void Update()
	{
		if (_canInput)
		{
			if (dialoguePanel.activeSelf && Input.GetMouseButtonDown(0))
			{
				AdvanceDialogue();
			}
			if (dialoguePanel.activeSelf && !isTypingComplete && !dialogueSuperText.reading)
			{
				isTypingComplete = true;
				ShowAdvanceIndicator();
			}
		}
	}

	private void ShowAdvanceIndicator()
	{
		if (!dialoguePanel.activeSelf)
		{
			return;
		}
		if (indicatorAnimator != null)
		{
			indicatorAnimator.enabled = false;
		}
		advanceIndicator.SetActive(value: true);
		advanceIndicator.transform.localScale = Vector3.zero;
		advanceIndicator.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack).OnComplete(delegate
		{
			if (indicatorAnimator != null)
			{
				indicatorAnimator.enabled = true;
			}
		});
	}

	private void PrepareNextLineUI()
	{
		if (currentSequence == null || currentLineIndex >= currentSequence.lines.Count)
		{
			EndDialogue();
			return;
		}
		DialogueLine dialogueLine = currentSequence.lines[currentLineIndex];
		nameText.text = (dialogueLine.localizedCharacterName.IsEmpty ? dialogueLine.characterName : dialogueLine.localizedCharacterName.GetLocalizedString());
		if (dialogueLine.characterPortrait != null)
		{
			portraitImage.sprite = dialogueLine.characterPortrait;
		}
		isTypingComplete = false;
		advanceIndicator.SetActive(value: false);
		_activeVoiceProfile = dialogueLine.voiceProfile;
		_pendingLineText = (dialogueLine.localizedDialogue.IsEmpty ? dialogueLine.dialogueText : dialogueLine.localizedDialogue.GetLocalizedString());
	}

	private void BeginTypingCurrentLine()
	{
		_skipSounds = false;
		_letterAudioCount = 0;
		dialogueSuperText.text = _pendingLineText;
	}

	public void ShowDialogue(DialogueSequenceSO sequence)
	{
		if (SimulationBot.Instance != null && SimulationBot.Instance.isRunning)
		{
			Debug.Log("[DialogueManager] Auto-skipping dialogue for SimulationBot");
			DialogueManager.OnDialogueEnd?.Invoke();
			return;
		}
		_canInput = false;
		if (dialoguePanel.activeSelf)
		{
			return;
		}
		isCutsceneActive = true;
		currentSequence = sequence;
		currentLineIndex = 0;
		dialoguePanel.SetActive(value: true);
		if (sequence.pauseGame)
		{
			Time.timeScale = 0f;
		}
		if (currentLineIndex == 0)
		{
			dialoguePanelRT.localScale = Vector3.one;
			dialoguePanel.SetActive(value: true);
			if (backgroundCanvasGroup != null)
			{
				backgroundCanvasGroup.alpha = 0f;
			}
			if (contentRT != null)
			{
				contentRT.localScale = Vector3.zero;
			}
			PrepareNextLineUI();
			LayoutRebuilder.ForceRebuildLayoutImmediate(dialoguePanelRT);
			if (NPCSpeechMove != null)
			{
				NPCSpeechMove.Initialize(dialogueSuperText);
			}
			if (backgroundCanvasGroup != null)
			{
				backgroundCanvasGroup.DOFade(1f, backgroundFadeDuration).SetUpdate(isIndependentUpdate: true);
			}
			if (contentRT != null)
			{
				contentRT.DOScale(Vector3.one * contentTargetScale, animationDuration).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true)
					.SetDelay(backgroundFadeDuration)
					.OnComplete(delegate
					{
						if (_isPausedByMenu)
						{
							_waitingToType = true;
						}
						else
						{
							_canInput = true;
							BeginTypingCurrentLine();
						}
					});
			}
			else
			{
				_canInput = true;
				BeginTypingCurrentLine();
			}
		}
		else
		{
			dialoguePanel.SetActive(value: true);
			dialoguePanelRT.localScale = Vector3.one;
			if (backgroundCanvasGroup != null)
			{
				backgroundCanvasGroup.alpha = 1f;
			}
			if (contentRT != null)
			{
				contentRT.localScale = Vector3.one * contentTargetScale;
			}
			_canInput = true;
			DisplayNextLine();
		}
	}

	private void DisplayNextLine()
	{
		if (currentSequence == null || currentLineIndex >= currentSequence.lines.Count)
		{
			EndDialogue();
			return;
		}
		DialogueLine dialogueLine = currentSequence.lines[currentLineIndex];
		nameText.text = (dialogueLine.localizedCharacterName.IsEmpty ? dialogueLine.characterName : dialogueLine.localizedCharacterName.GetLocalizedString());
		if (dialogueLine.characterPortrait != null)
		{
			portraitImage.sprite = dialogueLine.characterPortrait;
		}
		isTypingComplete = false;
		advanceIndicator.SetActive(value: false);
		_activeVoiceProfile = dialogueLine.voiceProfile;
		_skipSounds = false;
		_letterAudioCount = 0;
		dialogueSuperText.text = (dialogueLine.localizedDialogue.IsEmpty ? dialogueLine.dialogueText : dialogueLine.localizedDialogue.GetLocalizedString());
	}

	public void PlayRandomTestSequence()
	{
		if (testSequences == null || testSequences.Count == 0)
		{
			Debug.LogWarning("[DialogueManager] No test sequences assigned in the inspector!");
			return;
		}
		int index = UnityEngine.Random.Range(0, testSequences.Count);
		DialogueSequenceSO sequence = testSequences[index];
		if (dialoguePanel.activeSelf)
		{
			dialoguePanelRT.DOKill();
			if (contentRT != null)
			{
				contentRT.DOKill();
			}
			if (backgroundCanvasGroup != null)
			{
				backgroundCanvasGroup.DOKill();
			}
			if (portraitImage != null && portraitImage.transform != null)
			{
				portraitImage.transform.DOKill();
				portraitImage.transform.localPosition = _initialPortraitPosition;
			}
			dialoguePanel.SetActive(value: false);
			dialogueSuperText.text = "";
			if (contentRT != null)
			{
				contentRT.localScale = Vector3.one * contentTargetScale;
			}
			if (backgroundCanvasGroup != null)
			{
				backgroundCanvasGroup.alpha = 0f;
			}
			ResumeTimeScale();
			isCutsceneActive = false;
			if (advanceIndicator != null)
			{
				advanceIndicator.SetActive(value: false);
			}
		}
		ShowDialogue(sequence);
	}

	public void PlayTypingSound()
	{
		if (_skipSounds)
		{
			return;
		}
		int num = ((_activeVoiceProfile != null) ? _activeVoiceProfile.playSoundEveryNLetters : playSoundEveryNLetters);
		_letterAudioCount++;
		if (_letterAudioCount % num == 0)
		{
			AudioClip[] array = ((_activeVoiceProfile != null && _activeVoiceProfile.typingSounds != null && _activeVoiceProfile.typingSounds.Length != 0) ? _activeVoiceProfile.typingSounds : typingSounds);
			float minInclusive = ((_activeVoiceProfile != null) ? _activeVoiceProfile.minPitch : minPitch);
			float maxInclusive = ((_activeVoiceProfile != null) ? _activeVoiceProfile.maxPitch : maxPitch);
			float volumeScale = ((_activeVoiceProfile != null) ? _activeVoiceProfile.volume : 1f);
			if (_typingPool != null && _typingPool.Length != 0 && array != null && array.Length != 0)
			{
				AudioSource obj = _typingPool[_nextTypingPoolIndex];
				_nextTypingPoolIndex = (_nextTypingPoolIndex + 1) % _typingPool.Length;
				obj.pitch = UnityEngine.Random.Range(minInclusive, maxInclusive);
				obj.PlayOneShot(array[UnityEngine.Random.Range(0, array.Length)], volumeScale);
			}
		}
	}

	public void AdvanceDialogue()
	{
		if (dialogueSuperText.reading)
		{
			_skipSounds = true;
			dialogueSuperText.SkipToEnd();
		}
		else if (!dialogueSuperText.reading && !dialogueSuperText.unreading)
		{
			advanceIndicator.SetActive(value: false);
			if (!dialogueSuperText.Continue())
			{
				currentLineIndex++;
				DisplayNextLine();
			}
		}
	}

	private void EndDialogue()
	{
		_canInput = false;
		ResumeTimeScale();
		DialogueManager.OnDialogueEnd?.Invoke();
		((contentRT != null) ? contentRT : dialoguePanelRT).DOScale(Vector3.zero, animationDuration).SetEase(Ease.InBack).SetUpdate(isIndependentUpdate: true)
			.OnComplete(delegate
			{
				if (backgroundCanvasGroup != null)
				{
					backgroundCanvasGroup.DOFade(0f, backgroundFadeDuration).SetUpdate(isIndependentUpdate: true).OnComplete(CleanUpDialogue);
				}
				else
				{
					CleanUpDialogue();
				}
			});
	}

	private void CleanUpDialogue()
	{
		dialoguePanel.SetActive(value: false);
		dialogueSuperText.text = "";
		if (portraitImage != null && portraitImage.transform != null)
		{
			portraitImage.transform.DOKill();
			portraitImage.transform.localPosition = _initialPortraitPosition;
		}
		dialoguePanelRT.localScale = Vector3.one;
		if (contentRT != null)
		{
			contentRT.localScale = Vector3.one * contentTargetScale;
		}
		if (backgroundCanvasGroup != null)
		{
			backgroundCanvasGroup.alpha = 0f;
		}
		ResumeTimeScale();
		DialogueManager.OnDialogueEnd?.Invoke();
		isCutsceneActive = false;
		if (advanceIndicator != null)
		{
			advanceIndicator.SetActive(value: false);
		}
	}

	private void ResumeTimeScale()
	{
		if (SimulationBot.Instance != null && SimulationBot.Instance.isRunning)
		{
			Time.timeScale = SimulationBot.Instance.timeScale;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	public void ShowTutorialOnce(string tutorialKey, DialogueSequenceSO sequence)
	{
		if (SimulationBot.Instance != null && SimulationBot.Instance.isRunning)
		{
			Debug.Log("[DialogueManager] Bot is running. Skipping tutorial: " + tutorialKey);
			PlayerPrefs.SetInt(tutorialKey, 1);
			PlayerPrefs.Save();
		}
		else if (PlayerPrefs.GetInt(tutorialKey, 0) == 0)
		{
			ShowDialogue(sequence);
			PlayerPrefs.SetInt(tutorialKey, 1);
			PlayerPrefs.Save();
		}
	}
}
