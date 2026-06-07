using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Game.Spawning.New
{
	public abstract class BaseSummoner
	{
		protected float credits;

		private List<EnemyCard> cards;

		private float giveCreditsTimer;

		private float spendCreditsTimer;

		public const int maxEnemiesPerSecond = 500;

		public const int maxEnemiesPerCycle = 200;

		protected int enemiesThisSecond;

		private int nextSecond;

		protected int id;

		public bool slowmode;

		private float slowmodeMultiplier;

		private float slowmodeOverAtTime;

		private bool isWaveMode;

		private float waveModeOverAtTime;

		private List<EnemyCard> waveModeCards;

		protected List<EEnemy> currentEnemies;

		private List<Enemy> spawnedEnemies;

		public BaseSummoner(int id, List<EEnemy> defaultEnemies)
		{
		}

		public void Cleanup()
		{
		}

		public void Tick()
		{
		}

		protected virtual void TickExtra()
		{
		}

		protected void GenerateCardsForSummoner(List<EEnemy> enemies)
		{
		}

		protected virtual List<EnemyCard> GenerateCards(List<EEnemy> enemies)
		{
			return null;
		}

		private void RefreshCardWeights()
		{
		}

		public void AddCredits()
		{
		}

		public float GetCreditsPerSecond()
		{
			return 0f;
		}

		public virtual List<Enemy> SpendCredits(bool useWeights = true)
		{
			return null;
		}

		protected EnemyCard GetRandomCard(bool useWeights)
		{
			return null;
		}

		public void SetSlowmode(float multiplier, float duration)
		{
		}

		public void SetWaveMode(List<EEnemy> waveEnemies, float duration)
		{
		}

		protected float GetMultiplier()
		{
			return 0f;
		}

		protected virtual bool UseMultiplier()
		{
			return false;
		}

		private bool CanEarnCredits()
		{
			return false;
		}

		private void OnStatUpdated(EStat stat)
		{
		}

		private void OnPlayerInventoryInitialized(PlayerInventory playerInventory)
		{
		}

		protected abstract void Init();

		protected abstract List<EEnemy> GetEnemies();

		public abstract float GetSummonInterval();

		public abstract float GetBaseCreditsPerSecond();

		public abstract float GetInitialCredits();

		public abstract int GetNumTargetEnemies();

		protected abstract bool UseDirectionBias();

		protected abstract bool ForceSpawn();
	}
}
