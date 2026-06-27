using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace TypeNameFormatter
{
	[GeneratedCode("TypeNameFormatter", "1.1.1")]
	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal static class TypeName
	{
		private static Dictionary<Type, string> typeKeywords;

		static TypeName()
		{
			typeKeywords = new Dictionary<Type, string>
			{
				[typeof(bool)] = "bool",
				[typeof(byte)] = "byte",
				[typeof(char)] = "char",
				[typeof(decimal)] = "decimal",
				[typeof(double)] = "double",
				[typeof(float)] = "float",
				[typeof(int)] = "int",
				[typeof(long)] = "long",
				[typeof(object)] = "object",
				[typeof(sbyte)] = "sbyte",
				[typeof(short)] = "short",
				[typeof(string)] = "string",
				[typeof(uint)] = "uint",
				[typeof(ulong)] = "ulong",
				[typeof(ushort)] = "ushort",
				[typeof(void)] = "void"
			};
		}

		public static StringBuilder AppendFormattedName(this StringBuilder stringBuilder, Type type, TypeNameFormatOptions options = TypeNameFormatOptions.Default)
		{
			stringBuilder.AppendFormattedName(type, options, type);
			return stringBuilder;
		}

		public static string GetFormattedName(this Type type, TypeNameFormatOptions options = TypeNameFormatOptions.Default)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormattedName(type, options);
			return stringBuilder.ToString();
		}

		private static void AppendFormattedName(this StringBuilder stringBuilder, Type type, TypeNameFormatOptions options, Type typeWithGenericTypeArgs)
		{
			if (!IsSet(TypeNameFormatOptions.NoKeywords, options) && typeKeywords.TryGetValue(type, out string value))
			{
				stringBuilder.Append(value);
				return;
			}
			if (type.HasElementType)
			{
				Type elementType = type.GetElementType();
				if (type.IsArray)
				{
					Queue<int> queue = new Queue<int>();
					queue.Enqueue(type.GetArrayRank());
					HandleArrayElementType(elementType, queue);
				}
				else if (type.IsByRef)
				{
					stringBuilder.Append("ref ");
					stringBuilder.AppendFormattedName(elementType, options);
				}
				else
				{
					stringBuilder.AppendFormattedName(elementType, options);
					stringBuilder.Append('*');
				}
				return;
			}
			bool flag = IsConstructedGenericType(typeWithGenericTypeArgs);
			if (flag)
			{
				if (!IsSet(TypeNameFormatOptions.NoNullableQuestionMark, options))
				{
					Type underlyingType = Nullable.GetUnderlyingType(type);
					if (underlyingType != null)
					{
						stringBuilder.AppendFormattedName(underlyingType, options);
						stringBuilder.Append('?');
						return;
					}
				}
				if (!IsSet(TypeNameFormatOptions.NoTuple, options) && type.Name.StartsWith("ValueTuple`", StringComparison.Ordinal) && type.Namespace == "System")
				{
					Type[] genericTypeArguments = GetGenericTypeArguments(typeWithGenericTypeArgs);
					int num = genericTypeArguments.Length;
					if (num > 1)
					{
						stringBuilder.Append('(');
						for (int i = 0; i < num; i++)
						{
							if (i > 0)
							{
								stringBuilder.Append(", ");
							}
							stringBuilder.AppendFormattedName(genericTypeArguments[i], options);
						}
						stringBuilder.Append(')');
						return;
					}
				}
			}
			string name = type.Name;
			if (!IsSet(TypeNameFormatOptions.NoAnonymousTypes, options) && name.StartsWith("<>f", StringComparison.Ordinal))
			{
				stringBuilder.Append('{');
				int num2 = 0;
				foreach (PropertyInfo declaredProperty in GetDeclaredProperties(type))
				{
					if (num2 > 0)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.AppendFormattedName(declaredProperty.PropertyType, options).Append(' ').Append(declaredProperty.Name);
					num2++;
				}
				stringBuilder.Append('}');
				return;
			}
			if (!type.IsGenericParameter)
			{
				if (type.IsNested)
				{
					stringBuilder.AppendFormattedName(type.DeclaringType, options, typeWithGenericTypeArgs);
					stringBuilder.Append('.');
				}
				else if (IsSet(TypeNameFormatOptions.Namespaces, options))
				{
					string value2 = type.Namespace;
					if (!string.IsNullOrEmpty(value2))
					{
						stringBuilder.Append(value2);
						stringBuilder.Append('.');
					}
				}
			}
			if (flag || IsGenericType(type))
			{
				int num3 = name.LastIndexOf('`');
				if (num3 >= 0)
				{
					stringBuilder.Append(name, 0, num3);
				}
				else
				{
					stringBuilder.Append(name);
				}
				int num4 = GetGenericTypeArguments(type).Length;
				int num5 = 0;
				if (type.IsNested)
				{
					int num6 = GetGenericTypeArguments(type.DeclaringType).Length;
					if (num4 >= num6)
					{
						num5 = num6;
					}
				}
				if (num5 >= num4)
				{
					return;
				}
				stringBuilder.Append('<');
				if (flag || !IsSet(TypeNameFormatOptions.NoGenericParameterNames, options))
				{
					Type[] genericTypeArguments2 = GetGenericTypeArguments(typeWithGenericTypeArgs);
					int j = num5;
					for (int num7 = num4; j < num7; j++)
					{
						if (j > num5)
						{
							stringBuilder.Append(", ");
						}
						stringBuilder.AppendFormattedName(genericTypeArguments2[j], options);
					}
				}
				else
				{
					stringBuilder.Append(',', num4 - num5 - 1);
				}
				stringBuilder.Append('>');
			}
			else
			{
				stringBuilder.Append(name);
			}
			void HandleArrayElementType(Type et, Queue<int> r)
			{
				if (et.IsArray)
				{
					r.Enqueue(et.GetArrayRank());
					HandleArrayElementType(et.GetElementType(), r);
				}
				else
				{
					stringBuilder.AppendFormattedName(et, options);
					while (r.Count > 0)
					{
						stringBuilder.Append('[');
						stringBuilder.Append(',', r.Dequeue() - 1);
						stringBuilder.Append(']');
					}
				}
			}
		}

		private static bool IsSet(TypeNameFormatOptions option, TypeNameFormatOptions options)
		{
			return (options & option) == option;
		}

		private static IEnumerable<PropertyInfo> GetDeclaredProperties(Type type)
		{
			return type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		private static Type[] GetGenericTypeArguments(Type type)
		{
			return type.GetGenericArguments();
		}

		private static bool IsGenericType(Type type)
		{
			return type.IsGenericType;
		}

		private static bool IsConstructedGenericType(Type type)
		{
			if (type.IsGenericType)
			{
				return !type.IsGenericTypeDefinition;
			}
			return false;
		}
	}
}
