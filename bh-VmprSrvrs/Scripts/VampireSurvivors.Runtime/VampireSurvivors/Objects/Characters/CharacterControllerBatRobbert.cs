using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerBatRobbert : CharacterController
	{
		private int MaxHealthMaxBonus;

		private int CurrentMaxHPBonus;

		private PhaserSprite _highlight;

		private PhaserSprite _rainbow;

		private MultiTargetTween _highlightTween;

		private MultiTargetTween _rainbowTween;

		private MultiTargetTween _highlightTween2;

		private MultiTargetTween _rainbowTween2;

		public override void AfterFullInitialization()
		{
		}

		private void CriticalHP()
		{
		}

		private void CriticalAnim()
		{
		}

		public void ShowHighlightAt(float x, float y)
		{
		}

		private void AddMaxHPBonus(int value)
		{
		}
	}
}
