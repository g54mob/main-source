using App.Data;
using ReinforcementLearning.Environment;

namespace DeepTraffic
{
	public class CarQuest : BaseGameQuest
	{
		public int wasReseted;

		public int BlocksLimit;

		public int CustomsLimit;

		public int ServersLimit;

		public int FirstTimeBorder;

		public int SecondTimeBorder;

		public int FirstFakeTimeBorder;

		public int SecondFakeTimeBorder;

		public string AgentType;

		public bool LidarVisible;

		public string AgentKeyName;

		public string AgentEnabledKeyName;

		public string EnvKeyName;

		public string ControllerKeyName;

		public string ControllerEnabledKeyName;

		public string LeftCarDatasKeyName;

		public string FrontCarDatasKeyName;

		public string BehindCarDatasKeyName;

		public string RightCarDatasKeyName;

		public string LeftStatList;

		public string FrontStatList;

		public string BehindStatList;

		public string RightStatList;

		public string AttentionBackgroundKeyName;

		public string CarSliderParamsBoundsKeyName;

		private DeepTrafficEnvPresets carEnv;

		public AgentPresets carAgent;

		public AgentUnlockedParams carEnabledParams;

		public DeepTrafficControllerUnlockedParams controllerEnabledParams;

		public CarCondition bronzeCondition;

		public CarCondition silverCondition;

		public CarCondition goldCondition;

		public SuperEpochData superEpochData;

		private CarDatas leftCarDatas;

		private CarDatas frontCarDatas;

		private CarDatas behindCarDatas;

		private CarDatas rightCarDatas;

		private CarSliderParamsBounds carSliderParamsBounds;

		private CarAttentionBackground carAttentionBack;

		public DeepTrafficEnvPresets CarEnv => carEnv ?? (carEnv = (DeepTrafficEnvPresets)Logic.GetCarEnvByKeyName(EnvKeyName).Clone());

		public AgentPresets CarAgent => carAgent ?? (carAgent = (AgentPresets)Logic.GetCarAgentByKeyName(AgentKeyName).Clone());

		public AgentUnlockedParams CarEnabledParams => carEnabledParams ?? (carEnabledParams = (AgentUnlockedParams)Logic.GetCarEnabledParamsByKeyName(AgentEnabledKeyName).Clone());

		public DeepTrafficControllerUnlockedParams ControllerEnabledParams => controllerEnabledParams ?? (controllerEnabledParams = (DeepTrafficControllerUnlockedParams)Logic.GetCarControllerEnabledParamByKeyName(ControllerEnabledKeyName).Clone());

		public DeepTrafficControllerPresets CarController => GetCarCondition(2).CarController;

		public CarConstraint CarParamsConstraints => GetCarCondition(2).CarConstraint;

		public SuperEpochData SuperEpochData => superEpochData ?? (superEpochData = new SuperEpochData(CarController.superEpochSize));

		public CarDatas LeftCarDatas => leftCarDatas ?? (leftCarDatas = (CarDatas)Logic.GetCarDatasByKeyName(LeftCarDatasKeyName).Clone());

		public CarDatas FrontCarDatas => frontCarDatas ?? (frontCarDatas = (CarDatas)Logic.GetCarDatasByKeyName(FrontCarDatasKeyName).Clone());

		public CarDatas BehindCarDatas => behindCarDatas ?? (behindCarDatas = (CarDatas)Logic.GetCarDatasByKeyName(BehindCarDatasKeyName).Clone());

		public CarDatas RightCarDatas => rightCarDatas ?? (rightCarDatas = (CarDatas)Logic.GetCarDatasByKeyName(RightCarDatasKeyName).Clone());

		public CarSliderParamsBounds CarSliderParamsBounds => carSliderParamsBounds ?? (carSliderParamsBounds = (CarSliderParamsBounds)Logic.GetCarSliderParamsBoundsByKeyName(CarSliderParamsBoundsKeyName).Clone());

		public CarAttentionBackground CarAttentionBack => carAttentionBack ?? (carAttentionBack = (CarAttentionBackground)Logic.GetCarAttentionBackgroundByKeyName(AttentionBackgroundKeyName).Clone());

		public override int GetRewardFromMedal(int medal)
		{
			return Reward + GetCondition(medal).ExtraMoney;
		}

		private bool CheckCarEnv(DeepTrafficEnvPresets envPresets)
		{
			if (envPresets.maxPatchesAhead == CarEnv.maxPatchesAhead && envPresets.maxPatchesBehind == CarEnv.maxPatchesBehind && envPresets.maxLanesSide == CarEnv.maxLanesSide && envPresets.carHeight == CarEnv.carHeight && envPresets.patchesAhead == CarEnv.patchesAhead && envPresets.lanesSide == CarEnv.lanesSide)
			{
				return envPresets.patchesBehind != CarEnv.patchesBehind;
			}
			return true;
		}

