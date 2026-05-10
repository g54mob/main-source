using System;
using CTS;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.TechTree;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;

public class UISoundManager : MonoBehaviour
{
	[SerializeField]
	private AudioSource _audioSource;

	[SerializeField]
	private AudioAsset _buttonSound;

	[SerializeField]
	private AudioAsset _showedSoundCanvas;

	[SerializeField]
	private AudioAsset _hidedSoundCanvas;

	[SerializeField]
	private AudioAsset _moneySound;

	[SerializeField]
	private AudioAsset _lostMoneySound;

	[SerializeField]
	private AudioAsset _hireSound;

	[SerializeField]
	private AudioAsset _deliverySound;

	[SerializeField]
	private AudioAsset _furnitureRotationSound;

	[SerializeField]
	private AudioAsset _pauseSound;

	[SerializeField]
	private AudioAsset _slowTimeSound;

	[SerializeField]
	private AudioAsset _fastTimeSound;

	[SerializeField]
	private AudioAsset _agencyTransitionSound;

	[SerializeField]
	private AudioAsset _abyssalWrath;

	[SerializeField]
	private AudioAsset _technoUnlock;

	[SerializeField]
	[Foldout("Quest")]
	private AudioAsset _objectiveSucced;

	[SerializeField]
	[Foldout("Quest")]
	private AudioAsset _missionSucced;

	[SerializeField]
	[Foldout("WorkerPanel")]
	private AudioAsset _showPanel;

	[SerializeField]
	[Foldout("WorkerPanel")]
	private AudioAsset _hidePanel;

	[SerializeField]
	[Foldout("InformationPanel")]
	private AudioAsset _showInformationPanel;

	private AudioClip _previousAudioClipTimeSound;

	private AudioSource _previousAudioSourceTimeSound;

	private void OnEnable()
	{
		ButtonStaticEvents.ButtonPressed += PlayButtonSound;
		ToggleStaticEvents.TogglePressed = (Action)Delegate.Combine(ToggleStaticEvents.TogglePressed, new Action(PlayButtonSound));
		MoneyHandler.EarnedMoney += PlayMoneySound;
		MoneyHandler.LostMoney += OnLostMoney;
		WorkerHirePanel.Hiring += OnHiring;
		Deliveries.DeliveryCompleted += OnDeliveryArrived;
		FurnitureController.Rotating += OnRotating;
		TimeController.TimeModeChanged += OnTimeScaleChanged;
		InterimAgency.SwitchingScene += OnAgencyChange;
		CanvasGroupAudioPlayer.CanvasShow += CanvasShow;
		CanvasGroupAudioPlayer.CanvasHidden += CanvasHidden;
		Quest.QuestEntrySucceeded += QuestObjectiveSucced;
		Quest.QuestSucceeded += SoundQuestSucced;
		AgentPanelGroup.ShowPanelWorker += ShowPanelWorker;
		AgentPanelGroup.HidePanelWorker += HidePanelWorker;
		UIMessage.MessageShowing += MessageShow;
		UIGifs.GifsOn += MessageShow;
		UIGifs.GifValidated += CanvasHidden;
		PowerInfernalSoundEvent.LaunchSound += AbyssalWrathSound;
		TechTreeNodeSetup.TechUnlockSound += TechTreeNodeSetup_TechUnlockSound;
	}

	private void OnDisable()
	{
		PowerInfernalSoundEvent.LaunchSound -= AbyssalWrathSound;
		ButtonStaticEvents.ButtonPressed -= PlayButtonSound;
		ToggleStaticEvents.TogglePressed = (Action)Delegate.Remove(ToggleStaticEvents.TogglePressed, new Action(PlayButtonSound));
		MoneyHandler.EarnedMoney -= PlayMoneySound;
		MoneyHandler.LostMoney -= OnLostMoney;
		WorkerHirePanel.Hiring -= OnHiring;
		Deliveries.DeliveryCompleted -= OnDeliveryArrived;
		FurnitureController.Rotating -= OnRotating;
		TimeController.TimeModeChanged -= OnTimeScaleChanged;
		InterimAgency.SwitchingScene -= OnAgencyChange;
		CanvasGroupAudioPlayer.CanvasShow -= CanvasShow;
		CanvasGroupAudioPlayer.CanvasHidden -= CanvasHidden;
		Quest.QuestEntrySucceeded -= QuestObjectiveSucced;
		Quest.QuestSucceeded -= SoundQuestSucced;
		AgentPanelGroup.ShowPanelWorker -= ShowPanelWorker;
		AgentPanelGroup.HidePanelWorker -= HidePanelWorker;
		UIMessage.MessageShowing -= MessageShow;
		UIGifs.GifsOn -= MessageShow;
		UIGifs.GifValidated -= CanvasHidden;
		TechTreeNodeSetup.TechUnlockSound -= TechTreeNodeSetup_TechUnlockSound;
	}

	private void TechTreeNodeSetup_TechUnlockSound()
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_technoUnlock);
	}

	private void AbyssalWrathSound()
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_abyssalWrath);
	}

	private void MessageShow()
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_showInformationPanel);
	}

	private void QuestObjectiveSucced(Quest arg1, int arg2)
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_objectiveSucced);
	}

	private void SoundQuestSucced(Quest obj)
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_missionSucced);
	}

	private void HidePanelWorker()
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_hidePanel);
	}

	private void ShowPanelWorker()
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_showPanel);
	}

	private void OnLostMoney()
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_lostMoneySound);
	}

	private void OnAgencyChange()
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_agencyTransitionSound);
	}

	private void OnTimeScaleChanged(ETimeModes newMode)
	{
		AudioAsset audioAsset = null;
		switch (newMode)
		{
		case ETimeModes.Pause:
			audioAsset = _pauseSound;
			break;
		case ETimeModes.Fast:
			audioAsset = _fastTimeSound;
			break;
		case ETimeModes.SlowMo:
			audioAsset = _slowTimeSound;
			break;
		}
		if ((bool)_previousAudioSourceTimeSound && _previousAudioSourceTimeSound.isPlaying && _previousAudioSourceTimeSound.clip == _previousAudioClipTimeSound)
		{
			MonoSingleton<SoundManager>.Instance.ReleaseAudioSourceToPool(_previousAudioSourceTimeSound);
		}
		if (audioAsset != null)
		{
			_previousAudioClipTimeSound = audioAsset.AudioClips[0];
		}
		_previousAudioSourceTimeSound = MonoSingleton<SoundManager>.Instance.PlayAudioAsset(audioAsset);
	}

	private void OnRotating(bool playSound)
	{
		if (playSound)
		{
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_furnitureRotationSound);
		}
	}

	private void OnDeliveryArrived(Delivery delivery)
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_deliverySound);
	}

	private void PlayButtonSound()
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_buttonSound);
	}

	private void PlayMoneySound(int addedMoney)
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_moneySound);
	}

	private void OnHiring(Agent obj)
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_hireSound);
	}

	private void CanvasHidden()
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_hidedSoundCanvas);
	}

	private void CanvasShow()
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_showedSoundCanvas);
	}
}
