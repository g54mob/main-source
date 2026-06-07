using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.CelestialData;
using ModApi.Common.Extensions;
using ModApi.Exceptions;
using ModApi.Flight.Sim;
using ModApi.Mods;
using ModApi.Scripts.State;
using ModApi.State;
using ModApi.State.MapView;
using UnityEngine;

namespace Assets.Scripts.State
{
	public class FlightStateData : IFlightStateData
	{
		public const int CurrentXmlVersion = 3;

		private List<ICraftNodeData> _craftNodes = new List<ICraftNodeData>();

		private List<ICraftNodeData> _deletedCraftsPending = new List<ICraftNodeData>();

		private MapViewData _mapViewData;

		private List<PlanetNodeData> _planetNodes = new List<PlanetNodeData>();

		public IReadOnlyList<ICraftNodeData> CraftNodes => _craftNodes;

		public string DirectoryPath { get; private set; }

		public RequiredModsData FlightStateRequiredMods { get; private set; }

		public string LegacySolarSystemId { get; private set; }

		public MapViewData MapView => _mapViewData;

		public int MinCraftNodeId { get; set; }

		public ModelType ModelType { get; private set; }

		public string Path { get; private set; }

		public PlanetarySystemFileData PlanetarySystem { get; private set; }

		public CelestialFileReference PlanetarySystemFileReference { get; private set; }

		public IReadOnlyList<PlanetNodeData> PlanetNodes => _planetNodes;

		public int PlayerNodeId { get; set; }

		public bool PreventSave { get; private set; }

		public double Time { get; set; }

		public double TotalFlightTimeInRealtimeSeconds { get; set; }

		public FlightStateData(string path, CelestialFileReference planetarySystemReferenceOverride = null)
		{
			ModelType = ModelType.Static;
			Path = path;
			DirectoryPath = new FileInfo(path).DirectoryName;
			XElement xElement = XDocument.Load(path).Element("FlightState");
			int intAttribute = Utilities.GetIntAttribute(xElement, "xmlVersion", 1);
			if (intAttribute > 3)
			{
				throw new XmlVersionException();
			}
			if (intAttribute < 3)
			{
				FlightStateXmlVersionUpdater.Upgrade(xElement, intAttribute);
			}
			Time = xElement.GetDoubleAttribute("time");
			TotalFlightTimeInRealtimeSeconds = xElement.GetDoubleAttribute("totalFlightTimeInRealtimeSeconds");
			PlayerNodeId = xElement.GetIntAttribute("playerNodeId", 1);
			MinCraftNodeId = xElement.GetIntAttribute("minNodeId", 1);
			PreventSave = xElement.GetBoolAttribute("preventSave");
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			XElement xElement2 = xElement.Element("PlanetarySystem");
			if (xElement2 != null || planetarySystemReferenceOverride != null)
			{
				PlanetarySystemFileReference = ((planetarySystemReferenceOverride == null) ? CelestialFileReference.LoadFromXml(xElement2) : planetarySystemReferenceOverride);
				PlanetarySystem = celestialDatabase.GetPlanetarySystem(PlanetarySystemFileReference);
			}
			else
			{
				LegacySolarSystemId = (string)xElement.Attribute("solarSystemId");
				if (LegacySolarSystemId == "__default__")
				{
					PlanetarySystemFileReference = CelestialFileReference.CreateWithFileId(null, celestialDatabase.DefaultPlanetarySystemV1Id);
					PlanetarySystem = celestialDatabase.GetPlanetarySystem(celestialDatabase.DefaultPlanetarySystemV1Id);
				}
				else if (LegacySolarSystemId == "__StockJuno__")
				{
					PlanetarySystemFileReference = CelestialFileReference.CreateWithFileId(null, celestialDatabase.DefaultPlanetarySystemV2Id);
					PlanetarySystem = celestialDatabase.GetPlanetarySystem(celestialDatabase.DefaultPlanetarySystemV2Id);
				}
			}
			FlightStateRequiredMods = new RequiredModsData(xElement.Element("RequiredMods"));
			foreach (XElement item2 in xElement.Element("Nodes").Elements())
			{
				if (item2.Name == "Craft")
				{
					CraftNodeDataStatic craftNodeDataStatic = new CraftNodeDataStatic(item2);
					_craftNodes.Add(craftNodeDataStatic);
					if (craftNodeDataStatic.CraftPartCount == 0)
					{
						Debug.Log("Flight State contains a craft with zero parts. The craft will be automatically removed. Path: '" + Path + "'");
						RemoveCraftNode(craftNodeDataStatic);
					}
				}
				else
				{
					if (!(item2.Name == "Planet"))
					{
						throw new NotImplementedException("Only craft and planet nodes are supported at this time.");
					}
					PlanetNodeData item = new PlanetNodeData(item2);
					_planetNodes.Add(item);
				}
			}
			_mapViewData = new MapViewData(() => Game.Instance.FlightScene.IocContainer, xElement.Element("MapView"));
		}