		private bool CheckAgentParams(AgentPresets agentPresets, AgentUnlockedParams unlockedParams)
		{
			if ((unlockedParams.chromosomeMutationProbability || !carEnabledParams.chromosomeMutationProbability || agentPresets.chromosomeMutationProbability == carAgent.chromosomeMutationProbability) && (unlockedParams.geneMutationProbability || !carEnabledParams.geneMutationProbability || agentPresets.geneMutationProbability == carAgent.geneMutationProbability) && (unlockedParams.killParents || !carEnabledParams.killParents || agentPresets.killParents == carAgent.killParents) && (unlockedParams.mutationRate || !carEnabledParams.mutationRate || agentPresets.mutationRate == carAgent.mutationRate) && (unlockedParams.parentsNumber || !carEnabledParams.parentsNumber || agentPresets.parentsNumber == carAgent.parentsNumber) && (unlockedParams.populationSize || !carEnabledParams.populationSize || agentPresets.populationSize == carAgent.populationSize) && (unlockedParams.useCrossover || !carEnabledParams.useCrossover || agentPresets.useCrossover == carAgent.useCrossover) && (unlockedParams.maxBufferSize || !carEnabledParams.maxBufferSize || agentPresets.maxBufferSize == carAgent.maxBufferSize) && (unlockedParams.percentile || !carEnabledParams.percentile || agentPresets.percentile == carAgent.percentile))
			{
				if (!unlockedParams.learningRate && carEnabledParams.learningRate)
				{
					return agentPresets.learningRate != carAgent.learningRate;
				}
				return false;
			}
			return true;
		}

		private bool CheckControllerParams(DeepTrafficControllerUnlockedParams unlockedParams, DeepTrafficControllerPresets otherControllerPresets, DeepTrafficControllerPresets thisControllerPresets)
		{
			if ((unlockedParams.seed || !ControllerEnabledParams.seed || otherControllerPresets.seed == thisControllerPresets.seed) && (unlockedParams.trainSteps || !ControllerEnabledParams.trainSteps || otherControllerPresets.trainSteps == thisControllerPresets.trainSteps) && otherControllerPresets.iterationsToEvaluate == thisControllerPresets.iterationsToEvaluate && otherControllerPresets.superEpochSize == thisControllerPresets.superEpochSize && otherControllerPresets.evalEpoch == thisControllerPresets.evalEpoch && otherControllerPresets.iterationBeforeYield == thisControllerPresets.iterationBeforeYield)
			{
				return otherControllerPresets.playerDrivingIterationUpperBound != thisControllerPresets.playerDrivingIterationUpperBound;
			}
			return true;
		}

		private bool CheckConstraints(CarConstraint otherConstraints, CarConstraint thisConstraints)
		{
			if (otherConstraints.populationSizeMax == thisConstraints.populationSizeMax && otherConstraints.trainStepsMax == thisConstraints.trainStepsMax)
			{
				return otherConstraints.maxEpoch != thisConstraints.maxEpoch;
			}
			return true;
		}

		private bool CheckCarMedalConditions(CarMedalCondition otherConditions, CarMedalCondition thisConditions)
		{
			return otherConditions.averageSpeed != thisConditions.averageSpeed;
		}

		public override void ReInitConstructionArea(bool resetInOut = true)
		{
			Logic.GetController().construction.ReInitConstructionArea(this);
		}

		public override bool Update(BaseQuest refQuest)
		{
			CarQuest carQuest = refQuest.As<CarQuest>();
			if (CheckCarEnv(carQuest.CarEnv))
			{
				return true;
			}
			try
			{
				if (CheckAgentParams(carQuest.CarAgent, carQuest.CarEnabledParams))
				{
					return true;
				}
			}
			catch
			{
				return true;
			}
			if (((carQuest.GetCarCondition(1) == null) ^ (GetCarCondition(0) == null)) || ((carQuest.GetCarCondition(1) == null) ^ (GetCarCondition(1) == null)) || ((carQuest.GetCarCondition(2) == null) ^ (GetCarCondition(2) == null)))
			{
				return true;
			}
			if ((GetCarCondition(0) != null && CheckControllerParams(carQuest.ControllerEnabledParams, carQuest.GetCarCondition(0).CarController, GetCarCondition(0).CarController)) || (GetCarCondition(1) != null && CheckControllerParams(carQuest.ControllerEnabledParams, carQuest.GetCarCondition(1).CarController, GetCarCondition(1).CarController)) || (GetCarCondition(2) != null && CheckControllerParams(carQuest.ControllerEnabledParams, carQuest.GetCarCondition(2).CarController, GetCarCondition(2).CarController)))
			{
				return true;
			}
			if ((GetCarCondition(0) != null && CheckConstraints(carQuest.GetCarCondition(0).CarConstraint, GetCarCondition(0).CarConstraint)) || (GetCarCondition(1) != null && CheckConstraints(carQuest.GetCarCondition(1).CarConstraint, GetCarCondition(1).CarConstraint)) || (GetCarCondition(2) != null && CheckConstraints(carQuest.GetCarCondition(2).CarConstraint, GetCarCondition(2).CarConstraint)))
			{
				return true;
			}
			if ((GetCarCondition(0) != null && CheckCarMedalConditions(carQuest.GetCarCondition(0).CarMedalCondition, GetCarCondition(0).CarMedalCondition)) || (GetCarCondition(1) != null && CheckCarMedalConditions(carQuest.GetCarCondition(1).CarMedalCondition, GetCarCondition(1).CarMedalCondition)) || (GetCarCondition(2) != null && CheckCarMedalConditions(carQuest.GetCarCondition(2).CarMedalCondition, GetCarCondition(2).CarMedalCondition)))
			{
				return true;
			}
			if (carQuest.UnlockedBlocks != UnlockedBlocks)
			{
				return true;
			}
			if (CheckStatLists(carQuest))
			{
				return true;
			}
			carEnabledParams = null;
			controllerEnabledParams = null;
			return false;
		}

