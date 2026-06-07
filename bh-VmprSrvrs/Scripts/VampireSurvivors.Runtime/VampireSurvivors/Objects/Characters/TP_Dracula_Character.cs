using System.Collections.Generic;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Dracula_Character : TP_Character
	{
		private float _armorBonus;

		private float _cooldownBonus;

		private float _moveSpeedBonus;

		private float _mightBonus;

		private MorphVFX _morphVFX;

		private bool _isMorphed;

		private List<PhaserSprite> _megaloSprites;

		public override bool DrainWeaponsImmunity => false;

		public override float PPower()
		{
			return 0f;
		}

		public override void AfterFullInitialization()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void LevelUp()
		{
		}

		public void Morph(bool addBonusStats = true)
		{
		}

		private void CleanupMegaloSprites()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void MakeMorphVFX()
		{
		}

		private void CreateMegaloDraculaSprites()
		{
		}

		private void UpdateMegaloDraculaSprites()
		{
		}

		public override void SetExtraVisualsVisible(bool show)
		{
		}
	}
}
