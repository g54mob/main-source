using System;

namespace FluentAssertions.Equivalency.Execution
{
	internal class ObjectInfo : IObjectInfo
	{
		public Type Type { get; }

		public Type ParentType { get; }

		public string Path { get; set; }

		public Type CompileTimeType { get; }

		public Type RuntimeType { get; }

		public ObjectInfo(Comparands comparands, INode currentNode)
		{
			Type = currentNode.Type;
			ParentType = currentNode.ParentType;
			Path = currentNode.Expectation.PathAndName;
			CompileTimeType = comparands.CompileTimeType;
			RuntimeType = comparands.RuntimeType;
		}
	}
}
