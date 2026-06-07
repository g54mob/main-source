using System;
using System.Collections.Generic;
using System.Threading;
using Localization;
using ReinforcementLearning;
using ReinforcementLearning.Environment;
using UnityEngine;
using UnityEngine.UI;

namespace DeepTraffic
{
	public class DeepTrafficGameController : ActiveComponent
	{
		private enum CarMoveState
		{
			Forward = 0,
			Hold = 1,
			Backward = 2
		}

		private enum CarChangeLineState
		{
			Hold = 0,
			Left = 1,
			Right = 2
		}

		private DeepTrafficEnvironment renderEnv;

		private DeepTrafficEnvironment trainEnv;

		private DeepTrafficTrainer trainer;

		private DeepTrafficEnvPresets deepTrafficEnvPresets;

		private AgentPresets agentPresets;

		private DeepTrafficControllerPresets deepTrafficControllerPresets;

		private CarMedalCondition questConditions;

		private CarMedalController carMedalController;

		[SceneBind("Environment")]
		public CarEnvironment Environment;

		[SceneBind("PlayerSpeed/PlayerSpeedText")]
		private Text playerSpeedText;

		[SceneBind("SuperEpoch")]
		private SuperEpoch superEpoch;

		[SceneBind("LastEpochReached")]
		private RectTransform LastEpochReached;

		[SceneBind("DeepTrafficGameRenderer")]
		public DeepTrafficGameRenderer deepTrafficGameRenderer;

		[SceneBind("EvaluationProgress/ProgressSlider")]
		private Slider progressSlider;

		[SceneBind("EvaluationProgress/Text")]
		private Text progressText;

		[SceneBind("SpeedLayer")]
		public SpeedLayerControl speedLayerControl;

		[SceneBind("UseReplayField/Toggle")]
		public Toggle useReplayToggle;

		[SceneBind("Holder")]
		private Transform holder;

		public Button attentionButton;

		public Button stopButton;

		public Button testButton;

		public Button trainButton;

		[SceneBind("MobileControls")]
		public RectTransform MobileControls;

		[SceneBind("MobileControls/Hold")]
		public Button Hold;

		[SceneBind("MobileControls/Forward")]
		public Button Forward;

		[SceneBind("MobileControls/Backward")]
		public Button Backward;

		[SceneBind("MobileControls/Left")]
		public Button Left;

		[SceneBind("MobileControls/Right")]
		public Button Right;

		[SceneBind("MobileControls/Forward")]
		public Image ForwardImg;

		[SceneBind("MobileControls/Backward")]
		public Image BackwardImg;

		[SceneBind("MobileControls/Left")]
		public Image LeftImg;

		[SceneBind("MobileControls/Right")]
		public Image RightImg;

		private Color defaultBtnColor;

		private bool attentionWasShown;

		private Action trainEndCallback;

		private Action<int, bool> evalEndCallback;

		private Func<int, int> getConstraintNumber;

		private Func<int, float, int> getMedalNumber;

		private Action teachEndCallback;

		private Func<int, CellObjects, System.Random, int> encoder;

		private DeepTrafficRunMode runMode;

		private int renderIterationNumber;

		private DeepTrafficAction keyboardAction;

		private IAgentWrapper agent;

		private bool started;

		private bool freezed;

		private System.Random trainRandom;

		private System.Random renderRandom;

		private Thread trainThread;

		private SuperEpochData superEpochData;

		private AgentUnlockedParams agentUnlockedParams;

		private Action dropCarTrain;

		private CarMoveState carMoveState = CarMoveState.Hold;

		private CarChangeLineState carChangeLineState;

		private CarMoveState carPrevMoveState = CarMoveState.Hold;

		private Vector3 oldPosition;

		public int StepsPerUpdate => (int)(2f * speedLayerControl.Speed);

		public void SetEnvState(bool state)
		{
			Environment.SetState(state, renderEnv);
		}

		public int GetCurIterNum()
		{
			return renderIterationNumber;
		}

		public int GetMaxItersNum()
		{
			return deepTrafficControllerPresets.iterationsToEvaluate;
		}

		public float GetTimeCoef()
		{
			return 1f / Time.fixedDeltaTime;
		}

		public int GetStepInFixedUpdate()
		{
			return StepsPerUpdate;
		}

		public bool IsStrangeRunning()
		{
			if (runMode != DeepTrafficRunMode.Train)
			{
				return runMode == DeepTrafficRunMode.Teach;
			}
			return true;
		}

