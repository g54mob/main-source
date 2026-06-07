using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Pathfinding.Ionic.Zip;
using UnityEngine;

namespace Pathfinding.Serialization
{
	public class AstarSerializer
	{
		private AstarData data;

		private ZipFile zip;

		private MemoryStream zipStream;

		private GraphMeta meta;

		private SerializeSettings settings;

		private GameObject contextRoot;

		private NavGraph[] graphs;

		private bool[] persistentGraphs;

		private Dictionary<NavGraph, int> graphIndexInZip;

		private const string binaryExt = ".binary";

		private const string jsonExt = ".json";

		private uint checksum;

		private UTF8Encoding encoding;

		private static StringBuilder _stringBuilder;

		public static readonly Version V3_8_3;

		public static readonly Version V3_9_0;

		public static readonly Version V4_1_0;

		public static readonly Version V4_3_2;

		public static readonly Version V4_3_6;

		public static readonly Version V4_3_37;

		public static readonly Version V4_3_12;

		public static readonly Version V4_3_68;

		public static readonly Version V4_3_74;

		public static readonly Version V4_3_80;

		public static readonly Version V4_3_83;

		public static readonly Version V4_3_85;

		public static readonly Version V4_3_87;

		public static readonly Version V5_1_0;

		public static readonly Version V5_2_0;

		private static StringBuilder GetStringBuilder()
		{
			return null;
		}

		public AstarSerializer(AstarData data, GameObject contextRoot)
		{
		}

		public AstarSerializer(AstarData data, SerializeSettings settings, GameObject contextRoot)
		{
		}

		private void AddChecksum(byte[] bytes)
		{
		}

		private void AddEntry(string name, byte[] bytes)
		{
		}

		public uint GetChecksum()
		{
			return 0u;
		}

		public void OpenSerialize()
		{
		}

		public byte[] CloseSerialize()
		{
			return null;
		}

		public void SerializeGraphs(NavGraph[] _graphs)
		{
		}

		private byte[] SerializeMeta()
		{
			return null;
		}

		public byte[] Serialize(NavGraph graph)
		{
			return null;
		}

		private static int GetMaxNodeIndexInAllGraphs(NavGraph[] graphs)
		{
			return 0;
		}

		private static byte[] SerializeNodeIndices(NavGraph[] graphs)
		{
			return null;
		}

		private static byte[] SerializeGraphExtraInfo(NavGraph graph, bool[] persistentGraphs)
		{
			return null;
		}

		private static byte[] SerializeGraphNodeReferences(NavGraph graph, bool[] persistentGraphs)
		{
			return null;
		}

		public void SerializeExtraInfo()
		{
		}

		private ZipEntry GetEntry(string name)
		{
			return null;
		}

		private bool ContainsEntry(string name)
		{
			return false;
		}

		public bool OpenDeserialize(byte[] bytes)
		{
			return false;
		}

		private static Version FullyDefinedVersion(Version v)
		{
			return null;
		}

		public void CloseDeserialize()
		{
		}

		private NavGraph DeserializeGraph(int zipIndex, int graphIndex, Type[] availableGraphTypes)
		{
			return null;
		}

		public NavGraph[] DeserializeGraphs(Type[] availableGraphTypes, bool allowLoadingNodes, Func<int> nextGraphIndex)
		{
			return null;
		}

		private bool DeserializeExtraInfo(NavGraph graph)
		{
			return false;
		}

		private bool AnyDestroyedNodesInGraphs()
		{
			return false;
		}

		private GraphNode[] DeserializeNodeReferenceMap()
		{
			return null;
		}

		private void DeserializeNodeReferences(NavGraph graph, GraphNode[] int2Node)
		{
		}

		private void DeserializeAndRemoveOldNodeLinks(GraphSerializationContext ctx)
		{
		}

		private void DeserializeExtraInfo()
		{
		}

		public void PostDeserialization()
		{
		}

		private void DeserializeEditorSettingsCompatibility()
		{
		}

		private static BinaryReader GetBinaryReader(ZipEntry entry)
		{
			return null;
		}

		private static string GetString(ZipEntry entry)
		{
			return null;
		}

		private GraphMeta DeserializeMeta(ZipEntry entry)
		{
			return null;
		}

		private GraphMeta DeserializeBinaryMeta(ZipEntry entry)
		{
			return null;
		}

		public static void SaveToFile(string path, byte[] data)
		{
		}

		public static byte[] LoadFromFile(string path)
		{
			return null;
		}
	}
}
