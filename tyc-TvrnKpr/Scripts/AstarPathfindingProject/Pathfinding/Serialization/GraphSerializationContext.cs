using System.IO;
using Pathfinding.Collections;
using Unity.Collections;
using UnityEngine;

namespace Pathfinding.Serialization
{
	public class GraphSerializationContext
	{
		private readonly GraphNode[] id2NodeMapping;

		public readonly BinaryReader reader;

		public readonly BinaryWriter writer;

		public readonly uint graphIndex;

		public readonly GraphMeta meta;

		public bool[] persistentGraphs;

		public GraphSerializationContext(BinaryReader reader, GraphNode[] id2NodeMapping, uint graphIndex, GraphMeta meta)
		{
		}

		public GraphSerializationContext(BinaryWriter writer, bool[] persistentGraphs)
		{
		}

		public void SerializeNodeReference(GraphNode node)
		{
		}

		public void SerializeConnections(Connection[] connections, bool serializeMetadata)
		{
		}

		public Connection[] DeserializeConnections(bool deserializeMetadata)
		{
			return null;
		}

		public GraphNode DeserializeNodeReference()
		{
			return null;
		}

		public void SerializeVector3(Vector3 v)
		{
		}

		public Vector3 DeserializeVector3()
		{
			return default(Vector3);
		}

		public void SerializeInt3(Int3 v)
		{
		}

		public Int3 DeserializeInt3()
		{
			return default(Int3);
		}

		public UnsafeSpan<T> ReadSpan<T>(Allocator allocator) where T : struct
		{
			return default(UnsafeSpan<T>);
		}
	}
}
