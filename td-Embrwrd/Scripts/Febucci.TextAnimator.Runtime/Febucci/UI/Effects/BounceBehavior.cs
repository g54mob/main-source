using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[DefaultValue("baseWaveSize", 0.2f)]
	[DefaultValue("baseAmplitude", 13.19f)]
	[EffectInfo("bounce", EffectCategory.Behaviors)]
	[CreateAssetMenu(fileName = "Bounce", menuName = "Text Animator/Animations/Behaviors/Bounce")]
	[DefaultValue("baseFrequency", 1f)]
	[Preserve]
	public sealed class BounceBehavior : BehaviorScriptableSine
	{
		private float BounceTween(float t)
		{
			return 0f;
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