		public static void ChangePlanetarySystemReference(XDocument xml, Guid planetarySystemId)
		{
			XElement content = CelestialFileReference.CreateWithFileId(null, planetarySystemId).SaveToXml("PlanetarySystem");
			XElement xElement = xml.Root.Element("PlanetarySystem");
			if (xElement == null)
			{
				xml.Root.AddFirst(content);
			}
			else
			{
				xElement.ReplaceWith(content);
			}
		}

		public void AddCraftNode(ICraftNodeData craftNodeData)
		{
			_craftNodes.Add(craftNodeData);
		}

		public void AddPlanetNodeData(PlanetNodeData planetNodeData)
		{
			_planetNodes.Add(planetNodeData);
		}

		public void ChangePlanetarySystem(CelestialFile planetarySystemFile, bool useFilePath)
		{
			CelestialFileReference planetarySystemFileReference = (useFilePath ? CelestialFileReference.CreateWithFilePath(null, planetarySystemFile) : CelestialFileReference.CreateWithFileId(null, planetarySystemFile));
			ChangePlanetarySystem(planetarySystemFileReference);
		}

		public void ChangePlanetarySystem(CelestialFileReference planetarySystemFileReference)
		{
			PlanetarySystemFileData planetarySystem = Game.Instance.CelestialDatabase.GetPlanetarySystem(planetarySystemFileReference);
			if (planetarySystem == null)
			{
				string text = planetarySystemFileReference.FileId?.ToString() ?? planetarySystemFileReference.FilePath.RelativePath;
				throw new Exception("Unable to find planetary system: '" + text + "'");
			}
			PlanetarySystemFileReference = planetarySystemFileReference;
			PlanetarySystem = planetarySystem;
		}

		public bool CheckCraftXmlExists(int nodeId)
		{
			return File.Exists(GetCraftXmlFilePath(nodeId));
		}

		public XDocument GenerateXml()
		{
			XElement xElement = new XElement("FlightState");
			xElement.SetAttributeValue("xmlVersion", 3);
			xElement.SetAttributeValue("time", Time);
			xElement.SetAttributeValue("totalFlightTimeInRealtimeSeconds", TotalFlightTimeInRealtimeSeconds);
			xElement.SetAttributeValue("playerNodeId", PlayerNodeId);
			xElement.SetAttributeValue("minNodeId", MinCraftNodeId);
			if (PlanetarySystemFileReference != null)
			{
				xElement.Add(PlanetarySystemFileReference.SaveToXml("PlanetarySystem"));
			}
			XElement orCreateElement = xElement.GetOrCreateElement("Nodes");
			foreach (PlanetNodeData planetNode in PlanetNodes)
			{
				orCreateElement.Add(planetNode.GenerateXml());
			}
			foreach (ICraftNodeData craftNode in CraftNodes)
			{
				orCreateElement.Add(craftNode.GenerateXml());
			}
			xElement.Add(MapView.GenerateXml());
			FlightStateRequiredMods = GetAllRequiredMods();
			xElement.Add(FlightStateRequiredMods.GenerateXml());
			return new XDocument(xElement);
		}

		public ICraftNodeData GetCraftNodeData(int id)
		{
			foreach (ICraftNodeData craftNode in CraftNodes)
			{
				if (craftNode.NodeId == id)
				{
					return craftNode;
				}
			}
			return null;
		}

		public int GetNextNodeId()
		{
			int num = MinCraftNodeId;
			foreach (ICraftNodeData craftNode in _craftNodes)
			{
				num = Mathf.Max(craftNode.NodeId, num);
			}
			return MinCraftNodeId = num + 1;
		}

