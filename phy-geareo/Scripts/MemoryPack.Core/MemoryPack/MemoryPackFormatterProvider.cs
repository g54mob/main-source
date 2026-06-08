using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MemoryPack
{
	public static class MemoryPackFormatterProvider
	{
		private static class Check<T>
		{
			public static bool registered;
		}

		private static class Cache<T>
		{
			public static MemoryPackFormatter<T> formatter;

			static Cache()
			{
			}
		}

		private static readonly Dictionary<Type, Type> ArrayLikeFormatters;

		private static readonly Dictionary<Type, Type> CollectionFormatters;

		private static readonly Dictionary<Type, Type> ImmutableCollectionFormatters;

		private static readonly Dictionary<Type, Type> InterfaceCollectionFormatters;

		private static readonly ConcurrentDictionary<Type, IMemoryPackFormatter> formatters;

		private static readonly ConcurrentDictionary<Type, Type> genericFormatterFactory;

		private static readonly ConcurrentDictionary<Type, Type> genericCollectionFormatterFactory;

		private static readonly Dictionary<Type, Type> KnownGenericTypeFormatters;

		static MemoryPackFormatterProvider()
		{
		}

		public static bool IsRegistered<T>()
		{
			return false;
		}

		public static void Register<T>(MemoryPackFormatter<T> formatter) where T : notnull
		{
		}

		public static void RegisterGenericType(Type genericType, Type genericFormatterType)
		{
		}

		public static void RegisterCollection<TCollection, TElement>() where TCollection : ICollection<TElement>, new()
		{
		}

		public static void RegisterCollection(Type genericCollectionType)
		{
		}

		public static void RegisterSet<TSet, TElement>() where TSet : ISet<TElement>, new()
		{
		}

		public static void RegisterSet(Type genericSetType)
		{
		}

		public static void RegisterDictionary<TDictionary, TKey, TValue>() where TDictionary : IDictionary<TKey, TValue>, new()
		{
		}

		public static void RegisterDictionary(Type genericDictionaryType)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static MemoryPackFormatter<T> GetFormatter<T>() where T : notnull
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static IMemoryPackFormatter GetFormatter(Type type)
		{
			return null;
		}

		private static bool TryInvokeRegisterFormatter(Type type)
		{
			return false;
		}

		internal static object CreateGenericFormatter(Type type, bool typeIsReferenceOrContainsReferences)
		{
			return null;
		}

		private static Type TryCreateGenericFormatterType(Type type, IDictionary<Type, Type> knownTypes)
		{
			return null;
		}

		private static Type TryCreateGenericCollectionFormatterType(Type type)
		{
			return null;
		}

		internal static void RegisterWellKnownTypesFormatters()
		{
		}
	}
}
