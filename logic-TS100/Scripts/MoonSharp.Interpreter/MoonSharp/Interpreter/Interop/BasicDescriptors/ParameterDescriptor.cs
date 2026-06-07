using System;
using System.Linq;
using System.Reflection;

namespace MoonSharp.Interpreter.Interop.BasicDescriptors
{
	public sealed class ParameterDescriptor
	{
		private Type m_OriginalType;

		public string Name { get; private set; }

		public Type Type { get; private set; }

		public bool HasDefaultValue { get; private set; }

		public object DefaultValue { get; private set; }

		public bool IsOut { get; private set; }

		public bool IsRef { get; private set; }

		public bool IsVarArgs { get; private set; }

		public bool HasBeenRestricted
		{
			get
			{
				return m_OriginalType != null;
			}
		}

		public Type OriginalType
		{
			get
			{
				return m_OriginalType ?? Type;
			}
		}

		public ParameterDescriptor(string name, Type type, bool hasDefaultValue = false, object defaultValue = null, bool isOut = false, bool isRef = false, bool isVarArgs = false)
		{
			Name = name;
			Type = type;
			HasDefaultValue = hasDefaultValue;
			DefaultValue = defaultValue;
			IsOut = isOut;
			IsRef = isRef;
			IsVarArgs = isVarArgs;
		}

		public ParameterDescriptor(ParameterInfo pi)
		{
			Name = pi.Name;
			Type = pi.ParameterType;
			HasDefaultValue = !pi.DefaultValue.IsDbNull();
			DefaultValue = pi.DefaultValue;
			IsOut = pi.IsOut;
			IsRef = pi.ParameterType.IsByRef;
			IsVarArgs = pi.ParameterType.IsArray && pi.GetCustomAttributes(typeof(ParamArrayAttribute), true).Any();
		}

		public override string ToString()
		{
			return string.Format("{0} {1}{2}", Type.Name, Name, HasDefaultValue ? " = ..." : "");
		}

		public void RestrictType(Type type)
		{
			if (IsOut || IsRef || IsVarArgs)
			{
				throw new InvalidOperationException("Cannot restrict a ref/out or varargs param");
			}
			if (!Type.IsAssignableFrom(type))
			{
				throw new InvalidOperationException("Specified operation is not a restriction");
			}
			m_OriginalType = Type;
			Type = type;
		}
	}
}