		public bool IsRunning()
		{
			if (started)
			{
				return !IsStrangeRunning();
			}
			return false;
		}

		public bool IsReleaseRunning()
		{
			if (IsRunning())
			{
				return runMode == DeepTrafficRunMode.Release;
			}
			return false;
		}

		private void InitParameters(CarQuest cq, CarMedalCondition questConditions, SuperEpochData superEpochData, DeepTrafficRunMode runMode, Func<int, CellObjects, System.Random, int> encoder, Action trainEndCallback, Action<int, bool> evalEndCallback, Action teachEndCallback, Func<int, float, int> getMedalNumber, CarMedalController carMedalController, Func<int, int> getConstraintNumber, Action dropCarTrain)
		{
			deepTrafficEnvPresets = cq.CarEnv;
			deepTrafficControllerPresets = cq.CarController;
			this.questConditions = questConditions;
			this.superEpochData = superEpochData;
			this.runMode = runMode;
			this.dropCarTrain = dropCarTrain;
			if (MobileControls != null)
			{
				MobileControls.gameObject.SetActive(this.runMode == DeepTrafficRunMode.Teach);
				EnableAllControlBrns();
			}
			this.encoder = encoder;
			this.trainEndCallback = trainEndCallback;
			this.evalEndCallback = evalEndCallback;
			this.teachEndCallback = teachEndCallback;
			this.getMedalNumber = getMedalNumber;
			this.carMedalController = carMedalController;
			this.getConstraintNumber = getConstraintNumber;
			agentUnlockedParams = cq.CarEnabledParams;
			if (runMode == DeepTrafficRunMode.Test || runMode == DeepTrafficRunMode.Release)
			{
				renderRandom = new System.Random(deepTrafficControllerPresets.evalSeed ?? deepTrafficControllerPresets.seed);
			}
			else
			{
				renderRandom = new System.Random(deepTrafficControllerPresets.seed);
			}
			if (runMode == DeepTrafficRunMode.Train)
			{
				trainRandom = new System.Random(deepTrafficControllerPresets.seed);
				trainEnv = new DeepTrafficEnvironment(deepTrafficEnvPresets, trainRandom);
				trainer = new DeepTrafficTrainer(deepTrafficControllerPresets, superEpochData);
			}
			renderEnv = new DeepTrafficEnvironment(deepTrafficEnvPresets, renderRandom);
		}

		private void HoldCar()
		{
			carMoveState = CarMoveState.Hold;
		}

		private void EnableAllControlBrns()
		{
			Forward.interactable = true;
			Backward.interactable = true;
			Left.interactable = true;
			Right.interactable = true;
		}

		private void ForwardCar()
		{
			carMoveState = CarMoveState.Forward;
			EnableAllControlBrns();
			Forward.interactable = false;
		}

		private void BackwardCar()
		{
			EnableAllControlBrns();
			carMoveState = CarMoveState.Backward;
			Backward.interactable = false;
		}

		private void LeftCar()
		{
			carPrevMoveState = carMoveState;
			carChangeLineState = CarChangeLineState.Left;
		}

		private void RightCar()
		{
			carPrevMoveState = carMoveState;
			carChangeLineState = CarChangeLineState.Right;
		}

		public void Init(CarQuest cq, CarMedalCondition questConditions, SuperEpochData superEpochData, DeepTrafficRunMode runMode, Func<int, CellObjects, System.Random, int> encoder, Action trainEndCallback, Action<int, bool> evalEndCallback, Action teachEndCallback, Func<int, float, int> getMedalNumber, CarMedalController carMedalController, Func<int, int> getConstraintNumber, Action dropCarTrain)
		{
			InitParameters(cq, questConditions, superEpochData, runMode, encoder, trainEndCallback, evalEndCallback, teachEndCallback, getMedalNumber, carMedalController, getConstraintNumber, dropCarTrain);
			if (!base.IsInited)
			{
				base.Init();
			}
			deepTrafficGameRenderer.Init(renderEnv);
		}

