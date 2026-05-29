using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;

namespace Google.Protobuf
{
	internal sealed class FieldMaskTree
	{
		internal sealed class Node
		{
			public Dictionary<string, Node> Children { get; }
		}

		private const char FIELD_PATH_SEPARATOR = '.';

		private readonly Node root;

		public FieldMaskTree()
		{
		}

		public FieldMaskTree(FieldMask mask)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public FieldMaskTree AddFieldPath(string path)
		{
			return null;
		}

		public FieldMaskTree MergeFromFieldMask(FieldMask mask)
		{
			return null;
		}

		public FieldMask ToFieldMask()
		{
			return null;
		}

		private void GetFieldPaths(Node node, string path, List<string> paths)
		{
		}

		public void IntersectFieldPath(string path, FieldMaskTree output)
		{
		}

		public void Merge(IMessage source, IMessage destination, FieldMask.MergeOptions options)
		{
		}

		private void Merge(Node node, string path, IMessage source, IMessage destination, FieldMask.MergeOptions options)
		{
		}
	}
}
