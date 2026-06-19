#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using FullSerializerSave;
using UnityEngine;

namespace TH20
{
	public class ResearchNetworkGenerator
	{
		public struct NodeItem
		{
			public int Weight;

			public SharedInstance<ResearchNodeDefinition> NodeDefinition;
		}

		[InspectorHeader("Network Construction")]
		[fsProperty("minD")]
		public int MinDepth = 6;

		[fsProperty("maxD")]
		public int MaxDepth = 6;

		[fsProperty("minRB")]
		public int MinRootBranches = 3;

		[fsProperty("maxRB")]
		public int MaxRootBranches = 3;

		[fsProperty("minTB")]
		public int MinTotalBranches = 5;

		[fsProperty("maxTB")]
		public int MaxTotalBranches = 5;

		[InspectorHeader("Connections")]
		[fsProperty("maxPC")]
		public int MaxParentCount = 1;

		[InspectorHeader("Victory")]
		[fsProperty("v")]
		public Dictionary<CollaborativeNode.VictoryNodeType, SharedInstance<ResearchNodeDefinition>> VictoryConfiguration;

		[InspectorHeader("Non-Victory")]
		[fsProperty("nodes")]
		public List<SharedInstance<ResearchNodeDefinition>> NodeDefinitions;

		[fsProperty("wn")]
		public bool UseWeightedNodes;

		[fsProperty("nodegr")]
		public List<NodeItem> WeightedNodeDefinitions;

		[NonSerialized]
		private int _totalWeightCount;

		public ResearchNetwork GenerateNetwork(int seed)
		{
			_totalWeightCount = 0;
			if (UseWeightedNodes && WeightedNodeDefinitions != null)
			{
				for (int i = 0; i < WeightedNodeDefinitions.Count; i++)
				{
					_totalWeightCount += WeightedNodeDefinitions[i].Weight;
				}
			}
			LehmerRandomGenerator lehmerRandomGenerator = new LehmerRandomGenerator(seed);
			int num = lehmerRandomGenerator.NextRangeInt(MinRootBranches, MaxRootBranches + 1);
			int num2 = lehmerRandomGenerator.NextRangeInt(Mathf.Max(MinTotalBranches, num), MaxTotalBranches + 1);
			List<int> randomVictoryBranches = ResearchNetworkUtils.GetRandomVictoryBranches(lehmerRandomGenerator, num2, VictoryConfiguration.Count);
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int j = 0; j < num2; j++)
			{
				int num3 = lehmerRandomGenerator.NextRangeInt(MinDepth, MaxDepth + 1);
				list.Add(num3);
				if (j >= num)
				{
					list2.Add(lehmerRandomGenerator.NextRangeInt(1, num3));
				}
			}
			ResearchNetwork researchNetwork = new ResearchNetwork(new CollaborativeNode());
			for (int k = 0; k < list.Count; k++)
			{
				int num4 = list[k];
				if (k < num)
				{
					ResearchNetwork.Node node = researchNetwork.GetRootNode();
					for (int l = 0; l < num4; l++)
					{
						CollaborativeNode collaborativeNode = new CollaborativeNode();
						collaborativeNode.SetDefinition(GetNextRandomNodeDefinition(lehmerRandomGenerator));
						researchNetwork.AddChildToNode(node, collaborativeNode);
						node = collaborativeNode;
					}
					continue;
				}
				int num5 = list2[k - num];
				List<ResearchNetwork.Node> nodeList = new List<ResearchNetwork.Node>();
				researchNetwork.GetChildrenWithDepth(num5, ref nodeList);
				ResearchNetwork.Node node2 = nodeList[lehmerRandomGenerator.NextRangeInt(0, nodeList.Count)];
				for (int m = 0; m < num4 - num5; m++)
				{
					CollaborativeNode collaborativeNode2 = new CollaborativeNode();
					collaborativeNode2.SetDefinition(GetNextRandomNodeDefinition(lehmerRandomGenerator));
					researchNetwork.AddChildToNode(node2, collaborativeNode2);
					node2 = collaborativeNode2;
				}
			}
			ResearchNetworkUtils.FinaliseBranches(researchNetwork);
			int num6 = 0;
			foreach (int item in randomVictoryBranches)
			{
				CollaborativeNode obj = ResearchNetworkUtils.GetLeafNodeForBranch(researchNetwork, item) as CollaborativeNode;
				CollaborativeNode.VictoryNodeType victoryNodeType = VictoryConfiguration.Keys.ToList()[num6];
				VictoryConfiguration.TryGetValue(victoryNodeType, out var value);
				obj.SetDefinition(value.Instance);
				obj.SetIsVictoryNode(victoryNodeType);
				num6++;
			}
			return researchNetwork;
		}

		private ResearchNodeDefinition GetNextRandomNodeDefinition(LehmerRandomGenerator randomInstance)
		{
			if (!UseWeightedNodes)
			{
				return NodeDefinitions[randomInstance.NextRangeInt(0, NodeDefinitions.Count)].Instance;
			}
			int num = 0;
			double num2 = randomInstance.Next(0.0, _totalWeightCount);
			for (int i = 0; i < WeightedNodeDefinitions.Count; i++)
			{
				num += WeightedNodeDefinitions[i].Weight;
				if (num2 < (double)num)
				{
					return WeightedNodeDefinitions[i].NodeDefinition.Instance;
				}
			}
			Logging.Error(LogChannels.Online, "RB: GetNextRandomNodeDefinition returned a null node. Weighting are off!");
			return null;
		}
	}
}
