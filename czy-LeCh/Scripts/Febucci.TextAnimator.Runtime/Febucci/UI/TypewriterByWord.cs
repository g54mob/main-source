using Febucci.Attributes;
using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Febucci.UI
{
	[HelpURL("https://www.febucci.com/text-animator-unity/docs/typewriters/")]
	[AddComponentMenu("Febucci/TextAnimator/Typewriter - By Word")]
	public class TypewriterByWord : TypewriterCore
	{
		[SerializeField]
		[CharsDisplayTime]
		public float waitForNormalWord = 0.3f;

		[FormerlySerializedAs("waitForWordWithPuntuaction")]
		[SerializeField]
		[CharsDisplayTime]
		public float waitForWordWithPunctuation = 0.5f;

		[SerializeField]
		[CharsDisplayTime]
		public float disappearanceDelay = 0.5f;

		private bool IsCharInsideAnyWord(int charIndex)
		{
			return base.TextAnimator.Characters[charIndex].wordIndex >= 0;
		}

		protected override float GetWaitAppearanceTimeOf(int charIndex)
		{
			if (!IsCharInsideAnyWord(charIndex) && base.TextAnimator.latestCharacterShown.index > 0)
			{
				int wordIndex = base.TextAnimator.Characters[base.TextAnimator.latestCharacterShown.index - 1].wordIndex;
				if (wordIndex >= 0 && wordIndex < base.TextAnimator.WordsCount)
				{
					WordInfo wordInfo = base.TextAnimator.Words[wordIndex];
					if (!char.IsPunctuation(base.TextAnimator.Characters[wordInfo.lastCharacterIndex].info.character))
					{
						return waitForNormalWord;
					}
					return waitForWordWithPunctuation;
				}
				return waitForNormalWord;
			}
			return 0f;
		}

		protected override float GetWaitDisappearanceTimeOf(int charIndex)
		{
			if (IsCharInsideAnyWord(charIndex))
			{
				return 0f;
			}
			return disappearanceDelay;
		}
	}
}
