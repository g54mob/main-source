using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class ChallengeGhosts : Challenge
	{
		private readonly ChallengeGhostsConfig _config;

		public ChallengeGhosts(ChallengeConfig config, Level level)
			: base(config, level)
		{
			_config = GetConfig<ChallengeGhostsConfig>();
		}

		protected override void OnStart()
		{
			base.OnStart();
			List<HospitalMap> list = new List<HospitalMap>(base.Level.WorldState.HospitalMaps);
			list.RemoveAll((HospitalMap map) => !map.Plot.Bought);
			for (int num = 0; num < _config.NumGhostsToSpawn; num++)
			{
				if (RoomAlgorithms.GetRandomFreeTile(list.RandomItem().FloorPlan, out var worldPosition))
				{
					base.Level.CharacterManager.SpawnRandomGhost(worldPosition, Random.Range(0, 360), _config.GhostDefinition.NotNull() ? _config.GhostDefinition.Instance : null);
				}
			}
		}

		protected override int CalculateChallengeScore()
		{
			return 0;
		}

		protected override void UpdateChallenge(float timeDelta)
		{
			base.UpdateChallenge(timeDelta);
			FinishChallenge();
		}
	}
}
