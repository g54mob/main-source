using Febucci.TextAnimatorForUnity.Actions;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	internal static class TypewriterExtensions
	{
		public static TypewriterComponent InstantiateTypewriter(this ITextAnimatorProvider animatorProvider, ActionDatabase database, TypingsTimingsScriptableBase typewriterSettings)
		{
			TypewriterComponent typewriterComponent = new GameObject("Typewriter").AddComponent<TypewriterComponent>();
			if (typewriterComponent == null)
			{
				Debug.LogError("Error attaching typewriter");
				return null;
			}
			typewriterComponent.AssignAnimator(animatorProvider, database, typewriterSettings);
			return typewriterComponent;
		}
	}
}
