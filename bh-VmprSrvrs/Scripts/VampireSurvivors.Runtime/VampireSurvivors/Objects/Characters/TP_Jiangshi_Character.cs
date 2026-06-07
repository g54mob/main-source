using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Jiangshi_Character : CharacterController
	{
		private SpriteRenderer _sparkSprite;

		private SpriteRenderer _ringSprite;

		private MultiTargetTween _ringTween;

		private MultiTargetTween _sparkTween;

		private int _firingIndex;

		private int jumpsCounter;

		private int jumpsTrigger;

		public override bool DrainWeaponsImmunity => false;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void AfterFullInitialization()
		{
		}

		private void PlaySparkle()
		{
		}

		private void FireWeapons()
		{
		}

		public void UpdateWalkRate()
		{
		}

		public override void LevelUp()
		{
		}
	}
}
