using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DenExpansion
{
	public int currentExpansionStage;

	public List<ExpansionStageInfo> expansions = new List<ExpansionStageInfo>();

	public Transform currentNestTransform;

	public Transform currentBedroomTransform;

	public Transform currentRitualTransform;

	public int additionalCapacity;

	private ulong? registeredDog;

	private DogDenInterior interiorRef;

	public void ShowInitialExpansion()
	{
		for (int i = 0; i < expansions.Count; i++)
		{
			expansions[i].mainObject.SetActive(value: false);
			if (expansions[i].wallGeometry != null)
			{
				expansions[i].wallGeometry.SetActive(value: false);
			}
			if (expansions[i].floorCeilingCollisions != null)
			{
				expansions[i].floorCeilingCollisions.SetActive(value: false);
			}
		}
		currentNestTransform = null;
		currentBedroomTransform = null;
		currentRitualTransform = null;
		additionalCapacity = 0;
		currentExpansionStage = -1;
		Expand();
	}

	public void SetExpansionStage(int stage)
	{
		ShowInitialExpansion();
		while (currentExpansionStage < stage)
		{
			Expand(updateNavmesh: false);
		}
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER).Rebuild();
	}

	public void SetAssociatedInterior(DogDenInterior newRef)
	{
		interiorRef = newRef;
	}

	public DogDenInterior GetAssociatedInterior()
	{
		return interiorRef;
	}

	public Transform GetCurrentExpansionTransform()
	{
		return GetInfoForCurrentExpansionStage().expansionTransform;
	}

	public GameObject GetCurrentMainObject()
	{
		return GetInfoForCurrentExpansionStage().mainObject;
	}

	public ExpansionStageInfo GetInfoForCurrentExpansionStage()
	{
		return GetInfoForExpansionStage(currentExpansionStage);
	}

	public ExpansionStageInfo GetInfoForExpansionStage(int index)
	{
		if (index < 0)
		{
			return null;
		}
		if (index < expansions.Count)
		{
			return expansions[index];
		}
		Debug.LogError("No valid expansion stage info specified for stage: " + index);
		return null;
	}

	public void Expand(bool updateNavmesh = true)
	{
		if (currentExpansionStage >= expansions.Count - 1)
		{
			Debug.LogError("Can't expand any futher.");
			return;
		}
		ExpansionStageInfo infoForCurrentExpansionStage = GetInfoForCurrentExpansionStage();
		ExpansionStageInfo infoForExpansionStage = GetInfoForExpansionStage(currentExpansionStage + 1);
		if (infoForCurrentExpansionStage != null && infoForCurrentExpansionStage.mainObject != null)
		{
			infoForCurrentExpansionStage.mainObject.SetActive(value: false);
		}
		if (infoForExpansionStage.mainObject != null)
		{
			infoForExpansionStage.mainObject.SetActive(value: true);
		}
		if (infoForExpansionStage.colliderToTurnOff != null)
		{
			infoForExpansionStage.colliderToTurnOff.SetActive(value: false);
		}
		if (infoForExpansionStage.wallGeometry != null)
		{
			infoForExpansionStage.wallGeometry.SetActive(value: true);
		}
		if (infoForExpansionStage.floorCeilingCollisions != null)
		{
			infoForExpansionStage.floorCeilingCollisions.SetActive(value: true);
		}
		additionalCapacity += infoForExpansionStage.additionalCapacity;
		if (infoForExpansionStage.newBedroomTargetTransform != null)
		{
			currentBedroomTransform = infoForExpansionStage.newBedroomTargetTransform;
		}
		if (infoForExpansionStage.newNestTargetTransform != null)
		{
			currentNestTransform = infoForExpansionStage.newNestTargetTransform;
		}
		if (infoForExpansionStage.newRitualTargetTransform != null)
		{
			currentRitualTransform = infoForExpansionStage.newRitualTargetTransform;
		}
		currentExpansionStage++;
		if (updateNavmesh)
		{
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER).Rebuild();
		}
		if (infoForExpansionStage != null && infoForExpansionStage.finalExpansionForRoom)
		{
			GoalsController.SetGoalEvent(GoalCondition.FULLY_EXPANDED_DEN_ROOM, 1);
		}
	}

	public void RegisterDog(ulong dogUID)
	{
		if (registeredDog.HasValue)
		{
			Debug.LogError("Attempting to register a dog with this expansion but there's already one registered.");
		}
		else
		{
			registeredDog = dogUID;
		}
	}

	public void ClearDogRegistration()
	{
		registeredDog = null;
	}

	public bool IsDogRegistered()
	{
		if (!registeredDog.HasValue)
		{
			return false;
		}
		return true;
	}

	public bool CanDogExpand()
	{
		if (currentExpansionStage < expansions.Count - 1 && !registeredDog.HasValue)
		{
			return true;
		}
		return false;
	}
}
