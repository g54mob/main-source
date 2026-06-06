using Febucci.Parsing.Regions;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorForUnity
{
	public interface ITextAnimatorProvider
	{
		internal TextAnimator TextAnimator { get; }

		int CharactersCount { get; }

		CharacterData[] Characters { get; }

		int WordsCount { get; }

		WordInfo[] Words { get; }

		int FirstVisibleCharacter { get; set; }

		int MaxVisibleCharacters { get; set; }

		TextRegion<IEffectPlayer>[] Behaviors { get; }

		TextRegion<IEffectPlayer>[] Appearances { get; }

		TextRegion<IEffectPlayer>[] Disappearances { get; }

		void TryInitializingOnce();

		void SetVisibilityChar(int index, bool isVisible, bool canPlayEffects);

		void SetVisibilityWord(int index, bool isVisible, bool canPlayEffects);

		void SetVisibilityEntireText(bool isVisible, bool canPlayEffects = true);

		void SetText(string text, bool hideText = false);

		void SwapText(string text);

		void AppendText(string appendedText, bool hideText = false);
	}
}
