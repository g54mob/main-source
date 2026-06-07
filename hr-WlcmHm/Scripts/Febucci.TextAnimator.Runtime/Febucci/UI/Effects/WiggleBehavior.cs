using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Wiggle", fileName = "Wiggle Behavior")]
	[EffectInfo("wiggle", EffectCategory.Behaviors)]
	[DefaultValue("baseAmplitude", 4.74f)]
	[DefaultValue("baseFrequency", 7.82f)]
	[DefaultValue("baseWaveSize", 0.551f)]
	public sealed class WiggleBehavior : BehaviorScriptableSine
	{
		private const int maxDirections = 23;

		private Vector3[] directions;

		private int indexCache;

		protected override void OnInitialize()
		{
			base.OnInitialize();
			directions = new Vector3[23];
			for (int i = 0; i < 23; i++)
			{
				directions[i] = TextUtilities.fakeRandoms[Random.Range(0, 24)] * Mathf.Sign(Mathf.Sin(i));
			}
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			indexCache = character.index % 23;
			character.current.positions.MoveChar(directions[indexCache] * Mathf.Sin(animator.time.timeSinceStart * frequency + (float)character.index * waveSize) * amplitude * character.uniformIntensity);
		}
	}
}
