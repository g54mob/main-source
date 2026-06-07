using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Rainbow", fileName = "Rainbow Behavior")]
	[EffectInfo("rainb", EffectCategory.Behaviors)]
	public sealed class RainbowBehavior : BehaviorScriptableBase
	{
		public float baseFrequency;

		public float baseWaveSize;

		private float frequency;

		private float waveSize;

		private Color32 temp;

		public override void SetModifier(ModifierInfo modifier)
		{
		}

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
