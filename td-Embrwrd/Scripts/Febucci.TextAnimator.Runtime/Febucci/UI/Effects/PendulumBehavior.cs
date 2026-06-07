using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Pendulum Behavior", menuName = "Text Animator/Animations/Behaviors/Pendulum")]
	[DefaultValue("baseAmplitude", 24.7f)]
	[DefaultValue("baseFrequency", 3.1f)]
	[DefaultValue("baseWaveSize", 0.2f)]
	[EffectInfo("pend", EffectCategory.Behaviors)]
	public sealed class PendulumBehavior : BehaviorScriptableSine
	{
		public bool anchorBottom;

		private int targetVertex1;

		private int targetVertex2;

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
