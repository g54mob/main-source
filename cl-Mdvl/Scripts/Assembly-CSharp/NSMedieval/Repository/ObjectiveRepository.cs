using System;
using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Objectives;

namespace NSMedieval.Repository
{
	public class ObjectiveRepository : DynamicJsonRepository<ObjectiveRepository, Objective>
	{
		[NonSerialized]
		private bool checkObjectiveOnPlantPhaseChangeCacheInit;

		[NonSerialized]
		private HashSet<string> checkObjectiveOnPlantPhaseChangeCache;

		private HashSet<string> CheckObjectiveOnPlantPhaseChangeCache
		{
			get
			{
				if (!checkObjectiveOnPlantPhaseChangeCacheInit)
				{
					checkObjectiveOnPlantPhaseChangeCache = new HashSet<string>();
					foreach (Objective allItem in base.AllItems)
					{
						ObjectiveTask[] tasks = allItem.Tasks;
						foreach (ObjectiveTask objectiveTask in tasks)
						{
							if (objectiveTask.Requirements == null)
							{
								continue;
							}
							ObjectiveTaskRequirement[] requirements = objectiveTask.Requirements;
							foreach (ObjectiveTaskRequirement objectiveTaskRequirement in requirements)
							{
								if (objectiveTaskRequirement.Type == ObjectiveTaskRequirementType.HavePlantInRoom && objectiveTaskRequirement.PlantLifePhases != null && objectiveTaskRequirement.PlantLifePhases.Count > 0)
								{
									checkObjectiveOnPlantPhaseChangeCache.Add(objectiveTaskRequirement.ModelId);
								}
							}
						}
					}
					checkObjectiveOnPlantPhaseChangeCacheInit = true;
				}
				return checkObjectiveOnPlantPhaseChangeCache;
			}
		}

		protected override string JsonFile()
		{
			return "Objectives/ObjectiveRepository.json";
		}

		public bool ShouldCheckObjectiveOnPlantPhaseChange(string plantBlueprintId)
		{
			return CheckObjectiveOnPlantPhaseChangeCache.Contains(plantBlueprintId);
		}
	}
}