		protected override void OnInit()
		{
			base.OnInit();
			SceneBindContainer.BindObjects(this, base.transform);
			defaultBtnColor = ForwardImg.color;
			Forward.onClick.AddListener(ForwardCar);
			Backward.onClick.AddListener(BackwardCar);
			Left.onClick.AddListener(LeftCar);
			Right.onClick.AddListener(RightCar);
			MobileControls.gameObject.SetActive(value: false);
			superEpoch.gameObject.SetActive(value: false);
			playerSpeedText.transform.parent.gameObject.SetActive(value: false);
			progressSlider.transform.parent.gameObject.SetActive(value: false);
			useReplayToggle.transform.parent.gameObject.SetActive(value: false);
			speedLayerControl.Init(0.5f, 3f, 0.5f);
			playerSpeedText.text = Logic.ColorTransform("SPEED", deepTrafficEnvPresets.baseCarSpeed + " " + TextResources.GetString("SPEED_TEXT"));
			attentionButton.onClick.AddListener(delegate
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				attentionButton.transform.parent.gameObject.SetActive(value: false);
				stopButton.onClick.Invoke();
				ActiveComponent.Model.construction.PressTestAfterTeachTutorial.gameObject.SetActive(ActiveComponent.Model.P.firstCarTeachTutorial == 0 && QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName);
				ActiveComponent.Model.P.firstCarTeachTutorial = 1;
				Logic.UpdateGameSaves();
			});
			Environment.Init();
		}

		private void Freeze()
		{
			freezed = true;
			trainThread.Join();
			int num = getConstraintNumber(superEpoch.CurEpoch);
			if (!attentionWasShown && num == getMedalNumber(superEpoch.CurEpoch, superEpochData.meanSpeed.GetValueOrDefault()))
			{
				superEpoch.AutoEvolve = false;
				attentionWasShown = true;
				attentionButton.transform.parent.gameObject.SetActive(value: true);
				ActiveComponent.Program.cursor.SetPosition(attentionButton.transform.position);
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
			}
		}

		private void Unfreeze()
		{
			freezed = false;
			superEpochData.Reset();
			agent.UpdateEvalAgent();
			trainThread = new Thread((ThreadStart)delegate
			{
				trainer.TrainSuperEpoch(agent, trainEnv, agentPresets.history);
			});
			trainer.usePlayerReplay = useReplayToggle.isOn;
			trainThread.Start();
		}

		public void SetRenderRunMode(DeepTrafficRunMode runMode)
		{
			deepTrafficGameRenderer.SetRoadType(runMode);
		}

		public void FullStart(AgentPresets agentPresets, string agentType)
		{
			this.agentPresets = agentPresets;
			switch (agentType)
			{
			case "EliteState":
				agent = new DeepTrafficEliteStateAgent(deepTrafficEnvPresets, agentPresets, trainRandom, renderRandom, encoder);
				break;
			default:
				agent = new GeneticAgentWrapper(deepTrafficEnvPresets, agentPresets, trainRandom, renderRandom, encoder);
				break;
			case "DQN":
				agent = new DQNWrapper(deepTrafficEnvPresets, agentPresets, trainRandom, renderRandom, encoder);
				break;
			}
			playerSpeedText.transform.parent.gameObject.SetActive(value: true);
			if (runMode == DeepTrafficRunMode.Train)
			{
				superEpoch.Init(deepTrafficControllerPresets.superEpochSize, Freeze, Unfreeze, agentUnlockedParams, OnEnd, dropCarTrain);
				superEpoch.InitUpdateData(superEpochData);
				superEpoch.gameObject.SetActive(value: true);
				progressSlider.transform.parent.gameObject.SetActive(value: false);
				trainEnv.Reset();
				if (agentPresets.history != null)
				{
					useReplayToggle.transform.parent.gameObject.SetActive(value: true);
				}
				trainer.usePlayerReplay = useReplayToggle.isOn;
				superEpoch.ProgressMaxValue = deepTrafficControllerPresets.superEpochSize + 1;
				trainThread = new Thread((ThreadStart)delegate
				{
					trainer.TrainSuperEpoch(agent, trainEnv, agentPresets.history);
				});
			}
			else
			{
				useReplayToggle.transform.parent.gameObject.SetActive(value: false);
				superEpoch.gameObject.SetActive(value: false);
				progressSlider.transform.parent.gameObject.SetActive(value: true);
				progressSlider.maxValue = deepTrafficControllerPresets.iterationsToEvaluate;
				progressSlider.value = 0f;
				progressText.text = TextResources.GetString("EVAL_PROGRESS");
				if (runMode == DeepTrafficRunMode.Teach)
				{
					progressText.text = TextResources.GetString("TEACH_PROGRESS");
					progressSlider.maxValue = deepTrafficControllerPresets.playerDrivingIterationUpperBound;
					agentPresets.history = new List<Episode<CellObjects[], DeepTrafficAction>>();
					speedLayerControl.SaveState();
					speedLayerControl.Speed = 1f;
					speedLayerControl.gameObject.SetActive(value: false);
				}
			}
			carMedalController.ChooseComplexity(getConstraintNumber(superEpochData.superEpochNumber - 1), setCurrentCondition: false, lockGreater: true);
			carMedalController.Locked = true;
			deepTrafficGameRenderer.FullStart(runMode);
			renderIterationNumber = 0;
			started = true;
			freezed = false;
			attentionWasShown = false;
			if (runMode == DeepTrafficRunMode.Train)
			{
				trainThread.Start();
			}
		}

