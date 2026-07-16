using System;
using MLCN_Localization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PopupDialogComponent : MonoBehaviour
{
	public enum PopupSpace
	{
		Global = 0,
		Local = 1
	}

	[SerializeField]
	private TMP_Text labelCharacterName;

	[SerializeField]
	private GameObject nameTag;

	[SerializeField]
	private TMP_Text labelDialogMessage;

	[SerializeField]
	private UIContentAnimator animator;

	[SerializeField]
	private PopupSpace popupSpace;

	private DialogSequence activeSequence;

	private bool isVisible;

	private int dialogSequenceIndex = -1;

	private int dialogSequenceLength = -1;

	private bool multiDialogIsRunning;

	private bool isPlayingTextAnimation;

	private string[] queuedDialogs;

	private bool enterDialogInteraction;

	private string currentSoundToPlay;

	private UnityEvent onCleanup = new UnityEvent();

	private UnityAction onNextDialog;

	private UnityAction onExit;

	private string lastUsedNameId = string.Empty;

	private void Start()
	{
		animator.BeginWithTargetState();
		onCleanup.AddListener(delegate
		{
			Cleanup();
		});
	}

	private void OnDestroy()
	{
	}

	public bool IsVisible()
	{
		return isVisible;
	}

	public void ExitEscape()
	{
		if (isVisible)
		{
			TweenerManager.StopTweenWithContainingKey(lastUsedNameId + "Dialog_" + popupSpace);
			TweenerManager.StopTweenWithContainingKey(lastUsedNameId);
			SoundManager.StopSoundContainingKey(currentSoundToPlay, destroy: false);
			animator.OnPlay(onCleanup);
			labelDialogMessage.text = "";
			multiDialogIsRunning = false;
			dialogSequenceLength = -1;
			dialogSequenceIndex = -1;
			queuedDialogs = null;
			isVisible = false;
			onNextDialog = null;
			enterDialogInteraction = false;
			if (onNextDialog != null)
			{
				InputManager.OnMainClick.RemoveListener(onNextDialog);
			}
			if (onExit != null)
			{
				InputManager.OnCancleClick.RemoveListener(onExit);
				onExit = null;
			}
		}
	}

	public void NextDialog()
	{
		if (isVisible && !DialogManager.IsAutoplayActive())
		{
			onNextDialog();
		}
	}

	public void EnterDialogSequence(string dialogKey, string soundToPlay = "characters_talk_generic", EntityNameTag nameTag = null)
	{
		TryShowNameTag(nameTag);
		string nameId = ((nameTag != null) ? (nameTag.GetID() + "_") : "");
		Action action = delegate
		{
			TweenerManager.TweenTimeAction(nameId + "DialogDuration_" + popupSpace, DialogManager.GetDialogDuration(), delegate
			{
				ExitDialogSequence(nameId);
			});
		};
		string localizedString = LocalizationManager.GetLocalizedString(dialogKey, LocalizationDataTable.Tables.Dialogs);
		if (isVisible && isPlayingTextAnimation)
		{
			TweenerManager.StopTweenWithContainingKey(nameId + "DialogAnimation_" + popupSpace);
			StopDialogAnimation(localizedString, nameTag);
			action();
			return;
		}
		if (isPlayingTextAnimation)
		{
			PlayDialogAnimation(localizedString, nameTag, action);
			return;
		}
		if (isVisible)
		{
			ExitDialogSequence(nameId);
			return;
		}
		Cleanup(nameTag);
		animator.OnReverse();
		SoundManager.PlaySoundOnce(soundToPlay, noDuplicates: true);
		currentSoundToPlay = soundToPlay;
		PlayDialogAnimation(localizedString, nameTag, action);
		isVisible = true;
	}

	public void EnterPreLocalizedDialogSequence(string dialog, string soundToPlay = "characters_talk_generic", EntityNameTag nameTag = null)
	{
		TryShowNameTag(nameTag);
		string nameId = ((nameTag != null) ? (nameTag.GetID() + "_") : "");
		Action action = delegate
		{
			TweenerManager.TweenTimeAction(nameId + "DialogDuration_" + popupSpace, DialogManager.GetDialogDuration(), delegate
			{
				ExitDialogSequence(nameId);
			});
		};
		if (isVisible && isPlayingTextAnimation)
		{
			TweenerManager.StopTweenWithContainingKey(nameId + "DialogAnimation_" + popupSpace);
			StopDialogAnimation(dialog, nameTag);
			action();
			return;
		}
		if (isPlayingTextAnimation)
		{
			PlayDialogAnimation(dialog, nameTag, action);
			return;
		}
		if (isVisible)
		{
			ExitDialogSequence(nameId);
			labelDialogMessage.text = "";
			return;
		}
		Cleanup(nameTag);
		animator.OnReverse();
		SoundManager.PlaySoundOnce(soundToPlay, noDuplicates: true);
		currentSoundToPlay = soundToPlay;
		PlayDialogAnimation(dialog, nameTag, action);
		isVisible = true;
	}

	public void ExitDialogSequence(string nameId, bool cleanup = false, EntityNameTag nameTag = null)
	{
		TweenerManager.StopTweenWithContainingKey(nameId + "Dialog_" + popupSpace);
		SoundManager.StopSoundContainingKey(currentSoundToPlay, destroy: false);
		if (onExit != null)
		{
			InputManager.OnCancleClick.RemoveListener(onExit);
			onExit = null;
		}
		animator.OnPlay(onCleanup);
		if (cleanup)
		{
			Cleanup(nameTag);
		}
		multiDialogIsRunning = false;
		dialogSequenceLength = -1;
		dialogSequenceIndex = -1;
		queuedDialogs = null;
		if (enterDialogInteraction && onNextDialog != null)
		{
			InputManager.OnMainClick.RemoveListener(onNextDialog);
			TweenerManager.TweenTimeAction("Delay GameState Switch_" + popupSpace, 0.3f, delegate
			{
				isVisible = false;
			});
			onNextDialog = null;
			enterDialogInteraction = false;
		}
		else
		{
			isVisible = false;
		}
	}

	public void EnterMultiDialogSequence(string[] dialogKeys, int startIndex, string soundToPlay = "characters_talk_generic", Action onFinishedSequence = null, float duration = 3f, EntityNameTag nameTag = null)
	{
		TryShowNameTag(nameTag);
		if (!DialogManager.IsAutoplayActive() && popupSpace == PopupSpace.Global)
		{
			GlobalReferences.GetCharacterController().StopMovement();
			EnterMultiDialogByInteraction(dialogKeys, startIndex, soundToPlay, onFinishedSequence, nameTag);
			return;
		}
		string nameId = ((nameTag != null) ? (nameTag.GetID() + "_") : "");
		if (multiDialogIsRunning)
		{
			TweenerManager.StopTweenWithContainingKey(nameId + "Dialog_" + popupSpace);
			Cleanup(nameTag);
			if (!isPlayingTextAnimation)
			{
				dialogSequenceIndex++;
			}
			NextDialogSequence(dialogKeys, dialogSequenceIndex, soundToPlay, onFinishedSequence, duration, nameTag);
			return;
		}
		multiDialogIsRunning = true;
		dialogSequenceIndex = startIndex;
		dialogSequenceLength = dialogKeys.Length;
		animator.OnReverse();
		onExit = delegate
		{
			ExitDialogSequence(nameId, cleanup: true, nameTag);
		};
		Action action = delegate
		{
			InputManager.OnCancleClick.AddListener(onExit);
		};
		TweenerManager.TweenTimeAction(nameId + "_delay_clickevent_registration", 0.1f, action);
		Action onFinished = delegate
		{
			if (!isPlayingTextAnimation)
			{
				Cleanup(nameTag);
				dialogSequenceIndex++;
			}
			NextDialogSequence(dialogKeys, dialogSequenceIndex, soundToPlay, onFinishedSequence, duration, nameTag);
		};
		Action onFinished2 = delegate
		{
			TweenerManager.TweenTimeAction(nameId + "Delay Next Dialog_" + popupSpace, duration, onFinished);
		};
		string localizedString = LocalizationManager.GetLocalizedString(dialogKeys[startIndex], LocalizationDataTable.Tables.Dialogs);
		PlayDialogAnimation(localizedString, nameTag, onFinished2);
		SoundManager.PlaySoundOnce(soundToPlay, noDuplicates: true);
		currentSoundToPlay = soundToPlay;
		isVisible = true;
	}

	private void NextDialogSequence(string[] dialogKeys, int index, string soundToPlay = "characters_talk_generic", Action onFinishedSequence = null, float duration = 3f, EntityNameTag nameTag = null)
	{
		string nameId = ((nameTag != null) ? (nameTag.GetID() + "_") : "");
		if (dialogSequenceIndex >= dialogSequenceLength)
		{
			if (onFinishedSequence != null)
			{
				onFinishedSequence();
			}
			ExitDialogSequence(nameId);
			return;
		}
		Action onFinished = delegate
		{
			Cleanup();
			dialogSequenceIndex++;
			NextDialogSequence(dialogKeys, dialogSequenceIndex, soundToPlay, onFinishedSequence, 3f, nameTag);
		};
		Action action = delegate
		{
			TweenerManager.TweenTimeAction(nameId + "Delay Next Dialog_" + popupSpace, duration, onFinished);
		};
		if (isPlayingTextAnimation)
		{
			StopDialogAnimation(LocalizationManager.GetLocalizedString(dialogKeys[index], LocalizationDataTable.Tables.Dialogs), nameTag);
			action();
			return;
		}
		string localizedString = LocalizationManager.GetLocalizedString(dialogKeys[index], LocalizationDataTable.Tables.Dialogs);
		PlayDialogAnimation(localizedString, nameTag, action);
		currentSoundToPlay = soundToPlay;
		SoundManager.PlaySoundOnce(soundToPlay, noDuplicates: true);
	}

	private void EnterMultiDialogByInteraction(string[] dialogKeys, int startIndex, string soundToPlay = "characters_talk_generic", Action onFinishedSequence = null, EntityNameTag nameTag = null)
	{
		TryShowNameTag(nameTag);
		string nameId = ((nameTag != null) ? (nameTag.GetID() + "_") : "");
		if (enterDialogInteraction || onNextDialog != null || isVisible)
		{
			return;
		}
		Cleanup(nameTag);
		queuedDialogs = dialogKeys;
		dialogSequenceIndex = startIndex;
		Action onFinish = delegate
		{
			if (onFinishedSequence != null)
			{
				onFinishedSequence();
			}
			ExitDialogSequence(nameId);
		};
		onNextDialog = delegate
		{
			if (queuedDialogs != null)
			{
				NextDialogInteraction(queuedDialogs, soundToPlay, onFinish, nameTag);
				if (!DialogManager.IsAnimationActivated())
				{
					dialogSequenceIndex++;
				}
			}
		};
		if (!isVisible)
		{
			animator.OnReverse();
			isVisible = true;
			if (!enterDialogInteraction)
			{
				SoundManager.PlaySoundOnce(soundToPlay, noDuplicates: true);
				currentSoundToPlay = soundToPlay;
				string localizedString = LocalizationManager.GetLocalizedString(dialogKeys[dialogSequenceIndex], LocalizationDataTable.Tables.Dialogs);
				PlayDialogAnimation(localizedString, nameTag);
				enterDialogInteraction = true;
			}
		}
	}

	private void NextDialogInteraction(string[] dialogKeys, string soundToPlay = "characters_talk_generic", Action onFinishedSequence = null, EntityNameTag nameTag = null)
	{
		string text = ((nameTag != null) ? (nameTag.GetID() + "_") : "");
		if (dialogSequenceIndex >= dialogKeys.Length)
		{
			onFinishedSequence();
			dialogSequenceIndex = 0;
			return;
		}
		if (isPlayingTextAnimation)
		{
			StopDialogAnimation(LocalizationManager.GetLocalizedString(dialogKeys[dialogSequenceIndex], LocalizationDataTable.Tables.Dialogs), nameTag);
			dialogSequenceIndex++;
			return;
		}
		TweenerManager.StopTweenWithContainingKey(text + "Dialog_" + popupSpace);
		Cleanup(nameTag);
		string localizedString = LocalizationManager.GetLocalizedString(dialogKeys[dialogSequenceIndex], LocalizationDataTable.Tables.Dialogs);
		PlayDialogAnimation(localizedString, nameTag);
		SoundManager.PlaySoundOnce(soundToPlay, noDuplicates: true);
		currentSoundToPlay = soundToPlay;
	}

	private void PlayDialogAnimation(string dialog, EntityNameTag nameTag, Action onFinished = null)
	{
		string text = ((nameTag != null) ? (nameTag.GetID() + "_") : "");
		TweenerManager.StopTweenWithContainingKey(text + "DialogAnimation_" + popupSpace);
		if (DialogManager.IsAnimationActivated())
		{
			float t = TweenerManager.GetDefaultEaseCurve().Evaluate(DialogManager.GetTextAnimationSpeed());
			float textAnimationSpeed = Mathf.Lerp(DialogManager.GetTextAnimationSpeedMaximum(), DialogManager.GetTextAnimationSpeedMinimum(), t) * 0.001f;
			isPlayingTextAnimation = true;
			onFinished = (Action)Delegate.Combine(onFinished, (Action)delegate
			{
				isPlayingTextAnimation = false;
			});
			TweenerManager.TweenText(text + "DialogAnimation_" + popupSpace, dialog, labelDialogMessage, textAnimationSpeed, onFinished);
		}
		else
		{
			isPlayingTextAnimation = false;
			labelDialogMessage.text = dialog;
			onFinished?.Invoke();
		}
	}

	private void StopDialogAnimation(string showDialog, EntityNameTag nameTag)
	{
		TweenerManager.StopTweenWithContainingKey(((nameTag != null) ? (nameTag.GetID() + "_") : "") + "DialogAnimation_" + popupSpace);
		isPlayingTextAnimation = false;
		labelDialogMessage.text = showDialog;
	}

	private void TryShowNameTag(EntityNameTag nameTag = null)
	{
		if (nameTag == null || !nameTag.HasName())
		{
			HideNameTag();
		}
		else
		{
			ShowNameTag(nameTag.GetName(), nameTag.GetNameColor());
		}
	}

	private void ShowNameTag(string name, Color nameColor)
	{
		labelCharacterName.text = name;
		labelCharacterName.color = nameColor;
		nameTag.SetActive(value: true);
	}

	private void HideNameTag()
	{
		nameTag.SetActive(value: false);
	}

	private void Cleanup(EntityNameTag nameTag = null)
	{
		labelDialogMessage.text = "";
		if (nameTag != null)
		{
			TweenerManager.StopTweenWithContainingKey(nameTag.GetID().ToString());
		}
	}

	public void HideMessage()
	{
		animator.OnPlay();
		labelDialogMessage.text = "";
		isVisible = false;
	}

	public void HideForce()
	{
		if (!(animator == null))
		{
			animator.BeginWithTargetState();
			labelDialogMessage.text = "";
			isVisible = false;
		}
	}
}
