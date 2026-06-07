using JetBrains.Annotations;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors.Objects.Stages
{
	[UsedImplicitly]
	public class Background1 : BackgroundManager
	{
		private bool _hadEnoughChicken;

		private bool _chickenTrailSpawned;

		private int _chickenTimerLoopCount;

		private SpriteRenderer _chickenSprite;

		private ParticleSystem _pfxEmitterPickups;

		private Timer _chickenTimer;

		private EnemyStalkerNoob _boon;

		private bool _awarded;

		public override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Create()
		{
		}

		private bool Siffregatoipummarola()
		{
			return false;
		}

		private void StartChickenTrail()
		{
		}

		private void OnDefeated()
		{
		}

		public void AwardNeoUnlock()
		{
		}

		private void SpawnFreeChicken()
		{
		}

		private void GenerateParticleSystems()
		{
		}

		private void GenerateChickenSprite()
		{
		}
	}
}
