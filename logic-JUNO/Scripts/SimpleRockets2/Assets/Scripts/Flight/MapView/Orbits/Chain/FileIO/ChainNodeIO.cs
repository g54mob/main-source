using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.FileIO
{
	public class ChainNodeIO
	{
		private class ChainNodeIOConstants
		{
			public const string DeltaV = "deltaV";

			public const string ManeuverNodeScriptType = "ManeuverNodeScript";

			public const string Period = "period";

			public const string Sensitivity = "sensitivity";

			public const string SoiEnterNodeScriptType = "SoiEnterNodeScript";

			public const string SoiExitNodeScriptType = "SoiExitNodeScript";

			public const string TrueAnomalyOnPreviousOrbit = "nuOnPrev";

			public const string Type = "type";
		}

		private const string NodeElementName = "Node";

		private ChainNodeManager _chainNodeManager;

		private ManeuverNodeManagerScript _maneuverNodeManager;

		private IChainableOrbit _rootNode;

		private string NodeChainQuickSaveLocation => Utilities.CombinePaths(Application.temporaryCachePath, "Sr2NodeChainQuickSave.xml");

		public ChainNodeIO(IIocContainer ioc, IChainableOrbit rootNode, ChainNodeManager chainNodeManager, ManeuverNodeManagerScript maneuverNodeManager)
		{
			_rootNode = rootNode;
			_chainNodeManager = chainNodeManager;
			_maneuverNodeManager = maneuverNodeManager;
		}

		public XElement GenerateXml()
		{
			return GenerateXmlFromNodeChain(_rootNode);
		}

		public void QuickSaveNodeChain()
		{
			try
			{
				GenerateXmlFromNodeChain(_rootNode).Save(NodeChainQuickSaveLocation);
				Debug.Log("Node chain saved to: " + NodeChainQuickSaveLocation);
			}
			catch (Exception ex)
			{
				Debug.LogError("Error saving node chain: " + ex.Message);
			}
		}

		public void RestoreNodeChain(XElement maneuverNodes)
		{
			try
			{
				RestoreNode(_rootNode, maneuverNodes.Element("Node"));
			}
			catch (Exception ex)
			{
				Debug.LogError("Error restoring nodes: " + ex.Message);
				_chainNodeManager.DestroyNodes();
			}
		}

		public void RestoreQuickSaveNodeChain()
		{
			if (!File.Exists(NodeChainQuickSaveLocation))
			{
				Debug.LogError("No node chain save file exists at " + NodeChainQuickSaveLocation + ", save one first.");
				return;
			}
			try
			{
				_chainNodeManager.DestroyNodes();
				XDocument xDocument = XDocument.Load(NodeChainQuickSaveLocation);
				RestoreNodeChain(xDocument.Element("NodeChain"));
			}
			catch (Exception ex)
			{
				Debug.LogError("Error restoring nodes: " + ex.Message);
				_chainNodeManager.DestroyNodes();
			}
		}

		private static List<XAttribute> GenerateXmlAttributes(IChainableOrbit chainNode)
		{
			ManeuverNodeScript maneuverNodeScript = chainNode as ManeuverNodeScript;
			return new List<XAttribute>
			{
				new XAttribute("type", chainNode.GetType().Name),
				new XAttribute("nuOnPrev", chainNode.TrueAnomalyOnPreviousOrbit),
				(maneuverNodeScript == null) ? null : new XAttribute("period", maneuverNodeScript.ReferenceOrbitPeriod),
				(maneuverNodeScript == null) ? null : new XAttribute("deltaV", Utilities.Vector3dToString(maneuverNodeScript.DeltaV)),
				(maneuverNodeScript == null) ? null : new XAttribute("sensitivity", maneuverNodeScript.DeltaVAdjustmentSensitivityLinear)
			};
		}

		private static XElement GenerateXmlFromNodeChain(IChainableOrbit node)
		{
			XElement result = null;
			if (node != null)
			{
				IChainableOrbit node2 = node.ListNode.Next?.Value;
				result = ((!(node is MapCraft)) ? new XElement("Node", GenerateXmlAttributes(node), GenerateXmlFromNodeChain(node2)) : new XElement("NodeChain", new XAttribute("craftId", (node.OrbitInfo.OrbitNode as CraftNode).NodeId), GenerateXmlFromNodeChain(node2)));
			}
			return result;
		}

		private static void LogRestoreNodeChainError(string desc)
		{
			Debug.LogError("Error restoring node chain: " + desc);
		}

		private string GetNodeStack(IChainableOrbit lastNode)
		{
			string text = string.Empty;
			while (lastNode != null)
			{
				text += lastNode.Name;
				lastNode = lastNode.ListNode.Previous?.Value;
				if (lastNode != null)
				{
					text += " <-";
				}
			}
			return text;
		}

		private ManeuverNodeScript RestoreManeuverNode(IChainableOrbit prevNode, XElement node)
		{
			double? doubleAttributeOrNull = node.GetDoubleAttributeOrNull("nuOnPrev");
			int? intAttributeOrNull = node.GetIntAttributeOrNull("period");
			Vector3d? vector3dAttributeOrNull = node.GetVector3dAttributeOrNull("deltaV");
			float? floatAttributeOrNull = node.GetFloatAttributeOrNull("sensitivity");
			ManeuverNodeScript maneuverNodeScript;
			if (!doubleAttributeOrNull.HasValue || !vector3dAttributeOrNull.HasValue)
			{
				maneuverNodeScript = null;
			}
			else
			{
				maneuverNodeScript = _maneuverNodeManager.AddManeuverNode(prevNode.OrbitInfo, doubleAttributeOrNull.Value, vector3dAttributeOrNull.Value, restoring: true);
				maneuverNodeScript.ReferenceOrbitPeriod = intAttributeOrNull.GetValueOrDefault();
				maneuverNodeScript.DeltaVAdjustmentSensitivityLinear = floatAttributeOrNull ?? 1f;
			}
			return maneuverNodeScript;
		}

		private void RestoreNode(IChainableOrbit prevNode, XElement node)
		{
			if (node == null)
			{
				return;
			}
			string value = node.Attribute("type").Value;
			bool flag = true;
			IChainableOrbit chainableOrbit;
			switch (value)
			{
			case "ManeuverNodeScript":
				chainableOrbit = RestoreManeuverNode(prevNode, node);
				if (chainableOrbit != null && (chainableOrbit as ManeuverNodeScript).Orphaned)
				{
					Debug.LogError("Error restoring node chain: Planned burn node was immediately orphaned after creation");
					chainableOrbit = null;
				}
				break;
			case "SoiEnterNodeScript":
				chainableOrbit = prevNode.CheckAndCreateEncounter();
				flag = VerifyEncounterCreated(chainableOrbit, value);
				break;
			case "SoiExitNodeScript":
				chainableOrbit = prevNode.CheckAndCreateEncounter();
				flag = VerifyEncounterCreated(chainableOrbit, value);
				break;
			default:
				Debug.LogError(value + " is not a supported type for restoring chain nodes");
				chainableOrbit = null;
				break;
			}
			if (!flag)
			{
				chainableOrbit = null;
				Debug.LogError("Error restoring chain nodes: expected " + value + " to be created.  Current node stack: " + GetNodeStack(prevNode));
			}
			if (chainableOrbit != null)
			{
				RestoreNode(chainableOrbit, node.Element("Node"));
			}
		}

		private bool VerifyEncounterCreated(IChainableOrbit node, string type)
		{
			if (node != null)
			{
				if (node.GetType().Name == type)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}
}
