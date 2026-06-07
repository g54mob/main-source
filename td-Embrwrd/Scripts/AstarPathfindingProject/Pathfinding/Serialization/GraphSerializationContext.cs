using System.IO;
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

		public GraphSerializationContext(BinaryReader reader, GraphNode[] id2NodeMapping, uint graphIndex, GraphMeta meta)
		{
		}

		public GraphSerializationContext(BinaryWriter writer)
		{
		}

		public void SerializeNodeReference(GraphNode node)
		{
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

		public int DeserializeInt(int defaultValue)
		{
			return 0;
		}

		public float DeserializeFloat(float defaultValue)
		{
			return 0f;
		}

		public Object DeserializeUnityObject()
		{
			return null;
		}
	}
}