		public PlanetNodeData GetPlanetNodeData(string name)
		{
			foreach (PlanetNodeData planetNode in PlanetNodes)
			{
				if (planetNode.Name == name)
				{
					return planetNode;
				}
			}
			return null;
		}

		public XElement LoadCraftXml(int nodeId)
		{
			return XDocument.Load(GetCraftXmlFilePath(nodeId)).Root;
		}

		public void ReassignCraftNodeData(int nodeId, ICraftNodeData newCraftNodeData)
		{
			_craftNodes.Remove(GetCraftNodeData(nodeId));
			_craftNodes.Add(newCraftNodeData);
		}

		public void RemoveCraftNode(ICraftNodeData craftNodeData)
		{
			_craftNodes.Remove(craftNodeData);
			_deletedCraftsPending.Add(craftNodeData);
		}

		public void RemovePlanetNode(string planetName)
		{
			if (_planetNodes.RemoveAll((PlanetNodeData x) => x.Name == planetName) <= 0)
			{
				return;
			}
			for (int num = _craftNodes.Count - 1; num >= 0; num--)
			{
				ICraftNodeData craftNodeData = _craftNodes[num];
				if (craftNodeData.ParentName == planetName)
				{
					RemoveCraftNode(craftNodeData);
				}
			}
		}

		public void Save()
		{
			if (!PreventSave)
			{
				GenerateXml().Save(Path);
				foreach (ICraftNodeData item in _deletedCraftsPending)
				{
					DeleteCraftXmlFile(item.NodeId);
				}
				_deletedCraftsPending.Clear();
			}
			else
			{
				Debug.LogWarning("Cannot save flight state because it is protected.");
			}
		}

		public void SaveCraftXml(int nodeId, XElement craftXml)
		{
			string craftXmlFilePath = GetCraftXmlFilePath(nodeId);
			new XDocument(craftXml).Save(craftXmlFilePath);
			ICraftNodeData craftNodeData = GetCraftNodeData(nodeId);
			if (craftNodeData == null)
			{
				Debug.LogError($"Unable to find the craft node data in the flight state data when saving craft XML for craft node '{nodeId}'.");
			}
			else
			{
				craftNodeData.RequiredMods = new RequiredModsData(craftXml.Element("RequiredMods"));
			}
		}

		public void SwitchModelType(ModelType newType, IEnumerable<(CraftNode CraftNode, ICraftNodeData CraftNodeData)> craftNodes)
		{
			if (ModelType == newType)
			{
				return;
			}
			_craftNodes.Clear();
			foreach (var craftNode in craftNodes)
			{
				switch (newType)
				{
				case ModelType.Dynamic:
					_craftNodes.Add(new CraftNodeDataDynamic(craftNode.CraftNode, craftNode.CraftNodeData));
					break;
				case ModelType.Static:
					_craftNodes.Add(new CraftNodeDataStatic(craftNode.CraftNode, craftNode.CraftNodeData));
					break;
				default:
					Debug.LogError($"Unsupported model type: {newType}");
					break;
				}
			}
			ModelType = newType;
		}

		private void DeleteCraftXmlFile(int nodeId)
		{
			string craftXmlFilePath = GetCraftXmlFilePath(nodeId);
			if (File.Exists(craftXmlFilePath))
			{
				File.Delete(craftXmlFilePath);
			}
		}

		private RequiredModsData GetAllRequiredMods()
		{
			RequiredModsData requiredModsData = new RequiredModsData();
			if (Game.Instance.ModManager != null)
			{
				foreach (GameMod gameMod in Game.Instance.ModManager.GameMods)
				{
					if (gameMod.IsModRequiredForFlightState(this))
					{
						requiredModsData.Add(new RequiredModData(gameMod.ModInfo, requiresCodeExecution: true));
					}
				}
			}
			if (PlanetarySystem != null)
			{
				requiredModsData.Add(PlanetarySystem.RequiredMods);
			}
			foreach (ICraftNodeData craftNode in _craftNodes)
			{
				requiredModsData.Add(craftNode.RequiredMods);
			}
			return requiredModsData;
		}

		private string GetCraftXmlFilePath(int nodeId)
		{
			return System.IO.Path.Combine(DirectoryPath, $"Craft-{nodeId}.xml");
		}
	}
}
