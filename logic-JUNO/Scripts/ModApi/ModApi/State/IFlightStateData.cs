using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.CelestialData;
using ModApi.Flight.Sim;
using ModApi.Mods;
using ModApi.Scripts.State;
using ModApi.State.MapView;

namespace ModApi.State
{
	public interface IFlightStateData
	{
		IReadOnlyList<ICraftNodeData> CraftNodes { get; }

		string DirectoryPath { get; }

		RequiredModsData FlightStateRequiredMods { get; }

		MapViewData MapView { get; }

		string Path { get; }

		PlanetarySystemFileData PlanetarySystem { get; }

		IReadOnlyList<PlanetNodeData> PlanetNodes { get; }

		int PlayerNodeId { get; set; }

		bool PreventSave { get; }

		double Time { get; set; }

		void AddCraftNode(ICraftNodeData craftNodeData);

		bool CheckCraftXmlExists(int nodeId);

		XDocument GenerateXml();

		ICraftNodeData GetCraftNodeData(int id);

		int GetNextNodeId();

		PlanetNodeData GetPlanetNodeData(string name);

		XElement LoadCraftXml(int nodeId);

		void RemoveCraftNode(ICraftNodeData craftNodeData);

		void Save();

		void SaveCraftXml(int nodeId, XElement craftXml);
	}
}
