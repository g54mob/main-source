using System;
using System.Collections;
using System.Collections.Generic;
using App.Data;
using Localization;
using ReinforcementLearning;
using ReinforcementLearning.Environment;
using UnityEngine;
using UnityEngine.UI;

namespace DeepTraffic
{
	public class DeepTrafficQuestController : ActiveComponent
	{
		[SceneBind("AgentParameters")]
		private AgentParametersController agentParametersController;

		[SceneBind("DeepTrafficGameController")]
		public DeepTrafficGameController deepTrafficGameController;

		[SceneBind("StatsLayer/StaticServ")]
		private Text StaticServ;

		[SceneBind("TaskId")]
		private Text TaskId;

		[SceneBind("StatsLayer/StaticReward")]
		private Text StaticReward;

		[SceneBind("StatsLayer/DynamicMoney")]
		private Text DynamicMoney;

		[SceneBind("StatsLayer/MoneySpent")]
		private Text MoneySpent;

		[SceneBind("StatsLayer/DynamicTime")]
		private Text DynamicTime;

		[SceneBind("StatsLayer/MoneyValue")]
		private Text MoneyValue;

		[SceneBind("StatsLayer/TargetSpeed")]
		private Text TargetSpeed;

		[SceneBind("StatsLayer/Epoch")]
		private Text TargetEpoch;

		[SceneBind("ControlButtonsRight/StopButton")]
		private Button stopButton;

		[SceneBind("ControlButtonsRight/TrainButton")]
		private Button trainButton;

		[SceneBind("ControlButtonsRight/TestButton")]
		private Button testButton;

		[SceneBind("ControlButtonsLeft/ExitButton")]
		private Button exitButton;

		[SceneBind("ControlButtonsLeft/SetDefaultButton")]
		private Button setDefaultButton;

		[SceneBind("SetDefaultAttentionWin")]
		private AttentionController setDefaultAttention;

		[SceneBind("ControlButtonsLeft/RefreshAgentButton")]
		private Button refreshAgentButton;

		[SceneBind("RefreshAgentAttentionWin")]
		private AttentionController refreshAgentAttention;

		[SceneBind("TeachButton")]
		public Button teachButton;

		[SceneBind("DeepTrafficQuestResult")]
		private DeepTrafficQuestResultController deepTrafficQuestResultController;

		[SceneBind("ControlButtonsRight/ReleaseButton")]
		private Button releaseButton;

		[SceneBind("ControlButtonsRight/SaveBtn")]
		private Button saveButton;

		[SceneBind("TabHolder")]
		private Transform tabHolderTransform;

		[SceneBind("TabHolder/LidarCustom")]
		private CustomLidarController customLidarController;

		[SceneBind("TabHolder/LidarCustom/BaseBlock")]
		private RectTransform customLidarControllerBaseBlock;

		[SceneBind("Medal")]
		private CarMedalController carMedalController;

		[SceneBind("TechButtonBackground")]
		private Image techSwitcherBack;

		[SceneBind("TechButtonBackground/TechButton")]
		private BinaryImageSwitcher techSwitcher;

		[SceneBind("OnlyTeachRunText")]
		private Text onlyTeachRunText;

		[SceneBind("StopTrainingAttention")]
		private RectTransform StopTrainingAttention;

		[SceneBind("StopTrainingAttention/Accept")]
		private Button attentionButton;

		private CarQuest carQuest;

		private CarMedalCondition carMedalCondition;

		private Action<int> nextQuestCallback;

		private Func<int, CellObjects, System.Random, int> dataEncoder;

		private float moneyPerSecond;

		private DeepTrafficRunMode curRunMode;

		private HoverShow trainButtonHoverShow;

		private HoverShow teachButtonHoverShow;

		[SceneBind("ControlButtonsRight/TrainButton/PopupImage")]
		private Image trainButtonPopup;

		[SceneBind("TeachButton/PopupImage")]
		private Image teachButtonPopup;

		[SceneBind("ControlButtonsRight/TrainBeforeReleaseAttention")]
		private OpacitySin trainBeforeReleaseAttention;

		[SceneBind("TeachBeforeRunAttention")]
		private OpacitySin teachBeforeRunAttention;

		[SceneBind("LidarAttention")]
		private OpacitySin lidarAttention;

		[SceneBind("DeepTrafficGameController/Holder/RenderImage")]
		private MaskToAspect renderImage;

		private Color openTabColor = new Color(0.14901961f, 13f / 85f, 0.16078432f);

		private Color closeTabColor = new Color(1f, 1f, 1f, 0f);

		private int prevLidarSize;

		private bool teachBeforeRunAttentionSaved;

		private bool trainBeforeReleaseAttentionSaved;

		private AgentPresets oldPresets;

