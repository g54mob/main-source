using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerSpaceDude : CharacterController
	{
		private float _paradoxHazeDelay;

		private float _paradoxHazeTime;

		private Timer _activationTimer;

		private PhaserSprite _highlight;

		private PhaserSprite _rainbow;

		private MultiTargetTween _highlightTween;

		private MultiTargetTween _rainbowTween;

		private MultiTargetTween _highlightTween2;

		private MultiTargetTween _rainbowTween2;

		public float ParadoxHazeInterval()
		{
			return 0f;
		}

		public override void OnWeaponFired(Weapon weapon)
		{
		}

		protected void ActivateAllWeapons()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void ShowHighlightAt(float x, float y)
		{
		}
	}
}
