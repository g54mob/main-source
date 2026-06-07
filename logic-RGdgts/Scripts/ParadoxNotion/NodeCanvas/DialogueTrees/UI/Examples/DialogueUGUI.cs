using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.DialogueTrees.UI.Examples
{
	public class DialogueUGUI : MonoBehaviour
	{
		[Serializable]
		public class SubtitleDelays
		{
			public float characterDelay;

			public float sentenceDelay;

			public float commaDelay;

			public float finalDelay;
		}

		public bool skipOnInput;

		public bool waitForInput;

		public RectTransform subtitlesGroup;

		public Text actorSpeech;

		public Text actorName;

		public Image actorPortrait;

		public RectTransform waitInputIndicator;

		public SubtitleDelays subtitleDelays;

		public List<AudioClip> typingSounds;

		private AudioSource playSource;

		public RectTransform optionsGroup;

		public Button optionButton;

		private Dictionary<Button, int> cachedButtons;

		private Vector2 originalSubsPosition;

		private bool isWaitingChoice;

		private AudioSource _localSource;

		private AudioSource localSource => null;

		private bool anyKeyDown => false;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Subscribe()
		{
		}

		private void UnSubscribe()
		{
		}

		private void Hide()
		{
		}

		private void OnDialogueStarted(DialogueTree dlg)
		{
		}

		private void OnDialoguePaused(DialogueTree dlg)
		{
		}

		private void OnDialogueFinished(DialogueTree dlg)
		{
		}

		private void OnSubtitlesRequest(SubtitlesRequestInfo info)
		{
		}

		private IEnumerator Internal_OnSubtitlesRequestInfo(SubtitlesRequestInfo info)
		{
			return null;
		}

		private void PlayTypeSound()
		{
		}

		private IEnumerator CheckInput(Action Do)
		{
			return null;
		}

		private IEnumerator DelayPrint(float time)
		{
			return null;
		}

		private void OnMultipleChoiceRequest(MultipleChoiceRequestInfo info)
		{
		}

		private IEnumerator CountDown(MultipleChoiceRequestInfo info)
		{
			return null;
		}

		private void Finalize(MultipleChoiceRequestInfo info, int index)
		{
		}

		private void SetMassAlpha(RectTransform root, float alpha)
		{
		}
	}
}
