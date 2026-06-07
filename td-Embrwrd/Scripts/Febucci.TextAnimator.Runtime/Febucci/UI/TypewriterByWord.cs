using Febucci.Attributes;
using Febucci.UI.Core;
using UnityEngine;

namespace Febucci.UI
{
	[HelpURL("https://www.febucci.com/text-animator-unity/docs/typewriters/")]
	public class TypewriterByWord : TypewriterCore
	{
		[CharsDisplayTime]
		[SerializeField]
		private float waitForNormalWord;

		[SerializeField]
		[CharsDisplayTime]
		private float waitForWordWithPuntuaction;

		[SerializeField]
		[CharsDisplayTime]
		private float disappearanceDelay;

		private bool IsCharInsideAnyWord(int charIndex)
		{
			return false;
		}

		protected override float GetWaitAppearanceTimeOf(int charIndex)
		{
			return 0f;
		}

		protected override float GetWaitDisappearanceTimeOf(int charIndex)
		{
			return 0f;
		}
	}
}
