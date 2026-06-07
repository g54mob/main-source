using System;
using System.Collections.Generic;
using Febucci.UI;
using I2.Loc;
using PajamaLlama.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : Panel, ILocalizationGenderProvider, ILocalizationParamsManager, IUIFlagsProvider
{
	[Serializable]
	public class PanelElements
	{
		[SerializeField]
		private GameObject _panel;

		[SerializeField]
		private TMP_Text _speakerName;

		[SerializeField]
		private Image _speakerPortrait;

		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private TypewriterByCharacter _typewriterAnimator;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private GameObject _progressArrow;

		public GameObject Panel => _panel;

		public TMP_Text SpeakerName => _speakerName;

		public Image SpeakerPortrait => _speakerPortrait;

		public TMP_Text Text => _text;

		public TypewriterByCharacter TypewriterAnimator => _typewriterAnimator;

		public Animator Animator => _animator;

		public GameObject ProgressArrow => _progressArrow;

		public void Enable()
		{
			_panel.SetActive(value: true);
		}

		public void Disable()
		{
			if (_animator.isActiveAndEnabled)
			{
				_animator.ResetTrigger("OnDisable");
				_animator.SetTrigger("OnDisable");
				_animator.Update(0f);
			}
			_panel.SetActive(value: false);
		}
	}

	[SerializeField]
	private PanelContainer _container;

	[SerializeField]
	private PanelElements _regularDialogueElements = new PanelElements();

	[SerializeField]
	private PanelElements _radioMessageElements = new PanelElements();

	[SerializeField]
	private ChildBehaviourCache<DialoguePlayerChoiceButton> _playerChoiceButtons = new ChildBehaviourCache<DialoguePlayerChoiceButton>();

	[SerializeField]
	private SelectableGroup _playerChoicesSelectableGroup;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString _speakerNameUnknown;

	private Dialogue _currentDialogue;

	private PanelElements _currentPanelElements;

	private readonly Queue<DialogueGameEvent> _queuedDialogueRequests = new Queue<DialogueGameEvent>();

	private GameSpeed _gameSpeedBeforeDialogue = GameSpeed.One;

	private bool _isGamePausedByDialogue;

	private bool _isQueuedDialogueStarting;

	private bool _shouldCloseAtEndOfFrame;

	PanelContainerFlags IUIFlagsProvider.Flags => PanelContainerFlags.None;

	bool IUIFlagsProvider.BlockCancel => false;

	bool IUIFlagsProvider.BlockArchitectMode => true;

	Agent.EGender ILocalizationGenderProvider.LocalizationGender
	{
		get
		{
			if (_currentDialogue == null || !(_currentDialogue.CurrentSpeaker != null))
			{
				return Agent.EGender.Male;
			}
			return _currentDialogue.CurrentSpeaker.Gender;
		}
	}

	public void DialogueClick()
	{
		if (_currentPanelElements.TypewriterAnimator != null && _currentPanelElements.TypewriterAnimator.isShowingText)
		{
			GameManager.WorldMapManager.WorldMap.ActivateForwardInputWait();
			_currentPanelElements.TypewriterAnimator.SkipTypewriter();
			return;
		}
		if (_currentDialogue.CanProgressDialogue())
		{
			GameManager.WorldMapManager.WorldMap.ActivateForwardInputWait();
		}
		ProgressDialogue();
	}

	private void Awake()
	{
		_regularDialogueElements.Panel.SetActive(value: false);
		_radioMessageElements.Panel.SetActive(value: false);
	}

	private void OnEnable()
	{
		UIManager.AddFlagsProvider(this);
	}

	private void OnDisable()
	{
		UIManager.RemoveFlagsProvider(this);
		GameManager.WorldMapManager.WorldMap.RemoveMovementBlocker(this);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DialogueStartRequest, OnDialogueStartRequest);
		_regularDialogueElements.TypewriterAnimator.onTypewriterStart.RemoveListener(DisableProgressArrow);
		_regularDialogueElements.TypewriterAnimator.onTextShowed.RemoveListener(EnableProgressArrow);
		_radioMessageElements.TypewriterAnimator.onTypewriterStart.RemoveListener(DisableProgressArrow);
		_radioMessageElements.TypewriterAnimator.onTextShowed.RemoveListener(EnableProgressArrow);
	}

	public override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.DialogueStartRequest, OnDialogueStartRequest);
		_regularDialogueElements.TypewriterAnimator.onTypewriterStart.AddListener(DisableProgressArrow);
		_regularDialogueElements.TypewriterAnimator.onTextShowed.AddListener(EnableProgressArrow);
		_radioMessageElements.TypewriterAnimator.onTypewriterStart.AddListener(DisableProgressArrow);
		_radioMessageElements.TypewriterAnimator.onTextShowed.AddListener(EnableProgressArrow);
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (!(context is DialogueGameEvent dialogueGameEvent) || !base.Open(id, context))
		{
			return false;
		}
		_shouldCloseAtEndOfFrame = false;
		ActivateAppropriatePanelElements(dialogueGameEvent.IsRadioMessage);
		if (_currentDialogue == null || dialogueGameEvent.IsNewDialogue || (dialogueGameEvent.DialogueProperties != null && dialogueGameEvent.DialogueProperties != _currentDialogue.DialogueProperties))
		{
			StartDialogue(dialogueGameEvent);
			if (dialogueGameEvent.IsNewDialogue && GameSpeedManager.GameSpeed > GameSpeed.One)
			{
				_gameSpeedBeforeDialogue = GameSpeedManager.GameSpeed;
				GameSpeedManager.SetGameSpeed(GameSpeed.One);
			}
		}
		return true;
	}

	private void ActivateAppropriatePanelElements(bool isRadioMessage)
	{
		_currentPanelElements?.Disable();
		_currentPanelElements = (isRadioMessage ? _radioMessageElements : _regularDialogueElements);
		_currentPanelElements.Enable();
	}

	public void DisplayPlayerChoiceButtons(IReadOnlyList<DialogueNodePlayerChoicesProperties.PlayerChoice> choices, DialogueNodePlayerChoices choicesNode)
	{
		DisableProgressArrow();
		_playerChoiceButtons.Reset();
		int i = 0;
		for (int count = choices.Count; i < count; i++)
		{
			_playerChoiceButtons.Get(active: true).Initialize(choices[i].Text, i, choicesNode);
		}
		_playerChoiceButtons.Trim();
		_playerChoicesSelectableGroup.enabled = true;
		_playerChoicesSelectableGroup.Initialize(clearSelected: true);
	}

	public void ClearPlayerChoiceButtons()
	{
		_playerChoiceButtons.Reset();
		_playerChoiceButtons.Trim();
		_playerChoicesSelectableGroup.enabled = false;
	}

	private void StartDialogue(DialogueGameEvent dialogueEvent)
	{
		if (_currentDialogue == null || dialogueEvent.DialogueProperties != _currentDialogue.DialogueProperties)
		{
			SetCurrentDialogue(dialogueEvent.DialogueProperties);
		}
		else
		{
			_currentDialogue.RestartDialogue();
		}
		_currentDialogue.SetIsRepeat(dialogueEvent.IsRepeat);
		_currentDialogue.AcquireMainSpeaker(dialogueEvent.DialogueInteractable);
		if (dialogueEvent.DialogueInteractable != null)
		{
			StartDialogueBranchReference(dialogueEvent.DialogueInteractable, dialogueEvent.SpecificBranchEntryNode);
		}
		else if ((bool)dialogueEvent.SpecificBranchEntryNode)
		{
			StartSpecificDialogueBranch(dialogueEvent.SpecificBranchEntryNode);
		}
		else
		{
			ProgressDialogue();
		}
	}

	public void ProgressDialogue()
	{
		if (_currentDialogue.CanProgressDialogue())
		{
			if (_currentDialogue.ProgressDialogue(this))
			{
				SetupCurrentDialogueNode();
			}
			else
			{
				EndDialogue();
			}
		}
	}

	private void StartDialogueBranchReference(IDialogueInteractable dialogueInteractable, DialogueNodeProperties entryNode = null)
	{
		if (_currentDialogue.PlayDialogueInteractable(dialogueInteractable, this, entryNode))
		{
			SetupCurrentDialogueNode();
		}
		else
		{
			EndDialogue();
		}
	}

	private void StartSpecificDialogueBranch(DialogueNodeProperties specificBranchEntryNode)
	{
		if (_currentDialogue.PlaySpecificDialogueBranch(specificBranchEntryNode, this))
		{
			SetupCurrentDialogueNode();
		}
		else
		{
			EndDialogue();
		}
	}

	private void SetupCurrentDialogueNode()
	{
		DialoguePanelOptions currentDialoguePanelOptions = _currentDialogue.CurrentDialoguePanelOptions;
		if (currentDialoguePanelOptions != null)
		{
			ApplyOptions(currentDialoguePanelOptions, _currentDialogue.CurrentSpeaker);
		}
		else
		{
			_regularDialogueElements.SpeakerName.SetText((_currentDialogue.CurrentSpeaker != null) ? _currentDialogue.CurrentSpeaker.Name : ((string)_speakerNameUnknown));
			ClearOptionEffects();
		}
		PanelID[] excludedPanels = _container.ExcludedPanels;
		foreach (PanelID panelID in excludedPanels)
		{
			GameManager.UIManager.ClosePanel(panelID);
		}
	}

	private void EndDialogue()
	{
		ClearOptionEffects();
		if (_currentPanelElements != null)
		{
			_currentPanelElements.Text.text = "";
		}
		if (_currentDialogue.Interactable != null)
		{
			_currentDialogue.Interactable.OnDialogueResponse(DialogueResponseType.EndOfDialogue, _currentDialogue);
		}
		DialogueGameEvent.DispatchDialogueEnded(_currentDialogue.DialogueProperties, IsToBeContinued());
		SetCurrentDialogue(null);
		_shouldCloseAtEndOfFrame = true;
		if (_gameSpeedBeforeDialogue > GameSpeed.One && GameSpeedManager.GameSpeed == GameSpeed.One)
		{
			GameSpeedManager.SetGameSpeed(_gameSpeedBeforeDialogue);
		}
		_gameSpeedBeforeDialogue = GameSpeed.One;
		if (_queuedDialogueRequests.Count > 0)
		{
			float delay = _queuedDialogueRequests.Peek().Delay;
			Invoke("TriggerNextQueuedDialogueRequest", delay);
			_shouldCloseAtEndOfFrame = delay > 0f;
		}
		if (_shouldCloseAtEndOfFrame)
		{
			FinalUpdate.RegisterEndOfFrameOneShot(CloseAtEndOfFrame);
		}
	}

	private void ApplyOptions(DialoguePanelOptions options, AgentDescriptor speaker)
	{
		if (string.IsNullOrWhiteSpace(options.SpeakerNameOverride))
		{
			_regularDialogueElements.SpeakerName.SetText((speaker != null) ? speaker.Name : ((string)_speakerNameUnknown));
		}
		else
		{
			_regularDialogueElements.SpeakerName.SetText(options.SpeakerNameOverride);
		}
		EnableSpeakerPortrait(speaker, options);
		UIManager uIManager = GameManager.UIManager;
		if (options.PauseGame != _isGamePausedByDialogue)
		{
			if (options.PauseGame)
			{
				uIManager.PauseGame();
			}
			else
			{
				uIManager.UnpauseGame();
			}
			_isGamePausedByDialogue = options.PauseGame;
		}
		uIManager.SetGameInputsBlockerActive(options.BlockGameInputs);
		if (options.BlockGameInputs || options.BlockTownMovement)
		{
			GameManager.WorldMapManager.WorldMap.AddMovementBlocker(this);
		}
		else
		{
			GameManager.WorldMapManager.WorldMap.RemoveMovementBlocker(this);
		}
		if (options.BlockUILayersInputs != 0)
		{
			uIManager.SetUILayersInteractable(options.BlockUILayersInputs, interactable: false);
		}
		if (options.HideUILayers != 0)
		{
			uIManager.SetUILayersActive(options.HideUILayers, active: false);
		}
		if (_currentDialogue.CanProgressDialogue())
		{
			_container.AddFlags(PanelContainerFlags.BlockCursorContext | PanelContainerFlags.BlockDPadInput);
		}
		else
		{
			_container.RemoveFlags(PanelContainerFlags.BlockCursorContext | PanelContainerFlags.BlockDPadInput);
		}
	}

	private void EnableSpeakerPortrait(ActorDescriptor speaker, DialoguePanelOptions options, bool registerToDisableEvent = true)
	{
		DisableSpeakerPortrait();
		if (!options.ShowSpeakerPortrait)
		{
			return;
		}
		if ((bool)options.SpeakerPortraitOverride)
		{
			EnableSpeakerPortrait(options.SpeakerPortraitOverride);
		}
		else if (speaker is AgentDescriptor descriptor)
		{
			GameManager.UIManager.EnableDynamicPortrait(descriptor, options.SpeakerActivity);
			if (registerToDisableEvent)
			{
				GameEventDispatcher.AddListener(GameEventType.DrifterPortraitDisabled, ReenableSpeakerPortrait);
			}
		}
		else if (speaker != null && (bool)speaker.ActorProfile && (bool)speaker.ActorProfile.DialoguePortrait)
		{
			EnableSpeakerPortrait(speaker.ActorProfile.DialoguePortrait);
		}
	}

	private void EnableSpeakerPortrait(Sprite portrait)
	{
		GameManager.UIManager.DisableDynamicPortrait();
		if ((bool)_currentPanelElements.SpeakerPortrait)
		{
			_currentPanelElements.SpeakerPortrait.gameObject.SetActive(value: true);
			_currentPanelElements.SpeakerPortrait.overrideSprite = portrait;
		}
	}

	private void DisableSpeakerPortrait()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DrifterPortraitDisabled, ReenableSpeakerPortrait);
		GameManager.UIManager.DisableDynamicPortrait(_currentDialogue.CurrentSpeaker);
		if ((bool)_currentPanelElements.SpeakerPortrait)
		{
			_currentPanelElements.SpeakerPortrait.overrideSprite = null;
			_currentPanelElements.SpeakerPortrait.gameObject.SetActive(value: false);
		}
	}

	private void ClearOptionEffects()
	{
		DisableSpeakerPortrait();
		UIManager uIManager = GameManager.UIManager;
		if (_isGamePausedByDialogue)
		{
			uIManager.UnpauseGame();
			_isGamePausedByDialogue = false;
		}
		uIManager.SetGameInputsBlockerActive(active: false);
		GameManager.WorldMapManager.WorldMap.RemoveMovementBlocker(this);
		uIManager.SetUILayersInteractable((UIElementsLayerID)(-1), interactable: true);
		uIManager.SetUILayersActive((UIElementsLayerID)(-1), active: true);
	}

	private void CloseAtEndOfFrame()
	{
		if (_shouldCloseAtEndOfFrame)
		{
			if (_currentPanelElements != null)
			{
				_currentPanelElements.Disable();
				_currentPanelElements = null;
			}
			Close();
		}
		_shouldCloseAtEndOfFrame = false;
	}

	public void SetDialogueText(string sentence)
	{
		_currentPanelElements.Text.SetText(sentence);
		if (_currentDialogue.IsNextNodePlayerChoices())
		{
			if (_currentPanelElements.TypewriterAnimator != null)
			{
				_currentPanelElements.TypewriterAnimator.onTextShowed.AddListener(TryAutoShowPlayerChoices);
			}
			else
			{
				TryAutoShowPlayerChoices();
			}
		}
	}

	private void TryAutoShowPlayerChoices()
	{
		if (_currentPanelElements.TypewriterAnimator != null)
		{
			_currentPanelElements.TypewriterAnimator.onTextShowed.RemoveListener(TryAutoShowPlayerChoices);
		}
		_currentDialogue.TryProgressToPlayerChoices(this);
	}

	private void TriggerNextQueuedDialogueRequest()
	{
		_isQueuedDialogueStarting = false;
		GameManager.UIManager.DisplayPanel(PanelID.DialoguePanel, _queuedDialogueRequests.Dequeue());
	}

	private void OnDialogueStartRequest(GameEvent gameEvent)
	{
		if (!(gameEvent is DialogueGameEvent dialogueGameEvent))
		{
			return;
		}
		if (dialogueGameEvent.IsNewDialogue)
		{
			bool flag = _currentDialogue != null || _isQueuedDialogueStarting;
			if (!(!dialogueGameEvent.Queue && flag))
			{
				_queuedDialogueRequests.Enqueue(dialogueGameEvent);
				if (!flag)
				{
					_isQueuedDialogueStarting = true;
					Invoke("TriggerNextQueuedDialogueRequest", dialogueGameEvent.Delay);
				}
			}
		}
		else
		{
			GameManager.UIManager.DisplayPanel(PanelID.DialoguePanel, dialogueGameEvent);
		}
	}

	private void ReenableSpeakerPortrait(GameEvent gameEvent)
	{
		if (_currentDialogue == null || _currentDialogue.CurrentDialoguePanelOptions == null || !_currentDialogue.CurrentDialoguePanelOptions.ShowSpeakerPortrait)
		{
			GameEventDispatcher.RemoveListener(GameEventType.DrifterPortraitDisabled, ReenableSpeakerPortrait);
			return;
		}
		DialoguePanelOptions currentDialoguePanelOptions = _currentDialogue.CurrentDialoguePanelOptions;
		if (currentDialoguePanelOptions != null && currentDialoguePanelOptions.ShowSpeakerPortrait)
		{
			AgentDescriptor agentDescriptor = ((_currentDialogue.CurrentSpeaker != null) ? _currentDialogue.CurrentSpeaker : StoryManager.DialogueContext.GetActor(DialogueContext.ActorType.FirstMate));
			if (agentDescriptor != null)
			{
				EnableSpeakerPortrait(agentDescriptor, currentDialoguePanelOptions, registerToDisableEvent: false);
			}
		}
	}

	private void EnableProgressArrow()
	{
		if (_currentDialogue != null)
		{
			Dialogue currentDialogue = _currentDialogue;
			currentDialogue.OnCanProgressDialogue = (Action)Delegate.Remove(currentDialogue.OnCanProgressDialogue, new Action(EnableProgressArrow));
			if (_currentDialogue.CanProgressDialogue())
			{
				_currentPanelElements.ProgressArrow.SetActive(value: true);
				return;
			}
			Dialogue currentDialogue2 = _currentDialogue;
			currentDialogue2.OnCanProgressDialogue = (Action)Delegate.Combine(currentDialogue2.OnCanProgressDialogue, new Action(EnableProgressArrow));
		}
	}

	private void DisableProgressArrow()
	{
		_currentPanelElements.ProgressArrow.SetActive(value: false);
	}

	private void SetCurrentDialogue(DialogueTreeProperties dialogueProperties)
	{
		if (_currentDialogue != null)
		{
			LocalizationManager.ParamManagers.Remove(_currentDialogue);
		}
		if ((bool)dialogueProperties)
		{
			_currentDialogue = new Dialogue(dialogueProperties);
			LocalizationManager.ParamManagers.Add(_currentDialogue);
		}
		else
		{
			_currentDialogue = null;
		}
	}

	public bool IsInteractableActiveOrQueued(IDialogueInteractable interactable)
	{
		if (_currentDialogue == null || _currentDialogue.Interactable != interactable)
		{
			return IsInteractableQueued(interactable);
		}
		return true;
	}

	private bool IsInteractableQueued(IDialogueInteractable interactable)
	{
		foreach (DialogueGameEvent queuedDialogueRequest in _queuedDialogueRequests)
		{
			if (queuedDialogueRequest.DialogueInteractable == interactable)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsToBeContinued()
	{
		if (_currentDialogue != null && _queuedDialogueRequests.TryPeek(out var result))
		{
			return _currentDialogue.DialogueProperties == result.DialogueProperties;
		}
		return false;
	}
}
