using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Pendulum Behavior", menuName = "Text Animator/Animations/Behaviors/Pendulum")]
	[EffectInfo("pend", EffectCategory.Behaviors)]
	[DefaultValue("baseAmplitude", 24.7f)]
	[DefaultValue("baseFrequency", 3.1f)]
	[DefaultValue("baseWaveSize", 0.2f)]
	public sealed class PendulumBehavior : BehaviorScriptableSine
	{
		public bool anchorBottom;

		private int targetVertex1;

		private int targetVertex2;

		public override void ResetContext(TAnimCore animator)
		{
			base.ResetContext(animator);
			if (anchorBottom)
			{
				targetVertex1 = 0;
				targetVertex2 = 3;
			}
			else
			{
				targetVertex1 = 1;
				targetVertex2 = 2;
			}
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			character.current.positions.RotateChar(Mathf.Sin((0f - animator.time.timeSinceStart) * frequency + waveSize * (float)character.index) * amplitude, (character.current.positions[targetVertex1] + character.current.positions[targetVertex2]) / 2f);
		}
	}
}
