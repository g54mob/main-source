using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[EffectInfo("dangle", EffectCategory.Behaviors)]
	[DefaultValue("baseAmplitude", 7.87f)]
	[DefaultValue("baseWaveSize", 0.306f)]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Dangle", fileName = "Dangle Behavior")]
	[DefaultValue("baseFrequency", 3.37f)]
	[Preserve]
	public sealed class DangleBehavior : BehaviorScriptableSine
	{
		public bool anchorBottom;

		private float sin;

		private int targetIndex1;

		private int targetIndex2;

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
