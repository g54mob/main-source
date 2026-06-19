using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Aggro.Core
{
	public static class EntityTypeManager
	{
		public class TypeInfo
		{
			public int typeIndex;

			public TypeCategory category;

			public TypeFlag flags;

			public Type type;

			public ushort sizeInBytes;

			internal uint checkedVersion;

			internal int nextCheckIndex;

			internal List<int> inheritedTypeIndices;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct TypeInfoCache<T>
		{
			public static readonly TypeInfo cached = GetInfo(typeof(T));
		}

		public enum TypeCategory : byte
		{
			Component = 0,
			JobComponent = 1,
			BufferItem = 2,
			ExternalData = 3,
			Other = 4
		}

		[Flags]
		public enum TypeFlag : byte
		{
			CanBeBehaviour = 1,
			AlwaysActive = 2,
			UpdateWhenDying = 4,
			Sealed = 8
		}

		private static Dictionary<Type, TypeInfo> _indices;

		private static List<TypeInfo> _infos;

		private static List<Type> _behaviourTypes;

		public static int count => _infos.Count;

		public static uint version { get; private set; }

		static EntityTypeManager()
		{
			_indices = new Dictionary<Type, TypeInfo>();
			_infos = new List<TypeInfo>();
			_behaviourTypes = new List<Type>();
			Type typeFromHandle = typeof(IEntityTyped);
			List<Type> list = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Type typeFromHandle2 = typeof(Behaviour);
			Assembly[] array = assemblies;
			for (int i = 0; i < array.Length; i++)
			{
				Type[] types = array[i].GetTypes();
				foreach (Type type in types)
				{
					if (!type.IsInterface && !type.IsGenericTypeDefinition && !type.IsAbstract && type.GetCustomAttribute<NoAutoCreationAttribute>() == null && typeFromHandle.IsAssignableFrom(type))
					{
						list.Add(type);
					}
					if (typeFromHandle2.IsAssignableFrom(type))
					{
						_behaviourTypes.Add(type);
					}
				}
			}
			list.Sort((Type x, Type y) => string.Compare(x.AssemblyQualifiedName, y.AssemblyQualifiedName, StringComparison.Ordinal));
			foreach (Type item in list)
			{
				AddType(item);
			}
		}

		public static int GetIndex<T>()
		{
			return TypeInfoCache<T>.cached.typeIndex;
		}

		public static int GetIndex(Type type)
		{
			return GetInfo(type).typeIndex;
		}

		public static TypeInfo GetInfo<T>()
		{
			return TypeInfoCache<T>.cached;
		}

		public static TypeInfo GetInfo(Type type)
		{
			if (_indices.TryGetValue(type, out var value))
			{
				return value;
			}
			return AddType(type);
		}

		public static TypeInfo GetInfo(int typeIndex)
		{
			if (typeIndex < 0 || typeIndex >= _infos.Count)
			{
				Debug.LogError($"[ENTITY] Type index is not valid! ({typeIndex})");
				return null;
			}
			return _infos[typeIndex];
		}

		public static void MarkAlwaysActive<T>()
		{
			GetInfo<T>().flags |= TypeFlag.AlwaysActive;
		}

		internal static TypeInfo GetInfoUpdateInherited(int typeIndex)
		{
			if (typeIndex < 0 || typeIndex >= _infos.Count)
			{
				Debug.LogError($"[ENTITY] Type index is not valid! ({typeIndex})");
				return null;
			}
			TypeInfo typeInfo = _infos[typeIndex];
			if ((typeInfo.flags & TypeFlag.Sealed) == 0 && typeInfo.checkedVersion != version)
			{
				typeInfo.checkedVersion = version;
				int num = _infos.Count;
				while (typeInfo.nextCheckIndex < num)
				{
					TypeInfo info = GetInfo(typeInfo.nextCheckIndex);
					if (info.typeIndex != typeInfo.typeIndex && typeInfo.type.IsAssignableFrom(info.type))
					{
						typeInfo.inheritedTypeIndices.Add(typeInfo.nextCheckIndex);
					}
					typeInfo.nextCheckIndex++;
				}
			}
			return typeInfo;
		}

		public static void GetValidTypeIndices<T>(List<int> typeIndices)
		{
			GetValidTypeIndices(GetIndex<T>(), typeIndices);
		}

		public static void GetValidTypeIndices(Type type, List<int> typeIndices)
		{
			GetValidTypeIndices(GetIndex(type), typeIndices);
		}

		public static void GetValidTypeIndices(int typeIndex, List<int> typeIndices)
		{
			TypeInfo infoUpdateInherited = GetInfoUpdateInherited(typeIndex);
			typeIndices.Add(typeIndex);
			typeIndices.AddRangeNoGarbage(infoUpdateInherited.inheritedTypeIndices);
		}

		public static Type GetType(int typeIndex)
		{
			return GetInfo(typeIndex).type;
		}

		public static TypeInfo[] GetAllCurrentTypeInfos()
		{
			return _infos.ToArray();
		}

		private static TypeInfo AddType<T>()
		{
			return AddType(typeof(T));
		}

		private static TypeInfo AddType(Type type)
		{
			version++;
			TypeInfo typeInfo = new TypeInfo();
			typeInfo.typeIndex = _infos.Count;
			typeInfo.type = type;
			typeInfo.nextCheckIndex = 0;
			typeInfo.checkedVersion = 0u;
			typeInfo.inheritedTypeIndices = new List<int>();
			if (UnsafeUtility.IsUnmanaged(type) && typeof(IEntityJobComponent).IsAssignableFrom(type))
			{
				typeInfo.category = TypeCategory.JobComponent;
				typeInfo.sizeInBytes = (ushort)UnsafeUtility.SizeOf(type);
			}
			else if (type.IsValueType && typeof(IEntityStruct).IsAssignableFrom(type))
			{
				typeInfo.category = TypeCategory.Component;
				typeInfo.sizeInBytes = (ushort)UnsafeUtility.SizeOf(type);
			}
			else if (type.IsValueType && typeof(IBufferItem).IsAssignableFrom(type))
			{
				typeInfo.category = TypeCategory.BufferItem;
			}
			else if (type.IsClass && typeof(IExternalData).IsAssignableFrom(type))
			{
				typeInfo.category = TypeCategory.ExternalData;
			}
			else
			{
				typeInfo.category = TypeCategory.Other;
			}
			if (type.GetCustomAttribute<AlwaysActiveAttribute>() != null)
			{
				typeInfo.flags |= TypeFlag.AlwaysActive;
			}
			if (type.GetCustomAttribute<UpdateWhenDyingAttribute>() != null)
			{
				typeInfo.flags |= TypeFlag.UpdateWhenDying;
			}
			if (type.IsSealed)
			{
				typeInfo.flags |= TypeFlag.Sealed;
			}
			if (type.IsClass && (typeof(Behaviour).IsAssignableFrom(type) || type == typeof(Component) || type == typeof(UnityEngine.Object)))
			{
				typeInfo.flags |= TypeFlag.CanBeBehaviour;
			}
			if (type.IsInterface)
			{
				int num = _behaviourTypes.Count;
				for (int i = 0; i < num; i++)
				{
					if (type.IsAssignableFrom(_behaviourTypes[i]))
					{
						typeInfo.flags |= TypeFlag.CanBeBehaviour;
						break;
					}
				}
			}
			_indices[type] = typeInfo;
			_infos.Add(typeInfo);
			return typeInfo;
		}
	}
}
