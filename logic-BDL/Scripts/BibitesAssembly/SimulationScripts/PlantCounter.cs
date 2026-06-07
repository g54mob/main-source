using UnityEngine;

namespace SimulationScripts
{
	public class PlantCounter : MonoBehaviour, IEntityCounter
	{
		public static int Count;

		public static double Biomass;

		public MatterPellet pellet;

		public void Awake()
		{
			if (!(pellet == null))
			{
				Count++;
				pellet.AfterEnergyChange.AddListener(ChangeCount);
			}
		}

		public void ChangeCount(float biomassDifference)
		{
			Biomass += biomassDifference;
		}

		public static void ResetCount()
		{
			Count = 0;
			Biomass = 0.0;
		}

		public void AddToGlobalCount()
		{
			if (!(pellet == null))
			{
				Count++;
				Biomass += pellet.energy;
			}
		}

		public void OnDestroy()
		{
			if (!(pellet == null))
			{
				Count--;
				ChangeCount(0f - pellet.energy);
				pellet.AfterEnergyChange.RemoveListener(ChangeCount);
			}
		}
	}
}
