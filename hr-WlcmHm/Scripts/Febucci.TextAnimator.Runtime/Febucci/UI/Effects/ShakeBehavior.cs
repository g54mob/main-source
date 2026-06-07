using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Shake", fileName = "Shake Behavior")]
	[EffectInfo("shake", EffectCategory.Behaviors)]
	[DefaultValue("baseAmplitude", 1.13f)]
	[DefaultValue("baseDelay", 0.1f)]
	[DefaultValue("baseWaveSize", 0.45f)]
	public sealed class ShakeBehavior : BehaviorScriptableBase
	{
		public float baseAmplitude = 0.085f;

		public float baseDelay = 0.04f;

		public float baseWaveSize = 0.2f;

		private float amplitude;

		private float delay;

		private float waveSize;

		private int randIndex;

		private float timePassed;

		private void ClampValues()
		{
			delay = Mathf.Clamp(delay, 0.002f, 500f);
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			randIndex = Random.Range(0, 25);
		}

		public override void ResetContext(TAnimCore animator)
		{
			amplitude = baseAmplitude;
			delay = baseDelay;
			waveSize = baseWaveSize;
			ClampValues();
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			switch (modifier.name)
			{
			case "a":
				amplitude = baseAmplitude * modifier.value;
				break;
			case "d":
				delay = baseDelay * modifier.value;
				break;
			case "w":
				waveSize = baseWaveSize * modifier.value;
				break;
			}
			ClampValues();
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			timePassed = animator.time.timeSinceStart;
			timePassed += (float)character.index * waveSize;
			randIndex = Mathf.RoundToInt(timePassed / delay) % 25;
			if (randIndex < 0)
			{
				randIndex *= -1;
			}
			character.current.positions.MoveChar(TextUtilities.fakeRandoms[randIndex] * amplitude * character.uniformIntensity);
		}

		private void OnValidate()
		{
			ClampValues();
		}
	}
}
