using System;
using Febucci.Attributes;
using Febucci.UI.Core;
using UnityEngine;

namespace Febucci.UI
{
	[HelpURL("https://www.febucci.com/text-animator-unity/docs/typewriters/")]
	[AddComponentMenu("Febucci/TextAnimator/Typewriter - By Character")]
	public class TypewriterByCharacter : TypewriterCore
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

		[SerializeField]
		[Tooltip("-True: only the last punctuaction on a sequence waits for its category time.\n-False: each punctuaction will wait, regardless if it's in a sequence or not")]
		public bool avoidMultiplePunctuactionWait;

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

		protected override float GetWaitAppearanceTimeOf(int charIndex)
		{
			char character = base.TextAnimator.Characters[charIndex].info.character;
			if (!waitForLastCharacter && base.TextAnimator.allLettersShown)
			{
				return 0f;
			}
			if (avoidMultiplePunctuactionWait && char.IsPunctuation(character) && charIndex < base.TextAnimator.CharactersCount - 1 && char.IsPunctuation(base.TextAnimator.Characters[charIndex + 1].info.character))
			{
				return waitForNormalChars;
			}
			if (!waitForNewLines && !base.TextAnimator.latestCharacterShown.info.isRendered && IsUnicodeNewLine(Convert.ToUInt64(base.TextAnimator.latestCharacterShown.info.character)))
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

		protected override float GetWaitDisappearanceTimeOf(int charIndex)
		{
			if (!useTypewriterWaitForDisappearances)
			{
				return disappearanceWaitTime;
			}
			return GetWaitAppearanceTimeOf(charIndex) * (1f / disappearanceSpeedMultiplier);
		}
	}
}
