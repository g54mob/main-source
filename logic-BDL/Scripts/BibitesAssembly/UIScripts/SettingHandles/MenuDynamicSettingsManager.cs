using System.Collections;
using System.Collections.Generic;
using SettingScripts;
using SimulationScripts;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class MenuDynamicSettingsManager : MonoBehaviour
	{
		[Header("SettingsHolders")]
		public GameObject SimulationOptionsHolder;

		public GameObject WorldParametersHolder;

		public GameObject BibiteParametersHolder;

		public GameObject EnergyBalanceHolder;

		public float progress;

		public bool doneLoading;

		private int nSettings;

		private List<ISettingsListHandle> SettingGroups;

		private SettingsGroupHandle SimulationOptions = new SettingsGroupHandle
		{
			GroupTitle = "Simulation Options",
			Settings = new List<ISettingHandle>
			{
				new SettingToggle(ScenarioSettings.Instance.preventMutations),
				new SubSettingsGroupHandle
				{
					GroupTitle = "Pellet Options",
					MasterToggle = new SubSettingsToggleMaster(ScenarioSettings.Instance.pelletCollision),
					Settings = new List<ISettingHandle>
					{
						new SettingToggle(ScenarioSettings.Instance.pelletRotation),
						new SettingToggle(ScenarioSettings.Instance.pelletMerge)
					}
				},
				new SettingToggle(ScenarioSettings.Instance.disableHerding),
				new SubSettingsGroupHandle
				{
					GroupTitle = "Shade Effect",
					MasterToggle = new SubSettingsToggleMaster(ScenarioSettings.Instance.shadeOutsideOfBounds),
					Settings = new List<ISettingHandle>
					{
						new SettingToggle(ScenarioSettings.Instance.shadeAvoidance),
						new SettingToggle(ScenarioSettings.Instance.worldWrapping)
					}
				},
				new SettingToggle(ScenarioSettings.Instance.preventRedPheroProduction),
				new SettingToggle(ScenarioSettings.Instance.preventGreenPheroProduction),
				new SettingToggle(ScenarioSettings.Instance.preventBluePheroProduction)
			}
		};

		private SettingsGroupHandle CheatOptions = new SettingsGroupHandle
		{
			GroupTitle = "Cheat Options",
			Settings = new List<ISettingHandle>
			{
				new SubSettingsGroupHandle
				{
					GroupTitle = "Void Avoidance Settings",
					MasterToggle = new SubSettingsToggleMaster(ScenarioSettings.Instance.voidAvoidance),
					Settings = new List<ISettingHandle>
					{
						new FloatSettingSlider(ScenarioSettings.Instance.voidAvoidanceDistance)
					}
				}
			}
		};

		private SettingsGroupHandle GlobalParameters = new SettingsGroupHandle
		{
			GroupTitle = "Zones Parameters",
			Settings = new List<ISettingHandle>
			{
				new LogFloatSettingSlider(ScenarioIndependentSettings.Instance.biomassDensity, 10f, wholeNumbers: false, simple: false, 3.5f),
				new LogFloatSettingSlider(ScenarioIndependentSettings.Instance.pelletGrowth, 10f, wholeNumbers: false, simple: false, 3.5f),
				new LogFloatSettingSlider(ScenarioSettings.Instance.globalZoneSpeed, 10f, wholeNumbers: false, simple: false, 6f),
				new LogFloatSettingSlider(ScenarioSettings.Instance.pelletEnergy, 10f)
			}
		};

		private SettingsGroupHandle TPSParameters = new SettingsGroupHandle
		{
			GroupTitle = "Simulation Performance Parameters",
			Settings = new List<ISettingHandle>
			{
				new IntSettingSlider(ScenarioIndependentSettings.Instance.simTPS),
				new IntSettingSlider(ScenarioIndependentSettings.Instance.brainTPS),
				new IntSettingSlider(ScenarioIndependentSettings.Instance.decayTPS),
				new IntSettingSlider(ScenarioIndependentSettings.Instance.visionLookupUpdateFactor),
				new IntSettingSlider(ScenarioIndependentSettings.Instance.visionSenseUpdateFactor),
				new LogFloatSettingSlider(ScenarioSettings.Instance.minPelletSize, 10f, wholeNumbers: false, simple: false, 3.5f)
			}
		};

		private SettingsGroupHandle PhysicsParameters = new SettingsGroupHandle
		{
			GroupTitle = "Physics Parameters",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ScenarioSettings.Instance.dragCoefficient),
				new SettingToggle(ScenarioSettings.Instance.disableDragOnHeldPellet)
			}
		};

		private SettingsGroupHandle VirginBibiteOptions = new SettingsGroupHandle
		{
			GroupTitle = "Virgin Bibite Options",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ScenarioIndependentSettings.Instance.virginSpawnRate),
				new SubSettingsGroupHandle
				{
					GroupTitle = "Limit Bibite Birth",
					MasterToggle = new SubSettingsToggleMaster(ScenarioIndependentSettings.Instance.limitBibiteBirth),
					Settings = new List<ISettingHandle>
					{
						new IntSettingSlider(ScenarioIndependentSettings.Instance.bibiteLimit)
					}
				},
				new FloatSettingSlider(ScenarioSettings.Instance.backgroundMutationChance),
				new FloatSettingSlider(ScenarioSettings.Instance.backgroundMutationVariance),
				new FloatSettingSlider(ScenarioSettings.Instance.relativeMutationShare),
				new FixedSumSettingsGroupHandle
				{
					GroupTitle = "Brain Mutation Probabilities",
					fixedSumValue = 1f,
					Settings = new List<ISettingHandle>
					{
						new FloatSettingSlider(ScenarioSettings.Instance.synapseMutationChance),
						new FloatSettingSlider(ScenarioSettings.Instance.neuronMutationChance)
					}
				},
				new FixedSumSettingsGroupHandle
				{
					GroupTitle = "Synapse Mutation Probabilities",
					fixedSumValue = 1f,
					Settings = new List<ISettingHandle>
					{
						new FloatSettingSlider(ScenarioSettings.Instance.synapseChangeChance),
						new FloatSettingSlider(ScenarioSettings.Instance.synapseFlipChance),
						new FloatSettingSlider(ScenarioSettings.Instance.synapseToggleChance),
						new FloatSettingSlider(ScenarioSettings.Instance.synapseAddChance),
						new FloatSettingSlider(ScenarioSettings.Instance.synapseRemoveChance)
					}
				},
				new FixedSumSettingsGroupHandle
				{
					GroupTitle = "Neuron Mutation Probabilities",
					fixedSumValue = 1f,
					Settings = new List<ISettingHandle>
					{
						new FloatSettingSlider(ScenarioSettings.Instance.neuronDefaultChance),
						new FloatSettingSlider(ScenarioSettings.Instance.neuronChangeChance),
						new FloatSettingSlider(ScenarioSettings.Instance.neuronAddChance),
						new FloatSettingSlider(ScenarioSettings.Instance.neuronRemoveChance)
					}
				}
			}
		};

		private SettingsGroupHandle BibiteConstants = new SettingsGroupHandle
		{
			GroupTitle = "Bibite Balance",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ScenarioSettings.Instance.armMusclePressure),
				new FloatSettingSlider(ScenarioSettings.Instance.forwardForceSizePower),
				new FloatSettingSlider(ScenarioSettings.Instance.turnForceSizePower),
				new FloatSettingSlider(ScenarioSettings.Instance.backwardFraction),
				new FloatSettingSlider(ScenarioSettings.Instance.bitingPressure),
				new FloatSettingSlider(ScenarioSettings.Instance.jawMusclesSizingPower),
				new FloatSettingSlider(ScenarioSettings.Instance.bitePeriodFactor),
				new FloatSettingSlider(ScenarioSettings.Instance.throwingForceFactor),
				new FloatSettingSlider(ScenarioSettings.Instance.bitingThrowForceFactor),
				new FloatSettingSlider(ScenarioSettings.Instance.bitingDamageFactor),
				new FloatSettingSlider(ScenarioSettings.Instance.healRate),
				new FloatSettingSlider(ScenarioSettings.Instance.healPowerFactor),
				new SettingsGroupHandle
				{
					GroupTitle = "Energy Balance",
					Settings = new List<ISettingHandle>
					{
						new FloatSettingSlider(ScenarioSettings.Instance.energyUsageEfficiency),
						new FloatSettingSlider(ScenarioSettings.Instance.pheromoneProductionCost),
						new FloatSettingSlider(ScenarioSettings.Instance.fatSustain),
						new FloatSettingSlider(ScenarioSettings.Instance.pheromoneProductionStrength),
						new FloatSettingSlider(ScenarioSettings.Instance.baseMetabolismCost),
						new FloatSettingSlider(ScenarioSettings.Instance.moveMusclesCost),
						new FloatSettingSlider(ScenarioSettings.Instance.neuronBirthCost),
						new FloatSettingSlider(ScenarioSettings.Instance.synapseBirthCost),
						new FloatSettingSlider(ScenarioSettings.Instance.neuronUpkeepCost),
						new FloatSettingSlider(ScenarioSettings.Instance.synapseUpkeepCost)
					}
				},
				new FloatSettingSlider(ScenarioSettings.Instance.storableEnergyPerArea),
				new SettingsGroupHandle
				{
					GroupTitle = "Bibite Aging",
					Settings = new List<ISettingHandle>
					{
						new FloatSettingSlider(ScenarioSettings.Instance.ageingThreshold),
						new FloatSettingSlider(ScenarioSettings.Instance.ageStrengthPenalties),
						new FloatSettingSlider(ScenarioSettings.Instance.ageMetabolismPenalties)
					}
				}
			}
		};

		private SettingsGroupHandle MaterialParameters = new SettingsGroupHandle
		{
			GroupTitle = "Materials Parameters",
			Settings = new List<ISettingHandle>
			{
				new MatterMaterialSettingsHandle(MatterMaterialManager.PlantParameters),
				new MatterMaterialSettingsHandle(MatterMaterialManager.MeatParameters),
				new MatterMaterialSettingsHandle(MatterMaterialManager.FatParameters),
				new MatterMaterialSettingsHandle(MatterMaterialManager.ArmorParameters),
				new FloatSettingSlider(ScenarioSettings.Instance.plantAffinityPowerFactor),
				new FloatSettingSlider(ScenarioSettings.Instance.meatAffinityPowerFactor)
			}
		};

		private void Awake()
		{
			doneLoading = false;
			SettingGroups = new List<ISettingsListHandle>
			{
				SimulationOptions.AssignHolder(SimulationOptionsHolder),
				CheatOptions.AssignHolder(SimulationOptionsHolder),
				GlobalParameters.AssignHolder(WorldParametersHolder),
				TPSParameters.AssignHolder(SimulationOptionsHolder),
				PhysicsParameters.AssignHolder(SimulationOptionsHolder),
				VirginBibiteOptions.AssignHolder(BibiteParametersHolder),
				BibiteConstants.AssignHolder(EnergyBalanceHolder),
				MaterialParameters.AssignHolder(EnergyBalanceHolder)
			};
			nSettings = 0;
			SettingGroups.ForEach(delegate(ISettingsListHandle sg)
			{
				nSettings += sg.GetSettingsCount();
			});
		}

		public void StartLoadingSettingsHandles()
		{
			progress = 0f;
			StartCoroutine(LoadUISettingsHandles());
		}

		public void UpdateControls()
		{
			SettingGroups.ForEach(delegate(ISettingsListHandle _s)
			{
				_s.UpdateUIElement();
			});
		}

		public void ResetValues()
		{
			SettingGroups.ForEach(delegate(ISettingsListHandle _s)
			{
				_s.ResetValue();
			});
			UpdateControls();
		}

		private IEnumerator LoadUISettingsHandles()
		{
			foreach (ISettingsListHandle settingsGroup in SettingGroups)
			{
				yield return null;
				settingsGroup.CreateUIElements();
				progress += (float)settingsGroup.GetSettingsCount() / (float)nSettings;
			}
			doneLoading = true;
			progress = 1f;
		}

		private void OnDestroy()
		{
			foreach (ISettingsListHandle settingGroup in SettingGroups)
			{
				settingGroup.ReleaseDependencies();
			}
		}
	}
}
