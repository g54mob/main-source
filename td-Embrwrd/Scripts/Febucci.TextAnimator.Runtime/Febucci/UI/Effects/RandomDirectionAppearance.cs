using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[EffectInfo("rdir", EffectCategory.Appearances)]
	[CreateAssetMenu(fileName = "RandomDir Appearance", menuName = "Text Animator/Animations/Appearances/Random Direction")]
	public sealed class RandomDirectionAppearance : AppearanceScriptableBase
	{
		public float baseAmount;

		private float amount;

		private Vector3[] directions;

		public override void ResetContext(TAnimCore animator)
		{
		}

		protected override void OnInitialize()
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}

		public override void SetModifier(ModifierInfo modifier)
		{
		}
	}
}
