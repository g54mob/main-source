using Unity.Profiling;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class TP_ADV_BOSS_Succubus : EnemyControllerBoss
	{
		[Header("HP Thresholds")]
		[SerializeField]
		private float formShiftThresholdPercentage;

		[Space]
		private bool _showingBaseForm;

		private float _formShiftThresholdHp;

		private static readonly ProfilerMarker MarkerSetEnemySpriteAndAnimations;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void SetAsSuccubusSpriteAndAnimations()
		{
		}

		protected override void Die()
		{
		}

		private void SetAsPlayerSpriteAndAnimations()
		{
		}
	}
}
