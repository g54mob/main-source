using System;
using System.Collections.Generic;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class JobChainControllerWithEmptyHaulGeneration : JobChainController
{
	public JobChainControllerWithEmptyHaulGeneration(GameObject jobChainGO)
		: base(jobChainGO)
	{
	}

	protected override void OnLastJobInChainCompleted(Job lastJobInChain)
	{
		StaticJobDefinition staticJobDefinition = jobChain[jobChain.Count - 1];
		if (staticJobDefinition.job == lastJobInChain && lastJobInChain.jobType == JobType.ShuntingUnload)
		{
			StaticShuntingUnloadJobDefinition staticShuntingUnloadJobDefinition = staticJobDefinition as StaticShuntingUnloadJobDefinition;
			if (staticShuntingUnloadJobDefinition != null)
			{
				StationController startingStation = SingletonBehaviour<LogicController>.Instance.YardIdToStationController[staticShuntingUnloadJobDefinition.logicStation.ID];
				System.Random rng = new System.Random(Environment.TickCount);
				List<CarsPerTrack> carsPerDestinationTrack = staticShuntingUnloadJobDefinition.carsPerDestinationTrack;
				for (int i = 0; i < carsPerDestinationTrack.Count; i++)
				{
					Track track = carsPerDestinationTrack[i].track;
					List<Car> cars = carsPerDestinationTrack[i].cars;
					JobChainController jobChainController = EmptyHaulJobProceduralGenerator.GenerateEmptyHaulJobWithExistingCars(startingStation, track, cars, rng);
					if (jobChainController != null)
					{
						for (int j = 0; j < cars.Count; j++)
						{
							carsForJobChain.Remove(cars[j]);
						}
						jobChainController.FinalizeSetupAndGenerateFirstJob();
						Debug.Log("Generated job chain [" + jobChainController.jobChainGO.name + "]: ", jobChainController.jobChainGO);
					}
				}
			}
			else
			{
				Debug.LogError("Couldn't convert lastJobDef to StaticShuntingUnloadJobDefinition. EmptyHaul jobs won't be generated.");
			}
		}
		else
		{
			Debug.LogError("Unexpected job chain format. ShuntingUnload has to be last job in chain for JobChainControllerWithEmptyHaulGeneration!EmptyHaul jobs won't be generated.");
		}
		base.OnLastJobInChainCompleted(lastJobInChain);
	}
}
