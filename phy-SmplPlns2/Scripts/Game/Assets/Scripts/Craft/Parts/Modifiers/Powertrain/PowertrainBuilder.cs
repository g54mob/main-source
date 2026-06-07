using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public static class PowertrainBuilder
	{
		public static PowertrainNode BuildPowertrainTree(IPowertrainNode startPart)
		{
			if (startPart == null)
			{
				return null;
			}
			return FindRootEngine(startPart)?.CreatePowertrainNode(null);
		}

		public static PowertrainNode CreateOutputNode(PowertrainNode node, PartScript partScript, List<IPowertrainNode> magicSinks = null, int outputAttachPointIndex = 0, string outputTransformName = "PowertrainOutput", float maxComponentGearRatio = 1f)
		{
			Transform parentConnectionTransform = Utilities.FindFirstGameObjectMyselfOrChildren(outputTransformName, partScript.gameObject)?.transform;
			PartConnection partConnection = partScript.Part.AttachPoints[outputAttachPointIndex].PartConnections.FirstOrDefault();
			IPowertrainNode otherPowertrainPartNode = GetOtherPowertrainPartNode(partScript.Part, partConnection);
			PowertrainNodeConnection powertrainNodeConnection = new PowertrainNodeConnection(node, partConnection, parentConnectionTransform);
			powertrainNodeConnection.MaxTotalGearRatio = (node.InputConnection?.MaxTotalGearRatio ?? 1f) * maxComponentGearRatio;
			PowertrainNode powertrainNode = null;
			if (magicSinks == null || magicSinks.Count == 0)
			{
				powertrainNode = otherPowertrainPartNode?.CreatePowertrainNode(powertrainNodeConnection);
			}
			else
			{
				powertrainNode = new WirelessPowertrainNode(partScript).CreatePowertrainNode(powertrainNodeConnection);
				if (otherPowertrainPartNode != null)
				{
					PowertrainNodeConnection inputConnection = new PowertrainNodeConnection(powertrainNode, partConnection, parentConnectionTransform);
					PowertrainNode powertrainNode2 = otherPowertrainPartNode.CreatePowertrainNode(inputConnection);
					if (powertrainNode2 != null)
					{
						powertrainNode.AddChild(powertrainNode2);
					}
				}
				foreach (IPowertrainNode magicSink in magicSinks)
				{
					PowertrainNodeConnection inputConnection2 = new PowertrainNodeConnection(powertrainNode, null, null);
					PowertrainNode powertrainNode3 = magicSink.CreatePowertrainNode(inputConnection2);
					if (powertrainNode3 != null)
					{
						powertrainNode.AddChild(powertrainNode3);
					}
				}
			}
			if (powertrainNode != null)
			{
				node.AddChild(powertrainNode);
			}
			return powertrainNode;
		}

		public static IPowertrainNode GetOtherPowertrainPartNode(PartData sourcePart, PartConnection sourcePartConnection)
		{
			if (sourcePartConnection != null)
			{
				PartData otherPart = sourcePartConnection.GetOtherPart(sourcePart);
				if (otherPart != null)
				{
					return otherPart.PartScript.GetModifierWithInterface<IPowertrainNode>();
				}
			}
			return null;
		}

		public static string PrintNode(PowertrainNode node, int indent = 0)
		{
			string text = new string(' ', indent * 4) + node.Name + "\n";
			foreach (PowertrainNode child in node.Children)
			{
				text += PrintNode(child, indent + 1);
			}
			return text;
		}

		private static IPowertrainNode FindRootEngine(IPowertrainNode start)
		{
			Queue<IPowertrainNode> queue = new Queue<IPowertrainNode>();
			HashSet<IPowertrainNode> hashSet = new HashSet<IPowertrainNode>();
			queue.Enqueue(start);
			hashSet.Add(start);
			while (queue.Count > 0)
			{
				IPowertrainNode powertrainNode = queue.Dequeue();
				if (powertrainNode is JEngineScript)
				{
					return powertrainNode;
				}
				foreach (IPowertrainNode connectedPowertrainPart in GetConnectedPowertrainParts(powertrainNode))
				{
					if (!hashSet.Contains(connectedPowertrainPart))
					{
						hashSet.Add(connectedPowertrainPart);
						queue.Enqueue(connectedPowertrainPart);
					}
				}
			}
			return null;
		}

		private static IEnumerable<IPowertrainNode> GetConnectedPowertrainParts(IPowertrainNode current)
		{
			PartScript partScript = current as PartScript;
			if (partScript == null)
			{
				yield break;
			}
			foreach (PartConnection partConnection in partScript.Part.PartConnections)
			{
				IPowertrainNode powertrainNode = partConnection.GetOtherPart(partScript.Part)?.PartScript.GetModifierWithInterface<IPowertrainNode>();
				if (powertrainNode != null)
				{
					yield return powertrainNode;
				}
			}
		}
	}
}
