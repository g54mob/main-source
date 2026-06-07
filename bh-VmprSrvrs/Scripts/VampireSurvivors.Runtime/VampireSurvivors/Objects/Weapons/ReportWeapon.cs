using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class ReportWeapon : Weapon
	{
		[SerializeField]
		private SpriteRenderer _reportImage;

		[SerializeField]
		private GameObject _deadBodyDisplay;

		[SerializeField]
		private SpriteRenderer _deadCharacterSprite;

		[SerializeField]
		private SpriteRenderer _deadCharacterShadowSprite;

		private List<VampireSurvivors.Objects.Characters.CharacterController> _reportedPlayers;

		private bool _isSendingBodyReport;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void ReportBody(VampireSurvivors.Objects.Characters.CharacterController character = null)
		{
		}

		private void PerformReport(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private void Unfreeze()
		{
		}
	}
}
