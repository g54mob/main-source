using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Wiggle", fileName = "Wiggle Behavior")]
	[DefaultValue("baseAmplitude", 4.74f)]
	[DefaultValue("baseFrequency", 7.82f)]
	[DefaultValue("baseWaveSize", 0.551f)]
	[EffectInfo("wiggle", EffectCategory.Behaviors)]
	public sealed class WiggleBehavior : BehaviorScriptableSine
	{
		private const int maxDirections = 23;

		private Vector3[] directions;

		private int indexCache;

		protected override void OnInitialize()
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
