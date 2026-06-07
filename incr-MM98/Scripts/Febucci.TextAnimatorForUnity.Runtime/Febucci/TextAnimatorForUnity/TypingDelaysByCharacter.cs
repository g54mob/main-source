using System;
using Febucci.Attributes;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Text;
using UnityEngine;
using UnityEngine.Serialization;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Typewriters/By Character", fileName = "Typewriter By Character")]
	public class TypingDelaysByCharacter : TypingsTimingsScriptableBase
	{
		[SerializeField]
		[CharsDisplayTime]
		[Tooltip("Wait time for normal letters")]
		public float waitForNormalChars = 0.03f;

		[SerializeField]
		[CharsDisplayTime]
		[Tooltip("Wait time for ! ? .")]
		public float waitLong = 0.6f;

		[SerializeField]
		[CharsDisplayTime]
		[Tooltip("Wait time for ; : ) - ,")]
		public float waitMiddle = 0.2f;

		[FormerlySerializedAs("avoidMultiplePunctuactionWait")]
		[SerializeField]
		[Tooltip("-True: only the last punctuation on a sequence waits for its category time.\n-False: each punctuation will wait, regardless if it's in a sequence or not")]
		public bool avoidMultiplePunctuationWait;

		[SerializeField]
		[Tooltip("True if you want the typewriter to wait for new line characters")]
		public bool waitForNewLines = true;

		[SerializeField]
		[Tooltip("True if you want the typewriter to wait for all characters, false if you want to skip waiting for the last one")]
		public bool waitForLastCharacter = true;

		[SerializeField]
		[Tooltip("True if you want to use the same typewriter's wait times for the disappearance progression, false if you want to use a different wait time")]
		public bool useTypewriterWaitForDisappearances = true;

		[SerializeField]
		[CharsDisplayTime]
		[Tooltip("Wait time for characters in the disappearance progression")]
		private float disappearanceWaitTime = 0.015f;

		[SerializeField]
		[MinValue(0.1f)]
		[Tooltip("How much faster/slower is the disappearance progression compared to the typewriter's typing speed")]
		public float disappearanceSpeedMultiplier = 1f;

		[Obsolete("Typo, please use 'avoidMultiplePunctuationWait' instead.")]
		public bool avoidMultiplePunctuactionWait => avoidMultiplePunctuationWait;

		public override float GetWaitAppearanceTimeOf(CharacterData characterData, TextAnimator animator)
		{
			int index = characterData.index;
			char character = characterData.info.character;
			if (!waitForLastCharacter && animator.AllLettersShown)
			{
				return 0f;
			}
			if (avoidMultiplePunctuationWait && char.IsPunctuation(character) && index < animator.CharactersCount - 1 && char.IsPunctuation(animator.Characters[index + 1].info.character))
			{
				return waitForNormalChars;
			}
			if (!waitForNewLines && !characterData.info.isRendered && IsUnicodeNewLine(Convert.ToUInt64(character)))
			{
				return 0f;
			}
			switch (character)
			{
			case ')':
			case ',':
			case '-':
			case ':':
			case ';':
				return waitMiddle;
			case '!':
			case '.':
			case '?':
				return waitLong;
			default:
				return waitForNormalChars;
			}
			static bool IsUnicodeNewLine(ulong unicode)
			{
				if (unicode != 10)
				{
					return unicode == 13;
				}
				return true;
			}
		}

		public override float GetWaitDisappearanceTimeOf(CharacterData characterData, TextAnimator animator)
		{
			if (!useTypewriterWaitForDisappearances)
			{
				return disappearanceWaitTime;
			}
			return GetWaitAppearanceTimeOf(characterData, animator) * (1f / disappearanceSpeedMultiplier);
		}
	}
}
