using System;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	public class Comparands
	{
		private Type compileTimeType;

		public object Subject { get; set; }

		public object Expectation { get; set; }

		public Type CompileTimeType
		{
			get
			{
				if (!(compileTimeType != typeof(object)) && Expectation != null)
				{
					return RuntimeType;
				}
				return compileTimeType;
			}
			set
			{
				compileTimeType = value;
			}
		}

		public Type RuntimeType
		{
			get
			{
				if (Expectation != null)
				{
					return Expectation.GetType();
				}
				return CompileTimeType;
			}
		}

		public Comparands()
		{
		}

		public Comparands(object subject, object expectation, Type compileTimeType)
		{
			this.compileTimeType = compileTimeType;
			Subject = subject;
			Expectation = expectation;
		}

		public Type GetExpectedType(IEquivalencyOptions options)
		{
			return (options.UseRuntimeTyping ? RuntimeType : CompileTimeType).NullableOrActualType();
		}

		public override string ToString()
		{
			return FormattableString.Invariant($"{{Subject={Subject}, Expectation={Expectation}}}");
		}
	}
}
