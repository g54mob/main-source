using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_HPCritical_RecoverHP : CharacterSkillCard_Base
	{
		private PhaserSprite _highlight;

		private PhaserSprite _rainbow;

		private MultiTargetTween _highlightTween;

		private MultiTargetTween _rainbowTween;

		private MultiTargetTween _highlightTween2;

		private MultiTargetTween _rainbowTween2;

		public SubSkillCard_HPCritical_RecoverHP(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void InitialActivate()
		{
		}

		public override void OnOwnerCriticalHPTreshold(float rawDamage)
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
