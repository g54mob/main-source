using System.Collections;
using System.Collections.Generic;
using ManagementScripts;
using OneUseScripts;
using SettingScripts;
using SimulationScripts;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class ScenariosEditor : UIPanel
	{
		[Header("SettingsHolders")]
		public GameObject SimulationOptionsHolder;

		public GameObject EnergyBalanceHolder;

		public GameObject WorldParametersHolder;

		public GameObject GeneticsHolder;

		public GameObject settingsTuner;

		[SerializeField]
		private ZonesEditorPanel zonesEditorPanel;

		[SerializeField]
		private ScenarioSelectorPanel scenarioSelector;

		[SerializeField]
		private GameObject challengeParametersPrefab;

		[SerializeField]
		private Transform challengeParametersHolder;

		[SerializeField]
		private DefaultBibitesPanel defaultBibitesPanel;

		[SerializeField]
		private ScenarioSaver savePanel;

		private ChallengeParametersHandle challengeParameters;

		public float progress;

		public bool doneLoading;

		private int nSettings;

		public List<GameObject> Panels = new List<GameObject>();

		public List<GameObject> Previews = new List<GameObject>();

		public List<GameObject> showWithChallenges = new List<GameObject>();

		public List<GameObject> hideWithChallenges = new List<GameObject>();

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
				new SettingToggle(ScenarioSettings.Instance.eggCollision),
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

		private SettingsGroupHandle WorldParameters = new SettingsGroupHandle
		{
			GroupTitle = "World Parameters",
			Settings = new List<ISettingHandle>
			{
				new LogFloatSettingSlider(ScenarioIndependentSettings.Instance.SimulationSize, 10f),
				new LogFloatSettingSlider(ScenarioIndependentSettings.Instance.biomassDensity, 10f, wholeNumbers: false, simple: false, 3.5f),
				new FloatSettingSlider(ScenarioSettings.Instance.initialSeeding),
				new LogFloatSettingSlider(ScenarioIndependentSettings.Instance.pelletGrowth, 10f, wholeNumbers: false, simple: false, 3.5f),
				new LogFloatSettingSlider(ScenarioSettings.Instance.globalZoneSpeed, 10f, wholeNumbers: false, simple: false, 6f),
				new LogFloatSettingSlider(ScenarioSettings.Instance.pelletEnergy, 10f)
			}
		};

		private SettingsGroupHandle PerformanceParameters = new SettingsGroupHandle
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
				new SettingToggle(ScenarioSettings.Instance.disableDragOnHeldPellet),
				new FloatSettingSlider(ScenarioSettings.Instance.armMusclePressure),
				new FloatSettingSlider(ScenarioSettings.Instance.forwardForceSizePower),
				new FloatSettingSlider(ScenarioSettings.Instance.turnForceSizePower),
				new FloatSettingSlider(ScenarioSettings.Instance.backwardFraction),
				new FloatSettingSlider(ScenarioSettings.Instance.bibiteMassDensity),
				new FloatSettingSlider(ScenarioSettings.Instance.stomachContentContribution),
				new FloatSettingSlider(ScenarioSettings.Instance.bitingPressure),
				new FloatSettingSlider(ScenarioSettings.Instance.jawMusclesSizingPower),
				new FloatSettingSlider(ScenarioSettings.Instance.bitePeriodFactor),
				new FloatSettingSlider(ScenarioSettings.Instance.throwingForceFactor),
				new FloatSettingSlider(ScenarioSettings.Instance.bitingThrowForceFactor),
				new FloatSettingSlider(ScenarioSettings.Instance.bitingDamageFactor),
				new FloatSettingSlider(ScenarioSettings.Instance.collisionDamageConstant),
				new FloatSettingSlider(ScenarioSettings.Instance.collisionDamageThreshold)
			}
		};

		private SettingsGroupHandle BibiteConstants = new SettingsGroupHandle
		{
			GroupTitle = "Bibite Balance",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ScenarioSettings.Instance.storableEnergyPerArea),
				new FloatSettingSlider(ScenarioSettings.Instance.fatSustain),
				new FloatSettingSlider(ScenarioSettings.Instance.baseMetabolismCost),
				new FloatSettingSlider(ScenarioSettings.Instance.energyUsageEfficiency),
				new FloatSettingSlider(ScenarioSettings.Instance.moveMusclesCost),
				new FloatSettingSlider(ScenarioSettings.Instance.neuronBirthCost),
				new FloatSettingSlider(ScenarioSettings.Instance.synapseBirthCost),
				new FloatSettingSlider(ScenarioSettings.Instance.neuronUpkeepCost),
				new FloatSettingSlider(ScenarioSettings.Instance.synapseUpkeepCost),
				new FloatSettingSlider(ScenarioSettings.Instance.pheromoneProductionCost),
				new FloatSettingSlider(ScenarioSettings.Instance.pheromoneProductionStrength)
			}
		};

		private SettingsGroupHandle BibiteAging = new SettingsGroupHandle
		{
			GroupTitle = "Bibite Aging",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ScenarioSettings.Instance.ageingThreshold),
				new FloatSettingSlider(ScenarioSettings.Instance.ageStrengthPenalties),
				new FloatSettingSlider(ScenarioSettings.Instance.ageMetabolismPenalties)
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

		private SettingsGroupHandle ChallengeParameters = new SettingsGroupHandle
		{
			GroupTitle = "Challenge Scenario Parameters",
			Settings = new List<ISettingHandle>
			{
				new SubSettingsGroupHandle
				{
					GroupTitle = "Star Challenges",
					Settings = new List<ISettingHandle>()
				}
			}
		};

		private SettingsGroupHandle MeatBalance = new SettingsGroupHandle
		{
			GroupTitle = "Bibite Meat Balance",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ScenarioSettings.Instance.baseBodyGrowthCost),
				new FloatSettingSlider(ScenarioSettings.Instance.viewAngleAddedCost),
				new FloatSettingSlider(ScenarioSettings.Instance.viewRadiusAddedCost),
				new FloatSettingSlider(ScenarioSettings.Instance.healthPerArea),
				new FloatSettingSlider(ScenarioSettings.Instance.healthEnergyFactor),
				new FloatSettingSlider(ScenarioSettings.Instance.healRate),
				new FloatSettingSlider(ScenarioSettings.Instance.healPowerFactor)
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
				}
			}
		};

		private SettingsGroupHandle SpeciesSettings = new SettingsGroupHandle
		{
			GroupTitle = "Species Settings",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ScenarioIndependentSettings.Instance.speciesGeneticSpan),
				new FloatSettingSlider(ScenarioIndependentSettings.Instance.speciesSpanScalingFactor)
			}
		};

		private SettingsGroupHandle MutationGenes = new SettingsGroupHandle
		{
			GroupTitle = "Mutation Genes",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ScenarioSettings.Instance.backgroundMutationChance),
				new FloatSettingSlider(ScenarioSettings.Instance.backgroundMutationVariance),
				new FloatSettingSlider(ScenarioSettings.Instance.relativeMutationShare)
			}
		};

		private FixedSumSettingsGroupHandle baseBrainMutationGroupHandle = new FixedSumSettingsGroupHandle
		{
			GroupTitle = "Brain Mutation Probabilities",
			fixedSumValue = 1f,
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ScenarioSettings.Instance.synapseMutationChance),
				new FloatSettingSlider(ScenarioSettings.Instance.neuronMutationChance)
			}
		};

		private FixedSumSettingsGroupHandle synapseMutationGroupHandle = new FixedSumSettingsGroupHandle
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
		};

		private FixedSumSettingsGroupHandle neuronMutationGroupHandle = new FixedSumSettingsGroupHandle
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
		};

		public override void InitPanel()
		{
			doneLoading = false;
			SettingGroups = new List<ISettingsListHandle>
			{
				SimulationOptions.AssignHolder(SimulationOptionsHolder),
				CheatOptions.AssignHolder(SimulationOptionsHolder),
				WorldParameters.AssignHolder(WorldParametersHolder),
				PerformanceParameters.AssignHolder(SimulationOptionsHolder),
				PhysicsParameters.AssignHolder(SimulationOptionsHolder),
				BibiteAging.AssignHolder(EnergyBalanceHolder),
				BibiteConstants.AssignHolder(EnergyBalanceHolder),
				MaterialParameters.AssignHolder(EnergyBalanceHolder),
				MeatBalance.AssignHolder(EnergyBalanceHolder),
				VirginBibiteOptions.AssignHolder(GeneticsHolder),
				SpeciesSettings.AssignHolder(GeneticsHolder),
				MutationGenes.AssignHolder(GeneticsHolder),
				baseBrainMutationGroupHandle.AssignHolder(GeneticsHolder),
				synapseMutationGroupHandle.AssignHolder(GeneticsHolder),
				neuronMutationGroupHandle.AssignHolder(GeneticsHolder)
			};
			ScenarioIndependentSettings.Instance.speciesGeneticSpan.SetValue(UserSettings.SpeciesSpanPreference.val);
			ScenarioIndependentSettings.Instance.speciesGeneticSpan.OnValueChange.AddListener(UserSettings.SpeciesSpanPreference.SetValue);
			ScenarioIndependentSettings.Instance.speciesSpanScalingFactor.SetValue(UserSettings.SpeciesSpanScalingFactorPreference.val);
			ScenarioIndependentSettings.Instance.speciesSpanScalingFactor.OnValueChange.AddListener(UserSettings.SpeciesSpanScalingFactorPreference.SetValue);
			nSettings = 0;
			SettingGroups.ForEach(delegate(ISettingsListHandle sg)
			{
				nSettings += sg.GetSettingsCount();
			});
			zonesEditorPanel.InitPanel();
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			if (doneLoading)
			{
				UpdateControls();
			}
			zonesEditorPanel.FillPanel();
			defaultBibitesPanel.RefillPanel();
			SwitchToPanel(0);
			UINavigationManager.ClearRevertableStack();
			UpdateIsChallenge();
		}

		public override void ClosePanel()
		{
			PopupManager.DisplayChoiceDialog("Warning", "You're about to exit the Scenario Editor without saving it in a new scenario or starting your simulation.\n\rYou will lose any modifications, and values will be reset to their default.\n\rAre you sure?", "Cancel", "YES", null, ActuallyClosePanel);
		}

		public void ActuallyClosePanel()
		{
			base.ClosePanel();
			scenarioSelector.gameObject.SetActive(value: true);
			scenarioSelector.SelectScenarioItem(scenarioSelector.selectedItem);
			zonesEditorPanel.ResetState();
			if (challengeParameters != null)
			{
				Object.Destroy(challengeParameters.gameObject);
			}
			UINavigationManager.ClearRevertableStack();
		}

		public void StartSimulation()
		{
			PopupManager.DisplayActionWarning(ActionWarnings.startScenarioAfterEdit, delegate
			{
				scenarioSelector.StartSim(customScenario: true);
			}, "YES", null, "Launching Simulation");
		}

		public void SwitchToPanel(int i)
		{
			if (i < Panels.Count)
			{
				Panels.ForEach(delegate(GameObject p)
				{
					p.SetActive(value: false);
				});
				Previews.ForEach(delegate(GameObject p)
				{
					p.SetActive(value: false);
				});
				Panels[i].SetActive(value: true);
				Previews[i].SetActive(value: true);
			}
		}

		public void StartLoadingSettingsHandles()
		{
			progress = 0f;
			base.gameObject.SetActive(value: true);
			Panels.ForEach(delegate(GameObject p)
			{
				p.SetActive(value: true);
			});
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

		public void RequestSaveScenario()
		{
			SwitchToPanel(1);
			zonesEditorPanel.SetShowLabels(val: false);
			RectScreenShooter.instance.CaptureObject(zonesEditorPanel.previewRT, OpenSaverPanel, alsoSaveTempScreenshot: true);
		}

		public void OpenSaverPanel(Texture2D screenshot)
		{
			zonesEditorPanel.SetShowLabels(val: true);
			Texture2D tex = screenshot;
			if (ScenarioSelectorPanel.scenarioHasIMG)
			{
				tex = ScenarioSelectorPanel.tex;
			}
			savePanel.OpenWithImage(tex);
		}

		public void SetIsChallenge(bool val)
		{
			ScenarioSettings.Instance.challengeParameters = (val ? new ChallengeParameters() : null);
			UpdateIsChallenge();
		}

		private void UpdateIsChallenge()
		{
			bool isChallenge = ScenarioSettings.Instance.isChallenge;
			showWithChallenges.ForEach(delegate(GameObject g)
			{
				g.SetActive(isChallenge);
			});
			hideWithChallenges.ForEach(delegate(GameObject g)
			{
				g.SetActive(!isChallenge);
			});
			if (!isChallenge && challengeParameters != null)
			{
				Object.Destroy(challengeParameters.gameObject);
			}
			if (isChallenge && challengeParameters == null)
			{
				challengeParameters = Object.Instantiate(challengeParametersPrefab, challengeParametersHolder).GetComponent<ChallengeParametersHandle>();
				challengeParameters.InitializeItem(ScenarioSettings.Instance.challengeParameters);
			}
		}

		private IEnumerator LoadUISettingsHandles()
		{
			yield return null;
			foreach (ISettingsListHandle settingGroup in SettingGroups)
			{
				settingGroup.CreateUIElements();
				progress += (float)settingGroup.GetSettingsCount() / (float)nSettings;
				yield return null;
			}
			SwitchToPanel(0);
			doneLoading = true;
			progress = 1f;
		}

		private void OnDestroy()
		{
			foreach (ISettingsListHandle settingGroup in SettingGroups)
			{
				settingGroup.ReleaseDependencies();
			}
			ScenarioIndependentSettings.Instance.speciesGeneticSpan.OnValueChange.RemoveListener(UserSettings.SpeciesSpanPreference.SetValue);
			ScenarioIndependentSettings.Instance.speciesSpanScalingFactor.OnValueChange.RemoveListener(UserSettings.SpeciesSpanScalingFactorPreference.SetValue);
		}
	}
}
