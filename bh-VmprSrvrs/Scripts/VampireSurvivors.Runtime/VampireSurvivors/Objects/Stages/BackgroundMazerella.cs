using SuperTiled2Unity;
using UnityEngine;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundMazerella : BackgroundManager
	{
		private const float DancerSpawnDistanceFromPlayerSpawn = 1f;

		private const string LeftRelicName = "StartLeft";

		private const string RightRelicName = "StartRight";

		private const string PlayerSpawnName = "PlayerStart";

		private const string LeftDeadEndName = "DancerDeadEndLeft";

		private const string RightDeadEndName = "DancerDeadEndRight";

		private Bounds _leftDeadEndBounds;

		private Bounds _rightDeadEndBounds;

		private MazerellaDancerMazeNavigation _mazeNavigation;

		private const int PlayerStartNavigationNodeIndex = 84;

		private VampireSurvivors.Objects.Characters.CharacterController _player;

		private MazerellaTorinoSecretPositions _torinoSecretPositions;

		private EX_Boss_Colossus _colossus;

		private bool _colossusHasLeftMap;

		private bool _torinoUnlocked;

		private bool _isInverse;

		public override void Create()
		{
		}

		public void SetColossus(EX_Boss_Colossus colossus)
		{
		}

		private Bounds GenerateDeadEndBounds(EnemyMazerellaDancer.DancerSide dancerSide, TilingTileset tilingTileset)
		{
			return default(Bounds);
		}

		private void CreateBoss()
		{
		}

		private void SpawnDancers(TilingTileset tilingTileset)
		{
		}

		private void SpawnDancer(SuperObject playerSpawnPoint, EnemyMazerellaDancer.DancerSide dancerSide)
		{
		}

		private void CheckForTorinoUnlock()
		{
		}

		public void UnlockTorino()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
