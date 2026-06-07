using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[CreateAssetMenu(fileName = "Composite With Emission", menuName = "Text Animator/Animations/Special/Composite With Emission")]
	[Preserve]
	[EffectInfo(null, EffectCategory.All)]
	public sealed class CompositeWithEmission : AnimationScriptableBase
	{
		public TimeMode timeMode;

		[EmissionCurveProperty]
		public EmissionCurve emissionCurve;

		public AnimationScriptableBase[] animations;

		private MeshData prev;

		protected override void OnInitialize()
		{
		}

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override void SetModifier(ModifierInfo modifier)
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}

		public override bool CanApplyEffectTo(CharacterData character, TAnimCore animator)
		{
			return false;
		}

		public override float GetMaxDuration()
		{
			return 0f;
		}

		private void ValidateArray()
		{
		}

		private void OnValidate()
		{
		}
	}
}
