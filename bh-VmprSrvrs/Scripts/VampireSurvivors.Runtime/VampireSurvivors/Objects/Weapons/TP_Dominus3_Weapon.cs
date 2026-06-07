using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Dominus3_Weapon : Weapon
	{
		[SerializeField]
		private SpriteRenderer _Renderer;

		[SerializeField]
		private SpriteRenderer _ZoneRenderer;

		private Tween _angleTween;

		private Sequence _fadeTween;

		private Sequence _fadeTween2;

		private List<bool> _cachedInRange;

		private const float _baseDamageValue = 3f;

		private const float _baseStatBonusValue = 0.08f;

		private int _statBonusMultiplier;

		protected override void Awake()
		{
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void Cleanup()
		{
		}

		public override void InternalUpdate()
		{
		}

		private bool IsCharacterInRange(VampireSurvivors.Objects.Characters.CharacterController character)
		{
			return false;
		}

		private void UpdateStatBonuses()
		{
		}

		private void ApplyStatBonuses(VampireSurvivors.Objects.Characters.CharacterController character, bool addStats = true)
		{
		}

		private void ClearStatBonuses()
		{
		}

		private float GetRadius()
		{
			return 0f;
		}

		private void UpdateRendererScaleToArea(SpriteRenderer renderer, float multiplier = 1f)
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
