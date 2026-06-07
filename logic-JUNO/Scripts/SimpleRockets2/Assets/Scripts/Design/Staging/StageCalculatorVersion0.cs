using System.Collections.Generic;
using System.Linq;
using ModApi.Craft;
using ModApi.Craft.Parts;

namespace Assets.Scripts.Design.Staging
{
	public class StageCalculatorVersion0
	{
		public struct PartWrapper
		{
			public int Depth { get; set; }

			public PartData Part { get; set; }

			public int Priority
			{
				get
				{
					int result = 0;
					switch (Part.Config.StageActivationType)
					{
					case StageActivationType.Detacher:
						result = 5;
						break;
					case StageActivationType.Fairing:
						result = 4;
						break;
					case StageActivationType.Engine:
						result = 3;
						break;
					case StageActivationType.LandingLeg:
						result = 2;
						break;
					case StageActivationType.Parachute:
					case StageActivationType.Payload:
						result = 1;
						break;
					}
					return result;
				}
			}
		}

		private List<PartWrapper> _activatingParts = new List<PartWrapper>();

		private ICommandPod _commandPod;

		private Queue<PartWrapper> _queue = new Queue<PartWrapper>();

		private Dictionary<int, bool> _visitedNodes = new Dictionary<int, bool>();

		public StageCalculatorVersion0(ICommandPod commandPod)
		{
			_commandPod = commandPod;
		}

		public StagingData CalculateStages(List<int> userStages)
		{
			PartWrapper item = new PartWrapper
			{
				Part = _commandPod.Part,
				Depth = 0
			};
			StagingData stagingData = new StagingData();
			_queue.Enqueue(item);
			while (_queue.Count > 0)
			{
				PartWrapper part = _queue.Dequeue();
				VisitNode(part);
			}
			ActivationStage activationStage = new ActivationStage();
			stagingData.Stages.Add(activationStage);
			foreach (PartWrapper activatingPart in _activatingParts)
			{
				if (!activatingPart.Part.ActivationStageOverride)
				{
					if (StageContainsOtherActivationTypes(activationStage, activatingPart.Part.Config.StageActivationType))
					{
						activationStage = new ActivationStage();
						stagingData.Stages.Add(activationStage);
					}
					activationStage.Parts.Add(activatingPart.Part);
				}
			}
			int[] array = userStages.OrderBy((int x) => x).ToArray();
			foreach (int num2 in array)
			{
				if (num2 >= 0 && num2 < stagingData.Stages.Count)
				{
					ActivationStage item2 = new ActivationStage();
					stagingData.Stages.Insert(num2, item2);
				}
			}
			for (int num3 = 0; num3 < stagingData.Stages.Count; num3++)
			{
				foreach (PartData part2 in stagingData.Stages[num3].Parts)
				{
					part2.ActivationStage = num3;
				}
			}
			foreach (PartWrapper activatingPart2 in _activatingParts)
			{
				if (activatingPart2.Part.ActivationStageOverride)
				{
					if (activatingPart2.Part.ActivationStage < 0)
					{
						activatingPart2.Part.ActivationStage = 0;
					}
					while (stagingData.Stages.Count <= activatingPart2.Part.ActivationStage)
					{
						stagingData.Stages.Add(new ActivationStage());
					}
					stagingData.Stages[activatingPart2.Part.ActivationStage].Parts.Add(activatingPart2.Part);
				}
			}
			return stagingData;
		}

		private bool StageContainsOtherActivationTypes(ActivationStage stage, StageActivationType activationType)
		{
			if (stage.Parts.Count > 0)
			{
				foreach (PartData part in stage.Parts)
				{
					if (part.Config.StageActivationType != StageActivationType.None && part.Config.StageActivationType != activationType)
					{
						return true;
					}
				}
			}
			return false;
		}

		private void VisitNode(PartWrapper part)
		{
			if (_visitedNodes.ContainsKey(part.Part.Id))
			{
				return;
			}
			_visitedNodes[part.Part.Id] = true;
			if (part.Part.Config.StageActivationType != StageActivationType.None && part.Part.CommandPod == _commandPod.Part)
			{
				int index = _activatingParts.Count;
				for (int i = 0; i < _activatingParts.Count; i++)
				{
					PartWrapper partWrapper = _activatingParts[i];
					if (part.Depth > partWrapper.Depth)
					{
						index = i;
						break;
					}
					if (part.Depth == partWrapper.Depth && part.Priority > partWrapper.Priority)
					{
						index = i;
						break;
					}
				}
				_activatingParts.Insert(index, part);
			}
			foreach (PartConnection partConnection in part.Part.PartConnections)
			{
				PartWrapper item = new PartWrapper
				{
					Part = partConnection.GetOtherPart(part.Part),
					Depth = part.Depth + 1
				};
				_queue.Enqueue(item);
			}
		}
	}
}
