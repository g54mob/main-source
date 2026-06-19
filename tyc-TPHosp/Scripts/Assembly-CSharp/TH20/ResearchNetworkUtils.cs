using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public static class ResearchNetworkUtils
	{
		public class GridData
		{
			public int X;

			public int Y;

			public int RequiredRows;

			public int RowOffset;

			public Vector2 LocalPosition;
		}

		public static List<CollaborativeNode> FindVictoryNodes([NotNull] ResearchNetwork network)
		{
			List<CollaborativeNode> list = new List<CollaborativeNode>();
			for (int i = 0; i < network.GetNodeCount(); i++)
			{
				if (network[i] is CollaborativeNode collaborativeNode && collaborativeNode.IsVictoryNode)
				{
					list.Add(collaborativeNode);
				}
			}
			return list;
		}

		public static bool IsNodeCompleted([NotNull] CollaborativeNode node, [NotNull] CollaborativeProject project)
		{
			if (node.Definition == null)
			{
				return true;
			}
			int num = 0;
			foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum in project.ProjectData)
			{
				if (projectDatum.Value is CollaborativeProjectData collaborativeProjectData && collaborativeProjectData.ResearchData.CompletedNodeTimestamps.ContainsKey(node.NodeID))
				{
					num++;
				}
			}
			return num >= node.Definition.CompletionsRequired;
		}

		public static void CreateGridLayout([NotNull] ResearchNetwork network, out Dictionary<int, GridData> gridLayout, Vector2 spacing, Vector2 padding)
		{
			gridLayout = new Dictionary<int, GridData>();
			int rowsRequiredForBranch = GetRowsRequiredForBranch(network, network.GetRootNode());
			GridData gridData = new GridData();
			gridData.RequiredRows = rowsRequiredForBranch;
			gridData.RowOffset = 0;
			gridData.X = 0;
			gridData.Y = rowsRequiredForBranch / 2;
			gridData.LocalPosition = new Vector2((float)gridData.X * spacing.x + padding.x, (float)gridData.Y * spacing.y + padding.y);
			gridLayout.Add(0, gridData);
			SetGridData(network, ref gridLayout, network.GetRootNode(), 0, spacing, padding);
		}

		private static int GetRowsRequiredForBranch([NotNull] ResearchNetwork network, [NotNull] ResearchNetwork.Node node)
		{
			List<ResearchNetwork.Node> leafNodes = new List<ResearchNetwork.Node>();
			List<ResearchNetwork.Node> splitNodes = new List<ResearchNetwork.Node>();
			network.GetLeafNodes(node, ref leafNodes);
			network.GetSplitNodes(node, ref splitNodes);
			int num = leafNodes.Count;
			foreach (ResearchNetwork.Node item in splitNodes)
			{
				if (item.Children.Count > 0 && item.Children.Count % 2 == 0)
				{
					num++;
				}
			}
			return num;
		}

		private static void SetGridData([NotNull] ResearchNetwork network, [NotNull] ref Dictionary<int, GridData> gridLayout, ResearchNetwork.Node node, int rowOffset, Vector2 spacing, Vector3 padding)
		{
			int num = rowOffset;
			bool flag = node.Children.Count % 2 == 0;
			int num2 = node.Children.Count / 2;
			int num3 = 0;
			foreach (int child in node.Children)
			{
				ResearchNetwork.Node node2 = network.GetNode(child);
				int rowsRequiredForBranch = GetRowsRequiredForBranch(network, node2);
				GridData gridData = new GridData();
				gridData.RequiredRows = rowsRequiredForBranch;
				if (flag)
				{
					gridData.X = node2.Depth;
					gridData.Y = ((num3 < num2) ? (num + rowsRequiredForBranch / 2) : (num + rowsRequiredForBranch / 2 + 1));
					gridData.RowOffset = ((num3 < num2) ? num : (num + 1));
				}
				else
				{
					gridData.X = node2.Depth;
					gridData.Y = num + rowsRequiredForBranch / 2;
					gridData.RowOffset = num;
				}
				gridData.LocalPosition = new Vector2((float)gridData.X * spacing.x + padding.x, (float)gridData.Y * spacing.y + padding.y);
				gridLayout[child] = gridData;
				SetGridData(network, ref gridLayout, node2, gridData.RowOffset, spacing, padding);
				num3++;
				num += gridData.RequiredRows;
			}
		}

		public static void FinaliseBranches([NotNull] ResearchNetwork network)
		{
			ResearchNetwork.Node rootNode = network.GetRootNode();
			if (rootNode != null)
			{
				rootNode.BranchID = 0;
				SetBranchIdForChildren(network, rootNode);
			}
		}

		private static int SetBranchIdForChildren([NotNull] ResearchNetwork network, [NotNull] ResearchNetwork.Node node)
		{
			int num = node.BranchID;
			for (int i = 0; i < node.Children.Count; i++)
			{
				int index = node.Children[i];
				ResearchNetwork.Node node2 = network.GetNode(index);
				if (node2 != null)
				{
					node2.BranchID = num;
					num = SetBranchIdForChildren(network, node2);
					if (i != node.Children.Count - 1)
					{
						num++;
					}
				}
			}
			return num;
		}

		public static List<int> GetRandomVictoryBranches(LehmerRandomGenerator randomInstance, int branchCount, int victoryNodeCount)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < branchCount; i++)
			{
				list2.Add(i);
			}
			for (int j = 0; j < victoryNodeCount; j++)
			{
				int index = randomInstance.NextRangeInt(0, list2.Count);
				int item = list2[index];
				list.Add(item);
				list2.RemoveAt(index);
			}
			return list;
		}

		public static ResearchNetwork.Node GetLeafNodeForBranch([NotNull] ResearchNetwork network, int branchID)
		{
			List<ResearchNetwork.Node> leafNodes = new List<ResearchNetwork.Node>();
			network.GetLeafNodes(0, ref leafNodes);
			foreach (ResearchNetwork.Node item in leafNodes)
			{
				if (item.BranchID == branchID)
				{
					return item;
				}
			}
			return null;
		}

		public static int GetMinNumParticipants(CollaborativeProjectDefinition projectDefinition)
		{
			ResearchNetworkGenerator researchNetworkGenerator = projectDefinition?.NetworkGenerator?.Instance;
			if (researchNetworkGenerator == null)
			{
				return 1;
			}
			int num = 1;
			foreach (SharedInstance<ResearchNodeDefinition> nodeDefinition in researchNetworkGenerator.NodeDefinitions)
			{
				num = Mathf.Max(nodeDefinition.Instance.CompletionsRequired, num);
			}
			foreach (KeyValuePair<CollaborativeNode.VictoryNodeType, SharedInstance<ResearchNodeDefinition>> item in researchNetworkGenerator.VictoryConfiguration)
			{
				num = Mathf.Max(item.Value.Instance.CompletionsRequired, num);
			}
			return num;
		}

		public static ResearchNetworkGenerator GetLatestNetworkGenerator(CollaborativeProjectDefinition projectDefinition, out int version)
		{
			version = 0;
			ResearchNetworkGenerator result = null;
			if (projectDefinition.VersionNetworkGenerator != null)
			{
				foreach (KeyValuePair<int, SharedInstance<ResearchNetworkGenerator>> item in projectDefinition.VersionNetworkGenerator)
				{
					int key = item.Key;
					if (version <= key && !item.Value.IsNull())
					{
						result = item.Value.Instance;
						version = key;
					}
				}
			}
			if (version > 0)
			{
				return result;
			}
			return projectDefinition.NetworkGenerator.Instance;
		}

		public static ResearchNetworkGenerator GetNetworkGenerator(CollaborativeProjectDefinition projectDefinition, int version)
		{
			if (version == 0)
			{
				return projectDefinition.NetworkGenerator.Instance;
			}
			if (!projectDefinition.VersionNetworkGenerator.TryGetValue(version, out var value))
			{
				return null;
			}
			return value.Instance;
		}
	}
}
