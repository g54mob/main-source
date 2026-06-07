using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class EME_CharacterController_CatFollower : CharacterController
	{
		private List<WeaponType> hiddenWeaponTypes;

		private WeaponType _chosenWeapon;

		protected const string EmeraldsTextureName = "character_eme_witch";

		[SerializeField]
		private bool _randomiseColour;

		private float RingLevelUpEveyXLevels;

		private List<Sprite> idleAnim;

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}

		protected override void SetCharacterSprite()
		{
		}

		protected override void SetupAnimation()
		{
		}

		protected override void AddAttackAnimations()
		{
		}

		private List<Sprite> GetCatIdleAnimation()
		{
			return null;
		}

		protected virtual ItemType GetCatType()
		{
			return default(ItemType);
		}
	}
}
