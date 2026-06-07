using System.Collections.Generic;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerLuminaire : CharacterController
	{
		private float _cooldownBonus;

		private float _moveBonus;

		private float _bonusDuration;

		private bool _hasBonus;

		private List<PhaserSprite> _doilies;

		private MultiTargetTween _tween1;

		private float _mightBonus;

		private MorphVFX _morphVFX;

		private float _elapsedGFBonusTime;

		private PhaserSprite _fogRays;

		private float _timesRevived;

		private float _originalMoveSpeed;

		public override bool NeedsCart => false;

		protected override void OnUpdate()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}

		public override void Revive(float percentage = 1f, bool instantRevival = false)
		{
		}

		public void RemoveBonus()
		{
		}

		protected override void OnStop()
		{
		}

		private void RosaryDamage()
		{
		}

		private void PlayRosaryAnim()
		{
		}
	}
}
