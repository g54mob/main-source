using System.Collections.Generic;
using System.Linq;
using ModApi.Craft;
using ModApi.Craft.Parts;

namespace Assets.Scripts.Design.Staging
{
	public class StageCalculatorVersion1
	{
		public struct PartWrapper
		{
			public int Depth { get; set; }

			public PartData Part { get; set; }

			public StageGroup StageGroup { get; set; }
		}

		public class StageGroup
		{
			private List<PartData>[] _parts = new List<PartData>[3];

			public int Depth { get; set; }

			public void AddPart(PartData part, int version)
			{
				if (part.Config.StageActivationType == StageActivationType.Detacher)
				{
					AddPartToSubStage(part, 0);
				}
				else if (part.Config.StageActivationType == StageActivationType.Parachute || part.Config.StageActivationType == StageActivationType.Payload)
				{
					AddPartToSubStage(part, (version != 1) ? 1 : 2);
				}
				else
				{
					AddPartToSubStage(part, (version == 1) ? 1 : 0);
				}
			}

			public IEnumerable<PartData> GetParts(int subStage)
			{
				return _parts[subStage];
			}

			private void AddPartToSubStage(PartData part, int subStage)
			{
				if (_parts[subStage] == null)
				{
					_parts[subStage] = new List<PartData>();
				}
				_parts[subStage].Add(part);
			}
		}

		private const int MaxSubStages = 3;

		private List<PartData> _activatingParts = new List<PartData>();

		private ICommandPod _commandPod;

		private Queue<PartWrapper> _queue = new Queue<PartWrapper>();

		private Dictionary<int, StageGroup> _stageGroups = new Dictionary<int, StageGroup>();

		private Dictionary<int, bool> _visitedNodes = new Dictionary<int, bool>();

		public StageCalculatorVersion1(ICommandPod commandPod)
		{
			_commandPod = commandPod;
		}

		public StagingData CalculateStages(List<int> userStages, int version)
		{
			StageGroup stageGroup = new StageGroup();
			PartWrapper item = new PartWrapper
			{
				Part = _commandPod.Part,
				Depth = 0,
				StageGroup = stageGroup
			};
			_stageGroups[item.Depth] = stageGroup;
			_queue.Enqueue(item);
			while (_queue.Count > 0)
			{
				PartWrapper part = _queue.Dequeue();
				VisitNode(part, version);
			}
			StagingData stagingData = new StagingData();
			foreach (KeyValuePair<int, StageGroup> item3 in _stageGroups.OrderByDescending((KeyValuePair<int, StageGroup> x) => x.Key).ToList())
			{
				StageGroup value = item3.Value;
				for (int num = 0; num < 3; num++)
				{
					AddStage(stagingData, value, num);
				}
			}
			int[] array = userStages.OrderBy((int x) => x).ToArray();
			foreach (int num3 in array)
			{
				if (num3 >= 0 && num3 < stagingData.Stages.Count)
				{
					ActivationStage item2 = new ActivationStage();
					stagingData.Stages.Insert(num3, item2);
				}
			}
			for (int num4 = 0; num4 < stagingData.Stages.Count; num4++)
			{
				foreach (PartData part2 in stagingData.Stages[num4].Parts)
				{
					if (!part2.ActivationStageOverride)
					{
						part2.ActivationStage = num4;
					}
				}
			}
			foreach (PartData activatingPart in _activatingParts)
			{
				if (activatingPart.ActivationStageOverride)
				{
					if (activatingPart.ActivationStage < 0)
					{
						activatingPart.ActivationStage = 0;
					}
					while (stagingData.Stages.Count <= activatingPart.ActivationStage)
					{
						stagingData.Stages.Add(new ActivationStage());
					}
					stagingData.Stages[activatingPart.ActivationStage].Parts.Add(activatingPart);
				}
			}
			return stagingData;
		}

		private void AddStage(StagingData stagingData, StageGroup stageGroup, int subStage)
		{
			IEnumerable<PartData> parts = stageGroup.GetParts(subStage);
			if (parts != null)
			{
				ActivationStage activationStage = new ActivationStage();
				activationStage.Parts.AddRange(parts);
				stagingData.Stages.Add(activationStage);
			}
		}

		private void VisitNode(PartWrapper part, int version)
		{
			if (_visitedNodes.ContainsKey(part.Part.Id))
			{
				return;
			}
			_visitedNodes[part.Part.Id] = true;
			StageGroup stageGroup = part.StageGroup;
			if (part.Part.Config.StageActivationType != StageActivationType.None && part.Part.CommandPod == _commandPod.Part)
			{
				if (part.Part.ActivationStageOverride)
				{
					_activatingParts.Add(part.Part);
				}
				else
				{
					stageGroup.AddPart(part.Part, version);
				}
			}
			if (part.Part.Config.StageActivationType == StageActivationType.Detacher)
			{
				if (!_stageGroups.ContainsKey(part.Depth))
				{
					_stageGroups[part.Depth] = new StageGroup();
				}
				stageGroup = _stageGroups[part.Depth];
			}
			foreach (PartConnection partConnection in part.Part.PartConnections)
			{
				PartWrapper item = new PartWrapper
				{
					Part = partConnection.GetOtherPart(part.Part),
					Depth = part.Depth + 1,
					StageGroup = stageGroup
				};
				_queue.Enqueue(item);
			}
		}
	}
}