		private RedrawEnum state;

		private bool redraw;

		private float predictSpendMoney;

		public bool IsLidarWindowOpened()
		{
			return techSwitcher.SwitcherState == 1;
		}

		private void Stop()
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			testButton.gameObject.SetActive(value: true);
			deepTrafficGameController.OnEnd();
			teachButton.gameObject.SetActive(QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName);
			trainButton.gameObject.SetActive(value: true);
		}

		protected override void OnInit()
		{
			base.OnInit();
			SceneBindContainer.BindObjects(this, base.transform);
			setDefaultAttention.gameObject.SetActive(value: false);
			refreshAgentAttention.gameObject.SetActive(value: false);
			setDefaultAttention.Init();
			refreshAgentAttention.Init();
			stopButton.gameObject.SetActive(value: false);
			trainButton.gameObject.SetActive(value: true);
			deepTrafficQuestResultController.gameObject.SetActive(value: false);
			deepTrafficGameController.attentionButton = attentionButton;
			deepTrafficGameController.stopButton = stopButton;
			deepTrafficGameController.testButton = testButton;
			deepTrafficGameController.trainButton = trainButton;
			agentParametersController.Init();
			trainButton.onClick.AddListener(delegate
			{
				testButton.gameObject.SetActive(value: false);
				trainButton.gameObject.SetActive(value: false);
				if (customLidarController.gameObject.activeSelf)
				{
					techSwitcher.Switch();
				}
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_LearnButton");
				StartGameListener(DeepTrafficRunMode.Train);
			});
			trainButtonHoverShow = trainButton.GetComponent<HoverShow>();
			teachButtonHoverShow = teachButton.GetComponent<HoverShow>();
			testButton.onClick.AddListener(delegate
			{
				testButton.gameObject.SetActive(value: false);
				trainButton.gameObject.SetActive(value: false);
				QuestLine.GetCurrentQuest().testRunsOnQuest++;
				if (customLidarController.gameObject.activeSelf)
				{
					techSwitcher.Switch();
				}
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_TestButton");
				StartGameListener(DeepTrafficRunMode.Test);
				Logic.SendAnalytics("CONSTRUCTION_TASK_TEST", new Dictionary<string, object>
				{
					{
						"keyName",
						QuestLine.GetCurrentQuestName()
					},
					{
						"money spend",
						(int)QuestLine.GetCurrentQuest().moneySpent
					},
					{
						"test runs",
						QuestLine.GetCurrentQuest().testRunsOnQuest
					},
					{
						"time in quest",
						QuestLine.GetCurrentQuest().timeInQuest
					},
					{
						"teach runs",
						QuestLine.GetCurrentQuest().teachRunsInCar
					},
					{
						"train runs",
						QuestLine.GetCurrentQuest().trainRunsInCar
					}
				});
			});
			teachButton.onClick.AddListener(delegate
			{
				testButton.gameObject.SetActive(value: false);
				trainButton.gameObject.SetActive(value: false);
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_LearnButton");
				StartGameListener(DeepTrafficRunMode.Teach);
			});
			releaseButton.onClick.AddListener(delegate
			{
				if (customLidarController.gameObject.activeSelf)
				{
					techSwitcher.Switch();
				}
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_ReleaseButton");
				StartGameListener(DeepTrafficRunMode.Release);
			});
			releaseButton.gameObject.SetActive(value: false);
			saveButton.onClick.AddListener(delegate
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				Logic.UpdateGameSaves();
			});
			stopButton.onClick.AddListener(Stop);
			exitButton.onClick.AddListener(delegate
			{
				if (customLidarController.gameObject.activeSelf)
				{
					techSwitcher.Switch();
				}
				ActiveComponent.Model.construction.UpdateSpeed(ActiveComponent.Model.P.rememberedSpeed);
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
				base.gameObject.SetActive(value: false);
			});
			agentParametersController.newRandomSeedButton.onClick.AddListener(delegate
			{
				int? randomSeed = agentParametersController.RandomSeed;
				carQuest.CarController.seed = randomSeed.Value;
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				ReInitGameController();
			});
			agentParametersController.randomSeedInputField.onEndEdit.AddListener(delegate
			{
				int? randomSeed = agentParametersController.RandomSeed;
				if (randomSeed.HasValue)
				{
					carQuest.CarController.seed = randomSeed.Value;
					ReInitGameController();
				}
			});
			setDefaultButton.onClick.AddListener(delegate
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				StartCoroutine(SetDefaultAction());
			});
			if (ActiveComponent.Model.P.dontShowRefreshAgentAttention)
			{
				refreshAgentButton.onClick.AddListener(delegate
				{
					ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
					RefreshAgent();
				});
			}
			else
			{
				refreshAgentButton.onClick.AddListener(delegate
				{
					ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
					StartCoroutine(RefreshAgentAction());
				});
			}
			DynamicMoney.gameObject.SetActive(value: false);
			MoneySpent.gameObject.SetActive(value: false);
			techSwitcher.Init(CloseLidarTab, delegate
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				OpenLidarTab();
			});
			techSwitcherBack.enabled = false;
			Color color = Logic.GetColor("WARNING");
			trainBeforeReleaseAttention.GetComponent<Image>().color = color;
			teachBeforeRunAttention.GetComponent<Image>().color = color;
		}

		public void Init(CarQuest carQuest, Func<int, CellObjects, System.Random, int> dataEncoder, Action<int> nextQuestCallback, float moneyPerSecond)
		{
			base.Init();
			renderImage.Init();
			setDefaultButton.gameObject.SetActive(carQuest.AttentionBackgroundKeyName != "onlyTeach");
			this.carQuest = carQuest;
			this.dataEncoder = dataEncoder;
			this.nextQuestCallback = nextQuestCallback;
			this.moneyPerSecond = moneyPerSecond;
			teachButton.gameObject.SetActive(QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName);
			if (carQuest.CarEnv.enabledLidarCells == null)
			{
				carQuest.CarEnv.SetDefaultLidars();
			}
			agentParametersController.PopulationSizeMax = carQuest.CarParamsConstraints.populationSizeMax;
			agentParametersController.TrainStepsMax = carQuest.CarParamsConstraints.trainStepsMax;
			agentParametersController.Init(carQuest.CarSliderParamsBounds);
			deepTrafficGameController.Init(carQuest, carMedalCondition, carQuest.SuperEpochData, DeepTrafficRunMode.Train, dataEncoder, TrainEndCallback, EvalEndCallback, TeachEndCallback, carQuest.GetCurrentMedalNumber, carMedalController, carQuest.GetCurrentConstraintNumber, RefreshAgent);
			carMedalController.Init(carQuest, ChooseMedalAction);
			if (carQuest.GetCurrentConstraintNumber(carQuest.SuperEpochData.superEpochNumber) == -1)
			{
				ButtonInteractible(trainButton, interactible: false, "BLUE");
				ButtonInteractible(teachButton, interactible: false, "BLUE");
				trainButtonPopup.gameObject.SetActive(value: true);
				teachButtonPopup.gameObject.SetActive(value: true);
				trainButtonHoverShow.Init();
				teachButtonHoverShow.Init();
				trainButtonHoverShow.enabled = true;
				teachButtonHoverShow.enabled = true;
			}
			else
			{
				ButtonInteractible(trainButton, interactible: true, "BLUE");
				ButtonInteractible(teachButton, QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName, "BLUE");
				trainButtonHoverShow.enabled = false;
				teachButtonHoverShow.enabled = false;
				trainButtonPopup.gameObject.SetActive(value: false);
				teachButtonPopup.gameObject.SetActive(value: false);
			}
			tabHolderTransform.gameObject.SetActive(value: false);
			customLidarController.gameObject.SetActive(value: false);
			techSwitcherBack.gameObject.SetActive(Logic.GetBestLidarData() != null && carQuest.LidarVisible);
			if (carQuest.CarAttentionBack.TeachBeforeTrain)
			{
				teachBeforeRunAttention.gameObject.SetActive(carQuest.CarAgent.history == null);
				if (!trainButtonHoverShow.enabled)
				{
					ButtonInteractible(trainButton, !teachBeforeRunAttention.gameObject.activeSelf, "BLUE");
				}
				if (carQuest.CarAttentionBack.TrainBeforeRelease)
				{
					trainBeforeReleaseAttention.gameObject.SetActive(trainButton.interactable && !carQuest.CarController.evalSeed.HasValue);
				}
				else
				{
					trainBeforeReleaseAttention.gameObject.SetActive(value: false);
				}
			}
			else
			{
				teachBeforeRunAttention.gameObject.SetActive(value: false);
				trainBeforeReleaseAttention.gameObject.SetActive(value: false);
			}
			lidarAttention.gameObject.SetActive(ActiveComponent.Model.P.lidarTutorial == 0 && Logic.GetBestLidarData() != null && QuestLine.GetCurrentQuest().GetBaseQuest().As<CarQuest>()
				.LidarVisible);
			deepTrafficGameController.speedLayerControl.Init(0.5f, 3f, 0.5f);
			releaseButton.gameObject.SetActive(!QuestLine.GetCurrentQuest().IsCompleted());
			SetUpParmas(useDefault: false);
			Redraw();
			attentionButton.transform.parent.gameObject.SetActive(value: false);
			deepTrafficGameController.attentionButton = attentionButton;
		}

		private void OpenTab()
		{
			deepTrafficGameController.OpenTab(agentParametersController.transform.position.x - agentParametersController.Width / 2f + 2f);
			tabHolderTransform.gameObject.SetActive(value: true);
			deepTrafficGameController.Environment.gameObject.SetActive(value: false);
		}

		private void CloseTab()
		{
			deepTrafficGameController.CloseTab();
			tabHolderTransform.gameObject.SetActive(value: false);
			deepTrafficGameController.Environment.gameObject.SetActive(value: true);
		}

		private void OpenLidarTab()
		{
			OpenTab();
			customLidarController.Init(carQuest, deepTrafficGameController.RedrawLidar);
			customLidarController.gameObject.SetActive(value: true);
			customLidarControllerBaseBlock.gameObject.SetActive(value: false);
			prevLidarSize = carQuest.CarEnv.enabledCount;
			techSwitcherBack.enabled = true;
			if (ActiveComponent.Model.P.lidarTutorial == 0 && Logic.GetBestLidarData() != null)
			{
				ActiveComponent.Model.construction.RunAllTutorials();
				lidarAttention.gameObject.SetActive(value: false);
			}
		}

		private void CloseLidarTab()
		{
			CloseTab();
			customLidarController.gameObject.SetActive(value: false);
			techSwitcherBack.enabled = false;
			if (prevLidarSize != carQuest.CarEnv.enabledCount)
			{
				RefreshAgent();
			}
		}

		private IEnumerator SetDefaultAction()
		{
			setDefaultAttention.Redraw();
			setDefaultAttention.gameObject.SetActive(value: true);
			ActiveComponent.Program.cursor.SetPosition(setDefaultAttention.Accept.transform.position);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
			yield return setDefaultAttention.WaitForUserAction();
			if (setDefaultAttention.wait == BasicState.Accept)
			{
				SetUpParmas(useDefault: true, refreshAgent: true);
			}
			setDefaultAttention.gameObject.SetActive(value: false);
			if (customLidarController.gameObject.activeSelf)
			{
				customLidarController.Init(carQuest, deepTrafficGameController.RedrawLidar);
			}
		}

		private IEnumerator RefreshAgentAction()
		{
			refreshAgentAttention.Redraw();
			refreshAgentAttention.Redraw(hideState: false);
			refreshAgentAttention.gameObject.SetActive(value: true);
			ActiveComponent.Program.cursor.SetPosition(refreshAgentAttention.Accept.gameObject.transform.position);
			yield return refreshAgentAttention.WaitForUserAction();
			if (refreshAgentAttention.wait == BasicState.Accept)
			{
				RefreshAgent();
			}
			refreshAgentAttention.gameObject.SetActive(value: false);
			if (refreshAgentAttention.DontShowAgain.isOn)
			{
				ActiveComponent.Model.P.dontShowRefreshAgentAttention = true;
				refreshAgentButton.onClick.RemoveAllListeners();
				refreshAgentButton.onClick.AddListener(delegate
				{
					ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
					RefreshAgent();
				});
			}
		}

		private void RefreshAgent()
		{
			carQuest.CarAgent.weights = null;
			carQuest.CarController.evalSeed = null;
			carQuest.CarAgent.history = null;
			carQuest.SuperEpochData.Reset(full: true);
			ButtonInteractible(trainButton, !carQuest.CarAttentionBack.TeachBeforeTrain, "BLUE");
			ButtonInteractible(teachButton, QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName, "BLUE");
			teachButton.gameObject.SetActive(QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName);
			trainButtonHoverShow.enabled = false;
			teachButtonHoverShow.enabled = false;
			trainButtonPopup.gameObject.SetActive(value: false);
			teachButtonPopup.gameObject.SetActive(value: false);
			ChooseMedalAction(carMedalController.LastChosenMedal);
			ButtonInteractible(agentParametersController.newRandomSeedButton, interactible: true, "GREEN");
			Redraw();
			teachBeforeRunAttention.gameObject.SetActive(carQuest.CarAttentionBack.TeachBeforeTrain);
			trainBeforeReleaseAttention.gameObject.SetActive(value: false);
		}

		private void SetUpParmas(bool useDefault, bool refreshAgent = false)
		{
			if (useDefault)
			{
				carQuest.carAgent = (AgentPresets)Logic.GetCarAgentByKeyName(carQuest.AgentKeyName).Clone();
				carQuest.CarEnv.SetDefaultLidars();
			}
			agentParametersController.PopulationSize = carQuest.CarAgent.populationSize;
			agentParametersController.MutationRate = carQuest.CarAgent.mutationRate;
			agentParametersController.ParentsNumber = carQuest.CarAgent.parentsNumber;
			agentParametersController.ChromosomeMutationProbability = carQuest.CarAgent.chromosomeMutationProbability;
			agentParametersController.GeneMutationProbability = carQuest.CarAgent.geneMutationProbability;
			agentParametersController.Crossover = carQuest.CarAgent.useCrossover;
			agentParametersController.KillParents = carQuest.CarAgent.killParents;
			agentParametersController.RandomSeed = carQuest.CarController.seed;
			agentParametersController.TrainSteps = carQuest.CarController.iterationsToEvaluate;
			DisableUnusedParams();
			if (refreshAgent)
			{
				RefreshAgent();
			}
			deepTrafficGameController.RedrawLidar();
		}

		private void DisableUnusedParams()
		{
			AgentUnlockedParams carEnabledParams = carQuest.CarEnabledParams;
			DeepTrafficControllerUnlockedParams controllerEnabledParams = carQuest.ControllerEnabledParams;
			if (!carEnabledParams.chromosomeMutationProbability)
			{
				agentParametersController.ChromosomeMutationProbability = null;
			}
			if (!carEnabledParams.geneMutationProbability)
			{
				agentParametersController.GeneMutationProbability = null;
			}
			if (!carEnabledParams.killParents)
			{
				agentParametersController.KillParents = null;
			}
			if (!carEnabledParams.mutationRate)
			{
				agentParametersController.MutationRate = null;
			}
			if (!carEnabledParams.parentsNumber)
			{
				agentParametersController.ParentsNumber = null;
			}
			if (!carEnabledParams.populationSize)
			{
				agentParametersController.PopulationSize = null;
			}
			if (!carEnabledParams.useCrossover)
			{
				agentParametersController.Crossover = null;
			}
			if (!controllerEnabledParams.seed)
			{
				agentParametersController.RandomSeed = null;
			}
			if (!controllerEnabledParams.trainSteps)
			{
				agentParametersController.TrainSteps = null;
			}
			agentParametersController.gameObject.SetActive(!carQuest.CarAttentionBack.TeachBeforeTrain);
			onlyTeachRunText.gameObject.SetActive(carQuest.CarAttentionBack.TeachBeforeTrain);
		}

		private void DisableAttentionDuringGame()
		{
			teachBeforeRunAttentionSaved = teachBeforeRunAttention.gameObject.activeSelf;
			trainBeforeReleaseAttentionSaved = trainBeforeReleaseAttention.gameObject.activeSelf;
			teachBeforeRunAttention.gameObject.SetActive(value: false);
			trainBeforeReleaseAttention.gameObject.SetActive(value: false);
		}

		private void LoadAttentionAfterGame()
		{
			teachBeforeRunAttention.gameObject.SetActive(teachBeforeRunAttentionSaved);
		}

		private void ToggleUIInteractible(bool interactible)
		{
			ButtonInteractible(exitButton, interactible);
			setDefaultButton.interactable = interactible;
			refreshAgentButton.interactable = interactible;
			teachButton.interactable = interactible;
			techSwitcher.Interactible = interactible;
			teachButton.gameObject.SetActive(interactible && QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName);
			lidarAttention.gameObject.SetActive(ActiveComponent.Model.P.lidarTutorial == 0 && interactible && Logic.GetBestLidarData() != null && QuestLine.GetCurrentQuest().GetBaseQuest().As<CarQuest>()
				.LidarVisible);
			stopButton.gameObject.SetActive(!interactible);
		}

		private void StartGameListener(DeepTrafficRunMode runMode)
		{
			teachButton.gameObject.SetActive(value: false);
			predictSpendMoney = 0f;
			curRunMode = runMode;
			if (runMode == DeepTrafficRunMode.Train)
			{
				QuestLine.GetCurrentQuest().IncTrainRuns();
				agentParametersController.gameObject.SetActive(value: false);
				onlyTeachRunText.gameObject.SetActive(value: false);
			}
			else
			{
				agentParametersController.SetReadonly(value: true);
			}
			if (runMode == DeepTrafficRunMode.Teach)
			{
				QuestLine.GetCurrentQuest().IncTeachRuns();
			}
			ToggleUIInteractible(interactible: false);
			DisableAttentionDuringGame();
			carQuest.CarAgent.populationSize = agentParametersController.PopulationSize.Value;
			carQuest.CarAgent.mutationRate = agentParametersController.MutationRate.Value;
			carQuest.CarAgent.parentsNumber = agentParametersController.ParentsNumber.Value;
			carQuest.CarAgent.chromosomeMutationProbability = (float)agentParametersController.ChromosomeMutationProbability.Value;
			carQuest.CarAgent.geneMutationProbability = (float)agentParametersController.GeneMutationProbability.Value;
			carQuest.CarAgent.useCrossover = agentParametersController.Crossover.Value;
			carQuest.CarAgent.killParents = agentParametersController.KillParents.Value;
			carQuest.CarController.trainSteps = agentParametersController.TrainSteps.Value;
			carQuest.CarController.seed = agentParametersController.RandomSeed.Value;
			if (runMode != DeepTrafficRunMode.Test && runMode != DeepTrafficRunMode.Release)
			{
				carQuest.CarController.evalSeed = null;
			}
			carMedalCondition = new CarMedalCondition();
			deepTrafficGameController.Init(carQuest, carMedalCondition, carQuest.SuperEpochData, runMode, dataEncoder, TrainEndCallback, EvalEndCallback, TeachEndCallback, carQuest.GetCurrentMedalNumber, carMedalController, carQuest.GetCurrentConstraintNumber, RefreshAgent);
			oldPresets = (AgentPresets)carQuest.CarAgent.Clone();
			__EasyWinFirstLevel__();
			deepTrafficGameController.FullStart(carQuest.CarAgent, carQuest.AgentType);
			Redraw(RedrawEnum.Full);
			deepTrafficGameController.SetEnvState(state: true);
			if (carQuest.CarAttentionBack.TeachBeforeTrain)
			{
				deepTrafficGameController.useReplayToggle.transform.parent.gameObject.SetActive(value: false);
			}
		}

		private void __EasyWinFirstLevel__()
		{
			if (!(carQuest.KeyName == "NON_ML_CAR") || carQuest.CarAgent.history == null)
			{
				return;
			}
			float num = 0f;
			foreach (Episode<CellObjects[], DeepTrafficAction> item in carQuest.CarAgent.history)
			{
				num += (float)item.reward;
			}
			num /= (float)carQuest.CarAgent.history.Count;
			if (num >= 1f)
			{
				carQuest.CarAgent.history = null;
			}
		}

		private void ReInitGameController(bool save = true, DeepTrafficRunMode runMode = DeepTrafficRunMode.Train)
		{
			deepTrafficGameController.Init(carQuest, carMedalCondition, carQuest.SuperEpochData, runMode, dataEncoder, TrainEndCallback, EvalEndCallback, TeachEndCallback, carQuest.GetCurrentMedalNumber, carMedalController, carQuest.GetCurrentConstraintNumber, RefreshAgent);
			deepTrafficGameController.SetRenderRunMode(runMode);
			Redraw(RedrawEnum.Full);
			if (save)
			{
				Logic.UpdateGameSaves();
			}
		}

		public void TrainEndCallback()
		{
			LoadAttentionAfterGame();
			ToggleUIInteractible(interactible: true);
			agentParametersController.gameObject.SetActive(!carQuest.CarAttentionBack.TeachBeforeTrain);
			onlyTeachRunText.gameObject.SetActive(carQuest.CarAttentionBack.TeachBeforeTrain);
			if (!carQuest.CarController.evalSeed.HasValue)
			{
				carQuest.carAgent = oldPresets;
			}
			else
			{
				trainBeforeReleaseAttention.gameObject.SetActive(value: false);
			}
			deepTrafficGameController.SetEnvState(state: false);
			ReInitGameController();
			if (carQuest.GetCurrentConstraintNumber(carQuest.SuperEpochData.superEpochNumber) == -1)
			{
				ButtonInteractible(trainButton, interactible: false, "BLUE");
				ButtonInteractible(teachButton, QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName, "BLUE");
				teachButton.gameObject.SetActive(QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName);
				trainButtonHoverShow.enabled = true;
				teachButtonHoverShow.enabled = true;
			}
		}

		private void TestEndCallback(int medalNumber)
		{
			float num = (float)carMedalCondition.averageSpeed;
			deepTrafficQuestResultController.Init(num, DeepTrafficStatic.GetMoneyBySpeed(num), DeepTrafficStatic.GetMoneySpend(moneyPerSecond, carQuest.CarController.iterationsToEvaluate), medalNumber, DeepTrafficRunMode.Test, delegate
			{
				base.gameObject.SetActive(value: false);
				ActiveComponent.Model.P.Money -= DeepTrafficStatic.GetMoneySpend(moneyPerSecond, carQuest.CarController.iterationsToEvaluate);
				int num2 = QuestLine.GetCurrentQuest().GetRewardFromMedal(medalNumber) + DeepTrafficStatic.GetMoneyBySpeed((float)carMedalCondition.averageSpeed);
				ActiveComponent._controller.InitGainMoneyWindow(num2, num2 - DeepTrafficStatic.GetMoneySpend(moneyPerSecond, carQuest.CarController.iterationsToEvaluate));
				nextQuestCallback(medalNumber);
				Logic.SendAnalytics("CONSTRUCTION_TASK_RELEASED", new Dictionary<string, object>
				{
					{
						"keyName",
						QuestLine.GetCurrentQuestName()
					},
					{
						"money spend",
						(int)QuestLine.GetCurrentQuest().moneySpent
					},
					{ "speed", carMedalCondition.averageSpeed },
					{
						"test runs",
						QuestLine.GetCurrentQuest().testRunsOnQuest
					},
					{
						"time in quest",
						QuestLine.GetCurrentQuest().timeInQuest
					},
					{
						"teach runs",
						QuestLine.GetCurrentQuest().teachRunsInCar
					},
					{
						"train runs",
						QuestLine.GetCurrentQuest().trainRunsInCar
					},
					{
						"global release num",
						ActiveComponent.Model.globalSaves.passedTasksCou[QuestLine.GetCurrentQuestName()]
					}
				});
			});
			if (medalNumber > 0)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Test_Good");
			}
			else
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Test_Bad");
			}
			deepTrafficQuestResultController.gameObject.SetActive(value: true);
			deepTrafficGameController.SetEnvState(state: false);
			Redraw(RedrawEnum.Full);
		}

		private void EvalEndCallback(int medalNumber, bool earlyStop)
		{
			TeachEndCallback();
			if (earlyStop)
			{
				ReInitGameController();
				return;
			}
			if (curRunMode == DeepTrafficRunMode.Test)
			{
				TestEndCallback(medalNumber);
			}
			deepTrafficGameController.SetEnvState(state: false);
			ReInitGameController();
		}

		private void TeachEndCallback()
		{
			ToggleUIInteractible(interactible: true);
			LoadAttentionAfterGame();
			agentParametersController.SetReadonly(value: false);
			testButton.gameObject.SetActive(value: true);
			deepTrafficGameController.SetEnvState(state: false);
			ReInitGameController();
			teachBeforeRunAttention.gameObject.SetActive(value: false);
			if (curRunMode == DeepTrafficRunMode.Teach && carQuest.CarAttentionBack.TeachBeforeTrain && !trainButtonHoverShow.enabled)
			{
				ButtonInteractible(trainButton, interactible: true, "BLUE");
				if (carQuest.CarAttentionBack.TrainBeforeRelease)
				{
					ActiveComponent.Model.construction.PressTrainAfterTeachTutorial.gameObject.SetActive(ActiveComponent.Model.P.firstCarTeachTutorial == 0 && QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName);
				}
			}
		}

		private void ReleaseEndCallback(int medalNumber)
		{
			QuestLine.GetCurrentQuest().IncDeployAnalytics();
			float num = (float)carMedalCondition.averageSpeed;
			deepTrafficQuestResultController.Init(num, DeepTrafficStatic.GetMoneyBySpeed(num), DeepTrafficStatic.GetMoneySpend(moneyPerSecond, carQuest.CarController.iterationsToEvaluate), medalNumber, DeepTrafficRunMode.Release, delegate
			{
				base.gameObject.SetActive(value: false);
				nextQuestCallback(medalNumber);
			});
			deepTrafficQuestResultController.gameObject.SetActive(value: true);
			if (medalNumber > 0)
			{
				ActiveComponent.Model.globalSaves.passedTasksCou[QuestLine.GetCurrentQuestName()]++;
			}
			string sound = "Monokanal/WhileTrueLearn_Release_Bad";
			switch (medalNumber)
			{
			case 1:
				sound = "Monokanal/WhileTrueLearn_Release_Good_Bronze";
				break;
			case 2:
				sound = "Monokanal/WhileTrueLearn_Release_Good_Bronze";
				break;
			case 3:
				sound = "Monokanal/WhileTrueLearn_Release_Good_Bronze";
				break;
			}
			ActiveComponent.Sound.Play(sound);
			if (medalNumber > 0)
			{
				ReInitGameController();
			}
			deepTrafficGameController.SetEnvState(state: false);
			Redraw(RedrawEnum.Full);
		}

		public void Redraw(RedrawEnum state = RedrawEnum.States)
		{
			redraw = true;
			if (state < this.state)
			{
				this.state = state;
			}
		}

		private void PerformRedraw()
		{
			if (state <= RedrawEnum.States)
			{
				StaticReward.gameObject.SetActive(!QuestLine.GetCurrentQuest().IsCompleted());
				StaticServ.text = Logic.ColorTransform("BAD", Math.Round(moneyPerSecond, 2) + "$");
				DynamicMoney.gameObject.SetActive(value: false);
				MoneySpent.gameObject.SetActive(value: false);
				if (deepTrafficGameController.IsStrangeRunning())
				{
					DynamicMoney.gameObject.SetActive(value: false);
					MoneySpent.gameObject.SetActive(value: false);
					DynamicTime.gameObject.SetActive(value: false);
				}
			}
			int curIterNum = deepTrafficGameController.GetCurIterNum();
			int maxItersNum = deepTrafficGameController.GetMaxItersNum();
			float num = deepTrafficGameController.GetTimeCoef() * 2f;
			if (deepTrafficGameController.IsRunning())
			{
				DynamicTime.text = Logic.ColorTransform("TIME", Logic.RoundFloatTostr((float)(maxItersNum - curIterNum) / num) + " " + TextResources.GetString("SEC"));
			}
			else
			{
				DynamicTime.text = Logic.ColorTransform("TIME", Logic.RoundFloatTostr((float)maxItersNum / num) + " " + TextResources.GetString("SEC"));
			}
			redraw = false;
			state = RedrawEnum.OnlyTime;
		}

		private void ChooseMedalAction(int medalNumber)
		{
			TargetSpeed.text = Logic.ColorTransform("SPEED", Mathf.RoundToInt((float)carQuest.GetCarCondition(Mathf.Max(0, medalNumber)).CarMedalCondition.averageSpeed).ToString("d") + " " + TextResources.GetString("SPEED_TEXT"));
			StaticReward.text = Logic.ColorTransform("MONEY", ((medalNumber == -1) ? "0" : carQuest.GetRewardFromMedal(medalNumber).ToString("d")) + "$");
			TargetEpoch.text = Logic.ColorTransform("BLUE", (carQuest.SuperEpochData.superEpochNumber - 1).ToString("d") + " / " + carQuest.GetCarCondition(Mathf.Max(0, medalNumber)).CarConstraint.maxEpoch.ToString("d"));
		}

		public static void ButtonInteractible(Button button, bool interactible, string activeColor = "RED")
		{
			button.interactable = interactible;
			button.GetComponent<Image>().color = Logic.GetColor(interactible ? activeColor : "GREY");
		}

		private void FixedUpdate()
		{
			Redraw(RedrawEnum.OnlyTime);
			if (!(deepTrafficGameController == null) && deepTrafficGameController.IsRunning() && !deepTrafficGameController.IsReleaseRunning())
			{
				predictSpendMoney += moneyPerSecond * Time.fixedDeltaTime * (float)deepTrafficGameController.GetStepInFixedUpdate() / 2f;
			}
		}

		private void Update()
		{
			if (ActiveComponent.Model == null || ActiveComponent.Model.P == null)
			{
				return;
			}
			if (!ActiveComponent.Model.construction.WaitTutorial && !setDefaultAttention.gameObject.activeSelf && !refreshAgentAttention.gameObject.activeSelf && !deepTrafficQuestResultController.gameObject.activeSelf && !StopTrainingAttention.gameObject.activeSelf && !ActiveComponent.Model.construction.StopTrainingAttentionLastEpoch.gameObject.activeSelf && !ActiveComponent.Model.construction.LastEpochReachedTutorial.gameObject.activeSelf && !ActiveComponent.Model.construction.MeetTheMLTutorial.gameObject.activeSelf && !ActiveComponent.Model.construction.CrossoverTutorial.gameObject.activeSelf && !ActiveComponent.Model.construction.MutationTutorial.gameObject.activeSelf && !ActiveComponent.Model.construction.LidarTutorial.gameObject.activeSelf && !ActiveComponent.Model.construction.MutationRateTutorial.gameObject.activeSelf && !ActiveComponent.Model.construction.GeneticPopulationTutorial.gameObject.activeSelf && !ActiveComponent.Model.construction.MeetTheMLTutorial.gameObject.activeSelf)
			{
				if (ActiveComponent.Program.joyInput.yUp && !ActiveComponent.Model.construction.PressTestAfterTeachTutorial.gameObject.activeSelf && trainButton.gameObject.activeSelf && trainButton.interactable)
				{
					ActiveComponent.Model.construction.PressTrainAfterTeachTutorial.gameObject.SetActive(value: false);
					trainButton.onClick.Invoke();
					return;
				}
				if (ActiveComponent.Program.joyInput.xUp && !ActiveComponent.Model.construction.PressTrainAfterTeachTutorial.gameObject.activeSelf)
				{
					if (stopButton.gameObject.activeSelf)
					{
						Stop();
						return;
					}
					if (ActiveComponent.Model.construction.PressTestAfterTeachTutorial.gameObject.activeSelf)
					{
						ActiveComponent.Model.construction.PressTestAfterTeachTutorial.GetActiveBtn().onClick.Invoke();
						return;
					}
					if (testButton.gameObject.activeSelf && testButton.interactable)
					{
						testButton.onClick.Invoke();
						return;
					}
				}
			}
			if (redraw)
			{
				PerformRedraw();
			}
		}
	}
}
