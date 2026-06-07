using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Wave", fileName = "Wave Behavior")]
	[EffectInfo("wave", EffectCategory.Behaviors)]
	[DefaultValue("baseAmplitude", 7.27f)]
	[DefaultValue("baseFrequency", 4f)]
	[DefaultValue("baseWaveSize", 0.4f)]
	public sealed class WaveBehavior : BehaviorScriptableSine
	{
		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			character.current.positions.MoveChar(Vector3.up * Mathf.Sin(animator.time.timeSinceStart * frequency + (float)character.index * waveSize) * amplitude * character.uniformIntensity);
		}
	}
}
