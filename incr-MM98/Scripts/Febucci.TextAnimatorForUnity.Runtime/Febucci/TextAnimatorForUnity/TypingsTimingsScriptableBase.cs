using System;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Text;
using Febucci.TextAnimatorCore.Typing;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	public abstract class TypingsTimingsScriptableBase : ScriptableObject, ITypingTimingsProvider
	{
		public abstract float GetWaitAppearanceTimeOf(CharacterData character, TextAnimator animator);

		public virtual float GetWaitDisappearanceTimeOf(CharacterData character, TextAnimator animator)
		{
			return GetWaitAppearanceTimeOf(character, animator);
		}
	}
}