		private Episode<CellObjects[], DeepTrafficAction> RenderStep(DeepTrafficAction action)
		{
			Episode<CellObjects[], DeepTrafficAction> episode = renderEnv.Step(action);
			deepTrafficGameRenderer.AddToRoadSpeedList(renderEnv.PlayerSpeed);
			questConditions.averageSpeed += episode.reward + 50.0;
			return episode;
		}

		private void Update()
		{
			if (!started)
			{
				return;
			}
			playerSpeedText.text = Logic.ColorTransform("SPEED", renderEnv.FullState.player.speed + " " + TextResources.GetString("SPEED_TEXT"));
			if (runMode != DeepTrafficRunMode.Teach)
			{
				return;
			}
			if (ActiveComponent.Program.joyInput.areaMove && ActiveComponent.Program.joyInput.hardAreaMoveStartX && ActiveComponent.Program.joyInput.areaMoveDelta.x < 0f)
			{
				LeftImg.color = defaultBtnColor * Left.colors.pressedColor;
				RightImg.color = defaultBtnColor;
				LeftCar();
			}
			else if (ActiveComponent.Program.joyInput.areaMove && ActiveComponent.Program.joyInput.hardAreaMoveStartX && ActiveComponent.Program.joyInput.areaMoveDelta.x > 0f)
			{
				LeftImg.color = defaultBtnColor;
				RightImg.color = defaultBtnColor * Right.colors.pressedColor;
				RightCar();
			}
			else if (ActiveComponent.Program.joyInput.areaMove && ActiveComponent.Program.joyInput.areaMoveDelta.y > 0f)
			{
				LeftImg.color = defaultBtnColor;
				RightImg.color = defaultBtnColor;
				ForwardImg.color = defaultBtnColor * Right.colors.pressedColor;
				BackwardImg.color = defaultBtnColor;
				ForwardCar();
			}
			else if (ActiveComponent.Program.joyInput.areaMove && ActiveComponent.Program.joyInput.areaMoveDelta.y < 0f)
			{
				LeftImg.color = defaultBtnColor;
				RightImg.color = defaultBtnColor;
				ForwardImg.color = defaultBtnColor;
				BackwardImg.color = defaultBtnColor * Right.colors.pressedColor;
				BackwardCar();
			}
			keyboardAction = DeepTrafficAction.noAction;
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || carMoveState == CarMoveState.Forward)
			{
				keyboardAction = DeepTrafficAction.acelerate;
				if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
				{
					EnableAllControlBrns();
					carMoveState = CarMoveState.Forward;
					Forward.interactable = false;
				}
			}
			if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || carMoveState == CarMoveState.Backward)
			{
				keyboardAction = DeepTrafficAction.decelerate;
				if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
				{
					EnableAllControlBrns();
					carMoveState = CarMoveState.Backward;
					Backward.interactable = false;
				}
			}
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || carChangeLineState == CarChangeLineState.Left)
			{
				keyboardAction = DeepTrafficAction.goLeft;
				carChangeLineState = CarChangeLineState.Hold;
			}
			else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || carChangeLineState == CarChangeLineState.Right)
			{
				keyboardAction = DeepTrafficAction.goRight;
				carChangeLineState = CarChangeLineState.Hold;
			}
		}

		private bool RenderEnvFixedUpdate()
		{
			renderIterationNumber++;
			switch (runMode)
			{
			case DeepTrafficRunMode.Teach:
				agentPresets.history.Add(RenderStep(keyboardAction));
				if (renderIterationNumber >= deepTrafficControllerPresets.playerDrivingIterationUpperBound)
				{
					OnTeachEnd();
					return true;
				}
				break;
			case DeepTrafficRunMode.Train:
				RenderStep(agent.GetEvalAction(renderEnv.State));
				break;
			case DeepTrafficRunMode.Test:
			case DeepTrafficRunMode.Release:
				RenderStep(agent.GetEvalAction(renderEnv.State));
				if (renderIterationNumber >= deepTrafficControllerPresets.iterationsToEvaluate)
				{
					OnEvalEnd();
					return true;
				}
				break;
			}
			progressSlider.value = renderIterationNumber;
			return false;
		}

		private void FixedUpdate()
		{
			if (!started)
			{
				return;
			}
			for (int i = 0; i < StepsPerUpdate; i++)
			{
				if (RenderEnvFixedUpdate())
				{
					return;
				}
			}
			if (!freezed && runMode == DeepTrafficRunMode.Train)
			{
				if (superEpoch.CurEpoch != superEpochData.superEpochNumber)
				{
					carMedalController.ChooseComplexity(getConstraintNumber(superEpoch.CurEpoch), setCurrentCondition: false, lockGreater: true);
				}
				superEpoch.UpdateData(superEpochData, getMedalNumber(superEpoch.CurEpoch, superEpochData.meanSpeed.GetValueOrDefault()), getConstraintNumber(superEpochData.superEpochNumber) != -1);
				trainer.usePlayerReplay = useReplayToggle.isOn;
			}
		}

		private void Stop()
		{
			started = false;
			deepTrafficGameRenderer.OnEnd();
			playerSpeedText.transform.parent.gameObject.SetActive(value: false);
			carMedalController.Locked = false;
			testButton.gameObject.SetActive(value: true);
			trainButton.gameObject.SetActive(value: true);
		}

		public void OnEnd()
		{
			switch (runMode)
			{
			case DeepTrafficRunMode.Train:
				OnTrainEnd();
				break;
			case DeepTrafficRunMode.Test:
			case DeepTrafficRunMode.Release:
				OnEvalEnd();
				break;
			case DeepTrafficRunMode.Teach:
				ActiveComponent.Model.construction.PressTrainAfterTeachTutorial.gameObject.SetActive(ActiveComponent.Model.P.firstCarTeachTutorial == 0 && QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName);
				OnTeachEnd();
				break;
			}
		}

		private void OnTrainEnd()
		{
			if (trainThread != null && trainThread.IsAlive)
			{
				trainer.stop = true;
				trainThread.Join();
			}
			Stop();
			superEpoch.gameObject.SetActive(value: false);
			useReplayToggle.transform.parent.gameObject.SetActive(value: false);
			superEpochData.Reset();
			trainEndCallback();
		}

		private void OnEvalEnd()
		{
			Stop();
			progressSlider.transform.parent.gameObject.SetActive(value: false);
			questConditions.averageSpeed /= deepTrafficControllerPresets.iterationsToEvaluate;
			evalEndCallback(getMedalNumber(superEpochData.superEpochNumber - 1, (float)questConditions.averageSpeed), renderIterationNumber < deepTrafficControllerPresets.iterationsToEvaluate);
		}

		private void OnTeachEnd()
		{
			Stop();
			progressSlider.transform.parent.gameObject.SetActive(value: false);
			speedLayerControl.LoadState();
			speedLayerControl.gameObject.SetActive(value: true);
			teachEndCallback();
		}

		public void OpenTab(float newCenter)
		{
			Vector3 position = holder.position;
			Vector3 position2 = speedLayerControl.transform.position;
			Vector3 position3 = (oldPosition = base.transform.position);
			position3.x += newCenter + deepTrafficGameRenderer.HiddenRoadWidth / 2f - deepTrafficGameRenderer.HiddenRoadPosition.x;
			base.transform.position = position3;
			holder.position = position;
			speedLayerControl.transform.position = position2;
		}

		public void CloseTab()
		{
			Vector3 position = holder.position;
			Vector3 position2 = speedLayerControl.transform.position;
			base.transform.position = oldPosition;
			holder.position = position;
			speedLayerControl.transform.position = position2;
		}

		public void RedrawLidar(DeepTrafficEnvPresets presets = null)
		{
			if (presets != null)
			{
				deepTrafficGameRenderer.InitLidars(presets);
			}
			deepTrafficGameRenderer.RenderLidar(renderEnv.FullState.player, presets);
			deepTrafficGameRenderer.ColorLidar(renderEnv.FullState);
		}
	}
}
