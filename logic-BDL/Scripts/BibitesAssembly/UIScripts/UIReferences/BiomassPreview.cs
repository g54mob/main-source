using SettingScripts;
using UIScripts.InfoHandles;
using UnityEngine;

namespace UIScripts.UIReferences
{
	public class BiomassPreview : MonoBehaviour
	{
		[SerializeField]
		private FloatValueTextHandle biomass;

		[SerializeField]
		private FloatValueTextHandle fertility;

		[SerializeField]
		private FloatValueTextHandle pellet;

		private void Awake()
		{
			ScenarioSettings.onZoneBiomassChange.AddListener(UpdateEstimations);
			ScenarioSettings.onZoneRemoved.AddListener(UpdateEstimations2);
			ScenarioIndependentSettings.Instance.SimulationSize.Subscribe(UpdateEstimations);
			ScenarioIndependentSettings.Instance.biomassDensity.Subscribe(UpdateEstimations);
			ScenarioIndependentSettings.Instance.pelletGrowth.Subscribe(UpdateEstimations);
			ScenarioSettings.Instance.pelletEnergy.Subscribe(UpdateEstimations);
			UpdateEstimations();
		}

		private void UpdateEstimations2(ZoneSettings set)
		{
			UpdateEstimations();
		}

		private void UpdateEstimations()
		{
			biomass.UpdateValue(ScenarioSettings.Instance.TotalBiomass());
			fertility.UpdateValue(ScenarioSettings.Instance.TotalGrowth());
			pellet.UpdateValue(ScenarioSettings.Instance.PelletNumberEstimation());
		}

		private void OnDestroy()
		{
			ScenarioSettings.onZoneBiomassChange.RemoveListener(UpdateEstimations);
			ScenarioSettings.onZoneRemoved.RemoveListener(UpdateEstimations2);
			ScenarioIndependentSettings.Instance.SimulationSize.UnSubscribe(UpdateEstimations);
			ScenarioIndependentSettings.Instance.biomassDensity.UnSubscribe(UpdateEstimations);
			ScenarioIndependentSettings.Instance.pelletGrowth.UnSubscribe(UpdateEstimations);
			ScenarioSettings.Instance.pelletEnergy.UnSubscribe(UpdateEstimations);
		}
	}
}
