using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[DefaultValue("baseWaveSize", 0f)]
	[Preserve]
	[DefaultValue("baseAmplitude", 5f)]
	[EffectInfo("slide", EffectCategory.Behaviors)]
	[CreateAssetMenu(fileName = "Slide Behavior", menuName = "Text Animator/Animations/Behaviors/Slide")]
	[DefaultValue("baseFrequency", 3f)]
	public sealed class SlideBehavior : BehaviorScriptableSine
	{
		private float sin;

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
