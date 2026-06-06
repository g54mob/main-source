using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore
{
	public interface IEffectState : IParameterUpdater
	{
		void Apply(ref CharacterData character, in ManagedEffectContext context);
	}
}
