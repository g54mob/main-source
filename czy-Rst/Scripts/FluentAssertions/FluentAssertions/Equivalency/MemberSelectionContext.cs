using System;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	public class MemberSelectionContext
	{
		private readonly Type compileTimeType;

		private readonly Type runtimeType;

		private readonly IEquivalencyOptions options;

		public MemberVisibility IncludedProperties => options.IncludedProperties;

		public MemberVisibility IncludedFields => options.IncludedFields;

		public Type Type => (options.UseRuntimeTyping ? runtimeType : compileTimeType).NullableOrActualType();

		public MemberSelectionContext(Type compileTimeType, Type runtimeType, IEquivalencyOptions options)
		{
			this.runtimeType = runtimeType;
			this.compileTimeType = compileTimeType;
			this.options = options;
		}
	}
}
