using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Slide Behavior", menuName = "Text Animator/Animations/Behaviors/Slide")]
	[EffectInfo("slide", EffectCategory.Behaviors)]
	[DefaultValue("baseAmplitude", 5f)]
	[DefaultValue("baseFrequency", 3f)]
	[DefaultValue("baseWaveSize", 0f)]
	public sealed class SlideBehavior : BehaviorScriptableSine
	{
		private float sin;

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			sin = Mathf.Sin(frequency * animator.time.timeSinceStart + (float)character.index * waveSize) * amplitude * character.uniformIntensity;
			character.current.positions[0] += Vector3.right * sin;
			character.current.positions[3] += Vector3.right * sin;
			character.current.positions[1] += Vector3.right * (0f - sin);
			character.current.positions[2] += Vector3.right * (0f - sin);
		}
	}
}
