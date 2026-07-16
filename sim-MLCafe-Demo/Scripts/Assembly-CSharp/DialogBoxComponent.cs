using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogBoxComponent : MonoBehaviour
{
	[SerializeField]
	private UIContentAnimator animator;

	[SerializeField]
	private GameObject nameTagContent;

	[SerializeField]
	private TMP_Text labelNameTag;

	[SerializeField]
	private TMP_Text labelDialogTextBox;

	public UnityAction OnFinished = delegate
	{
	};

	public UnityEvent OnFinishedSingleEvent = new UnityEvent();

	public bool isVisible;

	public bool isPlayingTypeAnimation;

	private string activeSentence;

	public bool alwaysAutoProceed;

	private int id;

	private Queue<string> sentences;

	private Dialog activeDialog;

	private void Awake()
	{
		id = Guid.NewGuid().GetHashCode();
		sentences = new Queue<string>();
	}

	private void Start()
	{
		animator.OnFinishedReverse.AddListener(delegate
		{
			isVisible = false;
			OnFinished();
			OnFinished = delegate
			{
			};
			if (activeDialog != null && activeDialog.animationProperty != null)
			{
				activeDialog.animationProperty.animator.SetBool(activeDialog.animationProperty.stateName, activeDialog.animationProperty.value);
			}
			OnFinishedSingleEvent.Invoke();
		});
	}

	public void ValidateSentences()
	{
		if (sentences == null)
		{
			sentences = new Queue<string>();
		}
	}

	public bool IsPlaying()
	{
		if (sentences.Count <= 0)
		{
			return isVisible;
		}
		return true;
	}

	public bool IsPlayingTextAnimation()
	{
		if (isPlayingTypeAnimation)
		{
			return isVisible;
		}
		return false;
	}

	public bool PlayDialog(Dialog dialog)
	{
		if (IsPlaying())
		{
			return false;
		}
		if (dialog == null || GameStateManager.GetCurrentCharacterState() != GameStateManager.CharacterState.CharacterMode)
		{
			return false;
		}
		activeDialog = dialog;
		TryShowNameTag(activeDialog.nameTag);
		animator.OnPlay();
		isVisible = true;
		if (activeDialog != null && activeDialog.animationProperty != null)
		{
			activeDialog.animationProperty.animator.SetBool(activeDialog.animationProperty.stateName, activeDialog.animationProperty.value);
		}
		sentences.Clear();
		string[] array = activeDialog.sentences;
		foreach (string item in array)
		{
			sentences.Enqueue(item);
		}
		DisplayNextSentence();
		return true;
	}

	public void StopDialog()
	{
		if (activeDialog != null)
		{
			SoundManager.StopSoundContainingKey(activeDialog.sound);
		}
		activeSentence = "";
		if (activeDialog != null && activeDialog.animationProperty != null)
		{
			activeDialog.animationProperty.animator.SetBool(activeDialog.animationProperty.stateName, !activeDialog.animationProperty.value);
		}
		activeDialog = null;
		if (sentences != null)
		{
			sentences.Clear();
		}
		animator.OnReverse();
	}

	public void StopDialogImmidiate()
	{
		if (activeDialog != null)
		{
			SoundManager.StopSoundContainingKey(activeDialog.sound);
		}
		activeSentence = "";
		if (activeDialog != null && activeDialog.animationProperty != null)
		{
			activeDialog.animationProperty.animator.SetBool(activeDialog.animationProperty.stateName, !activeDialog.animationProperty.value);
		}
		activeDialog = null;
		if (sentences != null)
		{
			sentences.Clear();
		}
		animator.BeginWithNormalState();
		isVisible = false;
	}

	public void PauseDialog()
	{
		animator.OnReverseWithoutNotify();
		isVisible = false;
	}

	public void ContinueDialog()
	{
		animator.OnPlayWithoutNotify();
		isVisible = true;
	}

	public void DisplayNextSentence()
	{
		if (isPlayingTypeAnimation)
		{
			StopDialogAnimation();
			return;
		}
		if (sentences.Count == 0 || activeDialog == null)
		{
			StopDialog();
			return;
		}
		TweenerManager.StopTweenWithContainingKey(id + "_" + activeDialog.nameTag.GetID() + "DelayNextDialog");
		Action action = null;
		if (DialogManager.IsAutoplayActive() || activeDialog.autoProceed || alwaysAutoProceed)
		{
			action = delegate
			{
				TweenerManager.TweenTimeAction(id + "_" + activeDialog.nameTag.GetID() + "DelayNextDialog", DialogManager.GetDialogDuration(), delegate
				{
					DisplayNextSentence();
				});
			};
		}
		SoundManager.PlaySoundOnce(activeDialog.sound, noDuplicates: true);
		activeSentence = sentences.Dequeue();
		if (DialogManager.IsAnimationActivated())
		{
			StartCoroutine(TypeSentence(activeSentence, action));
			return;
		}
		labelDialogTextBox.text = activeSentence;
		action?.Invoke();
	}

	private void TryShowNameTag(EntityNameTag nameTag)
	{
		if (nameTag == null || !nameTag.HasName())
		{
			nameTagContent.SetActive(value: false);
			return;
		}
		labelNameTag.color = nameTag.GetNameColor();
		labelNameTag.text = nameTag.GetName();
		nameTagContent.SetActive(value: true);
	}

	public void StopDialogAnimation()
	{
		StopAllCoroutines();
		isPlayingTypeAnimation = false;
		labelDialogTextBox.text = activeSentence;
		if (activeDialog != null && activeDialog.animationProperty != null)
		{
			activeDialog.animationProperty.animator.SetBool(activeDialog.animationProperty.stateName, activeDialog.animationProperty.value);
		}
	}

	private IEnumerator TypeSentence(string sentence, Action onFinished = null)
	{
		bool commandDetected = false;
		string command = "";
		labelDialogTextBox.text = "";
		float t = TweenerManager.GetDefaultEaseCurve().Evaluate(DialogManager.GetTextAnimationSpeed());
		float speed = Mathf.Lerp(DialogManager.GetTextAnimationSpeedMaximum(), DialogManager.GetTextAnimationSpeedMinimum(), t) * 0.001f;
		isPlayingTypeAnimation = true;
		char[] array = sentence.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			char c = array[i];
			if (c == '<')
			{
				commandDetected = true;
			}
			if (commandDetected)
			{
				command += c;
				if (c == '>')
				{
					labelDialogTextBox.text += command;
					command = "";
					commandDetected = false;
				}
			}
			else
			{
				labelDialogTextBox.text += c;
				yield return new WaitForSeconds(speed);
			}
		}
		isPlayingTypeAnimation = false;
		onFinished?.Invoke();
	}
}
