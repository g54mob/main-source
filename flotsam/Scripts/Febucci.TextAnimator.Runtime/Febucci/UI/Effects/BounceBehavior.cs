using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Bounce", menuName = "Text Animator/Animations/Behaviors/Bounce")]
	[EffectInfo("bounce", EffectCategory.Behaviors)]
	[DefaultValue("baseAmplitude", 13.19f)]
	[DefaultValue("baseFrequency", 1f)]
	[DefaultValue("baseWaveSize", 0.2f)]
	public sealed class BounceBehavior : BehaviorScriptableSine
	{
		private float BounceTween(float t)
		{
			if (t <= 0.2f)
			{
				return Tween.EaseInOut(t / 0.2f);
			}
			t -= 0.2f;
			if (t <= 0.6f)
			{
				return 1f - Tween.BounceOut(t / 0.6f);
			}
			return 0f;
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			character.current.positions.MoveChar(Vector3.up * character.uniformIntensity * BounceTween(Mathf.Repeat(animator.time.timeSinceStart * frequency - waveSize * (float)character.index, 1f)) * amplitude);
		}
	}
}
