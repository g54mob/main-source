using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SickDev.CommandSystem
{
	internal static class SignatureBuilder
	{
		private static readonly Dictionary<Type, string> aliases = new Dictionary<Type, string>
		{
			{
				typeof(byte),
				"byte"
			},
			{
				typeof(sbyte),
				"sbyte"
			},
			{
				typeof(short),
				"short"
			},
			{
				typeof(ushort),
				"ushort"
			},
			{
				typeof(int),
				"int"
			},
			{
				typeof(uint),
				"uint"
			},
			{
				typeof(long),
				"long"
			},
			{
				typeof(ulong),
				"ulong"
			},
			{
				typeof(float),
				"float"
			},
			{
				typeof(double),
				"double"
			},
			{
				typeof(decimal),
				"decimal"
			},
			{
				typeof(object),
				"object"
			},
			{
				typeof(bool),
				"bool"
			},
			{
				typeof(char),
				"char"
			},
			{
				typeof(string),
				"string"
			},
			{
				typeof(void),
				"void"
			},
			{
				typeof(byte?),
				"byte?"
			},
			{
				typeof(sbyte?),
				"sbyte?"
			},
			{
				typeof(short?),
				"short?"
			},
			{
				typeof(ushort?),
				"ushort?"
			},
			{
				typeof(int?),
				"int?"
			},
			{
				typeof(uint?),
				"uint?"
			},
			{
				typeof(long?),
				"long?"
			},
			{
				typeof(ulong?),
				"ulong?"
			},
			{
				typeof(float?),
				"float?"
			},
			{
				typeof(double?),
				"double?"
			},
			{
				typeof(decimal?),
				"decimal?"
			},
			{
				typeof(bool?),
				"bool?"
			},
			{
				typeof(char?),
				"char?"
			}
		};

		public static string Build(MethodInfo method, string nameOverride = null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = TypeToString(method.ReturnType);
			if (text != aliases[typeof(void)])
			{
				stringBuilder.Append(text);
				stringBuilder.Append(" ");
			}
			stringBuilder.Append(nameOverride ?? method.Name);
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length != 0)
			{
				AddParameters(stringBuilder, parameters);
			}
			return stringBuilder.ToString();
		}

		private static void AddParameters(StringBuilder signature, ParameterInfo[] parameters)
		{
			signature = signature.Append('(');
			for (int i = 0; i < parameters.Length; i++)
			{
				AddParameter(signature, parameters[i]);
				if (i != parameters.Length - 1)
				{
					signature = signature.Append(", ");
				}
			}
			signature = signature.Append(')');
		}

		private static void AddParameter(StringBuilder signature, ParameterInfo parameter)
		{
			signature = signature.Append(TypeToString(parameter.ParameterType));
			signature = signature.Append(" ");
			signature = signature.Append(parameter.Name);
			if (parameter.IsOptional)
			{
				signature = signature.Append(" = ");
				signature = ((!(parameter.DefaultValue is string)) ? signature.Append(parameter.DefaultValue) : signature.AppendFormat("\"{0}\"", parameter.DefaultValue));
			}
		}

		private static string TypeToString(Type type)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (aliases.ContainsKey(type))
			{
				stringBuilder = stringBuilder.Append(aliases[type]);
			}
			else if (type.IsArray)
			{
				stringBuilder = stringBuilder.Append(TypeToString(type.GetElementType())).Append("[]");
			}
			else if (type.IsGenericType)
			{
				Type[] genericArguments = type.GetGenericArguments();
				stringBuilder = stringBuilder.Append(type.Name.Substring(0, type.Name.IndexOf('`'))).Append("<");
				for (int i = 0; i < genericArguments.Length; i++)
				{
					stringBuilder = stringBuilder.Append(TypeToString(genericArguments[i]));
					if (i != genericArguments.Length - 1)
					{
						stringBuilder = stringBuilder.Append(", ");
					}
				}
				stringBuilder = stringBuilder.Append(">");
			}
			else
			{
				stringBuilder = stringBuilder.Append(type.Name);
			}
			return stringBuilder.ToString();
		}
	}
}
