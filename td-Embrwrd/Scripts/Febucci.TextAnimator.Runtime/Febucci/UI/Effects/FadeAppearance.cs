using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[EffectInfo("fade", EffectCategory.Appearances)]
	[CreateAssetMenu(fileName = "Fade Appearance", menuName = "Text Animator/Animations/Appearances/Fade")]
	public sealed class FadeAppearance : AppearanceScriptableBase
	{
		private Color32 temp;

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
