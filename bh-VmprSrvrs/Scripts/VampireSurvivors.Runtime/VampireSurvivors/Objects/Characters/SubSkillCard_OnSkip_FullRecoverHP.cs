using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_OnSkip_FullRecoverHP : CharacterSkillCard_Base
	{
		private PhaserSprite _highlight;

		private PhaserSprite _rainbow;

		private MultiTargetTween _highlightTween;

		private MultiTargetTween _rainbowTween;

		private MultiTargetTween _highlightTween2;

		private MultiTargetTween _rainbowTween2;

		public SubSkillCard_OnSkip_FullRecoverHP(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerLevelUpSkipped()
		{
		}

		private void CriticalAnim()
		{
		}

		public void ShowHighlightAt(float x, float y)
		{
		}
	}
}
