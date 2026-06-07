using Febucci.UI.Core;

namespace Febucci.UI.Effects
{
	public abstract class BehaviorScriptableBase : AnimationScriptableBase
	{
		public override float GetMaxDuration()
		{
			return -1f;
		}

		public override bool CanApplyEffectTo(CharacterData character, TAnimCore animator)
		{
			return true;
		}
	}
}
