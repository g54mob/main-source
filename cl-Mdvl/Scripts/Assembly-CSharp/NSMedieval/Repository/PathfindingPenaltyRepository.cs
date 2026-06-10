using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class PathfindingPenaltyRepository : DynamicJsonRepository<PathfindingPenaltyRepository, PathfindingPenalty>
	{
		public static List<PathfindingPenalty> FastRepo;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void OnDomainReload()
		{
			FastRepo = null;
		}

		protected override string JsonFile()
		{
			return "Creature/PathfindingPenaltyRepository.json";
		}

		public override void Deserialize()
		{
			base.Deserialize();
			FastRepo = repository;
		}
	}
}
