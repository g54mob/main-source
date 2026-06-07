using System;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Settings;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore
{
	public interface IEffectPlayer : ITagProvider, IDisposable
	{
		void InitializeOnce(bool isUpPositive, GlobalSettingsBase globalSettings);

		float GetTotalDuration();

		void Animate(ref CharacterData characterData, in AnimationContext animationContext);

		void Refresh();
	}
}
