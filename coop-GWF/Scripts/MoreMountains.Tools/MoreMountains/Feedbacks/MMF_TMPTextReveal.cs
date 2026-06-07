using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you reveal words, lines, or characters in a target TMP, one at a time")]
	[FeedbackPath("TextMesh Pro/TMP Text Reveal")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.TextMeshPro", null)]
	public class MMF_TMPTextReveal : MMF_Feedback
	{
		public enum RevealModes
		{
			Character = 0,
			Lines = 1,
			Words = 2
		}

		public enum DurationModes
		{
			Interval = 0,
			TotalDuration = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		protected string _originalText;

		protected TMP_TextInfo _textInfo;

		[MMFInspectorGroup("Target", true, 12, true, false)]
		[Tooltip("the target TMP_Text component we want to change the text on")]
		public TMP_Text TargetTMPText;

		[MMFInspectorGroup("Change Text", true, 13, false, false)]
		[Tooltip("whether or not to replace the current TMP target's text on play")]
		public bool ReplaceText;

		[Tooltip("the new text to replace the old one with")]
		[TextArea]
		public string NewText = "Hello World";

		[MMFInspectorGroup("Reveal", true, 14, false, false)]
		[Tooltip("the selected way to reveal the text (character by character, word by word, or line by line)")]
		public RevealModes RevealMode;

		[Tooltip("whether to define duration by the time interval between two unit reveals, or by the total duration the reveal should take")]
		public DurationModes DurationMode;

		[Tooltip("the interval (in seconds) between two reveals")]
		[MMFEnumCondition("DurationMode", new int[] { 0 })]
		public float IntervalBetweenReveals = 0.05f;

		[Tooltip("the total duration of the text reveal, in seconds")]
		[MMFEnumCondition("DurationMode", new int[] { 1 })]
		public float RevealDuration = 1f;

		[Tooltip("a UnityEvent to invoke every time a reveal happens (word, line or character)")]
		public UnityEvent OnReveal;

		[Tooltip("alright so that one will be weird : for reasons, TextMeshPro won't let you read the length of a disabled text, so to do so, we need to enable it, even if it's just to disable it again right after. If you're targeting a disabled text, or a text that is part of a disabled hierarchy, you'll probably want to set this to true so that the system can proceed with accurate duration computation. If you don't, and your target transform is disabled, duration won't be computed correctly.")]
		public bool AllowHierarchyActivationForDurationComputation;

		protected float _delay;

		protected Coroutine _coroutine;

		protected int _richTextLength;

		protected int _totalCharacters;

		protected int _totalLines;

		protected int _totalWords;

		protected string _initialText;

		protected int _indexLastTime = -1;

		public override bool HasAutomatedTargetAcquisition => true;

		public override float FeedbackDuration
		{
			get
			{
				if (DurationMode == DurationModes.TotalDuration)
				{
					return RevealDuration;
				}
				if (TargetTMPText == null)
				{
					return 0f;
				}
				if (TargetTMPText.textInfo == null)
				{
					bool activeSelf = TargetTMPText.gameObject.activeSelf;
					TargetTMPText.gameObject.SetActive(value: true);
					TargetTMPText.ForceMeshUpdate(ignoreActiveState: true);
					TargetTMPText.gameObject.SetActive(activeSelf);
				}
				if (AllowHierarchyActivationForDurationComputation)
				{
					List<Transform> list = (from p in TargetTMPText.transform.MMEnumerateAllParents(includeSelf: true)
						where !p.gameObject.activeSelf
						select p).ToList();
					list.ForEach(delegate(Transform p)
					{
						p.gameObject.SetActive(value: true);
					});
					TargetTMPText.ForceMeshUpdate(ignoreActiveState: true);
					list.ForEach(delegate(Transform p)
					{
						p.gameObject.SetActive(value: false);
					});
				}
				if (TargetTMPText.textInfo == null)
				{
					return 0f;
				}
				float result = 0f;
				if (ReplaceText)
				{
					_originalText = TargetTMPText.text;
					TargetTMPText.text = NewText;
				}
				switch (RevealMode)
				{
				case RevealModes.Character:
					result = (float)RichTextLength(TargetTMPText.text) * IntervalBetweenReveals;
					break;
				case RevealModes.Lines:
					result = (float)TargetTMPText.textInfo.lineCount * IntervalBetweenReveals;
					break;
				case RevealModes.Words:
					result = (float)TargetTMPText.textInfo.wordCount * IntervalBetweenReveals;
					break;
				}
				if (ReplaceText)
				{
					TargetTMPText.text = _originalText;
				}
				return result;
			}
			set
			{
				if (DurationMode == DurationModes.TotalDuration)
				{
					RevealDuration = value;
				}
				else if (TargetTMPText != null)
				{
					if (ReplaceText)
					{
						_originalText = TargetTMPText.text;
						TargetTMPText.text = NewText;
					}
					switch (RevealMode)
					{
					case RevealModes.Character:
						IntervalBetweenReveals = value / (float)RichTextLength(TargetTMPText.text);
						break;
					case RevealModes.Lines:
						IntervalBetweenReveals = value / (float)TargetTMPText.textInfo.lineCount;
						break;
					case RevealModes.Words:
						IntervalBetweenReveals = value / (float)TargetTMPText.textInfo.wordCount;
						break;
					}
					if (ReplaceText)
					{
						TargetTMPText.text = _originalText;
					}
				}
			}
		}

		protected override void AutomateTargetAcquisition()
		{
			TargetTMPText = FindAutomatedTarget<TMP_Text>();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetTMPText == null))
			{
				_initialText = TargetTMPText.text;
				_textInfo = TargetTMPText.textInfo;
				if (ReplaceText)
				{
					TargetTMPText.text = NewText;
					TargetTMPText.ForceMeshUpdate();
				}
				_richTextLength = RichTextLength(TargetTMPText.text);
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
				}
				switch (RevealMode)
				{
				case RevealModes.Character:
					_delay = ((DurationMode == DurationModes.Interval) ? IntervalBetweenReveals : (RevealDuration / (float)_richTextLength));
					TargetTMPText.maxVisibleCharacters = 0;
					_coroutine = Owner.StartCoroutine(RevealCharacters());
					break;
				case RevealModes.Lines:
					_delay = ((DurationMode == DurationModes.Interval) ? IntervalBetweenReveals : (RevealDuration / (float)TargetTMPText.textInfo.lineCount));
					TargetTMPText.maxVisibleLines = 0;
					_coroutine = Owner.StartCoroutine(RevealLines());
					break;
				case RevealModes.Words:
					_delay = ((DurationMode == DurationModes.Interval) ? IntervalBetweenReveals : (RevealDuration / (float)TargetTMPText.textInfo.wordCount));
					TargetTMPText.maxVisibleWords = 0;
					_coroutine = Owner.StartCoroutine(RevealWords());
					break;
				}
			}
		}

		protected virtual IEnumerator RevealCharacters()
		{
			float startTime = FeedbackTime;
			_totalCharacters = _richTextLength;
			int visibleCharacters = 0;
			float lastCharAt = 0f;
			IsPlaying = true;
			while (visibleCharacters <= _totalCharacters && !Owner.SkippingToTheEnd)
			{
				float time = FeedbackTime;
				if (time - lastCharAt < IntervalBetweenReveals)
				{
					yield return null;
				}
				TargetTMPText.maxVisibleCharacters = visibleCharacters;
				InvokeRevealEvents();
				visibleCharacters++;
				lastCharAt = time;
				float delay;
				if (DurationMode == DurationModes.Interval)
				{
					_delay = Mathf.Max(IntervalBetweenReveals, FeedbackDeltaTime);
					delay = _delay - FeedbackDeltaTime;
				}
				else
				{
					int num = _totalCharacters - visibleCharacters;
					float num2 = time - startTime;
					if (num != 0)
					{
						_delay = (RevealDuration - num2) / (float)num;
					}
					delay = _delay - FeedbackDeltaTime;
				}
				yield return WaitFor(delay);
			}
			TargetTMPText.maxVisibleCharacters = _richTextLength;
			IsPlaying = false;
		}

		protected virtual IEnumerator RevealLines()
		{
			_totalLines = TargetTMPText.textInfo.lineCount;
			int visibleLines = 0;
			IsPlaying = true;
			while (visibleLines <= _totalLines && !Owner.SkippingToTheEnd)
			{
				TargetTMPText.maxVisibleLines = visibleLines;
				InvokeRevealEvents();
				visibleLines++;
				yield return WaitFor(_delay);
			}
			TargetTMPText.maxVisibleLines = _totalLines;
			IsPlaying = false;
		}

		protected virtual IEnumerator RevealWords()
		{
			_totalWords = TargetTMPText.textInfo.wordCount;
			int visibleWords = 0;
			IsPlaying = true;
			while (visibleWords <= _totalWords && !Owner.SkippingToTheEnd)
			{
				TargetTMPText.maxVisibleWords = visibleWords;
				InvokeRevealEvents();
				visibleWords++;
				yield return WaitFor(_delay);
			}
			TargetTMPText.maxVisibleWords = _totalWords;
			IsPlaying = false;
		}

		protected virtual void InvokeRevealEvents()
		{
			if ((RevealMode != RevealModes.Character || TargetTMPText.maxVisibleCharacters != 0) && (RevealMode != RevealModes.Character || IsNewVisibleCharacter()) && (RevealMode != RevealModes.Lines || TargetTMPText.maxVisibleLines != 0) && (RevealMode != RevealModes.Words || TargetTMPText.maxVisibleWords != 0))
			{
				OnReveal?.Invoke();
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
					_coroutine = null;
				}
			}
		}

		protected override void CustomSkipToTheEnd(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (IsPlaying)
			{
				switch (RevealMode)
				{
				case RevealModes.Character:
					TargetTMPText.maxVisibleCharacters = _totalCharacters;
					break;
				case RevealModes.Lines:
					TargetTMPText.maxVisibleLines = _totalLines;
					break;
				case RevealModes.Words:
					TargetTMPText.maxVisibleWords = _totalWords;
					break;
				}
			}
		}

		protected int RichTextLength(string richText)
		{
			int num = 0;
			bool flag = false;
			richText = richText.Replace("<br>", "-");
			string text = richText;
			for (int i = 0; i < text.Length; i++)
			{
				switch (text[i])
				{
				case '<':
					flag = true;
					continue;
				case '>':
					flag = false;
					continue;
				}
				if (!flag)
				{
					num++;
				}
			}
			return num;
		}

		protected virtual bool IsNewVisibleCharacter()
		{
			int num = -1;
			_textInfo = TargetTMPText.GetTextInfo(TargetTMPText.text);
			for (int i = 0; i < _textInfo.characterCount; i++)
			{
				if (_textInfo.characterInfo[i].isVisible)
				{
					num = i;
				}
			}
			if (num < 0 || num > TargetTMPText.text.Length || num == _indexLastTime)
			{
				return false;
			}
			_indexLastTime = num;
			return char.IsLetterOrDigit(_textInfo.characterInfo[num].character);
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				TargetTMPText.text = _initialText;
			}
		}
	}
}
