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

		private Dictionary<NavGraph, int> graphIndexInZip;

		private int graphIndexOffset;

		private const string binaryExt = ".binary";

		private const string jsonExt = ".json";

		private uint checksum;

		private UTF8Encoding encoding;

		private static StringBuilder _stringBuilder;

		public static readonly Version V3_8_3;

		public static readonly Version V3_9_0;

		public static readonly Version V4_1_0;

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

		public void SetGraphIndexOffset(int offset)
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

		[Obsolete("Not used anymore. You can safely remove the call to this function.")]
		public void SerializeNodes()
		{
		}

		private static int GetMaxNodeIndexInAllGraphs(NavGraph[] graphs)
		{
			return 0;
		}

		private static byte[] SerializeNodeIndices(NavGraph[] graphs)
		{
			return null;
		}

		private static byte[] SerializeGraphExtraInfo(NavGraph graph)
		{
			return null;
		}

		private static byte[] SerializeGraphNodeReferences(NavGraph graph)
		{
			return null;
		}

		public void SerializeExtraInfo()
		{
		}

		private byte[] SerializeNodeLinks()
		{
			return null;
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

		public NavGraph[] DeserializeGraphs(Type[] availableGraphTypes)
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

		public void DeserializeExtraInfo()
		{
		}

		private void DeserializeNodeLinks(GraphNode[] int2Node)
		{
		}

		public void PostDeserialization()
		{
		}

		public void DeserializeEditorSettingsCompatibility()
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
