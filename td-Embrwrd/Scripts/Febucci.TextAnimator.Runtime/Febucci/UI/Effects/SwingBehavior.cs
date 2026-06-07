using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[DefaultValue("baseWaveSize", 0.171f)]
	[DefaultValue("baseAmplitude", 22.74f)]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Swing", fileName = "Swing Behavior")]
	[EffectInfo("swing", EffectCategory.Behaviors)]
	[Preserve]
	[DefaultValue("baseFrequency", 3.65f)]
	public sealed class SwingBehavior : BehaviorScriptableSine
	{
		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
