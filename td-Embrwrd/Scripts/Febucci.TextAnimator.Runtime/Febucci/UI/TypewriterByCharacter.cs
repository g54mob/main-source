using Febucci.Attributes;
using Febucci.UI.Core;
using UnityEngine;

namespace Febucci.UI
{
	[AddComponentMenu("Febucci/TextAnimator/Typewriter - By Character")]
	[HelpURL("https://www.febucci.com/text-animator-unity/docs/typewriters/")]
	public class TypewriterByCharacter : TypewriterCore
	{
		[SerializeField]
		[CharsDisplayTime]
		[Tooltip("Wait time for normal letters")]
		public float waitForNormalChars;

		[SerializeField]
		[Tooltip("Wait time for ! ? .")]
		[CharsDisplayTime]
		public float waitLong;

		[SerializeField]
		[CharsDisplayTime]
		[Tooltip("Wait time for ; : ) - ,")]
		public float waitMiddle;

		[SerializeField]
		[Tooltip("-True: only the last punctuaction on a sequence waits for its category time.\n-False: each punctuaction will wait, regardless if it's in a sequence or not")]
		public bool avoidMultiplePunctuactionWait;

		[Tooltip("True if you want the typewriter to wait for new line characters")]
		[SerializeField]
		public bool waitForNewLines;

		[Tooltip("True if you want the typewriter to wait for all characters, false if you want to skip waiting for the last one")]
		[SerializeField]
		public bool waitForLastCharacter;

		[Tooltip("True if you want to use the same typewriter's wait times for the disappearance progression, false if you want to use a different wait time")]
		[SerializeField]
		public bool useTypewriterWaitForDisappearances;

		[CharsDisplayTime]
		[Tooltip("Wait time for characters in the disappearance progression")]
		[SerializeField]
		private float disappearanceWaitTime;

		[MinValue(0.1f)]
		[SerializeField]
		[Tooltip("How much faster/slower is the disappearance progression compared to the typewriter's typing speed")]
		public float disappearanceSpeedMultiplier;

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
