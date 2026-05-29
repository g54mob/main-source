using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class TypeExtensions
	{
		private static readonly HashSet<Type> _unitySerializablePrimitiveTypes = new HashSet<Type>
		{
			typeof(bool),
			typeof(byte),
			typeof(sbyte),
			typeof(char),
			typeof(double),
			typeof(float),
			typeof(int),
			typeof(uint),
			typeof(long),
			typeof(ulong),
			typeof(short),
			typeof(ushort),
			typeof(string)
		};

		private static readonly HashSet<Type> _unitySerializableBuiltinTypes = new HashSet<Type>
		{
			typeof(Vector2),
			typeof(Vector3),
			typeof(Vector4),
			typeof(Rect),
			typeof(Quaternion),
			typeof(Matrix4x4),
			typeof(Color),
			typeof(Color32),
			typeof(LayerMask),
			typeof(AnimationCurve),
			typeof(Gradient),
			typeof(RectOffset),
			typeof(GUIStyle)
		};

		public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
		{
			while (toCheck != null && toCheck != typeof(object))
			{
				Type type = (toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck);
				if (generic == type)
				{
					return true;
				}
				toCheck = toCheck.BaseType;
			}
			return false;
		}

		public static bool InheritsFrom(this Type typeToCheck, Type baseType)
		{
			bool flag = baseType.IsGenericType && typeToCheck.IsSubclassOfRawGeneric(baseType);
			return baseType.IsAssignableFrom(typeToCheck) || flag;
		}

		public static string GetShortAssemblyName(this Type type)
		{
			string fullName = type.Assembly.FullName;
			return fullName[..fullName.IndexOf(',')];
		}

		public static bool IsUnitySerializable(this Type type)
		{
			if (type.IsInterface || (type.IsAbstract && type.IsSealed))
			{
				return false;
			}
			if (IsCustomSerializableType(type))
			{
				return true;
			}
			if (type.InheritsFrom(typeof(UnityEngine.Object)) && !type.IsGenericTypeDefinition)
			{
				return true;
			}
			if (type.IsEnum)
			{
				return true;
			}
			if (!_unitySerializablePrimitiveTypes.Contains(type))
			{
				return _unitySerializableBuiltinTypes.Contains(type);
			}
			return true;
			static bool IsCustomSerializableType(Type typeToCheck)
			{
				if (typeToCheck.IsSerializable)
				{
					return !IsSystemType(typeToCheck);
				}
				return false;
			}
			static bool IsSystemType(Type typeToCheck)
			{
				if (typeToCheck.Namespace != null)
				{
					return typeToCheck.Namespace.StartsWith("System");
				}
				return false;
			}
		}
	}
}
