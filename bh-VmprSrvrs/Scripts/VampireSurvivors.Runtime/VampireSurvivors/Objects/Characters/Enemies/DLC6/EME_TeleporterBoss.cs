using UnityEngine;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Characters.Enemies.DLC6
{
	public class EME_TeleporterBoss : EnemyControllerBoss
	{
		[Header("Teleporter Boss")]
		[SerializeField]
		private BackgroundEmerald.EmeraldsBiomes _bossBiome;

		[SerializeField]
		private string[] _teleportKeysToActivate;

		protected override void Die()
		{
		}
	}
}
