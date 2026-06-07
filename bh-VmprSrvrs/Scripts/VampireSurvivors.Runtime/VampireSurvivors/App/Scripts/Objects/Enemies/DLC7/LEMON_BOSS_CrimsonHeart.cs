using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.App.Scripts.Objects.Enemies.DLC7
{
	public class LEMON_BOSS_CrimsonHeart : EnemyControllerBoss
	{
		private const string VfxTextureName = "vfx";

		private List<VampireSurvivors.Objects.Characters.CharacterController> players;

		private List<Weapon> disabledWeapons;

		private bool abilityWasDisabled;

		private SpriteRenderer _disableRingSprite;

		private MultiTargetTween _disableRingTween;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void InitDisableVFX()
		{
		}

		private void PlayDisableVFX()
		{
		}

		public override void Despawn()
		{
		}
	}
}
