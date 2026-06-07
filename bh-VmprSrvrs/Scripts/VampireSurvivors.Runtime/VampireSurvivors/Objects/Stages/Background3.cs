using JetBrains.Annotations;
using UnityEngine;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages
{
	[UsedImplicitly]
	public class Background3 : BackgroundManager
	{
		private int _bossesDefeated;

		private bool _awarded;

		private const int BOSSES_TO_DEFEAT = 7;

		public override void Awake()
		{
		}

		public override void Create()
		{
		}

		private void OnPickupCallback(Pickup item)
		{
		}

		private void SpawnWerewolves(Vector2 pos)
		{
		}

		private void OnDefeated()
		{
		}

		public void AwardGRAZIELLAUnlock()
		{
		}
	}
}
