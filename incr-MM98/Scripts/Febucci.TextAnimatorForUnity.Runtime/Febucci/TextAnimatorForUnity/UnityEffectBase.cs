using System;
using Febucci.Parsing;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorForUnity
{
	public class UnityEffectBase : IEffectState, IParameterUpdater
	{
		public void UpdateParameters(RegionParameters parameters)
		{
			throw new NotImplementedException();
		}

		public void Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			throw new NotImplementedException();
		}

		void IEffectState.Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			Apply(ref character, in context);
		}
	}
}
