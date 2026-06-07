using System;
using System.Collections.Generic;
using UnityEngine;

namespace NewGameplayScripts
{
	public class PlantsOnSceneCollection : MonoBehaviour
	{
		public List<Plant> collection;

		public List<Plant> FirstFloorCollection;

		public List<Plant> SecondFloorCollection;

		public static PlantsOnSceneCollection Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			UpdateChildren();
			PlantCreatingSystem instance = PlantCreatingSystem.Instance;
			instance.OnPlantsLoaded = (Action)Delegate.Combine(instance.OnPlantsLoaded, new Action(UpdateChildren));
		}

		private void OnDestroy()
		{
			PlantCreatingSystem instance = PlantCreatingSystem.Instance;
			instance.OnPlantsLoaded = (Action)Delegate.Remove(instance.OnPlantsLoaded, new Action(UpdateChildren));
		}

		private void OnTransformChildrenChanged()
		{
			UpdateChildren();
		}

		public void SwitchFirstFloorCollection(bool turnOn)
		{
			SwitchFloorCollection(FirstFloorCollection, turnOn);
		}

		public void SwitchSecondFloorCollection(bool turnOn)
		{
			SwitchFloorCollection(SecondFloorCollection, turnOn);
		}

		public void SwitchItemsMoveOnFirstFloorPossibility(bool TurnOn)
		{
			foreach (Plant item in FirstFloorCollection)
			{
				item.SwitchMovement(TurnOn);
			}
		}

		private void UpdateChildren()
		{
			collection.Clear();
			FirstFloorCollection.Clear();
			SecondFloorCollection.Clear();
			Plant[] componentsInChildren = base.transform.GetComponentsInChildren<Plant>();
			foreach (Plant plant in componentsInChildren)
			{
				collection.Add(plant);
				if (plant.transform.position.y > 0f)
				{
					SecondFloorCollection.Add(plant);
				}
				else
				{
					FirstFloorCollection.Add(plant);
				}
			}
			if (collection.Count >= 50 && collection.Count < 100)
			{
				SteamIntegration.Instance.UnlockAchievement("PLANTS50_20", 20);
			}
			if (collection.Count >= 100)
			{
				SteamIntegration.Instance.UnlockAchievement("PLANTS100_21", 21);
			}
		}

		private void SwitchFloorCollection(List<Plant> plants, bool turnOn)
		{
			foreach (Plant plant in plants)
			{
				plant.SetIsMoving(!turnOn);
				plant.GetSinglePlantInfoUI().gameObject.SetActive(turnOn);
				plant.GetPlantVisual().gameObject.SetActive(turnOn);
				if (plant.IsWallPlant())
				{
					plant.GetWallPot().gameObject.SetActive(turnOn);
				}
				else
				{
					plant.GetFloorPot().gameObject.SetActive(turnOn);
				}
			}
		}
	}
}
