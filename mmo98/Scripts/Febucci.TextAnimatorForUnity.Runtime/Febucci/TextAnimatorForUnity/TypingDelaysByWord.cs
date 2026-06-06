using System;
using Febucci.Attributes;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Text;
using UnityEngine;
using UnityEngine.Serialization;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Typewriters/By Word", fileName = "Typewriter By Word")]
	public class TypingDelaysByWord : TypingsTimingsScriptableBase
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

		private bool IsCharInsideAnyWord(CharacterData character)
		{
			return character.wordIndex >= 0;
		}

		public override float GetWaitAppearanceTimeOf(CharacterData chardata, TextAnimator textAnimator)
		{
			if (!IsCharInsideAnyWord(chardata) && textAnimator.LatestCharacterShown.index > 0)
			{
				int wordIndex = textAnimator.Characters[textAnimator.LatestCharacterShown.index - 1].wordIndex;
				if (wordIndex >= 0 && wordIndex < textAnimator.WordsCount)
				{
					WordInfo wordInfo = textAnimator.Words[wordIndex];
					if (!char.IsPunctuation(textAnimator.Characters[wordInfo.lastCharacterIndex].info.character))
					{
						return waitForNormalWord;
					}
					return waitForWordWithPunctuation;
				}
				return waitForNormalWord;
			}
			return 0f;
		}

		public override float GetWaitDisappearanceTimeOf(CharacterData charIndex, TextAnimator animator)
		{
			if (IsCharInsideAnyWord(charIndex))
			{
				return 0f;
			}
			return disappearanceDelay;
		}
	}
}
