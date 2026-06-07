using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerMenya : CharacterController
	{
		private bool _hasSecondAnim;

		private float _mightBonus;

		private float _moveBonus;

		private float _cooldownBonus;

		private float _curseBonus;

		private float _morphDuration;

		private int _morphedTimes;

		private int _finalMorphedTimes;

		private SpriteRenderer _sparkSprite;

		private SpriteRenderer _ringSprite;

		private MultiTargetTween _ringTween;

		private MultiTargetTween _sparkTween;

		private SpriteRenderer _burstSprite;

		private SpriteRenderer _darkSprite;

		private MultiTargetTween _darkTween;

		private SpriteAnimation _burstAnim;

		private int[] _thresholds;

		private int _finalThreshold;

		private bool _isMorphed;

		private bool _hasBonusApplied;

		private int _enemiesTs;

		private float _originalMoveSpeed;

		public override bool NeedsCart => false;

		private void CalculateTreshold()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		protected override void OnStop()
		{
		}

		[Command]
		public void PerformOnlineMorph(long startingSimFrame)
		{
		}

		private void Morph()
		{
		}

		private void Unmorph()
		{
		}

		private void PlaySparkle()
		{
		}
	}
}
