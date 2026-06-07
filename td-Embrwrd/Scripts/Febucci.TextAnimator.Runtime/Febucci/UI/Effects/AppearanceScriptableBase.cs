using System;
using Febucci.UI.Core;

namespace Febucci.UI.Effects
{
	[Serializable]
	public abstract class AppearanceScriptableBase : AnimationScriptableBase
	{
		public float baseDuration;

		protected float duration;

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override float GetMaxDuration()
		{
			return 0f;
		}

		public override void SetModifier(ModifierInfo modifier)
		{
		}

		public override bool CanApplyEffectTo(CharacterData character, TAnimCore animator)
		{
			return false;
		}
	}
}
