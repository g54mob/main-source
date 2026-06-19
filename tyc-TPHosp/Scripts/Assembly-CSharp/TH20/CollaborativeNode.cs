using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class CollaborativeNode : ResearchNetwork.Node
	{
		public enum VictoryNodeType
		{
			None = 0,
			Alpha = 1,
			Gamma = 2,
			Omega = 3,
			Lambda = 4,
			Tau = 5,
			Xi = 6,
			Pi = 7,
			Psi = 8,
			Yellow = 9,
			Green = 10,
			Blue = 11,
			Purple = 12,
			Orange = 13
		}

		public enum State
		{
			Hidden = 0,
			Discovered = 1,
			Completed = 2,
			Debug = 3
		}

		private ResearchNodeDefinition _definition;

		private VictoryNodeType _victoryNodeType;

		[NonSerialized]
		private State _status;

		[NonSerialized]
		private int _numCompletions;

		[NonSerialized]
		private bool _completedByLocalPlayer;

		public ResearchNodeDefinition Definition => _definition;

		public bool IsVictoryNode => _victoryNodeType != VictoryNodeType.None;

		public VictoryNodeType VictoryType => _victoryNodeType;

		public State Status => _status;

		public int NumCompletions => _numCompletions;

		public int CompletionsRequired
		{
			get
			{
				if (Definition == null)
				{
					return -1;
				}
				return Definition.CompletionsRequired;
			}
		}

		public float PercentageCompleted
		{
			get
			{
				if (CompletionsRequired <= 0)
				{
					return 1f;
				}
				return (float)NumCompletions / (float)CompletionsRequired;
			}
		}

		public bool IsCompletedByLocalPlayer => _completedByLocalPlayer;

		public bool IsCompleted => _status == State.Completed;

		public void SetDefinition(ResearchNodeDefinition definition)
		{
			_definition = definition;
		}

		public void SetIsVictoryNode(VictoryNodeType nodeType)
		{
			_victoryNodeType = nodeType;
		}

		public void RefreshStatus(IResearchNetworkState networkState)
		{
			_numCompletions = networkState.GetNumNodeCompletions(NodeID);
			_completedByLocalPlayer = networkState.IsNodeCompletedByLocalPlayer(NodeID);
			if (networkState.IsShowAllMode())
			{
				_status = State.Debug;
				return;
			}
			if (networkState.IsAllCompletedMode())
			{
				_status = State.Completed;
				return;
			}
			if (networkState.IsAllDiscoveredMode())
			{
				_status = State.Discovered;
				return;
			}
			if (Definition == null)
			{
				_status = State.Completed;
				return;
			}
			if (_numCompletions >= Definition.CompletionsRequired)
			{
				_status = State.Completed;
				return;
			}
			if (Depth <= 1)
			{
				_status = State.Discovered;
				return;
			}
			List<ResearchNetwork.Node> parentList = new List<ResearchNetwork.Node>();
			List<ResearchNetwork.Node> childList = new List<ResearchNetwork.Node>();
			networkState.GetAllNodeParents(NodeID, ref parentList);
			networkState.GetAllNodeChildren(NodeID, ref childList);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			for (int i = 0; i < parentList.Count; i++)
			{
				int num = Mathf.Abs(Depth - parentList[i].Depth);
				if (num > 2)
				{
					continue;
				}
				CollaborativeNode collaborativeNode = parentList[i] as CollaborativeNode;
				if (collaborativeNode?.Definition == null)
				{
					continue;
				}
				ResearchNodeDefinition definition = collaborativeNode.Definition;
				if (definition == null || networkState.GetNumNodeCompletions(collaborativeNode.NodeID) >= definition.CompletionsRequired)
				{
					switch (num)
					{
					case 1:
						flag2 = true;
						break;
					case 2:
						flag3 = true;
						break;
					}
				}
			}
			for (int j = 0; j < childList.Count; j++)
			{
				CollaborativeNode collaborativeNode2 = childList[j] as CollaborativeNode;
				if (collaborativeNode2?.Definition == null)
				{
					continue;
				}
				ResearchNodeDefinition definition2 = collaborativeNode2.Definition;
				if (networkState.GetNumNodeCompletions(collaborativeNode2.NodeID) >= definition2.CompletionsRequired)
				{
					switch (Mathf.Abs(Depth - collaborativeNode2.Depth))
					{
					case 1:
						flag2 = true;
						break;
					case 2:
						flag3 = true;
						break;
					default:
						flag = true;
						break;
					}
				}
			}
			if (flag2)
			{
				_status = State.Discovered;
			}
			else if (flag3 || flag)
			{
				_status = State.Hidden;
			}
			else
			{
				_status = State.Hidden;
			}
		}
	}
}
