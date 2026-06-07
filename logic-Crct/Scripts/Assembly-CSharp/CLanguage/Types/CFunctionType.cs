using System.Collections.Generic;
using CLanguage.Compiler;

namespace CLanguage.Types
{
	public class CFunctionType : CType
	{
		public class Parameter
		{
			public string Name { get; set; }

			public CType ParameterType { get; set; }

			public int Offset { get; set; }

			public Value? DefaultValue { get; set; }

			public Parameter(string name, CType parameterType, Value? defaultValue)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public static readonly CFunctionType VoidProcedure;

		private readonly List<Parameter> parameters;

		public override int NumValues => 0;

		public CType ReturnType { get; private set; }

		public IReadOnlyList<Parameter> Parameters => null;

		public bool IsInstance { get; private set; }

		public CType? DeclaringType { get; }

		public CFunctionType(CType returnType, bool isInstance, CType? declaringType)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public void AddParameter(string name, CType type, Value? defaultValue)
		{
		}

		private void CalculateParameterOffsets()
		{
		}

		public override int GetByteSize(EmitContext c)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public int ScoreParameterTypeMatches(CType[]? argTypes)
		{
			return 0;
		}

		public bool ParameterTypesEqual(CFunctionType otherType)
		{
			return false;
		}
	}
}
