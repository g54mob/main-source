using System;

namespace FluentAssertions.Equivalency
{
	public interface IObjectInfo
	{
		[Obsolete("Use CompileTimeType or RuntimeType instead")]
		Type Type { get; }

		Type ParentType { get; }

		string Path { get; set; }

		Type CompileTimeType { get; }

		Type RuntimeType { get; }
	}
}
