using System;

namespace FluentAssertions.Equivalency.Ordering
{
	internal class CollectionMemberObjectInfo : IObjectInfo
	{
		public Type Type { get; }

		public Type ParentType { get; }

		public string Path { get; set; }

		public Type CompileTimeType { get; }

		public Type RuntimeType { get; }

		public CollectionMemberObjectInfo(IObjectInfo context)
		{
			Path = GetAdjustedPropertyPath(context.Path);
			Type = context.Type;
			ParentType = context.ParentType;
			RuntimeType = context.RuntimeType;
			CompileTimeType = context.CompileTimeType;
		}

		private static string GetAdjustedPropertyPath(string propertyPath)
		{
			return propertyPath.Substring(SystemExtensions.IndexOf(propertyPath, '.', StringComparison.Ordinal) + 1);
		}
	}
}
