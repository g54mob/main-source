using System.Collections.Generic;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Olrox_Character : TP_Character
	{
		private MorphVFX _morphVFX;

		private bool _isMorphed;

		private bool _hasSecondAnim;

		private float _mightBonus;

		private float _cooldownBonus;

		private float _morphDuration;

		private int _morphedTimes;

		private int _finalMorphedTimes;

		private int _finalThreshold;

		private int _enemiesTs;

		private bool hasBonusesApplied;

		private int[] _thresholds;

		private bool canMorph;

		private NdujaWeapon addedHiddenWeapon;

		private List<Vector2> _cachedHeadOffsets;

		public override bool DrainWeaponsImmunity => false;

		private void CalculateTreshold()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public void PermanentMorph()
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
