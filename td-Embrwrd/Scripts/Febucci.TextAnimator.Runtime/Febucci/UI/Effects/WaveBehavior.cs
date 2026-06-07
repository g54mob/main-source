using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[DefaultValue("baseFrequency", 4f)]
	[DefaultValue("baseWaveSize", 0.4f)]
	[EffectInfo("wave", EffectCategory.Behaviors)]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Wave", fileName = "Wave Behavior")]
	[Preserve]
	[DefaultValue("baseAmplitude", 7.27f)]
	public sealed class WaveBehavior : BehaviorScriptableSine
	{
		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
