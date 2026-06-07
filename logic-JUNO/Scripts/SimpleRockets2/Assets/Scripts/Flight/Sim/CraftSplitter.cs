using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	[Obfuscation(Exclude = true)]
	public static class CraftSplitter
	{
		public static void MergeCraftNode(CraftNode sourceCraftNode, CraftNode targetCraftNode)
		{
			List<IBodyScript> list = new List<IBodyScript>();
			foreach (BodyData body in sourceCraftNode.CraftScript.Data.Assembly.Bodies)
			{
				list.Add(body.BodyScript);
			}
			MoveBodiesToAssembly(list, sourceCraftNode.CraftScript.Data.Assembly, targetCraftNode.CraftScript.Data.Assembly);
			foreach (IBodyScript item in list)
			{
				((BodyScript)item).MoveToCraft((CraftScript)targetCraftNode.CraftScript);
				foreach (PartData part in item.Data.Parts)
				{
					part.IsRootPart = false;
					PartScript obj = part.PartScript as PartScript;
					obj.OnMovingToNewCraft(targetCraftNode.CraftScript);
					obj.OnMovedToNewCraft(targetCraftNode.CraftScript);
					obj.OnCraftLoaded(targetCraftNode.CraftScript, movedToNewCraft: true);
				}
			}
			while (sourceCraftNode.CraftScript.Data.Themes.Count > 0)
			{
				ThemeData themeData = sourceCraftNode.CraftScript.Data.Themes[0];
				if (targetCraftNode.CraftScript.Data.GetTheme(themeData.Id) == null)
				{
					targetCraftNode.CraftScript.Data.AddTheme(themeData);
				}
				sourceCraftNode.CraftScript.Data.RemoveTheme(themeData);
			}
			CraftScript sourceCraftScript = sourceCraftNode.CraftScript as CraftScript;
			(targetCraftNode.CraftScript as CraftScript).AbsorbCraftScript(sourceCraftScript);
			foreach (int initialCraftNodeId in sourceCraftNode.InitialCraftNodeIds)
			{
				if (!targetCraftNode.InitialCraftNodeIds.Contains(initialCraftNodeId))
				{
					targetCraftNode.InitialCraftNodeIds.Add(initialCraftNodeId);
				}
			}
			targetCraftNode.CopyInitialCraftNodeData(sourceCraftNode);
			if (targetCraftNode.ContractTrackingId == null)
			{
				targetCraftNode.ContractTrackingId = sourceCraftNode.ContractTrackingId;
				targetCraftNode.Name = sourceCraftNode.Name;
			}
			targetCraftNode.OnMergedWithCraftNode(targetCraftNode, sourceCraftNode);
			sourceCraftNode.OnMergedWithCraftNode(targetCraftNode, sourceCraftNode);
			sourceCraftNode.GameView.RemoveGameViewObject(sourceCraftNode, flightEnd: false);
			sourceCraftNode.DestroyCraft();
		}

		public static void ProcessDisconnectedBody(BodyData body, CraftScript craftScript)
		{
			List<IBodyScript> list = new List<IBodyScript>();
			GetConnectedBodies(body.BodyScript, list);
			if (DetermineCraftNodeEligibility(list))
			{
				MoveBodyToNewCraftNode(list, craftScript);
				return;
			}
			PartLookup partLookup = new PartLookup();
			foreach (IBodyScript item in list)
			{
				BodyScript obj = item as BodyScript;
				obj.IsDebris = true;
				obj.PartIsland = partLookup;
				foreach (PartData part in item.Data.Parts)
				{
					part.CommandPod = null;
					partLookup.AddPart(part);
				}
			}
			craftScript.UpdateFuelSourcesForDebris(partLookup);
		}

		public static void SplitCraftNode(CraftNode craftNode, ModApi.Craft.Assembly assembly)
		{
			CraftScript craftScript = CreateCraftScriptFromDisconnectedBodies(craftNode.CraftScript, assembly);
			Vector3d position = craftNode.GameView.ReferenceFrame.FrameToPlanetPosition(craftScript.FramePosition);
			Vector3d velocity = craftNode.GameView.ReferenceFrame.FrameToPlanetVelocity(craftScript.FrameVelocity);
			Quaterniond heading = craftNode.GameView.ReferenceFrame.FrameToPlanetRotation(craftScript.FrameHeading);
			CraftNode craftNode2 = new CraftNode(position, velocity, heading, craftNode.FlightState, craftNode.Parent.PlanetData.Mass, craftScript.Data, craftScript);
			craftNode2.HasCommandPod = craftScript.RootPart.Data.PartType.IsCommandPod;
			craftNode.Parent.AddChildNode(craftNode2);
			craftNode.FlightState.AddCraft(craftNode2, craftNode);
			craftScript.CraftNode = craftNode2;
			craftScript.gameObject.name = craftNode2.Name;
			craftNode2.Initialize();
			craftNode2.FlightStart();
			foreach (PartData part in assembly.Parts)
			{
				(part.PartScript as PartScript).OnMovedToNewCraft(craftScript);
				string text = part.Payload?.CraftTrackingId;
				if (part.PreviouslyActivated && !string.IsNullOrEmpty(text))
				{
					craftNode2.ContractTrackingId = text;
					craftNode.ContractTrackingId = null;
				}
			}
			craftNode.GameView.AddGameViewObject(craftNode2);
			craftScript.InitiateDragRecalculation();
			craftScript.IsPhysicsEnabled = true;
			if (craftNode.CraftScript.ActiveCommandPod != null && assembly.ContainsPart(craftNode.CraftScript.ActiveCommandPod.Part))
			{
				FlightSceneScript.Instance.ChangePlayersActiveCommandPodImmediate(craftNode.CraftScript.ActiveCommandPod, craftNode2, ignoreDistance: true);
				craftNode.CraftScript.SetActiveCommandPod(null);
			}
			craftNode.InitialCraftNodeIds = craftNode.CraftScript.Data.Assembly.Parts.Select((PartData x) => x.Config.InitialCraftNodeId).Distinct().ToList();
			craftNode2.InitialCraftNodeIds = craftNode2.CraftScript.Data.Assembly.Parts.Select((PartData x) => x.Config.InitialCraftNodeId).Distinct().ToList();
			craftNode2.CopyInitialCraftNodeData(craftNode);
			craftNode.ClearUnusedInitialCraftNodeData();
			craftNode.CraftScript.RaiseCraftSplitEvent();
		}

		private static CraftScript CreateCraftScriptFromDisconnectedBodies(ICraftScript sourceCraftScript, ModApi.Craft.Assembly assembly)
		{
			CraftScript craftScript = new GameObject("Craft-Disconnected")
			{
				layer = 31
			}.AddComponent<CraftScript>();
			CraftData craftData = CraftData.CreateEmptyCraftDataFromSource(sourceCraftScript.Data, assembly);
			Dictionary<Guid, bool> dictionary = new Dictionary<Guid, bool>();
			foreach (PartData part in assembly.Parts)
			{
				dictionary[part.ThemeData.Id] = true;
			}
			foreach (Guid key in dictionary.Keys)
			{
				foreach (ThemeData theme in sourceCraftScript.Data.Themes)
				{
					if (!(theme.Id == key))
					{
						continue;
					}
					ThemeData themeData = theme.Duplicate();
					craftData.AddTheme(themeData);
					foreach (PartData part2 in assembly.Parts)
					{
						if (part2.ThemeData == theme)
						{
							part2.ThemeData = themeData;
						}
					}
				}
			}
			craftScript.Transform.SetParent(sourceCraftScript.Transform.parent, worldPositionStays: false);
			craftScript.Initialize(craftData);
			craftScript.Transform.SetPositionAndRotation(assembly.Bodies[0].BodyScript.Transform.position, sourceCraftScript.Transform.rotation);
			craftScript.InitializeFromSourceCraft(sourceCraftScript);
			foreach (PartData part3 in assembly.Parts)
			{
				(part3.PartScript as PartScript).OnMovingToNewCraft(craftScript);
			}
			craftScript.OnCraftLoaded(movedToNewCraft: true, initialLaunch: false);
			foreach (BodyData body in assembly.Bodies)
			{
				(body.BodyScript as BodyScript).MoveToCraft(craftScript);
			}
			return craftScript;
		}

		private static bool DetermineCraftNodeEligibility(List<IBodyScript> bodyScripts)
		{
			Bounds? bounds = null;
			foreach (IBodyScript bodyScript in bodyScripts)
			{
				foreach (PartData part in bodyScript.Data.Parts)
				{
					if (part.Config.PreventDebris)
					{
						return true;
					}
					Bounds bounds2 = Utilities.CalculateBoundsOfGameObject(part.PartScript.GameObject);
					bounds = (bounds.HasValue ? new Bounds?(Utilities.ExpandBounds(bounds.Value, bounds2)) : new Bounds?(bounds2));
					if (bounds.Value.size.x > 10f || bounds.Value.size.y > 10f || bounds.Value.size.z > 10f)
					{
						return true;
					}
				}
			}
			return false;
		}

		private static void GetConnectedBodies(IBodyScript bodyScript, List<IBodyScript> connectedBodies)
		{
			if (connectedBodies.Contains(bodyScript))
			{
				return;
			}
			connectedBodies.Add(bodyScript);
			foreach (IBodyJoint joint in bodyScript.Joints)
			{
				if (!joint.PartConnection.IsDestroyed)
				{
					GetConnectedBodies(joint.OtherBody(bodyScript), connectedBodies);
				}
			}
		}

		private static void MoveBodiesToAssembly(IEnumerable<IBodyScript> bodies, ModApi.Craft.Assembly sourceAssembly, ModApi.Craft.Assembly targetAssembly)
		{
			List<PartCollision> list = new List<PartCollision>();
			foreach (IBodyScript body in bodies)
			{
				foreach (PartData part in body.Data.Parts)
				{
					sourceAssembly.RemovePart(part);
					targetAssembly.AddPart(part);
					foreach (PartConnection partConnection in part.PartConnections)
					{
						sourceAssembly.RemovePartConnection(partConnection);
						targetAssembly.AddPartConnection(partConnection);
					}
					foreach (PartCollision partCollision in sourceAssembly.GetPartCollisions(part))
					{
						if (sourceAssembly.RemovePartCollision(partCollision))
						{
							list.Add(partCollision);
						}
					}
				}
				sourceAssembly.RemoveBody(body.Data);
				targetAssembly.AddBody(body.Data);
			}
			foreach (PartCollision item in list)
			{
				if (targetAssembly.ContainsPart(item.PartA) && targetAssembly.ContainsPart(item.PartB))
				{
					targetAssembly.AddPartCollision(item);
				}
			}
		}

		private static void MoveBodyToNewCraftNode(List<IBodyScript> bodyScripts, CraftScript craftScript)
		{
			ModApi.Craft.Assembly assembly = new ModApi.Craft.Assembly();
			MoveBodiesToAssembly(bodyScripts, craftScript.Data.Assembly, assembly);
			PartData partData = null;
			foreach (PartData part in assembly.Parts)
			{
				if (partData == null && part.PartType.IsCommandPod)
				{
					partData = part;
				}
			}
			foreach (PartData part2 in assembly.Parts)
			{
				if (part2.CommandPod != null && !assembly.ContainsPart(part2.CommandPod))
				{
					part2.CommandPod = partData;
				}
			}
			if (partData == null)
			{
				partData = bodyScripts[0].Data.Parts[0];
			}
			partData.IsRootPart = true;
			SplitCraftNode(craftScript.CraftNode as CraftNode, assembly);
		}
	}
}
