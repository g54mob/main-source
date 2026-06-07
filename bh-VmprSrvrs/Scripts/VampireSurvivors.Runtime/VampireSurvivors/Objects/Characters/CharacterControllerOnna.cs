using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerOnna : CharacterController
	{
		private SpriteRenderer _sparkSprite;

		private SpriteRenderer _ringSprite;

		private MultiTargetTween _ringTween;

		private MultiTargetTween _sparkTween;

		private int _firingIndex;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		private void PlaySparkle()
		{
		}

		private void FireWeapons()
		{
		}

		public override void LevelUp()
		{
		}
	}
}