		public bool CheckStatLists(CarQuest cq)
		{
			if (cq.LeftStatList != LeftStatList)
			{
				return true;
			}
			if (cq.FrontStatList != FrontStatList)
			{
				return true;
			}
			if (cq.BehindStatList != BehindStatList)
			{
				return true;
			}
			if (cq.RightStatList != RightStatList)
			{
				return true;
			}
			return false;
		}

		public void ClearDataToSave()
		{
			carEnabledParams = null;
			controllerEnabledParams = null;
			carAttentionBack = null;
			carSliderParamsBounds = null;
			rightCarDatas = null;
			frontCarDatas = null;
			behindCarDatas = null;
			leftCarDatas = null;
			bronzeCondition = null;
			silverCondition = null;
			goldCondition = null;
			carAgent = null;
			superEpochData.Reset(full: true);
		}

		public CarCondition GetCarCondition(int i)
		{
			if (i == 0 && ConditionBronze != "-")
			{
				return bronzeCondition ?? (bronzeCondition = (CarCondition)Logic.GetCarConditionByKeyName(ConditionBronze).Clone());
			}
			if (i <= 1 && ConditionSilver != "-")
			{
				return silverCondition ?? (silverCondition = (CarCondition)Logic.GetCarConditionByKeyName(ConditionSilver).Clone());
			}
			return goldCondition ?? (goldCondition = (CarCondition)Logic.GetCarConditionByKeyName(ConditionGold).Clone());
		}

		public override BaseCondition GetCondition(int i)
		{
			return GetCarCondition(i);
		}

		public bool CheckMedalConstraints(CarCondition medal, int curEpoch)
		{
			return medal?.CarConstraint.Check(curEpoch) ?? true;
		}

		public bool CheckMedalConstraints(int medalNumber, int curEpoch)
		{
			return CheckMedalConstraints(GetCarCondition(medalNumber), curEpoch);
		}

		public bool CheckMedalConditions(CarCondition medal, float averageSpeed)
		{
			return medal?.CarMedalCondition.CheckConditions(averageSpeed) ?? true;
		}

		public bool CheckMedalConditions(int medalNumber, float averageSpeed)
		{
			return CheckMedalConditions(GetCarCondition(medalNumber), averageSpeed);
		}

		public bool CheckMedal(CarCondition medal, int curEpoch, float averageSpeed)
		{
			if (CheckMedalConstraints(medal, curEpoch))
			{
				return CheckMedalConditions(medal, averageSpeed);
			}
			return false;
		}

		public bool CheckMedal(int medalNumber, int curEpoch, float averageSpeed)
		{
			return CheckMedal(GetCarCondition(medalNumber), curEpoch, averageSpeed);
		}

		public int GetCurrentConstraintNumber(int curEpoch)
		{
			if (CheckMedalConstraints(2, curEpoch))
			{
				return 2;
			}
			if (ConditionSilver != "-" && CheckMedalConstraints(1, curEpoch))
			{
				return 1;
			}
			if (ConditionBronze != "-" && CheckMedalConstraints(0, curEpoch))
			{
				return 0;
			}
			return -1;
		}

		public int GetCurrentMedalNumber(int curEpoch, float averageSpeed)
		{
			if (CheckMedal(2, curEpoch, averageSpeed))
			{
				return 2;
			}
			if (ConditionSilver != "-" && CheckMedal(1, curEpoch, averageSpeed))
			{
				return 1;
			}
			if (ConditionBronze != "-" && CheckMedal(0, curEpoch, averageSpeed))
			{
				return 0;
			}
			return -1;
		}

		public CarCondition GetCurrentMedal(int curEpoch, int averageSpeed)
		{
			return GetCarCondition(GetCurrentMedalNumber(curEpoch, averageSpeed));
		}

		public override void InitTaskController(TaskController taskController)
		{
			taskController.Acc.gameObject.SetActive(value: false);
			taskController.Time.gameObject.SetActive(value: false);
		}

		public override void End()
		{
			bool flag = true;
			foreach (CarQuest carQuest in Logic.GetStaticData().CarQuests)
			{
				if (carQuest.Locked == 0 && carQuest.VisibleToPlayer)
				{
					if (!QuestLine.IsLoadedInMemory(carQuest.KeyName))
					{
						flag = false;
						break;
					}
					if (!QuestLine.GetQuest(carQuest.KeyName).IsCompleted())
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				Steam.UnlockAchievement("ACHIEVEMENT_31");
			}
			base.End();
			CarAgent.history = null;
		}
	}
}
