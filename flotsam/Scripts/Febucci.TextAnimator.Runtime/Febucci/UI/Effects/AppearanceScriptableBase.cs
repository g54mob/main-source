using System;
using Febucci.UI.Core;

namespace Febucci.UI.Effects
{
	[Serializable]
	public abstract class AppearanceScriptableBase : AnimationScriptableBase
	{
		public float baseDuration = 0.5f;

		protected float duration;

		public override void ResetContext(TAnimCore animator)
		{
			duration = baseDuration;
		}

		public override float GetMaxDuration()
		{
			return duration;
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			if (modifier.name == "d")
			{
				duration = baseDuration * modifier.value;
			}
		}

		public override bool CanApplyEffectTo(CharacterData character, TAnimCore animator)
		{
			return character.passedTime <= duration;
		}
	}
}
