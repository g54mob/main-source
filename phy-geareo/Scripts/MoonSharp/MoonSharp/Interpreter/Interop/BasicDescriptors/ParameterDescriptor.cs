using System;
using System.Reflection;

namespace MoonSharp.Interpreter.Interop.BasicDescriptors
{
	public sealed class ParameterDescriptor : IWireableDescriptor
	{
		private Type m_OriginalType;

		public string Name { get; private set; }

		public Type Type { get; private set; }

		public bool HasDefaultValue { get; private set; }

		public object DefaultValue { get; private set; }

		public bool IsOut { get; private set; }

		public bool IsRef { get; private set; }

		public bool IsVarArgs { get; private set; }

		public bool HasBeenRestricted => false;

		public Type OriginalType => null;

		public ParameterDescriptor(string name, Type type, bool hasDefaultValue = false, object defaultValue = null, bool isOut = false, bool isRef = false, bool isVarArgs = false)
		{
		}

		public ParameterDescriptor(string name, Type type, bool hasDefaultValue, object defaultValue, bool isOut, bool isRef, bool isVarArgs, Type typeRestriction)
		{
		}

		public ParameterDescriptor(ParameterInfo pi)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void RestrictType(Type type)
		{
		}

		public void PrepareForWiring(Table table)
		{
		}
	}
}
