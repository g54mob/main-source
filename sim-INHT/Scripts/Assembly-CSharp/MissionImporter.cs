using System;
using System.Collections.Generic;
using Localisation;
using Newtonsoft.Json.Linq;
using SleepyNodes;

public static class MissionImporter
{
	[Serializable]
	public class NodeReference
	{
		public string ID;

		public string NextID;

		public string PrevID;

		public Dictionary<string, string> Outputs;

		public double PosX;

		public double PosY;

		public string NodeType;

		public object NodeData;
	}

	[Serializable]
	public class MissionDefinition
	{
		public string MissionID;

		public string MissionName;

		public MissionGraph.MissionTypes MissionType;

		public string MapImage;

		public string MapTopoImage;

		public List<Zone> Zones;

		public int RequisitionPoints;

		public int PowderCharges;

		public Dictionary<string, NodeReference> Nodes;
	}

	public static class NodeTypeRegistry
	{
		public static readonly Dictionary<string, Type> Types;
	}

	public class ExportPackage
	{
		public string MissionName { get; set; }

		public string MissionJson { get; set; }

		public List<ExportFile> Files { get; set; }
	}

	public class ExportFile
	{
		public string Name { get; set; }

		public string Data { get; set; }
	}

	private static List<TextIdentifier> ImportedText;

	public static MissionGraph ImportMission(string json, MissionGraph missionGraph = null, bool updateMissionData = true, bool isPerminant = false)
	{
		return null;
	}

	private static void ApplyData(object target, Dictionary<string, object> data, ExportPackage package = null, string missionId = null)
	{
	}

	private static object ConvertValue(JToken token, Type targetType, ExportPackage package, string missionId)
	{
		return null;
	}
}
