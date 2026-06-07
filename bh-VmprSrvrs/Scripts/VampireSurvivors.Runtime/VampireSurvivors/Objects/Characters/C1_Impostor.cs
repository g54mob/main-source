using System.Collections.Generic;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class C1_Impostor : CharacterController
	{
		private bool _hasSecondAnim;

		private float _mightBonus;

		private float _moveBonus;

		private float _cooldownBonus;

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

		private int[] _thresholds;

		private int _finalThreshold;

		private bool _isMorphed;

		private int _enemiesTs;

		private MorphVFX _morphVFX;

		private List<Weapon> hiddenTongues;

		private bool hasBonusesApplied;

		private float _originalMoveSpeed;

		private void CalculateTreshold()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		[Command]
		public void Morph()
		{
		}

		private void Unmorph()
		{
		}

		public void MakeMorphVFX()
		{
		}
	}
}
