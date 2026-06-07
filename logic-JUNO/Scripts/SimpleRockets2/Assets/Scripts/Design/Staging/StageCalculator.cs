using System.Collections.Generic;
using ModApi.Craft;
using ModApi.Craft.Parts;

namespace Assets.Scripts.Design.Staging
{
	public class StageCalculator
	{
		public const int Version = 2;

		private ICommandPod _commandPod;

		public StageCalculator(ICommandPod commandPod)
		{
			_commandPod = commandPod;
		}

		public StagingData CalculateStages(List<int> userStages)
		{
			if (_commandPod.StageCalculationVersion == 0)
			{
				return new StageCalculatorVersion0(_commandPod).CalculateStages(userStages);
			}
			return new StageCalculatorVersion1(_commandPod).CalculateStages(userStages, _commandPod.StageCalculationVersion);
		}

		public StagingData GetStages()
		{
			List<PartData> list = new List<PartData>();
			foreach (PartData part in _commandPod.Part.PartScript.CraftScript.Data.Assembly.Parts)
			{
				if (!part.PartScript.Disconnected && part.Config.StageActivationType != StageActivationType.None && part.CommandPod == _commandPod.Part)
				{
					list.Add(part);
				}
			}
			StagingData stagingData = new StagingData();
			ActivationStage item = new ActivationStage();
			stagingData.Stages.Add(item);
			foreach (PartData item2 in list)
			{
				if (item2.ActivationStage >= 0)
				{
					while (stagingData.Stages.Count <= item2.ActivationStage)
					{
						stagingData.Stages.Add(new ActivationStage());
					}
					stagingData.Stages[item2.ActivationStage].Parts.Add(item2);
				}
			}
			return stagingData;
		}
	}
}
