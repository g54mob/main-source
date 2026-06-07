using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Characters
{
	public class EnemyControllerBoss_TerrainBreaker : EnemyControllerBoss
	{
		private static readonly List<string> TILE_LAYERS;

		private List<int2> _tilesToEat;

		private List<int2> _currentTilesBeingEaten;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private GravityWell _well;

		public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected virtual void UpdateTileDestructionList()
		{
		}

		protected void CheckTiles()
		{
		}

		protected void StartEatingTile(List<int2> posList)
		{
		}

		private void EatTile(List<int2> posList)
		{
		}

		private void BlackExplosionAt(List<int2> posList)
		{
		}

		private void CreateBlackEmitter()
		{
		}
	}
}
