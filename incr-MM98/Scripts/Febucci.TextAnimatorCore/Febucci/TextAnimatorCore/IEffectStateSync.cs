using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore
{
	public interface IEffectStateSync : IEffect, ITagProvider, IParameterUpdater
	{
		float GetDefaultDuration();

		void Apply(ref CharacterData character, in DirectEffectContext context);
	}
}
