using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Composite Animation", menuName = "Text Animator/Animations/Special/Composite")]
	[EffectInfo(null, EffectCategory.All)]
	public sealed class CompositeAnimation : AnimationScriptableBase
	{
		public AnimationScriptableBase[] animations;

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
